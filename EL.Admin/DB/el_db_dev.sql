/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50714
Source Host           : 127.0.0.1:3306
Source Database       : el_db_dev

Target Server Type    : MYSQL
Target Server Version : 50714
File Encoding         : 65001

Date: 2019-12-30 17:19:44
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for sys_accounts
-- ----------------------------
DROP TABLE IF EXISTS `sys_accounts`;
CREATE TABLE `sys_accounts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Account` varchar(255) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `RoleId` int(11) NOT NULL,
  `Sort` int(11) DEFAULT NULL,
  `Enabled` bit(1) NOT NULL,
  `EditTime` datetime DEFAULT NULL,
  `Editor` varchar(255) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `Creater` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='账号表';

-- ----------------------------
-- Table structure for sys_logs
-- ----------------------------
DROP TABLE IF EXISTS `sys_logs`;
CREATE TABLE `sys_logs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Message` varchar(255) DEFAULT NULL,
  `Exception` text,
  `StackTrace` text,
  `CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='日志表';

-- ----------------------------
-- Table structure for sys_menus
-- ----------------------------
DROP TABLE IF EXISTS `sys_menus`;
CREATE TABLE `sys_menus` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ParentId` int(11) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Path` varchar(255) DEFAULT NULL,
  `Code` varchar(255) DEFAULT NULL,
  `Icon` varchar(255) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `Enabled` bit(1) NOT NULL,
  `EditTime` datetime DEFAULT NULL,
  `Editor` varchar(255) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `Creater` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COMMENT='菜单表';

-- ----------------------------
-- Table structure for sys_roles
-- ----------------------------
DROP TABLE IF EXISTS `sys_roles`;
CREATE TABLE `sys_roles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `Enabled` bit(1) NOT NULL,
  `EditTime` datetime DEFAULT NULL,
  `Editor` varchar(255) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `Creater` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='角色表';

-- ----------------------------
-- Table structure for sys_role_menus
-- ----------------------------
DROP TABLE IF EXISTS `sys_role_menus`;
CREATE TABLE `sys_role_menus` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` int(11) DEFAULT NULL,
  `MenuId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8 COMMENT='角色菜单表';
