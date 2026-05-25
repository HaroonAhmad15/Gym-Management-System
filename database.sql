
-- ============================================================

CREATE DATABASE IF NOT EXISTS GymDB;
USE GymDB;

CREATE TABLE IF NOT EXISTS Users (
    UserID   INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50)  NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,
    Role     VARCHAR(20)  DEFAULT 'Admin'
);

CREATE TABLE IF NOT EXISTS Members (
    MemberID INT AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Phone    VARCHAR(20),
    Email    VARCHAR(100),
    Gender   VARCHAR(10),
    JoinDate DATE         DEFAULT (CURDATE()),
    IsActive BOOLEAN      DEFAULT TRUE
);

CREATE TABLE IF NOT EXISTS MembershipPlans (
    PlanID       INT AUTO_INCREMENT PRIMARY KEY,
    PlanName     VARCHAR(50)    NOT NULL,
    DurationDays INT            NOT NULL,
    Price        DECIMAL(10,2)  NOT NULL
);

CREATE TABLE IF NOT EXISTS MemberMemberships (
    SubID     INT AUTO_INCREMENT PRIMARY KEY,
    MemberID  INT         NOT NULL,
    PlanID    INT         NOT NULL,
    StartDate DATE        NOT NULL,
    EndDate   DATE        NOT NULL,
    Status    VARCHAR(20) DEFAULT 'Active',
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
    FOREIGN KEY (PlanID)   REFERENCES MembershipPlans(PlanID)
);

CREATE TABLE IF NOT EXISTS Payments (
    PaymentID     INT AUTO_INCREMENT PRIMARY KEY,
    MemberID      INT           NOT NULL,
    Amount        DECIMAL(10,2) NOT NULL,
    PaymentDate   DATETIME      DEFAULT NOW(),
    PaymentMethod VARCHAR(20)   DEFAULT 'Cash',
    Notes         VARCHAR(255),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);

CREATE TABLE IF NOT EXISTS Attendance (
    AttendanceID INT AUTO_INCREMENT PRIMARY KEY,
    MemberID     INT      NOT NULL,
    CheckInTime  DATETIME DEFAULT NOW(),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);

CREATE TABLE IF NOT EXISTS Trainers (
    TrainerID  INT AUTO_INCREMENT PRIMARY KEY,
    FullName   VARCHAR(100)   NOT NULL,
    Phone      VARCHAR(20),
    Specialty  VARCHAR(100),
    Salary     DECIMAL(10,2)  DEFAULT 0.00,
    IsActive   BOOLEAN        DEFAULT TRUE
);

INSERT INTO Users (Username, Password, Role)
VALUES ('admin', 'admin123', 'Admin');

INSERT INTO MembershipPlans (PlanName, DurationDays, Price) VALUES
('Monthly',   30,  2500.00),
('Quarterly', 90,  6500.00),
('Yearly',    365, 20000.00);

INSERT INTO Members (FullName, Phone, Email, Gender, JoinDate, IsActive) VALUES
('Ali Ahmed',    '03001234567', 'ali@gmail.com',    'Male',   '2025-01-10', 1),
('Sara Khan',    '03121234567', 'sara@gmail.com',   'Female', '2025-02-15', 1),
('Usman Malik',  '03331234567', 'usman@gmail.com',  'Male',   '2025-03-20', 1);

INSERT INTO Trainers (FullName, Phone, Specialty, Salary, IsActive) VALUES
('Ahmad Raza', '03451234567', 'Weight Training', 25000.00, 1);
