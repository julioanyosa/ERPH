01 por generar
02 xml generado
03 enviado y aceptado sunat
05 error de geenracion
06 error de sunat

/*
20394050599
CORPORACION PERUANA DE ENVASES E.I.R.L.
JR. CONTAMANA NRO. 114 (FRENTE AL HOSPEDAJE FALCÓN) UCAYALI - CORONEL PORTILLO - CALLERIA


20394050599
GRANJA AVICOLA HALLEY E.I.R.L.
JR. 7 DE JUNIO NRO. 400 URB. CERCADO DE PUCALLPA (MZ. 68 LT. 1) UCAYALI - CORONEL PORTILLO - CALLERIA

250101
CALLERIA
UCAYALI
CORONEL PORTILLO
CALLERIA
*/
--https://excelservicios.com/blog/facturador-sunat-v-1-2/
/*
select* from empresa.Empresa

CREATE NONCLUSTERED INDEX [IDX_VENTAS_COMPROBANTE_COMPROBANTEID]
ON [Ventas].[Comprobante] ([ComprobanteId])

SELECT ComprobanteId, AudCrea, EmpresaID,  * FROM Ventas.Comprobante WHERE TipoComprobanteID IN(4) AND EMPRESAID = 'AH'
SELECT  * FROM Ventas.Comprobante WHERE ComprobanteId =  2449144

-- To allow advanced options to be changed.
EXEC sp_configure 'show advanced options', 1
GO
-- To update the currently configured value for advanced options.
RECONFIGURE
GO
-- To enable the feature.
EXEC sp_configure 'xp_cmdshell', 1
GO
-- To update the currently configured value for this feature.
RECONFIGURE
GO

*/

SELECT ComprobanteId, * FROM VENTAS.Comprobante WHERE TipoComprobanteID in( 4,5)


select* from empresa.Empresa
--Ventas.GenerarTxtFacturadorSunat 98



alter PROCEDURE Ventas.GenerarTxtFacturadorSunat
(
@ID BIGINT 
)
as
--DECLARE @ID BIGINT = 2479196
DECLARE @UNIDADRAIZ VARCHAR(500) = 'E:\SFS_v1.2\sunat_archivos\sfs\DATA\', @NOMBREARCHIVO varchar(250)
DECLARE @Cadena    varchar(max) 
 
  DECLARE @RUTAEJECUTAR0 VARCHAR(300)   
-------------------------------------------------------------------
--CABECERA
SELECT @NOMBREARCHIVO = E.RUC + '-' + CASE WHEN C.TipoComprobanteID = 4 THEN '03' ELSE '01'  END + '-' +
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.CAB'  FROM Ventas.Comprobante AS C
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID

  --PONER EL ARCHIVO EN BLANCO    
 
 

SELECT 
'0101' + '^|' + --Tipo de operación (VENTA INTERNA)
CONVERT(char(10), C.AudCrea,126) + '^|' + --Fecha de emisión
CONVERT(varchar(10),C.AudCrea,108) + '^|' +--Hora de Emisión
'-' + '^|' +--Fecha de vencimiento
'0001' + '^|' +--Código del domicilio fiscal o de local anexo del emisor


 case      
 when cL.ClienteID = 0 or cL.ClienteID = 1 or cL.ClienteID = 204 or cL.ClienteID = 241 or cL.ClienteID = 3032 then '0'      
 else td.TipoContabilidad end   + '^|' + ---Tipo de documento de identidadL del adquirente o usuario      
 CASE      
 when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'      
 else LEFT(cl.NroDocumento,100) end  + '^|' + --Número de documento de identidad del adquirente o usuario       
 case      
 when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then 'Clientes Varios'      
 else LEFT(cl.RazonSocial,100) end  + '^|' + --Apellidos y nombres, denominación o razón social del adquirente o usuario    + '^|' + --apellidos y nombres  
 'PEN' + '^|' +--Tipo de moneda en la cual se emite la factura electrónica
CONVERT(VARCHAR(50),convert(decimal(12,2),C.TotalIGV)) + '^|' + --Sumatoria Tributos
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal)) + '^|' +--Total valor de venta 
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV- ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00))) + '^|' +--Total Precio de Venta
 CONVERT(VARCHAR(50), ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00)) + '^|' +--Total descuentos
'0.00' + '^|' + --Sumatoria otros Cargos
'0.00' + '^|' + --Total Anticipos
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV)) + '^|'  + --Importe total de la venta, cesión en uso o del servicio prestado
'2.1' + '^|' + --Versión UBL
'2.0' + '^|'--Customization Documento
 as rrr
into #tmp1
 FROM Ventas.Comprobante AS C
 INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID
  INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento  
   left JOIN         
(SELECT dc.NumComprobante, dc.TipoComprobanteID, SUM(dc.Importe) AS Importe FROM Ventas.DetalleComprobante dc WHERE dc.ProductoID = '00267000102.7'        
 GROUP BY dc.NumComprobante, dc.TipoComprobanteID) AS Descuento ON Descuento.NumComprobante = C.NumComprobante AND Descuento.TipoComprobanteID = C.TipoComprobanteID         
  left join         
  (        
  select distinct EmpresaID,SedeID,Establecimiento from Almacen.Almacen        
  )        
   as AL on AL.EmpresaID = C.EmpresaID and AL.SedeID = C.SedeID    
  WHERE C.ComprobanteId =  @ID

 
 DECLARE @Comando VARCHAR(2048) 
SET @Comando = 'Exec xp_Cmdshell ''bcp "select * from #tmp1" queryout "' + @UNIDADRAIZ   + @NOMBREARCHIVO + '" -c -T'''
EXEC (@Comando);
  
-------------------------------------------------------------------
--DETALLE   

SELECT @NOMBREARCHIVO = E.RUC + '-' + CASE WHEN C.TipoComprobanteID = 4 THEN '03' ELSE '01'  END + '-' +
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.DET'  FROM Ventas.Comprobante AS C
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID

    
SELECT      
  case
  when p.ProductoID = '00394000102.7' then   'ZZ' 
  when p.ProductoID = '00478000102.7' then   'ZZ' 
  when p.ProductoID = '00216000102.7' then   'ZZ'  
  when p.ProductoID = '00645050102.7' then   'ZZ' 
  when p.ProductoID = '00650000060.7' then   'ZZ' 
  when p.ProductoID = '00650000060.7' then   'ZZ'  
  when p.ProductoID = '00651050102.7' then   'ZZ' 
  when p.ProductoID = '00652050102.7' then   'ZZ'        
  when p.unidadmedidaid = 'UN' then   'NIU'        
  when p.unidadmedidaid = 'KG' then   'KGM'        
  when p.unidadmedidaid = 'MT' then   'MTR'        
  when p.unidadmedidaid = 'LT' then   'LTR'        
  when p.unidadmedidaid = 'PQ' then   'PK'        
  when p.unidadmedidaid = 'GL' then   'GLL'        
  when p.unidadmedidaid = 'GR' then   'GRM'        
  when p.unidadmedidaid = 'SC' then   'NIU'       
  else 'ERROR-' END + '^|' +  --Código de unidad de medida por ítem        
  convert(varchar(23),convert(decimal(12,2),dc.Cantidad))  + '^|' + --Cantidad de unidades por ítem        
  dc.ProductoID + '^|' + --Código de producto        
  '-'  + '^|' + --Codigo producto SUNAT        
  left(p.alias,250) + '^|' + --Descripción detallada del servicio prestado, bien vendido o cedido en uso, indicando las características.        
  CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00))   + '^|' + --Valor unitario por ítem 
  '0.00'   + '^|' +  --Sumatoria Tributos por item
  '9997' + '^|' +  --Tributo: Códigos de tipos de tributos IGV (EXONERADO)
'0.00'   + '^|' +  --Tributo: Monto de IGV por ítem
CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00))   + '^|' +  --Tributo: Base Imponible IGV por Item
'EXO'   + '^|' +  --Tributo: Nombre de tributo por item
'VAT'   + '^|' +  --Tributo: Código de tipo de tributo por Item
'20'   + '^|' +  --Tributo: Afectación al IGV por ítem
'0.00'   + '^|' +  --Tributo: Porcentaje de IGV
 

'-'   + '^|' + --15	Tributo ISC: Códigos de tipos de tributos ISC
''   + '^|' + --16	Tributo ISC: Monto de ISC por ítem
''   + '^|' + --17	Tributo ISC: Base Imponible ISC por Item
''   + '^|' + --18	Tributo ISC: Nombre de tributo por item
''   + '^|' + --19	Tributo ISC: Código de tipo de tributo por Item
''   + '^|' + --20	Tributo ISC: Tipo de sistema ISC
''   + '^|' + --21	Tributo ISC: Porcentaje de ISC
 

'-'   + '^|' + --22	Tributo Otro: Códigos de tipos de tributos OTRO
''   + '^|' + --23	Tributo Otro: Monto de tributo OTRO por iItem
''   + '^|' + --24	Tributo Otro: Base Imponible de tributo OTRO por Item
''   + '^|' + --25	Tributo Otro:  Nombre de tributo OTRO por item
''   + '^|' + --26	Tributo Otro: Código de tipo de tributo OTRO por Item
''   + '^|' + --27	Tributo Otro: Porcentaje de tributo OTRO por Item
CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00)) + '^|' + --28	"Precio de venta unitario cac:InvoiceLine/cac:PricingReference/cac:AlternativeConditionPrice"
CONVERT(varchar(14),(convert(decimal(12,2),dc.Cantidad * dc.PrecioUnitario))) + '^|' + --29	Valor de venta por Item cac:InvoiceLine/cbc:LineExtensionAmount
'0.00' + '^|'  --30	"Valor REFERENCIAL unitario (gratuitos) "
as rrrr into #tmp2
  FROM Ventas.DetalleComprobante dc        
  INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID        
  inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID        
  inner join [Ventas].[TipoComprobante] as tc on tc.TipoComprobanteID = con.TipoComprobanteID        
  --WHERE dc.ProductoID NOT IN( '00267000102.7','00216000102.7') and        
  WHERE   
    con.ComprobanteId =  @ID    

 
SET @Comando = 'Exec xp_Cmdshell ''bcp "select * from #tmp2" queryout "' + @UNIDADRAIZ   + @NOMBREARCHIVO + '" -c -T'''
EXEC (@Comando);  
 
-------------------------------------------------------------------
--TRIBUTOS GENERALES 
 
SELECT @NOMBREARCHIVO = E.RUC + '-' + CASE WHEN C.TipoComprobanteID = 4 THEN '03' ELSE '01'  END + '-' +
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.TRI'  FROM Ventas.Comprobante AS C
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID

 
SELECT 
'9997' + '^|' + --1	Identificador de tributo
'EXO' + '^|' + --2	Nombre de tributo
'VAT' + '^|' + --3	Código de tipo de tributo
CONVERT(varchar(14),SUM(ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00))) + '^|' + --4	Base imponible
'0.00'   + '^|'  --5	Monto de Tirbuto por ítem
as rrrr
into #tmp3
FROM Ventas.DetalleComprobante dc        
INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID        
inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID        
inner join [Ventas].[TipoComprobante] as tc on tc.TipoComprobanteID = con.TipoComprobanteID        
--WHERE dc.ProductoID NOT IN( '00267000102.7','00216000102.7') and        
WHERE   
con.ComprobanteId =  @ID    

SET @Comando = 'Exec xp_Cmdshell ''bcp "select * from #tmp3" queryout "' + @UNIDADRAIZ   + @NOMBREARCHIVO + '" -c -T'''
EXEC (@Comando);  
-------------------------------------------------------------------
--LEYENDA
SELECT @NOMBREARCHIVO = E.RUC +'-' + CASE WHEN C.TipoComprobanteID = 4 THEN '03' ELSE '01'  END + '-' +
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.LEY'  FROM Ventas.Comprobante AS C
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID
 
select * into #tmp5 from( 
SELECT 
'1000^|' + [dbo].[FN_CantidadConLetraSoles](C.SubTotal + C.TotalIGV) + '^|' as rr
FROM Ventas.Comprobante AS C  WHERE C.ComprobanteId =  @ID

 union

SELECT  '2001^|BIENES TRANSFERIDOS EN LA AMAZONÍA REGIÓN SELVA PARA SER CONSUMIDOS EN LA MISMA^|' as rr
) as ttt
SET @Comando = 'Exec xp_Cmdshell ''bcp "select * from #tmp5" queryout "' + @UNIDADRAIZ   + @NOMBREARCHIVO + '" -c -T'''
EXEC (@Comando);   


select 'OK' as ok
GO



ALTER FUNCTION [dbo].[FN_CantidadConLetraSoles]
(
    @Numero             Decimal(18,2)
)
RETURNS Varchar(180)
AS
BEGIN
    DECLARE @ImpLetra Varchar(180)
        DECLARE @lnEntero INT,
                        @lcRetorno VARCHAR(512),
                        @lnTerna INT,
                        @lcMiles VARCHAR(512),
                        @lcCadena VARCHAR(512),
                        @lnUnidades INT,
                        @lnDecenas INT,
                        @lnCentenas INT,
                        @lnFraccion INT
        SELECT  @lnEntero = CAST(@Numero AS INT),
                        @lnFraccion = (@Numero - @lnEntero) * 100,
                        @lcRetorno = '',
                        @lnTerna = 1
  WHILE @lnEntero > 0
  BEGIN /* WHILE */
            -- Recorro terna por terna
            SELECT @lcCadena = ''
            SELECT @lnUnidades = @lnEntero % 10
            SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
            SELECT @lnDecenas = @lnEntero % 10
            SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
            SELECT @lnCentenas = @lnEntero % 10
            SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
            -- Analizo las unidades
            SELECT @lcCadena =
            CASE /* UNIDADES */
              WHEN @lnUnidades = 1 THEN 'UN ' + @lcCadena
              WHEN @lnUnidades = 2 THEN 'DOS ' + @lcCadena
              WHEN @lnUnidades = 3 THEN 'TRES ' + @lcCadena
              WHEN @lnUnidades = 4 THEN 'CUATRO ' + @lcCadena
              WHEN @lnUnidades = 5 THEN 'CINCO ' + @lcCadena
              WHEN @lnUnidades = 6 THEN 'SEIS ' + @lcCadena
              WHEN @lnUnidades = 7 THEN 'SIETE ' + @lcCadena
              WHEN @lnUnidades = 8 THEN 'OCHO ' + @lcCadena
              WHEN @lnUnidades = 9 THEN 'NUEVE ' + @lcCadena
              ELSE @lcCadena
            END /* UNIDADES */
            -- Analizo las decenas
            SELECT @lcCadena =
            CASE /* DECENAS */
              WHEN @lnDecenas = 1 THEN
                CASE @lnUnidades
                  WHEN 0 THEN 'DIEZ '
                  WHEN 1 THEN 'ONCE '
                  WHEN 2 THEN 'DOCE '
                  WHEN 3 THEN 'TRECE '
                  WHEN 4 THEN 'CATORCE '
                  WHEN 5 THEN 'QUINCE '
                  WHEN 6 THEN 'DIEZ Y SEIS '
                  WHEN 7 THEN 'DIEZ Y SIETE '
                  WHEN 8 THEN 'DIEZ Y OCHO '
                  WHEN 9 THEN 'DIEZ Y NUEVE '
                END
              WHEN @lnDecenas = 2 THEN
              CASE @lnUnidades
                WHEN 0 THEN 'VEINTE '
                ELSE 'VEINTI' + @lcCadena
              END
              WHEN @lnDecenas = 3 THEN
              CASE @lnUnidades
                WHEN 0 THEN 'TREINTA '
                ELSE 'TREINTA Y ' + @lcCadena
              END
              WHEN @lnDecenas = 4 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'CUARENTA'
                    ELSE 'CUARENTA Y ' + @lcCadena
                END
              WHEN @lnDecenas = 5 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'CINCUENTA '
                    ELSE 'CINCUENTA Y ' + @lcCadena
                END
              WHEN @lnDecenas = 6 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'SESENTA '
                    ELSE 'SESENTA Y ' + @lcCadena
                END
              WHEN @lnDecenas = 7 THEN
                 CASE @lnUnidades
                    WHEN 0 THEN 'SETENTA '
                    ELSE 'SETENTA Y ' + @lcCadena
                 END
              WHEN @lnDecenas = 8 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'OCHENTA '
                    ELSE  'OCHENTA Y ' + @lcCadena
                END
              WHEN @lnDecenas = 9 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'NOVENTA '
                    ELSE 'NOVENTA Y ' + @lcCadena
                END
              ELSE @lcCadena
            END /* DECENAS */
            -- Analizo las centenas
            SELECT @lcCadena =
            CASE /* CENTENAS */
              WHEN @lnCentenas = 1 THEN 'CIENTO ' + @lcCadena
              WHEN @lnCentenas = 2 THEN 'DOSCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 3 THEN 'TRESCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 4 THEN 'CUATROCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 5 THEN 'QUINIENTOS ' + @lcCadena
              WHEN @lnCentenas = 6 THEN 'SEISCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 7 THEN 'SETECIENTOS ' + @lcCadena
              WHEN @lnCentenas = 8 THEN 'OCHOCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 9 THEN 'NOVECIENTOS ' + @lcCadena
              ELSE @lcCadena
            END /* CENTENAS */
            -- Analizo la terna
            SELECT @lcCadena =
            CASE /* TERNA */
              WHEN @lnTerna = 1 THEN @lcCadena
              WHEN @lnTerna = 2 THEN @lcCadena + 'MIL '
              WHEN @lnTerna = 3 THEN @lcCadena + 'MILLONES '
              WHEN @lnTerna = 4 THEN @lcCadena + 'MIL '
              ELSE ''
            END /* TERNA */
            -- Armo el retorno terna a terna
            SELECT @lcRetorno = @lcCadena  + @lcRetorno
            SELECT @lnTerna = @lnTerna + 1
   END /* WHILE */
   IF @lnTerna = 1
       SELECT @lcRetorno = 'CERO'
   DECLARE @sFraccion VARCHAR(15)
   SET @sFraccion = '00' + LTRIM(CAST(@lnFraccion AS varchar))
   SELECT @ImpLetra = RTRIM(@lcRetorno) + ' CON ' + SUBSTRING(@sFraccion,LEN(@sFraccion)-1,2) + '/100 SOLES'

   RETURN @ImpLetra
END
GO

--Ventas.GenerarTxtFacturadorSunatResumenDiario '2019-02-26', 'AH', 4
alter procedure Ventas.GenerarTxtFacturadorSunatResumenDiario
(
@fecha date,
@EmpresaID char(2),
@TipoComprobanteID int
)
as
DECLARE @UNIDADRAIZ VARCHAR(500) = 'E:\SFS_v1.2\sunat_archivos\sfs\DATA\', @NOMBREARCHIVO varchar(250)
DECLARE @Cadena    varchar(max)  

SELECT top 1 @NOMBREARCHIVO = E.RUC + '-RC-' +
convert(char(4),YEAR(getdate())) + right('00' + convert(varchar(2),month(getdate())),2)
  + right('00' + convert(varchar(2),day(getdate())),2)+ '-001.RDI'  FROM  Empresa.Empresa AS E 
  WHERE   E.EmpresaID = @EmpresaID  

  --PONER EL ARCHIVO EN BLANCO    
  DECLARE @RUTAEJECUTAR0 VARCHAR(300)     
 SET @RUTAEJECUTAR0 = 'WRITE  > ' + @UNIDADRAIZ   + @NOMBREARCHIVO    
 exec xp_cmdshell @RUTAEJECUTAR0, no_output 

 DECLARE @RUTAEJECUTAR1  VARCHAR(8000)  

 DECLARE CURSOR_PRODUCTOS CURSOR FOR    

select

CONVERT(char(10), C.AudCrea,126) + '^|' + --1	Fecha de generación del documento
CONVERT(char(10), getdate(),126) + '^|' + --2	Fecha de generación del resumen
'03' + '^|'+ --3	Tipo de documento de resumen (boleta)
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END + 
SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '^|' + --4	Serie y número de documento
 case      
 when cL.ClienteID = 0 or cL.ClienteID = 1 or cL.ClienteID = 204 or cL.ClienteID = 241 or cL.ClienteID = 3032 then '0'      
 else td.TipoContabilidad end   + '^|' + --5	Tipo de documento de Identidad del adquirente o usuario 
 CASE      
 when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'      
 else LEFT(cl.NroDocumento,100) end  + '^|' + --6	Número de documento del adquirente o usuario 
 'PEN' + '^|' + --7	Tipo de Moneda
'0.00' + '^|' + --8	Total valor de venta - operaciones gravadas
CONVERT(varchar(14),convert(decimal(12,2),c.SubTotal)) + '^|' + --9	Total valor de venta - operaciones exoneradas
'0.00' + '^|' + --10	Total valor de venta - operaciones inafectas
'0.00' + '^|' + --11	Total valor de venta - operaciones gratuitas
'0.00' + '^|' + --12	Importe total de sumatoria otros cargos del ítem
'0.00' + '^|' + --13	Total ISC
CONVERT(varchar(14),convert(decimal(12,2),c.TotalIGV)) + '^|' + --14	Total IGV
'0.00' + '^|' + --15	Total Otros tributos
 CONVERT(varchar(14),convert(decimal(12,2),c.TotalIGV + c.SubTotal)) + '^|' + --16	Importe total de la venta, cesión en uso o del servicio prestado
'' + '^|' + --17	Tipo de documento que modifica
'' + '^|' + --18	Número de serie de la boleta de venta que modifica
'' + '^|' + --19	Número correlativo de la boleta de venta que modifica
'' + '^|' + --20	Régimen de percepción
'' + '^|' + --21	Porcentaje de Percepcion
'' + '^|' + --22	Base imponible percepción 
'' + '^|' + --23	Monto de la percepción
'' + '^|' + --24	"Monto total a cobrar incluida lapercepción"
'1' + '^|' --25	Estado

FROM Ventas.Comprobante AS C
 INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID
  INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento  
   left JOIN         
(SELECT dc.NumComprobante, dc.TipoComprobanteID, SUM(dc.Importe) AS Importe FROM Ventas.DetalleComprobante dc WHERE dc.ProductoID = '00267000102.7'        
 GROUP BY dc.NumComprobante, dc.TipoComprobanteID) AS Descuento ON Descuento.NumComprobante = C.NumComprobante AND Descuento.TipoComprobanteID = C.TipoComprobanteID         
  left join         
  (        
  select distinct EmpresaID,SedeID,Establecimiento from Almacen.Almacen        
  )        
   as AL on AL.EmpresaID = C.EmpresaID and AL.SedeID = C.SedeID    
  WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID


 OPEN CURSOR_PRODUCTOS     
 FETCH NEXT FROM CURSOR_PRODUCTOS INTO @Cadena    
    
 WHILE @@FETCH_STATUS = 0     
 BEGIN    
   SET @RUTAEJECUTAR1 = 'echo ' + @Cadena + '>> ' + @UNIDADRAIZ   + @NOMBREARCHIVO    
   exec xp_cmdshell @RUTAEJECUTAR1, no_output 
   set @Cadena =''       
   FETCH NEXT FROM CURSOR_PRODUCTOS INTO @Cadena    
 END     
     
CLOSE CURSOR_PRODUCTOS     
DEALLOCATE CURSOR_PRODUCTOS  
go

 --Ventas.ObtenerTxtFacturadorSunat 81
--GO
CREATE PROCEDURE Ventas.ObtenerTxtFacturadorSunat
(
@ID BIGINT 
)
as
--DECLARE @ID BIGINT = 2479196
DECLARE @UNIDADRAIZ VARCHAR(500) = 'E:\SFS_v1.2\sunat_archivos\sfs\DATA\', 
@NOMBREARCHIVOCAB varchar(250), @NOMBREARCHIVOLEY varchar(250), @NOMBREARCHIVODET varchar(250),
@NOMBREARCHIVOTRI varchar(250)
DECLARE @Cadena    varchar(max) 
 
SELECT @UNIDADRAIZ AS UNIDADRAIZ 
-------------------------------------------------------------------
--CABECERA
SELECT @NOMBREARCHIVOCAB = E.RUC + '-' + CASE WHEN C.TipoComprobanteID = 4 THEN '03' ELSE '01'  END + '-' +
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.CAB'  FROM Ventas.Comprobante AS C
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID

 SELECT @NOMBREARCHIVOCAB AS NOMBREARCHIVOCAB

SELECT 
'0101' + '|' + --Tipo de operación (VENTA INTERNA)
CONVERT(char(10), C.AudCrea,126) + '|' + --Fecha de emisión
CONVERT(varchar(10),C.AudCrea,108) + '|' +--Hora de Emisión
'-' + '|' +--Fecha de vencimiento
'0001' + '|' +--Código del domicilio fiscal o de local anexo del emisor


 case      
 when cL.ClienteID = 0 or cL.ClienteID = 1 or cL.ClienteID = 204 or cL.ClienteID = 241 or cL.ClienteID = 3032 then '0'      
 else td.TipoContabilidad end   + '|' + ---Tipo de documento de identidadL del adquirente o usuario      
 CASE      
 when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'      
 else LEFT(cl.NroDocumento,100) end  + '|' + --Número de documento de identidad del adquirente o usuario       
 case      
 when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then 'Clientes Varios'      
 else LEFT(cl.RazonSocial,100) end  + '|' + --Apellidos y nombres, denominación o razón social del adquirente o usuario    + '|' + --apellidos y nombres  
 'PEN' + '|' +--Tipo de moneda en la cual se emite la factura electrónica
CONVERT(VARCHAR(50),convert(decimal(12,2),C.TotalIGV)) + '|' + --Sumatoria Tributos
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal)) + '|' +--Total valor de venta 
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV- ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00))) + '|' +--Total Precio de Venta
 CONVERT(VARCHAR(50), ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00)) + '|' +--Total descuentos
'0.00' + '|' + --Sumatoria otros Cargos
'0.00' + '|' + --Total Anticipos
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV)) + '|'  + --Importe total de la venta, cesión en uso o del servicio prestado
'2.1' + '|' + --Versión UBL
'2.0' + '|'--Customization Documento
 as COL1
 FROM Ventas.Comprobante AS C
 INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID
  INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento  
   left JOIN         
(SELECT dc.NumComprobante, dc.TipoComprobanteID, SUM(dc.Importe) AS Importe FROM Ventas.DetalleComprobante dc WHERE dc.ProductoID = '00267000102.7'        
 GROUP BY dc.NumComprobante, dc.TipoComprobanteID) AS Descuento ON Descuento.NumComprobante = C.NumComprobante AND Descuento.TipoComprobanteID = C.TipoComprobanteID         
  left join         
  (        
  select distinct EmpresaID,SedeID,Establecimiento from Almacen.Almacen        
  )        
   as AL on AL.EmpresaID = C.EmpresaID and AL.SedeID = C.SedeID    
  WHERE C.ComprobanteId =  @ID

 
-------------------------------------------------------------------
--DETALLE   

SELECT @NOMBREARCHIVODET = E.RUC + '-' + CASE WHEN C.TipoComprobanteID = 4 THEN '03' ELSE '01'  END + '-' +
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.DET'  FROM Ventas.Comprobante AS C
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID

 SELECT @NOMBREARCHIVODET AS NOMBREARCHIVODET   
SELECT      
  case
  when p.ProductoID = '00394000102.7' then   'ZZ' 
  when p.ProductoID = '00478000102.7' then   'ZZ' 
  when p.ProductoID = '00216000102.7' then   'ZZ'  
  when p.ProductoID = '00645050102.7' then   'ZZ' 
  when p.ProductoID = '00650000060.7' then   'ZZ' 
  when p.ProductoID = '00650000060.7' then   'ZZ'  
  when p.ProductoID = '00651050102.7' then   'ZZ' 
  when p.ProductoID = '00652050102.7' then   'ZZ'        
  when p.unidadmedidaid = 'UN' then   'NIU'        
  when p.unidadmedidaid = 'KG' then   'KGM'        
  when p.unidadmedidaid = 'MT' then   'MTR'        
  when p.unidadmedidaid = 'LT' then   'LTR'        
  when p.unidadmedidaid = 'PQ' then   'PK'        
  when p.unidadmedidaid = 'GL' then   'GLL'        
  when p.unidadmedidaid = 'GR' then   'GRM'        
  when p.unidadmedidaid = 'SC' then   'NIU'       
  else 'ERROR-' END + '|' +  --Código de unidad de medida por ítem        
  convert(varchar(23),convert(decimal(12,2),dc.Cantidad))  + '|' + --Cantidad de unidades por ítem        
  dc.ProductoID + '|' + --Código de producto        
  '-'  + '|' + --Codigo producto SUNAT        
  left(p.alias,250) + '|' + --Descripción detallada del servicio prestado, bien vendido o cedido en uso, indicando las características.        
  CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00))   + '|' + --Valor unitario por ítem 
  '0.00'   + '|' +  --Sumatoria Tributos por item
  '9997' + '|' +  --Tributo: Códigos de tipos de tributos IGV (EXONERADO)
'0.00'   + '|' +  --Tributo: Monto de IGV por ítem
CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00))   + '|' +  --Tributo: Base Imponible IGV por Item
'EXO'   + '|' +  --Tributo: Nombre de tributo por item
'VAT'   + '|' +  --Tributo: Código de tipo de tributo por Item
'20'   + '|' +  --Tributo: Afectación al IGV por ítem
'0.00'   + '|' +  --Tributo: Porcentaje de IGV
 

'-'   + '|' + --15	Tributo ISC: Códigos de tipos de tributos ISC
''   + '|' + --16	Tributo ISC: Monto de ISC por ítem
''   + '|' + --17	Tributo ISC: Base Imponible ISC por Item
''   + '|' + --18	Tributo ISC: Nombre de tributo por item
''   + '|' + --19	Tributo ISC: Código de tipo de tributo por Item
''   + '|' + --20	Tributo ISC: Tipo de sistema ISC
''   + '|' + --21	Tributo ISC: Porcentaje de ISC
 

'-'   + '|' + --22	Tributo Otro: Códigos de tipos de tributos OTRO
''   + '|' + --23	Tributo Otro: Monto de tributo OTRO por iItem
''   + '|' + --24	Tributo Otro: Base Imponible de tributo OTRO por Item
''   + '|' + --25	Tributo Otro:  Nombre de tributo OTRO por item
''   + '|' + --26	Tributo Otro: Código de tipo de tributo OTRO por Item
''   + '|' + --27	Tributo Otro: Porcentaje de tributo OTRO por Item
CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00)) + '|' + --28	"Precio de venta unitario cac:InvoiceLine/cac:PricingReference/cac:AlternativeConditionPrice"
CONVERT(varchar(14),(convert(decimal(12,2),dc.Cantidad * dc.PrecioUnitario))) + '|' + --29	Valor de venta por Item cac:InvoiceLine/cbc:LineExtensionAmount
'0.00' + '|'  --30	"Valor REFERENCIAL unitario (gratuitos) "
as COL1  
  FROM Ventas.DetalleComprobante dc        
  INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID        
  inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID        
  inner join [Ventas].[TipoComprobante] as tc on tc.TipoComprobanteID = con.TipoComprobanteID        
  --WHERE dc.ProductoID NOT IN( '00267000102.7','00216000102.7') and        
  WHERE   
    con.ComprobanteId =  @ID    
	 
 
-------------------------------------------------------------------
--TRIBUTOS GENERALES 
 
SELECT @NOMBREARCHIVOTRI = E.RUC + '-' + CASE WHEN C.TipoComprobanteID = 4 THEN '03' ELSE '01'  END + '-' +
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.TRI'  FROM Ventas.Comprobante AS C
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID

 SELECT @NOMBREARCHIVOTRI AS NOMBREARCHIVOTRI
SELECT 
'9997' + '|' + --1	Identificador de tributo
'EXO' + '|' + --2	Nombre de tributo
'VAT' + '|' + --3	Código de tipo de tributo
CONVERT(varchar(14),SUM(ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00))) + '|' + --4	Base imponible
'0.00'   + '|'  --5	Monto de Tirbuto por ítem
as COL1
FROM Ventas.DetalleComprobante dc        
INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID        
inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID        
inner join [Ventas].[TipoComprobante] as tc on tc.TipoComprobanteID = con.TipoComprobanteID        
--WHERE dc.ProductoID NOT IN( '00267000102.7','00216000102.7') and        
WHERE   
con.ComprobanteId =  @ID    

 
-------------------------------------------------------------------
--LEYENDA
SELECT @NOMBREARCHIVOLEY = E.RUC +'-' + CASE WHEN C.TipoComprobanteID = 4 THEN '03' ELSE '01'  END + '-' +
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.LEY'  FROM Ventas.Comprobante AS C
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID
 
 SELECT @NOMBREARCHIVOLEY AS NOMBREARCHIVOLEY
select *  from( 
SELECT 
'1000|' + [dbo].[FN_CantidadConLetraSoles](C.SubTotal + C.TotalIGV) + '|' as COL1
FROM Ventas.Comprobante AS C  WHERE C.ComprobanteId =  @ID

 union

SELECT  '2001|BIENES TRANSFERIDOS EN LA AMAZONÍA REGIÓN SELVA PARA SER CONSUMIDOS EN LA MISMA|' as COL1
) as ttt
 
  
GO


alter table ventas.comprobante add GeneradoTxt bit
go
update ventas.comprobante set GeneradoTxt = 0 where TipoComprobanteID in(4,5)
go
CREATE PROCEDURE Ventas.ObtenerComprobantesGenerar
(
@EmpresaID char(2),
@TipoComprobanteID int, 
@FechaIni date,
@FechaFin date
)
as

select ComprobanteId, NumComprobante from Ventas.Comprobante
where TipoComprobanteID = @TipoComprobanteID and CONVERT(date,AudCrea) between @FechaIni and @FechaFin
and EmpresaID = @EmpresaID and GeneradoTxt = 0

 update  Ventas.Comprobante set GeneradoTxt = 1
where TipoComprobanteID = @TipoComprobanteID and CONVERT(date,AudCrea) between @FechaIni and @FechaFin
and EmpresaID = @EmpresaID and GeneradoTxt = 0
go