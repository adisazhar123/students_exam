-- ----------------------------------------------------------------------------
-- MySQL Workbench Migration
-- Migrated Schemata: students
-- Source Schemata: students
-- Created: Mon Mar  5 01:57:16 2018
-- Workbench Version: 6.3.10
-- ----------------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------------------------------------------------------
-- Schema students
-- ----------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `students` ;
CREATE SCHEMA IF NOT EXISTS `students` ;

-- ----------------------------------------------------------------------------
-- Table students.student_answers
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `students`.`student_answers` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `ans` VARCHAR(256) NULL,
  PRIMARY KEY (`Id`));

-- ----------------------------------------------------------------------------
-- Table students.Table
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `students`.`Table` (
  `Id` INT NOT NULL,
  PRIMARY KEY (`Id`));

-- ----------------------------------------------------------------------------
-- Table students.soal_tes
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `students`.`soal_tes` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `ep_id` INT NULL,
  `question` VARCHAR(300) NULL,
  `ans1` VARCHAR(256) NULL,
  `ans2` VARCHAR(256) NULL,
  `ans3` VARCHAR(256) NULL,
  `rightans` VARCHAR(256) NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `FK_soal_tes_ToEP`
    FOREIGN KEY (`ep_id`)
    REFERENCES `students`.`exam_packets` (`ep_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table students.students
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `students`.`students` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(256) NULL,
  `department` VARCHAR(256) NULL,
  `faculty` VARCHAR(256) NULL,
  PRIMARY KEY (`Id`));

-- ----------------------------------------------------------------------------
-- Table students.admins
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `students`.`admins` (
  `admin_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(256) NULL,
  `username` VARCHAR(20) NULL,
  `password` VARCHAR(50) NULL,
  `last_login` DATETIME(6) NULL,
  `is_on` TINYINT(1) NULL,
  PRIMARY KEY (`admin_id`));

-- ----------------------------------------------------------------------------
-- Table students.subjects
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `students`.`subjects` (
  `subjects_id` INT NOT NULL,
  `name` VARCHAR(100) NULL,
  `description` VARCHAR(256) NULL,
  PRIMARY KEY (`subjects_id`));

-- ----------------------------------------------------------------------------
-- Table students.exam_packets
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `students`.`exam_packets` (
  `ep_id` INT NOT NULL AUTO_INCREMENT,
  `subjects_id` INT NULL,
  `name` VARCHAR(100) NULL,
  `description` VARCHAR(256) NULL,
  PRIMARY KEY (`ep_id`));

-- ----------------------------------------------------------------------------
-- Table students.exam_info
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `students`.`exam_info` (
  `ep_id` INT NOT NULL,
  `start_date` DATE NULL,
  `start_time` TIME(6) NULL,
  `end_date` DATE NULL,
  `end_time` TIME(6) NULL,
  `duration` INT NULL);

-- ----------------------------------------------------------------------------
-- Table students.exam_packets_info
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `students`.`exam_packets_info` (
  `ep_id` INT NOT NULL,
  `start_date` DATE NULL,
  `start_time` TIME(6) NULL,
  `end_date` DATE NULL,
  `end_time` TIME(6) NULL,
  `duration` INT NULL);
SET FOREIGN_KEY_CHECKS = 1;
