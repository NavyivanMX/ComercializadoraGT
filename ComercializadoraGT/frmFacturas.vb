Public Class frmFacturas
    Dim LREG As New List(Of String)
    Dim CLIENTE As String
    Dim LISTANOTAS As New List(Of Integer)
    Dim LISTAESNOTA As New List(Of Boolean)
    Private Sub frmFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        RBNOTA.Checked = True
        LIMPIAR()
        TXTCLI.Focus()
        TXTCLI.SelectAll()
    End Sub
   
    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT TIENDA,CLAVE,NOMBRE,DIRECCION,TELEFONO FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' ", "  AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 2, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CLIENTE = frmClsBusqueda.TREG.Rows(0).Item(1).ToString
            TXTCLI.Text = CLIENTE.ToString
            CARGACLIENTE(frmClsBusqueda.TREG.Rows(0).Item(1).ToString, frmClsBusqueda.TREG.Rows(0).Item(2).ToString)
        End If
    End Sub
    Private Sub CARGACLIENTE(ByVal CLAVE As String, ByVal NOM As String)
        TXTNCLI.Text = NOM
        If Not OPLlenaComboBox(CBRFC, LREG, "SELECT REGISTRO,NOMBREFISCAL FROM CLIENTERFC WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLIENTE=" + CLIENTE + " ORDER BY NOMBREFISCAL", frmPrincipal.CadenaConexion) Then
            MessageBox.Show("El cliente no tiene datos de facturación,favor de ingresar datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Dim VCRFC As New frmClientesRFC
            VCRFC.CARGACLI(TXTCLI.Text)
            VCRFC.ShowDialog()
        End If
        CBRFC.Enabled = True
        TXTNOTA.Enabled = True
    End Sub
    Private Sub CARGADATOSRFC()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT NOMBREFISCAL, RFC,DIRECCION,CP,CIUDAD FROM CLIENTERFC WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLIENTE=" + CLIENTE + " AND REGISTRO=" + LREG(CBRFC.SelectedIndex), frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            TXTNFIS.Text = LEC(0)
            TXTRFC.Text = LEC(1)
            TXTDFIS.Text = LEC(2)
            TXTCP.Text = LEC(3)
            TXTCD.Text = LEC(4)
        End If
        LEC.Close()
        SQL.Dispose()
    End Sub
    Private Function REVISAFACTURA() As Boolean
        If TXTFAC.Text = "" Then
            Return False
        End If
        If String.IsNullOrEmpty(TXTFAC.Text) Then
            Return False
        End If
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT FACTURA FROM FACTURASCLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND FACTURA='" + TXTFAC.Text + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            LEC.Close()
            Return False
        Else
            LEC.Close()
        End If
        Dim SQL2 As New SqlClient.SqlCommand("SELECT FACTURA FROM FACTURASCLIENTESPG WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND FACTURA='" + TXTFAC.Text + "'", frmPrincipal.CONX)
        Dim LEC2 As SqlClient.SqlDataReader
        LEC2 = SQL2.ExecuteReader
        If LEC2.Read Then
            LEC2.Close()
            Return False
        Else
            LEC2.Close()
        End If
        Return True
    End Function
    Private Sub CBRFC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBRFC.SelectedIndexChanged
        CARGADATOSRFC()
    End Sub
    Private Sub CARGAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim LEYO As Boolean
        LEYO = False
        Dim SQL As New SqlClient.SqlCommand("SELECT NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE=" + TXTCLI.Text, frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            TXTNCLI.Text = LEC(0)
            LEYO = True
            LEC.Close()
        Else
            LEC.Close()
        End If
        CLIENTE = TXTCLI.Text
        SQL.Dispose()
        If LEYO Then
            CARGACLIENTE(CLIENTE, TXTNCLI.Text)
        Else
            MessageBox.Show("Cliente no encontrado, favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub TXTCLI_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLI.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            If TXTCLI.Text = "" Then
            Else
                CARGAR()
            End If
        End If
    End Sub

    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        If TXTNOTA.Text = "" Then
        Else
            If DGV.Rows.Count = 22 Then
                MessageBox.Show("ha rebasado el limite de productos por factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If
            If VALIDANOTA(TXTNOTA.Text) Then
                AGREGAR(True)
            Else
                MessageBox.Show("Nota no Existe o ha sido Agregada a una Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        End If
    End Sub
    Dim TABLA As String
    Dim VESNOTA As String
    Private Function VALIDANOTA(ByVal NOTA As String) As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        If RBNOTA.Checked Then
            TABLA = "NOTASDEVENTA"
            VESNOTA = "1"
        Else
            TABLA = "NOTASDEVENTACREDITO"
            VESNOTA = "0"
        End If
        Dim QUERY As String
        QUERY = "SELECT N.NOTA FROM " + TABLA + " N INNER JOIN DETALLE" + TABLA + " D ON N.TIENDA=D.TIENDA AND N.NOTA=D.NOTA WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA=" + TXTNOTA.Text + " AND D.PRODUCTO<>'CREDITO' AND N.NOTA NOT IN (SELECT NOTA FROM DETALLEFACTURASCLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ESNOTA=" + VESNOTA + ")"
        Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            LEC.Close()
            Return True
        Else
            LEC.Close()
            Return False
        End If
        Return True
    End Function
    Private Sub AGREGAR(ByVal QUITA As Boolean)
        If TXTNOTA.Text = "" Then
            Exit Sub
        End If
        Dim ESNOTA As Boolean
        If RBNOTA.Checked Then
            ESNOTA = True
        Else
            ESNOTA = False
        End If
        Dim TN As Integer
        Dim ENCONTRADO As Boolean = False
        If QUITA = False Then
            For X = 0 To LISTANOTAS.Count - 1
                If LISTANOTAS(X) = CType(TXTNOTA.Text, Integer) And LISTAESNOTA(X) = ESNOTA Then
                    TN = X
                    ENCONTRADO = True
                End If
            Next
            If ENCONTRADO Then
                LISTANOTAS.RemoveAt(TN)
                LISTAESNOTA.RemoveAt(TN)
            End If
        Else
            If Not frmPrincipal.CHECACONX() Then
                Exit Sub
            End If
            If Not frmPrincipal.CHECACONX() Then
                Exit Sub
            End If
            Dim SQLYA As New SqlClient.SqlCommand("SELECT NOTA FROM " + TABLA + " WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND NOTA=" + TXTNOTA.Text + " AND NOTA NOT IN (SELECT NOTA FROM DETALLEFACTURASCLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ESNOTA=" + VESNOTA + ")", frmPrincipal.CONX)
            Dim LECYA As SqlClient.SqlDataReader
            LECYA = SQLYA.ExecuteReader
            If LECYA.Read Then
                For X = 0 To LISTANOTAS.Count - 1
                    If LISTANOTAS(X) = CType(TXTNOTA.Text, Integer) And LISTAESNOTA(X) = ESNOTA Then
                        MessageBox.Show("Esta Nota ya ha sido Agregada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        LECYA.Close()
                        TXTNOTA.SelectAll()
                        TXTNOTA.Focus()
                        Exit Sub
                    End If
                Next
                LISTANOTAS.Add(CType(TXTNOTA.Text, Integer))
                LISTAESNOTA.Add(ESNOTA)
            Else
                MessageBox.Show("Esta Nota No se Encuentra Registrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                LECYA.Close()
                TXTNOTA.SelectAll()
                TXTNOTA.Focus()
                Exit Sub
            End If
            LECYA.Close()
        End If
        'LBLCAJ.Text = ""
        'For X = 0 To LISTANOTAS.Count - 1
        '        LBLCAJ.Text = LBLCAJ.Text + ", " + LISTANOTAS(X).ToString
        '       Next
        NOTASAGREGADAS()
    End Sub
    Private Sub NOTASAGREGADAS()
        DGV.Rows.Clear()
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        For X = 0 To LISTANOTAS.Count - 1
            If LISTAESNOTA(X) Then
                Dim SQL As New SqlClient.SqlCommand("SELECT D.NOTA,D.PRODUCTO,P.NOMBRE DESCRIPCION,D.CANTIDAD,P.PRECIO,D.TOTAL FROM DETALLENOTASDEVENTA D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + LISTANOTAS(X).ToString, frmPrincipal.CONX)
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
                End While
                LECTOR.Close()
            Else
                Dim SQL As New SqlClient.SqlCommand("SELECT D.NOTA,D.PRODUCTO,P.NOMBRE DESCRIPCION,D.CANTIDAD,P.PRECIO,D.TOTAL FROM DETALLENOTASDEVENTACREDITO D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + LISTANOTAS(X).ToString, frmPrincipal.CONX)
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
                End While
                LECTOR.Close()
            End If
        Next
        CHECATABLA()
    End Sub
    Dim CNUM As New num2text
    Private Function CHECATABLA() As Boolean
        If DGV.Rows.Count = 0 Then
            TXTSUB.Text = 0
            TXTIVA.Text = 0
            TXTTOT.Text = 0
            TXTLETRA.Text = CNUM.Letras(TXTTOT.Text)
            TXTNOTA.Focus()
            TXTNOTA.SelectAll()
            Return False
        End If
        CALCULASIT()
        TXTLETRA.Text = CNUM.Letras(TXTTOT.Text)
        TXTNOTA.Focus()
        TXTNOTA.SelectAll()
        Return True
    End Function
    Private Function CALCULASIT() As Boolean
        Dim X, Y As Integer
        Dim S, I, T As Double
        S = 0
        T = 0
        Dim QUERY As String
        Dim DT As New DataTable
        For X = 0 To LISTANOTAS.Count - 1

            DT.Rows.Clear()
            DT.Columns.Clear()
            DT.Clear()
            If LISTAESNOTA(X) Then
                QUERY = "SELECT dbo.NULL2NUMERIC(SUM(DBO.SUBTOTAL(D.PRODUCTO,D.TOTAL))),0 FROM DETALLENOTASDEVENTA D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE AND P.IVA=0 WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + LISTANOTAS(X).ToString + "  UNION ALL SELECT DBO.NULL2NUMERIC(SUM(DBO.SUBTOTAL(D.PRODUCTO,D.TOTAL))),DBO.NULL2NUMERIC(SUM(DBO.SUBTOTAL(D.PRODUCTO,D.TOTAL)*.16)) FROM DETALLENOTASDEVENTA D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE AND P.IVA=1 WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + LISTANOTAS(X).ToString
            Else
                QUERY = "SELECT DBO.NULL2NUMERIC(SUM(DBO.SUBTOTAL(D.PRODUCTO,D.TOTAL))),0 FROM DETALLENOTASDEVENTACREDITO D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE AND P.IVA=0 WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + LISTANOTAS(X).ToString + "  UNION ALL SELECT DBO.NULL2NUMERIC(SUM(DBO.SUBTOTAL(D.PRODUCTO,D.TOTAL))),DBO.NULL2NUMERIC(SUM(DBO.SUBTOTAL(D.PRODUCTO,D.TOTAL)*.16)) FROM DETALLENOTASDEVENTACREDITO D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE AND P.IVA=1 WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + LISTANOTAS(X).ToString
            End If
            DT = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
            For Y = 0 To DT.Rows.Count - 1
                S += DT.Rows(Y).Item(0)
                I += DT.Rows(Y).Item(1)
            Next
        Next
        T = S + I
        TXTTOT.Text = FormatNumber(T, 2).ToString()
        TXTSUB.Text = FormatNumber(S, 2).ToString()
        TXTIVA.Text = FormatNumber(I, 2).ToString()
        Return True
    End Function

    Private Sub TXTNOTA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOTA.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(TXTNOTA.Text) Then
                Exit Sub
            Else
                If VALIDANOTA(TXTNOTA.Text) Then
                    AGREGAR(True)
                Else
                    MessageBox.Show("Nota no Existe o ha sido Agregada a una Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    TXTNOTA.Focus()
                    TXTNOTA.SelectAll()
                End If
            End If
        End If
    End Sub
    Private Function VALIDACLIENTE() As Boolean
        If TXTCLI.Text = "" Then
            Return False
        End If
        If String.IsNullOrEmpty(TXTCLI.Text) Then
            Return False
        End If
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT CLAVE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE=" + TXTCLI.Text + "", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            LEC.Close()
            Return True
        Else
            LEC.Close()
            Return False
        End If
        Return False
    End Function
    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        If Not VALIDACLIENTE Then
            MessageBox.Show("Favor de verificar el cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If Not REVISAFACTURA() Then
            MessageBox.Show("Este número de factura ya se ha utilizado en esta tienda, favor de escribir otro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
    End Sub
    Private Sub GUARDAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO FACTURASCLIENTES (TIENDA,FACTURA,CLIENTE,FACCLIENTE,FECHA,TOTAL) VALUES ('" + frmPrincipal.SucursalBase + "','" + TXTFAC.Text + "'," + CLIENTE + "," + LREG(CBRFC.SelectedIndex) + ",@FEC," + CType(TXTTOT.Text, Double).ToString + ")", frmPrincipal.CONX)
        SQL.Parameters.Add("@FEC", SqlDbType.DateTime).Value = DTDE.Value.Date
        SQL.CommandTimeout = 300
        SQL.ExecuteNonQuery()
        SQL.Parameters.Clear()
        SQL.CommandText = "INSERT INTO DETALLEFACTURASCLIENTES (TIENDA,FACTURA,NOTA,ESNOTA) VALUES ('" + frmPrincipal.SucursalBase + "','" + TXTFAC.Text + "',@NOTA,@ESNOTA)"
        SQL.Parameters.Add("@NOTA", SqlDbType.Int)
        SQL.Parameters.Add("@ESNOTA", SqlDbType.Bit)
        Dim X As Integer
        For X = 0 To LISTANOTAS.Count - 1
            SQL.Parameters("@NOTA").Value = LISTANOTAS(X)
            SQL.Parameters("@ESNOTA").Value = LISTAESNOTA(X)
            SQL.ExecuteNonQuery()
        Next
        SQL.Dispose()
        MessageBox.Show("La información ha sido guardada, se mostrará la factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Dim REP As New rptFactura
        Dim S, I, T As Double
        S = CType(TXTSUB.Text, Double)
        I = CType(TXTIVA.Text, Double)
        T = CType(TXTTOT.Text, Double)
        Dim QUERY As String
        QUERY = "SELECT F.FECHA,R.NOMBREFISCAL,R.DIRECCION,R.CIUDAD,R.RFC,D.CANTIDAD,P.NOMBRE,PRECIO=CONVERT(NUMERIC(15,2), DBO.ELPRECIO(P.CLAVE,D.CANTIDAD,D.TOTAL),2),CONVERT(NUMERIC(15,2), DBO.ELTOTALFAC(P.CLAVE,D.TOTAL),2)TOTAL, SUBTOTAL=CONVERT(NUMERIC(15,2),DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,1)+DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,0),2), IVA=CONVERT(NUMERIC(15,2),DBO.IVATOTALFACTURA(D.TIENDA,F.FACTURA),2) ,ELTOTAL=F.TOTAL,CCLETRA='" + TXTLETRA.Text + "',R.CP,U.NOMBRE UNIDAD,SUBTOTALPRODUCTOSCONIVA=DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,1),SUBTOTALPRODUCTOSSINIVA=DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,0)  FROM FACTURASCLIENTES F INNER JOIN CLIENTERFC R   ON F.TIENDA=R.TIENDA AND F.CLIENTE=R.CLIENTE AND F.FACCLIENTE=R.REGISTRO INNER JOIN DETALLEFACTURASCLIENTES DF   ON F.TIENDA=DF.TIENDA AND F.FACTURA=DF.FACTURA INNER JOIN DETALLENOTASDEVENTA D   ON DF.TIENDA=D.TIENDA AND DF.NOTA=D.NOTA AND DF.ESNOTA=1 INNER JOIN PRODUCTOS P   ON D.PRODUCTO=P.CLAVE INNER JOIN UNIDADES U  ON U.CLAVE=P.UVENTA  WHERE F.TIENDA='" + frmPrincipal.SucursalBase + "' AND F.FACTURA='" + TXTFAC.Text + "'   UNION ALL   SELECT F.FECHA,R.NOMBREFISCAL,R.DIRECCION,R.CIUDAD,R.RFC,D.CANTIDAD,P.NOMBRE,PRECIO=CONVERT(NUMERIC(15,2), DBO.ELPRECIO(P.CLAVE,D.CANTIDAD,D.TOTAL),2),CONVERT(NUMERIC(15,2), DBO.ELTOTALFAC(P.CLAVE,D.TOTAL),2)TOTAL,SUBTOTAL=CONVERT(NUMERIC(15,2),DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,1)+DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,0),2), IVA=CONVERT(NUMERIC(15,2),DBO.IVATOTALFACTURA(D.TIENDA,F.FACTURA),2) ,ELTOTAL=F.TOTAL,CCLETRA='" + TXTLETRA.Text + "',R.CP,U.NOMBRE UNIDAD,SUBTOTALPRODUCTOSCONIVA=DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,1),SUBTOTALPRODUCTOSSINIVA=DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,0)   FROM FACTURASCLIENTES F INNER JOIN CLIENTERFC R   ON F.TIENDA=R.TIENDA AND F.CLIENTE=R.CLIENTE AND F.FACCLIENTE=R.REGISTRO INNER JOIN DETALLEFACTURASCLIENTES DF  ON F.TIENDA=DF.TIENDA AND F.FACTURA=DF.FACTURA INNER JOIN DETALLENOTASDEVENTACREDITO D   ON DF.TIENDA=D.TIENDA AND DF.NOTA=D.NOTA AND DF.ESNOTA=0 INNER JOIN PRODUCTOS P   ON D.PRODUCTO=P.CLAVE INNER JOIN UNIDADES U  ON U.CLAVE=P.UVENTA  WHERE F.TIENDA='" + frmPrincipal.SucursalBase + "' AND F.FACTURA='" + TXTFAC.Text + "'"
        MOSTRARREPORTE(REP, frmPrincipal.NombreComun + "  Factura " + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), "Enviar a OneNote 2007")

        'MOSTRARREPORTE(REP, frmPrincipal.NombreComun + "  Factura " + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString, BDLlenatabla("SELECT F.FECHA,R.NOMBREFISCAL,R.DIRECCION,R.CIUDAD,R.RFC,D.CANTIDAD,P.NOMBRE,P.PRECIO,D.TOTAL,SUBTOTAL=CONVERT(NUMERIC(15,2),(F.TOTAL/1.16),2),IVA=CONVERT(NUMERIC(15,2),(F.TOTAL/1.16*.16),2)  ,ELTOTAL=F.TOTAL,CCLETRA='" + Cantidad2Letras(DGV.Item(3, DGV.CurrentRow.Index).Value) + "' FROM FACTURASCLIENTES F INNER JOIN CLIENTERFC R ON F.TIENDA=R.TIENDA AND F.CLIENTE=R.CLIENTE AND F.FACCLIENTE=R.REGISTRO INNER JOIN DETALLEFACTURASCLIENTES DF ON F.TIENDA=DF.TIENDA AND F.FACTURA=DF.FACTURA INNER JOIN DETALLENOTASDEVENTA D ON DF.TIENDA=D.TIENDA AND DF.NOTA=D.NOTA INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE F.TIENDA='" + frmPrincipal.SucursalBase + "' AND F.FACTURA=" + TXTFAC.Text + "", frmPrincipal.CadenaConexion), "Enviar a OneNote 2007")
        LIMPIAR()
    End Sub
    Private Sub LIMPIAR()
        LISTANOTAS.Clear()
        LISTAESNOTA.Clear()
        DGV.Rows.Clear()
        TXTCD.Text = ""
        'TXTCLI.Text = ""
        TXTCP.Text = ""
        TXTDFIS.Text = ""
        TXTFAC.Text = ""
        TXTIVA.Text = ""
        TXTLETRA.Text = ""
        TXTNCLI.Text = ""
        TXTNFIS.Text = ""
        TXTNOTA.Text = ""
        CBRFC.Enabled = False
        TXTNOTA.Enabled = False
        CHECATABLA()
    End Sub
    Private Sub MOSTRARFACTURA()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TXTNOTA.Text = "" Then
        Else
            If VALIDANOTA(TXTNOTA.Text) Then
                AGREGAR(False)
            Else
                MessageBox.Show("Nota no existe o ha sido agregada a una factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        End If
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        'Dim REP As New rptFactura
        'MOSTRARREPORTE(REP, frmPrincipal.NombreComun + "  Factura " + TXTFAC.Text, BDLlenatabla("SELECT F.FECHA,R.NOMBREFISCAL,R.DIRECCION,R.CIUDAD,R.RFC,D.CANTIDAD,P.NOMBRE,P.PRECIO,D.TOTAL,SUBTOTAL=500.00,IVA=150.00,ELTOTAL=650.00,CCLETRA='Seis Cientos Cincuenta pesos 00/100 M.N.' FROM FACTURASCLIENTES F INNER JOIN CLIENTERFC R ON F.TIENDA=R.TIENDA AND F.CLIENTE=R.CLIENTE AND F.FACCLIENTE=R.REGISTRO INNER JOIN DETALLEFACTURASCLIENTES DF ON F.TIENDA=DF.TIENDA AND F.FACTURA=DF.FACTURA INNER JOIN DETALLENOTASDEVENTA D ON DF.TIENDA=D.TIENDA AND DF.NOTA=D.NOTA INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE F.TIENDA='" + frmPrincipal.SucursalBase + "' AND F.FACTURA=" + TXTFAC.Text + "", frmPrincipal.CadenaConexion))
        LIMPIAR()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim VC As New frmClientes
        VC.ShowDialog()
    End Sub
End Class