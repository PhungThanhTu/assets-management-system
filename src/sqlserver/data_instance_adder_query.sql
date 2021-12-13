use AssetsManagement
go

-- Supplier --
INSERT INTO Supplier (name) VALUES (N'Thế giới di động')
INSERT INTO Supplier (name) VALUES (N'FPT')
INSERT INTO Supplier (name) VALUES (N'Tin học ngôi sao')
INSERT INTO Supplier (name) VALUES (N'GearVN')
-- Device_Set --
INSERT INTO Device_Set (name) VALUES (N'PC văn phòng')
INSERT INTO Device_Set (name) VALUES (N'PC ASUS ROG Strix')
-- Contracts --
SET IDENTITY_INSERT Contracts ON
INSERT INTO Contracts (id) VALUES (1)
INSERT INTO Contracts (id) VALUES (2)
-- Device --
INSERT INTO Device (contract,set_id,name,price) VALUES (1,1,N'Màn hình samsung',750000)
INSERT INTO Device (contract,set_id,name,price) VALUES (1,1,N'CPU intel pentium 4',350000)
INSERT INTO Device (contract,set_id,name,price) VALUES (1,1,N'Chuột OEM',70000)
INSERT INTO Device (contract,set_id,name,price) VALUES (1,1,N'Bàn phím OEM',135000)
INSERT INTO Device (contract,set_id,name,price) VALUES (1,1,N'Case',700000)
INSERT INTO Device (contract,set_id,name,price) VALUES (1,1,N'Nguồn',300000)
INSERT INTO Device (contract,set_id,name,price) VALUES (1,1,N'Main',300000)

INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'Case Asus Rog Strix Helios GX 601',7900000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'Main Asus Rog Strix B365-G GAMING',2000000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'Nguồn Asus Rog Strix 650W',3800000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'GPU RTX 3060Ti',22000000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'CPU Intel core i5 11400F',6000000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'RAM Samsung DDR4 16GB',2000000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'SSD Samsung EVO 970 Plus',3100000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'Quạt tản nhiệt CPU cooler master t40',300000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'Quạt tản nhiệt CPU cooler master t40',300000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'Quạt tản nhiệt CPU cooler master t40',300000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'Bàn phím AKKO 3087 vs DS Midnight',1200000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'Chuột Microsoft Arc Mouse',2400000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'Màn hình Asus ROG Strix XG27WQ 2K 165Hz',12000000)
INSERT INTO Device (contract,set_id,name,price) VALUES (2,2,N'Dàn loa Sony 5.1 HT-S20R 400W',4000000)