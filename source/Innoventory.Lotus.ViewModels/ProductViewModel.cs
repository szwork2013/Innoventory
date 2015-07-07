using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Innoventory.Lotus.ViewModels
{

    public class ProductViewModel
    {
        public Guid ProductId { get; set; }



        public int ItemType { get; set; }


        public string ProductName { get; set; }


        public string Description { get; set; }


        public string Remarks { get; set; }


        public Guid CategoryId { get; set; }


        public string CategoryName { get; set; }

        public Guid SubCategoryId { get; set; }


        public string SubCategoryName { get; set; }


        public decimal? ReorderPoint { get; set; }


        public decimal? ReorderQuantity { get; set; }


        public Guid UnitId { get; set; }


        public string Unit { get; set; }

        public Guid? ImageId { get; set; }

        public Guid SalesOrderUnitId { get; set; }

        public string SalesOrderUnit { get; set; }

        public Guid PurchaseOrderUnitId { get; set; }
        
        public Guid PurchaseOrderUnitName { get; set; }


    }
}
