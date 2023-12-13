Public Class frmCompraExpress
    Dim Tienda, IdProducto, Forma, IdUnidad As String
    Dim Cantidad As Double
    Private Sub frmCompraExpress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        TXTCANT.SelectAll()
        TXTCANT.Focus()
    End Sub

    Private Sub TXTCANT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCANT.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNGUARDAR.Focus()
        End If
    End Sub

    Private Sub BTNGUARDAR_Click(sender As Object, e As EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub

    Public Sub Mostrar(ByVal pTienda As String, ByVal pIdProducto As String, ByVal pNombreProducto As String, ByVal pIdUnidad As String, ByVal pCantidad As Double, ByVal pForma As String)
        LBLNPRO.Text = pNombreProducto
        Tienda = pTienda
        IdProducto = pIdProducto
        IdUnidad = pIdUnidad
        Cantidad = pCantidad
        TXTCANT.Text = pCantidad.ToString
        Forma = pForma

        Me.ShowDialog()
    End Sub
    Private Sub GUARDAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim CANT As Double
        Try
            CANT = CType(TXTCANT.Text, Double)
        Catch ex As Exception
            TXTCANT.SelectAll()
            TXTCANT.Focus()
            OPMsgError("Cantidad no válida")
            Exit Sub
        End Try
        If CANT <= 0 Then
            TXTCANT.SelectAll()
            TXTCANT.Focus()
            OPMsgError("Cantidad no válida")
            Exit Sub
        End If
        Dim NOCOMPRA As Integer
        NOCOMPRA = BDExtraeUnDato("SELECT DBO.SIGUIENTECOMPRA('" + Tienda + "')", frmPrincipal.CadenaConexion)
        Dim L As String
        L = BDExtraeUnDato("SELECT DBO.SIGLOTE('" + frmPrincipal.SucursalBase + "','" + IdProducto + "')", frmPrincipal.CadenaConexion)
        'TRAN = frmPrincipal.CONX.BeginTransaction(IsolationLevel.RepeatableRead)
        Dim SQLBORRA As New SqlClient.SqlCommand("DELETE FROM COMPRAS WHERE TIENDA='" + Tienda + "' AND NOORDEN=" + NOCOMPRA.ToString, frmPrincipal.CONX)
        SQLBORRA.CommandTimeout = 300
        SQLBORRA.ExecuteNonQuery()
        SQLBORRA.CommandText = "DELETE FROM DETALLECOMPRAS WHERE TIENDA='" + Tienda + "' AND NOORDEN=" + NOCOMPRA.ToString
        SQLBORRA.ExecuteNonQuery()
        SQLBORRA.Dispose()

        Dim SQLGUARDACOMPRA As New SqlClient.SqlCommand("INSERT INTO COMPRAS (TIENDA,NOORDEN,FACTURA,PROVEEDOR,FECHA,USUARIO,CONCEPTO,SUBTOTAL,IVA,TOTAL,PAGADO,ESNOTA,PEDIMENTO) VALUES ('" + Tienda + "'," + NOCOMPRA.ToString + ",'N/A','1',GETDATE(),'" + frmPrincipal.Usuario + "','COMPRA EXPRESS " + Forma + "',0,0,0,0,@NF,'')", frmPrincipal.CONX)
        SQLGUARDACOMPRA.CommandTimeout = 300
        SQLGUARDACOMPRA.Parameters.Add("@NF", SqlDbType.Bit)

        SQLGUARDACOMPRA.Parameters("@NF").Value = 0

        SQLGUARDACOMPRA.ExecuteNonQuery()
        SQLGUARDACOMPRA.Dispose()

        Dim SQLGUARDADETALLECOMPRA As New SqlClient.SqlCommand("INSERT INTO DETALLECOMPRAS (TIENDA,NOORDEN,PRODUCTO,CANTIDAD,UNIDAD,TOTAL,REGISTRO,DESCUENTO)VALUES (@TI,@NOO,@PRO,@CANT,@UNI,@TOT,@REG,@DESC)", frmPrincipal.CONX)
        SQLGUARDADETALLECOMPRA.CommandTimeout = 300
        SQLGUARDADETALLECOMPRA.Parameters.Add("@TI", SqlDbType.VarChar, 10)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@NOO", SqlDbType.Int)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@PRO", SqlDbType.VarChar, 50)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@CANT", SqlDbType.Float)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@TOT", SqlDbType.Float)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@REG", SqlDbType.Int)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@UNI", SqlDbType.Int)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@DESC", SqlDbType.Float)


        SQLGUARDADETALLECOMPRA.Parameters("@TI").Value = Tienda
        SQLGUARDADETALLECOMPRA.Parameters("@NOO").Value = NOCOMPRA



        Dim SQLGUARDALOTES As New SqlClient.SqlCommand("SPLOTES", frmPrincipal.CONX)
        SQLGUARDALOTES.CommandType = CommandType.StoredProcedure
        SQLGUARDALOTES.CommandTimeout = 300
        SQLGUARDALOTES.Parameters.Add("@TI", SqlDbType.VarChar).Value = Tienda
        SQLGUARDALOTES.Parameters.Add("@CPRO", SqlDbType.VarChar).Value = IdProducto
        SQLGUARDALOTES.Parameters.Add("@COS", SqlDbType.Float).Value = 0
        SQLGUARDALOTES.Parameters.Add("@PROO", SqlDbType.VarChar).Value = 1
        Try
            SQLGUARDALOTES.ExecuteNonQuery()
        Catch ex As Exception

        End Try

        SQLGUARDADETALLECOMPRA.Parameters("@PRO").Value = L
        SQLGUARDADETALLECOMPRA.Parameters("@CANT").Value = CANT
        SQLGUARDADETALLECOMPRA.Parameters("@TOT").Value = 0
        SQLGUARDADETALLECOMPRA.Parameters("@UNI").Value = IdUnidad
        SQLGUARDADETALLECOMPRA.Parameters("@REG").Value = 1
        SQLGUARDADETALLECOMPRA.Parameters("@DESC").Value = 0

        SQLGUARDADETALLECOMPRA.ExecuteNonQuery()


        SQLGUARDADETALLECOMPRA.Dispose()

        'Dim xyz As Short
        'xyz = MessageBox.Show("¿Desea imprimir el ticket de compra?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        'If xyz = 6 Then
        '    IMPRIMIR(NOCOMPRA)
        'End If
        'MessageBox.Show("La información ha sido guardada exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
        Exit Sub
    End Sub
    Private Sub IMPRIMIR(ByVal NOCOMPRA As Integer)
        Dim QUERY As String
        Dim REP As New rptTicketCompra
        QUERY = "SELECT T.NOMBRECOMUN TIENDA,D.NOORDEN,PR.NOMBRE PROVEEDOR,C.FECHA,P.NOMBRE PRODUCTO,D.CANTIDAD,U.NOMBRE UNIDAD,D.TOTAL,C.SUBTOTAL,C.IVA,C.TOTAL TOTALCOMPRA FROM COMPRAS C INNER JOIN DETALLECOMPRAS D ON C.TIENDA=D.TIENDA AND C.NOORDEN=D.NOORDEN INNER JOIN LOTES L ON L.CLAVE=D.PRODUCTO INNER JOIN PRODUCTOS P  ON P.CP=L.PRODUCTO INNER JOIN UNIDADES U ON U.CLAVE=D.UNIDAD INNER JOIN TIENDAS T ON T.CLAVE=C.TIENDA INNER JOIN  PROVEEDORES PR  ON P.EMPRESA=T.EMPRESA AND PR.CLAVE=C.PROVEEDOR WHERE C.NOORDEN='" + NOCOMPRA.ToString + "'  AND C.TIENDA='" + Tienda + "' ORDER BY D.REGISTRO"
        IMPRIMIRREPORTE(REP, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), 1, "")
    End Sub
End Class