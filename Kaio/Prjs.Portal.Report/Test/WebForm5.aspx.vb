Imports Novacode
Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.Security
Public Class WebForm5
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CreateSampleDocument()
    End Sub
    Public Sub CreateSampleDocument()
        ' Modify to siut your machine:
        Dim fileName As String = "C:\HP\netPrjs\HQ\Prjs.Portal.Report\Test\VMG_New_TienTien.docx"

        ' Create a document in memory:
        Dim doc = DocX.Create(fileName)

        ' Insert a paragrpah:
        doc.InsertParagraph("This is my first paragraph")

        ' Save to the output directory:
        doc.Save()

        ' Open in Word:
        Process.Start("WINWORD.EXE", fileName)
    End Sub
    Public Sub CreateSampleDocument_Multiple_Paragraphs()
        Dim fileName As String = "C:\HP\netPrjs\HQ\Prjs.Portal.Report\Test\VMG_New_TienTien.docx"
        Dim headlineText As String = "Constitution of the United States"
        Dim paraOne As String = "" & "We the People of the United States, in Order to form a more perfect Union, " & "establish Justice, insure domestic Tranquility, provide for the common defence, " & "promote the general Welfare, and secure the Blessings of Liberty to ourselves " & "and our Posterity, do ordain and establish this Constitution for the United States of America."

        ' A formatting object for our headline:
        Dim headLineFormat = New Formatting()
        headLineFormat.FontFamily = New System.Drawing.FontFamily("Arial Black")
        headLineFormat.Size = 18.0
        headLineFormat.Position = 12

        ' A formatting object for our normal paragraph text:
        Dim paraFormat = New Formatting()
        paraFormat.FontFamily = New System.Drawing.FontFamily("Calibri")
        paraFormat.Size = 10.0

        ' Create the document in memory:
        Dim doc = DocX.Create(fileName)

        ' Insert the now text obejcts;
        doc.InsertParagraph(headlineText, False, headLineFormat)
        doc.InsertParagraph(paraOne, False, paraFormat)

        ' Save to the output directory:
        doc.Save()

        ' Open in Word:
        Process.Start("WINWORD.EXE", fileName)

        ' Insert the Headline and do some formatting:
        'Dim headline As Paragraph = doc.InsertParagraph(headlineText)
        'headline.Color(System.Drawing.Color.Blue)
        'headline.Font(New System.Drawing.FontFamily("Comic Sans MS"))
        'headline.Bold()
        'headline.Position(12.0)
        'headline.FontSize(18.0)

    End Sub
    Private Function GetRejectionLetterTemplate() As DocX
        ' Adjust the path so suit your machine:
        Dim fileName As String = "C:\HP\netPrjs\HQ\Prjs.Portal.Report\Test\VMG_New_TienTien.docx"

        ' Set up our paragraph contents:
        Dim headerText As String = "Rejection Letter"
        Dim letterBodyText As String = DateTime.Now.ToShortDateString()

        Dim paraTwo As String = ((("" & "Dear %APPLICANT%") + Environment.NewLine + Environment.NewLine & "I am writing to thank you for your resume. Unfortunately, your skills and " & "experience do not match our needs at the present time. We will keep your " & "resume in our circular file for future reference. Don't call us, " & "we'll call you. ") + Environment.NewLine + Environment.NewLine & "Sincerely, ") + Environment.NewLine + Environment.NewLine & "Jim Smith, Corporate Hiring Manager"

        ' Title Formatting:
        Dim titleFormat = New Formatting()
        titleFormat.FontFamily = New System.Drawing.FontFamily("Arial Black")
        titleFormat.Size = 18.0
        titleFormat.Position = 12


        ' Body Formatting
        Dim paraFormat = New Formatting()
        paraFormat.FontFamily = New System.Drawing.FontFamily("Calibri")
        paraFormat.Size = 10.0
        titleFormat.Position = 12

        ' Create the document in memory:
        Dim doc = DocX.Create(fileName)

        ' Insert each prargraph, with appropriate spacing and alignment:
        Dim title As Paragraph = doc.InsertParagraph(headerText, False, titleFormat)
        title.Alignment = Alignment.center

        doc.InsertParagraph(Environment.NewLine)
        Dim letterBody As Paragraph = doc.InsertParagraph(letterBodyText, False, paraFormat)
        letterBody.Alignment = Alignment.both

        doc.InsertParagraph(Environment.NewLine)
        doc.InsertParagraph(paraTwo, False, paraFormat)

        Return doc
    End Function
    Public Sub CreateRejectionLetter(applicantField As String, applicantName As String)
        ' We will need a file name for our output file (change to suit your machine):
        Dim fileNameTemplate As String = "C:\HP\netPrjs\HQ\Prjs.Portal.Report\Test\Rejection-Letter-{0}-{1}.docx"

        ' Let's save the file with a meaningful name, including the 
        ' applicant name and the letter date:
        Dim outputFileName As String = String.Format(fileNameTemplate, applicantName, DateTime.Now.ToString("MM-dd-yy"))

        ' Grab a reference to our document template:
        Dim letter As DocX = Me.GetRejectionLetterTemplate()

        ' Perform the replace:
        letter.ReplaceText(applicantField, applicantName)

        ' Save as New filename:
        letter.SaveAs(outputFileName)

        ' Open in word:
        Process.Start("WINWORD.EXE", """" & outputFileName & """")
    End Sub

    Private Sub CreateSampleTable()


        ' We will need a file name for our output file (change to suit your machine):
        Dim fileNameTemplate As String = "C:\HP\netPrjs\HQ\Prjs.Portal.Report\Test\Rejection-Letter-{0}-{1}.docx"

        ' Let's save the file with a meaningful name, including the 
        ' applicant name and the letter date:
        Dim outputFileName As String = String.Format(fileNameTemplate, "ABC", DateTime.Now.ToString("MM-dd-yy"))

        ' Grab a reference to our document template:
        Dim letter As DocX = Me.GetRejectionLetterTemplate()

        Dim rowsCount As Integer = 10
        Dim columnsCount As Integer = 20
        Dim columnWidth As Integer = 30

        Dim sampleTable As Table = letter.AddTable(rowsCount, 1)
        For Each row As Row In sampleTable.Rows
            row.Cells(0).Width = columnWidth
        Next

        For colIndex As Integer = 1 To columnsCount - 1
            sampleTable.InsertColumn(colIndex)
            For Each row As Row In sampleTable.Rows
                row.Cells(colIndex).Width = columnWidth
            Next
        Next

        Dim par As Paragraph = letter.InsertParagraph()
        par.InsertTableBeforeSelf(sampleTable)


        ' Perform the replace:
        letter.ReplaceText("XYZ", "ABC")

        ' Save as New filename:
        letter.SaveAs(outputFileName)

        ' Open in word:
        Process.Start("WINWORD.EXE", """" & outputFileName & """")
    End Sub

    Private Sub CreateTable()
        ' http://www.c-sharpcorner.com/uploadfile/scottlysle/using-the-docx-dll-to-programmatically-create-word-documents/
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CreateSampleDocument()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CreateSampleDocument_Multiple_Paragraphs()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CreateRejectionLetter("%APPLICANT%", "Vu Quang Mai")
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim document As DocX = Me.GetRejectionLetterTemplate()
        Dim t As Table = document.AddTable(20, 4)
        'Format
        'http://www.c-sharpcorner.com/uploadfile/scottlysle/using-the-docx-dll-to-programmatically-create-word-documents/
        'https://github.com/Word-DocX/DocX/blob/master/Examples/Program.cs: VERY GOOD
        't.Design = TableDesign.ColorfulGridAccent1
        't.AutoFit = AutoFit.Window


        For i As Integer = 0 To 19
            t.Rows(i).Cells(0).Paragraphs.First().Append(i)
            t.Rows(i).Cells(1).Paragraphs.First.Append(i + 1)
        Next
        Dim fileNameTemplate As String = "C:\HP\netPrjs\HQ\Prjs.Portal.Report\Test\Rejection-Letter-{0}-{1}.docx"

        ' Let's save the file with a meaningful name, including the 
        ' applicant name and the letter date:
        Dim outputFileName As String = String.Format(fileNameTemplate, "QBC", DateTime.Now.ToString("MM-dd-yy"))
        document.InsertTable(t)

        ' Hợp đồng Hợp tác thanh toán trực tuyến này ("Hợp Đồng") được lập và ký ngày 12 tháng07năm 2016 giữa các bên:
        ' Word HĐ Formatting
        Dim _3Format = New Formatting()
        _3Format.FontFamily = New System.Drawing.FontFamily("Calibri")
        _3Format.Size = 10.0
        _3Format.Position = 12
        _3Format.Bold = True

        Dim para3 As String = "Hợp Đồng"
        document.InsertParagraph(Environment.NewLine)
        document.InsertParagraph(para3, False, _3Format)

        document.SaveAs(outputFileName)
        Process.Start("WINWORD.EXE", """" & outputFileName & """")
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim filePath As String = "C:\HP\netPrjs\HQ\Prjs.Portal.Report\Test\abc.docx"
        Dim doc As DocX = DocX.Create(filePath)
        Dim p1 As Paragraph = doc.InsertParagraph()
        p1.AppendLine("This line contains a ").Append("bold").Bold().Append(" word.")
        p1.AppendLine("Here is example with question mark?")
        p1.AppendLine()
        p1.AppendLine("Can you help me figure it out?")
        p1.AppendLine()

        doc.InsertParagraph(Environment.NewLine)
        doc.InsertParagraph(p1)
        Process.Start("WINWORD.EXE", filePath)
    End Sub
    Private Sub HyperlinksImagesTables()
        Console.WriteLine(vbTab & "HyperlinksImagesTables()")

        ' Create a document.
        'Using document As DocX = DocX.Create("C:\HP\netPrjs\HQ\Prjs.Portal.Report\Test\12345.docx")
        Dim s As String = Context.Request.Url.Host & Context.Request.PhysicalApplicationPath
        Using document As DocX = DocX.Create(Context.Request.PhysicalApplicationPath & "\Test\xyz.docx")
            ' Add a hyperlink into the document.
            Dim link As Hyperlink = document.AddHyperlink("link", New Uri("http://www.google.com"))
            ' Add a Table into the document.
            Dim table As Table = document.AddTable(2, 2)
            table.Design = TableDesign.ColorfulGridAccent2
            table.Alignment = Alignment.center
            table.Rows(0).Cells(0).Paragraphs(0).Append("1")
            table.Rows(0).Cells(1).Paragraphs(0).Append("2")
            table.Rows(1).Cells(0).Paragraphs(0).Append("3")
            table.Rows(1).Cells(1).Paragraphs(0).Append("4")

            Dim newRow As Row = table.InsertRow(table.Rows(1))
            newRow.ReplaceText("4", "5")

            ' Add an image into the document.    
            'Dim image As Novacode.Image = document.AddImage("images\logo_template.png")

            ' Create a picture (A custom view of an Image).
            'Dim picture As Picture = Novacode.Image.CreatePicture()
            'picture.Rotation = 10
            'picture.SetPictureShape(BasicShapes.cube)

            ' Insert a new Paragraph into the document.
            Dim title As Paragraph = document.InsertParagraph().Append("Test").FontSize(20).Font(New FontFamily("Comic Sans MS"))
            title.Alignment = Alignment.center

            ' Insert a new Paragraph into the document.
            Dim p1 As Paragraph = document.InsertParagraph()

            ' Append content to the Paragraph
            p1.AppendLine("This line contains a ").Append("bold").Bold().Append(" word.")
            p1.AppendLine("Here is a cool ").AppendHyperlink(link).Append(".")
            p1.AppendLine("1.1" & vbTab).Append("Telcos").Bold().Append(": là các Công ty Viễn thông di động đang hoạt động trên lãnh thổ Việt Nam như Viettel, VinaPhone, MobiFone, Vietnamobile, Gmobile … ")
            p1.AppendLine()
            ' p1.AppendLine("Check out this picture ").AppendPicture(picture).Append(" its funky don't you think?")
            p1.AppendLine()
            p1.AppendLine("Can you check this Table of figures for me?")
            p1.AppendLine()

            ' Insert the Table after Paragraph 1.
            p1.InsertTableAfterSelf(table)

            ' Insert a new Paragraph into the document.
            Dim p2 As Paragraph = document.InsertParagraph()

            ' Append content to the Paragraph.
            p2.AppendLine("Is it correct?")

            ' Save this document.
            document.Save()

            Console.WriteLine(vbTab & "Created: docs\HyperlinksImagesTables.docx" & vbLf)
        End Using
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        HyperlinksImagesTables()
    End Sub
End Class