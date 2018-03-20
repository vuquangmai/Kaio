Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Script.Serialization
Public Class LottYtLiveResult
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
        End If
    End Sub
    <WebMethod()> _
    Public Shared Function LoadQueue(ByVal param1 As String) As String

        Dim vJson As String = ""
        If DateTime.Parse(Now).ToString("HHmm") > 1810 And DateTime.Parse(Now).ToString("HHmm") < 1830 Then
            Dim vCustomerInfo As New ObjResultInfo(1)
            vJson = ObjectToJson(vCustomerInfo)
        End If

        ' LogService.WriteLog(Constants.LogLevel._Debug, vJson)
        Return vJson
    End Function
    Public Shared Function DatasetToJson(ByVal ds As DataSet) As String
        Dim json As StringBuilder = New StringBuilder
        For Each dr As DataRow In ds.Tables(0).Rows
            json.Append("{")
            Dim i As Integer = 0
            Dim colcount As Integer = dr.Table.Columns.Count
            For Each dc As DataColumn In dr.Table.Columns
                json.Append("\""")
                json.Append(dc.ColumnName)
                json.Append("\"":\""")
                json.Append(dr(dc))
                json.Append("\""")
                i = (i + 1)
                If (i < colcount) Then
                    json.Append(",")
                End If
            Next
            json.Append("\""}")
            json.Append(",")
        Next
        Return json.ToString
    End Function
    Public Shared Function ObjectToJson(ByVal obj As Object) As String
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer
        Return serializer.Serialize(obj)
    End Function
    Public Shared Function GetJson(ByVal dt As DataTable) As String
        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object) = Nothing
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each dc As DataColumn In dt.Columns
                ' If dc.ColumnName.Trim() = "TAGNAME" Then
                row.Add(dc.ColumnName.Trim(), dr(dc))
                ' End If
            Next
            rows.Add(row)
        Next
        Return serializer.Serialize(rows)
    End Function
End Class