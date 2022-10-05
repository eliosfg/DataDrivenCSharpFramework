CREATE Database Guru99TestData;

USE Guru99TestData;

CREATE TABLE Users(
username varchar(255), 
password varchar(255));

delete from users where username = 'mngr289676';

Insert into users (username, password) values ('mngr289676', 'dUpajyr');


select * from users;
