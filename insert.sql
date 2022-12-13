INSERT INTO [dbo].[Voiture]
           ([NumChassis]
           ,[Nom]
           ,[Puissance]
           ,[NbPortes]
           ,[NbVitesse]
           ,[Cylindres]
           ,[Couleur]
           ,[Kilometrage]
           ,[Annee]
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
           ('1234567'
           ,'voiture vieille réduc'
           ,'92 kW (125 CH)'
           ,4
           ,5
           ,2
           ,'rouge'
           ,1000
           ,'3/10/2000'
           ,'3/10/2010'
           ,'Oui'
           --TypeTransaction 0 vente 1 location
           ,1
           ,600
           ,10
           ,'1.jpg'
           ,'3/10/1996'
           ,1
           ,2
           ,2
           ,2
           ,2)