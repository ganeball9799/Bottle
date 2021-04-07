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
        /// Указывает, что программа КОМПАС-3D запущена.
        /// </summary>
        public bool IsActive => _instance != null;

        /// <summary>
        /// Закрывает КОМПАС-3D.
        /// </summary>
        public void Close()
        {
            _instance?.Quit();
            _instance = null;
        }

        /// <summary>
        /// Запускает КОМПАС-3D.
        /// </summary>
        public void Start()
        {
            var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
            _instance = (KompasObject)Activator.CreateInstance(type);

            if (_instance == null)
                throw new NullReferenceException("Не найдена совместимая версия КОМПАС-3D.");

            _instance.Visible = true;
            _instance.ActivateControllerAPI();
        }

        /// <summary>
        /// Создает документ в КОМПАС-3D.
        /// </summary>
        /// <returns></returns>
        public ksDocument3D CreateDocument3D()
        {
            if (!IsActive)
                throw new NullReferenceException("КОМПАС-3D не запущен.");

            ksDocument3D document3D = _instance.Document3D();
            document3D.Create(false, false);
            return document3D;
        }
    }
}