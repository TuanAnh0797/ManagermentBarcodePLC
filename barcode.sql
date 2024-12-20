USE [managermentbarcode]
GO
/****** Object:  StoredProcedure [dbo].[addmaster]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addmaster]@McAddress varchar(80), @Namemachine varchar(80),@index int, @Namepart varchar(50),@DeviceType varchar(6),@StartDevice int,@DataType varchar(6),
@LenghtDevice int, @TotalCode int
as
begin
INSERT INTO [dbo].[tablemaster]
           ([McAddress]
		   ,[Namemachine]
           ,[indexpart]
           ,[Namepart]
           ,[DeviceType]
           ,[StartDevice]
           ,[DataType]
           ,[LenghtDevice]
           ,[TotalCode]
		   ,[TimeUpdate]
           )
     VALUES
           (@McAddress
		   ,@Namemachine
		   ,@index
           ,@Namepart
           ,@DeviceType
           ,@StartDevice
           ,@DataType
           ,@LenghtDevice
           ,@TotalCode
		   ,GETDATE()
           )
end

GO
/****** Object:  StoredProcedure [dbo].[addmcaddress]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[addmcaddress] @namemachine varchar(80),@ipaddress varchar(30), @portnumber int
as
begin 
	INSERT INTO [dbo].[McAddress]
           ([NameMachine]
           ,[Ipaddress]
           ,[PortNumber]
           ,[TimeUpdate])
     VALUES
           (@namemachine
           ,@ipaddress
           ,@portnumber
           ,getdate())
end



GO
/****** Object:  StoredProcedure [dbo].[deletemaster]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[deletemaster] @Namemachine varchar(80)
as
begin
 exec('Drop table '+@Namemachine)
 delete tablemaster where Namemachine = @Namemachine
end

GO
/****** Object:  StoredProcedure [dbo].[deletemcaddress]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[deletemcaddress] @namemachine varchar(80)
as
begin 
	Delete [dbo].[McAddress]
        
     where NameMachine = @namemachine
          
end



GO
/****** Object:  StoredProcedure [dbo].[deletepart]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[deletepart] @Namemachine varchar(80),@Partname varchar(80)
as
begin
BEGIN TRAN
BEGIN TRY
    delete tablemaster where Namemachine = @Namemachine and Namepart = @Partname
	exec('ALTER TABLE '+@Namemachine +' DROP COLUMN '+@Partname)
COMMIT
select 1;
END TRY
BEGIN CATCH
   ROLLBACK
   select 0;
END CATCH
end

GO
/****** Object:  StoredProcedure [dbo].[getdatamaster]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getdatamaster]
as
begin
SELECT [McAddress]
		,[Namemachine]
      ,[indexpart]
      ,[Namepart]
      ,[DeviceType]
      ,[StartDevice]
      ,[DataType]
      ,[LenghtDevice]
      ,[TotalCode]
      ,[TimeUpdate]
  FROM [managermentbarcode].[dbo].[tablemaster](nolock) order by [TimeUpdate] desc
end

GO
/****** Object:  StoredProcedure [dbo].[getdatamasterbymachine]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getdatamasterbymachine] @Namemachine varchar(80)
as
begin
	SELECT  [McAddress]
      ,[Namemachine]
      ,[indexpart]
      ,[Namepart]
      ,[DeviceType]
      ,[StartDevice]
      ,[DataType]
      ,[LenghtDevice]
      ,[TotalCode]
      ,[TimeUpdate]
  FROM [managermentbarcode].[dbo].[tablemaster] where Namemachine = @Namemachine order by indexpart desc
end

GO
/****** Object:  StoredProcedure [dbo].[getdatamastercombobox]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[getdatamastercombobox]
as
begin
SELECT 
		[Namemachine]
      
  FROM [managermentbarcode].[dbo].[tablemaster](nolock) group by  [Namemachine]
end

GO
/****** Object:  StoredProcedure [dbo].[getlisttable]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[getlisttable]
as
begin
SELECT [McAddress]
		,[Namemachine]
      ,[indexpart]
      ,[Namepart]
      ,[DeviceType]
      ,[StartDevice]
      ,[DataType]
      ,[LenghtDevice]
      ,[TotalCode]
      ,[TimeUpdate]
  FROM [managermentbarcode].[dbo].[tablemaster](nolock) where indexpart = 1  order by [TimeUpdate] desc
end

GO
/****** Object:  StoredProcedure [dbo].[getmcaddress]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[getmcaddress]
as
begin 
	SELECT TOP (1000) [NameMachine]
      ,[Ipaddress]
      ,[PortNumber]
	  ,[TimeUpdate]
  FROM [managermentbarcode].[dbo].[McAddress]
end

GO
/****** Object:  StoredProcedure [dbo].[updatemcaddress]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[updatemcaddress] @namemachine varchar(80),@ipaddress varchar(30), @portnumber int
as
begin 
	Update [dbo].[McAddress]
         set 
		 Ipaddress = @ipaddress,
		 PortNumber = @portnumber,
		 TimeUpdate = getdate()
     where NameMachine = @namemachine
          
end



GO
/****** Object:  StoredProcedure [dbo].[updatepart]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[updatepart] @namemachine varchar(80),@Namepart varchar(80), @DeviceType varchar(6),@StartDevice int, @LenghtDevice int
as
begin 
	Update [dbo].[tablemaster]
         set DeviceType = @DeviceType,
		 StartDevice = @StartDevice,
		
		LenghtDevice = @LenghtDevice
     where NameMachine = @namemachine and Namepart = @Namepart
          
end



GO
/****** Object:  Table [dbo].[CheckCabi]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CheckCabi](
	[Cabi] [varchar](100) NULL,
	[PCB] [varchar](100) NULL,
	[Res] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[McAddress]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[McAddress](
	[NameMachine] [varchar](50) NULL,
	[Ipaddress] [varchar](30) NOT NULL,
	[PortNumber] [int] NOT NULL,
	[TimeUpdate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ipaddress] ASC,
	[PortNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NameMachine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tablemaster]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tablemaster](
	[McAddress] [varchar](80) NOT NULL,
	[Namemachine] [varchar](80) NOT NULL,
	[indexpart] [int] NOT NULL,
	[Namepart] [varchar](50) NOT NULL,
	[DeviceType] [varchar](6) NOT NULL,
	[StartDevice] [int] NOT NULL,
	[DataType] [varchar](6) NOT NULL,
	[LenghtDevice] [int] NOT NULL,
	[TotalCode] [int] NOT NULL,
	[TimeUpdate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Test]    Script Date: 2023/11/13 11:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Test](
	[Mater] [varchar](100) NULL,
	[Part1] [varchar](100) NULL,
	[part2DEC] [bigint] NULL,
	[Part3Float] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
