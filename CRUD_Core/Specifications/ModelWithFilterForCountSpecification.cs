using CRUD_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Core.Specifications
{
    public class ModelWithFilterForCountSpecification : BaseSpecification<Model>
    {
        public ModelWithFilterForCountSpecification(ModelSpecParams param) :
            base(m => (!param.IsCompleted.HasValue || m.IsCompleted == param.IsCompleted)
               && (string.IsNullOrEmpty(param.Search) || m.Title.ToLower().Contains(param.Search) || m.Description.ToLower().Contains(param.Search)))
        {

        }
    }
}
