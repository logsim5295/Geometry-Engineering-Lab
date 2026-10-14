using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace _01_3D_Math
{
    /// <summary>
    /// 2D 벡터
    /// </summary>
    public readonly record struct Vector2D(double X, double Y)
    {
        #region Property
        #endregion

        #region private
        #endregion

        #region public
        /// <summary>
        /// 벡터 길이 값
        /// </summary>
        /// <returns></returns>
        public double Length() => Math.Sqrt(LengthSquared());

        /// <summary>
        /// 제곱근 하지 않은 벡터 길이 값
        ///  - Math.Sqrt 하지 않아 단순 길이 비교용으로 사용할 때 성능이 좋다.
        /// </summary>
        /// <returns></returns>
        public double LengthSquared() => Dot(this, this);

        /// <summary>
        /// 정규화된 벡터(길이 1, 방향 동일)를 새로 만들어 반환한다.
        /// </summary>
        /// <returns>단위 벡터. 영벡터이면 영벡터를 그대로 반환한다.</returns>
        public Vector2D Normalized()
        {
            double length = Length();
            if (length == 0)
            {
                return this;
            }

            return this / length;
        }

        /// <summary>
        /// 벡터 덧셈
        /// </summary>
        /// <param name="v1">벡터1</param>
        /// <param name="v2">벡터2</param>
        /// <returns></returns>
        public static Vector2D operator +(Vector2D v1, Vector2D v2) => new(v1.X + v2.X, v1.Y + v2.Y);

        /// <summary>
        /// 벡터 뺄셈
        /// </summary>
        /// <param name="v1">벡터1</param>
        /// <param name="v2">벡터2</param>
        /// <returns></returns>
        public static Vector2D operator -(Vector2D v1, Vector2D v2) => new(v1.X - v2.X, v1.Y - v2.Y);

        /// <summary>
        /// 벡터 곱셈
        /// </summary>
        /// <param name="v1">벡터</param>
        /// <param name="value">곱할 값</param>
        /// <returns></returns>
        public static Vector2D operator *(Vector2D v1, double value) => new(v1.X * value, v1.Y * value);

        /// <summary>
        /// 벡터 나눗셈
        /// </summary>
        /// <param name="v1">벡터</param>
        /// <param name="value">나눌 값</param>
        /// <returns></returns>
        public static Vector2D operator /(Vector2D v1, double value) => new(v1.X / value, v1.Y / value);

        /// <summary>
        /// 벡터 내적 (v1·v2 = |v1||v2|cosθ)
        ///  - 양수 : 사잇각이 90° 미만 (같은 방향 쪽), 예각
        ///  - 0    : 수직
        ///  - 음수 : 사잇각이 90° 초과 (반대 방향 쪽), 둔각
        ///  - v2가 단위벡터면 v1을 v2 방향으로 투영한 길이
        /// </summary>>
        /// <param name="v1">벡터1</param>
        /// <param name="v2">벡터2</param>
        /// <returns></returns>
        public static double Dot(Vector2D v1, Vector2D v2) => v1.X * v2.X + v1.Y * v2.Y;

        #endregion
    }
}
