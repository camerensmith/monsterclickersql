
Imports System.Data.SqlClient
Imports System

Public Class Form1



    REM NuGet download packages for SQL server // Package manager for System.Data.SqlClient




    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim myCursor As New Cursor(New IO.MemoryStream(My.Resources.cursor.cursor)) 'Exception here indicates a 32bpp cursor.
    End Sub
    ' Change over the cursor to the Pokeball style image


    Dim index As Integer
    Dim Points As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        loadData(index)
        Label4.Text = dt.Rows.Count
        Timer1.Enabled = True



    End Sub





    Dim dt As New DataTable
    Private Sub loadData(ByVal position As Integer)



        Dim conn As New SqlConnection("Data Source=.;Initial catalog=games;Integrated Security=true")
        Dim cmd As New SqlCommand("Select word,path_picture from game1", conn)
        Dim da As New SqlDataAdapter(cmd)

        da.Fill(dt)
        'After defining the variables for storage, I fill in the data table that I defined as dt through
        'the SQL data adapter

        Label1.Text = dt.Rows(position)(0).ToString
        PictureBox1.Image = Image.FromFile(dt.Rows(position)(1).ToString)



    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As Event Args) Handles PictureBox1.Click

        index = index + 1
        loadData(index)
        Points = Points + 1
        Label2.Text = Points


    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        PictureBox1.Left = Rnd() * (Me.Width - PictureBox1.Left)
        PictureBox1.Top = Rnd() * (Me.Width - PictureBox1.Height)

        If PictureBox1.Bounds.IntersectsWith(Button1.Bounds) Then
            PictureBox1.Top = 230
            PictureBox1.Left = 180
        End If

        If PictureBox1.Bounds.IntersectsWith(Label1.Bounds) Then
            PictureBox1.Top = 230
            PictureBox1.Left = 180
        End If

        If PictureBox1.Bounds.IntersectsWith(Label2.Bounds) Then
            PictureBox1.Top = 230
            PictureBox1.Left = 180
        End If

        If PictureBox1.Bounds.IntersectsWith(Label3.Bounds) Then
            PictureBox1.Top = 230
            PictureBox1.Left = 180
        End If

        If PictureBox1.Bounds.IntersectsWith(Label4.Bounds) Then
            PictureBox1.Top = 230
            PictureBox1.Left = 180
        End If


        If Label2.Text >= Label4.Text Then
            Label1.Visible = False
            PictureBox1.Visible = False
            Timer1.Enabled = False
            MessageBox.Show("Thanks for Playing")
        End If

        ' Buttoning up the game for completion, makes screen go blank and a message box appear
        'to end the game
    End Sub





End Class
