Create table District (
Id_District int primary key not null,
DistrictName nvarchar(255)
)


Create table Location (
Id_Location int primary key not null,
Latitude nvarchar(255),
Longitude nvarchar(255),
Altitude nvarchar(255),
Description nvarchar(255),
District int foreign key references District(Id_District),
Countie smallInt foreign key references Counties(CountyId)
)

Create table Station(
Id_Station int primary key not null,
Name nvarchar(255),
Country nvarchar(255),
Regional varchar(50),
Nat nvarchar(255),
Wmo int,
Icao varchar(255),
Iata varchar(255),
Elevation int,
Timezone varchar(255),
Active bit,
Id_Location int foreign key references Location(Id_Location)

)

Create table Node(
Id_Node int Primary Key not null identity(1,1),
Description nvarchar(250),
Id_Location int foreign key references Location(Id_Location),
Id_NearStation int foreign key references Station(Id_Station)
)

Create table Hist_Evaporation(
Id_HistEvaporation int primary key not null, 
Reading_date datetime,
Minimum float,
Maxi float,
Range float,
Mean float,
Std float,
Id_County smallint foreign key references Counties(CountyId)
)

Create table Hist_Reading(
Id_HistReading int primary key not null,
DateReading datetime default getdate(),
Temperature float,
Dwpt float,
Rhum int,
Prcp float,
Snow int,
Wdir int,
Wspd float,
Wpgt float,
Pres float,
Tsun integer,
Coco integer
)
