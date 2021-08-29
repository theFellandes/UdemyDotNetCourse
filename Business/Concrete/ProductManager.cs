﻿using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(
                _productDal
                .GetList(p => p.CategoryId == categoryId)
                .ToList()
                );
        }

        public IResult Add(Product product)
        {
            //Business codes, iş kuralları buraya gelir.
            //validasyon kodları gibi
            _productDal.Add(product);
            return new SuccessResult(Constants.Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Constants.Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Constants.Messages.ProductUpdated);
        }
    }
}