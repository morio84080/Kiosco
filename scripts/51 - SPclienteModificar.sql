/****** Object:  StoredProcedure [dbo].[SPclienteModificar]    Script Date: 05/03/2021 08:34:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SPclienteModificar] (
	@LocaClie	numeric(5,0),
	@RasoClie	varchar(35),
	@CuitClie	varchar(25),
	@DireClie	varchar(35),
	@TeleClie	varchar(25),
	@MailClie	varchar(100),
	@EstaClie	bit,
	@IdClie		int,
	@CondIvaClie	smallint		
)
AS
UPDATE CLIENTE SET
LOCACLIE=@LocaClie,
RASOCLIE=@RasoClie,
CUITCLIE=@CuitClie,
DIRECLIE=@DireClie,
TELECLIE=@TeleClie,
EMAILCLIE=@MailClie,
ELIMINADOCLIE=@EstaClie,
CONDIVACLIE= @CondIvaClie
WHERE IDCLIE=@IdClie


