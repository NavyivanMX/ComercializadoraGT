Public Class frmKardexClientes

    Private Sub frmKardexClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CHECATABLA()
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("select C.CLAVE CLAVE,C.NOMBRE CLIENTE,TOTALDEBE = DBO.TOTALDEBECLIENTE(C.TIENDA, C.CLAVE) FROM  CLIENTES C WHERE C.TIENDA='" + frmPrincipal.SucursalBase + "'", " AND C.NOMBRE", " ORDER BY C.NOMBRE", "Búsqueda Clientes", "Nombre del Cliente", "Clientes", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCLI.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            CARGACLIENTE()
        End If
    End Sub
    Private Sub CARGACLIENTE()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE,TOTALDEBE = DBO.TOTALDEBECLIENTE(C.TIENDA, C.CLAVE) FROM  CLIENTES C WHERE C.TIENDA='" + frmPrincipal.SucursalBase + "' AND C.CLAVE='" + TXTCLI.Text + "' ", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            LBLNCLI.Text = LEC(1)
            LBLADE.Text = LEC(2)
        End If
        LEC.Close()
        SQL.Dispose()
    End Sub
    Private Sub CARGADATOS()
        Dim QUERY As String
        QUERY = "SELECT N.NOTA,CONVERT(VARCHAR(10),N.FECHA,103) FECHA,N.TOTAL,T.NOMBRE TIPOPAGO,N.OBSERVACION,DBO.NOTAVENTANOTACREDITO(N.TIENDA,N.NOTA)NOTACREDITO,DBO.FOLIOFACNOTA('" + frmPrincipal.Serie + "',N.NOTA)Factura FROM NOTASDEVENTA N INNER JOIN TIPOSPAGOS T ON N.TIPOPAGO=T.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.CLIENTE='" + TXTCLI.Text + "' AND N.FECHA>=@INI AND N.FECHA<=@FIN ORDER BY N.FECHA"

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        QUERY = "SELECT N.Nota,N.Total,(N.TOTAL-(DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))[Resta por Pagar],CONVERT(VARCHAR(10),N.FECHA,103)Fecha,convert(varchar(10),DATEADD(dd,C.DIASCREDITO,N.FECHA),103) [Fecha de Vencimiento],C.DIASCREDITO [Dias de Credito],[Dias Vencido]=DATEDIFF(dd,N.FECHA,GETDATE())-C.DIASCREDITO,DBO.FOLIOFAC('" + frmPrincipal.Serie + "',N.NOTA)Factura,N.PAGADO FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE AND C.TIENDA=N.TIENDA WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.CLIENTE='" + TXTCLI.Text + "' AND N.FECHA>=@INI AND N.FECHA<=@FIN ORDER BY N.FECHA"
        DGV2.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        QUERY = "SELECT N.NOTA,N.ABONO,N.SALDO,N.FECHA,NOTAVENTA [NOTA DE COBRANZA], DBO.FOLIOFAC('" + frmPrincipal.Serie + "',N.NOTA)Factura FROM ABONOSCREDITOS  N INNER JOIN NOTASDEVENTACREDITO D ON N.TIENDA=D.TIENDA AND N.NOTA=D.NOTA INNER JOIN CLIENTES C ON D.TIENDA=C.TIENDA AND D.CLIENTE=C.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.CLIENTE='" + TXTCLI.Text + "' AND N.FECHA>=@INI AND N.FECHA<=@FIN ORDER BY N.FECHA"
        DGV3.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(4))
        DGV3.Columns(1).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV3.Columns(2).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV3.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV3.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV3.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV3.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV3.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV3.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        CHECATABLA()
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()    
    End Sub
    Private Sub CHECATABLA()
        If DGV.Rows.Count <= 0 Then
            Button1.Enabled = False
            'Button2.Enabled = False
            Button4.Enabled = False
        Else
            Button1.Enabled = True
            Button2.Enabled = True
            Button4.Enabled = True
        End If
        If DGV2.Rows.Count <= 0 Then
            'Button3.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
        Else
            'Button3.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
        End If
    End Sub
    Private Sub BTNADEUDOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNADEUDOS.Click
        'MessageBox.Show("Favor de capturar desde la caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Dim VAC As New frmAbonosCreditos
        VAC.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmDetalleDeNotas.MOSTRAR(DGV.Item(0, DGV.CurrentRow.Index).Value)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DGV2.RowCount <= 0 Then
            Exit Sub
        End If
        frmDetalleDeNotaCredito.MOSTRAR(DGV2.Item(0, DGV2.CurrentRow.Index).Value)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmDetalleDeNotaCredito.MOSTRAR(DGV2.Item(0, DGV2.CurrentRow.Index).Value)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If DGV.Item(5, DGV.CurrentRow.Index).Value = "N/A" Then
            MessageBox.Show("No corresponde a una Factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MOSTRARFACTURA(DGV.Item(5, DGV.CurrentRow.Index).Value)
        End If
    End Sub
    Private Sub MOSTRARFACTURA(ByVal FOLIO As String)
        Dim CADENA As String
        CADENA = frmPrincipal.CadenaConexionFE
        Dim QUERY As String
        QUERY = "SELECT * from VRFACTURA33 F  where F.RFCEMISOR='" + frmPrincipal.EmisorBase + "' AND F.SERIE='" + frmPrincipal.Serie + "' AND F.FOLIO=" + FOLIO
        Dim REP As New rptFENavySoluciones40
        MOSTRARREPORTE(REP, "Factura Electronica", BDLlenatabla(QUERY, CADENA), "")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If DGV2.Item(7, DGV2.CurrentRow.Index).Value = "N/A" Then
            MessageBox.Show("No corresponde a una Factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MOSTRARFACTURA(DGV2.Item(7, DGV2.CurrentRow.Index).Value)
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmDetalleAbonos.MOSTRAR(DGV2.Item(0, DGV2.CurrentRow.Index).Value)
    End Sub
End Class