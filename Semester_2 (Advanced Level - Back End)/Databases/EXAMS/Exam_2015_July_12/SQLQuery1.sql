--select 
--ch.Name
--from Characters as ch
--order by ch.Name asc

--Problem 2.	Games from 2011 and 2012 year

--select top 50
--g.Name [Game],
--FORMAT(g.start,'yyyy-MM-dd', 'en-us') [Start]
--from Games as g
--where YEAR(g.Start) in (2011,2012)
--order by [Start] asc, [Game] asc

--Problem 3.	User Email Providers

--select 
--u.Username,
--SUBSTRING(u.Email,(CHARINDEX('@',u.Email)+1),LEN(u.Email)) [Email Provider]
--from Users as u
--order by [Email Provider] asc, u.Username


--Problem 4.	Get users with IPAddress like pattern
--select
--u.Username,
--u.IpAddress [IP Address]
--from Users as u
--where u.IpAddress like '___.1%.%.___'
--order by u.Username asc

--Problem 5.	Show All Games with Duration and Part of the Day

--select 
--g.Name [Game],
--CASE
--   WHEN DATEPART(HH,g.Start) >= 0 and DATEPART(HH,g.Start) < 12 THEN 'Morning'
--   WHEN DATEPART(HH,g.Start) >= 12 and DATEPART(HH,g.Start) < 18 THEN 'Afternoon'
--   WHEN DATEPART(HH,g.Start) >= 18 and DATEPART(HH,g.Start) < 24 THEN 'Evening'

--END [Part of the Day],
--CASE
-- WHEN g.Duration is null THEN 'Extra Long'
--   WHEN g.Duration <= 3 THEN 'Extra Short'
--   WHEN g.Duration >= 4 AND  g.Duration <= 6 THEN 'Short'
--   WHEN g.Duration > 6 THEN 'Long'

--END [Duration]
--from Games as g
--order by g.Name asc, [Duration] asc , [Part of the Day] asc

--Problem 6.	Number of Users for Email Provider

--select 
-- SUBSTRING(u.Email,(CHARINDEX('@',u.Email)+1),LEN(u.Email)) [Email Provider],
-- count (u.Username) [Number Of Users]
--from Users as u
--Group by SUBSTRING(u.Email,(CHARINDEX('@',u.Email)+1),LEN(u.Email))
--order by [Number Of Users] desc, [Email Provider] asc


--Problem 7.	All User in Games
--select 
--	g.Name [Game],
--	gt.Name [Game Type],
--	u.Username [Username],
--	ug.Level [Level],
--	ug.Cash [Cash],
--	ch.Name [Character]
--from Users as u
--left join UsersGames as ug
--	on ug.UserId = u.Id
--left join Games as g
--	on ug.GameId = g.Id
--join GameTypes as gt
--	on g.GameTypeId = gt.Id
--join Characters as ch
--	on ug.CharacterId = ch.Id
--order by [Level] desc, [Username] asc, [Game] asc

--Problem 8.	Users in Games with Their Items



--Problem 9.	* User in Games with Their Statistics

--select 
-- u.Username [Username],
-- g.Name [Game],
-- ch.Name [Character],
-- Sum(st.Strength) [Strenght],
-- Sum(st.Defence) [Defence],
-- Sum(st.Speed) [Speed],
-- Sum(st.Mind) [Mind],
-- Sum(st.Luck) [Luck]
--from Users as u
--left join UsersGames as ug
--	on ug.UserId = u.Id
--left join Games as g
--	on ug.GameId = g.Id
--left join Characters as ch
--	on ug.CharacterId = ch.Id
--left join [Statistics] as st
--	on st.Id = ch.StatisticId
--group by  u.Username, g.Name, ch.Name

--Problem 10.	All Items with Greater than Average Statistics

--select 
-- i.Name,
-- i.Price,
-- i.MinLevel,
-- st.Strength,
-- st.Defence,
-- st.Speed,
-- st.Luck,
-- st.Mind
--from Items as i
--left join [Statistics] as st
--on i.StatisticId = st.Id
--where st.Mind > 
--	(select AVG(st.Mind)
--	from Items as i
--	left join [Statistics] as st
--	on i.StatisticId = st.Id) 
--	AND
--	st.Luck > 
--	(select AVG(st.Luck)
--	from Items as i
--	left join [Statistics] as st
--	on i.StatisticId = st.Id)
--	AND 
--	st.Speed > 
--	(select AVG(st.Speed)
--	from Items as i
--	left join [Statistics] as st
--	on i.StatisticId = st.Id)
--order by i.Name asc

--Problem 11.	Display All Items with Information about Forbidden Game Type

--select 
--	i.Name [Item],
--	i.Price,
--	i.MinLevel,
--	gt.Name [Forbidden Game Type]
--from Items as i
--left join GameTypeForbiddenItems as gtf
--	on gtf.ItemId = i.Id
--left join GameTypes gt
--	on gtf.GameTypeId = gt.Id
--order by gt.Name desc, i.Name asc

--Problem 12.	Buy items for user in game

--insert into UserGameItems(ItemId, UserGameId)
--values (
--	(select i.Id
--	from Items as i
--	where i.Name = 'Blackguard'
--	),
--	(
--	select 
--	ug.Id
--	from UsersGames as ug
--	join Users as u
--		on ug.UserId = u.Id
--	join Games as g
--		on ug.GameId = g.Id
--	where u.Username = 'Alex' and g.Name = 'Edinburgh'
--	))
--GO


--insert into UserGameItems(ItemId, UserGameId)
--values (
--	(select i.Id
--	from Items as i
--	where i.Name = 'Bottomless Potion of Amplification'
--	),
--	(
--	select 
--	ug.Id
--	from UsersGames as ug
--	join Users as u
--		on ug.UserId = u.Id
--	join Games as g
--		on ug.GameId = g.Id
--	where u.Username = 'Alex' and g.Name = 'Edinburgh'
--	))
--GO

--insert into UserGameItems(ItemId, UserGameId)
--values (
--	(select i.Id
--	from Items as i
--	where i.Name = 'Eye of Etlich (Diablo III)'
--	),
--	(
--	select 
--	ug.Id
--	from UsersGames as ug
--	join Users as u
--		on ug.UserId = u.Id
--	join Games as g
--		on ug.GameId = g.Id
--	where u.Username = 'Alex' and g.Name = 'Edinburgh'
--	))
--GO

--insert into UserGameItems(ItemId, UserGameId)
--values (
--	(select i.Id
--	from Items as i
--	where i.Name = 'Gem of Efficacious Toxin'
--	),
--	(
--	select 
--	ug.Id
--	from UsersGames as ug
--	join Users as u
--		on ug.UserId = u.Id
--	join Games as g
--		on ug.GameId = g.Id
--	where u.Username = 'Alex' and g.Name = 'Edinburgh'
--	))
--GO

--insert into UserGameItems(ItemId, UserGameId)
--values (
--	(select i.Id
--	from Items as i
--	where i.Name = 'Golden Gorget of Leoric'
--	),
--	(
--	select 
--	ug.Id
--	from UsersGames as ug
--	join Users as u
--		on ug.UserId = u.Id
--	join Games as g
--		on ug.GameId = g.Id
--	where u.Username = 'Alex' and g.Name = 'Edinburgh'
--	))
--GO

--insert into UserGameItems(ItemId, UserGameId)
--values (
--	(select i.Id
--	from Items as i
--	where i.Name = 'Hellfire Amulet'
--	),
--	(
--	select 
--	ug.Id
--	from UsersGames as ug
--	join Users as u
--		on ug.UserId = u.Id
--	join Games as g
--		on ug.GameId = g.Id
--	where u.Username = 'Alex' and g.Name = 'Edinburgh'
--	))
--GO



--select 
--ug.Id
--from UsersGames as ug
--join Users as u
--	on ug.UserId = u.Id
--join Games as g
--	on ug.GameId = g.Id
--where u.Username = 'Alex' and g.Name = 'Edinburgh'

--select i.Id
--from Items as i
--where i.Name = 'Blackguard'


--select SUM(i.Price)
--	from Items as i
--	where i.Name IN ( 'Blackguard', 
--	'Bottomless Potion of Amplification', 
--	'Eye of Etlich (Diablo III)', 
--	'Gem of Efficacious Toxin', 
--	'Golden Gorget of Leoric', 
--	'Hellfire Amulet')


--UPDATE UsersGames
--set Cash = Cash - CAST(
--	(
--	select SUM(i.Price)
--		from Items as i
--		where i.Name IN ( 'Blackguard', 
--		'Bottomless Potion of Amplification', 
--		'Eye of Etlich (Diablo III)', 
--		'Gem of Efficacious Toxin', 
--		'Golden Gorget of Leoric', 
--		'Hellfire Amulet')
--	)
--	 as money)
--where UsersGames.Id = ( select 
--	ug.Id
--	from UsersGames as ug
--	join Users as u
--		on ug.UserId = u.Id
--	join Games as g
--		on ug.GameId = g.Id
--	where u.Username = 'Alex' and g.Name = 'Edinburgh')



--select 
--	u.Username,
--	g.Name,
--	ug.Cash,
--	i.Name [Item Name]
--from Users as U
--join UsersGames as ug
--	on ug.UserId = u.Id
--join Games as g
--	on ug.GameId = g.Id
--join UserGameItems as ugi
--	on ugi.UserGameId = ug.Id
--join Items as i
--	on ugi.ItemId = i.Id
--where g.Name = 'Edinburgh'
--order by i.Name asc

--Problem 13.	Massive shopping


BEGIN TRAN
	BEGIN TRY
			
			DECLARE itemCursor CURSOR FOR
				(select i.Id, i.Price
					from Items as i
					where i.MinLevel between 11 and 12)

			open itemCursor
			declare @itemId int
			declare @itemPrice money

			declare @currBalance money
			SET @currBalance = (
				select ug.Cash
				from UsersGames as ug
				join Users as u
						on ug.UserId = u.Id
				join Games as g
						on ug.GameId = g.Id
				where u.Username = 'Stamat' and g.Name = 'Safflower'					
			)

			fetch next from itemCursor into @itemId,@itemPrice
			while @@FETCH_STATUS = 0
			begin 					

					IF ( @currBalance >= @itemPrice)
					BEGIN
						insert into UserGameItems(ItemId, UserGameId)
						values (
							@itemId,
							(
							select 
							ug.Id
							from UsersGames as ug
							join Users as u
								on ug.UserId = u.Id
							join Games as g
								on ug.GameId = g.Id
							where u.Username = 'Stamat' and g.Name = 'Safflower'
							))

					UPDATE UsersGames
						set Cash = Cash - CAST(
							(
							select SUM(i.Price)
								from Items as i
								where i.Id = @itemId
							)
							 as money)
						where UsersGames.Id = ( 
							select 
								ug.Id
							from UsersGames as ug
							join Users as u
								on ug.UserId = u.Id
							join Games as g
								on ug.GameId = g.Id
							where u.Username = 'Stamat' and g.Name = 'Safflower')

						set @currBalance = @currBalance - @itemPrice
					END	

				fetch next from itemCursor into @itemId,@itemPrice			
			end

			close itemCursor
			deallocate itemCursor
		
		COMMIT TRAN
	END TRY

BEGIN CATCH

  ROLLBACK TRAN

END CATCH

select 
i.Name [Item Name]
from UserGameItems as ugi
left join Items as i
	on ugi.ItemId = i.Id
left join UsersGames as ug
	on ugi.UserGameId = ug.Id
left join Games as g
	on ug.GameId = g.Id
where g.Name = 'Safflower'
order by [Item Name] asc


--Problem 14.	Scalar Function: Cash in User Games Odd Rows

--IF OBJECT_ID('fn_CashInUsersGames') IS NOT NULL
--  DROP FUNCTION fn_CashInUsersGames
--GO

--CREATE FUNCTION fn_CashInUsersGames(@gameName nvarchar(max))
--	RETURNS money
--AS
--BEGIN

--	declare @sumOfOdds money
--	set @sumOfOdds = 0
--	DECLARE cashCursor CURSOR  LOCAL DYNAMIC for
--				select 
--					ug.Cash
--				from  UsersGames as ug
--				left join Games as g
--					on ug.GameId = g.Id
--				where g.Name = @gameName
--				order by ug.Cash desc	
--			FOR UPDATE OF ug.Cash


--	open cashCursor
--	declare @row int
--	set @row = 1
--	declare @cash money
--	FETCH NEXT FROM cashCursor INTO @cash
--	WHILE @@FETCH_STATUS = 0
--	BEGIN
--		if(@row % 2 != 0)
--		begin 
--			set @sumOfOdds = @sumOfOdds + @cash
--		end
--		FETCH NEXT FROM cashCursor INTO @cash
--		set @row = @row +1
--	END
	
--	close cashCursor
--	deallocate cashCursor

--	RETURN @sumOfOdds

--END
--GO



--SELECT dbo.fn_CashInUsersGames('Bali') [SumCash]
--union
--SELECT dbo.fn_CashInUsersGames('Lily Stargazer')
--union
--SELECT dbo.fn_CashInUsersGames('Love in a mist')
--union
--SELECT dbo.fn_CashInUsersGames('Mimosa')
--union
--SELECT dbo.fn_CashInUsersGames('Ming fern')


