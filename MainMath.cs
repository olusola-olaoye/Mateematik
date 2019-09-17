/*

Written by olusola olaoye

*/

using System;
using UnityEngine;

namespace Mateematik
{
    public static class MainMath
    {

        public static Vector normalize(Vector vector)
        {
            float vector_length = magnitude(vector);

            return new Vector(vector.x / vector_length, vector.y / vector_length, vector.z / vector_length);
        }

        public static float magnitude(Vector vector)
        {
            return Mathf.Sqrt((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z));
        }

        public static Vector distanceVector(Vector v2, Vector v1)
        {
            return v2 - v1;
        }

        public static float distance(Vector v2, Vector v1)
        {
            return magnitude(distanceVector(v2, v1));
        }

        public static float dotProduct(Vector vector1, Vector vector2)
        {
            return (vector1.x * vector2.x) + (vector1.y * vector2.y) + (vector1.z * vector2.z);
        }

        public static bool isPepedincular(Vector vector1, Vector vector2)
        {
            return ((vector1.x * vector2.x) + (vector1.y * vector2.y) + (vector1.z * vector2.z)) == 0;
        }

        public static bool isAngleGreaterThan90(Vector vector1, Vector vector2)
        {
            return ((vector1.x * vector2.x) + (vector1.y * vector2.y) + (vector1.z * vector2.z)) < 0;
        }

        public static bool isAngleLessThan90(Vector vector1, Vector vector2)
        {
            return ((vector1.x * vector2.x) + (vector1.y * vector2.y) + (vector1.z * vector2.z)) > 0;
        }

        // angle between
        public static float angleBetween(Vector v1, Vector v2)
        {
            return Mathf.Acos((dotProduct(v1, v2)) / (magnitude(v1) * magnitude(v2)));
        }

        public static Vector rotateVectorBy(Vector v, float angle)
        {
            Vector new_vector = new Vector(v.x * Mathf.Cos(angle) - v.y * Mathf.Sin(angle), 0, v.x * Mathf.Sin(angle) + v.y * Mathf.Cos(angle));

            return new_vector;
        }

        public static Vector crossProduct(Vector v1, Vector v2)
        {
            Vector new_vector = new Vector((v1.y * v2.z) - (v1.z * v2.y), (v1.z * v2.x) - (v1.x * v2.z), (v1.x * v2.y) - (v1.y * v2.x));

            return new_vector;
        }

        public static bool clockWise(Vector v1, Vector v2)
        {
            return crossProduct(v1, v2).z < 0;
        }

        public static Vector lookAt(Transform observer, Transform target)
        {
            float angle_between = angleBetween(Vector.fromVector3(observer.forward), 
            distanceVector(Vector.fromVector3(target.position), 
            Vector.fromVector3(observer.position)));

            return rotateVectorBy(Vector.fromVector3(observer.forward), angle_between); 
        }

        public static float toDrgree(float rad)
        {
            return rad * 180f / Mathf.PI;
        }

        public static float toRads(float degree)
        {
            return degree * Mathf.PI / 180f;
        }

        public static float clamp(float value, float min, float max)
        {
            if(value < min)
            {
                value = min;
            }
            else if(value > max)
            {
                value = max;
            }
            return value;
        }

        public static Vector translate(Vector position, Vector facing, Vector direction)
        {
            if (distance(Vector.zero(), direction) <= 0) return position;

            float angle = angleBetween(direction, facing);
            float world_angle = angleBetween(direction, new Vector(0, 0, 1));

            Vector new_direction = clockWise(facing, direction) ? rotateVectorBy(direction, angle + world_angle) : 
            rotateVectorBy(direction, 360 - (angle + world_angle));
            return position + new_direction;
        }

        public static Vector lerp(Vector A, Vector B, float time)
        {
            Vector difference = B - A;

            return (A + difference) * time;
        }

        public static Vector lerp(Vector A, Vector B, float time, float min, float max)
        {
            clamp(time, min, max);
            Vector difference = B - A;

            return (A + difference) * time;
        }

        public static Vector createPlane(Vector point, Vector U, Vector V, float u_time, float v_time)
        {
            clamp(u_time, point.x, U.x);
            clamp(v_time, point.z, V.z);
            return point + (V * v_time) + (U * u_time);
        }

        public static Vector createPlane(Vector point, Vector U, Vector V)
        {
            float u_time = U.x - point.x;
            float v_time = V.z - point.z;

            clamp(u_time, point.x, U.x);
            clamp(v_time, point.z, V.z);
            return point + (V * v_time) + (U * u_time);
        }

        public static Vector getPlaneNormalStart(Vector point, Vector U, Vector V)
        {
            Vector start_normal;
            
            start_normal = new Vector((magnitude(U) / 2) + 1, point.y, (magnitude(V) / 2) - 1);

            return start_normal;
        }

        public static Vector getPlaneNormalEnd(Vector point, Vector U, Vector V, int normal_length)
        {
            Vector end_normal;
            end_normal = new Vector(getPlaneNormalStart(point, U, V).x, normal_length, getPlaneNormalStart(point, U, V).z);

            return  end_normal;
        }

        public static Vector project(Vector item, Vector wall)
        {
            return dotProduct(-item, wall) * wall;
        }


        public static Vector reflect(Vector incident, Vector wall)
        {
        
            return incident + (2 * project
            (incident, wall));
        }

        public static float[] arrayCopy(float[] original, float[] copy)
        {
            if(original.Length > copy.Length)
            {
                for(int i = 0; i < copy.Length; i++)
                {
                    copy[i] = original[i];
                }
            }
            else
            {
                for (int i = 0; i < original.Length; i++)
                {
                    copy[i] = original[i];
                }
            }

            return copy;
        }

       
    }
}