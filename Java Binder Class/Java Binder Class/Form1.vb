Imports System.IO
Imports System.Text

Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim openFileDialog1 As New OpenFileDialog()


        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True
        If openFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            TextBox1.Text = openFileDialog1.FileName
        End If

    End Sub
    Sub work()
        Dim size As Integer = TextBox2.Text * 1000
        Dim F() As Byte = File.ReadAllBytes(TextBox1.Text)
        Dim buff As New StringBuilder("")

        Dim m1 As String = " public static byte[]a" 'put co

        Dim m2 As String = "(){byte[]aa={" 'put  buff

        Dim mend As String = "}; return aa;}"
        Dim i As Integer = 0
        Dim co As Integer = 0

        buff.Append(m1)
        buff.Append(co)
        buff.Append(m2)

        For Each b As Byte In F
            buff.Append(" (byte)").Append(b.ToString()).Append(",")    '0x
            i = i + 1
            If (i Mod 70 = 0) Then 'new line
                buff.Append(vbCrLf)
            End If
            If (i = size) Then
                buff.Append(mend) 'end current method
                buff.Append(vbCrLf).Append(vbCrLf) 'lines
                buff.Append(m1) 'begin method
                co += 1
                buff.Append(co)
                buff.Append(m2)
                i = 0
            End If
        Next
        buff.Append(mend) 'end ,ethod

        Dim retutnAll As New StringBuilder
        retutnAll.Append("public static byte[]getfile(){try {").Append(vbCrLf)
        retutnAll.Append("ByteArrayOutputStream outputStream = new ByteArrayOutputStream( );").Append(vbCrLf)
        For ii As Integer = 0 To co
            retutnAll = retutnAll.Append("outputStream.write( a").Append(ii).Append("() );").Append(vbCrLf)
        Next

        retutnAll.Append("byte c[] = outputStream.toByteArray( );").Append(vbCrLf).Append("return c;}")
        retutnAll.Append("catch (IOException ex) {return null; }}")
        retutnAll.Append(vbCrLf).Append(buff).Append(vbCrLf)

        IO.File.WriteAllText(TextBox1.Text & "_java.txt", retutnAll.ToString())


    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        work()
        MsgBox("Done ! File saved to the same path ")
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label2.Text = "max size of code in java is 64 kb" & vbNewLine & "keep in mind that one byte take more than 7 bytes to represent" & vbNewLine & "so split by a smaller value that 64 kb  ,Advice , just keep it 7" & _
            vbNewLine & "you may want to keep each file bytes in separated class"
        Me.AllowDrop = True
        TextBox2.Text = "7"
    End Sub

    Private Sub TextBox1_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            TextBox1.Text = path
        Next
        work()
    End Sub

    Private Sub TextBox1_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If

    End Sub
End Class
