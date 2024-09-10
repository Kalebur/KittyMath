using System;

namespace TimeConverter
{
    public class UnitAssigner
    {
        private readonly UnitConverter _unitConverter;

        public UnitAssigner(UnitConverter timeConverter)
        {
            _unitConverter = timeConverter;
        }

        public void AssignConvertedValues(Dictionary<char, decimal> unitsByUnitCode, char majorUnit, char minorUnit, decimal majorValue, Func<decimal, decimal> convertToMinor)
        {
            var convertedValues = _unitConverter.ConvertValues(majorValue, convertToMinor);
            unitsByUnitCode[majorUnit] = convertedValues.major;
            unitsByUnitCode[minorUnit] = convertedValues.minor;
        }
    }

}
