use [ERP_HALLEYnuevo31-05-2017]
go

select * from Empresa.Empresa;
--NO OLVIDAR COMPARTIR LAS CARPETAS
insert into Empresa.empresa
([EmpresaID], [NomEmpresa], [RUC], [DomicilioFiscal],
[Telefono], [FlgEst], [UsuarioID], [AudCrea],
 [RutaXMLFE], [RutaCDRFE], [RutaCertificado], [ClaveCertificado],
[UsuarioSOL], [ClaveSol], [EmiteFE], [GenerarFisico], [EsVentas], [RutaArchivosSunat], [RutaBDSunat], 
[RutaWS], [ValidezId], [ValidezClave])

SELECT 'SD', 'GANADERIA SANTO DOMINGO E.I.R.L.','20394070867', 'JR. 7 DE JUNIO NRO. 400 (2DO PISO, LOCAL HALLEY) UCAYALI - CORONEL PORTILLO - CALLERIA',
'061574776',1, GETDATE(),
'D:\FE_SD\XML\','D:\FE_SD\CDR\','D:\FE_SD\SANTODOMINGO.pfx','ganaderia1234',
'JULIO111','123456aB','S','S',1,'\\domserver\SFS_9004\sunat_archivos\sfs\DATA','\\domserver\SFS_9004\bd\BDFacturador.db',
'','1b71e358-b0c4-4922-b245-bfc10aaae29e','ofbHcmGE4DcYgo901AcuSQ=='
UNION
SELECT 'GP', 'AGROPECUARIA HALLEY E.I.R.L.', '20604982651', 'JR. REQUENA NRO. 107 (AL COSTADO DEL GRIFO JACKELINE) UCAYALI - CORONEL PORTILLO - CALLERIA',
'961634544',1, GETDATE(),
'D:\FE_GP\XML\','D:\FE_GP\CDR\','D:\FE_GP\AGROPECUARIAHALLEY.pfx','agropecuaria1234',
'JULIO111','123456aB','S','S',1,'\\domserver\SFS_9005\sunat_archivos\sfs\DATA','\\domserver\SFS_9005\bd\BDFacturador.db',
'','a20c1fed-ab6f-4888-8f48-dfbd1333af1b','PEi4hhddxg8/autXr5z6zw=='
