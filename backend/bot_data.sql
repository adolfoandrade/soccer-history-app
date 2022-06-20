/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [Id]
      ,[CompetitionId]
	  ,[MatchNumber]
      ,[QuantityEvents]
      ,CASE 
			WHEN Odd = 5 THEN 'Goals Over/Under'
			WHEN Odd = 8 THEN 'Both Teams Score'
			WHEN Odd = 45 THEN 'Corners Over/Under'
			ELSE 'Not found'
		END AS Odd
      ,[OverUnder]
      ,[Quantity]
  FROM [dbo].[DataSentToBot]

 -- ALTER TABLE [dbo].[DataSentToBot] ADD MatchNumber INT NOT NULL

--DELETE FROM [dbo].[DataSentToBot]

 SELECT [Id]
      ,[CompetitionId]
	  ,[MatchNumber]
      ,[QuantityEvents]
      ,CASE 
			WHEN Odd = 5 THEN 'Goals Over/Under'
			WHEN Odd = 8 THEN 'Both Teams Score'
			WHEN Odd = 45 THEN 'Corners Over/Under'
			ELSE 'Not found'
		END AS Odd
      ,[OverUnder]
      ,[Quantity]
  FROM [dbo].[DataSentToBot]
  WHERE Quantity >= 3 AND Quantity <= 9 AND OverUnder > 1 AND OverUnder < 2 AND Odd = 5 AND CompetitionId = 260
  ORDER BY MatchNumber DESC


 SELECT [Id]
      ,[CompetitionId]
	  ,[MatchNumber]
      ,[QuantityEvents]
      ,CASE 
			WHEN Odd = 5 THEN 'Goals Over/Under'
			WHEN Odd = 8 THEN 'Both Teams Score'
			WHEN Odd = 45 THEN 'Corners Over/Under'
			ELSE 'Not found'
		END AS Odd
      ,[OverUnder]
      ,[Quantity]
  FROM [dbo].[DataSentToBot]
  WHERE Quantity >= 1 AND Quantity < 9 AND CompetitionId = 260 AND Odd = 8
  ORDER BY MatchNumber DESC

  SELECT [Id]
      ,[CompetitionId]
	  ,[MatchNumber]
      ,[QuantityEvents]
      ,CASE 
			WHEN Odd = 5 THEN 'Goals Over/Under'
			WHEN Odd = 8 THEN 'Both Teams Score'
			WHEN Odd = 45 THEN 'Corners Over/Under'
			ELSE 'Not found'
		END AS Odd
      ,[OverUnder]
      ,[Quantity]
  FROM [dbo].[DataSentToBot]
  WHERE CompetitionId = 237 AND MatchNumber = 13
  ORDER BY MatchNumber DESC