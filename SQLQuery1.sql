create  table Admin(
AdminUserId int primary key NOT NULL,
AdminUserName varchar(50) NOT NULL,
AdminPassword varchar(50) NOT NULL
);

insert into Admin(AdminUserId, AdminUserName, AdminPassword) values(1,'Root','Admin123');