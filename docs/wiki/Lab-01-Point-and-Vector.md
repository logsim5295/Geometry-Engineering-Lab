# 실습 01 · Point와 Vector, 이동 원리

[Home](Home.md) · [Phase 1](Phase-1-3D-Math.md) · [다음 실습](Lab-02-Rotation.md)

**상태:** 기존 코드 있음, 이번 검증 미완료. **시간:** 30~60분 × 3회(첫 회차는 아래 C# 검증).

## 해결하려는 문제

CAD 형상의 위치와 이동량을 구분하고, 이미 수행한 형상 이동을 수학적으로 설명한다. 기존 Point2D/Vector2D를 다시 만들지 않는다.

## 핵심 수학

점은 위치, 벡터는 변위와 방향·크기를 나타낸다. `B−A=v`, `A+v=B`이다. `p'=p+t`에서 p는 점이고 t는 이동 벡터다. 점+점은 이 모델에서 제공하지 않는다. 원점에서 점까지의 위치 벡터는 선택한 좌표계에 의존한다.

벡터는 평행 이동으로 바뀌지 않는다. 크기가 0인 벡터에는 방향이 정의되지 않는다. 현재 `Vector2D.Normalized()`는 영벡터를 그대로 반환하므로 이 결과를 단위 방향으로 사용하면 안 된다.

## 구현 방법과 C# 예제

별도 임시 콘솔 프로젝트에서 기존 `01-3D-Math.csproj`를 참조하고 아래를 `Program.cs`로 사용한다. 기존 라이브러리 프로젝트에 top-level 코드를 직접 넣지 않는다. 기존 프로젝트는 `net10.0`이다.

```csharp
using _01_3D_Math;

static void Near(double actual, double expected)
{
    if (!double.IsFinite(actual) || Math.Abs(actual - expected) > 1e-9)
        throw new Exception($"Expected {expected}, got {actual}");
}

var a = new Point2D(1, 2);
var b = new Point2D(4, 6);
var displacement = b - a;
var moved = a + displacement;
Near(displacement.X, 3);
Near(displacement.Y, 4);
Near(displacement.Length(), 5);
Near(moved.X, b.X);
Near(moved.Y, b.Y);
Near(Point2D.Distance(a, b), 5);
Near(displacement.Normalized().Length(), 1);
Near(new Vector2D(0, 0).Normalized().Length(), 0); // 현재 구현의 정책
Console.WriteLine("Point / Vector checks passed.");
```

예제의 `1e-9`는 작은 좌표의 수치 실습 기준이며 실제 CAD 모델에 일괄 적용하는 tolerance가 아니다.

## OpenCascade 적용

적용함. 기존 형상 이동 예제를 재사용한다.

- gp_Pnt: 위치를 표현한다.
- gp_Vec: 크기가 있는 벡터이며 이동량을 표현할 수 있다.
- gp_Dir: 단위 방향을 표현한다. 영벡터로 방향을 만들지 않는다.
- gp_Trsf: 이동 변환을 정의하고 점/형상에 적용한다.

OCCT 버전 및 C# 바인딩이 아직 확인되지 않았으므로 실행 가능한 C# OCCT API 호출을 가정하지 않는다. 사용한 래퍼의 메서드와 공식 API를 대응시킨 뒤 원래 이동 코드에 주석을 추가한다.

## 테스트와 예상 결과

| 입력·검사 | 예상 결과 |
|---|---|
| A=(1,2), B=(4,6), B−A | (3,4), 길이 5 |
| A+(B−A) | B=(4,6) |
| (3,4) 정규화 | (0.6,0.8), 길이 1 |
| (0,0) 정규화 | 현재 코드에서는 (0,0); 단위 방향 아님 |
| p=(1,2,3), t=(10,0,0) | 이동된 점 (11,2,3) |
| v=(1,2,3)에 같은 순수 이동 적용 | 벡터 성분 불변 |

## 완료 기준

- [ ] 점/변위/단위 방향의 차이를 예제로 설명함
- [ ] C#의 정상 입력 및 영벡터 정책을 확인함
- [ ] 이동 전후 점과 벡터의 차이를 기록함
- [ ] 기존 이동 코드 위치, OCCT/래퍼 버전, 실행 결과를 남김

## 실습 결과

문서 작성 검증(2026-10-26): .NET SDK 10.0.402 임시 콘솔에서 기존 프로젝트를 참조해 위 예제를 실행했고 `Point / Vector checks passed.`를 확인했다. 학습자 본인의 원리 검증·실습 기록은 미완료다. 형상 이동 수행 자체는 학습자 확인으로 완료이며 원리 검증과 결과 기록이 남았다.

## 새롭게 이해한 점

학습 후 직접 작성: “점의 좌표에 이동량을 더하는 것과 방향 벡터에 변환을 적용하는 것은 어떻게 다른가?”

## 다음 학습

[회전축과 회전각](Lab-02-Rotation.md). 참고: [KOCW와 OCCT 공식 자료](References.md).
