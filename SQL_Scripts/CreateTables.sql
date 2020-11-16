drop table if exists Grade;
drop table if exists Modul;
drop table if exists Semester;
drop table if exists Benutzeraccount;

create table Benutzeraccount (
	BenutzeraccountID int NOT NULL primary key IDENTITY,
	Benutzername varchar(255) not null,
	Passwort varchar(255) not null
);

create table Semester (
	SemesterID int not null primary key IDENTITY,
	Name varchar(255) not null,
	BenutzeraccountID int not null,
	constraint FK_Benutzeraccount foreign key (BenutzeraccountID)
		references Benutzeraccount(BenutzeraccountID)
);

create table Modul (
	ModulID int not null primary key IDENTITY,
	Name varchar(255) not null,
	SemesterID int not null,
	constraint FK_Semester foreign key (SemesterID)
		references Semester(SemesterID)
);

create table Grade (
	GradeID int NOT NULL primary key IDENTITY,
	Note decimal not null,
	Name varchar(255) not null,
	Gewichtung decimal not null,
	ModulID int not null,
	constraint FK_Modul foreign key (ModulID)
		references Modul(ModulID)
);
