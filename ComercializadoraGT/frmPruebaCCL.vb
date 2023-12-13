Public Class frmPruebaCCL
    Dim DT As New DataTable
    Private Sub frmPruebaCCL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        DT.Columns.Add("Numero")
        DT.Columns.Add("Letra")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PROBAR()
    End Sub
    Private Sub PROBAR()
        Dim X As Integer
        PB.Minimum = 1
        PB.Maximum = 99999
        Dim CCL As New num2text
        For X = 1 To 99999
            Dim ROW As System.Data.DataRow = DT.NewRow
            ROW(0) = X.ToString
            ROW(1) = CCL.Letras(X.ToString)
            PB.Value = X
            DT.Rows.Add(ROW)
        Next
        DGV.DataSource = DT
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
End Class