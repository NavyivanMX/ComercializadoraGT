Public Class frmHistorialCambioPrecio

    Private Sub frmHistorialCambioPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        QUERY = "SELECT T.NOMBRECOMUN TIENDA,P.NOMBRE PRODUCTO,H.PRECIOANT,H.PRECIODES,(H.PRECIODES-H.PRECIOANT) DIFERENCIA,H.FECHA,H.USUARIO FROM HISTCAMBIOPRECIOSSUCURSALES H INNER JOIN TIENDAS T ON T.CLAVE=H.TIENDA INNER JOIN PRODUCTOS P ON H.PRODUCTO=P.CP WHERE H.FECHA>=@INI AND H.FECHA<=@FIN  "

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub
End Class