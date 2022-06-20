
SELECT ME.* FROM MatchEvents AS ME
INNER JOIN Events AS E ON E.Id = Me.EventId
INNER JOIN Matches AS M ON M.Id = E.MatchId
INNER JOIN Competitions AS C ON C.Id = M.CompetitionId
WHERE UPPER(ME.Type) = UPPER('Goal') AND C.Id = 237 AND UPPER(E.Status) = UPPER('Match Finished')

SELECT ME.* FROM MatchEvents AS ME
INNER JOIN Events AS E ON E.Id = Me.EventId
INNER JOIN Matches AS M ON M.Id = E.MatchId
INNER JOIN Competitions AS C ON C.Id = M.CompetitionId
WHERE UPPER(ME.Type) = UPPER('CARD') AND C.Id = 237 AND UPPER(E.Status) = UPPER('Match Finished')

SELECT DISTINCT M.* FROM MatchEvents AS ME
INNER JOIN Events AS E ON E.Id = ME.EventId
INNER JOIN Matches AS M ON M.Id = E.MatchId
INNER JOIN Competitions AS C ON C.Id = M.CompetitionId
WHERE C.Id = 237 AND UPPER(E.Status) = UPPER('Match Finished')


SELECT ME.* FROM MatchEvents AS ME
INNER JOIN Events AS E ON E.Id = Me.EventId
INNER JOIN Matches AS M ON M.Id = E.MatchId
INNER JOIN Competitions AS C ON C.Id = M.CompetitionId
WHERE UPPER(ME.Type) = UPPER('Goal') AND C.Id = 237 AND UPPER(E.Status) = UPPER('Match Finished') AND Elapsed <= 45

SELECT ME.* FROM MatchEvents AS ME
INNER JOIN Events AS E ON E.Id = Me.EventId
INNER JOIN Matches AS M ON M.Id = E.MatchId
INNER JOIN Competitions AS C ON C.Id = M.CompetitionId
WHERE UPPER(ME.Type) = UPPER('Goal') AND C.Id = 237 AND UPPER(E.Status) = UPPER('Match Finished') AND Elapsed > 45




SELECT ME.* FROM MatchEvents AS ME
INNER JOIN Events AS E ON E.Id = Me.EventId
INNER JOIN Matches AS M ON M.Id = E.MatchId
INNER JOIN Competitions AS C ON C.Id = M.CompetitionId
WHERE UPPER(ME.Type) = UPPER('Goal') AND C.Id = 237 AND UPPER(E.Status) = UPPER('Match Finished')