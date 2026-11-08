# 참고 자료

[Home](Home.md)

확인일: 2026-10-26. 아래 링크는 검색 또는 페이지 접근으로 존재를 확인했다. 한국어를 우선 사용하며 계산 기하·OCCT는 공식 영어 문서로 보완한다. 한국어가 아닌 자료를 한국어 강의로 표시하지 않는다. 강좌 전체를 순서대로 수강하기보다 현재 실습에 필요한 단원만 읽는다.

| 자료 | 언어·성격 | 사용할 주제 |
|---|---|---|
| [KOCW · 성균관대학교 선형대수학](https://www.kocw.net/home/search/kemView.do?ar=relateCourse&kemId=704693) | 한국어, 공개 대학 강의 | Phase 1의 벡터·행렬·선형변환. 대각화 등은 당장 필요할 때만 |
| [3Blue1Brown · Linear Algebra](https://www.3blue1brown.com/?topic=linear-algebra) | 영어, 제작자 자료 | 벡터·기저·선형변환의 시각적 직관. 한국어 자막 제공을 전제하지 않음 |
| [OCCT · Modeling Data](https://occt3d.com/dev/doc/overview/html/occt_user_guides__modeling_data.html) | 공식 영어 문서 | Phase 1·3의 기하 타입, Geometry·Topology·B-Rep |
| [OCCT · gp_Trsf](https://occt3d.com/dev/doc/refman/html/classgp___trsf.html) | 공식 영어 API | 회전·이동·합성, Multiply/PreMultiply와 좌표 변환 의미 |
| [OCCT · Modeling Algorithms](https://occt3d.com/dev/doc/overview/html/occt_user_guides__modeling_algos.html) | 공식 영어 문서 | Phase 3의 형상 생성·변환·교차·Boolean |
| [OCCT · STEP Translator](https://occt3d.com/dev/doc/overview/html/occt_user_guides__step.html) | 공식 영어 문서 | STEP 읽기·전송·Shape 분석, XDE 확장 |
| [Clipper2](https://www.angusj.com/clipper2/) | 제작자 공식 영어 문서 | Phase 2·5의 다각형 clipping·offset 비교와 지원 범위 확인 |
| [Shewchuk · Robust Predicates](https://www.cs.cmu.edu/~quake/robust.html) | 저자 논문·코드, 영어 | 거의 공선인 입력 등 수치 안정성 심화. 처음부터 전체 구현을 이식하지 않음 |
| [Google OR-Tools · Packing](https://developers.google.com/optimization/pack?hl=ko) | 공식 한국어 문서 | Phase 4·5의 목적 함수·제약 모델링. 불규칙 2D Nesting 완성 엔진은 아님 |
| [Google OR-Tools · Bin Packing](https://developers.google.com/optimization/pack/bin_packing?hl=ko) | 공식 한국어 문서, C# 예제 포함 | 작은 기준 문제의 모델링과 해 확인 |
| [SciPy · Dual Annealing](https://docs.scipy.org/doc/scipy/reference/generated/scipy.optimize.dual_annealing.html) | 공식 영어 문서 | 온도·종료 조건·난수 설정 참고. 연속 최적화의 변형 알고리즘으로, 기본 이산 SA와 동일하지 않음 |
| [pymoo · Genetic Algorithm](https://pymoo.org/algorithms/soo/ga.html) | 공식 영어 문서 | GA의 선택·교차·변이 흐름과 비교 실험 참고 |
| [pymoo · Particle Swarm Optimization](https://pymoo.org/algorithms/soo/pso.html) | 공식 영어 문서 | PSO의 위치·속도·개인/전체 최선 개념. 이산 배치에는 별도 인코딩 필요 |
| [Google · 머신러닝 단기집중과정](https://developers.google.com/machine-learning/crash-course?hl=ko) | 공식 한국어 문서 | Phase 6의 회귀·분류·데이터·과적합 |
| [Google · 머신러닝 실습](https://developers.google.com/machine-learning/crash-course/exercises?hl=ko) | 공식 한국어 안내 | 필요한 모듈의 짧은 실습. Python 예제는 Geometry 코드와 분리 |

## 자료 사용 규칙

OCCT 공식 문서의 기존 `dev.opencascade.org` 링크는 확인 시 `occt3d.com` 문서로 이동했다. 확인한 문서는 8.0.1이며 학습자의 설치 버전은 아직 확인되지 않았다. 실제 호출은 설치 버전과 C# 바인딩의 지원 범위를 확인한다.

API 사용 결과는 화면만 보고 판단하지 않고 기대 좌표·거리·면적·체적과 비교한다. 링크와 API가 AI의 제안일 경우에도 실제 존재와 지원 버전을 확인한다. 참고 자료에 없는 구현상의 판단은 학습 실험에서 가정과 검증 결과로 기록한다.
