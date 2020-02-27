using AspnetCoreWithBugs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreWithBugs.Data
{
    public class ProductDB
    {
        /// <summary>
        /// Create a product to add to ProductDB
        /// </summary>
        /// <param name="p"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<Product> Create(Product p, ProductContext context)
        {
            await context.AddAsync(p);
            await context.SaveChangesAsync();
            return p;
        }

        /// <summary>
        /// Returns a single clothing item, or null if there is no match.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<Product> GetProductByID(int id, ProductContext context)
            {
                Product p = await (from product in context.Product
                                   where product.ProductId == id
                                   select product).SingleOrDefaultAsync();

                return p;
            }

        /// <summary>
        /// Returns the quantity/count of unique clothing items in the DB
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async static Task<int> GetNumProducts(ProductContext context)
        {
            return await context.Product.CountAsync();
        }

        /// <summary>
        /// Updates a product from the DB
        /// </summary>
        /// <param name="p"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task Update(Product p, ProductContext context)
        {
            await context.AddAsync(p);
            context.Entry(p).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a product from the DB
        /// </summary>
        /// <param name="p"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task Delete(Product p, ProductContext context)
        {
            await context.AddAsync(p);
            context.Entry(p).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}
