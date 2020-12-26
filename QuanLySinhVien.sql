create database HocSinh
go

use HocSinh
go



create table Khoa
(
	id int  identity primary key,
	name nvarchar(100)not null default N'Chưa có tên',
)
go

create table Lop
(
	id int  identity primary key,
	name nvarchar(100)not null default N'Chưa có tên',
	idKhoa int not null
	foreign key (idKhoa) references Khoa(id)
)
go


Create table MonHoc
(
	id int  identity primary key,
	name nvarchar(100)not null default N'Chưa có tên',
	tinchi int not null default 2,
	MaKhoa int not null,
	foreign key (MaKhoa) references Khoa (id)
)
go


Create table GiaoVien
(
	id int identity primary key,
	name nvarchar (100) not null default N'Chua co ten',
	malop int ,
	mamonhoc int,	
	Makhoa int not null,
	foreign key (makhoa) references Khoa(id),
	foreign key (malop) references Lop(id),
	foreign key(mamonhoc) references  Monhoc(id)

)


create table Account
(
DisplayName nvarchar(100) not null default N'BTKT',
UserName nvarchar(100) primary key,
Password nvarchar(1000) default 0 not null,
Type int not null default 0 ,--1=>admin
IdGiaoVien int ,

foreign key (IdGiaoVien) references GiaoVien(id)
)
go


	


create table SinhVien
(
	id int  identity primary key,
	name nvarchar(100)not null default N'Chưa có tên',
	ngaysinh date default '1/1/2000',
	gioitinh int,
	Diachi nvarchar(200) default N'Long An',
	Malop int not null
	foreign key(MaLop) references Lop(id)

)
go


create table LopGiangDay
(
idGiaoVien int ,
idLop int ,
primary key(idGiaoVien,idLop),
foreign key(idGiaoVien) references  GiaoVien(id),
foreign key(idLop) references Lop(id)
)
go

Create table Diem
(
	
	idHocSinh int not null,
	idMonHoc int  not null,
	diemchuyencan float default 0,
	diemtrungbinhkiemtra float default 0,
	diemthi float default 0,
	diemtrungbinh float default 0,
	idgiaovien int ,
	primary key (idHocSinh,idMonHoc),	
	foreign key (idHocsinh) references SinhVien(id),
	foreign key (idmonhoc) references Monhoc (id),
	foreign key (idgiaovien) references GiaoVien(id)
)
go
--THÊM KHOA
Insert into Khoa ( name) values(N'Khoa Công nghệ thông tin')
Insert into Khoa ( name) values(N'Khoa Cơ Khí')
Insert into Khoa ( name) values(N'Khoa Cơ Khí- Động lực')
Insert into Khoa ( name) values(N'Khoa Điện-Điện tử')
Insert into Khoa ( name) values(N'Khoa Tạm') 	--Khoa tạm chứa dử liệu makhoa cua bang  giáo viên khi các khoa kia bị xóa

--THÊM LỚP
	

	--Khoa công nghệ thông tin
Insert Into Lop(name,idKhoa) values(N'Cao đẳng Tin Học 18A',1)
Insert Into Lop(name,idKhoa) values(N'Cao đẳng Tin Học 18B',1)
Insert Into Lop(name,idKhoa) values(N'Cao đẳng Tin Học 18C',1)
Insert Into Lop(name,idKhoa) values(N'Cao đẳng Tin Học 18D',1)
	--Khoa cơ khí
Insert Into Lop(name,idKhoa) values(N'Cơ khí 18',2)
Insert Into Lop(name,idKhoa) values(N'Cơ khí 19',2)
	--Khoa cơ khí đông lực
Insert Into Lop(name,idKhoa) values(N'Cơ khí-Động lực 18',3)
Insert Into Lop(name,idKhoa) values(N'Cơ khí-Động lực 19',3)
	--Khoa điện- điện tử
Insert Into Lop(name,idKhoa) values(N'Điện-Điện tử 18',4)
Insert Into Lop(name,idKhoa) values(N'Điện-Điện tử 19',4)


--Thêm môn học
		--KHoa công nghệ thông tin
Insert into MonHoc (name, Makhoa)values (N'Lập trình Java cơ bản', 1)
Insert into MonHoc (name, Makhoa)values (N'Lập trình PHP cơ bản',1)
Insert into MonHoc (name, Makhoa)values (N'Anh văn chuyên ngành',1)
Insert into MonHoc (name, Makhoa)values (N'Lập trình windown',1)
Insert into MonHoc (name, Makhoa)values (N'Thực hành lập trình windown',1)
Insert into MonHoc (name, Makhoa)values (N'Đồ án lập trình windown',1)
		--Khoa cơ khí
Insert into MonHoc (name, Makhoa)values (N'Cơ khí 1', 2)
Insert into MonHoc (name, Makhoa)values (N'Cơ khí 2', 2)
		--Khoa cơ khí động lực
Insert into MonHoc (name, Makhoa)values (N'Cơ khí-Động lực 1', 3)
Insert into MonHoc (name, Makhoa)values (N'Cơ khí-Động lực 2', 3)
		--Khoa điện tử
Insert into MonHoc (name, Makhoa)values (N'Điện-Điện tử 1', 4)
Insert into MonHoc (name, Makhoa)values (N'Điện-Điện tử 2', 4)
--Khoa tạm
Insert into MonHoc (name, Makhoa)values (N'Môn tạm', 5)

--THÊM GIÁO VIÊN
	
Insert into GiaoVien(name,mamonhoc,Makhoa) values(N'Kim Thắm',1,1)
Insert into GiaoVien(name,mamonhoc,Makhoa) values(N'Ngọc Diệp',2,1)
Insert into GiaoVien(name,mamonhoc,Makhoa) values(N'Quỳnh Anh',3,1)
Insert into GiaoVien(name,mamonhoc,Makhoa) values(N'Ngọc Bích',4,1)
Insert into GiaoVien(name,mamonhoc,Makhoa) values(N'Thị Nở',5,1)
Insert into GiaoVien(name,mamonhoc,Makhoa) values(N'Văn Toàn',6,1)
Insert into GiaoVien(name,mamonhoc,Makhoa) values(N'Minh Tài',7,2)
Insert into GiaoVien(name,mamonhoc,Makhoa) values(N'Minh Tuấn',8,2)
Insert into GiaoVien(name,mamonhoc,Makhoa) values(N'Văn Vủ',9,3)
Insert into GiaoVien(name,mamonhoc,Makhoa) values(N'Ngọc Như',10,3)
Insert into GiaoVien(name,mamonhoc,Makhoa) values(N'Văn Phúc',11,4)
Insert into GiaoVien(name,mamonhoc,Makhoa) values(N'Trần Vũ',12,4)


-- Thêm Account

insert into Account(Username,Displayname,Password,Type)values(N'Admin',N'Admin',1,1)
insert into Account(Username,Displayname,Password,Type)values(N'NV',N'Nhân Viên',1,0) 

insert into Account(Username,Displayname,Password,Type,IdGiaoVien)values(N'KimTham',N'Kim Thắm',1,2,1)
insert into Account(Username,Displayname,Password,Type,IdGiaoVien)values(N'NgocDiep',N'Ngọc Diệp',1,2,2)
insert into Account(Username,Displayname,Password,Type,IdGiaoVien)values(N'QuynhAnh',N'Quỳnh Anh',1,2,3)
insert into Account(Username,Displayname,Password,Type,IdGiaoVien)values(N'NgocBich',N'Ngọc Bích',1,2,4)
insert into Account(Username,Displayname,Password,Type,IdGiaoVien)values(N'ThiNo',N'Thị Nở',1,2,5)
insert into Account(Username,Displayname,Password,Type,IdGiaoVien)values(N'VanToan',N'Văn Toàn',1,2,6)
insert into Account(Username,Displayname,Password,Type,IdGiaoVien)values(N'MinhTai',N'Minh Tài',1,2,7)
insert into Account(Username,Displayname,Password,Type,IdGiaoVien)values(N'MinhTuan',N'Minh Tuấn',1,2,8)
insert into Account(Username,Displayname,Password,Type,IdGiaoVien)values(N'VanVu',N'Văn Vủ',1,2,9)
insert into Account(Username,Displayname,Password,Type,IdGiaoVien)values(N'NgocNhu',N'NgocNhu',1,2,10)
insert into Account(Username,Displayname,Password,Type,IdGiaoVien)values(N'VanPhuc',N'Văn Phúc',1,2,11)
insert into Account(Username,Displayname,Password,Type,IdGiaoVien)values(N'TranVu',N'Trần Vũ',1,2,12)



Update Account set Password='1962026656160185351301320480154111117132155' 
go



--THÊM HỌC SINH
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Trần Minh Tài','2000/4/2',1,1)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Trần Minh Tuấn','2000/7/12',1,1)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Nguyễn Minh Thanh','2000/10/3',1,1)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Trần Thị Tú','2000/11/5',0,1)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Trần Tuấn Cảnh','2000/11/4',1,1)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Nguyễn Ngọc Như','2000/9/22',0,1)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Võ Ý Minh','2000/6/9',0,1)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Mai Tài Phến','2000/3/29',1,1)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Võ Văn Vũ' , '2000/1/3',1,1)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Hồ Ngọc','2000/12/31',0,1)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Hồ Ngọc Như','2000/12/31',0,2)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Võ Văn Phúc','2000/12/30',1,2)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Tô Tâm Như ','2000/12/31',0,2)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Trần Vũ','2000/12/1',1,2)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Văn Sâm','2000/1/31',1,2)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Thúi Kiều','2000/5/1',0,2)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Thanh Hậu','2000/10/2',0,2)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Minh Hậu','2000/9/2',1,2)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Thu Cam','2000/1/2',0,2)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Thanh Hậu','2000/10/2',0,2)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Quỳnh Anh','2000/7/2',0,3)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Diệu Anh','2000/2/7',0,3)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Ngọc Bích','2000/9/2',0,3)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Cát Tường','2000/8/5',0,3)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Minh An','2000/10/2',1,3)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Gia Hòa','2000/1/2',1,3)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Trung Dũng','2000/6/6',1,3)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Thông Đạt','2000/4/1',1,3)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Nhân Nghĩa','2000/1/2',1,3)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N' Minh Nhật','2000/10/2',1,3)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Bảo Khánh','2000/1/2',1,4)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Đăng Khoa','2000/3/4',1,4)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Ngọc Quang','2000/4/3',1,4)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Thiện Ngôn','2000/1/6',1,4)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Gia Hòa','2000/1/5',1,4)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Ngọc Bích','2000/1/4',0,4)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Mỹ Duyên','2000/10/20',0,4)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Trâm Anh','2000/11/21',0,4)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Quế Chi','2000/12/22',0,4)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Ngọc Diệp','2000/6/5',0,4)
Insert into SinhVien(name,ngaysinh,gioitinh,Malop)values(N'Quỳnh Anh','2000/5/6',0,4)

go
--------------
--Thêm dử liệu lớp giảng dạy cho giáo viên
Insert into LopGiangDay(idGiaoVien,idLop) values(1,1)
Insert into LopGiangDay(idGiaoVien,idLop) values(1,2)
Insert into LopGiangDay(idGiaoVien,idLop) values(1,3)
Insert into LopGiangDay(idGiaoVien,idLop) values(1,4)
Insert into LopGiangDay(idGiaoVien,idLop) values(2,1)
Insert into LopGiangDay(idGiaoVien,idLop) values(2,2)
Insert into LopGiangDay(idGiaoVien,idLop) values(2,3)
Insert into LopGiangDay(idGiaoVien,idLop) values(2,4)
Insert into LopGiangDay(idGiaoVien,idLop) values(3,1)
Insert into LopGiangDay(idGiaoVien,idLop) values(3,2)
Insert into LopGiangDay(idGiaoVien,idLop) values(3,3)
Insert into LopGiangDay(idGiaoVien,idLop) values(3,4)
Insert into LopGiangDay(idGiaoVien,idLop) values(4,1)
Insert into LopGiangDay(idGiaoVien,idLop) values(4,2)
Insert into LopGiangDay(idGiaoVien,idLop) values(4,3)
Insert into LopGiangDay(idGiaoVien,idLop) values(4,4)

go
--
--THÊM ĐIỂM HỌC SINH MS1
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(1,1,7,8,9,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(1,2,8,9,9,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(1,3,7,6,5,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(1,4,7,5,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(1,5,7,5,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(1,6,7,5,8,6)
--THÊM ĐIỂM HỌC SINH MS2
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(2,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(2,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(2,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(2,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(2,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(2,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS3
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(3,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(3,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(3,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(3,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(3,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(3,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS4
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(4,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(4,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(4,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(4,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(4,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(4,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS5
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(5,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(5,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(5,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(5,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(5,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(5,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS6
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(6,1,7,8,9,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(6,2,8,9,9,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(6,3,7,6,5,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(6,4,7,5,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(6,5,7,5,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(6,6,7,5,8,6)

--THÊM ĐIỂM HỌC SINH MS7
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(7,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(7,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(7,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(7,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(7,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(7,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS8
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(8,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(8,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(8,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(8,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(8,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(8,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS9
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(9,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(9,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(9,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(9,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(9,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(9,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS10
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(10,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(10,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(10,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(10,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(10,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(10,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS11
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(11,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(11,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(11,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(11,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(11,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(11,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS12
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(12,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(12,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(12,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(12,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(12,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(12,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS13
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(13,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(13,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(13,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(13,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(13,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(13,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS14
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(14,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(14,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(14,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(14,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(14,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(14,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS15
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(15,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(15,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(15,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(15,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(15,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(15,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS16
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(16,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(16,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(16,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(16,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(16,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(16,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS17
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(17,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(17,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(17,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(17,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(17,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(17,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS18
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(18,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(18,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(18,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(18,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(18,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(18,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS19
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(19,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(19,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(19,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(19,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(19,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(19,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS20
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(20,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(20,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(20,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(20,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(20,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(20,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS21
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(21,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(21,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(21,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(21,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(21,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(21,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS22
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(22,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(22,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(22,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(22,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(22,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(22,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS23
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(23,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(23,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(23,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(23,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(23,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(23,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS24
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(24,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(24,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(24,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(24,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(24,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(24,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS25
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(25,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(25,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(25,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(25,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(25,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(25,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS26
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(26,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(26,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(26,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(26,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(26,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(26,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS27
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(27,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(27,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(27,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(27,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(27,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(27,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS28
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(28,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(28,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(28,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(28,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(28,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(28,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS29
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(29,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(29,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(29,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(29,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(29,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(29,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS30
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(30,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(30,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(30,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(30,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(30,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(30,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS31
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(31,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(31,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(31,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(31,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(31,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(31,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS32
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(32,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(32,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(32,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(32,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(32,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(32,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS33
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(33,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(33,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(33,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(33,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(33,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(33,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS34
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(34,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(34,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(34,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(34,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(34,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(34,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS35
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(35,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(35,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(35,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(35,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(35,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(35,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS36
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(36,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(36,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(36,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(36,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(36,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(36,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS37
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(37,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(37,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(37,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(37,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(37,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(37,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS38
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(38,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(38,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(38,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(38,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(38,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(38,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS39
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(39,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(39,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(39,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(39,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(39,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(39,6,7,8,8,6)
--THÊM ĐIỂM HỌC SINH MS40
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(40,1,7,6,8,1)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(40,2,7,7,8,2)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(40,3,7,8,8,3)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(40,4,7,6,8,4)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(40,5,7,7,8,5)
Insert into Diem (idHocSinh,idMonHoc,diemchuyencan,diemtrungbinhkiemtra,diemthi,idgiaovien) values(40,6,7,8,8,6)
go


-------------------------------------------
Create Proc USP_GetAccountByUserName
@username nvarchar(100)
as
begin
	select * from Account where UserName=@username
end
go

Exec USP_GetAccountByUserName @username= BTKT
go
-----------
Create proc USP_Login
@username nvarchar(100), @password nvarchar(1000)
as
begin
	select * from Account where UserName= @username and Password =@password
end
go
--
Create proc USP_GetStudentList
as
begin
	select * from SinhVien
end
go

exec USP_GetStudentList
go
--
create proc USP_GetFacultyList
as
begin
	select id , name  from Khoa
end
go

---------
create proc USP_GetClassList
as
begin
	select * from Lop 
end
go

exec USP_GetClassList
go
------------
create proc USP_GetScoresList
as
begin
	select * from diem
end
go

--------
create proC USB_GetAccountList
as
begin
	select UserName,DisplayName, Type from Account
end
go



create proc USP_UpdateAccount
@userName nvarchar(100),@displayName nvarchar(100), @password nvarchar(1000), @newPassword nvarchar(1000)
as
begin
	declare @isOk int =0
	select @isOk= count(*) from Account where Username=@userName and Password=@password
	if (@isOk=1)
	begin
	if(@newPassword=NULL or @newPassword='')
		begin 
			update Account set  Displayname=@displayName where Username=@userName
		end
	else
		update  Account set Displayname=@displayName,Password=@newPassword where Username=@userName
	end


end
go

-----------------
	CREATE FUNCTION [dbo].[ThayDoiKiTu](@inputVar NVARCHAR(MAX) )
RETURNS NVARCHAR(MAX)
AS
BEGIN    
    IF (@inputVar IS NULL OR @inputVar = '')  RETURN ''
   
    DECLARE @RT NVARCHAR(MAX)
    DECLARE @SIGN_CHARS NCHAR(256)
    DECLARE @UNSIGN_CHARS NCHAR (256)
 
    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' + NCHAR(272) + NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
 
    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
   
    SET @COUNTER = 1
    WHILE (@COUNTER <= LEN(@inputVar))
    BEGIN  
        SET @COUNTER1 = 1
        WHILE (@COUNTER1 <= LEN(@SIGN_CHARS) + 1)
        BEGIN
            IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@inputVar,@COUNTER ,1))
            BEGIN          
                IF @COUNTER = 1
                    SET @inputVar = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)-1)      
                ELSE
                    SET @inputVar = SUBSTRING(@inputVar, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)- @COUNTER)
                BREAK
            END
            SET @COUNTER1 = @COUNTER1 +1
        END
        SET @COUNTER = @COUNTER +1
    END
    -- SET @inputVar = replace(@inputVar,' ','-')
    RETURN @inputVar
END

GO
	-----------
	
	create trigger AutoSetMediumScores
	on Diem for insert ,update
	as
	begin
			
				declare @idmax int
				select @idmax= max (idhocsinh) from Diem
				print @idmax
				declare @idmonhocmax int
				select @idmonhocmax= max (idMonHoc) from Diem
				print @idmonhocmax
				declare @i int =0
				declare @j int =0
				


						while @i<=@idmax
						begin

						while @j<=@idmonhocmax
							begin
								declare @id int
								declare @idMonhoc int
								select @id = @i
								select @idMonhoc = @j

									declare @diemchuyencan float 
									select @diemchuyencan= diemchuyencan from Diem where idHocSinh = @id and idMonHoc= @idMonhoc
									declare @diemtrungbinhkiemtra float 
									select @diemtrungbinhkiemtra= diemtrungbinhkiemtra from Diem  where idHocSinh = @id and idMonHoc= @idMonhoc
									declare @diemthi float 
									select @diemthi =diemthi from Diem   where idHocSinh = @id and idMonHoc= @idMonhoc

									declare @diemtb float=0;
									select @diemtb=((@diemchuyencan * 0.1)+(@diemtrungbinhkiemtra * 0.4)+ (@diemthi * 0.5))	--Tính điểm trung bình 							
										
										
											Update Diem set diemtrungbinh = (select STR(@diemtb,5,1) ) where idHocSinh = @id and idMonHoc= @idMonhoc-- câp nhật điểm trung bình cho học sinh.

																
									set @j=@j+1 
								end
								set @j=0
								set @i=@i+1
							--
						end
					
					
							
	end
	
	go
	-----
 --------------
create proc USB_InsertScores
@idStudent int, @idSubject int ,@diem15p float , @diem1tiet float , @diemthi float 
as
begin
		declare @idhocsinh int
		declare @idmonhoc int
		select @idhocsinh=id from SinhVien where id=@idStudent
		select @idmonhoc =id from MonHoc where id=@idSubject
		if(@idhocsinh = @idStudent and @idmonhoc=@idSubject)
		begin 
			insert into Diem(diemchuyencan,diemtrungbinhkiemtra,diemthi)values(@diem15p,@diem1tiet,@diemthi)
		end
		

end
go

