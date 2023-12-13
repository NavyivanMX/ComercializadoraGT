Public Class frmReporteVentaSinExistenciaDesglosado
    Dim QUERY As String
    Private Sub frmReporteVentaSinExistenciaDesglosado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Private Function CHECAFECHAS() As Boolean
        If DTDE.Value.Date > DTHASTA.Value.Date Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub CARGADATOS()
        If Not CHECAFECHAS() Then
            MessageBox.Show("El rango de fechas esta incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        QUERY = "SELECT P.NOMBRE PRODUCTO,V.CANTIDAD CANTIDAD,U.NOMBRE UNIDAD,V.FECHA FROM VENTASINEXIS V inner join TIENDAS R   ON V.TIENDA= R.CLAVE INNER JOIN PRODUCTOS P   ON P.CP=V.PRODUCTO AND P.EMPRESA=R.EMPRESA INNER JOIN UNIDADES U   ON V.UNIDAD = U.CLAVE   WHERE FECHA>=@INI AND FECHA<=@FIN AND R.CLAVE='" + frmPrincipal.SucursalBase + "'  AND P.CLAVE<>'999' AND P.CLAVE<>'CREDITO' ORDER BY P.NOMBRE "
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()


        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub BTNCARGA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCARGA.Click
        CARGADATOS()
    End Sub
End Class