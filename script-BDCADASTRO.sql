/* CRIA��O DO BANCO DE DADOS */
CREATE DATABASE BDCADASTRO;

/* ABRIR O BANCO DE DADOS */
USE BDCADASTRO;

/* CRIA��O DA TABELA PRODUTO */
CREATE TABLE PRODUTO (
	ID INT NOT NULL PRIMARY KEY IDENTITY,
	NOME VARCHAR(30) NOT NULL
);
