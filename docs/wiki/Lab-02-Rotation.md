# 실습 02 · 회전축과 회전각

[Home](Home.md) · [Phase 1](Phase-1-3D-Math.md) · [다음 실습](Lab-03-Transformation-Order.md)

**상태:** 미착수. **시간:** 30~60분 × 3회. **주제:** 원점 Z축과 임의의 점을 지나는 Z방향 축 비교, 이후 일반 축으로 확장.

## 해결하려는 문제와 수학

같은 회전각이라도 축의 위치가 다르면 결과가 달라진다. 오른손 좌표계에서 Z축 +90° 회전은 +X 방향을 +Y로 보낸다.

```text
x' = cosθ·x − sinθ·y
y' = sinθ·x + cosθ·y
z' = z
중심 C를 지나는 Z방향 축: P' = C + Rz(P − C)
```

회전축은 점 C와 방향 d의 조합이다. 임의 위치의 Z방향 축과 임의 방향 축은 다른 단계다. 일반 단위축 k는 Rodrigues 공식 `Rv=v cosθ+(k×v) sinθ+k(k·v)(1−cosθ)`로 확장한다.

## 구현 방법과 C# 예제

독립 콘솔의 `Program.cs`에 넣는 BCL만 사용하는 수치 예제다. 첫 회차는 Z방향 축만 구현한다.

```csharp
static (double X, double Y, double Z) RotateZ(
    (double X, double Y, double Z) p,
    (double X, double Y, double Z) center, double angle)
{
    double x = p.X - center.X, y = p.Y - center.Y;
    double c = Math.Cos(angle), s = Math.Sin(angle);
    return (center.X + c * x - s * y,
            center.Y + s * x + c * y, p.Z);
}
static void Check((double X, double Y, double Z) a,
                  (double X, double Y, double Z) b)
{
    double error = Math.Max(Math.Abs(a.X-b.X),
        Math.Max(Math.Abs(a.Y-b.Y), Math.Abs(a.Z-b.Z)));
    if (!double.IsFinite(error) || error > 1e-9) throw new Exception("Rotation mismatch");
}
Check(RotateZ((1,0,0), (0,0,0), Math.PI/2), (0,1,0));
Check(RotateZ((2,1,0), (1,1,0), Math.PI/2), (1,2,0));
Check(RotateZ((1,1,5), (1,1,0), Math.PI/2), (1,1,5));
var turned = RotateZ((2,1,0), (1,1,0), Math.PI/2);
Check(RotateZ(turned, (1,1,0), -Math.PI/2), (2,1,0));
Console.WriteLine("Rotation checks passed.");
```

## OpenCascade 적용

적용함. 공식 API의 개념 순서는 `gp_Ax1(축 위 점, gp_Dir(방향))` → `gp_Trsf.SetRotation(축, 라디안)` → 점과 형상에 적용이다. 실제 호출 문법은 기존 C# 바인딩에서 확인한다. 바인딩 미확인 코드를 실행 가능 예제로 표시하지 않는다.

## 테스트 방법과 예상 결과

위 C#의 네 사례를 OCCT에도 적용한다. 축 위 점은 움직이지 않고, 회전 전후 두 점의 거리와 축까지 거리는 보존되어야 한다. 회전각 0, ±90°, 180°와 역회전을 비교한다. 영방향 축 입력은 거부한다.

일반 축 확장에서는 원점과 k=(1,1,1)/√3을 사용해 +120° 회전한 (1,0,0)이 (0,1,0)이 되는지 확인한다. 순수 회전 검증이므로 스케일을 함께 적용하지 않는다.

## 완료 기준

- [ ] 각도 단위, 축의 위치와 방향을 설명함
- [ ] 원점 Z축·이동된 Z축 회전 결과를 수치로 검증함
- [ ] OCCT 결과와 C# 결과를 비교하고 거리 보존을 확인함
- [ ] 일반 축 확장은 별도 완료 여부를 기록함

## 실습 결과

문서 작성 검증(2026-10-26): .NET SDK 10.0.402에서 위 C# 예제를 실행해 `Rotation checks passed.`를 확인했다. 학습자 실습과 OCCT 비교·일반 축 확장은 미실행·미기록이다.

## 새롭게 이해한 점

학습 후 작성: “같은 각도를 적용해도 회전축 위치가 바뀌면 왜 점의 궤적이 달라지는가?”

## 다음 학습

[이동과 회전의 순서](Lab-03-Transformation-Order.md). 참고: [gp_Trsf 공식 문서](References.md).
