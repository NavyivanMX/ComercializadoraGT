Public Class frmLocalidades
    Private Sub frmLocalidades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CBACT.SelectedIndex = 0
        LIMPIAR()
        ACTIVAR(True)
    End Sub
 
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTCLA.Enabled = V
        TXTMUE.Enabled = Not V
        TXTNIV.Enabled = Not V
        TXTPOS.Enabled = Not V
        TXTCAP.Enabled = Not V
        TXTTIE.Enabled = Not V
        CBACT.Enabled = Not V
        BTNGUARDAR.Enabled = Not V
        BTNELIMINAR.Enabled = False
        If V Then
            TXTCLA.SelectAll()
            TXTCLA.Focus()
        Else
            TXTMUE.SelectAll()
            TXTMUE.Focus()
        End If
    End Sub
    Private Sub LIMPIAR()
        TXTMUE.Text = ""
        TXTNIV.Text = ""
        TXTPOS.Text = ""
        TXTCAP.Text = "0"
        TXTTIE.Text = "0"
        CBACT.SelectedIndex = 0
    End Sub
    Private Function VALIDARDATOS() As Boolean
        If String.IsNullOrEmpty(TXTTIE.Text) Then
            Return True
        End If
        Return False
    End Function
    Private Sub CARGADATOS()
        frmPrincipal.CHECACONX()
        ACTIVAR(False)
        Dim SQLSELECT As New SqlClient.SqlCommand("SELECT CLAVE,MUEBLE,NIVEL,POSICION,ACTIVO FROM LOCALIDADES WHERE CLAVE=@CLA", frmPrincipal.CONX)
        SQLSELECT.Parameters.Add("@CLA", SqlDbType.VarChar, 5)
        SQLSELECT.Parameters("@CLA").Value = TXTCLA.Text
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            TXTMUE.Text = LECTOR(1).ToString
            TXTNIV.Text = LECTOR(2).ToString
            TXTPOS.Text = LECTOR(3).ToString
            'TXTCAP.Text = LECTOR(4).ToString
            'TXTTIE.Text = LECTOR(5).ToString
            If LECTOR(4) = 1 Then
                CBACT.SelectedIndex = 1
            Else
                CBACT.SelectedIndex = 0
            End If
            BTNELIMINAR.Enabled = True
        End If
        LECTOR.Close()
    End Sub
    Private Sub BTNGUARDAR_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.MouseEnter
        BTNGUARDAR.BackColor = System.Drawing.Color.Blue
        BTNGUARDAR.Text = "GUARDAR"
        BTNGUARDAR.ForeColor = System.Drawing.Color.Yellow
    End Sub

    Private Sub BTNGUARDAR_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.MouseLeave
        BTNGUARDAR.BackColor = System.Drawing.Color.Transparent
        BTNGUARDAR.Text = ""
        BTNGUARDAR.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub BTNELIMINAR_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.MouseEnter
        BTNELIMINAR.BackColor = System.Drawing.Color.Blue
        BTNELIMINAR.Text = "ELIMINAR"
        BTNELIMINAR.ForeColor = System.Drawing.Color.Yellow
    End Sub

    Private Sub BTNELIMINAR_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.MouseLeave
        BTNELIMINAR.BackColor = System.Drawing.Color.Transparent
        BTNELIMINAR.Text = ""
        BTNELIMINAR.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub BTNCANCELAR_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.MouseEnter
        BTNCANCELAR.BackColor = System.Drawing.Color.Blue
        BTNCANCELAR.Text = "CANCELAR"
        BTNCANCELAR.ForeColor = System.Drawing.Color.Yellow
    End Sub

    Private Sub BTNCANCELAR_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.MouseLeave
        BTNCANCELAR.BackColor = System.Drawing.Color.Transparent
        BTNCANCELAR.Text = ""
        BTNCANCELAR.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub TXTCLA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLA.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTCLA.Text = "" Then
            Else
                CARGADATOS()
            End If
        End If
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        If VALIDARDATOS() Then
            MessageBox.Show("Debe especificar un Tiempo vlido", "Aviso", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("Desea Guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        Dim SQLGUARDAR As New SqlClient.SqlCommand("SPLOCALIDADES", frmPrincipal.CONX)

        SQLGUARDAR.CommandType = CommandType.StoredProcedure
        SQLGUARDAR.Parameters.Add("@CLA", SqlDbType.VarChar, 10).Value = TXTCLA.Text
        SQLGUARDAR.Parameters.Add("@MUE", SqlDbType.Int).Value = TXTMUE.Text
        SQLGUARDAR.Parameters.Add("@NIV", SqlDbType.VarChar, 10).Value = TXTNIV.Text
        SQLGUARDAR.Parameters.Add("@POS", SqlDbType.Int).Value = TXTPOS.Text
        SQLGUARDAR.Parameters.Add("@ACT", SqlDbType.Bit)


        If CBACT.SelectedIndex = 0 Then
            SQLGUARDAR.Parameters("@ACT").Value = 1
        Else
            SQLGUARDAR.Parameters("@ACT").Value = 0
        End If
        SQLGUARDAR.ExecuteNonQuery()
        MessageBox.Show("La información ha sido Guardada correctamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ACTIVAR(True)
        LIMPIAR()
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        LIMPIAR()
        ACTIVAR(True)
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("Esta seguro que desea Eliminar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If xyz = 6 Then
            Try
                Dim SQLELIMINAR As New SqlClient.SqlCommand
                SQLELIMINAR.Connection = frmPrincipal.CONX
                SQLELIMINAR.CommandText = "DELETE FROM LOCALIDADES WHERE CLAVE =@CLA"
                SQLELIMINAR.Parameters.Add("@CLA", SqlDbType.VarChar, 5)
                SQLELIMINAR.Parameters("@CLA").Value = TXTCLA.Text
                SQLELIMINAR.ExecuteNonQuery()
                MessageBox.Show("La información ha sido Eliminada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                ex.Message.ToString()
            End Try
            LIMPIAR()
            ACTIVAR(True)
        End If
    End Sub

    Private Sub TXTMUE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMUE.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TXTNIV_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNIV.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TXTPOS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPOS.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TXTCAP_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCAP.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TXTTIE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTIE.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE, MUEBLE, NIVEL, POSICION, ACTIVO FROM LOCALIDADES", " WHERE CLAVE", " ORDER BY CLAVE", "Búsqueda de Localidades", "Clave de la Localidad", "Localidad(es)", 1, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCLA.Text = frmClsBusqueda.TREG.Rows(0).Item(0)
            CARGADATOS()
        End If
    End Sub

End Class