using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
   public enum EDrivingType
    {
        [Description("Tự lái")] SELF_DRIVING,
        [Description("Có tài xế")] MANNED
    }
}
