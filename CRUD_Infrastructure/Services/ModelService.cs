using CRUD_Core.Entities;
using CRUD_Core.Interfaces;
using CRUD_Core.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Infrastructure.Services
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CountModelAsync(ISpecification<Model> modelSpec)
        {
            var totalitems = await _unitOfWork.Repository<Model>().CountAsync(modelSpec);

            return totalitems;
        }

        public async Task<Model> CreateModelAsync(Model model)
        {
            _unitOfWork.Repository<Model>().Add(model);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;

            return model;
        }

        public async Task<bool> DeleteModelAsync(int id)
        {
            var model = await GetModelByIdAsync(id);
            if (model != null)
            {
                _unitOfWork.Repository<Model>().Delete(model);
                var result = await _unitOfWork.Complete();
                if (result <= 0) return false;

                return true;
            }

            return false;
        }

        public async Task<Model> GetModelByIdAsync(int id)
        {
            var model = await _unitOfWork.Repository<Model>().GetByIdAsync(id);
            if (model != null) return model;

            return null;
        }

        public async Task<IReadOnlyList<Model>> GetModelsAsync()
        {
            var models = await _unitOfWork.Repository<Model>().ListAllAsync();

            return models;
        }

        public async Task<IReadOnlyList<Model>> GetModelsAsync(ISpecification<Model> modelSpec)
        {
            var models = await _unitOfWork.Repository<Model>().ListAsync(modelSpec);

            return models;
        }

        public async Task<Model> UpdateModelAsync(Model model, int id)
        {
            var modelfromDb = await GetModelByIdAsync(id);

            if (modelfromDb != null)
            {
                modelfromDb.Description = model.Description;
                modelfromDb.Title = model.Title;
                modelfromDb.IsCompleted = model.IsCompleted;

                _unitOfWork.Repository<Model>().Update(modelfromDb);
                var result = await _unitOfWork.Complete();

                if (result <= 0) return null;

                return modelfromDb;
            }

            return null;

        }
    }
}
