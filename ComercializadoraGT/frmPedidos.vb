Public Class frmPedidos
    Dim NOMOV As Integer
    Dim DT As New DataTable
    Dim X As Integer
    Dim LISTTP As New List(Of String)
    Dim CLAPRO As New List(Of String)
    Dim CLAPROD As New List(Of String)
    Dim CLAGRU As New List(Of String)
    Dim CLASUC As New List(Of String)
    Dim CLAUNI As New List(Of String)
    Dim CLACP As New List(Of String)
    Dim LGRU As New List(Of String)
    Dim LPRO As New List(Of String)
    Dim LUNI As New List(Of String)
    Dim VGUARDAR As Boolean
    Dim DTP As New DataTable
    Dim DV As New DataView
    Dim DV2 As New DataView
    Dim DT2 As New DataTable
    Dim SOLICITADO, EXISTENCIA, AGREGADO, CANTLOTE As Double
    Dim UNIDAD, UNIC As String
    Dim LDES As New List(Of String)
    Private Sub frmPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGATIPOPEDIDO()
        CARGANOPEDIDO()


        DT.Columns.Add("Grupo")
        DT.Columns.Add("Producto")
        DT.Columns.Add("Cantidad")
        DT.Columns.Add("Unidad")
        DT.Columns.Add("Descripción")
        Dim DA As New SqlClient.SqlDataAdapter("SELECT CLAVE,NOMBRE,UVENTA,DESCRIPCION,GRUPO,CP FROM PRODUCTOS WHERE EMPRESA=" + frmPrincipal.Empresa + "", frmPrincipal.CONX)
        DTP.Clear()
        DA.Fill(DTP)
        Dim DA2 As New SqlClient.SqlDataAdapter("SELECT E.PRODUCTO,E.UNIDAD,U.NOMBRE FROM EQUIVALENCIAS E INNER JOIN PRODUCTOS P ON E.UNIDAD2=P.UVENTA AND P.CP=E.PRODUCTO INNER JOIN UNIDADES U ON E.UNIDAD=U.CLAVE WHERE E.EMPRESA=" + frmPrincipal.Empresa + "", frmPrincipal.CONX)
        DT2.Clear()
        DA2.Fill(DT2)

        If CARGAGRUPOS() Then
            MessageBox.Show("Favor de agregar grupos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.Close()
        End If

        LGRU.Clear()
        LPRO.Clear()
        LUNI.Clear()

        CHECATABLA()
        TXTCLA.Text = ""
        TXTCLA.Focus()
    End Sub
    Private Function CARGATIPOPEDIDO() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        Dim LEIDO As Boolean
        LEIDO = False
        OPLlenaComboBox(CBTP, LISTTP, "SELECT CLAVE,NOMBRE FROM TiposPedidos WHERE ACTIVO=1  ORDER BY CLAVE", frmPrincipal.CadenaConexion)
        If CBGRU.Items.Count > 0 Then
            LEIDO = True
        End If
        Try
            CBTP.SelectedIndex = 0
        Catch ex As Exception

        End Try
       
    End Function
  
    Private Function CARGANOPEDIDO() As Integer
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        Dim NUM As Integer
        Dim SQLMOV As New SqlClient.SqlCommand("SELECT DBO.SIGUIENTEPEDIDO()", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLMOV.ExecuteReader
        If LECTOR.Read Then
            NUM = LECTOR(0)
            LECTOR.Close()
            LBLPED.Text = NUM
        Else
            LECTOR.Close()
        End If
    End Function
    Private Function CARGAGRUPOS() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBGRU, CLAGRU, "SELECT CLAVE,NOMBRE FROM GRUPOS WHERE ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + "  ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBGRU.Items.Count > 0 Then
            LEIDO = True
        End If


        Try
            CBGRU.SelectedIndex = 0
        Catch ex As Exception

        End Try

       

    End Function
    Private Sub CHECATABLA()
        If DGV.Rows.Count = 0 Then
            BTNQUITAR.Enabled = False
            BTNELIMINAR.Enabled = False
            BTNGUARDAR.Enabled = False
            ''CBMOV.Enabled = True
            'DGV.CaptionText = "Elementos"
        Else
            BTNGUARDAR.Enabled = True
            BTNQUITAR.Enabled = True
            BTNELIMINAR.Enabled = True
            'LBLCUANTOS.Text = TABLAPRIN.Rows.Count
        End If
        'Dim X As Integer
        'Dim TOT As Double
        ''Dim PZAS As Double
        'For X = 0 To DGV.Rows.Count - 1
        '    TOT = TOT + CType(DGV.Item(7, X).Value, Double)
        '    'PZAS = PZAS + CType(DGV.Item(2, X).Value, Double)
        'Next
        LBLCUANTOS.Text = "Total de articulos agregados= " + DGV.Rows.Count.ToString
    End Sub

    Private Function CARGADATAVIEW(ByVal GRUPO As String) As Boolean
        DV = New DataView(DTP, "GRUPO='" + GRUPO + "'", "NOMBRE", DataViewRowState.CurrentRows)
        Return CARGAPRODUCTOS()
    End Function
    Private Function CARGADATAVIEW2(ByVal PRO As String) As Boolean
        DV2 = New DataView(DT2, "PRODUCTO='" + PRO + "'", "NOMBRE", DataViewRowState.CurrentRows)
        Return CARGAEQUIVALENCIAS()
    End Function
    Private Function CARGAPRODUCTOS() As Boolean
        CBPROD.Items.Clear()
        CLAPROD.Clear()
        CLACP.Clear()
        'CLAGRU.Clear()
        LDES.Clear()
        Dim X As Integer
        Dim DRV As DataRowView
        For X = 0 To DV.Count - 1
            DRV = DV.Item(X)
            CBPROD.Items.Add(DRV.Item(1))
            CLAPROD.Add(DRV.Item(0))
            LDES.Add(DRV.Item(3))
            CLACP.Add(DRV.Item(5))
        Next

        Try
            CBPROD.SelectedIndex = 0
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
    Private Function CARGAEQUIVALENCIAS() As Boolean
        CLAUNI.Clear()
        CBUNI.Items.Clear()
        Dim X As Integer
        Dim DRV As DataRowView
        For X = 0 To DV2.Count - 1
            DRV = DV2.Item(X)
            CBUNI.Items.Add(DRV.Item(2))
            CLAUNI.Add(DRV.Item(1))
        Next
        Try
            CBUNI.SelectedIndex = 0
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTCANT.Enabled = V
        CBUNI.Enabled = V
        BTNAGREGAR.Enabled = V
    End Sub
    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged
        If Not CARGADATAVIEW(CLAGRU(CBGRU.SelectedIndex)) Then
            MessageBox.Show("No se encuentra asignado ningún producto en este grupo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            CBPROD.Enabled = False
            ACTIVAR(False)
        Else
            CBPROD.Enabled = True
            If Not CARGADATAVIEW2(CLACP(CBPROD.SelectedIndex)) Then
                MessageBox.Show("No se encuentra asignado ninguna equivalencia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ACTIVAR(False)
            Else
                ACTIVAR(True)
            End If
        End If
    End Sub

    Private Sub CBPROD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBPROD.SelectedIndexChanged
        LBLDES.Text = LDES(CBPROD.SelectedIndex)
        If Not CARGADATAVIEW2(CLACP(CBPROD.SelectedIndex)) Then
            MessageBox.Show("No se encuentra asignado ninguna equivalencia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ACTIVAR(False)
        Else
            ACTIVAR(True)
        End If
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub CARGAELGRUPO(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CLAGRU.Count - 1
            If CLAGRU(X) = CLA Then
                CBGRU.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
    Private Sub CARGAELPRODUCTO(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CLAPROD.Count - 1
            If CLAPROD(X) = CLA Then
                CBPROD.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub

    
    Private Sub AGREGAR(ByVal GRUPO As String, ByVal NGRU As String, ByVal PRO As String, ByVal NPRO As String, ByVal CANT As Double, ByVal UNI As String, ByVal DES As String)
        Dim DOW As System.Data.DataRow = DT.NewRow
        DOW(0) = NGRU
        DOW(1) = NPRO
        DOW(2) = CANT
        DOW(3) = UNI
        DOW(4) = DES
        DT.Rows.Add(DOW)
        LGRU.Add(GRUPO)
        LPRO.Add(PRO)
        LUNI.Add(CLAUNI(CBUNI.SelectedIndex))

        DGV.DataSource = DT
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Refresh()

        CHECATABLA()
        TXTCLA.Text = ""
        TXTCLA.Focus()
    End Sub

    
    Private Sub REGRESARUNO(ByVal GRU As String, ByVal PRO As String, ByVal CANT As Double, ByVal UNI As String)
        Dim X As Integer
        For X = 0 To CBGRU.Items.Count - 1
            If CBGRU.Items(X) = GRU Then
                CBGRU.SelectedIndex = X
            End If
        Next
        For X = 0 To CBPROD.Items.Count - 1
            If CBPROD.Items(X) = PRO Then
                CBPROD.SelectedIndex = X
            End If
        Next
        TXTCANT.Text = CANT.ToString
        For X = 0 To CBUNI.Items.Count - 1
            If CBUNI.Items(X) = UNI Then
                CBUNI.SelectedIndex = X
            End If
        Next
    End Sub
    Private Sub GUARDAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        CARGANOPEDIDO()
        Dim NP As Integer
        NP = LBLPED.Text

        Dim SQLD As New SqlClient.SqlCommand("INSERT INTO DETALLEPEDIDOSTIENDAS (NOPEDIDO,PRODUCTO,CANTIDAD,UNIDAD,REGISTRO)VALUES(@NP,@PRO,@CANT,@UNI,@REG)", frmPrincipal.CONX)
        SQLD.CommandTimeout = 300
        SQLD.Parameters.Add("@NP", SqlDbType.Int)
        SQLD.Parameters.Add("@PRO", SqlDbType.VarChar)
        SQLD.Parameters.Add("@CANT", SqlDbType.Float)
        SQLD.Parameters.Add("@UNI", SqlDbType.VarChar)
        SQLD.Parameters.Add("@REG", SqlDbType.Int)

        Dim INDD, INDF As Integer
        INDD = 0
        INDF = 0
        Dim TOTP As Double
        TOTP = 0
        SQLD.Parameters("@NP").Value = NP
       
        For X = 0 To DGV.Rows.Count - 1
            SQLD.Parameters("@PRO").Value = LPRO(X)
            SQLD.Parameters("@CANT").Value = DGV.Item(2, X).Value
            SQLD.Parameters("@UNI").Value = LUNI(X)
            SQLD.Parameters("@REG").Value = X
            SQLD.ExecuteNonQuery()
        Next
        SQLD.Dispose()

        Dim SQL As New SqlClient.SqlCommand("INSERT INTO PEDIDOSTIENDAS (NOPEDIDO,TIENDA,TIPOPEDIDO,ESTADO,FECHA,USUARIO) VALUES (@NP,@RES,@TP,0,GETDATE(),@USU)", frmPrincipal.CONX)
        SQL.CommandTimeout = 300
        SQL.Parameters.Add("@NP", SqlDbType.Int)
        SQL.Parameters.Add("@RES", SqlDbType.VarChar)
        SQL.Parameters.Add("@TP", SqlDbType.Int)
        SQL.Parameters.Add("@USU", SqlDbType.VarChar)

        SQL.Parameters("@NP").Value = NP
        SQL.Parameters("@RES").Value = frmPrincipal.SucursalBase
        SQL.Parameters("@TP").Value = LISTTP(CBTP.SelectedIndex)
        SQL.Parameters("@USU").Value = frmPrincipal.Usuario
        SQL.ExecuteNonQuery()
        SQL.Dispose()

        DT.Clear()
        DT.Rows.Clear()
        LGRU.Clear()
        LPRO.Clear()
        LUNI.Clear()
        DGV.Refresh()

        Dim SQLGUARDAR As New SqlClient.SqlCommand
        SQLGUARDAR.Connection = frmPrincipal.CONX
        SQLGUARDAR.CommandType = CommandType.StoredProcedure
        SQLGUARDAR.Parameters.Add("@PED", SqlDbType.Int).Value = NP
        SQLGUARDAR.CommandText = "DIVIDEPEDIDO"
        SQLGUARDAR.ExecuteNonQuery()

        Dim query As String
        query = "SELECT  N.NOPEDIDO,R.NOMBRECOMUN TIENDA,T.NOMBRE  TIPOPEDIDO,P.NOMBRE,P.DESCRIPCION, D.CANTIDAD, U.NOMBRE  UNIDAD, A.NOMBRE SUBGRUPO FROM PEDIDOSTIENDAS  N INNER JOIN TIENDAS R  ON N.TIENDA = R.CLAVE INNER JOIN TIPOSPEDIDOS  T  ON N.TIPOPEDIDO = T.CLAVE INNER JOIN DETALLEPEDIDOSTIENDAS  D  ON N.NOPEDIDO = D.NOPEDIDO INNER JOIN PRODUCTOS  P  ON D.PRODUCTO = P.CP INNER JOIN UNIDADES  U  ON D.UNIDAD = U.CLAVE INNER JOIN SUBGRUPOS  A  ON P.SUBGRUPO = A.CLAVE WHERE N.NOPEDIDO=" + NP.ToString + " "
        Dim REPO As New rptOrdenTrabajo
        GUARDARREPORTE(REPO, BDLlenatabla(query, frmPrincipal.CadenaConexion), CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "Acrobat Reader", "pdf", "¿Desea Guardar el Documento?", "Pedido " + LBLPED.Text + "", "Enviar One Note 2007")
        'frmReportes.IMPRIMIR13(REPO, "Pedido de:  " + frmPrincipal.SucursalBase, "SELECT N.NOPEDIDO,R.NOMBRE RESTAURANTE,T.NOMBRE TIPOPEDIDO,P.NOMBRE,P.DESCRIPCION,D.CANTIDAD,U.NOMBRE UNIDAD,A.NOMBRE AREASURTIDO FROM PEDIDOSRESTAURANTES N INNER JOIN CLIENTESCOMPRAS R ON N.RESTAURANTE=R.CLAVE INNER JOIN TIPOSPEDIDOS T ON N.TIPOPEDIDO=T.CLAVE INNER JOIN DETALLEPEDIDOSRESTAURANTES D ON N.NOPEDIDO=D.NOPEDIDO INNER JOIN PRODUCTOS P ON D.GRUPO=P.GRUPO AND D.PRODUCTO=P.CLAVE INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN AREASURTIDO A ON P.AREAIMPRESION=A.CLAVE WHERE N.NOPEDIDO=" + LBLPED.Text + " ORDER BY A.NOMBRE,P.NOMBRE", CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "Acrobat Reader", "pdf", "Pedido " + LBLPED.Text, "")
        CARGANOPEDIDO()
    End Sub


    Private Sub BTNBUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de productos", "Nombre del producto", "Productos(s)", 3, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(1))
            CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
            TXTCANT.Focus()
            TXTCANT.SelectAll()
        End If
    End Sub
    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        If TXTCANT.Text = "" Or TXTCANT.Text = 0 Then
            MessageBox.Show("Especifique una cantidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TXTCANT.Focus()
            TXTCANT.SelectAll()
            Exit Sub
        End If

        AGREGAR(CLAGRU(CBGRU.SelectedIndex), CBGRU.Text, CLACP(CBPROD.SelectedIndex), CBPROD.Text, CType(TXTCANT.Text, Double), CBUNI.Text, LBLDES.Text)

        CHECATABLA()
    End Sub
    Private Sub QUITAR()
        LGRU.RemoveAt(DGV.CurrentRow.Index)
        LPRO.RemoveAt(DGV.CurrentRow.Index)
        LUNI.RemoveAt(DGV.CurrentRow.Index)

        REGRESARUNO(DGV.Item(0, DGV.CurrentRow.Index).Value, DGV.Item(1, DGV.CurrentRow.Index).Value, DGV.Item(2, DGV.CurrentRow.Index).Value, DGV.Item(3, DGV.CurrentRow.Index).Value)

        DT.Rows.RemoveAt(DGV.CurrentRow.Index)
        DGV.DataSource = DT
        DGV.Refresh()

        CHECATABLA()
        TXTCANT.Focus()
        TXTCANT.SelectAll()
    End Sub
    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        QUITAR()
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Esta seguro que desea eliminar TODOS los elementos agregados?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If xyz = 6 Then
            LGRU.Clear()
            LPRO.Clear()
            LUNI.Clear()
            DT.Rows.Clear()
            DGV.Refresh()
            CHECATABLA()
        End If
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
        CHECATABLA()
    End Sub
    Dim CLAPRODC As New List(Of String)
    Dim CLAGRUC As New List(Of String)
    Private Function CHECAPROD() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        CLAPRODC.Clear()
        CLAGRUC.Clear()

        Dim SQLCARGAPROD As New SqlClient.SqlCommand("SELECT CLAVE,GRUPO FROM PRODUCTOS  WHERE ACTIVO=1 AND CLAVE='" + TXTCLA.Text + "'", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        Try
            LECTOR = SQLCARGAPROD.ExecuteReader

            If LECTOR.Read() Then
                CLAPRODC.Add(LECTOR(0))
                CLAGRUC.Add(LECTOR(1))
                
                LECTOR.Close()
                Return True
            Else
                LECTOR.Close()
                MessageBox.Show("El codigo del producto NO existe en el sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                TXTCLA.Text = ""
                TXTCLA.Focus()
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("El codigo del producto NO existe en el sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TXTCLA.Text = ""
            TXTCLA.Focus()
            Return False
        End Try
    End Function
    Private Sub TXTCLA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLA.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not CHECAPROD() Then
                Exit Sub
            End If
            CARGAELGRUPO(CLAGRUC(0))
            CARGAELPRODUCTO(CLAPRODC(0))
            TXTCANT.Focus()
            TXTCANT.SelectAll()
        End If
    End Sub

    Private Sub TXTCANT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCANT.KeyPress
        If e.KeyChar = Chr(13) Then
            CBUNI.Focus()
        End If
    End Sub

    Private Sub CBGRU_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBGRU.KeyPress
        If e.KeyChar = Chr(13) Then
            CBPROD.Focus()
        End If
    End Sub

    Private Sub CBPROD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBPROD.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTCANT.Focus()
            TXTCANT.SelectAll()
        End If
    End Sub

    Private Sub CBUNI_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBUNI.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTCANT.Text = "" Or TXTCANT.Text = 0 Then
                MessageBox.Show("Especifique una cantidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TXTCANT.Focus()
                TXTCANT.SelectAll()
                Exit Sub
            End If

            AGREGAR(CLAGRU(CBGRU.SelectedIndex), CBGRU.Text, CLACP(CBPROD.SelectedIndex), CBPROD.Text, CType(TXTCANT.Text, Double), CBUNI.Text, LBLDES.Text)

            CHECATABLA()
        End If
    End Sub

    Private Sub frmPedidos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de productos", "Nombre del producto", "Productos(s)", 3, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(1))
                CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
                TXTCANT.Focus()
                TXTCANT.SelectAll()
            End If
        End If

        If e.KeyCode = Keys.F4 Then
            If TXTCANT.Text = "" Or TXTCANT.Text = 0 Then
                MessageBox.Show("Especifique una cantidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TXTCANT.Focus()
                TXTCANT.SelectAll()
                Exit Sub
            End If

            AGREGAR(CLAGRU(CBGRU.SelectedIndex), CBGRU.Text, CLACP(CBPROD.SelectedIndex), CBPROD.Text, CType(TXTCANT.Text, Double), CBUNI.Text, LBLDES.Text)

            CHECATABLA()
        End If


        If e.KeyCode = Keys.F5 Then
            If DGV.Rows.Count = 0 Then
                MessageBox.Show("No hay ningun producto agregado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If
            QUITAR()
        End If


        If e.KeyCode = Keys.F7 Then
            If DGV.Rows.Count = 0 Then
                MessageBox.Show("No hay ningun producto agregado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            Dim xyz As Short
            xyz = MessageBox.Show("¿Esta seguro que desea eliminar TODOS los elementos agregados?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xyz = 6 Then
                LGRU.Clear()
                LPRO.Clear()
                LUNI.Clear()
                DT.Rows.Clear()
                DGV.Refresh()
                CHECATABLA()
            End If
        End If


        If e.KeyCode = Keys.F12 Then
            If DGV.Rows.Count = 0 Then
                MessageBox.Show("No hay ningun producto agregado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            Dim xyz As Short
            xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz <> 6 Then
                Exit Sub
            End If
            GUARDAR()
            CHECATABLA()
        End If
    End Sub
End Class