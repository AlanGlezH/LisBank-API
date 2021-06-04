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

