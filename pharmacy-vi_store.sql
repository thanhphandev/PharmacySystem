
CREATE TABLE unit_type (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	unit_name VARCHAR(100)           
);


CREATE TABLE supplier (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    supplier_name VARCHAR(100) NOT NULL,           
   	supplier_phone VARCHAR(50),                   
    supplier_address VARCHAR(255)                  
);


CREATE TABLE medicine_group (
    group_code VARCHAR(15) PRIMARY KEY,         
    group_name VARCHAR(100),                    
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


CREATE TABLE finance_bill (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    finance_bill_time DATETIME DEFAULT CURRENT_TIMESTAMP,           
    finance_bill_change DECIMAL(10, 2),  
    finance_is_spend_bill TINYINT(1) COMMENT 'Loại hóa đơn (1 nếu là chi tiêu, 0 nếu là khoản thu)',
    finance_bill_content VARCHAR(255),    
    employee_id INT,  
    FOREIGN KEY (employee_id) REFERENCES employee(id)
);


CREATE TABLE warehouse_bill (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    warehouse_bill_time DATETIME DEFAULT CURRENT_TIMESTAMP,
    employee_id INT,
    warehouse_is_import_bill TINYINT(1) COMMENT '(1 nếu là hóa đơn nhập, 0 nếu là hóa đơn xuất)',
    FOREIGN KEY (employee_id) REFERENCES employee(id)
);


CREATE TABLE medicine_warehouse_bill (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    warehouse_bill_id INT,                  
    medicine_id INT,                        
    medicine_quantity INT,                   
    FOREIGN KEY (warehouse_bill_id) REFERENCES warehouse_bill(id),
    FOREIGN KEY (medicine_id) REFERENCES medicine(id)
);


CREATE TABLE customer (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    customer_name VARCHAR(100),         
    customer_phone VARCHAR(50),          
    customer_address VARCHAR(255)        
);


CREATE TABLE pos_bill (
    pos_bill_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    pos_bill_time DATETIME DEFAULT CURRENT_TIMESTAMP,           
    pos_bill_receive DECIMAL(10, 2),      
    employee_id INT,                      
    pos_is_sell_bill TINYINT(1) COMMENT '(1 nếu là hóa đơn bán hàng, 0 nếu là hóa đơn trả hàng',
    warehouse_bill_id INT,                 
    finance_bill_id INT,                  
    customer_id INT,                      
    FOREIGN KEY (employee_id) REFERENCES employee(id),
    FOREIGN KEY (warehouse_bill_id) REFERENCES warehouse_bill(id),
    FOREIGN KEY (finance_bill_id) REFERENCES finance_bill(id),
    FOREIGN KEY (customer_id) REFERENCES customer(id)
);
