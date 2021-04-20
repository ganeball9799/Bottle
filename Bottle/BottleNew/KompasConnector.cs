using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Kompas6API5;

namespace BottleNew
{
    /// <summary>
    /// Соединитель с КОМПАС-3D.
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Экземпляр КОМПАС-3D.
        /// </summary>
        private KompasObject _instance;

        /// <summary>
        /// Запускает КОМПАС.
        /// </summary>
        public void Start()
        {

            var recievingResult = GetActiveKompas(out var kompas);
            if (!recievingResult)
            {
                var creationResult = CreateCompasInstance(out kompas);
                if (!creationResult)
                {
                    throw new ArgumentException(
                        "Не удалось создать новый экземпляр КОМПАС-3D."
                    );
                }
            }
            kompas.Visible = true;
            kompas.ActivateControllerAPI();
            _instance = kompas;
        }

        /// <summary>
        /// Подключение к открытому Компасу
        /// </summary>
        /// <param name="kompas"></param>
        /// <returns></returns>
        private bool GetActiveKompas(out KompasObject kompas)
        {
            kompas = null;
            try
            {
                kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                return true;
            }
            catch (COMException)
            {
                return false;
            }
        }


        /// <summary>
        /// Открытие нового компаса
        /// </summary>
        /// <param name="kompas"></param>
        /// <returns></returns>
        private bool CreateCompasInstance(out KompasObject kompas)
        {
            try
            {
                var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompas = (KompasObject)Activator.CreateInstance(type);
                return true;
            }
            catch (COMException)
            {
                kompas = null;
                return false;
            }
        }

        /// <summary>
        /// Создает документ в КОМПАС-3D.
        /// </summary>
        public ksDocument3D CreateDocument3D()
        {
            ksDocument3D document3D = _instance.Document3D();
            document3D.Create(false, false);
            return document3D;
        }
    }
}