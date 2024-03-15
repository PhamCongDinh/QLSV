create database QLSV

create table department(
	id int identity(1,1) not null primary key,
  abbreviations varchar(50) not null Unique,
	department_name nvarchar(50) not null unique
	)
insert into department(abbreviations,department_name) values
('CNTT', N'Công Nghệ Thông Tin'),
('KTVT',N'Kinh Tế Vận Tải'),
('TDH',N'Tự Động Hóa'),
('DTVT',N'Điện Tử Viễn Thông')

create table cohort(
  id int identity(1,1) not null primary key,
	abbreviations varchar(50) not null,
	cohort_name nvarchar(50) not null,
  id_dep int not null,
  foreign key (id_dep) REFERENCES department(id)

	)
  select * from classes
insert into cohort(abbreviations,cohort_name,id_dep) values
('K60',N'Khóa 60',1),
('K61',N'Khóa 61',1),
('K60',N'Khóa 60',2),
('K61',N'Khóa 61',2)





create table classes(
  id int identity(1,1) not null primary key,
	abbreviations varchar(50) not null,
	classes_name nvarchar(50) not null,
	id_coh int not null,
	foreign key (id_coh) REFERENCES cohort(id)
	)

insert into classes(abbreviations, classes_name,id_coh) values
('CNTT1', N'Công Nghệ Thông Tin 1',1),
('CNTT2', N'Công Nghệ Thông Tin 2',2),
('CNTT3', N'Công Nghệ Thông Tin 3',1)

create table account(
	id varchar(50) not null primary key,
	username nvarchar(50) not null,
	email varchar(50),
	password varchar(50) not null,
	dateofbirth date,
	town nvarchar(50),
	images nvarchar(50),
	role int not null
	)

insert into account(id, username,email, password,dateofbirth,town,images,role) values
('GV20001', N'Đỗ Văn Đức', 'doduc@gmail.com', '18042002', '2002-04-18', N'Nam Định', 'duc.jpg', 1),
('201200081', N'Vũ Huy Đức', 'Duc@gmail.com', '18042002', '2002-04-18', N'Nam Định', 'Manh.jpg', 1)

--('201200084', N'Phạm Công Định', 'pcd@gmail.com', '18042002', '2002-04-18', N'Nam Định', 'dinh.jpg', 1),
--('201200089', N'Đoàn Thị Mai Anh', 'MaiAnh@gmail.com', '18042002', '2002-04-18', N'Nam Định', 'Manh.jpg', 1),
--('201200088', N'Đào Thị Diễm', 'Diem@gmail.com', '18042002', '2002-04-18', N'Thái Bình', 'Manh.jpg', 1)

create table student(
	id varchar(50) not null primary key ,
	id_class int not null,
	foreign key (id_class) REFERENCES classes(id),
  foreign key (id) REFERENCES account(id)
	)



insert into student (id, id_class) values
('201200080', 4),
('201200081', 5)



create table teacher(
	id varchar(50) not null primary key ,
	id_dep int,
	foreign key (id) REFERENCES account(id),
	foreign key (id_dep) REFERENCES department(id)
	)

  select * from teacher
  insert into teacher(id,id_dep) values
  ('GV20001','1')

create table term(
	id int identity(1,1) not null primary key,
	term_name varchar(30) not null,
	semester int not null,
  startdate date,
  enddate date
	)
  select GETDATE()
  select * from term 
  where GETDATE() >= term.startdate and GETDATE()<= term.enddate
  insert into term(term_name, semester) values
  ('2020-2021', 1),
  ('2020-2021',2)

  select * from term
create table course(
	id varchar(50) not null primary key,
	course_name nvarchar(50) not null,
	id_term int not null,
  id_dep int,
	id_coh int,
	foreign key (id_term) REFERENCES term(id),
  foreign key (id_dep) REFERENCES department(id),
	foreign key (id_coh) REFERENCES cohort(id)
	)


insert into course(id,course_name,id_term,id_dep,id_coh) values
--('N01',N'Tin học đại cương', 1, 1, 1),
--('N02',N'Triết', 1, 1, 1),
('N03',N'Lập Trình Web',1,1,1)
select course.course_name from course
  join term on course.id_term= term.id
  join department on course.id_dep = department.id
  join cohort on  course.id_coh = cohort.id
    where cohort.cohort_name=N'Khóa 60' and department.department_name=N'Công Nghệ Thông Tin' and GETDATE() >= term.startdate and GETDATE()<= term.enddate

  --where cohort.cohort_name=N'Khóa 60' and department.department_name='Công Nghệ Thông Tin' and term.term_name='2020-2021' and term.semester=1




where 
create table point(
	id_stu varchar(50) not null,
	id_cour varchar(50) not null,
	point_process float,
	point_test float,
	number int not null,
	PRIMARY KEY (id_stu, id_cour, number),
    FOREIGN KEY (id_stu) REFERENCES student(id),
    FOREIGN KEY (id_cour) REFERENCES course(id)
	)
  insert into point (id_stu,id_cour, number) values
  ('201200084','N01',1)
  select *from point
create table teacher_class_cour(
	id_teacher varchar(50) not null,
	id_class int not null,
  id_cour varchar(50) not null,
	primary key (id_teacher, id_class, id_cour),
	FOREIGN KEY (id_teacher) REFERENCES teacher(id),
    FOREIGN KEY (id_cour) REFERENCES course(id),
	foreign key (id_class) REFERENCES classes(id)
	)

  insert into teacher_class_cour(id_teacher,id_class,id_cour) values
  ('GV20001',1,'N01')







  SELECT 
    student.id,
    account.username,
    account.email,
    account.dateofbirth,
    classes.classes_name ,
    cohort.cohort_name ,
	department.department_name
FROM account inner join student on account.id = student.id
              inner join classes on student.id_class = classes.id
              inner join cohort on classes.id_coh = cohort.id
              inner join department on cohort.id_dep = department.id
where student.id='201200084'



select * from course where course.id='N01'




select course.id from course
join teacher_class_cour on course.id = teacher_class_cour.id_cour
join teacher on teacher_class_cour.id_teacher = teacher.id
where teacher.id = 'GV20001'


  select course.id,course.course_name, account.id, account.username,classes.classes_name,cohort.cohort_name,point.point_process,point.point_test from course
join point on course.id =point.id_cour
join student on point.id_stu = student.id
join account on student.id = account.id
join classes on student.id_class = classes.id
join cohort on classes.id_coh = cohort.id
where course.id = 'N01'
