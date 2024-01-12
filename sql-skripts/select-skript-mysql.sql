-- name eines Lehres aius der Datenbank laden
SELECT Teachers.UserID, Users.FirstName, Users.LastName
FROM Teachers
INNER JOIN Users ON Teachers.UserID=Users.UserID;

-- auslesen einer Leistung für einen bestimmten Schüler