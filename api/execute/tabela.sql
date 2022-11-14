USE [master]
GO

CREATE DATABASE TESTE
GO

USE Teste
GO

CREATE TABLE dbo.cliente
(
    Id integer PRIMARY KEY,
    Nome varchar(50) 
);

INSERT INTO  cliente(Id,Nome) VALUES(1,'TESTE');