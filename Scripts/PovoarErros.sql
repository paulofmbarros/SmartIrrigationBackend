Declare @json nvarchar(max)='[{
    "Id": 1,
    "Location": "Travessa de Marcos",
    "DateRaised": "2020-03-20",
    "DateSolved": "",
    "IsSolved": 0,
    "ErrorDescription": ""
  }, {
    "Id": 2,
    "Location": "Rua do Paralelo Torto",
    "DateRaised": "2020-03-19",
    "DateSolved": "2020-03-19",
    "IsSolved": 1,
    "ErrorDescription": "Temperature value too high"
  }, {
    "Id": 3,
    "Location": "Quinta da Laje",
    "DateRaised": "2020-03-18",
    "DateSolved": "2020-03-19",
    "IsSolved": 1,
    "ErrorDescription": "Humidity value too high"
  }, {
    "Id": 4,
    "Location": "Quinta de Cepeda",
    "DateRaised": "2020-03-17",
    "DateSolved": "",
    "IsSolved": 0,
    "ErrorDescription": ""
  }, {
    "Id": 5,
    "Location": "Jardim Da Carreira",
    "DateRaised": "2020-03-17",
    "DateSolved": "2020-03-19",
    "IsSolved": 1,
    "ErrorDescription": "Temperature value too low"
  }, {
    "Id": 6,
    "Location": "Parque da cIdade de Paredes",
    "DateRaised": "2020-03-15",
    "DateSolved": "",
    "IsSolved": 0,
    "ErrorDescription": ""
  }, {
    "Id": 7,
    "Location": "Parque Jose Guilherme",
    "DateRaised": "2020-03-14",
    "DateSolved": "",
    "IsSolved": 0,
    "ErrorDescription": ""
  }, {
    "Id": 8,
    "Location": "Parque das flores",
    "DateRaised": "2020-03-13",
    "DateSolved": "2020-03-16",
    "IsSolved": 1,
    "ErrorDescription": "Temperature value too high"
  }, {
    "Id": 9,
    "Location": "Parque do quadrado",
    "DateRaised": "2020-03-12",
    "DateSolved": "2020-03-19",
    "IsSolved": 1,
    "ErrorDescription": "Temperature value unknown"
  }, {
    "Id": 10,
    "Location": "Quintal da Avo Maria",
    "DateRaised": "2020-03-11",
    "DateSolved": "",
    "IsSolved": 0,
    "ErrorDescription": ""
  }, {
    "Id": 11,
    "Location": "Rua da Sanchela",
    "DateRaised": "2020-03-10",
    "DateSolved": "",
    "IsSolved": "",
    "ErrorDescription": ""
  }, {
    "Id": 12,
    "Location": "Rua Francisco Pinto",
    "DateRaised": "2020-03-9",
    "DateSolved": "2020-03-10",
    "IsSolved": 1,
    "ErrorDescription": "Humidity value unknown"
	}]'




Insert into Errors (Location,DateRaised,DateSolved,Solved,ErrorDescription)
SELECT Location,DateRaised,DateSolved,IsSolved,ErrorDescription
FROM OPENJSON(@json)
     WITH (Id int, Location nvarchar(max), DateRaised date '$.DateRaised',
            DateSolved date '$.DateSolved', IsSolved bit, ErrorDescription nvarchar(max))
