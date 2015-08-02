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
    public class ProductVariantImageFileMapViewModel : IIdentifiable
    {

        [DataMember(Name="productVariantId")]
        public Guid ProductVariantId { get; set; }

        [DataMember(Name="imageFileId")]
        public Guid ImageFileId { get; set; }

        [ScaffoldColumn(false)]
        public Guid EntityId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
