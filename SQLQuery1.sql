use master 
go 
create database BookStore
on primary
( filename ='D:\ BookStore.mdf', name = 'a') 
log on
( filename ='D:\ BookStore.ldf', name = 'b')

go
use [BookStore]

CREATE TABLE book (
	bookid VARCHAR (15) PRIMARY KEY,
	Book NVARCHAR (50),
	Author NVARCHAR (30),
	price INT,
	quantity INT,
	type NVARCHAR (40),
);

CREATE TABLE Import (
	importID VARCHAR (15) PRIMARY KEY,
	PHs NVARCHAR (50),
	Phonenumber VARCHAR (12),
	address NVARCHAR (50),
	Delivery NVARCHAR (30),
	DOD DATE,
	Book NVARCHAR (30),
	bookid VARCHAR (15),
	quantity INT,
	price INT,
	total INT,
	SED DATE,
	FOREIGN KEY (bookid) REFERENCES book (bookid),
);

CREATE TABLE Export (
	exportID VARCHAR (15) PRIMARY KEY,
	bookagent NVARCHAR (30),
	agent_phonenumber VARCHAR (12),
	agent_address NVARCHAR (50),
	Delivery NVARCHAR (30),
	DOE DATE,
	Book NVARCHAR (30),
	bookid VARCHAR (15),
	quantity INT,
	price INT,
	total INT,
	SED DATE,
	FOREIGN KEY (bookid) REFERENCES book (bookid),
);

CREATE TABLE Staff (
    ID VARCHAR (15) PRIMARY KEY,
    FullName NVARCHAR(255),
    DOB DATE,
    Phone NVARCHAR(12),
    Salary DECIMAL(10, 2)
);


INSERT INTO book (bookid, Book, Author, price, quantity, type) VALUES ('A0001',N'NGÀY MAI, NGÀY MAI VÀ NGÀY MAI NỮA','Gabrielle Zevin',259000,900, N'Sách truyền cảm hứng')
INSERT INTO book (bookid, Book, Author, price, quantity, type) VALUES ('B0001',N'Khéo ăn nói được thiên hạ', N'Mỹ Thuận',138000,1100, N'Sách văn hoá xã hội')
INSERT INTO book (bookid, Book, Author, price, quantity, type) VALUES ('A0002',N'CLOSER TO LOVE', N'VEX KING',310000,1732, N'Sách truyền cảm hứng')
