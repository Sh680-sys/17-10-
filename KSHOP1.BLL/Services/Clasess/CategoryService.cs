using KSHOP1.BLL.Services.Interfaces;
using KSHOP1.DAL.DTO.Requests;
using KSHOP1.DAL.DTO.Responses;
using KSHOP1.DAL.Models;
using KSHOP1.DAL.Repositories.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace KSHOP1.BLL.Services.Clasess
{
    public class CategoryService : GenericService<CategoryRequest, CategoryResponses, Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository) : base(repository) { }
    }

}

