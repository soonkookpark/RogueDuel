# 프로젝트 운영 노트 (AI 세션 인계용)

이 파일은 이 프로젝트를 처음 보는 AI 세션(또는 다른 사람)이 현재
상태를 빠르게 파악하기 위한 문서입니다. 비밀값(API 키 등)은 여기
절대 적지 않습니다 — 필요한 키는 `.env`(git 제외)에 있습니다.

## 문서 구조

- `RogueDuel_최종_통합기획서.md` — 최종 확정 기획서 (이게 기준 문서)
- `RogueDuel_기획서.md`, `RogueDuel_게임디자인_기획서.md` — 통합 전
  원본 문서 (근거 자료로만 참고, 개발 기준은 통합본을 따를 것)
- `RogueDuel_체크리스트.md` — 로컬 마크다운 체크리스트 (Notion 원본)

## Notion 연동 상태

- Notion Integration 이름: "claudeCode"
- API 키 위치: 프로젝트 루트 `.env` 파일의 `NOTION_API_KEY`
  (반드시 `.gitignore`에 있는지 확인 후 사용할 것 — 이 레포는
  GitHub Public 레포로 운영하기로 되어 있음, 15번 섹션 참고)
- 연결된 노션 페이지: `.env`의 `NOTION_PAGE_ID`
- 생성된 데이터베이스: **"RogueDuel Dev Tracker"**
  (https://app.notion.com/p/3ba4ae22883b81a6ba3ec2c513baf1c7)
  - 속성: Name(제목), Phase(select: v0.1~v1.0/버퍼/Stretch),
    Status(select: 시작 전/진행 중/완료), Date(기간), Order(정렬용)
  - 총 86개 작업 항목이 `RogueDuel_체크리스트.md` 기준으로 이미
    입력되어 있음
  - 날짜는 2026-08-12(프로젝트 시작일) 기준으로 로드맵 14번 섹션의
    주차를 실제 캘린더 날짜로 환산해 채워짐
  - Notion API는 뷰(Board/Timeline/Calendar) 생성을 지원하지 않아,
    Date 속성을 기준으로 Timeline/Calendar 뷰를 만들려면 Notion
    UI에서 "+ 뷰 추가"를 한 번 수동으로 눌러야 함 (데이터는 이미
    준비되어 있어 뷰 추가만 하면 바로 보임)

## Notion API 재사용 시 참고

- PowerShell(Windows PowerShell 5.1)로 Notion API를 호출할 때,
  **한글이 포함된 .ps1 스크립트 파일을 `-File`로 직접 실행하면
  인코딩이 깨진다** (BOM 없는 UTF-8을 시스템 코드페이지로 오인식).
  해결: 한글 데이터는 별도 JSON 파일로 분리하고, `.ps1` 스크립트
  자체는 ASCII만 사용하며 `Get-Content -Raw -Encoding UTF8`로
  JSON을 읽어 처리할 것.
- Notion select 속성의 color는 다음 10개만 허용:
  default, gray, brown, orange, yellow, green, blue, purple, pink, red
  (teal 등은 400 에러 발생)
- 새 페이지를 Integration에 공유하지 않으면 API가 404
  `object_not_found`를 반환함 — 페이지 "..." 메뉴에서
  연결 추가(Add connections) 필요

## 다음 단계

RogueDuel_최종_통합기획서.md 14번 섹션 v0.1부터 순서대로 진행.
Notion Dev Tracker의 Status를 진행 상황에 맞춰 업데이트하면 됨.
