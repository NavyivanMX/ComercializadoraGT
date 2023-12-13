Public Class frmSeleccionConversion
    Public OPC As Integer
    Private Sub frmSeleccionConversion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        OPC = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OPC = 1
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OPC = 2
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub
End Class