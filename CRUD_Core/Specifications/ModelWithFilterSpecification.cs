using CRUD_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Core.Specifications
{
    public class ModelWithFilterSpecification : BaseSpecification<Model>
    {
        public ModelWithFilterSpecification(ModelSpecParams param) : 
            base (m => (!param.IsCompleted.HasValue || m.IsCompleted == param.IsCompleted)
                && (string.IsNullOrEmpty(param.Search) || m.Title.ToLower().Contains(param.Search) || m.Description.ToLower().Contains(param.Search)))
        {
            ApplyPaging(param.PageSize * (param.PageIndex - 1), param.PageSize);

            if (!string.IsNullOrEmpty(param.Sort))
            {
                switch (param.Sort)
                {
                    case "idAsc":
                        AddOrderBy(p => p.Id);
                        break;
                    case "idDesc":
                        AddOrderByDescending(p => p.Id);
                        break;
                    case "titleAsc":
                        AddOrderBy(p => p.Title);
                        break;
                    case "titleDesc":
                        AddOrderByDescending(p => p.Title);
                        break;
                    default:
                        AddOrderBy(n => n.Id);
                        break;

                }
            }
        }
    }
}
