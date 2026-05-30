-- Base de datos de prueba para CreacionesAmpis
CREATE DATABASE IF NOT EXISTS creacionesAmpis;
USE creacionesAmpis;

CREATE TABLE IF NOT EXISTS usuarios (
    Id            INT           AUTO_INCREMENT PRIMARY KEY,
    Nombre        VARCHAR(100)  NOT NULL,
    Email         VARCHAR(150)  NOT NULL UNIQUE,
    Contrasena    VARCHAR(255)  NOT NULL,
    Rol           VARCHAR(50)   NOT NULL DEFAULT 'usuario',
    Activo        TINYINT(1)    NOT NULL DEFAULT 1,
    FechaCreacion DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Registros de prueba
INSERT INTO usuarios (Nombre, Email, Contrasena, Rol, Activo, FechaCreacion) VALUES
('Admin Prueba', 'admin@ampis.com', 'Admin1234', 'admin',   1, NOW()),
('Usuario Uno',  'user1@ampis.com', 'Pass1234',  'usuario', 1, NOW()),
('Usuario Dos',  'user2@ampis.com', 'Pass5678',  'usuario', 0, NOW());
