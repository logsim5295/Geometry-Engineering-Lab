# 실습 04 · 내적 각도와 3D 외적

[Home](Home.md) · [Phase 1](Phase-1-3D-Math.md)

**상태:** 내적의 2D 구현 있음, 각도·3D 외적 실습 미착수. **시간:** 30~60분 × 3회.

## 2026-10-27 재개 위치

기존 2D 내적 구현과 P1-10 진행 중 상태는 유지한다. 이번 대화에서는 내적 정의·부호만 소개했으며 계산 문제는 아직 응답하지 않았다. a=(1,0,0)에 대해 b=(1,0,0), (-1,0,0), (0,3,0)의 내적 세 문제부터 재개한다. 각도·외적·좌표계는 이번 대화에서 완료하지 않았다.

## 해결하려는 문제와 수학

두 방향이 얼마나 다른지 측정하고 두 방향에 수직인 방향을 구한다. `θ=acos((a·b)/(|a||b|))`, `a×b`는 두 입력에 수직이다. 각도는 영벡터에서 정의되지 않고, 평행 벡터의 외적도 영벡터이므로 단위 법선을 만들 수 없다.

## 구현 방법과 C# 예제

독립 콘솔의 `Program.cs`로 실행하는 제한된 교육 예제다. 기존 `Vector2D.Dot`와 비교한 뒤 같은 원리로 3D로 확장한다. 아래 코드는 소규모의 유한한 좌표를 대상으로 하며 극단적 크기의 overflow/underflow에 대한 범용 수치 구현은 아니다.

```csharp
static void Near(double a, double b)
{
    if (!double.IsFinite(a) || Math.Abs(a-b)>1e-9) throw new Exception("Mismatch");
}
var x = new V3(1,0,0);
var y = new V3(0,1,0);
Near(V3.Angle(x, x), 0);
Near(V3.Angle(x, y), Math.PI/2);
Near(V3.Angle(x, new V3(-1,0,0)), Math.PI);
var z = V3.Cross(x, y);
Near(z.X, 0); Near(z.Y, 0); Near(z.Z, 1);
Near(V3.Dot(z, x), 0); Near(V3.Dot(z, y), 0);
Near(V3.Cross(y,x).Z, -1);
Near(V3.Dot(V3.Cross(x,x), V3.Cross(x,x)), 0);
bool rejected = false;
try { V3.Angle(new V3(0,0,0), x); }
catch (ArgumentException) { rejected = true; }
if (!rejected) throw new Exception("Zero vector must be rejected");
Console.WriteLine("Dot / Cross checks passed.");

readonly record struct V3(double X, double Y, double Z)
{
    public static double Dot(V3 a, V3 b) => a.X*b.X + a.Y*b.Y + a.Z*b.Z;
    public static V3 Cross(V3 a, V3 b) => new(
        a.Y*b.Z-a.Z*b.Y, a.Z*b.X-a.X*b.Z, a.X*b.Y-a.Y*b.X);
    public static double Angle(V3 a, V3 b)
    {
        double aa=Dot(a,a), bb=Dot(b,b);
        if (aa<=0 || bb<=0 || !double.IsFinite(aa) || !double.IsFinite(bb))
            throw new ArgumentException("Finite non-zero vectors required");
        double cosine = Dot(a,b) / Math.Sqrt(aa) / Math.Sqrt(bb);
        if (!double.IsFinite(cosine)) throw new ArgumentException("Input scale unsupported");
        return Math.Acos(Math.Clamp(cosine, -1.0, 1.0));
    }
}
```

## OpenCascade 적용 여부

이번 실습은 C#만으로 진행해도 된다. 선택적으로 기존 바인딩의 gp_Vec에 해당하는 내적·외적·각도 연산과 비교한다. 단위 방향으로 변환하기 전에 영벡터인지 검사한다.

## 테스트 방법과 예상 결과

동일·직교·반대 벡터의 각도는 0, π/2, π이다. ex×ey=ez이며 ey×ex=−ez이다. 외적 결과와 원래 두 벡터의 내적은 0이다. 평행 입력의 외적은 0, 영벡터 각도는 오류여야 한다. 거의 평행한 입력도 추가해 acos 정의역을 확인한다.

## 완료 기준

- [ ] 각도 수식과 clamp 필요성을 설명함
- [ ] 영벡터와 평행 벡터의 차이를 처리함
- [ ] 외적의 수직성과 방향을 검증함
- [ ] O+x ex+y ey+z ez로 로컬 점을 월드 좌표로 계산함

## 실습 결과

문서 작성 검증(2026-10-26): .NET SDK 10.0.402에서 C# 예제를 실행해 `Dot / Cross checks passed.`를 확인했다. 학습자 실습과 좌표계 연결 과제는 미완료다. 학습 후 직접 선택한 입력·출력·오차와 설명을 추가한다.

## 새롭게 이해한 점

학습 후 작성: “외적을 정규화하기 전에 어떤 입력을 검사해야 하는가?”

## 다음 학습

좌표계의 원점과 직교 단위 기저, 로컬↔월드 변환, Matrix 구현. 참고: [KOCW·3Blue1Brown·OCCT Modeling Data](References.md).
