using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces.Repositories;
using Delivery.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Delivery.Service
{
    public class SubCategoryService : BaseService<SubCategory>, ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        public SubCategoryService(ISubCategoryRepository subCategoryRepository) : base(subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        
    }
}