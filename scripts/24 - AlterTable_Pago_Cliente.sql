ALTER TABLE PAGO_CLIENTE ADD TIPOPACL SMALLINT
GO
UPDATE PAGO_CLIENTE SET TIPOPACL=1
GO