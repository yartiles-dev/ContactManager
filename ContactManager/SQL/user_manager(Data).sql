/*
 Navicat Premium Data Transfer

 Source Server         : mysql
 Source Server Type    : MySQL
 Source Server Version : 100410
 Source Host           : localhost:3306
 Source Schema         : user_manager

 Target Server Type    : MySQL
 Target Server Version : 100410
 File Encoding         : 65001

 Date: 28/01/2022 19:47:41
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for contact
-- ----------------------------
DROP TABLE IF EXISTS `contact`;
CREATE TABLE `contact`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `firstName` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `lastName` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `email` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `dateOfBirth` datetime NOT NULL,
  `phone` varchar(20) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `OwnerNavigationId` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `fk_contact_user_1`(`OwnerNavigationId`) USING BTREE,
  CONSTRAINT `fk_contact_user_1` FOREIGN KEY (`OwnerNavigationId`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 77 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of contact
-- ----------------------------

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `description` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `name` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES (1, NULL, 'Client');
INSERT INTO `role` VALUES (3, NULL, 'Manager');
INSERT INTO `role` VALUES (4, NULL, 'Project Administrator');
INSERT INTO `role` VALUES (5, NULL, 'Administrator');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `firstName` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `lastName` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `username` varchar(60) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `password` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `email` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `email`(`email`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 57 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES (55, 'Yuniet', 'Artiles', 'yartiles', '$2a$08$U7Q0tQhrrdw3EZYf3f/rn.JNBa4Pu8CxPMOEnSJqK6CdSX7uxzJFS', 'yartiles161195@gmail.com');
INSERT INTO `user` VALUES (56, 'Arletis', 'Abascal', 'arletis', '$2a$08$CZwnM0wZ7XIn2JATJszmV.TMMCp2hBu05G9s7QNBcYwdjBAqBLYdW', 'aabascal@gmail.com');

-- ----------------------------
-- Table structure for userrole
-- ----------------------------
DROP TABLE IF EXISTS `userrole`;
CREATE TABLE `userrole`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `RoleId` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `fk_role_user_role_1`(`RoleId`) USING BTREE,
  INDEX `fk_user_user_role_1`(`UserId`) USING BTREE,
  CONSTRAINT `fk_role_user_role_1` FOREIGN KEY (`RoleId`) REFERENCES `role` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_user_user_role_1` FOREIGN KEY (`UserId`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 19 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of userrole
-- ----------------------------
INSERT INTO `userrole` VALUES (11, 55, 1);
INSERT INTO `userrole` VALUES (12, 56, 1);
INSERT INTO `userrole` VALUES (14, 55, 3);
INSERT INTO `userrole` VALUES (15, 55, 4);
INSERT INTO `userrole` VALUES (16, 55, 5);
INSERT INTO `userrole` VALUES (17, 56, 3);
INSERT INTO `userrole` VALUES (18, 56, 4);

SET FOREIGN_KEY_CHECKS = 1;
