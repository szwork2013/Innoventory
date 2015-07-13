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

        [DisplayName("Item Type")]
        [DataMember]
        public int ItemType { get; set; }

        [DisplayName("Item Type Value")]
        [DataMember]
        public string ItemTypeValue { get; set; }

        [DisplayName("Product Name")]
        [DataMember]
        public string ProductName { get; set; }

        [DisplayName("Description")]
        [DataMember]
        public string Description { get; set; }

        [DisplayName("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

        [DisplayName("Category ID")]
        [DataMember]
        public Guid CategoryId { get; set; }

        [DisplayName("Category Name")]
        [DataMember]
        public string CategoryName { get; set; }

        [DisplayName("Sub Category ID")]
        [DataMember]
        public Guid SubCategoryId { get; set; }

        [DisplayName("Sub Category Name")]
        [DataMember]
        public string SubCategoryName { get; set; }

        [DisplayName("Re-Order Point")]
        [DataMember]
        public decimal? ReorderPoint { get; set; }

        [DisplayName("Re-Order Quantity")]
        [DataMember]
        public decimal? ReorderQuantity { get; set; }

        [DisplayName("Unit ID")]
        [DataMember]
        public Guid UnitId { get; set; }

        [DisplayName("Unit")]
        [DataMember]
        public string Unit { get; set; }

        [DisplayName("Image ID")]
        [DataMember]
        public Guid? ImageId { get; set; }

        [DisplayName("Sales Order Unit ID")]
        [DataMember]
        public Guid SalesOrderUnitId { get; set; }

        [DisplayName("Sales Order Unit")]
        [DataMember]
        public string SalesOrderUnit { get; set; }

        [DisplayName("Purchase Order Unit ID")]
        [DataMember]
        public Guid PurchaseOrderUnitId { get; set; }

        [DisplayName("Purschase Order Unit")]
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
