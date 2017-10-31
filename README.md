# CRM
# Proyecto 1 Aseguramiento de la calidad del software
# Tecnológico de Costa Rica
# Jonathan Rodriguez
# Melissa Molina
# Edwin Cen.

Pasos para correr el sistema. 
Primero: Cargar los datos de la  base de datos. Para esto en la carpeta de documentación -> ModeloBase -> Base de datos, se encuentra
un backup de los datos de la base de datos, para evitarse hacer los inserts de a la base. Para crear la base se puede crear con el schema 
en la carpeta Base con esquema o sin en schema, en la otra carpeta, esto por si se tiene conflictos con el nombre del esquema que se llama crm.

Para cargar los datos, puede seguir el siguiente tutorial: https://dev.mysql.com/doc/workbench/en/wb-admin-export-import-management.html

Segundo: Una vez cargados los datos, para conectarse a la base de datos desde el proyecto de Visual Studio, se conecta con los credenciales: ";server=localhost;userid=root;database=crm;password=root";
Estos usted los puede configurar de acuerdo a lo que haya puesto al configurar la base.

Una vez que se haya conectado a la base de datos, para entrar al sistema, los credenciales son usuario: Admin, contraseña: 1234567p

El archivo de Javascript para conectar la interfaz al servidor esta en la ruta: CRM_PROYECT -> Vista -> Scripts -> vista.js

Para usar el sistema puede consultar el manual de usuario adjunto en la documentación.

Cualquier duda puede mandar un correo a jonastu.9@gmail.com