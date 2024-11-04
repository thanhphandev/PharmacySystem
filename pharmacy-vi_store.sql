
CREATE TABLE unit_type (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	unit_name VARCHAR(100)           
);


CREATE TABLE supplier (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    supplier_name VARCHAR(100) NOT NULL,           
   	supplier_phone VARCHAR(50) NOT NULL,                   
    supplier_address VARCHAR(255)                  
);


CREATE TABLE medicine_group (
    group_code VARCHAR(15) PRIMARY KEY,         
    group_name VARCHAR(100) NOT NULL,                    
    group_content VARCHAR(255)                  
);

CREATE TABLE medicine_info (
    medicine_code VARCHAR(50) PRIMARY KEY,      
    medicine_name VARCHAR(100) UNIQUE,                
    unit_type INT,
    medicine_price DECIMAL(10, 2),
    medicine_img VARCHAR(255),                  
    medicine_content VARCHAR(255),               
    medicine_element VARCHAR(255),              
    group_code VARCHAR(15),             
    FOREIGN KEY (group_code) REFERENCES medicine_group(group_code),
    FOREIGN KEY (unit_type) REFERENCES unit_type(id)
);


CREATE TABLE medicine (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    medicine_expire_date DATE,           
    medicine_code VARCHAR(50),            
    supplier_id INT,                     
    FOREIGN KEY (supplier_id) REFERENCES supplier(id), 
    FOREIGN KEY (medicine_code) REFERENCES medicine_info(medicine_code)
);


CREATE TABLE medicine_quantity (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    medicine_id INT,                     
    quantity INT,                         
    FOREIGN KEY (medicine_id) REFERENCES medicine(id)
);


CREATE TABLE employee (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(30) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    full_name VARCHAR(100) COMMENT 'Họ và tên nhân viên',
    gender ENUM('male', 'female'),
    email VARCHAR(100) COMMENT 'Email nhân viên',
    phone VARCHAR(50) COMMENT 'Số điện thoại nhân viên',
    birth_date DATE COMMENT 'Ngày sinh',
    address VARCHAR(255) COMMENT 'Địa chỉ nhân viên',
    role ENUM('admin', 'manager', 'seller') NOT NULL DEFAULT 'seller'
);


CREATE TABLE pos_bill (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    pos_bill_time DATETIME DEFAULT CURRENT_TIMESTAMP,           
    pos_bill_receive DECIMAL(10, 2),      
    employee_id INT,                                      
    FOREIGN KEY (employee_id) REFERENCES employee(id)
);


INSERT INTO unit_type (unit_name) VALUES
('Viên'),
('Vỉ'),
('Ống'),
('Gói'),
('Lọ'),
('Hộp'),
('Tuýp'),
('Chai'),
('Miếng'),
('Bình xịt'),
('Bơm tiêm');

INSERT INTO supplier (supplier_name, supplier_phone, supplier_address) VALUES
('Công ty TNHH Dược phẩm Việt Nam', '0987654321', 'Hà Nội'),
('Công ty TNHH Dược phẩm Hà Nội', '0987654322', 'Hà Nội'),
('Công ty TNHH Dược phẩm Hồ Chí Minh', '0987654323', 'Hồ Chí Minh'),
('Công ty TNHH Dược phẩm Đà Nẵng', '0987654324', 'Đà Nẵng'),
('Công ty TNHH Dược phẩm Hải Phòng', '0987654325', 'Hải Phòng');

INSERT INTO medicine_group (group_code, group_name, group_content) VALUES
('ANL', 'Thuốc giảm đau', 'Nhóm thuốc giúp giảm đau nhức.'),
('ANT', 'Thuốc kháng sinh', 'Nhóm thuốc tiêu diệt hoặc ức chế vi khuẩn.'),
('ANTV', 'Thuốc kháng virus', 'Nhóm thuốc chống lại virus.'),
('ANTF', 'Thuốc kháng nấm', 'Nhóm thuốc điều trị nhiễm nấm.'),
('ANTH', 'Thuốc kháng histamin', 'Nhóm thuốc chống dị ứng.'),
('CVS', 'Thuốc tim mạch', 'Nhóm thuốc điều trị các bệnh về tim mạch.'),
('CNS', 'Thuốc thần kinh', 'Nhóm thuốc tác động lên hệ thần kinh trung ương.'),
('END', 'Thuốc nội tiết', 'Nhóm thuốc điều trị các rối loạn nội tiết.'),
('GI', 'Thuốc tiêu hóa', 'Nhóm thuốc hỗ trợ hệ tiêu hóa.'),
('RS', 'Thuốc hô hấp', 'Nhóm thuốc điều trị các bệnh về hô hấp.');

INSERT INTO medicine_info (medicine_code, medicine_name, unit_type, medicine_price, medicine_img, medicine_content, medicine_element, group_code) VALUES
('PARA', 'Paracetamol 500mg', 2, 50000, 'https://cdn.medigoapp.com/product/paracetamol_500mg_dp_thanh_nam_2_942b8959b9.jpg', 'Giảm đau, hạ sốt.', 'Paracetamol 500mg', 'ANL'),
('IBUP', 'Ibuprofen 400mg', 2, 7000, 'https://cdn.tgdd.vn/Products/Images/10023/243357/ibumed-400mg-h-100vthumb01.j-600x600.jpg', 'Giảm đau, chống viêm.', 'Ibuprofen 400mg', 'ANL'),
('AMOX', 'Amoxicillin 500mg', 6, 10000, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRa0gbftVQ-T-QYKMFiLhbLdnErggxe0xR8GA&s', 'Kháng sinh phổ rộng.', 'Amoxicillin 500mg', 'ANT'),
('AZIT', 'Azithromycin 250mg', 2, 15000, 'https://cdn.thegioididong.com/Products/Images/10026/153220/azicine-stada-250mg-mac-dinh-2.jpg', 'Kháng sinh nhóm macrolid.', 'Azithromycin 250mg', 'ANT'),
('CIPR', 'Ciprofloxacin 500mg', 2, 120000, 'https://cdnv2.tgdd.vn/mwg-static/ankhang/Products/Images/10026/247688/ciprofloxacin-500mg-stada-1-638642532549014656.jpg', 'Kháng sinh nhóm quinolon.', 'Ciprofloxacin 500mg', 'ANT'),
('METF', 'Metformin 500mg', 6, 8000, 'https://cdn.thegioididong.com/Products/Images/10049/262469/metformin-500mg-novartis-h-60v-mac-dinh-2.jpg', 'Điều trị tiểu đường type 2.', 'Metformin 500mg', 'END'),
('AMLO', 'Amlodipine 5mg', 2, 6000, 'https://cdn.thegioididong.com/Products/Images/6994/282981/amlodipine-5mg-stada-1.jpg', 'Điều trị tăng huyết áp.', 'Amlodipine 5mg', 'CVS'),
('OMEP', 'Omeprazole 20mg', 1, 9000, 'https://cdn.thegioididong.com/Products/Images/10039/129130/omeprazole-delayed-released-capsules-usp-2-1.jpg', 'Điều trị loét dạ dày.', 'Omeprazole 20mg', 'GI'),
('SIMV', 'Simvastatin 20mg', 2, 11000, 'https://cdn.thegioididong.com/Products/Images/10052/227775/silvasten-20mg-10mg-h-28v-2-1.jpg', 'Giảm cholesterol.', 'Simvastatin 20mg', 'CVS'),
('LISI', 'Lisinopril 10mg', 2, 9500, 'https://cdn.thegioididong.com/Products/Images/6994/131845/zestril-10mg-1-3.jpg', 'Điều trị tăng huyết áp.', 'Lisinopril 10mg', 'CVS'),
('ASPI', 'Aspirin 100mg', 8, 4500, 'https://cdn.thegioididong.com/Products/Images/6994/307479/aspirin-100-traphaco-dieu-tri-du-phong-nhoi-mau-co-tim-1.jpg', 'Giảm đau, hạ sốt, kháng viêm.', 'Aspirin 100mg', 'ANL'),
('CEF5', 'Cefixime 500mg', 2, 20000, 'https://cdn.thegioididong.com/Products/Images/10026/200774/thuoc-cefixim-100mg-tipharco-2.jpg', 'Kháng sinh phổ rộng nhóm cephalosporin.', 'Cefixime 500mg', 'ANT'),
('LOPE', 'Loperamide 2mg', 2, 3000, 'https://cdn.thegioididong.com/Products/Images/10042/243474/loperamide-2mg-stella-h-50v-mac-dinh-2.jpg', 'Điều trị tiêu chảy cấp.', 'Loperamide 2mg', 'GI'),
('METO', 'Metoprolol 50mg', 6, 9000, 'https://cdn.thegioididong.com/Products/Images/6994/129402/betaloc-50mg-60v-4.jpg', 'Điều trị cao huyết áp.', 'Metoprolol 50mg', 'CVS'),
('CLAR', 'Clarithromycin 250mg', 3, 18000, 'https://cdn.thegioididong.com/Products/Images/10026/131000/clarithromycin-stada-250mg-4.jpg', 'Kháng sinh nhóm macrolid.', 'Clarithromycin 250mg', 'ANT'),
('GABAP', 'Gabapentin 300mg', 5, 25000, 'https://cdn.thegioididong.com/Products/Images/10032/246525/pms-gabapentin-300mg-mac-dinh-2.jpg', 'Điều trị đau thần kinh.', 'Gabapentin 300mg', 'CNS'),
('THYR', 'Levothyroxine 50mg', 6, 7000, 'https://cdn.thegioididong.com/Products/Images/10044/131356/levothyrox-100-g-1-1.jpg', 'Điều trị suy giáp.', 'Levothyroxine 50mcg', 'END'),
('CETR', 'Cetirizine 10mg', 2, 5000, 'https://cdn.thegioididong.com/Products/Images/10036/130768/cetirizine-stada-10mg-mac-dinh-2.jpg', 'Giảm các triệu chứng dị ứng.', 'Cetirizine 10mg', 'ANTH'),
('RANI', 'Ranitidine 150mg', 1, 6000, 'https://cdn.thegioididong.com/Products/Images/10039/130431/ratidin-150mg-mac-dinh-2-1.jpg', 'Điều trị loét dạ dày và trào ngược.', 'Ranitidine 150mg', 'GI'),
('DIAZ', 'Diazepam 5mg', 5, 12000, 'https://cdn.thegioididong.com/Products/Images/9920/209299/thuoc-nho-mat-cravit-1-5-5ml-2-2.jpg', 'Giảm lo âu, co giật.', 'Diazepam 5mg', 'CNS');

INSERT INTO medicine (medicine_expire_date, medicine_code, supplier_id) VALUES
('2028-12-31', 'PARA', 1),
('2026-11-30', 'IBUP', 2),
('2026-10-15', 'AMOX', 3),
('2026-01-20', 'AZIT', 4),
('2029-09-25', 'CIPR', 5),
('2025-06-30', 'METF', 1),
('2025-08-15', 'AMLO', 2),
('2029-12-05', 'OMEP', 3),
('2030-03-10', 'SIMV', 4),
('2030-07-20', 'LISI', 5),
('2026-04-30', 'ASPI', 1),
('2028-07-15', 'CEF5', 2),
('2025-02-28', 'LOPE', 3),
('2026-10-11', 'METO', 4),
('2029-01-20', 'CLAR', 5),
('2027-05-25', 'GABAP', 1),
('2026-12-01', 'THYR', 2),
('2025-03-22', 'CETR', 3),
('2025-11-30', 'RANI', 4),
('2028-08-16', 'DIAZ', 5);


INSERT INTO medicine_quantity (medicine_id, quantity) VALUES
(1, 100),
(2, 200),
(3, 150),
(4, 300),
(5, 250),
(6, 120),
(7, 180),
(8, 90),
(9, 80),
(10, 70),
(11, 150),
(12, 130),
(13, 110),
(14, 200),
(15, 160),
(16, 90),
(17, 75),
(18, 120),
(19, 105),
(20, 95);