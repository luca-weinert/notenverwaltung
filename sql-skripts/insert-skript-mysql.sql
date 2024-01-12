-- anlegen von Benutzern
INSERT INTO Users(FirstName, LastName, Birthdate)
VALUES ("Luca", "Weinert", "1061282810"), ("Max", "Mustermann", "1061282810");

-- anlegen Schüler mit referenz auf einen Benutzer (UserID)
INSERT INTO Students(UserID)
VALUES (1);

-- anlegen Lehrer mit referenz auf einen Benutzer (UserID)
INSERT INTO Teachers(UserID)
VALUES (2);

-- anlegen von Bildungsgängen z.B. FAE oder Doppelqualifikation / Abendschule
INSERT INTO EducationalPath(Description)
VALUES ("FAE"), ("DQ");

-- anlegen von Kursen z.B. IA122 oder DQ122 ...
-- mit Referenz auf einen Bildungsgang
INSERT INTO Courses(EducationalPathID, Description, Year)
VALUES (1, "IA122", "2022"), (2, "DQ122", "2022");

-- anlegen von Fäschern
INSERT INTO Subjects(Description)
VALUES ("Deutsch"), ("SDM"), ("GIT"), ("EVP"), ("Mathe");

-- anlegen von Notentypen
INSERT INTO GradeTypes(Description)
VALUES ("Mündlich"), ("Schriftlich"), ("Klausur");

-- anlegen von Noten
INSERT INTO Grades(Percentage)
VALUES (0.1), (0.9), (0.4), (0.6);

-- anlegen der verschiedenen Notenschlüssel. z.B. IHK Notenschlüssel
INSERT INTO GradeKeys(Description, Institution)
VALUES ("IHK Notenschlüssel", "IHK-Bonn"), ("Abitur", "NRW");

-- anlegen Notenauflösung zwischen prozentzahl und notenschlüssel
-- z.B. 0.7 prozent beim IHK Notenschlüssel entspricht einer 3
INSERT INTO GradeResolution(GradeKeyID, Percentage, DecimalPlaces, Description)
VALUES (1, 0.1, 6, "sechs"), (1, 0.9, 1, "eins");

-- anlegen einer neuen Leistung mit allen ihren Eigenschaften
INSERT INTO Performance(Date, SubjectID, CourseID, GradeID, GradeTypeID, TeacherID, StudentID)
VALUES ("2023-02-02", 1, 1, 2, 2, 1, 1)