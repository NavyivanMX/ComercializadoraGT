Public Class frmVehiculosCartaPorte
    Dim LPER As New List(Of String)
    Dim LCON As New List(Of String)
    Private Sub frmVehiculosCartaPorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        CBACT.SelectedIndex = 0
        ACTIVAR(True)
        INICIALIZARTTT()
        CARGASIGEMP()
        OPLlenaComboBox(CBPER, LPER, "SELECT CLAVE,CLAVE +' - '+NOMBRE FROM CSATPERMISOSSCT ORDER BY NOMBRE", frmPrincipal.CadenaConexion, "Favor de seleccionar", "")
        OPLlenaComboBox(CBCON, LCON, "SELECT CLAVE,CLAVE +' - '+DESCRIPCION FROM CSATAUTOTRANSPORTES ORDER BY DESCRIPCION", frmPrincipal.CadenaConexion, "Favor de seleccionar", "")

        OPCargaX(LPER, CBPER, "TPXX00")
        LIMPIAR()
    End Sub
    Private Sub INICIALIZARNUD()
        Dim ANIO As Integer
        ANIO = Now.Year
        NUDMOD.Minimum = ANIO - 100
        NUDMOD.Maximum = ANIO + 1
        NUDMOD.Value = ANIO
    End Sub
    Private Sub INICIALIZARTTT()
        TTT.SetToolTip(BTNGUARDAR, "Guardar")
        TTT.SetToolTip(BTNCANCELAR, "Cancelar")
        TTT.SetToolTip(BTNELIMINAR, "Eliminar")
        TTT.SetToolTip(BTNBUSCAR, "Buscar")
    End Sub
    Private Sub CARGASIGEMP()
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim QUERY As String
        Try
            QUERY = "SELECT MAX(CLAVE) FROM VEHICULOSCARTAPORTE"
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
        TXTNUMPER.Enabled = Not V
        TXTPLACAS.Enabled = Not V
        CBCON.Enabled = Not V
        CBPER.Enabled = Not V
        NUDMOD.Enabled = Not V
        CBACT.Enabled = Not V

        TXTASE.Enabled = Not V
        TXTPOL.Enabled = Not V
        TXTASEMA.Enabled = Not V
        TXTPOLMA.Enabled = Not V
        BTNGUARDAR.Enabled = Not V
        BTNBUSPER.Enabled = Not V
        BTNBUSCON.Enabled = Not V
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
        TXTPLACAS.Text = ""
        TXTNUMPER.Text = ""

        TXTASE.Text = ""
        TXTASEMA.Text = ""
        TXTPOL.Text = ""
        TXTPOLMA.Text = ""
        INICIALIZARNUD()
        CBACT.SelectedIndex = 1
        CARGASIGEMP()
    End Sub

    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        ACTIVAR(False)
        Dim SQLSELECT As New SqlClient.SqlCommand("SELECT CLAVE, NOMBRE,PermSCT,NumPermisoSCT,ConfgVehicular,PlacasVM,AnioModeloVM,ACTIVO,ASEGURADORA,POLIZASEGURO,ASEGURADORAMA,POLIZAMA FROM VEHICULOSCARTAPORTE WHERE CLAVE=" + TXTCLA.Text, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            TXTNOM.Text = LECTOR(1).ToString
            OPCargaX(LPER, CBPER, LECTOR(2).ToString)
            TXTNUMPER.Text = LECTOR(3).ToString
            OPCargaX(LCON, CBCON, LECTOR(4).ToString)
            TXTPLACAS.Text = LECTOR(5).ToString
            NUDMOD.Value = CType(LECTOR(6), Integer)
            If CType(LECTOR(7), Boolean) Then
                CBACT.SelectedIndex = 1
            Else
                CBACT.SelectedIndex = 0
            End If
            TXTASE.Text = LECTOR(8).ToString
            TXTPOL.Text = LECTOR(9).ToString
            TXTASEMA.Text = LECTOR(10).ToString
            TXTPOLMA.Text = LECTOR(11).ToString
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
        If CadenaVacia(TXTNOM.Text) Or CadenaVacia(TXTNUMPER.Text) Or CadenaVacia(TXTPLACAS.Text) Then
            MessageBox.Show("Falta ingresar infomación importante del Vehículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If CBPER.SelectedIndex = 0 Or CBCON.SelectedIndex = 0 Then
            OPMsgError("Favor de seleccionar las opciones")
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
        SQLGUARDAR.Parameters.Add("@NOM", SqlDbType.VarChar, 200).Value = TXTNOM.Text
        SQLGUARDAR.Parameters.Add("@PERMSCT", SqlDbType.VarChar, 200).Value = LPER(CBPER.SelectedIndex)
        SQLGUARDAR.Parameters.Add("@NUMPERM", SqlDbType.VarChar, 200).Value = TXTNUMPER.Text
        SQLGUARDAR.Parameters.Add("@CONFVE", SqlDbType.VarChar, 200).Value = LCON(CBCON.SelectedIndex)
        SQLGUARDAR.Parameters.Add("@PLACAS", SqlDbType.VarChar, 50).Value = TXTPLACAS.Text
        SQLGUARDAR.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = NUDMOD.Value.ToString
        SQLGUARDAR.Parameters.Add("@ACT", SqlDbType.Bit).Value = CBACT.SelectedIndex
        SQLGUARDAR.Parameters.Add("@ASE", SqlDbType.VarChar).Value = TXTASE.Text
        SQLGUARDAR.Parameters.Add("@ASEMA", SqlDbType.VarChar).Value = TXTASEMA.Text
        SQLGUARDAR.Parameters.Add("@POL", SqlDbType.VarChar).Value = TXTPOL.Text
        SQLGUARDAR.Parameters.Add("@POLMA", SqlDbType.VarChar).Value = TXTPOLMA.Text

        SQLGUARDAR.CommandText = "SPVEHICULOSCARTAPORTE"
        SQLGUARDAR.ExecuteNonQuery()
        OPMsgGuardadoOK()
        ACTIVAR(True)
        LIMPIAR()
    End Sub
    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("Esta seguro que desea eliminar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If xyz = 6 Then
            Try
                If Not frmPrincipal.CHECACONX() Then
                    Exit Sub
                End If
                Dim SQLELIMINAR As New SqlClient.SqlCommand
                SQLELIMINAR.Connection = frmPrincipal.CONX
                SQLELIMINAR.CommandText = "DELETE FROM SPVEHICULOSCARTAPORTE WHERE CLAVE=" + TXTCLA.Text
                SQLELIMINAR.ExecuteNonQuery()
                MessageBox.Show("La información ha sido eliminada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            LIMPIAR()
            ACTIVAR(True)
            CARGASIGEMP()
        End If
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,ACTIVO FROM VEHICULOSCARTAPORTE ", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Vehículos", "Nombre del Vechículo", "Registro(s)", 1, frmPrincipal.CadenaConexion, True)
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
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,ACTIVO FROM VEHICULOSCARTAPORTE WHERE NOMBRE", "", " ORDER BY NOMBRE", "Búsqueda de Vehículos", "Nombre del Vechículo", "Registro(s)", 1, frmPrincipal.CadenaConexion, True)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                TXTCLA.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
                CARGADATOS()
            End If
        End If

    End Sub

    Private Sub TXTNOM_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOM.KeyPress, CBPER.KeyPress, CBCON.KeyPress, TXTNUMPER.KeyPress, TXTPLACAS.KeyPress, NUDMOD.KeyPress, CBACT.KeyPress, TXTASE.KeyPress, TXTPOL.KeyPress, TXTASEMA.KeyPress, TXTPOLMA.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BTNBUSPER_Click(sender As Object, e As EventArgs) Handles BTNBUSPER.Click
        frmClsBusqueda.BUSCAR("SELECT * FROM CSATPERMISOSSCT ", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Permisos SCT", "Nombre del Permiso", "Registro(s)", 1, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            OPCargaX(LPER, CBPER, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
        End If
    End Sub

    Private Sub BTNBUSCON_Click(sender As Object, e As EventArgs) Handles BTNBUSCON.Click
        frmClsBusqueda.BUSCAR("SELECT * FROM CSATAUTOTRANSPORTES ", " WHERE DESCRIPCION", " ORDER BY DESCRIPCION", "Búsqueda de AutoTransportes", "Nombre del AutoTransporte", "Registro(s)", 1, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            OPCargaX(LCON, CBCON, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
        End If

    End Sub

    Private Sub CBPER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBPER.SelectedIndexChanged
        TXTNUMPER.Enabled = True
        If LPER(CBPER.SelectedIndex) = "TPXX00" Then
            TXTNUMPER.Text = "Permiso no contemplado en el catálogo”
            TXTNUMPER.Enabled = False
        End If
    End Sub

    Private Sub BTNINFO_Click(sender As Object, e As EventArgs) Handles BTNINFO.Click
        frmInfo.Mostrar("Información Vehículos Carta Porte", "", "- Todos los campos son requeridos, excepto aseguradoras y pólizas")
    End Sub
End Class