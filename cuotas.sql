use [ERP_HALLEYnuevo31-05-2017]
go

select * from ventas.Cuota
select * from Ventas.Comprobante where ComprobanteId =2509351



create table ventas.Cuota
(
int_IdCuota int primary key identity(1,1), 
EmpresaID char(2) ,
bint_IdComprobante bigint ,
int_NroCuota smallint ,
dec_MontoCuota decimal(18,2) ,
dat_FechaPagar date ,
bit_Activo tinyint ,
int_IdUsuario int ,
datt_FechaRegistro datetime ,
bit_Pagado tinyint ,
int_IdUsuarioPago int, 
dat_FechaPago datetime, 
int_IdCliente int
)
go

CREATE NONCLUSTERED INDEX IDX_Ventas_Comprobante_ClienteID_TipoVentaID_FlgEst_AudCrea
ON [Ventas].[Comprobante] ([ClienteID],[TipoVentaID],[FlgEst],[AudCrea])
INCLUDE ([TipoPagoID],[ComprobanteId],[MontoTotal])
GO

CREATE NONCLUSTERED INDEX IDX_Ventas_Pago_NumComprobante_TipoComprobanteID
ON [Ventas].[Pago] ([NumComprobante],[TipoComprobanteID])
INCLUDE ([Importe])

CREATE NONCLUSTERED INDEX IDX_Ventas_NotaIngreso_NotaIngresoID
ON [Ventas].[NotaIngreso] ([NotaIngresoID])
INCLUDE ([Observacion],[LugarPago])
GO

--ventas.Usp_GetCuotas 'AH002-0000024', 4
create or alter procedure ventas.Usp_GetCuotas
(
 @NumComprobante char(13),  
 @TipoComprobanteID tinyint  
)
as
begin
select
cu.int_IdCuota, cu.int_NroCuota, cu.dec_MontoCuota, cu.dat_FechaPagar, 
case when cu.bit_Pagado = 1 then 'PAGADO' else 'PENDIENTE DE PAGO' end as str_estadoPago, cu.dat_FechaPago,
usu.Descripcion, cu.bit_Pagado
from Ventas.Cuota as cu
inner join Ventas.Comprobante as c on c.ComprobanteId = cu.bint_IdComprobante
left join Usuario.Usuario as usu on usu.UserID = cu.int_IdUsuarioPago
where c.NumComprobante = @NumComprobante and c.TipoComprobanteID = @TipoComprobanteID and cu.bit_Activo = 1;
end
go


Create or alter procedure ventas.Usp_AdministrarCuota
(
@EmpresaID char(2),
@bint_IdComprobante bigint,
@int_IdUsuario int,
@int_IdCliente int,
@XMLDetalle    xml,
@NumComprobante char(13),
@TipoComprobanteID tinyint,
@FormaPagoID tinyint
)
as
begin
	declare @fecha datetime = getdate();
	DECLARE @hDoc int  
	Exec sp_xml_preparedocument @hDoc OUTPUT,@XMLDetalle 
  
  --************ ingresar cuota cuota *****************  
	Insert Into Ventas.Cuota            
	(            
	EmpresaID,  bint_IdComprobante, int_NroCuota, dec_MontoCuota, dat_FechaPagar, int_IdUsuario, datt_FechaRegistro, 
	bit_Pagado, bit_Activo, int_IdCliente, int_IdUsuarioPago, dat_FechaPago
	)            
	Select            
	@EmpresaID,  @bint_IdComprobante, int_NroCuota, dec_MontoCuota, dat_FechaPagar, @int_IdUsuario, @fecha,
	bit_Pagado, 1, @int_IdCliente, case when bit_Pagado = 1 then @int_IdUsuario else null end, case when bit_Pagado = 1 then @fecha else null end
	FROM OPENXML(@hDoc, '/DocumentElement/Cuota')            
	WITH            
	(           
	int_IdCuota int 'int_IdCuota',
	int_NroCuota  int  'int_NroCuota',            
	dec_MontoCuota  decimal(18,2) 'dec_MontoCuota',            
	dat_FechaPagar datetime 'dat_FechaPagar',
	bit_Pagado int  'bit_Pagado' 
	)XMLCuotas Where  int_IdCuota = 0;
 
	--************ Actualizar cuota *****************            
	Update C          
	Set             
	C.dec_MontoCuota=XmlCuota.dec_MontoCuota,            
	C.dat_FechaPagar=XmlCuota.dat_FechaPagar    
	FROM OPENXML(@hDoc, '/DocumentElement/Cuota')             
	WITH            
	(            
	int_IdCuota int 'int_IdCuota',
	int_NroCuota  int  'int_NroCuota',            
	dec_MontoCuota  decimal(18,2) 'dec_MontoCuota',            
	dat_FechaPagar datetime 'dat_FechaPagar',
	bit_Pagado int  'bit_Pagado'              
	) XmlCuota 
	inner join Ventas.Cuota as C on C.int_IdCuota = XmlCuota.int_IdCuota and XmlCuota.bit_Pagado = 0 and XmlCuota.int_IdCuota != 0;

	  --************ ingresar Pago *****************  
	Insert Into  Ventas.Pago         
	(            
	[NumComprobante], [TipoComprobanteID], [Importe], [FormaPagoID], [UsuarioID], [AudCrea]
	)            
	Select            
	@NumComprobante,  @TipoComprobanteID, dec_MontoCuota, @FormaPagoID, @int_IdUsuario, @fecha
	FROM OPENXML(@hDoc, '/DocumentElement/Cuota')            
	WITH            
	(           
	int_IdCuota int 'int_IdCuota',
	int_NroCuota  int  'int_NroCuota',            
	dec_MontoCuota  decimal(18,2) 'dec_MontoCuota',            
	dat_FechaPagar datetime 'dat_FechaPagar',
	bit_Pagado int  'bit_Pagado' 
	)XMLCuotas Where  int_IdCuota != 0 and bit_Pagado = 1;

		--************ Actualizar pago cuota *****************            
	Update C          
	Set      
	C.int_IdUsuarioPago=@int_IdUsuario,            
	C.bit_Pagado = XmlCuota.bit_Pagado,
	C.dat_FechaPago = @fecha
	FROM OPENXML(@hDoc, '/DocumentElement/Cuota')             
	WITH            
	(            
	int_IdCuota int 'int_IdCuota',
	int_NroCuota  int  'int_NroCuota',            
	dec_MontoCuota  decimal(18,2) 'dec_MontoCuota',            
	dat_FechaPagar datetime 'dat_FechaPagar',
	bit_Pagado int  'bit_Pagado'              
	) XmlCuota 
	inner join Ventas.Cuota as C on C.int_IdCuota = XmlCuota.int_IdCuota and XmlCuota.bit_Pagado = 1
	where XmlCuota.int_IdCuota != 0;

      
             
	EXEC sp_xml_removedocument @hDoc           
end
go  


 --[Ventas].[Usp_GetCreditosCliente]  204,'A'
 /************************************************************************************************************  
Autor  : Julio Cesar Anyosa Candela  
Fecha  : 18/10/2011  
Descripción : Traer los creditos del cliente  
     
*************************************************************************************************************/  
CREATE or alter Procedure [Ventas].[Usp_GetCreditosCliente]   
(  
 @ClienteID int,  
 @Tipo  char(1)  
)  
As  
Begin  
if @Tipo = 'A'--activos  
Begin  
 Select CreditoID, ClienteID, NomCampanha, LineaCredito,CreditoDisponible,  
 DiasFinanciar, NumDeclaracionJurada, FechaInicio, EstadoID , AudCrea, CreditoDisponible,  
 DATEADD(d,DiasFinanciar, FechaInicio) AS FechaVencimiento  
 from Ventas.Credito  
 where ClienteID = @ClienteID  
 and convert(date, getdate()) <= convert(date,DATEADD(D,DiasFinanciar,FechaInicio))--esta es la fehca de vencimiento  
 and EstadoID = 0  
 order by FechaVencimiento desc  
End  
else if @Tipo = 'T'--todos, activos y no activos  
Begin  
 Select CreditoID, ClienteID, NomCampanha, LineaCredito,CreditoDisponible,  
 DiasFinanciar, NumDeclaracionJurada, FechaInicio, EstadoID , AudCrea, CreditoDisponible,  
 DATEADD(d,DiasFinanciar, FechaInicio) AS FechaVencimiento  
 from Ventas.Credito  
 where ClienteID = @ClienteID  
 order by FechaVencimiento desc  
  
End  
  
End
go

/************************************************************************************************************  
Autor  : Julio Cesar Anyosa Candela  
Fecha  : 20/10/2011  
Descripción : Traer los pagos amarrados a una boleta  
   [Ventas].[Usp_GetCreditosTotal]   5685  
     
*************************************************************************************************************/  
alter Procedure [Ventas].[Usp_GetCreditosTotal]   
(  
 --Deudas por credito  
 @ClienteID int  
)  
As  
Begin  
 declare @TotalCredito decimal(12,3)  
 declare @TotalPagado decimal(12,3)  
   
 Select @TotalCredito = sum(MontoTotal) from Ventas.Comprobante where CreditoID in(select CreditoID from Ventas.Credito  
 where ClienteID = @ClienteID and EstadoID = 0)--ESTADO PLANEADO  
   
 --total pagado  
 --Select @TotalPagado = sum(Importe) from Ventas.Pago where cast(TipoComprobanteID as CHAR(1)) + NumComprobante in(select cast(TipoComprobanteID as CHAR(1)) + NumComprobante from Ventas.Comprobante  
 --where CreditoID in(select CreditoID from Ventas.Credito where ClienteID =@ClienteID and EstadoID = 0)) --ESTADO PLANEADO  

  Select @TotalPagado = sum(pag.Importe) from Ventas.Pago  as pag
  inner join Ventas.Comprobante as c on c.NumComprobante = pag.NumComprobante and pag.TipoComprobanteID = c.TipoComprobanteID
  inner join Ventas.Credito as cre on c.CreditoID = c.CreditoID
 where c.CreditoID in(select CreditoID from Ventas.Credito where ClienteID =@ClienteID and EstadoID = 0) --ESTADO PLANEADO  
   
 select isnull(@TotalCredito,0) as TotalCredito, isnull(@TotalPagado,0) as TotalPagado  
  
End  
go

/************************************************************************************************************  
Autor  : Julio Cesar Anyosa Candela  
Fecha  : 07/12/2011  
Descripción : traer el numero de terminales  
[Ventas].[Usp_GetComprobantesCliente] 4215, '01/12/2011', '31/12/2011', 1  
*************************************************************************************************************/  
alter Procedure [Ventas].[Usp_GetComprobantesCliente]  
(  
 @ClienteID int,  
 @FechaIni smalldatetime,  
 @FechaFin smalldatetime,  
 @TipoVentaID int,
 @FormaPagoID int --usar 1 para credito y 2 para contado, 0 para ambos
)  
As  
SELECT T1.NumComprobante,T1.str_ID,
T1.TipoComprobanteID, T1.NomTipoComprobante, T1.AudCrea, T1.ComprobanteId, T1.MontoTotal, SUM(T1.Importe) as Importe
from
(
SELECT C.NumComprobante,
        CASE      
		WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'      
		WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END                         
		+ SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) as str_ID,
C.TipoComprobanteID, TC.NomTipoComprobante, C.AudCrea, C.ComprobanteId, p.Importe, C.MontoTotal
FROM Ventas.Comprobante as C  
inner join Ventas.TipoComprobante as TC on TC.TipoComprobanteID = C.TipoComprobanteID
left join Ventas.Pago as p on p.NumComprobante = C.NumComprobante and p.TipoComprobanteID = C.TipoComprobanteID 
where C.ClienteID = @ClienteID  
and C.TipoVentaID = @TipoVentaID
and (TipoPagoID = @FormaPagoID or @FormaPagoID = 0)
And C.AudCrea between @FechaIni and @FechaFin
and C.FlgEst = 1
) as T1
group by T1.NumComprobante, T1.str_ID, T1.TipoComprobanteID, T1.NomTipoComprobante, T1.AudCrea, T1.ComprobanteId, T1.MontoTotal
order by t1.NumComprobante desc
go

/************************************************************************************************************  
Autor  : Julio Cesar Anyosa Candela  
Fecha  : 20/10/2011  
Descripción : Traer los pagos amarrados a una boleta  
   [Ventas].[Usp_GetPagosBoleta] 'GH011-0004723',1  
*************************************************************************************************************/  
alter Procedure [Ventas].[Usp_GetPagosBoleta]   
(  
 @NumComprobante char(13),  
 @TipoComprobanteID tinyint  
)  
As  
Begin  
Set Nocount On  
 --indexar por numcomprobante  
 Select PagoID, isnull(Observacion,'Al contado') as Observacion, 
 LugarPago, isnull(SE.NomSede,'Venta normal') as NomSede, PA.Importe, 
 PA.FormaPagoID, FP.NomFormaPago, PA.AudCrea  
 from Ventas.Pago as  PA  
 left Join Ventas.NotaIngreso as NI on PA.NotaIngresoID = NI.NotaIngresoID  
 left Join Empresa.Sede as SE on SE.SedeID = NI.LugarPago  
 inner join Ventas.FormaPago as FP On FP.FormaPagoID = PA.FormaPagoID  
 where PA.NumComprobante = @NumComprobante  
 and PA.TipoComprobanteID = @TipoComprobanteID  order by PA.AudCrea
   
 Select (C.MontoTotal) as TotalPagar, AudCrea  
 from Ventas.Comprobante as  C  
 where C.NumComprobante = @NumComprobante  
 and C.TipoComprobanteID = @TipoComprobanteID  
Set Nocount Off  
End  
go


/************************************************************************************************************    
Autor  : Julio Anyosa    
Fecha  : 21/10/2011    
Descripción : Insertar Pago    
        
*************************************************************************************************************/    
alter Procedure [Ventas].[Usp_InsertPago2]    
(    
 @EmpresaID char(2),    
 @FormaPagoID tinyint,    
 @Tipo char(1),    
 @Numcaja int,    
 @Observacion varchar(200),    
 @NumComprobante char(13),    
 @TipoComprobanteID tinyint,    
 @LugarPago char(5),    
 @Importe decimal(12,3),    
 @ClienteID int,    
 @Estado tinyint,    
 @UsuarioID int,    
     
 @EstadoID int,  
 @Serie char(3) = null,  
 @Numero char(7) = null,
 @int_IdCuota int = 0
)    
As    
Begin    
declare @NotaIngresoID int    
 Set Nocount On    
  --Verificar si el pago es aceptado    
  if @Tipo = 'I'    
  Begin    
   Insert Into Ventas.NotaIngreso    
   (    
    EmpresaID,FormaPagoID,Tipo,Numcaja,Observacion,LugarPago,Importe,ClienteID,Estado,UsuarioID,AudCrea    
   )    
   values    
   (    
    @EmpresaID, @FormaPagoID, @Tipo, @Numcaja, @Observacion, @LugarPago, @Importe, @ClienteID, @Estado, @UsuarioID, GETDATE()  
   )    
       
   select @NotaIngresoID = SCOPE_IDENTITY()    
      
    
   Insert Into Ventas.Pago    
   (    
    NotaIngresoID, NumComprobante, TipoComprobanteID, Importe, FormaPagoID, UsuarioID, AudCrea    
   )    
   Values    
   (    
    @NotaIngresoID, @NumComprobante, @TipoComprobanteID, @Importe, @FormaPagoID, @UsuarioID, GETDATE()    
   )

   --actualizar la cuota
   if @int_IdCuota != 0 and @int_IdCuota is not null
   begin
	   update Ventas.Cuota set bit_Pagado = 1, dat_FechaPago = GETDATE(), int_IdUsuarioPago = @UsuarioID
	   where int_IdCuota = @int_IdCuota;
   end

   --Actualizar el estado del comprobante    
   update Ventas.Comprobante    
   set    
    EstadoID = @EstadoID,    
    AudModifica = GETDATE(),    
    UsuarioIDM = @UsuarioID    
   Where    
   NumComprobante = @NumComprobante    
   and TipoComprobanteID = @TipoComprobanteID    
  End    
  Else if @Tipo = 'C'    
   Begin    
    IF EXISTS(SELECT NotaIngresoID FROM Ventas.NotaIngreso    
    WHERE EmpresaID = @EmpresaID    
    and Numcaja = @Numcaja    
    and UsuarioID = @UsuarioID    
    and Tipo= @Tipo    
    and LugarPago = @LugarPago    
    and Convert(Char(8), AudCrea, 101) = Convert(Char(8), GETDATE(), 101))    
    Begin    
     declare @Message varchar(200)    
     Select @Message = 'Ya ha sido ingresado el monto de apertura de caja en este dìa'    
     RaisError(@Message, 16, 1)    
     Return    
    End    
    else    
    Begin    
     Insert Into Ventas.NotaIngreso    
     (    
      EmpresaID, FormaPagoID, Tipo, Numcaja, Observacion, LugarPago, Importe, ClienteID, Estado, UsuarioID, AudCrea    
     )    
     values    
     (  
      @EmpresaID, @FormaPagoID, @Tipo, @Numcaja, @Observacion, @LugarPago, @Importe, @ClienteID, @Estado, @UsuarioID, GETDATE()    
     )    
         
     select @NotaIngresoID = SCOPE_IDENTITY()    
      End    
   End    
  Else    
  Begin    
  if not exists(select * from ventas.NotaIngreso where Serie = @Serie and Numero = @Numero and EmpresaID = @EmpresaID)  
  begin  
    Insert Into Ventas.NotaIngreso    
    (    
  EmpresaID, FormaPagoID, Tipo, Numcaja, Observacion, LugarPago, Importe, ClienteID, Estado, UsuarioID, AudCrea, Serie, Numero    
    )    
    values    
    (    
  @EmpresaID, @FormaPagoID, @Tipo, @Numcaja, @Observacion, @LugarPago, @Importe, @ClienteID, @Estado, @UsuarioID, GETDATE(), @Serie, @Numero    
    )    
       
    select @NotaIngresoID = SCOPE_IDENTITY()    
   end  
   else  
   begin  
  raiserror('El recibo de ingreso ya existe.', 16,1);  
   end  
  End    
  --devolver el id de pago    
  select @NotaIngresoID    
 Set Nocount Off    
End    

go

select  ComprobanteId,* from Ventas.Comprobante where AudCrea >= '2021-09-19' 
--  ventas.proc_DatosComprobante 2509369, 'AH', '01'



alter procedure Ventas.ObtenerParaImpresion              
(              
@ComprobanteId bigint              
)              
as              
select              
C.AudCrea,C.TipoComprobanteID,c.NumComprobante, c.MontoTotal as Monto,              
c.TotalIGV,emp.RUC,emp.NomEmpresa,vt.Descripcion as NomCaja,C.EmpresaID,              
 CASE                      
  when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'                      
  else   LEFT(cl.NroDocumento,100) end  as NroDocumentoCliente,                
   case                          
  when c.ClienteID = 0 or c.ClienteID = 1 or c.ClienteID = 204 or c.ClienteID = 241 or c.ClienteID = 3032 then 'CLIENTE VARIOS'                          
  else LEFT(cl.RazonSocial,500) end  as RazonSocialCliente,               
cl.Direccion as DireccionCliente, isnull(C.TotalICBPER ,0) as TotalICBPER, pagado.MontoPagado, C.TipoPagoID           
from ventas.Comprobante C              
inner join Empresa.Empresa as emp on emp.EmpresaID = c.EmpresaID              
inner join Ventas.Terminal as vt on vt.Numcaja  = C.NumCaja              
 INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID          
 inner join (select sum(pag.Importe) as MontoPagado, @ComprobanteId as ComprobanteId  from ventas.Pago as pag        
 inner join ventas.Comprobante as comp on comp.NumComprobante = pag.NumComprobante and pag.TipoComprobanteID = comp.TipoComprobanteID        
 where comp.ComprobanteId = @ComprobanteId)        
 as pagado  on pagado.ComprobanteId = c.ComprobanteId        
where C.ComprobanteId = @ComprobanteId              
              
select    dc.ProductoID,           
dc.Cantidad,pro.UnidadMedidaID,pro.Alias, dc.PrecioUnitario,dc.Importe              
from ventas.Comprobante C              
inner join Ventas.DetalleComprobante as dc on dc.TipoComprobanteID = c.TipoComprobanteID              
and dc.NumComprobante = c.NumComprobante              
inner join Producto.Producto as pro on pro.ProductoID = dc.ProductoID              
where C.ComprobanteId = @ComprobanteId              
 go



--[ventas].[usp_GetDetalleVentasComprobante3] '2019-01-01','2019-03-21',    
alter Procedure [Ventas].[usp_GetDetalleVentasComprobante3]          
(          
 @FechaIni smalldatetime,          
 @FechaFin smalldatetime,          
 @Cajero  int,          
 @EmpresaID char(2),          
 @SedeID  char(5)          
)          
As          
Begin          
   select          
    N.AudCrea   as AudCrea,          
  Serie,       
   isnull(Serie + '-' + Numero, convert(varchar(13),N.NotaIngresoID)) as NumComprobante,          
    Case N.Tipo          
    when 'C'          
     then '*SALDO INICIAL'          
    when 'A'          
     then '*INGRESO'          
    when 'E'          
     then '*EGRESO'          
    end as NomTipoComprobante,          
    N.Importe   as TotalComprobante,          
    N.Importe   as Pagado,          
    'PAGADO'   as NomEstado,          
    'EFECTIVO'   as NomFormaPago,          
    'True'    as FlgEst,          
    ''     as Ingreso,        
 Observacion          
   from Ventas.NotaIngreso as N          
   where N.UsuarioID = @Cajero          
   and LugarPago = @SedeID          
   and N.Tipo in('C','E', 'A')--comienzo del dia, egreso y Adelanto          
   and N.EmpresaID = @EmpresaID          
   And convert(date, N.AudCrea) between @FechaIni and @FechaFin          
        
   union all          
          
   Select          
    C.AudCrea,          
 case
 when C.TipoComprobanteID = 4 then 'B' + substring(C.NumComprobante,3,3)
 when C.TipoComprobanteID = 5 then 'F' + substring(C.NumComprobante,3,3)
 else  substring(C.NumComprobante,3,3) end as Serie,   
  case
 when C.TipoComprobanteID = 4 then 'B' + substring(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7)
 when C.TipoComprobanteID = 5 then 'F' + substring(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7)
 else  substring(C.NumComprobante,3,3) end as NumComprobante,   
    -- C.NumComprobante,          
    TD.NomTipoComprobante,          
    C.MontoTotal  as TotalComprobante,          
    PA.Importe as Pagado,          
    E.NomEstado,          
    FP.NomFormaPago,          
    FlgEst,          
    Ingreso,        
 '' as Observacion          
   from ventas.Comprobante as C          
   --Inner Join ventas.DetalleComprobante as DC On C.NumComprobante = DC.NumComprobante and C.TipoComprobanteID = DC.TipoComprobanteID          
   Inner Join ventas.TipoComprobante as TD  On C.TipoComprobanteID = TD.TipoComprobanteID          
   Inner join Almacen.Estado as E    On C.EstadoID = E.EstadoID          
   inner Join Ventas.Pago as PA    on PA.NumComprobante = C.NumComprobante and PA.TipoComprobanteID = C.TipoComprobanteID          
   inner join Ventas.FormaPago  as FP   on FP.FormaPagoID = PA.FormaPagoID          
   where          
    PA.UsuarioID = @Cajero          
   and convert(date,PA.AudCrea) between @FechaIni and  @FechaFin       
    and C.EmpresaID = @EmpresaID          
    and C.SedeID = @SedeID          
 and C.TipoComprobanteID not in (3)         
        
   union all          
          
   Select          
    C.AudCrea,          
 substring(C.NumComprobante,3,3) as Serie,       
    C.NumComprobante,          
    TD.NomTipoComprobante,          
    C.MontoTotal as TotalComprobante,          
    PA.Importe as Pagado,          
    E.NomEstado,          
    FP.NomFormaPago,          
    FlgEst,          
    Ingreso,        
 '' as Observacion          
   from ventas.Comprobante as C          
   --Inner Join ventas.DetalleComprobante as DC On C.NumComprobante = DC.NumComprobante and C.TipoComprobanteID = DC.TipoComprobanteID          
   Inner Join ventas.TipoComprobante as TD  On C.TipoComprobanteID = TD.TipoComprobanteID          
   Inner join Almacen.Estado as E    On C.EstadoID = E.EstadoID          
   inner Join Ventas.Pago as PA    on PA.NumComprobante = C.NumComprobante and PA.TipoComprobanteID = C.TipoComprobanteID          
   inner join Ventas.FormaPago  as FP   on FP.FormaPagoID = PA.FormaPagoID          
   where          
    PA.UsuarioID = @Cajero          
   and convert(date,PA.AudCrea) between @FechaIni and  @FechaFin       
    and C.EmpresaID = @EmpresaID          
    and C.SedeID = @SedeID          
 and C.TipoComprobanteID in (3) and C.TipoTicket = 'B'          
        
    union all          

    Select            
    C.AudCrea,       
 substring(C.NumComprobante,3,3) as Serie,            
    C.NumComprobante,            
    'TICKET FACTURA' as  NomTipoComprobante,            
    C.MontoTotal as TotalComprobante,            
    PA.Importe as Pagado,            
    E.NomEstado,            
    FP.NomFormaPago,            
    FlgEst,            
   Ingreso,        
 '' as Observacion              
   from ventas.Comprobante as C            
   Inner join Almacen.Estado as E    On C.EstadoID = E.EstadoID            
   inner Join Ventas.Pago as PA    on PA.NumComprobante = C.NumComprobante and PA.TipoComprobanteID = C.TipoComprobanteID            
   inner join Ventas.FormaPago  as FP   on FP.FormaPagoID = PA.FormaPagoID            
   where            
    PA.UsuarioID = @Cajero            
   and convert(date,PA.AudCrea) between @FechaIni and  @FechaFin         
    and C.EmpresaID = @EmpresaID            
    and C.SedeID = @SedeID            
    and C.TipoComprobanteID in (3) and C.TipoTicket = 'F'          
              
              
              
   order by NomEstado, NomTipoComprobante, NumComprobante asc            
          
             
   select top 1 U.Descripcion from Usuario.Usuario as U          
   inner join Ventas.Comprobante as C on C.Cajero = U.UserID          
   where C.Cajero = @Cajero          
End   

go


ALTER PROCEDURE [Ventas].[proc_DatosComprobante]
(@bint_IdComprobante bigint, @str_IdEmpresa char(2), @str_Tipo varchar(10))
as
BEGIN
declare @int_Exonerado int = 1;
if @str_Tipo = '01' or @str_Tipo = '03'
begin
		declare @fecha datetime;
		declare @montoicbper decimal(18,2);

		set @fecha = (select AudCrea from Ventas.Comprobante as c where c.ComprobanteId = @bint_IdComprobante);
		set @montoicbper = (
        select case
        when year(@fecha) = 2019 then 0.10
		when year(@fecha) = 2020 then 0.20
		when year(@fecha) = 2021 then 0.30
		when year(@fecha) = 2022 then 0.40
		when year(@fecha) > 2022 then 0.50 end as dec_Monto);
      
        CREATE TABLE #tmp_impuestos(
		    str_CodigoImpuesto varchar(20),
            str_NombreTributo varchar(20),
            str_CodigoInternacionalTributo varchar(20),
            dec_MontoImpuesto decimal(18,2),
            dec_MontoOperacion decimal(18,2)
		);
 
    
		CREATE TABLE #tmp_leyendas(
		    str_Codigo varchar(20),
            str_Descripcion varchar(500)
		);
        
        
        -- tabla 1 cabecera
		select
        CASE      
		WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'      
		WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END                         
		+ SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) as str_ID,
        -- empresa
        tc.tiposunat as str_TipoDocumento,
        e.RUC as str_RucE, e.NomEmpresa as str_NombreComercial, e.NomEmpresa as str_RazonSocialE, '6' as str_TipoDocumentoE, suc.CodigoAlmacenSunat as str_CodigoSunatE,
        sed.Departamento as str_Departamento, sed.Provincia as str_Provincia, sed.Distrito as str_Distrito, e.Ubigeo as str_Ubigeo,
        sed.Direccion as str_DireccionE,
        -- cliente
        CASE      
		 when cli.ClienteID = 0 or cli.ClienteID = 1 or cli.ClienteID = 204 or cli.ClienteID = 241 or cli.ClienteID = 3032 then '0'      
		 else LEFT(cli.NroDocumento,100) end  as str_RucC,
		 case      
		 when cli.ClienteID = 0 or cli.ClienteID = 1 or cli.ClienteID = 204 or cli.ClienteID = 241 or cli.ClienteID = 3032 then 'Clientes Varios'      
		 else LEFT(cli.RazonSocial,100) end  as str_RazonSocialC,
        case      
		 when cli.ClienteID = 0 or cli.ClienteID = 1 or cli.ClienteID = 204 or cli.ClienteID = 241 or cli.ClienteID = 3032 then '0'      
		 else td.TipoContabilidad end   as str_TipoDocumentoC,
        suc.CodigoAlmacenSunat as str_CodigoDomicilioFiscalC,
        0.00 as dec_MontoTotalImpuesto, convert(decimal(12,2),C.MontoTotal) as dec_ValorVentaBruto,
		convert(decimal(12,2),C.MontoTotal) as dec_TotalPrecioVenta,
		0.00 as dec_MontoDescuentoTotal, 0.00 as dec_TotalOtrosCargos, 
        0.00 as dec_TotalAnticipos, convert(decimal(12,2),C.MontoTotal) as dec_Total, c.AudCrea as fec_FechaEmision,
        'PEN' as str_Moneda
        from Ventas.Comprobante as c
        inner join Empresa.Empresa as e on e.EmpresaID = c.EmpresaID
		inner join Ventas.TipoComprobante as tc on tc.TipoComprobanteID = c.TipoComprobanteID
        inner join Ventas.Cliente as cli on cli.ClienteID = c.ClienteID
		inner join Empresa.Sucursal as suc on suc.EmpresaID = c.EmpresaID and suc.SedeID = c.SedeID
		inner join Empresa.Sede as sed on sed.SedeID = c.SedeID
		INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cLi.IDTipoDocumento  
        where c.ComprobanteId = @bint_IdComprobante;
		
 

        -- impuestos
   
            
        insert into #tmp_leyendas
		(str_Codigo, str_Descripcion)
        select '2001' as str_Codigo, 'BIENES TRANSFERIDOS EN LA AMAZONÍA REGIÓN SELVA PARA SER CONSUMIDOS EN LA MISMA' as str_Descripcion;
       
        
		insert into #tmp_impuestos
		(str_CodigoImpuesto, str_NombreTributo, str_CodigoInternacionalTributo, dec_MontoImpuesto, dec_MontoOperacion)
		select
		'9997' as str_CodigoImpuesto,
		'EXO' as str_NombreTributo,
		'VAT' as str_CodigoInternacionalTributo,
		0.00 as dec_MontoImpuesto,
		convert(decimal(12,2),C.MontoTotal) as dec_MontoOperacion
		from Ventas.Comprobante as c
		where  c.ComprobanteId = @bint_IdComprobante;
		
		insert into #tmp_leyendas
		(str_Codigo, str_Descripcion)
		select '1000' as str_Codigo,  dbo.FN_CantidadConLetraSoles(C.MontoTotal) as str_Descripcion
		from Ventas.Comprobante as c
		where  c.ComprobanteId = @bint_IdComprobante;
        
        -- icbper 
        insert into #tmp_impuestos
		(str_CodigoImpuesto, str_NombreTributo, str_CodigoInternacionalTributo, dec_MontoImpuesto, dec_MontoOperacion)
         select
			'7152' as str_CodigoImpuesto,
            'ICBPER' as str_NombreTributo,
            'OTH' as str_CodigoInternacionalTributo,
			c.TotalICBPER as dec_MontoImpuesto,
            0.00 as dec_MontoOperacion
			from Ventas.Comprobante as c
			where  c.ComprobanteId = @bint_IdComprobante and c.TotalICBPER > 0;
        
         -- igv 
		--insert into #tmp_impuestos
		--(str_CodigoImpuesto, str_NombreTributo, str_CodigoInternacionalTributo, dec_MontoImpuesto, dec_MontoOperacion)
		--select
		--'1000' as str_CodigoImpuesto,
		--'IGV' as str_NombreTributo,
		--'VAT' as str_CodigoInternacionalTributo,
		--c.dec_MontoIGV as dec_MontoImpuesto,
		--c.dec_OperacionesGravadas as dec_MontoOperacion
		--from t_comprobante as c
		--where c.bint_IdComprobante = pbint_IdComprobante and c.dec_MontoIGV > 0;
        
        -- tabla 2 detalle
        select p.ProductoID as bint_IdComprobanteDetalle, p.ProductoID as str_Codigo, p.Alias as str_Descripcion,
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
		  else 'ERROR' END as str_UnidadMedida, '' as str_CodigoSunat,
       CONVERT(DECIMAL(18,2), cd.Cantidad)  as dec_Cantidad, CONVERT(DECIMAL(18,2), cd.Importe) as dec_ValorVenta, 
	   CONVERT(DECIMAL(18,2), cd.PrecioUnitario) as dec_PrecioVentaUnitario, CONVERT(DECIMAL(18,2), cd.PrecioUnitario) as dec_ValorUnitario,
		0.00 as dec_PorcentajeDescuento, 0.00 as dec_Descuento,
        CONVERT(DECIMAL(18,2), cd.Importe) as dec_ValorVentaBruto
        from Ventas.DetalleComprobante as cd
        inner join Producto.Producto as p on p.ProductoID = cd.ProductoID
		inner join Ventas.Comprobante as c on c.TipoComprobanteID = cd.TipoComprobanteID and c.NumComprobante = cd.NumComprobante
        where  c.ComprobanteId = @bint_IdComprobante AND cd.Importe >= 0
        
        -- tabla 3 impuesto del detalle
        select distinct cd.ProductoID as bint_IdComprobanteDetalle, '9997' as str_CodigoImpuesto, '20' as str_TipoAfectacionIGV, 0.00 as dec_Porcentaje,
        0.00 as dec_Monto, 'EXO' as str_NombreTributo, 'VAT' as str_CodigoTributo,
		0.00 as dec_PrecioUnitario
       from Ventas.DetalleComprobante as cd
	   inner join Ventas.Comprobante as c on c.TipoComprobanteID = cd.TipoComprobanteID and c.NumComprobante = cd.NumComprobante
        where  c.ComprobanteId = @bint_IdComprobante
		union
		select distinct cd.ProductoID as bint_IdComprobanteDetalle, '7152' as str_CodigoImpuesto, '00' as str_TipoAfectacionIGV, 0.00 as dec_Porcentaje,
        convert(decimal(12,2),(cd.Cantidad * @montoicbper)) as dec_Monto, 'ICBPER' as str_NombreTributo, 'OTH' as str_CodigoTributo,
		@montoicbper as dec_PrecioUnitario
       from Ventas.DetalleComprobante as cd
	   inner join Ventas.Comprobante as c on c.TipoComprobanteID = cd.TipoComprobanteID and c.NumComprobante = cd.NumComprobante
        where  c.ComprobanteId = @bint_IdComprobante and cd.ProductoID in (select Valor from Empresa.GrupoDetalle where GrupoId = 2)
       

	   

        -- tabla 4 impuesto
        select * from #tmp_impuestos;
        -- tabla 5 leyendas
        select * from #tmp_leyendas;

		  -- tabla 6 Cuotas
		  declare @int_FormaPago int;
		 select @int_FormaPago =  TipoPagoID from Ventas.Comprobante where ComprobanteId = @bint_IdComprobante;
      
        IF @int_FormaPago = 1 -- VENTA AL CREDITO
		BEGIN
			select 'Credito' as str_CuotaTipo, dec_MontoCuota, dat_FechaPagar from Ventas.Cuota where bint_IdComprobante = @bint_IdComprobante and int_NroCuota = 0
            union
            select concat('Cuota', RIGHT('000' + CONVERT(VARCHAR(10), int_NroCuota),3)) as str_CuotaTipo, dec_MontoCuota, dat_FechaPagar from Ventas.Cuota where bint_IdComprobante = @bint_IdComprobante and int_NroCuota != 0;
        END
		ELSE
		BEGIN
			select 'Contado' as str_CuotaTipo,  0.00 as dec_MontoCuota, null as dat_FechaPagar;
        END
 
end
else if @str_Tipo = 'RA'
begin
 


	select
	convert(varchar(100), year(db.fecha)) + right('00' + convert(varchar(100),  month(db.fecha)), 2)  +
	right('00' + convert(varchar(100),  day(db.fecha)), 2) + '-' + RIGHT('000' + convert(varchar(100),db.Correlativo),3) as str_ID,
    db.Fecha as fec_FechaGeneracionBaja, db.Fecha as fec_FechaGeneracionComunicacion,
     e.RUC as str_RucE, e.NomEmpresa as str_NombreComercial, e.NomEmpresa as str_RazonSocialE, '6' as str_TipoDocumentoE, db.tipo as str_TipoDocumento
    from Ventas.CorrelativoFacturadorSunat as db
    inner join Empresa.Empresa as e on e.EmpresaID = db.EmpresaID
    where db.CorrelativoFacturadorSunatId = @bint_IdComprobante;
     
    select 
	CASE  
	WHEN C.TipoComprobanteID = 4 THEN 'B'  
	WHEN C.TipoComprobanteID = 5 THEN 'F'  
	WHEN C.TipoComprobanteID = 1 THEN '0'  
	WHEN C.TipoComprobanteID = 2 THEN '0'  
	ELSE 'X'  END  +                        
	SUBSTRING(C.NumComprobante,3,3) as str_SerieComprobante, '0' + RIGHT(C.NumComprobante,7) as str_NumeroComprobante, 'POR ANULACIÓN' AS str_MotivoBaja    
    from Ventas.CorrelativoFacturadorSunat as db
    inner join Ventas.Comprobante as c on c.GeneradoBajaId = db.CorrelativoFacturadorSunatId
    where db.CorrelativoFacturadorSunatId = @bint_IdComprobante;
 end
else if @str_Tipo = 'RC'
begin
	
	if exists(select * from Ventas.Comprobante where GeneradoBajaId = @bint_IdComprobante)
	begin
		select
		convert(varchar(100), year(db.fecha)) + right('00' + convert(varchar(100),  month(db.fecha)), 2)  +
		right('00' + convert(varchar(100),  day(db.fecha)), 2) + '-'  + RIGHT('000' + convert(varchar(100),db.Correlativo),3) as str_ID,
		db.Fecha as fec_FechaEmisionComprobantes, db.Fecha as fec_FechaGeneracionResumen,
		-- empresa
		 e.RUC as str_RucE, e.NomEmpresa as str_NombreComercial, e.NomEmpresa as str_RazonSocialE, '6' as str_TipoDocumentoE, db.Tipo as str_TipoDocumento, 
		 '0000' as str_CodigoDomicilioFiscal,  
		3 as str_Estado
		from Ventas.CorrelativoFacturadorSunat as db
		inner join Empresa.Empresa as e on e.EmpresaID = db.EmpresaID
		where db.CorrelativoFacturadorSunatId = @bint_IdComprobante;
 
		select
		CASE  
		WHEN C.TipoComprobanteID = 4 THEN 'B'  
		WHEN C.TipoComprobanteID = 5 THEN 'F'  
		WHEN C.TipoComprobanteID = 1 THEN '0'  
		WHEN C.TipoComprobanteID = 2 THEN '0'  
		ELSE 'X'  END  +                        
		SUBSTRING(C.NumComprobante,3,3) as str_SerieComprobante, '0' + RIGHT(C.NumComprobante,7)  as str_NumeroComprobante,
		convert(decimal(12,2),C.MontoTotal)  as dec_Total, '03' as str_TipoDocumento, 
		0.00 as dec_OperacionesGravadas, convert(decimal(12,2),C.MontoTotal) as dec_OperacionesExoneradas, 0.00 as dec_OperacionesInafectas,
		0.00 as dec_OperacionsExportacion, 0.00 as dec_OperacionesGratuitas,
		0.00 as dec_MontoIGV, 0.00 as dec_MontoISC, c.TotalICBPER as dec_MontoIcbper, 0.00 as dec_TotalOtrosImpuestos,
		 -- cliente
		CASE      
			 when cli.ClienteID = 0 or cli.ClienteID = 1 or cli.ClienteID = 204 or cli.ClienteID = 241 or cli.ClienteID = 3032 then '0'      
			 else LEFT(cli.NroDocumento,100) end as str_RucC,
			 case      
			 when cli.ClienteID = 0 or cli.ClienteID = 1 or cli.ClienteID = 204 or cli.ClienteID = 241 or cli.ClienteID = 3032 then 'Clientes Varios'      
			 else LEFT(cli.RazonSocial,100) end as str_RazonSocialC,
		case      
			 when cli.ClienteID = 0 or cli.ClienteID = 1 or cli.ClienteID = 204 or cli.ClienteID = 241 or cli.ClienteID = 3032 then '0'      
			 else td.TipoContabilidad end  as str_TipoDocumentoC,
		'0000' as str_CodigoDomicilioFiscalC
		from Ventas.CorrelativoFacturadorSunat as db
		inner join Ventas.Comprobante as c on c.GeneradoBajaId = db.CorrelativoFacturadorSunatId
		inner join Ventas.Cliente as cli on cli.ClienteID = c.ClienteID
		INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cLi.IDTipoDocumento  
		where db.CorrelativoFacturadorSunatId = @bint_IdComprobante;
	end
	else
	begin
		select
		convert(varchar(100), year(db.fecha)) + right('00' + convert(varchar(100),  month(db.fecha)), 2)  +
		right('00' + convert(varchar(100),  day(db.fecha)), 2) + '-'  + RIGHT('000' + convert(varchar(100),db.Correlativo),3) as str_ID,
		db.Fecha as fec_FechaEmisionComprobantes, db.Fecha as fec_FechaGeneracionResumen,
		-- empresa
		 e.RUC as str_RucE, e.NomEmpresa as str_NombreComercial, e.NomEmpresa as str_RazonSocialE, '6' as str_TipoDocumentoE, db.Tipo as str_TipoDocumento, 
		 '0000' as str_CodigoDomicilioFiscal,  
		1 as str_Estado
		from Ventas.CorrelativoFacturadorSunat as db
		inner join Empresa.Empresa as e on e.EmpresaID = db.EmpresaID
		where db.CorrelativoFacturadorSunatId = @bint_IdComprobante;
 
		select
		CASE  
		WHEN C.TipoComprobanteID = 4 THEN 'B'  
		WHEN C.TipoComprobanteID = 5 THEN 'F'  
		WHEN C.TipoComprobanteID = 1 THEN '0'  
		WHEN C.TipoComprobanteID = 2 THEN '0'  
		ELSE 'X'  END  +                        
		SUBSTRING(C.NumComprobante,3,3) as str_SerieComprobante, '0' + RIGHT(C.NumComprobante,7)  as str_NumeroComprobante,
		convert(decimal(12,2),C.MontoTotal)  as dec_Total, '03' as str_TipoDocumento, 
		0.00 as dec_OperacionesGravadas, convert(decimal(12,2),C.MontoTotal) as dec_OperacionesExoneradas, 0.00 as dec_OperacionesInafectas,
		0.00 as dec_OperacionsExportacion, 0.00 as dec_OperacionesGratuitas,
		0.00 as dec_MontoIGV, 0.00 as dec_MontoISC, c.TotalICBPER as dec_MontoIcbper, 0.00 as dec_TotalOtrosImpuestos,
		 -- cliente
		CASE      
			 when cli.ClienteID = 0 or cli.ClienteID = 1 or cli.ClienteID = 204 or cli.ClienteID = 241 or cli.ClienteID = 3032 then '0'      
			 else LEFT(cli.NroDocumento,100) end as str_RucC,
			 case      
			 when cli.ClienteID = 0 or cli.ClienteID = 1 or cli.ClienteID = 204 or cli.ClienteID = 241 or cli.ClienteID = 3032 then 'Clientes Varios'      
			 else LEFT(cli.RazonSocial,100) end as str_RazonSocialC,
		case      
			 when cli.ClienteID = 0 or cli.ClienteID = 1 or cli.ClienteID = 204 or cli.ClienteID = 241 or cli.ClienteID = 3032 then '0'      
			 else td.TipoContabilidad end  as str_TipoDocumentoC,
		'0000' as str_CodigoDomicilioFiscalC
		from Ventas.CorrelativoFacturadorSunat as db
		inner join Ventas.Comprobante as c on c.GeneradoAltaId = db.CorrelativoFacturadorSunatId
		inner join Ventas.Cliente as cli on cli.ClienteID = c.ClienteID
		INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cLi.IDTipoDocumento  
		where db.CorrelativoFacturadorSunatId = @bint_IdComprobante;
	end

	 
end
END

go