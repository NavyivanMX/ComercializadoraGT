Public Class frmConfiguracion

    Private Sub frmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        TXTCOPIAS.Text = My.Settings.CopiasContado.ToString
        TXTCA.Text = My.Settings.copiasabono.ToString
        TXTCVC.Text = My.Settings.copiascredito.ToString
        CHKPIV.Checked = My.Settings.preguntarimpresionventa
        CHKMB.Checked = My.Settings.mostrarbusqueda
        CHKICC.Checked = My.Settings.ImpresionCopiaCredito
        TXTRES.Text = My.Settings.Resguardo.ToString
        TXTSA.Text = My.Settings.ServicioAdicional.ToString
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.CopiasContado = TXTCOPIAS.Text
        My.Settings.CopiasAbono = TXTCA.Text
        My.Settings.CopiasCredito = TXTCVC.Text
        My.Settings.preguntarimpresionventa = CHKPIV.Checked
        My.Settings.mostrarbusqueda = CHKMB.Checked
        My.Settings.ImpresionCopiaCredito = CHKICC.Checked
        My.Settings.Resguardo = TXTRES.Text
        My.Settings.ServicioAdicional = TXTSA.Text
        My.Settings.Save()
        My.Settings.Reload()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub CHKPIV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKPIV.CheckedChanged

    End Sub
End Class