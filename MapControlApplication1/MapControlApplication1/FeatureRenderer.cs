using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;

namespace MapControlApplication1
{
    class FeatureRenderer
    {
        public IMap m_map;


        //传入当前地图对象
        public FeatureRenderer(IMap map)
        {
            m_map = map;
        }
        //通过指定图层名从地图对象中返回相应图层
        public ILayer GetLayerByName(string sLayerName)
        {
            //对地图对象中的所有图层进行遍历，若某一图层与指定图层名称相同，则返回该图层

            if (sLayerName == "" || m_map == null)
            {
                return null;
            }

            for (int i = 0; i < m_map.LayerCount; i++)
            {
                if (m_map.get_Layer(i).Name == sLayerName)
                    return m_map.get_Layer(i);
            }
            //否则返回为空
            return null;
        }

        //传入图层名称，读取要素数据表中的Shape字段，获取要素的几何类型
        public string GetType(IFeatureLayer featureLayer)
        {
            IFeature feature;
            IFeatureCursor featureCursor = featureLayer.Search(null, false);
            feature = featureCursor.NextFeature();
            if (feature == null)
            {
                return null;
            }

            string geotype;
            switch (feature.Shape.GeometryType)
            {
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                    geotype = "point";
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                    geotype = "line";
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                    geotype = "polygon";
                    break;
                default:
                    geotype = "unknowkn";
                    break;
            }
            return geotype;
        }

        //传入图层名称，对图层进行简单渲染
        public void Render(string sLayerName)
        {
            ILayer layer = GetLayerByName(sLayerName);
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IGeoFeatureLayer geoLayer = featureLayer as IGeoFeatureLayer;

            string geotype = GetType(featureLayer);
            //构造SimpleRenderer
            ISimpleRenderer renderer = new SimpleRendererClass();
            renderer.Description = "简单地渲染一下";
            renderer.Label = geotype;
            //假设sym是一个和该图层中Geometry类型对应的符号；
            if (geotype=="point")
            {
                SimpleMarkerSymbol sym = new SimpleMarkerSymbol();

                IColor red = new RgbColorClass();
                red.RGB = 255;
                sym.Color = red;
                sym.Style = esriSimpleMarkerStyle.esriSMSDiamond;
                sym.Size = 2;
                sym.Outline = true;
                renderer.Symbol = sym as ISymbol;
            }
            if(geotype=="line")
            {
                LineFillSymbol sym = new LineFillSymbol();
                renderer.Symbol = sym as ISymbol;
            }
            if(geotype=="polygon")
            {
                ISimpleFillSymbol sym = new SimpleFillSymbolClass();
                IRgbColor blue = new RgbColorClass();
                blue.Red = 40;
                blue.Green = 144;
                blue.Blue = 255;
                sym.Color = blue;
                renderer.Symbol = sym as ISymbol;
            }
            if(geotype=="unknown")
            {
                return;
            }
            //为图层设置渲染，注意要刷新该图层。
            geoLayer.Renderer = renderer as IFeatureRenderer;
        }
    }
}
