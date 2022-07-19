using MWG_Ecommerce.Data;
using MWG_Ecommerce.DTO;
using MWG_Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MWG_Ecommerce.Service
{
    public class ProductService
    {
        private readonly ShoppingonlineContext _context;

        public ProductService(ShoppingonlineContext context)
        {
            _context = context;
        }

        public ProductService()
        {
        }

        public ProductPagingDTO GetProducts(int currentPage)
        {
            int maxRows = 10;
            var products = _context.Products.ToList();

            ProductPagingDTO productPaging = new()
            {
                Products = products.OrderBy(product => product.ProductId)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows).ToList()
            };

            double pageCount = (double)((decimal)products.Count / Convert.ToDecimal(maxRows));

            productPaging.PageCount = (int)Math.Ceiling(pageCount);

            productPaging.CurrentPageIndex = currentPage;

            return productPaging;
        }

        public List<Product> GetAllProduct()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetAllProductSameCategory(int idca)
        {
            return _context.Products.Where(o => o.CategoryId == idca).ToList();
        }

        public Product FindProductById(int idProduct)
        {
            return _context.Products.Find(idProduct);
        }

        public async Task<bool> AddProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            try
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public int CountProductOfCategory_1()
        {
            int list = _context.Products
                .Include(o => o.Category)
                .Where(o => o.CategoryId == 1)
                .Count();
            return list;
        }

        public int CountProductOfCategory_2()
        {
            int list = _context.Products
                .Include(o => o.Category)
                .Where(o => o.CategoryId == 2)
                .Count();
            return list;
        }

        public int CountProductOfCategory_3()
        {
            int list = _context.Products
                .Include(o => o.Category)
                .Where(o => o.CategoryId == 3)
                .Count();
            return list;
        }

        public int CountProductOfCategory_4()
        {
            int list = _context.Products
                .Include(o => o.Category)
                .Where(o => o.CategoryId == 4)
                .Count();
            return list;
        }

        public int CountProductOfCategory_5()
        {
            int list = _context.Products
                .Include(o => o.Category)
                .Where(o => o.CategoryId == 5)
                .Count();
            return list;
        }

        public int CountProductOfCategory_6()
        {
            int list = _context.Products
                .Include(o => o.Category)
                .Where(o => o.CategoryId == 6)
                .Count();
            return list;
        }

        public List<Product> GetTop12ProductView()
        {
            return _context.Products.OrderByDescending(o => o.Views).Take(12).ToList();
        }

        public List<Product> SortProductsInAscendingPrice()
        {
            return _context.Products.OrderBy(o => o.Price).ToList();
        }

        public List<Product> SortProductsInDescendingPrice()
        {
            return _context.Products.OrderByDescending(o => o.Price).ToList();
        }

        public List<Product> SortProductView()
        {
            return _context.Products.OrderByDescending(o => o.Views).ToList();
        }

        public List<Product> SearchProductUnderPrice100000()
        {
            return _context.Products.Where(o => o.Price < 100000).ToList();
        }



    }
}
