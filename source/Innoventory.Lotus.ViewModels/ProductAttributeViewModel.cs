using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class ProductAttributeViewModel
    {
        
        public Guid ProductAttributeId { get; set; }

        
        public string AttributeName { get; set; }

        
        public string AttributeDescription { get; set; }

    }
}
