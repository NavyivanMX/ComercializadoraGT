Public Class frmClientes
    Dim CADENA As String
    Private Sub frmClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CADENA = frmPrincipal.CadenaConexionFE
        CBACT.SelectedIndex = 0
        ACTIVAR(True)
        TXTCLA.Text = CARGACLI()
        CBDC.SelectedIndex = 0
    End Sub
    Private Function CARGACLI() As Integer
        Try
            frmPrincipal.CHECACONX()
            Dim NUM As Integer
            NUM = 1
            Dim SQLMOV As New SqlClient.SqlCommand("SELECT DBO.SIGCLIENTE('" + frmPrincipal.SucursalBase + "')", frmPrincipal.CONX)
            Dim LECTOR As SqlClient.SqlDataReader
            LECTOR = SQLMOV.ExecuteReader
            If LECTOR.Read Then
                NUM = LECTOR(0)
                LECTOR.Close()
                Return NUM
            Else
                LECTOR.Close()
                Return NUM
            End If
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTCLA.Enabled = V
        TXTRFC.Enabled = Not V
        TXTNOM.Enabled = Not V
        TXTDIR.Enabled = Not V
        TXTTEL.Enabled = Not V
        TXTCEL.Enabled = Not V
        TXTMAIL.Enabled = Not V
        TXTCRED.Enabled = Not V
        CBCALLE.Enabled = Not V
        CBFA.Enabled = Not V
        CBDC.Enabled = Not V
        CBACT.Enabled = Not V
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
        TXTDIR.Text = ""
        TXTTEL.Text = ""
        TXTCEL.Text = ""
        TXTMAIL.Text = ""
        TXTRFC.Text = ""
        CBDC.SelectedIndex = 0
        CBCALLE.Items.Clear()
        CBACT.Text = ""
        TXTCLA.Text = CARGACLI()
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        ACTIVAR(False)
        Dim SQLSELECT As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE,DIRECCION,TELEFONO,CELULAR,MAIL,CREDITO,DIASCREDITO,ACTIVO,RFC,FAUTO,DCLIENTE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE=" + TXTCLA.Text, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            TXTNOM.Text = LECTOR(1).ToString
            TXTDIR.Text = LECTOR(2).ToString
            TXTTEL.Text = LECTOR(3).ToString
            TXTCEL.Text = LECTOR(4).ToString
            TXTMAIL.Text = LECTOR(5).ToString
            TXTCRED.Text = LECTOR(6).ToString          
            CBDC.Text = LECTOR(7).ToString
            If LECTOR(8) = 1 Then
                CBACT.SelectedIndex = 1
            Else
                CBACT.SelectedIndex = 0
            End If
            TXTRFC.Text = LECTOR(9).ToString
            If CType(LECTOR(10), Boolean) Then
                CBFA.SelectedIndex = 1
                CARGADOMICILIOSCLIENTE()
                OPCargaX(LDOM, CBCALLE, LECTOR(11))
            Else
                CBFA.SelectedIndex = 0
            End If
            BTNELIMINAR.Enabled = True
        End If
        LECTOR.Close()
    End Sub

    Private Sub TXTNOM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOM.KeyPress, TXTDIR.KeyPress, TXTTEL.KeyPress, TXTCEL.KeyPress, TXTMAIL.KeyPress, CBDC.KeyPress, CBACT.KeyPress, TXTCRED.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CANCELAR()
        LIMPIAR()
        ACTIVAR(True)
        TXTCLA.Text = CARGACLI()
    End Sub
    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        CANCELAR()
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
        If TXTNOM.Text = "" Or TXTDIR.Text = "" Or TXTTEL.Text = "" Or TXTCEL.Text = "" Or TXTMAIL.Text = "" Then
            MessageBox.Show("Falta ingresar infomación importante del cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If TXTCRED.Text <= 0 Then
            MessageBox.Show("El limite de credito del cliente debe ser mayor a 0", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTCRED.Focus()
            TXTCRED.SelectAll()
            Exit Sub
        End If
        If CBFA.SelectedIndex = 1 Then
            If CBCALLE.Items.Count <= 0 Then
                MessageBox.Show("No cuenta con Domicilios para afectar la Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
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
        SQLGUARDAR.CommandTimeout = 300
        SQLGUARDAR.CommandType = CommandType.StoredProcedure
        SQLGUARDAR.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQLGUARDAR.Parameters.Add("@CLA", SqlDbType.Int).Value = CType(TXTCLA.Text, Integer)
        SQLGUARDAR.Parameters.Add("@NOM", SqlDbType.VarChar, 100).Value = TXTNOM.Text
        SQLGUARDAR.Parameters.Add("@DIR", SqlDbType.VarChar, 200).Value = TXTDIR.Text
        SQLGUARDAR.Parameters.Add("@TEL", SqlDbType.VarChar, 200).Value = TXTTEL.Text
        SQLGUARDAR.Parameters.Add("@CEL", SqlDbType.VarChar, 200).Value = TXTCEL.Text
        SQLGUARDAR.Parameters.Add("@MAIL", SqlDbType.VarChar, 50).Value = TXTMAIL.Text
        SQLGUARDAR.Parameters.Add("@RFC", SqlDbType.VarChar, 50).Value = TXTRFC.Text
        SQLGUARDAR.Parameters.Add("@CRED", SqlDbType.Float).Value = TXTCRED.Text
        SQLGUARDAR.Parameters.Add("@DC", SqlDbType.Int).Value = CBDC.Text
        SQLGUARDAR.Parameters.Add("@ACT", SqlDbType.Bit)
        SQLGUARDAR.Parameters.Add("@FA", SqlDbType.Bit)

        If CBACT.SelectedIndex = 0 Then
            SQLGUARDAR.Parameters("@ACT").Value = 1
        Else
            SQLGUARDAR.Parameters("@ACT").Value = 0
        End If
        If CBFA.SelectedIndex = 1 Then
            SQLGUARDAR.Parameters("@FA").Value = 1
            If CBCALLE.Items.Count <= 0 Then
                SQLGUARDAR.Parameters.Add("@DOMC", SqlDbType.Int).Value = 0
            Else
                SQLGUARDAR.Parameters.Add("@DOMC", SqlDbType.Int).Value = LREG(CBCALLE.SelectedIndex)
            End If
        Else
            SQLGUARDAR.Parameters.Add("@DOMC", SqlDbType.Int).Value = 0
            SQLGUARDAR.Parameters("@FA").Value = 0
        End If
        frmPrincipal.CHECACONX()
        SQLGUARDAR.CommandText = "SPCLIENTE"
        SQLGUARDAR.ExecuteNonQuery()
        SQLGUARDAR.Dispose()
        MessageBox.Show("La información ha sido guardada correctamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        'xyz = MessageBox.Show("¿Desea ingresar datos de facturación de este cliente?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        'If xyz = 6 Then
        '    frmClientesRFC.TXTNOMFIS.Text = TXTNOM.Text
        '    frmClientesRFC.TXTDIR.Text = TXTDIR.Text
        '    frmClientesRFC.CARGADATOS2(TXTCLA.Text)
        'End If

        'If OPMsgPreguntarSiNo("¿Desea ingresar datos de facturación de este cliente?") Then
        '    frmClientesRFC.TXTNOMFIS.Text = TXTNOM.Text
        '    frmClientesRFC.TXTDIR.Text = TXTDIR.Text
        '    frmClientesRFC.CARGADATOS2(TXTCLA.Text)
        'End If
        ACTIVAR(True)
        LIMPIAR()
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub
    Private Sub ELIMINAR()
        Dim xyz As Short
        xyz = MessageBox.Show("¿Esta seguro que desea eliminar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If xyz = 6 Then
            Try
                If Not frmPrincipal.CHECACONX() Then
                    Exit Sub
                End If
                Dim SQLELIMINAR As New SqlClient.SqlCommand
                SQLELIMINAR.Connection = frmPrincipal.CONX
                SQLELIMINAR.CommandText = "DELETE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE=" + TXTCLA.Text
                SQLELIMINAR.ExecuteNonQuery()
                MessageBox.Show("La información ha sido eliminada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            LIMPIAR()
            ACTIVAR(True)
            TXTCLA.Text = CARGACLI()
        End If
    End Sub
    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        ELIMINAR()
    End Sub
    Private Sub BUSCAR()
        frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,ACTIVO FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "'", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de cientes ", "Nombre del cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCLA.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            CARGADATOS()
        End If
    End Sub
    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        BUSCAR()
    End Sub

    Private Sub frmClientes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Alt + Keys.G Then
            If TXTNOM.Enabled = False Then
                Exit Sub
            End If
            GUARDAR()
        End If

        If e.KeyCode = Keys.Alt + Keys.E Then
            If BTNELIMINAR.Enabled = False Then
                Exit Sub
            End If
            ELIMINAR()
        End If

        If e.KeyCode = Keys.Alt + Keys.C Then
            CANCELAR()
        End If

        If e.KeyCode = Keys.Alt + Keys.B Then
            BUSCAR()
        End If
    End Sub

    Private Sub TXTCRED_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCRED.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Dim LREG As New List(Of String)
    Dim LDOM As New List(Of String)
    Private Sub CARGADOMICILIOSCLIENTE()
        OPLlenaComboBox(CBCALLE, LREG, LDOM, "SELECT REGISTRO,DBO.DIRCLIENTE(RFC,REGISTRO),CALLE FROM DOMICILIOSCLIENTES WHERE RFC='" + TXTRFC.Text + "' AND ACTIVO=1", CADENA)
        If CBCALLE.Items.Count <= 0 Then
            MessageBox.Show("Este cliente no cuenta con direcciones para la Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub CBFA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBFA.SelectedIndexChanged
        CARGADOMICILIOSCLIENTE()
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        frmClsBusqueda.BUSCAR("SELECT RFC,NOMBRE,NOMBRECOMERCIAL [NOMBRE COMERCIAL] FROM CLIENTES ", " WHERE NOMBRECOMERCIAL", " ORDER BY NOMBRE", "Búsqueda de Clientes", "Nombre Comercial del Cliente", "Cliente(s)", 1, CADENA, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTRFC.Text = frmClsBusqueda.TREG.Rows(0).Item(0)
            LBLNFIS.Text = frmClsBusqueda.TREG.Rows(0).Item(1)
            CARGADOMICILIOSCLIENTE()
        End If
    End Sub
End Class