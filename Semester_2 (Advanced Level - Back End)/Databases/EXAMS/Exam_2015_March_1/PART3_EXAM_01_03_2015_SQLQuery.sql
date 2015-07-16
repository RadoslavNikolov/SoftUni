IF OBJECT_ID('fn_MountainsPeaksJSON') IS NOT NULL
  DROP FUNCTION fn_MountainsPeaksJSON
GO

CREATE FUNCTION fn_MountainsPeaksJSON()
	RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @json nvarchar(MAX) = '{"mountains":['
	DECLARE mountainsCursor CURSOR FOR
		SELECT Id, MountainRange FROM Mountains

		OPEN mountainsCursor
		DECLARE @mountainName nvarchar(max)
		DECLARE @mountainId int

		FETCH NEXT FROM mountainsCursor INTO @mountainId, @mountainName
		WHILE @@FETCH_STATUS = 0
			BEGIN
				SET @json = @json + '{"name":"' + @mountainName + '","peaks":['

				DECLARE peaksCursor CURSOR FOR
				SELECT PeakName, Elevation FROM Peaks
				WHERE MountainId = @mountainId
				
				OPEN peaksCursor
				DECLARE @peakName nvarchar(max)
				DECLARE @elevation int
				FETCH NEXT FROM peaksCursor INTO @peakName, @elevation
				WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @json = @json + '{"name":"' + @peakName + '",' +
					'"elevation":' + CONVERT(NVARCHAR(MAX), @elevation) + '}'
					FETCH NEXT FROM peaksCursor INTO @peakName, @elevation
					IF @@FETCH_STATUS = 0
						SET @json = @json + ','
				END
				CLOSE peaksCursor
				DEALLOCATE peaksCursor
		SET @json = @json + ']}'

		FETCH NEXT FROM mountainsCursor INTO @mountainId, @mountainName
		IF @@FETCH_STATUS = 0
			SET @json = @json + ','

		END
		CLOSE mountainsCursor
		DEALLOCATE mountainsCursor

	SET @json = @json + ']}'
	RETURN @json

END
GO

SELECT dbo.fn_MountainsPeaksJSON()

SELECT
	M.MountainRange [Mountain],
	P.PeakName, 
	P.Elevation
FROM Mountains AS M
JOIN Peaks AS P
	ON P.MountainId = M.Id
ORDER BY M.MountainRange, P.PeakName