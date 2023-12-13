Public Class frmReporteNotaCanceladaCredito

    Private Sub frmReporteNotaCanceladaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        QUERY = "SELECT	N.NOTA,N.TOTAL,C.NOMBRE CLIENTE,N.USUARIO,N.OBSERVACION,N.FECHA FROM NOTASCANCELADASCREDITO N INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE  WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.FECHA>=@INI AND N.FECHA<=@FIN "

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ' CHECATABLA()
    End Sub

    Private Sub CARGADETALLE(ByVal NOTA As Integer)
        DGV2.DataSource = BDLlenatabla("SELECT D.PRODUCTO CLAVE,P.NOMBRE PRODUCTO,D.CANTIDAD,D.DESCUENTO,D.TOTAL FROM DETALLENOTACANCELADACREDITO D INNER JOIN TIENDAS T ON T.CLAVE=D.TIENDA INNER JOIN PRODUCTOS P ON P.EMPRESA=T.EMPRESA AND D.PRODUCTO=P.CLAVE WHERE T.EMPRESA='" + frmPrincipal.Empresa + "' AND D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + NOTA.ToString + "", frmPrincipal.CadenaConexion)

        DGV2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ' DGV2.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub DGV_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        CARGADETALLE(DGV.Item(0, DGV.CurrentRow.Index).Value)
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub
End Class