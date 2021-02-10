using System;
using System.Collections.Generic;
using System.Text;
using Core.DateAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order> // Her bir satırı anlattığı için Order tekil şekilde yazılır. SqlServer'da ise ORDERS çoğul.
    {
    }
}
