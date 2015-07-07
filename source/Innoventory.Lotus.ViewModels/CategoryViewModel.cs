using Innoventory.Lotus.Domain.DataEntities;
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
    public class CategoryViewModel
    {

        [ScaffoldColumn(false)]
        [DataMember]
        public Guid CategoryId { get; set; }


        [DisplayName("Category Name")]
        [DataMember]
        public string CategoryName { get; set; }

        [DisplayName("Category Description")]
        [DataMember]
        public string Description { get; set; }

    }
}
