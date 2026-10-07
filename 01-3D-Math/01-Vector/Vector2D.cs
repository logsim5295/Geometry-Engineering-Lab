using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace _01_3D_Math
{
    /// <summary>
    /// 2D 벡터
    /// </summary>
    public struct Vector2D
    {
        #region Property
        /// <summary>
        /// X 성분
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Y 성분
        /// </summary>
        public double Y { get; }
        #endregion

        #region private
        #endregion

        #region public
        /// <summary>
        /// 벡터 길이 값
        /// </summary>
        /// <returns></returns>
        public double Length()
        {
            return Math.Sqrt(LengthSquard());
        }

        /// <summary>
        /// 제곱근 하지 않은 벡터 길이 값
        ///  - Math.Sqrt 하지 않아 단순 길이 비교용으로 사용할 때 성능이 좋다.
        /// </summary>
        /// <returns></returns>
        public double LengthSquard()
        {
            return X * X + Y * Y;
        }
        #endregion
    }
}
