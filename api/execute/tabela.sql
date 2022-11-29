USE [master]
GO

CREATE DATABASE Agendamento_db
GO

USE Agendamento_db
GO

CREATE TABLE dbo.cliente
(
    Id integer PRIMARY KEY,
    Nome varchar(50) 
);

INSERT INTO  cliente(Id,Nome) VALUES(1,'TESTE');