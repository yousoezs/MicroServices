# Entity Specifications 
- **[Product](#product)**
- **[Order](#order)**
- **[OrderDetail](#orderdetail)**
- **[User](#user)**
---

### Product
- Guid **Id**
- string **Name**
- string **Description**
- decimal **Price**
- int **stockQuantity**
- DateTime **CreatedDate**
- DateTime **UpdatedDate**
---
### Order
- Guid **Id**
- List<OrderDetail> **OrderDetails**
- _UserId_
- DateTime **CreatedDate**
- DateTime **UpdatedDate**
---
### OrderDetail
- Guid **Id**
- _ProductId_
- _OrderFK_
- int **AmountOfProducts**
- DateTime **CreatedDate**
- DateTime **UpdatedDate**
---
### User
- Guid **Id**
- Enum **Role**
- string **Email**
- string **Password**
- DateTime **CreatedDate**
- DateTime **UpdatedDate**
