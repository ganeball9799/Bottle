﻿using System;
using BottleParametrs;
using NUnit.Framework;

namespace Bottle.Tests
{
    [TestFixture]
    public class BottleParameterTests
    {
        [TestCase(24, 80, 20, 22, 130, 
            TestName = "Диаметр основания меньше минимального (25).")]
        [TestCase(30, 65, 20, 22, 130, 
            TestName = "Длина основания меньше минимального (2/3 минимальной длины бутылки = 66.7).")]
        [TestCase(30, 80, 9, 22, 130, 
            TestName = "Диаметр горлышка меньше минимального (Минимальный диаметр основания/2).")]
        [TestCase(30, 80, 20, 19, 130, 
            TestName = "Длина горлышка меньше минимального (1/5 минимальной длины бутылки = 20).")]
        [TestCase(30, 80, 20, 22, 99, 
            TestName = "Длина бутылки меньше минимального (101).")]
        [TestCase(66, 80, 20, 22, 130, 
            TestName = "Диаметр основания больше максимального (65).")]
        [TestCase(30, 88, 20, 22, 130, 
            TestName = "Длина основания больше максимального (2/3 общей длины).")]
        [TestCase(30, 80, 20, 28, 130, 
            TestName = "Длина горлышка больше максимального (1/5 общей длины).")]
        [TestCase(30, 80, 20, 22, 255, 
            TestName = "Длина бутылки больше максимального (250).")]
        public void BottleParametersTest_ArgumentException(double baseDiameter, double baseLength,
            double bottleneckDiameter, double bottleneckLength, double lengthFullBottle)
        {
            Assert.Throws<ArgumentException>(() => new BottleParameters(baseDiameter, baseLength, bottleneckDiameter,
                bottleneckLength, lengthFullBottle));
        }

        [TestCase(60, 77, 18, 22, 135, 
            TestName = "Корректные параметры.")]
        public void BottleParametersTest_Correct(double baseDiameter, double baseLength,
            double bottleneckDiameter, double bottleneckLength, double lengthFullBottle)
        {
            var bottleParameters = new BottleParameters(baseDiameter, baseLength, bottleneckDiameter,
                bottleneckLength, lengthFullBottle);

            Assert.AreEqual(baseDiameter, bottleParameters.BaseDiameter);
            Assert.AreEqual(baseLength, bottleParameters.BaseLength);
            Assert.AreEqual(bottleneckDiameter, bottleParameters.BottleneckDiameter);
            Assert.AreEqual(bottleneckLength, bottleParameters.BottleneckLength);
            Assert.AreEqual(lengthFullBottle, bottleParameters.LengthFullBottle);
        }
    }
}