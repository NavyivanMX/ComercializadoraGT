Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmFacturar
    Dim LREG As New List(Of String)
    Dim LDOM As New List(Of String)
    Dim LDE As New List(Of String)
    Dim LMP As New List(Of String)
    Dim LFP As New List(Of String)
    Dim CONZ As New SqlClient.SqlConnection
    Dim CADENA As String
    Dim VMOSTRAR As Boolean
    Dim PG As Boolean
    Private Sub frmFacturar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CADENA = frmPrincipal.CadenaConexionFE
        CONZ.ConnectionString = CADENA
        CHECACONZ()
        ACTIVAR(True)
        CHECATABLA()
        OPLlenaComboBox(CBFP, LFP, "SELECT CLAVE,NOMBRE FROM FORMASPAGO WHERE ACTIVO=1 ORDER BY NOMBRE", CADENA)
        OPLlenaComboBox(CBMP, LMP, "SELECT CLAVE,NOMBRE FROM METODOSPAGOS WHERE ACTIVO=1 ORDER BY NOMBRE", CADENA)
        '
        PG = False
        If VMOSTRAR Then
            If TXTRFC.Text <> "1Il6G2Z0Oq95S" Then
                CARGADATOS()
                CARGARNOTA(frmPrincipal.SucursalBase, TXTNOTA.Text)
            End If
        Else
            LIMPIAR()
        End If

    End Sub
    Public Sub MOSTRAR(ByVal RFC As String, ByVal NOTA As String, ByVal CRE As Boolean)
        LIMPIAR()
        VMOSTRAR = True
        TXTRFC.Text = RFC
        TXTNOTA.Text = NOTA
        CHKCRE.Checked = CRE
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
            PG = True
        End If
        LEC.Close()
        SQL.Dispose()
        OPLlenaComboBox(CBCALLE, LREG, LDOM, "SELECT REGISTRO,DOMICILIO=CALLE+' '+NOEXT+' '+ NOINT+' '+COLONIA+' '+LOCALIDAD+' '+ESTADO+' '+CP,CALLE FROM DOMICILIOSCLIENTES WHERE RFC='" + TXTRFC.Text + "' AND ACTIVO=1", CADENA)
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
        TXTNOTA.Enabled = Not V
        BTNCORREO.Enabled = Not V
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT RFC,NOMBRE,NOMBRECOMERCIAL [NOMBRE COMERCIAL] FROM CLIENTES WHERE ACTIVO=1 ", " AND NOMBRECOMERCIAL", " ORDER BY NOMBRE", "Búsqueda de Clientes", "Nombre Comercial del Cliente", "Cliente(s)", 1, CADENA, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTRFC.Text = frmClsBusqueda.TREG.Rows(0).Item(0)
            CARGADATOS()
        End If
    End Sub
    Private Function NOTAYAGUARDADA(ByVal RES As String, ByVal NOTA As String, ByVal ESCRE As Boolean) As Boolean
        If Not CHECACONZ() Then
            Return True
        End If
        Dim RESULTADO As Boolean
        RESULTADO = False
        Dim BSERIE, BFOLIO, BFECHA As String
        BSERIE = ""
        BFOLIO = ""
        BFECHA = ""
        Dim BTS As String
        If ESCRE Then
            BTS = "1"
        Else
            BTS = "0"
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT M.SERIE,M.FOLIO,F.FECHA FROM FACTURAS F INNER JOIN MULTIPLESNOTAS M ON F.RFCEMISOR=M.RFC AND F.SERIE=M.SERIE AND F.FOLIO=M.FOLIO WHERE F.RFCEMISOR='" + frmPrincipal.EmisorBase + "' AND F.NEGOCIO='" + RES + "' AND M.NOTA='" + NOTA + "' AND ESCRE='" + BTS + "' AND F.ESTADO<>3", CONZ)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            BSERIE = LEC(0)
            BFOLIO = LEC(1)
            BFECHA = LEC(2)
            RESULTADO = True
        End If
        LEC.Close()
        If RESULTADO Then
            MessageBox.Show("Esta nota ya se ha utilizado para Facturar. Serie: " + BSERIE + ", Folio: " + BFOLIO + ", Fecha: " + BFECHA + ". Favor de utilizar la opción de Re Imprimir Factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return RESULTADO
    End Function
    Dim LISTANOTAS As New List(Of Integer)
    Dim LISTAESCREDITO As New List(Of Boolean)
    Private Function NOTAYAAGREGADA(ByVal NOTA As Integer, ByVal ESCRE As Boolean) As Boolean
        Dim X As Integer
        If LISTANOTAS.Count = 0 Then
            Return False
        Else
            For X = 0 To LISTANOTAS.Count - 1
                If LISTANOTAS(X) = NOTA And LISTAESCREDITO(X) = ESCRE Then
                    MessageBox.Show("Esta Nota ya ha sido Agregada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    TXTNOTA.SelectAll()
                    TXTNOTA.Focus()
                    Return True
                End If
            Next
        End If
        Return False
    End Function
    Private Sub NOTASAGREGADAS()
        DGV.Rows.Clear()
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim X As Integer
        For X = 0 To LISTANOTAS.Count - 1
            Dim SQL As New SqlClient.SqlCommand("SELECT D.PRODUCTO,D.CANTIDAD,P.NOMBRE+' '+P.PEDIMENTO DESCRIPCION,PRECIO=DBO.PRECIOFAC(D.PRODUCTO,D.CANTIDAD,D.TOTAL),TOTAL=DBO.TOTALFAC(D.PRODUCTO,D.TOTAL,D.CANTIDAD),U.NOMBRE UNIDAD,IVA=DBO.IVAFAC(D.PRODUCTO,D.TOTAL,D.CANTIDAD),DBO.IEPSFAC(P.IEPS,D.CANTIDAD,D.TOTAL) IEPS,P.TASAIEPS,P.GRUPOIEPS  FROM DETALLENOTASDEVENTA D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE INNER JOIN UNIDADES U ON P.UVENTA=U.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + LISTANOTAS(X).ToString + " ", frmPrincipal.CONX)
            If LISTAESCREDITO(X) Then
                SQL.CommandText = "SELECT D.PRODUCTO,D.CANTIDAD,P.NOMBRE+' '+P.PEDIMENTO DESCRIPCION,PRECIO=DBO.PRECIOFAC(D.PRODUCTO,D.CANTIDAD,D.TOTAL),TOTAL=DBO.TOTALFAC(D.PRODUCTO,D.TOTAL,D.CANTIDAD),U.NOMBRE UNIDAD,IVA=DBO.IVAFAC(D.PRODUCTO,D.TOTAL,D.CANTIDAD),DBO.IEPSFAC(P.IEPS,D.CANTIDAD,D.TOTAL) IEPS,P.TASAIEPS,P.GRUPOIEPS FROM DETALLENOTASDEVENTACREDITO D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE INNER JOIN UNIDADES U ON P.UVENTA=U.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + LISTANOTAS(X).ToString + " "
            End If
            Dim LECTOR As SqlClient.SqlDataReader
            LECTOR = SQL.ExecuteReader
            Dim ITEMS As Integer
            While LECTOR.Read
                DGV.Rows.Add(1)
                ITEMS = DGV.Rows.Count - 1
                DGV.Item(0, ITEMS).Value = LECTOR(0)
                DGV.Item(1, ITEMS).Value = LECTOR(1)
                DGV.Item(2, ITEMS).Value = LECTOR(2)
                DGV.Item(3, ITEMS).Value = LECTOR(3)
                DGV.Item(4, ITEMS).Value = LECTOR(4)
                DGV.Item(5, ITEMS).Value = LECTOR(5)
                DGV.Item(6, ITEMS).Value = LECTOR(6)
                DGV.Item(7, ITEMS).Value = LECTOR(7)
                DGV.Item(8, ITEMS).Value = LECTOR(8)
                DGV.Item(9, ITEMS).Value = LECTOR(9)
            End While
            LECTOR.Close()
        Next
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub
    Private Sub QUITARNOTA(ByVal IND As Integer)
        'Dim X, POS As Integer
        'Dim ENCONTRADO As Boolean
        'ENCONTRADO = False
        'For X = 0 To LISTANOTAS.Count - 1
        '    If LISTANOTAS(X) = NOTA Then
        '        ENCONTRADO = True
        '        POS = X
        '    End If
        'Next
        'If ENCONTRADO Then
        LISTANOTAS.RemoveAt(IND)
        LISTAESCREDITO.RemoveAt(IND)
        'End If
        NOTASAGREGADAS()
        ACTUALIZALB()
    End Sub
    Private Sub ACTUALIZALB()
        LB.Items.Clear()
        Dim X As Integer
        If LISTANOTAS.Count <= 0 Then
            BTNQUITAR.Enabled = False
        Else
            BTNQUITAR.Enabled = True
        End If
        For X = 0 To LISTANOTAS.Count - 1
            If LISTAESCREDITO(X) Then
                LB.Items.Add(LISTANOTAS(X).ToString + " -C")
            Else
                LB.Items.Add(LISTANOTAS(X).ToString + " -N")
            End If
        Next
    End Sub
    Private Function NOTADIAANTERIOR(ByVal RES As String, ByVal NOTA As Integer)
        If Not frmPrincipal.CHECACONX Then
            Return False
        End If
        Dim REG As Boolean
        REG = True
        Return False
        Dim RESULTADO As String
        RESULTADO = ""
        Dim SQL As New SqlClient.SqlCommand("SELECT DBO.FECHANOTA('" + RES + "'," + NOTA.ToString + ",0)", frmPrincipal.CONX)
        If CHKCRE.Checked Then
            SQL.CommandText = "SELECT DBO.FECHANOTA('" + RES + "'," + NOTA.ToString + ",1)"
            Return False
        End If

        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            RESULTADO = LEC(0)
        End If
        LEC.Close()
        SQL.Dispose()
        If RESULTADO = "VALIDA" Then
            Return False
        Else
            MessageBox.Show("Nota del Día: " + RESULTADO + " Solo se facturará en el mismo día", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return REG
    End Function
    Private Sub CARGARNOTA(ByVal RES As String, ByVal NOTA As String)
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        If NOTADIAANTERIOR(RES, NOTA) Then
            Exit Sub
        End If
        If NOTAYAAGREGADA(NOTA, CHKCRE.Checked) Then
            Exit Sub
        End If
        If NOTAYAGUARDADA(RES, NOTA, CHKCRE.Checked) Then
            Exit Sub
        End If
        LISTANOTAS.Add(CType(NOTA, Integer))
        LISTAESCREDITO.Add(CHKCRE.Checked)
        ACTUALIZALB()
        NOTASAGREGADAS()
        TXTNOTA.Focus()
        TXTNOTA.SelectAll()
        'DGV.DataSource = BDLlenatabla("SELECT D.TELA,D.EQUIVALENCIA CANTIDAD,P.DESCRIPCION DESCRIPCION,PRECIO=(CONVERT(NUMERIC(15,2),(D.TOTAL/D.EQUIVALENCIA)/1.16,2)),TOTAL=CONVERT(NUMERIC(15,2),(D.TOTAL/1.16),2),U.NOMBRECORTO UNIDAD FROM DETALLENOTASDEVENTA D INNER JOIN PRODUCTOS P ON D.TELA=P.CLAVE INNER JOIN UNIDADES U ON P.UNIDAD=U.CLAVE WHERE D.SUCURSAL='" + RES + "' AND NOTA=" + NOTA.ToString + " ", frmPrincipal.CadenaConexion)
        'CHECATABLA()
    End Sub
    Private Sub TXTNOTA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOTA.KeyPress
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(TXTRFC.Text) Then
            Else
                CARGARNOTA(frmPrincipal.SucursalBase, TXTNOTA.Text)
            End If
        End If
    End Sub
    Private Function SERIE() As String
        If Not CHECACONZ() Then
            Exit Function
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT SERIE FROM NEGOCIOS WHERE RFC='" + frmPrincipal.EmisorBase + "' AND CLAVE='" + frmPrincipal.SucursalBase + "'", CONZ)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        Dim REG As String
        REG = "GRAL"
        If LEC.Read Then
            REG = LEC(0)
        End If
        LEC.Close()
        SQL.Dispose()
        Return REG
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
        'Dim FF As Integer
        'FF = 0
        'SQL.CommandText = "SELECT FOLIOFINAL FROM NEGOCIOS WHERE RFC='" + frmPrincipal.EmisorBase + "' AND CLAVE='" + frmPrincipal.SucursalBase + "'"
        'LEC = SQL.ExecuteReader
        'If LEC.Read Then
        '    Try
        '        FF = LEC(0)
        '    Catch ex As Exception

        '    End Try
        'End If
        'LEC.Close()
        'SQL.Dispose()
        'If REG > FF Then
        '    MessageBox.Show("Folios excedidos, favor de comunicarse al departamenteo de Contabilidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If
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
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO FACTURAS (RFCEMISOR,SERIE,FOLIO,NEGOCIO,RFCCLIENTE,DOMICILIOCLIENTE,TIPOCOMPROBANTE,METODOPAGO,FORMAPAGO,REFNOTA,SUBTOTAL,IVA,TOTAL,CCLETRA,TIPOFACTURA,NOMBRE,DIGITOSTC) VALUES ('" + frmPrincipal.EmisorBase + "','" + VSERIE + "'," + ELFOLIO.ToString + ",'" + frmPrincipal.SucursalBase + "','" + TXTRFC.Text + "','" + LREG(CBCALLE.SelectedIndex).ToString + "','1','" + LMP(CBMP.SelectedIndex).ToString + "','" + LFP(CBFP.SelectedIndex).ToString + "','" + TXTNOTA.Text + "'," + S.ToString + "," + I.ToString + "," + T.ToString + ",'" + LBLCCL.Text + "',1,'" + TXTNOM.Text + "','" + DIGITOSTC + "')", CONZ)
        SQL.ExecuteNonQuery()
        Dim SQLD As New SqlClient.SqlCommand("INSERT INTO DETALLEFACTURAS (RFCEMISOR,SERIE,FOLIO,REFNOTA,CODIGO,CANTIDAD,DESCRIPCION,VALORUNITARIO,IMPORTE,REGISTRO,UNIDAD,IVA,IEPS,TASAIEPS,GRUPOIEPS) VALUES ('" + frmPrincipal.EmisorBase + "','" + VSERIE + "','" + ELFOLIO.ToString + "','" + TXTNOTA.Text + "',@COD,@CANT,@DES,@PRE,@IMP,@REG,@UNI,@IVA,@IEPS,@TIEPS,@GIEPS)", CONZ)

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
            'SQLD.Parameters("@COD").Value = DGV.Item(0, X).Value.ToString
            'SQLD.Parameters("@CANT").Value = DGV.Item(1, X).Value
            'SQLD.Parameters("@DES").Value = DGV.Item(2, X).Value.ToString
            'SQLD.Parameters("@PRE").Value = DGV.Item(3, X).Value
            'SQLD.Parameters("@IMP").Value = DGV.Item(4, X).Value
            'SQLD.Parameters("@REG").Value = X.ToString
            'SQLD.Parameters("@UNI").Value = DGV.Item(5, X).Value
            'SQLD.ExecuteNonQuery()
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
        Dim SQLMN As New SqlClient.SqlCommand("INSERT INTO MULTIPLESNOTAS (RFC,SERIE,FOLIO,NOTA,ESCRE,TIENDA) VALUES ('" + frmPrincipal.EmisorBase + "','" + VSERIE + "'," + ELFOLIO.ToString + ",@NOTA,@ESCRE,'" + frmPrincipal.SucursalBase + "')", CONZ)
        SQLMN.Parameters.Add("@NOTA", SqlDbType.Int)
        SQLMN.Parameters.Add("@ESCRE", SqlDbType.Bit)
        For X = 0 To LISTANOTAS.Count - 1
            SQLMN.Parameters("@NOTA").Value = LISTANOTAS(X)
            SQLMN.Parameters("@ESCRE").Value = LISTAESCREDITO(X)
            SQLMN.ExecuteNonQuery()
        Next
        SQL.Dispose()
        SQLD.Dispose()
        SQLMN.Dispose()
        MessageBox.Show("La informacion ha sido Guardada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Dim VMF As New frmMensajeFactura
        VMF.ShowDialog()
        VMF.Dispose()
        Dim VER As New frmEsperaRespuesta
        VER.MOSTRAR(frmPrincipal.EmisorBase, VSERIE, ELFOLIO)
        VER.Dispose()
        ACTIVAR(True)
        LIMPIAR()
    End Sub
    Dim DIGITOSTC As String
    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        If DGV.Rows.Count <= 0 Then
            Exit Sub
        End If
        If Not PG Then
            MessageBox.Show("No se ha especificado un cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        DIGITOSTC = "No Identificado"
        If LMP(CBMP.SelectedIndex) <> "1" Then
            If TXTTAR.TextLength <> 4 Then
                'MessageBox.Show("Debe escribir los últimos 4 dígitos de Tarjeta / Cheque", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                DIGITOSTC = TXTTAR.Text
            End If
        End If
        'Dim xyz As Short
        'xyz = MessageBox.Show("¿Desea Guardar la Información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        'If xyz <> 6 Then
        '    Exit Sub
        'End If
        GUARDAR()
    End Sub
    Private Sub LIMPIAR()
        TXTNOTA.Text = ""
        DGV.Rows.Clear()
        LISTANOTAS.Clear()
        ACTUALIZALB()
        DGV.DataSource = Nothing
        DGV.Refresh()
        CHECATABLA()
    End Sub
    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
        LIMPIAR()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim VNCLIENTES As New frmClientesFacturasElectronicas
        VNCLIENTES.ShowDialog()
    End Sub

    Private Sub BTNCORREO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCORREO.Click
        Dim VCCRFC As New frmCorreosClientesFacturas
        VCCRFC.MOSTRAR(TXTRFC.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        'Dim POS As Integer
        'POS = LB.SelectedIndex - 1
        QUITARNOTA(LB.SelectedIndex)
    End Sub

    'Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim ELFOLIO As Integer
    '    Dim VSERIE As String
    '    VSERIE = SERIE()


    '    Dim Y As Integer
    '    For Y = 1 To 100
    '        S = 13.84 * Y
    '        I = (13.84 * Y) * 0.16
    '        T = S + I
    '        Dim SQL As New SqlClient.SqlCommand("INSERT INTO FACTURAS (RFCEMISOR,SERIE,FOLIO,NEGOCIO,RFCCLIENTE,DOMICILIOCLIENTE,TIPOCOMPROBANTE,METODOPAGO,FORMAPAGO,REFNOTA,SUBTOTAL,IVA,TOTAL,CCLETRA,TIPOFACTURA) VALUES ('" + frmPrincipal.EmisorBase + "','" + VSERIE + "'," + Y.ToString + ",'" + frmPrincipal.SucursalBase + "','" + TXTRFC.Text + "','" + LREG(CBCALLE.SelectedIndex).ToString + "','1','" + LMP(CBMP.SelectedIndex).ToString + "','" + LFP(CBFP.SelectedIndex).ToString + "','" + TXTNOTA.Text + "'," + S.ToString + "," + I.ToString + "," + T.ToString + ",'" + LBLCCL.Text + "',2)", CONZ)
    '        SQL.ExecuteNonQuery()
    '        Dim SQLD As New SqlClient.SqlCommand("INSERT INTO DETALLEFACTURAS (RFCEMISOR,SERIE,FOLIO,REFNOTA,CODIGO,CANTIDAD,DESCRIPCION,VALORUNITARIO,IMPORTE,REGISTRO,UNIDAD) VALUES ('" + frmPrincipal.EmisorBase + "','" + VSERIE + "','" + Y.ToString + "','" + TXTNOTA.Text + "',@COD,@CANT,@DES,@PRE,@IMP,@REG,@UNI)", CONZ)
    '        SQLD.Parameters.Add("@COD", SqlDbType.VarChar)
    '        SQLD.Parameters.Add("@CANT", SqlDbType.Float)
    '        SQLD.Parameters.Add("@DES", SqlDbType.VarChar)
    '        SQLD.Parameters.Add("@UNI", SqlDbType.VarChar)
    '        SQLD.Parameters.Add("@PRE", SqlDbType.Float)
    '        SQLD.Parameters.Add("@IMP", SqlDbType.Float)
    '        SQLD.Parameters.Add("@REG", SqlDbType.Int)

    '        SQLD.Parameters("@COD").Value = "COD" + Y.ToString
    '        SQLD.Parameters("@CANT").Value = Y
    '        SQLD.Parameters("@DES").Value = "VENTA DE PRODUCTO X" + Y.ToString
    '        SQLD.Parameters("@PRE").Value = 13.84
    '        SQLD.Parameters("@IMP").Value = 13.84 * Y
    '        SQLD.Parameters("@REG").Value = 0
    '        SQLD.Parameters("@UNI").Value = "PIEZA"
    '        SQLD.ExecuteNonQuery()
    '    Next

    'End Sub

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
End Class