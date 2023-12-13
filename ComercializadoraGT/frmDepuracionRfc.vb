Imports System.Text
Imports System.Text.RegularExpressions
Public Class frmDepuracionRfc
    Dim CONZ As New SqlClient.SqlConnection
    Dim CADENA As String
    Dim LUSO As New List(Of String)
    Private Sub frmDepuracionRfc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)

        CADENA = frmPrincipal.CadenaConexionFE
        CONZ.ConnectionString = CADENA
        CHECACONZ()
        ACTIVAR(True)
    End Sub
    Private Sub LIMPIAR()
        TXTNOM.Text = ""
        TXTNCOM.Text = ""
        DGV.DataSource = Nothing
        DGV2.DataSource = Nothing
        DGV.Refresh()
        DGV2.Refresh()
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
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTRFC.Enabled = V
        TXTNCOM.Enabled = Not V
        TXTNOM.Enabled = Not V
        CHKACT.Enabled = Not V
        CBUSO.Enabled = Not V
        BTNGUARDAR.Enabled = Not V
    End Sub
    Private Sub CARGADATOS()
        If Not CHECACONZ() Then
            Exit Sub
        End If
        Dim ENC As Boolean
        ENC = False
        ACTIVAR(False)
        LIMPIAR()
        Dim USO As String
        USO = ""
        If TXTRFC.Text.Length = 13 Then
           OPLlenaComboBox(CBUSO, LUSO, "SELECT CLAVE,NOMBRE FROM CSATUSOCOMPROBANTE WHERE ACTIVO=1 AND FISICA=1 ORDER BY NOMBRE", CADENA, "Favor de Seleccionar", "")
        Else
           OPLlenaComboBox(CBUSO, LUSO, "SELECT CLAVE,NOMBRE FROM CSATUSOCOMPROBANTE WHERE ACTIVO=1 AND MORAL=1 ORDER BY NOMBRE", CADENA, "Favor de Seleccionar", "")
        End If

        Dim SQL As New SqlClient.SqlCommand("SELECT NOMBRE,NOMBRECOMERCIAL,VN,USO FROM CLIENTES WHERE RFC='" + TXTRFC.Text + "'", CONZ)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            ENC = True
            TXTNOM.Text = LEC(0)
            TXTNCOM.Text = LEC(1)
            USO = LEC(3)
        End If
        LEC.Close()
        SQL.Dispose()
        If Not ENC Then
            MessageBox.Show("RFC no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ACTIVAR(True)
            Exit Sub
        End If
        OPCargaX(LUSO, CBUSO, USO)
        CARGADOMICILIOS()

    End Sub
    Private Sub CARGADOMICILIOS()
        If Not CHECACONZ() Then
            Exit Sub
        End If
        DGV.DataSource = BDLlenatabla("SELECT RFC,CALLE,COLONIA,LOCALIDAD,MUNICIPIO,ESTADO,CP,NOEXT,NOINT,REGISTRO,ACTIVO FROM DOMICILIOSCLIENTES WHERE RFC='" + TXTRFC.Text + "'", CADENA)
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(9).ReadOnly = True
        CARGACORREOS()
    End Sub
    Private Sub CARGACORREOS()
        If Not CHECACONZ() Then
            Exit Sub
        End If
        DGV2.DataSource = BDLlenatabla("SELECT RFC,CORREO1,CORREO2,CORREO3,CORREO4,CORREO5,REGISTRO FROM CORREOSCLIENTES WHERE RFC='" + TXTRFC.Text + "'", CADENA)
        DGV2.Columns(0).ReadOnly = True
        DGV2.Columns(6).ReadOnly = True
    End Sub
    Private Sub GUARDAR()
        If CHKACT.Checked Then
            If CBUSO.SelectedIndex = 0 Then
                MessageBox.Show("Favor de seleccionar un uso del CFDI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        If Not VALIDACORREOS() Then
            MessageBox.Show("Favor de revisar el email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Not CHECACONZ() Then
            Exit Sub
        End If
        Try
            Dim SQL As New SqlClient.SqlCommand("UPDATE CLIENTES  SET NOMBRE=@NOM,NOMBRECOMERCIAL=@NC,ACTIVO=@ACT,USO=@USO WHERE RFC=@RFC", CONZ)
            If CHKACT.Checked Then
                SQL.Parameters.Add("@ACT", SqlDbType.Bit).Value = 1
            Else
                SQL.Parameters.Add("@ACT", SqlDbType.Bit).Value = 0
            End If
            SQL.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TXTRFC.Text
            SQL.Parameters.Add("@NOM", SqlDbType.VarChar).Value = TXTNOM.Text
            SQL.Parameters.Add("@NC", SqlDbType.VarChar).Value = TXTNCOM.Text
            SQL.Parameters.Add("@USO", SqlDbType.VarChar).Value = LUSO(CBUSO.SelectedIndex)
            SQL.ExecuteNonQuery()
            GUARDADOMICILIOS()
            GUARDACORREOS()
            ACTIVAR(True)
            LIMPIAR()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GUARDADOMICILIOS()
        If Not CHECACONZ() Then
            Exit Sub
        End If
        Dim X As Integer
        Dim SQL As New SqlClient.SqlCommand("UPDATE DOMICILIOSCLIENTES SET ACTIVO=@ACT WHERE RFC=@RFC AND REGISTRO=@REG", CONZ)
        SQL.Parameters.Add("@ACT", SqlDbType.Bit)
        SQL.Parameters.Add("@RFC", SqlDbType.VarChar)
        SQL.Parameters.Add("@REG", SqlDbType.Int)
        For X = 0 To DGV.RowCount - 1
            SQL.Parameters("@ACT").Value = DGV.Item(10, X).Value
            SQL.Parameters("@RFC").Value = DGV.Item(0, X).Value
            SQL.Parameters("@REG").Value = DGV.Item(9, X).Value
            SQL.ExecuteNonQuery()
        Next
    End Sub
    Private Sub GUARDACORREOS()
        If Not CHECACONZ() Then
            Exit Sub
        End If
        Dim X As Integer
        Dim SQL As New SqlClient.SqlCommand("UPDATE CORREOSCLIENTES SET CORREO1=@C1,CORREO2=@C2,CORREO3=@C3,CORREO4=@C4,CORREO5=@C5 WHERE RFC=@RFC AND REGISTRO=@REG", CONZ)
        SQL.Parameters.Add("@C1", SqlDbType.VarChar)
        SQL.Parameters.Add("@C2", SqlDbType.VarChar)
        SQL.Parameters.Add("@C3", SqlDbType.VarChar)
        SQL.Parameters.Add("@C4", SqlDbType.VarChar)
        SQL.Parameters.Add("@C5", SqlDbType.VarChar)
        SQL.Parameters.Add("@RFC", SqlDbType.VarChar)
        SQL.Parameters.Add("@REG", SqlDbType.Int)
        For X = 0 To DGV2.RowCount - 1
            SQL.Parameters("@C1").Value = DGV2.Item(1, X).Value.ToString
            SQL.Parameters("@C2").Value = DGV2.Item(2, X).Value.ToString
            SQL.Parameters("@C3").Value = DGV2.Item(3, X).Value.ToString
            SQL.Parameters("@C4").Value = DGV2.Item(4, X).Value.ToString
            SQL.Parameters("@C5").Value = DGV2.Item(5, X).Value.ToString
            SQL.Parameters("@RFC").Value = DGV2.Item(0, X).Value
            SQL.Parameters("@REG").Value = DGV2.Item(6, X).Value
            SQL.ExecuteNonQuery()
        Next
    End Sub
    Private Function VALIDACORREOS() As Boolean
        Dim X, Y As Integer
        For X = 1 To DGV2.Columns.Count - 2
            For Y = 0 To DGV2.RowCount - 1
                If Not ValidaEmail(DGV2.Item(X, Y).Value.ToString) Then
                    DGV2.CurrentCell = DGV2.Item(X, Y)
                    Return False
                End If
            Next
        Next
        Return True
    End Function
    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT RFC,NOMBRE,NOMBRECOMERCIAL [NOMBRE COMERCIAL],DOMICILIOS,CORREOS FROM VCLIENTES ", " WHERE COMPUESTO", " ORDER BY NOMBRE", "Búsqueda de Clientes", "Nombre Comercial del Cliente", "Cliente(s)", 1, CADENA, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTRFC.Text = frmClsBusqueda.TREG.Rows(0).Item(0)
            CARGADATOS()
        End If
    End Sub

    Private Sub TXTRFC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRFC.KeyPress
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(TXTRFC.Text) Then
            Else
                If TXTRFC.Text.Length < 12 Then
                    MessageBox.Show("RFC Incompleto, faltan Caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                End If
                If TXTRFC.Text.Length = 13 Then
                    If RegularExpressions.Regex.IsMatch(Me.TXTRFC.Text, "^([A-Z,&,ñ,Ñ\s]{4})\d{6}([A-Z\w]{3})$") Then
                        CARGADATOS()
                    Else
                        MessageBox.Show("Teclee un RFC valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                If TXTRFC.Text.Length = 12 Then
                    If RegularExpressions.Regex.IsMatch(Me.TXTRFC.Text, "^([A-Z,&,ñ,Ñ\s]{3})\d{6}([A-Z\w]{3})$") Then
                        CARGADATOS()
                    Else
                        MessageBox.Show("Teclee un RFC valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
        LIMPIAR()
    End Sub
End Class