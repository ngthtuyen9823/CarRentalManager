using CarRentalManager.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.services
{
    public class VariableService
    {
        public VariableService() { }

        public int parseStringToInt(string value)
        {
            try
            {
                int result;
                int.TryParse(value, out result);
                return result;
            }
            catch {
                return 0;
            }
        }
        public T parseStringToEnum<T>(string value)
        {
            try
            {
                T result = (T)Enum.Parse(typeof(T), value);
                if (!Enum.IsDefined(typeof(T), result)) return default(T);
                return result;
            }
            catch
            {
                return default(T);
            }
        }
    }
}
