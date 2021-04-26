using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using BottleParametrs;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using static System.Math;

namespace BottleNew
{
    /// <summary>
    /// Строитель бутылки.
    /// </summary>
    public class BottleBuilder
    {
        /// <summary>
        /// Экземпляр класса параметров.
        /// </summary>
        private  BottleParameters _bottleParameters;

        private KompasConnector _kompas;

        /// <summary>
        /// Экземпляр компонента
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Конструктор
        /// </summary>
        public BottleBuilder(ksDocument3D document3D, BottleParameters bottleParameters, KompasConnector kompas)
        {
            _part = document3D.GetPart(-1);
            _bottleParameters = bottleParameters;
            _kompas = kompas;
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
            CreateOpener();
        }

        /// <summary>
        /// Построитель горлышка.
        /// </summary>
        private void BuildBottleneck()
        {
            ksEntity planeOffset = _part.NewEntity(14);
            ksPlaneOffsetDefinition planeOffsetDefinition = planeOffset.GetDefinition();

            planeOffsetDefinition.direction = true;
            planeOffsetDefinition.offset = _bottleParameters.BaseLength;

            ksEntity planeXOY = _part.GetDefaultEntity(1);
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
            ksEntity planeXOY = _part.GetDefaultEntity(1);
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
            ksEntity sketch = _part.NewEntity(5);
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
            ksEntity extrusion = _part.NewEntity(24);
            ksBaseExtrusionDefinition extrusionDefinition = extrusion.GetDefinition();

            extrusionDefinition.SetSideParam(true, 0, length);
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
            ksEntity fillet = _part.NewEntity(34);

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
            ksEntityCollection faceCollection = _part.EntityCollection(6);

            faceCollection.SelectByPoint(0, 0, _bottleParameters.BaseLength);

            ksEntity baseFace = faceCollection.First();
            CreateFillet(baseFace, 1);
        }

        /// <summary>
        /// Округление горлышка.
        /// </summary>
        private void FilletBottleneck()
        {
            ksEntityCollection faceCollection = _part.EntityCollection(6);

            var baseRadius = _bottleParameters.BaseDiameter / 2;
            var bottleneckRadius = _bottleParameters.BottleneckDiameter / 2;

            var pointOnFace = baseRadius - bottleneckRadius - 1;

            faceCollection.SelectByPoint(pointOnFace, pointOnFace, _bottleParameters.BaseLength);
            ksEntity filletFace = faceCollection.First();

            var filletRadius = _bottleParameters.LengthFullBottle -
                               (_bottleParameters.BaseLength + _bottleParameters.BottleneckLength);

            CreateFillet(filletFace, filletRadius);
        }

        private void CreateRectangle(double lenght,double x,double y,double ang)
        {
            ksEntity sketch = _part.NewEntity(5);
            ksSketchDefinition sketchDefinition = sketch.GetDefinition();
            ksEntity planeXOY = _part.GetDefaultEntity(1);
            sketchDefinition.SetPlane(planeXOY);
            sketch.Create();
            
            lenght = _bottleParameters.BottleneckDiameter;
            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();
            var param = (ksRectangleParam)_kompas._instance.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            param.ang = ang;
            param.height = lenght;
            param.width = lenght;
            param.style = 1;
            param.x = x;
            param.y = y;
            sketchEdit.ksRectangle(param,1);
            sketchDefinition.EndEdit();

            MakeCutExtrude(sketch, 2);
        }

        
        private void MakeCutExtrude(object entitySketch, short direction)
        {
            var entityCutExtrusion = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            var cutExtrusionDefinition = (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
            cutExtrusionDefinition.directionType = direction;
            cutExtrusionDefinition.SetSideParam(true);
            cutExtrusionDefinition.SetSketch(entitySketch);
            entityCutExtrusion.Create();
        }

        private void CreateOpener()
        {
            var lenght = _bottleParameters.BottleneckDiameter;
            CreateRectangle(lenght, -lenght / 2, -lenght / 2, 0);
            CreateRectangle(lenght, 0, -lenght*(Sqrt(2)/2), 45);
        }
    }
}