Public Class frmNotaDeVenta
    Public NE As New Integer
    Dim NOMEMP As String
    Public META, TV As Double
    Dim TABLAPRIN As New DataTable
    Dim LISTANOAPARECE As New List(Of String)
    Dim NOHAY As Boolean
    Dim UNIDAD As String
    Dim EMPLEADO As Integer
    Dim VALENOMBRE, VALEUNIDAD As String
    Public CAJA As Integer
    Dim VALE, COMPRADO As Boolean
    Dim CLIENTEBASE As String
    Dim NOMBRECLIENTEBASE As String
    Dim RFCCLIENTE As String
    Public DTPRECIOSCLIENTES As New DataTable
    Dim LTP As New List(Of String)
    Dim FACTURAAUTOMATICA As Boolean
    Dim LBAN As New List(Of String)
    Dim CBBANCO As New ComboBox
    Private Sub frmNotaDeVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        VALE = False

        OPLlenaComboBox(CBBANCO, LBAN, "SELECT CLAVE,NOMBRE FROM BANCOSVENTA WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        LISTANOAPARECE.Clear()
        frmPrincipal.PRE.EliminarNota()
        TXTNOTA.Text = CARGANOTA.ToString
        LLAMAEMPLEADO()
        Me.Text = "Nota de venta. Atendido por.- " + NOMEMP
        CHECAPRODUCTOS()
        OPLlenaComboBox(CBTP, LTP, "SELECT CLAVE,NOMBRE FROM TIPOSPAGOS WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        'CBTP.SelectedIndex = 0
        TXTCOD.SelectAll()
        TXTCOD.Focus()
        FACTURAAUTOMATICA = False
        BTNCOBRAR.Enabled = False
        LBLPMIN.Visible = True
        LBLPMIN.BringToFront()
        'Dim mysize As New Size
        'mysize.Height = 762
        'mysize.Width = 1386
        'Me.Size = mysize
        'Me.StartPosition = FormStartPosition.CenterScreen
        LLAMACLIENTE(False)
    End Sub
    Private Sub LLAMACLIENTE(ByVal AbrirBusqueda As Boolean)
        CARGANOTA()
        FACTURAAUTOMATICA = False
        Me.Opacity = 25
        Dim VNV As New frmSeleccionaCliente
        VNV.Mostrar(AbrirBusqueda)
        If VNV.DialogResult = Windows.Forms.DialogResult.Yes Then
            CLIENTEBASE = VNV.CLIENTEBASE
            NOMBRECLIENTEBASE = VNV.NOMBRECLIENTEBASE
            RFCCLIENTE = VNV.RFCCLIENTEBASE
            FACTURAAUTOMATICA = VNV.FAUTO
            TXTNOTA.Text = CARGANOTA.ToString
            LBLNCLI.Text = NOMBRECLIENTEBASE
            If CLIENTEBASE = 0 Then
                BTNVALE.Enabled = False
            Else
                BTNVALE.Enabled = True
            End If
            DTPRECIOSCLIENTES.Clear()
            DTPRECIOSCLIENTES = BDLlenatabla("SELECT PRODUCTO,PRECIO,PPD FROM VPRECIOSCLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLIENTE='" + CLIENTEBASE.ToString + "'", frmPrincipal.CadenaConexion)
            Me.Opacity = 100
            CHECATABLA()
            If CHECAADEUDO() Then
                frmAdeudoCliente.CHECAADEUDO(NOMBRECLIENTEBASE, CLIENTEBASE)
            End If
            DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
            ACOMODARDGV()
            DGV.Refresh()
            MARCAPRECIOCLIENTES()
            CHECATABLA()
            CHECAPRODUCTOS()
            If CLIENTEBASE = "0" Then

            Else
                If BUSCAR() Then
                    If My.Settings.mostrarbusqueda Then
                        BTNBUS.Focus()
                    End If
                End If
            End If

        Else
            Me.Close()
        End If
    End Sub

    Private Function CHECAADEUDO() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim QUERY As String
        QUERY = "SELECT N.Nota,(N.TOTAL-(SELECT DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))Adeudo FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE AND C.TIENDA=N.TIENDA WHERE N.PAGADO=0 AND DATEDIFF(dd,N.FECHA,GETDATE())>C.DIASCREDITO AND C.CLAVE='" + CLIENTEBASE + "' GROUP BY N.NOTA,N.FECHA,C.DIASCREDITO,N.TOTAL,N.TIENDA"
        Dim SQLSELECT As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)

        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            LECTOR.Close()
            Return True
        Else
            LECTOR.Close()
            Return False
        End If
    End Function

    Private Function DgvCellEstilo(ByVal FONDO As Color, ByVal FUENTE As Color) As DataGridViewCellStyle
        Dim RESTILO As New DataGridViewCellStyle
        RESTILO.BackColor = FONDO
        RESTILO.ForeColor = FUENTE
        Return RESTILO
    End Function


    Private Sub AGREGANOAPARECE(ByVal VALOR As String)
        LISTANOAPARECE.Add(VALOR)
    End Sub
    Dim FZ As DateTime
    Private Function HAYZ() As Boolean
        If Not frmPrincipal.CHECACONX() Then
            Return False
        End If

        Try
            Dim QUERY As String
            QUERY = "SELECT FECHAZ FROM CORTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + CAJA.ToString + ""
            Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
            Dim LEC As SqlClient.SqlDataReader
            LEC = SQL.ExecuteReader
            If LEC.Read Then
                FZ = LEC(0)
                LEC.Close()
            Else
                LEC.Close()
                MessageBox.Show("No se Puede Cobrar en esta Caja, No esta Correcta la Informacin, Favor de Comunicarse con DeIP", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            End If

            If FZ.Date < Now.Date Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show("Hubo un conflicto con las cajas favor de comunicarse con Structure", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Function
    Private Sub CargaExistenciaProducto(ByVal CODIGO As String)
        Dim query As String
        Try
            query = "SELECT SUM (I.CANTIDAD)  FROM INVPISOTIENDA I INNER JOIN LOTES L ON L.CLAVE=I.PRODUCTO INNER JOIN PRODUCTOS P ON P.CP=L.PRODUCTO WHERE I.TIENDA='" + frmPrincipal.SucursalBase + "' AND P.CLAVE='" + CODIGO + "' AND P.EMPRESA=" + frmPrincipal.Empresa + " "
            Dim SQLHAY As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
            Dim LECHAY As SqlClient.SqlDataReader
            LECHAY = SQLHAY.ExecuteReader
            If LECHAY.Read Then
                If LECHAY(0) Is DBNull.Value Then
                    LECHAY.Close()
                    'MessageBox.Show("No hay existencia del producto en el inventario de piso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    LBLEXIS.Text = 0
                    LBLEXIS.ForeColor = Color.Red

                Else
                    LBLEXIS.Text = FormatNumber(LECHAY(0), 2).ToString
                    LBLEXIS.ForeColor = Color.Green
                    LECHAY.Close()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function HAYENINVENTARIO(ByVal CODIGO As String) As Boolean
        If Not frmPrincipal.CHECACONX() Then
            Exit Function
        End If
        COMPRADO = False
        If Not CHECAAGREGADO(CODIGO) Then
            If OPMsgPreguntarSiNo("No hay existencia del producto en el inventario de piso, Desea realizar una compra?") Then
                MostrarCompraExpress(CODIGO)
            End If
        End If
        Return CHECAAGREGADO(CODIGO)

    End Function

    Private Sub LLAMAEMPLEADO()
        DESCEST = False
        CARGANOTA()
        Me.Opacity = 25
        Dim VNV As New frmEntrarCaja
        VNV.ShowDialog()
        If VNV.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTNOTA.Text = CARGANOTA.ToString
            NOMEMP = VNV.NOMBRE
            NE = VNV.CAJERA
            CAJA = 1

            Me.Opacity = 100
            CHECATABLA()
            Me.Text = "Nota de Venta. " + frmPrincipal.NombreComun + " Caja # " + CAJA.ToString + " Cajera: " + NOMEMP
            TXTCOD.Focus()
        Else
            Me.Close()
        End If
    End Sub
    Private Sub MARCAPRECIOCLIENTES()
        Dim X As Integer
        For X = 0 To DTPRECIOSCLIENTES.Rows.Count - 1
            For Each Row As DataGridViewRow In DGV.Rows
                If DTPRECIOSCLIENTES.Rows(X).Item(0).ToString = Row.Cells(0).Value Then
                    Row.Cells(0).Style = DgvCellEstilo(Color.BlueViolet, Color.Black)
                    Row.Cells(1).Style = DgvCellEstilo(Color.BlueViolet, Color.Black)
                    Row.Cells(2).Style = DgvCellEstilo(Color.BlueViolet, Color.Black)
                    Row.Cells(3).Style = DgvCellEstilo(Color.BlueViolet, Color.Black)
                    Row.Cells(4).Style = DgvCellEstilo(Color.BlueViolet, Color.Black)
                    Row.Cells(5).Style = DgvCellEstilo(Color.BlueViolet, Color.Black)

                    Row.Cells(6).Style = DgvCellFormatoNumerico()
                    Row.Cells(7).Style = DgvCellFormatoNumerico()
                Else

                End If
            Next
        Next
    End Sub
    Public Sub CHECATABLA()
        If frmPrincipal.PRE.ElementosAgregados.Rows.Count <= 0 Then
            TXTTOT.Text = 0
            TXTTOTTC.Text = 0
            'BTNQUITAR.Enabled = False
            BTNAGREGAR.Enabled = False
            BTNRESTAR.Enabled = False
        Else
            TXTTOT.Text = FormatNumber(frmPrincipal.PRE.Total, 2).ToString
            TXTTOTTC.Text = FormatNumber(frmPrincipal.PRE.TotalTar, 2).ToString
            'BTNQUITAR.Enabled = True
            BTNAGREGAR.Enabled = True
            BTNRESTAR.Enabled = True
            CHECACANTIDADES()
            MARCAPRECIOCLIENTES()
        End If

        If DGV.Rows.Count <= 0 Then
        Else
            'Dim CR As Integer
            'CR = DGV.Rows.Count - 1
            Try
                DGV.CurrentCell = DGV.Rows(DGV.Rows.Count - 1).Cells(2)
            Catch ex As Exception

            End Try
        End If
        LBLP.Text = DGV.Rows.Count
    End Sub
    Private Function CARGANOTA() As Integer
        'Try
        If Not frmPrincipal.CHECACONX() Then
            Exit Function
        End If
        Dim NUM As Integer
        NUM = 1
        Dim SQLMOV As New SqlClient.SqlCommand("SELECT DBO.SIGUIENTENOTA('" + frmPrincipal.SucursalBase + "')", frmPrincipal.CONX)
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
    Dim GRUPO As String
    Dim PMIN As Double
    Private Function CHECAPROD() As Boolean
        If Not frmPrincipal.CHECACONX() Then
            Return False
        End If
        NOHAY = True
        Dim GRU As Integer
        Dim query As String
        query = "SELECT P.NOMBRE,PRE.PRECIO,P.IMG,P.GRUPO,P.CP,DBO.ELULTIMOCOSTOPRODUCTOTI(P.CLAVE,'" + frmPrincipal.SucursalBase + "'),DBO.ULTIMOCAMBIOPRECIO('" + TXTCOD.Text + "') FROM PRODUCTOS P INNER JOIN PRECIOSSUCURSALES PRE ON PRE.TIENDA='" + frmPrincipal.SucursalBase + "' AND PRE.PRODUCTO=P.CLAVE WHERE P.CLAVE= '" + TXTCOD.Text + "' AND EMPRESA=" + frmPrincipal.Empresa + " AND ACTIVO=1 AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1)"
        Dim SQLCARGAPROD As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        Try
            LECTOR = SQLCARGAPROD.ExecuteReader
            If LECTOR.Read() Then
                LBLPRE.Text = "$" & LECTOR(1)
                LBLNOM.Text = LECTOR(0)
                PBIMG.ImageLocation = LECTOR(2)
                'INV = LECTOR(3)
                GRU = LECTOR(3)
                PMIN = LECTOR(5)
                LBLPMIN.Text = "$ " + LECTOR(5).ToString
                LBLFUC.Text = LECTOR(6).ToString
                LECTOR.Close()
                'If INV = True Then
                If HAYENINVENTARIO(TXTCOD.Text) Then
                Else
                    If COMPRADO Then
                        COMPRADO = False
                        If HAYENINVENTARIO(TXTCOD.Text) Then
                        Else
                            LBLEXIS.Text = "0" '' --> SI NO HAY K APAREZCA UN CERO NO??
                            LBLEXIS.ForeColor = Color.Red
                            MessageBox.Show("Este Código NO aparece en el inventario, favor de corregir el inventario lo antes posible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            LECTOR.Close()
                            NOHAY = False
                        End If
                    End If

                End If
                Return NOHAY
            Else
                LECTOR.Close()
                'MessageBox.Show("El codigo del producto NO existe en el sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'TXTCOD.Text = ""
                'TXTCOD.Focus()
                LECTOR.Close()
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("El codigo del producto NO existe en el sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TXTCOD.Text = ""
            TXTCOD.Focus()
            Return False
        End Try
    End Function
    Private Function CHECAPROD2() As Boolean
        If Not frmPrincipal.CHECACONX() Then
            Return False
        End If
        NOHAY = True
        Dim CB, COD, PES As String
        Dim CANT As Double
        CB = TXTCOD.Text
        Try
            COD = CB.Substring(0, 12)
            TXTCOD.Text = COD
        Catch ex As Exception

        End Try
        Dim GRU As Integer
        Dim query As String
        query = "SELECT P.NOMBRE,PRE.PRECIO,P.IMG,P.GRUPO,P.CP,DBO.ELULTIMOCOSTOPRODUCTOTI(P.CLAVE,'" + frmPrincipal.SucursalBase + "'),DBO.ULTIMOCAMBIOPRECIO('" + TXTCOD.Text + "') FROM PRODUCTOS P INNER JOIN PRECIOSSUCURSALES PRE ON PRE.TIENDA='" + frmPrincipal.SucursalBase + "' AND PRE.PRODUCTO=P.CLAVE WHERE P.CLAVE= '" + TXTCOD.Text + "' AND EMPRESA=" + frmPrincipal.Empresa + " AND ACTIVO=1 AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1)"
        Dim SQLCARGAPROD As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        Try
            LECTOR = SQLCARGAPROD.ExecuteReader
            If LECTOR.Read() Then
                LBLPRE.Text = "$" & LECTOR(1)
                LBLNOM.Text = LECTOR(0)
                PBIMG.ImageLocation = LECTOR(2)
                'INV = LECTOR(3)
                GRU = LECTOR(3)
                PMIN = LECTOR(5)
                LBLPMIN.Text = LECTOR(5).ToString
                LBLFUC.Text = LECTOR(6).ToString
                LECTOR.Close()
                'If INV = True Then
                If HAYENINVENTARIO(TXTCOD.Text) Then
                Else
                    If COMPRADO Then
                        COMPRADO = False
                        If HAYENINVENTARIO(TXTCOD.Text) Then
                        Else
                            LBLEXIS.Text = "0" '' --> SI NO HAY K APAREZCA UN CERO NO??
                            LBLEXIS.ForeColor = Color.Red
                            MessageBox.Show("Este Código NO aparece en el inventario, favor de corregir el inventario lo antes posible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            LECTOR.Close()
                            NOHAY = False
                        End If
                    End If

                End If
                Return NOHAY
            Else
                LECTOR.Close()
                MessageBox.Show("El codigo del producto NO existe en el sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                TXTCOD.Text = ""
                TXTCOD.Focus()
                LECTOR.Close()
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("El codigo del producto NO existe en el sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TXTCOD.Text = ""
            TXTCOD.Focus()
            Return False
        End Try
    End Function

    Private Sub TXTCANT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCANT.KeyPress
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
            TXTCOD.Focus()
        End If
    End Sub
    Private Sub CARGADATOS()
        DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
        ACOMODARDGV()
        CHECATABLA()
    End Sub

    'Public Sub AGREGAR(ByVal COD As String, ByVal NOM As String, ByVal CANT As Double, ByVal PRE As Double)

    '    ' Dim DOW As System.Data.DataRow = TABLAPRIN.NewRow

    '    Dim TOTAL As Double
    '    TOTAL = 0
    '    DGV.Rows.Add(1)
    '    Dim ITEMS As Integer
    '    ITEMS = DGV.Rows.Count - 1

    '    Try
    '        'TXTDES.Text = 0
    '        TOTAL = CANT * PRE
    '        DGV.Item(4, ITEMS).Value = 0
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        TXTCANT.Focus()
    '        Exit Sub
    '    End Try

    '    Try
    '        TOTAL = CANT * PRE

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        TXTCANT.Focus()
    '        Exit Sub
    '    End Try


    '    DGV.Item(0, ITEMS).Value = COD
    '    DGV.Item(1, ITEMS).Value = NOM
    '    DGV.Item(2, ITEMS).Value = CANT
    '    DGV.Item(3, ITEMS).Value = PRE
    '    DGV.Item(4, ITEMS).Value = TOTAL

    '    DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    'DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    '    DGV.Refresh()
    '    CHECATABLA()
    '    TXTCOD.Focus()
    '    TXTCOD.SelectAll()
    'End Sub
    Dim ACOD, ADES As String
    Dim APRE As Double
    Private Sub GUARDAR()
        Dim DESC As Double
        DESC = 0
        Try
            DESC = CType(TXTDESC.Text, Double)
        Catch ex As Exception

        End Try
        If TXTDESC.Text <> 0 Then
            frmPrincipal.PRE.PoneDescuento(DESC)
        End If


        Dim LANOTA As Integer
        If CHECAPRODUCTOS() = False Then
            MessageBox.Show("Debe agregar al menos 1 producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        'If Not CHECACANTIDADES() Then
        '    Exit Sub
        'End If

        Dim TP As Integer
        'TP = LTP(CBTP.SelectedIndex)
        'If TP = 2 Then
        '    If frmPrincipal.PagoTarjeta = False Then
        '        MessageBox.Show("Por el momento el pago con tarjeta ha sido desactivado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Exit Sub
        '    End If
        'End If

        'If LTP(CBTP.SelectedIndex) = 4 Then
        '    frmPagoMixto.MOSTRAR(CAJA, NE, NOMEMP)
        '    Dim VPM As New frmPagoMixto
        '    VPM.ShowDialog()
        '    Exit Sub
        'End If

        Dim AWA, AOYR, SERVADD, ASA As Boolean
        Dim BANCO, DIGITOS, AUTORIZACION, TIPOTARJETA, EFECTIVO, CAMBIO As String

        Dim VPAGOS As New frmPagos
        VPAGOS.MOSTRAR(TXTTOT.Text, LTP, CBTP, LBAN, CBBANCO, CHKSA.Checked)
        If VPAGOS.DialogResult = Windows.Forms.DialogResult.Yes Then
            BANCO = VPAGOS.BANCO
            DIGITOS = VPAGOS.DIGITOS
            AUTORIZACION = VPAGOS.AUTORIZACION
            TIPOTARJETA = VPAGOS.TIPOTARJETA
            EFECTIVO = VPAGOS.EFECTIVO
            CAMBIO = VPAGOS.CAMBIO
            TP = VPAGOS.TIPOPAGO
            AWA = 0
            SERVADD = VPAGOS.SERVADD
            AOYR = False
            ASA = VPAGOS.ASA
        Else
            Exit Sub
        End If

        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If

        If HAYZ() Then
            Dim xyz As Short
            xyz = MessageBox.Show("Se ha realizado un corte Z este día, la(s) nota(s) cobrada(s) aparecerán en el corte del día siguiente, Desea continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz <> 6 Then
                Exit Sub
            End If
            LANOTA = CARGANOTA()

            Dim SQLIMP As New SqlClient.SqlCommand("UPDATE NOTASDEVENTA SET ESTADO=1 WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND NOCAJA=" + CAJA.ToString + " AND ESTADO=3 AND FECHA>=(SELECT DBO.LAFECHA())", frmPrincipal.CONX)
            SQLIMP.CommandTimeout = 300
            SQLIMP.ExecuteNonQuery()
            SQLIMP.Dispose()

            Dim SQLGUARDA1 As New SqlClient.SqlCommand("INSERT INTO NOTASDEVENTA(TIENDA,NOTA,TOTAL,ESTADO,NOCAJA,CAJERA,TIPOPAGO,FECHA,CLIENTE,SA,PAGACON,CAMBIO,BANCO,REF,AUT) VALUES (@TI,@NOTA,@TOT,@EDO,@NOCAJA,@EMP,@TP,@FEC,@CLIE,@SA,@PAGA,@CAMBIO,@BAN,@REF,@AUT)", frmPrincipal.CONX)
            SQLGUARDA1.CommandTimeout = 300
            SQLGUARDA1.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
            SQLGUARDA1.Parameters.Add("@NOTA", SqlDbType.Int).Value = LANOTA
            If SERVADD Then
                SQLGUARDA1.Parameters.Add("@TOT", SqlDbType.Float).Value = frmPrincipal.PRE.TotalTar
            Else
                SQLGUARDA1.Parameters.Add("@TOT", SqlDbType.Float).Value = frmPrincipal.PRE.Total
            End If
            SQLGUARDA1.Parameters.Add("@EMP", SqlDbType.Int).Value = NE
            SQLGUARDA1.Parameters.Add("@EDO", SqlDbType.Int).Value = 1
            SQLGUARDA1.Parameters.Add("@NOCAJA", SqlDbType.Int).Value = CAJA.ToString
            SQLGUARDA1.Parameters.Add("@TP", SqlDbType.Int).Value = TP
            SQLGUARDA1.Parameters.Add("@CLIE", SqlDbType.Int).Value = CLIENTEBASE
            SQLGUARDA1.Parameters.Add("@FEC", SqlDbType.DateTime).Value = FZ.Date.AddHours(33)
            SQLGUARDA1.Parameters.Add("@SA", SqlDbType.Bit).Value = ASA

            SQLGUARDA1.Parameters.Add("@PAGA", SqlDbType.Float).Value = EFECTIVO
            SQLGUARDA1.Parameters.Add("@CAMBIO", SqlDbType.Float).Value = CAMBIO

            SQLGUARDA1.Parameters.Add("@BAN", SqlDbType.VarChar).Value = BANCO
            SQLGUARDA1.Parameters.Add("@REF", SqlDbType.VarChar).Value = DIGITOS
            SQLGUARDA1.Parameters.Add("@AUT", SqlDbType.VarChar).Value = AUTORIZACION

            If Now.DayOfWeek = DayOfWeek.Saturday Then
                SQLGUARDA1.Parameters("@FEC").Value = FZ.Date.AddHours(57)
            End If
            If Now.DayOfWeek = DayOfWeek.Sunday Then
                SQLGUARDA1.Parameters("@FEC").Value = FZ.Date.AddHours(33)
            End If

            SQLGUARDA1.ExecuteNonQuery()
            TXTNOTA.Text = LANOTA.ToString
            SQLGUARDA1.Dispose()
        Else

            LANOTA = CARGANOTA()
            Dim SQLGUARDA1 As New SqlClient.SqlCommand("INSERT INTO NOTASDEVENTA(TIENDA,NOTA,TOTAL,ESTADO,NOCAJA,CAJERA,TIPOPAGO,FECHA,CLIENTE,SA,PAGACON,CAMBIO,BANCO,REF,AUT) VALUES (@TI,@NOTA,@TOT,@EDO,@NOCAJA,@EMP,@TP,GETDATE(),@CLIE,@SA,@PAGA,@CAMBIO,@BAN,@REF,@AUT)", frmPrincipal.CONX)
            SQLGUARDA1.CommandTimeout = 300
            SQLGUARDA1.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
            SQLGUARDA1.Parameters.Add("@NOTA", SqlDbType.Int).Value = LANOTA
            If SERVADD Then
                SQLGUARDA1.Parameters.Add("@TOT", SqlDbType.Float).Value = frmPrincipal.PRE.TotalTar
            Else
                SQLGUARDA1.Parameters.Add("@TOT", SqlDbType.Float).Value = frmPrincipal.PRE.Total
            End If

            SQLGUARDA1.Parameters.Add("@EMP", SqlDbType.Int).Value = NE
            SQLGUARDA1.Parameters.Add("@EDO", SqlDbType.Int).Value = 1
            SQLGUARDA1.Parameters.Add("@NOCAJA", SqlDbType.Int).Value = CAJA.ToString
            SQLGUARDA1.Parameters.Add("@TP", SqlDbType.Int).Value = TP
            SQLGUARDA1.Parameters.Add("@CLIE", SqlDbType.Int).Value = CLIENTEBASE
            SQLGUARDA1.Parameters.Add("@SA", SqlDbType.Bit).Value = ASA
            SQLGUARDA1.Parameters.Add("@PAGA", SqlDbType.Float).Value = EFECTIVO
            SQLGUARDA1.Parameters.Add("@CAMBIO", SqlDbType.Float).Value = CAMBIO
            SQLGUARDA1.Parameters.Add("@BAN", SqlDbType.VarChar).Value = BANCO
            SQLGUARDA1.Parameters.Add("@REF", SqlDbType.VarChar).Value = DIGITOS
            SQLGUARDA1.Parameters.Add("@AUT", SqlDbType.VarChar).Value = AUTORIZACION
            SQLGUARDA1.CommandTimeout = 300
            SQLGUARDA1.ExecuteNonQuery()
            SQLGUARDA1.Dispose()
            TXTNOTA.Text = LANOTA.ToString
        End If

        If VALE = True Then
            Dim SQLDETALLES As New SqlClient.SqlCommand("INSERT INTO DETALLEVALESDEVENTA(TIENDA,VALE,PRODUCTO,CANTIDAD,TOTAL,REGISTRO,DESCUENTO) VALUES (@TI,@VALE,@PROD,@CANT,@TOT,@REG,@DES)", frmPrincipal.CONX)
            SQLDETALLES.CommandTimeout = 300
            SQLDETALLES.Parameters.Add("@TI", SqlDbType.VarChar)
            SQLDETALLES.Parameters.Add("@VALE", SqlDbType.VarChar)
            SQLDETALLES.Parameters.Add("@PROD", SqlDbType.VarChar)
            SQLDETALLES.Parameters.Add("@CANT", SqlDbType.Decimal)
            SQLDETALLES.Parameters.Add("@TOT", SqlDbType.Float)
            SQLDETALLES.Parameters.Add("@DES", SqlDbType.Float)
            SQLDETALLES.Parameters.Add("@REG", SqlDbType.VarChar)

            SQLDETALLES.Parameters("@TI").Value = frmPrincipal.SucursalBase
            SQLDETALLES.Parameters("@VALE").Value = LANOTA
            SQLDETALLES.CommandTimeout = 300
            Dim X As Integer
            For X = 0 To DGV.Rows.Count - 1
                SQLDETALLES.Parameters("@PROD").Value = DGV.Item(0, X).Value
                SQLDETALLES.Parameters("@CANT").Value = DGV.Item(2, X).Value
                If SERVADD Then
                    SQLDETALLES.Parameters("@TOT").Value = DGV.Item(5, X).Value * (1 + My.Settings.ServicioAdicional)
                Else
                    SQLDETALLES.Parameters("@TOT").Value = DGV.Item(5, X).Value
                End If
                SQLDETALLES.Parameters("@DES").Value = DGV.Item(3, X).Value
                SQLDETALLES.Parameters("@REG").Value = X
                SQLDETALLES.ExecuteNonQuery()
            Next
            'If CHKCE.Checked Then
            '    SQLDETALLES.Parameters("@PROD").Value = "777"
            '    SQLDETALLES.Parameters("@CANT").Value = "1"
            '    SQLDETALLES.Parameters("@DES").Value = "Servicios Adicionales"
            '    SQLDETALLES.Parameters("@TOT").Value = frmPrincipal.PRE.Total * 0.02
            '    SQLDETALLES.Parameters("@REG").Value = X + 1
            '    SQLDETALLES.ExecuteNonQuery()
            'End If
            SQLDETALLES.Dispose()
        Else
            Dim SQLDETALLES As New SqlClient.SqlCommand("INSERT INTO DETALLENOTASDEVENTA(TIENDA,NOTA,PRODUCTO,CANTIDAD,TOTAL,REGISTRO,DESCUENTO) VALUES (@TI,@NOTA,@PROD,@CANT,@TOT,@REG,@DES)", frmPrincipal.CONX)
            SQLDETALLES.CommandTimeout = 300
            SQLDETALLES.Parameters.Add("@TI", SqlDbType.VarChar)
            SQLDETALLES.Parameters.Add("@NOTA", SqlDbType.VarChar)
            SQLDETALLES.Parameters.Add("@PROD", SqlDbType.VarChar)
            SQLDETALLES.Parameters.Add("@CANT", SqlDbType.Float)
            SQLDETALLES.Parameters.Add("@TOT", SqlDbType.Float)
            SQLDETALLES.Parameters.Add("@DES", SqlDbType.Float)
            SQLDETALLES.Parameters.Add("@REG", SqlDbType.VarChar)
            SQLDETALLES.CommandTimeout = 300
            SQLDETALLES.Parameters("@TI").Value = frmPrincipal.SucursalBase
            SQLDETALLES.Parameters("@NOTA").Value = LANOTA
            Dim X As Integer
            For X = 0 To DGV.Rows.Count - 1
                Dim p As String
                Dim ca As Integer
                Dim t As Double
                p = DGV.Item(0, X).Value
                ca = DGV.Item(2, X).Value
                t = DGV.Item(4, X).Value
                SQLDETALLES.Parameters("@PROD").Value = DGV.Item(0, X).Value
                SQLDETALLES.Parameters("@CANT").Value = DGV.Item(2, X).Value
                If SERVADD Then
                    SQLDETALLES.Parameters("@TOT").Value = DGV.Item(5, X).Value * (1 + My.Settings.ServicioAdicional)
                Else
                    SQLDETALLES.Parameters("@TOT").Value = DGV.Item(5, X).Value
                End If

                SQLDETALLES.Parameters("@DES").Value = DGV.Item(3, X).Value
                SQLDETALLES.Parameters("@REG").Value = X
                SQLDETALLES.ExecuteNonQuery()
            Next
            'If CHKCE.Checked Then
            '    SQLDETALLES.Parameters("@PROD").Value = "777"
            '    SQLDETALLES.Parameters("@CANT").Value = "1"
            '    SQLDETALLES.Parameters("@DES").Value = 0
            '    SQLDETALLES.Parameters("@TOT").Value = frmPrincipal.PRE.Total * 0.02
            '    SQLDETALLES.Parameters("@REG").Value = X + 1
            '    SQLDETALLES.ExecuteNonQuery()
            'End If
            SQLDETALLES.Dispose()
        End If
        LISTANOAPARECE.Clear()


        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'DGV.Rows.Clear()
        'TXTCOD.Clear()
        'LBLPRE.Text = "0"
        'LBLEXIS.Text = "0"
        'TXTCANT.Text = "1"
        'TXTEFECTIVO.Text = "0.00"
        'LBLP.Text = "0"
        'LBLNOM.Text = "0"
        'CHECACANTIDADES()

        '    Exit Sub
        'End Try

        Dim SQLGC As New SqlClient.SqlCommand("UPDATE CORTES SET PAGA='" + CType(TXTEFECTIVO.Text, Double).ToString + "',CAMBIO='" + CType(TXTCAMBIO.Text, Double).ToString + "',TOTAL='" + CType(TXTEFECTIVO.Text, Double).ToString + "' WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + CAJA.ToString + "", frmPrincipal.CONX)
        SQLGC.CommandTimeout = 300
        SQLGC.ExecuteNonQuery()
        SQLGC.Dispose()

        frmPrincipal.CI.Abrir()
        IMPRIMIRNOTA(LANOTA)
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Try
            Dim SQLGUARDAR As New SqlClient.SqlCommand
            SQLGUARDAR.Connection = frmPrincipal.CONX
            SQLGUARDAR.CommandTimeout = 300
            SQLGUARDAR.CommandType = CommandType.StoredProcedure
            SQLGUARDAR.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
            SQLGUARDAR.Parameters.Add("@NOT", SqlDbType.Int).Value = LANOTA

            SQLGUARDAR.CommandText = "SPCAMBIOPRECIO"
            SQLGUARDAR.ExecuteNonQuery()
            SQLGUARDAR.Dispose()
        Catch ex As Exception
            MessageBox.Show("Error al modificar precios de clientes " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Dim SQLPRECIOSCLIENTES As New SqlClient.SqlCommand
            SQLPRECIOSCLIENTES.Connection = frmPrincipal.CONX
            SQLPRECIOSCLIENTES.CommandTimeout = 300
            SQLPRECIOSCLIENTES.CommandType = CommandType.StoredProcedure
            SQLPRECIOSCLIENTES.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
            SQLPRECIOSCLIENTES.Parameters.Add("@NOTA", SqlDbType.Int).Value = LANOTA
            SQLPRECIOSCLIENTES.Parameters.Add("@CRE", SqlDbType.Bit).Value = 0

            SQLPRECIOSCLIENTES.CommandText = "SPPRECIOSCLIENTESVENTA"
            SQLPRECIOSCLIENTES.ExecuteNonQuery()
            SQLPRECIOSCLIENTES.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        frmCambio.CAMBIO(CType(CAMBIO, Double))
        frmPrincipal.PRE.EliminarNota()
        TXTNOTA.Text = LANOTA.ToString
        If FACTURAAUTOMATICA Then
            Try
                Dim VF33 As New frmFacturar33
                VF33.MOSTRAR(RFCCLIENTE, LANOTA.ToString, False)
            Catch ex As Exception
                MessageBox.Show("Error al cargar la ventana de facturación de forma automática", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            If CHKSD.Checked Then
                Try
                    Dim VF33 As New frmFacturar33
                    VF33.MOSTRAR(RFCCLIENTE, LANOTA.ToString, False)
                Catch ex As Exception
                    MessageBox.Show("Error al cargar la ventana de facturación de forma automática", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If

        DGV.Refresh()
        TXTCOD.Clear()
        LBLPRE.Text = "0"
        LBLEXIS.Text = "0"
        TXTCANT.Text = "1"
        LBLP.Text = "0"
        Dim VSR As Double
        VSR = CHECARESGUARDO()
        If VSR >= My.Settings.Resguardo Then
            frmPrincipal.VentaSinResguardo += 1
            MessageBox.Show("Se le solicita que se realice un RESGUARDO", " A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        CHKSD.Checked = False
        CHKSA.Checked = False
        CHECAPRODUCTOS()
        TXTEFECTIVO.Text = "0"
        TXTCOD.Focus()
        TXTNOTA.Text = CARGANOTA()
        VALE = False
        CBTP.SelectedIndex = 0
        TXTDESC.Text = 0
        LLAMACLIENTE(False)
    End Sub
    Private Function CHECARESGUARDO() As Double
        If Not frmPrincipal.CHECACONX Then
            Return 0
        End If
        Dim REG As Double
        REG = 0
        Dim SQL As New SqlClient.SqlCommand("SELECT DBO.VENTASINRESGUARDAR('" + frmPrincipal.SucursalBase + "','" + CAJA.ToString + "')", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            REG = LEC(0)
        End If
        LEC.Close()
        SQL.Dispose()
        Return REG
    End Function
    Private Function IMPRIMIRNOTA(ByVal LANOTA As Integer) As Boolean
        Try
            frmPrincipal.CHECACONX()
            Dim QUER As String
            QUER = "SELECT S.NOMBRECOMUN,S.NOMBREFISCAL,D.NOTA,D.PRODUCTO CODIGO,P.NOMBRECORTO PRODUCTO,D.CANTIDAD,PRECIO=DBO.DIVISIONSINCERO(D.TOTAL,D.CANTIDAD),D.TOTAL,SUBTOTAL=DBO.ELSUBTOTAL(D.PRODUCTO,D.TOTAL),IVA=DBO.ELIVA(D.PRODUCTO,D.TOTAL),CONVERT(VARCHAR(10),E.CLAVE) EMPLEADO,N.FECHA,S.DIRECCION,S.CIUDAD,S.RFC,S.TELEFONO,N.PAGACON PAGA,N.CAMBIO,N.NOCAJA,TIPO='NOTA',VUNI='',D.DESCUENTO,CL.NOMBRE NOMBRE,S.COMENTARIO1,S.COMENTARIO2,S.COMENTARIO3,S.CP,N.REF TEL,CL.DIRECCION DIR,N.AUT R ,TP.NOMBRE TIPOPAGO,N.CLIENTE CCLIENTE,REGIMEN='" + frmPrincipal.Regimen + "',VNOM=S.COLONIA FROM DETALLENOTASDEVENTA D INNER JOIN TIENDAS S ON D.TIENDA=S.CLAVE INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE INNER JOIN NOTASDEVENTA N ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA INNER JOIN EMPLEADOS E ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE INNER JOIN CORTES C ON N.TIENDA=C.TIENDA AND N.NOCAJA=C.CAJA INNER JOIN CLIENTES CL ON CL.CLAVE=N.CLIENTE AND CL.TIENDA=N.TIENDA INNER JOIN TIPOSPAGOS TP ON N.TIPOPAGO=TP.CLAVE left JOIN CLIENTERFC CR ON CR.CLIENTE=CL.CLAVE AND CL.TIENDA=CR.TIENDA AND CR.REGISTRO=0  WHERE S.CLAVE='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=" + CAJA.ToString + " AND N.NOTA=" + LANOTA.ToString + "  "

            If frmPrincipal.SucursalBase = "MZT" Then
                Dim REPI As New rptNotaVentaMZT
                IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), My.Settings.CopiasContado, "")
            Else
                Dim REPI As New rptNotaDeVenta
                IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), My.Settings.CopiasContado, "")
            End If
        Catch ex As Exception
            Dim xyz As Short
            xyz = MessageBox.Show("No se imprimió la nota, Desea volver a intentar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz = 6 Then
                Return False
            Else
                MessageBox.Show("Utilice la opción reimprimir nota ( " + TXTNOTA.Text + " )", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return True
            End If
        End Try
        Return True
    End Function
    Public Function CHECAPRODUCTOS() As Boolean
        If frmPrincipal.PRE.ElementosAgregados.Rows.Count <= 0 Then
            'BTNQUITAR.Enabled = False
            BTNCANCELAR.Enabled = False
            BTNCOBRAR.Enabled = False
            BTNVALE.Enabled = False

            Return False
        Else
            'BTNQUITAR.Enabled = True
            BTNCANCELAR.Enabled = True
            BTNVALE.Enabled = True
            BTNCOBRAR.Enabled = True
            Return True
        End If

    End Function

    Private Sub frmNotaDeVenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            frmPrincipal.PRE.EliminarNota()
            DGV.Refresh()
            TXTCOD.Clear()
            LBLPRE.Text = "0"
            LBLEXIS.Text = "0"
            TXTCANT.Text = "1"
            LBLP.Text = "0"

            CHECAPRODUCTOS()
            TXTEFECTIVO.Text = "0"
            TXTCOD.Focus()
            TXTNOTA.Text = CARGANOTA()
            VALE = False
            CBTP.SelectedIndex = 0
            TXTDESC.Text = 0
            LLAMACLIENTE(True)

        End If

        If e.KeyCode = Keys.F3 Then
            'Dim VC As New frmNotaDeVentaTactil
            'VC.ShowDialog()
            '' MessageBox.Show("activar tactil")
            AgregarServDom()
        End If
        If e.KeyCode = Keys.F4 Then
            MostrarCompra("")
        End If
        If e.KeyCode = Keys.F6 Then
            CHKSD.Checked = Not CHKSD.Checked
        End If
        If e.KeyCode = Keys.F2 Then
            Dim VX As New frmCorteX
            VX.VISTA(1, NOMEMP)
        End If
        If e.KeyCode = Keys.F12 Then
            GUARDAR()
        End If

        If e.KeyCode = Keys.F11 Then
            Dim VFAC As New frmFacturar33
            'VFAC.TXTCLI.Text = CLIENTEBASE
            VFAC.MOSTRAR("1Il6G2Z0Oq95S", 0, False)
            VFAC.Dispose()
        End If

        If e.KeyCode = Keys.F10 Then
            If BUSCAR() Then
                If My.Settings.mostrarbusqueda Then
                    BTNBUS.Focus()
                End If
            End If
        End If


        If e.KeyCode = Keys.F5 Then
            'If DGV.Rows.Count <= 0 Then
            '    MessageBox.Show("No hay ningun producto agregado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '    Exit Sub
            'Else
            '    frmPrincipal.PRE.Quitar(DGV.Item(0, DGV.CurrentRow.Index).Value)
            '    ' DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
            '    CHECATABLA()
            'End If
            'CHECAPRODUCTOS()

            Dim VRFAC As New frmReporteFacturasElectronicas
            VRFAC.ShowDialog()
        End If


        If e.KeyCode = Keys.F7 Then

            If DGV.Rows.Count <= 0 Then
                MessageBox.Show("No hay ningun producto agregado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            Else
                frmPrincipal.PRE.EliminarNota()
                CHECATABLA()
                CHECAPRODUCTOS()

                DGV.Refresh()
            End If
            CHECAPRODUCTOS()
        End If

        If e.KeyCode = Keys.F8 Then
            Dim VCc As New frmAbonosCreditos
            VCc.MOSTRAR(1, NOMEMP, NE, "0")
        End If

        If e.KeyCode = Keys.F9 Then
            If CLIENTEBASE = 0 Then
            Else
                If DGV.Rows.Count <= 0 Then
                    MessageBox.Show("No hay ningun producto agregado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                Else

                    Dim VC As New frmCredito
                    VC.MOSTRAR(CLIENTEBASE, CHKSD.Checked, CHKSA.Checked)
                    If VC.DialogResult = Windows.Forms.DialogResult.Yes Then
                        LLAMACLIENTE(False)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BTNCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DGV.Rows.Count = 0 Then
            LLAMAEMPLEADO()
        Else
            Dim xyz As Short
            xyz = MessageBox.Show("Desea cancelar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz <> 6 Then
                Exit Sub
            End If
            LLAMAEMPLEADO()
        End If
    End Sub

    Private Sub BTNIMPRIMIR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GUARDAR()
    End Sub

    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
        CHECATABLA()
    End Sub

    Private Sub DGV_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV.RowsRemoved
        CHECATABLA()
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GUARDAR()
    End Sub

    Private Sub TXTEFECTIVO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTEFECTIVO.TextChanged
        If TXTEFECTIVO.Text = "" Or TXTEFECTIVO.Text = "0" Then
            TXTCAMBIO.Text = "0"
        Else
            CHECACANTIDADES()
        End If
    End Sub
    Private Function CHECACANTIDADES() As Boolean
        'BTNCOBRAR.Enabled = False
        TXTCAMBIO.Text = "0"
        Dim TOTAL, EFECTIVO As Double
        Try
            TOTAL = CType(TXTTOT.Text, Double)
            EFECTIVO = CType(TXTEFECTIVO.Text, Double)
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        If EFECTIVO >= TOTAL Then
            'BTNCOBRAR.Enabled = True
            TXTCAMBIO.Text = FormatNumber(EFECTIVO - TOTAL).ToString()
            Return True
        Else
            TXTCAMBIO.Text = 0
            Return False
        End If

    End Function
    'Private Sub CHECACANTIDADES()
    '    Dim TOTAL, EFECTIVO As Double
    '    Try
    '        TOTAL = CType(TXTTOT.Text, Double)
    '        EFECTIVO = CType(TXTEFECTIVO.Text, Double)
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try
    '    If EFECTIVO >= TOTAL Then

    '        LBLCAM.Text = FormatNumber(EFECTIVO - TOTAL).ToString()
    '    Else
    '        LBLCAM.Text = 0
    '    End If
    'End Sub

    Private Sub TXTEFECTIVO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEFECTIVO.KeyPress
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
            BTNCOBRAR.Focus()
        End If
    End Sub

    Dim ESC, MAT, NOM, MAIL As String
    Dim DESCEST As Boolean
    Private Sub MostrarCompra(ByVal CODIGO As String)
        Dim VCOM As New frmCompras
        VCOM.MOSTRAR(TXTNOTA.Text, CODIGO)
        If VCOM.DialogResult = Windows.Forms.DialogResult.Yes Then
            COMPRADO = True
        End If

    End Sub
    Private Sub MostrarCompraExpress(ByVal CODIGO As String)
        Dim CP As String
        CP = BDExtraeUnDato("SELECT CP FROM PRODUCTOS WHERE CLAVE='" + CODIGO + "'", frmPrincipal.CadenaConexion)
        Dim VCOM As New frmCompraExpress
        VCOM.Mostrar(frmPrincipal.SucursalBase, CP, LBLNOM.Text, 1, RestaComprar, "Nota Venta " + TXTNOTA.Text)
        If VCOM.DialogResult = Windows.Forms.DialogResult.Yes Then
            COMPRADO = True
        End If
    End Sub

    Private Function BUSCAR() As Boolean
        frmClsBusqueda.BUSCAR("SELECT P.CLAVE,P.NOMBRE PRODUCTO,PRE.PRECIO,DBO.EXISTENCIAALMACEN('" + frmPrincipal.SucursalBase + "',P.CP) EXISTENCIA  FROM PRODUCTOS P INNER JOIN PRECIOSSUCURSALES PRE ON PRE.TIENDA='" + frmPrincipal.SucursalBase + "' AND PRE.PRODUCTO=P.CLAVE WHERE P.ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + "  AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1)", "  AND P.NOMBRE  ", "  ORDER BY P.NOMBRE  ", "Busqueda de productos", "Nombre del producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCOD.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            If Not CHECAPROD() Then
                TXTCOD.Text = ""
                TXTCOD.Focus()
                Exit Function
            End If
            If Not CHECAAGREGADO(TXTCOD.Text) Then
                ''MessageBox.Show("No puede agregar mas producto, revise su inventario por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Dim xyz As Short
                xyz = MessageBox.Show("No puede agregar mas producto, revise su inventario por favor, Desea realizar una compra?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If xyz = 6 Then
                    MostrarCompraExpress(TXTCOD.Text)
                    CONTINUADESPUESCOMPRA()
                End If
                TXTCOD.Text = ""
                TXTCOD.Focus()
                TXTCANT.Text = 1
                Exit Function
            End If


            Dim DESC As Double
            DESC = 0
            Try
                'If DGV.Rows.Count >= 50 Then
                '    MessageBox.Show("ha rebasado el limite de productos por nota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                '    Exit Function
                'End If

                DESC = CType(TXTDESC.Text, Double)
            Catch ex As Exception
            End Try
            Dim ELPRECIO As Double
            ELPRECIO = 0
            Try
                ELPRECIO = CType(LBLPRE.Text, Double)
            Catch ex As Exception

            End Try
            Dim X As Integer
            For X = 0 To DTPRECIOSCLIENTES.Rows.Count - 1
                If TXTCOD.Text = DTPRECIOSCLIENTES.Rows(X).Item(0).ToString Then
                    If CType(DTPRECIOSCLIENTES.Rows(X).Item(1).ToString, Double) < PMIN Then
                        If CType(DTPRECIOSCLIENTES.Rows(X).Item(2).ToString, Boolean) Then
                            ELPRECIO = CType(DTPRECIOSCLIENTES.Rows(X).Item(1).ToString, Double)
                        Else
                            ELPRECIO = PMIN
                        End If
                    Else
                        ELPRECIO = CType(DTPRECIOSCLIENTES.Rows(X).Item(1).ToString, Double)
                    End If
                End If
            Next
            frmPrincipal.PRE.Agregar(TXTCOD.Text, LBLNOM.Text, CType(TXTCANT.Text, Double), ELPRECIO, DESC)
            Me.DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
            ACOMODARDGV()
            CHECATABLA()
            CHECAPRODUCTOS()
            ' AGREGAR(TXTCOD.Text, LBLNOM.Text, CType(TXTCANT.Text, Double), LBLPRE.Text)
            TXTCANT.Text = "1"
            TXTCOD.Text = ""
            TXTCOD.Focus()

            Return True
        End If
        Return False
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUS.Click
        If BUSCAR() Then
            If My.Settings.mostrarbusqueda Then
                BTNBUS.Focus()
            End If
        End If
    End Sub

    Private Sub BTNCOBRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCOBRAR.Click
        If frmPrincipal.VentaSinResguardo >= 2 Then
            MessageBox.Show("Debe realizar un resguardo, no se permite continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        GUARDAR()
    End Sub

    Private Sub BTNQUITAR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        'Dim pro As String

        'pro = DGV.Item(0, DGV.CurrentRow.Index).Value
        'frmPrincipal.PRE.Quitar(pro)

        'CHECATABLA()
        'CHECAPRODUCTOS()
        Dim VRFAC As New frmReporteFacturasElectronicas
        VRFAC.ShowDialog()
    End Sub

    Private Sub BTNVTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVTA.Click
        Dim VX As New frmCorteX
        VX.VISTA(1, NOMEMP)
    End Sub

    Private Sub BTNCORTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCORTE.Click
        Dim VC As New frmReporteStockMin
        VC.ShowDialog()
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        frmPrincipal.PRE.EliminarNota()
        CHECATABLA()
        CHECAPRODUCTOS()

        DGV.Refresh()
    End Sub

    Private Sub Sumar(ByVal V As Boolean)
        Dim CANT As Double
        Try
            CANT = CType(TXTCANT.Text, Double)
        Catch ex As Exception
            OPMsgError("Favor de indicar la cantidad")
            Exit Sub
        End Try
        frmPrincipal.PRE.AgregaQuita(DGV.Item(0, DGV.CurrentRow.Index).Value.ToString, TXTCANT.Text, V)

        DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
        ACOMODARDGV()
        CHECATABLA()
        CHECAPRODUCTOS()
        TXTCANT.Text = "1"
        TXTCOD.Text = ""
        TXTCOD.Focus()
    End Sub
    Dim RestaComprar As Double
    Private Function CHECAAGREGADO(ByVal CODIGO As String) As Boolean
        'Return True
        CargaExistenciaProducto(CODIGO)
        Dim VCANT, VEXIS As Double
        RestaComprar = 0
        Try
            VCANT = CType(TXTCANT.Text, Double)
            VEXIS = CType(LBLEXIS.Text, Double)
        Catch ex As Exception
            Return False
        End Try
        If VCANT > VEXIS Then
            RestaComprar = VCANT - VEXIS
            Return False
        End If

        'If TXTCANT.Text > LBLEXIS.Text Then
        '    Return False
        'End If
        Dim c As Double
        c = 0
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(0, X).Value = CODIGO Then
                c = c + DGV.Item(2, X).Value
            End If
        Next
        c = c + TXTCANT.Text


        If c > LBLEXIS.Text Then
            RestaComprar = c - VEXIS
            Return False
        End If
        Return True
    End Function
    Private Sub TXTCOD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOD.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTCOD.Text = "" Then
            Else
                If Not CHECAPROD() Then
                    If Not CHECAPROD2() Then
                        TXTCOD.Text = ""
                        TXTCANT.Text = "1"
                        TXTCOD.Focus()
                        Exit Sub
                    End If
                End If
                Dim DESC As Double
                DESC = 0
                If Not CHECAAGREGADO(TXTCOD.Text) Then
                    ''MessageBox.Show("No puede agregar mas producto, revise su inventario por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                    Dim xyz As Short
                    xyz = MessageBox.Show("No puede agregar mas producto, revise su inventario por favor, Desea realizar una compra?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If xyz <> 6 Then
                        Exit Sub
                    End If
                    MostrarCompraExpress(TXTCOD.Text)
                    CONTINUADESPUESCOMPRA()
                    TXTCOD.Text = ""
                    TXTCOD.Focus()
                    TXTCANT.Text = 1
                    TXTCOD.Text = ""
                    TXTCOD.Focus()
                    TXTCANT.Text = 1
                    Exit Sub
                End If



                Try
                    DESC = CType(TXTDESC.Text, Double)
                Catch ex As Exception

                End Try

                If DGV.Rows.Count >= 50 Then
                    MessageBox.Show("ha rebasado el limite de productos por nota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                End If
                'Dim pre, pre1, descu
                'pre = DGV.Item(4, DGV.CurrentRow.Index).Value
                'pre1 = LBLPRE.Text
                'descu = DGV.Item(3, DGV.CurrentRow.Index).Value

                'If pre1 = pre Then
                Dim X As Integer
                For X = 0 To DTPRECIOSCLIENTES.Rows.Count - 1
                    If TXTCOD.Text = DTPRECIOSCLIENTES.Rows(X).Item(0).ToString Then
                        LBLPRE.Text = DTPRECIOSCLIENTES.Rows(X).Item(1).ToString
                    End If
                Next
                frmPrincipal.PRE.Agregar(TXTCOD.Text, LBLNOM.Text, CType(TXTCANT.Text, Double), LBLPRE.Text, DESC)
                'Else
                '    frmPrincipal.PRE.Agregar(TXTCOD.Text, LBLNOM.Text, CType(TXTCANT.Text, Double), pre, descu)
                'End If

                DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
                ACOMODARDGV()
                CHECATABLA()
                CHECAPRODUCTOS()
                TXTCANT.Text = "1"
                TXTCOD.Text = ""
                TXTCOD.Focus()
            End If
        End If
    End Sub
    Private Sub CONTINUADESPUESCOMPRA()
        If TXTCOD.Text = "" Then
        Else
            If Not CHECAPROD() Then
                If Not CHECAPROD2() Then
                    TXTCOD.Text = ""
                    TXTCANT.Text = "1"
                    TXTCOD.Focus()
                    Exit Sub
                End If
            End If
            Dim DESC As Double
            DESC = 0
            If Not CHECAAGREGADO(TXTCOD.Text) Then
                ''MessageBox.Show("No puede agregar mas producto, revise su inventario por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                'Dim xyz As Short
                'xyz = MessageBox.Show("No puede agregar mas producto, revise su inventario por favor, 󿿿Desea realizar una compra?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If xyz <> 6 Then
                '    Exit Sub
                'End If
                'MostrarCompra(TXTCOD.Text)

                TXTCOD.Text = ""
                TXTCOD.Focus()
                TXTCANT.Text = 1
                TXTCOD.Text = ""
                TXTCOD.Focus()
                TXTCANT.Text = 1
                Exit Sub
            End If



            Try
                DESC = CType(TXTDESC.Text, Double)
            Catch ex As Exception

            End Try

            'If DGV.Rows.Count >= 50 Then
            '    MessageBox.Show("ha rebasado el limite de productos por nota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '    Exit Sub
            'End If
            'Dim pre, pre1, descu
            'pre = DGV.Item(4, DGV.CurrentRow.Index).Value
            'pre1 = LBLPRE.Text
            'descu = DGV.Item(3, DGV.CurrentRow.Index).Value

            'If pre1 = pre Then
            Dim X As Integer
            For X = 0 To DTPRECIOSCLIENTES.Rows.Count - 1
                If TXTCOD.Text = DTPRECIOSCLIENTES.Rows(X).Item(0).ToString Then
                    LBLPRE.Text = DTPRECIOSCLIENTES.Rows(X).Item(1).ToString
                End If
            Next
            frmPrincipal.PRE.Agregar(TXTCOD.Text, LBLNOM.Text, CType(TXTCANT.Text, Double), LBLPRE.Text, DESC)
            'Else
            '    frmPrincipal.PRE.Agregar(TXTCOD.Text, LBLNOM.Text, CType(TXTCANT.Text, Double), pre, descu)
            'End If

            DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
            ACOMODARDGV()
            CHECATABLA()
            CHECAPRODUCTOS()
            TXTCANT.Text = "1"
            TXTCOD.Text = ""
            TXTCOD.Focus()
        End If

    End Sub
    Private Sub AgregarServDom()
        frmPrincipal.PRE.Agregar("0000000001", "SERV. A DOMI", 1, 10, 0)
        'Else
        '    frmPrincipal.PRE.Agregar(TXTCOD.Text, LBLNOM.Text, CType(TXTCANT.Text, Double), pre, descu)
        'End If

        DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
        ACOMODARDGV()
        CHECATABLA()
        CHECAPRODUCTOS()
        TXTCANT.Text = "1"
        TXTCOD.Text = ""
        TXTCOD.Focus()
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AgregarServDom()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CARGADATOS()
    End Sub

    Private Sub CBTP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBTP.SelectedIndexChanged

        If LTP(CBTP.SelectedIndex) <> 1 Then
            TXTEFECTIVO.Text = TXTTOT.Text
        End If
        CHECATABLA()
    End Sub

    Private Sub TXTDESC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDESC.KeyPress
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
            Dim DESC As Double
            DESC = 0
            Try
                DESC = CType(TXTDESC.Text, Double)
            Catch ex As Exception

            End Try
            frmPrincipal.PRE.PoneDescuento(DESC)
            DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
            ACOMODARDGV()
            CHECATABLA()
            TXTCOD.Focus()
        End If
    End Sub


    Private Sub BTNFAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNFAC.Click
        Dim VFAC As New frmFacturar33
        'VFAC.TXTCLI.Text = CLIENTEBASE
        VFAC.MOSTRAR("1Il6G2Z0Oq95S", 0, False)
        VFAC.Dispose()
    End Sub
    Private Sub ACOMODARDGV()
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).ReadOnly = True
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(3).ReadOnly = True
        DGV.Columns(5).ReadOnly = True
        DGV.Columns(6).ReadOnly = True
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        DGV.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader



        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).ReadOnly = True
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(3).ReadOnly = True
        DGV.Columns(5).ReadOnly = True
        DGV.Columns(6).ReadOnly = True
        DGV.Columns(7).ReadOnly = True
        DGV.Columns(3).Visible = False



        Try
            DGV.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
        Catch ex As Exception

        End Try

        DGV.Columns(2).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(3).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(4).DefaultCellStyle = DgvCellFormatoNumerico(2)
        DGV.Columns(5).DefaultCellStyle = DgvCellFormatoNumerico(2)
        DGV.Columns(6).DefaultCellStyle = DgvCellFormatoNumerico(2)
        DGV.Columns(7).DefaultCellStyle = DgvCellFormatoNumerico(2)
    End Sub
    Private Sub DGV_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Dim PRE As Double
        Try
            PRE = CType(DGV.Item(4, DGV.CurrentRow.Index).Value, Double)
        Catch ex As Exception
            Exit Sub
        End Try
        Dim ARTICULO As String
        ARTICULO = DGV.Item(0, DGV.CurrentRow.Index).Value
        'ARTICULO = DGV.Item(1, DGV.CurrentRow.Index).Value
        'ARTICULO = DGV.Item(2, DGV.CurrentRow.Index).Value
        'ARTICULO = DGV.Item(3, DGV.CurrentRow.Index).Value
        'ARTICULO = DGV.Item(4, DGV.CurrentRow.Index).Value
        'ARTICULO = DGV.Item(5, DGV.CurrentRow.Index).Value
        frmPrincipal.PRE.ModificaPrecio(ARTICULO, PRE)
        DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
        ACOMODARDGV()
        DGV.Refresh()
        CHECATABLA()
    End Sub

    Private Sub BTNVALE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVALE.Click
        Dim VC As New frmCredito

        If FACTURAAUTOMATICA Then
            CHKSD.Checked = True
        End If

        VC.MOSTRAR(CLIENTEBASE, CHKSD.Checked, CHKSA.Checked)
        If VC.DialogResult = Windows.Forms.DialogResult.Yes Then
            LLAMACLIENTE(False)
        End If
        CHKSD.Checked = False
        CHKSA.Checked = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim VCC As New frmAbonosCreditos
        VCC.MOSTRAR(1, NOMEMP, NE, "0")
    End Sub

    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        If Not CHECAAGREGADO(DGV.Item(0, DGV.CurrentRow.Index).Value.ToString) Then
            ' MessageBox.Show("No puede agregar mas producto, revise su inventario por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Dim xyz As Short
            xyz = MessageBox.Show("No puede agregar mas producto, revise su inventario por favor, ¿Desea realizar una compra?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz <> 6 Then
                Exit Sub
            End If

            MostrarCompraExpress(DGV.Item(0, DGV.CurrentRow.Index).Value.ToString)
            CONTINUADESPUESCOMPRA()
            TXTCOD.Text = ""
            TXTCOD.Focus()
            TXTCANT.Text = 1
            TXTCOD.Text = ""
            TXTCOD.Focus()
            TXTCANT.Text = 1
            Exit Sub
        End If
        Sumar(True)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRESTAR.Click
        Sumar(False)
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmPrincipal.PRE.EliminarNota()
        DGV.Refresh()
        TXTCOD.Clear()
        LBLPRE.Text = "0"
        LBLEXIS.Text = "0"
        TXTCANT.Text = "1"
        LBLP.Text = "0"


        TXTEFECTIVO.Text = "0"
        TXTCOD.Focus()
        TXTNOTA.Text = CARGANOTA()
        VALE = False
        CBTP.SelectedIndex = 0
        TXTDESC.Text = 0
        LLAMACLIENTE(True)
        CHECAPRODUCTOS()
    End Sub



    Private Sub TXTNOTA_TextChanged(sender As Object, e As EventArgs) Handles TXTNOTA.TextChanged

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim VAFST As New frmAjustadorFacturasSinTimbrar
        VAFST.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim VCH As New frmConversorHuevos
        VCH.ShowDialog()
    End Sub

    Private Sub frmNotaDeVenta_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.Width < 1478 Then
            'Button1.Location=914, 149


        End If
        If Me.Width >= 1478 And Me.Width < 1656 Then
            'Button1.Location=1006, 200
            '+=1006, 262   -=1095, 260
        End If
        If Me.Width >= 1656 Then

            'x,y
            ' Button1.Location  ='1007, 263
        End If
    End Sub



    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        frmCotizacion.MOSTRAR(LBLNCLI.Text, NE, NOMEMP)
        'REVISARPRECIOS()
        'ACOMODARDGV()
        CHECATABLA()
        'CHECAPRODUCTOSVTA()
        TXTCANT.Text = "1"
        TXTCOD.Text = ""
        TXTCOD.Focus()
    End Sub

    Private Sub DGV_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellDoubleClick
        frmAutorizacionCredito.mostrar(1, "Autorizacin Cambio Precio")
        If frmAutorizacionCredito.DialogResult = Windows.Forms.DialogResult.Yes Then
            DGV.Columns(4).ReadOnly = False
        Else
            Exit Sub
        End If

    End Sub

    Private Sub CHKCE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CHECATABLA()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MostrarCompra("")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        frmResguardos.MOSTRAR(CAJA, NE, NOMEMP, False)
    End Sub

    Private Sub BTNCONF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCONF.Click
        frmConfiguracion.ShowDialog()
    End Sub
End Class