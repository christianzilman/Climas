# Climas
Proyecto de prueba técnica. Caso de uso, realizar el muestreo de datos de climas de determinadas Zonas y guardar el Histórico de consultas.   


Configuraciones de base de datos

Crear base de datos en sql server
Nombre: Climas

script sql para las configuraciones

create table ZonaClima
(
	ID int  PRIMARY key , 
	Nombre varchar(255) not null,
	Pais varchar(255) not null
)



create table HistorialConsultaClima
(
	ID int identity(1,1) PRIMARY key,
	IdZonaClima int  FOREIGN KEY REFERENCES ZonaClima(ID), 
	Temperatura numeric(8,2),
	SensacionTermica numeric(8,2),
	FechaConsulta datetime	
)



insert ZonaClima values(3836873,'San Miguel de Tucumán', 'Argentina');



-- para la configuracion de entity framework cambiar la configuracion

"CONNECTION_EF_STRING": "Server=NOMBREDESUSERVER\\SQLEXPRESS;Database=Climas;Persist Security Info=True;User ID=sa;Password=Testeo123;"

que se encuentra en appsetting de la web api como el site mvc.




