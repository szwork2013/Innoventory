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
    public class VolumeMeasureViewModel:IIdentifiable
    {
        [Key]
        [DataMember(Name="volumeMeasureId")]
        public Guid VolumeMeasureId { get; set; }

        [StringLength(50)]
        [DataMember(Name = "volumeMeasureName")]
        public string VolumeMeasureName { get; set; }
        
        [StringLength(5)]
        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }



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
