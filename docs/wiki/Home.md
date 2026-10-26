# Geometry Engineering 학습 Wiki

> **현재 위치:** Phase 1 · 3D Math / Vector 기초 진행 중  
> **지금 할 일:** [Point와 Vector 구분 실습](Lab-01-Point-and-Vector.md) — 기존 코드를 이용해 30~60분 검증  
> **다음 할 일:** 이동 변환의 원리를 정리한 뒤 [회전축과 회전각 실습](Lab-02-Rotation.md)

**[학습 진행도·체크리스트 열기 →](Progress.md)** — 6개 Phase의 항목별 완료 여부, 진행률, 학습 기록을 관리한다.

기준일: 2026-10-26. 학습 상태의 기준과 근거는 [진행도·체크리스트](Progress.md)에서 관리한다.

## 프로젝트 목적

수학적 원리를 설명하고, C#으로 기하 알고리즘을 구현하며, OpenCascade에서 실제 형상으로 검증하는 장기 학습 프로젝트다. 의류 패턴 2D CAD와 Nesting 개발에 적용할 수 있는 계산 기하·최적화 역량을 쌓고 3D CAD 커널 이해로 확장한다.

## 학습자 프로필

- SOLIDWORKS 엔지니어 약 7년 경력, 3D CAD 및 PDM 기술 경험
- SOLIDWORKS API 자동화와 C# 응용프로그램 개발 경험
- 현재 의류 패턴 2D CAD 및 Nesting 프로그램 개발 중
- 3D Geometry에 대한 실무 경험과 관심, OpenCascade 학습 희망

초급 프로그래밍 강의를 반복하지 않는다. 구현 경험을 바탕으로 수학, 알고리즘, CAD 커널의 동작과 검증에 집중한다.

## 최종 학습 목표

1. 3D 공간의 점·벡터·좌표계·행렬을 자신의 언어로 설명한다.
2. 이동·회전·스케일·좌표 변환을 CAD 기능에 적용한다.
3. C#으로 거리·투영·교차·다각형 알고리즘을 구현하고 경계 조건을 검증한다.
4. OpenCascade의 Geometry, Topology, B-Rep 관계를 설명한다.
5. 형상 생성·변환·교차·거리 분석과 STEP 구조 분석을 구현한다.
6. 기하 알고리즘을 2D 패턴과 Nesting 문제에 적용한다.
7. Greedy, Heuristic, Local Search, SA, GA 등을 같은 조건에서 비교한다.
8. 기존 알고리즘 대비 이점이 확인되는 경우에 AI를 결합한다.

## 전체 커리큘럼

| 단계 | 목표와 대표 결과물 | 참고 기간 | 상태 |
|---|---|---|---|
| [Phase 1 · 3D Math](Phase-1-3D-Math.md) | 벡터·좌표계·행렬·변환 / 수학 계산과 형상 변환 비교 | 8~10주 | 진행 중 |
| [Phase 2 · Computational Geometry](Phase-2-Computational-Geometry.md) | 거리·투영·교차·다각형 / GeometryLab | 10~12주 | 미착수 |
| [Phase 3 · OpenCascade](Phase-3-OpenCascade.md) | Geometry·Topology·B-Rep / STEP 분석 | 8~10주 | 본 과정 미착수, 이동 선행 실습 완료 |
| [Phase 4 · Optimization](Phase-4-Optimization.md) | 목적 함수·제약·탐색 / 동일 문제 알고리즘 비교 | 8~10주 | 미착수 |
| [Phase 5 · Nesting Engineering](Phase-5-Nesting.md) | 기하와 최적화 결합 / Mini Nesting | 8~12주 | 미착수 |
| [Phase 6 · AI + Geometry](Phase-6-AI-Geometry.md) | 후보 점수 예측 / 기존 탐색과 결합 평가 | 6~8주 | 미착수 |

합계 48~62주는 학습량을 가늠하는 참고 범위다. 평일 30~60분, 주 3~4회(주 1.5~4시간)를 기준으로 하며 마감 일정이 아니다. 어려운 알고리즘은 여러 회차로 나누고 필요하면 기간을 늘린다. Phase 1의 OpenCascade 선행 실습은 Phase 3에서 재사용한다.

## 현재 진행 상황

- **완료:** OpenCascade 형상 이동 실습 — 학습자 확인 기준
- **진행 중:** Vector 개념 이해. 저장소에 Point2D 및 Vector2D 기본 연산·정규화·내적 구현 존재
- **다음 검증:** Point와 Vector 의미, 영벡터 처리, gp_Pnt·gp_Vec·gp_Dir 역할, gp_Trsf 이동 원리
- **미완료:** 회전, 변환 합성, 내적을 이용한 각도, 3D 외적, 좌표계와 행렬 확장

코드가 존재한다는 사실만으로 학습 또는 테스트 완료로 표시하지 않는다. [진행도 대시보드](Progress.md)의 완료율은 고유 ID가 있는 체크 항목 수를 기준으로 계산하며 숙련도나 학습 시간의 비율은 아니다.

## 학습 운영

**개념 → 수학적 원리 → 작은 C# 구현 → 필요한 경우 OpenCascade 적용 → 수치 검증 → README 기록** 순서로 진행한다.

한 회차는 개념 10분, 구현 20~30분, 검증 10분, 기록 5~10분을 기본으로 한다. 30분밖에 없으면 구현과 검증을 다음 회차로 분리한다. 한 회차에서 작은 기능 하나 또는 테스트 묶음 하나를 끝낸다.

- [다음 4주 계획](Next-4-Weeks.md): 주 3회 필수 + 선택 1회
- [학습 진행도·체크리스트](Progress.md): 항목별 상태, 완료율, 학습 기록의 단일 기준
- [실습 기록 양식](Lab-Template.md): 실제 결과와 예상 결과를 분리
- [참고 자료](References.md): 한국어 우선, 공식 문서와 확인된 링크

새 주제를 추가할 때 선행 개념, 현재 개발 문제와의 연결, 작은 실습, 완료 기준을 함께 적는다. 검증하지 않은 결과나 AI가 생성한 설명을 완료 근거로 사용하지 않는다.

## 코드와 문서 구조

현재 저장소 이름은 `Geometry-Engineering-Lab`, 솔루션 파일은 `3D-Engineering-Study.slnx`이다. 기존 이름과 코드는 유지한다.

```text
Geometry-Engineering-Lab/
├── 3D-Engineering-Study.slnx          # 기존
├── 01-3D-Math/                       # 기존
│   ├── 01-Primitives/Point2D.cs
│   └── 02-Vector/Vector2D.cs
├── docs/wiki/                       # 이번에 작성한 Wiki 원고
├── 02-Computational-Geometry/       # 해당 Phase 착수 시 생성 예정
├── 03-OpenCascade/                  # 해당 Phase 착수 시 생성 예정
├── 04-Optimization/                 # 해당 Phase 착수 시 생성 예정
├── 05-Nesting/                      # 해당 Phase 착수 시 생성 예정
└── 06-AI/                           # 해당 Phase 착수 시 생성 예정
```

루트 README는 문서 진입점으로 사용한다. 예정 폴더는 아직 생성하거나 구현하지 않았다. 실습을 추가할 때 독립 실행 방법 또는 호출 예제와 README를 함께 둔다. 업무 소스, 기밀 정보, 고객 데이터는 사용하지 않고 합성 도형과 공개 사용이 허용된 샘플을 사용한다.
