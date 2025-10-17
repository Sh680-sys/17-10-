using Azure;
using Azure.Core;
using KSHOP1.DAL.DTO.Requests;
using KSHOP1.DAL.DTO.Responses;
using KSHOP1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSHOP1.BLL.Services.Interfaces
{
    public interface IBrandService : IGenericService<BrandRequest, BrandResponse, Brand>
    {
    }



}
