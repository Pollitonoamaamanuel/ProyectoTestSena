use My_Test
go
create table users(
id int primary key identity (1,1),
nick varchar (50),
password varchar (50));
go 
insert into users values ('root','12345');
go
select * from users
go 

create table employees(
id int primary key identity (1,1),
name varchar(255),
lastName varchar(255),
user_id int unique
);
go
alter table employees add foreign key (user_id) references users(id);
go 
/*Inicio PA*/
create procedure pa_select_all_employees
as 
Select * from employees;
/* Fin PA*/
go

/*Inicio PA*/
create procedure pa_insert_employees
@name varchar(255),
@lastName varchar(255),
@user_id int
as
insert into employees (name, lastName, user_id) values(@name, @lastName, @user_id);
/* Fin PA*/
go


/* Procedimientos Almacenados */

create procedure pa_insert_users
@nick1 varchar(50),
@pass1 varchar(50)
as
insert into users values (@nick1, @pass1);

go

execute pa_insert_users 'alfa', '9999';
go
exec  pa_insert_users 'beta', '000';
go
select * from users

go

Update users set nick='ggg', password='3333' where id='3'
go

Create Procedure pa_update_users
@nick varchar(50),
@password varchar(50),
@id int
As
Update users set nick = @nick, password = @password  where id = @id ;
go

exec pa_update_users 'algo', '1234', '3';

go
select  * from Users

go 

Delete from users where id='4'
 

Go
create procedure pa_delete_users
@id int
as
Delete from users where id= @id;

Go


exec pa_delete_users '3';

go
		
create procedure pa_select_all_users
as
select * from users;

go 
exec pa_select_all_users;
go

create procedure pa_select_one_users
@id int
as
select * from users where id = @id;

go
exec pa_select_one_users '5';
go
select * from Users where nick LIKE '%a%' or password LIKE '%a%';
go
create procedure pa_filter_users
@nick varchar(50),
@password varchar(50)
as 
select * from Users where nick LIKE '%'+@nick+'%' or password LIKE '%'+@password+'%';
go

exec pa_filter_users 'a', 'a';