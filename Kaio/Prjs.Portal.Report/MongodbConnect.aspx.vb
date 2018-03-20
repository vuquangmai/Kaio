Imports MongoDB.Bson
Imports MongoDB.Driver
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class MongodbConnect
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            InsertData()
            FullCode()
        End If
    End Sub
    Public Function DbConnection(ByRef ConnString As String, vDbName As String, vColName As String) As MongoClient

        'default port
        'ConnString = "mongodb://localhost:27017"

        'example DB and Collection
        'vDbName = "blog"
        'vColName = "users"

        'Root Object
        Dim vClient As MongoClient
        vClient = New MongoClient(ConnString)

        Dim vDb As MongoDatabaseBase
        vDb = vClient.GetDatabase(vDbName)

        Dim vCol As IMongoCollection(Of BsonDocument)
        vCol = vDb.GetCollection(Of BsonDocument)(vColName)

        Return vClient

    End Function
    Private Sub InsertData()
        Dim ConnString As String = "mongodb://localhost:27017"
        Dim vDbName As String = "LearningNoSQL"

        Dim vColName As String = "User_List"
        'Root Object
        Dim vClient As MongoClient

        vClient = DbConnection(ConnString, vDbName, vColName)

        Dim vDb As MongoDatabaseBase
        vDb = vClient.GetDatabase(vDbName)

        Dim vCol As IMongoCollection(Of BsonDocument)
        vCol = vDb.GetCollection(Of BsonDocument)(vColName)

        Dim vAddUser As BsonDocument
        vAddUser = New BsonDocument

        vAddUser.Add("_Id", "1")
        vAddUser.Add("Name ", "Vu Quang Mai")
        vAddUser.Add("Email", "quangmai.vu@vmgmedia.vn")
        vAddUser.Add("City", "Ha Noi")

        'rtfDataDisplay.Text = "BsonDocument = " & vAddUser.ToString & ", #" & vAddUser.Count

        Dim insertTask = vCol.InsertOneAsync(vAddUser)
        insertTask.Wait()

    End Sub
    Private Sub QueryData()
        'Dim ConnString As String = "mongodb://localhost:27017"
        'Dim vDbName As String = "LearningNoSQL"
        'Dim vColName As String = "books"
        ''Root Object
        'Dim vClient As MongoClient
        'vClient = DbConnection(ConnString, vDbName, vColName)

        'Dim vDb As MongoDatabaseBase
        'vDb = vClient.GetDatabase(vDbName)

        'Dim vCol As IMongoCollection(Of BsonDocument)
        'vCol = vDb.GetCollection(Of BsonDocument)(vColName)

        'Dim book As BsonDocument = New BsonDocument() _
        '                           .Add("_id", BsonValue.Create(BsonType.ObjectId)) _
        '                           .Add("author", "Ernest Hemingway") _
        '                           .Add("title", "For Whom the Bell Tolls")
        'vCol.InsertOneAsync(book)
        'Dim query = New QueryDocument("author", "Ernest Hemingway")

        'For Each item As BsonDocument In vCol.Find(query)
        '    Dim json As String = item.ToJson()

        '    Console.WriteLine(json)
        '    Console.WriteLine()

        '    Dim token As JToken = JToken.Parse(json)
        '    token.SelectToken("title").Replace("some other title")

        '    Console.WriteLine("Author: {0}, Title: {1}", token.SelectToken("author"), token.SelectToken("title"))
        '    Console.WriteLine()

        '    Dim node As XNode = JsonConvert.DeserializeXNode(json, "documents")

        '    Console.WriteLine("Node:")
        '    Console.WriteLine(node)
        '    Console.WriteLine()

        '    Dim author As BsonElement = item.GetElement("author")
        '    Dim title As BsonElement = item.GetElement("title")

        '    For Each element As BsonElement In item.Elements
        '        Console.WriteLine("Name: {0}, Value: {1}", element.Name, element.Value)
        '    Next

        '    Console.WriteLine()
        '    Console.WriteLine("Author: {0}, Title: {1}", author.Value, title.Value)

        'Next
    End Sub

#Region "Full Code"
    Private Sub FullCode()

        Dim connectionString As String = "mongodb://localhost:27017"
        Console.WriteLine("Creating Client..........")
        Dim client As MongoClient = Nothing
        Try
            client = New MongoClient(connectionString)
            Console.WriteLine("Client Created Successfuly........")
            Console.WriteLine("Client: " + client.ToString())
        Catch ex As Exception
            Console.WriteLine("Filed to Create Client.......")
            Console.WriteLine(ex.Message)
        End Try

        Console.WriteLine("Initianting Mongo Db Server.......")
        Dim Server As MongoServer = Nothing
        Try
            Console.WriteLine("Getting Servicer object......")
            Server = client.GetServer
            Console.WriteLine("Server object created Successfully....")
            Console.WriteLine("Server :" + Server.ToString())
        Catch ex As Exception
            Console.WriteLine("Filed to getting Server Details")
            Console.WriteLine(ex.Message)
        End Try

        Console.WriteLine("Initianting Mongo Databaser.........")
        Dim database As MongoDatabase = Nothing
        Try
            Console.WriteLine("Getting reference of database.......")
            database = Server.GetDatabase("LearningNoSQL")
            Console.WriteLine("Database Name : " + database.Name)
        Catch ex As Exception
            Console.WriteLine("Failed to Get reference of Database")
            Console.WriteLine("Error :" + ex.Message)
        End Try

        Try
            Console.WriteLine("Deleteing Collection books")
            database.DropCollection("books")
        Catch ex As Exception
            Console.WriteLine("Failed to delete collection from Database")
            Console.WriteLine("Error :" + ex.Message)
        End Try

        Console.WriteLine("Getting Collections from database Database.......")
        Dim symbolcollection As MongoCollection = Nothing
        Try
            symbolcollection = database.GetCollection(Of Symbol)("Symbols")
            Console.WriteLine(symbolcollection.Count().ToString())
        Catch ex As Exception
            Console.WriteLine("Failed to Get collection from Database")
            Console.WriteLine("Error :" + ex.Message)
        End Try

        Dim id As New ObjectId()
        Console.WriteLine("Inserting document to collection............")
        Try
            Dim symbol As New Symbol()
            symbol.Name = "Star"
            symbolcollection.Insert(symbol)
            id = symbol.ID



            Console.WriteLine(symbolcollection.Count().ToString())
        Catch ex As Exception
            Console.WriteLine("Failed to insert into collection of Database " + database.Name)
            Console.WriteLine("Error :" + ex.Message)
        End Try

    End Sub



#End Region
End Class
Public Class Symbol
    Public Property Name() As String
        Get
        End Get
        Set
        End Set
    End Property
    Public Property ID() As ObjectId
        Get
        End Get
        Set
        End Set
    End Property
End Class
