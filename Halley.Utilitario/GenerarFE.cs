using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Halley.Utilitario
{
    public class GenerarFE
    {
        public string GenerarPdf(DataSet DS, string RutaGuardar, string NombreArchivo, String RespuestaSunat)
        {
            try
            {
                CrystalReports.CrFE rpt = new CrystalReports.CrFE();
                DS.Tables[0].TableName = "Cabecera";
                DS.Tables[1].TableName = "Detalle";
                rpt.SetDataSource(DS);

                TextFunctions ObjTextFunctions = new TextFunctions();
                string TotalPagarLetras = ObjTextFunctions.enletras((DS.Tables[0].Rows[0]["ImporteTotal"]).ToString());


                TextObject TxtMontoLetras;
                TxtMontoLetras = (TextObject)rpt.ReportDefinition.ReportObjects["TxtMontoLetras"];
                TxtMontoLetras.Text = TotalPagarLetras + " Soles.";

                TextObject TxtRespuestaSunat;
                TxtRespuestaSunat = (TextObject)rpt.ReportDefinition.ReportObjects["TxtRespuestaSunat"];
                TxtRespuestaSunat.Text = RespuestaSunat;

                //ExportOptions CrExportOptions;
                //DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                //PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                //CrDiskFileDestinationOptions.DiskFileName = RutaGuardar;
                //CrExportOptions = rpt.ExportOptions;
                //{
                //    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                //    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                //    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                //    CrExportOptions.FormatOptions = CrFormatTypeOptions;

                //}
                //rpt.Export();
                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, RutaGuardar + NombreArchivo + ".pdf");
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
}
