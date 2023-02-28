CREATE FUNCTION ObtenerNetoNoGravado
(
    @total decimal(18,2)
)
RETURNS DECIMAL(18,2)
AS BEGIN	
	return round((@total * 0.7458),2)
END
