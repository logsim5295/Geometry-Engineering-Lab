using System;
using System.Collections.Generic;
using System.Text;

namespace _01_3D_Math
{
    /// <summary>
    /// 3D 벡터
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    public readonly record struct Vector3D(double X, double Y, double Z)
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

        /// <summary>
        /// 두 입력 벡터에 수직인 단위 법선 구하기
        /// </summary>
        /// <param name="v1">벡터1</param>
        /// <param name="v2">벡터2</param>
        /// <returns></returns>
        public static Vector3D UnitNormal(Vector3D v1, Vector3D v2)
        {
            // * 공차
            const double tolerance = 1e-10;

            // #01. 입력 벡터의 길이를 구한다.
            double length1 = v1.Length();
            double length2 = v2.Length();

            // #02. 입력 벡터의 길이 유효성 검사 수행한다.
            if (length1 == 0 || length2 == 0)
                throw new ArgumentException("영벡터는 방향이 없습니다.");

            // #03. 입력 벡터를 정규화한다.
            Vector3D unit1 = new(v1.X / length1, v1.Y / length1, v1.Z / length1);
            Vector3D unit2 = new(v2.X / length2, v2.Y / length2, v2.Z / length2);

            // #04. 외적 구하기
            Vector3D cross = Cross(unit1, unit2);

            // #05. 외적 벡터 길이 구하기
            double sinAngle = cross.Length();

            // #06. 평행·반평행에 가까운지 허용오차로 판정
            if (sinAngle <= tolerance)
            {
                throw new ArgumentException("두 벡터가 평행하거나 거의 평행하여 단위 법선을 구하지 않습니다.");
            }

            return new(cross.X / sinAngle, cross.Y / sinAngle, cross.Z / sinAngle);
        }

        public double LengthSquared() => Dot(this, this);

        #endregion
    }
}
