# Phase 3 · OpenCascade 및 3D Geometry

[Home](Home.md) · [이전 Phase](Phase-2-Computational-Geometry.md) · [다음 Phase](Phase-4-Optimization.md)

**목표:** CAD 커널의 수학적 Geometry와 연결·경계 구조인 Topology를 이해하고 실제 형상을 분석한다. **참고 기간:** 8~10주. **상태:** 본 과정 미착수, 형상 이동 선행 실습 완료(학습자 확인).

## 환경과 구현 방식

먼저 기존 이동 실습에 사용한 OCCT 버전, C# 래퍼/바인딩, 빌드 구조를 기록한다. 현재 저장소에는 이 정보가 없다. 공식 C++ API 이름을 C#에서 그대로 사용할 수 있다고 가정하지 않는다. 기존 연동 환경을 재사용하고, 직접 C++/CLI 연동 구현은 필요할 때 별도 회차로 분리한다.

예정 코드 폴더: `03-OpenCascade/`. Phase 1의 이동·회전 예제를 재사용한다. 커널·래퍼 버전과 단위, tolerance, 실행 방법을 README에 고정한다.

## 세부 학습 순서

| 순서 | 핵심 개념 | 30~60분 실습 단위 / 완료 기준 |
|---|---|---|
| 1 Basic Geometry | 좌표, 단위, tolerance | 기존 이동 예제의 버전·입력·출력 기록 |
| 2 Point·Vector·Direction·Axis | gp_Pnt, gp_Vec, gp_Dir, gp_Ax1, gp_Ax2 | 점·변위·단위 방향·좌표 프레임을 생성하고 역할 설명 |
| 3 Curve와 Surface | gp_Lin, gp_Pln, 곡선/곡면 매개변수 | 직선·원 또는 평면의 점 평가; 매개변수와 공간 좌표 구분 |
| 4 Topology | Vertex, Edge, Wire, Face, Shell, Solid, Compound | 간단한 상자의 Face와 Edge 탐색; 발생 횟수와 고유 개수 구분 |
| 5 B-Rep | 경계, 공유, 방향, 형상 위치 | Edge와 underlying Curve, Face와 Surface 관계를 그림으로 기록 |
| 6 Shape 생성 | TopoDS_Shape, 경계·유효성 | 상자→원통→Wire/Face를 별도 회차 생성하고 유효성 확인 |
| 7 Shape Transformation | gp_Trsf, 형상 변환 | Phase 1 검증 재사용, Location과 형상 변환 결과 비교 |
| 8 Boolean Operation | Cut, Fuse, Common | 겹치는 상자 2개, 분리된 상자, 접촉만 하는 상자를 각각 비교 |
| 9 Geometry Analysis | Bounding Box, 거리, 교차 | AABB 후보 검사→최소 거리→Boolean 결과를 각각 기록 |
| 10 STEP Import 및 분석 | 읽기, 전송, Shape, 단위 | 합성 STEP 읽기→상태 확인→토폴로지 탐색→분석 보고서 |

## 검증 원칙

모든 TopoDS_Shape가 Solid인 것은 아니다. Shell은 Face의 집합이며 Solid의 유효한 경계를 이루는지 별도 확인한다. B-Rep을 단순히 삼각형 메시와 동일시하지 않는다.

Boolean 연산은 성공 여부, 오류/경고, 결과 null 여부, 유효성을 확인하고 입력·출력 체적을 비교한다. 접촉·포함·양의 체적 겹침을 구분한다. 거리 0이나 AABB 겹침 하나만으로 체적 충돌을 확정하지 않는다.

STEP은 `ReadFile` 및 전송 성공을 확인한 뒤 분석한다. 기본 Shape 분석과 이름·색상·조립 구조를 다루는 XDE는 범위가 다르며, XDE는 기초 완료 후 확장한다.

## Phase 완료 기준

- [ ] Geometry와 Topology, Curve/Edge 및 Surface/Face의 차이를 설명함
- [ ] B-Rep의 연결·방향·위치를 설명하고 Face/Edge를 탐색함
- [ ] 형상 생성·변환·Boolean과 Bounding Box·거리 분석을 검증함
- [ ] STEP 파일의 단위와 Shape 구조를 분석하고 오류 조건을 기록함

전체 주제는 이동 선행 경험을 제외하면 미착수다. [공식 참고 자료](References.md)의 **Modeling Data**, **Modeling Algorithms**, **gp_Trsf**, **STEP Translator**를 사용한다. 설치 버전과 문서 버전이 다르면 해당 버전의 API를 다시 확인한다.
