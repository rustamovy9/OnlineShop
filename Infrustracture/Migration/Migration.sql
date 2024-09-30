Create database Online_Shop

Create table Customers
(
    id uuid primary key DEFAULT  gen_random_uuid(),
    FullName varchar unique not null,
    Email varchar unique not null,
    Phone varchar (9) unique not null,
    CreatedAt timestamp DEFAULT  NOW()
);

Create table Products
(
    id uuid primary key DEFAULT  gen_random_uuid(),
    Name varchar unique not null,
    Price decimal(10,2) not null,
    StockQuantity int,
    CreatedAt timestamp DEFAULT NOW()
);

Create table Orders
(
    id uuid primary key DEFAULT gen_random_uuid(),
    CustomerId uuid,
    TotalAmount decimal(10,2),
    OrderDate timestamp Default NOW(),
    Status varchar not null Default 'Pending',
    CreatedAt timestamp default Now(),
    Foreign key(CustomerId) references Customers(id)
);




Create table OrderItems
(
    id uuid primary key Default gen_random_uuid(),
    OrderId uuid,
    ProductId uuid,
    Quantity int,
    Price decimal(10,2),
    Created timestamp default Now()
);


