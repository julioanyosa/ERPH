alter PROCEDURE [Ventas].[ObtenerTxtFacturadorSunat]  
(  
@ID BIGINT   
)  
as  
--DECLARE @ID BIGINT = 2479196  
--DECLARE @UNIDADRAIZ VARCHAR(500) = '',   
--@NOMBREARCHIVOCAB varchar(250), @NOMBREARCHIVOLEY varchar(250), @NOMBREARCHIVODET varchar(250),  
--@NOMBREARCHIVOTRI varchar(250)  
  
declare @impuestobolsa decimal(18,2)  
  
select @impuestobolsa = CONVERT(decimal(18,2),Valor) from Empresa.GrupoDetalle  
where Descripcion = (select convert(varchar(50), YEAR(AudCrea)) from ventas.Comprobante as C WHERE C.ComprobanteId =  @ID)  
and GrupoId = 1  
  
  
DECLARE @Cadena    varchar(max)   
   
--SELECT @UNIDADRAIZ AS UNIDADRAIZ   
  
CREATE TABLE #CABECERA      
(      
ID INT,      
TEXTO VARCHAR(8000)      
)      
      
CREATE TABLE #DETALLE      
(      
ID INT,      
TEXTO VARCHAR(8000)      
)   
  
  
-------------------------------------------------------------------  
--CABECERA  
INSERT INTO #CABECERA (ID, TEXTO)    
SELECT 1,   E.RUC + '-' + CASE WHEN C.TipoComprobanteID in(1,4) THEN '03' WHEN C.TipoComprobanteID in(2,5) THEN '01'  END + '-' +  
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END  
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.CAB'  FROM Ventas.Comprobante AS C  
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID  
  
INSERT INTO #DETALLE (ID, TEXTO)    
SELECT 1,  
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
CONVERT(VARCHAR(50),convert(decimal(12,2),C.TotalIGV) + isnull(C.TotalICBPER,0.00)) + '|' + --Sumatoria Tributos  
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal)) + '|' +--Total valor de venta   
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV + isnull(C.TotalICBPER,0.00)- ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00))) + '|' +--Total Precio de Venta  
CONVERT(VARCHAR(50), ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00))  + '|' +--Total descuentos  
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
INSERT INTO #CABECERA (ID, TEXTO)    
SELECT 2,  E.RUC + '-' + CASE WHEN C.TipoComprobanteID in(1,4) THEN '03' WHEN C.TipoComprobanteID in(2,5) THEN '01'  END + '-' +  
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END  
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.DET'  FROM Ventas.Comprobante AS C  
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID  
  
INSERT INTO #DETALLE (ID, TEXTO)   
SELECT 2,  
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
 case when con.Esgratuito = 1 then '0.00' else CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00)) end  + '|' + --Valor unitario por ítem   
  '0.00'   + '|' +  --Sumatoria Tributos por item  
 case when con.Esgratuito = 1 then '9996' else '9997' end + '|' +  --Tributo: Códigos de tipos de tributos IGV (GRATUITO 9996) (EXONERADO 9997)  
'0.00'   + '|' +  --Tributo: Monto de IGV por ítem  
CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.TotalVenta),0.00))   + '|' +  --Tributo: Base Imponible IGV por Item  
case when con.Esgratuito = 1 then 'GRA' ELSE 'EXO' END  + '|' +  --Tributo: Nombre de tributo por item  
case when con.Esgratuito = 1 then 'FRE' ELSE 'VAT' END  + '|' +  --Tributo: Código de tipo de tributo por Item  
case when con.Esgratuito = 1 then '21' ELSE '20' END  + '|' +  --Tributo: Afectación al IGV por ítem  
'0.00'   + '|' +  --Tributo: Porcentaje de IGV  
   
   
'-'   + '|' + --15 Tributo ISC: Códigos de tipos de tributos ISC  
''   + '|' + --16 Tributo ISC: Monto de ISC por ítem  
''   + '|' + --17 Tributo ISC: Base Imponible ISC por Item  
''   + '|' + --18 Tributo ISC: Nombre de tributo por item  
''   + '|' + --19 Tributo ISC: Código de tipo de tributo por Item  
''   + '|' + --20 Tributo ISC: Tipo de sistema ISC  
''   + '|' + --21 Tributo ISC: Porcentaje de ISC  
   
  
case when con.TotalICBPER > 0 then '9999' else  '-' end  + '|' + --22 Tributo Otro: Códigos de tipos de tributos OTRO  
case when con.TotalICBPER > 0 then CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.Cantidad * @impuestobolsa),0.00)) else  '' end  + '|' + --23 Tributo Otro: Monto de tributo OTRO por iItem  
case when con.TotalICBPER > 0 then CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.Importe),0.00)) else  '' end   + '|' + --24 Tributo Otro: Base Imponible de tributo OTRO por Item  
case when con.TotalICBPER > 0 then 'OTROS' else  '' end   + '|' + --25 Tributo Otro:  Nombre de tributo OTRO por item  
case when con.TotalICBPER > 0 then 'OTH' else  '' end  + '|' + --26 Tributo Otro: Código de tipo de tributo OTRO por Item  
case when con.TotalICBPER > 0 then '0.00' else  '' end   + '|' + --27 Tributo Otro: Porcentaje de tributo OTRO por Item  
case when con.Esgratuito = 1 then '0.00'   
else CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00)) end + '|' + --28 "Precio de venta unitario cac:InvoiceLine/cac:PricingReference/cac:AlternativeConditionPrice"  
CONVERT(varchar(14),(convert(decimal(12,2),dc.Cantidad * dc.PrecioUnitario))) + '|' + --29 Valor de venta por Item cac:InvoiceLine/cbc:LineExtensionAmount  
case when con.Esgratuito = 1 then  
CONVERT(varchar(14),(convert(decimal(12,2),dc.Cantidad * dc.PrecioUnitario)))  
else '0.00' end + '|'  --30 "Valor REFERENCIAL unitario (gratuitos) "  
as COL1    
  FROM Ventas.DetalleComprobante dc          
  INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID          
  inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID          
  inner join [Ventas].[TipoComprobante] as tc on tc.TipoComprobanteID = con.TipoComprobanteID          
  --WHERE dc.ProductoID NOT IN( '00267000102.7','00216000102.7') and          
  WHERE     
    con.ComprobanteId =  @ID      
    
 --BX|19|9100||Item 1 - Gratuito 9996|0.00|0.00|9996|0.00|190.00|GRA|FRE|21|0.00|-|0.00||ISC|EXC|01|2.00|-||||||0.00|190.00|10.00|  
-------------------------------------------------------------------  
--TRIBUTOS GENERALES   
INSERT INTO #CABECERA (ID, TEXTO)   
SELECT 3, E.RUC + '-' + CASE WHEN C.TipoComprobanteID in(1,4) THEN '03' WHEN C.TipoComprobanteID in(2,5) THEN '01'  END + '-' +  
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END  
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.TRI'  FROM Ventas.Comprobante AS C  
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID  
   
INSERT INTO #DETALLE (ID, TEXTO)  
SELECT 3,  
case when con.Esgratuito = 1 then '9996' else '9997' end + '|' + --1 Identificador de tributo  
case when con.Esgratuito = 1 then 'GRA' ELSE 'EXO' END  + '|' + --2 Nombre de tributo  
case when con.Esgratuito = 1 then 'FRE' ELSE 'VAT' END + '|' + --3 Código de tipo de tributo  
CONVERT(varchar(14),SUM(ISNULL(convert(decimal(12,2),dc.Importe),0.00))) + '|' + --4 Base imponible  
'0.00'   + '|'  --5 Monto de Tirbuto por ítem  
as COL1  
FROM Ventas.DetalleComprobante dc          
INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID          
inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID           
--WHERE dc.ProductoID NOT IN( '00267000102.7','00216000102.7') and          
WHERE     
con.ComprobanteId =  @ID      
group by con.Esgratuito   
  
 if  exists(SELECT *  
FROM Ventas.DetalleComprobante dc                
INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID                
inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID                  
WHERE           
con.ComprobanteId =  @ID    
and dc.ProductoID IN(select Valor from Empresa.GrupoDetalle where GrupoId = 2) )  
begin  
 INSERT INTO #DETALLE (ID, TEXTO)  
 SELECT 3,    
 '9999|' + --1 Identificador de tributo        
 'OTROS|' + --2 Nombre de tributo        
 'OTH|' + --3 Código de tipo de tributo        
 CONVERT(varchar(14),SUM(ISNULL(convert(decimal(12,2),dc.Importe),0.00))) + '|' + --4 Base imponible        
 CONVERT(varchar(14),SUM(ISNULL(convert(decimal(12,2),dc.Cantidad * @impuestobolsa),0.00))) + '|'  --5 Monto de Tirbuto por ítem        
 as COL1        
 FROM Ventas.DetalleComprobante dc                
 INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID                
 inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID                  
 WHERE           
 con.ComprobanteId =  @ID    
 and dc.ProductoID IN(select Valor from Empresa.GrupoDetalle where GrupoId = 2)   
end  
       
-------------------------------------------------------------------  
--LEYENDA  
INSERT INTO #CABECERA (ID, TEXTO)  
SELECT 4, E.RUC +'-' + CASE WHEN C.TipoComprobanteID in(1,4) THEN '03' WHEN C.TipoComprobanteID in(2,5) THEN '01'  END + '-' +  
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END   
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.LEY'  FROM Ventas.Comprobante AS C  
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID  
   
INSERT INTO #DETALLE (ID, TEXTO)  
select 4, ttt.COL1  from(   
SELECT   
'1000|' + [dbo].[FN_CantidadConLetraSoles](C.SubTotal + C.TotalIGV) + '|' as COL1  
FROM Ventas.Comprobante AS C  WHERE C.ComprobanteId =  @ID  
  
 union  
  
SELECT  '2001|BIENES TRANSFERIDOS EN LA AMAZONÍA REGIÓN SELVA PARA SER CONSUMIDOS EN LA MISMA|' as COL1  
) as ttt  
   
  
  
SELECT '' AS RUTA      
SELECT * FROM #CABECERA      
SELECT * FROM #DETALLE    
   
go


--Ventas.GenerarTxtFacturadorSunatResumenDiario '2019-07-13', 'IH', 3 ,1         
alter procedure Ventas.GenerarTxtFacturadorSunatResumenDiario                
(                
@fecha date,                
@EmpresaID char(2),                
@TipoComprobanteID int,          
@FlgEst bit            
)                
as                
declare @Message varchar(500)               
           
             
              
DECLARE @UNIDADRAIZ VARCHAR(500) = 'E:\SFS_v1.2\sunat_archivos\sfs\DATA\'                 
declare @cor int                
declare @CorrelativoFacturadorSunatId int                    
          
              
CREATE TABLE #CABECERA                
(                
ID INT,                
TEXTO VARCHAR(8000)                
)                
                
CREATE TABLE #DETALLE                
(                
ID INT,                
TEXTO VARCHAR(8000)                
)                
       
  if @FlgEst  = 0           
  begin          
          
 --validar que haya bajas          
  if not exists(select *              
 FROM Ventas.Comprobante AS C                 
 WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                
 and c.FlgEst = 0  and GeneradoBajaId is null)              
 begin                
    Select @Message = 'No hay comprobantes anulados para generar del día ' +  convert(varchar(10), @fecha , 103)              
    RaisError(@Message, 16, 1)                
    Return                
 end             
          
  --validar que hayan sido enviados los documentos          
    if (              
 (select count(*)              
 FROM Ventas.Comprobante AS C                 
 WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                
 and c.FlgEst = 0  and GeneradoBajaId is null) !=               
 (select count(*)              
 FROM Ventas.Comprobante AS C                 
 WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                
 and c.FlgEst = 0  and GeneradoBajaId is null and EstadoSunat in('03', '04', '11', '12'))              
 )              
 begin                
    Select @Message = 'alguno de comprobantes aún no han sido enviados a sunat. Fecha: ' +  convert(varchar(10), @fecha , 103)              
    RaisError(@Message, 16, 1)                
    Return                
 end          
          
 --obtener correlativo                
           
 select @cor = max(Correlativo) from                 
 Ventas.CorrelativoFacturadorSunat where EmpresaID = @EmpresaID and Fecha = convert(date,@fecha) and Tipo = 'RC'                
                
 set @cor  = ISNULL(@cor,0) + 1             
           
  INSERT INTO #CABECERA (ID, TEXTO)                
 SELECT 1,   E.RUC + '-RC-' +                
 convert(char(4),YEAR(@fecha)) + right('00' + convert(varchar(2),month(@fecha)),2)                
   + right('00' + convert(varchar(2),day(@fecha)),2)+ '-' + right('000' + convert(varchar(3),@cor),3) + '.RDI' AS NOMBREARCHIVO  FROM  Empresa.Empresa AS E                 
   WHERE   E.EmpresaID = @EmpresaID                
                
 insert into Ventas.CorrelativoFacturadorSunat (EmpresaID,Fecha,Correlativo, Tipo,TipoComprobanteID)                
 values(@EmpresaID,convert(date,@fecha),@cor, 'RC', 10)             
            
               
 set @CorrelativoFacturadorSunatId = SCOPE_IDENTITY()              
           
  INSERT INTO #DETALLE (ID, TEXTO)                
 select top 500 1,                
                
 CONVERT(char(10), C.AudCrea,126) + '|' + --1 Fecha de generación del documento                
 CONVERT(char(10), @fecha,126) + '|' + --2 Fecha de generación del resumen                
 '03' + '|'+ --3 Tipo de documento de resumen (boleta)                
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END  +                 
 SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '|' + --4 Serie y número de documento                
  case                      
  when cL.ClienteID = 0 or cL.ClienteID = 1 or cL.ClienteID = 204 or cL.ClienteID = 241 or cL.ClienteID = 3032 then '0'                    
  else td.TipoContabilidad end   + '|' + --5 Tipo de documento de Identidad del adquirente o usuario                 
  CASE                      
  when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'                      
  else LEFT(cl.NroDocumento,100) end  + '|' + --6 Número de documento del adquirente o usuario                 
  'PEN' + '|' + --7 Tipo de Moneda                
 '0.00' + '|' + --8 Total valor de venta - operaciones gravadas                
 CONVERT(varchar(14),convert(decimal(12,2),c.SubTotal)) + '|' + --9 Total valor de venta - operaciones exoneradas                
 '0.00' + '|' + --10 Total valor de venta - operaciones inafectas                
 '0.00' + '|' + --11 Total valor de venta - operaciones gratuitas                
 '0.00' + '|' + --12 Importe total de sumatoria otros cargos del ítem                
 '0.00' + '|' + --13 Total ISC                
 CONVERT(varchar(14),convert(decimal(12,2),c.TotalIGV)) + '|' + --14 Total IGV                
 case when C.TotalICBPER  > 0 then CONVERT(varchar(14),ISNULL(convert(decimal(12,2),c.TotalICBPER),0.00)) else  '0.00' end + '|' + --15 Total Otros tributos                
  CONVERT(varchar(14),convert(decimal(12,2),c.TotalIGV + c.SubTotal + isnull(c.TotalICBPER,0))) + '|' + --16 Importe total de la venta, cesión en uso o del servicio prestado                
 '' + '|' + --17 Tipo de documento que modifica                
 '' + '|' + --18 Número de serie de la boleta de venta que modifica                
 '' + '|' + --19 Número correlativo de la boleta de venta que modifica                
 '' + '|' + --20 Régimen de percepción                
 '' + '|' + --21 Porcentaje de Percepcion                
 '' + '|' + --22 Base imponible percepción                 
 '' + '|' + --23 Monto de la percepción                
 '' + '|' + --24 "Monto total a cobrar incluida lapercepción"                
 case when c.FlgEst = 0 then '3' when c.FlgEst = 1 then '1' end + '|' --25 Estado                
 as  COL1                
 FROM Ventas.Comprobante AS C                
  INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID                
   INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento                  
              
   WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                
    and GeneradoBajaId is null    and c.FlgEst = 0           
           
                 
   update ventas.Comprobante set GeneradoBajaId = @CorrelativoFacturadorSunatId               
   WHERE ComprobanteId in(        
   select top 500 ComprobanteId from Ventas.Comprobante as C        
    WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                
    and GeneradoBajaId is null    and c.FlgEst = 0          
   )        
  end          
  else          
  begin          
   --validar que haya altas          
  if not exists(select *              
 FROM Ventas.Comprobante AS C                 
 WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                
   and GeneradoAltaId is null)              
 begin                
    Select @Message = 'No hay comprobantes para generar del día ' +  convert(varchar(10), @fecha , 103)              
    RaisError(@Message, 16, 1)                
    Return                
 end            
          
   select @cor = max(Correlativo) from                 
 Ventas.CorrelativoFacturadorSunat where EmpresaID = @EmpresaID and Fecha = convert(date,@fecha) and Tipo = 'RC'                
                
 set @cor  = ISNULL(@cor,0) + 1                
                
 insert into Ventas.CorrelativoFacturadorSunat (EmpresaID,Fecha,Correlativo, Tipo,TipoComprobanteID)                
 values(@EmpresaID,convert(date,@fecha),@cor, 'RC', 10)                
              
 set @CorrelativoFacturadorSunatId = SCOPE_IDENTITY()           
          
  INSERT INTO #CABECERA (ID, TEXTO)                
  SELECT 1,   E.RUC + '-RC-' +                
  convert(char(4),YEAR(@fecha)) + right('00' + convert(varchar(2),month(@fecha)),2)                
  + right('00' + convert(varchar(2),day(@fecha)),2)+ '-' + right('000' + convert(varchar(3),@cor),3) + '.RDI' AS NOMBREARCHIVO  FROM  Empresa.Empresa AS E         
  WHERE   E.EmpresaID = @EmpresaID             
           
 INSERT INTO #DETALLE (ID, TEXTO)                
 select top 500 1,                
                
 CONVERT(char(10), C.AudCrea,126) + '|' + --1 Fecha de generación del documento                
 CONVERT(char(10), @fecha,126) + '|' + --2 Fecha de generación del resumen                
 '03' + '|'+ --3 Tipo de documento de resumen (boleta)                
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'   END +                 
 SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '|' + --4 Serie y número de documento                
  case                      
  when cL.ClienteID = 0 or cL.ClienteID = 1 or cL.ClienteID = 204 or cL.ClienteID = 241 or cL.ClienteID = 3032 then '0'                      
  else td.TipoContabilidad end   + '|' + --5 Tipo de documento de Identidad del adquirente o usuario                 
  CASE                      
  when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'                      
  else LEFT(cl.NroDocumento,100) end  + '|' + --6 Número de documento del adquirente o usuario                 
  'PEN' + '|' + --7 Tipo de Moneda                
 '0.00' + '|' + --8 Total valor de venta - operaciones gravadas                
 CONVERT(varchar(14),convert(decimal(12,2),c.SubTotal)) + '|' + --9 Total valor de venta - operaciones exoneradas                
 '0.00' + '|' + --10 Total valor de venta - operaciones inafectas                
 '0.00' + '|' + --11 Total valor de venta - operaciones gratuitas                
 '0.00' + '|' + --12 Importe total de sumatoria otros cargos del ítem                
 '0.00' + '|' + --13 Total ISC                
 CONVERT(varchar(14),convert(decimal(12,2),c.TotalIGV)) + '|' + --14 Total IGV                
 case when C.TotalICBPER  > 0 then CONVERT(varchar(14),ISNULL(convert(decimal(12,2),c.TotalICBPER),0.00)) else  '0.00' end + '|' + --15 Total Otros tributos                
  CONVERT(varchar(14),convert(decimal(12,2),c.TotalIGV + c.SubTotal + isnull(c.TotalICBPER,0))) + '|' + --16 Importe total de la venta, cesión en uso o del servicio prestado                  
 '' + '|' + --17 Tipo de documento que modifica                
 '' + '|' + --18 Número de serie de la boleta de venta que modifica                
 '' + '|' + --19 Número correlativo de la boleta de venta que modifica                
 '' + '|' + --20 Régimen de percepción                
 '' + '|' + --21 Porcentaje de Percepcion                
 '' + '|' + --22 Base imponible percepción                 
 '' + '|' + --23 Monto de la percepción                
 '' + '|' + --24 "Monto total a cobrar incluida lapercepción"                
 '1'  + '|' --25 Estado      --siempre debe ser uno          
 as  COL1                
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
    and GeneradoAltaId is null            
          
          
 update ventas.Comprobante set GeneradoAltaId = @CorrelativoFacturadorSunatId              
 WHERE  ComprobanteId in(        
 select top 500 C.ComprobanteId FROM Ventas.Comprobante AS C                
   WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                
    and GeneradoAltaId is null           
 )           
end          
          
                
  SELECT @UNIDADRAIZ AS RUTA                
  SELECT * FROM #CABECERA                
  SELECT * FROM #DETALLE                

  go

  --Ventas.ListarEnvioOSE 'IH', '2019-08-05'
alter procedure Ventas.ListarEnvioOSE               
(                
@EmpresaID char(2),                
@Fecha date        
)                
as                
               
       
select    
C.TipoComprobanteID,              
C.ComprobanteId,                
C.NumComprobante,                 
TC.TipoSunat,                
TC.NomTipoComprobante AS TipoComprobante,                
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END              
+ SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) as Comprobante,                
                  
CONVERT(char(10), C.AudCrea,126) as FechaEmision,                 
CONVERT(varchar(10),C.AudCrea,108) as HoraEmision,                
                
case                      
when cL.ClienteID = 0 or cL.ClienteID = 1 or cL.ClienteID = 204 or cL.ClienteID = 241 or cL.ClienteID = 3032 then '0'                      
else td.TipoContabilidad end as tipocliente, ---Tipo de documento de identidadL del adquirente o usuario                      
CASE                      
when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'                      
else LEFT(cl.NroDocumento,100) end  as DocumentoCliente,                       
case                      
when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then 'Clientes Varios'                      
else LEFT(cl.RazonSocial,100) end as RazonSocial,                    
   
                
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV))  as ImporteTotal,                
C.GeneradoTxt, C.MensajeSunat,                
isnull(C.EstadoSunat, '00') as EstadoSunat, isnull(efe.Descripcion,'') as EstadoEnvio,        
C.FechaEnvioSunat                
                 
                 
FROM Ventas.Comprobante AS C                
INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID                
inner JOIN VENTAS.TipoComprobante AS TC ON TC.TipoComprobanteID = C.TipoComprobanteID                
INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento                  
left join Ventas.EstadoFacturacionElectronica as efe on efe.Codigo =  C.EstadoSunat                 
left JOIN                         
(SELECT dc.NumComprobante, dc.TipoComprobanteID, SUM(dc.Importe) AS Importe FROM Ventas.DetalleComprobante dc WHERE dc.ProductoID = '00267000102.7'                        
GROUP BY dc.NumComprobante, dc.TipoComprobanteID) AS Descuento ON Descuento.NumComprobante = C.NumComprobante AND Descuento.TipoComprobanteID = C.TipoComprobanteID                         
where C.EmpresaID = @EmpresaID and convert(date, C.AudCrea) = @Fecha                 
and (c.TipoComprobanteID in(2,5) )            
and isnull(EnviadoSunat,'N') = 'N'        
  
  
   
union all            
          
select     
cs.TipoComprobanteID,          
cs.CorrelativoFacturadorSunatId as ComprobanteId,               
  
cs.Tipo + '-' + convert(varchar(10), year(cs.Fecha))          
+ right('00' + convert(varchar(10),month(cs.fecha)),2)          
+ right('00' + convert(varchar(10),day(cs.fecha)),2) + '-'           
+ right('000' + convert(varchar(10), cs.Correlativo),3) AS NumComprobante,                
           
cs.Tipo as TipoSunat,            case          
when cs.tipo = 'RA' then 'Comunicacion de Baja'          
when cs.tipo = 'RC' then 'Resumen de Boletas' end AS TipoComprobante,           
             
  convert(varchar(10), year(cs.Fecha))          
+ right('00' + convert(varchar(10),month(cs.fecha)),2)          
+ right('00' + convert(varchar(10),day(cs.fecha)),2) + '-'           
+ right('000' + convert(varchar(10),cs.Correlativo),3) AS Comprobante,               
                  
CONVERT(char(10), cs.Fecha,126) as FechaEmision,                 
'00:00' as HoraEmision,                
          
'' as tipocliente, ---Tipo de documento de identidadL del adquirente o usuario                      
'' as DocumentoCliente,           
case          
when cs.tipo = 'RA' then 'Comunicacion de Baja'          
when cs.tipo = 'RC' then 'Resumen de Boletas' end AS RazonSocial,                  
                
'0.00'   as ImporteTotal,                
cs.GeneradoTxt, cs.MensajeSunat,                
isnull(cs.EstadoSunat, '00') as EstadoSunat,          
isnull(efe.Descripcion,'') as EstadoEnvio   ,        
cs.FechaEnvioSunat            
from Ventas.CorrelativoFacturadorSunat as cs          
left join Ventas.EstadoFacturacionElectronica as efe on efe.Codigo =  cs.EstadoSunat              
where cs.EmpresaID = @EmpresaID and cs.Fecha = @Fecha  and                
 cs.TipoComprobanteID in(10,11)             
and  isnull(EnviadoSunat,'N') = 'N'             
go
 
  
    
 alter procedure Ventas.ActualizarDesdeFacturadorSunat        
(        
@EmpresaID char(2),        
@NumComprobante varchar(20),        
@TipoComprobanteID int,        
@fechaenvio datetime,        
@mensaje varchar(500),        
@EstadoSunat char(2),    
@NroTicket varchar(50)    
)        
as     
    
declare @enviadosunat char(1) = null    
declare @GeneradoTxt bit = null  
    
if(@EstadoSunat in('03','04','11','12'))    
begin    
 set @enviadosunat = 'S'    
 set @GeneradoTxt = 1  
end    
    
 if(@TipoComprobanteID in(1,2,4,5))      
 begin      
 update ventas.Comprobante set FechaEnvioSunat = @fechaenvio, MensajeSunat = @mensaje, EstadoSunat = @EstadoSunat,    
 EnviadoSunat = @enviadosunat, GeneradoTxt = @GeneradoTxt  
 where NumComprobante = @NumComprobante and EmpresaID = @EmpresaID and TipoComprobanteID = @TipoComprobanteID        
 end      
 else if(@TipoComprobanteID = 10 or @TipoComprobanteID = 11)      
 begin      
 --RA-20190306-001      
 update ventas.CorrelativoFacturadorSunat set FechaEnvioSunat = @fechaenvio, MensajeSunat = @mensaje, EstadoSunat = @EstadoSunat ,    
 EnviadoSunat = @enviadosunat, NroTicket = @NroTicket          
 where       
 Tipo + '-' + convert(varchar(10), year(Fecha)) + right('00' + convert(varchar(10),month(fecha)),2)      
 + right('00' + convert(varchar(10),day(fecha)),2) + '-' + right('000' + convert(varchar(10), Correlativo),3) = @NumComprobante       
 and EmpresaID = @EmpresaID and TipoComprobanteID = @TipoComprobanteID        
 end      
 go

alter procedure Ventas.ListarFacturadorSunat                    
(                    
@EmpresaID char(2),                    
@FechaIni date,                    
@FechaFin date,                    
@TipoComprobanteId int,                    
@EstadoSunat char(2),                    
@pagenum  int,                    
@pagesize int,                
@tipo smallint                    
)                    
as                    
                    
                     
 if @tipo = 1                
 begin                
WITH C AS                    
(                     
SELECT ROW_NUMBER() OVER(ORDER BY tabla1.NumComprobante) AS rownum,                
tabla1.* from(              
select        
C.TipoComprobanteID,                  
C.ComprobanteId,                    
C.NumComprobante,                     
TC.TipoSunat,                    
TC.NomTipoComprobante AS TipoComprobante,                    
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END                   
+ SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) as Comprobante,                    
                      
CONVERT(char(10), C.AudCrea,126) as FechaEmision,                     
CONVERT(varchar(10),C.AudCrea,108) as HoraEmision,                    
                    
case                          
when cL.ClienteID = 0 or cL.ClienteID = 1 or cL.ClienteID = 204 or cL.ClienteID = 241 or cL.ClienteID = 3032 then '0'                          
else td.TipoContabilidad end as tipocliente, ---Tipo de documento de identidadL del adquirente o usuario                          
CASE                          
when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'                          
else LEFT(cl.NroDocumento,100) end  as DocumentoCliente,                           
case                          
when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then 'Clientes Varios'                          
else LEFT(cl.RazonSocial,100) end as RazonSocial,                        
'PEN' as TipoMoneda,                      
CONVERT(VARCHAR(50),convert(decimal(12,2),C.TotalIGV)) as SumatoriaTributos,                    
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal)) as ValorVenta,                     
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV                     
- ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00))) as PrecioVenta,                    
CONVERT(VARCHAR(50), ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00)) as TotalDescuento,                    
                    
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV))  as ImporteTotal,                    
C.GeneradoTxt, C.MensajeSunat,                    
isnull(C.EstadoSunat, '00') as EstadoSunat, isnull(efe.Descripcion,'') as EstadoEnvio,            
C.FechaEnvioSunat, '' as NroTicket, null as FechaConsultaTicket,    
CASE when C.FlgEst = 0 then 'ANULADO' else '' end as Estado, CFS.FechaConsultaTicket as FechaEnvioAnulacion    
                     
                     
FROM Ventas.Comprobante AS C                    
INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID                    
inner JOIN VENTAS.TipoComprobante AS TC ON TC.TipoComprobanteID = C.TipoComprobanteID                    
INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento                      
left join Ventas.EstadoFacturacionElectronica as efe on efe.Codigo =  C.EstadoSunat       
left join ventas.CorrelativoFacturadorSunat as CFS on CFS.CorrelativoFacturadorSunatId = C.GeneradoBajaId    
                 
left JOIN                             
(SELECT dc.NumComprobante, dc.TipoComprobanteID, SUM(dc.Importe) AS Importe FROM Ventas.DetalleComprobante dc WHERE dc.ProductoID = '00267000102.7'                            
GROUP BY dc.NumComprobante, dc.TipoComprobanteID) AS Descuento ON Descuento.NumComprobante = C.NumComprobante AND Descuento.TipoComprobanteID = C.TipoComprobanteID                             
where C.EmpresaID = @EmpresaID and convert(date, C.AudCrea) between @FechaIni and @FechaFin                     
and (c.TipoComprobanteID = @TipoComprobanteId or (c.TipoComprobanteID in(1,2,4,5) and @TipoComprobanteId = 0))                
and (isnull(c.EstadoSunat,'00') = @EstadoSunat or @EstadoSunat = '  ')                  
              
union all                
              
select         
cs.TipoComprobanteID,              
cs.CorrelativoFacturadorSunatId as ComprobanteId,                 
      
cs.Tipo + '-' + convert(varchar(10), year(cs.Fecha))              
+ right('00' + convert(varchar(10),month(cs.fecha)),2)              
+ right('00' + convert(varchar(10),day(cs.fecha)),2) + '-'               
+ right('000' + convert(varchar(10), cs.Correlativo),3) AS NumComprobante,                    
               
cs.Tipo as TipoSunat,            case              
when cs.tipo = 'RA' then 'Comunicacion de Baja'              
when cs.tipo = 'RC' then 'Resumen de Boletas' end AS TipoComprobante,               
                 
cs.Tipo + '-' + convert(varchar(10), year(cs.Fecha))              
+ right('00' + convert(varchar(10),month(cs.fecha)),2)              
+ right('00' + convert(varchar(10),day(cs.fecha)),2) + '-'               
+ right('000' + convert(varchar(10),cs.Correlativo),3) AS Comprobante,                   
                      
CONVERT(char(10), cs.Fecha,126) as FechaEmision,                     
'00:00' as HoraEmision,                    
              
'' as tipocliente, ---Tipo de documento de identidadL del adquirente o usuario                          
'' as DocumentoCliente,               
case              
when cs.tipo = 'RA' then 'Comunicacion de Baja'              
when cs.tipo = 'RC' then 'Resumen de Boletas' end AS RazonSocial,                      
'PEN' as TipoMoneda,                      
'0.00' as SumatoriaTributos,                    
'0.00'  as ValorVenta,                     
'0.00' as PrecioVenta,                    
'0.00'  as TotalDescuento,                    
'0.00'   as ImporteTotal,                    
cs.GeneradoTxt, cs.MensajeSunat,                    
isnull(cs.EstadoSunat, '00') as EstadoSunat,              
isnull(efe.Descripcion,'') as EstadoEnvio   ,            
cs.FechaEnvioSunat, cs.NroTicket, cs.FechaConsultaTicket, ''  as Estado, null as FechaEnvioAnulacion                
from Ventas.CorrelativoFacturadorSunat as cs              
left join Ventas.EstadoFacturacionElectronica as efe on efe.Codigo =  cs.EstadoSunat                  
where cs.EmpresaID = @EmpresaID and cs.Fecha between @FechaIni and @FechaFin                     
and (cs.TipoComprobanteID = @TipoComprobanteId or (cs.TipoComprobanteID in(10,11) and @TipoComprobanteId = 0))                
and (isnull(cs.EstadoSunat,'00') = @EstadoSunat or @EstadoSunat = '  ')               
) as tabla1              
                 
),                  
     
TotalRegistros  AS                    
(              
select count(t1.col) as Cantidad from(                 
select 1  as col              
FROM Ventas.Comprobante AS C                    
              
where C.EmpresaID = @EmpresaID and convert(date, C.AudCrea) between @FechaIni and @FechaFin                     
and (c.TipoComprobanteID = @TipoComprobanteId or (c.TipoComprobanteID in(4,5) and @TipoComprobanteId = 0))                
and (isnull(c.EstadoSunat,'00') = @EstadoSunat or @EstadoSunat = '  ')               
                
union all               
select 2 as col              
from Ventas.CorrelativoFacturadorSunat as cs              
left join Ventas.EstadoFacturacionElectronica as efe on efe.Codigo =  cs.EstadoSunat                  
where cs.EmpresaID = @EmpresaID and cs.Fecha between @FechaIni and @FechaFin                     
and (cs.TipoComprobanteID = @TipoComprobanteId or (cs.TipoComprobanteID in(10,11) and @TipoComprobanteId = 0))                
and (isnull(cs.EstadoSunat,'00') = @EstadoSunat or @EstadoSunat = '  ')               
) as t1       
)                     
SELECT * ,(select Cantidad from TotalRegistros) as Cantidad                  
FROM C                    
WHERE rownum BETWEEN (@pagenum - 1) * @pagesize + 1 AND @pagenum * @pagesize ORDER BY NumComprobante ;                  
                   
end               
                
else if @tipo = 2                
begin                
select                  
C.AudCrea as Fecha,                  
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END  +                  
SUBSTRING(C.NumComprobante,3,3)  as Serie,                  
'''0' + RIGHT(C.NumComprobante,7) as Numero,                  
TC.NomTipoComprobante,                  
CASE                        
when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'                        
else '''' + LEFT(cl.NroDocumento,100) end  as NroDocumentoCliente,                  
case                            
when c.ClienteID = 0 or c.ClienteID = 1 or c.ClienteID = 204 or c.ClienteID = 241 or c.ClienteID = 3032 then 'CLIENTE VARIOS'                            
else LEFT(cl.RazonSocial,500) end  as RazonSocialCliente,                 
convert(decimal(12,2),C.TotalIGV + C.SubTotal) as ImporteTotal,                
isnull('''' +efe.Codigo, '''00') as [Codigo sunat] ,                
isnull(efe.Descripcion, 'Sin Estado')  as [Estado Sunat],                
C.MensajeSunat,          
c.FechaEnvioSunat,  
case when isnull(c.GeneradoTxt,0 )= 0 then 'NO' else 'SI' end as [Generado TXT]                
                  
from ventas.Comprobante as C                  
inner join ventas.TipoComprobante as TC on TC.TipoComprobanteID  = c.TipoComprobanteID                  
INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID                  
left join ventas.EstadoFacturacionElectronica as efe on efe.Codigo = c.EstadoSunat                
where C.EmpresaID = @EmpresaID and CONVERT(date,c.AudCrea) between @FechaIni and @FechaFin                  
and (isnull(c.EstadoSunat,'00') = @EstadoSunat or @EstadoSunat = '  ')                
and (c.TipoComprobanteID = @TipoComprobanteId or (c.TipoComprobanteID in(4,5) and @TipoComprobanteId = 0))                
order by NomTipoComprobante, Serie, Numero                  
end                    
go


alter procedure Ventas.ActualizarTicketBaja  
(  
@id int,  
@mensaje varchar(500)  
)  
as  
declare @fecha datetime = getdate()  
declare @fechaenvio datetime;  
select @fechaenvio = FechaEnvioSunat from ventas.CorrelativoFacturadorSunat  
where CorrelativoFacturadorSunatId = @id  
  
update Ventas.CorrelativoFacturadorSunat set EnviadoSunat = 'S', MensajeSunat = @mensaje,  
FechaConsultaTicket = @fecha  
where CorrelativoFacturadorSunatId = @id  
  
update ventas.Comprobante set EnviadoSunat = 'S' , MensajeSunat = @mensaje,   
FechaEnvioSunat = @fechaenvio, FechaAltaSunat = @fechaenvio, EstadoSunat = '03'  
where GeneradoAltaId = @id  
  
update ventas.Comprobante set EnviadoSunat = 'S'  , MensajeSunat = @mensaje,  
FechaBajaSunat = @fechaenvio  
where GeneradoBajaId = @id  
  
--adicionalmente obtenemos informacion de las boletas enviadas para eliminarlas del facturador sunat  
select 
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END  +         
SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) as Comprobante, TC.TipoSunat   
from  ventas.Comprobante as C  
inner JOIN VENTAS.TipoComprobante AS TC ON TC.TipoComprobanteID = C.TipoComprobanteID         
where GeneradoAltaId = @id  
  
  
  go


alter procedure Ventas.GenerarTxtFacturadorSunatComunicacionBaja        
(         
@EmpresaID char(2),        
@NumComprobante CHAR(13),        
@MotivoBaja varchar(100)        
)        
as      
      
declare @Message varchar(500)       
      
if not exists(select *      
FROM Ventas.Comprobante AS C         
WHERE NumComprobante = @NumComprobante AND EmpresaID = @EmpresaID AND TipoComprobanteID = 5       
 and c.FlgEst = 0  and GeneradoBajaId is null)      
begin        
   Select @Message = 'No está anulada la factura '        
   RaisError(@Message, 16, 1)        
   Return        
end        
      
if (      
(select count(*)      
FROM Ventas.Comprobante AS C         
WHERE NumComprobante = @NumComprobante AND EmpresaID = @EmpresaID AND TipoComprobanteID = 5       
 and c.FlgEst = 0  and GeneradoBajaId is null) !=       
(select count(*)      
FROM Ventas.Comprobante AS C         
WHERE NumComprobante = @NumComprobante AND EmpresaID = @EmpresaID AND TipoComprobanteID = 5       
 and FlgEst = 0  and GeneradoBajaId is null and EstadoSunat in('03', '04', '05', '11', '12'))      
)      
begin        
   Select @Message = 'la factura no ha sido enviado a sunat.'       
   RaisError(@Message, 16, 1)        
   Return        
end        
       
DECLARE @UNIDADRAIZ VARCHAR(500) = 'E:\SFS_v1.2\sunat_archivos\sfs\DATA\'         
         
--obtener correlativo        
declare @cor int      
declare @CorrelativoFacturadorSunatId int      
      
select @cor = max(Correlativo) from         
Ventas.CorrelativoFacturadorSunat where EmpresaID = @EmpresaID and Fecha = convert(date,GETDATE()) and Tipo = 'RA'        
        
set @cor  = ISNULL(@cor,0) + 1        
        
insert into Ventas.CorrelativoFacturadorSunat (EmpresaID,Fecha,Correlativo, Tipo, TipoComprobanteID)        
values(@EmpresaID,convert(date,GETDATE()),@cor, 'RA',11)        
      
set @CorrelativoFacturadorSunatId = SCOPE_IDENTITY()      
      
      
CREATE TABLE #CABECERA        
(        
ID INT,        
TEXTO VARCHAR(8000)        
)        
        
CREATE TABLE #DETALLE        
(        
ID INT,        
TEXTO VARCHAR(8000)        
)        
        
INSERT INTO #CABECERA (ID, TEXTO)        
SELECT 1,   E.RUC + '-RA-' +        
convert(char(4),YEAR(getdate())) + right('00' + convert(varchar(2),month(getdate())),2)        
  + right('00' + convert(varchar(2),day(getdate())),2)+ '-' + right('000' + convert(varchar(3),@cor),3) + '.CBA' AS NOMBREARCHIVO  FROM  Empresa.Empresa AS E         
  WHERE   E.EmpresaID = @EmpresaID          
        
          
INSERT INTO #DETALLE (ID, TEXTO)        
SELECT 1,        
CONVERT(char(10), C.AudCrea,126) + '|' + --1 Fecha de generación del documento        
CONVERT(char(10), getdate(),126) + '|' + --2 Fecha de generación del resumen        
'01'+ '|' +  --Tipo de documento de baja        
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END  +         
SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '|' + --Número de documento de baja        
@MotivoBaja + '|' --Descripción de motivo de baja        
FROM VENTAS.Comprobante AS C WHERE NumComprobante = @NumComprobante AND EmpresaID = @EmpresaID AND TipoComprobanteID = 5       
 and c.FlgEst = 0  and GeneradoBajaId is null       
      
  update ventas.Comprobante set GeneradoBajaId = @CorrelativoFacturadorSunatId     
  WHERE NumComprobante = @NumComprobante AND EmpresaID = @EmpresaID AND TipoComprobanteID = 5  and FlgEst = 0 and GeneradoBajaId is null      
       
          
  SELECT @UNIDADRAIZ AS RUTA        
  SELECT * FROM #CABECERA        
  SELECT * FROM #DETALLE        
  go