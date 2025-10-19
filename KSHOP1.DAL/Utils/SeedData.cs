using KSHOP1.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSHOP1.DAL.Utils;

public class SeedData : ISeedData
{
    private readonly ApplicationDbContext _context;
    public SeedData(ApplicationDbContext context)
    {
        _context = context;
    }

    public void DataSeeding()      
    {
        if (_context.Database.GetPendingMigrations().Any())
            _context.Database.Migrate();

        if (!_context.Categories.Any())
        {
            _context.Categories.AddRange(
                new Models.Category { Name = "Electronics", Description = "Electronic devices and gadgets" },
                new Models.Category { Name = "Books", Description = "Various kinds of books" },
                new Models.Category { Name = "Clothing", Description = "Apparel and accessories" }
            );
        }

        if (!_context.Brands.Any())
        {
            _context.Brands.AddRange(
                new Models.Brand { Name = "Apple", Description = "Electronics brand" },
                new Models.Brand { Name = "Samsung", Description = "Electronics brand" },
                new Models.Brand { Name = "Nike", Description = "Sportswear brand" }
            );
        }

        _context.SaveChanges();
    }

    public void IdentityDataSeeding()
    {
        throw new NotImplementedException();
    }
}
