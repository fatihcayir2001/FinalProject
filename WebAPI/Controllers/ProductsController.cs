using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //---> ATTRIBUTE Bir class ile ilgili bilgi verme, imzalama yöntemidir
    //isimlendirme standartanı göre çağrırken controlleri yazmayız
    //10.satırda nasıl çağrıcağımız var
    //bu kodu api/products yazarak çağrabiliriz
    public class ProductsController : ControllerBase
    {
        //Loosely coupled -- Gevşek bağlılık
        //IoC Container -- Inersion of Controller   
        //IoC container bellekte kullkanılacak manager,servisi newleyip tutmak diyebiliriz
        //Startup da 33 ve 34.satıra bakabilirsin (AddSingleon ile yaptık)
        
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]   
        public List<Product> Get()
        {
            return _productService.GetAll().Data;
            
        }

    }
}
