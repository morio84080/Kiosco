/****** Object:  StoredProcedure [dbo].[SPclienteAgregar]    Script Date: 05/03/2021 08:27:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SPclienteAgregar] (
	@LocaClie	numeric(5,0),
	@RasoClie	varchar(60),
	@CuitClie	varchar(25),
	@DireClie	varchar(35),
	@TeleClie	varchar(25),
	@MailClie	varchar(100),
	@CondIvaClie	smallint	
)
AS
insert into CLIENTE (LOCACLIE,RASOCLIE,CUITCLIE,DIRECLIE,TELECLIE,EMAILCLIE,CONDIVACLIE) 
values (@LocaClie,@RasoClie,@CuitClie,@DireClie,@TeleClie,@MailClie,@CondIvaClie)
