using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //static verince newlenmez
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string UnitPriceInvalid = "Geçersiz Fiyat";
        public static string ProductCountOfCategoryError ="bir kategoride en fzla 10 ürün olbilir";
        public static string ProductNameAlreadyExists ="Bu isim daha önceden kullanılmış";
    }
}
