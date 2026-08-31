create database test;

use test;

show tables;

create table student (
id char(9) primary key not null,
name varchar(50) not null,
age int not null,
major varchar(20) not null,
phone varchar(20)
);show tables;

select * from student;

insert into student (id, name, age, major) 
values ('202207051', '박영환', 20,'컴퓨터소프트웨어공학과');

insert into student (id, name, age, major) 
values ('202207052', '이영현', 22,'연극영화과');

insert into student (id, name, age, major) 
values ('202207053', '신연아', 23,'포스트모던학과');
