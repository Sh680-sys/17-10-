using KSHOP1.BLL.Services.Clasess;
using KSHOP1.BLL.Services.Interfaces;
using KSHOP1.DAL.DTO.Requests;
using KSHOP1.DAL.DTO.Responses;
using KSHOP1.DAL.Models;
using KSHOP1.DAL.Repositories.Interfaces;

namespace KSHOP1.BLL.Services.Clasess 
{
    public class BrandService : GenericService<BrandRequest, BrandResponse, Brand>, IBrandService
    {
        public BrandService(IBrandRepository repository) : base(repository)
        {
        }
    }
}

