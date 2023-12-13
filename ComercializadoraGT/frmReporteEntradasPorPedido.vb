Public Class frmReporteEntradasPorPedido

    Private Sub frmReporteEntradasPorPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        DTDE.Focus()
    End Sub
    Private Function CHECAFECHAS() As Boolean
        If DTDE.Value.Date > DTHASTA.Value.Date Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        If Not CHECAFECHAS() Then
            MessageBox.Show("El rango de fechas esta incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim query As String
        query = "SELECT P.NOPEDIDO,D.LOTE,PR.NOMBRE,D.CANTIDAD,U.NOMBRE UNIDAD,(SELECT CONVERT(NUMERIC(15,2),(SELECT DBO.REGRESATOTALPRECIO(D.LOTE,D.CANTIDAD,D.UNIDAD)),2)) COSTO,D.USUARIORECIBE,d.FECHARECIBIDO  FROM PEDIDOS P INNER JOIN DETALLEPEDIDOS D  ON P.NOPEDIDO=D.NOPEDIDO INNER JOIN LOTES L  ON D.LOTE=L.CLAVE INNER JOIN PRODUCTOS PR  ON L.PRODUCTO=PR.Cp  INNER JOIN UNIDADES U  ON D.UNIDAD=U.CLAVE WHERE P.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.FECHARECIBIDO>=@INI AND D.FECHARECIBIDO<=@FIN AND D.RECIBIDO=1"

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()

        'DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
        BTNIMPRIMIR.Focus()
    End Sub

    Private Sub DTDE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTDE.KeyPress, DTHASTA.KeyPress, BTNMOSTRAR.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        BTNGUARDAR.Focus()
    End Sub
End Class