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
       ('KH010', N'Bùi Thị Lan Anh', N'Hà Tĩnh', '0901234567');
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
       ('NV005', N'Đỗ Quang Dũng', '1994-05-05', 'Nam', N'Nghệ An', '0961234567', 'CM001', 'TD005');
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
VALUES ('T001', 'Paracetamol', 'Paracetamol 500mg', 1000, 2000, 100, '2023-01-01', '2025-01-01', N'Mẫn cảm với paracetamol', 'NSX001', 'DDC001', 'DV001'),
       ('T002', 'Amoxicillin', 'Amoxicillin 250mg', 2000, 4000, 50, '2023-02-01', '2025-02-01', N'Mẫn cảm với penicillin', 'NSX002', 'DDC002', 'DV002'),
       ('T003', 'Ibuprofen', 'Ibuprofen 200mg', 1500, 3000, 80, '2023-03-01', '2025-03-01', N'Viêm dạ dày, suy thận', 'NSX003', 'DDC003', 'DV003'),
       ('T004', 'Aspirin', 'Aspirin 81mg', 500, 1000, 200, '2023-04-01', '2025-04-01', N'Dị ứng salicylat, xuất huyết', 'NSX004', 'DDC004', 'DV004'),
       ('T005', 'Cetirizine', 'Cetirizine 10mg', 3000, 6000, 40, '2023-05-01', '2025-05-01', N'Mẫn cảm với cetirizine', 'NSX005', 'DDC005', 'DV001'),
       ('T006', 'Omeprazole', 'Omeprazole 20mg', 4000, 8000, 60, '2023-06-01', '2025-06-01', N'Mang thai, cho con bú', 'NSX006', 'DDC001', 'DV002'),
       ('T007', 'Metformin', 'Metformin 500mg', 5000, 10000, 30, '2023-07-01', '2025-07-01', N'Suy thận, suy gan, acid lactic', 'NSX007', 'DDC003', 'DV004'),
       ('T008', 'Simvastatin', 'Simvastatin 20mg', 6000, 12000, 70, '2023-08-01', '2025-08-01', N'Mẫn cảm với simvastatin', 'NSX008', 'DDC002', 'DV003'),
       ('T009', 'Lisinopril', 'Lisinopril 10mg', 7000, 14000, 90, '2023-09-01', '2025-09-01', N'Mẫn cảm với ACE inhibitor', 'NSX009', 'DDC005', 'DV004'),
       ('T010', 'Amlodipine', 'Amlodipine 5mg', 8000, 16000, 100, '2023-10-01', '2025-10-01', N'Mẫn cảm với amlodipine', 'NSX001', 'DDC002', 'DV001'),
       ('T011', 'Atorvastatin', 'Atorvastatin 10mg', 9000, 18000, 110, '2023-11-01', '2025-11-01', N'Mẫn cảm với atorvastatin', 'NSX002', 'DDC001', 'DV001'),
       ('T012', 'Levothyroxine', 'Levothyroxine 50mcg', 10000, 20000, 120, '2023-12-01', '2025-12-01', N'Tăng hoạt động tuyến giáp', 'NSX003', 'DDC002', 'DV002'),
       ('T013', 'Hydrochlorothiazide', 'Hydrochlorothiazide 25mg', 11000, 22000, 130, '2024-01-01', N'2026-01-01', N'Mẫn cảm với thiazide', 'NSX003', 'DDC003', 'DV003'),
       ('T014', 'Losartan', 'Losartan 50mg', 12000, 24000, 140, '2024-02-01', '2026-02-01', N'Mẫn cảm với losartan', 'NSX004', 'DDC004', 'DV004'),
       ('T015', 'Prednisone', 'Prednisone 5mg', 13000, 26000, 150, '2024-03-01', '2026-03-01', N'Nhiễm trùng, loét dạ dày, tiểu đường', 'NSX009', 'DDC005', 'DV003'),
	   ('T016', 'Gabapentin', 'Gabapentin 300mg', 14000, 28000, 160, '2024-04-01', '2026-04-01', N'Mẫn cảm với gabapentin', 'NSX006', 'DDC002', 'DV004'), 
	   ('T017', 'Sertraline', 'Sertraline 50mg', 15000, 30000, 170, '2024-05-01', '2026-05-01', N'Mẫn cảm với sertraline', 'NSX007', 'DDC001', 'DV001'), 
	   ('T018', 'Alprazolam', 'Alprazolam 0.5mg', 16000, 32000, 180, '2024-06-01', '2026-06-01', N'Mang thai, cho con bú, nghiện rượu', 'NSX008', 'DDC004', 'DV001'), 
	   ('T019', 'Loratadine', 'Loratadine 10mg', 17000, 34000, 190, '2024-07-01', '2026-07-01', N'Mẫn cảm với loratadine', 'NSX009', 'DDC003', 'DV003'), 
	   ('T020', 'Melatonin', 'Melatonin 3mg', 18000, 36000, 200, '2024-08-01', '2026-08-01', N'Tăng huyết áp, bệnh gan, bệnh thận', 'NSX003', 'DDC005', 'DV001');

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
('CD030', N'Trị tiểu đường');

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
(N'Thuốc trị rối loạn tiền đình, chóng mặt', 'T020', 'CD026');

