Public Class Form1
    Private Sub BINtxtbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BINtxtbox.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Computer.Network.IsAvailable = False Then
            MsgBox("Sem Acesso a Internet")
        Else
            If BINtxtbox.Text = "" Then
                MsgBox("Nao ha nada no campo de bin")
            Else
                If BINtxtbox.Text < 100000 Then
                    MsgBox("Erro Bin Invalida Necessita de no minimo 6 Numeros")
                Else
                    WebBrowser1.Navigate("https://www.bankbinlist.com/search.html?bin=" & BINtxtbox.Text & "&hl=pt")
                End If
            End If
        End If
    End Sub

    Private Sub Form1_ClientSizeChanged(sender As Object, e As EventArgs) Handles Me.ClientSizeChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Size = New Point(Me.Size.Width, 5)
        Button1.Location = New Point((Panel1.Size.Width / 2) - (Button1.Size.Width / 2), BINlbl.Location.Y + BINlbl.Size.Height + 10)
        Panel1.Location = New Point(0, Button1.Location.Y + Button1.Size.Height + 5)
        Label1.Location = New Point(10, Panel1.Location.Y + Panel1.Size.Height + 15)
        Label2.Location = New Point(10, Label1.Location.Y + Label1.Size.Height)
        Label3.Location = New Point(10, Label2.Location.Y + Label2.Size.Height)
        Label4.Location = New Point(10, Label3.Location.Y + Label3.Size.Height)
        Label5.Location = New Point(10, Label4.Location.Y + Label4.Size.Height)
        Label6.Location = New Point(10, Label5.Location.Y + Label5.Size.Height)
        Label7.Location = New Point(10, Label6.Location.Y + Label6.Size.Height)
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Dim ArrayTag As New ArrayList
        For Each item As HtmlElement In Me.WebBrowser1.Document.GetElementsByTagName("td")
            ArrayTag.Add(item.InnerText)
        Next
        Label1.Text = "País:" & " " & ArrayTag(0)
        Label2.Text = "Moeda:" & " " & ArrayTag(2)
        Label3.Text = "Banco:" & " " & ArrayTag(3)
        Label4.Text = "Site Banco:" & " " & ArrayTag(4)
        Label5.Text = "Bandeira:" & " " & ArrayTag(7)
        Label6.Text = "Tipo:" & " " & ArrayTag(8)
        Label7.Text = "Classe:" & " " & ArrayTag(9)

    End Sub
End Class
