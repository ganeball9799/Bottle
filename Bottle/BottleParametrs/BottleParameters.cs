using System;
using System.Collections.Generic;
using System.Linq;

namespace BottleParametrs
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

            var nameValue = new List<string>();

            nameValue.Add("Длина бутылки");
            nameValue.Add("Длина основания");
            nameValue.Add("Длина горлышка");
            nameValue.Add("Диаметр основания");
            nameValue.Add("Диаметр горлышка");


            const double minLengthFullBottle = 100;
            const double maxLengthFullBottle = 250;

            const double minBaseLength = 2 * minLengthFullBottle / 3;
            var maxBaseLength = 2 * lengthFullBottle / 3;

            const double minBottleneckLength = minLengthFullBottle / 5;
            var maxBottleneckLength = lengthFullBottle / 5;

            const double minBaseDiameter = 35;
            const double maxBaseDiameter = 65;

            const double minBottleneckDiameter = 15;
            var maxBottleneckDiameter = 26;
            
            ValidateValue(minLengthFullBottle, maxLengthFullBottle,lengthFullBottle,
                nameValue[0], errors);
            ValidateValue(minBaseLength, maxBaseLength, baseLength, 
                nameValue[1], errors);
            ValidateValue(minBottleneckLength, maxBottleneckLength, bottleneckLength, 
                nameValue[2], errors);
            ValidateValue(minBaseDiameter, maxBaseDiameter, baseDiameter, 
                nameValue[3], errors);
            ValidateValue(minBottleneckDiameter, maxBottleneckDiameter, bottleneckDiameter,
                nameValue[4], errors);

            return errors;
        }

        /// <summary>
        /// Метод проверки данных на вхождение в диапазон
        /// </summary>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <param name="value">Текущее значение</param>
        /// <param name="name">Имя параметра</param>
        /// <param name="error">Лист с ошибками</param>
        private void ValidateValue(double min, double max, double value, string name, List<string> error)
        {
            if (min > value || value > max)
            {
                error.Add($"{name} не в ходит в диапазон {min} - {max} мм");
            }
        }

        /// Получает общее сообщение об ошибке из списка ошибок.
        /// </summary>
        /// <param name="errorMessages">Сообщения об ошибках.</param>
        /// <returns>Общее сообщение.</returns>
        private string GetUnitedErrorMessage(IEnumerable<string> errorMessages)
        {
            var result = "Параметры некорректны:\n\n";

            result += string.Join(";\n\n", errorMessages);
            result += '.';

            return result;
        }
    }
}