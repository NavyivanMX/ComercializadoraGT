Public Class frmChoferesCartaPorte
    Dim LTF As New List(Of String)
    Private Sub frmChoferesCartaPorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        OPLlenaComboBox(CBTF, LTF, "SELECT CLAVE,CLAVE +' - '+NOMBRE FROM CSATTIPOSFIGURA WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion, "Favor de Seleccionar", "")
        CBACT.SelectedIndex = 1
        ACTIVAR(True)
        INICIALIZARTTT()
        CARGASIGEMP()
    End Sub
    Private Sub INICIALIZARTTT()
        TTT.SetToolTip(BTNGUARDAR, "Guardar")
        TTT.SetToolTip(BTNCANCELAR, "Cancelar")
        TTT.SetToolTip(BTNELIMINAR, "Eliminar")
    End Sub
    Private Sub CARGASIGEMP()
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim QUERY As String
        Try
            QUERY = "SELECT MAX(CLAVE) FROM CHOFERESCARTAPORTE"
            Dim SQLSELECT As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
            Dim LECTOR As SqlClient.SqlDataReader
            LECTOR = SQLSELECT.ExecuteReader
            If LECTOR.Read Then
                If LECTOR(0) Is DBNull.Value Then
                    TXTCLA.Text = "1"
                Else
                    TXTCLA.Text = LECTOR(0) + 1
                End If
            End If
            LECTOR.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTCLA.Enabled = V
        TXTNOM.Enabled = Not V
        TXTLIC.Enabled = Not V
        TXTNRI.Enabled = Not V
        TXTPAIS.Enabled = Not V
        CBACT.Enabled = Not V
        CBTF.Enabled = Not V
        TXTRFC.Enabled = Not V
        BTNGUARDAR.Enabled = Not V
        BTNELIMINAR.Enabled = False
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
        TXTLIC.Text = ""
        TXTNRI.Text = ""
        TXTPAIS.Text = ""
        TXTRFC.Text = ""
        CBACT.Text = ""
        CBTF.SelectedIndex = 0
        CARGASIGEMP()
    End Sub

    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        ACTIVAR(False)
        Dim SQLSELECT As New SqlClient.SqlCommand("SELECT TIPOFIGURA,RFC,NUMLICENCIA,NOMBRE,REGIDTRIB,RESFIS,ACTIVO FROM CHOFERESCARTAPORTE WHERE CLAVE=" + TXTCLA.Text, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            OPCargaX(LTF, CBTF, LECTOR(0).ToString)
            TXTRFC.Text = LECTOR(1).ToString
            TXTLIC.Text = LECTOR(2).ToString
            TXTNOM.Text = LECTOR(3).ToString
            TXTNRI.Text = LECTOR(4)

            If CType(LECTOR(6), Boolean) Then
                CBACT.SelectedIndex = 1
            Else
                CBACT.SelectedIndex = 0
            End If


            BTNELIMINAR.Enabled = True
        End If
        LECTOR.Close()
    End Sub
    Private Sub TXTNOM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        LIMPIAR()
        ACTIVAR(True)
        CARGASIGEMP()
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
    Private Sub GUARDAR()
        If CBTF.SelectedIndex = 0 Then
            OPMsgError("Favor de seleccionar el tipo figura")
            Exit Sub
        End If
        If TXTNOM.Text = "" Or TXTRFC.Text = "" Or TXTLIC.Text = "" Then
            MessageBox.Show("Falta ingresar infomacin importante del emplead@", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If TXTRFC.Text.Length < 12 Or TXTRFC.Text.Length > 14 Then
            OPMsgError("RFC Incorrecto")
            Exit Sub
        End If
        If Not EsRFCValido(TXTRFC.Text) Then
            OPMsgError("RFC Incorrecto")
            Exit Sub
        End If
        If TXTLIC.Text.Length < 6 Or TXTLIC.Text.Length > 16 Then
            OPMsgError("Licencia Incorrecto 6-16")
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("Desea Guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim SQLGUARDAR As New SqlClient.SqlCommand
        SQLGUARDAR.Connection = frmPrincipal.CONX
        SQLGUARDAR.CommandType = CommandType.StoredProcedure
        SQLGUARDAR.Parameters.Add("@CLA", SqlDbType.Int).Value = CType(TXTCLA.Text, Integer)
        SQLGUARDAR.Parameters.Add("@TF", SqlDbType.VarChar).Value = LTF(CBTF.SelectedIndex)
        SQLGUARDAR.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TXTRFC.Text
        SQLGUARDAR.Parameters.Add("@NL", SqlDbType.VarChar).Value = TXTLIC.Text
        SQLGUARDAR.Parameters.Add("@NOM", SqlDbType.VarChar).Value = TXTNOM.Text
        SQLGUARDAR.Parameters.Add("@REGID", SqlDbType.VarChar).Value = TXTNRI.Text
        SQLGUARDAR.Parameters.Add("@RESFIS", SqlDbType.VarChar).Value = "MEX"
        SQLGUARDAR.Parameters.Add("@ACT", SqlDbType.Bit).Value = CBACT.SelectedIndex
        frmPrincipal.CHECACONX()
        SQLGUARDAR.CommandText = "SPCHOFERESCARTAPORTE"
        SQLGUARDAR.ExecuteNonQuery()
        MessageBox.Show("La información ha sido Guardada correctamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ACTIVAR(True)
        LIMPIAR()
    End Sub
    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click

        GUARDAR()
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        'Dim xyz As Short
        'xyz = MessageBox.Show("Esta seguro que desea eliminar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        'If xyz = 6 Then
        '    Try
        '        If Not frmPrincipal.CHECACONX() Then
        '            Exit Sub
        '        End If
        '        Dim SQLELIMINAR As New SqlClient.SqlCommand
        '        SQLELIMINAR.Connection = frmPrincipal.CONX
        '        SQLELIMINAR.CommandText = "DELETE FROM EMPLEADOS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE=" + TXTCLA.Text
        '        SQLELIMINAR.ExecuteNonQuery()
        '        MessageBox.Show("La información ha sido eliminada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '    End Try
        '    LIMPIAR()
        '    ACTIVAR(True)
        '    CARGASIGEMP()
        'End If
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,RFC,NUMLICENCIA,ACTIVO FROM CHOFERESCARTAPORTE ", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Choferes", "Nombre del Chofer", "Registro(s)", 1, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCLA.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            CARGADATOS()
        End If
    End Sub


    Private Sub frmEmpleados_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Alt + Keys.G Then
            GUARDAR()
        End If


        If e.KeyCode = Keys.Alt + Keys.C Then
            LIMPIAR()
            ACTIVAR(True)
            CARGASIGEMP()
        End If


        If e.KeyCode = Keys.Alt + Keys.B Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,RFC,NUMLICENCIA,ACTIVO FROM CHOFERESCARTAPORTE ", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Choferes", "Nombre del Chofer", "Registro(s)", 1, frmPrincipal.CadenaConexion, True)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                TXTCLA.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
                CARGADATOS()
            End If
        End If

    End Sub

    Private Sub TXTNOM_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOM.KeyPress, TXTLIC.KeyPress, TXTNRI.KeyPress, TXTPAIS.KeyPress, CBTF.KeyPress, CBACT.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class