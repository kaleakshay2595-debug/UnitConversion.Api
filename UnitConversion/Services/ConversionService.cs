
using UnitConversion.Services;

namespace UnitConversion.Api.Services
{
    public class ConversionService : IConversionService
    {
        public double Convert(double value, string fromUnit, string toUnit)
        {
            fromUnit = fromUnit.Trim().ToLowerInvariant();
            toUnit = toUnit.Trim().ToLowerInvariant();

             
            string fromCategory = GetCategory(fromUnit);
            string toCategory = GetCategory(toUnit);

             
            if (fromCategory != toCategory)
            {
                throw new ArgumentException(
                    "Cannot convert between different unit categories.");
            }

             
            if (fromUnit == toUnit)
            {
                return value;
            }

            double baseValue;

             
            if (fromUnit == "meter")
            {
                baseValue = value;
            }
            else if (fromUnit == "kilometer")
            {
                baseValue = value * 1000;
            }
            else if (fromUnit == "foot")
            {
                baseValue = value * 0.3048;
            }
            else if (fromUnit == "celsius")
            {
                baseValue = value;
            }
            else if (fromUnit == "fahrenheit")
            {
                baseValue = (value - 32) * 5 / 9;
            }
            else if (fromUnit == "kelvin")
            {
                baseValue = value - 273.15;
            }
            else if (fromUnit == "kilogram")
            {
                baseValue = value;
            }
            else if (fromUnit == "gram")
            {
                baseValue = value / 1000;
            }
            else if (fromUnit == "pound")
            {
                baseValue = value * 0.45359237;
            }
            else
            {
                throw new ArgumentException("Source unit is not supported.");
            }

             
            if (toUnit == "meter")
            {
                return baseValue;
            }
            else if (toUnit == "kilometer")
            {
                return baseValue / 1000;
            }
            else if (toUnit == "foot")
            {
                return baseValue / 0.3048;
            }
            else if (toUnit == "celsius")
            {
                return baseValue;
            }
            else if (toUnit == "fahrenheit")
            {
                return (baseValue * 9 / 5) + 32;
            }
            else if (toUnit == "kelvin")
            {
                return baseValue + 273.15;
            }
            else if (toUnit == "kilogram")
            {
                return baseValue;
            }
            else if (toUnit == "gram")
            {
                return baseValue * 1000;
            }
            else if (toUnit == "pound")
            {
                return baseValue / 0.45359237;
            }
            else
            {
                throw new ArgumentException("Target unit is not supported.");
            }
        }

       
        private string GetCategory(string unit)
        {
            if (unit == "meter" ||
                unit == "kilometer" ||
                unit == "foot")
            {
                return "Length";
            }
            else if (unit == "celsius" ||
                     unit == "fahrenheit" ||
                     unit == "kelvin")
            {
                return "Temperature";
            }
            else if (unit == "kilogram" ||
                     unit == "gram" ||
                     unit == "pound")
            {
                return "Weight";
            }
            else
            {
                throw new ArgumentException("Unit is not supported.");
            }
        }
    }
}
