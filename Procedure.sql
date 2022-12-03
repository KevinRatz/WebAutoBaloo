CREATE PROCEDURE [dbo].[AddClient]
	@nom varchar(50),
	@prenom varchar(50),
	@adresse varchar(50),
	@tel varchar(50),
	@email varchar(50),
	@mdp varchar(50)
AS
DECLARE @UPnom varchar(50) = UPPER(LEFT(@nom,1))+SUBSTRING(@nom,2,LEN(@nom));
DECLARE @UPprenom varchar(50) = UPPER(LEFT(@prenom,1))+SUBSTRING(@prenom,2,LEN(@prenom));
DECLARE @UPadresse varchar(50) = UPPER(LEFT(@adresse,1))+SUBSTRING(@adresse,2,LEN(@adresse));

BEGIN
	IF((SELECT EMail FROM CLIENT WHERE EMail = @email) IS NULL) 
	begin
		INSERT INTO dbo.CLIENT 
				(	[Nom]
					,[Prenom]
					,[Adresse]
					,Tel
					,[Email]
					,[Password]
					)
		 VALUES (@UPnom,@UPprenom,@UPadresse,@tel,@email,ENCRYPTBYPASSPHRASE('tdi202', @mdp));
	 end
END

CREATE PROCEDURE [dbo].[ValidateUser]
      @Email VARCHAR(20),
      @Password VARCHAR(20)
AS
BEGIN
      SELECT EMail
      FROM Client 
	  WHERE EMail = @Email 
	  AND 
	  CONVERT(varchar(50),DECRYPTBYPASSPHRASE('tdi202',Password)) = @Password
     
    
END