CREATE PROCEDURE [dbo].[SPupdateLogin] (
	@id smallint,
	@generationTime datetime,
	@expirationTime datetime,
	@token varchar(max),
	@sign varchar(max)
)
AS
update LOGINCMS set
generationTime=@generationTime,
expirationTime=@expirationTime,
token=@token,
[sign]=@sign
--where id=@id


GO


