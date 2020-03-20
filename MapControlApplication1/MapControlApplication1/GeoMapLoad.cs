using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapControlApplication1
{
    public class GeoMapLoad
    {
        public static void CopyAndOverwriteMap(AxMapControl axMapControl, AxPageLayoutControl axPageLayoutControl)
        {
            //使用object类将地图视图内容复制到打印视图
            IObjectCopy objectCopy = new ObjectCopyClass();
            object toCopyMap = axMapControl.Map;
            object copiedMap = objectCopy.Copy(toCopyMap);
            object overwriteMap = axPageLayoutControl.ActiveView.FocusMap;
            objectCopy.Overwrite(toCopyMap, ref overwriteMap);
        }
    }
}
