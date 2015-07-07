using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{

    public class SubCategoryViewModel
    {

        public Guid SubCategoryId { get; set; }



        public string SubCategoryName { get; set; }

        public string SubCategoryDescription { get; set; }
    }
}
