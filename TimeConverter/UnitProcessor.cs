using System;
using System.Text.RegularExpressions;

namespace TimeConverter
{
    public class UnitProcessor
    {
        private readonly UnitAssigner _unitAssigner;
        private readonly UnitConverter _unitConverter;

        public UnitProcessor(UnitAssigner unitAssigner, UnitConverter unitConverter)
        {
            _unitAssigner = unitAssigner;
            _unitConverter = unitConverter;
        }

        public Dictionary<char, decimal> ConvertFromString(string input)
        {
            var valuesFromString = input.Split(" ");
            var unitsByUnitCode = new Dictionary<char, decimal>();

            decimal combinedSeconds = 0;
            foreach (var value in valuesFromString)
            {
                combinedSeconds += _unitConverter.ConvertToSeconds(value);
            }

            decimal convertedMinutes = _unitConverter.ConvertSecondsToMinutes(combinedSeconds);
            _unitAssigner.AssignConvertedValues(unitsByUnitCode, 'm', 's', convertedMinutes, _unitConverter.ConvertMinutesToSeconds);

            decimal convertedHours = _unitConverter.ConvertMinutesToHours(unitsByUnitCode['m']);
            _unitAssigner.AssignConvertedValues(unitsByUnitCode, 'h', 'm', convertedHours, _unitConverter.ConvertHoursToMinutes);

            decimal convertedDays = _unitConverter.ConvertHoursToDays(unitsByUnitCode['h']);
            _unitAssigner.AssignConvertedValues(unitsByUnitCode, 'd', 'h', convertedDays, _unitConverter.ConvertDaysToHours);

            decimal convertedMonths = _unitConverter.ConvertDaysToMonths(unitsByUnitCode['d']);
            _unitAssigner.AssignConvertedValues(unitsByUnitCode, 'M', 'd', convertedMonths, _unitConverter.ConvertMonthsToDays);

            decimal convertedYears = _unitConverter.ConvertMonthsToYears(unitsByUnitCode['M']);
            _unitAssigner.AssignConvertedValues(unitsByUnitCode, 'y', 'M', convertedYears, _unitConverter.ConvertYearsToMonths);

            //var convertedValuesAsInputString = $"{unitsByUnitCode['y']}y {unitsByUnitCode['M']}M {unitsByUnitCode['d']}d {unitsByUnitCode['h']}h {unitsByUnitCode['m']}m {unitsByUnitCode['s']}s";
            //Console.WriteLine(convertedValuesAsInputString);

            return unitsByUnitCode;
        }

        public Dictionary<char, decimal> SimpleConvertFromString(string input)
        {
            var unitsByUnitCode = new Dictionary<char, decimal>()
            {
                {'y', 0 },
                {'d', 0 },
                {'h', 0 },
                {'m', 0 },
                {'s', 0 },
            };
            var valuesToConvert = input.Split(" ");
            Regex regex = new Regex(@"(\d+)([ydhms])");

            foreach (var value in valuesToConvert)
            {
                var unitType = value.Last();
                var unitCount = int.Parse(value[0..(value.Length - 1)]);
                unitsByUnitCode[unitType] = unitCount;
            }

            var convertedValues = _unitConverter.PerformSimpleConversion(unitsByUnitCode);

            return convertedValues;
        }
    }

}
