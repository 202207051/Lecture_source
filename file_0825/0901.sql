-- Database Creation & Switch
DROP DATABASE IF EXISTS univDB;
CREATE DATABASE IF NOT EXISTS univDB;
USE univDB;

-- 1. Table Declarations
CREATE TABLE 과목 (
    과목번호  CHAR(4)     NOT NULL,
    이름      VARCHAR(20) NOT NULL,
    강의실    CHAR(3)     NOT NULL,
    개설학과  VARCHAR(20) NOT NULL,
    시수      INT         NOT NULL,
    PRIMARY KEY (과목번호)
);

CREATE TABLE 학생 (
    학번       CHAR(4)     NOT NULL,
    이름       VARCHAR(20) NOT NULL,
    주소       VARCHAR(50) NULL DEFAULT '미정',
    학년       INT         NOT NULL,
    나이       INT         NULL,
    성별       CHAR(1)     NOT NULL,
    휴대폰번호 CHAR(14)    NULL,
    소속학과   VARCHAR(20) NULL,
    PRIMARY KEY (학번)
);

CREATE TABLE 수강 (
    학번     CHAR(4) NOT NULL,
    과목번호 CHAR(4) NOT NULL,
    신청날짜 DATE    NOT NULL,
    중간성적 INT     NULL DEFAULT 0,
    기말성적 INT     NULL DEFAULT 0,
    평가학점 CHAR(1) NULL,
    PRIMARY KEY (학번, 과목번호)
);

-- 2. Data Insertions
-- 학생 데이터
INSERT INTO 학생 VALUES ('s001', '김연아', '서울 서초', 4, 23,   '여', '010-1111-2222', '컴퓨터');
INSERT INTO 학생 VALUES ('s002', '홍길동', DEFAULT,     1, 26,   '남', NULL,           '통계');
INSERT INTO 학생 VALUES ('s003', '이승엽', NULL,        3, 30,   '남', NULL,           '정보통신');
INSERT INTO 학생 VALUES ('s004', '이영애', '경기 분당', 2, NULL, '여', '010-4444-5555', '정보통신');
INSERT INTO 학생 VALUES ('s005', '송윤아', '경기 분당', 4, 23,   '여', '010-6666-7777', '컴퓨터');
INSERT INTO 학생 VALUES ('s006', '홍길동', '서울 종로', 2, 26,   '남', '010-8888-9999', '컴퓨터');
INSERT INTO 학생 VALUES ('s007', '이은진', '경기 과천', 1, 23,   '여', '010-2222-3333', '경영');

-- 과목 데이터
INSERT INTO 과목 VALUES ('c001', '데이터베이스', 126, '컴퓨터',   3);
INSERT INTO 과목 VALUES ('c002', '정보보호',     137, '정보통신', 3);
INSERT INTO 과목 VALUES ('c003', '모바일웹',     128, '컴퓨터',   3);
INSERT INTO 과목 VALUES ('c004', '철학개론',     117, '철학',     2);
INSERT INTO 과목 VALUES ('c005', '전공글쓰기',   120, '교양학부', 1);

-- 수강 데이터
INSERT INTO 수강 VALUES ('s001', 'c002', '2019-09-03', 93, 98, 'A');
INSERT INTO 수강 VALUES ('s004', 'c005', '2019-03-03', 72, 78, 'C');
INSERT INTO 수강 VALUES ('s003', 'c002', '2017-09-06', 85, 82, 'B');
INSERT INTO 수강 VALUES ('s002', 'c001', '2018-03-10', 31, 50, 'F');
INSERT INTO 수강 VALUES ('s001', 'c004', '2019-03-05', 82, 89, 'B');
INSERT INTO 수강 VALUES ('s004', 'c003', '2020-09-03', 91, 94, 'A');
INSERT INTO 수강 VALUES ('s001', 'c005', '2020-09-03', 74, 79, 'C');
INSERT INTO 수강 VALUES ('s003', 'c001', '2019-03-03', 81, 82, 'B');
INSERT INTO 수강 VALUES ('s004', 'c002', '2018-03-05', 92, 95, 'A');

-- 3. Select Queries
-- 전체 데이터 조회
SELECT * FROM 학생;
SELECT * FROM 과목;
SELECT * FROM 수강;

-- 소속학과 오름차순 목록 (중복 제거)
SELECT DISTINCT 소속학과 
FROM 학생 
ORDER BY 소속학과 ASC;

-- 2학년 이상 컴퓨터학과 학생 조회 
-- (참고: 입력된 데이터에는 소속학과가 '컴퓨터'로 저장되어 있으므로 아래 쿼리는 0건이 반환될 수 있습니다)
SELECT 이름, 학년, 소속학과, 휴대폰번호
FROM 학생
WHERE 학년 >= 2 AND 소속학과 = '컴퓨터과';

-- 1~3학년 또는 컴퓨터학과 학생 조회
SELECT 학년, 이름, 소속학과, 휴대폰번호
FROM 학생
WHERE (학년 >= 1 AND 학년 <= 3) 
   OR (소속학과 = '컴퓨터');

-- 컴퓨터/정보통신 학과 학생 조회 (학년 오름차순, 이름 내림차순)
SELECT 이름, 학년, 소속학과
FROM 학생
WHERE 소속학과 IN ('컴퓨터', '정보통신')
ORDER BY 학년 ASC, 이름 DESC;

-- 휴대폰번호가 존재하는 학생 수
SELECT COUNT(휴대폰번호) AS 휴대폰수 
FROM 학생;

-- 전체 학생 수 및 휴대폰 보유 학생 수
SELECT 
    COUNT(학번)       AS 학생수, 
    COUNT(휴대폰번호) AS 휴대폰수 
FROM 학생;

-- 여학생 평균 나이
SELECT AVG(나이) AS '여학생 평균나이'
FROM 학생 
WHERE 성별 = '여';

-- 학과별 최고령/최연소자 나이
SELECT 
    소속학과, 
    MAX(나이) AS '최고령자', 
    MIN(나이) AS '최연소자'
FROM 학생 
GROUP BY 소속학과;

-- 20세~30세 사이의 나이별 학생 수
SELECT 
    나이, 
    COUNT(*) AS '나이별 학생수' 
FROM 학생 
WHERE 나이 BETWEEN 20 AND 30 
GROUP BY 나이;

-- 2명 이상인 학년별 학생 수
SELECT 
    학년, 
    COUNT(*) AS '학년별 학생수' 
FROM 학생 
GROUP BY 학년 
HAVING COUNT(*) >= 2;

-- 4명 이상인 성별 인원수
SELECT 
    성별, 
    COUNT(성별) AS 성별인원수 
FROM 학생 
GROUP BY 성별 
HAVING COUNT(성별) >= 4;

-- 성이 '이'씨이고 이름이 3글자인 학생 조회
SELECT 학번, 이름 
FROM 학생 
WHERE 이름 LIKE '이__';