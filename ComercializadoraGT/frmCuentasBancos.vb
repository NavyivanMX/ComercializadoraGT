Public Class frmCuentasBancos
    Dim TABLAPRIN As New DataTable
    Dim CLABAN As New List(Of String)
    Dim CLABANCO As New List(Of String)
    Dim CLACU As New List(Of String)
    Private Sub frmCuentasBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CBACT.SelectedIndex = 0

        TABLAPRIN.Columns.Clear()
        TABLAPRIN.Columns.Add("BANCO")
        TABLAPRIN.Columns.Add("NUM. CUENTA")
        TABLAPRIN.Columns.Add("ACTIVO")
        TABLAPRIN.Columns.Add("CLAVE")

        If Not CARGACUENTA() Then
            MessageBox.Show("No hay dados de alta cuentas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Dim VG As New frmCuentas
            VG.ShowDialog()
        End If

        If Not CARGABANCO() Then
            MessageBox.Show("No hay dados de alta bancos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Dim VG As New frmBancos
            VG.ShowDialog()
        End If
       

        ACTIVAR2(True)
        ACTIVAR(True)

    End Sub
    Private Sub ACTIVAR2(ByVal V As Boolean)
        BTNAGREGAR.Enabled = V
        BTNQUITAR.Enabled = Not V
        BTNELIMINAR.Enabled = Not V
        BTNGUARDAR.Enabled = Not V
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        CBCU.Enabled = V
        CBBAN.Enabled = Not V
        TXTNC.Enabled = Not V
        CBACT.Enabled = Not V
        BTNAGREGAR.Enabled = Not V
        BTNCANCELAR.Enabled = Not V
    End Sub
    Private Sub LIMPIAR()
        CBBAN.SelectedIndex = 0
        CBCU.SelectedIndex = 0
        TXTNC.Text = ""
        CBACT.SelectedIndex = 0
    End Sub
    Private Function CARGABANCO() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBBAN, CLABAN, "SELECT CLAVE,NOMBRE FROM BANCOS WHERE ACTIVO=1  ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBBAN.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBBAN.SelectedIndex = 0
            Return LEIDO
        Catch ex As Exception

        End Try
    End Function
    Private Function CARGACUENTA() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBCU, CLACU, "SELECT CLAVE,NOMBRE FROM CUENTAS WHERE ACTIVO=1  ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBCU.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBCU.SelectedIndex = 0
            Return LEIDO
        Catch ex As Exception

        End Try
    End Function

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR2(True)
        ACTIVAR(True)

        If DGV.Rows.Count >= 1 Then
            DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
        End If
    End Sub

    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        Dim x As Integer
        For x = 0 To DGV.Rows.Count - 1
            If DGV.Item(0, x).Value.ToString = CBBAN.Text Then
                MessageBox.Show("El banco ya fue agregado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next
        AGREGAR()
    End Sub
    Private Sub AGREGAR()
        DGV.Rows.Add(1)
        Dim ITEMS As Integer
        ITEMS = DGV.Rows.Count - 1
        DGV.Item(0, ITEMS).Value = CBBAN.Text
        DGV.Item(1, ITEMS).Value = TXTNC.Text
        If CBACT.SelectedIndex = 0 Then
            DGV.Item(2, ITEMS).Value = True
        Else
            DGV.Item(2, ITEMS).Value = False
        End If
        DGV.Item(3, ITEMS).Value = CLABAN(CBBAN.SelectedIndex)
        DGV.Refresh()
        CLABANCO.Add(CLABAN(CBBAN.SelectedIndex))

        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).Visible = False

        BTNQUITAR.Enabled = True
        BTNGUARDAR.Enabled = True
        DGV.Refresh()
    End Sub
    Private Sub CHECATABLA()
        If DGV.Rows.Count = 0 Then
            BTNQUITAR.Enabled = False
            BTNELIMINAR.Enabled = False
            BTNGUARDAR.Enabled = False
        Else
            BTNQUITAR.Enabled = True
            BTNELIMINAR.Enabled = True
            BTNGUARDAR.Enabled = True
        End If
    End Sub
    Private Sub CARGAELBANCO(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CLABAN.Count - 1
            If CLABAN(X) = CLA Then
                CBBAN.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        CARGAELBANCO(DGV.Item(3, DGV.CurrentRow.Index).Value)
        TXTNC.Text = DGV.Item(1, DGV.CurrentRow.Index).Value
        DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
        'CLABANCO.RemoveAt(DGV.CurrentRow.Index)
        CHECATABLA()
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Estas seguro que deseas eliminar los elementos agregados?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If

        Dim SQL As New SqlClient.SqlCommand("DELETE FROM CUENTASBANCOS WHERE CUENTA='" + CLACU(CBCU.SelectedIndex) + "' ", frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
        DGV.Rows.Clear()
        DGV.Refresh()
        CHECATABLA()
        ACTIVAR2(True)
        ACTIVAR(True)
        CBCU.Focus()
    End Sub
    Private Sub GUARDAR()

        Dim SQL As New SqlClient.SqlCommand("DELETE FROM CUENTASBANCOS WHERE CUENTA='" + CLACU(CBCU.SelectedIndex) + "' ", frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
        Dim SQLD As New SqlClient.SqlCommand("INSERT INTO CUENTASBANCOS(CUENTA,BANCO,NUMCUENTA,ACTIVO)VALUES(@CU,@BAN,@NC,@ACT)", frmPrincipal.CONX)
        SQLD.Parameters.Add("@CU", SqlDbType.VarChar).Value = CLACU(CBCU.SelectedIndex)
        SQLD.Parameters.Add("@BAN", SqlDbType.VarChar)
        SQLD.Parameters.Add("@NC", SqlDbType.VarChar)
        SQLD.Parameters.Add("@ACT", SqlDbType.Bit)

        Dim X As Integer
        'Dim ABC As String
        For X = 0 To DGV.Rows.Count - 1
            SQLD.Parameters("@BAN").Value = DGV.Item(3, X).Value
            SQLD.Parameters("@NC").Value = DGV.Item(1, X).Value
            If DGV.Item(2, X).Value = True Then
                SQLD.Parameters("@ACT").Value = True
            Else
                SQLD.Parameters("@ACT").Value = False
            End If
            SQLD.ExecuteNonQuery()
        Next
        CLABANCO.Clear()
        MessageBox.Show("La información ha sido guardada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        DGV.Rows.Clear()
        ACTIVAR2(True)
        ACTIVAR(True)
        LIMPIAR()
    End Sub
    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
        CBCU.Focus()
    End Sub
    Private Sub CARGADATOS()
        Dim LAQ As String
        CLABANCO.Clear()
        LAQ = "SELECT CB.CUENTA,C.NOMBRE,CB.BANCO,B.NOMBRE,CB.NUMCUENTA,CB.ACTIVO  FROM CUENTASBANCOS CB INNER JOIN CUENTAS C  ON C.CLAVE=CB.CUENTA INNER JOIN BANCOS B  ON B.CLAVE=CB.BANCO  WHERE CB.CUENTA='" + CLACU(CBCU.SelectedIndex) + "'"
        Dim DA As New SqlClient.SqlDataAdapter(LAQ, frmPrincipal.CONX)
        Dim DDT As New DataTable
        DA.Fill(DDT)
        DGV.Rows.Clear()
        Dim X As Integer
        For X = 0 To DDT.Rows.Count - 1
            DGV.Rows.Add(1)
            Dim ITEMS As Integer
            ITEMS = DGV.Rows.Count - 1
            DGV.Item(0, ITEMS).Value = DDT.Rows(X).Item(3)
            DGV.Item(1, ITEMS).Value = DDT.Rows(X).Item(4)
            If CType(DDT.Rows(X).Item(5), Boolean) Then
                DGV.Item(2, ITEMS).Value = True
            Else
                DGV.Item(2, ITEMS).Value = False
            End If
            DGV.Item(3, ITEMS).Value = DDT.Rows(X).Item(2)
        Next
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).Visible = False
        ACTIVAR(False)
        CHECATABLA()
    End Sub

    Private Sub CBCU_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBCU.KeyPress, CBBAN.KeyPress, TXTNC.KeyPress, CBACT.KeyPress
        If e.KeyChar = Chr(13) Then
            CARGADATOS()
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TXTNC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTNC.TextChanged

    End Sub
End Class