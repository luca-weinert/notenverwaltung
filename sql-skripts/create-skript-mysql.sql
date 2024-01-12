-- Drop tables if they exist
DROP TABLE IF EXISTS Performance;
DROP TABLE IF EXISTS GradeResolution;
DROP TABLE IF EXISTS GradeKeys;
DROP TABLE IF EXISTS Grades;
DROP TABLE IF EXISTS GradeTypes;
DROP TABLE IF EXISTS Subjects;
DROP TABLE IF EXISTS Courses;
DROP TABLE IF EXISTS EducationalPath;
DROP TABLE IF EXISTS Students;
DROP TABLE IF EXISTS Teachers;
DROP TABLE IF EXISTS Users;

-- Create Users table
CREATE TABLE Users (
    UserID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    Birthdate VARCHAR(255)
);

-- Create Teachers table
CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY AUTO_INCREMENT,
    UserID INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Create Students table
CREATE TABLE Students (
    StudentID INT PRIMARY KEY AUTO_INCREMENT,
    UserID INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Create EducationalPath table
CREATE TABLE EducationalPath (
    EducationalPathID INT PRIMARY KEY AUTO_INCREMENT,
    Description VARCHAR(255)
);

-- Create Courses table
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY AUTO_INCREMENT,
    EducationalPathID INT,
    Description VARCHAR(255),
    Year INT,
    FOREIGN KEY (EducationalPathID) REFERENCES EducationalPath(EducationalPathID)
);

-- Create Subjects table
CREATE TABLE Subjects (
    SubjectID INT PRIMARY KEY AUTO_INCREMENT,
    Description VARCHAR(255)
);

-- Create GradeTypes table
CREATE TABLE GradeTypes (
    GradeTypeID INT PRIMARY KEY AUTO_INCREMENT,
    Description VARCHAR(255)
);

-- Create Grades table
CREATE TABLE Grades (
    GradeID INT PRIMARY KEY AUTO_INCREMENT,
    Percentage DECIMAL(5,2) -- Adjust precision and scale as needed
);

-- Create GradeKeys table
CREATE TABLE GradeKeys (
    GradeKeyID INT PRIMARY KEY AUTO_INCREMENT,
    Description VARCHAR(255),
    Institution VARCHAR(255) -- Adjust the length based on your needs
);

-- Create GradeResolution table
CREATE TABLE GradeResolution (
    GradeResolutionID INT PRIMARY KEY AUTO_INCREMENT,
    GradeKeyID INT,
    Percentage FLOAT,
    DecimalPlaces INT,
    Description VARCHAR(255),
    FOREIGN KEY (GradeKeyID) REFERENCES GradeKeys(GradeKeyID)
);

-- Create Performance table
CREATE TABLE Performance (
    PerformanceID INT PRIMARY KEY AUTO_INCREMENT,
    Date DATE,
    SubjectID INT,
    CourseID INT,
    GradeID INT,
    GradeTypeID INT,
    TeacherID INT,
    StudentID INT,
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    FOREIGN KEY (GradeID) REFERENCES Grades(GradeID),
    FOREIGN KEY (GradeTypeID) REFERENCES GradeTypes(GradeTypeID),
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
);
