Public Class frmClientesRFC
    Dim CLACLI As New List(Of String)
    Dim DT As New DataTable
    Dim cliente As String


    Private Sub frmClientesRFC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        If cliente = 0 Then
            If Not CARGACLIENTES() Then
                MessageBox.Show("Debe dar de alta clientes primero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            ACTIVAR(True)
        End If

    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        Try
            CBCLI.Enabled = V
            TXTNOMFIS.Enabled = Not V
            TXTRFC.Enabled = Not V
            TXTDIR.Enabled = Not V
            TXTCP.Enabled = Not V
            TXTCD.Enabled = Not V
            TXTE.Enabled = Not V
            If V Then
                CBCLI.SelectAll()
                CBCLI.Focus()
            Else
                TXTNOMFIS.SelectAll()
                TXTNOMFIS.Focus()
            End If

            'BTNAGREGAR.Enabled = V
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub LIMPIAR()
        TXTNOMFIS.Text = ""
        TXTRFC.Text = ""
        TXTDIR.Text = ""
        TXTCP.Text = ""
        TXTCD.Text = ""
        TXTE.Text = ""
        TXTNOMFIS.Focus()
    End Sub
    Private Sub CANCELAR()
        Try
            Dim xyz As Short
            xyz = MessageBox.Show("¿Esta seguro que desea cancelar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xyz = 6 Then
                DT.Rows.Clear()
                DGV.Refresh()
                CHECATABLA()
                ACTIVAR(True)
                LIMPIAR()
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Function CARGACLIENTES() As Boolean
        Try
            Dim SQL As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM CLIENTES WHERE ACTIVO=1 AND TIENDA='" + frmPrincipal.SucursalBase + "' ORDER BY NOMBRE", frmPrincipal.CONX)
            Dim LEC As SqlClient.SqlDataReader
            LEC = SQL.ExecuteReader
            CBCLI.Items.Clear()
            CLACLI.Clear()
            Dim LEIDO As Boolean
            LEIDO = False
            While LEC.Read
                CBCLI.Items.Add(LEC(1))
                CLACLI.Add(LEC(0))
                LEIDO = True
            End While
            LEC.Close()
            CBCLI.SelectedIndex = 0
            Return LEIDO
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Public Function CARGACLI(ByVal CLI As String) As Boolean
        If Not CARGACLIENTES() Then
            MessageBox.Show("Debe dar de alta clientes primero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If
        OPCargaX(CLACLI, CBCLI, CLI)
    End Function
    Public Sub CARGADATOS()
        Dim QUERY As String
        ACTIVAR(False)
        QUERY = "SELECT NOMBREFISCAL,RFC,DIRECCION,CP,CIUDAD,ENCARGADO FROM CLIENTERFC WHERE CLIENTE=" + CLACLI(CBCLI.SelectedIndex) + " AND TIENDA='" + frmPrincipal.SucursalBase + "'"
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim DA As New SqlClient.SqlDataAdapter()
        DA.SelectCommand = SQL

        DA.Fill(DT)
        DGV.DataSource = DT
        DGV.Refresh()

        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        CHECATABLA()
        ' BTN.Enabled = True
    End Sub
    Public Sub CARGADATOS2(ByVal cla As Integer)

        ACTIVAR(False)
        CARGACLIENTES()
        Dim X As Integer
        For X = 0 To CLACLI.Count - 1
            If CLACLI(X) = cla Then
                CBCLI.SelectedIndex = X
            End If
        Next
        cliente = cla
        CARGADATOS()
        CHECATABLA()
        ACTIVAR(False)
        Me.ShowDialog()

    End Sub

   
    Private Sub TXTCP_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCP.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        AGREGAR()
    End Sub
    Private Sub AGREGAR()
        Try
            If TXTNOMFIS.Text = "" Or TXTCD.Text = "" Or TXTCP.Text = "" Or TXTRFC.Text = "" Or TXTDIR.Text = "" Or TXTE.Text = "" Then
                MessageBox.Show("Debe llenar todos los campos para poder agregar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TXTNOMFIS.Focus()
                TXTNOMFIS.SelectAll()
                Exit Sub
            End If

            AGREGAR(TXTNOMFIS.Text, TXTRFC.Text, TXTDIR.Text, TXTCP.Text, TXTCD.Text, TXTE.Text)
            LIMPIAR()
            CHECATABLA()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub AGREGAR(ByVal NOMFIS As String, ByVal RFC As String, ByVal DIR As String, ByVal CP As String, ByVal CD As String, ByVal E As String)
        Try
            Dim DOW As System.Data.DataRow = DT.NewRow
            DOW(0) = NOMFIS
            DOW(1) = RFC
            DOW(2) = DIR
            DOW(3) = CP
            DOW(4) = CD
            DOW(5) = E
            DT.Rows.Add(DOW)

            DGV.DataSource = DT
            DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DGV.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Refresh()
            CHECATABLA()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        QUITAR()
    End Sub
    Private Sub QUITAR()
        Try
            TXTNOMFIS.Text = DGV.Item(0, DGV.CurrentRow.Index).Value
            TXTRFC.Text = DGV.Item(1, DGV.CurrentRow.Index).Value
            TXTDIR.Text = DGV.Item(2, DGV.CurrentRow.Index).Value
            TXTCP.Text = DGV.Item(3, DGV.CurrentRow.Index).Value
            TXTCD.Text = DGV.Item(4, DGV.CurrentRow.Index).Value
            TXTE.Text = DGV.Item(5, DGV.CurrentRow.Index).Value
            DT.Rows.RemoveAt(DGV.CurrentRow.Index)
            DGV.DataSource = DT
            DGV.Refresh()
            CHECATABLA()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub CBCLI_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBCLI.KeyPress
        If e.KeyChar = Chr(13) Then
            CARGADATOS()
        End If
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        CANCELAR()
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub
    Private Sub GUARDAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        'CHECATABLA()

        Dim SQLBORRA As New SqlClient.SqlCommand("DELETE FROM CLIENTERFC WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "'", frmPrincipal.CONX)
        SQLBORRA.CommandTimeout = 300
        SQLBORRA.ExecuteNonQuery()
        SQLBORRA.Dispose()

        

        Dim SQLGUARDA As New SqlClient.SqlCommand("INSERT INTO CLIENTERFC (TIENDA,CLIENTE,NOMBREFISCAL,RFC,DIRECCION,CP,CIUDAD,REGISTRO,ENCARGADO)VALUES (@TI,@CLI,@NOM,@RFC,@DIR,@CP,@CD,@REG,@E)", frmPrincipal.CONX)
        SQLGUARDA.CommandTimeout = 300
        SQLGUARDA.Parameters.Add("@TI", SqlDbType.VarChar, 10)
        SQLGUARDA.Parameters.Add("@CLI", SqlDbType.Int)
        SQLGUARDA.Parameters.Add("@NOM", SqlDbType.VarChar, 100)
        SQLGUARDA.Parameters.Add("@RFC", SqlDbType.VarChar, 13)
        SQLGUARDA.Parameters.Add("@DIR", SqlDbType.VarChar, 100)
        SQLGUARDA.Parameters.Add("@CP", SqlDbType.VarChar, 10)
        SQLGUARDA.Parameters.Add("@CD", SqlDbType.VarChar, 100)
        SQLGUARDA.Parameters.Add("@REG", SqlDbType.Int)
        SQLGUARDA.Parameters.Add("@E", SqlDbType.VarChar, 100)

        SQLGUARDA.Parameters("@TI").Value = frmPrincipal.SucursalBase
        SQLGUARDA.Parameters("@CLI").Value = CLACLI(CBCLI.SelectedIndex)
        Dim L As String
        L = DGV.Item(0, 0).Value.ToString

        For X = 0 To DGV.Rows.Count - 1
            SQLGUARDA.Parameters("@NOM").Value = DGV.Item(0, X).Value.ToString
            SQLGUARDA.Parameters("@RFC").Value = DGV.Item(1, X).Value.ToString
            SQLGUARDA.Parameters("@DIR").Value = DGV.Item(2, X).Value.ToString
            SQLGUARDA.Parameters("@CP").Value = DGV.Item(3, X).Value.ToString
            SQLGUARDA.Parameters("@CD").Value = DGV.Item(4, X).Value.ToString
            SQLGUARDA.Parameters("@E").Value = DGV.Item(5, X).Value.ToString
            SQLGUARDA.Parameters("@REG").Value = X
            SQLGUARDA.ExecuteNonQuery()
        Next
        SQLGUARDA.Dispose()

        MessageBox.Show("La información ha sido guardada exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        DT.Clear()
        DGV.Refresh()
        CHECATABLA()
        ACTIVAR(True)
        LIMPIAR()
    End Sub
    Private Sub CHECATABLA()
        If DGV.Rows.Count = 0 Then
            'BTNAGREGAR.Enabled = False
            BTNQUITAR.Enabled = False
            'BTNCANCELAR.Enabled = False
            BTNGUARDAR.Enabled = False
            'TXTCANT.Text = ""
            'TXTCOS.Text = ""
            ' BTNBUSCAR.Enabled = False
        Else

            ' BTNBUSCAR.Enabled = True
            BTNGUARDAR.Enabled = True
            BTNQUITAR.Enabled = True
            BTNCANCELAR.Enabled = True
        End If
    End Sub
    Public Sub CARGACLIENTE(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CLACLI.Count - 1
            If CLACLI(X) = CLA Then
                CBCLI.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' ", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de cliente", "Nombre del cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CARGACLIENTE(frmClsBusqueda.TREG.Rows(0).Item(1))
            CARGADATOS()
        End If
    End Sub

    Private Sub TXTNOMFIS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOMFIS.KeyPress, TXTRFC.KeyPress, TXTDIR.KeyPress, TXTCP.KeyPress, TXTCD.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmClientesRFC_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        cliente = 0
    End Sub

    Private Sub frmClientesRFC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

    End Sub
End Class