CREATE DATABASE pharmacy_db;

USE pharmacy_db;
-- Nhà cung cấp
CREATE TABLE suppliers (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    code VARCHAR(20) NOT NULL UNIQUE,  -- Thêm mã nhà cung cấp để dễ tra cứu
    name NVARCHAR(100) NOT NULL,
    phone NVARCHAR(20) NOT NULL,
    email NVARCHAR(100),               -- Thêm email liên hệ
    address NVARCHAR(255),
    tax_code NVARCHAR(20),             -- Thêm mã số thuế
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);

-- Nhóm thuốc
CREATE TABLE medicine_groups (
    code VARCHAR(15) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(255),
    parent_code VARCHAR(15),           -- Thêm liên kết phân cấp nhóm thuốc
    status BIT DEFAULT 1,              -- Trạng thái hoạt động
    FOREIGN KEY (parent_code) REFERENCES medicine_groups(code)
);

-- Đơn vị tính
CREATE TABLE unit_types (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL UNIQUE,
    description NVARCHAR(255)
);

-- Thuốc
CREATE TABLE medicines (
    code VARCHAR(50) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL UNIQUE,
    generic_name NVARCHAR(200),        -- Tên hoạt chất
    base_unit_id BIGINT NOT NULL,      -- Đơn vị cơ bản
    retail_unit_id BIGINT NOT NULL,    -- Đơn vị bán lẻ
    base_price DECIMAL(10, 2),         -- Giá cơ bản
    retail_price DECIMAL(10, 2),       -- Giá bán lẻ
    wholesale_price DECIMAL(10, 2),    -- Giá bán sỉ
    image_url NVARCHAR(255),
    description NVARCHAR(MAX),
    ingredients NVARCHAR(MAX),
    usage_guide NVARCHAR(MAX),         -- Hướng dẫn sử dụng
    side_effects NVARCHAR(MAX),        -- Tác dụng phụ
    group_code VARCHAR(15) NOT NULL,
    barcode VARCHAR(50),               -- Mã vạch
    manufacturer NVARCHAR(100),        -- Nhà sản xuất
    is_prescription BIT DEFAULT 0,     -- Có kê đơn không
    is_active BIT DEFAULT 1,           -- Trạng thái hoạt động
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (base_unit_id) REFERENCES unit_types(id),
    FOREIGN KEY (retail_unit_id) REFERENCES unit_types(id),
    FOREIGN KEY (group_code) REFERENCES medicine_groups(code)
);

-- Đơn vị quy đổi
CREATE TABLE unit_conversions (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    from_unit_id BIGINT NOT NULL,
    to_unit_id BIGINT NOT NULL,
    ratio DECIMAL(10, 4) NOT NULL,     -- Tỷ lệ quy đổi
    medicine_code VARCHAR(50) NOT NULL, -- Áp dụng cho thuốc cụ thể
    FOREIGN KEY (from_unit_id) REFERENCES unit_types(id),
    FOREIGN KEY (to_unit_id) REFERENCES unit_types(id),
    FOREIGN KEY (medicine_code) REFERENCES medicines(code)
);

-- Khách hàng
CREATE TABLE customers (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    phone NVARCHAR(20) NOT NULL UNIQUE,
    fullname NVARCHAR(100),
    gender NVARCHAR(10) CHECK (gender IN ('male', 'female', 'other')),
    email NVARCHAR(100),
    points INT DEFAULT 0,              -- Điểm tích lũy
    customer_type VARCHAR(20) DEFAULT 'normal' CHECK (customer_type IN ('normal', 'vip', 'wholesale')),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);


-- Lịch sử giá thuốc
CREATE TABLE medicine_price_history (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    medicine_code VARCHAR(50) NOT NULL,
    base_price DECIMAL(10, 2) NOT NULL,
    retail_price DECIMAL(10, 2) NOT NULL,
    wholesale_price DECIMAL(10, 2),
    effective_date DATETIME NOT NULL,  -- Ngày có hiệu lực
    employee_id BIGINT,                -- Người cập nhật
    reason NVARCHAR(255),              -- Lý do thay đổi
    FOREIGN KEY (medicine_code) REFERENCES medicines(code)
);

-- Lô thuốc
CREATE TABLE medicine_batches (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    batch_code VARCHAR(50) NOT NULL UNIQUE, -- Mã lô
    medicine_code VARCHAR(50) NOT NULL,
    supplier_id BIGINT NOT NULL,
    manufacturing_date DATE,           -- Ngày sản xuất
    expire_date DATE NOT NULL,
    import_date DATE DEFAULT GETDATE(), -- Ngày nhập kho
    quantity INT NOT NULL CHECK (quantity >= 0),
    import_price DECIMAL(10, 2) NOT NULL, -- Giá nhập
    notes NVARCHAR(255),
    status VARCHAR(20) DEFAULT 'active' CHECK (status IN ('active', 'expired', 'damaged', 'recalled')),
    FOREIGN KEY (medicine_code) REFERENCES medicines(code),
    FOREIGN KEY (supplier_id) REFERENCES suppliers(id)
);

-- Phiếu nhập kho
CREATE TABLE import_invoices (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    invoice_number VARCHAR(50) NOT NULL UNIQUE,
    supplier_id BIGINT NOT NULL,
    import_date DATETIME DEFAULT GETDATE(),
    total_amount DECIMAL(12, 2),
    tax_amount DECIMAL(10, 2),
    payment_status VARCHAR(20) DEFAULT 'unpaid' CHECK (payment_status IN ('unpaid', 'partial', 'paid')),
    notes NVARCHAR(255),
    employee_id BIGINT NOT NULL,
    FOREIGN KEY (supplier_id) REFERENCES suppliers(id)
);

-- Chi tiết phiếu nhập kho
CREATE TABLE import_invoice_items (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    invoice_id BIGINT NOT NULL,
    medicine_batch_id BIGINT NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    import_price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (invoice_id) REFERENCES import_invoices(id),
    FOREIGN KEY (medicine_batch_id) REFERENCES medicine_batches(id)
);

-- Nhân viên
CREATE TABLE employees (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    employee_code VARCHAR(20) NOT NULL UNIQUE, -- Mã nhân viên
    username NVARCHAR(30) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL,
    fullname NVARCHAR(100) NOT NULL,
    gender NVARCHAR(10) NOT NULL CHECK (gender IN ('male', 'female', 'other')),
    email NVARCHAR(100),
    phone NVARCHAR(20),
    birth_date DATE,
    address NVARCHAR(255),
    role VARCHAR(30) NOT NULL CHECK (role IN ('admin', 'manager', 'staff')),
    status VARCHAR(20) DEFAULT 'active' CHECK (status IN ('active', 'inactive', 'suspended')),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    last_login DATETIME
);

-- Hóa đơn bán hàng
CREATE TABLE pos_bills (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    bill_number VARCHAR(50) NOT NULL UNIQUE, -- Số hóa đơn
    customer_id BIGINT,                  -- Liên kết với bảng khách hàng
    created_at DATETIME DEFAULT GETDATE(),
    received_amount DECIMAL(12, 2) CHECK (received_amount >= 0),
    discount_amount DECIMAL(10, 2) DEFAULT 0,
    tax_amount DECIMAL(10, 2) DEFAULT 0,
    payment_method VARCHAR(20) DEFAULT 'cash' CHECK (payment_method IN ('cash', 'card', 'transfer', 'mixed')),
    total_amount DECIMAL(12, 2) DEFAULT 0,
    employee_id BIGINT NOT NULL,
    status VARCHAR(20) DEFAULT 'completed' CHECK (status IN ('pending', 'completed', 'cancelled', 'refunded')),
    notes NVARCHAR(255),
    FOREIGN KEY (customer_id) REFERENCES customers(id),
    FOREIGN KEY (employee_id) REFERENCES employees(id)
);

-- Chi tiết hóa đơn
CREATE TABLE pos_bill_items (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    bill_id BIGINT NOT NULL,
    medicine_batch_id BIGINT NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    unit_price DECIMAL(10, 2) NOT NULL,
    discount_percent DECIMAL(5, 2) DEFAULT 0,
    item_total AS (quantity * unit_price * (1 - discount_percent/100)) PERSISTED,
    FOREIGN KEY (bill_id) REFERENCES pos_bills(id),
    FOREIGN KEY (medicine_batch_id) REFERENCES medicine_batches(id)
);


-- Bảng theo dõi tồn kho
CREATE TABLE inventory_transactions (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    transaction_type VARCHAR(20) NOT NULL CHECK (transaction_type IN ('import', 'sale', 'return', 'adjustment', 'expired', 'damage')),
    medicine_batch_id BIGINT NOT NULL,
    quantity INT NOT NULL, -- Số lượng (dương: nhập, âm: xuất)
    reference_id BIGINT,   -- ID của hóa đơn hoặc phiếu nhập
    reference_type VARCHAR(20) NOT NULL CHECK (reference_type IN ('import_invoice', 'pos_bill', 'adjustment_form')),
    transaction_date DATETIME DEFAULT GETDATE(),
    notes NVARCHAR(255),
    employee_id BIGINT NOT NULL,
    FOREIGN KEY (medicine_batch_id) REFERENCES medicine_batches(id),
    FOREIGN KEY (employee_id) REFERENCES employees(id)
);

-- Trigger để kiểm tra và cập nhật số lượng tồn kho khi bán hàng
CREATE OR ALTER TRIGGER check_stock_on_sale
ON pos_bill_items
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra nếu số lượng bán vượt quá số lượng tồn
    IF EXISTS (
        SELECT 1 FROM inserted i
        JOIN medicine_batches mb ON i.medicine_batch_id = mb.id
        WHERE mb.quantity < i.quantity
    )
    BEGIN
        RAISERROR('Số lượng bán vượt quá số lượng tồn kho!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
    
    -- Cập nhật số lượng tồn kho
    UPDATE mb
    SET mb.quantity = mb.quantity - (i.quantity - ISNULL(d.quantity, 0))
    FROM medicine_batches mb
    JOIN inserted i ON mb.id = i.medicine_batch_id
    LEFT JOIN deleted d ON i.id = d.id;
    
    -- Thêm vào bảng inventory_transactions
    INSERT INTO inventory_transactions (
        transaction_type, medicine_batch_id, quantity, 
        reference_id, reference_type, employee_id
    )
    SELECT 
        'sale', i.medicine_batch_id, -i.quantity,
        i.bill_id, 'pos_bill', 
        (SELECT employee_id FROM pos_bills WHERE id = i.bill_id)
    FROM inserted i;
END;

-- Trigger để cập nhật tồn kho khi nhập hàng
CREATE OR ALTER TRIGGER update_stock_on_import
ON import_invoice_items
AFTER INSERT
AS
BEGIN
    -- Cập nhật số lượng tồn kho
    UPDATE mb
    SET mb.quantity = mb.quantity + i.quantity
    FROM medicine_batches mb
    JOIN inserted i ON mb.id = i.medicine_batch_id;
    
    -- Thêm vào bảng inventory_transactions
    INSERT INTO inventory_transactions (
        transaction_type, medicine_batch_id, quantity, 
        reference_id, reference_type, employee_id
    )
    SELECT 
        'import', i.medicine_batch_id, i.quantity,
        i.invoice_id, 'import_invoice', 
        (SELECT employee_id FROM import_invoices WHERE id = i.invoice_id)
    FROM inserted i;
END;

-- Dữ liệu mẫu cho bảng suppliers
INSERT INTO suppliers (code, name, phone, email, address, tax_code)
VALUES
('SUP001', 'Công ty TNHH Dược phẩm Việt Nam', '0987654321', 'info@vietpharm.com', 'Hà Nội', '0123456789'),
('SUP002', 'Công ty TNHH Dược phẩm Hà Nội', '0987654322', 'info@hanoipharm.com', 'Hà Nội', '0123456788'),
('SUP003', 'Công ty TNHH Dược phẩm Hồ Chí Minh', '0987654323', 'info@hcmpharm.com', 'Hồ Chí Minh', '0123456787'),
('SUP004', 'Công ty TNHH Dược phẩm Đà Nẵng', '0987654324', 'info@danangpharm.com', 'Đà Nẵng', '0123456786'),
('SUP005', 'Công ty TNHH Dược phẩm Hải Phòng', '0987654325', 'info@haiphongpharm.com', 'Hải Phòng', '0123456785');

-- Dữ liệu mẫu cho bảng medicine_groups
INSERT INTO medicine_groups (code, name, description)
VALUES
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

-- Cập nhật phân cấp nhóm thuốc
UPDATE medicine_groups SET parent_code = 'ANT' WHERE code = 'ANTV';
UPDATE medicine_groups SET parent_code = 'ANT' WHERE code = 'ANTF';

-- Dữ liệu mẫu cho bảng unit_types
INSERT INTO unit_types (name, description)
VALUES
('Viên', 'Đơn vị viên thuốc'),
('Vỉ', 'Đơn vị vỉ thuốc'),
('Ống', 'Đơn vị ống thuốc'),
('Gói', 'Đơn vị gói thuốc'),
('Lọ', 'Đơn vị lọ thuốc'),
('Hộp', 'Đơn vị hộp thuốc'),
('Tuýp', 'Đơn vị tuýp thuốc'),
('Chai', 'Đơn vị chai thuốc'),
('Miếng', 'Đơn vị miếng dán'),
('Bình xịt', 'Đơn vị bình xịt'),
('Bơm tiêm', 'Đơn vị bơm tiêm');

-- Dữ liệu mẫu cho bảng unit_conversions
INSERT INTO unit_conversions (from_unit_id, to_unit_id, ratio, medicine_code)
VALUES
(2, 1, 10.0, 'PARA'), -- 1 vỉ = 10 viên Paracetamol
(6, 2, 3.0, 'PARA'), -- 1 hộp = 3 vỉ Paracetamol
(6, 1, 30.0, 'PARA'); -- 1 hộp = 30 viên Paracetamol

-- Dữ liệu mẫu cho bảng customers
INSERT INTO customers (phone, fullname, gender, email, points, customer_type)
VALUES
('0901234567', 'Nguyễn Văn A', 'male', 'nguyenvana@example.com', 100, 'normal'),
('0901234568', 'Trần Thị B', 'female', 'tranthib@example.com', 200, 'vip'),
('0901234569', 'Lê Văn C', 'male', 'levanc@example.com', 50, 'normal'),
('0901234570', 'Phạm Thị D', 'female', 'phamthid@example.com', 300, 'vip'),
('0901234571', 'Hoàng Văn E', 'male', 'hoangvane@example.com', 80, 'normal');

-- Dữ liệu mẫu cho bảng medicines
INSERT INTO medicines (code, name, generic_name, base_unit_id, retail_unit_id, base_price, retail_price, wholesale_price, image_url, description, ingredients, usage_guide, side_effects, group_code, barcode, manufacturer, is_prescription)
VALUES
('PARA', 'Paracetamol 500mg', 'Paracetamol', 1, 2, 3000, 5000, 4500, 'https://cdn.medigoapp.com/product/paracetamol_500mg_dp_thanh_nam_2_942b8959b9.jpg', 'Giảm đau, hạ sốt.', 'Paracetamol 500mg', 'Uống sau khi ăn. Người lớn 1-2 viên/lần, 3-4 lần/ngày', 'Buồn nôn, đau bụng, dị ứng', 'ANL', '8934563201234', 'Dược phẩm Hà Nội', 0),
('IBUP', 'Ibuprofen 400mg', 'Ibuprofen', 1, 2, 4000, 7000, 6500, 'https://cdn.tgdd.vn/Products/Images/10023/243357/ibumed-400mg-h-100vthumb01.j-600x600.jpg', 'Giảm đau, chống viêm.', 'Ibuprofen 400mg', 'Uống sau khi ăn. Người lớn 1 viên/lần, 3 lần/ngày', 'Đau dạ dày, khó tiêu, chóng mặt', 'ANL', '8934563201235', 'Dược phẩm Sài Gòn', 0),
('AMOX', 'Amoxicillin 500mg', 'Amoxicillin', 1, 6, 5000, 10000, 9000, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRa0gbftVQ-T-QYKMFiLhbLdnErggxe0xR8GA&s', 'Kháng sinh phổ rộng.', 'Amoxicillin 500mg', 'Uống trước hoặc sau khi ăn. Người lớn 1 viên/lần, 3 lần/ngày trong 5-7 ngày', 'Tiêu chảy, nổi mẩn, nôn', 'ANT', '8934563201236', 'Dược phẩm Việt Nam', 1),
('AZIT', 'Azithromycin 250mg', 'Azithromycin', 1, 2, 8000, 15000, 13000, 'https://cdn.thegioididong.com/Products/Images/10026/153220/azicine-stada-250mg-mac-dinh-2.jpg', 'Kháng sinh nhóm macrolid.', 'Azithromycin 250mg', 'Uống 1 giờ trước hoặc 2 giờ sau bữa ăn', 'Buồn nôn, đau bụng, tiêu chảy', 'ANT', '8934563201237', 'Dược phẩm Đông Dược', 1),
('CIPR', 'Ciprofloxacin 500mg', 'Ciprofloxacin', 1, 2, 9000, 12000, 11000, 'https://cdnv2.tgdd.vn/mwg-static/ankhang/Products/Images/10026/247688/ciprofloxacin-500mg-stada-1-638642532549014656.jpg', 'Kháng sinh nhóm quinolon.', 'Ciprofloxacin 500mg', 'Uống với nhiều nước, tránh đồ uống có cafein', 'Buồn nôn, tiêu chảy, chóng mặt', 'ANT', '8934563201238', 'Dược phẩm Tây Nam', 1);

-- Dữ liệu mẫu cho bảng medicine_price_history
INSERT INTO medicine_price_history (medicine_code, base_price, retail_price, wholesale_price, effective_date, reason)
VALUES
('PARA', 2800, 4800, 4300, '2024-01-01', 'Giá ban đầu'),
('PARA', 3000, 5000, 4500, '2024-03-15', 'Điều chỉnh theo thị trường'),
('IBUP', 3800, 6800, 6200, '2024-01-01', 'Giá ban đầu'),
('IBUP', 4000, 7000, 6500, '2024-02-10', 'Điều chỉnh theo thị trường');
