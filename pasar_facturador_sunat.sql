   
--Ventas.ObtenerDatosCliente '20302186'    
alter procedure Ventas.ObtenerDatosCliente    
(    
@RUC VARCHAR(11)    
)    
as    
if exists(SELECT top 1 *  FROM VENTAS.Cliente WHERE NroDocumento like @RUC + '%')    
begin    
 SELECT top 15 ClienteID, TipoClienteID, IDTipoDocumento,NroDocumento, RazonSocial, Direccion,     
 NombreVia, DireccionNumero, DireccionInterior,     
 DistritoId,ProvinciaId,DepartamentoId,'' as ESTADO, '' as CONDICION_DE_DOMICILIO, 'CLIENTE' AS FUENTE FROM VENTAS.Cliente WHERE NroDocumento like @RUC + '%' 
end    
else    
begin    
 SELECT 0 as ClienteID, 2 as TipoClienteID, 1 as IDTipoDocumento, RUC as NroDocumento, RAZON_SOCIAL as RazonSocial,     
 EA.TIPO_DE_VIA + ' ' + EA.NOMBRE_DE_VIA   +    
 CASE WHEN EA.NUMERO <> '-' THEN ' NUM. ' + EA.NUMERO ELSE '' END +     
 CASE WHEN EA.INTERIOR <> '-' THEN ' INTER. ' + EA.INTERIOR ELSE '' END +     
 CASE WHEN EA.LOTE <> '-' THEN ' LOTE. ' + EA.LOTE ELSE '' END +     
 CASE WHEN EA.DEPARTAMENTO <> '-' THEN ' DEP. ' + EA.DEPARTAMENTO ELSE '' END +      
 CASE WHEN EA.MANZANA <> '-' THEN ' MZ. ' + EA.MANZANA ELSE '' END +     
 CASE WHEN EA.[KILÓMETRO] <> '-' THEN ' KM. ' + EA.[KILÓMETRO] ELSE '' END +      
 CASE WHEN EA.CODIGO_DE_ZONA <> '-' THEN ' ZONA: ' + EA.CODIGO_DE_ZONA ELSE '' END +     
 CASE WHEN EA.TIPO_DE_ZONA <> '-' THEN ' ' + EA.TIPO_DE_ZONA ELSE '' END  AS  Direccion,    
 CASE WHEN EA.NOMBRE_DE_VIA <> '-' THEN   EA.NOMBRE_DE_VIA ELSE '' END  as NombreVia,    
 CASE WHEN EA.NUMERO <> '-' THEN   EA.NUMERO ELSE '' END  as DireccionNumero,    
 CASE WHEN EA.INTERIOR <> '-' THEN   EA.INTERIOR ELSE '' END  as DireccionInterior,     
   DIST.DistritoId,PROV.ProvinciaId,DEP.DepartamentoId, EA.ESTADO, EA.CONDICION_DE_DOMICILIO, 'PADRON' AS FUENTE FROM DBO.EMPRESAS_ACTIVAS AS EA     
 INNER JOIN EMPRESA.Departamento AS DEP ON DEP.Codigo = LEFT(EA.UBIGEO,2)    
 INNER JOIN EMPRESA.Provincia AS PROV ON PROV.Codigo = LEFT(EA.UBIGEO,4)      
 INNER JOIN EMPRESA.Distrito AS DIST ON DIST.Codigo =  EA.UBIGEO     
 WHERE EA.RUC like @RUC + '%'    
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
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END                
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
and (c.TipoComprobanteID = @TipoComprobanteId or (c.TipoComprobanteID in(4,5) and @TipoComprobanteId = 0))            
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
c.FechaEnvioSunat            
              
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
