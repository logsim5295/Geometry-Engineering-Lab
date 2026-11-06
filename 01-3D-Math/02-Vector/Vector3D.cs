using System;
using System.Collections.Generic;
using System.Text;

namespace _01_3D_Math._02_Vector
{
    /// <summary>
    /// 3D 벡터
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    public readonly record struct Vector3D(double X,double Y, double Z)
    {
        #region Property
        #endregion

        #region private
        #endregion

        #region public
        public double Length() => Math.Sqrt(Dot(this, this));

        /// <summary>
        /// 벡터 내적 (v1·v2 = |v1||v2|cosθ)
        ///  - 양수 : 사잇각이 90° 미만 (같은 방향 쪽), 예각
        ///  - 0    : 수직
        ///  - 음수 : 사잇각이 90° 초과 (반대 방향 쪽), 둔각
        ///  - v2가 단위벡터면 v1을 v2 방향으로 투영한 길이
        /// </summary>
        /// <param name="v1">벡터1</param>
        /// <param name="v2">벡터2</param>
        /// <returns></returns>
        public static double Dot(Vector3D v1, Vector3D v2)
            => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;

        /// <summary>
        /// 벡터 외적 (v1×v2)
        ///  - 결과는 v1과 v2에 수직인 벡터
        /// </summary>
        /// <param name="v1">벡터1</param>
        /// <param name="v2">벡터2</param>
        /// <returns></returns>
        public static Vector3D Cross(Vector3D v1, Vector3D v2)
            => new(v1.Y * v2.Z - v1.Z * v2.Y,
                   v1.Z * v2.X - v1.X * v2.Z,
                   v1.X * v2.Y - v1.Y * v2.X);
        #endregion
    }
}
