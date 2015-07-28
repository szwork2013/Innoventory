using Innoventory.Lotus.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class SubCategoryAttributeMapViewModel : IIdentifiable
    {

        public Guid SubCategoryAttributeMapId { get; set; }
        public Guid CategorySubCategoryMapId { get; set; }
        public Guid ProductAttributeId { get; set; }


        public SubCategoryViewModel SubCategory { get; set; }


        public ProductAttributeViewModel ProductAttribute { get; set; }



        public Guid EntityId
        {
            get { return SubCategoryAttributeMapId; }
            set { SubCategoryAttributeMapId = value; }
        }
    }
}
