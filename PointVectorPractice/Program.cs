using _01_3D_Math;

var a = new Point2D(1, 2);
var b = new Point2D(4, 6);

var displacement = b - a;
var moved = a + displacement;
var unit = displacement.Normalized();
var zero = new Vector2D(0, 0).Normalized();

Console.WriteLine($"B - A = ({displacement.X}, {displacement.Y})");
Console.WriteLine($"이동 벡터의 길이 = {displacement.Length()}");
Console.WriteLine($"A + (B - A) = ({moved.X}, {moved.Y})");
Console.WriteLine($"정규화 = ({unit.X}, {unit.Y}), 길이 = {unit.Length()}");
Console.WriteLine($"영벡터 정규화 = ({zero.X}, {zero.Y}), 길이 = {zero.Length()}");