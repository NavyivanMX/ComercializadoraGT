Public Class frmDeshabilitaUsuario
    Dim CLAUSU As New List(Of String)
    Dim CLAACT As New List(Of String)
    Private Sub frmDeshabilitaUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        ACTIVAR(True)
        LIMPIAR()
        If Not OPLlenaComboBox(CBUSU, CLAUSU, CLAACT, "SELECT NIVEL,ACTIVO,USUARIO FROM USUARIOS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' ORDER BY USUARIO", frmPrincipal.CadenaConexion) Then
            MessageBox.Show("No hay usuarios registrados en esta sucursal, favor de dar de alta usuarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
    End Sub
    Private Function ACTIVAR(ByVal V) As Boolean
        CBUSU.Enabled = V
        CBATC.Enabled = Not V
        BTNGUARDAR.Enabled = Not V
    End Function
    Private Sub LIMPIAR()
        CBATC.SelectedIndex = 0
        CBATC.SelectedIndex = 0
        LBLNIV.Text = 0
    End Sub
    Private Sub CBUSU_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBUSU.KeyPress
        If e.KeyChar = Chr(13) Then
            'CARGADATOS()
            e.Handled = True
            SendKeys.Send("{TAB}")
            If CLAUSU(CBUSU.SelectedIndex) = 1 Then
                LBLNIV.Text = "Normal"
            ElseIf CLAUSU(CBUSU.SelectedIndex) = 5 Then
                LBLNIV.Text = "Administrador"
            ElseIf CLAUSU(CBUSU.SelectedIndex) = 10 Then
                LBLNIV.Text = "Super administrador"
            End If

            If CType(CLAACT(CBUSU.SelectedIndex), Boolean) Then
                CBATC.SelectedIndex = 0
            Else
                CBATC.SelectedIndex = 1
            End If
            ACTIVAR(False)
        End If
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
        LIMPIAR()
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If

        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim QUERY As String
        If CBATC.SelectedIndex = 0 Then
            QUERY = "UPDATE USUARIOS SET ACTIVO=1 WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND USUARIO='" + CBUSU.Text + "'"
        Else
            QUERY = "UPDATE USUARIOS SET ACTIVO=0 WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND USUARIO='" + CBUSU.Text + "'"
        End If
        Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
        MessageBox.Show("La informacion ha sido guardada exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        ACTIVAR(True)
        LIMPIAR()
    End Sub
End Class