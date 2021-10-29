Public Class FrmCategoria

    Private Sub Formato()
        DgvListado.Columns(0).Visible = False
        DgvListado.Columns(0).Width = 100
        DgvListado.Columns(1).Width = 100
        DgvListado.Columns(2).Width = 150
        DgvListado.Columns(3).Width = 400
        DgvListado.Columns(4).Width = 100
    End Sub

    Private Sub Listar()
        Try
            Dim Neg As New Negocio.NCategoria
            DgvListado.DataSource = Neg.Listar()
            LblTotal.Text = "Total Registros: " & DgvListado.DataSource.Rows.Count
            Me.Formato()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Buscar()
        Try
            Dim Neg As New Negocio.NCategoria
            Dim Valor As String
            Valor = TxtValor.Text
            DgvListado.DataSource = Neg.Buscar(Valor)
            LblTotal.Text = "Total Registros: " & DgvListado.DataSource.Rows.Count
            Me.Formato()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Limpiar()
        BtnInsertar.Visible = True
        TxtValor.Text = ""
        TxtId.Text = ""
        TxtNombre.Text = ""
        TxtDescripcion.Text = ""
    End Sub

    Private Sub FrmCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Listar()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Me.Buscar()
    End Sub

    Private Sub BtnInsertar_Click(sender As Object, e As EventArgs) Handles BtnInsertar.Click
        If Me.ValidateChildren = True And TxtNombre.Text <> "" Then
            Dim Obj As New Entidades.Categoria
            Dim Neg As New Negocio.NCategoria

            Obj.Nombre = TxtNombre.Text
            Obj.Descripcion = TxtDescripcion.Text

            If (Neg.Insertar(Obj)) Then
                MsgBox("Se ha registrado correctamente", vbOKOnly + vbInformation, "Registro correcto")
                Me.Limpiar()
                Me.Listar()
            Else
                MsgBox("No se ha podido registrar", vbOKOnly + vbCritical, "Registro incorrecto")
            End If
        Else
            MsgBox("Rellene todos los campos obligatorios (*)", vbOKOnly + vbCritical, "Falta ingresar datos")
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Limpiar()
        TabGeneral.SelectedIndex = 0
    End Sub

    Private Sub TxtNombre_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtNombre.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorIcono.SetError(sender, "")
        Else
            Me.ErrorIcono.SetError(sender, "Ingrese el nombre de la categoría porfavor, este dato es obligatorio")
        End If
    End Sub
End Class
