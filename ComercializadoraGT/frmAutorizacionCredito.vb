Public Class frmAutorizacionCredito
    Dim nivel As Integer
    Dim LANOTA As Integer
    Public USU As String
    Public CLI As String

    Private Sub frmAutorizacionCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Private Sub VALIDAR()
        If Not frmPrincipal.CHECACONX Then

        End If
        Dim SQLUSER As New SqlClient.SqlCommand("SELECT USUARIO,NIVEL FROM USUARIOS WHERE USUARIO='" + TXTUSER.Text + "' AND PASSWORD='" + TXTPWD.Text + "' AND TIENDA='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
        Dim LECUSER As SqlClient.SqlDataReader
        LECUSER = SQLUSER.ExecuteReader
        If frmPrincipal.CONX.State = ConnectionState.Closed Or frmPrincipal.CONX.State = ConnectionState.Broken Then
            Try
                frmPrincipal.CONX.Open()
            Catch ex As Exception
                MessageBox.Show("La conexión NO esta realizada, la información no se ha procesado, intente en un momento por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        If LECUSER.Read() Then
            USU = LECUSER(0)
            nivel = LECUSER(1)
            LECUSER.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Yes
            LIMPIAR()
            frmPrincipal.MenuStrip1.Focus()
        Else
            MessageBox.Show("Nombre de usuario y contraseña NO encontrados favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            LECUSER.Close()
            LIMPIAR()
        End If
        If nivel <= 5 Then
            MessageBox.Show("El usuario no es administrador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            LIMPIAR()
            Exit Sub
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Yes
            LIMPIAR()
            Me.Close()
        End If
    End Sub
    Private Sub LIMPIAR()
        TXTUSER.Text = ""
        TXTPWD.Text = ""
        TXTUSER.Focus()
    End Sub
    Public Sub mostrar(ByVal usu As String, ByVal NV As String)
        CLI = usu
        Me.Text = NV
        Me.ShowDialog()
    End Sub
    'Private Sub GUARDAR()
    '    Dim TOT As Double
    '    TOT = frmNotaDeVenta.TXTTOT.Text

    '    If Not frmPrincipal.CHECACONX() Then
    '        Exit Sub
    '    End If

    '    LANOTA = frmCredito.CARGANOTA()
    '    Dim SQLGUARDA1 As New SqlClient.SqlCommand("INSERT INTO NOTASDEVENTACREDITO(TIENDA,CLIENTE,NOTA,TOTAL,ESTADO,NOCAJA,CAJERA,FECHA,PAGADO,AUTORIZO) VALUES (@TI,@CLI,@NOTA,@TOT,@EDO,@NOCAJA,@EMP,GETDATE(),0,@USU)", frmPrincipal.CONX)
    '    SQLGUARDA1.CommandTimeout = 300
    '    SQLGUARDA1.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
    '    SQLGUARDA1.Parameters.Add("@CLI", SqlDbType.VarChar).Value = CLI
    '    SQLGUARDA1.Parameters.Add("@NOTA", SqlDbType.Int).Value = LANOTA
    '    SQLGUARDA1.Parameters.Add("@TOT", SqlDbType.Float).Value = CType(frmNotaDeVenta.TXTTOT.Text, Double)
    '    SQLGUARDA1.Parameters.Add("@EMP", SqlDbType.Int).Value = frmNotaDeVenta.NE
    '    SQLGUARDA1.Parameters.Add("@EDO", SqlDbType.Int).Value = 1
    '    SQLGUARDA1.Parameters.Add("@NOCAJA", SqlDbType.Int).Value = frmEntrarCaja.NOCAJA
    '    SQLGUARDA1.Parameters.Add("@USU", SqlDbType.VarChar).Value = USU


    '    SQLGUARDA1.CommandTimeout = 300
    '    SQLGUARDA1.ExecuteNonQuery()
    '    SQLGUARDA1.Dispose()
    '    'TXTNOTA.Text = LANOTA.ToString



    '    Dim SQLDETALLES As New SqlClient.SqlCommand("INSERT INTO DETALLENOTASDEVENTACREDITO(TIENDA,NOTA,PRODUCTO,CANTIDAD,TOTAL,REGISTRO,DESCUENTO) VALUES (@TI,@NOTA,@PROD,@CANT,@TOT,@REG,@DES)", frmPrincipal.CONX)
    '    SQLDETALLES.CommandTimeout = 300
    '    SQLDETALLES.Parameters.Add("@TI", SqlDbType.VarChar)
    '    SQLDETALLES.Parameters.Add("@NOTA", SqlDbType.VarChar)
    '    SQLDETALLES.Parameters.Add("@PROD", SqlDbType.VarChar)
    '    SQLDETALLES.Parameters.Add("@CANT", SqlDbType.Float)
    '    SQLDETALLES.Parameters.Add("@TOT", SqlDbType.Float)
    '    SQLDETALLES.Parameters.Add("@DES", SqlDbType.Float)
    '    SQLDETALLES.Parameters.Add("@REG", SqlDbType.VarChar)
    '    SQLDETALLES.CommandTimeout = 300
    '    SQLDETALLES.Parameters("@TI").Value = frmPrincipal.SucursalBase
    '    SQLDETALLES.Parameters("@NOTA").Value = LANOTA
    '    Dim X As Integer
    '    For X = 0 To frmNotaDeVenta.DGV.Rows.Count - 1
    '        SQLDETALLES.Parameters("@PROD").Value = frmNotaDeVenta.DGV.Item(0, X).Value
    '        SQLDETALLES.Parameters("@CANT").Value = frmNotaDeVenta.DGV.Item(2, X).Value
    '        SQLDETALLES.Parameters("@TOT").Value = frmNotaDeVenta.DGV.Item(5, X).Value
    '        SQLDETALLES.Parameters("@DES").Value = frmNotaDeVenta.DGV.Item(3, X).Value
    '        SQLDETALLES.Parameters("@REG").Value = X
    '        SQLDETALLES.ExecuteNonQuery()
    '    Next
    '    SQLDETALLES.Dispose()



    '    Dim total, CRED As Double
    '    total = CType(frmNotaDeVenta.TXTTOT.Text, Double)
    '    Dim SQLCRE As New SqlClient.SqlCommand("SELECT CREDITO FROM CLIENTES WHERE CLAVE='" + CLI + "' AND TIENDA='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
    '    Dim LECCRE As SqlClient.SqlDataReader
    '    LECCRE = SQLCRE.ExecuteReader

    '    If LECCRE.Read Then
    '        CRED = LECCRE(0)
    '    End If
    '    LECCRE.Close()


    '    Dim QUERY As String
    '    If CRED > total Then
    '        QUERY = "UPDATE CLIENTES SET CREDITO=CREDITO-" + total.ToString + ",ADEUDO=ADEUDO+" + total.ToString + " WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE=" + CLI + " "
    '    Else
    '        QUERY = "UPDATE CLIENTES SET CREDITO=0,ADEUDO=ADEUDO+" + total.ToString + " WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE=" + CLI + " "
    '    End If
    '    Dim SQLCLI As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
    '    SQLCLI.CommandTimeout = 300
    '    SQLCLI.ExecuteNonQuery()
    '    SQLCLI.Dispose()


    '    frmPrincipal.CI.Abrir()
    '    frmCredito.IMPRIMIRNOTA(LANOTA)

    '    frmPrincipal.PRE.EliminarNota()
    '    frmNotaDeVenta.DGV.Refresh()
    '    frmNotaDeVenta.TXTCOD.Clear()
    '    frmNotaDeVenta.LBLPRE.Text = "0"
    '    frmNotaDeVenta.LBLEXIS.Text = "0"
    '    frmNotaDeVenta.TXTCANT.Text = "1"
    '    frmNotaDeVenta.LBLP.Text = "0"
    '    frmNotaDeVenta.CHECAPRODUCTOS()
    '    frmNotaDeVenta.TXTEFECTIVO.Text = "0"
    '    frmNotaDeVenta.TXTCOD.Focus()
    '    frmNotaDeVenta.CBTP.SelectedIndex = 0
    '    frmNotaDeVenta.TXTDESC.Text = 0
    '    frmCredito.Close()
    '    LIMPIAR()
    '    Me.Close()
    'End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        VALIDAR()
    End Sub

    Private Sub TXTUSER_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTUSER.KeyPress, TXTPWD.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        LIMPIAR()
        Me.Close()
    End Sub
End Class