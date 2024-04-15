using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRageMath;

namespace IngameScript.Helpers
{
    static class GPSParser
    {
        public static Vector3D Parse(string gps)
        {
            var arr = gps.Split(':');
            if(arr.Length == 7)
            {
                double x = double.Parse(arr[2]);
                double y = double.Parse(arr[3]);
                double z = double.Parse(arr[4]);

                return new Vector3D(x, y, z);
            }

            throw new Exception("Invalid GPS string" +  gps);
        }
    }
}
