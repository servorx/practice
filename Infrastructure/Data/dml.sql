-- Insertar países
INSERT INTO countries (name) VALUES ('Colombia'), ('Argentina'), ('Chile');

-- Insertar regiones
INSERT INTO regions (name, country_id) VALUES 
('Antioquia', 1),
('Buenos Aires', 2),
('Metropolitana', 3);

-- Insertar ciudades
INSERT INTO cities (name, region_id) VALUES 
('Medellín', 1),
('Buenos Aires', 2),
('Santiago', 3);

-- Insertar compañías
INSERT INTO companies (name, uk_niu, address, city_id, email) VALUES
('Tech Solutions', 123456, 'Cra 10 #20-30', 1, 'info@techsolutions.com'),
('Agro SA', 654321, 'Av. Corrientes 123', 2, 'contacto@agrosa.com'),
('Innovatech', 789012, 'Av. Providencia 456', 3, 'contact@innovatech.cl');

-- Insertar sucursales
INSERT INTO branches (number_comercial, address, email, contact_name, phone, city_id, company_id) VALUES
(101, 'Cra 11 #21-31', 'sucursal1@techsolutions.com', 'Juan Perez', '3001234567', 1, 1),
(201, 'Av. Callao 456', 'sucursal1@agrosa.com', 'Maria Gomez', '1134567890', 2, 2),
(301, 'Av. Apoquindo 789', 'sucursal1@innovatech.cl', 'Carlos Ruiz', '987654321', 3, 3);