using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    class SubCategoryViewModel
    {
        [ScaffoldColumn(false)]
        [DataMember(Name = "subCategoryId")]
        public Guid SubCategoryId { get; set; }


        [DisplayName("Sub Category Name")]
        [DataMember(Name = "subCategoryName")]
        [Required(ErrorMessage = "Sub Category Name is required field")]
        public string SubCategoryName { get; set; }

        [DisplayName("Sub Category Description")]
        [DataMember(Name = "subCategoryDescription")]
        public string SubCategoryDescription { get; set; }
    }
}
