using UnityEngine;

namespace Mateematik
{
    public class Vector
    {
        public float x;
        public float y;
        public float z;

        public Vector()
        {
            float x = 0;
            float y = 0;
            float z = 0;
        }

        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(Vector2 v2)
        {
            this.x = v2.x;
            this.y = v2.y;
            this.z = 0;
        }

        public Vector(Vector3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public float this[int index]
        {
            get { return index == 0 ? x : index == 1 ? y : index == z ? 2 : 0; }
        }

        public Vector3 toVector3()
        {
            return new Vector3(x, y, z);
        }

        public Vector2 toVecto2()
        {
            return new Vector3(x, y);
        }

        public string toString()
        {
            string print = x.ToString() + " " + y.ToString() + " " + z.ToString();
            return print;
        }

        public static Vector fromVector3(Vector3 v)
        {
            return new Vector(v.x, v.y, v.z);
        }

        public static Vector fromVector2(Vector2 v)
        {
            return new Vector(v.x,v.y);
        }

        public static Vector zero()
        {
            return new Vector(0,0,0);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector pepedincular(Vector v)
        {
            Vector pepedincular = new Vector(-v.y, v.x, v.z);

            return pepedincular;
        }

        public static Vector pepedincular(Line l)
        {
            Vector v;
            v = l.getEnd() - l.getStart();
            Vector pepedincular = new Vector(-v.y, v.x, v.z);

            return pepedincular;
        }

        public static Vector operator -(Vector a)
        {
            return new Vector(- a.x , -a.y, -a.z);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vector operator *(Vector a, float f)
        {
            return new Vector(a.x * f, a.y * f, a.z * f);
        }
        public static Vector operator *(float f, Vector a)
        {
            return new Vector(a.x * f, a.y * f, a.z * f);
        }
        public static Vector operator /(Vector a, float f)
        {
            return new Vector(a.x / f, a.y / f, a.z / f);
        }
        public static bool operator ==(Vector a, Vector b)
        {
            return ((a.x == b.x) && (a.y == b.y) && (a.z == b.z));
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return !((a.x == b.x) && (a.y == b.y) && (a.z == b.z));
        }
    }
}

