Public Class frmReporteCreditos

    Dim QUERY As String
    Private Sub frmReporteCreditos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CBTIP.SelectedIndex = 0
    End Sub
  
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim AD, AB, AT As Double
        AD = 0
        AB = 0
        AT = 0
        For X = 0 To DGV.Rows.Count - 1
            AD = AD + DGV.Item(2, X).Value
            If DGV.Item(3, X).Value Is DBNull.Value Then
            Else
                AB = AB + DGV.Item(3, X).Value
            End If
        Next
        LBLAB.Text = FormatNumber(AB).ToString()
        LBLAT.Text = FormatNumber(AD - AB).ToString()
        LBLAD.Text = FormatNumber(AD).ToString

    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        QUERY = "SELECT C.NOMBRE CLIENTE,N.NOTA,N.TOTAL,SUM(A.ABONO) ABONOS, N.FECHA CONSUMO, MAX(A.FECHA)[ULTIMO PAGO],N.PAGADO  FROM NOTASDEVENTACREDITO N LEFT JOIN ABONOSCREDITOS A  ON N.TIENDA=A.TIENDA AND N.NOTA=A.NOTA INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' "
        If CBTIP.SelectedIndex = 1 Then
            QUERY = QUERY + " AND N.PAGADO=0 "
        End If
        If CBTIP.SelectedIndex = 2 Then
            QUERY = QUERY + " AND N.PAGADO=1 "
        End If
        QUERY = QUERY + " GROUP BY N.NOTA,N.TOTAL,N.FECHA,N.PAGADO,C.NOMBRE ORDER BY C.NOMBRE,N.NOTA"

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub

    Private Sub DGV_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV.Sorted
        CHECATABLA()
    End Sub
End Class