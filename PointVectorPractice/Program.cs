using _01_3D_Math;

var a = new Point2D(1, 2);
var b = new Point2D(4, 6);

var displacement = b - a;
var moved = a + displacement;
var unit = displacement.Normalized();
var zero = new Vector2D(0, 0).Normalized();
var returned = b - displacement;

Console.WriteLine($"B - A = ({displacement.X}, {displacement.Y})");
Console.WriteLine($"이동 벡터의 길이 = {displacement.Length()}");
Console.WriteLine($"A + (B - A) = ({moved.X}, {moved.Y})");
Console.WriteLine($"정규화 = ({unit.X}, {unit.Y}), 길이 = {unit.Length()}");
Console.WriteLine($"영벡터 정규화 = ({zero.X}, {zero.Y}), 길이 = {zero.Length()}");
Console.WriteLine($"B - v = ({returned.X}, {returned.Y})");
Console.WriteLine($"원래 점 A와 같은가? {returned == a}");
Console.WriteLine($"결과 타입: {returned.GetType().Name}");

static double AngleDegrees(Vector2D v1, Vector2D v2)
{
    double length1 = v1.Length();
    double length2 = v2.Length();

    if (length1 == 0 || length2 == 0)
    {
        throw new ArgumentException("벡터의 길이가 0이면 각도를 계산할 수 없습니다.");
    }

    double consine = Vector2D.Dot(v1, v2) / (length1 * length2);
    consine = Math.Clamp(consine, -1.0, 1.0);

    return Math.Acos(consine) * (180.0 / Math.PI);
}

var axisX = new Vector2D(1, 0);

Console.WriteLine($"같은 방향: {AngleDegrees(axisX, axisX):F1}°");
Console.WriteLine($"수직 방향: {AngleDegrees(axisX, new Vector2D(0, 1)):F1}°");
Console.WriteLine($"반대 방향: {AngleDegrees(axisX, new Vector2D(-1, 0)):F1}°");
Console.WriteLine($"단위 벡터: {AngleDegrees(axisX, new Vector2D(0.6, 0.8)):F1}°");
Console.WriteLine($"길이 10 벡터: {AngleDegrees(axisX, new Vector2D(6, 8)):F1}°");

try
{
    Console.WriteLine(AngleDegrees(axisX, new Vector2D(0, 0)));
}
catch (ArgumentException ex)
{
    Console.WriteLine($"각도 계산 실패: {ex.Message}");
}