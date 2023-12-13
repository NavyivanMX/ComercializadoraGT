Public Class frmRelacionNotaFactura
    Dim LTI As New List(Of String)
    Dim LCLI As New List(Of String)
    Private Sub frmRelacionNotaFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        OPLlenaComboBox(CBTI, LTI, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE CLAVE<>'PRUEBAS' ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion)
    End Sub
    Private Sub CARGADATOS()
        Dim Q1, Q2, QUERY As String
        Q1 = "SELECT T.NOMBRECOMUN TIENDA,C.NOMBRE CLIENTE,N.NOTA,N.TOTAL,N.FECHA,T.SERIEFAC,DBO.FOLIOFAC(T.SERIEFAC,N.NOTA)FOLIOFACTURA,FORMA='CREDITO' FROM NOTASDEVENTACREDITO N INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE INNER JOIN CLIENTES C ON N.TIENDA=C.TIENDA AND N.CLIENTE=C.CLAVE WHERE N.TIENDA='" + LTI(CBTI.SelectedIndex) + "' AND N.FECHA>=@INI AND N.FECHA<=@FIN"
        Q2 = " UNION ALL SELECT T.NOMBRECOMUN TIENDA,C.NOMBRE CLIENTE,N.NOTA,N.TOTAL,N.FECHA,T.SERIEFAC,DBO.FOLIOFACNOTA(T.SERIEFAC,N.NOTA)FOLIOFACTURA,FORMA='CONTADO' FROM NOTASDEVENTA N INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE INNER JOIN CLIENTES C ON N.TIENDA=C.TIENDA AND N.CLIENTE=C.CLAVE WHERE N.TIENDA='" + LTI(CBTI.SelectedIndex) + "' AND N.FECHA>=@INI AND N.FECHA<=@FIN"
        If CBCLI.SelectedIndex <> 0 Then
            Q1 += " AND C.CLAVE='" + LCLI(CBCLI.SelectedIndex) + "'"
            Q2 += " AND C.CLAVE='" + LCLI(CBCLI.SelectedIndex) + "'"
        End If
        QUERY = Q1 + Q2
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CARGADATOS()
    End Sub

    Private Sub CBTI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBTI.SelectedIndexChanged
       OPLlenaComboBox(CBCLI, LCLI, "SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + LTI(CBTI.SelectedIndex) + "' AND ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion, "Todos los Clientes", "")
    End Sub
End Class