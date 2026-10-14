using System;

namespace _01_3D_Math
{
    /// <summary>
    /// 2D 점 (공간상의 위치)
    ///  - Vector2D는 방향과 크기, Point2D는 위치를 나타낸다.
    ///  - 점 - 점 = 벡터, 점 + 벡터 = 점. 점 + 점은 의미가 없으므로 정의하지 않는다.
    /// </summary>
    public readonly record struct Point2D(double X, double Y)
    {
        #region Property
        /// <summary>
        /// 원점 (0, 0)
        /// </summary>
        public static Point2D Origin => new(0, 0);
        #endregion

        #region private
        #endregion

        #region public
        /// <summary>
        /// 원점에서 이 점까지의 위치 벡터로 변환한다.
        /// </summary>
        /// <returns></returns>
        public Vector2D ToVector() => new(X, Y);

        /// <summary>
        /// 점 - 점 = 벡터 (p2에서 p1을 향하는 벡터)
        /// </summary>
        /// <param name="p1">끝점</param>
        /// <param name="p2">시작점</param>
        /// <returns></returns>
        public static Vector2D operator -(Point2D p1, Point2D p2) => new(p1.X - p2.X, p1.Y - p2.Y);

        /// <summary>
        /// 점 + 벡터 = 점 (점을 벡터만큼 이동)
        /// </summary>
        /// <param name="p">점</param>
        /// <param name="v">이동 벡터</param>
        /// <returns></returns>
        public static Point2D operator +(Point2D p, Vector2D v) => new(p.X + v.X, p.Y + v.Y);

        /// <summary>
        /// 점 - 벡터 = 점 (점을 벡터 반대 방향으로 이동)
        /// </summary>
        /// <param name="p">점</param>
        /// <param name="v">이동 벡터</param>
        /// <returns></returns>
        public static Point2D operator -(Point2D p, Vector2D v) => new(p.X - v.X, p.Y - v.Y);

        /// <summary>
        /// 두 점 사이의 거리
        /// </summary>
        /// <param name="p1">점1</param>
        /// <param name="p2">점2</param>
        /// <returns></returns>
        public static double Distance(Point2D p1, Point2D p2) => (p1 - p2).Length();

        /// <summary>
        /// 제곱근 하지 않은 두 점 사이의 거리
        ///  - Math.Sqrt 하지 않아 단순 거리 비교용으로 사용할 때 성능이 좋다.
        /// </summary>
        /// <param name="p1">점1</param>
        /// <param name="p2">점2</param>
        /// <returns></returns>
        public static double DistanceSquared(Point2D p1, Point2D p2) => (p1 - p2).LengthSquared();

        #endregion
    }
}
