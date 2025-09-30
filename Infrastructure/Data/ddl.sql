DROP DATABASE IF EXISTS practice;
CREATE DATABASE IF NOT EXISTS practice;
USE practice;

CREATE TABLE IF NOT EXISTS countries (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS regions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(60) NOT NULL,
    country_id INT NOT NULL,
    CONSTRAINT fk_region_country FOREIGN KEY (country_id) REFERENCES countries(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS cities (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    region_id INT NOT NULL,
    CONSTRAINT fk_city_region FOREIGN KEY (region_id) REFERENCES regions(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS companies (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(120) NOT NULL,
    -- el uk es united kingdom y el niu es el registro unico tributario
    uk_niun INT NOT NULL,
    address VARCHAR(80) NOT NULL,
    city_id INT NOT NULL,
    email VARCHAR(80) NOT NULL,
    CONSTRAINT fk_company_city FOREIGN KEY (city_id) REFERENCES cities(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS branches (
    id INT AUTO_INCREMENT PRIMARY KEY,
    number_comercial INT NOT NULL,
    address VARCHAR(80) NOT NULL,
    email VARCHAR(80) NOT NULL,
    contact_name VARCHAR(50) NOT NULL,
    phone VARCHAR(25) NOT NULL,
    city_id INT NOT NULL,
    company_id INT NOT NULL,
    CONSTRAINT fk_branch_city FOREIGN KEY (city_id) REFERENCES cities(id),
    CONSTRAINT fk_branch_company FOREIGN KEY (company_id) REFERENCES companies(id)
) ENGINE=INNODB;