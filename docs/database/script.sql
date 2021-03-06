USE [master]
GO
/****** Object:  Database [db_a7d809_phungthanhtu]    Script Date: 1/7/2022 8:53:22 AM ******/
CREATE DATABASE [db_a7d809_phungthanhtu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_a7d809_phungthanhtu_Data', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_a7d809_phungthanhtu_DATA.mdf' , SIZE = 8192KB , MAXSIZE = 1024000KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'db_a7d809_phungthanhtu_Log', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_a7d809_phungthanhtu_Log.LDF' , SIZE = 3072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_a7d809_phungthanhtu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET  MULTI_USER 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET QUERY_STORE = OFF
GO
USE [db_a7d809_phungthanhtu]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 1/7/2022 8:53:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Check_log]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Check_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[check_date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Check_log_detail]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Check_log_detail](
	[check_log_id] [int] NOT NULL,
	[device] [int] NOT NULL,
	[division] [int] NULL,
	[status] [nvarchar](50) NULL,
	[current_value] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[check_log_id] ASC,
	[device] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[supplier] [int] NULL,
	[price] [money] NULL,
	[import_date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detailed_Inventory_Personnel]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detailed_Inventory_Personnel](
	[inventory] [int] NOT NULL,
	[personnel] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[inventory] ASC,
	[personnel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detailed_liquidation_personnel]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detailed_liquidation_personnel](
	[liquidation] [int] NOT NULL,
	[personnel] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[liquidation] ASC,
	[personnel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detailed_Transfers]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detailed_Transfers](
	[transfers] [int] NOT NULL,
	[device] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[transfers] ASC,
	[device] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[device_type]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[device_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[t_name] [nvarchar](20) NULL,
	[note] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[device_unit]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[device_unit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[u_name] [nvarchar](20) NULL,
	[note] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Devices]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devices](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[price] [money] NULL,
	[specification] [nvarchar](50) NULL,
	[production_year] [int] NULL,
	[implement_year] [int] NULL,
	[status] [nvarchar](50) NULL,
	[annual_value_lost] [float] NULL,
	[contract_id] [int] NOT NULL,
	[holding_division] [int] NULL,
	[unit] [int] NULL,
	[type] [int] NULL,
	[current_value] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Division]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Division](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[type] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[check_log] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Liquidation]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Liquidation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[check_log] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personnel]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personnel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[position] [nvarchar](50) NULL,
	[division] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repair_bill]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repair_bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[repairer] [int] NULL,
	[repair_date] [date] NULL,
	[sum_money] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repair_bill_detail]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repair_bill_detail](
	[bill] [int] NOT NULL,
	[device] [int] NOT NULL,
	[price] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[bill] ASC,
	[device] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repairer]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repairer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[phone] [varchar](20) NULL,
	[address] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](100) NULL,
	[phone] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transfers]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transfers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sender] [int] NULL,
	[receiver] [int] NULL,
	[transfer_date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Check_log_detail]  WITH CHECK ADD FOREIGN KEY([check_log_id])
REFERENCES [dbo].[Check_log] ([id])
GO
ALTER TABLE [dbo].[Check_log_detail]  WITH CHECK ADD FOREIGN KEY([device])
REFERENCES [dbo].[Devices] ([id])
GO
ALTER TABLE [dbo].[Check_log_detail]  WITH CHECK ADD FOREIGN KEY([division])
REFERENCES [dbo].[Division] ([id])
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD FOREIGN KEY([supplier])
REFERENCES [dbo].[Supplier] ([id])
GO
ALTER TABLE [dbo].[Detailed_Inventory_Personnel]  WITH CHECK ADD FOREIGN KEY([inventory])
REFERENCES [dbo].[Inventory] ([id])
GO
ALTER TABLE [dbo].[Detailed_Inventory_Personnel]  WITH CHECK ADD FOREIGN KEY([personnel])
REFERENCES [dbo].[Personnel] ([id])
GO
ALTER TABLE [dbo].[Detailed_liquidation_personnel]  WITH CHECK ADD FOREIGN KEY([liquidation])
REFERENCES [dbo].[Liquidation] ([id])
GO
ALTER TABLE [dbo].[Detailed_liquidation_personnel]  WITH CHECK ADD FOREIGN KEY([personnel])
REFERENCES [dbo].[Personnel] ([id])
GO
ALTER TABLE [dbo].[Detailed_Transfers]  WITH CHECK ADD FOREIGN KEY([transfers])
REFERENCES [dbo].[Transfers] ([id])
GO
ALTER TABLE [dbo].[Detailed_Transfers]  WITH CHECK ADD FOREIGN KEY([device])
REFERENCES [dbo].[Devices] ([id])
GO
ALTER TABLE [dbo].[Devices]  WITH CHECK ADD FOREIGN KEY([contract_id])
REFERENCES [dbo].[Contracts] ([id])
GO
ALTER TABLE [dbo].[Devices]  WITH CHECK ADD FOREIGN KEY([holding_division])
REFERENCES [dbo].[Division] ([id])
GO
ALTER TABLE [dbo].[Devices]  WITH CHECK ADD FOREIGN KEY([type])
REFERENCES [dbo].[device_type] ([id])
GO
ALTER TABLE [dbo].[Devices]  WITH CHECK ADD FOREIGN KEY([unit])
REFERENCES [dbo].[device_unit] ([id])
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD FOREIGN KEY([check_log])
REFERENCES [dbo].[Check_log] ([id])
GO
ALTER TABLE [dbo].[Liquidation]  WITH CHECK ADD FOREIGN KEY([check_log])
REFERENCES [dbo].[Check_log] ([id])
GO
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD FOREIGN KEY([division])
REFERENCES [dbo].[Division] ([id])
GO
ALTER TABLE [dbo].[Repair_bill]  WITH CHECK ADD FOREIGN KEY([repairer])
REFERENCES [dbo].[Repairer] ([id])
GO
ALTER TABLE [dbo].[Repair_bill_detail]  WITH CHECK ADD FOREIGN KEY([device])
REFERENCES [dbo].[Devices] ([id])
GO
ALTER TABLE [dbo].[Repair_bill_detail]  WITH CHECK ADD FOREIGN KEY([bill])
REFERENCES [dbo].[Repair_bill] ([id])
GO
ALTER TABLE [dbo].[Transfers]  WITH CHECK ADD FOREIGN KEY([receiver])
REFERENCES [dbo].[Division] ([id])
GO
ALTER TABLE [dbo].[Transfers]  WITH CHECK ADD FOREIGN KEY([sender])
REFERENCES [dbo].[Division] ([id])
GO
ALTER TABLE [dbo].[Division]  WITH CHECK ADD  CONSTRAINT [chk_type] CHECK  (([type]='Managing' OR [type]='Using'))
GO
ALTER TABLE [dbo].[Division] CHECK CONSTRAINT [chk_type]
GO
/****** Object:  StoredProcedure [dbo].[checkDeviceStatus]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[checkDeviceStatus] @check nvarchar(max)
as
--- insert check log table
insert into Check_log (check_date)
					select check_date 
					from openjson(@check,'$.check') with
					(
						check_date date '$.check_date'
					)
-- insert check log detail
DECLARE @new_log_id int
SELECT @new_log_id = IDENT_CURRENT('Check_log') 

insert into Check_log_detail (check_log_id,device,division,status,current_value)
			select @new_log_id as check_log_id,device,division,status,current_value from openjson(@check,'$.detail') with
(
	device int '$.id',
	division int '$.division',
	status nvarchar(50) '$.status',
	current_value money '$.current_value'
) 

-- update device information
UPDATE Devices
SET    status = device_data.status,
       current_value = device_data.current_value
FROM   Devices
JOIN   OPENJSON(@check, '$.detail')
       WITH (
	   id int '$.id',
	   status nvarchar(50) '$.status',
	   current_value money '$.current_value'
	   ) device_data
       ON Devices.id = device_data.id
GO
/****** Object:  StoredProcedure [dbo].[createNewTransfer]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[createNewTransfer] @json nvarchar(max)
as
insert into Transfers (sender,receiver,transfer_date)
					select sender,receiver,transfer_date 
					from openjson(@json,'$.transfer') with
					(
						sender int '$.sender',
						receiver int '$.receiver',
						transfer_date date '$.transfer_date'
					)

DECLARE @new_transfer_id int 
SELECT @new_transfer_id = IDENT_CURRENT('Transfers') 


insert into Detailed_Transfers (transfers,device) 
			select @new_transfer_id as transfers,id as device from openjson(@json,'$.devices') with
(
	id int '$.id'
)

update Devices 
SET Devices.holding_division = ( select receiver from openjson(@json,'$.transfer') with
								(
									sender int '$.sender',
									receiver int '$.receiver',
									transfer_date date '$.transfer_date'
								))
FROM Devices 
	JOIN openjson(@json,'$.devices') with
(
	id int '$.id'
)	newdevices
ON Devices.id = newdevices.id
GO
/****** Object:  StoredProcedure [dbo].[repair_device]    Script Date: 1/7/2022 8:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[repair_device] @repair nvarchar(max)
as
-- insert into bill
insert into Repair_bill (repairer,repair_date,sum_money)
select repairer,repair_date,0 as sum_money from openjson(@repair) with 
(
	repairer int '$.repairer',
	repair_date date '$.repair_date'
)

-- select inserted repair bill
declare @curr_bill_id int
select @curr_bill_id = IDENT_CURRENT('Repair_bill')

-- insert into repair bill detail
insert into Repair_bill_detail (bill,device,price)
			select @curr_bill_id as bill,device,price from openjson(@repair,'$.repair_bill') with
(
	device int '$.device',
	price money '$.price'
) 

-- update device status
-- update device information
UPDATE Devices
SET    status = 'Used'
FROM   Devices
JOIN   OPENJSON(@repair,'$.repair_bill')
       WITH (
	   id int '$.device'
	   ) device_data
       ON Devices.id = device_data.id
GO
USE [master]
GO
ALTER DATABASE [db_a7d809_phungthanhtu] SET  READ_WRITE 
GO
