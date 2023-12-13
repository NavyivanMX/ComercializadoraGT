Public Class frmModificaNotas
    Dim CAJA, CAJERA, CLIENTE As Integer
    Dim TOT As Double
    Dim Z As Integer
    Public DTNOTA As New DataTable
    Public DTPRECIOSCLIENTES As New DataTable
    Dim NOHAY As Boolean
    Private Sub frmModificaNotas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CBTP.SelectedIndex = 0
        DTNOTA.Columns.Add("CLAVE")
        DTNOTA.Columns.Add("PRODUCTO")
        DTNOTA.Columns.Add("CANTIDAD")
        DTNOTA.Columns.Add("PRECIO")
        DTNOTA.Columns.Add("DESCUENTO")
        TXTNOTA1.Text = CARGANOTA1.ToString
        CHECAPRODUCTOS()
        BTNCOBRAR.Enabled = False
        CHECATABLA()
        ACTIVAR(True)
        LIMPIAR()
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTNOTA.Enabled = V
        BTNCANCELAR.Enabled = Not V
        Button1.Enabled = Not V
        BTNQUITAR.Enabled = Not V
        BTNBUS.Enabled = Not V
        TXTCANT.Enabled = Not V
        TXTCOD.Enabled = Not V
        TXTDESC.Enabled = Not V
        CBTP.Enabled = Not V
        TXTEFECTIVO.Enabled = Not V
        If V Then
            TXTNOTA.Focus()
        Else
            TXTCOD.Focus()
        End If
    End Sub
    Private Sub LIMPIAR()
        TXTNOTA.Text = ""
        LBLEMP.Text = ""
        LBLCLI.Text = ""
        TXTEFECTIVO.Text = ""
        TXTCAMBIO.Text = 0
        TXTDESC.Text = 0
    End Sub
    Private Function CARGANOTA1() As Integer
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
    Private Sub CARGANOTA()
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim QUERY As String
        QUERY = "SELECT E.NOMBRE EMPLEADO,N.FECHA,NOCAJA,N.CAJERA,C.NOMBRE,C.CLAVE,N.TOTAL FROM NOTASDEVENTA N INNER JOIN EMPLEADOS E  ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE  INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA=" + TXTNOTA.Text
        Dim SQLEMP As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLEMP.ExecuteReader
        Dim FEC As DateTime
        If LECTOR.Read Then
            LBLEMP.Text = LECTOR(0)
            FEC = CType(LECTOR(1), DateTime)
            CAJA = LECTOR(2)
            CAJERA = LECTOR(3)
            LBLCLI.Text = LECTOR(4)
            CLIENTE = LECTOR(5)
            TOT = LECTOR(6)
            LECTOR.Close()
            ACTIVAR(False)
            If FEC.Date <> Now.Date Then
                MessageBox.Show("La nota que intenta modificar no coincide con la fecha actual, NO se permite modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            Else
                'Dim SQL As New SqlClient.SqlCommand("SELECT FECHAZ FROM CORTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + CAJA.ToString, frmPrincipal.CONX)
                'Dim LEC As SqlClient.SqlDataReader
                'LEC = SQL.ExecuteReader
                'If LEC.Read Then
                '    FEC2 = LEC(0)
                'End If
                'LEC.Close()
                'If FEC2 > FEC Then
                '    MessageBox.Show("La nota ha sido incluida en un corten no se permite eliminar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Exit Sub
                'End If
                'TXTOBS.Focus()
            End If
        Else
            MessageBox.Show("No se encontró el numero de nota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            LECTOR.Close()
            Exit Sub
        End If

        DTPRECIOSCLIENTES.Clear()
        DTPRECIOSCLIENTES = BDLlenatabla("SELECT PRODUCTO,PRECIO FROM PRECIOSCLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLIENTE='" + CLIENTE.ToString + "'", frmPrincipal.CadenaConexion)

        DTNOTA = BDLlenatabla("SELECT D.PRODUCTO CLAVE,P.NOMBRE,D.CANTIDAD,(D.TOTAL*(1+(D.DESCUENTO/100)))/D.CANTIDAD,D.DESCUENTO FROM DETALLENOTASDEVENTA D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + TXTNOTA.Text + "", frmPrincipal.CadenaConexion)
        Dim X As Integer
        For X = 0 To DTNOTA.Rows.Count - 1
            frmPrincipal.PRE.Agregar(DTNOTA.Rows(X).Item(0).ToString, DTNOTA.Rows(X).Item(1).ToString, DTNOTA.Rows(X).Item(2).ToString, DTNOTA.Rows(X).Item(3).ToString, DTNOTA.Rows(X).Item(4).ToString)
        Next

        DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).ReadOnly = True
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(3).ReadOnly = True
        DGV.Columns(5).ReadOnly = True

        'ACTIVAR(False)
        'CHECATABLA()
    End Sub
    Private Sub TXTNOTA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOTA.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            If TXTNOTA.Text = "" Then
            Else
                frmPrincipal.PRE.EliminarNota()
                CARGANOTA()
                CHECATABLA()
            End If
        End If
    End Sub

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
    Private Function CHECACANTIDADES() As Boolean
        BTNCOBRAR.Enabled = False
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
            BTNCOBRAR.Enabled = True
            TXTCAMBIO.Text = FormatNumber(EFECTIVO - TOTAL).ToString()
            Return True
        Else
            TXTCAMBIO.Text = 0
            Return False
        End If
    End Function
    Private Function DgvCellEstilo(ByVal FONDO As Color, ByVal FUENTE As Color) As DataGridViewCellStyle
        Dim RESTILO As New DataGridViewCellStyle
        RESTILO.BackColor = FONDO
        RESTILO.ForeColor = FUENTE
        Return RESTILO
    End Function
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
                Else

                End If
            Next
        Next
    End Sub
    Public Sub CHECATABLA()
        If frmPrincipal.PRE.CuentaElementos <= 0 Then
            TXTTOT.Text = 0
            BTNQUITAR.Enabled = False
            BTNAGREGAR.Enabled = False
            BTNRESTAR.Enabled = False
        Else
            TXTTOT.Text = FormatNumber(frmPrincipal.PRE.Total, 2).ToString
            BTNQUITAR.Enabled = True
            BTNAGREGAR.Enabled = True
            BTNRESTAR.Enabled = True
            CHECACANTIDADES()
            MARCAPRECIOCLIENTES()
        End If
        LBLP.Text = DGV.Rows.Count
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
            DGV.Refresh()
            CHECATABLA()
            TXTCOD.Focus()
        End If
    End Sub
    Public Function CHECAPRODUCTOS() As Boolean
        If frmPrincipal.PRE.CuentaElementos <= 0 Then
            BTNQUITAR.Enabled = False
            BTNCANCELAR.Enabled = False
            BTNCOBRAR.Enabled = False
            Return False
        Else
            BTNQUITAR.Enabled = True
            BTNCANCELAR.Enabled = True
            Return True
        End If

    End Function
    Private Sub Sumar(ByVal V As Boolean)
        frmPrincipal.PRE.AgregaQuita(DGV.Item(0, DGV.CurrentRow.Index).Value.ToString, TXTCANT.Text, V)

        DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).ReadOnly = True
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(3).ReadOnly = True
        DGV.Columns(5).ReadOnly = True

        CHECATABLA()
        CHECAPRODUCTOS()
        TXTCANT.Text = "1"
        TXTCOD.Text = ""
        TXTCOD.Focus()
    End Sub
    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        If Not CHECAAGREGADO(DGV.Item(0, DGV.CurrentRow.Index).Value.ToString) Then
            MessageBox.Show("No puede agregar mas producto, revise su inventario por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TXTCOD.Text = ""
            TXTCOD.Focus()
            TXTCANT.Text = 1
            Exit Sub
        End If
        Sumar(True)
       
    End Sub

    Private Sub BTNRESTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRESTAR.Click
        Sumar(False)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim vc As New frmNotaDeVentaTactil
        vc.ShowDialog()
    End Sub

    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        Dim pro As String

        pro = DGV.Item(0, DGV.CurrentRow.Index).Value
        frmPrincipal.PRE.Quitar(pro)

        CHECATABLA()
        CHECAPRODUCTOS()
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPrincipal.PRE.EliminarNota()
        CHECATABLA()
        CHECAPRODUCTOS()

        DGV.Refresh()
    End Sub
    Private Function HAYENINVENTARIO(ByVal CODIGO As String) As Boolean
        If Not frmPrincipal.CHECACONX() Then
            Exit Function
        End If
        Dim query As String
        Try
            query = "SELECT SUM (I.CANTIDAD)  FROM INVPISOTIENDA I INNER JOIN LOTES L ON L.CLAVE=I.PRODUCTO INNER JOIN PRODUCTOS P ON P.CP=L.PRODUCTO WHERE I.TIENDA='" + frmPrincipal.SucursalBase + "' AND P.CLAVE='" + CODIGO + "' AND P.EMPRESA=" + frmPrincipal.Empresa + " "
            Dim SQLHAY As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
            Dim LECHAY As SqlClient.SqlDataReader
            LECHAY = SQLHAY.ExecuteReader
            If LECHAY.Read Then
                If LECHAY(0) Is DBNull.Value Then
                    LECHAY.Close()
                    MessageBox.Show("No hay existencia del producto en el inventario de piso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                Else
                    LBLEXIS.Text = FormatNumber(LECHAY(0), 2).ToString
                    LBLEXIS.ForeColor = Color.Green
                    LECHAY.Close()
                    Return True

                End If
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function CHECAPROD() As Boolean
        If Not frmPrincipal.CHECACONX() Then
            Return False
        End If
        NOHAY = False
        Dim GRU As Integer
        Dim query As String
        query = "SELECT P.NOMBRE,P." + frmPrincipal.SucursalBase + ",P.IMG,P.GRUPO,P.CP FROM PRODUCTOS P WHERE P.CLAVE= '" + TXTCOD.Text + "' AND EMPRESA=" + frmPrincipal.Empresa + " "
        Dim SQLCARGAPROD As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        Try
            LECTOR = SQLCARGAPROD.ExecuteReader
            If LECTOR.Read() Then
                LBLPRE.Text = "$" & LECTOR(1)
                LBLNOM.Text = LECTOR(0)
                PBIMG.ImageLocation = "C:/FOTOSPRICE/" + LECTOR(2) + ".JPG"
                'INV = LECTOR(3)
                GRU = LECTOR(3)
                LECTOR.Close()
                'If INV = True Then
                If HAYENINVENTARIO(TXTCOD.Text) Then
                Else
                    LBLEXIS.Text = "0" '' --> SI NO HAY K APAREZCA UN CERO NO??
                    LBLEXIS.ForeColor = Color.Red
                    MessageBox.Show("Este Código NO aparece en el inventario, favor de corregir el inventario lo antes posible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LECTOR.Close()
                    NOHAY = True
                End If
                Return True
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
    Private Sub BTNBUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUS.Click
        frmClsBusqueda.BUSCAR("SELECT P.CLAVE,P.NOMBRE PRODCUTO,P." + frmPrincipal.SucursalBase + "  FROM PRODUCTOS P  WHERE P.ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + "  ", "  AND P.NOMBRE  ", "  ORDER BY P.NOMBRE  ", "Busqueda de productos", "Nombre del producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCOD.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            If Not CHECAPROD() Then
                TXTCOD.Text = ""
                TXTCOD.Focus()
                Exit Sub
            End If
            If Not CHECAAGREGADO(TXTCOD.Text) Then
                MessageBox.Show("No puede agregar mas producto, revise su inventario por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                TXTCOD.Text = ""
                TXTCOD.Focus()
                TXTCANT.Text = 1
                Exit Sub
            End If

            Dim DESC As Double
            DESC = 0
            Try
                If DGV.Rows.Count >= 22 Then
                    MessageBox.Show("ha rebasado el limite de productos por nota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                End If

                DESC = CType(TXTDESC.Text, Double)
            Catch ex As Exception
            End Try
            Dim X As Integer
            For X = 0 To DTPRECIOSCLIENTES.Rows.Count - 1
                If TXTCOD.Text = DTPRECIOSCLIENTES.Rows(X).Item(0).ToString Then
                    LBLPRE.Text = DTPRECIOSCLIENTES.Rows(X).Item(1).ToString
                End If
            Next
            frmPrincipal.PRE.Agregar(TXTCOD.Text, LBLNOM.Text, CType(TXTCANT.Text, Double), LBLPRE.Text, DESC)
            Me.DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
            DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            CHECATABLA()
            CHECAPRODUCTOS()
            ' AGREGAR(TXTCOD.Text, LBLNOM.Text, CType(TXTCANT.Text, Double), LBLPRE.Text)
            TXTCOD.Text = ""
            TXTCOD.Focus()
            DGV.Columns(0).ReadOnly = True
            DGV.Columns(1).ReadOnly = True
            DGV.Columns(2).ReadOnly = True
            DGV.Columns(3).ReadOnly = True
            DGV.Columns(5).ReadOnly = True
        End If
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
                MessageBox.Show("No se Puede Cobrar en esta Caja, No esta Correcta la Información, Favor de Comunicarse con DeIP", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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
    Private Function IMPRIMIRNOTA(ByVal LANOTA As Integer) As Boolean
        Try
            frmPrincipal.CHECACONX()
            Dim QUER As String
            'QUER = "SELECT S.NOMBRECOMUN,S.NOMBREFISCAL,D.NOTA,D.PRODUCTO CODIGO,P.NOMBRECORTO PRODUCTO,D.CANTIDAD,PRECIO=(D.TOTAL/D.CANTIDAD),D.TOTAL,SUBTOTAL=DBO.ELSUBTOTAL(D.PRODUCTO,D.TOTAL),IVA=DBO.ELIVA(D.PRODUCTO,D.TOTAL),E.NOMBRE EMPLEADO,N.FECHA,S.DIRECCION,S.CIUDAD,S.RFC,S.TELEFONO,C.PAGA,C.CAMBIO,N.NOCAJA,TIPO='NOTA',VNOM='',VUNI='',D.DESCUENTO,CL.NOMBRE,S.COMENTARIO1,S.COMENTARIO2,S.COMENTARIO3,S.CP,CL.TELEFONO TEL,CL.DIRECCION DIR,CR.RFC R FROM DETALLENOTASDEVENTA D INNER JOIN TIENDAS S   ON D.TIENDA=S.CLAVE INNER JOIN PRODUCTOS P   ON D.PRODUCTO=P.CLAVE INNER JOIN NOTASDEVENTA N   ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA INNER JOIN EMPLEADOS E   ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE INNER JOIN CORTES C   ON N.TIENDA=C.TIENDA AND N.NOCAJA=C.CAJA INNER JOIN CLIENTES CL ON CL.CLAVE=N.CLIENTE AND CL.TIENDA=N.TIENDA left JOIN CLIENTERFC CR ON CR.CLIENTE=CL.CLAVE AND CL.TIENDA=CR.TIENDA AND CR.REGISTRO=0 WHERE S.CLAVE='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=" + CAJA.ToString + " AND N.NOTA=" + LANOTA.ToString + "  "
            QUER = "SELECT S.NOMBRECOMUN,S.NOMBREFISCAL,D.NOTA,D.PRODUCTO CODIGO,P.NOMBRECORTO PRODUCTO,D.CANTIDAD,PRECIO=DBO.DIVISIONSINCERO(D.TOTAL,D.CANTIDAD),D.TOTAL,SUBTOTAL=DBO.ELSUBTOTAL(D.PRODUCTO,D.TOTAL),IVA=DBO.ELIVA(D.PRODUCTO,D.TOTAL),E.NOMBRE EMPLEADO,N.FECHA,S.DIRECCION,S.CIUDAD,S.RFC,S.TELEFONO,N.PAGACON PAGA,N.CAMBIO,N.NOCAJA,TIPO='NOTA',VNOM='',VUNI='',D.DESCUENTO,CL.NOMBRE,S.COMENTARIO1,S.COMENTARIO2,S.COMENTARIO3,S.CP,CL.TELEFONO TEL,CL.DIRECCION DIR,ISNULL(CR.RFC,'') R ,TP.NOMBRE TIPOPAGO,N.CLIENTE CCLIENTE,REGIMEN='" + frmPrincipal.Regimen + "' FROM DETALLENOTASDEVENTA D INNER JOIN TIENDAS S ON D.TIENDA=S.CLAVE INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE INNER JOIN NOTASDEVENTA N ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA INNER JOIN EMPLEADOS E ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE INNER JOIN CORTES C ON N.TIENDA=C.TIENDA AND N.NOCAJA=C.CAJA INNER JOIN CLIENTES CL ON CL.CLAVE=N.CLIENTE AND CL.TIENDA=N.TIENDA INNER JOIN TIPOSPAGOS TP ON N.TIPOPAGO=TP.CLAVE left JOIN CLIENTERFC CR ON CR.CLIENTE=CL.CLAVE AND CL.TIENDA=CR.TIENDA AND CR.REGISTRO=0  WHERE S.CLAVE='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=" + CAJA.ToString + " AND N.NOTA=" + LANOTA.ToString + "  "
            If frmPrincipal.SucursalBase = "MZT" Then
                Dim REPI As New rptNotaVentaMZT
                IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), 1, "")
            Else
                Dim REPI As New rptNotaDeVenta
                IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), 1, "")
            End If
        Catch ex As Exception
            Dim xyz As Short
            xyz = MessageBox.Show("No se imprimió la nota, ¿Desea volver a intentar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz = 6 Then
                Return False
            Else
                MessageBox.Show("Utilice la opción reimprimir nota ( " + TXTNOTA.Text + " )", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return True
            End If
        End Try
        Return True
    End Function
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
        If Not CHECACANTIDADES() Then
            Exit Sub
        End If

        Dim TP As Integer
        If CBTP.SelectedIndex = 0 Then
            TP = 1
        End If
        If CBTP.SelectedIndex = 1 Then
            If frmPrincipal.PagoTarjeta = False Then
                MessageBox.Show("Por el momento el pago con tarjeta ha sido desactivado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            TP = 2
        End If
        If CBTP.SelectedIndex = 3 Then
            TP = 3
        End If

        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If


        Dim SQL As New SqlClient.SqlCommand
        SQL.Connection = frmPrincipal.CONX
        SQL.CommandType = CommandType.StoredProcedure
        SQL.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQL.Parameters.Add("@NOT", SqlDbType.Int).Value = TXTNOTA.Text.ToString
        SQL.Parameters.Add("@TOT", SqlDbType.Float).Value = TOT.ToString
        SQL.Parameters.Add("@CAJA", SqlDbType.Int).Value = CAJA.ToString
        SQL.Parameters.Add("@CAJE", SqlDbType.Int).Value = CAJERA.ToString
        SQL.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        SQL.Parameters.Add("@OBS", SqlDbType.VarChar).Value = "MODIFICACION DE NOTA"
        SQL.Parameters.Add("@CLI", SqlDbType.Int).Value = CLIENTE.ToString

        SQL.CommandText = "SPNOTASCANCELADAS"
        SQL.ExecuteNonQuery()



        If HAYZ() Then
            Dim xyz As Short
            xyz = MessageBox.Show("Se ha realizado un corte Z este día, la(s) nota(s) cobrada(s) aparecerán en el corte del día siguiente, ¿Desea continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz <> 6 Then
                Exit Sub
            End If
            LANOTA = CARGANOTA1.ToString

            Dim SQLIMP As New SqlClient.SqlCommand("UPDATE NOTASDEVENTA SET ESTADO=1 WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND NOCAJA=" + CAJA.ToString + " AND ESTADO=3 AND FECHA>=(SELECT DBO.LAFECHA())", frmPrincipal.CONX)
            SQLIMP.CommandTimeout = 300
            SQLIMP.ExecuteNonQuery()
            SQLIMP.Dispose()

            Dim SQLGUARDA1 As New SqlClient.SqlCommand("INSERT INTO NOTASDEVENTA(TIENDA,NOTA,TOTAL,ESTADO,NOCAJA,CAJERA,TIPOPAGO,FECHA,CLIENTE) VALUES (@TI,@NOTA,@TOT,@EDO,@NOCAJA,@EMP,@TP,@FEC,@CLIE)", frmPrincipal.CONX)
            SQLGUARDA1.CommandTimeout = 300
            SQLGUARDA1.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
            SQLGUARDA1.Parameters.Add("@NOTA", SqlDbType.Int).Value = LANOTA
            SQLGUARDA1.Parameters.Add("@TOT", SqlDbType.Float).Value = CType(TXTTOT.Text, Double)
            SQLGUARDA1.Parameters.Add("@EMP", SqlDbType.Int).Value = CAJERA.ToString
            SQLGUARDA1.Parameters.Add("@EDO", SqlDbType.Int).Value = 1
            SQLGUARDA1.Parameters.Add("@NOCAJA", SqlDbType.Int).Value = CAJA.ToString
            SQLGUARDA1.Parameters.Add("@TP", SqlDbType.Int).Value = TP
            SQLGUARDA1.Parameters.Add("@CLIE", SqlDbType.Int).Value = CLIENTE.ToString
            SQLGUARDA1.Parameters.Add("@FEC", SqlDbType.DateTime).Value = FZ.Date.AddHours(33)

            SQLGUARDA1.ExecuteNonQuery()
            TXTNOTA.Text = LANOTA.ToString
            SQLGUARDA1.Dispose()
        Else

            LANOTA = CARGANOTA1.ToString
            Dim SQLGUARDA1 As New SqlClient.SqlCommand("INSERT INTO NOTASDEVENTA(TIENDA,NOTA,TOTAL,ESTADO,NOCAJA,CAJERA,TIPOPAGO,FECHA,CLIENTE) VALUES (@TI,@NOTA,@TOT,@EDO,@NOCAJA,@EMP,@TP,GETDATE(),@CLIE)", frmPrincipal.CONX)
            SQLGUARDA1.CommandTimeout = 300
            SQLGUARDA1.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
            SQLGUARDA1.Parameters.Add("@NOTA", SqlDbType.Int).Value = LANOTA
            SQLGUARDA1.Parameters.Add("@TOT", SqlDbType.Float).Value = CType(TXTTOT.Text, Double)
            SQLGUARDA1.Parameters.Add("@EMP", SqlDbType.Int).Value = CAJERA.ToString
            SQLGUARDA1.Parameters.Add("@EDO", SqlDbType.Int).Value = 1
            SQLGUARDA1.Parameters.Add("@NOCAJA", SqlDbType.Int).Value = CAJA.ToString
            SQLGUARDA1.Parameters.Add("@TP", SqlDbType.Int).Value = TP
            SQLGUARDA1.Parameters.Add("@CLIE", SqlDbType.Int).Value = CLIENTE.ToString
            SQLGUARDA1.CommandTimeout = 300
            SQLGUARDA1.ExecuteNonQuery()
            SQLGUARDA1.Dispose()
            TXTNOTA.Text = LANOTA.ToString
        End If

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
            SQLDETALLES.Parameters("@TOT").Value = DGV.Item(5, X).Value
            SQLDETALLES.Parameters("@DES").Value = DGV.Item(3, X).Value
            SQLDETALLES.Parameters("@REG").Value = X
            SQLDETALLES.ExecuteNonQuery()
        Next
        SQLDETALLES.Dispose()

        'LISTANOAPARECE.Clear()


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

        End Try


        frmCambio.CAMBIO(CType(TXTCAMBIO.Text, Double))
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
        TXTNOTA.Text = CARGANOTA1.ToString
        CBTP.SelectedIndex = 0
        TXTDESC.Text = 0
        CHECATABLA()
        ACTIVAR(True)
    End Sub
    Private Sub BTNCOBRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCOBRAR.Click
        guardar()
    End Sub

    Private Sub BTNCANCELAR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
        frmPrincipal.PRE.EliminarNota()
        CHECATABLA()
        CHECAPRODUCTOS()
        DGV.Refresh()
        LIMPIAR()
    End Sub

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

    Private Sub TXTEFECTIVO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTEFECTIVO.TextChanged
        If TXTEFECTIVO.Text = "" Or TXTEFECTIVO.Text = "0" Then
            TXTCAMBIO.Text = "0"
        Else
            CHECACANTIDADES()
        End If
    End Sub
    Private Function CHECAAGREGADO(ByVal CODIGO As String) As Boolean
        If TXTCANT.Text > LBLEXIS.Text Then
            Return False
        End If
        Dim c As Integer
        c = 0
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(0, X).Value = CODIGO Then
                c = c + DGV.Item(2, X).Value
            End If
        Next
        c = c + TXTCANT.Text
        If c > LBLEXIS.Text Then
            Return False
        End If
        Return True
    End Function
    Private Sub frmModificaNotas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            Dim VC As New frmNotaDeVentaTactil
            VC.ShowDialog()
            ' MessageBox.Show("activar tactil")
        End If
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT P.CLAVE,P.NOMBRE PRODCUTO,P." + frmPrincipal.SucursalBase + "  FROM PRODUCTOS P  WHERE P.ACTIVO=1 AND P.EMPRESA=" + frmPrincipal.Empresa + " ", " AND P.NOMBRE ", " ORDER BY P.NOMBRE ", "Busqueda de productos", "Nombre del producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                TXTCOD.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
                If Not CHECAPROD() Then
                    TXTCOD.Text = ""
                    TXTCOD.Focus()
                    Exit Sub
                End If
                If Not CHECAAGREGADO(TXTCOD.Text) Then
                    MessageBox.Show("No puede agregar mas producto, revise su inventario por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    TXTCOD.Text = ""
                    TXTCOD.Focus()
                    TXTCANT.Text = 1
                    Exit Sub
                End If


                Dim DESC As Double
                DESC = 0
                Try
                    If DGV.Rows.Count >= 22 Then
                        MessageBox.Show("ha rebasado el limite de productos por nota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Exit Sub
                    End If
                    DESC = CType(TXTDESC.Text, Double)
                Catch ex As Exception
                End Try
                Dim X As Integer
                For X = 0 To DTPRECIOSCLIENTES.Rows.Count - 1
                    If TXTCOD.Text = DTPRECIOSCLIENTES.Rows(X).Item(0).ToString Then
                        LBLPRE.Text = DTPRECIOSCLIENTES.Rows(X).Item(1).ToString
                    End If
                Next
                frmPrincipal.PRE.Agregar(TXTCOD.Text, LBLNOM.Text, CType(TXTCANT.Text, Double), LBLPRE.Text, DESC)
                Me.DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
                DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns(0).ReadOnly = True
                DGV.Columns(1).ReadOnly = True
                DGV.Columns(2).ReadOnly = True
                DGV.Columns(3).ReadOnly = True
                DGV.Columns(5).ReadOnly = True
                CHECATABLA()
                'AGREGAR(TXTCOD.Text, LBLNOM.Text, CType(TXTCANT.Text, Double), LBLPRE.Text)
                TXTCOD.Text = ""
                CHECAPRODUCTOS()
                TXTCOD.Focus()
            End If
        End If


        If e.KeyCode = Keys.F5 Then
            If DGV.Rows.Count <= 0 Then
                MessageBox.Show("No hay ningun producto agregado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            Else
                frmPrincipal.PRE.Quitar(DGV.Item(0, DGV.CurrentRow.Index).Value)
                ' DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
                CHECATABLA()
            End If
            CHECAPRODUCTOS()
        End If


    End Sub

    Private Sub TXTCOD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOD.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTCOD.Text = "" Then
            Else
                If Not CHECAPROD() Then
                    TXTCOD.Text = ""
                    TXTCOD.Focus()
                    Exit Sub
                End If
                Dim DESC As Double
                DESC = 0
                If Not CHECAAGREGADO(TXTCOD.Text) Then
                    MessageBox.Show("No puede agregar mas producto, revise su inventario por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    TXTCOD.Text = ""
                    TXTCOD.Focus()
                    TXTCANT.Text = 1
                    Exit Sub
                End If
                Try
                    DESC = CType(TXTDESC.Text, Double)
                Catch ex As Exception

                End Try

                If DGV.Rows.Count >= 22 Then
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
                DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                DGV.Columns(0).ReadOnly = True
                DGV.Columns(1).ReadOnly = True
                DGV.Columns(2).ReadOnly = True
                DGV.Columns(3).ReadOnly = True
                DGV.Columns(5).ReadOnly = True


                CHECATABLA()
                CHECAPRODUCTOS()
                TXTCANT.Text = "1"
                TXTCOD.Text = ""
                TXTCOD.Focus()
            End If
        End If
    End Sub
End Class