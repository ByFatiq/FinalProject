using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract; //Farklı klasörden class implemente etmek istiyorsak bu şekilde  eklememiz gerek. Buna İşaretleme Denir.

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


    }
}
