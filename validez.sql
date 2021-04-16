alter table empresa.empresa add ValidezId varchar(200), ValidezClave varchar(200) 

update Empresa.Empresa set ValidezId = '3d2b2aca-5b4d-494b-bc5a-911bab3ffe17', ValidezClave = 'lOiFo1rEESdoSv7FH8qbdA=='
update Empresa.Empresa set ValidezId = '3259c931-cb08-455b-a4d5-91391ec4b97e', ValidezClave = '0RWUyJYo5ye1nnkz9oCRrQ==' where EmpresaID = 'IH'   

alter procedure Ventas.ObtenerDatosFacturdorSunat        
(        
@EmpresaID char(2)        
)        
as        
select EmpresaID, NomEmpresa,RutaArchivosSunat,RutaBDSunat, RUC, DomicilioFiscal,RutaXMLFE, RutaCDRFE,  
RutaCertificado,ClaveCertificado,UsuarioSOL,ClaveSol, RutaWS, ValidezId, ValidezClave    
 from Empresa.Empresa where EmpresaID = @EmpresaID     
 go
