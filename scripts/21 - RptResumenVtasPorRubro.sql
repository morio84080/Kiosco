CREATE PROCEDURE [dbo].[RptResumenVtasPorRubro] (
	@fechaIni datetime,
	@fechaFin datetime
)
AS
SELECT R.*,QUERY.*
FROM
RUBRO R INNER JOIN
(SELECT A.RUBRARTI,SUM(VA.CANTVEAR) CANTIDAD, SUM(VA.SUBTOTAVEAR) SUBTOTAL
FROM
(select * 
from VENTA 
where ELIMINADOVTA=0 and FECHVTA between @fechaIni and @fechaFin
and NUMEVTA NOT IN (SELECT NUMEVTANOCR FROM NOTA_CREDITO WHERE ELIMINADO=0)) VENTAS
INNER JOIN (VENTA_ARTICULO VA INNER JOIN ARTICULO A ON VA.ARTIVEAR=A.IDARTI) ON VENTAS.NUMEVTA=VA.NUMEVEAR
GROUP BY A.RUBRARTI) QUERY
ON R.CODIRUBR=QUERY.RUBRARTI
order by DESCRUBR