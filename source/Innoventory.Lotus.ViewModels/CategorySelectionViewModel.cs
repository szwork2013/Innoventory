using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class CategorySelectionViewModel
    {
        [DataMember(Name="category")]
        public CategoryViewModel CategoryVM { get; set; }

        [DataMember(Name="isSelected")]
        public bool IsSelected { get; set; }

    }
}
