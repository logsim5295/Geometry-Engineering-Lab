# 실습 04 · 내적 각도와 3D 외적

[Home](Home.md) · [Phase 1](Phase-1-3D-Math.md)

**상태:** 2026-10-30 P1-10 내적·각도 기본 검증 완료. 3D 외적은 도입만 제시, 첫 질문·구현·검증 미완료. **시간:** 30~60분 × 3회.

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

문서 작성 검증(2026-10-26): .NET SDK 10.0.402에서 C# 예제를 실행해 `Dot / Cross checks passed.`를 확인했다. 당시 학습자 실습과 좌표계 연결 과제는 미완료였으며, 2026-10-30 내적·각도의 학습자 실행은 아래에 별도로 기록한다. 학습 후 직접 선택한 입력·출력·오차와 설명을 추가한다.

## 새롭게 이해한 점

학습 후 작성: “외적을 정규화하기 전에 어떤 입력을 검사해야 하는가?”

## 다음 학습

외적의 첫 방향 질문 → 오른손 규칙·역순 부호·평행 입력 검증 → 좌표계의 원점과 직교 단위 기저. 참고: [KOCW·3Blue1Brown·OCCT Modeling Data](References.md).


## 2026-10-30 · 학습자 내적·각도 직접 실행

기존 `01-3D-Math/02-Vector/Vector2D.cs`의 Dot 구현을 재사용하고 `PointVectorPractice/Program.cs`의 AngleDegrees 함수로 확장했다. 이번 구현은 2D이며, 대화에서 사용한 3D 예제는 Z=0이다. 일반 3D 외적·좌표계 구현까지 완료한 것은 아니다.

손계산: a=(1,0,0)과 b=(1,0,0), (-1,0,0), (0,3,0)의 내적을 각각 1, -1, 0으로 답했다. 단위 방향 (0.6,0.8,0)과 X축의 내적 0.6 및 예각 관계를 확인했고, (6,8,0)과 X축은 내적 6, cosθ=6/10=0.6, 약 53.1°임을 답했다. 내적에는 길이도 반영되지만 양의 배율로 길이만 바꾸면 방향과 각도는 같음을 확인했다.

학습자가 직접 보고한 출력:

```text
같은 방향: 0.0°
수직 방향: 90.0°
반대 방향: 180.0°
각도 계산 실패: 벡터의 길이가 0이면 각도를 계산할 수 없습니다.
단위 벡터: 53.1°
길이 10 벡터: 53.1°
```

학습자는 영벡터의 내적이 0이어도 방향이 없으므로 각도를 90°라고 할 수 없다고 설명하고 예외 처리를 선택했다. 실제 소스에서 길이 0 검사, ArgumentException, `Math.Clamp(cosine,-1,1)`, `Math.Acos` 및 라디안→도 변환을 확인했다. clamp는 코사인 입력 범위 보호이며, 범위를 벗어난 값이나 거의 평행한 입력을 별도로 주입하는 테스트는 이번에 수행하지 않았다. 53.1°는 소수 첫째 자리 표시 결과이며 전체 정밀도 오차를 측정한 값은 아니다.

P1-10의 기본 내적·각도·영벡터 검증은 완료한다. 외적은 X×Y=Z와 두 입력에 수직인 방향이라는 도입만 제시했으며 첫 질문에는 아직 답하지 않았다. 외적 구현·수직성·역순 부호·평행/반평행·거의 평행 검증은 다음 과제다.

**다음 재개 질문:** X축과 Y축에 모두 수직인 방향은 +Z 외에 무엇인가? 답변 후 외적 방향 선택과 오른손 규칙, 순서 반전으로 이어간다.
