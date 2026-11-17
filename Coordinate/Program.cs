using _01_3D_Math;

// [World to Local Coordinates] ***************************************************************
var world = new Point3D(1, 4, 3);
//var origin = new Point3D(5, -2, 1);

//Vector3D v = world - origin; // (-4, 6, 2)
//Console.WriteLine($"world - origin = {v}");

//var ex = new Vector3D(0, 1, 0);
//var ey = new Vector3D(-1, 0, 0);
//var ez = new Vector3D(0, 0, 1);

//var local = new Point3D(
//    Vector3D.Dot(v, ex),
//    Vector3D.Dot(v, ey),
//    Vector3D.Dot(v, ez)
//);

//Console.WriteLine(local);

// [Local to World Coordinates] ***************************************************************
//var origin = new Point3D(5, -2, 1);

//var ex = new Vector3D(0, 1, 0);
//var ey = new Vector3D(-1, 0, 0);
//var ez = new Vector3D(0, 0, 1);

//var local = new Point3D(6, 4, 2);

//double worldX = origin.X
//    + local.X * ex.X
//    + local.Y * ey.X
//    + local.Z * ez.X;

//double worldY = origin.Y
//    + local.X * ex.Y
//    + local.Y * ey.Y
//    + local.Z * ez.Y;

//double worldZ = origin.Z
//    + local.X * ex.Z
//    + local.Y * ey.Z
//    + local.Z * ez.Z;

//var restoredWorld = new Point3D(worldX, worldY, worldZ);
//Console.WriteLine(restoredWorld);

//double error = Point3D.Distance(world, restoredWorld);
//double tolerance = 1e-10; // 이번 실습에서 사용할 거리 허용오차

//Console.WriteLine($"왕복 오차: {error:G17}");
//Console.WriteLine($"허용오차 이내: {error <= tolerance}");

// [ToWorld] ***************************************************************************
static Point3D ToWorld(
    Point3D local,
    Point3D origin,
    Vector3D ex,
    Vector3D ey,
    Vector3D ez)
{
    return new Point3D(
        origin.X + local.X * ex.X + local.Y * ey.X + local.Z * ez.X,
        origin.Y + local.X * ex.Y + local.Y * ey.Y + local.Z * ez.Y,
        origin.Z + local.X * ex.Z + local.Y * ey.Z + local.Z * ez.Z
    );
}

//var origin = new Point3D(5, -2, 1);
//var ex = new Vector3D(0, 1, 0);
//var ey = new Vector3D(-1, 0, 0);
//var ez = new Vector3D(0, 0, 1);
//var local = new Point3D(6, 4, 2);
//var restoredWorld = ToWorld(local, origin, ex, ey, ez);
//Console.WriteLine(restoredWorld);

//double error = Point3D.Distance(world, restoredWorld);
//double tolerance = 1e-10; // 이번 실습에서 사용할 거리 허용오차

//Console.WriteLine($"왕복 오차: {error:G17}");
//Console.WriteLine($"허용오차 이내: {error <= tolerance}");

// [ToLocal] ***************************************************************************
// ex, ey, ez는 서로 수직이고 길이가 1이어야 합니다.
static Point3D ToLocal(
    Point3D world,
    Point3D origin,
    Vector3D ex,
    Vector3D ey,
    Vector3D ez)
{
    if (!IsOrthonormal(ex, ey, ez))
    {
        throw new ArgumentException(
            "좌표축은 서로 수직이고 각각 길이가 1이어야 합니다.");
    }

    Vector3D v = world - origin;

    return new Point3D(
        Vector3D.Dot(v, ex),
        Vector3D.Dot(v, ey),
        Vector3D.Dot(v, ez)
    );
}

//var origin = new Point3D(5, -2, 1);
//var ex = new Vector3D(1.2, 1.6, 0); // 길이 2
//var ey = new Vector3D(-0.8, 0.6, 0);
//var ez = new Vector3D(0, 0, 1);
//var local = ToLocal(world, origin, ex, ey, ez);
//var restoredWorld = ToWorld(local, origin, ex, ey, ez);

//double error = Point3D.Distance(world, restoredWorld);

//Console.WriteLine($"로컬 좌표: {local}");
//Console.WriteLine($"복원한 월드 좌표: {restoredWorld}");
//Console.WriteLine($"왕복 오차: {error:G17}");
//Console.WriteLine($"허용오차 이내: {error <= 1e-10}");

//Console.WriteLine($"ex 길이: {ex.LengthSquared()}");
//bool isUnitX = Math.Abs(ex.LengthSquared() - 1.0) <= 1e-10;
//Console.WriteLine($"ex는 단위 벡터인가요? {isUnitX}");

//Console.WriteLine($"ex 길이 제곱: {ex.LengthSquared()}"); // 4
//Console.WriteLine($"ex 길이: {ex.Length()}");             // 2

//var ex = new Vector3D(1, 0, 0);
//var ey = new Vector3D(0.6, 0.8, 0);
//var ez = new Vector3D(0, 0, 1);

//Console.WriteLine($"ex 길이 제곱: {ex.LengthSquared()}"); // 4
//Console.WriteLine($"ex 길이: {ex.Length()}");             // 2
//Console.WriteLine($"ey 길이 제곱: {ey.LengthSquared()}"); // 4
//Console.WriteLine($"ey 길이: {ey.Length()}");             // 2
//Console.WriteLine($"ez 길이 제곱: {ez.LengthSquared()}"); // 1
//Console.WriteLine($"ez 길이: {ez.Length()}");             // 1


//Console.WriteLine($"ex와 ey의 내적: {Vector3D.Dot(ex, ey)}"); // 0.6

// ********************************************************************
static bool IsOrthonormal(
    Vector3D ex,
    Vector3D ey,
    Vector3D ez)
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

//Console.WriteLine(IsOrthonormal(
//    new(0.6, 0.8, 0), new(-0.8, 0.6, 0), new(0, 0, 1)));

//Console.WriteLine(IsOrthonormal(
//    new(1.2, 1.6, 0), new(-0.8, 0.6, 0), new(0, 0, 1)));

//Console.WriteLine(IsOrthonormal(
//    new(1, 0, 0), new(0.6, 0.8, 0), new(0, 0, 1)));

//try
//{
//    var testWorld = new Point3D(1, 4, 3);
//    var testOrigin = new Point3D(5, -2, 1);

//    var axisX = new Vector3D(0.6, 0.8, 0);
//    var axisY = new Vector3D(-0.8, 0.6, 0);
//    var axisZ = new Vector3D(0, 0, 1);

//    var testLocal = ToLocal(
//        testWorld, testOrigin, axisX, axisY, axisZ);

//    var restored = ToWorld(
//        testLocal, testOrigin, axisX, axisY, axisZ);

//    double roundTripError = Point3D.Distance(testWorld, restored);

//    Console.WriteLine($"왕복 오차: {roundTripError:G17}");
//    Console.WriteLine($"허용오차 이내: {roundTripError <= 1e-10}");
//}
//catch (ArgumentException ex)
//{
//    Console.WriteLine($"예상한 예외: {ex.Message}");
//}

// [CoordinateSystem3D] ****************************************************************
var coordinateSystem = new CoordinateSystem3D(
    new Point3D(5, -2, 1),
    new Vector3D(0.6, 0.8, 0),
    new Vector3D(-0.8, 0.6, 0),
    new Vector3D(0, 0, 1)
);

Console.WriteLine(coordinateSystem.Origin);
Console.WriteLine(coordinateSystem.AxisX);

var original = new Point3D(1, 4, 3);

var localPoint = coordinateSystem.ToLocal(original);
var restoredPoint = coordinateSystem.ToWorld(localPoint);

double error = Point3D.Distance(original, restoredPoint);

Console.WriteLine($"로컬 좌표: {localPoint}");
Console.WriteLine($"복원한 월드 좌표: {restoredPoint}");
Console.WriteLine($"왕복 오차: {error:G17}");
Console.WriteLine($"허용오차 이내: {error <= 1e-10}");

try
{
    var invalidSystem = new _01_3D_Math.CoordinateSystem3D(
        new Point3D(5, -2, 1),
        new Vector3D(1.2, 1.6, 0), // 길이 2
        new Vector3D(-0.8, 0.6, 0),
        new Vector3D(0, 0, 1)
    );

    Console.WriteLine("검사 실패: 잘못된 좌표계가 생성됐습니다.");
}
catch (ArgumentException error2)
{
    Console.WriteLine($"예상한 예외: {error2.Message}");
}

double a = 1.0 / Math.Sqrt(2.0);
double b = 1.0 / Math.Sqrt(6.0);
double c = 1.0 / Math.Sqrt(3.0);

var tiltedSystem = new _01_3D_Math.CoordinateSystem3D(
    new Point3D(5, -2, 1),
    new Vector3D(a, a, 0),
    new Vector3D(-b, b, 2 * b),
    new Vector3D(c, -c, c)
);

var originalLocal = new Point3D(2, -3, 4);

var worldPoint = tiltedSystem.ToWorld(originalLocal);
var restoredLocal = tiltedSystem.ToLocal(worldPoint);

double error3 = Point3D.Distance(originalLocal, restoredLocal);

Console.WriteLine($"월드 좌표: {worldPoint}");
Console.WriteLine($"복원한 로컬 좌표: {restoredLocal}");
Console.WriteLine($"왕복 오차: {error3:G17}");
Console.WriteLine($"허용오차 이내: {error3 <= 1e-10}");