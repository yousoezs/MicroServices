# API Specification 

Table of Contents
=================

## User

| Method  | Endpoint /api/customer | Request     | Response                     | Description |
| ------  | ---------------------- | ----------- | ---------------------------- | ----------- |
| `POST`  | /add 		   | UserDto     | HttpStatusCode-UserDto       | Add user to user DB
| `GET`   | /getAll 		   | 	         | HttpStatusCode-ListOfUserDto | Get all users from user DB
| `GET`   | /getById/{guid} 	   | Header-guid | HttpStatusCode-UserDto       | Get user by id from user DB
| `GET`   | /login 	           | UserDto     | HttpStatusCode-UserDto       | Returns 200 if UserDto.Email && password matches same values in user DB
| `PUT`   | /update 	           | UserDto     | HttpStatusCode-UserDto       | Updates user in user DB
| `DELETE`| /delete/{guid}         | Header-guid | HttpStatusCode-UserDto       | Deletes user in user DB

## Order

| Method  | Endpoint /api/customer | Request     | Response                     | Description |
| ------  | ---------------------- | ----------- | ---------------------------- | ----------- |
| `POST`  | /add 		   | OrderDto     | HttpStatusCode-OrderDto       | Add Order to OrderDb
| `GET`   | /getAll 		   | 	         | HttpStatusCode-ListOfOrderDto | Get all order from OrderDb
| `PUT`   | /update 	           | OrderDto     | HttpStatusCode-OrderDto       | Updates order in OrderDb
| `DELETE`| /delete/{guid}         | Header-guid | HttpStatusCode-OrderDto       | Deletes order in OrderDb

## Pencil

| Method  | Endpoint /api/pencil | Request     | Response                     | Description |
| ------  | ---------------------- | ----------- | ---------------------------- | ----------- |
| `POST`  | /add 		   | PencilDto    | PencilDto       | Add Pencil to Db
| `GET`   | /get	           | 	          | List<PencilDto> | Get all Pencils from Db
| `GET`   | /get/{id}	           | Route - Id : string	          | PencilDto | Get Pencil by id from Db
| `PUT`   | /update 	           | PencilDto     | PencilDto      | Updates Pencil in Db
| `DELETE`| /delete/{id}           | Route - Id: string| PencilDto       | Deletes Pencil in Db
