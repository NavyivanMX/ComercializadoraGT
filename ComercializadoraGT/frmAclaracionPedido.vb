Public Class frmAclaracionPedido
    Dim X As Integer
    Dim TABLAPRIN As New DataTable
    Dim TABLATEMP As New DataTable

    Private Sub frmAclaracionPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()
        Dim TP As Double
        TP = 0
        LBLART.Text = "Artículos: " + DGV.Rows.Count.ToString
        If TABLATEMP.Rows.Count = 0 Then
            BTNIMPRIMIR.Enabled = False
            BTNGUARDAR.Enabled = False
            SIIMP.Enabled = False
            NOIMP.Enabled = False
            LBLART.Text = "Artículos: 0"
        Else
            BTNIMPRIMIR.Enabled = True
            BTNGUARDAR.Enabled = True
            SIIMP.Enabled = True
            NOIMP.Enabled = True
            LBLART.Text = "Artículos: " + DGV.Rows.Count.ToString

        End If
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            TP = TP + DGV.Item(6, X).Value
        Next
        LBLTOTPED.Text = "Total pedido: " + FormatNumber(TP, 2).ToString
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        Dim SQLPED As New SqlClient.SqlCommand("SELECT S.NOMBRECOMUN,T.NOMBRE FROM PEDIDOS P INNER JOIN TIENDAS S ON P.TIENDA=S.CLAVE INNER JOIN TIPOSPEDIDOS T ON P.TIPOPEDIDO=T.CLAVE WHERE P.NOPEDIDO=" + LBLPED.Text + " ", frmPrincipal.CONX)
        SQLPED.CommandTimeout = 300
        Dim LECPED As SqlClient.SqlDataReader
        LECPED = SQLPED.ExecuteReader
        If LECPED.Read Then
            LBLSUC.Text = LECPED(0)
            LBLTP.Text = LECPED(1)
        End If
        LECPED.Close()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim NPED As Integer
        NPED = 4
        Dim SQL As New SqlClient.SqlCommand("SELECT ESTADO FROM PEDIDOS WHERE NOPEDIDO='" + LBLPED.Text + "'", frmPrincipal.CONX)
        SQL.CommandTimeout = 300
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            NPED = LEC(0)
        End If
        LEC.Close()
        SQLPED.Dispose()
        If NPED <> 4 Then
            MessageBox.Show("Este pedido no ha sido recibido, opción no válida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim QUERY As String
        QUERY = "SELECT DBO.ULTIMOLOTE(D.CP)LOTE,P.NOMBRE PRODUCTO,D.CANTIDAD,U.NOMBRE UNIDAD,CANTR CRECIBIDO,D.RECIBIDO,DIFERENCIA=D.CANTIDAD-D.CANTR,MARCAR=CONVERT(BIT,0),D.REGISTRO FROM DETALLEPEDIDOS2 D INNER JOIN LOTES L ON DBO.ULTIMOLOTE(D.CP)=L.CLAVE INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE  WHERE D.NOPEDIDO=" + LBLPED.Text + "  ORDER BY P.NOMBRE"
        TABLATEMP = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV.DataSource = TABLATEMP
        DGV.Refresh()
        If TABLATEMP.Rows.Count <= 0 Then
            MessageBox.Show("No se han generado el pedido o ya ha sido agregado al inventario de la sucursal", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).ReadOnly = True
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(3).ReadOnly = True
        DGV.Columns(5).ReadOnly = True
        DGV.Columns(8).ReadOnly = True

        CHECATABLA()

        MARCANORECIBIDOS()
    End Sub
    Private Sub MARCANORECIBIDOS()
        Dim X As Integer
        'For X = 0 To DGV.Rows.Count - 1
        For Each Row As DataGridViewRow In DGV.Rows
            If CType(Row.Cells(6).Value, Double) > 0 Then
                Row.Cells(0).Style = DgvCellEstilo(Color.Gold, Color.Black)
                Row.Cells(1).Style = DgvCellEstilo(Color.Gold, Color.Black)
                Row.Cells(2).Style = DgvCellEstilo(Color.Gold, Color.Black)
                Row.Cells(3).Style = DgvCellEstilo(Color.Gold, Color.Black)
                Row.Cells(4).Style = DgvCellEstilo(Color.Gold, Color.Black)
                Row.Cells(5).Style = DgvCellEstilo(Color.Gold, Color.Black)
                Row.Cells(6).Style = DgvCellEstilo(Color.Gold, Color.Black)
                Row.Cells(7).Style = DgvCellEstilo(Color.Gold, Color.Black)
                Row.Cells(8).Style = DgvCellEstilo(Color.Gold, Color.Black)

            Else

            End If
        Next
        'Next
    End Sub
    Private Sub LBLPED_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LBLPED.KeyPress
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

    Private Sub SIIMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SIIMP.Click
        Dim XYZ As Short
        XYZ = MessageBox.Show("Desea marcar los datos correctos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If XYZ = 6 Then
            For X = 0 To DGV.Rows.Count - 1
                DGV.Item(7, X).Value = True
            Next
        End If
    End Sub
    Private Sub NOIMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NOIMP.Click
        Dim XYZ As Short
        XYZ = MessageBox.Show("Desea desmarcar los datos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If XYZ = 6 Then
            For X = 0 To DGV.Rows.Count - 1
                DGV.Item(7, X).Value = False
            Next
        End If
    End Sub
    Private Sub RECIBIDOS()
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(4, X).Value = True Then
                Dim SQL As New SqlClient.SqlCommand("UPDATE DETALLEPEDIDOS2 SET RECIBIDO=1 WHERE PEDIDO=" + LBLPED.Text + " AND LOTE='" + DGV.Item(0, X).Value + "' ", frmPrincipal.CONX)
                SQL.CommandTimeout = 300
                SQL.ExecuteNonQuery()
                SQL.Dispose()
            End If
        Next
    End Sub
    Dim RENGLON As Integer
    Private Function GUARDAR2(ByVal REN As Integer) As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim SQLGUARDA As New SqlClient.SqlCommand("ACTUALIZAINVRES", frmPrincipal.CONX)
        SQLGUARDA.CommandType = CommandType.StoredProcedure
        SQLGUARDA.CommandTimeout = 300
        SQLGUARDA.Parameters.Add("@RES", SqlDbType.VarChar)
        SQLGUARDA.Parameters.Add("@PRO", SqlDbType.VarChar)
        SQLGUARDA.Parameters.Add("@CANT", SqlDbType.Float)
        SQLGUARDA.Parameters.Add("@UNI", SqlDbType.VarChar)
        'Dim ALGO As String
        Try
            For X = REN To DGV.Rows.Count - 1
                If DGV.Item(5, X).Value = True Then
                Else
                    If DGV.Item(7, X).Value = True Then
                        SQLGUARDA.Parameters("@RES").Value = frmPrincipal.SucursalBase
                        SQLGUARDA.Parameters("@PRO").Value = DGV.Item(0, X).Value.ToString
                        SQLGUARDA.Parameters("@CANT").Value = DGV.Item(2, X).Value.ToString
                        SQLGUARDA.Parameters("@UNI").Value = DGV.Item(3, X).Value.ToString
                        SQLGUARDA.ExecuteNonQuery()
                        Dim SQL2 As New SqlClient.SqlCommand("UPDATE DETALLEPEDIDOS2 SET RECIBIDO=1,CANTIDAD=@CANT,USUARIORECIBE='" + frmPrincipal.Usuario + "',FECHARECIBIDO=GETDATE() WHERE NOPEDIDO=" + LBLPED.Text + " AND REGISTRO='" + DGV.Item(8, X).Value.ToString + "' ", frmPrincipal.CONX)
                        SQL2.Parameters.Add("@CANT", SqlDbType.Float).Value = DGV.Item(6, X).Value.ToString
                        SQL2.CommandTimeout = 300
                        SQL2.ExecuteNonQuery()
                    End If

                End If
            Next
            SQLGUARDA.Dispose()

        Catch ex As Exception
            RENGLON = X
            MessageBox.Show(ex.Message)
            Dim CCC As Short
            CCC = MessageBox.Show("Hubo una desconexión en el renglon " + X.ToString + ", ¿Desea continuar guardando el pedido?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If CCC <> 6 Then
                Dim DDD As Short
                DDD = MessageBox.Show("¿Estas seguro que deseas cancelar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                If DDD <> 6 Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        End Try
        MessageBox.Show("El pedido se ha guardado con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Return True
    End Function
    Private Sub GUARDAR()
        RENGLON = 0
        While Not GUARDAR2(RENGLON)
        End While
        'RECIBIDOS()
        MessageBox.Show("El inventario ha sido actualizado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Dim SQLPED As New SqlClient.SqlCommand("UPDATE PEDIDOS SET ESTADO=4 WHERE NOPEDIDO=" + LBLPED.Text + " ", frmPrincipal.CONX)
        SQLPED.CommandTimeout = 300
        SQLPED.ExecuteNonQuery()
        SQLPED.Dispose()
        TABLAPRIN.Rows.Clear()
        DGV.DataSource = Nothing
        DGV.Refresh()
        TABLATEMP.Clear()
        CHECATABLA()
    End Sub



    Private Sub BTNBUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUS.Click
        Dim FECHA As String
        Dim DT, DTNOW As New DateTimePicker
        DTNOW.Value = Now
        DT.Value = DTNOW.Value.AddDays(-45)
        FECHA = Format(DT.Value.Date, "yyyyMMdd")
        Dim query As String
        query = "SELECT P.NOPEDIDO,S.NOMBRECOMUN TIENDA,P.FECHA,T.NOMBRE TIPO,E.NOMBRE ESTADO FROM PEDIDOS P INNER JOIN TIPOSPEDIDOS T ON T.CLAVE=P.TIPOPEDIDO INNER JOIN TIENDAS S ON P.TIENDA=S.CLAVE INNER JOIN ESTADOPEDIDO E ON P.ESTADO=E.CLAVE WHERE FECHA>=DATEADD(dd,-45,P.FECHA)  AND P.ESTADO=4"
        frmClsBusqueda.BUSCAR(query, " AND NOPEDIDO ", " ORDER BY FECHA DESC ", "Busqueda de pedidos", "No. pedido", "Pedido(s)", 0, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            LBLPED.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            'SURTIDOR = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            CARGADATOS()
        End If
    End Sub


    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim ABC As Short
        ABC = MessageBox.Show("¿Se encuentra marcado de recibido el producto?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If ABC <> 6 Then
            Exit Sub
        End If
        Dim XYZ As Short
        XYZ = MessageBox.Show("Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If XYZ = 6 Then
            GUARDAR()
            MessageBox.Show("La información ha sido guardada", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            DGV.DataSource = Nothing
            TABLAPRIN.Columns.Clear()
            TABLAPRIN.Rows.Clear()
            CHECATABLA()
        End If
    End Sub


    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        If LBLPED.Text = "" Then
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("Desea imprimir el pedido?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz = 6 Then

            Dim REP As New rptPedidoTraspaso
            Dim QREP As String
            QREP = "SELECT A.NOMBRECOMUN ALMACEN,D.NOPEDIDO NOSALIDA,G.NOMBRE GRUPO,P.NOMBRE PRODUCTO, D.CANTIDAD, U.NOMBRE UNIDAD,DBO.EXISTENCIAALMACEN('PM',D.CP)EXISTENCIA,COSTOPROMEDIO=DBO.COSTOPROM('PM',D.CP),TOTAL=DBO.TOTALUNIDADMINIMA(D.CP,D.CANTIDAD,D.UNIDAD)*DBO.COSTOPROM('PM',D.CP),D.COSTOPROMEDIO CPGUARDADO,S.USUARIOHACE USUARIO FROM PEDIDOS S INNER JOIN DETALLEPEDIDOS2 D ON S.NOPEDIDO=D.NOPEDIDO INNER JOIN TIENDAS A ON S.TIENDA=A.CLAVE INNER JOIN PRODUCTOS P ON D.CP=P.CP INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE  WHERE D.NOPEDIDO=" + LBLPED.Text
            MOSTRARREPORTE(REP, "Pedido: " + LBLPED.Text, BDLlenatabla(QREP, frmPrincipal.CadenaConexion), "")
            'Dim REPO As New rptSalidaBodega

            'MOSTRARREPORTE(REPO, "Reporte de salida de: " + frmPrincipal.NombreComun, BDLlenatabla("SELECT R.NOMBRECOMUN TIENDA,N.NOPEDIDO,D.LOTE,P.NOMBRE,P.DESCRIPCION,D.CANTIDAD,U.NOMBRE UNIDAD,L.COSTOU,TOTAL=(SELECT DBO.REGRESATOTALPRECIO(D.LOTE,D.CANTIDAD,D.UNIDAD)),A.NOMBRE AREA,T.NOMBRE TIPOPEDIDO,LU.NOMBRE UNIDABASE,N.FECHA,N.FECHA HORA  FROM PEDIDOS N INNER JOIN TIENDAS R ON N.TIENDA=R.CLAVE INNER JOIN DETALLEPEDIDOS D ON N.NOPEDIDO=D.NOPEDIDO INNER JOIN LOTES L ON D.LOTE=L.CLAVE INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP  INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN SUBGRUPOS A ON P.SUBGRUPO =A.CLAVE INNER JOIN TIPOSPEDIDOS T  ON N.TIPOPEDIDO=T.CLAVE INNER JOIN LASUNIDADES LU ON P.UVENTA=LU.CLAVE WHERE N.NOPEDIDO = " + LBLPED.Text + " ", frmPrincipal.CadenaConexion), "Enviar a One Note 2007")
            'Dim CI As New clsImprimir
            'CI.MOSTRAR2(REPO, "Reporte de Salida de: " + frmPrincipal.NombreComun, "SELECT R.NOMBRECOMUN TIENDA,N.NOPEDIDO,D.LOTE,P.NOMBRE,P.DESCRIPCION,D.CANTIDAD,U.NOMBRE UNIDAD,L.COSTOU,TOTAL=(SELECT DBO.REGRESATOTALPRECIO(D.LOTE,D.CANTIDAD,D.UNIDAD)),A.NOMBRE AREA,T.NOMBRE TIPOPEDIDO,LU.NOMBRE UNIDABASE  FROM PEDIDOS N INNER JOIN TIENDAS R ON N.TIENDA=R.CLAVE INNER JOIN DETALLEPEDIDOS D ON N.NOPEDIDO=D.NOPEDIDO AND D.PERTENECE=N.PERTENECE INNER JOIN LOTES L ON D.LOTE=L.CLAVE INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP  INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN SUBGRUPOS A ON P.SUBGRUPO =A.CLAVE INNER JOIN TIPOSPEDIDOS T  ON N.TIPOPEDIDO=T.CLAVE INNER JOIN LASUNIDADES LU ON P.UVENTA=LU.CLAVE WHERE N.NOPEDIDO = " + LBLPED.Text+" AND P.PERTENECE='"+P.TOSTRING+"', frmPrincipal.CadenaConexion)
            ' frmReportes.IMPRIMIR2(REPO, "Reporte de Salida de: " + CBSUC.Text, "SELECT R.NOMBRE RESTAURANTE,N.NOPEDIDO,D.LOTE,P.NOMBRE,P.DESCRIPCION,D.CANTIDAD,U.NOMBRE UNIDAD,L.COSTOU,TOTAL=(SELECT DBO.REGRESATOTALPRECIO(D.LOTE,D.CANTIDAD,D.UNIDAD)),A.NOMBRE AREA,T.NOMBRE TIPOPEDIDO,LU.NOMBRE UNIDABASE FROM PEDIDOS N INNER JOIN CLIENTESCOMPRAS R ON N.RESTAURANTE=R.CLAVE INNER JOIN DETALLEPEDIDOS D ON N.NOPEDIDO=D.NOPEDIDO INNER JOIN LOTES L ON D.LOTE=L.CLAVE INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CLAVE AND L.GRUPO=P.GRUPO INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN AREASURTIDO A ON P.AREAIMPRESION =A.CLAVE INNER JOIN TIPOSPEDIDOS T ON N.TIPOPEDIDO=T.CLAVE INNER JOIN LASUNIDADES LU ON P.UNIDADENTRADA=LU.CLAVE WHERE N.NOPEDIDO = " + LBLPED.Text)
        End If

    End Sub


End Class