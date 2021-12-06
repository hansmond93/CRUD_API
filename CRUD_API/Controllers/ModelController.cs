using CRUD_API.Dto;
using CRUD_API.Helpers;
using CRUD_Core.Entities;
using CRUD_Core.Interfaces;
using CRUD_Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;
        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        /// <summary>
        /// Creates a Model Entity and returns the created model.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ModelToReturnDto>> CreateModel(ModelToCreateDto model)
        {

            var modelToCreate = new Model
            {
                Description = model.Description,
                IsCompleted = model.IsCompleted,
                Title = model.Title
            };

            var created = await _modelService.CreateModelAsync(modelToCreate);

            //can return modelToREturnDto here but since it is the same properties with Model entity
            //it's fine to return the model entity in this case
            if (created == null) return BadRequest(new { Message = "Problem creating model" });

            return Ok(created);
        }

        /// <summary>
        /// Gets all Model Entities
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Model>>> GetAllModels()
        {
            var models = await _modelService.GetModelsAsync();

            return Ok(models);
        }

        /// <summary>
        /// Gets all Model Entities with different parameters/ filters/ sorting / pagination
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<Pagination<IReadOnlyList<Model>>>> GetModels([FromQuery]ModelSpecParams param)
        {
            var spec = new ModelWithFilterSpecification(param);

            var countSpec = new ModelWithFilterForCountSpecification(param);

            var models = await _modelService.GetModelsAsync(spec);

            var totalItems = await _modelService.CountModelAsync(countSpec);

            return Ok(new Pagination<Model>(param.PageIndex, param.PageSize, totalItems, models));
        }

        /// <summary>
        /// updates a single Model entity by Id
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<Model>> UpdateModel(ModelToCreateDto model, int id)
        {
            var modelToUpdate = new Model
            {
                Description = model.Description,
                Title = model.Title,
                IsCompleted = model.IsCompleted
            };

            var updatedModel = await _modelService.UpdateModelAsync(modelToUpdate, id);

            if (updatedModel == null) return BadRequest(new { Message = "Problem updating model" });

            return Ok(updatedModel);

        }

        /// <summary>
        /// Deletes a single Model entity by Id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteModel(int id)
        {
            var deleted = await _modelService.DeleteModelAsync(id);

            if (deleted) return Ok(deleted);

            return BadRequest(new { Message = "Problem deleting model" });
        }
    }
}
