Public Class frmSoluciondeDevolucion
    Dim CLASOL As New List(Of String)
    Dim CLATM As New List(Of String)
    Dim REGISTRO As String
    Dim CLAAS As New List(Of String)
    Private Sub frmSoluciondeDevolucion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGAACCION()
        CARGARSOLUCION()
        CARGARTIPOMERMA()
        ACTIVAR(True)
        LIMPIAR()
        VERLABEL(True)
        CBTM.Enabled = False
    End Sub
    Public Sub VERLABEL(ByVal T As Boolean)
        LBLNP.Visible = Not T
        LBLTI.Visible = Not T
        LBLCANT.Visible = Not T
        LBLLOTE.Visible = Not T
        LBLUNI.Visible = Not T
        LBLPROD.Visible = Not T
        LBLFEC.Visible = Not T
        LBLREG.Visible = Not T
        LBLOBS.Visible = Not T
    End Sub

    Public Sub LIMPIAR()
        CBSOL.SelectedIndex = 0
        CBTM.SelectedIndex = 0
        VERLABEL(False)
    End Sub
    Public Sub ACTIVAR(ByVal TF As Boolean)
        CBSOL.Enabled = Not TF
        CBTM.Enabled = Not TF
        BTNGUARDAR.Enabled = Not TF
        CBAS.Enabled = Not TF
    End Sub
    Private Function CARGARSOLUCION() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBSOL, CLASOL, "SELECT CLAVE,NOMBRE FROM SOLUCIONDEVOLUCION WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBSOL.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBSOL.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Function
    Private Function CARGARTIPOMERMA() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBTM, CLATM, "SELECT CLAVE,NOMBRE FROM TIPOMERMA WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBTM.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBTM.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Function
    Private Function CARGAACCION() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBAS, CLAAS, "SELECT CLAVE,NOMBRE FROM ACCIONSOLUCION WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBAS.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBAS.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Function

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub
    Private Sub GUARDAR()
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        Dim SQLGUARDAR As New SqlClient.SqlCommand
        SQLGUARDAR.Connection = frmPrincipal.CONX
        SQLGUARDAR.CommandType = CommandType.StoredProcedure
        SQLGUARDAR.CommandTimeout = 300
        SQLGUARDAR.Parameters.Add("@TM", SqlDbType.VarChar, 50).Value = CLATM(CBTM.SelectedIndex)
        SQLGUARDAR.Parameters.Add("@NP", SqlDbType.Int).Value = LBLNP.Text
        SQLGUARDAR.Parameters.Add("@ACC", SqlDbType.Int).Value = CLAAS(CBAS.SelectedIndex)
        SQLGUARDAR.Parameters.Add("@LOTE", SqlDbType.VarChar, 50).Value = LBLLOTE.Text
        SQLGUARDAR.Parameters.Add("@USU", SqlDbType.VarChar, 50).Value = frmPrincipal.Usuario
        SQLGUARDAR.Parameters.Add("@REG", SqlDbType.Int).Value = REGISTRO
        SQLGUARDAR.Parameters.Add("@SOL", SqlDbType.VarChar, 50).Value = CLASOL(CBSOL.SelectedIndex)
        SQLGUARDAR.CommandText = "AGREGASOLUCION"
        SQLGUARDAR.ExecuteNonQuery()
        SQLGUARDAR.Dispose()

        MessageBox.Show("La información ha sido guardada correctamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        CBTM.Enabled = True
        ACTIVAR(True)
        LIMPIAR()
        VERLABEL(True)
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        LIMPIAR()
        ACTIVAR(True)
        VERLABEL(True)
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT R.NOMBRECOMUN TIENDA,D.NOPEDIDO,D.LOTE,P.NOMBRE,D.CANTIDAD,U.NOMBRE UNIDAD,PD.FECHA FechaSalida, D.REGISTRO, DE.FECHARECIBIDO,DE.USUARIORECIBE   FROM DEVOLUCIONES D INNER JOIN PEDIDOS PD   ON PD.NOPEDIDO=D.NOPEDIDO INNER JOIN DETALLEPEDIDOS DE  ON DE.NOPEDIDO=PD.NOPEDIDO and de.lote=d.lote INNER JOIN TIENDAS R   ON PD.TIENDA=R.CLAVE INNER JOIN LOTES L   ON D.LOTE=L.CLAVE INNER JOIN PRODUCTOS P   ON L.PRODUCTO=P.CP  INNER JOIN UNIDADES U   ON D.UNIDAD=U.CLAVE  WHERE D.ESTADO=5", " AND P.NOMBRE", " ORDER BY P.NOMBRE", "Búsqueda de devoluciones pendientes por resolver", "Nombre del producto", "Devolucion (es)", 2, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            LBLNP.Text = frmClsBusqueda.TREG.Rows(0).Item(1)
            CARGARDATOS(frmClsBusqueda.TREG.Rows(0).Item(1), frmClsBusqueda.TREG.Rows(0).Item(2), frmClsBusqueda.TREG.Rows(0).Item(7))
        End If
    End Sub
    Public Sub CARGARDATOS(ByVal PED As Integer, ByVal LOTE As String, ByVal REG As Integer)
        REGISTRO = REG
        ACTIVAR(False)
        Dim BUSCAR3 As New SqlClient.SqlCommand("SELECT D.NOPEDIDO,R.NOMBRECOMUN,D.CANTIDAD,U.NOMBRE UNIDAD,(Select Convert(Char(15),D.FECHA,103))FECHA,D.REGISTRO,D.LOTE,P.NOMBRE,D.SOLUCION,D.TIPOMERMA,O.NOMBRE OBSERVACION  FROM DEVOLUCIONES D INNER JOIN PEDIDOS PD ON PD.NOPEDIDO=D.NOPEDIDO INNER JOIN TIENDAS R  ON PD.TIENDA=R.CLAVE INNER JOIN LOTES L  ON D.LOTE=L.CLAVE INNER JOIN PRODUCTOS P  ON L.PRODUCTO=P.CP  INNER JOIN UNIDADES U  ON D.UNIDAD=U.CLAVE INNER JOIN OBSERVACIONRECIBO O  ON D.OBSERVACION=O.CLAVE  WHERE D.NOPEDIDO=" + PED.ToString + " AND D.LOTE='" + LOTE + "' AND D.REGISTRO=" + REG.ToString, frmPrincipal.CONX)
        Dim LECTOR3 As SqlClient.SqlDataReader
        LECTOR3 = BUSCAR3.ExecuteReader
        While LECTOR3.Read
            LBLNP.Text = LECTOR3(0).ToString
            LBLTI.Text = LECTOR3(1).ToString
            LBLCANT.Text = LECTOR3(2).ToString
            LBLUNI.Text = LECTOR3(3).ToString
            LBLFEC.Text = LECTOR3(4).ToString
            LBLREG.Text = LECTOR3(5).ToString
            LBLLOTE.Text = LECTOR3(6).ToString
            LBLPROD.Text = LECTOR3(7).ToString
            CARGASOL(LECTOR3(8))
            CARGATM(LECTOR3(9))
            LBLOBS.Text = LECTOR3(10).ToString
        End While
        VERLABEL(False)
        LECTOR3.Close()
    End Sub
    Private Sub CARGASOL(ByVal NHOR As String)
        Dim X As Integer
        X = CBSOL.Items.Count
        For X = 0 To CLASOL.Count - 1
            If NHOR = CLASOL(X) Then
                CBSOL.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
    Private Sub CARGATM(ByVal NHOR As String)
        Dim X As Integer
        For X = 0 To CLATM.Count - 1
            If NHOR = CLATM(X) Then
                CBTM.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
End Class