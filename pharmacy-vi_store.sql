CREATE DATABASE pharmacy_sys
       
USE pharmacy_sys;

-- Supplier - Done
CREATE TABLE suppliers (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    phone NVARCHAR(50) NOT NULL,
    address NVARCHAR(255),
    tax_code NVARCHAR(20)
);

-- Medicine Group - Done
CREATE TABLE medicine_groups (
    code VARCHAR(15) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(255)
);

-- Unit Type - Done
CREATE TABLE unit_types (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL UNIQUE
);

-- Medicine Info (Static info) done
CREATE TABLE medicines (
    code VARCHAR(50) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL UNIQUE,
    unit_type_id BIGINT NOT NULL,
    price DECIMAL(10, 2),
    image_url NVARCHAR(255),
    description NVARCHAR(MAX),
    ingredients NVARCHAR(MAX),
    group_code VARCHAR(15) NOT NULL,
    FOREIGN KEY (unit_type_id) REFERENCES unit_types(id),
    FOREIGN KEY (group_code) REFERENCES medicine_groups(code)
);


-- Medicine Stock (per batch) - Done
CREATE TABLE medicine_batches (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    medicine_code VARCHAR(50) NOT NULL,
    supplier_id BIGINT NOT NULL,
    expire_date DATE NOT NULL,
    quantity INT NOT NULL CHECK (quantity >= 0),
    FOREIGN KEY (medicine_code) REFERENCES medicines(code),
    FOREIGN KEY (supplier_id) REFERENCES suppliers(id)
);

-- Employees - Done
CREATE TABLE employees (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(30) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL,
    full_name NVARCHAR(100),
    gender NVARCHAR(10) NOT NULL CHECK (gender IN ('male', 'female')),
    email NVARCHAR(100),
    phone NVARCHAR(50),
    birth_date DATE,
    address NVARCHAR(255),
    role NVARCHAR(30) NOT NULL CHECK (role IN ('admin', 'staff')) DEFAULT 'staff',
);

-- POS Bills
CREATE TABLE pos_bills (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    customer_phone NVARCHAR(50),
    received_amount DECIMAL(10,2) CHECK (received_amount >= 0),
    total_amount DECIMAL(10,2),
    employee_id BIGINT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (employee_id) REFERENCES employees(id)
);

-- POS Bill Items
CREATE TABLE pos_bill_items (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    bill_id BIGINT NOT NULL,
    medicine_batch_id BIGINT NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (bill_id) REFERENCES pos_bills(id),
    FOREIGN KEY (medicine_batch_id) REFERENCES medicine_batches(id)
);



INSERT INTO unit_types (name) VALUES
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


INSERT INTO suppliers (name, phone, address) VALUES
('Công ty TNHH Dược phẩm Việt Nam', '0987654321', 'Hà Nội'),
('Công ty TNHH Dược phẩm Hà Nội', '0987654322', 'Hà Nội'),
('Công ty TNHH Dược phẩm Hồ Chí Minh', '0987654323', 'Hồ Chí Minh'),
('Công ty TNHH Dược phẩm Đà Nẵng', '0987654324', 'Đà Nẵng'),
('Công ty TNHH Dược phẩm Hải Phòng', '0987654325', 'Hải Phòng');

INSERT INTO medicine_groups (code, name, Description) VALUES
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


INSERT INTO medicines (code, name, unit_type_id, price, image_url, description, ingredients, group_code) VALUES
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

INSERT INTO medicine_batches (expire_date, medicine_code, supplier_id, quantity) VALUES
('2028-12-31', 'PARA', 1, 100),
('2026-11-30', 'IBUP', 2, 200),
('2026-10-15', 'AMOX', 3, 150),
('2026-01-20', 'AZIT', 4, 300),
('2029-09-25', 'CIPR', 5, 250),
('2025-06-30', 'METF', 1, 120),
('2025-08-15', 'AMLO', 2, 180),
('2029-12-05', 'OMEP', 3, 90),
('2030-03-10', 'SIMV', 4, 80),
('2030-07-20', 'LISI', 5, 70),
('2026-04-30', 'ASPI', 1, 150),
('2028-07-15', 'CEF5', 2, 130),
('2025-02-28', 'LOPE', 3, 110),                                                           
('2026-10-11', 'METO', 4, 200),
('2029-01-20', 'CLAR', 5, 160),
('2027-05-25', 'GABAP', 1, 90),
('2026-12-01', 'THYR', 2, 75),
('2025-03-22', 'CETR', 3, 120),
('2025-11-30', 'RANI', 4, 105),
('2028-08-16', 'DIAZ', 5, 95);