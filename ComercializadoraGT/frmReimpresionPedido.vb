Public Class frmReimpresionPedido
    Dim X As Integer
    Dim TABLAPRIN As New DataTable
    Dim TABLATEMP As New DataTable
    Dim SURTIDOR As String
    Private Sub frmReimpresionPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            'BTNGUARDAR.Enabled = False
            'SIIMP.Enabled = False
            ' NOIMP.Enabled = False
            LBLART.Text = "Artículos: 0"
        Else
            BTNIMPRIMIR.Enabled = True
            'BTNGUARDAR.Enabled = True
            'SIIMP.Enabled = True
            'NOIMP.Enabled = True
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
        'If LBLSUC.Text <> frmPrincipal.NombreComun Then
        '    MessageBox.Show("Este pedido No corresponde a la sucursal con la que se ha registrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If

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
        If NPED = 4 Then
            MessageBox.Show("Este pedido ha sido recibido, No se permite volver a cargar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim QUERY As String
        QUERY = "SELECT D.LOTE,P.NOMBRE PRODUCTO,D.CANTIDAD,U.NOMBRE UNIDAD,L.COSTOU,TOTAL=(SELECT DBO.REGRESATOTALPRECIO(D.LOTE,D.CANTIDAD,D.UNIDAD)),D.REGISTRO FROM DETALLEPEDIDOS D INNER JOIN LOTES L ON D.LOTE=L.CLAVE INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE WHERE D.NOPEDIDO=" + LBLPED.Text + "  ORDER BY P.NOMBRE"
        Dim DATEMP As New SqlClient.SqlDataAdapter(QUERY, frmPrincipal.CONX)
        TABLATEMP.Rows.Clear()
        TABLATEMP.Columns.Clear()
        DATEMP.Fill(TABLATEMP)
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
        DGV.Columns(6).ReadOnly = True
        'DGV.Columns(7).ReadOnly = True
        CHECATABLA()
        SQLPED.Dispose()
    End Sub
    Private Sub BTNBUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUS.Click
        Dim FECHA As String
        Dim DT, DTNOW As New DateTimePicker
        DTNOW.Value = Now
        DT.Value = DTNOW.Value.AddDays(-20)
        FECHA = Format(DT.Value.Date, "yyyyMMdd")
        Dim query As String
        query = "SELECT NOPEDIDO,TIENDA,FECHA, TIPO, ESTADO  FROM VISTAPEDIDOS WHERE FECHA>='" + FECHA + "'  AND CE=3 "
        frmClsBusqueda.BUSCAR(query, " WHERE NOPEDIDO ", " ORDER BY FECHA DESC ", "Busqueda de pedidos", "No. pedido", "Pedido(s)", 0, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            LBLPED.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            'SURTIDOR = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            CARGADATOS()
        End If
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

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        If LBLPED.Text = "" Then
            Exit Sub
        End If

        Dim xyz As Short
        xyz = MessageBox.Show("Desea imprimir el pedido?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz = 6 Then
            Dim REPO As New rptOrdenTrabajo2 'TICKETERA
            IMPRIMIRREPORTE(REPO, BDLlenatabla("SELECT N.NOPEDIDO,R.NOMBRECOMUN TIENDA,T.NOMBRE TIPOPEDIDO,D.LOCALIDAD,D.LOTE,P.NOMBRE,P.DESCRIPCION,D.CANTIDAD,U.NOMBRE UNIDAD,A.NOMBRE SUBGRUPO   FROM PEDIDOS N INNER JOIN TIENDAS R   ON N.TIENDA=R.CLAVE INNER JOIN TIPOSPEDIDOS T   ON N.TIPOPEDIDO=T.CLAVE INNER JOIN DETALLEPEDIDOS D   ON N.NOPEDIDO=D.NOPEDIDO  INNER JOIN LOTES L   ON D.LOTE=L.CLAVE INNER JOIN PRODUCTOS P   ON L.PRODUCTO=P.Cp INNER JOIN UNIDADES U   ON D.UNIDAD=U.CLAVE INNER JOIN SUBGRUPOS A   ON P.SUBGRUPO=A.CLAVE   WHERE N.NOPEDIDO=" + LBLPED.Text + "   ORDER BY A.NOMBRE,P.NOMBRE,D.LOTE", frmPrincipal.CadenaConexion), 1, "Enviar a One Note 2007")

            'Dim CI As New clsImprimir
            'CI.MOSTRAR2(REPO, "Reporte de Salida de: " + frmPrincipal.NombreComun, "SELECT R.NOMBRECOMUN TIENDA,N.NOPEDIDO,D.LOTE,P.NOMBRE,P.DESCRIPCION,D.CANTIDAD,U.NOMBRE UNIDAD,L.COSTOU,TOTAL=(SELECT DBO.REGRESATOTALPRECIO(D.LOTE,D.CANTIDAD,D.UNIDAD)),A.NOMBRE AREA,T.NOMBRE TIPOPEDIDO,LU.NOMBRE UNIDABASE  FROM PEDIDOS N INNER JOIN TIENDAS R ON N.TIENDA=R.CLAVE INNER JOIN DETALLEPEDIDOS D ON N.NOPEDIDO=D.NOPEDIDO AND D.PERTENECE=N.PERTENECE INNER JOIN LOTES L ON D.LOTE=L.CLAVE INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP  INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN SUBGRUPOS A ON P.SUBGRUPO =A.CLAVE INNER JOIN TIPOSPEDIDOS T  ON N.TIPOPEDIDO=T.CLAVE INNER JOIN LASUNIDADES LU ON P.UVENTA=LU.CLAVE WHERE N.NOPEDIDO = " + LBLPED.Text+" AND P.PERTENECE='"+P.TOSTRING+"', frmPrincipal.CadenaConexion)
            ' frmReportes.IMPRIMIR2(REPO, "Reporte de Salida de: " + CBSUC.Text, "SELECT R.NOMBRE RESTAURANTE,N.NOPEDIDO,D.LOTE,P.NOMBRE,P.DESCRIPCION,D.CANTIDAD,U.NOMBRE UNIDAD,L.COSTOU,TOTAL=(SELECT DBO.REGRESATOTALPRECIO(D.LOTE,D.CANTIDAD,D.UNIDAD)),A.NOMBRE AREA,T.NOMBRE TIPOPEDIDO,LU.NOMBRE UNIDABASE FROM PEDIDOS N INNER JOIN CLIENTESCOMPRAS R ON N.RESTAURANTE=R.CLAVE INNER JOIN DETALLEPEDIDOS D ON N.NOPEDIDO=D.NOPEDIDO INNER JOIN LOTES L ON D.LOTE=L.CLAVE INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CLAVE AND L.GRUPO=P.GRUPO INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN AREASURTIDO A ON P.AREAIMPRESION =A.CLAVE INNER JOIN TIPOSPEDIDOS T ON N.TIPOPEDIDO=T.CLAVE INNER JOIN LASUNIDADES LU ON P.UNIDADENTRADA=LU.CLAVE WHERE N.NOPEDIDO = " + LBLPED.Text)
        End If

    End Sub
End Class