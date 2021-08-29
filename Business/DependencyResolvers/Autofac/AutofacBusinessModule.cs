using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        //Module bizim interface'in karşılığı budur, soyutun karşılığı budur
        // dediğimiz yerdir.
        protected override void Load(ContainerBuilder builder)
        {
            //Birisi eğer IProductService şeklinde bir şey isterse biz ona ProductManager şeklinde bir şey vereceğiz.
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
        }
    }
}