-- 1. 데이터베이스 생성 및 이동
CREATE DATABASE test;
USE test;

-- 테이블 목록 확인 (생성 전)
SHOW TABLES;

-- 2. student 테이블 생성
CREATE TABLE student (
    id    CHAR(9)     NOT NULL PRIMARY KEY,
    name  VARCHAR(50) NOT NULL,
    age   INT         NOT NULL,
    major VARCHAR(20) NOT NULL,
    phone VARCHAR(20) NULL
);

-- 테이블 목록 확인 (생성 후)
SHOW TABLES;

-- 3. 데이터 삽입
INSERT INTO student (id, name, age, major) 
VALUES ('202207051', '박영환', 20, '컴퓨터소프트웨어공학과');

INSERT INTO student (id, name, age, major) 
VALUES ('202207052', '이영현', 22, '연극영화과');

INSERT INTO student (id, name, age, major) 
VALUES ('202207053', '신연아', 23, '포스트모던학과');

-- 4. 전체 데이터 조회
SELECT * FROM student;