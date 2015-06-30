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
        public Guid VolumeMeasureMappingId { get; set; }
        public Guid PrimaryVMId { get; set; }
        public Guid SecondaryVMId { get; set; }
        public decimal Ratio { get; set; }

        [ForeignKey("PrimaryVMId")]
        public VolumeMeasure PrimaryVM { get; set; }

        [ForeignKey("SecondaryVMId")]
        public VolumeMeasure SecondaryVM { get; set; }

    }
}
