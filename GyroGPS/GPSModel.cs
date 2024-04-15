using System;
using VRageMath;

namespace IngameScript
{
    class GPSModel
    {
        private Vector3D? vector3d = null;

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public string Hex { get; set; }

        public Vector3D GetVector3D
        {
            get{
                if(vector3d == null) 
                {
                    return new Vector3D(X, Y, Z);
                }
                else
                {
                    return (Vector3D)vector3d;
                }
            }
        }

        public GPSModel()
        {
        }
        public GPSModel(string gpsStr)
        {
            var temp = ParseString(gpsStr);

            X = temp.X;
            Y = temp.Y;
            Z = temp.Z;
            Hex = temp.Hex;
        }

        public static GPSModel ParseString(string str)
        {
            var model = new GPSModel();

            string[] arr = str.Split(':');

            const int STR_PARTS_COUNT = 7;
            
            float x, y, z;
            if (
                arr.Length != STR_PARTS_COUNT  ||
                !float.TryParse(arr[2].Trim(), out x) ||
                !float.TryParse(arr[3].Trim(), out y) ||
                !float.TryParse(arr[4].Trim(), out z))
            {
                throw new ArgumentException("Invalid string " + str);
            }

            model.X = x;
            model.Y = y;
            model.Z = z;

            model.Hex = arr[5];

            return model;
        }    
    }
}