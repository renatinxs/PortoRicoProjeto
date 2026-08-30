create database DbPortoRico;
use DbPortoRico;

create table tbCliente(
Id int auto_increment primary key,
Nome Varchar(50) not null,
Nascimento DateTime not null,
Sexo char(1) not null,
CPF Varchar(11) not null,
Telefone Varchar(15) not null,
Email Varchar(50) not null,
Senha varchar(10) not null,
ConfirmacaoSenha Varchar(8) not null,
Situacao char(1) not null);