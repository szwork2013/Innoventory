﻿using Innoventory.Lotus.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class CustomerProductVariantPriceViewModel : IIdentifiable
    {

        public Guid CustomerProductVariantPriceId { get; set; }

        public Guid CustomerId { get; set; }
        public Guid ProductVariantId { get; set; }
        public int PricingType { get; set; }
        public decimal PricingValue { get; set; }


        public CustomerViewModel Customer { get; set; }



        public ProductVariantViewModel ProductVariant { get; set; }


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
