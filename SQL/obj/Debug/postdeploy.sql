if not exists (select 1 from [dbo].[Pathes])
begin
	insert into [dbo].[Pathes] ([location])
	values
	('F:/pobrane/');
end
GO
