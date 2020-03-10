using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Halley.CapaDatos.Almacen;
using Halley.Configuracion;
using System.Data;
using Halley.Utilitario;
using Halley.Entidad.Almacen;

namespace Halley.CapaLogica.Almacen
{
    public class CL_Kardex
    {
        public static string Name
        {
            get { return "Kardex"; }
        }

        public DataTable getKardex(string EmpresaID, string ProductoID, int TipoMovimiento, int UsuarioID, DateTime FechaInicial, DateTime FechaFinal)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Kardex.getKardex(EmpresaID, ProductoID, TipoMovimiento, UsuarioID, FechaInicial, FechaFinal);
            return dtTMP;

        }

        public DataTable ArmarReporteKardex(DataTable dtTMP)
        {
            decimal Cantidad = 0, CantidadAcumulada = 0, PrecioPonderado = 0, CostoAcumulado = 0;
            string nombreproducto = "", codigoproducto = "";

            DataTable DtKardex2 = new DataTable("GetKardex2");
            DtKardex2.Columns.Add("CantidadAcumulada", typeof(decimal));
            DtKardex2.Columns.Add("PrecioPonderado", typeof(decimal));
            DtKardex2.Columns.Add("CostoAcumulado", typeof(decimal));
            DtKardex2.Columns.Add("Operacion", typeof(string));

            try
            {
                CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);



                //Creamos tabla para ordenar los datos
                DataTable DtKardex = new DataTable("GetKardex");
                DtKardex.Columns.Add("ID", typeof(int));
                DtKardex.Columns.Add("ProductoID", typeof(string));
                DtKardex.Columns.Add("Producto", typeof(string));
                DtKardex.Columns.Add("UM", typeof(string));
                DtKardex.Columns.Add("Fecha", typeof(string));
                DtKardex.Columns.Add("Tipo", typeof(string));
                DtKardex.Columns.Add("Serie", typeof(string));
                DtKardex.Columns.Add("Numero", typeof(string));
                DtKardex.Columns.Add("Operacion", typeof(string));
                DtKardex.Columns.Add("ECantidad", typeof(decimal));
                DtKardex.Columns.Add("ECostoUnitario", typeof(decimal));
                DtKardex.Columns.Add("ECostoTotal", typeof(decimal));
                DtKardex.Columns.Add("SCantidad", typeof(decimal));
                DtKardex.Columns.Add("SCostoUnitario", typeof(decimal));
                DtKardex.Columns.Add("SCostoTotal", typeof(decimal));
                DtKardex.Columns.Add("FCantidad", typeof(decimal));
                DtKardex.Columns.Add("FCostoUnitario", typeof(decimal));
                DtKardex.Columns.Add("FCostoTotal", typeof(decimal));
                DtKardex.Columns.Add("KardexID", typeof(int));
                DtKardex.Columns.Add("TipoExistencia", typeof(string));
                DtKardex.Columns.Add("Tabla", typeof(string));
                DtKardex.Columns.Add("AudCrea", typeof(DateTime));
                DtKardex.Columns.Add("UnidadMedidaID", typeof(string));
                DtKardex.Columns.Add("TipoM", typeof(decimal));
                DtKardex.Columns.Add("TipoSunat", typeof(string));
                DtKardex.Columns.Add("CodigoExistencia", typeof(string));
                DtKardex.Columns.Add("Establecimiento", typeof(string));

                //Seleccionamos disticnt de los productos
                DataTable DtProductos = new DataTable();
                DtProductos = dtTMP.DefaultView.ToTable(true, "ProductoID");

            

                foreach (DataRow DRP in DtProductos.Rows)
                {


                    //filtramos datos por producto
                    DataView Dv = new DataView(dtTMP, "ProductoID='" + DRP["ProductoID"].ToString() + "'", "AudCrea ASC,Orden ASC", DataViewRowState.CurrentRows);
                    int ID = 1; //id para saber el orden
                    foreach (DataRowView Dr in Dv)
                    {

                        nombreproducto = Dr["Producto"].ToString();
                        codigoproducto = Dr["ProductoID"].ToString();

                        if (codigoproducto == "00001000002.7")
                        {
                            string julio = "";
                        }
                        DataRow DR = DtKardex.NewRow();
                        DR["ID"] = ID;
                        DR["ProductoID"] = Dr["ProductoID"];
                        DR["Producto"] = Dr["Producto"];
                        DR["UM"] = Dr["UMContabilidad"];
                        DR["Fecha"] = Convert.ToDateTime(Dr["AudCrea"]).ToShortDateString();
                        DR["Tipo"] = Dr["TipoContabilidad"];
                        DR["Serie"] = Dr["Serie"];
                        DR["Numero"] = Dr["Numero"];
                        DR["Operacion"] = Dr["TipoOperacion"];
                        DR["TipoExistencia"] = Dr["TipoExistencia"];

                        Cantidad = decimal.Round(Convert.ToDecimal(Dr["Cantidad"]), 3);


                        //validar si es entrada o salida
                        if (Dr["Tipo"].ToString() == "I")
                        {
                            PrecioPonderado = Convert.ToDecimal(Dr["PrecioUnitario"]);//temporal
                            CantidadAcumulada += Cantidad;
                            if (CantidadAcumulada != 0)
                                DR["ECantidad"] = Cantidad;
                            DR["ECostoUnitario"] = PrecioPonderado;
                            DR["ECostoTotal"] = Cantidad * PrecioPonderado;
                            CostoAcumulado += Cantidad * PrecioPonderado;
                            DR["SCantidad"] = DBNull.Value;
                            DR["SCostoUnitario"] = DBNull.Value;
                            DR["SCostoTotal"] = DBNull.Value;
                            DR["FCantidad"] = CantidadAcumulada;
                            if (CantidadAcumulada != 0)
                                PrecioPonderado = decimal.Round(CostoAcumulado / CantidadAcumulada, 3);//precio real nuevo
                            DR["FCostoUnitario"] = PrecioPonderado;
                            DR["FCostoTotal"] = CostoAcumulado;

                            DataRow DR2 = DtKardex2.NewRow();
                            DR2["CantidadAcumulada"] = CantidadAcumulada;
                            DR2["PrecioPonderado"] = PrecioPonderado;
                            DR2["CostoAcumulado"] = CostoAcumulado;
                            DR2["Operacion"] =  CostoAcumulado.ToString() + "/" + CantidadAcumulada.ToString();
                            DtKardex2.Rows.Add(DR2);
                        }
                        else if (Dr["Tipo"].ToString() == "S" & (Dr["TipoOperacion"].ToString() == "01" | Dr["TipoOperacion"].ToString() == "10"))//salida por venta y por produccion
                        {
                            CantidadAcumulada -= Cantidad;
                            CostoAcumulado = decimal.Round(CantidadAcumulada * PrecioPonderado, 3);
                            DR["ECantidad"] = DBNull.Value;
                            DR["ECostoUnitario"] = DBNull.Value;
                            DR["ECostoTotal"] = DBNull.Value;
                            DR["SCantidad"] = Cantidad;
                            DR["SCostoUnitario"] = PrecioPonderado;
                            DR["SCostoTotal"] = Cantidad * PrecioPonderado;
                            DR["FCantidad"] = CantidadAcumulada;
                            if (CantidadAcumulada != 0)
                                PrecioPonderado = decimal.Round(CostoAcumulado / CantidadAcumulada, 3);
                            DR["FCostoUnitario"] = PrecioPonderado;
                            DR["FCostoTotal"] = CostoAcumulado;

                            DataRow DR2 = DtKardex2.NewRow();
                            DR2["CantidadAcumulada"] = CantidadAcumulada;
                            DR2["PrecioPonderado"] = PrecioPonderado;
                            DR2["CostoAcumulado"] = CostoAcumulado;
                            DR2["Operacion"] =  CostoAcumulado.ToString() + "/" + CantidadAcumulada.ToString();
                            DtKardex2.Rows.Add(DR2);
                        }
                        else if (Dr["Tipo"].ToString() == "S")//otro tipo de salida
                        {
                            PrecioPonderado = Convert.ToDecimal(Dr["PrecioUnitario"]);//temporal
                            CantidadAcumulada -= Cantidad;
                            DR["ECantidad"] = DBNull.Value;
                            DR["ECostoUnitario"] = DBNull.Value;
                            DR["ECostoTotal"] = DBNull.Value;
                            DR["SCantidad"] = Cantidad;
                            DR["SCostoUnitario"] = PrecioPonderado;
                            DR["SCostoTotal"] = Cantidad * PrecioPonderado;
                            DR["FCantidad"] = CantidadAcumulada;
                            CostoAcumulado -= decimal.Round(Cantidad * PrecioPonderado, 3);
                            if (CantidadAcumulada != 0)
                                PrecioPonderado = decimal.Round(CostoAcumulado / CantidadAcumulada, 3);
                            DR["FCostoUnitario"] = PrecioPonderado;
                            DR["FCostoTotal"] = CostoAcumulado;

                            DataRow DR2 = DtKardex2.NewRow();
                            DR2["CantidadAcumulada"] = CantidadAcumulada;
                            DR2["PrecioPonderado"] = PrecioPonderado;
                            DR2["CostoAcumulado"] = CostoAcumulado;
                            DR2["Operacion"] =  CostoAcumulado.ToString() + "/" + CantidadAcumulada.ToString();
                            DtKardex2.Rows.Add(DR2);
                        }
                        else if (Dr["Tipo"].ToString() == "A")//saldo inicial
                        {
                            PrecioPonderado = Convert.ToDecimal(Dr["PrecioUnitario"]);
                            CantidadAcumulada += Cantidad;
                            DR["ECantidad"] = DBNull.Value;
                            DR["ECostoUnitario"] = DBNull.Value;
                            DR["ECostoTotal"] = DBNull.Value;
                            CostoAcumulado += decimal.Round(Cantidad * PrecioPonderado, 3);
                            DR["SCantidad"] = DBNull.Value;
                            DR["SCostoUnitario"] = DBNull.Value;
                            DR["SCostoTotal"] = DBNull.Value;
                            DR["FCantidad"] = Cantidad;
                            DR["FCostoUnitario"] = PrecioPonderado;
                            DR["FCostoTotal"] = decimal.Round(Cantidad * PrecioPonderado, 3);

                            DataRow DR2 = DtKardex2.NewRow();
                            DR2["CantidadAcumulada"] = CantidadAcumulada;
                            DR2["PrecioPonderado"] = PrecioPonderado;
                            DR2["CostoAcumulado"] = CostoAcumulado;
                            DR2["Operacion"] =  Cantidad.ToString() + "/" + PrecioPonderado.ToString();
                            DtKardex2.Rows.Add(DR2);
                        }
                        DR["KardexID"] = Dr["KardexID"];
                        DR["Tabla"] = Dr["Tabla"];
                        DR["AudCrea"] = Convert.ToDateTime(Convert.ToDateTime(Dr["AudCrea"]).ToShortDateString());
                        DR["UnidadMedidaID"] = Dr["UnidadMedidaID"];
                        DR["CodigoExistencia"] = Dr["CodigoExistencia"];
                        DR["Establecimiento"] = Dr["Establecimiento"];
                        DR["TipoSunat"] = Dr["Tipo"];

                        DtKardex.Rows.Add(DR);

             //           if (CantidadAcumulada < 0 | PrecioPonderado < 0 | CostoAcumulado < 0)
             //           {
             //               throw new Exception( Convert.ToDateTime(Dr["AudCrea"]).ToShortDateString() + "|" + Convert.ToString(Cantidad) + "|" + Convert.ToString(CantidadAcumulada) + "|" + Convert.ToString(PrecioPonderado) + "|" + Convert.ToString(CostoAcumulado)
             //+ "|" + nombreproducto + "|" + codigoproducto);
             //           }
                        ID = ID + 1;
                    }
                    Cantidad = 0; CantidadAcumulada = 0; PrecioPonderado = 0; CostoAcumulado = 0;
                }
                return DtKardex;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "|" + Convert.ToString(Cantidad) + "|" + Convert.ToString(CantidadAcumulada) + "|" + Convert.ToString(PrecioPonderado) + "|" + Convert.ToString(CostoAcumulado)
                + "|" + nombreproducto + "|" + codigoproducto);
            }


        }

        public void getKardex3(DataTable dtTMP, string Mes, string Anho, string RUC, string ruta)
        {
            //afecta [Usp_get_Kardex2]
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);

            //DataTable DtProductoDis = new BaseFunctions().SelectDistinct(dtTMP, "TipoContabilidad");
            //Creamos tabla para ordenar los datos
            DataTable DtKardex = new DataTable("GetKardex");
            DtKardex.Columns.Add("ProductoID", typeof(string));
            DtKardex.Columns.Add("Producto", typeof(string));
            DtKardex.Columns.Add("UM", typeof(string));
            DtKardex.Columns.Add("UnidadMedidaID", typeof(string));
            DtKardex.Columns.Add("Fecha", typeof(string));
            DtKardex.Columns.Add("Tipo", typeof(string));
            DtKardex.Columns.Add("Serie", typeof(string));
            DtKardex.Columns.Add("Numero", typeof(string));
            DtKardex.Columns.Add("Operacion", typeof(string));
            DtKardex.Columns.Add("ECantidad", typeof(decimal));
            DtKardex.Columns.Add("ECostoUnitario", typeof(decimal));
            DtKardex.Columns.Add("ECostoTotal", typeof(decimal));
            DtKardex.Columns.Add("SCantidad", typeof(decimal));
            DtKardex.Columns.Add("SCostoUnitario", typeof(decimal));
            DtKardex.Columns.Add("SCostoTotal", typeof(decimal));
            DtKardex.Columns.Add("FCantidad", typeof(decimal));
            DtKardex.Columns.Add("FCostoUnitario", typeof(decimal));
            DtKardex.Columns.Add("FCostoTotal", typeof(decimal));
            DtKardex.Columns.Add("KardexID", typeof(string));
            DtKardex.Columns.Add("TipoExistencia", typeof(string));
            DtKardex.Columns.Add("Tabla", typeof(string));
            DtKardex.Columns.Add("TipoSunat", typeof(string));
            DtKardex.Columns.Add("CodigoExistencia", typeof(string));
            DtKardex.Columns.Add("AudCrea", typeof(DateTime));
            DtKardex.Columns.Add("Establecimiento", typeof(string));

            //Seleccionamos disticnt de los productos
            DataTable DtProductos = new DataTable();
            DtProductos = dtTMP.DefaultView.ToTable(true, "ProductoID");

            foreach (DataRow DRP in DtProductos.Rows)
            {
                //filtramos datos por producto
                DataView Dv = new DataView(dtTMP, "ProductoID='" + DRP["ProductoID"].ToString() + "'", "AudCrea ASC", DataViewRowState.CurrentRows);
                DataView DvCierre = new DataView(dtTMP, "ProductoID='" + DRP["ProductoID"].ToString() + "'", "ID DESC", DataViewRowState.CurrentRows);

                foreach (DataRowView Dr in Dv)
                {
                    DataRow DR = DtKardex.NewRow();

                    DR["ProductoID"] = Dr["ProductoID"];
                    DR["Producto"] = Dr["Producto"];
                    DR["UM"] = Dr["UM"];
                    DR["UnidadMedidaID"] = Dr["UnidadMedidaID"];
                    DR["Fecha"] = Convert.ToDateTime(Dr["AudCrea"]).ToShortDateString();
                    if (Dr["Tipo"].ToString() == "99")
                        DR["Tipo"] = "00";
                    else
                        DR["Tipo"] = Dr["Tipo"];

                    if (Dr["Serie"].ToString() == "PRO")
                        DR["Serie"] = "0900";
                    else
                        DR["Serie"] = Dr["Serie"].ToString().PadLeft(4, '0');

                    DR["Numero"] = Dr["Numero"].ToString().PadLeft(7, '0');
                    DR["Operacion"] = Dr["Operacion"];
                    DR["TipoExistencia"] = Dr["TipoExistencia"];


                    if (Dr["ECantidad"] is DBNull)
                        DR["ECantidad"] = 0;
                    else
                        DR["ECantidad"] = Dr["ECantidad"];

                    if (Dr["ECostoUnitario"] is DBNull)
                        DR["ECostoUnitario"] = 0;
                    else
                        DR["ECostoUnitario"] = Dr["ECostoUnitario"];

                    if (Dr["ECostoTotal"] is DBNull)
                        DR["ECostoTotal"] = 0;
                    else
                        DR["ECostoTotal"] = Dr["ECostoTotal"];

                    if (Dr["SCantidad"] is DBNull)
                        DR["SCantidad"] = 0;
                    else
                        DR["SCantidad"] = Dr["SCantidad"];

                    if (Dr["SCostoUnitario"] is DBNull)
                        DR["SCostoUnitario"] = 0;
                    else
                        DR["SCostoUnitario"] = Dr["SCostoUnitario"];

                    if (Dr["SCostoTotal"] is DBNull)
                        DR["SCostoTotal"] = 0;
                    else
                        DR["SCostoTotal"] = Dr["SCostoTotal"];

                    if (Dr["FCantidad"] is DBNull)
                        DR["FCantidad"] = 0;
                    else
                        DR["FCantidad"] = Dr["FCantidad"];

                    if (Dr["FCostoUnitario"] is DBNull)
                        DR["FCostoUnitario"] = 0;
                    else
                        DR["FCostoUnitario"] = Dr["FCostoUnitario"];

                    if (Dr["FCostoTotal"] is DBNull)
                        DR["FCostoTotal"] = 0;
                    else
                        DR["FCostoTotal"] = Dr["FCostoTotal"];
                    if (Dr["TipoSunat"].ToString() == "A")
                        DR["TipoSunat"] = "A";
                    else
                        DR["TipoSunat"] = "M";


                    DR["KardexID"] = Dr["KardexID"];
                    DR["Tabla"] = Dr["Tabla"];
                    DR["CodigoExistencia"] = Dr["CodigoExistencia"];
                    DR["AudCrea"] = Dr["AudCrea"];
                    DR["Establecimiento"] = Dr["Establecimiento"];


                    DtKardex.Rows.Add(DR);
                }
                //=====================================================================================
                ////Ahora insertamos el cierre
                DataRow DRF = DtKardex.NewRow();
                DRF["ProductoID"] = DvCierre[0]["ProductoID"];
                DRF["Producto"] = DvCierre[0]["Producto"];
                DRF["UM"] = DvCierre[0]["UM"];
                DRF["UnidadMedidaID"] = DvCierre[0]["UnidadMedidaID"];
                DRF["Fecha"] = Convert.ToDateTime(DvCierre[0]["AudCrea"]).AddMonths(1).AddDays(-1).ToShortDateString();
                DRF["Tipo"] = "00";
                DRF["Serie"] = "0";
                DRF["Numero"] = "0";
                DRF["Operacion"] = "99";
                DRF["TipoExistencia"] = DvCierre[0]["TipoExistencia"];
                DRF["ECantidad"] = 0;
                DRF["ECostoUnitario"] = 0;
                DRF["ECostoTotal"] = 0;
                DRF["SCantidad"] = 0;
                DRF["SCostoUnitario"] = 0;
                DRF["SCostoTotal"] = 0;
                DRF["FCantidad"] = DvCierre[0]["FCantidad"];
                DRF["FCostoUnitario"] = DvCierre[0]["FCostoUnitario"];
                DRF["FCostoTotal"] = DvCierre[0]["FCostoTotal"];
                DRF["TipoSunat"] = "C";
                string valorreemplazo = NumeroEnLetra(Convert.ToInt32(DvCierre[0]["KardexID"]));
                DRF["KardexID"] = valorreemplazo;
                DRF["Tabla"] = DvCierre[0]["Tabla"];
                DRF["CodigoExistencia"] = DvCierre[0]["CodigoExistencia"];
                DRF["AudCrea"] = DvCierre[0]["AudCrea"];
                DRF["Establecimiento"] = DvCierre[0]["Establecimiento"];
                DtKardex.Rows.Add(DRF);
                //=====================================================================================
            }

            //KG	KILOGRAMOS	01
            //MT	METROS	00
            //CM	CENTIMETROS	00
            //DM	DECIMETROS	00
            //DO	DOCENA	00
            //UN	UNIDAD	07
            //PQ	PAQUETES	00
            //LT	Litros	08
            //GR	GRAMOS	00
            //SC	Sacos	00
            //GL	GALON	09
            //ML	MILILITROS	00

            //NIU	number of international units
            //KGM	kilogram
            //MTR	metre
            //LTR	litre
            //PK	package


            // Compose a string that consists of three lines.
            StringBuilder stbLineas = new StringBuilder("");
            foreach (DataRow DR in DtKardex.Rows)
            {
                string UM = "";
                if (DR["UnidadMedidaID"].ToString() == "UN")
                    UM = "NIU";
                else if (DR["UnidadMedidaID"].ToString() == "KG")
                    UM = "KGM";
                else if (DR["UnidadMedidaID"].ToString() == "MT")
                    UM = "MTR";
                else if (DR["UnidadMedidaID"].ToString() == "LT")
                    UM = "LTR";
                else if (DR["UnidadMedidaID"].ToString() == "PQ")
                    UM = "PK";
                else if (DR["UnidadMedidaID"].ToString() == "GL")
                    UM = "GLL";
                else if (DR["UnidadMedidaID"].ToString() == "GR")
                    UM = "GRM";
                else
                    UM = "ERR";

                string PRODUCTO = "";
                if (DR["Producto"].ToString().Length > 80)
                    PRODUCTO = DR["Producto"].ToString().Substring(0, 80);
                else
                    PRODUCTO = DR["Producto"].ToString();

                stbLineas.Append(Anho + Mes.PadLeft(2, '0') + "00" + "|" + //año y mes
                     DR["KardexID"].ToString() + "|" +  //id identificador
                     DR["TipoSunat"].ToString() + DR["KardexID"].ToString() + "|" + //tipo de movimiento  A M C
                      DR["Establecimiento"].ToString() + "|" + //Código de establecimiento anexo (falta)
                     "9" + "|" + //Código del catálogo 
                     DR["CodigoExistencia"].ToString() + "|" + //Tipo de existencia
                     DR["CodigoExistencia"].ToString() + "|" + //Código propio de la existencia 
                     "0000000000000000" + "|" + //Código OSCE 
                     Convert.ToDateTime(DR["AudCrea"]).Day.ToString().PadLeft(2, '0') + "/" + Convert.ToDateTime(DR["AudCrea"]).Month.ToString().PadLeft(2, '0') + "/" + Convert.ToDateTime(DR["AudCrea"]).Year.ToString() + "|" + //Fecha de emisió
                     DR["Tipo"].ToString() + "|" + //Tipo del documento de traslado, comprobante de pago, documento interno o similar
                     DR["Serie"].ToString() + "|" + //Número de serie del documento de traslado, comprobante de pago, documento interno o similar
                     DR["Numero"].ToString() + "|" + //Número del documento de traslado, comprobante de pago, documento interno o similar
                     DR["Operacion"].ToString() + "|" + //Tipo de operación efectuada
                     PRODUCTO + "|" + //Descripción de la existencia
                     UM + "|" + //Código de la unidad de medida
                     "1" + "|" + //Código del Método de valuación de existencias aplicado (hata tengo entendido es el promedio ponderado)
                     Convert.ToDecimal(DR["ECantidad"]).ToString("#########0.00") + "|" +  //Cantidad de unidades físicas del bien ingresado (la primera tupla corresponde al saldo inicial)
                     Convert.ToDecimal(DR["ECostoUnitario"]).ToString("#########0.00") + "|" + //Costo unitario del bien ingresado
                     Convert.ToDecimal(DR["ECostoTotal"]).ToString("#########0.00") + "|" + //Costo total del bien ingresado
                     Convert.ToDecimal(DR["SCantidad"]).ToString("#########0.00") + "|" +//Cantidad de unidades físicas del bien retirado
                     Convert.ToDecimal(DR["SCostoUnitario"]).ToString("#########0.00") + "|" + //Costo unitario del bien retirado
                     Convert.ToDecimal(DR["SCostoTotal"]).ToString("#########0.00") + "|" + //Costo total del bien retirado
                     Convert.ToDecimal(DR["FCantidad"]).ToString("#########0.00") + "|" + //Cantidad de unidades físicas del saldo final
                     Convert.ToDecimal(DR["FCostoUnitario"]).ToString("#########0.00") + "|" + //Costo unitario del saldo final
                     Convert.ToDecimal(DR["FCostoTotal"]).ToString("#########0.00") + "|" + //Costo total del saldo final
                     "1" + "|\r\n" + //Indica el estado de la operación (se asume que es la operacion del mes)
                "");



            }

            //Nombre del archivo
            //LERRRRRRRRRRRAAAAMM0013010000OIM1.TXT
            string NombreArchivo = "";
            NombreArchivo = "LE" + RUC + Anho + Mes + "00" + "130100" + "00" + "0" + "1" + "1" + "1";

            // Write the string to a file.
            if (ruta.Substring(ruta.Length - 1, 1) != @"\")
            {
                ruta = ruta + @"\";
            }

            System.IO.StreamWriter file = new System.IO.StreamWriter(ruta + NombreArchivo + ".TXT");
            string cadena = stbLineas.ToString();
            file.WriteLine(cadena.Substring(0, cadena.Length - 1));


            file.Close();

        }

        public DataTable getKardex_Producto(string ProductoID, string SedeID)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Kardex.getKardex_Producto(ProductoID, SedeID);
            return dtTMP;

        }


        public DataTable getDTKardex_varios(string ProductoID, string EmpresaID, DateTime FechaInicial, DateTime FechaFinal, string Sede, int Accion)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable("DtKardex");
            dtTMP = ObjCD_Kardex.getDTKardex2(ProductoID, EmpresaID, FechaInicial, FechaFinal, Sede, Accion);
            return dtTMP;

        }

        public DataTable getDTKardexPLE(string ProductoID, string EmpresaID, int Periodo, int Mes)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable("DtKardex");
            dtTMP = ObjCD_Kardex.getDTKardexPLE(ProductoID, EmpresaID, Periodo, Mes);
            return dtTMP;

        }

        public void InsertDesperdicio(DataTable dtSalida, string AlmacenID, int TipoMovimiento, int UsuarioID)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);

            dtSalida.TableName = "Movimiento";
            string _xml = new BaseFunctions().GetXML(dtSalida).Replace("NewDataSet", "DocumentElement");
            string xml = _xml.Replace("Table", "Movimiento");

            ObjCD_Kardex.InsertDesperdicio(AlmacenID, TipoMovimiento, UsuarioID, xml);
        }

        public void InsertConsumo(DataTable dtConsumo, int UsuarioID)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);

            dtConsumo.TableName = "Consumo";
            string _xml = new BaseFunctions().GetXML(dtConsumo).Replace("NewDataSet", "DocumentElement");
            string xml = _xml.Replace("Table", "Consumo");

            ObjCD_Kardex.InsertConsumo(UsuarioID, xml);
        }

        public void UpdateXMLKardex(DataTable DTModificar)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);

            DTModificar.TableName = "Modificar";
            string _xml = new BaseFunctions().GetXML(DTModificar).Replace("NewDataSet", "DocumentElement");
            string xml = _xml.Replace("Table", "Modificar");

            ObjCD_Kardex.UpdateXMLKardex(xml);
        }

        public void UpdateXMLCierreMensual(DataTable DTModificar)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);

            DTModificar.TableName = "Modificar";
            string _xml = new BaseFunctions().GetXML(DTModificar).Replace("NewDataSet", "DocumentElement");
            string xml = _xml.Replace("Table", "Modificar");

            ObjCD_Kardex.UpdateXMLCierreMensual(xml);
        }

        public DataTable GetTipoDocumento()
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Kardex.GetTipoDocumento();
            return dtTMP;
        }
        public DataTable GetOperacionKardex()
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Kardex.GetOperacionKardex();
            return dtTMP;
        }

        public DataTable GetMovimiento()
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Kardex.GetMovimiento();
            return dtTMP;
        }

        public int InsertKardex(E_Kardex ObjE_Kardex, DataTable DtKardex, string Tipo)
        {
            int KardexID = 0;
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            string XML = "";

            if (Tipo == "M")
            {
                string _xml = new BaseFunctions().GetXML(DtKardex).Replace("NewDataSet", "DocumentElement");
                XML = _xml.Replace("Table", "Kardex");
            }

            KardexID = ObjCD_Kardex.InsertKardex(ObjE_Kardex, XML, Tipo);
            return KardexID;
        }

        public bool Existekardex(E_Kardex ObjE_Kardex)
        {
            bool Existe = true;
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            Existe = ObjCD_Kardex.Existekardex(ObjE_Kardex);
            return Existe;
        }
        public int InsertCierreKardex(int Accion, int UsuarioID, string Almacen, string ProductoID, string EmpresaID, string Periodo, int Anno, bool CostoCero, decimal Cantidad2, decimal CostoUnitario)
        {
            int totalAfectados = 0;
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            if (Accion == 1)
            {

                DataTable dtTMP = new DataTable();
                DataTable dtTMP2 = new DataTable();
                if (CostoCero == false)
                {

                    //aplicar la lógica del cierre en el reporte mensual
                    if (ProductoID == "TODOS")
                        ProductoID = "";


                    DateTime FecInicial, FecFinal;
                    FecInicial = new DateTime(Anno, Convert.ToInt16(Periodo), 1);
                    FecFinal = new DateTime(Anno, Convert.ToInt16(Periodo), 1).AddMonths(1);


                    dtTMP2 = new CL_Kardex().getDTKardex_varios(ProductoID, EmpresaID, FecInicial, FecFinal, Almacen, 1);
                    dtTMP = new CL_Kardex().ArmarReporteKardex(dtTMP2);


                    //Seleccionamos disticnt de los productos
                    DataTable DtProductos = new DataTable();
                    DtProductos = dtTMP.DefaultView.ToTable(true, "ProductoID");

                    //tabla apra agregar los cierres
                    DataTable DTCierre = new DataTable("Cierre");
                    DTCierre.Columns.Add("ProductoID", typeof(string));
                    DTCierre.Columns.Add("Cantidad", typeof(decimal));
                    DTCierre.Columns.Add("CostoUnitario", typeof(decimal));


                    foreach (DataRow DRP in DtProductos.Rows)
                    {
                        //filtramos datos por producto
                        DataView Dv = new DataView(dtTMP, "ProductoID='" + DRP["ProductoID"].ToString() + "'", "ID DESC", DataViewRowState.CurrentRows);

                        DataRow DR = DTCierre.NewRow();
                        DR["ProductoID"] = DRP["ProductoID"];
                        DR["Cantidad"] = decimal.Round(Convert.ToDecimal(Dv[0]["FCantidad"]), 2);
                        DR["CostoUnitario"] = decimal.Round(Convert.ToDecimal(Dv[0]["FCostoUnitario"]), 2);
                        DTCierre.Rows.Add(DR);


                    }
                    string XML = "";
                    string _xml = new BaseFunctions().GetXML(DTCierre).Replace("NewDataSet", "DocumentElement");
                    XML = _xml.Replace("Table", "Cierre");

                    //insercion masiva del kardex
                    totalAfectados = ObjCD_Kardex.InsertCierreKardex(Accion, XML, UsuarioID, null, null, EmpresaID, Periodo, Anno, false, Cantidad2, CostoUnitario);




                }
                else
                {
                    string XML = "";
                    totalAfectados = ObjCD_Kardex.InsertCierreKardex(Accion, XML, UsuarioID, Almacen, ProductoID, EmpresaID, Periodo, Anno, CostoCero, Cantidad2, CostoUnitario);
                }
            }
            else if (Accion == 2)
            {
                //ingreso manual
                totalAfectados = ObjCD_Kardex.InsertCierreKardex(Accion, "", UsuarioID, Almacen, ProductoID, EmpresaID, Periodo, Anno, CostoCero, Cantidad2, CostoUnitario);
            }
            return totalAfectados;
        }

        public void UpdateMovimiento(E_Movimiento ObjMovimiento, string Tipo)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            ObjCD_Kardex.UpdateMovimiento(ObjMovimiento, Tipo);
        }

        public void InserMovimiento(E_Movimiento ObjMovimiento)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            ObjCD_Kardex.InserMovimiento(ObjMovimiento);
        }

        public void UpdateOperacion(E_Operacion ObjOperacion, string Tipo)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            ObjCD_Kardex.UpdateOperacion(ObjOperacion, Tipo);
        }

        public void InsertOperacion(E_Operacion ObjOperacion)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            ObjCD_Kardex.InsertOperacion(ObjOperacion);
        }

        public void UpdateTipoDocumento(E_TipoDocumento ObjTipoDocumento, string Tipo)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            ObjCD_Kardex.UpdateTipoDocumento(ObjTipoDocumento, Tipo);
        }

        public void InsertTipoDocumento(E_TipoDocumento ObjTipoDocumento)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            ObjCD_Kardex.InsertTipoDocumento(ObjTipoDocumento);
        }

        public void DeleteKardex(int KardexID)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            ObjCD_Kardex.DeleteKardex(KardexID);
        }

        private string NumeroEnLetra(int valorNumerico)
        {
            Int16 valor = Convert.ToInt16(valorNumerico.ToString().Substring(0, 1));
            string respuesta = "";
            if (valor == 0)
                respuesta = "A";
            else if (valor == 1)
                respuesta = "B";
            else if (valor == 2)
                respuesta = "C";
            else if (valor == 3)
                respuesta = "D";
            else if (valor == 4)
                respuesta = "E";
            else if (valor == 5)
                respuesta = "F";
            else if (valor == 6)
                respuesta = "G";
            else if (valor == 7)
                respuesta = "H";
            else if (valor == 8)
                respuesta = "I";
            else if (valor == 9)
                respuesta = "J";

            return respuesta + valorNumerico.ToString().Substring(1, valorNumerico.ToString().Length - 1);
        }
    }
}
