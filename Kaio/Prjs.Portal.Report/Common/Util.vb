Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Configuration
Imports System.Data
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Globalization
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Public Class Util
#Region "Format Exception Log Info"
    Public Shared Function ExceptionLogInfo(ByVal vDll As String, ByVal vClass As String, ByVal vMethod As String, vException As String) As String
        Return "Dll: " & vDll & vbCrLf & _
                   "Class: " & vClass & vbCrLf & _
                   "Method: " & vMethod & vbCrLf & _
                   "Detail:" & vException
    End Function
#End Region
#Region "Regular expressions"
    Public Shared Function IsRegexMatch(ByVal vPattern As String, ByVal vInput As String) As Boolean
        Dim vReVal As Boolean = False
        Dim IsRegex As New Regex(vPattern, RegexOptions.IgnoreCase)
        Dim vMatch As Match = IsRegex.Match(vInput)
        If vMatch.Success Then
            vReVal = True
        Else
            vReVal = False
        End If
        Return vReVal

    End Function
    Public Shared Function IsRegexNumeric(ByVal vInput As String) As Boolean
        Dim Regex As Regex = New Regex("[^0-9]")
        Return Not Regex.IsMatch(vInput)
    End Function
    Public Shared Function IsValidPassword(ByVal strPassword As String) As Boolean
        Dim CompareRegex As New Regex("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,15})$")
        If CompareRegex.IsMatch(strPassword) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function IsValidEmail(ByVal strEmail As String) As Boolean
        Dim CompareRegex As String = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        Dim rx As New Regex(CompareRegex, RegexOptions.IgnoreCase)
        If Not rx.IsMatch(strEmail) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function IsRegexInfo(ByVal vPattern As String, ByVal vInput As String) As Boolean
        Dim vReVal As Boolean = False
        If IsRegexMatch(vPattern, vInput) Then
            vReVal = True
        Else
            vReVal = False
        End If
        Return vReVal
    End Function
    'Lọc lấy chữ số
    Public Shared Function FilterNumber(ByVal str As String) As String
        Dim myRegex As Regex = New Regex("\D")
        Dim retval = ""
        For Each subString As String In myRegex.Split(str)
            retval += subString
        Next
        Return retval
    End Function

#End Region
#Region "Date and Time"
    Public Class DateTimeFomat
        Public Shared Function DayOfWeekVietnamese(ByVal vDayOfWeek As String) As String
            Dim str As String = ""
            Select Case vDayOfWeek
                Case 0
                    str = "Chủ nhật"
                Case 1
                    str = "Thứ hai"
                Case 2
                    str = "Thứ ba"
                Case 3
                    str = "Thứ tư"
                Case 4
                    str = "Thứ năm"
                Case 5
                    str = "Thứ sáu"
                Case 6
                    str = "Thứ bảy"
                Case Else
                    str = "#"
            End Select
            Return str
        End Function
        Public Shared Function DateNow() As String
            Return DayOfWeekVietnamese(Now.DayOfWeek) & ", " & Date.Today.Day.ToString() & "-" & Date.Today.Month.ToString & "-" & Date.Today.Year.ToString & " "
        End Function
#Region "Xác định tháng thứ mấy dựa vào tuần của năm"
        Public Shared Function getMonthNum(ByVal vYear As Integer, ByVal vWeek As Integer) As String
            Dim vMonth As Integer = New DateTime(vYear, 1, 1).AddDays(7 * (vWeek - 1)).Month
            Return vMonth
        End Function
#End Region
#Region "Xác định tuần trong năm dựa vào ngày"
        Public Function getWeek() As Integer

            Dim [date] As DateTime = DateTime.Now
            Dim cult_info As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("no")
            Dim cal As System.Globalization.Calendar = cult_info.Calendar
            Dim weekNo As Integer = cal.GetWeekOfYear([date], cult_info.DateTimeFormat.CalendarWeekRule, cult_info.DateTimeFormat.FirstDayOfWeek)
            Return weekNo

        End Function
#End Region
#Region "Xác định ngày đầu tháng và cuối tháng"
        'Public Sub New(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer)
        'End Sub
        'Public Function FirstDayOfMonthFromDateTime(ByVal dateTime As DateTime) As DateTime
        '    Return New DateTime(dateTime.Year, dateTime.Month, 1)
        'End Function
        'Public Function LastDayOfMonthFromDateTime(ByVal dateTime As DateTime) As DateTime
        '    Dim firstDayOfTheMonth As New DateTime(dateTime.Year, dateTime.Month, 1)
        '    Return firstDayOfTheMonth.AddMonths(1).AddDays(-1)
        'End Function
#End Region
#Region "Xác định ngày đầu tuần và cuối tuần trước"
        Private Sub GetDates(ByRef stDate As Date, ByRef endDate As Date)
            Dim offset As Double = 0
            Select Case Today.DayOfWeek
                Case DayOfWeek.Monday : offset = 0
                Case DayOfWeek.Tuesday : offset = -1
                Case DayOfWeek.Wednesday : offset = -2
                Case DayOfWeek.Thursday : offset = -3
                Case DayOfWeek.Friday : offset = -4
                Case DayOfWeek.Saturday : offset = -5
                Case DayOfWeek.Sunday : offset = -6
            End Select
            endDate = DateAdd(DateInterval.Day, offset, Today)
            stDate = DateAdd(DateInterval.Day, -7 + offset, Today)
        End Sub

#End Region
#Region "Get First and Last day of Week from Date"
        Public Sub FirstLastofWeek()
            Dim dtNow As DateTime = Date.Parse("02/01/2012")

            Dim nowdayofweek As Integer = dtNow.DayOfWeek

            Dim weekStartDate, weekEndDate As DateTime

            weekStartDate = DateAdd("d", 0 - dtNow.DayOfWeek, dtNow)

            weekEndDate = DateAdd("d", 6 - dtNow.DayOfWeek, dtNow)

            'Displays first day of the week 

            'Response.Write(weekStartDate.ToString("MM/dd/yyyy"))
            'Response.Write("---")
            'Displays last day of the week 

            'Response.Write(weekEndDate.ToString("MM/dd/yyyy"))
        End Sub
#End Region
#Region "Xác định ngày đầu tuần khi biết năm+tuần"
        Public Shared Function GetWeekStartDate(ByVal Year As Integer, ByVal Week As Integer) As DateTime
            Dim jan1 As New DateTime(Year, 1, 1)
            Dim day As Integer = CInt(jan1.DayOfWeek) - 1
            Dim delta As Integer = (If(day < 4, -day, 7 - day)) + 7 * (Week - 1)
            Return jan1.AddDays(delta)
        End Function
#End Region
#Region "Xác định ngày đầu tiên của năm"
        Private Function FirstDayOfYear(ByVal y As DateTime) As DateTime
            Return New DateTime(y.Year, 1, 1)
        End Function
#End Region
#Region "Xác định ngày cuối cùng của năm"
        Public Shared Function LastDayOfYear(ByVal d As DateTime) As DateTime
            Dim time As New DateTime((d.Year + 1), 1, 1)
            Return time.AddDays(-1)
        End Function
#End Region
#Region "Xác định số tuần trong 1 tháng"
        Public Shared Function GetWeekOfMonth(ByVal [date] As DateTime) As Integer
            Dim beginningOfMonth As New DateTime([date].Year, [date].Month, 1)

            While [date].[Date].AddDays(1).DayOfWeek <> CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
                [date] = [date].AddDays(1)
            End While

            Return CInt(Math.Truncate(CDbl([date].Subtract(beginningOfMonth).TotalDays) / 7.0F)) + 1
        End Function
#End Region
#Region "Xác định tổng số tuần của 1 năm "
        Public Shared Function WeekOfYear(ByVal d As DateTime) As Integer
            'Return DatePart(DateInterval.WeekOfYear, d)
            Dim cult_info As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("no")
            Dim cal As System.Globalization.Calendar = cult_info.Calendar
            Dim weekNo As Integer = cal.GetWeekOfYear(d, cult_info.DateTimeFormat.CalendarWeekRule, cult_info.DateTimeFormat.FirstDayOfWeek)
            Return weekNo
        End Function
#End Region
#Region "Xác định tháng dựa vào năm và tuần"
        Public Shared Function MonthOfYear(ByVal vYear As Integer, ByVal vWeek As Integer) As Integer
            Dim vStartDate As DateTime = New DateTime(vYear, 1, 1)
            While vWeek <> DatePart(DateInterval.WeekOfYear, vStartDate)
                vStartDate = vStartDate.AddDays(1)
            End While
            Return vStartDate.Month
        End Function
#End Region
#Region "Xác định tuần thứ mấy dựa vào ngày"
        Public Shared Function GetWeekNumber(ByVal vdate As DateTime) As Integer
            ' Gets the Calendar instance associated with a CultureInfo.
            Dim myCI As New CultureInfo("vi-VN")
            Dim myCal As System.Globalization.Calendar = myCI.Calendar

            ' Gets the DTFI properties required by GetWeekOfYear.
            Dim myCWR As CalendarWeekRule = myCI.DateTimeFormat.CalendarWeekRule
            Dim myFirstDOW As DayOfWeek = myCI.DateTimeFormat.FirstDayOfWeek

            Return myCal.GetWeekOfYear(vdate, myCWR, myFirstDOW)


            'Dim ci As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture

            'Dim weekNo As Int32 = ci.Calendar.GetWeekOfYear(vdate, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek)
            'Return weekNo
        End Function

#End Region
#Region "Xác định thứ dựa vào ngày"
        Public Shared Function GetDayOfWeek(ByVal ddmmyyyy As String) As Integer
            Dim d As String = ddmmyyyy '"02/06/2016"
            Dim culture As IFormatProvider = New System.Globalization.CultureInfo("vi-VN", True)
            Dim dt2 As DateTime = DateTime.Parse(d, culture, System.Globalization.DateTimeStyles.AssumeLocal)
            Return dt2.DayOfWeek
        End Function
#End Region
        Public Shared Function Timestamp2YYYYMMDD(ByVal ts As DateTime, ByVal seperator As String) As String
            Return DateTime.Parse(ts).ToString("yyyy" & seperator & "MM" & seperator & "dd")
        End Function
        Public Shared Function Timestamp2DDMMYYYY(ByVal ts As DateTime, ByVal seperator As String) As String
            Return DateTime.Parse(ts).ToString("dd" & seperator & "MM" & seperator & "yyyy")
        End Function
        Public Shared Function Timestamp2YYMMDD(ByVal ts As DateTime, ByVal seperator As String) As String
            Return DateTime.Parse(ts).ToString("yy" & seperator & "MM" & seperator & "dd")
        End Function
        Public Shared Function Timestamp2YYYYMM(ByVal ts As DateTime, ByVal seperator As String) As String
            Return DateTime.Parse(ts).ToString("yyyy" & seperator & "MM")
        End Function
        Public Shared Function Timestamp2YYYY(ByVal ts As DateTime) As String
            Return DateTime.Parse(ts).ToString("yyyy")
        End Function
        Public Shared Function Timestamp2MM(ByVal ts As DateTime) As String
            Return DateTime.Parse(ts).ToString("MM")
        End Function
        Public Shared Function Timestamp2DD(ByVal ts As DateTime) As String
            Return DateTime.Parse(ts).ToString("dd")
        End Function
        Public Shared Function Timestamp2HH(ByVal ts As DateTime) As String
            Return DateTime.Parse(ts).ToString("HH")
        End Function
        Public Shared Function Timestamp2MI(ByVal ts As DateTime) As String
            Return DateTime.Parse(ts).ToString("mm")
        End Function
        Public Shared Function Timestamp2SS(ByVal ts As DateTime) As String
            Return DateTime.Parse(ts).ToString("ss")
        End Function
        Public Shared Function Second2Time(ByVal TotalSecond As Integer) As String
            Dim t As TimeSpan = TimeSpan.FromSeconds(TotalSecond)
            Return t.Hours & ":" & t.Minutes & ":" & t.Seconds
        End Function
        Public Shared Function ConvertDateTimeAMPMTo24Hour(ByVal ts As String, ByVal CultureInfo As String) As DateTime
            'Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True) 'dd/MM/yyyy
            'Dim culture As IFormatProvider = New System.Globalization.CultureInfo("en-US", True) 'MM/dd/yyyy
            'Dim culture As IFormatProvider = System.Threading.Thread.CurrentThread.CurrentCulture
            'Dim culture As IFormatProvider = System.Globalization.CultureInfo.InvariantCulture
            'Dim dt As DateTime = DateTime.ParseExact("12/22/2015 9:54:02 PM", "MM/dd/yyyy h:mm:ss tt", culture)
            Dim retval As DateTime = Nothing
            Dim culture As IFormatProvider = System.Globalization.CultureInfo.InvariantCulture
            Select Case CultureInfo
                Case Constants.CultureInfo.culture_Fr
                    culture = New System.Globalization.CultureInfo("fr-FR", True) 'dd/MM/yyyy
                    retval = DateTime.ParseExact(ts, "d/M/yyyy h:mm:ss tt", culture)
                Case Constants.CultureInfo.culture_En
                    culture = New System.Globalization.CultureInfo("en-US", True) 'MM/dd/yyyy
                    retval = DateTime.ParseExact(ts, "M/d/yyyy h:mm:ss tt", culture)
            End Select
            Return retval
        End Function
#Region "Xác định tổng số ngày trong 1 tháng"
        Public Shared Function CaculateDayOfMonth(ByVal Year As Integer, ByVal Month As Integer) As Integer
            Dim retval As Integer = 0
            Select Case Month
                Case 1, 3, 5, 7, 8, 10, 12
                    retval = 31
                Case 4, 6, 9, 11
                    retval = 30
                Case 2 ' Nếu là năm nhuận sẽ có 29 ngày. Năm nhuận là năm thỏa mãn 1 trong 2 yêu cầu sau:
                    '+ Năm chia hết cho 400
                    '+ Năm chia hết cho 4 và không chia hết cho 100
                    If (Year Mod 400 = 0) Or (Year Mod 4 = 0 And Year Mod 100 <> 0) Then
                        retval = 29
                    Else
                        retval = 28
                    End If
            End Select
            Return retval
        End Function
#End Region
#Region "Xác định ngày làm việc thực tế, trừ ngày nghỉ, lễ"
        Public Shared Function BusinessDateDiff(ByVal startDate As Date, ByVal endDate As Date, Optional ByVal saturdayIsHoliday As Boolean = True) As Integer
            Dim incr As Integer = 0
            ' incr can be +1 or -1
            If startDate <= endDate Then incr = 1 Else incr = -1
            Do Until startDate = endDate
                ' skip to previous or next day
                startDate = startDate.AddDays(incr)
                If startDate.DayOfWeek <> DayOfWeek.Sunday AndAlso (startDate.DayOfWeek <> DayOfWeek.Saturday Or Not saturdayIsHoliday) Then 'false || false: false
                    ' if it's a weekday add/subtract one to the result
                    BusinessDateDiff += incr
                End If
            Loop
            ' when the loop is exited the function name contains the correct
            Return BusinessDateDiff
        End Function

#End Region
    End Class
   
#End Region
#Region "Default Object"
    Public Class DefaultObject
        Public Shared Function IsNothing(ByVal value As Object) As String
            Dim str As String = ""
            If value Is Nothing Then
                str = Constants.Encrypt.Zero
            Else
                str = value
            End If
            Return str
        End Function
    End Class
#End Region
#Region "Encrypt"
    Public Class Encrypt
        ' Encrypt the text
        Public Shared Function EncryptText(ByVal strText As String) As String
            Return HttpUtility.UrlEncode(Encrypt(strText, "&%#@?,:*"))
        End Function
        'Decrypt the text 
        Public Shared Function DecryptText(ByVal strText As String) As String
            Return HttpUtility.UrlDecode(Decrypt(strText, "&%#@?,:*"))
        End Function
        'The function used to encrypt the text
        Private Shared Function Encrypt(ByVal strText As String, ByVal strEncrKey As String) As String
            Dim byKey() As Byte = {}
            Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
            Try
                byKey = System.Text.Encoding.UTF8.GetBytes(Left(strEncrKey, 8))

                Dim des As New DESCryptoServiceProvider
                Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(strText)
                Dim ms As New MemoryStream
                Dim cs As New CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write)
                cs.Write(inputByteArray, 0, inputByteArray.Length)
                cs.FlushFinalBlock()
                Return Convert.ToBase64String(ms.ToArray())

            Catch ex As Exception
                Return ex.Message
            End Try

        End Function
        'The function used to decrypt the text
        Private Shared Function Decrypt(ByVal strText As String, ByVal sDecrKey As String) As String
            Dim byKey() As Byte = {}
            Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
            Dim inputByteArray(strText.Length) As Byte
            Try
                byKey = System.Text.Encoding.UTF8.GetBytes(Left(sDecrKey, 8))
                Dim des As New DESCryptoServiceProvider
                inputByteArray = Convert.FromBase64String(strText)
                Dim ms As New MemoryStream
                Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)

                cs.Write(inputByteArray, 0, inputByteArray.Length)
                cs.FlushFinalBlock()
                Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8

                Return encoding.GetString(ms.ToArray())

            Catch ex As Exception
                Return ex.Message
            End Try
        End Function
        Public Shared Function Encode(ByVal str As String) As String
            Return Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(str.Trim))
        End Function
        Public Shared Function Decode(ByVal str As String) As String
            Return System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(str.Trim))
        End Function
    End Class
#End Region
#Region "Create Folder"
    Public Shared Sub CreateUserFolder(ByVal strFolderName As String)
        If Not Directory.Exists(strFolderName) Then
            Directory.CreateDirectory(strFolderName)
        End If
    End Sub
#End Region
#Region "Numeric"
    Public Class Numeric
        Public Function FormatDecimal(ByVal Value As Object, ByVal DecimalPlace As Integer) As String
            Dim str As String = ""
            If Value Is Nothing Or IsDBNull(Value) Then
                str = ""
                Return str
            End If
            If Value = 0 Then
                Return 0
            End If
            If IsNumeric(Value) = True Then
                str = FormatNumber(Value, DecimalPlace, TriState.False)
            Else
                str = Value
            End If
            str = str.Replace(",", "#")
            str = str.Replace(".", ",")
            str = str.Replace("#", ".")
            Return str
        End Function
        Public Shared Function Number2Decimal(ByVal Value As Object, ByVal DecimalPlace As Integer) As String
            Dim str As String = ""
            If Value Is Nothing Or IsDBNull(Value) Then
                str = ""
                Return str
            End If
            If Value = 0 Then
                Return 0
            End If
            If IsNumeric(Value) = True Then
                ' If Value > 0 Then
                str = FormatNumber(Value, DecimalPlace, TriState.False)
                'Else
                'str = Value
                'End If
            Else
                str = Value
            End If
            str = str.Replace(",", "#")
            str = str.Replace(".", ",")
            str = str.Replace("#", ".")
            Return str
        End Function
        Public Function CommasInPlaceOfDecimals(ByVal Value As Object, ByVal DecimalPlace As Integer) As String
            Dim retval As String = ""
            Dim culture = System.Globalization.CultureInfo.GetCultureInfo("de-DE")
            Dim HashTag As String = ""
            For j As Integer = 1 To DecimalPlace
                HashTag = HashTag & "#"
            Next
            retval = [String].Format(culture, "{0:0." & HashTag & "}", Value)
            Return retval
        End Function
    End Class
   
#End Region
#Region "String StringBuilder"
    Public Class StringBuilder
        Public Shared Function ConvertDigit(ByVal str As String) As String
            If str.Trim.Length = 1 Then
                Return "0" & str
            Else
                Return str
            End If
        End Function
    End Class
#End Region
#Region "Format Mobile Operator"
    Public Shared Function FormatOperator(ByVal vMsisdn As String) As String
        Dim str As String = "Unknown"
        If vMsisdn.StartsWith("8491") = True Or vMsisdn.StartsWith("8494") = True Or vMsisdn.StartsWith("84123") = True Or vMsisdn.StartsWith("84124") = True Or vMsisdn.StartsWith("84125") = True Or vMsisdn.StartsWith("84127") = True Or vMsisdn.StartsWith("84129") = True Or vMsisdn.StartsWith("8488") = True Then
            Return "VNP"
        End If
        If vMsisdn.StartsWith("8490") = True Or vMsisdn.StartsWith("8493") = True Or vMsisdn.StartsWith("84120") = True Or vMsisdn.StartsWith("84121") = True Or vMsisdn.StartsWith("84122") = True Or vMsisdn.StartsWith("84126") = True Or vMsisdn.StartsWith("84128") = True Or vMsisdn.StartsWith("8489") = True Then
            Return "VMS"
        End If
        If vMsisdn.StartsWith("8496") = True Or vMsisdn.StartsWith("8498") = True Or vMsisdn.StartsWith("8497") = True Or vMsisdn.StartsWith("84162") = True Or vMsisdn.StartsWith("84163") = True Or vMsisdn.StartsWith("84164") = True Or vMsisdn.StartsWith("84165") = True Or vMsisdn.StartsWith("84166") = True Or vMsisdn.StartsWith("84167") = True Or vMsisdn.StartsWith("84168") = True Or vMsisdn.StartsWith("84169") = True Or vMsisdn.StartsWith("8486") = True Then
            Return "VIETTEL"
        End If
        If vMsisdn.StartsWith("8492") = True Or vMsisdn.StartsWith("84188") = True Or vMsisdn.StartsWith("84186") = True Then
            Return "VNM"
        End If
        If vMsisdn.StartsWith("8499") = True Or vMsisdn.StartsWith("84199") = True Then
            Return "GTEL"
        End If
        Return str
    End Function
     
#End Region
#Region "Random"
    Public Class Randomize
        Public Shared Function RandomString() As String
            Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$()[]"
            Dim r As New Random
            Dim sb As New System.Text.StringBuilder
            For i As Integer = 1 To 8
                Dim idx As Integer = r.Next(0, 68)
                sb.Append(s.Substring(idx, 1))
            Next
            Return sb.ToString()
        End Function
    End Class
#End Region
    Public Shared Function RemoveAccented(ByVal str As String)
        Dim Mảng(13, 17) As String 'Tạo mảng có 14 hàng và 17 cột, mỗi hàng chứa các ký tự cùng nhóm
        Dim i As Byte
        Dim j As Byte
        'Dim n As Byte
        Dim Chuỗi As String
        Dim Thga, Thge, Thgo, Thgu, Thgi, Thgd, Thgy As String
        Dim HoaA, HoaE, HoaO, HoaU, HoaI, HoaD, HoaY As String
        Chuỗi = "aAeEoOuUiIdDyY"
        Thga = "áàạảãâấầậẩẫăắằặẳẵ"
        HoaA = "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ"
        Thge = "éèẹẻẽêếềệểễeeeeee"
        HoaE = "ÉÈẸẺẼÊẾỀỆỂỄEEEEEE"
        Thgo = "óòọỏõôốồộổỗơớờợởỡ"
        HoaO = "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ"
        Thgu = "úùụủũưứừựửữuuuuuu"
        HoaU = "ÚÙỤỦŨƯỨỪỰỬỮUUUUUU"
        Thgi = "íìịỉĩiiiiiiiiiiii"
        HoaI = "ÍÌỊỈĨIIIIIIIIIIII"
        Thgd = "đdddddddddddddddd"
        HoaD = "ĐDDDDDDDDDDDDDDDD"
        Thgy = "ýỳỵỷỹyyyyyyyyyyyy"
        HoaY = "ÝỲỴỶỸYYYYYYYYYYYY"
        'Nạp vào trong Mảng các ký tự
        'Nạp vào từng đầu hàng các ký tự không dấu
        'Nạp vào cột đầu tiên
        For i = 0 To 13
            Mảng(i, 0) = Mid(Chuỗi, i + 1, 1)
        Next
        'Nạp vào từng ô các ký tự có dấu
        For j = 1 To 17
            For i = 1 To 17
                Mảng(0, i) = Mid(Thga, i, 1) 'Nạp từng ký tự trong chuỗi Thga vào từng ô trong hàng 0
                Mảng(1, i) = Mid(HoaA, i, 1) 'Nạp từng ký tự trong chuỗi HoaA vào từng ô trong  hàng 1
                Mảng(2, i) = Mid(Thge, i, 1) 'Nạp từng ký tự trong chuỗi Thge vào từng ô trong  hàng 2
                Mảng(3, i) = Mid(HoaE, i, 1) 'Nạp từng ký tự trong chuỗi HoaE vào từng ô trong  hàng 3
                Mảng(4, i) = Mid(Thgo, i, 1) 'Nạp từng ký tự trong chuỗi Thgo vào từng ô trong  hàng 4
                Mảng(5, i) = Mid(HoaO, i, 1) 'Nạp từng ký tự trong chuỗi HoaO vào từng ô trong  hàng 5
                Mảng(6, i) = Mid(Thgu, i, 1) 'Nạp từng ký tự trong chuỗi Thgu vào từng ô trong  hàng 6
                Mảng(7, i) = Mid(HoaU, i, 1) 'Nạp từng ký tự trong chuỗi HoaU vào từng ô trong  hàng 7
                Mảng(8, i) = Mid(Thgi, i, 1) 'Nạp từng ký tự trong chuỗi Thgi vào từng ô trong  hàng 8
                Mảng(9, i) = Mid(HoaI, i, 1) 'Nạp từng ký tự trong chuỗi HoaI vào từng ô trong  hàng 9
                Mảng(10, i) = Mid(Thgd, i, 1) 'Nạp từng ký tự trong chuỗi Thgd vào từng ô trong  hàng 10
                Mảng(11, i) = Mid(HoaD, i, 1) 'Nạp từng ký tự trong chuỗi HoaD vào từng ô trong  hàng 11
                Mảng(12, i) = Mid(Thgy, i, 1) 'Nạp từng ký tự trong chuỗi Thgy vào từng ô trong  hàng 12
                Mảng(13, i) = Mid(HoaY, i, 1) 'Nạp từng ký tự trong chuỗi HoaY vào từng ô trong  hàng 13
            Next
        Next

        Dim Tạm1, Tạm2 As String
        ' Gán cho biến Tạm1 nội dung trong TxtViết 
        Tạm1 = str.Trim
        ' Tiến hành thay thế , lọc bỏ dấu cho chuỗi
        For j = 0 To 13
            For i = 1 To 17
                Tạm2 = Tạm1.Replace(Mảng(j, i), Mảng(j, 0))
                Tạm1 = Tạm2
            Next
        Next
        Return Tạm1
    End Function
#Region "Xử lý lỗi gửi email: The remote certificate is invalid according to the validation procedure."
    Private Shared Function CustomCertValidation(ByVal sender As Object, ByVal cert As X509Certificate, ByVal chain As X509Chain, ByVal errors As SslPolicyErrors) As Boolean
        Return True
    End Function
    'USAGE
    Public Shared Sub DoStuff()
        'CALL THIS BEFORE ANY HTTPS CALLS THAT WILL FAIL WITH CERT ERROR
        ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf CustomCertValidation)
    End Sub
#End Region
#Region "Load Control Data"
    Public Class ControlData
        Public Shared Sub LoadControlMMDDHH(ByVal vYear As Integer, ByVal vMonth As Integer, _
                          ByVal ControlFromDate As System.Web.UI.WebControls.DropDownList, _
                          ByVal ControlToDate As System.Web.UI.WebControls.DropDownList, _
                          ByVal ControlFromHour As System.Web.UI.WebControls.DropDownList, _
                          ByVal ControlToHour As System.Web.UI.WebControls.DropDownList)
            Dim MonthOfYear() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}
            Dim DayOfMonth() As Integer = {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}
            Dim result As Integer = 0
            Dim TotalDayOfMonth As Integer = DateTimeFomat.CaculateDayOfMonth(vYear, vMonth)
            ControlFromDate.Items.Clear()
            ControlToDate.Items.Clear()
            For i As Integer = 1 To TotalDayOfMonth
                ControlFromDate.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
                ControlToDate.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
            Next

            If vMonth = Now.Month Then
                ControlFromDate.SelectedValue = Now.Day
                ControlToDate.SelectedValue = Now.Day
            Else
                ControlFromDate.SelectedValue = 1
                ControlToDate.SelectedValue = 1
            End If
            For i As Integer = 0 To 23
                ControlFromHour.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
                ControlToHour.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
            Next
            ControlFromHour.SelectedValue = 0
            ControlToHour.SelectedValue = 23
            For i As Integer = 0 To 23
                ControlFromHour.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
                ControlToHour.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
            Next
            ControlFromHour.SelectedValue = 0
            ControlToHour.SelectedValue = 23

        End Sub
        Public Shared Sub LoadControlMMDD(ByVal vMonth As Integer, _
                        ByVal ControlFromDate As System.Web.UI.WebControls.DropDownList, _
                        ByVal ControlToDate As System.Web.UI.WebControls.DropDownList)
            Dim MonthOfYear() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}
            Dim DayOfMonth() As Integer = {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}
            Dim result As Integer = 0
            Dim TotalDayOfMonth As Integer = 0
            For k As Integer = 0 To MonthOfYear.Length - 1
                If vMonth = MonthOfYear(k) Then
                    TotalDayOfMonth = DayOfMonth(k)
                    Exit For
                End If
            Next
            ControlFromDate.Items.Clear()
            ControlToDate.Items.Clear()
            For i As Integer = 1 To TotalDayOfMonth
                ControlFromDate.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
                ControlToDate.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
            Next

            If vMonth = Now.Month Then
                ControlFromDate.SelectedValue = Now.Day
                ControlToDate.SelectedValue = Now.Day
            Else
                ControlFromDate.SelectedValue = 1
                ControlToDate.SelectedValue = 1
            End If
        End Sub
        Public Shared Sub MMDDHHMI(ByVal vMonth As Integer, _
                          ByVal ControlFromDate As System.Web.UI.WebControls.DropDownList, _
                          ByVal ControlToDate As System.Web.UI.WebControls.DropDownList, _
                          ByVal ControlFromHour As System.Web.UI.WebControls.DropDownList, _
                          ByVal ControlToHour As System.Web.UI.WebControls.DropDownList, _
                          ByVal ControlFromMinute As System.Web.UI.WebControls.DropDownList, _
                          ByVal ControlToMinute As System.Web.UI.WebControls.DropDownList)
            Dim MonthOfYear() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}
            Dim DayOfMonth() As Integer = {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}
            Dim result As Integer = 0
            Dim TotalDayOfMonth As Integer = 0
            For k As Integer = 0 To MonthOfYear.Length - 1
                If vMonth = MonthOfYear(k) Then
                    TotalDayOfMonth = DayOfMonth(k)
                    Exit For
                End If
            Next
            ControlFromDate.Items.Clear()
            ControlToDate.Items.Clear()
            For i As Integer = 1 To TotalDayOfMonth
                ControlFromDate.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
                ControlToDate.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
            Next

            If vMonth = Now.Month Then
                ControlFromDate.SelectedValue = Now.Day
                ControlToDate.SelectedValue = Now.Day
            Else
                ControlFromDate.SelectedValue = 1
                ControlToDate.SelectedValue = 1
            End If
            For i As Integer = 0 To 23
                ControlFromHour.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
                ControlToHour.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
            Next
            ControlFromHour.SelectedValue = 0
            ControlToHour.SelectedValue = 23
            For i As Integer = 0 To 23
                ControlFromHour.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
                ControlToHour.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
            Next
            ControlFromHour.SelectedValue = 0
            ControlToHour.SelectedValue = 23
            For i As Integer = 0 To 59
                ControlFromMinute.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
                ControlToMinute.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), i))
            Next
            ControlFromMinute.SelectedValue = 0
            ControlToMinute.SelectedValue = 59
        End Sub
    End Class
#End Region
End Class
