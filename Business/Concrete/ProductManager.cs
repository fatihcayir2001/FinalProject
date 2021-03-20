using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Cross_Cutting_Concerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;


        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            //bir entitymanager kendisi hariç başkabir dal'ı enjekete edemez
            //o yüzden categoryservice kullandık
            _productDal = productDal;
            _categoryService = categoryService;
           
        }

       
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
            

            
        }


        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id),Messages.ProductsListed); 
        }
        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDeatils());
        }

        //[LogAspect] --> AOP yani bu kodu logla demek

        [CacheRemoveAspect("IProductService.Get")]
        //[SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //bir kategoride en fazla 10 ürün olcak
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfProductNameExists(product.ProductName),CheckMaxNumberOfCategory());

            if (result!=null)//kurala uymayan bir şey varsa onu dön
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

            
        }
        [CacheRemoveAspect("IProductService.Get")]//sadece get yazarsak heryerdeki geti siler
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfProductNameExists(product.ProductName));

            if (result != null)//kurala uymayan bir şey varsa onu dön
            {
                return result;
            }
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductAdded);

            //iş kurallarını yazarken dry prensiblerine dikkat etmeliyiz
            

        }

        private IResult CheckIfProductCountOfCategoryCorrect(int CategoryId)
        {
            var products = _productDal.GetAll(p => p.CategoryId == CategoryId);
            if (products.Count >= 100)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
            
        }

        private IResult CheckMaxNumberOfCategory()
        {
            int numberOfCategory = _categoryService.GetAll().Data.Count();
            if (numberOfCategory>15)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);
            if (product.UnitPrice<10)
            {
                throw new Exception("");
            }

            Add(product);
            return null;
        }
    }
}
