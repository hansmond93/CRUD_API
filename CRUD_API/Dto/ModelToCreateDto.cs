using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUD_API.Dto
{
    public class ModelToCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage ="Length can not be more than 1000 words")]
        public string Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; }
    }
}
