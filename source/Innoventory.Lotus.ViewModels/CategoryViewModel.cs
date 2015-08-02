using Innoventory.Lotus.Core.Contracts;
using Innoventory.Lotus.Database.DataEntities;
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
    public class CategoryViewModel : IIdentifiable
    {
        //public CategoryViewModel (Category category)
        //{ }

        [ScaffoldColumn(false)]
        [DataMember(Name = "categoryId")]
        public Guid CategoryId { get; set; }


        [DisplayName("Category Name")]
        [DataMember(Name = "categoryName")]
        public string CategoryName { get; set; }

        [DisplayName("Category Description")]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public Guid EntityId
        {
            get { return CategoryId; }

            set { CategoryId = value; }
        }
    }
}
