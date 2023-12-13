Public Class frmRevisarVenta
    Dim LCAJ As New List(Of String)
    Private Sub frmRevisarVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        OPLlenaComboBox(CBCAJA, LCAJ, "SELECT CAJA,CAJA CAJA2 FROM CORTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' ORDER BY CAJA", frmPrincipal.CadenaConexion)
    End Sub
    Private Sub CARGADATOS()
        DGV.DataSource = BDLlenatabla("select R.NOMBRECOMUN TIENDA,NOTA,TOTAL,T.NOMBRE TIPOPAGO,CONVERT(VARCHAR(10),FECHA,108) HORA,DBO.SUMADETALLENOTA(N.TIENDA,NOTA)SUMADETALLENOTA,NOCAJA,DIFERENCIA=TOTAL-DBO.SUMADETALLENOTA(N.TIENDA,NOTA), E.NOMBRE CAJERA FROM NOTASDEVENTA N INNER JOIN TIENDAS R ON N.TIENDA=R.CLAVE INNER JOIN TIPOSPAGOS T ON N.TIPOPAGO=T.CLAVE INNER JOIN EMPLEADOS E ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND FECHA>=@INI AND FECHA<=@FIN AND NOCAJA=" + CBCAJA.Text + "", frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1))
        DGV.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim TOT As Double
        TOT = 0
        For X = 0 To DGV.Rows.Count - 1
            TOT += DGV.Item(2, X).Value
        Next
        LBLTV.Text = "Total Venta: " + FormatNumber(TOT, 2).ToString
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CARGADATOS()
    End Sub
End Class