using System.Diagnostics.CodeAnalysis;
using Kompas6API5;

namespace BottleNew
{
    /// <summary>
    /// Строитель бутылки.
    /// </summary>
    public class BottleBuilder
    {
        //TODO: Вынести BottleParameters в отдельный проект
        /// <summary>
        /// Экземпляр класса параметров.
        /// </summary>
        private  BottleParameters _bottleParameters;

        /// <summary>
        /// Экземпляр компонента
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Конструктор
        /// </summary>
        public BottleBuilder(ksDocument3D document3D, BottleParameters bottleParameters)
        {
            _part = document3D.GetPart(pTop_part);
            _bottleParameters = bottleParameters;
        }

        /// <summary>
        /// Метод построение бутылки.
        /// </summary>
        public void BuildBottle()
        {
            BuildBase();
            FilletBase();
            BuildBottleneck();
            FilletBottleneck();
        }

        /// <summary>
        /// Построитель горлышка.
        /// </summary>
        private void BuildBottleneck()
        {
            ksEntity planeOffset = _part.NewEntity(o3d_planeOffset);
            ksPlaneOffsetDefinition planeOffsetDefinition = planeOffset.GetDefinition();

            planeOffsetDefinition.direction = true;
            planeOffsetDefinition.offset = _bottleParameters.BaseLength;

            ksEntity planeXOY = _part.GetDefaultEntity(o3d_planeXoy);
            planeOffsetDefinition.SetPlane(planeXOY);

            planeOffset.Create();

            var length = _bottleParameters.LengthFullBottle - _bottleParameters.BaseLength;

            CreateCylinder(planeOffset, _bottleParameters.BottleneckDiameter, length);
        }

        /// <summary>
        /// Построитель основания.
        /// </summary>
        private void BuildBase()
        {
            ksEntity planeXOY = _part.GetDefaultEntity(o3d_planeXoy);
            CreateCylinder(planeXOY, _bottleParameters.BaseDiameter, _bottleParameters.BaseLength);
        }

        /// <summary>
        /// Построитель цилиндра.
        /// </summary>
        /// <param name="plane">Плоскость, относительно которой будет выдавливаться цилиндр.</param>
        /// <param name="diameter">Диаметр цилиндра.</param>
        /// <param name="length">Длина цилиндра.</param>
        private void CreateCylinder(ksEntity plane, double diameter, double length)
        {
            ksEntity sketch = _part.NewEntity(o3d_sketch);
            ksSketchDefinition sketchDefinition = sketch.GetDefinition();

            sketchDefinition.SetPlane(plane);
            sketch.Create();

            ksDocument2D document2D = sketchDefinition.BeginEdit();

            CreateCircle(document2D, diameter);

            sketchDefinition.EndEdit();

            CreateExtrusion(length, sketch);
        }

        /// <summary>
        /// Построитель выдавливания.
        /// </summary>
        /// <param name="length">Длина выдавливания.</param>
        /// <param name="sketch">Эскиз для выдавливания.</param>
        private void CreateExtrusion(double length, ksEntity sketch)
        {
            ksEntity extrusion = _part.NewEntity(o3d_baseExtrusion);
            ksBaseExtrusionDefinition extrusionDefinition = extrusion.GetDefinition();

            extrusionDefinition.SetSideParam(true, etBland, length);
            extrusionDefinition.SetSketch(sketch);
            extrusion.Create();
        }

        /// <summary>
        /// Построитель круга.
        /// </summary>
        /// <param name="document2D">2D документ.</param>
        /// <param name="diameter">Диаметр.</param>
        private static void CreateCircle(ksDocument2D document2D, double diameter)
        {
            document2D.ksCircle(0, 0, diameter / 2, 1);
        }

        /// <summary>
        /// Построитель скругления.
        /// </summary>
        /// <param name="face">Грань, которая будет скругляться.</param>
        /// <param name="radius">Радиус скругления.</param>
        private void CreateFillet(ksEntity face, double radius)
        {
            ksEntity fillet = _part.NewEntity(o3d_fillet);

            ksFilletDefinition filletDefinition = fillet.GetDefinition();

            filletDefinition.radius = radius;
            filletDefinition.tangent = false;

            ksEntityCollection entityCollectionFillet = filletDefinition.array();
            entityCollectionFillet.Add(face);

            fillet.Create();
        }

        /// <summary>
        /// Округление основания.
        /// </summary>
        private void FilletBase()
        {
            ksEntityCollection faceCollection = _part.EntityCollection(o3d_face);

            faceCollection.SelectByPoint(0, 0, _bottleParameters.BaseLength);

            ksEntity baseFace = faceCollection.First();
            CreateFillet(baseFace, 1);
        }

        /// <summary>
        /// Округление горлышка.
        /// </summary>
        private void FilletBottleneck()
        {
            ksEntityCollection faceCollection = _part.EntityCollection(o3d_face);

            var baseRadius = _bottleParameters.BaseDiameter / 2;
            var bottleneckRadius = _bottleParameters.BottleneckDiameter / 2;

            var pointOnFace = baseRadius - bottleneckRadius - 1;

            faceCollection.SelectByPoint(pointOnFace, pointOnFace, _bottleParameters.BaseLength);
            ksEntity filletFace = faceCollection.First();

            var filletRadius = _bottleParameters.LengthFullBottle -
                               (_bottleParameters.BaseLength + _bottleParameters.BottleneckLength);

            CreateFillet(filletFace, filletRadius);
        }

        #region KompasConstants
         //TODO: RSDN
        private const short pTop_part = -1;
        private const short o3d_sketch = 5;
        private const short o3d_baseExtrusion = 24;
        private const short o3d_face = 6;
        private const short o3d_planeXoy = 1;
        private const short o3d_planeOffset = 14;
        private const short o3d_fillet = 34;
        private const short etBland = 0;

        #endregion
    }
}