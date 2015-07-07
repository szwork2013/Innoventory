using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class SupplierViewModel
    {

        public Guid SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string SupplierContactNo { get; set; }

        public string SupplierEmailId { get; set; }

        public Guid CurrencyId { get; set; }

        public CurrencyViewModel Currency { get; set; }




    }
}
