INSERT INTO [dbo].[Voiture]
           ([NumChassis]
           ,[Nom]
           ,[Puissance]
           ,[NbPortes]
           ,[NbVitesse]
           ,[Cylindres]
           ,[Couleur]
           ,[Kilometrage]
           ,[Année]
           ,[DateCtrlTech]
           ,[CarnetEntretien]
           ,[TypeTransaction]
           ,[Prix]
           ,[Reduction]
           ,[Photo]
           ,[DateArrive]
           ,[Etat]
           ,[Transmission]
           ,[Carburant]
           ,[Carrosserie]
           ,[Marque])
     VALUES
           (<NumChassis, varchar(30),>
           ,<Nom, varchar(30),>
           ,<Puissance, varchar(30),>
           ,<NbPortes, int,>
           ,<NbVitesse, int,>
           ,<Cylindres, int,>
           ,<Couleur, varchar(60),>
           ,<Kilometrage, decimal(18,0),>
           ,<Année, date,>
           ,<DateCtrlTech, date,>
           ,<CarnetEntretien, varchar(3),>
           ,<TypeTransaction, int,>
           ,<Prix, decimal(18,0),>
           ,<Reduction, int,>
           ,<Photo, varchar(30),>
           ,<DateArrive, date,>
           ,<Etat, int,>
           ,<Transmission, int,>
           ,<Carburant, int,>
           ,<Carrosserie, int,>
           ,<Marque, int,>)