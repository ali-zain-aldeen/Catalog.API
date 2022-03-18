# Catalog.API By Ali Zain Aldeen

as we implement the clean archetecture here, you can find the services for emails and menus in the Domain folder, the api for them in Api folder, and the repositories ( if needed ) with all the database structre in the Repositories folder

# 1- API folder:

  <p>1. Catalog.Api , which contain CRUD operation for menus </p>
  <p>2. Catalog.Email , which contain the test api for the email service</p>
  <p1>3. Catalog.ApiGateway , which contain the api gateway for the solutoin</p>
  
# 2- Domain folder:

  <p1>1. Catalog.Common , which contain common application services and class</p>
  <p1>2. Catalog.Emails , which contain the services and neccassacy classes for email application</p>
  <p1>3. Catalog.Menus , which contain the services and neccassacy classes for menus application</p>
  <p1>4. Catalog.Menus.Test , which contain the Unit tests for the menue service</p>
  
# 3- Repositories folder:

  <p1>1. Catalog.Repositories.Menus, which contain the persistencies classes for the menue service</p>
  
  
# Some nugget packages used
  
  <p>1- Ocelot for api gateway </p>
  <p>2- Mass transit for rabbit mq cumminication</p> 
  <p>3- MIME kit and MAIL kit for email seding </p>
  <p>4- Entity framework as on ORM for the database</p>
  <p>5- Fluent validation for validations </p>
  <p>6- xUnit and Fluent assertion and Nsubtitue and Auto fixture for unit testing </p>
  
  
