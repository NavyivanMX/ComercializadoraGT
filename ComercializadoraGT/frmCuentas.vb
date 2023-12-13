Public Class frmCuentas

    Private Sub frmCuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGASIGCUENTA()
        CBACT.SelectedIndex = 0
        ACTIVAR(True)
    End Sub
    Private Sub CARGASIGCUENTA()
        ' Try
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim NUM As Integer
        NUM = 1
        Dim SQLMOV As New SqlClient.SqlCommand("SELECT DBO.SIGUIENTECUENTA()", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLMOV.ExecuteReader
        If LECTOR.Read Then
            NUM = LECTOR(0)
            LECTOR.Close()
            TXTCLA.Text = NUM
        Else
            LECTOR.Close()
        End If
        'Catch ex As Exception
        '    Me.Close()
        'End Try
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTCLA.Enabled = V
        TXTNOM.Enabled = Not V
        CBACT.Enabled = Not V
        BTNGUARDAR.Enabled = Not V

        If V Then
            TXTCLA.SelectAll()
            TXTCLA.Focus()
        Else
            TXTNOM.SelectAll()
            TXTNOM.Focus()
        End If
    End Sub
    Private Sub LIMPIAR()
        TXTNOM.Text = ""
        CBACT.SelectedIndex = 0
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        ACTIVAR(False)
        Dim SQLSELECT As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE,ACTIVO FROM CUENTAS WHERE CLAVE=" + TXTCLA.Text + "", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            TXTNOM.Text = LECTOR(1).ToString
            If LECTOR(2) = 1 Then
                CBACT.SelectedIndex = 1
            Else
                CBACT.SelectedIndex = 0
            End If

        End If
        LECTOR.Close()
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        If TXTNOM.Text = "" Then
            MessageBox.Show("Falta ingresar datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If

        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim SQLGUARDAR As New SqlClient.SqlCommand
        SQLGUARDAR.Connection = frmPrincipal.CONX
        SQLGUARDAR.CommandType = CommandType.StoredProcedure
        SQLGUARDAR.Parameters.Add("@TI", SqlDbType.VarChar, 10).Value = frmPrincipal.SucursalBase
        SQLGUARDAR.Parameters.Add("@CLA", SqlDbType.Int).Value = TXTCLA.Text
        SQLGUARDAR.Parameters.Add("@NOM", SqlDbType.VarChar, 50).Value = TXTNOM.Text
        SQLGUARDAR.Parameters.Add("@ACT", SqlDbType.Bit)

        If CBACT.SelectedIndex = 0 Then
            SQLGUARDAR.Parameters("@ACT").Value = 1
        Else
            SQLGUARDAR.Parameters("@ACT").Value = 0
        End If

        SQLGUARDAR.CommandText = "SPCUENTAS"
        SQLGUARDAR.ExecuteNonQuery()
        MessageBox.Show("La información ha sido guardada correctamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ACTIVAR(True)
        LIMPIAR()
        CARGASIGCUENTA()
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
        LIMPIAR()
        CARGASIGCUENTA()
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,ACTIVO FROM CUENTAS  ", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de cuentas", "Nombre de la cuenta", "Cuenta(s)", 1, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCLA.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            CARGADATOS()
        End If
    End Sub

    Private Sub TXTCLA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLA.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            CARGADATOS()
        End If
    End Sub

    Private Sub TXTNOM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOM.KeyPress, CBACT.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class