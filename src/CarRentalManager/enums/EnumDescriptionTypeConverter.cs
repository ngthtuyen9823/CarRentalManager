﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.enums
{
    public class EnumDescriptionTypeConverter : EnumConverter
    {
        public EnumDescriptionTypeConverter(Type type) : base(type) 
        {
        
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType== typeof(string))
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                if (fi != null) 
                {
                    var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    return (attributes.Length > 0 && !string.IsNullOrEmpty(attributes[0].Description)) ? attributes[0].Description : value.ToString();
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
