using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class ProductFilterOption
    {
        [DataMember(Name = "category")]
        public Guid Category { get; set; }

        [DataMember(Name = "subCategory")]
        public Guid SubCategory { get; set; }

        [DataMember(Name = "searchString")]
        public string SearchString { get; set; }
    }

    [DataContract]
    public class SortOption
    {
        [DataMember(Name = "productSortField")]
        public int ProductSortField { get; set; }


        [DataMember(Name = "sortDirection")]
        public int SortDirection { get; set; }
    }


    public enum SortField
    {
        ProductName = 1,
        Category = 2,
        SubCategory = 3,
        Price = 4,

    }

    public enum SortDirection
    {
        Asc = 0,
        Desc = 1
    }
}
