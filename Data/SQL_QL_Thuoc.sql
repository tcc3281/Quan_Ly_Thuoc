--create DATABASE QL_Thuoc
USE QL_Thuoc
CREATE TABLE KhachHang
(
  MaKhach VARCHAR(10) NOT NULL,
  TenKhach NVARCHAR(100)  NULL,
  DiaChi NVARCHAR(100)  NULL,
  DienThoai VARCHAR(15)  NULL,
  PRIMARY KEY (MaKhach)
);

CREATE TABLE CongDung
(
  MaCongDung VARCHAR(10) NOT NULL,
  TenCongDung NVARCHAR(100)  NULL,
  PRIMARY KEY (MaCongDung)
);

CREATE TABLE NhaCungCap
(
  MaNCC VARCHAR(10) NOT NULL,
  TenNCC NVARCHAR(100)  NULL,
  DiaChi NVARCHAR(100)  NULL,
  DienThoai VARCHAR(15)  NULL,
  PRIMARY KEY (MaNCC)
);

CREATE TABLE DangDieuChe
(
  MaDangDieuChe VARCHAR(10) NOT NULL,
  TenDangDieuChe NVARCHAR(100)  NULL,
  PRIMARY KEY (MaDangDieuChe)
);

CREATE TABLE NuocSX
(
  MaNSX VARCHAR(10) NOT NULL,
  TenNSX NVARCHAR(100)  NULL,
  PRIMARY KEY (MaNSX)
);

CREATE TABLE TrinhDo
(
  MaTrinhDo VARCHAR(10) NOT NULL,
  TenTrinhDo NVARCHAR(100)  NULL,
  PRIMARY KEY (MaTrinhDo)
);

CREATE TABLE ChuyenMon
(
  MaChuyenMon VARCHAR(10) NOT NULL,
  TenChuyenMon NVARCHAR(100)  NULL,
  PRIMARY KEY (MaChuyenMon)
);

CREATE TABLE DonViTinh
(
  MaDV VARCHAR(10) NOT NULL,
  TenDonViTinh NVARCHAR(100)  NULL,
  PRIMARY KEY (MaDV)
);

CREATE TABLE DanhMucThuoc
(
  MaThuoc VARCHAR(10) NOT NULL,
  TenThuoc NVARCHAR(100)  NULL,
  ThanhPhan NVARCHAR(1000)  NULL,
  DonGiaNhap FLOAT  NULL,
  GiaBan FLOAT  NULL,
  SLHienCo INT  NULL,
  NgaySX DATE  NULL,
  HanSD DATE  NULL,
  ChongChiDinh nvarchar(1000)  NULL,
  MaNSX VARCHAR(10)  NULL,
  MaDangDieuChe VARCHAR(10)  NULL,
  MaDV VARCHAR(10)  NULL,
  PRIMARY KEY (MaThuoc),
  FOREIGN KEY (MaNSX) REFERENCES NuocSX(MaNSX),
  FOREIGN KEY (MaDangDieuChe) REFERENCES DangDieuChe(MaDangDieuChe),
  FOREIGN KEY (MaDV) REFERENCES DonViTinh(MaDV)
);

CREATE TABLE NhanVien
(
  MaNhanVien VARCHAR(10) NOT NULL,
  TenNV NVARCHAR(100)  NULL,
  NgaySinh DATE  NULL,
  GioiTinh NVARCHAR(10)  NULL,
  DiaChi NVARCHAR(100)  NULL,
  DienThoai VARCHAR(15)  NULL,
  MaChuyenMon VARCHAR(10)  NULL,
  MaTrinhDo VARCHAR(10)  NULL,
  PRIMARY KEY (MaNhanVien),
  FOREIGN KEY (MaChuyenMon) REFERENCES ChuyenMon(MaChuyenMon),
  FOREIGN KEY (MaTrinhDo) REFERENCES TrinhDo(MaTrinhDo)
);

CREATE TABLE HoaDonNhap
(
  MaHDN VARCHAR(10) NOT NULL,
  NgayNhap DATE  NULL,
  TongTien FLOAT  NULL,
  MaNCC VARCHAR(10)  NULL,
  MaNhanVien VARCHAR(10)  NULL,
  PRIMARY KEY (MaHDN),
  FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC),
  FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE ChiTietHDN
(
  SLNhap INT NOT NULL,
  DonGia FLOAT  NULL,
  KhuyenMai FLOAT  NULL,
  ThanhTien FLOAT  NULL,
  MaHDN VARCHAR(10) NOT NULL,
  MaThuoc VARCHAR(10) NOT NULL,
  PRIMARY KEY (MaHDN, MaThuoc),
  FOREIGN KEY (MaHDN) REFERENCES HoaDonNhap(MaHDN),
  FOREIGN KEY (MaThuoc) REFERENCES DanhMucThuoc(MaThuoc)
);

CREATE TABLE Thuoc_CongDung
(
  GhiChu NVARCHAR(100)  NULL,
  MaThuoc VARCHAR(10) NOT NULL,
  MaCongDung VARCHAR(10) NOT NULL,
  PRIMARY KEY (MaThuoc, MaCongDung),
  FOREIGN KEY (MaThuoc) REFERENCES DanhMucThuoc(MaThuoc),
  FOREIGN KEY (MaCongDung) REFERENCES CongDung(MaCongDung)
);

CREATE TABLE HoaDonBan
(
  MaHDB VARCHAR(10) NOT NULL,
  NgayBan DATE  NULL,
  TongTien FLOAT  NULL,
  MaKhach VARCHAR(10)  NULL,
  MaNhanVien VARCHAR(10)  NULL,
  TrangThai int NULL,
  PRIMARY KEY (MaHDB),
  FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach),
  FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE ChiTietHDB
(
  SoLuong INT  NULL,
  GiamGia FLOAT  NULL,
  ThanhTien FLOAT  NULL,
  MaHDB VARCHAR(10) NOT NULL,
  MaThuoc VARCHAR(10) NOT NULL,
  PRIMARY KEY (MaHDB, MaThuoc),
  FOREIGN KEY (MaHDB) REFERENCES HoaDonBan(MaHDB),
  FOREIGN KEY (MaThuoc) REFERENCES DanhMucThuoc(MaThuoc)
);
-- Thêm 10 bản ghi vào bảng KhachHang
INSERT INTO KhachHang (MaKhach, TenKhach, DiaChi, DienThoai)
VALUES ('KH001', N'Đỗ Quang Dũng', N'Nghệ An', '0961234567'),
       ('KH002', N'Nguyễn Thị Lộ',N'Bắc Ninh', '0972345678'),
       ('KH003', N'Hoàng Văn Long', N'Cần Thơ', '0934567890'),
       ('KH004', N'Vũ Thị Hải', N'Quảng Ninh', '0923456789'),
       ('KH005', N'Trịnh Quốc Lương', N'Huế', '0956789012'),
       ('KH006', N'Lý Thị Lan', N'Bình Dương', '0947890123'),
       ('KH007', N'Ngô Văn Kiên', N'Lâm Đồng', '0989012345'),
       ('KH008', N'Dương Thị Lý', N'Hà Giang', '0990123456'),
       ('KH009', N'Phan Minh Dương', N'Kiên Giang', '0912345670'),
       ('KH010', N'Bùi Thị Lan Anh', N'Hà Tĩnh', '0901234567'),
       ('KH011', N'Trần Văn Thành', N'Đà Nẵng', '0962345678'),
       ('KH012', N'Phạm Thị Hồng', N'Hải Phòng', '0973456789'),
       ('KH013', N'Lê Văn Minh', N'Đồng Nai', '0935678901'),
       ('KH014', N'Nguyễn Thị Thanh', N'Ninh Bình', '0924567890'),
       ('KH015', N'Đặng Quốc Tuấn', N'Đắk Lắk', '0957890123'),
       ('KH016', N'Hoàng Thị Mai', N'Quảng Bình', '0948901234'),
       ('KH017', N'Võ Văn Hùng', N'An Giang', '0989023456'),
       ('KH018', N'Lê Thị Nga', N'Yên Bái', '0991234567'),
       ('KH019', N'Nguyễn Văn Hải', N'Vĩnh Phúc', '0913456789'),
       ('KH020', N'Doãn Thị Hà', N'Nam Định', '0902345678'),
       ('KH021', N'Phùng Văn Quang', N'Điện Biên', '0963456789'),
       ('KH022', N'Nguyễn Thị Hương', N'Thái Bình', '0974567890'),
       ('KH023', N'Nguyễn Văn Thắng', N'Gia Lai', '0936789012'),
       ('KH024', N'Vũ Thị Hồng', N'Phú Thọ', '0925678901'),
       ('KH025', N'Nguyễn Văn Tài', N'Bình Phước', '0958901234'),
       ('KH026', N'Phạm Thị Lan', N'Quảng Trị', '0949012345'),
       ('KH027', N'Nguyễn Văn Sơn', N'Bạc Liêu', '0989034567'),
       ('KH028', N'Nguyễn Thị Thúy', N'Lào Cai', '0992345678'),
       ('KH029', N'Nguyễn Văn Huy', N'Hà Nam', '0914567890'),
       ('KH030', N'Nguyễn Thị Ngọc', N'Ninh Thuận', '0903456789'),
       ('KH031', N'Nguyễn Văn Phúc', N'Sơn La', '0964567890'),
       ('KH032', N'Nguyễn Thị Thảo', N'Long An', '0975678901'),
       ('KH033', N'Nguyễn Văn Tùng', N'Kon Tum', '0937890123'),
       ('KH034', N'Nguyễn Thị Hằng', N'Thái Nguyên', '0926789012'),
       ('KH035', N'Nguyễn Văn Thịnh', N'Bến Tre', '0959012345'),
       ('KH036', N'Nguyễn Thị Hồng Nga', N'Lạng Sơn', '0949023456'),
       ('KH037', N'Nguyễn Văn Thành', N'Cà Mau', '0989045678'),
       ('KH038', N'Nguyễn Thị Thanh Hà', N'Tuyên Quang', '0993456789'),
       ('KH039', N'Nguyễn Văn Hùng', N'Bắc Giang', '0915678901'),
       ('KH040', N'Nguyễn Thị Thanh Thúy', N'Sóc Trăng', '0904567890');
-- Thêm một vài bản ghi vào bảng TrinhDo
INSERT INTO TrinhDo (MaTrinhDo, TenTrinhDo)
VALUES ('TD001', N'Cử nhân'),
       ('TD002', N'Thạc sĩ'),
       ('TD003', N'Tiến sĩ'),
       ('TD004', N'Giáo sư'),
       ('TD005', N'Thực tập sinh');

-- Thêm một vài bản ghi vào bảng ChuyenMon
INSERT INTO ChuyenMon (MaChuyenMon, TenChuyenMon)
VALUES ('CM001', N'Bán hàng'),
       ('CM002', N'Tư vấn khách hàng'),
       ('CM003', N'Chăm sóc khách hàng'),
       ('CM004', N'Quản lý');

-- Thêm 10 bản ghi vào bảng NhanVien
INSERT INTO NhanVien (MaNhanVien, TenNV, NgaySinh, GioiTinh, DiaChi, DienThoai, MaChuyenMon, MaTrinhDo)
VALUES ('NV001', N'Nguyễn Văn An', '1990-01-01', 'Nam', N'Hà Nội', '0123456789', 'CM001', 'TD001'),
       ('NV002', N'Trần Thị Yên', '1991-02-02', N'Nữ', N'Hồ Chí Minh', '0987654321', 'CM002', 'TD002'),
       ('NV003', N'Lê Văn Sĩ', '1992-03-03', 'Nam', N'Đà Nẵng', '0912345678', 'CM003', 'TD003'),
       ('NV004', N'Phạm Thị Mai', '1993-04-04', N'Nữ', N'Hải Phòng', '0945678912', 'CM004', 'TD004'),
       ('NV005', N'Đỗ Quang Dũng', '1994-05-05', 'Nam', N'Nghệ An', '0961234567', 'CM001', 'TD005'),
       ('NV006', N'Nguyễn Thị Hà', '1995-06-06', N'Nữ', N'Vĩnh Phúc', '0962345678', 'CM002', 'TD001'),
       ('NV007', N'Phan Văn Hùng', '1996-07-07', 'Nam', N'Đồng Tháp', '0973456789', 'CM003', 'TD002'),
       ('NV008', N'Nguyễn Thị Lan', '1997-08-08', N'Nữ', N'Quảng Nam', '0934567890', 'CM004', 'TD003'),
       ('NV009', N'Trần Văn Minh', '1998-09-09', 'Nam', N'Đắk Nông', '0923456789', 'CM001', 'TD004'),
       ('NV010', N'Phạm Thị Thanh', '1999-10-10', N'Nữ', N'Nha Trang', '0956789012', 'CM002', 'TD005'),
       ('NV011', N'Nguyễn Văn Thắng', '2000-11-11', 'Nam', N'Hải Dương', '0947890123', 'CM003', 'TD001'),
       ('NV012', N'Nguyễn Thị Hương', '2001-12-12', N'Nữ', N'Đà Lạt', '0989012345', 'CM004', 'TD002'),
       ('NV013', N'Phan Văn Tuấn', '2002-01-13', 'Nam', N'Đồng Nai', '0990123456', 'CM001', 'TD003'),
       ('NV014', N'Phạm Thị Hồng', '2003-02-14', N'Nữ', N'Phú Quốc', '0912345670', 'CM002', 'TD004'),
       ('NV015', N'Nguyễn Văn Hải', '2004-03-15', 'Nam', N'Nghệ An', '0901234567', 'CM003', 'TD005');
--Thêm Đơn Vị Tính
INSERT INTO DonViTinh(MaDV,TenDonViTinh) VALUES
('DV001',N'Viên'),
('DV002',N'Gói'),
('DV003',N'Hộp'),
('DV004',N'Vỉ');

--Thêm nước sản xuất
INSERT INTO NuocSX(MaNSX,TenNSX) values
('NSX001',N'Anh'),
('NSX002',N'Mỹ'),
('NSX003',N'Việt Nam'),
('NSX004',N'Hàn Quốc'),
('NSX005',N'Nhật Bản'),
('NSX006',N'Pháp'),
('NSX007',N'Đức'),
('NSX008',N'Úc'),
('NSX009',N'Nga');

--thêm dạng điều chế
insert into DangDieuChe(MaDangDieuChe,TenDangDieuChe) values
('DDC001',N'Viên nén'),
('DDC002',N'Viên nang'),
('DDC003',N'Viên cứng'),
('DDC004',N'Bột'),
('DDC005',N'Nước');
--thêm nhà cung cấp
delete from NhaCungCap
INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, DienThoai) 
VALUES ('NCC001', N'Công ty TNHH Dược Phẩm An Khang', N'Số 12, Ngõ 34, Đường Láng, Quận Đống Đa, Hà Nội', '024-12345678'), 
('NCC002', N'Công ty Cổ Phần Dược Phẩm Việt Nam', N'Số 5, Ngõ 45, Đường Trần Duy Hưng, Quận Cầu Giấy, Hà Nội', '024-87654321'), 
('NCC003', N'Công ty TNHH Dược Phẩm Minh Châu', N'Số 7, Ngõ 23, Đường Hoàng Quốc Việt, Quận Bắc Từ Liêm, Hà Nội', '024-45678901'), 
('NCC004', N'Công ty TNHH Dược Phẩm Thanh Hà', N'Số 9, Ngõ 67, Đường Lê Văn Lương, Quận Thanh Xuân, Hà Nội', '024-10987654'), 
('NCC005', N'Công ty TNHH Dược Phẩm Phúc Lộc', N'Số 11, Ngõ 89, Đường Nguyễn Trãi, Quận Hà Đông, Hà Nội', '024-23456789'), 
('NCC006', N'Công ty TNHH Dược Phẩm Hồng Phát', N'Số 13, Ngõ 101, Đường Giải Phóng, Quận Hoàng Mai, Hà Nội', '024-98765432'), 
('NCC007', N'Công ty TNHH Dược Phẩm Thái Dương', N'Số 15, Ngõ 123, Đường Nguyễn Chí Thanh, Quận Đống Đa, Hà Nội', '024-34567890'), 
('NCC008', N'Công ty TNHH Dược Phẩm Hà Nội', N'Số 17, Ngõ 145, Đường Kim Mã, Quận Ba Đình, Hà Nội', '024-76543210'), 
('NCC009', N'Công ty TNHH Dược Phẩm Quốc Tế', N'Số 19, Ngõ 167, Đường Phạm Hùng, Quận Nam Từ Liêm, Hà Nội', '024-56789012'), 
('NCC010', N'Công ty TNHH Dược Phẩm Đông Y', N'Số 21, Ngõ 189, Đường Ngọc Khánh, Quận Ba Đình, Hà Nội', '024-90123456');
-- Thêm 20 bản ghi vào bảng DanhMucThuoc
INSERT INTO DanhMucThuoc (MaThuoc, TenThuoc, ThanhPhan, DonGiaNhap, GiaBan, SLHienCo, NgaySX, HanSD, ChongChiDinh, MaNSX, MaDangDieuChe, MaDV)
VALUES 
	   ('T001', 'Paracetamol', 'Paracetamol 500mg', 1000, 2000, 100, '2022-01-01', '2025-01-01', N'Mẫn cảm với paracetamol', 'NSX001', 'DDC001', 'DV001'),
       ('T002', 'Amoxicillin', 'Amoxicillin 250mg', 2000, 4000, 50, '2022-02-01', '2025-02-01', N'Mẫn cảm với penicillin', 'NSX002', 'DDC002', 'DV002'),
       ('T003', 'Ibuprofen', 'Ibuprofen 200mg', 1500, 3000, 80, '2022-03-01', '2025-03-01', N'Viêm dạ dày, suy thận', 'NSX003', 'DDC003', 'DV003'),
       ('T004', 'Aspirin', 'Aspirin 81mg', 500, 1000, 200, '2022-04-01', '2025-04-01', N'Dị ứng salicylat, xuất huyết', 'NSX004', 'DDC004', 'DV004'),
       ('T005', 'Cetirizine', 'Cetirizine 10mg', 3000, 6000, 40, '2022-05-01', '2025-05-01', N'Mẫn cảm với cetirizine', 'NSX005', 'DDC005', 'DV001'),
       ('T006', 'Omeprazole', 'Omeprazole 20mg', 4000, 8000, 60, '2022-06-01', '2025-06-01', N'Mang thai, cho con bú', 'NSX006', 'DDC001', 'DV002'),
       ('T007', 'Metformin', 'Metformin 500mg', 5000, 10000, 30, '2022-07-01', '2025-07-01', N'Suy thận, suy gan, acid lactic', 'NSX007', 'DDC003', 'DV004'),
       ('T008', 'Simvastatin', 'Simvastatin 20mg', 6000, 12000, 70, '2022-08-01', '2025-08-01', N'Mẫn cảm với simvastatin', 'NSX008', 'DDC002', 'DV003'),
       ('T009', 'Lisinopril', 'Lisinopril 10mg', 7000, 14000, 90, '2022-09-01', '2025-09-01', N'Mẫn cảm với ACE inhibitor', 'NSX009', 'DDC005', 'DV004'),
       ('T010', 'Amlodipine', 'Amlodipine 5mg', 8000, 16000, 100, '2022-10-01', '2025-10-01', N'Mẫn cảm với amlodipine', 'NSX001', 'DDC002', 'DV001'),
       ('T011', 'Atorvastatin', 'Atorvastatin 10mg', 9000, 18000, 110, '2022-11-01', '2025-11-01', N'Mẫn cảm với atorvastatin', 'NSX002', 'DDC001', 'DV001'),
       ('T012', 'Levothyroxine', 'Levothyroxine 50mcg', 10000, 20000, 120, '2022-12-01', '2025-12-01', N'Tăng hoạt động tuyến giáp', 'NSX003', 'DDC002', 'DV002'),
       ('T013', 'Hydrochlorothiazide', 'Hydrochlorothiazide 25mg', 11000, 22000, 130, '2022-01-01', N'2026-01-01', N'Mẫn cảm với thiazide', 'NSX003', 'DDC003', 'DV003'),
       ('T014', 'Losartan', 'Losartan 50mg', 12000, 24000, 140, '2022-02-01', '2022-02-01', N'Mẫn cảm với losartan', 'NSX004', 'DDC004', 'DV004'),
       ('T015', 'Prednisone', 'Prednisone 5mg', 13000, 26000, 150, '2022-03-01', '2026-03-01', N'Nhiễm trùng, loét dạ dày, tiểu đường', 'NSX009', 'DDC005', 'DV003'),
	   ('T016', 'Gabapentin', 'Gabapentin 300mg', 14000, 28000, 160, '2022-04-01', '2026-04-01', N'Mẫn cảm với gabapentin', 'NSX006', 'DDC002', 'DV004'), 
	   ('T017', 'Sertraline', 'Sertraline 50mg', 15000, 30000, 170, '2022-05-01', '2026-05-01', N'Mẫn cảm với sertraline', 'NSX007', 'DDC001', 'DV001'), 
	   ('T018', 'Alprazolam', 'Alprazolam 0.5mg', 16000, 32000, 180, '2022-06-01', '2026-06-01', N'Mang thai, cho con bú, nghiện rượu', 'NSX008', 'DDC004', 'DV001'), 
	   ('T019', 'Loratadine', 'Loratadine 10mg', 17000, 34000, 190, '2022-07-01', '2026-07-01', N'Mẫn cảm với loratadine', 'NSX009', 'DDC003', 'DV003'), 
	   ('T020', 'Melatonin', 'Melatonin 3mg', 18000, 36000, 200, '2022-08-01', '2026-08-01', N'Tăng huyết áp, bệnh gan, bệnh thận', 'NSX003', 'DDC005', 'DV001'),
	   ('T021', 'Acetaminophen', 'Acetaminophen 325mg', 19000, 38000, 210, '2022-09-01', '2026-09-01', N'Mẫn cảm với acetaminophen', 'NSX001', 'DDC001', 'DV002'),
       ('T022', 'Ciprofloxacin', 'Ciprofloxacin 500mg', 20000, 40000, 220, '2022-10-01', '2026-10-01', N'Mẫn cảm với quinolone, suy thận', 'NSX002', 'DDC002', 'DV003'),
       ('T023', 'Fluoxetine', 'Fluoxetine 20mg', 21000, 42000, 230, '2022-11-01', '2026-11-01', N'Mẫn cảm với fluoxetine, tăng nhãn áp', 'NSX003', 'DDC003', 'DV004'),
       ('T024', 'Diphenhydramine', 'Diphenhydramine 25mg', 22000, 44000, 240, '2022-12-01', '2026-12-01', N'Mẫn cảm với diphenhydramine, glaucoma', 'NSX004', 'DDC004', 'DV001'),
       ('T025', 'Ranitidine', 'Ranitidine 150mg', 23000, 46000, 250, '2022-01-01', '2027-01-01', N'Mẫn cảm với ranitidine, suy gan', 'NSX005', 'DDC005', 'DV002'),
       ('T026', 'Clonazepam', 'Clonazepam 0.5mg', 24000, 48000, 260, '2022-02-01', '2027-02-01', N'Mang thai, cho con bú, nghiện rượu', 'NSX006', 'DDC001', 'DV003'),
       ('T027', 'Montelukast', 'Montelukast 10mg', 25000, 50000, 270, '2022-03-01', '2027-03-01', N'Mẫn cảm với montelukast', 'NSX007', 'DDC002', 'DV004'),
       ('T028', 'Tramadol', 'Tramadol 50mg', 26000, 52000, 280, '2022-04-01', '2027-04-01', N'Mẫn cảm với tramadol, suy thận, suy gan', 'NSX008', 'DDC003', 'DV001'),
       ('T029', 'Fexofenadine', 'Fexofenadine 180mg', 27000, 54000, 290, '2022-05-01', '2027-05-01', N'Mẫn cảm với fexofenadine', 'NSX009', 'DDC004', 'DV002'),
       ('T030', 'Rosuvastatin', 'Rosuvastatin 10mg', 28000, 56000, 300, '2022-06-01', '2027-06-01', N'Mẫn cảm với rosuvastatin', 'NSX001', 'DDC005', 'DV003'),
       ('T031', 'Esomeprazole', 'Esomeprazole 20mg', 29000, 58000, 310, '2022-07-01', '2027-07-01', N'Mang thai, cho con bú', 'NSX002', 'DDC001', 'DV004'),
       ('T032', 'Lorazepam', 'Lorazepam 1mg', 30000, 60000, 320, '2022-08-01', '2027-08-01', N'Mang thai, cho con bú, nghiện rượu', 'NSX003', 'DDC002', 'DV001'),
       ('T033', 'Clopidogrel', 'Clopidogrel 75mg', 31000, 62000, 330, '2022-09-01', '2027-09-01', N'Mẫn cảm với clopidogrel, xuất huyết', 'NSX004', 'DDC003', 'DV002'),
       ('T034', 'Warfarin', 'Warfarin 5mg', 32000, 64000, 340, '2022-10-01', '2027-10-01', N'Mẫn cảm với warfarin, xuất huyết', 'NSX005', 'DDC004', 'DV003'),
       ('T035', 'Bupropion', 'Bupropion 150mg', 33000, 66000, 350, '2022-11-01', '2027-11-01', N'Mẫn cảm với bupropion, động kinh', 'NSX006', 'DDC005', 'DV004'),
	   ('T036', 'Trazodone', 'Trazodone 50mg', 34000, 68000, 360, '2022-12-01', '2027-12-01', N'Mẫn cảm với trazodone, tăng nhãn áp', 'NSX007', 'DDC001', 'DV001'), 
	   ('T037', 'Oxycodone', 'Oxycodone 5mg', 35000, 70000, 370, '2022-01-01', '2028-01-01', N'Mẫn cảm với oxycodone, suy thận, suy gan', 'NSX008', 'DDC002', 'DV002'), 
	   ('T038', 'Venlafaxine', 'Venlafaxine 75mg', 36000, 72000, 380, '2022-02-01', '2028-02-01', N'Mẫn cảm với venlafaxine, tăng nhãn áp', 'NSX009', 'DDC003', 'DV003'), 
	   ('T039', 'Lansoprazole', 'Lansoprazole 15mg', 37000, 74000, 390, '2022-03-01', '2028-03-01', N'Mang thai, cho con bú', 'NSX001', 'DDC004', 'DV004'), 
	   ('T040', 'Diazepam', 'Diazepam 5mg', 38000, 76000, 400, '2022-04-01', '2028-04-01', N'Mang thai, cho con bú, nghiện rượu', 'NSX002', 'DDC005', 'DV001');
--them cong dung
-- Chèn 15 bản ghi vào bảng CongDung
INSERT INTO CongDung (MaCongDung, TenCongDung)
VALUES
('CD001', N'Hạ sốt'),
('CD002', N'Giảm đau'),
('CD003', N'Kháng viêm'),
('CD004', N'Chống dị ứng'),
('CD005', N'Hoạt huyết'),
('CD006', N'An thần'),
('CD007', N'Bổ sung vitamin'),
('CD008', N'Tăng cường miễn dịch'),
('CD009', N'Thanh nhiệt'),
('CD010', N'Giải độc'),
('CD011', N'Trị mụn'),
('CD012', N'Làm đẹp da'),
('CD013', N'Giảm cân'),
('CD014', N'Tăng cường sinh lý'),
('CD015', N'Phòng ngừa ung thư'),
('CD016', N'Trị ho'),
('CD017', N'Trị cảm'),
('CD018', N'Trị viêm họng'),
('CD019', N'Trị đau bụng'),
('CD020', N'Trị tiêu chảy'),
('CD021', N'Trị táo bón'),
('CD022', N'Trị sổ mũi'),
('CD023', N'Trị viêm xoang'),
('CD024', N'Trị đau đầu'),
('CD025', N'Trị mất ngủ'),
('CD026', N'Trị rối loạn tiền đình'),
('CD027', N'Trị đau khớp'),
('CD028', N'Trị gout'),
('CD029', N'Trị cao huyết áp'),
('CD030', N'Trị tiểu đường'),
('CD031', N'Trị đau răng'),
('CD032', N'Trị viêm nha chu'),
('CD033', N'Trị sâu răng'),
('CD034', N'Trị nhiễm trùng răng miệng'),
('CD035', N'Trị viêm loét dạ dày'),
('CD036', N'Trị trào ngược dạ dày'),
('CD037', N'Trị viêm gan'),
('CD038', N'Trị men gan cao'),
('CD039', N'Trị sỏi mật'),
('CD040', N'Trị viêm ruột');

--them thuoc-congdung
INSERT INTO Thuoc_CongDung (GhiChu, MaThuoc, MaCongDung)
VALUES
(N'Thuốc hạ sốt, giảm đau, kháng viêm', 'T001', 'CD001'),
(N'Thuốc hạ sốt, giảm đau, kháng viêm', 'T001', 'CD002'),
(N'Thuốc hạ sốt, giảm đau, kháng viêm', 'T001', 'CD003'),
(N'Thuốc chống dị ứng, giảm ngứa', 'T002', 'CD004'),
(N'Thuốc chống dị ứng, giảm ngứa', 'T002', 'CD002'),
(N'Thuốc hoạt huyết, giảm đau', 'T003', 'CD005'),
(N'Thuốc hoạt huyết, giảm đau', 'T003', 'CD002'),
(N'Thuốc an thần, giúp ngủ ngon', 'T004', 'CD006'),
(N'Thuốc bổ sung vitamin C', 'T005', 'CD007'),
(N'Thuốc bổ sung vitamin C', 'T005', 'CD008'),
(N'Thuốc thanh nhiệt, giải độc', 'T006', 'CD009'),
(N'Thuốc thanh nhiệt, giải độc', 'T006', 'CD010'),
(N'Thuốc trị mụn, làm đẹp da', 'T007', 'CD011'),
(N'Thuốc trị mụn, làm đẹp da', 'T007', 'CD012'),
(N'Thuốc giảm cân, tăng cường sinh lý', 'T008', 'CD013'),
(N'Thuốc giảm cân, tăng cường sinh lý', 'T008', 'CD014'),
(N'Thuốc phòng ngừa ung thư', 'T009', 'CD015'),
(N'Thuốc trị ho, giảm đau họng', 'T010', 'CD016'),
(N'Thuốc trị ho, giảm đau họng', 'T010', 'CD002'),
(N'Thuốc trị cảm, hạ sốt', 'T011', 'CD017'),
(N'Thuốc trị cảm, hạ sốt', 'T011', 'CD001'),
(N'Thuốc trị viêm họng, giảm đau', 'T012', 'CD018'),
(N'Thuốc trị viêm họng, giảm đau', 'T012', 'CD002'),
(N'Thuốc trị đau bụng, kích thích tiêu hóa', 'T013', 'CD019'),
(N'Thuốc trị tiêu chảy, bổ sung nước và điện giải', 'T014', 'CD020'),
(N'Thuốc trị táo bón, nhuận tràng', 'T015', 'CD021'),
(N'Thuốc trị sổ mũi, giảm ngạt mũi', 'T016', 'CD022'),
(N'Thuốc trị viêm xoang, thông mũi', 'T017', 'CD023'),
(N'Thuốc trị đau đầu, giảm căng thẳng', 'T018', 'CD024'),
(N'Thuốc trị mất ngủ, an thần', 'T019', 'CD025'),
(N'Thuốc trị rối loạn tiền đình, chóng mặt', 'T020', 'CD026'),
(N'Thuốc trị đau khớp, kháng viêm', 'T021', 'CD027'),
(N'Thuốc trị đau khớp, kháng viêm', 'T021', 'CD003'),
(N'Thuốc trị gout, giảm acid uric', 'T022', 'CD028'),
(N'Thuốc trị gout, giảm acid uric', 'T022', 'CD010'),
(N'Thuốc trị cao huyết áp, giãn mạch', 'T023', 'CD029'),
(N'Thuốc trị tiểu đường, giảm đường huyết', 'T024', 'CD030'),
(N'Thuốc trị đau răng, kháng viêm', 'T025', 'CD031'),
(N'Thuốc trị đau răng, kháng viêm', 'T025', 'CD003'),
(N'Thuốc trị viêm nha chu, kháng khuẩn', 'T026', 'CD032'),
(N'Thuốc trị viêm nha chu, kháng khuẩn', 'T026', 'CD008'),
(N'Thuốc trị sâu răng, giảm đau', 'T027', 'CD033'),
(N'Thuốc trị sâu răng, giảm đau', 'T027', 'CD002'),
(N'Thuốc trị nhiễm trùng răng miệng, kháng khuẩn', 'T028', 'CD034'),
(N'Thuốc trị nhiễm trùng răng miệng, kháng khuẩn', 'T028', 'CD008'),
(N'Thuốc trị viêm loét dạ dày, ức chế tiết axit', 'T029', 'CD035'),
(N'Thuốc trị trào ngược dạ dày, ức chế tiết axit', 'T030', 'CD036'),
(N'Thuốc trị viêm gan, giải độc gan', 'T031', 'CD037'),
(N'Thuốc trị viêm gan, giải độc gan', 'T031', 'CD010'),
(N'Thuốc trị men gan cao, giảm mỡ máu', 'T032', 'CD038'),
(N'Thuốc trị men gan cao, giảm mỡ máu', 'T032', 'CD013'),
(N'Thuốc trị sỏi mật, giải độc mật', 'T033', 'CD039'),
(N'Thuốc trị sỏi mật, giải độc mật', 'T033', 'CD010'),
(N'Thuốc trị viêm ruột, kháng khuẩn', 'T034', 'CD008'),
(N'Thuốc trị viêm ruột, kháng khuẩn', 'T034', 'CD040'),
(N'Thuốc trị đau dạ dày, giảm đau', 'T035', 'CD019'),
(N'Thuốc trị đau dạ dày, giảm đau', 'T035', 'CD002'),
(N'Thuốc trị trào ngược dạ dày, ức chế tiết axit', 'T036', 'CD036'),
(N'Thuốc trị trào ngược dạ dày, ức chế tiết axit', 'T036', 'CD019'),
(N'Thuốc trị viêm gan, giải độc gan', 'T037', 'CD037'),
(N'Thuốc trị viêm gan, giải độc gan', 'T037', 'CD010'),
(N'Thuốc trị men gan cao, giảm mỡ máu', 'T038', 'CD038'),
(N'Thuốc trị men gan cao, giảm mỡ máu', 'T038', 'CD013'),
(N'Thuốc trị sỏi mật, giải độc mật', 'T039', 'CD039'),
(N'Thuốc trị sỏi mật, giải độc mật', 'T039', 'CD010'),
(N'Thuốc trị đái tháo đường, giảm đường huyết', 'T040', 'CD030'),
(N'Thuốc trị đái tháo đường, giảm đường huyết', 'T040', 'CD013');
--THEM HOA DON BAN
insert into HoaDonBan(MaHDB,MaKhach,MaNhanVien,NgayBan,TongTien,TrangThai) 
values
('HDB001','KH001','NV001','2023-01-01',10000*3+20000*1+15000*5,1),
('HDB002', 'KH021', 'NV011', '2023-01-02', 10000*2+20000*3+15000*4, 1),
('HDB003', 'KH032', 'NV012', '2023-01-03', 10000*5+20000*2+15000*3, 1),
('HDB004', 'KH013', 'NV013', '2023-01-04', 10000*4+20000*4+15000*2, 1),
('HDB005', 'KH024', 'NV014', '2023-01-05', 10000*3+20000*5+15000*1, 1),
('HDB006', 'KH035', 'NV015', '2023-01-06', 10000*6+20000*1+15000*5, 1),
('HDB007', 'KH016', 'NV001', '2023-01-07', 10000*7+20000*3+15000*4, 1),
('HDB008', 'KH027', 'NV002', '2023-01-08', 10000*8+20000*2+15000*3, 1),
('HDB009', 'KH038', 'NV003', '2023-01-09', 10000*9+20000*4+15000*2, 1),
('HDB010', 'KH019', 'NV004', '2023-01-10', 10000*10+20000*5+15000*1, 1),
('HDB011', 'KH030', 'NV005', '2023-01-11', 10000*1+20000*6+15000*5, 1);
		
--chi tiết thêm hóa đơn bán
insert into ChiTietHDB(MaHDB,MaThuoc,SoLuong,ThanhTien,GiamGia)
values 
('HDB001','T001',3,10000,0),
('HDB001','T004',1,20000,0),
('HDB001','T002',5,15000,0),
('HDB002', 'T002', 2, 10000, 0),
('HDB002', 'T005', 3, 20000, 0),
('HDB002', 'T008', 4, 15000, 0),
('HDB003', 'T011', 5, 10000, 0),
('HDB003', 'T014', 2, 20000, 0),
('HDB003', 'T017', 3, 15000, 0),
('HDB004', 'T020', 4, 10000, 0),
('HDB004', 'T023', 4, 20000, 0),
('HDB004', 'T026', 2, 15000, 0),
('HDB005', 'T029', 3, 10000, 0),
('HDB005', 'T032', 5, 20000, 0),
('HDB005', 'T035', 1, 15000, 0),
('HDB006', 'T038', 6, 10000, 0),
('HDB006', 'T040', 1, 20000, 0),
('HDB006', 'T034', 5, 15000, 0),
('HDB007', 'T027', 7, 10000, 0),
('HDB007', 'T010', 3, 20000, 0),
('HDB007', 'T003', 4, 15000, 0),
('HDB008', 'T026', 8, 10000, 0),
('HDB008', 'T029', 2, 20000, 0),
('HDB008', 'T012', 3, 15000, 0),
('HDB009', 'T005', 9, 10000, 0),
('HDB009', 'T038', 4, 20000, 0),
('HDB009', 'T031', 2, 15000, 0),
('HDB010', 'T024', 10, 10000, 0),
('HDB010', 'T007', 5, 20000, 0),
('HDB010', 'T010', 1, 15000, 0),
('HDB011', 'T033', 1, 10000, 0),
('HDB011', 'T026', 6, 20000, 0),
('HDB011', 'T019', 5, 15000, 0);
select a.MaThuoc as Mã Thuốc,a.TenThuoc as Tên Thuốc,a.ThanhPhan as Thành phần,a.DonGiaNhap as Giá nhập ,a.GiaBan as Giá bán,a.SLHienCo as Số lượng hiện có,a.NgaySX as Ngày sản xuất,a.HanSD as Hạn sử dụng,a.ChongChiDinh as Chống chỉ định,b.TenNSX as Tên nhà sản xuất,c.TenDangDieuChe as Tên dạng điều chế,d.TenDonViTinh as Đơn vị tính\r\nfrom DanhMucThuoc a join NuocSX b on a.MaNSX=b.MaNSX
join DangDieuChe c on a.MaDangDieuChe=c.MaDangDieuChe
join DonViTinh d on a.MaDV=d.MaDV