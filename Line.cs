/*

Written by olusola olaoye

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mateematik
{
    public class Line
    {
        private Vector A;
        private Vector B;
        private Vector V; // vector that goes from a to b

        public enum LineType { Line, Segment, Ray };
        private LineType type;

        public Line(Vector A, Vector B, LineType type)
        {
            this.A = A;
            this.B = B;
            this.type = type;
            
            V = B - A;
        }

        public Line(Vector A, Vector B)
        {
            this.A = A;
            this.B = B;
            this.type = LineType.Segment; // default type to 

            V = B - A;
        }

        public Vector lerp(float t)
        {
            t = type == LineType.Segment ? Mateematik.clamp(t, 0, 1) : type == LineType.Ray ? Mateematik.clamp(t, 0, Mathf.Infinity)
                  : Mateematik.clamp(t, -Mathf.Infinity, Mathf.Infinity);

            return ( (A + V) * t);
        }

        public void drawLine(float width, Color color)
        {
            Vector.drawLine(A,B,width,color);
        }

        public Vector toVector()
        {
            return B - A;
        }

        public float intersectAt(Line other)
        {
            if (Mateematik.dotProduct(Vector.pepedincular(other.V), V) == 0 )
                return float.NaN;

            float time; // t is a point in this line where other intersects at

            Vector this_line = this.toVector();
            Vector other_line = other.toVector();

            Vector this_line_pepedincular = Vector.pepedincular(this_line);
            Vector other_line_pepedincular = Vector.pepedincular(other_line);

            time = Mateematik.dotProduct(other_line_pepedincular , (other.A - this.A) ) / Mateematik.dotProduct(other_line_pepedincular , this_line);

            if ((time < 0 || time > 1) && type == LineType.Segment) return float.NaN;

            return time;
        }

        public bool doesLineIntersect(Line other)
        {
            if (Mateematik.dotProduct(Vector.pepedincular(other.V), V) == 0)
                return false;

            float time; // t is a point in this line where other intersects at

            Vector this_line = this.toVector();
            Vector other_line = other.toVector();

            Vector this_line_pepedincular = Vector.pepedincular(this_line);
            Vector other_line_pepedincular = Vector.pepedincular(other_line);

            time = Mateematik.dotProduct(other_line_pepedincular, (other.A - this.A)) / Mateematik.dotProduct(other_line_pepedincular, this_line);

            if ((time < 0 || time > 1) && type == LineType.Segment) return false;

            return true;
        }

        public Vector getStart()
        {
            return A;
        }
        public Vector getEnd()
        {
            return B;

        }
    }
}

