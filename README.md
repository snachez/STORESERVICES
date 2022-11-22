# STORESERVICES
Servicio de compra de libros.
<br />Cada servicio contiene su capa (MODEL, DAO, SERVICES, API)
<br />El api gateway es con ocelot

# STORESERVICES.API.AUTHOR
Servicio que puede crear, obtener por AutorLibroGuid y obtener todos los autores 
ej: AutorLibroGuid = E5F9CBC6-B91C-4CF5-B049-7D50B76A17C8

# STORESERVICES.API.BOOK
Servicio que puede crear, obtener por LibreriaMaterialId y obtener todos los libros
ej: LibreriaMaterialId = E7FF889E-8525-4417-9756-08DAA1989575

# STORESERVICES.API.SHOPPINGCART
Servicio que puede crear y obtener por CartSessionId el carrito de compra
ej: CartSessionId = 1

# STORESERVICES.API.GATEWAY
Servicio que sirve de puente de comunicacion entre los servicios y el frontend
