 # Database Diagram
 
 ```mermaid
 classDiagram
     
     class Pencil{
        + Guid Id
        + string Name
        + string Description
        + decimal Price
        + int stockQuantity
     }

     class Order{
        + Guid Id
        + List~OrderDetail~ OrderDetails
        + Guid CustomerId
        + OrderStatus OrderStatus
     }
Order <|-- OrderDetail
User <|-- Order
Pencil <|-- OrderDetail

     class OrderDetail{
        + Guid Id
        + Guid OrderId
        + Guid ProductId
        + int AmountOfProducts
     }

     class User{
        + Guid Id
        + Enum Role
        + string Email
        + string Password
     }

```
