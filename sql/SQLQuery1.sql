create database PQGD

create table GiaoVien(
	id_giaovien varchar(20) not null,
	 primary key(id_giaovien),
	 hoten nvarchar(50) not null,
	 gioitinh nvarchar(10) not null,
	 ngaysinh datetime not null,
	 matkhau varchar(50) not null,
	 sdt varchar(10) not null,
	 email varchar(50)not null
);

create table Lop(
	 malop varchar(20) not null,
	 primary key(malop),
	 tenlop nvarchar(50) not null,
);

create table MonHoc(
	 mamh varchar(20) not null,
	 primary key(mamh),
	 tenmh nvarchar(50) not null,
);
	

create table HocKyNamHoc(
	 hocky varchar(10) not null,
	 primary key(HocKy),
	 namhoc nvarchar(20) not null,
);

	create table PhanQuyen(
	id_phanquyen varchar(20) not null,
	primary key(id_phanquyen),
	 magv varchar(20) not null,
	 malop varchar(20) not null,
	 mamh varchar(20) not null,
	 hocky varchar(10) not null,
	 matkhau varchar(50) not null,
	 vaitro varchar(20) not null
);