using System;

namespace TemperatureLibrary
{
    public class Calculate
    {
        private double ConstForengeiteValue { get; set; }
        private double ConstForengeiteValue2 { get; set; }
       

        private double ConvertToForengeite(double temperature)
        {
            ConstForengeiteValue = 1.8;
            ConstForengeiteValue2 = 32;
            var value = temperature * ConstForengeiteValue + ConstForengeiteValue2;
            return value;
        }
       
    }
}
