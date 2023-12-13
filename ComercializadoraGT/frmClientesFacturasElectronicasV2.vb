Imports PriceMarket.WSNavy
Imports System.Text.RegularExpressions

Public Class frmClientesFacturasElectronicasV2
    Dim CONZ As New SqlClient.SqlConnection
    Dim CADENA As String
    Dim LUSO As New List(Of String)
    Dim LRF As New List(Of String)

    Private Sub frmClientesFacturasElectronicasV2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        CADENA = frmPrincipal.CadenaConexionFE
        If TXTRFC.Text.Length = 13 Then
            OPLlenaComboBox(CBUSO, LUSO, "SELECT CLAVE,NOMBRE FROM CSATUSOCOMPROBANTE WHERE ACTIVO=1 AND FISICA=1 ORDER BY NOMBRE", CADENA, "Favor de Seleccionar", "")
            OPLlenaComboBox(CBRF, LRF, "SELECT CLAVE,CLAVE+' - '+NOMBRE FROM CSATREGIMENFISCAL WHERE ACTIVO=1 AND FISICA=1", CADENA, "Favor de seleccionar", "")
        Else
            OPLlenaComboBox(CBUSO, LUSO, "SELECT CLAVE,NOMBRE FROM CSATUSOCOMPROBANTE WHERE ACTIVO=1 AND MORAL=1 ORDER BY NOMBRE", CADENA, "Favor de Seleccionar", "")
            OPLlenaComboBox(CBRF, LRF, "SELECT CLAVE,CLAVE+' - '+NOMBRE FROM CSATREGIMENFISCAL WHERE ACTIVO=1 AND MORAL=1", CADENA, "Favor de seleccionar", "")
        End If
        CONZ.ConnectionString = CADENA
        CHECACONZ()
        LIMPIAR()
        ACTIVAR(True)
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTRFC.Enabled = V
        TXTNOM.Enabled = Not V
        TXTNCOM.Enabled = Not V
        CHKACT.Enabled = Not V
        TXTM1.Enabled = Not V
        TXTM5.Enabled = Not V
        TXTM2.Enabled = Not V
        TXTM3.Enabled = Not V
        TXTM4.Enabled = Not V
        CBUSO.Enabled = Not V
        BTNGUARDAR.Enabled = Not V
        CBRF.Enabled = Not V
        TXTCP.Enabled = Not V
        If V Then
            TXTRFC.Focus()
            TXTRFC.SelectAll()
        Else
            TXTNOM.Focus()
            TXTNOM.SelectAll()
        End If
    End Sub
    Private Function CHECACONZ() As Boolean
        If Me.CONZ.State = ConnectionState.Closed Or Me.CONZ.State = ConnectionState.Broken Then
            Try
                Me.CONZ.Open()
            Catch ex As Exception
                MessageBox.Show("La Conexión NO esta realizada, La Informacion No se ha Procesado, Intente en un momento por Favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End Try
        End If
        Return True
    End Function
    Dim VWS As Boolean
    Private Function VALIDADATOS() As Boolean
        VWS = True
        If TXTRFC.Text.ToUpper = "XAXX010101000" Then
            MessageBox.Show("La Información de Publico General no puede ser Modificada", "Aviso", MessageBoxButtons.OK)
            Return False
        End If
        If String.IsNullOrEmpty(TXTNOM.Text) Then
            MessageBox.Show("Debe especificar un Nombre de Cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TXTNOM.Focus()
            Return False
        End If
        Dim CP As Integer
        Try
            CP = CType(TXTCP.Text, Integer)
        Catch ex As Exception
            OPMsgError("Favor de escribir un codigo postal valido")
            Return False
        End Try
        If TXTCP.TextLength <> 5 Then
            OPMsgError("Favor de escribir un codigo postal valido")
            Return False
        End If
        If CBRF.SelectedIndex = 0 Then
            OPMsgError("Favor de seleccionar un regimen fiscal del cliente")
            Return False
        End If
        'Dim WSVER As New TimbrarXML()
        'Dim RESP As WSNavy.RespuestaActivarCliente
        'RESP = WSVER.ValidarRFC(My.Settings.USUWS, My.Settings.PWDWS, TXTRFC.Text.ToUpper)
        'If RESP.Codigo = "00" Then
        '    If RESP.Mensaje = "success. . " Then
        '    Else
        '        MessageBox.Show(RESP.Mensaje, "Resultado Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '        VWS = True
        '    End If
        'End If
        Return True
    End Function
    Private Sub GUARDARDIRECCION()
        If Not CHECACONZ() Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SPDOMICILIOSCLIENTES", CONZ)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.CommandTimeout = 300
        SQL.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TXTRFC.Text.ToUpper
        SQL.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = "CONOCIDA"
        SQL.Parameters.Add("@COL", SqlDbType.VarChar).Value = ""
        SQL.Parameters.Add("@LOC", SqlDbType.VarChar).Value = ""
        SQL.Parameters.Add("@MUN", SqlDbType.VarChar).Value = ""
        SQL.Parameters.Add("@CP", SqlDbType.VarChar).Value = TXTCP.Text
        SQL.Parameters.Add("@NOEXT", SqlDbType.VarChar).Value = ""
        SQL.Parameters.Add("@NOINT", SqlDbType.VarChar).Value = ""
        SQL.Parameters.Add("@TEL", SqlDbType.VarChar).Value = ""
        SQL.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = ""
        SQL.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = ""
        SQL.Parameters.Add("@WEB", SqlDbType.VarChar).Value = ""
        SQL.Parameters.Add("@REF", SqlDbType.VarChar).Value = ""
        SQL.Parameters.Add("@EDO", SqlDbType.VarChar).Value = ""
        SQL.Parameters.Add("@REG", SqlDbType.Int).Value = 99
        SQL.ExecuteNonQuery()
    End Sub
    Private Sub GUARDACORREOS()
        If Not CHECACONZ() Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SPCORREOSCLIENTES", CONZ)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.CommandTimeout = 300
        SQL.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TXTRFC.Text.ToUpper
        SQL.Parameters.Add("@C1", SqlDbType.VarChar).Value = TXTM1.Text
        SQL.Parameters.Add("@C2", SqlDbType.VarChar).Value = TXTM2.Text
        SQL.Parameters.Add("@C3", SqlDbType.VarChar).Value = TXTM3.Text
        SQL.Parameters.Add("@C4", SqlDbType.VarChar).Value = TXTM4.Text
        SQL.Parameters.Add("@C5", SqlDbType.VarChar).Value = TXTM5.Text
        SQL.Parameters.Add("@REG", SqlDbType.Int).Value = 99
        SQL.ExecuteNonQuery()
        LIMPIAR()

    End Sub
    Private Sub CARGARINICIO()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        ACTIVAR(False)
        If TXTRFC.Text.Length = 13 Then
            OPLlenaComboBox(CBUSO, LUSO, "SELECT CLAVE,NOMBRE FROM CSATUSOCOMPROBANTE WHERE ACTIVO=1 AND FISICA=1 ORDER BY NOMBRE", CADENA, "Favor de Seleccionar", "")
            OPLlenaComboBox(CBRF, LRF, "SELECT CLAVE,CLAVE+' - '+NOMBRE FROM CSATREGIMENFISCAL WHERE ACTIVO=1 AND FISICA=1", CADENA, "Favor de seleccionar", "")
        Else
            OPLlenaComboBox(CBUSO, LUSO, "SELECT CLAVE,NOMBRE FROM CSATUSOCOMPROBANTE WHERE ACTIVO=1 AND MORAL=1 ORDER BY NOMBRE", CADENA, "Favor de Seleccionar", "")
            OPLlenaComboBox(CBRF, LRF, "SELECT CLAVE,CLAVE+' - '+NOMBRE FROM CSATREGIMENFISCAL WHERE ACTIVO=1 AND MORAL=1", CADENA, "Favor de seleccionar", "")
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT NOMBRE,NOMBRECOMERCIAL,ACTIVO,USO,REGIMENFISCAL FROM CLIENTES WHERE RFC='" + TXTRFC.Text.ToUpper + "'", CONZ)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            TXTNOM.Text = LEC(0)
            TXTNCOM.Text = LEC(1)
            CHKACT.Checked = CType(LEC(2), Boolean)
            OPCargaX(LUSO, CBUSO, LEC(3))
            OPCargaX(LRF, CBRF, LEC(4))
        End If
        LEC.Close()
        CARGACORREOS()
        TXTCP.Text = BDExtraeUnDato("SELECT CP FROM DOMICILIOSCLIENTES WHERE RFC='" + TXTRFC.Text + "' AND REGISTRO=99", CADENA)
    End Sub
    Private Sub CARGACORREOS()
        If Not CHECACONZ() Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("select CORREO1,CORREO2,CORREO3,CORREO4,CORREO5 from CORREOSCLIENTES WHERE RFC=@RFC AND REGISTRO=99", CONZ)
        SQL.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TXTRFC.Text.ToUpper
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            TXTM1.Text = LEC(0)
            TXTM2.Text = LEC(1)
            TXTM3.Text = LEC(2)
            TXTM4.Text = LEC(3)
            TXTM5.Text = LEC(4)
        End If
        LEC.Close()
        SQL.Dispose()
    End Sub
    Private Sub LIMPIAR()
        TXTRFC.Text = ""
        TXTNOM.Text = ""
        TXTNCOM.Text = ""
        TXTM1.Text = ""
        TXTM2.Text = ""
        TXTM3.Text = ""
        TXTM4.Text = ""
        TXTM5.Text = ""
    End Sub
    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        LIMPIAR()
        ACTIVAR(True)
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT RFC,NOMBRE,NOMBRECOMERCIAL [NOMBRE COMERCIAL] FROM VCLIENTES ", " WHERE COMPUESTO", " ORDER BY NOMBRE", "Búsqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 2, CADENA, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTRFC.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToUpper
            CARGARINICIO()
        End If
    End Sub

    Private Sub TXTNOM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOM.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub



    Private Sub TXTRFC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRFC.KeyPress
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(TXTRFC.Text) Then
            Else
                'CARGARINICIO()
                If TXTRFC.Text.Length < 12 Then
                    MessageBox.Show("RFC Incompleto, faltan Caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                End If
                If TXTRFC.Text.Length = 13 Then
                    If Regex.IsMatch(Me.TXTRFC.Text.ToUpper, "^([A-Z,&,ñ,Ñ\s]{4})\d{6}([A-Z\w]{3})$") Then
                        CARGARINICIO()
                    Else
                        MessageBox.Show("Teclee un RFC valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                If TXTRFC.Text.Length = 12 Then
                    If Regex.IsMatch(Me.TXTRFC.Text.ToUpper, "^([A-Z,&,ñ,Ñ\s]{3})\d{6}([A-Z\w]{3})$") Then
                        CARGARINICIO()
                    Else
                        MessageBox.Show("Teclee un RFC valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Private Function ValidaCorreos() As Boolean
        Dim MV As Boolean
        MV = True
        If Not ValidaEmail(TXTM1.Text) Then
            TXTM1.SelectAll()
            TXTM1.Focus()
            MV = False
        End If
        If Not ValidaEmail(TXTM2.Text) Then
            TXTM2.SelectAll()
            TXTM2.Focus()
            MV = False
        End If
        If Not ValidaEmail(TXTM3.Text) Then
            TXTM3.SelectAll()
            TXTM3.Focus()
            MV = False
        End If
        If Not ValidaEmail(TXTM4.Text) Then
            TXTM4.SelectAll()
            TXTM4.Focus()
            MV = False
        End If
        If Not ValidaEmail(TXTM5.Text) Then
            TXTM5.SelectAll()
            TXTM5.Focus()
            MV = False
        End If

        Return MV
    End Function
    Private Sub BTNGUARDAR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        If CBUSO.SelectedIndex = 0 Then
            MessageBox.Show("Favor de seleccionar un uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Not VALIDADATOS() Then
            Exit Sub
        End If
        If Not ValidaCorreos() Then
            MessageBox.Show("Favor de revisar el email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If String.IsNullOrEmpty(TXTNOM.Text) Then
            MessageBox.Show("Debe especificar un Nombre de Cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If Not VWS Then
            Dim xyz As Short
            xyz = MessageBox.Show("No se completo la validación del RFC, ¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz <> 6 Then
                Exit Sub
            End If
        End If
        If Not CHECACONZ() Then
            Exit Sub
        End If
        Try
            Dim SQL As New SqlClient.SqlCommand("SPCLIENTESV2", CONZ)
            SQL.CommandType = CommandType.StoredProcedure
            If CHKACT.Checked Then
                SQL.Parameters.Add("@ACT", SqlDbType.Bit).Value = 1
            Else
                SQL.Parameters.Add("@ACT", SqlDbType.Bit).Value = 0
            End If
            SQL.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TXTRFC.Text.ToUpper
            SQL.Parameters.Add("@NOM", SqlDbType.VarChar).Value = TXTNOM.Text
            SQL.Parameters.Add("@NOMC", SqlDbType.VarChar).Value = TXTNCOM.Text
            SQL.Parameters.Add("@USO", SqlDbType.VarChar).Value = LUSO(CBUSO.SelectedIndex)
            SQL.Parameters.Add("@RF", SqlDbType.VarChar).Value = LRF(CBRF.SelectedIndex)

            SQL.ExecuteNonQuery()
            GUARDARDIRECCION()
            GUARDACORREOS()
            MessageBox.Show("La información ha sido guardada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            LIMPIAR()
            ACTIVAR(True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBRF_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBRF.SelectedIndexChanged
        CARGAUSOCOMPROBANTE(LRF(CBRF.SelectedIndex))
    End Sub
    Private Sub CARGAUSOCOMPROBANTE(ByVal REGIMEN As String)
        Try
            OPLlenaComboBox(CBUSO, LUSO, "SELECT D.CLAVE,D.NOMBRE FROM CSATREGIMENUSO N INNER JOIN CSATUSOCOMPROBANTE D ON N.USO=D.CLAVE WHERE D.ACTIVO=1 AND N.REGIMEN='" + REGIMEN + "' ORDER BY NOMBRE", frmPrincipal.CadenaConexionFE, "Favor de Seleccionar", "")
        Catch ex As Exception

        End Try
    End Sub
End Class

