Imports System.Data.SqlClient

Public Class Conexion

    Public conn As SqlConnection

    Public Sub New()
        Me.conn = New SqlConnection("Data Source=DESKTOP-GFAMC7N;Initial Catalog=dbsistema;User ID=sa;Password=Password123")
    End Sub

End Class
