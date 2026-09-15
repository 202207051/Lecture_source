select * from 학생;
select * from 수강;

update 학생 set 휴대폰번호 = '없음'
where 휴대폰번호 is null;

select * from 학생;

update 수강
set 학번 = (select 학번 from 학생 where 이름='이은진')
where 학번='s003';

select * from 수강;

select * from 학생; 

delete from 학생 where 학년=2;

select * from 학생;


