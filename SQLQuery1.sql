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
	Book NVARCHAR (100),
	PHid VARCHAR (15),
	Author NVARCHAR (100),
	price INT,
	type NVARCHAR (100),
);


CREATE TABLE PHs (
	PHid VARCHAR (15) PRIMARY KEY,
	PHname NVARCHAR (50),
	PHaddress NVARCHAR (50),
	PHphone VARCHAR (12),
	PHbank VARCHAR (20),
   unpaid_amount int CHECK (unpaid_amount <= 40000000)
);
ALTER TABLE book
ADD CONSTRAINT FK_book_PHid FOREIGN KEY (PHid) REFERENCES PHs (PHid);

CREATE TABLE AGENT (
	agentid VARCHAR (15) PRIMARY KEY,
	agentname NVARCHAR (50),
	agentphone VARCHAR (12),
	agentaddr NVARCHAR (50),
	amount_owed int CHECK (amount_owed <= 40000000)
);

CREATE TABLE import (
	importid VARCHAR (15) PRIMARY KEY,
	PHid VARCHAR (15),
	PHphone VARCHAR (12),
	PHaddress NVARCHAR (50),
	Deliver NVARCHAR (50),
	bookid VARCHAR (15),
	quantity int,
	price int,
	DOD date,
	SED date,
	total int,
	FOREIGN KEY (bookid) REFERENCES book (bookid),
	FOREIGN KEY (PHid) REFERENCES PHs (PHid)
);


CREATE TABLE export (
	exportid VARCHAR (15) PRIMARY KEY,
	agentid VARCHAR (15),
	agentphone VARCHAR (12),
	agentaddr NVARCHAR (50),
	Deliver NVARCHAR (50),
	bookid VARCHAR (15),
	quantity int,
	price int,
	DOD date,
	SID date,
	total int,
	FOREIGN KEY (bookid) REFERENCES book (bookid),
	FOREIGN KEY (agentid) REFERENCES AGENT (agentid)
);

CREATE TABLE Staff (
    ID VARCHAR (15) PRIMARY KEY,
    FullName NVARCHAR(255),
    Role VARCHAR (30),
    Phone NVARCHAR(12),
    Salary DECIMAL(10, 2)
);

CREATE TABLE agent_sta(
	agent_sta_id VARCHAR (15),
	agentid VARCHAR (15),
	bookid VARCHAR (15),
	sold_quantity int,
	PRIMARY KEY (agent_sta_id),
	FOREIGN KEY (bookid) REFERENCES book (bookid),
);

CREATE TABLE statistic(
	statisticid VARCHAR (15),
	PHid VARCHAR (15),
	bookid VARCHAR (15),
	unsold_quantity int,
	PRIMARY KEY (statisticid),
	FOREIGN KEY (bookid) REFERENCES book (bookid),
);

CREATE TABLE sales (
    SaleID INT PRIMARY KEY,
    SaleDate DATE,
    Amount DECIMAL(10, 2)
);

INSERT INTO Staff
VALUES
    ('079120312', N'Nguyễn Văn A', 'IMPORT', '0901234567', 5000.00),
    ('081234012', N'Trần Thị B', 'PUBLISHING', '0912345678', 5500.00),
    ('012340831', N'Lê Văn C', 'STATISTIC', '0976543210', 6000.00),
    ('043212345', N'Phạm Văn D', 'STATISTIC', '0987654321', 5200.00);


INSERT INTO Sales (SaleID, SaleDate, Amount)
VALUES
    (1, '2022-11-03', 1100.00),
    (2, '2022-11-12', 1300.00),
    (3, '2022-11-21', 1050.00),
	(4, '2022-12-02', 950.00),
    (5, '2022-12-11', 1200.00),
    (6, '2022-12-28', 1400.00),
	(7, '2023-01-05', 1050.00),
    (8, '2023-01-15', 1250.00),
    (9, '2023-01-25', 1300.00),
	(10, '2023-02-07', 1150.00),
    (11, '2023-02-18', 1400.00),
    (12, '2023-02-27', 1100.00),
	(13, '2023-03-05', 1200.00),
    (14, '2023-03-15', 1300.00),
    (15, '2023-03-25', 1100.00),
	(16, '2023-04-02', 1400.00),
    (17, '2023-04-11', 1250.00),
    (18, '2023-04-21', 1350.00),
	(19, '2023-05-03', 1500.00),
    (20, '2023-05-12', 1450.00),
    (21, '2023-05-22', 1550.00),
	(22, '2023-10-02', 50000.00),
    (23, '2023-10-05', 75000.00),
    (24, '2023-10-12', 90000.00),
    (25, '2023-11-01', 60000.00),
    (26, '2023-11-15', 85000.00),
    (27, '2023-12-05', 120000.00)
--Week
SELECT YEAR(SaleDate) AS SaleYear, 
       DATEPART(WEEK, SaleDate) AS WeekNumber,
       SUM(Amount) AS WeeklyRevenue
FROM Sales
GROUP BY YEAR(SaleDate), DATEPART(WEEK, SaleDate)
ORDER BY SaleYear, WeekNumber;
--Month
SELECT YEAR(SaleDate) AS SaleYear, 
       DATEPART(MONTH, SaleDate) AS MonthNumber,
       SUM(Amount) AS MonthlyRevenue
FROM Sales
GROUP BY YEAR(SaleDate), DATEPART(MONTH, SaleDate)
ORDER BY SaleYear, MonthNumber;
--Year
SELECT YEAR(SaleDate) AS SaleYear, 
       SUM(Amount) AS YearlyRevenue
FROM Sales
GROUP BY YEAR(SaleDate)
ORDER BY SaleYear;

INSERT INTO PHs (PHid, PHname, PHaddress, PHphone, PHbank, unpaid_amount)
VALUES 
    ('PUB01', N'Publisher 1', N'Address 1', '12345678', '00000001', 0),
    ('PUB02', N'Publisher 2', N'Address 2', '23456789', '00000002', 0),
    ('PUB03', N'Publisher 3', N'Address 3', '34567890', '00000003', 22000000),
    ('PUB04', N'Publisher 4', N'Address 4', '45678901', '00000004', 0),
    ('PUB05', N'Publisher 5', N'Address 5', '56789012', '00000005', 17000000),
    ('PUB06', N'Publisher 6', N'Address 6', '67890123', '00000006', 0),
    ('PUB07', N'Publisher 7', N'Address 7', '78901234', '00000007', 30000000);

INSERT INTO book VALUES
	('A00001', N'Harry Potter và Hòn đá Phù thủy', 'PUB01', 'J.K. Rowling', 79000, N'Sách thiếu nhi'),
    ('A00002', N'Bí kíp làm cha mẹ', 'PUB01', 'John Gottman', 82000, N'Sách thiếu nhi'),
    ('A00003', N'Bác Gấu Đen và hai chú gấu con', 'PUB01', 'Jan Brett', 85000, N'Sách thiếu nhi'),
    ('A00004', N'Cây tre trăm đốt', 'PUB04', 'Hans Christian Andersen', 88000, N'Sách thiếu nhi'),
	('B00001', N'The Bible', 'PUB05', 'Various Authors', 119000, N'Sách tôn giáo'),
    ('B00002', N'The Quran', 'PUB05', 'Various Authors', 125000, N'Sách tôn giáo'),
	('C00001', N'Những nguyên tắc thành công', 'PUB07', 'Jack Canfield, Janet Switzer', 119000, N'Sách văn hóa xã hội'),
    ('C00002', N'Đường Mây Qua Xứ Sở Của Những Điều Nguy Hiểm', 'PUB02', 'Trent Dalton', 125000, N'Sách văn hóa xã hội'),
	('D00001', N'Sapiens: A Brief History of Humankind', 'PUB05', 'Yuval Noah Harari', 139000, N'Sách lịch sử'),
    ('D00002', N'Guns, Germs, and Steel: The Fates of Human Societies', 'PUB06', 'Jared Diamond', 145000, N'Sách lịch sử'),
    ('D00003', N'The Rise and Fall of the Third Reich', 'PUB05', 'William L. Shirer', 152000, N'Sách lịch sử'),
    ('D00004', N'The Diary of a Young Girl', 'PUB03', 'Anne Frank', 158000, N'Sách lịch sử'),
    ('D00005', N'A Peoples History of the United States', 'PUB04', 'Howard Zinn', 165000, N'Sách lịch sử'),
	('E00001', N'Dune', 'PUB05', 'Frank Herbert', 139000, N'Sách văn học viễn tưởng'),
    ('E00002', N'1984', 'PUB05', 'George Orwell', 145000, N'Sách văn học viễn tưởng'),
    ('E00003', N'Brave New World', 'PUB03', 'Aldous Huxley', 152000, N'Sách văn học viễn tưởng'),
	('F00001', N'I Am Zlatan Ibrahimovic', 'PUB03', 'David Lagercrantz', 189000, N'Sách tiểu sử, tự truyện'),
    ('F00002', N'The Autobiography of Pelé', 'PUB03', 'Pelé', 195000, N'Sách tiểu sử, tự truyện'),
    ('F00003', N'My Story', 'PUB03', 'Steven Gerrard', 199000, N'Sách tiểu sử, tự truyện'),
    ('F00004', N'The Autobiography', 'PUB04', 'Roy Keane', 205000, N'Sách tiểu sử, tự truyện'),
    ('F00005', N'Quiet Leadership: Winning Hearts, Minds and Matches', 'PUB04', 'Carlo Ancelotti', 209000, N'Sách tiểu sử, tự truyện'),
    ('F00006', N'Pep Confidential: The Inside Story of Pep Guardiola’s First Season at Bayern Munich', 'PUB04', 'Martí Perarnau', 215000, N'Sách tiểu sử, tự truyện'),
    ('F00007', N'The Autobiography of Roy Keane', 'PUB05', 'Roy Keane', 219000, N'Sách tiểu sử, tự truyện'),
    ('F00008', N'Leading: Learning from Life and My Years at Manchester United', 'PUB05', 'Alex Ferguson', 225000, N'Sách tiểu sử, tự truyện'),
    ('F00009', N'Zidane: A 21st Century Portrait', 'PUB06', 'David Lagercrantz', 229000, N'Sách tiểu sử, tự truyện'),
    ('F00010', N'The Autobiography of Alex Ferguson', 'PUB06', 'Alex Ferguson', 235000, N'Sách tiểu sử, tự truyện'),
	('G00001', N'The Shining', 'PUB01', 'Stephen King', 139000, N'Sách kinh dị, bí ẩn'),
    ('G00002', N'The Da Vinci Code', 'PUB01', 'Dan Brown', 145000, N'Sách kinh dị, bí ẩn'),
    ('G00003', N'House of Leaves', 'PUB02', 'Mark Z. Danielewski', 152000, N'Sách kinh dị, bí ẩn'),
	('H00001', N'The Professional Chef', 'PUB02', 'The Culinary Institute of America', 69000, N'Sách dạy nấu ăn'),
    ('H00002', N'Essentials of Classic Italian Cooking', 'PUB02', 'Marcella Hazan', 75000, N'Sách dạy nấu ăn'),
    ('H00003', N'How to Cook Everything', 'PUB03', 'Mark Bittman', 82000, N'Sách dạy nấu ăn'),
    ('H00004', N'The Flavor Bible: The Essential Guide to Culinary Creativity', 'PUB05', 'Karen Page', 88000, N'Sách dạy nấu ăn'),
    ('H00005', N'The Food Lab: Better Home Cooking Through Science', 'PUB06', 'J. Kenji López-Alt', 93000, N'Sách dạy nấu ăn'),
	('I00001', N'Introduction to Algorithms', 'PUB02', 'Thomas H. Cormen', 309000, N'Sách khoa học công nghệ'),
    ('I00002', N'The Art of Computer Programming', 'PUB02', 'Donald E. Knuth', 315000, N'Sách khoa học công nghệ'),
    ('I00003', N'The Selfish Gene', 'PUB01', 'Richard Dawkins', 322000, N'Sách khoa học công nghệ'),
    ('I00004', N'The Innovators: How a Group of Hackers, Geniuses, and Geeks Created the Digital Revolution', 'PUB01', 'Walter Isaacson', 328000, N'Sách khoa học công nghệ'),
    ('I00005', N'Sapiens: A Brief History of Humankind', 'PUB01', 'Yuval Noah Harari', 335000, N'Sách khoa học công nghệ'),
    ('I00006', N'The Structure of Scientific Revolutions', 'PUB03', 'Thomas S. Kuhn', 342000, N'Sách khoa học công nghệ'),
    ('I00007', N'The Gene: An Intimate History', 'PUB04', 'Siddhartha Mukherjee', 349000, N'Sách khoa học công nghệ'),
	('J00001', N'The Alchemist', 'PUB02', N'Paulo Coelho', 199000, N'Sách truyền cảm hứng'),
    ('J00002', N'The Power of Now', 'PUB02', N'Eckhart Tolle', 205000, N'Sách truyền cảm hứng'),
    ('J00003', N'The 7 Habits of Highly Effective People', 'PUB01', N'Stephen R. Covey', 212000, N'Sách truyền cảm hứng'),
    ('J00004', N'Atomic Habits: An Easy & Proven Way to Build Good Habits & Break Bad Ones', 'PUB01', N'James Clear', 218000, N'Sách truyền cảm hứng'),
    ('J00005', N'Mans Search for Meaning', 'PUB01', N'Viktor E. Frankl', 225000, N'Sách truyền cảm hứng'),
    ('J00006', N'The Magic of Thinking Big', 'PUB03', N'David J. Schwartz', 232000, N'Sách truyền cảm hứng'),
    ('J00007', N'The Happiness Advantage: How a Positive Brain Fuels Success in Work and Life', 'PUB04', N'Shawn Achor', 239000, N'Sách truyền cảm hứng'),
    ('J00008', N'Daring Greatly: How the Courage to Be Vulnerable Transforms the Way We Live, Love, Parent, and Lead', 'PUB05', N'Brené Brown', 245000, N'Sách truyền cảm hứng'),
    ('J00009', N'Extreme Ownership: How U.S. Navy SEALs Lead and Win', 'PUB06', N'Jocko Willink', 252000, N'Sách truyền cảm hứng'),
    ('J00010', N'Grit: The Power of Passion and Perseverance', 'PUB06', N'Angela Duckworth', 258000, N'Sách truyền cảm hứng'),
    ('J00011', N'The Subtle Art of Not Giving a F*ck: A Counterintuitive Approach to Living a Good Life', 'PUB07', N'Mark Manson', 265000, N'Sách truyền cảm hứng'),
    ('J00012', N'Mindset: The New Psychology of Success', 'PUB07', N'Carol S. Dweck', 272000, N'Sách truyền cảm hứng'),
    ('J00013', N'Becoming', 'PUB07', N'Michelle Obama', 279000, N'Sách truyền cảm hứng');



INSERT INTO AGENT (agentid, agentname, agentphone, agentaddr, amount_owed)
VALUES 
    ('AGT001', N'Đại lý A', '123456789', N'Địa chỉ A', 10000000),
    ('AGT002', N'Đại lý B', '234567890', N'Địa chỉ B', 8000000),
    ('AGT003', N'Đại lý C', '345678901', N'Địa chỉ C', 30000000),
    ('AGT004', N'Đại lý D', '456789012', N'Địa chỉ D', 0),
    ('AGT005', N'Đại lý E', '567890123', N'Địa chỉ E', 26000000),
    ('AGT006', N'Đại lý F', '678901234', N'Địa chỉ F', 16898000);




-- Thêm dữ liệu mẫu vào bảng agent_sta
INSERT INTO agent_sta (agent_sta_id, agentid, bookid, sold_quantity)
VALUES
    -- Thêm 15 bản ghi mẫu
    -- agentid = AGT001
    (1, 'AGT001', 'F00007', 1700),
    (2, 'AGT001', 'J00010', 1200),
    -- agentid = AGT002
    (3, 'AGT002', 'D00002', 1800),
    (4, 'AGT002', 'I00003', 1400),
    (5, 'AGT002', 'H00001', 1600),
    -- agentid = AGT003
    (6, 'AGT003', 'J00007', 2000),
    (7, 'AGT003', 'E00003', 1300),
    (8, 'AGT003', 'D00005', 1900),
    -- agentid = AGT004
    (9, 'AGT004', 'B00002', 1500),
    (10, 'AGT004','I00004', 1700),
    (11, 'AGT004','J00009', 1200),
    -- agentid = AGT005
    (12, 'AGT005', 'J00004', 1800),
    (13, 'AGT005', 'G00002', 1400),
    (14, 'AGT005', 'F00008', 1600);

	Select * From agent_sta order by agent_sta_id desc

INSERT INTO statistic (statisticid, PHid, bookid, unsold_quantity) VALUES
('1', 'PUB01', 'J00004', 50),
('2', 'PUB02', 'F00008', 30),
('3', 'PUB03', 'J00009', 40),
('4', 'PUB04', 'I00004', 25),
('5', 'PUB05', 'J00010', 20),
('6', 'PUB06', 'D00005', 35),
('7', 'PUB07', 'H00005', 45),
('8', 'PUB01', 'A00001', 55),
('9', 'PUB02', 'J00008', 28),
('10','PUB03', 'E00001', 37);

select * from import