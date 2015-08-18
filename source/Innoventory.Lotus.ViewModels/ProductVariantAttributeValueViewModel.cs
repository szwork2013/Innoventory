using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.Core.Contracts;
using System.Runtime.Serialization;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class ProductVariantAttributeValueViewModel
    {

        [DataMember(Name = "productVariantId")]
        public Guid ProductVariantId { get; set; }

        [DataMember(Name = "productAttributeId")]
        public Guid ProductAttributeId { get; set; }

        [DataMember(Name = "attributeValueListId")]
        public Guid? AttributeValueListId { get; set; }

        [DataMember(Name = "productAttributeName")]
        public string ProductAttributeName { get; set; }

        [DataMember(Name = "productAttributeValue")]
        public string ProductAttributeValue { get; set; }


    }
}
