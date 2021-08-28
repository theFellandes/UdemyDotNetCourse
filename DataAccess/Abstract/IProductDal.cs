using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //interface interface'i inherit etti, gönderilen tipe göre işlemleri barındırıyor.
    public interface IProductDal : IEntityRepository<Product>
    {
     //Tamamen IProductDal'a özel işlemleri burada yazıyoruz Join gibi   
    }
}