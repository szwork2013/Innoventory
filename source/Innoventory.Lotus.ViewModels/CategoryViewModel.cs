using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class CategoryViewModel
    {
        [ScaffoldColumn(false)]
        public Guid CategoryId { get; set; }


        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        [DisplayName("Category Description")]
        public string CategoryDescription { get; set; }

    }
}
