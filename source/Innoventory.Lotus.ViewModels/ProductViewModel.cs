using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel;
using Innoventory.Lotus.Core.Contracts;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class ProductViewModel:IIdentifiable 
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public Guid ProductId { get; set; }


        [DataMember]
        public int ItemType { get; set; }

        [DataMember]
        public string ItemTypeValue { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public Guid CategoryId { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public Guid SubCategoryId { get; set; }

        [DataMember]

        public string SubCategoryName { get; set; }


        [DataMember]
        public decimal? ReorderPoint { get; set; }

        [DataMember]
        public decimal? ReorderQuantity { get; set; }

        [DataMember]
        public Guid UnitId { get; set; }

        [DataMember]
        public string Unit { get; set; }

        [DataMember]
        public Guid? ImageId { get; set; }

        [DataMember]
        public Guid SalesOrderUnitId { get; set; }

        [DataMember]
        public string SalesOrderUnit { get; set; }

        [DataMember]
        public Guid PurchaseOrderUnitId { get; set; }

        [DataMember]
        public Guid PurchaseOrderUnitName { get; set; }



        public Guid EntityId
        {
            get
            {
                return ProductId;
            }
            set
            {
                ProductId = value;
            }
        }
    }
}
