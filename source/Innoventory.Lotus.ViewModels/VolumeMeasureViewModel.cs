using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.Core.Contracts;

namespace Innoventory.Lotus.ViewModels
{
    public class VolumeMeasureViewModel:IIdentifiable
    {
        [Key]
        public Guid VolumeMeasureId { get; set; }
        [StringLength(50)]
        public string VolumeMeasureName { get; set; }
        [StringLength(5)]
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
