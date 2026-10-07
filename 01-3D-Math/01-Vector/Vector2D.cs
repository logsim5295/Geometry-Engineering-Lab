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
        public double Length() => Math.Sqrt(LengthSquard());

        /// <summary>
        /// 제곱근 하지 않은 벡터 길이 값
        ///  - Math.Sqrt 하지 않아 단순 길이 비교용으로 사용할 때 성능이 좋다.
        /// </summary>
        /// <returns></returns>
        public double LengthSquard() => X * X + Y * Y;

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
        /// <param name="v1">벡터1</param>
        /// <param name="v2">벡터2</param>
        /// <returns></returns>
        public static Vector2D operator *(Vector2D v1, Vector2D v2) => new(v1.X * v2.X, v1.Y * v2.Y);

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
        /// <param name="v1">벡터1</param>
        /// <param name="v2">벡터2</param>
        /// <returns></returns>
        public static Vector2D operator /(Vector2D v1, Vector2D v2) => new(v1.X / v2.X, v1.Y / v2.Y);

        /// <summary>
        /// 벡터 나눗셈
        /// </summary>
        /// <param name="v1">벡터</param>
        /// <param name="value">나눌 값</param>
        /// <returns></returns>
        public static Vector2D operator /(Vector2D v1, double value) => new(v1.X / value, v1.Y / value);

        #endregion
    }
}
