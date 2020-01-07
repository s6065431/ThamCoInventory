using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Inventorydata.data
{
    public static class InventoryDbInitialiser
    {
        public static async Task SeedTestData(InventoryDbContext context, IServiceProvider services)
        {

            if (context.StockRequests.Any())
            {
                //db seems to be seeded
                return;
            }

            var permissions = new List<Permissions>
            {
                new Permissions {Title = "Big Boy Permissions"},
                new Permissions {Title = "Little Boy Permissions"}
            };

            permissions.ForEach(p => context.Permission.Add(p));

            await context.SaveChangesAsync();

            var staff = new List<Staff>
            {
                new Staff { Permissions = permissions[0] },
                new Staff { Permissions = permissions[1] }
            };

            staff.ForEach(s => context.Staffs.Add(s));

            await context.SaveChangesAsync();

            var products = new List<Product>
            {
                new Product { Name = "Earphones", Quantity = 9},
                new Product { Name = "Mug", Quantity = 70 }
            };

            products.ForEach(x => context.Products.Add(x));

            await context.SaveChangesAsync();

            var requests = new List<StockRequest>
            {
                new StockRequest {Product = products[0], Staff = staff[0], ApprovalStatus = true, RequestedQuantity = 30 },
                new StockRequest {Product = products[1], Staff = staff[1], ApprovalStatus = false, RequestedQuantity = 20  }
            };

            requests.ForEach(x => context.StockRequests.Add(x));

            await context.SaveChangesAsync();
        }
    }
}
       

    

