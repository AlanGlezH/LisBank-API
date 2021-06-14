GO
USE LisBank
GO

INSERT INTO Authentication
  (Username, Password)
VALUES
  ('alan@gmail.com', '10000.NzrBHw1FwUDAcgEYtKHYlA==./CwyBYvmknzuw/Qc0XHKYM6c5farFkPwbqiKvPvRdog=')

INSERT INTO Authentication
  (Username, Password)
VALUES
  ('victor@gmail.com','10000.NzrBHw1FwUDAcgEYtKHYlA==./CwyBYvmknzuw/Qc0XHKYM6c5farFkPwbqiKvPvRdog=')

INSERT INTO Authentication
 (Username, Password)
VALUES
  ('gume@gmail.com','10000.NzrBHw1FwUDAcgEYtKHYlA==./CwyBYvmknzuw/Qc0XHKYM6c5farFkPwbqiKvPvRdog=')

INSERT INTO Authentication
  (Username, Password)
VALUES
  ('jose@gmail.com','10000.NzrBHw1FwUDAcgEYtKHYlA==./CwyBYvmknzuw/Qc0XHKYM6c5farFkPwbqiKvPvRdog=')
GO


INSERT INTO Client
  (Name, LastName, Address, Email, Birthday, Ine, NoClient, PhoneNumber, IdAuthentication)
VALUES
  ('Alan', 'Gonzalez Heredia', 'Del museo 333', 'alan@gmail.com', '1998-04-14', 'path', '12345', '123435434', 1)
GO
INSERT INTO Client
  (Name, LastName, Address, Email, Birthday, Ine, NoClient, PhoneNumber, IdAuthentication)
VALUES
  ('Victor Manuel', 'Niño Martínez', 'Av Xalapa', 'victor@gmail.com', '1998-04-14', 'path', '12345', '123435434', 2)
GO
INSERT INTO Client
  (Name, LastName, Address, Email, Birthday, Ine, NoClient, PhoneNumber, IdAuthentication)
VALUES
  ('Irving Ivan', 'Gumensio Trujillo', 'Av Xalapa', 'gume@gmail.com', '1998-07-14', 'path', '12345', '123435434', 3)
GO
INSERT INTO Client
  (Name, LastName, Address, Email, Birthday, Ine, NoClient, PhoneNumber, IdAuthentication)
VALUES
  ('Jose Miguel', 'Quiroz Benítez', 'Av Xalapa', 'chino@gmail.com', '1998-04-14', 'path', '12345', '123435434', 4)
GO
INSERT INTO Account
  ( Clabe, CreatedDate, Number, AvailableBalance, IdClient)
VALUES
  ('123456789', '2021-08-02', '64743847394', 34932, 1)  
GO
INSERT INTO DebitAccount
  (IdAccount)
VALUES
  (1)  
GO
INSERT INTO Account
  ( Clabe, CreatedDate, Number, AvailableBalance, IdClient)
VALUES
  ('123456789', '2021-08-02', '64743847394', 34932, 1)  
GO

INSERT INTO CreditAccount
  (Annuity, MaxCredit, ClosingDate, PaymentdueDate, MonthlyPayment, MinimumPayment,IdAccount) 
VALUES
  (800,5000,'2021-01-01','2021-01-20', 5000, 454, 2)  
GO

INSERT INTO Origin 
  (Name)
VALUES
  ('Sucursal 500')

INSERT INTO [Transaction] 
  (Concept, Date, Amount, Notransaction, Type, IdAccount, IdOrigin)
VALUES
('Transferencia bancaria','2021-01-20', 2300, '2344235', 'WITHDRAW', 1, 1)

INSERT INTO [Transaction] 
  (Concept, Date, Amount, Notransaction, Type, IdAccount, IdOrigin)
VALUES
('Transferencia bancaria','2021-01-20', 1800, '2344235', 'DEPOSIT', 1, 1)
GO

INSERT INTO [Payment] 
  (TotalDebt, PaymentDate, Monthlytotal, Minimum, PaymentMade, Cycle, Recharge, IdCreditAccount)
VALUES
  (2456, '2021-01-13', 460, 1234, 400, '2021-01-01', 0, 1)

INSERT INTO [Payment] 
  (TotalDebt, PaymentDate, Monthlytotal, Minimum, PaymentMade, Cycle, Recharge, IdCreditAccount)
VALUES
  (2456, '2021-02-10', 1460, 1234 , 400, '2021-02-01', 0, 1)
GO

INSERT INTO [Card] 
  (Cvv, DueDate, Nip, Number, IdAccount)
VALUES
  ('007', '04/27', 0809, 3445362738497346, 1)
GO

INSERT INTO [Card] 
  (Cvv, DueDate, Nip, Number, IdAccount)
VALUES
  ('007', '04/27', 0809, 3445362738497346, 1)
GO

INSERT INTO [Card] 
  (Cvv, DueDate, Nip, Number, IdAccount)
VALUES
  ('003', '04/24', 0809, 3445362738497346, 2)
GO



