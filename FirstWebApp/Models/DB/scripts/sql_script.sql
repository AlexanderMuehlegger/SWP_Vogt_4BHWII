create database web_4b collate utf8mb4_general_ci;

use web_4b;

create table users(
	user_id int unsigned not null auto_increment,
	username varchar(100) not null,
	password varchar(300) not null,
	birthdate date null,
	email varchar(50) not null,
	gender int null,
	
	constraint user_id_PK primary key(user_id)
);

insert into users values(null, "Alexander", sha2("Hallo123!", 512), "2004-12-23", "alex@gmail.com", 0);
insert into users values(null, "Gabi", sha2("Hallo123!", 512), "2001-01-02", "gabi@gmail.com", 1);
insert into users values(null, "Stefan", sha2("säa,sfmöä", 512), "2009-10-13", "stefan@gmail.com", 0);


select * from users;