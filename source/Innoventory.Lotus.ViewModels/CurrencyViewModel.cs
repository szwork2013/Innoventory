using Innoventory.Lotus.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Innoventory.Lotus.ViewModels
{
    public class CurrencyViewModel:IIdentifiable
    {
        
        public Guid CurrencyID { get; set; }

        public string CurrencyCode { get; set; }
        

        public string CurrencySymbol { get; set; }
        

        public string CurrencyFullName { get; set; }





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
