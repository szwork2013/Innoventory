﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Innoventory.Lotus.Core.Contracts;

namespace Innoventory.Lotus.ViewModels
{
    public class PurchaseReturnItemViewModel:IIdentifiable
    {

        [ScaffoldColumn(false)]
        public Guid PurchaseReturnItemId { get; set; }
        public Guid PurchaseReturnId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Price { get; set; }

        public PurchaseReturnViewModel PurchaseReturn { get; set; }

        public  ProductVariantViewModel ProductVariant { get; set; }


        [ScaffoldColumn(false)]
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
