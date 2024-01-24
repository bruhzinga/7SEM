
use WSZDA;

create table Student
(
    id   int          not null IDENTITY (1,1) primary key,
    name varchar(255) not null,
);

create table Note
(
    id         int          not null IDENTITY (1,1) primary key,
    student_id int          not null,
    subject    varchar(255) not null,
    note       int,
    foreign key (student_id) references Student (id)
);

--seed data

    insert into Student (name) values ('John');
    insert into Student (name) values ('Jane');
    insert into Student (name) values ('Jack');
    insert into Student (name) values ('Jill');
    
    insert into Note (student_id, subject, note) values (1, 'DB', 1);
    insert into Note (student_id, subject, note) values (1, 'PMMP', 2);
    insert into Note (student_id, subject, note) values (1, 'WCF', 3);
    insert into Note (student_id, subject, note) values (2, 'AIBIS', 4);
    insert into Note (student_id, subject, note) values (2, 'English', 5);
    insert into Note (student_id, subject, note) values (2, 'CMS', 6);
    insert into Note (student_id, subject, note) values (3, 'PWI', 7);
