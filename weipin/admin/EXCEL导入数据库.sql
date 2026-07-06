declare @Email varchar(50);
declare @MobilePhone varchar(20);
declare @Area varchar(50);
declare MyCursor cursor for
	select Email,MobilePhone,Area from 
	OPENROWSET('MICROSOFT.JET.OLEDB.4.0','Excel 5.0;HDR=YES;DATABASE=F:\51job\25.xls',Sheet1$) order by Email
open MyCursor
	declare @eml varchar(50);
fetch NEXT from MyCursor into @Email,@MobilePhone,@Area
while @@FETCH_STATUS = 0
begin
	select @eml=Email from Customers where Email=@Email
	if(@eml is null)
	begin
	insert into Customers(Email,MobilePhone,Area) values(@Email,@MobilePhone,@Area);
	end
set @eml=null;
	fetch NEXT from MyCursor into @Email,@MobilePhone,@Area
end
close MyCursor
deallocate MyCursor


--exec sp_configure 'show advanced options',1
--reconfigure
--exec sp_configure 'Ad Hoc Distributed Queries',1
--reconfigure


--exec sp_configure 'Ad Hoc Distributed Queries',0
--reconfigure
--exec sp_configure 'show advanced options',0
--reconfigure