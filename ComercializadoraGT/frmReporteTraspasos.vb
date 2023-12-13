Public Class frmReporteTraspasos
    Private Sub frmReporteTraspasos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        DGV.DataSource = BDLlenatabla("SELECT T.NOTRASPASO,O.NOMBRECOMUN ORIGEN,D.NOMBRECOMUN DESTINO,T.FECHA,T.ORIGEN FROM TRASPASOSTIENDAS T INNER JOIN TIENDAS O ON T.ORIGEN=O.CLAVE INNER JOIN TIENDAS D ON T.DESTINO=D.CLAVE WHERE T.FECHA>=@INI AND T.FECHA<@FIN", frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(4).Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CARGADATOS()
    End Sub

    Private Sub BTNIMPRIMIR_Click(sender As Object, e As EventArgs) Handles BTNIMPRIMIR.Click
        If DGV.RowCount <= 0 Then
            Exit Sub
        End If
        Dim NI As String
        NI = ""
        Dim VSI As New frmSeleccionarImpresora
        VSI.ShowDialog()
        If VSI.DialogResult = Windows.Forms.DialogResult.Yes Then
            NI = VSI.NIMPRESORA
        End If

        Dim QUERY As String
        QUERY = "SELECT A.NOMBRECOMUN CEDIS,B.NOMBRECOMUN ALMACEN,D.NOTRASPASO NOSALIDA,G.NOMBRE GRUPO,P.NOMBRE PRODUCTO, D.CANTIDAD, U.NOMBRE UNIDAD,DBO.CHECAEXISTENCIA('" + DGV.Item(4, DGV.CurrentRow.Index).Value.ToString + "',D.PRODUCTO)EXISTENCIA,COSTOPROMEDIO=DBO.COSTOPROM('" + DGV.Item(4, DGV.CurrentRow.Index).Value.ToString + "',D.PRODUCTO),TOTAL=DBO.TOTALUNIDADMINIMA2(D.PRODUCTO,D.CANTIDAD,D.UNIDAD)*DBO.COSTOPROM('" + DGV.Item(4, DGV.CurrentRow.Index).Value.ToString + "',D.PRODUCTO),D.COSTOPROMEDIO CPGUARDADO,S.USUARIO,RESPONSABLEO='',RESPONSABLED='' FROM DETALLETRASPASOSTIENDAS D INNER JOIN TRASPASOSTIENDAS S ON D.NOTRASPASO=S.NOTRASPASO INNER JOIN TIENDAS A ON S.ORIGEN=A.CLAVE INNER JOIN TIENDAS B ON S.DESTINO=B.CLAVE INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CP INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE D.NOTRASPASO=" + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString + " ORDER BY D.REGISTRO"

        Dim REP As New rptSalidaTraspaso
        MOSTRARREPORTE(REP, "Salida por Traspaso No. " + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), NI)

    End Sub

    Private Sub BTNCP_Click(sender As Object, e As EventArgs) Handles BTNCP.Click
        If DGV.RowCount <= 0 Then
            Exit Sub
        End If
        Dim VINFOTRAS As New frmTraspasoCartaPorte
        VINFOTRAS.MOSTRAR(DGV.Item(0, DGV.CurrentRow.Index).Value.ToString)
    End Sub
End Class