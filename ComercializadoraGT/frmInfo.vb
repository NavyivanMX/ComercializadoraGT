Public Class frmInfo
    Private Sub frmInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
    End Sub
    Public Sub Mostrar(ByVal NVentana As String, ByVal Titulo As String, ByVal Mensaje As String)
        Me.Text = NVentana
        LBLTIT.Text = Titulo
        LBLMSG.Text = Mensaje
        Me.ShowDialog()
    End Sub
End Class