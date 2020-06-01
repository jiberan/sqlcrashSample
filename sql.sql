USE crashTest
GO


drop PROCEDURE [dbo].[clr_crashSql]

drop ASSEMBLY [SqlCrash]
go

CREATE ASSEMBLY [SqlCrash]
FROM 'c:\cid\clr\SqlCrash.dll'
WITH PERMISSION_SET = EXTERNAL_ACCESS
GO


CREATE PROCEDURE [dbo].[clr_crashSql]

WITH EXECUTE AS CALLER
AS
EXTERNAL NAME [SqlCrash].[SqlCrash.Downloader].[DownloadData]
GO




--after 30-40s, SQL process will crash.
EXEC [clr_crashSql]
							  
	  
