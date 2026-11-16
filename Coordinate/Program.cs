using _01_3D_Math._01_Primitives;
using _01_3D_Math._02_Vector;

var world = new Point3D(1, 4, 3);
var origin = new Point3D(5, -2, 1);

Vector3D v = world - origin; // (-4, 6, 2)
Console.WriteLine($"world - origin = {v}");

var ex = new Vector3D(0, 1, 0);
var ey = new Vector3D(-1, 0, 0);
var ez = new Vector3D(0, 0, 1);

var local = new Point3D(
    Vector3D.Dot(v, ex),
    Vector3D.Dot(v, ey),
    Vector3D.Dot(v, ez)
);

Console.WriteLine(local);
