--Problem 12.Highest Peaks in Bulgaria
SELECT c.CountryCode,
	   m.MountainRange,
	   p.PeakName,
	   p.Elevation
FROM Countries AS c
INNER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
INNER JOIN Mountains AS m ON mc.MountainId = m.Id
INNER JOIN Peaks AS p ON m.Id = p.MountainId
WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--Problem 13.Count Mountain Ranges
SELECT CountryCode, COUNT(MountainId) FROM MountainsCountries
WHERE CountryCode IN ('BG','RU','US')
GROUP BY CountryCode

--Problem 14.Countries with Rivers
SELECT TOP(5) c.CountryName,
			  r.RiverName
FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT OUTER JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC

--Problem 15.*Continents and Currencies
SELECT ContinentCode, 
       CurrencyCode, 
       CurrencyCount AS CurrencyUsage
FROM (SELECT ContinentCode, 
             CurrencyCode, 
             CurrencyCount,
             DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS CurrencyRank
      FROM (SELECT ContinentCode, 
                   CurrencyCode,
                   COUNT(*) AS CurrencyCount 
             FROM Countries
             GROUP BY ContinentCode, CurrencyCode
            ) AS CurrencyCountQuery
      WHERE CurrencyCount > 1
	 ) AS CurrencyRankingQuery
WHERE CurrencyRank = 1
ORDER BY ContinentCode

--Problem 16.Countries without any Mountains
SELECT COUNT(*) FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL

--Problem 17.Highest Peak and Longest River by Country
SELECT TOP(5) CountryName,
	          MAX(p.Elevation) AS HighestPeakElevation,
	          MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT OUTER JOIN Rivers AS r ON cr.RiverId = r.Id
LEFT OUTER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT OUTER JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT OUTER JOIN Peaks AS p ON m.Id = p.MountainId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC,
	     LongestRiverLength DESC,
		 CountryName ASC

--Problem 18.* Highest Peak Name and Elevation by Country
SELECT TOP(5) Country,
              ISNULL(PeakName, '(no highest peak)') AS HighestPeakName,
	          ISNULL(Elevation, 0) AS HighestPeakElevation,
	          ISNULL(MountainRange, '(no mountain)') AS MountainRange
FROM (SELECT *,
            DENSE_RANK() OVER (PARTITION BY Country ORDER BY Elevation DESC) AS PeakRank
      FROM (SELECT CountryName AS Country,
      		   p.PeakName,
      		   p.Elevation,
      		   m.MountainRange
      	  FROM Countries AS c
      	  LEFT OUTER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
      	  LEFT OUTER JOIN Mountains AS m ON mc.MountainId = m.Id
      	  LEFT OUTER JOIN Peaks AS p ON m.Id = p.MountainId
      	 ) AS FullCountryMountainInfo
	 ) AS PeaksRankingQuery
WHERE PeakRank = 1
ORDER BY Country ASC,
		 HighestPeakName ASC