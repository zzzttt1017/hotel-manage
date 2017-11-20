use Master
go
if exists(select * from sysdatabases where name='HotelDB')
drop database HotelDB
go
create database HotelDB
on primary
(
	name='HotelDB_data',
	filename='E:\DB\HotelDB_data.mdf',
	size=5MB,
	filegrowth=2MB
)
 log on
(
	name='HotelDB_log',
	filename='E:\DB\HotelDB_log.mdf',
	size=5MB,
	filegrowth=2MB
)
go
use HotelDB
go
--����Ա��
if exists(select * from sysobjects where name='SysAdmins')
drop table SysAdmins
go
create table SysAdmins --����Ա��
(
	LoginId int primary key ,--��¼�˺�
	LoginName varchar(20), --��¼����
	LoginPwd varchar(20)	 --��¼����
) 
go
--���ŷ����
if exists(select * from sysobjects where name='NewsCategory')
drop table NewsCategory
go
create table NewsCategory --���ŷ���
(
	CategoryId int  identity(1,1) primary key ,
	CategoryName varchar(20)
)
go
--���ű�
if exists(select * from sysobjects where name='News')
drop table News
go
create table News  --������ϸ��
(
	NewsId int  identity(1000,1)  primary key , --���ű��
	NewsTitle varchar(100),--����
	NewsContents text,--����	
	PublishTime datetime default(getdate()),--����ʱ��
	CategoryId int references NewsCategory(CategoryId)--������
)
go
--��Ʒ�����
if exists(select * from sysobjects where name='DishCategory')
drop table DishCategory
go
create table DishCategory --��Ʒ����
(
	CategoryId int  identity(1,1) primary key ,
	CategoryName varchar(20)
)
go
--��Ʒ��
if exists(select * from sysobjects where name='Dishes')
drop table Dishes 
go
create table Dishes --��Ʒ��
(
	DishId int  identity(100,1)  primary key , --��Ʒ���
	DishName varchar(100),--��Ʒ����
	UnitPrice numeric(18,2), --�۸�
	CategoryId int references DishCategory(CategoryId)--������
)
go
--��ƷԤ����
if exists(select * from sysobjects where name='DishBook')
drop table DishBook
go
create table DishBook  --Ԥ���б�
(
	BookId int  identity(10000,1) primary key , --Ԥ�����
	HotelName varchar(50),   --�ֵ�����
	ConsumeTime datetime,--����ʱ��
	ConsumePersons int,--��������
	RoomType varchar(20),--��������
	CustomerName varchar(20),--Ԥ��������
	CustomerPhone varchar(100),--��ϵ�绰
	CustomerEmail varchar(100),  --�����ʼ�
	Comments nvarchar(500), --��ע����
	BookTime datetime default(getdate()),--Ԥ��ʱ��
	OrderStatus int default(0), --����״̬��0��δ��ˣ�1�����ͨ����-1 ��������2��������ϣ�	
)
go
--��Ƹ��Ϣ��
if exists(select * from sysobjects where name='Recruitment')
drop table Recruitment
go
create table Recruitment --��Ƹ��Ϣ��
(
	PostId int identity(100000,1) primary key ,
	PostName nvarchar(50), --ְλ����
	PostType char(4),--(ȫְ����ְ)
	PostPlace nvarchar(50),--�����ص�
	PostDesc text,--ְλ����
	PostRequire text,--����Ҫ��
	Experience nvarchar(100),--��������
	EduBackground nvarchar(100),--ѧ��
	RequireCount int ,--��Ƹ����
	PublishTime datetime default(getdate()), --����ʱ��
	Manager varchar(20),--��ϵ��
	PhoneNumber varchar(100),--�绰
	Email varchar(100) --�����ʼ�
)
go
--Ͷ�߽����
if exists(select * from sysobjects where name='Suggestion')
drop table Suggestion
go
create table Suggestion --Ͷ�߽����
(
	SuggestionId int identity(100000,1) primary key ,
	CustomerName nvarchar(50), --�ͻ�����
	ConsumeDesc text,--����˵��
	SuggestionDesc text,--Ͷ�߽�������
	SuggestTime datetime default(getdate()), --Ͷ��ʱ��	
	PhoneNumber varchar(100),--�绰
	Email varchar(100), --�����ʼ�
	StatusId int default(0)--Ͷ��״̬��0��δ����1��������
)
go










