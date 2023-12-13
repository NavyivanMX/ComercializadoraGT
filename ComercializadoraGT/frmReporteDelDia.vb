Public Class frmReporteDelDia

    Private Sub frmReporteDelDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Private Sub CARGADATOS()
        Dim LAQ, LAQ2, LAQ3 As String


        LAQ = "SELECT N.NOTA,C.NOMBRE CLIENTE,N.TOTAL,N.FECHA FROM NOTASDEVENTA N INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE INNER JOIN DETALLENOTASDEVENTA D ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA WHERE FECHA>=(SELECT DBO.LAFECHA()) AND N.TIENDA='" + frmPrincipal.SucursalBase + "'  AND D.PRODUCTO<>'CREDITO' ORDER BY N.NOTA"
        DGV.DataSource = BDLlenatabla(LAQ, frmPrincipal.CadenaConexion)
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        LAQ2 = "SELECT N.NOTA,C.NOMBRE CLIENTE,N.TOTAL,N.FECHA FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE  WHERE FECHA>=(SELECT DBO.LAFECHA()) AND N.TIENDA= '" + frmPrincipal.SucursalBase + "'   ORDER BY N.NOTA"
        DGV2.DataSource = BDLlenatabla(LAQ2, frmPrincipal.CadenaConexion)
        DGV2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        LAQ3 = "SELECT N.NOTA,C.NOMBRE CLIENTE,N.TOTAL,N.FECHA FROM NOTASDEVENTA N INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE INNER JOIN DETALLENOTASDEVENTA D ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA WHERE FECHA>=(SELECT DBO.LAFECHA()) AND N.TIENDA='" + frmPrincipal.SucursalBase + "'  AND D.PRODUCTO='CREDITO' ORDER BY N.NOTA"
        DGV3.DataSource = BDLlenatabla(LAQ3, frmPrincipal.CadenaConexion)
        DGV3.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV3.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'ACTIVAR(False)
        'CHECATABLA()
    End Sub
End Class