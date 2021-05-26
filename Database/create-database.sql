USE [master]
GO
/****** Object:  Database [LisBank]    Script Date: 5/23/2021 10:56:04 PM ******/
CREATE DATABASE [LisBank]
GO

USE [LisBank]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CLABE] [varchar](150) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[Number] [varchar](150) NOT NULL,
	[AvailableBalance] [float] NOT NULL,
	[IdClient] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authentication]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authentication](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[Device] [varchar](50) NULL,
	[Username] [varchar](50) NOT NULL,
	[LastLogin] [date] NULL,
 CONSTRAINT [PK_Authentication] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BranchOffice]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchOffice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](150) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[NoBranchOffice] [int] NOT NULL,
 CONSTRAINT [PK_BranchOffice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CVV] [varchar](50) NOT NULL,
	[DueDate] [varchar](50) NOT NULL,
	[NIP] [int] NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[IdAccount] [int] NOT NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[ProofIncome] [varchar](50) NULL,
	[Address] [varchar](150) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
	[INE] [varchar](50) NOT NULL,
	[NoClient] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[IdAuthentication] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditAccount]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Annuity] [float] NOT NULL,
	[MaxCredit] [float] NOT NULL,
	[ClosingDate] [date] NOT NULL,
	[PaymentdueDate] [date] NOT NULL,
	[MonthlyPayment] [float] NULL,
	[MinimumPayment] [float] NULL,
	[IdAccount] [int] NOT NULL,
 CONSTRAINT [PK_CreditAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DebitAccount]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DebitAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAccount] [int] NOT NULL,
 CONSTRAINT [PK_DebitAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IP] [varchar](50) NULL,
	[Name] [varchar](50) NOT NULL,
	[OperatingSystem] [varchar](50) NULL,
	[Version] [varchar](50) NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
	[ProfileImage] [varchar](50) NULL,
	[NoPersonal] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[IdBranchOffice] [int] NULL,
	[IdRole] [int] NOT NULL,
	[IdAuthentication] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Origin]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Origin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Origin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OriginBranchOffice]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OriginBranchOffice](
	[IdOriginBranchOffice] [int] NOT NULL,
	[IdOrigin] [int] NOT NULL,
	[IdBranchOffice] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TotalDebt] [float] NOT NULL,
	[PaymentDate] [date] NOT NULL,
	[MonthlyTotal] [float] NOT NULL,
	[Minimum] [float] NOT NULL,
	[PaymentMade] [float] NOT NULL,
	[Cycle] [date] NOT NULL,
	[Recharge] [float] NOT NULL,
	[IdCreditAccount] [int] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Table] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] NOT NULL,
	[Schedule] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Responsibility] [varchar](150) NULL,
	[Salary] [float] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 5/23/2021 10:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Concept] [varchar](150) NOT NULL,
	[Date] [date] NOT NULL,
	[Amount] [float] NOT NULL,
	[NoTransaction] [varchar](50) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[IdAccount] [int] NULL,
	[IdOrigin] [int] NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Client]
GO
ALTER TABLE [dbo].[BranchOffice]  WITH CHECK ADD  CONSTRAINT [FK_BranchOffice_Origin] FOREIGN KEY([Id])
REFERENCES [dbo].[Origin] ([Id])
GO
ALTER TABLE [dbo].[BranchOffice] CHECK CONSTRAINT [FK_BranchOffice_Origin]
GO
ALTER TABLE [dbo].[Card]  WITH CHECK ADD  CONSTRAINT [FK_Card_Account] FOREIGN KEY([IdAccount])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Card] CHECK CONSTRAINT [FK_Card_Account]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Authentication] FOREIGN KEY([IdAuthentication])
REFERENCES [dbo].[Authentication] ([Id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Authentication]
GO
ALTER TABLE [dbo].[CreditAccount]  WITH CHECK ADD  CONSTRAINT [FK_CreditAccount_Account] FOREIGN KEY([IdAccount])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[CreditAccount] CHECK CONSTRAINT [FK_CreditAccount_Account]
GO
ALTER TABLE [dbo].[DebitAccount]  WITH CHECK ADD  CONSTRAINT [FK_DebitAccount_Account] FOREIGN KEY([IdAccount])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[DebitAccount] CHECK CONSTRAINT [FK_DebitAccount_Account]
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Origin] FOREIGN KEY([Id])
REFERENCES [dbo].[Origin] ([Id])
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Origin]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Authentication] FOREIGN KEY([IdAuthentication])
REFERENCES [dbo].[Authentication] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Authentication]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_BranchOffice] FOREIGN KEY([IdBranchOffice])
REFERENCES [dbo].[BranchOffice] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_BranchOffice]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[OriginBranchOffice]  WITH CHECK ADD  CONSTRAINT [FK_OriginBranchOffice_BranchOffice] FOREIGN KEY([IdOriginBranchOffice])
REFERENCES [dbo].[BranchOffice] ([Id])
GO
ALTER TABLE [dbo].[OriginBranchOffice] CHECK CONSTRAINT [FK_OriginBranchOffice_BranchOffice]
GO
ALTER TABLE [dbo].[OriginBranchOffice]  WITH CHECK ADD  CONSTRAINT [FK_OriginBranchOffice_Origin] FOREIGN KEY([IdOrigin])
REFERENCES [dbo].[Origin] ([Id])
GO
ALTER TABLE [dbo].[OriginBranchOffice] CHECK CONSTRAINT [FK_OriginBranchOffice_Origin]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_CreditAccount] FOREIGN KEY([IdCreditAccount])
REFERENCES [dbo].[CreditAccount] ([Id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_CreditAccount]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Role]
GO
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_Employee] FOREIGN KEY([Id])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_Role_Employee]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Account] FOREIGN KEY([IdAccount])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Account]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Origin] FOREIGN KEY([IdOrigin])
REFERENCES [dbo].[Origin] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Origin]
GO
USE [master]
GO
ALTER DATABASE [LisBank] SET  READ_WRITE 
GO
