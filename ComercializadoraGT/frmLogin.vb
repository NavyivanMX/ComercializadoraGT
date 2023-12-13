Public Class frmLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        Try
            If frmPrincipal.CONX.State = ConnectionState.Closed Or frmPrincipal.CONX.State = ConnectionState.Broken Then
                frmPrincipal.CONX.Open()
            End If
            PasswordLabel.Text = "Contraseña"
            TXTUSER.Text = My.Settings.usuario
            TXTPWD.Text = My.Settings.contrasena
        Catch ex As Exception

        End Try
    End Sub

    Private Sub VALIDAR()
        frmPrincipal.AplicaBodega = False
        Dim SQLUSER As New SqlClient.SqlCommand("SELECT U.TIENDA,U.NIVEL,S.NOMBREFISCAL,S.NOMBRECOMUN,S.CIUDAD,S.CAJAS,S.CORTEX,S.EMPRESA,S.PAGOTARJETA,U.activo,U.BODEGA,S.DIRECCION+' '+S.CIUDAD,U.PERFIL,S.REGIMEN FROM USUARIOS U INNER JOIN TIENDAS S  ON U.TIENDA=S.CLAVE  WHERE U.USUARIO='" + TXTUSER.Text + "' AND U.PASSWORD='" + TXTPWD.Text + "'", frmPrincipal.CONX)
        Dim LECUSER As SqlClient.SqlDataReader
        LECUSER = SQLUSER.ExecuteReader
        If frmPrincipal.CONX.State = ConnectionState.Closed Or frmPrincipal.CONX.State = ConnectionState.Broken Then
            Try
                frmPrincipal.CONX.Open()
            Catch ex As Exception
                MessageBox.Show("La Conexin NO esta realizada, La Informacion No se ha Guardado, Intente en un momento por Favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        If LECUSER.Read() Then
            If CType(LECUSER(9), Boolean) = False Then
                MessageBox.Show("El usuario no puede acceder al sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                LECUSER.Close()
                Exit Sub
            End If
            frmPrincipal.SucursalBase = LECUSER(0)
            frmPrincipal.NivelBase = LECUSER(1)
            frmPrincipal.NombreSucursal = LECUSER(2)
            frmPrincipal.NombreComun = LECUSER(3)
            frmPrincipal.Ciudad = LECUSER(4)
            frmPrincipal.Usuario = TXTUSER.Text
            frmPrincipal.Empresa = LECUSER(7)
            frmPrincipal.NumCajas = LECUSER(5)
            If LECUSER(6) = 0 Then
                frmPrincipal.CorteXX = False
            Else
                frmPrincipal.CorteXX = True
            End If
            frmPrincipal.PagoTarjeta = LECUSER(7)
            frmPrincipal.AplicaBodega = LECUSER(10)
            frmPrincipal.Direccion = LECUSER(11)
            frmPrincipal.Perfil = LECUSER(12)
            frmPrincipal.Regimen = LECUSER(13)
            LECUSER.Close()
            My.Settings.usuario = TXTUSER.Text
            My.Settings.contrasena = ""
            My.Settings.Save()
            My.Settings.Reload()
            Me.DialogResult = Windows.Forms.DialogResult.Yes
            frmPrincipal.MenuStrip1.Focus()
        Else
            MessageBox.Show("Nombre de Usuario y Contraseña NO encontrados favor de Verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            LECUSER.Close()
        End If
    End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        VALIDAR()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Dim xyz As Short
        xyz = MessageBox.Show("Deseas realmente Salir del Sistema?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If xyz <> 6 Then
            Exit Sub
        Else
            Me.DialogResult = Windows.Forms.DialogResult.No
        End If
    End Sub

    Private Sub TXTUSER_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTUSER.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTPWD.Focus()
        End If
    End Sub

    Private Sub TXTPWD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPWD.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTUSER.Text = "" Or TXTPWD.Text = "" Then
            Else
                VALIDAR()
            End If
        End If
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        System.Diagnostics.Process.Start("osk")
    End Sub
End Class
