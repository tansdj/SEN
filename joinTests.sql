SELECT * FROM tblClient C
INNER JOIN tblClientProducts CP ON C.IdNr=CP.ClientIdNr
INNER JOIN tblProducts P ON CP.ProductCode = P.ProductCode
INNER JOIN tblSystemComponents SC ON P.ProductCode = SC.ProductCode
INNER JOIN tblConfiguration Conf ON Conf.ComponentCode = SC.ComponentCode
INNER JOIN tblClientCompConfiguration CCC ON CCC.ConfigCode = Conf.ConfigurationCode
WHERE CCC.ClientId = C.IdNr;