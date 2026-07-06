insert into OPENROWSET('MICROSOFT.JET.OLEDB.4.0','Excel 5.0;HDR=YES;DATABASE=f:\1.xls',sheet1$)
select email from customers

--exec sp_configure 'show advanced options',1
--reconfigure
--exec sp_configure 'Ad Hoc Distributed Queries',1
--reconfigure


--exec sp_configure 'Ad Hoc Distributed Queries',0
--reconfigure
--exec sp_configure 'show advanced options',0
--reconfigure