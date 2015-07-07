using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class VolumeMeasureMapViewModel
    {

        public Guid VolumeMeasureMapId { get; set; }
        public Guid PrimaryVMId { get; set; }
        public Guid SecondaryVMId { get; set; }
        public decimal Ratio { get; set; }

        public VolumeMeasureViewModel PrimaryVM { get; set; }

        public VolumeMeasureViewModel SecondaryVM { get; set; }
    }
}
