using KSHOP1.BLL.Services.Clasess;
using KSHOP1.BLL.Services.Interfaces;
using KSHOP1.DAL.DTO.Responses;
using KSHOP1.DAL.Models;
using KSHOP1.DAL.Repositories.Interfaces;

namespace KSHOP1.BLL.Services.Clasess 
{
    public class BrandService(IBrandRepository repository) 
        : GenericService<BrandRequest, BrandResponse, Brand>(repository), IBrandService
    {
    }
}

