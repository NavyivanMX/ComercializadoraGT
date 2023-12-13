Public Class frmConsumidoNota

    Private Sub frmConsumidoNota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Public Sub MOSTRAR(ByVal NOMBRE As String, ByVal TOTALDEBE As Double, ByVal NOTA As Integer)
        LBLNCLI.Text = NOMBRE
        LBLTRPP.Text = FormatNumber(TOTALDEBE, 2).ToString
        DGV.DataSource = BDLlenatabla("SELECT D.CANTIDAD,P.NOMBRE,D.DESCUENTO,D.TOTAL,N.FECHA FROM DETALLENOTASDEVENTACREDITO D INNER JOIN NOTASDEVENTACREDITO N ON D.TIENDA=N.TIENDA AND N.NOTA=D.NOTA INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA=" + NOTA.ToString, frmPrincipal.CadenaConexion)
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
        Me.ShowDialog()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim TOT As Double
        TOT = 0
        For X = 0 To DGV.Rows.Count - 1
            TOT += DGV.Item(3, X).Value
        Next
        TXTTOT.Text = FormatNumber(TOT, 2).ToString
    End Sub
End Class