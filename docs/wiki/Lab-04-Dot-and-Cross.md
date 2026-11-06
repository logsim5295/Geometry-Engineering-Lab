# 실습 04 · 내적 각도와 3D 외적

[Home](Home.md) · [Phase 1](Phase-1-3D-Math.md)

**상태:** 2026-11-06 · P1-10 완료, P1-11 진행 중. 2D·3D 외적과 수직성·넓이 실행 확인, 단위 법선·남은 경계 조건 검증 예정.

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

학습자 답변: “외적 벡터가 영벡터인지 확인한다.” 외적의 길이가 평행사변형 넓이이고 그 절반이 삼각형 넓이임을 이해했다. 단위 법선의 코드 실행은 다음 과제다.

## 다음 학습

단위 법선 구현·정상값·평행 입력 예외 → 3D 역순·반평행 출력 확인과 거의 평행 보완 → 좌표계의 원점과 직교 단위 기저. 참고: [KOCW·3Blue1Brown·OCCT Modeling Data](References.md).


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

**당시(2026-10-30) 재개 질문:** X축과 Y축에 모두 수직인 방향은 +Z 외에 무엇인가? 현재 재개 지점은 아래 2026-11-06 기록을 따른다.

## 2026-11-06 · 외적 구현과 삼각형 넓이 학습 기록

11월 4~6일 대화의 학습 결과를 11월 6일에 정리했다. 아래 실제값은 학습자가 직접 실행해 보고한 결과이며, 이번 문서 업데이트에서 새 실행을 한 것은 아니다.

| 검증 | 입력 | 학습자 보고 결과 |
|---|---|---|
| 2D 외적 | (1,0)×(0,1), 역순, (1,0)×(2,0) | 1, -1, 0 |
| 3D 외적 | a=(1,2,3), b=(4,5,6) | (-3,6,-3) |
| 수직성 | (a×b)·a, (a×b)·b | 모두 0 |
| 삼각형 넓이 | 위 a와 b를 같은 꼭짓점에서 출발하는 두 변으로 사용 | 3.6742346141747673 |
| 평행 입력 | (2,0,0)×(4,0,0) | 외적 (0,0,0), 삼각형 넓이 0 |

### 이해한 내용

- 2D Cross는 3D 외적의 Z 성분만 double로 반환한다. 식은 x1*y2-y1*x2이며, 역순이면 부호가 반대다.
- 3D Cross는 Vector3D를 반환한다. 결과와 두 입력의 내적이 0인지 확인해 수직성을 검증했다.
- 정규화 전에 외적이 영벡터인지 검사해야 한다고 학습자가 설명했다.
- AB=(2,0,0), AC=(0,3,0)의 외적 (0,0,6), 단위 법선 (0,0,1), 삼각형 넓이 3을 손으로 계산했다. 단위 법선 코드 실행과는 구분한다.
- 평행사변형 넓이 = 밑변×높이 = |a||b|sinθ = |a×b|임을 그림으로 학습했다. 삼각형 넓이는 그 절반이다. 일직선인 세 점의 외적과 넓이가 0임을 설명·실행 확인했다.

### 코드와 남은 검증

Geometry-Engineering-Lab의 `01-3D-Math/02-Vector/Vector2D.cs`, `Vector3D.cs`, `PointVectorPractice/Program.cs`를 확인했다. Vector3D에 Dot·Cross·Length가 있으며, 3D 역순·같은 방향·반대 방향 출력 코드도 있다. 소스가 있다는 사실만으로 학습자의 출력 검증을 완료 처리하지 않는다. 새 소스의 원격 게시 여부는 이번 기록에서 확인하지 않았다.

3D 역순·반평행 출력은 아직 별도로 보고받지 않았다. 거의 평행한 입력의 오차 검증과 UnitNormal의 구현·정상값·평행 입력 예외 실행도 남았다. 제시된 UnitNormal의 length==0 검사는 기본 실습용이며, 허용오차 정책을 구현한 것으로 기록하지 않는다.

**다음 재개 지점:** UnitNormal을 구현하고 (2,0,0), (0,3,0)에서 단위 법선 (0,0,1), 길이 1을 출력한다. 이어서 평행 입력 예외와 3D 역순·반평행 출력을 확인하고, 거의 평행한 경우를 보완한다. 그 다음 World/Local 좌표계로 진행한다.
