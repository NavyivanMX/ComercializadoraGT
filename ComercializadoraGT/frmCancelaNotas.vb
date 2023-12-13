Public Class frmCancelaNotas
    Dim CAJA, CAJERA, CLIENTE As Integer
    Dim Z As Integer
    Private Sub frmCancelaNotas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        TXTNOTA.SelectAll()
        TXTNOTA.Focus()
        ACTIVAR(True)
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTNOTA.Enabled = V
        BTNELIMINAR.Enabled = Not V
        TXTOBS.Enabled = Not V
        If V Then
            TXTNOTA.Focus()
        Else
            TXTOBS.Focus()
        End If
    End Sub
    Private Sub CHECATABLA()
        If DGV.Rows.Count = 0 Then
           
            TXTTOT.Text = 0
        Else
            Dim X As Integer
            Dim TOTAL As Double
            TOTAL = 0
            For X = 0 To DGV.Rows.Count - 1
                TOTAL = TOTAL + DGV.Item(4, X).Value
            Next
            TXTTOT.Text = FormatNumber(TOTAL).ToString()
         
        End If
    End Sub
    Private Sub CARGANOTA()
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim QUERY As String
        QUERY = "SELECT E.NOMBRE EMPLEADO,N.FECHA,NOCAJA,N.CAJERA,C.NOMBRE,C.CLAVE FROM NOTASDEVENTA N INNER JOIN EMPLEADOS E  ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE  INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA=" + TXTNOTA.Text
        Dim SQLEMP As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLEMP.ExecuteReader
        Dim FEC As DateTime
        If LECTOR.Read Then
            LBLEMP.Text = LECTOR(0)
            FEC = CType(LECTOR(1), DateTime)
            CAJA = LECTOR(2)
            CAJERA = LECTOR(3)
            LBLCLI.Text = LECTOR(4)
            CLIENTE = LECTOR(5)
            LECTOR.Close()
            If FEC.Date <> Now.Date Then
                MessageBox.Show("La nota que intenta eliminar no coincide con la fecha actual, NO se permite modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            Else
                'Dim SQL As New SqlClient.SqlCommand("SELECT FECHAZ FROM CORTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + CAJA.ToString, frmPrincipal.CONX)
                'Dim LEC As SqlClient.SqlDataReader
                'LEC = SQL.ExecuteReader
                'If LEC.Read Then
                '    FEC2 = LEC(0)
                'End If
                'LEC.Close()
                'If FEC2 > FEC Then
                '    MessageBox.Show("La nota ha sido incluida en un corten no se permite eliminar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Exit Sub
                'End If
                TXTOBS.Focus()
            End If
        Else
            MessageBox.Show("No se encontr el numero de nota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            LECTOR.Close()
            Exit Sub
        End If
        Dim DA As New SqlClient.SqlDataAdapter("SELECT D.PRODUCTO CLAVE,P.NOMBRE,D.CANTIDAD,P.PRECIO,D.TOTAL FROM DETALLENOTASDEVENTA D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + TXTNOTA.Text, frmPrincipal.CONX)
        Dim DT As New DataTable
        DA.Fill(DT)
        DGV.DataSource = DT
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ACTIVAR(False)
        CHECATABLA()
    End Sub

   

    Private Sub TXTNOTA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOTA.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            If TXTNOTA.Text = "" Then
            Else
                CARGANOTA()

            End If
        End If
    End Sub

    Dim LPLATILLOS As New List(Of Integer)
    Private Sub BTNCANCELAR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        DGV.DataSource = Nothing
        CHECATABLA()
        ACTIVAR(True)
    End Sub

    Private Sub BTNELIMINAR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        If String.IsNullOrEmpty(TXTOBS.Text) Then
            MessageBox.Show("Debe especificar una observación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TXTOBS.Focus()
            Exit Sub
        End If
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim TOT As Double
        TOT = CType(TXTTOT.Text, Double)

        Dim SQL As New SqlClient.SqlCommand
        SQL.Connection = frmPrincipal.CONX
        SQL.CommandType = CommandType.StoredProcedure
        SQL.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQL.Parameters.Add("@NOT", SqlDbType.Int).Value = TXTNOTA.Text.ToString
        SQL.Parameters.Add("@TOT", SqlDbType.Float).Value = TOT.ToString
        SQL.Parameters.Add("@CAJA", SqlDbType.Int).Value = CAJA.ToString
        SQL.Parameters.Add("@CAJE", SqlDbType.Int).Value = CAJERA.ToString
        SQL.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        SQL.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TXTOBS.Text.ToString
        SQL.Parameters.Add("@CLI", SqlDbType.Int).Value = CLIENTE.ToString

        SQL.CommandText = "SPNOTASCANCELADAS"
        SQL.ExecuteNonQuery()

        MessageBox.Show("La nota ha sido eliminada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        DGV.DataSource = Nothing
        CHECATABLA()
        ACTIVAR(True)
    End Sub

  
End Class