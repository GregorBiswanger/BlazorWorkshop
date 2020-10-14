using PetShop.Shared;
using System.Collections.Generic;

namespace PetShop.Api.Models
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int jobCategoryId);
    }
}
