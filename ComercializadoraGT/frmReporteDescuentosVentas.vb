Public Class frmReporteDescuentosVentas

    Private Sub frmReporteDescuentosVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        If Not CHECAFECHAS() Then
            MessageBox.Show("El rango de fechas esta incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim QUERY As String
        QUERY = "SELECT N.NOTA,P.NOMBRE PRODUCTO,D.CANTIDAD,D.DESCUENTO [DESCUENTO %],D.TOTAL [TOTAL $$],E.NOMBRE CAJERA, N.FECHA FECHA  FROM NOTASDEVENTA N INNER JOIN DETALLENOTASDEVENTA D ON N.TIENDA=D.TIENDA AND N.NOTA=D.NOTA INNER JOIN PRODUCTOS P ON P.CLAVE=D.PRODUCTO INNER JOIN EMPLEADOS E ON E.CLAVE=N.CAJERA AND E.TIENDA='" + frmPrincipal.SucursalBase + "' WHERE FECHA>=@INI AND FECHA<=@FIN AND N.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.DESCUENTO<>0"

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'CHECATABLA()
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub
End Class