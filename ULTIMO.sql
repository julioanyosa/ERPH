select * from producto.ListaPrecio


alter table producto.ListaPrecio add Puntos int
update producto.ListaPrecio set Puntos = 0

Create table Ventas.PuntosClientes
(
PuntosClientesID int identity(1,1) primary key,
Puntos int,
ComprobanteId bigint,
ClienteID int,
Fecha datetime, 
Concepto varchar(500),
Usuario int
)

 
 
create Procedure [Producto].[Usp_UpdatePuntos]
(
	@EmpresaID		char(2),
	@SedeID			char(5),
	@ProductoID		varchar(20),
	@Puntos			int,
	@UsuarioID		int
)
As
Begin
	Set Nocount On
 
	Update Producto.ListaPrecio
	set
		Puntos = @Puntos
	Where
		EmpresaID = @EmpresaID
		and SedeID = @SedeID
		and ProductoID = @ProductoID
	 
	Set Nocount Off
End
go


/************************************************************************************************************  
Autor  : Julio Cesar Anyosa Candela  
Fecha  : 20/10/2011  
Descripción : obtener los productos con precio  
 [Ventas].[Usp_GetProductosPrecio] 'GH002VU', 'SAL'  
*************************************************************************************************************/  
alter Procedure [Ventas].[Usp_GetProductosPrecio]  
(  
 @EmpresaSede char(7),  
 @Cadena varchar(150),  
 @Tipo Char(1)  
)  
As  
Begin  
if @Tipo = 'A'--buscar por alias  
 begin  
  SELECT EQ.ProductoIDVentas, P.ProductoID, Alias, UnidadMedidaID, L.PrecioUnitario, p.Almacen,isnull(L.Puntos,0) as Puntos,
 S.StockDisponible, L.HistoricoPrecioID  FROM Producto.Producto as p  
  inner join Producto.Equivalencia as EQ on EQ.ProductoID = P.ProductoID  
  inner Join Producto.ListaPrecio as L On L.ProductoID = P.ProductoID  
  Inner Join Almacen.StockAlmacen as S On P.ProductoID = S.ProductoID 
  Where L.EmpresaID + L.SedeID = @EmpresaSede  
  and S.AlmacenID = @EmpresaSede + P.Almacen  
  --and LEFT(P.Alias,LEN(@Cadena))  = @Cadena  
  and P.Alias  like '%' + @Cadena + '%'  
  
 End  
Else if @Tipo = 'C'  
 Begin  
  SELECT EQ.ProductoIDVentas, P.ProductoID, Alias, UnidadMedidaID, L.PrecioUnitario, p.Almacen,isnull(L.Puntos,0) as Puntos,
 S.StockDisponible, L.HistoricoPrecioID  FROM Producto.Producto as p  
  inner join Producto.Equivalencia as EQ on EQ.ProductoID = P.ProductoID  
  inner Join Producto.ListaPrecio as L On L.ProductoID = P.ProductoID  
  Inner Join Almacen.StockAlmacen as S On P.ProductoID = S.ProductoID  
  Where L.EmpresaID + L.SedeID = @EmpresaSede  
  and S.AlmacenID = @EmpresaSede + P.Almacen  
  and LEFT(EQ.ProductoIDVentas,LEN(@Cadena))  = @Cadena  
 End  
End  
go

/************************************************************************************************************  
Autor  : Juan Carlos  
Fecha  : 02/05/2011  
Descripción : Listar registros de la tabla de base de datos 
Prueba  :  
*************************************************************************************************************/ 
alter Procedure [Ventas].[Usp_Insert_Comprobante2]  
(  
 @EmpresaID  char(2),  
 @SedeID char(5),  
 @TipoComprobanteID  tinyint,  
 @ClienteID  int,  
 @Direccion  varchar(150),  
 @TipoVentaID tinyint,  
 @TipoPagoID  tinyint,  
 @FormaPagoID tinyint,  
 @NumCaja  int,  
 @NroGuia  varchar(12),  
 @IGV tinyint,  
 @SubTotal  decimal(12,3),  
 @TotalIGV  decimal(12,3),  
 @Vendedor  int,  
 @CreditoID  int,  
 @Cajero int,  
 @EstadoID  int,  
 @Externa  bit,  
 @Vale bit,  
 @Serie char(3),  
 @NumVale  int,  
 @XMLDetalle  xml,  
 @NumPedido  int,  
 @Tipo Char(1),  
 @TipoTicket char(1)  
)  
As  
Begin  
 Set Nocount On  
  
 DECLARE @hDoc int  
 DECLARE @NumComprobante char(13)  
 DECLARE @NumGuia int  
 DECLARE @NumGuiaS char(7)  
 DECLARE @EmpresaSede char(7)  
 DECLARE @FECHA_ACTUAL SMALLDATETIME = GETDATE()  
 
 Set @EmpresaSede=@EmpresaID+@SedeID  
 Select @NumGuia = Numero From ventas.SerieGuia Where EmpresaSede = @EmpresaSede and Serie =@Serie and TipoDocumento = @TipoComprobanteID  
 Set @NumGuiaS = RIGHT('0000000' + cast(@NumGuia + 1  as varchar(7)), 7)  
 Select @NumComprobante = left(@EmpresaSede,2) + @Serie + '-' + @NumGuiaS  
 
 --actualizar el nuevo numero de guia 
 update ventas.SerieGuia set Numero = @NumGuia + 1 Where EmpresaSede = @EmpresaSede and Serie =@Serie and TipoDocumento = @TipoComprobanteID  
 
 declare @id bigint 
 Insert Into Ventas.Comprobante  
 (  
  NumComprobante, EmpresaID,   SedeID,    TipoComprobanteID,    ClienteID,    Direccion,    TipoVentaID,    TipoPagoID,    FormaPagoID,  
  NumCaja,    NroGuia,    IGV,    SubTotal,    TotalIGV,    Vendedor,    CreditoID,    Cajero,    EstadoID,    Externa,    Vale,    NumVale,  
  Ingreso,    AudCrea,    FlgEst,    TipoTicket   )  
 Values  
 (  
  @NumComprobante,   @EmpresaID,    @SedeID,    @TipoComprobanteID,    @ClienteID,    @Direccion,    @TipoVentaID,    @TipoPagoID,    @FormaPagoID,  
  @NumCaja,    @NroGuia,    @IGV,    @SubTotal,    @TotalIGV,    @Vendedor,    @CreditoID,    @Cajero,    @EstadoID,    @Externa,    @Vale,  @NumVale,  
  'A',    @FECHA_ACTUAL,    'True',   @TipoTicket  
 )  
 set @id = SCOPE_IDENTITY()  
 
 Exec sp_xml_preparedocument @hDoc OUTPUT,@XMLDetalle 
 
 Insert Into Ventas.DetalleComprobante  
 (  
  NumComprobante,    TipoComprobanteID,    ProductoID,    Cantidad,    PrecioUnitario,    Importe,    FechaReserva,    EstadoID,  HistoricoPrecioID  
 )  
 Select  
  @NumComprobante,  @TipoComprobanteID,    ProductoID,  Cantidad, PrecioUnitario, Importe,  FechaReserva,  EstadoID,  HistoricoPrecioID  
 FROM OPENXML(@hDoc, '/DocumentElement/detallePedido')  
 WITH  
 (  
  ProductoID  varchar(20)  'ProductoID',  
  Cantidad  decimal(12,3) 'Cantidad',  
  PrecioUnitario decimal(12,3) 'PrecioUnitario',  
  Importe decimal(12,3) 'Importe',  
  FechaReserva smalldatetime 'FechaReserva',  
  EstadoID  int  'EstadoID',  
  HistoricoPrecioID INT 'HistoricoPrecioID'  
 )XMLDetalleComprobante  
 
  ---------------------------------------------------------------------------------------------------
 --insertamos los puntos
 insert into Ventas.PuntosClientes(Puntos,ComprobanteId, ClienteID, Fecha, Usuario)
 Select  
 convert(int,sum(lp.Puntos * Cantidad)) as puntos,   @id, @ClienteID, @FECHA_ACTUAL, @Cajero
 FROM OPENXML(@hDoc, '/DocumentElement/detallePedido')  
 WITH  
 (  
  ProductoID  varchar(20)  'ProductoID',  
  Cantidad  decimal(12,3) 'Cantidad',  
  PrecioUnitario decimal(12,3) 'PrecioUnitario',  
  Importe decimal(12,3) 'Importe',  
  FechaReserva smalldatetime 'FechaReserva',  
  EstadoID  int  'EstadoID',  
  HistoricoPrecioID INT 'HistoricoPrecioID'  
 )XMLDetalleComprobante
 inner join Producto.ListaPrecio as lp on lp.ProductoID = XMLDetalleComprobante.ProductoID
 and lp.EmpresaID = @EmpresaID and lp.SedeID = @SedeID where lp.Puntos >0
 ---------------------------------------------------------------------------------------------------


 --disminuir del credito disponible del cliente  
 if(isnull(@TipoPagoID,0) = 1)--venta al credito  
 Begin  
  update Ventas.Credito set 
 CreditoDisponible = CreditoDisponible - (@SubTotal + @TotalIGV),  
 UsuarioIDM = @Cajero,  
 SedeIDM = @SedeID  
  Where CreditoID = @CreditoID  
 End  
    
 
 if(isnull(@TipoVentaID,0) <> 3 and isnull(@TipoVentaID,0) <> 6 and @Tipo = 'D')--diferente de reserva y de diferida, Tipo = 'D' es descuento  
 Begin  
  --********** Insertar en Kardex *****************  
  --Obtenemos el tipo de documento  
  declare @TipoComprobante char(2)  
  select @TipoComprobante = TipoContabilidad from Almacen.TipoDocumento where DocumentoID = @TipoComprobanteID  
  
 Insert Into Almacen.Kardex  
  (  
  AlmacenID,    ProductoID,    Cantidad,    MovimientoID,    NroDocumento,    TipoComprobante,    Serie,    Numero,    TipoOperacion,  
  CostoUnitario,    Ingreso,    UsuarioID,    AudCrea    )  
  Select  
  AlmacenID,    ProductoID,    Cantidad,    1,    cast(@TipoComprobanteID as CHAR(1)) + '-' + @NumComprobante,    @TipoComprobante,    SUBSTRING(@NumComprobante,3,3),  
  cast(right(@NumComprobante,7) as int),    '01',  
  PrecioUnitario,   'A',    @Cajero,    @FECHA_ACTUAL  
 FROM OPENXML(@hDoc, '/DocumentElement/detallePedido')  
 WITH  
 (  
 AlmacenID  char(10)  'AlmacenID',  
 ProductoID  varchar(20)  'ProductoID',  
 Cantidad  decimal(12,3) 'Cantidad',  
 PrecioUnitario decimal(12,3) 'PrecioUnitario'  
 )  XMLInsertKardex  
  where XMLInsertKardex.ProductoID not in (select  ProductoID from Ventas.Servicios --excluyendo los servicios  
  union select ProductoID from Producto.Producto where IDExistencia = 6) -- excluyendo existencias que no mueven kardex  
  
  --************ Actualizar Stock *****************  
  Update Almacen.StockAlmacen  
  Set 
 Almacen.StockAlmacen.StockActual=Almacen.StockAlmacen.StockActual - XMLUpdateStock.Cantidad,  
 Almacen.StockAlmacen.StockDisponible=Almacen.StockAlmacen.StockDisponible - XMLUpdateStock.Cantidad,  
 Almacen.StockAlmacen.AudModifica=@FECHA_ACTUAL  
  FROM OPENXML(@hDoc, '/DocumentElement/detallePedido') 
 WITH  
 (  
  AlmacenID  char(10)  'AlmacenID',  
  ProductoID  varchar(20)  'ProductoID',  
  Cantidad  decimal(12,3) 'Cantidad'  
 )XMLUpdateStock  
 WHERE  
  Almacen.StockAlmacen.AlmacenID=XMLUpdateStock.AlmacenID AND  
  Almacen.StockAlmacen.ProductoID=XMLUpdateStock.ProductoID  
 end  
 
 --ELIMINAMOS EL PEDIDO  
 Delete Ventas.DetallePedido where NumPedido=@NumPedido  
 Delete Ventas.OrdenPedido where NumPedido=@NumPedido  
 
 EXEC sp_xml_removedocument @hDoc  
  
  
  
 Select @NumComprobante as NumComprobante, @FECHA_ACTUAL as FECHA_ACTUAL, @id as id  
 
 
 
 Set Nocount Off  
End  
go


alter procedure Ventas.ObtenerPuntosCliente
(
@ClienteID int
)
as
select isnull( Sum(Puntos),0) as PuntosDisponibles from ventas.PuntosClientes where ClienteID = @ClienteID
go

alter procedure Ventas.InsertarPuntos
(
@ClienteID int,
@Puntos int,
@Concepto varchar(500),
@Usuario int
)
as
 insert into Ventas.PuntosClientes(Puntos, ClienteID, Concepto, Usuario, fecha)
 values
 (@Puntos,@ClienteID, @Concepto, @Usuario, GETDATE())
go
