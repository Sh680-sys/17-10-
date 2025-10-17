using KSHOP1.DAL.Data;
using KSHOP1.DAL.Models;
using KSHOP1.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSHOP1.DAL.Repositories.Classes
{
    public class BrandRepository : GeneicRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
