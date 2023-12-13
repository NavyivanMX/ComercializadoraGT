
Imports System.Text
Imports System.Text.RegularExpressions
Public Class frmFacturarV2
    Dim LREG As New List(Of String)
    Dim LDOM As New List(Of String)
    Dim LDE As New List(Of String)
    Dim LMP As New List(Of String)
    Dim LFP As New List(Of String)
    Dim CONZ As New SqlClient.SqlConnection
    Dim CADENA As String
    Dim TIENDA As String
    Dim VV As String
    Dim VFECHA As DateTime
    Dim DT As DataTable
    Private Sub frmFacturarV2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CADENA = frmPrincipal.CadenaConexionFE
        CONZ.ConnectionString = CADENA
        CHECACONZ()
        ACTIVAR(True)
        CHECATABLA()
        OPLlenaComboBox(CBFP, LFP, "SELECT CLAVE,NOMBRE FROM FORMASPAGO WHERE ACTIVO=1 ORDER BY NOMBRE", CADENA)
        OPLlenaComboBox(CBMP, LMP, "SELECT CLAVE,NOMBRE FROM METODOSPAGOS WHERE ACTIVO=1 ORDER BY NOMBRE", CADENA)
        LIMPIAR()

        FOLIO(SERIE)
        TXTRFC.Text = "XAXX010101000"
        CARGADATOS()
    End Sub
    Public Sub MOSTRAR(ByVal VTIENDA As String, ByVal VSERIE As String, ByVal VDT As DataTable, ByVal FECHA As DateTime)
        TIENDA = VTIENDA
        VFECHA = FECHA
        VV = VSERIE
        CARGARDT(VDT)
        TXTCOM.Text = "FACTURA QUE AMPARA LA VENTA PUBLICO EN GENERAL DEL " + Format(FECHA, "dd/MM/yyyy")
        Me.ShowDialog()
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
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        ACTIVAR(False)
        Dim SQL As New SqlClient.SqlCommand("SELECT NOMBRE,NOMBRECOMERCIAL,VN FROM CLIENTES WHERE RFC='" + TXTRFC.Text + "'", CONZ)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            TXTNOM.Text = LEC(0)
            TXTNCOM.Text = LEC(1)
            TXTNOM.Enabled = CType(LEC(2), Boolean)
            TXTNCOM.Enabled = CType(LEC(2), Boolean)
        End If
        LEC.Close()
        SQL.Dispose()
        OPLlenaComboBox(CBCALLE, LREG, LDOM, "SELECT REGISTRO,DBO.DIRCLIENTE(RFC,REGISTRO),CALLE FROM DOMICILIOSCLIENTES WHERE RFC='" + TXTRFC.Text + "' AND ACTIVO=1", CADENA)
        If CBCALLE.Items.Count <= 0 Then
            MessageBox.Show("Este cliente no cuenta con direcciones para la Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ACTIVAR(True)
            Exit Sub
        Else
            CBCALLE.SelectedIndex = 0
            CHECATABLA()
        End If
    End Sub
    Dim S, I, T, VIEPS As Double
    Dim CLETRAS As New num2text
    Private Sub CHECATABLA()
        S = 0
        I = 0
        T = 0
        VIEPS = 0
        If DGV.Rows.Count <= 0 Then
            BTNGUARDAR.Enabled = False
        Else
            BTNGUARDAR.Enabled = True
            Dim X As Integer
            For X = 0 To DGV.Rows.Count - 1
                S += DGV.Item(4, X).Value
                I += DGV.Item(6, X).Value
                VIEPS += DGV.Item(7, X).Value
            Next
        End If
        'I = S * 0.16
        I = Math.Round(I, 2)
        T = S + I + VIEPS
        T = Math.Round(T, 2)
        LBLSUB.Text = "SubTotal $ " + FormatNumber(S, 2).ToString
        LBLIVA.Text = "IVA $ " + FormatNumber(I, 2).ToString
        LBLIEPS.Text = "IEPS $" + FormatNumber(VIEPS, 2).ToArray
        LBLTOT.Text = "Total $ " + FormatNumber(T, 2).ToString
        LBLCCL.Text = CLETRAS.Letras(T.ToString)
    End Sub
    Private Sub CBCALLE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBCALLE.SelectedIndexChanged
        LBLDD.Text = LDOM(CBCALLE.SelectedIndex)
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTRFC.Enabled = V
        TXTNOM.Enabled = False
        TXTNCOM.Enabled = False
        CBCALLE.Enabled = Not V
        BTNCORREO.Enabled = Not V
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT RFC,NOMBRE,NOMBRECOMERCIAL [NOMBRE COMERCIAL] FROM VCLIENTES WHERE ACTIVO=1", " and COMPUESTO", " ORDER BY NOMBRE", "Búsqueda de Clientes", "Nombre Comercial del Cliente", "Cliente(s)", 1, CADENA, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTRFC.Text = frmClsBusqueda.TREG.Rows(0).Item(0)
            CARGADATOS()
        End If
    End Sub

    Private Function CARGAPAGONOTA(ByVal RES As String, ByVal NOTA As String, ByVal ESCRE As Boolean) As Boolean
        If Not frmPrincipal.CHECACONX Then
            Return True
        End If
        If ESCRE Then
            OPCargaX(LFP, CBFP, 2)
            OPCargaX(LMP, CBMP, 6)
        Else
            Dim FP As Integer
            Dim TT As Integer
            Dim SQL As New SqlClient.SqlCommand("SELECT TIPOPAGO,REF,TIPOTARJETA FROM NOTASDEVENTA WHERE TIENDA='" + RES + "' AND NOTA='" + NOTA + "'", frmPrincipal.CONX)
            Dim LEC As SqlClient.SqlDataReader
            LEC = SQL.ExecuteReader
            If LEC.Read Then
                FP = LEC(0)
                TXTTAR.Text = LEC(1)
                TT = LEC(2)
            End If
            LEC.Close()
            If FP = 1 Then
                OPCargaX(LMP, CBMP, 1)
            End If
            If FP = 2 Then
                OPCargaX(LMP, CBMP, 2)
                If TT = 1 Then
                    OPCargaX(LMP, CBMP, 2)
                End If
                If TT = 2 Then
                    OPCargaX(LMP, CBMP, 3)
                End If

            End If
            If FP = 3 Then
                OPCargaX(LMP, CBMP, 4)
            End If
            If FP = 5 Then
                OPCargaX(LMP, CBMP, 5)
            End If
            SQL.Dispose()
        End If
    End Function
    Dim LISTANOTAS As New List(Of Integer)
    Dim LISTAESCREDITO As New List(Of Boolean)

    Private Sub CARGARDT(ByVal DT As DataTable)
        DGV.Rows.Clear()
        Dim ITEMS As Integer
        Dim X As Integer
        For X = 0 To DT.Rows.Count - 1
            DGV.Rows.Add(1)
            ITEMS = DGV.Rows.Count - 1
            DGV.Item(0, ITEMS).Value = DT.Rows(X).Item(0)
            DGV.Item(1, ITEMS).Value = DT.Rows(X).Item(1)
            DGV.Item(2, ITEMS).Value = DT.Rows(X).Item(2)
            DGV.Item(3, ITEMS).Value = DT.Rows(X).Item(3)
            DGV.Item(4, ITEMS).Value = DT.Rows(X).Item(4)
            DGV.Item(5, ITEMS).Value = DT.Rows(X).Item(5)
            DGV.Item(6, ITEMS).Value = DT.Rows(X).Item(6)
            DGV.Item(7, ITEMS).Value = DT.Rows(X).Item(7)
            DGV.Item(8, ITEMS).Value = DT.Rows(X).Item(8)
            DGV.Item(9, ITEMS).Value = DT.Rows(X).Item(9)
        Next
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub

    Private Function SERIE() As String
        LBLSER.Text = VV
        Return VV
        'If Not CHECACONZ() Then
        '    Return "GRAL"
        'End If
        'Dim SQL As New SqlClient.SqlCommand("SELECT SERIE FROM NEGOCIOS WHERE RFC='" + frmPrincipal.EmisorBase + "' AND CLAVE='" + VV + "'", CONZ)
        'Dim LEC As SqlClient.SqlDataReader
        'LEC = SQL.ExecuteReader
        'Dim REG As String
        'REG = "GRAL"
        'If LEC.Read Then
        '    REG = LEC(0)
        'End If
        'LEC.Close()
        'SQL.Dispose()
        'LBLSER.Text = "Serie: " + REG
        'Return REG
    End Function
    Private Function FOLIO(ByVal SERIE As String) As Integer
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT DBO.SIGFOLIO('" + frmPrincipal.EmisorBase + "','" + SERIE + "')", CONZ)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        Dim REG As Integer
        REG = 1
        If LEC.Read Then
            If LEC(0) Is DBNull.Value Then
                REG = 1
            Else
                REG = LEC(0)
            End If
        End If
        LEC.Close()
        LBLFOL.Text = "Folio: " + REG.ToString
        Return REG
    End Function

    Private Sub GUARDAR()
        If Not CHECACONZ() Then
            Exit Sub
        End If
        Dim ELFOLIO As Integer
        Dim VSERIE As String
        VSERIE = SERIE()
        ELFOLIO = FOLIO(VSERIE)
        Dim SQLUC As New SqlClient.SqlCommand("UPDATE CLIENTES SET NOMBRE='" + TXTNOM.Text + "' WHERE RFC='" + TXTRFC.Text + "'", CONZ)
        SQLUC.ExecuteNonQuery()
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO FACTURAS (RFCEMISOR,SERIE,FOLIO,NEGOCIO,RFCCLIENTE,DOMICILIOCLIENTE,TIPOCOMPROBANTE,METODOPAGO,FORMAPAGO,REFNOTA,SUBTOTAL,IVA,TOTAL,CCLETRA,TIPOFACTURA,NOMBRE,DIGITOSTC,COMENTARIO,FECHA,ORIGEN) VALUES ('" + frmPrincipal.EmisorBase + "','" + VSERIE + "'," + ELFOLIO.ToString + ",'" + VV + "','" + TXTRFC.Text + "','" + LREG(CBCALLE.SelectedIndex).ToString + "','1','" + LMP(CBMP.SelectedIndex).ToString + "','" + LFP(CBFP.SelectedIndex).ToString + "','0'," + S.ToString + "," + I.ToString + "," + T.ToString + ",'" + LBLCCL.Text + "',1,'" + TXTNOM.Text + "','" + DIGITOSTC + "','" + TXTCOM.Text + "',@FEC,2)", CONZ)
        SQL.Parameters.Add("@FEC", SqlDbType.DateTime).Value = VFECHA
        SQL.ExecuteNonQuery()
        Dim SQLD As New SqlClient.SqlCommand("INSERT INTO DETALLEFACTURAS (RFCEMISOR,SERIE,FOLIO,REFNOTA,CODIGO,CANTIDAD,DESCRIPCION,VALORUNITARIO,IMPORTE,REGISTRO,UNIDAD,IVA,IEPS,TASAIEPS,GRUPOIEPS) VALUES ('" + frmPrincipal.EmisorBase + "','" + VSERIE + "','" + ELFOLIO.ToString + "','0',@COD,@CANT,@DES,@PRE,@IMP,@REG,@UNI,@IVA,@IEPS,@TIEPS,@GIEPS)", CONZ)
        SQLD.Parameters.Add("@COD", SqlDbType.VarChar)
        SQLD.Parameters.Add("@CANT", SqlDbType.Float)
        SQLD.Parameters.Add("@DES", SqlDbType.VarChar)
        SQLD.Parameters.Add("@UNI", SqlDbType.VarChar)
        SQLD.Parameters.Add("@PRE", SqlDbType.Float)
        SQLD.Parameters.Add("@IMP", SqlDbType.Float)
        SQLD.Parameters.Add("@REG", SqlDbType.Int)
        SQLD.Parameters.Add("@IVA", SqlDbType.Float)
        SQLD.Parameters.Add("@IEPS", SqlDbType.Float)
        SQLD.Parameters.Add("@TIEPS", SqlDbType.Float)
        SQLD.Parameters.Add("@GIEPS", SqlDbType.Int)
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            SQLD.Parameters("@COD").Value = DGV.Item(0, X).Value.ToString
            SQLD.Parameters("@CANT").Value = DGV.Item(1, X).Value
            SQLD.Parameters("@DES").Value = DGV.Item(2, X).Value.ToString
            SQLD.Parameters("@PRE").Value = DGV.Item(3, X).Value
            SQLD.Parameters("@IMP").Value = DGV.Item(4, X).Value
            SQLD.Parameters("@REG").Value = X.ToString
            SQLD.Parameters("@UNI").Value = DGV.Item(5, X).Value
            SQLD.Parameters("@IVA").Value = DGV.Item(6, X).Value
            SQLD.Parameters("@IEPS").Value = DGV.Item(7, X).Value
            SQLD.Parameters("@TIEPS").Value = DGV.Item(8, X).Value
            SQLD.Parameters("@GIEPS").Value = DGV.Item(9, X).Value
            SQLD.ExecuteNonQuery()
        Next
        Dim SQLMN As New SqlClient.SqlCommand("INSERT INTO MULTIPLESNOTAS (RFC,SERIE,FOLIO,NOTA,ESCRE,TIENDA) VALUES ('" + frmPrincipal.EmisorBase + "','" + VSERIE + "'," + ELFOLIO.ToString + ",0,0,'" + frmPrincipal.SucursalBase + "')", CONZ)
        SQLMN.ExecuteNonQuery()
        SQL.Dispose()
        SQLD.Dispose()
        SQLMN.Dispose()
        MessageBox.Show("La informacion ha sido Guardada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        'Dim VMF As New frmMensajeFactura
        'VMF.ShowDialog()
        'VMF.Dispose()
        'Dim VER As New frmEsperaRespuesta
        'VER.MOSTRAR(frmPrincipal.EmisorBase, VSERIE, ELFOLIO)
        'VER.Dispose()
        ACTIVAR(True)
        LIMPIAR()
        Me.Close()
    End Sub
    Dim DIGITOSTC As String

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        If DGV.Rows.Count <= 0 Then
            Exit Sub
        End If
        DIGITOSTC = "No Identificado"
        If LMP(CBMP.SelectedIndex) <> "1" Then
            If TXTTAR.TextLength <> 4 Then
                MessageBox.Show("Debe escribir los últimos 4 dígitos de Tarjeta / Cheque", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                DIGITOSTC = TXTTAR.Text
            End If
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea Guardar la Información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
    End Sub
    Private Sub LIMPIAR()
        'DGV.Rows.Clear()
        LISTANOTAS.Clear()
        LISTAESCREDITO.Clear()
        CBFP.SelectedIndex = 0
        CBMP.SelectedIndex = 0
        'DGV.DataSource = Nothing
        'DGV.Refresh()
        CHECATABLA()
    End Sub
    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
        LIMPIAR()
    End Sub

    Private Sub BTNCORREO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCORREO.Click
        Dim VCCRFC As New frmCorreosClientesFacturas
        VCCRFC.MOSTRAR(TXTRFC.Text)
    End Sub


    Private Sub CBMP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBMP.SelectedIndexChanged
        If LMP(CBMP.SelectedIndex) <> "1" Then
            TXTTAR.Enabled = True
        Else
            TXTTAR.Text = ""
            TXTTAR.Enabled = False
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

    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        Dim VNCLIENTES As New frmClientesFacturasElectronicas
        VNCLIENTES.ShowDialog()
    End Sub

    Private Sub frmFacturarV2_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            CONZ.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class