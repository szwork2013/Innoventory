using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Innoventory.Lotus.Core
{
    public class Constants
    {


    }


    public class EnumDescription
    {
        public Enum EnumValue { get; set; }
        public string Description { get; set; }
        public string EnumMemberName { get; set; }
    }



    public static class EnumHelper
    {

        /// <summary>
        /// Retrieve the description on the enum, e.g.
        /// [Description("Bright Pink")]
        /// BrightPink = 2,
        /// Then when you pass in the enum, it will retrieve the description
        /// </summary>
        /// <param name="en">The Enumeration</param>
        /// <returns>A string representing the friendly name</returns>
        public static EnumDescription GetDescription(Enum en)
        {
            Type type = en.GetType();

            string description = string.Empty;

            EnumDescription enumDescription = new EnumDescription()
            {
                EnumValue = en,
                EnumMemberName = en.ToString()
            };

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            description = en.ToString();

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            enumDescription.Description = description;

            return enumDescription;
        }

    }


    public enum ProductVariantType
    {
        
        General = 0,
        
        Featured = 1,

        [Description("New Arrival")]
        NewArrival = 2,

    }

    public enum AgentProductPricingType
    {
        Flat = 1,
        Percentage = 2,
    }

    public enum AddressType
    {
        [Description("User Address")]
        UserAddress = 0,

        [Description("User Shipping Address")]
        UserShippingAddress = 1,

        [Description("User Billing Address")]
        UserBillingAddress = 2,

        [Description("Agent Address")]
        AgentAddress = 3,

    }


}
