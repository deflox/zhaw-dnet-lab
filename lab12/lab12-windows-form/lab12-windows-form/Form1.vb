Imports System.Xml

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog <> DialogResult.Cancel Then
            selectedFile.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (RadioButton1.Checked) Then
            ConvertToXml()
        End If
    End Sub

    Private Sub ConvertToXml()
        Dim isFirstRow As Boolean = True
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True

        Using writer As XmlWriter = XmlWriter.Create("output.xml", settings)
            writer.WriteStartDocument()
            writer.WriteStartElement("People")

            Using MyReader As New FileIO.TextFieldParser(OpenFileDialog1.FileName)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(";")
                Dim firstRow As String()
                Dim currentRow As String()

                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields()

                        If isFirstRow Then
                            firstRow = currentRow
                            isFirstRow = False
                        Else
                            writer.WriteStartElement("Person")
                            Dim fieldIndex As Integer = 0
                            Dim currentField As String
                            For Each currentField In currentRow
                                writer.WriteElementString(firstRow(fieldIndex), currentField)
                                fieldIndex = fieldIndex + 1
                            Next

                            writer.WriteEndElement()
                        End If

                    Catch ex As FileIO.MalformedLineException
                        MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                    End Try
                End While
            End Using

            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using
    End Sub
End Class
