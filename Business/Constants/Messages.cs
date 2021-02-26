using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInValid = "Ürün ismi Geçersiz.";
        internal static string MaintenanceTime = "Sistem Bakımda";
        internal static string ProductListed = "Ürünler Listelendi";
        internal static string ProductCountofCategoryError = "Category ID 10'dan fazla ürün eklenemez";
        internal static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";

        public static string CategoryLimitExceeded = "Kategori Limiti Aşıldı. 15'den fazla eklenemez.";
    }
}
