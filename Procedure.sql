CREATE PROCEDURE [dbo].[GetClient]
	@email varchar(30)
AS
BEGIN
	SELECT * fROM Client WHERE EMail = @email
END

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

CREATE PROCEDURE [dbo].[AddGmailClient]
	@email varchar(50)
AS

BEGIN
	IF((SELECT EMail FROM CLIENT WHERE EMail = @email) IS NULL) 
	begin
		INSERT INTO dbo.CLIENT 
				(	
					[Email]
					)
		 VALUES (@email);
	 end
END

CREATE PROCEDURE [dbo].[GetVehicule]
	@id int
AS
BEGIN
	Select IdVoiture, NumChassis, Voiture.Nom as NomVoit,Puissance,NbPortes,NbVitesse,Cylindres,
        Couleur,Kilometrage,Annee,DateCtrlTech,CarnetEntretien,TypeTransaction,Prix,Reduction,Photo,DateArrive,
        
        Etat as IdEtat,Etat.Nom As NomEtat,
        Transmission As IdTransm,Transmission.Nom As NomTransm,
        Carburant As IdCarbu,Carburant.Nom As NomCarbu,
        Carrosserie As IdCarro,Carrosserie.Nom As NomCarro,
        Marque As IdMarque,Marque.Nom As NomMarque

        from Voiture
        join Etat on Etat = Etat.IdEtat
        Join Transmission on Transmission = Transmission.IdTransmission
        Join Carburant on Carburant = Carburant.IdCarburant
        Join Carrosserie on Carrosserie = Carrosserie.IdCarrosserie
        Join Marque on Marque = Marque.IdMarque

		where IdVoiture = @id;
END

CREATE PROCEDURE [dbo].[AddVehicule]
	@num varchar(50), @nom varchar(50), @puissance varchar(50),
	@nbPortes int, @nbVitesse int, @cylindres int, 
	@couleur varchar(50), @kilometrage decimal, @annee date, 
	@dateCtrlTech date, @carnetEntretien varchar(50), @typeTransaction int,
	@prix decimal, @reduction int, @photo varchar(50),
	@dateArrive date, @etat int, @transmission int, 
	@carburant int, @carrosserie int, @marque int
AS
DECLARE @UPnom varchar(50) = UPPER(@nom);
DECLARE @UPcarnetEntretien varchar(50) = UPPER(LEFT(@carnetEntretien,1))+SUBSTRING(@carnetEntretien,2,LEN(@carnetEntretien));
DECLARE @UPcouleur varchar(50) = UPPER(LEFT(@couleur,1))+SUBSTRING(@couleur,2,LEN(@couleur));

BEGIN
	IF((SELECT NumChassis FROM Voiture WHERE NumChassis = @num) IS NULL) 
	begin
		INSERT INTO [dbo].[Voiture]
     VALUES
           (@num,@nom,@puissance,@nbPortes,@nbVitesse,@cylindres,@UPcouleur,@kilometrage,@annee,@dateCtrlTech,
		   @UPcarnetEntretien,@typeTransaction,@prix,@reduction,@photo,@dateArrive,@etat,@transmission,
		   @carburant,@carrosserie,@marque)
	 end
END

