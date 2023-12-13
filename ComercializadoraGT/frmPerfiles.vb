Public Class frmPerfiles
    Dim LM As New List(Of String)
    Dim LSM As New List(Of String)
    Dim LSSM As New List(Of String)
    Dim DT As New DataTable
    Dim DT2 As New DataTable
    Dim DTG As New DataTable
    Dim DV As New DataView
    Dim DV2 As New DataView
    Private Sub frmPerfiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        DTG.Columns.Add("Menú")
        DTG.Columns.Add("Sub Menú")
        DTG.Columns.Add("Sub Sub Menú")
        DTG.Columns.Add("M")
        DTG.Columns.Add("SM")
        DTG.Columns.Add("SSM")
        DT2 = BDLlenatabla("SELECT S.CLAVE,S.NOMBRE,S.SUBMENU FROM SUBSUBMENUS S WHERE SISTEMA=1", frmPrincipal.CadenaConexion)
        DT = BDLlenatabla("SELECT S.CLAVE,S.NOMBRE,S.MENU FROM SUBMENUS S WHERE SISTEMA=1", frmPrincipal.CadenaConexion)
        OPLlenaListBox(LBM, LM, "SELECT CLAVE,NOMBRE FROM MENUS WHERE SISTEMA=1 AND ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        CHECATABLA()
        ACTIVAR(True)
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTCLA.Enabled = V
        TXTNOM.Enabled = Not V
        BTNAGREGAR.Enabled = Not V
    End Sub
    Private Sub CARGADATAVIEW(ByVal MENU As String)
        DV = New DataView(DT, "MENU='" + MENU + "'", "NOMBRE", DataViewRowState.CurrentRows)
        'DGV2.DataSource = DT
        CARGASUBMENU()
    End Sub
    Private Sub CARGASUBMENU()
        LSM.Clear()
        LBSM.Items.Clear()
        
        Dim X As Integer
        Dim DRV As DataRowView
        For X = 0 To DV.Count - 1
            DRV = DV.Item(X)
            LSM.Add(DRV.Item(0))
            LBSM.Items.Add(DRV.Item(1))
        Next
        If DV.Count > 0 Then
            LBSM.SelectedIndex = 0
        End If
    End Sub
    Private Sub CARGADATAVIEW2(ByVal SUBMENU As String)
        DV2 = New DataView(DT2, "SUBMENU='" + SUBMENU + "'", "NOMBRE", DataViewRowState.CurrentRows)
        'DGV2.DataSource = DT
        CARGASUBSUBBMENU()
    End Sub
    Private Sub CARGASUBSUBBMENU()
        LSSM.Clear()
        LBSSM.Items.Clear()

        Dim X As Integer
        Dim DRV As DataRowView
        For X = 0 To DV2.Count - 1
            DRV = DV2.Item(X)
            LSSM.Add(DRV.Item(0))
            LBSSM.Items.Add(DRV.Item(1))
        Next
        If DV2.Count > 0 Then
            LBSSM.SelectedIndex = 0
        End If
    End Sub
    Private Sub LBM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBM.SelectedIndexChanged
        CARGADATAVIEW(LM(LBM.SelectedIndex))
    End Sub

    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        If LSSM.Count <= 0 Then
            AGREGAR(LBM.SelectedItem, LBSM.SelectedItem, "", LM(LBM.SelectedIndex), LSM(LBSM.SelectedIndex), 0)
        Else
            AGREGAR(LBM.SelectedItem, LBSM.SelectedItem, LBSSM.SelectedItem, LM(LBM.SelectedIndex), LSM(LBSM.SelectedIndex), LSSM(LBSSM.SelectedIndex))
        End If

    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT NOMBRE FROM PERFILES WHERE SISTEMA='1' AND PERFIL='" + TXTCLA.Text + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            TXTNOM.Text = LEC(0)
        End If
        LEC.Close()
        SQL.Dispose()
        ACTIVAR(False)

        Dim DTTEM As New DataTable
        DTTEM = BDLlenatabla("SELECT M.NOMBRE,S.NOMBRE,SS.NOMBRE,D.MENU,D.SUBMENU,D.SUBSUBMENU FROM PERFILESD D INNER JOIN MENUS M ON D.MENU=M.CLAVE AND D.SISTEMA=M.SISTEMA INNER JOIN SUBMENUS S ON D.SUBMENU=S.CLAVE  AND D.SISTEMA=S.SISTEMA INNER JOIN SUBSUBMENUS SS ON D.SUBSUBMENU=SS.CLAVE AND D.SISTEMA=SS.SISTEMA WHERE D.SISTEMA='1' AND D.PERFIL='" + TXTCLA.Text + "'", frmPrincipal.CadenaConexion)
        Dim X As Integer
        For X = 0 To DTTEM.Rows.Count - 1
            AGREGAR(DTTEM.Rows(X).Item(0), DTTEM.Rows(X).Item(1), DTTEM.Rows(X).Item(2), DTTEM.Rows(X).Item(3), DTTEM.Rows(X).Item(4), DTTEM.Rows(X).Item(5))
        Next

    End Sub
    Private Function AGREGADO(ByVal A As String, ByVal B As String, ByVal C As String) As Boolean
        Dim X As Integer
        For X = 0 To DTG.Rows.Count - 1
            If DTG.Rows(X).Item(3) = A And DTG.Rows(X).Item(4) = B And DTG.Rows(X).Item(5) = C Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub AGREGAR(ByVal MN As String, ByVal SMN As String, ByVal SSMN As String, ByVal M As String, ByVal SM As String, ByVal SSM As String)
        If AGREGADO(M, SM, SSM) Then
            Exit Sub
        End If
        Dim ROW As System.Data.DataRow = DTG.NewRow
        ROW(0) = MN
        ROW(1) = SMN
        ROW(2) = SSMN
        ROW(3) = M
        ROW(4) = SM
        ROW(5) = SSM
        DTG.Rows.Add(ROW)
        DGV.DataSource = DTG
        DGV.Columns(5).Visible = False
        DGV.Columns(4).Visible = False
        DGV.Columns(3).Visible = False
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()
        If DGV.Rows.Count <= 0 Then
            BTNQUITAR.Enabled = False
            BTNGUARDAR.Enabled = False
        Else
            BTNQUITAR.Enabled = True
            BTNGUARDAR.Enabled = True
        End If
    End Sub
    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        DTG.Rows.RemoveAt(DGV.CurrentRow.Index)
        CHECATABLA()
    End Sub

    Private Sub LBSM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBSM.SelectedIndexChanged
        CARGADATAVIEW2(LSM(LBSM.SelectedIndex))
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT SISTEMA,PERFIL,NOMBRE,ACTIVO FROM PERFILES WHERE SISTEMA=1", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Perfiles", "Nombre del Perfil", "Perfil(es)", 2, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCLA.Text = frmClsBusqueda.TREG.Rows(0).Item(1).ToString
            CARGADATOS()
        End If
    End Sub

    Private Sub TXTCLA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLA.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTCLA.Text = "" Then
            Else
                CARGADATOS()
            End If
        End If
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
    End Sub
    Private Sub GUARDAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        Dim SQL As New SqlClient.SqlCommand("DELETE FROM PERFILES WHERE PERFIL='" + TXTCLA.Text + "' AND SISTEMA=1", frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
        SQL.CommandText = "INSERT INTO PERFILES (SISTEMA,PERFIL,NOMBRE )VALUES ('1','" + TXTCLA.Text + "','" + TXTNOM.Text + "')"
        SQL.ExecuteNonQuery()
        SQL.CommandText = "DELETE FROM PERFILESD WHERE SISTEMA=1 AND PERFIL='" + TXTCLA.Text + "'"
        SQL.ExecuteNonQuery()
        SQL.Dispose()
        Dim SQLD As New SqlClient.SqlCommand("INSERT INTO PERFILESD VALUES (1,'" + TXTCLA.Text + "',@M,@S,@SS)", frmPrincipal.CONX)
        SQLD.Parameters.Add("@M", SqlDbType.Int)
        SQLD.Parameters.Add("@S", SqlDbType.Int)
        SQLD.Parameters.Add("@SS", SqlDbType.Int)
        Dim X As Integer
        For X = 0 To DTG.Rows.Count - 1
            SQLD.Parameters("@M").Value = DTG.Rows(X).Item(3)
            SQLD.Parameters("@S").Value = DTG.Rows(X).Item(4)
            SQLD.Parameters("@SS").Value = DTG.Rows(X).Item(5)
            SQLD.ExecuteNonQuery()
        Next
        MessageBox.Show("GUARDADO")
        DTG.Rows.Clear()
        DGV.DataSource = Nothing
        TXTNOM.Text = ""
        ACTIVAR(True)
    End Sub


    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
        DGV.DataSource = Nothing
        CHECATABLA()
    End Sub

    Private Sub frmPerfiles_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F4 Then
            If LSSM.Count <= 0 Then
                AGREGAR(LBM.SelectedItem, LBSM.SelectedItem, "", LM(LBM.SelectedIndex), LSM(LBSM.SelectedIndex), 0)
            Else
                AGREGAR(LBM.SelectedItem, LBSM.SelectedItem, LBSSM.SelectedItem, LM(LBM.SelectedIndex), LSM(LBSM.SelectedIndex), LSSM(LBSSM.SelectedIndex))
            End If
        End If
    End Sub
End Class