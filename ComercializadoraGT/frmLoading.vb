Public Class frmLoading
    Private Sub frmLoading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        Me.BringToFront()
        pbLoading.Load("NSTrabajando.gif")
        pbLoading.Location = New Point(Me.Width / 2 - pbLoading.Width / 2, Me.Height / 2 - pbLoading.Height / 2)
    End Sub
End Class