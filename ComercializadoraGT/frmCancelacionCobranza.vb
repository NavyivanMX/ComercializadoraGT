Public Class frmCancelacionCobranza
    Private Sub frmCancelacionCobranza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        CARGADATOS()
    End Sub

    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String
        QUERY = "SELECT NOTACOBRANZA [Nota Cobranza],Cliente,ABONOPAGO [Abono/Pago],TIPOPAGO [Tipo Pago],NOTAORIGEN [Nota Origen],TOTALORIGEN [Total Origen],FECHAVENTA [Fecha Venta],FECHAABONO [Fecha Abono/Pago],Cancelar FROM VNOTASCOBRANZASHOY WHERE TIENDA='" + frmPrincipal.SucursalBase + "' order by fechaabono"
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        Dim X As Integer
        For X = 0 To DGV.Columns.Count - 1
            DGV.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        DGV.Columns(0).Frozen = True
        DGV.Columns(1).Frozen = True
        DGV.Columns(2).Frozen = True
        DGV.Columns(2).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(5).DefaultCellStyle = DgvCellFormatoNumerico()
    End Sub
    Private Sub CANCELAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim X As Integer
        Dim SQL As New SqlClient.SqlCommand("SPCANCELARPAGO", frmPrincipal.CONX)
        SQL.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQL.Parameters.Add("@NOTA", SqlDbType.Int)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.CommandTimeout = 100
        For X = 0 To DGV.RowCount - 1
            If CType(DGV.Item(8, X).Value, Boolean) Then
                SQL.Parameters("@NOTA").Value = DGV.Item(0, X).Value.ToString
                SQL.ExecuteNonQuery()
            End If
        Next
        MessageBox.Show("Los abonos/pagos han sido cancelados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CARGADATOS()
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea eliminar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        CANCELAR()
        CARGADATOS()

    End Sub
End Class