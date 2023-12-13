Public Class frmAjustarInventario
    Dim DTP As New DataTable
    Dim DTA As New DataTable
    Dim DTD As New DataTable
    Dim DT As New DataTable
    Dim DTT As New DataTable
    Dim DV As New DataView
    Dim DTTEMP As New DataTable '' TABLA IMPRESION
    Private Sub frmAjustarInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        DTT.Columns.Add("Codigo")
        DTT.Columns.Add("Nombre")
        DTT.Columns.Add("Seleccionado", GetType(Boolean))
        DTT.Columns.Add("Cantidad", GetType(Double))
        DTT.Columns.Add("Marcado", GetType(Boolean))
    End Sub


    Private Sub BTN2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN2.Click
        frmBusquedaSeleccionMultiple.BUSCAR("SELECT CLAVE,NOMBRE,DBO.EXISTENCIAALMACEN('" + frmPrincipal.SucursalBase + "',CP) EXISTENCIA FROM PRODUCTOS ", " WHERE NOMBRE", " ORDER BY NOMBRE", "Selección de Productos", "Nombre del Producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, False, DTP)

        If frmBusquedaSeleccionMultiple.DialogResult = Windows.Forms.DialogResult.Yes Then
            DTA = New DataTable
            DTA = frmBusquedaSeleccionMultiple.TREG
            DGV.DataSource = DTA
            ACTUALIZASELECCION()
        End If
    End Sub
    Private Sub ACTUALIZASELECCION()

        Dim X, Y As Integer
        Dim ENC As Boolean
        For X = 0 To DTA.Rows.Count - 1
            ENC = False

            For Y = 0 To DTT.Rows.Count - 1
                If DTA.Rows(X).Item(0).ToString = DTT.Rows(Y).Item(0).ToString Then
                    ENC = True
                    DTT.Rows(Y).Item(2) = DTA.Rows(X).Item(2)
                End If
            Next
            If Not ENC Then
                Dim DOW As System.Data.DataRow = DTT.NewRow
                DOW(0) = DTA.Rows(X).Item(0).ToString
                DOW(1) = DTA.Rows(X).Item(1).ToString
                DOW(2) = DTA.Rows(X).Item(2).ToString
                DOW(3) = "0"
                DOW(4) = True
                DTT.Rows.Add(DOW)
            End If
        Next
        DV = New DataView(DTT, "Seleccionado=true", "Nombre", DataViewRowState.CurrentRows)
        DGV.DataSource = DV.ToTable
        DGV.Columns(2).Visible = False
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).ReadOnly = True
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).DefaultCellStyle = DgvCellFormatoNumerico()
        LBLB.Text = DGV.Rows.Count.ToString
    End Sub
    Private Sub MARCAR(ByVal V As Boolean)
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            DGV.Item(4, X).Value = V
        Next
    End Sub

    Private Sub BTNMARCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMARCAR.Click
        MARCAR(True)
    End Sub

    Private Sub BTNDESMARCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNDESMARCAR.Click
        MARCAR(False)
    End Sub
    Private Function VERIFICAMARCADO() As Boolean
        If DGV.Rows.Count <= 0 Then
            Return False
        End If
        Dim REG As Boolean
        REG = False
        'Dim A, B As String
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            'A = DGV.Item(4, X).Value.ToString
            'B = DGV.Item(3, X).Value.ToString
            If CType(DGV.Item(4, X).Value, Boolean) Then
                If DGV.Item(3, X).Value > 0 Then
                    REG = True
                End If
            End If
        Next
        Return REG
    End Function

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        If Not VERIFICAMARCADO() Then
            MessageBox.Show("Favor de marcar y poner cantidades válidas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        Dim X, Y, CANT As Integer
        Dim SQL As New SqlClient.SqlCommand("SPAJUSTARINVENTARIO", frmPrincipal.CONX)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQL.Parameters.Add("@PRO", SqlDbType.VarChar)
        SQL.Parameters.Add("@CANT", SqlDbType.VarChar)
        SQL.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        For X = 0 To DGV.Rows.Count - 1

            If CType(DGV.Item(4, X).Value, Boolean) Then
                If DGV.Item(3, X).Value > 0 Then
                    SQL.Parameters("@PRO").Value = DGV.Item(0, X).Value
                    SQL.Parameters("@CANT").Value = DGV.Item(3, X).Value
                    ' CANT = DGV.Item(3, X).Value
                    SQL.ExecuteNonQuery()
                End If
            End If
        Next
        MessageBox.Show("Ajustes realizados exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        DGV.DataSource = Nothing
        DGV.Refresh()

    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click

    End Sub
End Class