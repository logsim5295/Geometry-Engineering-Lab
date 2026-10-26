# 실습 03 · 이동과 회전의 순서

[Home](Home.md) · [Phase 1](Phase-1-3D-Math.md) · [다음 실습](Lab-04-Dot-and-Cross.md)

**상태:** 미착수. **시간:** 30~60분 × 3회. **문제:** 같은 이동·회전을 적용했는데 형상이 다른 곳에 놓이는 이유를 설명한다.

## 핵심 수학

P=(1,0), 이동 t=(2,0), 원점 기준 회전 R=+90°이면:

- 이동 후 회전: `R(P+t)=(0,3)`
- 회전 후 이동: `R(P)+t=(2,1)`

열벡터에서는 `R T P`가 이동 후 회전이다. 합성의 역변환은 역순으로 적용한다. `M=T R`이면 `M⁻¹=R⁻¹ T⁻¹`이다.

## 구현 방법과 C# 예제

첫 회차는 2D 수치로 비교한다. 아래는 독립 콘솔 프로그램이며 3D Z축 회전의 XY 성분과 같다.

```csharp
static (double X, double Y) Move((double X, double Y) p) => (p.X+2, p.Y);
static (double X, double Y) Turn((double X, double Y) p) => (-p.Y, p.X);
var p = (X: 1.0, Y: 0.0);
var moveThenTurn = Turn(Move(p));
var turnThenMove = Move(Turn(p));
if (moveThenTurn != (0.0, 3.0) || turnThenMove != (2.0, 1.0))
    throw new Exception("Composition order mismatch");
Console.WriteLine($"R(T(P)) = {moveThenTurn}; T(R(P)) = {turnThenMove}");
```

이 예제는 정수값으로 정확한 90° 변환을 정의해 정확 비교를 쓴다. 일반 sin/cos 계산에서는 tolerance로 비교한다.

## OpenCascade 적용

적용함. 먼저 변환을 순차 적용해 기준 결과를 얻는다. 이후 gp_Trsf의 합성 연산으로 같은 결과를 재현한다. `Multiply`와 `PreMultiply`는 순서가 다르므로 메서드 이름만 추측하지 말고 설치 버전 문서와 기준점 결과로 확인한다.

각 형상은 동일한 원본에서 출발한다. 첫 결과를 두 번째 실험의 원본으로 사용해 변환을 누적하지 않는다.

## 테스트와 예상 결과

P=(1,0,0)에 t=(2,0,0), 원점 Z축 +90°를 적용하면 순서에 따라 (0,3,0), (2,1,0)이 된다. 각 합성에 역변환을 적용하면 원래 P로 돌아와야 한다. 두 변환 순서 모두 점 사이 거리는 보존한다.

## 완료 기준

- [ ] 두 순서의 결과를 계산하고 C#·OCCT에서 검증함
- [ ] 열/행벡터 규약과 라이브러리 적용 순서를 기록함
- [ ] 역변환 왕복 테스트와 형상 기준점 좌표를 기록함

## 실습 결과

문서 작성 검증(2026-10-26): .NET SDK 10.0.402에서 C# 예제를 실행해 `R(T(P)) = (-0, 3); T(R(P)) = (2, 1)`을 확인했다. 부동소수점의 −0은 여기서 0과 같은 값이다. 학습자 실습·OCCT 비교·역변환 검증은 미완료이며 실제 형상 결과는 학습 후 추가한다.

## 새롭게 이해한 점

학습 후 작성: “첫 번째 순서에서는 이동 벡터 자체도 회전하는가?”

## 다음 학습

[내적 각도·외적](Lab-04-Dot-and-Cross.md), 이후 좌표계와 4×4 행렬. 참고: [gp_Trsf](References.md).
