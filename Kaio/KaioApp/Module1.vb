Imports MongoDB.Bson
Imports MongoDB.Driver
Imports System
Imports System.Threading.Tasks
Module Module1


    Sub Main()
        Try


            'src: https://www.codementor.io/pmbanugo/working-with-mongodb-in-net-1-basics-g4frivcvz
            '1.Accessing a database
            'Dim client = New MongoClient()
            Dim connectionString As String = "mongodb://localhost:27017"
            Dim client As MongoClient = New MongoClient(connectionString)
            'Other:
            'Dim client As MongoClient = New MongoClient(New MongoUrl("mongodb://localhost:27017"))
            'Or:
            'Dim client As MongoClient = New MongoClient(MongoUrl.Create("mongodb://localhost:27017"))
            Dim db As IMongoDatabase = client.GetDatabase("school")
            '2.Create a collection
            db.CreateCollectionAsync("students")
            Dim document As BsonDocument = New BsonDocument()
            document.Add("name", "Steven Johnson")
            document.Add("age", 23)

            Dim collection As IMongoCollection(Of BsonDocument)
            collection = db.GetCollection(Of BsonDocument)("students")
            collection.InsertOneAsync(document)




        Catch ex As Exception

        End Try
    End Sub


End Module
