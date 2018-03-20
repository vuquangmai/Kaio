
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Reflection
Imports Novacode
Imports System
Imports System.Diagnostics
 
Namespace Novacode
    Class Program

        Shared gAssembly As Assembly



        ' reference to the working document.

        Shared gDocument As DocX





        Private Shared Sub Main(args As String())


            ' set a global reference to the executing assembly

            gAssembly = Assembly.GetExecutingAssembly()



            ' To begin with, we can look for a document template 

            ' to see if it exists, if it does not, we will 

            ' programmatically create the template, else we will use it.

            Try


                If File.Exists("InvoiceTemplate.docx") Then


                    ' set a global reference to the template;

                    ' note the template is just a document and

                    ' not actually a template

                    gDocument = DocX.Load("InvoiceTemplate.docx")



                    ' once we have the document, we will populate it

                    ' in code, this will create the document we want

                    ' to send out or print.


                    gDocument = CreateInvoiceFromTemplate(DocX.Load("InvoiceTemplate.docx"))



                    ' Save the current working document so as not

                    ' to overwrite the template document that we

                    ' will want to reuse many times


                    gDocument.SaveAs("NewLoadedShipment.docx")
                Else



                    ' Create a store a global reference to the

                    ' template 'InvoiceTemplate.docx'.

                    gDocument = CreateInvoiceTemplate()



                    ' Save the template 'InvoiceTemplate.docx'.

                    gDocument.Save()



                    ' I will be lazy and just call the

                    ' same code again now that we have

                    ' a working template saved and so

                    ' the user does not have to restart

                    ' the appication is the template was

                    ' originally missing



                    ' set a global reference to the template

                    ' just created

                    gDocument = DocX.Load("InvoiceTemplate.docx")



                    ' populate the document with data so we

                    ' can print it or email it off to a

                    ' recipient


                    gDocument = CreateInvoiceFromTemplate(DocX.Load("InvoiceTemplate.docx"))



                    ' Save the current working document so as not

                    ' to overwrite the template document that we

                    ' will want to reuse many times


                    gDocument.SaveAs("NewLoadedShipment.docx")

                End If

            Catch ex As Exception


                Console.WriteLine("An Error has occurred")

                Console.WriteLine("Message:  " & ex.Message)

                Console.WriteLine(ex.StackTrace)

                Console.WriteLine("Press any key to continue")


                Console.Read()
            End Try

        End Sub







        ''' <summary>

        ''' Take the document template and populate it with

        ''' variable data to ready it for one specific

        ''' billing target

        '''

        ''' This addresses putting custom data into various

        ''' regions of the document, demonstrating how to

        ''' fully populate the template.  Examine each

        ''' defined region to see how to put in text, images,

        ''' and tabular data.

        ''' </summary>

        ''' <param name="template"></param>

        ''' <returns></returns>

        Private Shared Function CreateInvoiceFromTemplate(template As DocX) As DocX




            '#Region "Logo"



            ' A glance at the template shows us that

            ' the logo exists in a table at row 0, cell 1.

            ' That image is a placeholder image that has

            ' to be replaced with the actual logo.


            Dim logo_paragraph As Paragraph = template.Tables(0).Rows(0).Cells(1).Paragraph



            ' Prepare to replace the temporary logo in

            ' the template with the actual logo by first

            ' removing that temporary image from the

            ' template

            logo_paragraph.Pictures(0).Remove()



            ' Add the actual logo to this document

            ' which is contained in an embedded

            ' resource



            Dim logo As Novacode.Image = template.AddImage(gAssembly.GetManifestResourceStream("Novacode.Resources.FakeLogo.png"))



            ' Insert the extracted logo into the paragraph

            Dim logo_picture As Picture = logo_paragraph.InsertPicture(logo.Id)



            '#End Region





            '#Region "Set Custom Property values"



            ' Set the value of the custom property 'company_name'.


            template.AddCustomProperty(New CustomProperty("company_name", "Bart's Parts"))



            ' Set the value of the custom property 'company_slogan'.


            template.AddCustomProperty(New CustomProperty("company_slogan", "The King of OEM distributions"))



            ' Set the value of the custom properties 'hired_company_address_line_one',

            ''hired_company_address_line_two' and 'hired_company_address_line_three'.


            template.AddCustomProperty(New CustomProperty("hired_company_username", "Joe Bagadonuts"))




            template.AddCustomProperty(New CustomProperty("hired_company_address_line_one", "1100 Main Street"))




            template.AddCustomProperty(New CustomProperty("hired_company_address_line_two", "Atlanta, GA"))




            template.AddCustomProperty(New CustomProperty("hired_company_address_line_three", "30303"))



            ' Set the value of the custom property 'invoice_date'.


            template.AddCustomProperty(New CustomProperty("invoice_date", DateTime.Today.[Date].ToShortDateString()))



            ' Set the value of the custom property 'invoice_time'.


            template.AddCustomProperty(New CustomProperty("invoice_time", DateTime.Today.[Date].ToShortTimeString()))



            ' Set the value of the custom property

            ' 'hired_company_details_line_one' and 'hired_company_details_line_two'.



            template.AddCustomProperty(New CustomProperty("hired_company_details_line_one", "1100 North Main Street, Fremont, CA 12345"))





            template.AddCustomProperty(New CustomProperty("hired_company_details_line_two", "Phone: 012-345-6789, Fax: 012-345-6789, e-mail: support@oem.com"))



            '#End Region


            '#Region "Replace Placeholder Table"



            ' Capture the blank table in the template

            Dim t As Table = template.Tables(1)



            ' replace the blank table with a table containing

            ' the invoice data


            Dim invoice_table As Table = CreateAndInsertInvoiceTableAfter(t, template)



            ' remove the blank table from the document

            t.Remove()



            ' Return the template now that it has been

            ' modified to hold all of our custom data.

            Return template



            '#End Region

        End Function



        ''' <summary>

        ''' Create a template

        '''

        ''' This method is called whenever the template does not

        ''' exist.  The purpose of the method is to create the

        ''' template so that it might be used as the basis for

        ''' creating data specific versions of the invoice

        ''' document

        '''

        ''' In general, the template defines locations and

        ''' custom properties that will be used by the process

        ''' used to populate the document with actual data.

        '''

        ''' In that process, the code will find each specific

        ''' location and property and replace the default

        ''' text assigned here with actual information

        ''' </summary>

        ''' <returns></returns>

        Private Shared Function CreateInvoiceTemplate() As DocX


            ' Create a new document with the canned

            ' document title.  Note this is really just

            ' a document and not an actual template

            Dim document As DocX = DocX.Create("InvoiceTemplate.docx")



            ' Create a table for layout purposes

            ' (This table will be invisible).

            ' Document content will be placed into various cells

            ' within this table

            Dim layout_table As Table = document.InsertTable(2, 2)

            layout_table.Design = TableDesign.TableNormal

            layout_table.AutoFit = AutoFit.Window





            '#Region "Create document style"



            ' create formatting styles that will be used

            ' to define the appearance of the document

            ' once populated with actual data



            ' Large Dark formatting - for titles

            Dim large_dark_formatting As New Formatting()

            large_dark_formatting.Bold = True

            large_dark_formatting.Size = 16

            large_dark_formatting.FontColor = Color.Black



            ' Dark formatting

            Dim dark_formatting As New Formatting()

            dark_formatting.Bold = True

            dark_formatting.Size = 12

            dark_formatting.FontColor = Color.Black



            ' Light formatting

            Dim light_formatting As New Formatting()

            light_formatting.Italic = True

            light_formatting.Size = 11

            light_formatting.FontColor = Color.Black



            '#End Region





            '#Region "Company Name"



            ' Define a custom property for the company name, this property

            ' will be populated with the actual company name when the

            ' document is populated with actual data



            ' Capture the upper left Paragraph location in the layout_table; this

            ' is the location the company name will be placed into when the

            ' document is populated with data.


            Dim upper_left_paragraph As Paragraph = layout_table.Rows(0).Cells(0).Paragraph



            ' Create a custom property called company_name and set it to

            ' display a generic company name in the template


            Dim company_name As New CustomProperty("company_name", "Company Name")



            ' Put the document property into the table at the

            ' correct location and apply the display style


            layout_table.Rows(0).Cells(0).Paragraph.InsertDocProperty(company_name, large_dark_formatting)



            ' Force the next text insert to be on a new line.

            upper_left_paragraph.InsertText(vbLf, False)



            '#End Region





            '#Region "Company Slogan"



            ' use the same approach used with the company name to

            ' insert a new property under the company name; this

            ' property will display the company slogan using a

            ' smaller font and in italics



            ' Create a custom property called company_slogan



            Dim company_slogan As New CustomProperty("company_slogan", "Company slogan goes here.")



            ' Insert a field of type doc property

            ' (This will display the custom property 'company_slogan')


            upper_left_paragraph.InsertDocProperty(company_slogan, light_formatting)



            '#End Region





            '#Region "Company Logo"

            ' Get the upper right Paragraph in the layout_table.

            Dim upper_right_paragraph As Paragraph = layout_table.Rows(0).Cells(1).Paragraph



            ' Add a template logo image to this document.

            Dim logo As Novacode.Image = document.AddImage(gAssembly.GetManifestResourceStream("Novacode.Resources.logo_template.png"))



            ' Insert this template logo into the upper right Paragraph.

            Dim picture_logo As Picture = upper_right_paragraph.InsertPicture(logo.Id, "", "")



            upper_right_paragraph.Alignment = Alignment.right

            '#End Region



            '#Region "Hired Company Address"



            ' Create a custom property called

            ' company_address_line_one



            Dim hired_company_username As New CustomProperty("hired_company_username", "User Name:")



            ' Create a custom property called

            ' company_address_line_one



            Dim hired_company_address_line_one As New CustomProperty("hired_company_address_line_one", "Street Address,")



            ' Get the lower left Paragraph in the layout_table.


            Dim lower_left_paragraph As Paragraph = layout_table.Rows(1).Cells(0).Paragraph



            lower_left_paragraph.InsertText("TO:" & vbLf, False, dark_formatting)



            ' Insert a field of type doc property

            ' (This will display the custom property

            ' 'hired_company_username')


            lower_left_paragraph.InsertDocProperty(hired_company_username, light_formatting)



            ' Force the next text insert to be on a new line.

            lower_left_paragraph.InsertText(vbLf, False)



            ' Insert a field of type doc property

            ' (This will display the custom property

            ' 'hired_company_address_line_one')


            lower_left_paragraph.InsertDocProperty(hired_company_address_line_one, light_formatting)



            ' Force the next text insert to be on a new line.

            lower_left_paragraph.InsertText(vbLf, False)



            ' Create a custom property called

            ' company_address_line_two



            Dim hired_company_address_line_two As New CustomProperty("hired_company_address_line_two", "City,")



            ' Insert a field of type doc property

            ' (This will display the custom property

            ' 'hired_company_address_line_two')


            lower_left_paragraph.InsertDocProperty(hired_company_address_line_two, light_formatting)



            ' Force the next text insert to be on a new line.

            lower_left_paragraph.InsertText(vbLf, False)



            ' Create a custom property called company_address_line_two



            Dim hired_company_address_line_three As New CustomProperty("hired_company_address_line_three", "Zip Code")



            ' Insert a field of type doc property

            ' (This will display the custom property

            ' 'hired_company_address_line_three')


            lower_left_paragraph.InsertDocProperty(hired_company_address_line_three, light_formatting)



            '#End Region



            '#Region "Date & Invoice number"



            ' Get the lower right Paragraph from the layout table.


            Dim lower_right_paragraph As Paragraph = layout_table.Rows(1).Cells(1).Paragraph





            Dim invoice_date As New CustomProperty("invoice_date", DateTime.Today.[Date].ToString("d"))




            lower_right_paragraph.InsertText("Date: ", False, dark_formatting)




            lower_right_paragraph.InsertDocProperty(invoice_date, light_formatting)





            Dim invoice_time As New CustomProperty("invoice_time", DateTime.Today.[Date].ToShortTimeString())




            lower_right_paragraph.InsertText(vbLf & "Time: ", False, dark_formatting)




            lower_right_paragraph.InsertText("", False, light_formatting)




            lower_right_paragraph.InsertDocProperty(invoice_time, light_formatting)



            ' set the paragraph to align against the right side

            ' of the invoice

            lower_right_paragraph.Alignment = Alignment.right



            '#End Region





            '#Region "Statement of thanks"



            ' Insert an empty Paragraph between two Tables,

            ' so that they do not touch.

            document.InsertParagraph(String.Empty, False)



            ' This table will hold all of the invoice data.

            ' set the table style to a canned format

            Dim invoice_table As Table = document.InsertTable(7, 4)

            invoice_table.Design = TableDesign.LightShadingAccent1

            invoice_table.Alignment = Alignment.center



            ' A nice thank you Paragraph.




            Dim thankyou As Paragraph = document.InsertParagraph(vbLf & "Thank you for your business, " & "see us again for all of your OEM parts needs.", False, dark_formatting)



            thankyou.Alignment = Alignment.center



            '#End Region



            '#Region "Hired company details"





            Dim hired_company_details_line_one As New CustomProperty("hired_company_details_line_one", "Street Address, City, ZIP Code")






            Dim hired_company_details_line_two As New CustomProperty("hired_company_details_line_two", "Phone: 000-000-0000, Fax: 000-000-0000, " & "e-mail: support@companyname.com")




            Dim companyDetails As Paragraph = document.InsertParagraph(String.Empty, False)




            companyDetails.InsertDocProperty(hired_company_details_line_one, light_formatting)



            companyDetails.InsertText(vbLf, False)




            companyDetails.InsertDocProperty(hired_company_details_line_two, light_formatting)



            companyDetails.Alignment = Alignment.center



            '#End Region



            ' Return the template document now that it has been created.

            Return document

        End Function



        ''' <summary>

        ''' This method will capture the data required to

        ''' populate the invoice's table, and it will then

        ''' use that data to populate a new table, will

        ''' insert the new table into the document, and

        ''' it will then remove the old blank place holder

        ''' table from the document

        ''' </summary>

        ''' <param name="t"></param>

        ''' <param name="document"></param>

        ''' <returns></returns>


        Private Shared Function CreateAndInsertInvoiceTableAfter(t As Table, ByRef document As DocX) As Table


            ' Grab data from somewhere (Most likely a database); this

            ' example just creates a dummy list of values

            Dim data As DataTable = GetDataFromDatabase()



            '
            '
            '             * The trick to replacing one Table with another,
            '
            '             * is to insert the new Table after the old one,
            '
            '             * and then remove the old one.
            '
            '             




            Dim invoice_table As Table = t.InsertTableAfterSelf(data.Rows.Count + 1, data.Columns.Count)



            invoice_table.Design = TableDesign.DarkListAccent1



            '#Region "Table title and column headers"



            Dim table_title As New Formatting()

            table_title.Bold = True




            invoice_table.Rows(0).Cells(0).Paragraph.InsertText("Invoice ID", False, table_title)




            invoice_table.Rows(0).Cells(0).Paragraph.Alignment = Alignment.left




            invoice_table.Rows(0).Cells(1).Paragraph.InsertText("Part Number", False, table_title)




            invoice_table.Rows(0).Cells(1).Paragraph.Alignment = Alignment.left




            invoice_table.Rows(0).Cells(2).Paragraph.InsertText("Description", False, table_title)




            invoice_table.Rows(0).Cells(2).Paragraph.Alignment = Alignment.left




            invoice_table.Rows(0).Cells(3).Paragraph.InsertText("Unit Price", False, table_title)




            invoice_table.Rows(0).Cells(3).Paragraph.Alignment = Alignment.left




            invoice_table.Rows(0).Cells(4).Paragraph.InsertText("Number Ordered", False, table_title)




            invoice_table.Rows(0).Cells(4).Paragraph.Alignment = Alignment.left




            invoice_table.Rows(0).Cells(5).Paragraph.InsertText("Total", False, table_title)




            invoice_table.Rows(0).Cells(5).Paragraph.Alignment = Alignment.left





            '#End Region





            ' Loop through the rows in the Table and insert

            ' data from the data source.

            For row As Integer = 1 To invoice_table.RowCount - 1


                For cell As Integer = 0 To invoice_table.Rows(row).Cells.Count - 1



                    Dim cell_paragraph As Paragraph = invoice_table.Rows(row).Cells(cell).Paragraph





                    cell_paragraph.InsertText(data.Rows(row - 1).ItemArray(cell).ToString(), False)

                Next
            Next



            ' Let the tables coloumns expand to fit its contents.

            invoice_table.AutoFit = AutoFit.Contents



            ' Center the Table

            invoice_table.Alignment = Alignment.center



            ' Return the invloce table now that it has been created.

            Return invoice_table



        End Function



        ''' <summary>

        ''' Get the source data and use it to populate the invoice

        ''' table displayed in the document

        '''

        ''' You will likely be getting the data from a database and

        ''' you will have to adjust the column headers and structure

        ''' to match the content returned from any required query

        ''' against the actual data source.

        ''' </summary>

        ''' <returns></returns>

        Private Shared Function GetDataFromDatabase() As DataTable


            Dim table As New DataTable()




            table.Columns.AddRange(New DataColumn() {New DataColumn("InvoiceId"), New DataColumn("PartNo"), New DataColumn("Description"), New DataColumn("UnitPrice"), New DataColumn("UnitsOrderd"), New DataColumn("RowTotal")})











            table.Rows.Add("78123", "801-ST344", "Steering Column", "$287.65", "1", "$287.65")











            table.Rows.Add("78124", "71-AC9488", "Compressor, AC", "$614.82", "1", "$614.82")











            table.Rows.Add("78125", "783342", "Air filter, Fram", "$9.12", "1", "$9.12")











            table.Rows.Add("78126", "AC49034", "Spark Plug, Platinum", "$5.12", "8", "$40.96")











            table.Rows.Add("78127", "FMC-66-1243", "Bumper, Front", "$212.45", "1", "$212.45")











            table.Rows.Add("", "", "Tax", "", "", "93.20")











            table.Rows.Add("", "", "Total", "", "", "$1258.20")



            Return table

        End Function

    End Class

End Namespace
