using System;
using System.Collections.Generic;
using System.Linq;

namespace BottleNew
{
    /// <summary>
    /// Параметры бутылки.
    /// </summary>
    public class BottleParameters
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="baseDiameter">Диаметр основания.</param>
        /// <param name="baseLength">Длина основания.</param>
        /// <param name="bottleneckDiameter">Диаметр горлышка.</param>
        /// <param name="bottleneckLength">Длина горлышка.</param>
        /// <param name="lengthFullBottle">Длина бутылки.</param>
        public BottleParameters(double baseDiameter, double baseLength, double bottleneckDiameter,
            double bottleneckLength, double lengthFullBottle)
        {
            var errors = Validate(baseDiameter, baseLength, 
                bottleneckDiameter, bottleneckLength, lengthFullBottle);

            if (errors.Any())
                throw new ArgumentException(GetUnitedErrorMessage(errors));

            BaseDiameter = baseDiameter;
            BaseLength = baseLength;
            BottleneckDiameter = bottleneckDiameter;
            BottleneckLength = bottleneckLength;
            LengthFullBottle = lengthFullBottle;
        }

        /// <summary>
        /// Диаметр основания.
        /// </summary>
        public double BaseDiameter { get; }

        /// <summary>
        /// Длина основания.
        /// </summary>
        public double BaseLength { get; }

        /// <summary>
        /// Диаметр горлышка.
        /// </summary>
        public double BottleneckDiameter { get; }

        /// <summary>
        /// Длина горлышка.
        /// </summary>
        public double BottleneckLength { get; }

        /// <summary>
        /// Длина всей бутылки.
        /// </summary>
        public double LengthFullBottle { get; }

        /// <summary>
        /// Проверяет полученные параметры на корректность.
        /// </summary>
        /// <param name="baseDiameter">Диаметр основания.</param>
        /// <param name="baseLength">Длина основания.</param>
        /// <param name="bottleneckDiameter">Диаметр горлышка.</param>
        /// <param name="bottleneckLength">Длина горлышка.</param>
        /// <param name="lengthFullBottle">Длина бутылки.</param>
        /// <returns>Сообщения об ошибках.</returns>
        private List<string> Validate(double baseDiameter, double baseLength, double bottleneckDiameter,
            double bottleneckLength, double lengthFullBottle)
        {
            var errors = new List<string>();

            const double minLengthFullBottle = 100;
            const double maxLengthFullBottle = 250;

            const double minBaseLength = 2 * minLengthFullBottle / 3;
            var maxBaseLength = 2 * lengthFullBottle / 3;

            const double minBottleneckLength = minLengthFullBottle / 5;
            var maxBottleneckLength = lengthFullBottle / 5;

            const double minBaseDiameter = 25;
            const double maxBaseDiameter = 65;

            const double minBottleneckDiameter = 17;
            var maxBottleneckDiameter = 26;
            //TODO: Duplication
             //TODO: RSDN
            if (lengthFullBottle < minLengthFullBottle)
                errors.Add($"Длина бутылки меньше минимальной равной {minLengthFullBottle} мм");
            if (lengthFullBottle > maxLengthFullBottle)
                errors.Add($"Длина бутылки больше максимальной равной {maxLengthFullBottle} мм");

            if (baseLength < minBaseLength)
                errors.Add($"Длина основания меньше минимальной равной {minBaseLength} мм");
            if (baseLength > maxBaseLength)
                errors.Add($"Длина основания больше максимальной равной {maxBaseLength} мм");

            if (bottleneckLength < minBottleneckLength)
                errors.Add($"Длина горлышка меньше минимальной равной {minBottleneckLength} мм");
            if (bottleneckLength > maxBottleneckLength)
                errors.Add($"Длина горлышка больше максимальной равной {maxBottleneckLength} мм");

            if (baseDiameter < minBaseDiameter)
                errors.Add($"Диаметр основания меньше минимального равного {minBaseDiameter} мм");
            if (baseDiameter > maxBaseDiameter)
                errors.Add($"- Диаметр основания больше максимального равного {maxBaseDiameter} мм");

            if (bottleneckDiameter < minBottleneckDiameter)
                errors.Add($"Диаметр горлышка меньше минимального равного {minBottleneckDiameter} мм");
            if (bottleneckDiameter > maxBottleneckDiameter)
                errors.Add($"- Диаметр горлышка больше максимального равного {maxBottleneckDiameter} мм");

            return errors;
        }

        /// <summary>
        /// Получает общее сообщение об ошибке из списка ошибок.
        /// </summary>
        /// <param name="errorMessages">Сообщения об ошибках.</param>
        /// <returns>Общее сообщение.</returns>
        private string GetUnitedErrorMessage(IEnumerable<string> errorMessages)
        {
            var result = "Параметры некорректны:\n\n";

            //TODO: RSDN 
            //TODO: https://docs.microsoft.com/ru-ru/dotnet/api/system.string.join?view=net-5.0
            foreach (var errorMessage in errorMessages)
                result += errorMessage + ";\n\n";

            result = result.Substring(0, result.Length - 3);

            result += '.';

            return result;
        }
    }
}