using System;
using System.Collections.Generic;
using System.Text;

namespace _01_3D_Math
{
    public sealed class CoordinateSystem3D
    {
        #region Property
        public Point3D Origin { get; }
        public Vector3D AxisX { get; }
        public Vector3D AxisY { get; }
        public Vector3D AxisZ { get; }
        #endregion

        #region private
        private bool IsOrthonormal(Vector3D ex, Vector3D ey, Vector3D ez)
        {
            const double tolerance = 1e-10;

            bool unitLengths =
                Math.Abs(ex.LengthSquared() - 1.0) <= tolerance &&
                Math.Abs(ey.LengthSquared() - 1.0) <= tolerance &&
                Math.Abs(ez.LengthSquared() - 1.0) <= tolerance;

            bool perpendicular =
                Math.Abs(Vector3D.Dot(ex, ey)) <= tolerance &&
                Math.Abs(Vector3D.Dot(ey, ez)) <= tolerance &&
                Math.Abs(Vector3D.Dot(ez, ex)) <= tolerance;

            return unitLengths && perpendicular;
        }
        #endregion

        #region public
        public CoordinateSystem3D(Point3D origin, Vector3D ex, Vector3D ey, Vector3D ez)
        {
            if (!IsOrthonormal(ex, ey, ez))
            {
                throw new ArgumentException("좌표축은 서로 수직이고 각각 길이가 1이어야 합니다.");
            }

            Origin = origin;
            AxisX = ex;
            AxisY = ey;
            AxisZ = ez;
        }

        public Point3D ToLocal(Point3D world)
        {
            Vector3D v = world - Origin;

            return new Point3D(
                    Vector3D.Dot(v, AxisX),
                    Vector3D.Dot(v, AxisY),
                    Vector3D.Dot(v, AxisZ)
                );
        }

        public Point3D ToWorld(Point3D local)
        {
            return new Point3D(
                Origin.X + local.X * AxisX.X
                         + local.Y * AxisY.X
                         + local.Z * AxisZ.X,

                Origin.Y + local.X * AxisX.Y
                         + local.Y * AxisY.Y
                         + local.Z * AxisZ.Y,

                Origin.Z + local.X * AxisX.Z
                         + local.Y * AxisY.Z
                         + local.Z * AxisZ.Z
            );
        }

        #endregion
    }
}
