
--These are passed in via the jQuery call
--Declare @Page as int
--Set @Page = 2

-- I've set these here in the SQL statement.. could be passed in as well from the page
Declare @NumRecords as int
Set @NumRecords = 6

select 
	SKU,
	Name
FROM Items

ORDER BY 
	SKU

--This is where the magic happens to only give you the records for the current page / set you need.
OFFSET (@Page - 1) * @NumRecords ROWS FETCH NEXT @NumRecords ROWS ONLY