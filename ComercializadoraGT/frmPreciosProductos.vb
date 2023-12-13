Public Class frmPreciosProductos
    Dim CLAGRU As New List(Of String)
    Dim CLAPROD As New List(Of String)
    Dim LRE As New List(Of String)
    Private Sub frmPreciosProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        OPLlenaCLB(CLB, LRE, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE CLAVE<>'PRUEBAS' AND CLAVE<>'ST' ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion)
        CARGAGRUPOS()
        CHECATABLA()
    End Sub
    Private Sub CARGAGRUPOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        OPLlenaComboBox(CBGRU, CLAGRU, "SELECT CLAVE,NOMBRE FROM GRUPOS WHERE ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBGRU.Items.Count > 0 Then

        End If

        Try
            CBGRU.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CARGAPRODUCTOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        OPLlenaComboBox(CBPRO, CLAPROD, "SELECT CLAVE,NOMBRE FROM PRODUCTOS WHERE GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "' AND ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " AND CLAVE<>'CREDITO' AND CLAVE<>'999' ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBPRO.Items.Count > 0 Then

        End If

        Try
            CBPRO.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged
        CARGAPRODUCTOS()
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String

        QUERY = "SELECT P.CLAVE,P.NOMBRE,P.PRECIO FROM PRODUCTOS P WHERE P.CLAVE='" + CLAPROD(CBPRO.SelectedIndex) + "' "

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV.Refresh()

        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).ReadOnly = True
        'DGV.Columns(0).Visible = False
        DGV2.DataSource = BDLlenatabla("SELECT T.NOMBRECOMUN TIENDA,P.NOMBRE PRODUCTO,PR.PRECIO FROM PRECIOSTIENDAS PR INNER JOIN TIENDAS T ON PR.TIENDA=T.CLAVE INNER JOIN PRODUCTOS P ON PR.CLAVE=P.CLAVE WHERE PR.CLAVE='" + CLAPROD(CBPRO.SelectedIndex) + "' ", frmPrincipal.CadenaConexion)
        DGV2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        BTNGUARDAR.Enabled = True
    End Sub

    Private Sub CBPRO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBPRO.KeyPress
        If e.KeyChar = Chr(13) Then
            CARGADATOS()
        End If
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        DGV.DataSource = Nothing
        DGV.Refresh()

        CARGAGRUPOS()
        CHECATABLA()
    End Sub
    Private Sub CARGAELGRUPO(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CLAGRU.Count - 1
            If CLAGRU(X) = CLA Then
                CBGRU.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
    Private Sub CARGAELPRODUCTO(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CLAPROD.Count - 1
            If CLAPROD(X) = CLA Then
                CBPRO.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS WHERE EMPRESA=" + frmPrincipal.Empresa + " ", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 2, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(1))
            CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
            CARGADATOS()
        End If
    End Sub
    Private Sub CHECATABLA()
        If DGV.DataSource = Nothing Then
            BTNGUARDAR.Enabled = False
        Else
            BTNGUARDAR.Enabled = True
        End If
    End Sub
    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("", frmPrincipal.CONX)
        Dim X As Integer
        For A = 0 To CLB.Items.Count - 1
            If CLB.GetItemChecked(A) Then
                For X = 0 To DGV.Rows.Count - 1
                    SQL.CommandText = "UPDATE PRODUCTOS SET " + LRE(A) + "=" + DGV.Item(2, X).Value.ToString + ",USUARIO='" + frmPrincipal.Usuario + "' WHERE CLAVE='" + CLAPROD(CBPRO.SelectedIndex) + "' "
                    SQL.ExecuteNonQuery()
                Next
            End If
        Next
        DGV.DataSource = Nothing
        DGV.Refresh()

        MessageBox.Show("La información ha sido guardada exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        CARGAGRUPOS()
        CHECATABLA()
    End Sub

    Private Sub CBGRU_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBGRU.KeyPress, CBPRO.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmPreciosProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS  ", " WHERE NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Productos", "Nombre del Producto", "Productos(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLAGRU, CBGRU, frmClsBusqueda.TREG.Rows(0).Item(1).ToString)
                OPCargaX(CLAPROD, CBPRO, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
    End Sub
End Class