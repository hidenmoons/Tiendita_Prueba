# Tiendita_Prueba
Prueba Técnica: Solución para una Tienda en Línea

Bienvenido a la descripción de la solución técnica desarrollada para abordar los problemas y mejorar la funcionalidad de una tienda en línea. A continuación, se presenta un resumen detallado de cómo se abordaron los problemas y las tecnologías utilizadas en esta solución.
Problemas Identificados

La tienda en línea presentaba varios problemas, como la pérdida de datos de carrito de compras y usuarios al cerrar la aplicación, entre otros. Para resolver estos problemas, se realizó una serie de pasos que se detallan a continuación.
Base de Datos y Modelo de Datos

Se creó una base de datos utilizando relaciones y claves primarias para garantizar la integridad y persistencia de los datos. Aquí hay una representación visual de la estructura de la base de datos:

Backend - Tecnologías Utilizadas

Se utilizó el framework .NET para desarrollar el backend de la aplicación. El enfoque elegido fue el de "Database First", que permitió generar automáticamente los modelos de datos a partir de la estructura de la base de datos. Aquí se muestra el comando utilizado para generar los modelos:

dotnet ef dbcontext scaffold "Data Source=(localdb)\Hidenmoons;Initial Catalog=Store_LowCost;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models

Autenticación y Seguridad

Se implementó la autenticación basada en JWT (JSON Web Tokens) para garantizar la seguridad de la aplicación. Los usuarios pueden registrarse y luego iniciar sesión para obtener un token JWT que se utiliza para autorizar las solicitudes.
Endpoints y Repositorios

Se crearon endpoints para manejar las operaciones de carrito, pedidos, productos y usuarios. Estos endpoints se desacoplaron mediante la implementación de repositorios y se utilizaron interfaces para definir los contratos de acceso a los datos. La inyección de dependencias se configuró en el archivo Program.cs para asegurar la correcta funcionalidad del proyecto.
Frontend - Tecnologías Utilizadas

La interfaz de usuario se desarrolló utilizando Angular. Se crearon pantallas de registro y inicio de sesión que permiten a los usuarios autenticarse. Además, se implementó una vista de catálogo que solo se puede acceder si el usuario ha iniciado sesión.
Funcionalidades Clave

    Registro de usuarios
    Inicio de sesión con JWT
    Catálogo de productos
    Agregar productos al carrito
    Visualizar y editar el carrito de compras
    Pago de artículos en el carrito
    Interfaz de administrador con acceso restringido

Capturas de Pantalla
![imagen](https://github.com/hidenmoons/Tiendita_Prueba/assets/26952057/eefa36e3-dcc3-41fa-b544-cc2706661ed1)
accediendo
![imagen](https://github.com/hidenmoons/Tiendita_Prueba/assets/26952057/8644b9ff-6cbb-40c2-8657-449e2a25d2c0)
recuperamos el jwt y el user
![imagen](https://github.com/hidenmoons/Tiendita_Prueba/assets/26952057/9cf39a58-eb57-4f78-9848-9829e6ebe54d)
agregamos un  item al carrito 
![imagen](https://github.com/hidenmoons/Tiendita_Prueba/assets/26952057/5efba292-0fd7-4477-a6f1-883399342c73)
tenemos nuestro carrito 
![imagen](https://github.com/hidenmoons/Tiendita_Prueba/assets/26952057/9a041abb-4627-43dd-af8f-efb2c5430af0)
forma de pago 
![imagen](https://github.com/hidenmoons/Tiendita_Prueba/assets/26952057/cef0c709-713e-4431-815f-537c9aed96c7)
una vez pagado se vacia el carrito 
![imagen](https://github.com/hidenmoons/Tiendita_Prueba/assets/26952057/89249ad2-eb3c-4cc2-8493-4fb6f405f267)
si somso admins podemos utilizar este crud 
![imagen](https://github.com/hidenmoons/Tiendita_Prueba/assets/26952057/8d15318d-cf08-4c1f-b2b6-bdd352868851)
para editar o borrar 
![imagen](https://github.com/hidenmoons/Tiendita_Prueba/assets/26952057/118777e9-c56f-4dd0-832c-bf9a7a871d1f)
![imagen](https://github.com/hidenmoons/Tiendita_Prueba/assets/26952057/072490ef-f53c-4d43-91a5-9943a8c64bc8)
y tambien para agregar 
![imagen](https://github.com/hidenmoons/Tiendita_Prueba/assets/26952057/54fe271f-0ce5-41a4-afe3-c01db6a39c78)

En resumen, esta solución técnica abordó los problemas identificados en la tienda en línea mediante la implementación de una base de datos robusta, un backend seguro y una interfaz de usuario amigable. Las tecnologías utilizadas permiten un manejo eficiente de los datos y proporcionan una experiencia fluida para los usuarios. Con este enfoque, se espera haber mejorado significativamente la funcionalidad y la seguridad de la tienda en línea.
Contacto

Si tienes alguna pregunta o consulta sobre esta solución técnica, no dudes en ponerte en contacto alexis_dx8@hotmail.com.
