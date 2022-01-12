Imports System.Data.SqlClient

Public Class Conexion

    Public conn As SqlConnection

    Public Sub New()
        Me.conn = New SqlConnection("Data Source=JORGELAPTOPASUS;Initial Catalog=dbsistema;User ID=sa;Password=Password123")
    End Sub

End Class
