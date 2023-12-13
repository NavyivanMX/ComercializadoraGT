Public Class frmReportePreciosSucursal
    Dim CLAGRU As New List(Of String)
    Dim CLAPROD As New List(Of String)
    Private Sub frmReportePreciosSucursal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGAGRUPOS()
        CARGAPRODUCTOS()
    End Sub
    Private Sub CARGAGRUPOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
       OPLlenaComboBox(CBGRU, CLAGRU, "SELECT CLAVE,NOMBRE FROM GRUPOS WHERE ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " ORDER BY NOMBRE", frmPrincipal.CadenaConexion, "Todos los grupos", "")
        If CBGRU.Items.Count > 0 Then

        End If

        Try
            CBGRU.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub
    Private Function CARGAPRODUCTOS() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
       OPLlenaComboBox(CBPRO, CLAPROD, "SELECT CLAVE,NOMBRE FROM PRODUCTOS WHERE GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "' AND ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " AND CLAVE<>'CREDITO' AND CLAVE<>'999' AND CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1)ORDER BY NOMBRE", frmPrincipal.CadenaConexion, "Todos los productos", "")
        If CBPRO.Items.Count > 0 Then
        End If

        Try
            CBPRO.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Function

    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged
        CARGAPRODUCTOS()
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String

        QUERY = "SELECT T.NOMBRECOMUN TIENDA,G.NOMBRE GRUPO,P.NOMBRE PRODUCTO,PT.PRECIO  FROM PRECIOSTIENDAS PT INNER JOIN TIENDAS  T ON T.CLAVE=PT.TIENDA INNER JOIN PRODUCTOS P  ON P.CLAVE=PT.CLAVE INNER JOIN GRUPOS G ON G.CLAVE=P.GRUPO "
        If CBGRU.SelectedIndex = 0 Then
            If CBPRO.SelectedIndex = 0 Then
            Else
            End If
        Else
            If CBPRO.SelectedIndex = 0 Then
                QUERY = QUERY + " WHERE G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1)"
            Else
                QUERY = QUERY + " WHERE G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' AND P.CLAVE='" + CLAPROD(CBPRO.SelectedIndex) + "' AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1)"
            End If
        End If
        QUERY = QUERY + " ORDER BY P.NOMBRE"

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub

    Private Sub frmReportePreciosSucursal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS  ", " WHERE NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Productos", "Nombre del Producto", "Productos(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLAGRU, CBGRU, frmClsBusqueda.TREG.Rows(0).Item(1).ToString)
                OPCargaX(CLAPROD, CBPRO, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
    End Sub
End Class