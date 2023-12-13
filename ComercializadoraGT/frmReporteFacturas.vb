Public Class frmReporteFacturas
    Dim CLACLI As New List(Of String)
    Dim CLARFC As New List(Of String)
    Private Sub frmReporteFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGACLIENTES()
    End Sub
    Private Sub CARGACLIENTES()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        CBCLI.Items.Clear()
        CLACLI.Clear()
        CBCLI.Items.Add("Todos los clientes")
        CLACLI.Add("")
        Dim SQLGRUPO As New SqlClient.SqlCommand("SELECT DISTINCT (C.CLAVE),C.NOMBRE FROM CLIENTES C INNER JOIN CLIENTERFC R ON C.TIENDA=R.TIENDA AND C.CLAVE=R.CLIENTE  WHERE ACTIVO=1 AND CLAVE<>0 ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LECGRUPO As SqlClient.SqlDataReader
        LECGRUPO = SQLGRUPO.ExecuteReader
        While LECGRUPO.Read
            CLACLI.Add(LECGRUPO(0))
            CBCLI.Items.Add(LECGRUPO(1))
        End While
        LECGRUPO.Close()
        Try
            CBCLI.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub
    Private Function CARGARFC() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        CBRFC.Items.Clear()
        CLARFC.Clear()
        CBRFC.Items.Add("Todos los RFC")
        CLARFC.Add("")

        Dim SQLPRO As New SqlClient.SqlCommand("SELECT RFC FROM CLIENTERFC WHERE CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "'", frmPrincipal.CONX)
        Dim LECPRO As SqlClient.SqlDataReader
        LECPRO = SQLPRO.ExecuteReader
        While LECPRO.Read
            CBRFC.Items.Add(LECPRO(0))
        End While
        LECPRO.Close()
        Try
            CBRFC.SelectedIndex = 0
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub CBCLI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBCLI.SelectedIndexChanged
        CARGARFC()
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        Dim QUERY As String
        QUERY = "SELECT DISTINCT(FACTURA),FECHA,CLIENTE,RFC,SUBTOTAL,IVA,TOTAL FROM VISTAREPORTEFACTURA WHERE FECHA>=@INI AND FECHA<=@FIN AND TIENDA='" + frmPrincipal.SucursalBase + "' "
        If CBCLI.SelectedIndex = 0 Then
            If CBRFC.SelectedIndex = 0 Then
            Else
            End If
        Else
            If CBRFC.SelectedIndex = 0 Then
                QUERY = QUERY + " AND CLAVE='" + CLACLI(CBCLI.SelectedIndex) + "' "
            Else
                QUERY = QUERY + " AND CLAVE='" + CLACLI(CBCLI.SelectedIndex) + "' AND RFC='" + CBRFC.Text + "' "
            End If
        End If
        'QUERY = QUERY + " AND P.CLAVE<>'12345' GROUP BY G.NOMBRE,P.NOMBRE,U.NOMBRE,P.STOCKMIN ORDER BY G.NOMBRE,P.NOMBRE "

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ' CHECATABLA()
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim TOTAL, S, I As Double
        TOTAL = 0
        S = 0
        I = 0
        For X = 0 To DGV.Rows.Count - 1
            S = S + DGV.Item(4, X).Value
            I = I + DGV.Item(5, X).Value
            TOTAL = TOTAL + DGV.Item(6, X).Value
        Next
        LBLT.Text = FormatNumber(TOTAL).ToString()
        LBLS.Text = FormatNumber(S).ToString()
        LBLI.Text = FormatNumber(I).ToString()
    End Sub

    Private Sub DGV_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        CARGADATOS2()
        'CHECATABLA2(DGV.Item(5, DGV.CurrentRow.Index).Value)
        CHECATABLA()
    End Sub
    Private Sub CARGADATOS2()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        Dim QUERY, QUERY2 As String
        QUERY = "SELECT D.NOTA,P.CLAVE,P.NOMBRE PRODUCTO,D.CANTIDAD,PRECIO=CONVERT(NUMERIC(15,2),(D.TOTAL/D.CANTIDAD),2),D.TOTAL FROM DETALLEFACTURASCLIENTES DF INNER JOIN DETALLENOTASDEVENTA D ON DF.TIENDA=D.TIENDA AND DF.NOTA=D.NOTA INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE INNER JOIN FACTURASCLIENTES F ON F.TIENDA=DF.TIENDA AND DF.FACTURA=F.FACTURA INNER JOIN CLIENTERFC CR ON CR.TIENDA=F.TIENDA AND CR.CLIENTE=F.CLIENTE  WHERE DF.TIENDA='" + frmPrincipal.SucursalBase + "' AND DF.ESNOTA=1 AND DF.FACTURA='" + DGV.Item(0, DGV.CurrentRow.Index).Value + "' "
        QUERY2 = "UNION ALL SELECT D.NOTA,P.CLAVE,P.NOMBRE PRODUCTO,D.CANTIDAD,PRECIO=CONVERT(NUMERIC(15,2),(D.TOTAL/D.CANTIDAD),2),D.TOTAL FROM DETALLEFACTURASCLIENTES DF INNER JOIN DETALLENOTASDEVENTACREDITO D ON DF.TIENDA=D.TIENDA AND DF.NOTA=D.NOTA INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE INNER JOIN FACTURASCLIENTES F ON F.TIENDA=DF.TIENDA AND DF.FACTURA=F.FACTURA INNER JOIN CLIENTERFC CR ON CR.TIENDA=F.TIENDA AND CR.CLIENTE=F.CLIENTE WHERE DF.TIENDA='" + frmPrincipal.SucursalBase + "' AND DF.ESNOTA=0 AND DF.FACTURA='" + DGV.Item(0, DGV.CurrentRow.Index).Value + "' "
        'If CBCLI.SelectedIndex = 0 Then
        '    If CBRFC.SelectedIndex = 0 Then
        '    Else
        '    End If
        'Else
        '    If CBRFC.SelectedIndex = 0 Then
        '        QUERY = QUERY + " AND F.CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "' "
        '        QUERY2 = QUERY2 + " AND F.CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "' "
        '    Else
        '        QUERY = QUERY + " F.CLIENTE=" + CLACLI(CBCLI.SelectedIndex) + " AND CR.RFC='" + CBRFC.Text + "' "
        '        QUERY2 = QUERY2 + " F.CLIENTE=" + CLACLI(CBCLI.SelectedIndex) + " AND CR.RFC='" + CBRFC.Text + "' "
        '    End If
        'End If
        'QUERY = QUERY + " AND P.CLAVE<>'12345' GROUP BY G.NOMBRE,P.NOMBRE,U.NOMBRE,P.STOCKMIN ORDER BY G.NOMBRE,P.NOMBRE "
        QUERY = QUERY + QUERY2
        DGV2.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV2.Refresh()
        DGV2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ' CHECATABLA()
    End Sub

    Dim CNUM As New num2text
    Private Sub frmReporteFacturas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            If DGV.Rows.Count <= 0 Then
            Else
                MOSTRARFACTURA(DGV.Item(0, DGV.CurrentRow.Index).Value.ToString, CNUM.Letras(DGV.Item(6, DGV.CurrentRow.Index).Value.ToString))
            End If
        End If
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0 ", " AND NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLACLI, CBCLI, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If

    End Sub
    Private Sub MOSTRARFACTURA(ByVal FAC As String, ByVal LETRA As String)
        Dim QUERY As String
        Dim REP As New rptFactura
        QUERY = "SELECT F.FECHA,R.NOMBREFISCAL,R.DIRECCION,R.CIUDAD,R.RFC,D.CANTIDAD,P.NOMBRE,PRECIO=CONVERT(NUMERIC(15,2), DBO.ELPRECIO(P.CLAVE,D.CANTIDAD,D.TOTAL),2),CONVERT(NUMERIC(15,2), DBO.ELTOTALFAC(P.CLAVE,D.TOTAL),2)TOTAL, SUBTOTAL=CONVERT(NUMERIC(15,2),DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,1)+DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,0),2), IVA=CONVERT(NUMERIC(15,2),DBO.IVATOTALFACTURA(D.TIENDA,F.FACTURA),2) ,ELTOTAL=F.TOTAL,CCLETRA='" + LETRA + "',R.CP,U.NOMBRE UNIDAD,SUBTOTALPRODUCTOSCONIVA=DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,1),SUBTOTALPRODUCTOSSINIVA=DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,0)  FROM FACTURASCLIENTES F INNER JOIN CLIENTERFC R   ON F.TIENDA=R.TIENDA AND F.CLIENTE=R.CLIENTE AND F.FACCLIENTE=R.REGISTRO INNER JOIN DETALLEFACTURASCLIENTES DF   ON F.TIENDA=DF.TIENDA AND F.FACTURA=DF.FACTURA INNER JOIN DETALLENOTASDEVENTA D   ON DF.TIENDA=D.TIENDA AND DF.NOTA=D.NOTA AND DF.ESNOTA=1 INNER JOIN PRODUCTOS P   ON D.PRODUCTO=P.CLAVE INNER JOIN UNIDADES U  ON U.CLAVE=P.UVENTA  WHERE F.TIENDA='" + frmPrincipal.SucursalBase + "' AND F.FACTURA='" + FAC + "'   UNION ALL   SELECT F.FECHA,R.NOMBREFISCAL,R.DIRECCION,R.CIUDAD,R.RFC,D.CANTIDAD,P.NOMBRE,PRECIO=CONVERT(NUMERIC(15,2), DBO.ELPRECIO(P.CLAVE,D.CANTIDAD,D.TOTAL),2),CONVERT(NUMERIC(15,2), DBO.ELTOTALFAC(P.CLAVE,D.TOTAL),2)TOTAL,SUBTOTAL=CONVERT(NUMERIC(15,2),DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,1)+DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,0),2), IVA=CONVERT(NUMERIC(15,2),DBO.IVATOTALFACTURA(D.TIENDA,F.FACTURA),2) ,ELTOTAL=F.TOTAL,CCLETRA='" + LETRA + "',R.CP,U.NOMBRE UNIDAD,SUBTOTALPRODUCTOSCONIVA=DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,1),SUBTOTALPRODUCTOSSINIVA=DBO.SUBTOTALFACTURA(D.TIENDA,F.FACTURA,0)   FROM FACTURASCLIENTES F INNER JOIN CLIENTERFC R   ON F.TIENDA=R.TIENDA AND F.CLIENTE=R.CLIENTE AND F.FACCLIENTE=R.REGISTRO INNER JOIN DETALLEFACTURASCLIENTES DF  ON F.TIENDA=DF.TIENDA AND F.FACTURA=DF.FACTURA INNER JOIN DETALLENOTASDEVENTACREDITO D   ON DF.TIENDA=D.TIENDA AND DF.NOTA=D.NOTA AND DF.ESNOTA=0 INNER JOIN PRODUCTOS P   ON D.PRODUCTO=P.CLAVE INNER JOIN UNIDADES U  ON U.CLAVE=P.UVENTA  WHERE F.TIENDA='" + frmPrincipal.SucursalBase + "' AND F.FACTURA='" + FAC + "'"
        MOSTRARREPORTE(REP, frmPrincipal.NombreComun + "  Factura " + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), "Enviar a OneNote 2007")
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        If DGV.Rows.Count <= 0 Then
        Else
            MOSTRARFACTURA(DGV.Item(0, DGV.CurrentRow.Index).Value.ToString, CNUM.Letras(DGV.Item(6, DGV.CurrentRow.Index).Value.ToString))
        End If
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim xyz As Short
        Dim query As String
        xyz = MessageBox.Show("¿Esta seguro que desea eliminar la factura " + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString + "?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If xyz = 6 Then
            Try
                If Not frmPrincipal.CHECACONX() Then
                    Exit Sub
                End If
                Dim SQLELIMINAR As New SqlClient.SqlCommand
                SQLELIMINAR.Connection = frmPrincipal.CONX
                query = "DELETE FROM FACTURASCLIENTES WHERE FACTURA ='" + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString + "' AND TIENDA='" + frmPrincipal.SucursalBase + "' "
                SQLELIMINAR.CommandText = query
                SQLELIMINAR.ExecuteNonQuery()
                MessageBox.Show("La factura ha sido eliminada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show("La factura no pudo ser eliminada favor de contactar a Structure", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'ex.Message.ToString()
                Exit Sub
            End Try
        End If
    End Sub
End Class