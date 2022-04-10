namespace SerapisPatient.Utils
{
    public static class NumberUtil
    {
        /// <summary>
        /// Converts double/int/string value to a Float value 
        /// </summary>
        /// <param name="value">Pass through a valid Double number</param>
        /// <returns></returns>
        public static float ToSingle(object value)
        {
            if (value is double)
            {
                double doubleVal = (double) value;
                return (float)doubleVal/100;    
            }else if(value is int)
            {
                int intVal = (int) value;
                return (float)intVal/100; 
            }else if (value is string)
            {
                string intVal = (string) value;
                return float.Parse(intVal)/100; 
            }

            return 0f;
        }
    }
}