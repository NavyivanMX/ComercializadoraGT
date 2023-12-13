Public Class frmReporteInventarioMixto

    Private Sub frmReporteInventarioMixto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String
        QUERY = "SELECT CLAVE,PRODUCTO,MOCHIS,BODEGA,LOZA FROM VEXISTENCIASPM3 "
        If String.IsNullOrEmpty(TXTCLA.Text) Then
        Else
            QUERY += " WHERE PRODUCTO LIKE '%" + TXTCLA.Text + "%'"
        End If
        QUERY += " ORDER BY PRODUCTO "
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(3).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(4).DefaultCellStyle = DgvCellFormatoNumerico()
    End Sub

    Private Sub TXTCLA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLA.KeyPress
        If e.KeyChar = Chr(13) Then
            CARGADATOS()
        End If
    End Sub
End Class