using CRUD_Core.Entities;
using CRUD_Core.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Core.Interfaces
{
    public interface IModelService
    {
        Task<Model> GetModelByIdAsync(int id);

        Task<IReadOnlyList<Model>> GetModelsAsync();

        Task<IReadOnlyList<Model>> GetModelsAsync(ISpecification<Model> modelSpec);

        Task<int> CountModelAsync(ISpecification<Model> modesSpec);

        Task<Model> CreateModelAsync(Model model);

        Task<Model> UpdateModelAsync(Model model, int id);

        Task<bool> DeleteModelAsync(int id);

    }
}
