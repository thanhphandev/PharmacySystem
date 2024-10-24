-- Lưu trữ thông tin địa điểm cửa hàng
CREATE TABLE location (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    location_name VARCHAR(100)            -- Tên địa điểm
);

CREATE TABLE unit_type (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	unit_name VARCHAR(100)            -- Tên đơn vị
);

-- Lưu trữ thông tin nhà cung cấp
 CREATE TABLE supplier (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    supplier_name VARCHAR(100) NOT NULL,            -- Tên nhà cung cấp
   	supplier_phone VARCHAR(50),                    -- Số điện thoại nhà cung cấp
    supplier_address VARCHAR(255)                   -- Địa chỉ nhà cung cấp
 );


-- Lưu trữ thông tin về nhóm thuốc
CREATE TABLE medicine_group (
    group_code VARCHAR(15) PRIMARY KEY,         -- Mã nhóm thuốc (primary key)
    group_name VARCHAR(100),                     -- Tên nhóm thuốc
    group_content VARCHAR(255)                   -- Nội dung mô tả
);

-- Lưu trữ thông tin chi tiết về thuốc
CREATE TABLE medicine_info (
    medicine_code VARCHAR(50) PRIMARY KEY, HJ      -- Mã thuốc (primary key)
    medicine_name VARCHAR(100),            Panadom      -- Tên thuốc
    unit_type INT,                         Vi      -- Đơn vị tính (liên kết với bảng unit_type)
    medicine_img VARCHAR(255),             /link      -- Hình ảnh thuốc            
    medicine_content VARCHAR(255),         thuoc nhuc dau      -- Nội dung mô tả thuốc
    medicine_element VARCHAR(255),         dhjsjhs      -- Thành phần của thuốc
    group_code VARCHAR(15),             uguuf-- Mã nhóm thuốc (liên kết với bảng medicine_group)
    FOREIGN KEY (group_code) REFERENCES medicine_group(group_code),
    FOREIGN KEY (unit_type) REFERENCES unit_type(id)
);

-- Lưu trữ thông tin về thuốc
CREATE TABLE medicine (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    medicine_expire_date DATE,            -- Ngày hết hạn của thuốc
    medicine_price DECIMAL(10, 2),        -- Giá của thuốc
    medicine_code VARCHAR(50),            -- Mã thông tin thuốc, liên kết với bảng medicine_info
    supplier_id INT,                      -- Mã định danh nhà cung cấp, liên kết với bảng supplier
    FOREIGN KEY (supplier_id) REFERENCES supplier(id),  -- Chỉ ra quan hệ với bảng supplier
    FOREIGN KEY (medicine_code) REFERENCES medicine_info(medicine_code)  -- Chỉ ra quan hệ với bảng medicine_info
);

-- Lưu trữ thông tin vị trí lưu trữ thuốc
CREATE TABLE medicine_location (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    medicine_id INT,                      -- Mã định danh thuốc, liên kết với bảng medicine
    location_id INT,                      -- Mã định danh địa điểm, liên kết với bảng location
    FOREIGN KEY (medicine_id) REFERENCES medicine(id),
    FOREIGN KEY (location_id) REFERENCES location(id)
);

-- Lưu trữ số lượng thuốc
CREATE TABLE medicine_quantity (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    medicine_id INT,                      -- Mã định danh thuốc, liên kết với bảng medicine
    quantity INT,                         -- Số lượng thuốc
    FOREIGN KEY (medicine_id) REFERENCES medicine(id)
);

-- Lưu trữ thông tin nhân viên
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


-- Lưu trữ thông tin hóa đơn tài chính (theo dõi biến động tài chính khoản thu/ khoản chi)
CREATE TABLE finance_bill (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    finance_bill_time DATETIME DEFAULT CURRENT_TIMESTAMP,            -- Thời gian tạo hóa đơn
    finance_bill_change DECIMAL(10, 2),    -- Số tiền biến động
    finance_is_spend_bill TINYINT(1) COMMENT 'Loại hóa đơn (1 nếu là chi tiêu, 0 nếu là khoản thu)',
    finance_bill_content VARCHAR(255),     -- Nội dung chi tiết của hóa đơn
    employee_id INT,                          -- Mã định danh nhân viên, liên kết với bảng employee
    FOREIGN KEY (employee_id) REFERENCES employee(id)
);

-- Lưu trữ thông tin hóa đơn kho
CREATE TABLE warehouse_bill (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    warehouse_bill_time DATETIME DEFAULT CURRENT_TIMESTAMP,       -- Thời gian tạo hóa đơn kho
    employee_id INT,                          -- Mã định danh nhân viên, liên kết với bảng employee
    warehouse_is_import_bill TINYINT(1) COMMENT 'Loại hóa đơn kho (1 nếu là hóa đơn nhập, 0 nếu là hóa đơn xuất)',
    FOREIGN KEY (employee_id) REFERENCES employee(id)
);

-- Lưu trữ thông tin hóa đơn nhập thuốc
CREATE TABLE medicine_warehouse_bill (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    warehouse_bill_id INT,                   -- Mã định danh của hóa đơn kho, liên kết với bảng warehouse_bill
    medicine_id INT,                         -- Mã định danh thuốc, liên kết với bảng medicine
    medicine_quantity INT,                   -- Số lượng thuốc
    FOREIGN KEY (warehouse_bill_id) REFERENCES warehouse_bill(id),
    FOREIGN KEY (medicine_id) REFERENCES medicine(id)
);

-- Lưu trữ thông tin khách hàng
CREATE TABLE customer (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    customer_name VARCHAR(100),            -- Tên khách hàng
    customer_phone VARCHAR(50),            -- Số điện thoại khách hàng
    customer_address VARCHAR(255)          -- Địa chỉ khách hàng
);

-- Lưu trữ thông tin hóa đơn POS (bán hàng)
CREATE TABLE pos_bill (
    pos_bill_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    pos_bill_time DATETIME DEFAULT CURRENT_TIMESTAMP,              -- Thời gian tạo hóa đơn POS
    pos_bill_receive DECIMAL(10, 2),       -- Số tiền nhận được từ khách hàng
    employee_id INT,                       -- Mã định danh nhân viên, liên kết với bảng employee
    pos_is_sell_bill TINYINT(1),           -- Loại hóa đơn POS (1 nếu là hóa đơn bán hàng, 0 nếu là hóa đơn trả hàng)
    warehouse_bill_id INT,                 -- Mã định danh hóa đơn kho, liên kết với bảng warehouse_bill
    finance_bill_id INT,                   -- Mã định danh hóa đơn tài chính, liên kết với bảng finance_bill
    customer_id INT,                       -- Mã định danh khách hàng, liên kết với bảng customer
    FOREIGN KEY (employee_id) REFERENCES employee(id),
    FOREIGN KEY (warehouse_bill_id) REFERENCES warehouse_bill(id),
    FOREIGN KEY (finance_bill_id) REFERENCES finance_bill(id),
    FOREIGN KEY (customer_id) REFERENCES customer(id)
);
