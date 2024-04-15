using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRageMath;

namespace  IngameScript.Torpedo
{
    public class FlyingPlan
    {
        private Queue<Vector3D> _points;

        public FlyingPlan()
        {
            _points = new Queue<Vector3D>();
        }

        public void EnqueuePoint(Vector3D point)
        {
            _points.Enqueue(point);
        }

        public void RemovePoint(Vector3D point)
        {
            _points = new Queue<Vector3D>(_points.Where(p => p != point));
        }

        public bool ContainsPoint(Vector3D point)
        {
            return _points.Contains(point);
        }

        public Vector3D PeekPoint()
        {
            return _points.Peek();
        }

        public Vector3D DequeuePoint()
        {
            if(_points.Count == 1)
            {
                return default(Vector3D);
            }
            return _points.Dequeue();
        }

        public int Count()
        {
            return _points.Count;
        }

        public void Clear()
        {
            _points.Clear();
        }
    }
}