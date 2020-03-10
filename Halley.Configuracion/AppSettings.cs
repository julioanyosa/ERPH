using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace Halley.Configuracion
{
    public class AppSettings
    {
        public static string GetConnectionString
        {
            get { return ConfigurationManager.AppSettings["ConnectionString"]; }
        }

        public static string GetConnectionStringFS
        {
            get { return ConfigurationManager.AppSettings["GetConnectionStringFS"]; }
        }

        public static string GetConnectionStringSIL
        {
            get { return ConfigurationManager.AppSettings["ConnectionStringSIL"]; }
        }

        public static string AreaMaestra
        {
            get { return ConfigurationManager.AppSettings["AreaMaestra"]; }
        }


        public static string SupportEmail
        {
            get { return ConfigurationManager.AppSettings["SupportEmail"]; }
        }


        public static string SmtpServer
        {
            get { return ConfigurationManager.AppSettings["SmtpServer"]; }
        }

        //************************************************************************

        static string _EmpresaID;

        public static string EmpresaID
        {
            get { return AppSettings._EmpresaID; }
            set { AppSettings._EmpresaID = value; }
        }


        static string _NomEmpresa;

        public static string NomEmpresa
        {
            get { return AppSettings._NomEmpresa; }
            set { AppSettings._NomEmpresa = value; }
        }

        static string _RUCEmpresa;

        public static string RUCEmpresa
        {
            get { return AppSettings._RUCEmpresa; }
            set { AppSettings._RUCEmpresa = value; }
        }

        static string _SedeID;

        public static string SedeID
        {
            get { return AppSettings._SedeID; }
            set { AppSettings._SedeID = value; }
        }

        static string _NomSede;

        public static string NomSede
        {
            get { return AppSettings._NomSede; }
            set { AppSettings._NomSede = value; }
        }

        static string _UbicacionSede;

        public static string UbicacionSede
        {
            get { return AppSettings._UbicacionSede; }
            set { AppSettings._UbicacionSede = value; }
        }

        static string _TelfSede;

        public static string TelfSede
        {
            get { return AppSettings._TelfSede; }
            set { AppSettings._TelfSede = value; }
        }

        static int _perfil;

        public static int Perfil
        {
            get { return AppSettings._perfil; }
            set { AppSettings._perfil = value; }
        }

        static string _NomPerfil;

        public static string NomPerfil
        {
            get { return AppSettings._NomPerfil; }
            set { AppSettings._NomPerfil = value; }
        }


        //************************************************************************

        static string _AssignedMenu;

        public static string AssignedMenu
        {
            get { return AppSettings._AssignedMenu; }
            set { AppSettings._AssignedMenu = value; }
        }

        static string _AlmacenAsignado;

        public static string AlmacenAsignado
        {
            get { return AppSettings._AlmacenAsignado; }
            set { AppSettings._AlmacenAsignado = value; }
        }

        static DataTable _AssignedPermission;

        public static DataTable AssignedPermission
        {
            get { return AppSettings._AssignedPermission; }
            set { AppSettings._AssignedPermission = value; }
        }

        static DataTable _Almacen;

        public static DataTable Almacen
        {
            get { return AppSettings._Almacen; }
            set { AppSettings._Almacen = value; }
        }

        static DataTable _AlmacenPermisos;

        public static DataTable AlmacenPermisos
        {
            get { return AppSettings._AlmacenPermisos; }
            set { AppSettings._AlmacenPermisos = value; }
        }


        static DataTable _SedesPermiso;

        public static DataTable SedesPermiso
        {
            get { return AppSettings._SedesPermiso; }
            set { AppSettings._SedesPermiso = value; }
        }

        //************************************************************************

        public static string ReportServerUrl
        {
            get { return ConfigurationManager.AppSettings["ReportServerUrl"]; }
        }

        public static string RibbonStyle
        {
            get { return ConfigurationManager.AppSettings["RibbonStyle"]; }
        }

        public static string Version
        {
            get { return ConfigurationManager.AppSettings["Version"]; }
        }

        public static string LeadTime
        {
            get { return ConfigurationManager.AppSettings["LeadTime"]; }
        }

        //************************************************************************

        static UserControl _controlChild;

        public static UserControl ControlChild
        {
            get { return AppSettings._controlChild; }
            set { AppSettings._controlChild = value; }
        }

        public static string UserLatest
        {
            get { return ConfigurationManager.AppSettings["User"]; }
        }

        public static string UserClave
        {
            get { return ConfigurationManager.AppSettings["Clave"]; }
        }

        public static string RutaCrystalReports
        {
            get { return ConfigurationManager.AppSettings["RutaCrystalReports"]; }
        }

        public static string ImpresoraBoletaGranja
        {
            get { return ConfigurationManager.AppSettings["ImpresoraBoletaGranja"]; }
        }

        public static string ImpresoraBoletaIndustria
        {
            get { return ConfigurationManager.AppSettings["ImpresoraBoletaIndustria"]; }
        }

        public static string ImpresoraBoletaComercio
        {
            get { return ConfigurationManager.AppSettings["ImpresoraBoletaComercio"]; }
        }

        public static string ImpresoraBoletaAvicola
        {
            get { return ConfigurationManager.AppSettings["ImpresoraBoletaAvicola"]; }
        }

        public static string ImpresoraFacturaGranja
        {
            get { return ConfigurationManager.AppSettings["ImpresoraFacturaGranja"]; }
        }

        public static string ImpresoraFacturaComercio
        {
            get { return ConfigurationManager.AppSettings["ImpresoraFacturaComercio"]; }
        }

        public static string ImpresoraFacturaIndustria
        {
            get { return ConfigurationManager.AppSettings["ImpresoraFacturaIndustria"]; }
        }

        public static string ImpresoraFacturaAvicola
        {
            get { return ConfigurationManager.AppSettings["ImpresoraFacturaAvicola"]; }
        }

        public static string ImpresoraTicketGranja
        {
            get { return ConfigurationManager.AppSettings["ImpresoraTicketGranja"]; }
        }

        public static string ImpresoraTicketComercio
        {
            get { return ConfigurationManager.AppSettings["ImpresoraTicketComercio"]; }
        }

        public static string ImpresoraTicketIndustria
        {
            get { return ConfigurationManager.AppSettings["ImpresoraTicketIndustria"]; }
        }

        public static string ImpresoraTicketAvicola
        {
            get { return ConfigurationManager.AppSettings["ImpresoraTicketAvicola"]; }
        }

        public static string ImpresoraPago
        {
            get { return ConfigurationManager.AppSettings["ImpresoraPago"]; }
        }


        public static float BoletaEjeX
        {
            get { return float.Parse(ConfigurationManager.AppSettings["BoletaEjeX"]); }
        }

        public static float BoletaEjeY
        {
            get { return float.Parse(ConfigurationManager.AppSettings["BoletaEjeY"]); }
        }

        public static string ImpresoraGuiaRemitentePeso
        {
            get { return ConfigurationManager.AppSettings["ImpresoraGuiaRemitentePeso"]; }
        }

        public static float FacturaEjeX
        {
            get { return float.Parse(ConfigurationManager.AppSettings["FacturaEjeX"]); }
        }
        public static float FacturaEjeY
        {
            get { return float.Parse(ConfigurationManager.AppSettings["FacturaEjeY"]); }
        }
        public static string ImpresoraGuiaRemitente
        {
            get { return ConfigurationManager.AppSettings["ImpresoraGuiaRemitente"]; }
        }

        public static string ImpresoraGuiaTransportista
        {
            get { return ConfigurationManager.AppSettings["ImpresoraGuiaTransportista"]; }
        }

        public static string GetConnectionStringGestNet
        {
            get { return ConfigurationManager.AppSettings["ConnectionStringGestNet"]; }
        }

        public static string SerialPortBalanza
        {
            get { return ConfigurationManager.AppSettings["SerialPortBalanza"]; }
        }

        public static string GHSerieDefectoBoleta
        {
            get { return ConfigurationManager.AppSettings["GHSerieDefectoBoleta"]; }
        }
        public static string GHSerieDefectoFactura
        {
            get { return ConfigurationManager.AppSettings["GHSerieDefectoFactura"]; }
        }
        public static string GHSerieDefectoTicket
        {
            get { return ConfigurationManager.AppSettings["GHSerieDefectoTicket"]; }
        }
        public static string IHSerieDefectoBoleta
        {
            get { return ConfigurationManager.AppSettings["IHSerieDefectoBoleta"]; }
        }
        public static string IHSerieDefectoFactura
        {
            get { return ConfigurationManager.AppSettings["IHSerieDefectoFactura"]; }
        }
        public static string IHSerieDefectoTicket
        {
            get { return ConfigurationManager.AppSettings["IHSerieDefectoTicket"]; }
        }
        public static string CHSerieDefectoBoleta
        {
            get { return ConfigurationManager.AppSettings["CHSerieDefectoBoleta"]; }
        }
        public static string CHSerieDefectoFactura
        {
            get { return ConfigurationManager.AppSettings["CHSerieDefectoFactura"]; }
        }
        public static string CHSerieDefectoTicket
        {
            get { return ConfigurationManager.AppSettings["CHSerieDefectoTicket"]; }
        }

        public static string AHSerieDefectoBoleta
        {
            get { return ConfigurationManager.AppSettings["AHSerieDefectoBoleta"]; }
        }
        public static string AHSerieDefectoFactura
        {
            get { return ConfigurationManager.AppSettings["AHSerieDefectoFactura"]; }
        }
        public static string AHSerieDefectoTicket
        {
            get { return ConfigurationManager.AppSettings["AHSerieDefectoTicket"]; }
        }

        public static string Key
        {
            get { return "YUXTAPUESTO/ASPI"; }
        }

        public static string IV
        {
            get { return "kabosilva0123456"; }
        }

        //************************************************************************

        static string _userEmail;

        public static string UserEmail
        {
            get { return AppSettings._userEmail; }
            set { AppSettings._userEmail = value; }
        }

        static string usuario;

        public static string Usuario
        {
            get { return AppSettings.usuario; }
            set { AppSettings.usuario = value; }
        }

        static int _userID;

        public static int UserID
        {
            get { return AppSettings._userID; }
            set { AppSettings._userID = value; }
        }

        static string _cadenaAlmacen;

        public static string CadenaAlmacen
        {
            get { return AppSettings._cadenaAlmacen; }
            set { AppSettings._cadenaAlmacen = value; }
        }

        static string _apenom_Login;

        public static string ApeNom_Login
        {
            get { return AppSettings._apenom_Login; }
            set { AppSettings._apenom_Login = value; }
        }

        static object _ImageReporte;

        public static object ImageReporte
        {
            get { return _ImageReporte; }
            set { _ImageReporte = value; }
        }

        #region prueba para reportes

        public static string ReportPath
        {
            get
            {
                return Application.StartupPath + "\\Rpt\\";
            }
        }
        #endregion

    }
}
