Public Class frmReporteGeneralCredito
    Dim query As String
    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        query = "select C.NOMBRE,TOTALDEBE=(SUM (N.TOTAL)-SUM(DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA))) FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON N.TIENDA=C.TIENDA AND N.CLIENTE=C.CLAVE WHERE N.PAGADO=0 AND N.TIENDA='" + frmPrincipal.SucursalBase + "' GROUP BY C.NOMBRE ORDER BY C.NOMBRE"
        DGV.DataSource = BDLlenatabla(query, frmPrincipal.CadenaConexion)
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      
        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim AD As Double
        AD = 0
        For X = 0 To DGV.Rows.Count - 1
            AD = AD + DGV.Item(1, X).Value
        Next
        LBLAB.Text = FormatNumber(AD).ToString()
    End Sub

    Private Sub frmReporteGeneralCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGADATOS()
    End Sub
    Dim QUER As String
    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        Dim REPI As New rptTicketAdeudoCreditos

        QUER = "select C.NOMBRE,TOTALDEBE=(SUM (N.TOTAL)-SUM(DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA))) FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON N.TIENDA=C.TIENDA AND N.CLIENTE=C.CLAVE WHERE N.PAGADO=0 AND N.TIENDA='" + frmPrincipal.SucursalBase + "' GROUP BY C.NOMBRE ORDER BY C.NOMBRE"

        MOSTRARREPORTE(REPI, "Reporte de Compras", BDLlenatabla(QUER, frmPrincipal.CadenaConexion), "Enviar a OneNote 2007")
    End Sub
    Private Sub GUARDAR()
        Dim REPI As New rptAdeudoCreditos
        QUER = "select C.NOMBRE,TOTALDEBE=(SUM (N.TOTAL)-SUM(DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA))) FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON N.TIENDA=C.TIENDA AND N.CLIENTE=C.CLAVE WHERE N.PAGADO=0 AND N.TIENDA='" + frmPrincipal.SucursalBase + "' GROUP BY C.NOMBRE ORDER BY C.NOMBRE"
        GUARDARREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "PDF", "PDF", "¿Desea guardar el reporte?", "Reporte adeudos de credito", "Enviar One Note 2007")
    End Sub
    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub
End Class