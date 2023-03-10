create procedure AlarmaStockMinimo  (
	@Ret int output
)
AS

set @Ret = ISNULL(
(select COUNT(A.idarti)
from ARTICULO a
INNER JOIN RUBRO R ON A.RUBRARTI=R.CODIRUBR
INNER JOIN MARCA M ON A.MARCAARTI=M.IDMARC
where STOCKARTI<=STOCKMINARTI and ESTAARTI=0 
),0)
