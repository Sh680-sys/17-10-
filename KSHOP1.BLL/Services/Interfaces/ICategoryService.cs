using KSHOP1.DAL.DTO.Requests;
using KSHOP1.DAL.DTO.Responses;
using System.Collections.Generic;
using KSHOP1.DAL.Models;

namespace KSHOP1.BLL.Services.Interfaces
{
    public interface ICategoryService : IGenericService<CategoryRequest,CategoryResponses,Category>
    {

    }

}