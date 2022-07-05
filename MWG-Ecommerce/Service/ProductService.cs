using MWG_Ecommerce.Data;
using MWG_Ecommerce.DTO;
using MWG_Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWG_Ecommerce.Service
{
    public class ProductService
    {
        private readonly ShoppingonlineContext _context;

        public ProductService(ShoppingonlineContext context)
        {
            _context = context;
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
    }
}
