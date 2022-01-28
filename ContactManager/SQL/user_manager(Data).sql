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

 Date: 28/01/2022 17:05:53
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
) ENGINE = InnoDB AUTO_INCREMENT = 76 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of contact
-- ----------------------------
INSERT INTO `contact` VALUES (0, 'dfg', 'dsfg', 'dfg', '2004-01-26 00:00:00', 'dfgdfg', 29);
INSERT INTO `contact` VALUES (57, 'dfg', NULL, 'dfgss@sds', '2004-01-24 00:00:00', 'dfgdfg', 29);
INSERT INTO `contact` VALUES (58, 'dfg', NULL, 'dfgss@sdsas', '2004-01-24 00:00:00', 'dfgdfg', 29);
INSERT INTO `contact` VALUES (59, 'dfg', NULL, 'dfgss@sdsasvcv', '2004-01-24 00:00:00', 'dfgdfg', 29);
INSERT INTO `contact` VALUES (60, 'dfg', NULL, 'dfgss@sdsasvc', '2004-01-24 00:00:00', 'dfgdfg', 29);
INSERT INTO `contact` VALUES (74, 'dfg', NULL, 'dfgss@sdsasvc.com', '2004-01-24 00:00:00', 'dfgdfg', 21);
INSERT INTO `contact` VALUES (75, 'dfg', NULL, 'dfgss@sdsasvcs.sd', '2004-01-24 00:00:00', 'dfgdfg', 39);

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `description` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `name` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Dynamic;

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
) ENGINE = InnoDB AUTO_INCREMENT = 40 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES (21, 'Jason', 'Watmore', 'jason', '$2a$08$ZLWExX0Hbxd0DsoVShCtSewKokOzXmpma51QRFPYN59RiviDTk4I.', 'yartiles@gmail.coas');
INSERT INTO `user` VALUES (22, 'Jason', 'Watmore', 'jasonsds', '$2a$08$jVvhTSzx.biODjITNoVDmup54u85TJ.bxf8ax5DOiJ8dEqEf1kviG', 'yartiles@gmail.coasd');
INSERT INTO `user` VALUES (23, 'Jason', 'Watmore', 'abascal', '$2a$08$LrS2HJvCAXrzs8aYkz7zV.1Q0VGsibHneHZNZmFER5dqXcak7lzsm', 'yartiles@gmail.com');
INSERT INTO `user` VALUES (29, 'Jason', 'Watmore', 'string', '$2a$08$uCiEskTUD3xkpC0nUJTpJOX9dp1Jx.OsAMjES4Mbyn1uSeYkiw8Ny', 'arletisabascal1@gmail.comp');
INSERT INTO `user` VALUES (30, 'pepepepepe', 'string', 'arletisabascal', '$2a$08$yGTow16Qmm80QsOydltFzudAQh5tjBuqXSdYPu40G3hB6Xip2QJpq', 'string@sdsd.com');
INSERT INTO `user` VALUES (31, 'Jason', 'Watmore', 'arletis', '$2a$08$skliLV2SXunjd3GvmOcDfOUtCrOlTAJ8VnjR7Po9kqYUy16p28EzW', 'arletisabascal@gmail.comp');
INSERT INTO `user` VALUES (32, 'Jason', 'Watmore', 'arletisss', '$2a$08$2oFghj5RUsO/c4L1PUDHj.EoyMnw28tTmQqIdevLQKvUqGhlwpRbq', 'arletisabascal@gmail.compsd');
INSERT INTO `user` VALUES (33, 'Jason', 'Watmore', 'arletisssad', '$2a$08$KEsg2FKCkDAbJQHlHtu8guOsXdeohqEI.ooIsKXXLk1FFwLbtDJFy', 'arletisabascal@gmail.compsda');
INSERT INTO `user` VALUES (34, 'Jason', 'Watmore', 'arletisssado', '$2a$08$7P0ok/kw.fkJEv2cC1p5NenygQwe33Wu3JSXHtw9f5pbSetL43F9y', 'arletisabascal@gmail.compsdap');
INSERT INTO `user` VALUES (39, 'Yuniet', 'Artiles', 'yartiles', '$2a$08$14r5Q8xrx20GappSY9FLleEJz1oi7i4dmDtJbZsSpHLmgCDmpUKMy', 'yartiles161195@gmail.com');

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
  CONSTRAINT `fk_user_user_role_1` FOREIGN KEY (`UserId`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_role_user_role_1` FOREIGN KEY (`RoleId`) REFERENCES `role` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 11 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of userrole
-- ----------------------------
INSERT INTO `userrole` VALUES (4, 30, 1);
INSERT INTO `userrole` VALUES (5, 39, 3);
INSERT INTO `userrole` VALUES (6, 39, 4);
INSERT INTO `userrole` VALUES (7, 39, 5);
INSERT INTO `userrole` VALUES (8, 31, 1);
INSERT INTO `userrole` VALUES (9, 31, 3);
INSERT INTO `userrole` VALUES (10, 31, 4);

SET FOREIGN_KEY_CHECKS = 1;
