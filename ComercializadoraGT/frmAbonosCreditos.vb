Public Class frmAbonosCreditos

    Dim LSecciones As New List(Of String)
    Dim NOMCLI As String
    Dim CLACLI As String
    Dim TRPP As Double
    Dim CC As New ColorConverter
    Dim LTP As New List(Of String)

    Dim NOCAJA, CAJERA As Integer
    Dim NOMCAJERA As String
    Private Sub frmAbonosCreditos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        TXTNOTA.Text = CARGANOTA.ToString
        OPLlenaComboBox(CBTP, LTP, "SELECT CLAVE,NOMBRE FROM TIPOSPAGOS WHERE CLAVE NOT IN (0,4) ORDER BY NOMBRE", frmPrincipal.CadenaConexion, "Favor de Seleccionar", "")
        If CAJERA = 0 Then
            LLAMAEMPLEADO()
        End If
        If TXTCLI.Text = "" Then
            BDEjecutarSql("EXEC SPRECALCULAADEUDOS '" + frmPrincipal.SucursalBase + "'", frmPrincipal.CadenaConexion)
            frmClsBusqueda.BUSCAR("select CLAVE,NOMBRE,TOTALDEBE TOTALADEUDO FROM  CLIENTESCONADEUDO WHERE TIENDA='" + frmPrincipal.SucursalBase + "' and TOTALDEBE>0 ", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda Clientes con Adeudo", "Nombre del Cliente", "Clientes con Adeudo", 1, frmPrincipal.CadenaConexion, True)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                TXTCLI.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
                CARGADATOS()
            End If
        Else
            CARGADATOS()
        End If
    End Sub
    Private Sub LLAMAEMPLEADO()
        CARGANOTA()
        Me.Opacity = 25
        Dim VNV As New frmEntrarCaja
        VNV.ShowDialog()
        If VNV.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTNOTA.Text = CARGANOTA.ToString
            NOMCAJERA = VNV.NOMBRE
            CAJERA = VNV.CAJERA
            NOCAJA = 1

            Me.Opacity = 100
            CHECATABLA()
            Me.Text = "Abonos /  Pagos de Notas de Créditos. " + frmPrincipal.NombreComun + " Caja # " + NOCAJA.ToString + " Cajera: " + NOMCAJERA

        Else
            Me.Close()
        End If
    End Sub
    'Public Sub MOSTRAR(ByVal CLACLI As String)
    '    TXTCLI.Text = CLACLI
    '    CARGADATOS()
    '    Me.ShowDialog()
    'End Sub
    Public Sub MOSTRAR(ByVal VCAJA As Integer, ByVal VNOMCAJERA As String, ByVal VCLACAJERA As Integer, ByVal Cliente As String)
        NOCAJA = VCAJA
        CAJERA = VCLACAJERA
        NOMCAJERA = VNOMCAJERA
        Me.Text = "Abonos /  Pagos de Notas de Créditos. " + frmPrincipal.NombreComun + " Caja # " + NOCAJA.ToString + " Cajera: " + NOMCAJERA
        If Cliente = "0" Then
            TXTCLI.Text = ""
        Else
            TXTCLI.Text = Cliente
        End If
        Me.ShowDialog()
    End Sub
    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        'frmClsBusqueda.BUSCAR("select N.CLIENTE CLAVE,C.NOMBRE CLIENTE,N.NOTA,N.TOTAL,N.FECHA,RESTA=(N.TOTAL-DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)),TOTALDEBE = DBO.TOTALDEBECLIENTE(N.TIENDA, N.CLIENTE) FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON N.TIENDA=C.TIENDA AND N.CLIENTE=C.CLAVE", " WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND C.NOMBRE", " AND N.PAGADO=0 ORDER BY N.FECHA,N.CLIENTE", "Búsqueda de Notas de Crédito", "Nombre del Cliente", "Cuentas que se Deben", 0, frmPrincipal.CadenaConexion, True)
        BDEjecutarSql("EXEC SPRECALCULAADEUDOS '" + frmPrincipal.SucursalBase + "'", frmPrincipal.CadenaConexion)
        frmClsBusqueda.BUSCAR("select CLAVE,NOMBRE,TOTALDEBE TOTALADEUDO FROM  CLIENTESCONADEUDO WHERE TIENDA='" + frmPrincipal.SucursalBase + "' and TOTALDEBE>0 ", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda Clientes con Adeudo", "Nombre del Cliente", "Clientes con Adeudo", 1, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCLI.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            CARGADATOS()
        End If
    End Sub
    Private Sub CARGACLIENTE(ByVal NOTA As String)
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        TRPP = 0
        Dim SQL As New SqlClient.SqlCommand("SELECT C.CLAVE,C.NOMBRE,DBO.TOTALDEBECLIENTE('" + frmPrincipal.SucursalBase + "', C.CLAVE) FROM CLIENTES C WHERE C.TIENDA='" + frmPrincipal.SucursalBase + "' AND C.CLAVE='" + NOTA + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            CLACLI = LEC(0)
            NOMCLI = LEC(1)
            TRPP = LEC(2)

        End If
        LEC.Close()
        SQL.Dispose()
        LBLNCLI.Text = NOMCLI
        LBLTRPP.Text = FormatNumber(TRPP, 2).ToString
    End Sub
    Private Function PAGADO() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT PAGADO FROM NOTASDEVENTACREDITO WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND NOTA=" + TXTCLI.Text + "", frmPrincipal.CONX)
        SQL.CommandTimeout = 300
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            If CType(LEC(0), Boolean) Then
                LEC.Close()
                Return True
                Exit Function
            Else
                LEC.Close()
                Return False
            End If
        Else
            LEC.Close()
        End If
        LEC.Close()
        SQL.Dispose()
    End Function
    Private Function DgvCellEstilo(ByVal FONDO As Integer, ByVal FUENTE As Integer) As DataGridViewCellStyle
        Dim RESTILO As New DataGridViewCellStyle
        RESTILO.BackColor = CC.ConvertFromString(FONDO)
        RESTILO.ForeColor = CC.ConvertFromString(FUENTE)
        Return RESTILO
    End Function
    Private Sub CARGADATOS()
        'If PAGADO() Then
        '    MessageBox.Show("Esta nota ya se encuentra pagada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '    Exit Sub
        'End If
        ACTIVAR(False)
        Dim query As String
        query = "SELECT N.Nota,N.Total,(N.TOTAL-(SELECT DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))[Resta por Pagar],CONVERT(VARCHAR(10),N.FECHA,103)Fecha,convert(varchar(10),DATEADD(dd,C.DIASCREDITO,N.FECHA),103) [Fecha de Vencimiento],C.DIASCREDITO [Dias de Credito],[Dias Vencido]=DATEDIFF(dd,N.FECHA,GETDATE())-C.DIASCREDITO,DBO.FOLIOFAC('" + frmPrincipal.Serie + "',N.NOTA)Factura,CONVERT(BIT,0)Abonar,CONVERT(NUMERIC(15,2),0.00)ABONO,CONVERT(NUMERIC(15,2),0.00)RESTA FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE AND C.TIENDA=N.TIENDA WHERE N.PAGADO = 0 AND N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.CLIENTE='" + TXTCLI.Text + "' AND (N.TOTAL-(SELECT DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))>0 GROUP BY N.NOTA,N.FECHA,C.DIASCREDITO,N.TOTAL,N.TIENDA"
        DGV.DataSource = BDLlenatabla(query, frmPrincipal.CadenaConexion)
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        DGV.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        DGV.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).ReadOnly = True
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(3).ReadOnly = True
        DGV.Columns(4).ReadOnly = True
        DGV.Columns(5).ReadOnly = True
        DGV.Columns(6).ReadOnly = True
        DGV.Columns(7).ReadOnly = True
        DGV.Columns(10).ReadOnly = True

        Dim TOT As Double
        TOT = 0
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            TOT = TOT + DGV.Item(2, X).Value
        Next
        TXTTOT.Text = FormatNumber(TOT, 2).ToString
        If DGV.Rows.Count <= 0 Then
            ACTIVAR(True)
            Exit Sub
        End If



        CARGACLIENTE(TXTCLI.Text)
        RESTAPORPAGAR()

        For Each Row As DataGridViewRow In DGV.Rows
            For X = 0 To DGV.Rows.Count - 1
                If DGV.Item(6, X).Value > DGV.Item(5, X).Value Then
                    DGV.Item(6, X).Style = DgvCellEstilo(-65536, -1)
                End If
            Next
        Next
    End Sub
    Private Sub CHECATABLA()
        Try
            Dim X As Integer
            Dim TA As Double
            TA = 0

            For X = 0 To DGV.Rows.Count - 1
                TA += DGV.Item(9, X).Value
            Next
            TXTABONO.Text = FormatNumber(TA.ToString, 2)
            LBLTP.Text = FormatNumber((TA).ToString, 2)
            If CHKCE.Checked Then
                LBLTP.Text = FormatNumber((TA * 1.02).ToString, 2)
            End If
        Catch ex As Exception
            TXTABONO.Text = "0.00"
        End Try
        RESTAPORPAGAR()
    End Sub
    Private Function VERIFICAMARCADO() As Boolean
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(8, X).Value = True Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Function VERIFICACANTIDADES(ByVal TIPO As Integer) As Boolean
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(8, X).Value = True Then
                If DGV.Item(10, X).Value < 0 Then
                    DGV.CurrentCell = DGV.Rows(X).Cells(8)
                    Return False
                End If
            End If
        Next
        If TIPO = 2 Then
            For X = 0 To DGV.Rows.Count - 1
                If DGV.Item(8, X).Value = True Then
                    If DGV.Item(9, X).Value <= 0 Then
                        DGV.CurrentCell = DGV.Rows(X).Cells(8)
                        Return False
                    End If
                End If
            Next
        End If
        Return True
    End Function
    Private Sub CARGAABONOS(ByVal NOTA As Integer)
        Dim query As String
        query = "SELECT ABONO,SALDO,FECHA,NotaVenta [Nota de Venta] FROM ABONOSCREDITOS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND NOTA=" + NOTA.ToString
        DGV2.DataSource = BDLlenatabla(query, frmPrincipal.CadenaConexion)
        'DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTCLI.Enabled = V
        BTNBUSCAR.Enabled = V
        BTNGUARDAR.Enabled = Not V
        TXTABONO.Enabled = Not V
        CBTP.Enabled = Not V
        LBLNCLI.Visible = Not V
        LBLTRPP.Visible = Not V
        BTNCONSUMO.Enabled = Not V
        RBAC.Enabled = Not V
        RBAN.Enabled = Not V
        If V Then
            DGV.DataSource = Nothing
            DGV2.DataSource = Nothing
            TXTABONO.Text = "0"
            TXTRESTA.Text = "0.00"
            TXTTOT.Text = "0.00"
        End If
    End Sub
    Dim RESTA As Double
    Private Function RESTAPORPAGAR() As Double

        Dim TOTAL, ABONOS As Double
        If RBAN.Checked Then
            Try
                TOTAL = CType(TXTTOT.Text, Double)
            Catch ex As Exception
                TOTAL = 0
            End Try
        Else
            Try
                TOTAL = CType(LBLTRPP.Text, Double)
            Catch ex As Exception
                TOTAL = 0
            End Try
        End If


        'Dim X As Integer
        'ABONOS = 0
        'For X = 0 To DGV2.Rows.Count - 1
        '    ABONOS = ABONOS + DGV2.Item(0, X).Value
        'Next
        Dim ULTIMOABONO As Double
        ULTIMOABONO = 0
        Try
            ULTIMOABONO = CType(TXTABONO.Text, Double)
        Catch ex As Exception

        End Try
        ABONOS = ULTIMOABONO
        If ABONOS >= TOTAL And TOTAL > 0 Then
            TXTRESTA.Text = "0"
            Return 0
        End If
        TXTRESTA.Text = FormatNumber((TOTAL - ABONOS), 2).ToString
        RESTA = FormatNumber((TOTAL - ABONOS), 2).ToString
        Return TOTAL - ABONOS
    End Function

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
    End Sub

    Private Sub TXTNOTA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLI.KeyPress, TXTABONO.KeyPress
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

    Private Sub TXTABONO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsPunctuation(e.KeyChar) Then
            e.Handled = False
        End If
        If e.KeyChar = Chr(13) Then
            BTNGUARDAR.Focus()
        End If
    End Sub

    Private Sub TXTABONO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTABONO.TextChanged
        RESTAPORPAGAR()
    End Sub

    Private Sub GUARDAPAGOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim LN As Integer
        LN = CARGANOTA()
        Dim TP As Double

        'Dim SQLCRP As New SqlClient.SqlCommand
        'SQLCRP.Connection = frmPrincipal.CONX
        'SQLCRP.CommandType = CommandType.StoredProcedure

        'SQLCRP.CommandText = "SPFACTURACOBRANZA"
        'SQLCRP.Parameters.Add("@TI", SqlDbType.VarChar)
        'SQLCRP.Parameters.Add("@NOTA", SqlDbType.Int)
        'SQLCRP.Parameters.Add("@AB", SqlDbType.Float)
        'SQLCRP.Parameters.Add("@SALDO", SqlDbType.Float)
        'SQLCRP.Parameters.Add("@USU", SqlDbType.VarChar)
        'SQLCRP.Parameters.Add("@NOTAVENTA", SqlDbType.Int)

        Dim SQLPAGO As New SqlClient.SqlCommand
        SQLPAGO.Connection = frmPrincipal.CONX
        SQLPAGO.CommandType = CommandType.StoredProcedure

        SQLPAGO.CommandText = "SPABONOS"
        SQLPAGO.Parameters.Add("@TI", SqlDbType.VarChar)
        SQLPAGO.Parameters.Add("@NOTA", SqlDbType.Int)
        SQLPAGO.Parameters.Add("@AB", SqlDbType.Float)
        SQLPAGO.Parameters.Add("@SALDO", SqlDbType.Float)
        SQLPAGO.Parameters.Add("@USU", SqlDbType.VarChar)
        SQLPAGO.Parameters.Add("@NOTAVENTA", SqlDbType.Int)

        Dim SQLTCOB As New SqlClient.SqlCommand("DELETE FROM TTEMPCOBRANZA WHERE TIENDA='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
        SQLTCOB.ExecuteNonQuery()

        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(8, X).Value = True Then
                LN = CARGANOTA()
                SQLPAGO.Parameters("@TI").Value = frmPrincipal.SucursalBase
                SQLPAGO.Parameters("@NOTA").Value = DGV.Item(0, X).Value
                SQLPAGO.Parameters("@AB").Value = DGV.Item(9, X).Value
                SQLPAGO.Parameters("@SALDO").Value = DGV.Item(10, X).Value
                SQLPAGO.Parameters("@USU").Value = frmPrincipal.Usuario
                SQLPAGO.Parameters("@NOTAVENTA").Value = LN
                SQLPAGO.ExecuteNonQuery()

                'SQLCRP.Parameters("@TI").Value = frmPrincipal.SucursalBase
                'SQLCRP.Parameters("@NOTA").Value = DGV.Item(0, X).Value
                'SQLCRP.Parameters("@AB").Value = DGV.Item(9, X).Value
                'SQLCRP.Parameters("@SALDO").Value = DGV.Item(10, X).Value
                'SQLCRP.Parameters("@USU").Value = frmPrincipal.Usuario
                'SQLCRP.Parameters("@NOTAVENTA").Value = LN

                TP = DGV.Item(9, X).Value
                'If CHKCE.Checked Then
                '    TP = DGV.Item(9, X).Value * 1.02
                'End If
                GUARDANOTA(TP, DGV.Item(0, X).Value, DGV.Item(7, X).Value.ToString)
                ''SQLPAGO.ExecuteNonQuery()

            End If
        Next

        Try
            Dim SQLCRP As New SqlClient.SqlCommand("SPFACTURAPAGO", frmPrincipal.CONX)
            SQLCRP.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
            SQLCRP.CommandType = CommandType.StoredProcedure
            SQLCRP.CommandTimeout = 300
            SQLCRP.ExecuteNonQuery()
        Catch ex As Exception

        End Try

        'OPMsgOK("Abono(s) realizados Correctamente")

        IMPRIMIRNOTA()
    End Sub
    Private Function CARGANOTA() As Integer
        'Try
        If Not frmPrincipal.CHECACONX() Then
            Exit Function
        End If
        Dim NUM As Integer
        NUM = 1
        Dim SQLMOV As New SqlClient.SqlCommand("SELECT DBO.SIGUIENTENOTACOBRANZAPRO('" + frmPrincipal.SucursalBase + "')", frmPrincipal.CONX)
        SQLMOV.CommandTimeout = 300
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
        'Catch ex As Exception
        '    Me.Close()
        'End Try
    End Function
    Dim LNOTAS As New List(Of String)
    Private Sub GUARDANOTA(ByVal GUARDAABONO As Double, ByVal NOTACREDITO As String, ByVal FACTURA As String)

        Dim LANOTA As Integer
        LANOTA = CARGANOTA()
        TXTNOTA.Text = LANOTA.ToString


        Dim TP As Integer
        TP = LTP(CBTP.SelectedIndex)
        If TP = 2 Then
            If frmPrincipal.PagoTarjeta = False Then
                MessageBox.Show("Por el momento el pago con tarjeta ha sido desactivado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim SQLTCOB As New SqlClient.SqlCommand("INSERT INTO TTEMPCOBRANZA (TIENDA,NOTA) VALUES ('" + frmPrincipal.SucursalBase + "','" + LANOTA.ToString + "')", frmPrincipal.CONX)
        SQLTCOB.ExecuteNonQuery()
        'Dim SQLGUARDA1 As New SqlClient.SqlCommand("INSERT INTO NOTASDEVENTA(TIENDA,NOTA,TOTAL,ESTADO,NOCAJA,CAJERA,TIPOPAGO,FECHA,CLIENTE,OBSERVACION) VALUES (@TI,@NOTA,@TOT,@EDO,@NOCAJA,@EMP,@TP,GETDATE(),@CLI,@OBS)", frmPrincipal.CONX)
        'SQLGUARDA1.CommandTimeout = 300
        'SQLGUARDA1.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        'SQLGUARDA1.Parameters.Add("@CLI", SqlDbType.VarChar).Value = TXTCLI.Text
        'SQLGUARDA1.Parameters.Add("@OBS", SqlDbType.VarChar).Value = "ABONO/ PAGO NOTA CREDITO: " + NOTACREDITO + ". FACTURA: " + FACTURA + ". TIPO DE PAGO :" + CBTP.Text
        'SQLGUARDA1.Parameters.Add("@NOTA", SqlDbType.Int).Value = LANOTA
        'SQLGUARDA1.Parameters.Add("@TOT", SqlDbType.Float).Value = GUARDAABONO
        'SQLGUARDA1.Parameters.Add("@EMP", SqlDbType.Int).Value = 1
        'SQLGUARDA1.Parameters.Add("@EDO", SqlDbType.Int).Value = 1
        'SQLGUARDA1.Parameters.Add("@NOCAJA", SqlDbType.Int).Value = 1
        'SQLGUARDA1.Parameters.Add("@TP", SqlDbType.Int).Value = TP
        'SQLGUARDA1.ExecuteNonQuery()
        ''TXTNOTA.Text = LANOTA.ToString
        'SQLGUARDA1.Dispose()

        'Dim SQLDETALLES As New SqlClient.SqlCommand("INSERT INTO DETALLENOTASDEVENTA(TIENDA,NOTA,PRODUCTO,CANTIDAD,TOTAL,REGISTRO,DESCUENTO) VALUES (@TI,@NOTA,@PROD,@CANT,@TOT,@REG,@DES)", frmPrincipal.CONX)
        'SQLDETALLES.CommandTimeout = 300
        'SQLDETALLES.Parameters.Add("@TI", SqlDbType.VarChar)
        'SQLDETALLES.Parameters.Add("@NOTA", SqlDbType.VarChar)
        'SQLDETALLES.Parameters.Add("@PROD", SqlDbType.VarChar)
        'SQLDETALLES.Parameters.Add("@CANT", SqlDbType.Float)
        'SQLDETALLES.Parameters.Add("@TOT", SqlDbType.Float)
        'SQLDETALLES.Parameters.Add("@DES", SqlDbType.Float)
        'SQLDETALLES.Parameters.Add("@REG", SqlDbType.VarChar)
        'SQLDETALLES.CommandTimeout = 300
        'SQLDETALLES.Parameters("@TI").Value = frmPrincipal.SucursalBase
        'SQLDETALLES.Parameters("@NOTA").Value = LANOTA

        'SQLDETALLES.Parameters("@PROD").Value = "CREDITO"
        'SQLDETALLES.Parameters("@CANT").Value = 1
        'SQLDETALLES.Parameters("@TOT").Value = GUARDAABONO
        'SQLDETALLES.Parameters("@DES").Value = 0
        'SQLDETALLES.Parameters("@REG").Value = 0
        'SQLDETALLES.ExecuteNonQuery()
        'SQLDETALLES.Dispose()
        'IMPRIMIRNOTA(LANOTA)


        Dim SQLGUARDA1 As New SqlClient.SqlCommand("INSERT INTO NOTASCOBRANZAPRO(TIENDA,NOTA,TOTAL,NOCAJA,CAJERA,TIPOPAGO,FECHA,CLIENTE,BANCO,REF,AUT,TIPOTARJETA) VALUES (@TI,@NOTA,@TOT,@NOCAJA,@EMP,@TP,GETDATE(),@CLI,@BAN,@REF,@AUT,@TT)", frmPrincipal.CONX)
        SQLGUARDA1.CommandTimeout = 300
        SQLGUARDA1.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQLGUARDA1.Parameters.Add("@CLI", SqlDbType.VarChar).Value = TXTCLI.Text
        SQLGUARDA1.Parameters.Add("@NOTA", SqlDbType.Int).Value = LANOTA
        SQLGUARDA1.Parameters.Add("@TOT", SqlDbType.Float).Value = GUARDAABONO
        SQLGUARDA1.Parameters.Add("@EMP", SqlDbType.VarChar).Value = CAJERA
        SQLGUARDA1.Parameters.Add("@EDO", SqlDbType.Int).Value = 1
        SQLGUARDA1.Parameters.Add("@NOCAJA", SqlDbType.Int).Value = 1
        SQLGUARDA1.Parameters.Add("@TP", SqlDbType.Int).Value = TP
        SQLGUARDA1.Parameters.Add("@FEC", SqlDbType.DateTime).Value = DTDE.Value

        SQLGUARDA1.Parameters.Add("@BAN", SqlDbType.Int).Value = 0
        'If CBTP.SelectedIndex = 1 Or CBTP.SelectedIndex = 3 Or CBTP.SelectedIndex = 4 Then
        '    SQLGUARDA1.Parameters("@BAN").Value = LBAN(CBBANCO.SelectedIndex)
        'End If
        'SQLGUARDA1.Parameters.Add("@REF", SqlDbType.VarChar).Value = TXTDIG.Text
        'SQLGUARDA1.Parameters.Add("@AUT", SqlDbType.VarChar).Value = TXTAUT.Text

        SQLGUARDA1.Parameters.Add("@REF", SqlDbType.VarChar).Value = ""
        SQLGUARDA1.Parameters.Add("@AUT", SqlDbType.VarChar).Value = ""
        SQLGUARDA1.Parameters.Add("@TT", SqlDbType.Int)
        SQLGUARDA1.Parameters("@TT").Value = 0
        'If TP = 2 Then
        '    If RB1.Checked Then
        '        SQLGUARDA1.Parameters("@TT").Value = 1
        '    Else
        '        SQLGUARDA1.Parameters("@TT").Value = 2
        '    End If
        'Else
        '    SQLGUARDA1.Parameters("@TT").Value = 0
        'End If
        SQLGUARDA1.ExecuteNonQuery()
        'TXTNOTA.Text = LANOTA.ToString
        SQLGUARDA1.Dispose()
        LNOTAS.Add(LANOTA)

    End Sub
    Private Function IMPRIMIRNOTA() As Boolean
        'Try
        frmPrincipal.CHECACONX()
        'Dim QUER As String
        'QUER = "SELECT CL.NOMBRE CLIENTE,RESTAPORPAGAR=DBO.TOTALDEBECLIENTE(N.TIENDA,N.CLIENTE),S.NOMBREFISCAL,D.NOTA,D.PRODUCTO CODIGO,P.NOMBRECORTO PRODUCTO,D.CANTIDAD,P.PRECIO,D.TOTAL,SUBTOTAL=(D.TOTAL/(1+" + frmPrincipal.IVA.ToString + ")),IVA=dbo.ivacredito4('" + frmPrincipal.SucursalBase + "','" + LANOTA.ToString + "',D.TOTAL),E.NOMBRE EMPLEADO,N.FECHA,S.DIRECCION,S.CIUDAD,S.RFC,S.TELEFONO,N.NOCAJA,TIPO='NOTA',VNOM='',VUNI='',D.DESCUENTO,S.COMENTARIO1,S.COMENTARIO2,CL.TELEFONO TEL,CL.DIRECCION DIR,CR.RFC R,N.OBSERVACION  FROM DETALLENOTASDEVENTA D INNER JOIN TIENDAS S ON D.TIENDA=S.CLAVE INNER JOIN PRODUCTOS P  ON D.PRODUCTO=P.CLAVE INNER JOIN NOTASDEVENTA N   ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA INNER JOIN EMPLEADOS E   ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE  INNER JOIN CLIENTES CL  ON CL.CLAVE=N.CLIENTE AND N.TIENDA=CL.TIENDA left JOIN CLIENTERFC CR ON CR.CLIENTE=CL.CLAVE AND CL.TIENDA=CR.TIENDA AND CR.REGISTRO=0 WHERE S.CLAVE='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=1 AND N.NOTA=" + LANOTA.ToString + "   "
        'Dim REPI As New rptTicketAbono
        ''Dim CI As New clsImprimir
        ''CI.IMPRIMIR2(REPI, QUER, 1, frmPrincipal.CadenaConexion)
        'IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), 1, "")

        'Catch ex As Exception
        '    Dim xyz As Short
        '    xyz = MessageBox.Show("No se imprimió la nota, ¿Desea volver a intentar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        '    If xyz = 6 Then
        '        Return False
        '    Else
        '        MessageBox.Show("Utilice la opción reimprimir nota ( " + TXTCLI.Text + " )", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '        Return True
        '    End If
        'End Try

        Dim QUER As String
        QUER = "SELECT T.NOMBRECOMUN,T.DIRECCION,T.CIUDAD,T.RFC,N.TOTAL,N.NOTA NOCOBRANZA,N.NOCAJA,E.NOMBRE CAJERA,TP.NOMBRE TIPOPAGO,NC.TOTAL TOTALCREDITO,NC.FECHA,A.NOTA NOTACREDITO,A.ABONO,A.SALDO, DBO.TXTRECIBOF(A.TIENDA,A.NOTA)RECIBO, N.FECHA FECHAAPLICACION,TOTALADEUDO=DBO.TOTALDEBECLIENTE(N.TIENDA,N.CLIENTE) FROM TTEMPCOBRANZA Tc INNER JOIN NOTASCOBRANZAPRO N  ON N.TIENDA=Tc.TIENDA AND N.NOTA=Tc.NOTA INNER JOIN ABONOSCREDITOS  A  ON N.TIENDA=A.TIENDA  AND N.NOTA=A.NOTAVENTA   AND A.FECHA>='25/01/2018' INNER JOIN TIENDAS T ON A.TIENDA=T.CLAVE INNER JOIN EMPLEADOS E ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE INNER JOIN TIPOSPAGOS TP ON N.TIPOPAGO=TP.CLAVE INNER JOIN NOTASDEVENTACREDITO   NC  ON A.TIENDA=NC.TIENDA AND A.NOTA=NC.NOTA WHERE TC.TIENDA='" + frmPrincipal.SucursalBase + "'"
        If frmPrincipal.SucursalBase = "MZT" Then
            Dim REPI As New rptTicketAbonoMZT
            IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), My.Settings.CopiasAbono, "")
        Else
            Dim REPI As New rptTicketAbono
            IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), My.Settings.CopiasAbono, "")
        End If
        'Dim CI As New clsImprimir
        'CI.IMPRIMIR2(REPI, QUER, 1, frmPrincipal.CadenaConexion)

        Return True
    End Function

    Private Function IMPRIMIRNOTA(ByVal LANOTA As List(Of String)) As Boolean
        'Try
        frmPrincipal.CHECACONX()
        'Dim SEC As Boolean
        'SEC = False
        'Dim EXTRA As String
        'EXTRA = "("
        'Dim X As Integer
        'For X = 0 To LANOTA.Count - 1
        '    If SEC Then
        '        EXTRA += " OR N.NOTA='" + LANOTA(X) + "'"
        '    Else
        '        EXTRA += " N.NOTA='" + LANOTA(X) + "'"
        '        SEC = True
        '    End If
        'Next
        'EXTRA += ")"
        Dim QUER As String

        'QUER = "SELECT T.NOMBRECOMUN,T.DIRECCION,T.CIUDAD,T.RFC,N.TOTAL,N.NOTA NOCOBRANZA,N.NOCAJA,E.NOMBRE CAJERA,TP.NOMBRE TIPOPAGO,NC.TOTAL TOTALCREDITO,NC.FECHA,A.NOTA NOTACREDITO,A.ABONO,A.SALDO,DBO.TXTRECIBO(N.TIENDA,N.NOTA)RECIBO,N.FECHA FECHAAPLICACION FROM NOTASCOBRANZAPRO N INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE INNER JOIN EMPLEADOS E ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE INNER JOIN TIPOSPAGOS TP ON N.TIPOPAGO=TP.CLAVE INNER JOIN ABONOSCREDITOS A ON N.TIENDA=A.TIENDA AND N.NOTA=A.NOTAVENTA INNER JOIN NOTASDEVENTACREDITO NC ON A.TIENDA=NC.TIENDA AND A.NOTA=NC.NOTA  WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND " + EXTRA
        'Dim REPI As New rptTicketAbono
        'IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), 1, "")


        For X = 0 To LANOTA.Count - 1
            QUER = "SELECT T.NOMBRECOMUN,T.DIRECCION,T.CIUDAD,T.RFC,N.TOTAL,N.NOTA NOCOBRANZA,N.NOCAJA,E.NOMBRE CAJERA,TP.NOMBRE TIPOPAGO,NC.TOTAL TOTALCREDITO,NC.FECHA,A.NOTA NOTACREDITO,A.ABONO,A.SALDO,DBO.TXTRECIBO(N.TIENDA,N.NOTA)RECIBO,CL.NOMBRE+' '+CL.APE1+' '+CLAPE2 CLIENTE,N.FECHA FECHAAPLICACION,DBO.TOTALDEBECLIENTE (N.TIENDA,NC.CLIENTE)TOTALADEUDO  FROM NOTASCOBRANZAPRO N INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE INNER JOIN EMPLEADOS E ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE INNER JOIN TIPOSPAGOS TP ON N.TIPOPAGO=TP.CLAVE INNER JOIN ABONOSCREDITOS A ON N.TIENDA=A.TIENDA AND N.NOTA=A.NOTAVENTA INNER JOIN NOTASDEVENTACREDITO NC ON A.TIENDA=NC.TIENDA AND A.NOTA=NC.NOTA INNER JOIN CLIENTES C ON N.CLIENTE=C.CLAVE AND N.TIENDA=C.TIENDA  WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA=" + LANOTA(X) + " AND A.FECHA>='25/01/2018'"
            If frmPrincipal.SucursalBase = "MZT" Then
                Dim REPI As New rptTicketAbonoMZT
                IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), My.Settings.CopiasAbono, "")
            Else
                Dim REPI As New rptTicketAbono
                IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), My.Settings.CopiasAbono, "")
            End If

        Next
        Return True
    End Function
    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        If Not VERIFICAMARCADO() Then
            MessageBox.Show("Debe marcar casilla de Abonar para aplicar los Abonos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If Not VERIFICACANTIDADES(1) Then
            MessageBox.Show("Esta dando una abono mayor a su saldo en la nota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If Not VERIFICACANTIDADES(2) Then
            MessageBox.Show("Esta dando abono a una cantidad no válida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If CBTP.SelectedIndex = 0 Then
            MessageBox.Show("Debe seleccionar un tipo de pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If Not VALIDAR() Then
            MessageBox.Show("Se esta realizando pagos a ventas facturadas y no facturadas simultáneamente, no se permite continuar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        'Dim xyz As Short
        'xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        'If xyz <> 6 Then
        '    Exit Sub
        'End If
        LNOTAS.Clear()
        GUARDAPAGOS()
        'IMPRIMIRNOTA(LNOTAS)
        'MessageBox.Show("Abono(s) realizados Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        ACTIVAR(True)
        TXTNOTA.Text = CARGANOTA.ToString
        CBTP.SelectedIndex = 0
    End Sub

    Private Sub DGV_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        CARGAABONOS(DGV.Item(0, DGV.CurrentRow.Index).Value)
    End Sub

    Private Sub BTNCONSUMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCONSUMO.Click
        frmConsumidoNota.MOSTRAR(LBLNCLI.Text, LBLTRPP.Text, DGV.Item(0, DGV.CurrentRow.Index).Value)
    End Sub


    Private Sub DGV_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV.Sorted
        For Each Row As DataGridViewRow In DGV.Rows
            For X = 0 To DGV.Rows.Count - 1
                If DGV.Item(6, X).Value > DGV.Item(5, X).Value Then
                    DGV.Item(6, X).Style = DgvCellEstilo(-65536, -1)
                End If
            Next
        Next
    End Sub

    Private Sub DGV_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        DGV.Item(10, DGV.CurrentRow.Index).Value = ((DGV.Item(2, DGV.CurrentRow.Index).Value) - (DGV.Item(9, DGV.CurrentRow.Index).Value))
        Try
            CHECATABLA()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmAbonosCreditos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("select C.CLAVE CLAVE,C.NOMBRE CLIENTE,TOTALDEBE = DBO.TOTALDEBECLIENTE(C.TIENDA, C.CLAVE) FROM  CLIENTES C WHERE C.TIENDA='" + frmPrincipal.SucursalBase + "' and DBO.TOTALDEBECLIENTE(C.TIENDA, C.CLAVE)>0 ", " AND C.NOMBRE", " ORDER BY C.NOMBRE", "Búsqueda Clientes con Adeudo", "Nombre del Cliente", "Clientes con Adeuto", 1, frmPrincipal.CadenaConexion, True)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                TXTCLI.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
                CARGADATOS()
            End If
        End If
    End Sub

    Private Sub CBTP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBTP.SelectedIndexChanged
        If LTP(CBTP.SelectedIndex) = "2" Then
            CHKCE.Enabled = True
        Else
            CHKCE.Enabled = False
            CHKCE.Checked = False
        End If
    End Sub

    Private Sub CHKCE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKCE.CheckedChanged
        CHECATABLA()
    End Sub
    Private Function VALIDAR() As Boolean
        Dim F, S As Integer
        F = 0
        S = 0
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(8, X).Value = True Then
                If DGV.Item(7, X).Value = "N/A" Then
                    S += 1
                Else
                    F += 1
                End If
            End If
        Next
        If F > 0 And S > 0 Then

            Return False
        Else
            Return True
        End If
    End Function
    Private Sub BTNFACTURAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNFACTURAR.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("Favor de cargar información", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If DGV.Item(7, DGV.CurrentRow.Index).Value <> "N/A" Then
            MessageBox.Show("Nota ya facturada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Dim RFCCLI As String
            RFCCLI = BDExtraeUnDato("SELECT RFC FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE='" + TXTCLI.Text + "'", frmPrincipal.CadenaConexion)
            Dim VF33 As New frmFacturar33
            VF33.MOSTRAR(RFCCLI, DGV.Item(0, DGV.CurrentRow.Index).Value, True)
            CARGADATOS()
        End If

    End Sub
End Class