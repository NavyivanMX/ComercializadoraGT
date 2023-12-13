Public Class frmBorraPedido
    Private Sub BTNACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNACEPTAR.Click
        If TXTPED.Text = "" Then
        Else
            Dim XYZ As Short
            XYZ = MessageBox.Show("¿Esta seguro que desea BORRAR el pedido?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If XYZ <> 6 Then
                Exit Sub
            End If
            Try
                frmPrincipal.CHECACONX()

                Dim SQLBORRA As New SqlClient.SqlCommand("DELETE FROM PEDIDOS WHERE NOPEDIDO=" + TXTPED.Text + " ", frmPrincipal.CONX)
                SQLBORRA.ExecuteNonQuery()
                SQLBORRA.CommandText = "delete from faltantepedidos where nopedido =" + TXTPED.Text + " "
                SQLBORRA.ExecuteNonQuery()
                MessageBox.Show("El pedido " + TXTPED.Text + " ha sido eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub TXTPED_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPED.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            BTNACEPTAR.Focus()
        End If
    End Sub

    Private Sub frmBorraPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
End Class