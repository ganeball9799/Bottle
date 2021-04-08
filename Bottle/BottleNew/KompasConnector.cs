using System;
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
        /// Запускает КОМПАС-3D.
        /// </summary>
        public void Start()
        {
            try
            {
                if (_instance == null)
                {
                    var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    _instance = (KompasObject)Activator.CreateInstance(type);
                }
                if (_instance == null) return;
                _instance.Visible = true;
                _instance.ActivateControllerAPI();
            }
            catch
            {
                _instance = null;
                if (_instance == null)
                {
                    var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    _instance = (KompasObject)Activator.CreateInstance(type);
                }
                if (_instance == null) return;
                _instance.Visible = true;
                _instance.ActivateControllerAPI();
            }
        }

        /// <summary>
        /// Создает документ в КОМПАС-3D.
        /// </summary>
        /// <returns></returns>
        public ksDocument3D CreateDocument3D()
        {
            ksDocument3D document3D = _instance.Document3D();
            document3D.Create(false, false);
            return document3D;
        }
    }
}