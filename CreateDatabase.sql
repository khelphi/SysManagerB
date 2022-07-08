
CREATE SCHEMA IF NOT EXISTS sysmanager;
USE sysmanager;

-- ---------------------------
-- tabela de usu�rios
-- ---------------------------
CREATE TABLE IF NOT EXISTS sysmanager.user
(
`id` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'Identificador unico do registro',
`userName` varchar(50) NOT NULL COMMENT 'nome do usu�rio',
`email` varchar(100) NOT NULL COMMENT 'email do usu�rio',
`password` varchar(50) NOT NULL COMMENT 'senha do usu�rio',
`active` bit NOT NULL DEFAULT false COMMENT 'indicador se o usu�rio esta ativo ou inativo',
PRIMARY KEY(`id`)
);

-- ---------------------------
-- tabela de produtos
-- ---------------------------
CREATE TABLE IF NOT EXISTS sysmanager.product
(
`id` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'Identificador unico do registro',
`name` varchar(50) NOT NULL COMMENT 'nome/Descri��o do produto',
`productType` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'tipo do produto',
`productCategory` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'categoria do produto',
`productUnity` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'unidade de medida do produto',
`costPrice` decimal DEFAULT 0  COMMENT 'pre�o de custo do produto',
`percentage` decimal DEFAULT 0  COMMENT 'percentual de venda do produto',
`price` decimal DEFAULT 0  COMMENT 'pre�o final do produto',
`active` bit NOT NULL DEFAULT false COMMENT 'indicador se o usu�rio esta ativo ou inativo',
PRIMARY KEY(`id`)
);


-- -----------------------------------------------------
-- Table `sysManager`.`productType`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS sysManager.productType (
  `id` CHAR(36) not null default 'uuid()' comment 'Identificador do registro',
  `name` varchar(100) not null comment 'Nome do Tipo de produto',
  `active` bit NOT NULL default false comment 'Ativo ou inativo',
  `createdDate` datetime not null default NOW() comment 'data de cria��o do registro',
  `updatedDate` datetime null comment 'data de atualiza��o do registro',
  PRIMARY KEY (`id`)
  );

-- -----------------------------------------------------
-- Table `sysManager`.`unity`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS sysManager.unity (
  `id` CHAR(36) not null default 'uuid()' comment 'Identificador do registro',
  `name` varchar(100) not null comment 'Nome do Unidade de produto',
  `active` NOT NULL default false comment 'Ativo ou inativo',
  `createdDate` datetime not null default NOW() comment 'data de cria��o do registro',
  `updatedDate` datetime null  comment 'data de atualiza��o do registro',
  PRIMARY KEY (`id`)
  );

-- -----------------------------------------------------
-- Table `sysManager`.`category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS sysManager.category (
  `id` CHAR(36) not null default 'uuid()' comment 'Identificador do registro',
  `name` varchar(100) not null comment 'Nome do categoria de produto',
  `parentId` varchar(50)  null comment 'Identificador do Tipo de produto pai',  
  `active` bit NOT NULL default false comment 'Ativo ou inativo',
  `createdDate` datetime not null default NOW() comment 'data de cria��o do registro',
  `updatedDate` datetime null comment 'data de atualiza��o do registro',
  PRIMARY KEY (`id`)
  )