using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class VolumeMeasure
    {
        [Key]
        public Guid VolumeMeasureId { get; set; }
        [StringLength(50)]
        public string VolumeMeasureName { get; set; }
        [StringLength(5)]
        public string ShortName { get; set; }


    }
}
