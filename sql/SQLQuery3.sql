UPDATE Predmeti
SET Broj_Studenata = (
    SELECT COUNT(DISTINCT STUDENT_ID) 
    FROM UpisaniPredmeti 
    WHERE Predmeti.Id = UpisaniPredmeti.PREDMET_ID
);