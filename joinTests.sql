SELECT * FROM tblClient C
INNER JOIN tblClientProducts CP ON C.IdNr=CP.ClientIdNr
INNER JOIN tblProducts P ON CP.ProductCode = P.ProductCode
INNER JOIN tblSystemComponents SC ON P.ProductCode = SC.ProductCode
INNER JOIN tblConfiguration Conf ON Conf.ComponentCode = SC.ComponentCode
INNER JOIN tblClientCompConfiguration CCC ON CCC.ConfigCode = Conf.ConfigurationCode
WHERE CCC.ClientId = C.IdNr;

SELECT * FROM tblClient C
INNER JOIN tblAddress A ON C.AddressId = A.pAddressId
INNER JOIN tblContact CT ON C.ContactId = CT.pContactId
INNER JOIN tblPaymentDetails PD ON C.IdNr = PD.ClientIdNr;

SELECT * FROM tblTechnicians T
INNER JOIN tblAddress A ON T.AddressId = A.AddressId
INNER JOIN tblContact C ON T.ContactId = C.ContactId

SELECT * FROM tblVendors V
INNER JOIN tblAddress A ON V.AddressId = A.pAddressId
INNER JOIN tblContact C ON V.ContactId = C.pContactId