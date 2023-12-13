Public Class frmReportePreciosClientes
    Dim CLACLI As New List(Of String)
    Dim CLASG As New List(Of String)
    Private Sub frmReportePreciosClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        OPLlenaComboBox(CBCLI, CLACLI, "SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1 AND CLAVE<>0 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
    End Sub

    'Private Sub CHECATABLA()
    '    If DGV.Rows.Count = 0 Then
    '        BTNQUITAR.Enabled = False
    '        BTNELIMINAR.Enabled = False
    '    Else
    '        BTNQUITAR.Enabled = True
    '        BTNELIMINAR.Enabled = True
    '    End If
    'End Sub
    Private Sub CARGADATOS()
        Dim LAQ As String

            LAQ = "SELECT C.PRODUCTO CLAVE,P.NOMBRE PRODUCTO,C.PRECIO FROM PRECIOSCLIENTES C INNER JOIN PRODUCTOS P ON C.PRODUCTO=P.CLAVE WHERE C.TIENDA='" + frmPrincipal.SucursalBase + "' AND C.CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "' ORDER BY P.NOMBRE"
     

            DGV.DataSource = BDLlenatabla(LAQ, frmPrincipal.CadenaConexion)

            DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ' ACTIVAR(False)
            'CHECATABLA()
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        CARGADATOS()
    End Sub

    Private Sub frmReportePreciosClientes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0 ", " AND NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLACLI, CBCLI, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
    End Sub
End Class