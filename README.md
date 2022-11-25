# STORESERVICES
Servicio de compra de libros.
<br />
<br />Cada servicio contiene su capa (MODEL, DAO, SERVICES, API)
<br />
<br />El api gateway es con ocelot. ej: https://arbems.com/api-gateway-en-net-6-con-ocelot/
<br />
<br />Se implemento el patron CQRS. ej: https://arbems.com/cqrs-mediatr-net-6/
<br />
<br />Se implemento como micro ORM a dapper. documentacion: https://github.com/DapperLib/Dapper y ej: https://arbems.com/dapper-ef-core-net-6/
<br />
<br />Se implemento FluentValidation para la validacion de los modelos de datos. ej: https://www.youtube.com/watch?v=RYJGfB6auuE&t=361s

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
Tambien si uno quiere puede centralizar todos los health check en una sola pagina. para que una sola api se encargue de eso.
ej: https://www.youtube.com/watch?v=kjK6aN4c86w

![health-check-status-ui](https://user-images.githubusercontent.com/31715033/204013078-710d1246-5b14-432e-b23c-a47f05c398d4.png)

# Metrics con Grafana
Tambien uno puede implementar metricas para ver el rendimiento de una api, cuanto consume una api y cuantas veces llaman un servicio para hacerle mejoras al servicio o api.
ej: https://www.youtube.com/watch?v=sM7D8biBf4k

![grafana](https://user-images.githubusercontent.com/31715033/204015593-1c96593e-1e05-445f-84a0-ec27477f6bca.png)
