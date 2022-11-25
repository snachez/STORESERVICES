# STORESERVICES
Servicio de compra de libros.
<br />Cada servicio contiene su capa (MODEL, DAO, SERVICES, API)
<br />El api gateway es con ocelot

# STORESERVICES.API.AUTHOR
Servicio que puede crear, obtener por AutorLibroGuid y obtener todos los autores 
<br />ej: AutorLibroGuid = E5F9CBC6-B91C-4CF5-B049-7D50B76A17C8

# STORESERVICES.API.BOOK
Servicio que puede crear, obtener por LibreriaMaterialId y obtener todos los libros
<br />ej: LibreriaMaterialId = E7FF889E-8525-4417-9756-08DAA1989575

# STORESERVICES.API.SHOPPINGCART
Servicio que puede crear y obtener por CartSessionId el carrito de compra
<br />ej: CartSessionId = 1

# STORESERVICES.API.GATEWAY
Servicio que sirve de puente de comunicacion entre los servicios y el frontend

# Health check Ui
Tambien si uno quiere puede centralizar todos los health check en una sola pagina. para que una sola api se encargue de eso
![health-check-status-ui](https://user-images.githubusercontent.com/31715033/204013078-710d1246-5b14-432e-b23c-a47f05c398d4.png)
