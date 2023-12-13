Public Class frmTraspasosV2
    Dim LALM As New List(Of String)
    Dim LCP As New List(Of Double)
    Dim LGRU As New List(Of String)
    Dim LPRO As New List(Of String)
    Dim LUNI As New List(Of String)
    Dim DV2 As New DataView
    Dim DTP As New DataTable
    Dim DT2 As New DataTable
    Dim PED As New clsPedidoV2
    Dim CEDIS, NCEDIS As String
    Dim ALMO As String
    Dim VGUARDAR, DESDEPEDIDO As Boolean
    Dim EMP As String
    Dim PCEDIS As String
    Private Sub frmTraspasosV2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        VGUARDAR = False
        DESDEPEDIDO = False
        'BTNSF.Enabled = False
        If Not LLAMACEDIS() Then
            Me.Close()
        Else
            OPLlenaComboBox(CBALM, LALM, "SELECT A.CLAVE,A.NOMBRECOMUN FROM TIENDAS A WHERE ACTIVO=1 AND A.CLAVE<>'" + CEDIS + "'  ORDER BY A.NOMBRECOMUN", frmPrincipal.CadenaConexion)
            DT2 = BDLlenatabla("SELECT E.PRODUCTO,P.GRUPO,E.UNIDAD,U.NOMBRE FROM EQUIVALENCIAS E INNER JOIN PRODUCTOS P ON E.UNIDAD2=P.UVENTA AND P.CP=E.PRODUCTO AND P.EMPRESA=E.EMPRESA INNER JOIN UNIDADES U ON E.UNIDAD=U.CLAVE WHERE P.ACTIVO=1", frmPrincipal.CadenaConexion)
            DTP = BDLlenatabla("SELECT P.CP CLAVE,P.GRUPO,P.UVENTA,EXISTENCIA=0.000,U.NOMBRE UNIDAD,P.DESCRIPCION NOMBRE,COSTO=0.000 FROM PRODUCTOS P INNER JOIN UNIDADES U ON P.UVENTA=U.CLAVE WHERE P.ACTIVO=1", frmPrincipal.CadenaConexion)
            OPLlenaComboBox(CBGRU, LGRU, "SELECT DISTINCT (G.CLAVE)CLAVE,G.NOMBRE FROM PRODUCTOS P INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE P.ACTIVO=1 ORDER BY G.NOMBRE", frmPrincipal.CadenaConexion)
            'OPLlenaComboBox(CBGRU, LGRU, "SELECT CLAVE,NOMBRE FROM GRUPOSARTICULOS WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
            CHECATABLA()
            CARGANOPEDIDO()
        End If
    End Sub
    Private Function LLAMACEDIS() As Boolean
        Me.Opacity = 25
        Dim VNV As New frmLlamaCedis
        VNV.ShowDialog()
        If VNV.DialogResult = Windows.Forms.DialogResult.Yes Then
            CEDIS = VNV.ALM
            NCEDIS = VNV.NALM
            EMP = VNV.EMP
            Me.Text = "Salida por Traspaso de Almacén: " + NCEDIS
            Return True
        Else
            Return False
        End If
        'TXTDES.Text = 0
    End Function
    Dim DV As New DataView
    Private Function CARGADATAVIEW(ByVal GRUPO As String) As Boolean
        DV = New DataView(DTP, "GRUPO='" + GRUPO + "'", "NOMBRE", DataViewRowState.CurrentRows)
        Return CARGAPRODUCTOS()
    End Function
    Dim LEXIS As New List(Of String)
    Dim LUNIEX As New List(Of String)
    Dim LDES As New List(Of String)
    Dim LUDS As New List(Of String)
    Dim LUDC As New List(Of String)
    Private Function CARGAPRODUCTOS() As Boolean
        Try
            CBPROD.Items.Clear()
            LPRO.Clear()
            LEXIS.Clear()
            LUNIEX.Clear()
            LDES.Clear()
            LUDS.Clear()
            LCP.Clear()
            Dim X As Integer
            Dim DRV As DataRowView
            For X = 0 To DV.Count - 1
                DRV = DV.Item(X)
                CBPROD.Items.Add(DRV.Item(5))
                LPRO.Add(DRV.Item(0))
                'CLAGRU.Add(DRV.Item(4))
                If DRV.Item(3) Is DBNull.Value Then
                    LEXIS.Add(0)
                Else
                    LEXIS.Add(DRV.Item(3))
                End If
                If DRV.Item(6) Is DBNull.Value Then
                    LUNIEX.Add("N/A")
                Else
                    LUNIEX.Add(DRV.Item(4))
                End If
                LDES.Add(DRV.Item(5))
                LUDS.Add(DRV.Item(2))
                LCP.Add(DRV.Item(6))
                LUDC.Add(DRV.Item(2))
            Next

            Try
                CBPROD.SelectedIndex = 0
                Return True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return False
            End Try
        Catch ex As Exception
            'frmPrincipal.CE.ESCRIBIR("Salida Inventario restaurantes", Now, "ventana:salidainventariorestaurante metodo:CARGAPRODUCTOS()", ex.Message.ToString)
            Exit Function
        End Try
    End Function
    Private Sub ACTIVAR(ByVal V As Boolean)
        Try
            TXTCANT.Enabled = V
            CBUNI.Enabled = V
            'TXTCOS.Enabled = V
            BTNAGREGAR.Enabled = V
        Catch ex As Exception
            ' frmPrincipal.CE.ESCRIBIR("Sailda inventario restaurantes", Now, "ventana:salidainventariorestaurante metodo: ACTIVAR", ex.Message.ToString)
            Exit Sub
        End Try
    End Sub
    Private Function CARGADATAVIEW2(ByVal GRUPO As String, ByVal PRO As String) As Boolean
        DV2 = New DataView(DT2, "GRUPO='" + GRUPO + "' AND PRODUCTO='" + PRO + "'", "NOMBRE", DataViewRowState.CurrentRows)
        Return CARGAEQUIVALENCIAS()
    End Function
    Private Function CARGAEQUIVALENCIAS() As Boolean
        Try
            LUNI.Clear()
            CBUNI.Items.Clear()
            Dim X As Integer
            Dim DRV As DataRowView
            For X = 0 To DV2.Count - 1
                DRV = DV2.Item(X)
                CBUNI.Items.Add(DRV.Item(3))
                LUNI.Add(DRV.Item(2))
            Next
            Try
                CBUNI.SelectedIndex = 0
                Return True
            Catch ex As Exception
                Return False
            End Try
            'DGV.DataSource = DT2
        Catch ex As Exception
            'frmPrincipal.CE.ESCRIBIR("Sailda inventario restaurantes", Now, "ventana:salidainventariorestaurante metodo: CARGAEQUIVALENCIAS()", ex.Message.ToString)
            Exit Function
        End Try
    End Function
    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged
        If Not CARGADATAVIEW(LGRU(CBGRU.SelectedIndex)) Then
            MessageBox.Show("No Se encuentra Asignado Ningún Producto en este Grupo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            CBPROD.Enabled = False
            ACTIVAR(False)
        Else
            CBPROD.Enabled = True
            If Not CARGADATAVIEW2(LGRU(CBGRU.SelectedIndex), LPRO(CBPROD.SelectedIndex)) Then
                MessageBox.Show("No Se encuentra Asignado Ninguna Equivalencia que Coincida con las Unidades de Entrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ACTIVAR(False)
            Else
                ACTIVAR(True)
            End If
        End If
    End Sub
    Dim TOT As Double
    Private Sub CHECATABLA()
        TOT = 0
        If DGV.Rows.Count = 0 Then
            BTNQUITAR.Enabled = False
            BTNELIMINAR.Enabled = False
            BTNGUARDAR.Enabled = False
        Else
            Dim X As Integer
            For X = 0 To DGV.Rows.Count - 1
                TOT = TOT + DGV.Item(6, X).Value
            Next
            'LBLTS.Text = FormatNumber(TOT, 2).ToString
            BTNGUARDAR.Enabled = True
            BTNQUITAR.Enabled = True
            BTNELIMINAR.Enabled = True
        End If
        LBLTA.Text = FormatNumber(PED.CuentaElementos, 2).ToString
    End Sub
    'Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
    '    frmClsBusqueda.BUSCAR("SELECT CLAVE,Nombre,GRUPO,DESCRIPCION,ACTIVO FROM PRODUCTOS", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 3, frmPrincipal.CadenaConexion, False)
    '    If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
    '        OPCargaX(LGRU, CBGRU, (frmClsBusqueda.TREG.Rows(0).Item(2)))
    '        OPCargaX(LPRO, CBPROD, frmClsBusqueda.TREG.Rows(0).Item(0))
    '        'CARGADATOS()
    '        TXTCANT.Focus()
    '        TXTCANT.SelectAll()
    '    End If
    'End Sub

    Private Sub CBPROD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBPROD.SelectedIndexChanged
        LBLDES.Text = LDES(CBPROD.SelectedIndex)
        If Not CARGADATAVIEW2(LGRU(CBGRU.SelectedIndex), LPRO(CBPROD.SelectedIndex)) Then
            MessageBox.Show("No Se encuentra Asignado Ninguna Equivalencia que Coincida con las Unidades de Entrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ACTIVAR(False)
        Else
            CARGAUNIDADDEFAULT()
            ACTIVAR(True)
            CargarExistencia()
        End If
    End Sub
    Private Sub CargarExistencia()
        Try
            EXISGRAL = BDExtraeUnDato("SELECT DBO.CHECAEXISTENCIA('" + CEDIS + "','" + LPRO(CBPROD.SelectedIndex) + "')", frmPrincipal.CadenaConexion)
        Catch ex As Exception
            EXISGRAL = 0
        End Try
        LBLCANTEXIS.Text = EXISGRAL.ToString ''LEXIS(CBPROD.SelectedIndex).ToString
        LBLUNIEXIS.Text = LUNIEX(CBPROD.SelectedIndex).ToString
    End Sub
    Dim EXISGRAL As Double
    Private Sub CARGAUNIDADDEFAULT()
        Try
            Dim VUNI As String
            VUNI = LUDC(CBPROD.SelectedIndex)
            Dim X As Integer
            For X = 0 To LUNI.Count - 1
                If LUNI(X) = VUNI Then
                    CBUNI.SelectedIndex = X
                End If
            Next
        Catch ex As Exception
            'frmPrincipal.CE.ESCRIBIR("Inventario Bajamar", Now, "ventana:Compras Metodo:CARGAUNIDADDEFAULT())", ex.Message.ToString)
            Exit Sub
        End Try


    End Sub
    Private Sub ACTUALIZARPEDIDO()
        DGV.DataSource = PED.ElementosAgregados

        DGV.Columns(9).Visible = False
        DGV.Columns(8).Visible = False
        DGV.Columns(7).Visible = False
        DGV.Columns(6).Visible = False
        DGV.Columns(5).Visible = False
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(3).ReadOnly = True
        DGV.Columns(4).ReadOnly = True
        DGV.Columns(5).ReadOnly = True
        DGV.Columns(6).ReadOnly = True
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'DGV.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


        DGV.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        'DGV.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        'DGV.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        CHECATABLA()
    End Sub
    Dim PEDORI As Integer

    Private Function CARGANOPEDIDO() As Integer
        Dim SQLMOV As New SqlClient.SqlCommand("SELECT MAX(NOTRASPASO)MAXIMOMOV FROM TRASPASOSTIENDAS", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLMOV.ExecuteReader
        Dim NUM As Integer
        If LECTOR.Read Then
            If LECTOR(0) Is DBNull.Value Then
                NUM = 1
            Else

                NUM = CType(LECTOR(0), Integer)
                NUM = NUM + 1
            End If
        End If
        LECTOR.Close()
        LBLPED.Text = NUM.ToString
        Return NUM
    End Function
    Private Sub GUARDAR()
        'If Not CHECAESTADO() Then
        '    MessageBox.Show("El pedido No puede ser Modificado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '    Exit Sub
        'End If

        If DGV.Rows.Count <= 0 Then
            MessageBox.Show("No hay información para Guardar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not CHECAEXISTENCIA() Then
            Exit Sub
        End If
        Dim CONTFALT As Integer
        CONTFALT = 0
        If VGUARDAR Then
            Dim SQLB As New SqlClient.SqlCommand("DELETE FROM TRASPASOSTIENDAS WHERE NOTRASPASO=" + LBLPED.Text, frmPrincipal.CONX)
            SQLB.ExecuteNonQuery()
            SQLB.CommandText = "DELETE FROM DETALLETRASPASOSTIENDAS WHERE NOTRASPASO=" + LBLPED.Text
            SQLB.ExecuteNonQuery()
        Else
            CARGANOPEDIDO()
        End If

        Dim SQLD As New SqlClient.SqlCommand("INSERT INTO DETALLETRASPASOSTIENDAS (NOTRASPASO,PRODUCTO,CANTIDAD,TOTAL,REGISTRO,COSTOPROMEDIO,UNIDAD)VALUES(@NOS,@PRO,@CANT,@TOT,@REG,@CP,@UNI)", frmPrincipal.CONX)
        SQLD.Parameters.Add("@CEDIS", SqlDbType.VarChar).Value = CEDIS
        SQLD.Parameters.Add("@NOS", SqlDbType.Int).Value = LBLPED.Text
        SQLD.Parameters.Add("@GRU", SqlDbType.VarChar)
        SQLD.Parameters.Add("@PRO", SqlDbType.VarChar)
        SQLD.Parameters.Add("@UNI", SqlDbType.VarChar)
        SQLD.Parameters.Add("@CANT", SqlDbType.Float)
        SQLD.Parameters.Add("@CP", SqlDbType.Float)
        SQLD.Parameters.Add("@TOT", SqlDbType.VarChar)
        SQLD.Parameters.Add("@REG", SqlDbType.Int)
        'SQLD.Parameters.Add("@uni", SqlDbType.VarChar)

        Dim INDD, INDF As Integer
        INDD = 0
        INDF = 0
        Dim TOTP As Double
        TOTP = 0
        For X = 0 To PED.ElementosAgregados.Rows.Count - 1
            If DGV.Item(1, X).Value = "N/A" Then
                If VGUARDAR Then
                Else
                    'SQLDF.Parameters("@NP").Value = LBLPED.Text
                    'SQLDF.Parameters("@GRU").Value = LGRU(X)
                    'SQLDF.Parameters("@PRO").Value = LPRO(X)
                    'SQLDF.Parameters("@CANT").Value = DGV.Item(4, X).Value
                    'SQLDF.Parameters("@UNI").Value = LUNI(X)
                    'SQLDF.Parameters("@REG").Value = INDF
                    'INDF = INDF + 1
                    'SQLDF.ExecuteNonQuery()
                End If
            Else
                SQLD.Parameters("@GRU").Value = PED.ElementosAgregados.Rows(X).Item(7)
                SQLD.Parameters("@PRO").Value = PED.ElementosAgregados.Rows(X).Item(8)
                SQLD.Parameters("@UNI").Value = PED.ElementosAgregados.Rows(X).Item(9)
                SQLD.Parameters("@CANT").Value = PED.ElementosAgregados.Rows(X).Item(1)
                SQLD.Parameters("@CP").Value = PED.ElementosAgregados.Rows(X).Item(5)
                SQLD.Parameters("@TOT").Value = PED.ElementosAgregados.Rows(X).Item(6)
                SQLD.Parameters("@REG").Value = X
                SQLD.ExecuteNonQuery()
            End If
        Next
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO TRASPASOSTIENDAS (ORIGEN,DESTINO,NOTRASPASO,ESTADO,FECHA,USUARIO) VALUES (@AO,@AD,@NOS,@EST,GETDATE(),@USU)", frmPrincipal.CONX)
        SQL.Parameters.Add("@NOS", SqlDbType.Int).Value = LBLPED.Text
        SQL.Parameters.Add("@AO", SqlDbType.VarChar).Value = CEDIS
        SQL.Parameters.Add("@AD", SqlDbType.VarChar).Value = LALM(CBALM.SelectedIndex)
        SQL.Parameters.Add("@EST", SqlDbType.Int).Value = 2
        'SQL.Parameters.Add("@TOT", SqlDbType.Float).Value = TOTP
        SQL.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        SQL.ExecuteNonQuery()

        'If DESDEPEDIDO Then
        '    Try
        '        Dim SQLPT As New SqlClient.SqlCommand("INSERT INTO PEDIDOSTRABAJADOS (NOPEDIDO,ALMACEN,FECHA,USUARIO)VALUES (@NP,@ALM,GETDATE(),@USU)", frmPrincipal.CONX)
        '        SQLPT.Parameters.Add("@NP", SqlDbType.Int).Value = PEDORI
        '        SQLPT.Parameters.Add("@ALM", SqlDbType.VarChar).Value = CEDIS
        '        SQLPT.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        '        SQLPT.ExecuteNonQuery()
        '    Catch ex As Exception

        '    End Try
        'End If
        'BTNSF.Enabled = False
        PED.EliminarNota()
        ACTUALIZARPEDIDO()
        VGUARDAR = False

 
        'If Not CHECAESTADO() Then
        '    MessageBox.Show("El pedido No puede ser Modificado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '    Exit Sub
        'Else
        'Dim SQL As New SqlClient.SqlCommand("UPDATE SALIDASTRASPASOSALMACENES SET ESTADO=3,FECHA=GETDATE() WHERE ALMACENO='" + CEDIS + "' AND NOSALIDA=" + LBLPED.Text, frmPrincipal.CONX)
        'SQL.ExecuteNonQuery()
        'Try
        Cursor = Cursors.WaitCursor
        SQL.CommandText = "SPGENERATRASPASO"
        SQL.Parameters.Clear()
        SQL.Parameters.Add("@NOT", SqlDbType.Int).Value = LBLPED.Text
        SQL.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        SQL.CommandType = CommandType.StoredProcedure
        SQL.CommandTimeout = 600
        SQL.ExecuteNonQuery()
        'Catch ex As Exception
        Cursor = Cursors.Default
        'End Try
        'End If


        Dim VINFOTRAS As New frmTraspasoCartaPorte
        VINFOTRAS.MOSTRAR(LBLPED.Text)

        IMPRIMIRSALIDA()
        'IMPRIMIRNOTA()

        PED.EliminarNota()
        'OPLlenaComboBox(CBALM, LALM, "SELECT CLAVE,NOMBRE FROM ALMACENES WHERE CLAVE<>'" + CEDIS + "' ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        'DT2 = BDLlenatabla("SELECT E.PRODUCTO,P.GRUPO,E.UNIDAD,U.NOMBRE FROM EQUIVALENCIAS E INNER JOIN PRODUCTOS P ON E.UNIDAD2=P.UVENTA AND P.CP=E.PRODUCTO AND P.EMPRESA=E.EMPRESA INNER JOIN UNIDADES U ON E.UNIDAD=U.CLAVE ", frmPrincipal.CadenaConexion)
        'DTP = BDLlenatabla("SELECT P.CP CLAVE,P.GRUPO,P.UVENTA,DBO.CHECAEXISTENCIA('" + CEDIS + "',P.CP)EXISTENCIA,U.NOMBRE UNIDAD,P.DESCRIPCION NOMBRE,DBO.COSTOPROM('" + CEDIS + "',P.CP)COSTO FROM PRODUCTOS P INNER JOIN UNIDADES U ON P.UVENTA=U.CLAVE WHERE P.ACTIVO=1", frmPrincipal.CadenaConexion)
        DTP = BDLlenatabla("SELECT P.CP CLAVE,P.GRUPO,P.UVENTA,EXISTENCIA=0.000,U.NOMBRE UNIDAD,P.DESCRIPCION NOMBRE,COSTO=0.000 FROM PRODUCTOS P INNER JOIN UNIDADES U ON P.UVENTA=U.CLAVE WHERE P.ACTIVO=1", frmPrincipal.CadenaConexion)
        CBGRU.SelectedIndex = 0
        'OPLlenaComboBox(CBGRU, LGRU, "SELECT DISTINCT (G.CLAVE)CLAVE,G.NOMBRE FROM PRODUCTOS P INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE P.ACTIVO=1 ORDER BY G.NOMBRE", frmPrincipal.CadenaConexion)
        ACTUALIZARPEDIDO()

    End Sub
    Private Sub DGV_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Dim CANT As Double
        Try
            CANT = CType(DGV.Item(1, DGV.CurrentRow.Index).Value, Double)
        Catch ex As Exception
            Exit Sub
        End Try
        Dim COL As Integer
        COL = DGV.Columns.Count - 1
        Dim ALGO As String
        ALGO = DGV.Item(7, DGV.CurrentRow.Index).Value
        ALGO = DGV.Item(8, DGV.CurrentRow.Index).Value
        ALGO = DGV.Item(9, DGV.CurrentRow.Index).Value
        PED.ModificaCantidad(DGV.Item(7, DGV.CurrentRow.Index).Value, DGV.Item(8, DGV.CurrentRow.Index).Value, CANT, TUM(DGV.Item(7, DGV.CurrentRow.Index).Value, DGV.Item(8, DGV.CurrentRow.Index).Value, DGV.Item(1, DGV.CurrentRow.Index).Value, DGV.Item(9, DGV.CurrentRow.Index).Value))
        ACTUALIZARPEDIDO()

    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea Guardar la Información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
    End Sub
    Private Sub AGREGAR()
        If TXTCANT.Text = "" Then
            MessageBox.Show("Especifique una Cantidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TXTCANT.Focus()
            TXTCANT.SelectAll()
            Exit Sub
        End If
        If CType(TXTCANT.Text, Double) <= 0 Then
            MessageBox.Show("Especifique una Cantidad Mayor a Cero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TXTCANT.Focus()
            TXTCANT.SelectAll()
            Exit Sub
        End If
        CargarExistencia()
        Dim TTT As Double
        TTT = TUM(LGRU(CBGRU.SelectedIndex), LPRO(CBPROD.SelectedIndex), TXTCANT.Text, LUNI(CBUNI.SelectedIndex))
        If TTT > EXISGRAL Then
            Dim VCE As New frmCompraExpress
            VCE.Mostrar(frmPrincipal.SucursalBase, LPRO(CBPROD.SelectedIndex), CBPROD.Text, LUNI(CBUNI.SelectedIndex), TTT - EXISGRAL, "Traspaso")
            If VCE.DialogResult = DialogResult.Yes Then
                CargarExistencia()
                AGREGAR()
            End If
        Else
            PED.Agregar(CBPROD.Text, TXTCANT.Text, CBUNI.Text, TTT, EXISGRAL, LPRO(CBPROD.SelectedIndex), 0, LGRU(CBGRU.SelectedIndex), LPRO(CBPROD.SelectedIndex), LUNI(CBUNI.SelectedIndex))
            ACTUALIZARPEDIDO()
            TXTCANT.Text = ""
            BTNBUS.Focus()
        End If
        DgvPosicionaUltimoRegistro(DGV)
    End Sub
    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        AGREGAR()
    End Sub
    Private Function TUM(ByVal GRU As String, ByVal PRO As String, ByVal CANT As Double, ByVal UNI As String) As Double
        If Not frmPrincipal.CHECACONX Then
            Return 0
        End If
        Dim REG As Double
        REG = 0
        Dim SQL As New SqlClient.SqlCommand("SELECT DBO.TOTALUNIDADMINIMA2('" + PRO + "','" + CANT.ToString + "','" + UNI + "')", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            REG = LEC(0)
        End If
        LEC.Close()
        SQL.Dispose()
        Return REG
    End Function
    'Private Sub BTNBUSBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSBD.Click
    '    frmClsBusqueda.BUSCAR("SELECT P.NOSALIDA,A.NOMBRE ALMACEN,E.NOMBRE ESTADO,P.FECHA,P.USUARIO FROM SALIDASTRASPASOSALMACENES P INNER JOIN ALMACENES A ON P.ALMACEND=A.CLAVE  INNER JOIN ESTADOPEDIDO E ON P.ESTADO=E.CLAVE WHERE P.FECHA>=DATEADD(dd,-45,P.FECHA) AND ALMACENO='" + CEDIS + "'", " AND A.NOMBRE", " ORDER BY P.FECHA", "Búsqueda de Sálidas de Traspaso", "Nombre del Almacén", "Pedido(s)", 1, frmPrincipal.CadenaConexion, True)
    '    If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
    '        PED.EliminarNota()
    '        ACTUALIZARPEDIDO()
    '        LBLPED.Text = frmClsBusqueda.TREG(0).Item(0)
    '        CARGARPEDIDOBD(frmClsBusqueda.TREG(0).Item(0))
    '    End If
    'End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea cancelar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        PED.EliminarNota()
        ACTUALIZARPEDIDO()
    End Sub

    'Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
    '    PED.EliminarNota()
    '    ACTUALIZARPEDIDO()
    '    'BTNSF.Enabled = False
    '    VGUARDAR = False
    '    DESDEPEDIDO = False
    '    CARGANOPEDIDO()
    'End Sub
    Private Sub IMPRIMIRSALIDA()
        Dim REP As New rptSalidaTraspaso
        Dim QUERY As String
        QUERY = "SELECT A.NOMBRECOMUN CEDIS,B.NOMBRECOMUN ALMACEN,D.NOTRASPASO NOSALIDA,G.NOMBRE GRUPO,P.NOMBRE PRODUCTO, D.CANTIDAD, U.NOMBRE UNIDAD,DBO.CHECAEXISTENCIA('" + PCEDIS + "',D.PRODUCTO)EXISTENCIA,COSTOPROMEDIO=DBO.COSTOPROM('" + PCEDIS + "',D.PRODUCTO),TOTAL=DBO.TOTALUNIDADMINIMA2(D.PRODUCTO,D.CANTIDAD,D.UNIDAD)*DBO.COSTOPROM('" + PCEDIS + "',D.PRODUCTO),D.COSTOPROMEDIO CPGUARDADO,S.USUARIO,RESPONSABLEO='',RESPONSABLED='' FROM DETALLETRASPASOSTIENDAS D INNER JOIN TRASPASOSTIENDAS S ON D.NOTRASPASO=S.NOTRASPASO INNER JOIN TIENDAS A ON S.ORIGEN=A.CLAVE INNER JOIN TIENDAS B ON S.DESTINO=B.CLAVE INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CP INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE D.NOTRASPASO=" + LBLPED.Text + " ORDER BY D.REGISTRO"
        MOSTRARREPORTE(REP, "Salida por Traspaso No. " + LBLPED.Text, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), "")
        Dim SQLNC As New SqlClient.SqlCommand("SPNOTIFICACIONMOVIMIENTO", frmPrincipal.CONX)
        SQLNC.CommandType = CommandType.StoredProcedure
        SQLNC.CommandTimeout = 600
        SQLNC.Parameters.Add("@MOV", SqlDbType.Int).Value = 3
        SQLNC.Parameters.Add("@ALM", SqlDbType.VarChar).Value = LALM(CBALM.SelectedIndex)
        SQLNC.Parameters.Add("@NOO", SqlDbType.Int).Value = LBLPED.Text
    End Sub
    Private Sub ActualizaExistencia()
        Dim ExisGral As Double
        Dim X As Integer
        For X = 0 To PED.ElementosAgregados.Rows.Count - 1
            Try
                ExisGral = BDExtraeUnDato("SELECT DBO.CHECAEXISTENCIA('" + CEDIS + "','" + PED.ElementosAgregados.Rows(X).Item(8) + "')", frmPrincipal.CadenaConexion)
                PED.AsignarExistencia(PED.ElementosAgregados.Rows(X).Item(8).ToString, ExisGral)
            Catch ex As Exception
                ExisGral = 0
            End Try
        Next
        DGV.DataSource = PED.ElementosAgregados
    End Sub
    Private Function CHECAEXISTENCIA() As Boolean
        ActualizaExistencia()
        Dim X As Integer
        Dim A, B As Double
        For X = 0 To DGV.Rows.Count - 1
            A = DGV.Item(3, X).Value
            B = DGV.Item(4, X).Value
            If A > B Then
                MessageBox.Show("Cantidad de Salida excede a la existencia: " + DGV.Item(0, X).Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DGV.CurrentCell = DGV.Rows(X).Cells(1)
                Return False
            End If
        Next
        Return True
    End Function
    'Private Sub BTNSF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSF.Click
    '    Dim xyz As Short
    '    xyz = MessageBox.Show("¿Desea establecer el Pedido Listo para Entregar?, El pedido No podrá ser Modificado", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '    If xyz <> 6 Then
    '        Exit Sub
    '    End If
    '    If Not CHECAEXISTENCIA() Then
    '        Exit Sub
    '    End If
    '    'If Not CHECAESTADO() Then
    '    '    MessageBox.Show("El pedido No puede ser Modificado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '    '    Exit Sub
    '    'Else
    '    Dim SQL As New SqlClient.SqlCommand("UPDATE SALIDASTRASPASOSALMACENES SET ESTADO=3,FECHA=GETDATE() WHERE ALMACENO='" + CEDIS + "' AND NOSALIDA=" + LBLPED.Text, frmPrincipal.CONX)
    '    SQL.ExecuteNonQuery()
    '    'Try
    '    Cursor = Cursors.WaitCursor
    '    SQL.CommandText = "SPGENERATRASPASO"
    '    SQL.Parameters.Add("@AO", SqlDbType.VarChar).Value = CEDIS
    '    SQL.Parameters.Add("@NOT", SqlDbType.Int).Value = LBLPED.Text
    '    SQL.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
    '    SQL.CommandType = CommandType.StoredProcedure
    '    SQL.CommandTimeout = 600
    '    SQL.ExecuteNonQuery()
    '    'Catch ex As Exception
    '    Cursor = Cursors.Default
    '    'End Try
    '    'End If
    '    IMPRIMIRSALIDA()
    '    IMPRIMIRNOTA()

    '    PED.EliminarNota()
    '    OPLlenaComboBox(CBALM, LALM, "SELECT CLAVE,NOMBRE FROM ALMACENES WHERE CLAVE<>'" + CEDIS + "' ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
    '    DT2 = BDLlenatabla("SELECT E.PRODUCTO,E.GRUPO,E.UNIDAD,U.NOMBRE FROM EQUIVALENCIAPRODUCTO E INNER JOIN PRODUCTOS P ON E.UNIDAD2=P.UNIDAD AND P.CLAVE=E.PRODUCTO AND P.GRUPO=E.GRUPO INNER JOIN UNIDADES U ON E.UNIDAD=U.CLAVE WHERE E.ESRESTAURANTE=0", frmPrincipal.CadenaConexion)
    '    DTP = BDLlenatabla("SELECT P.CLAVE,P.NOMBRE,P.GRUPO,P.UNIDAD,P.GRUPO,DBO.EXISTENCIAALMACEN(P." + PCEDIS + ",P.GRUPO,P.CLAVE)EXISTENCIA,U.NOMBRE UNIDAD,P.DESCRIPCION,P.UNIDAD,COSTOPROMEDIO=DBO.ULTIMOCOSTOGUARDADO(P." + PCEDIS + ",P.GRUPO,P.CLAVE),P.UNIDADCICLO FROM PRODUCTOS P INNER JOIN UNIDADES U ON P.UNIDAD=U.CLAVE", frmPrincipal.CadenaConexion)
    '    OPLlenaComboBox(CBGRU, LGRU, "SELECT CLAVE,NOMBRE FROM GRUPOSARTICULOS WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
    '    ACTUALIZARPEDIDO()
    'End Sub
    'Private Sub IMPRIMIRNOTA()
    '    If Not frmPrincipal.CHECACONX Then
    '        Exit Sub
    '    End If
    '    Dim EO, ED, AD As String
    '    Dim SQL As New SqlClient.SqlCommand("SELECT O.EMPRESA,D.EMPRESA,S.ALMACEND FROM SALIDASTRASPASOSALMACENES S INNER JOIN ALMACENES O ON S.ALMACENO=O.CLAVE INNER JOIN ALMACENES D ON S.ALMACEND=D.CLAVE WHERE ALMACENO=" + CEDIS.ToString + " AND NOSALIDA=" + LBLPED.Text, frmPrincipal.CONX)
    '    Dim LEC As SqlClient.SqlDataReader
    '    LEC = SQL.ExecuteReader
    '    If LEC.Read Then
    '        EO = LEC(0)
    '        ED = LEC(1)
    '        AD = LEC(2)
    '    End If
    '    LEC.Close()
    '    SQL.Dispose()
    '    Dim IMPTICK As Boolean
    '    IMPTICK = False
    '    If EO = 1 And ED <> EO Then
    '        'IMPRIMO NOTA
    '        IMPTICK = True
    '    End If
    '    If CEDIS = 8 And ED = 1 Then
    '        'GENERO ENTRADA A CREDITO            
    '    End If
    '    If IMPTICK Then
    '        Dim MN As Integer
    '        MN = 0
    '        Dim SQLN As New SqlClient.SqlCommand("SELECT MAX(NOTA) FROM NOTASDEVENTACREDITOINV WHERE TIENDA='ACIM' AND AO='" + CEDIS + "'", frmPrincipal.CONX)
    '        Dim LECN As SqlClient.SqlDataReader
    '        LECN = SQLN.ExecuteReader
    '        If LECN.Read Then
    '            MN = LECN(0)
    '        End If
    '        LECN.Close()
    '        SQLN.Dispose()
    '        If MN = 0 Then
    '            Exit Sub
    '        End If
    '        Dim QUER As String
    '        QUER = "SELECT S.NOMBRECOMUN,CL.NOMBRE CLIENTE,S.NOMBREFISCAL,D.NOTA,D.PRODUCTO CODIGO,P.NOMBRE PRODUCTO,D.CANTIDAD,DBO.PRECIODESC(D.TOTAL,D.CANTIDAD,0) PRECIO,D.TOTAL,SUBTOTAL=DBO.ELSUBTOTALINV(D.GRUPO,D.PRODUCTO,D.TOTAL),IVA=DBO.ELIVAINV(D.GRUPO,D.PRODUCTO,D.TOTAL),E.NOMBRE EMPLEADO,N.FECHA,S.DIRECCION,S.CIUDAD,S.RFC,S.TELEFONO,N.NOCAJA,TIPO='Ticket Credito',VNOM='',VUNI='',DESCUENTO=0.00,S.COMENTARIO5 COMENTARIO1,S.COMENTARIO6 COMENTARIO2,S.COMENTARIO7 COMENTARIO3,S.COMENTARIO8 COMENTARIO4,CL.TELEFONO TEL,DBO.DIRCLIENTE(CL.CLAVE) DIR,S.CP,CL.RFC R,DBO.TXTPAGAREINV(N.TIENDA,N.CLIENTE,N.TOTAL)TXTPAGARE,TIPOVENTA='VENTAS ALMACENES',COMENTARIO='' FROM DETALLENOTASDEVENTACREDITOINV D INNER JOIN TIENDAS S ON D.TIENDA=S.CLAVE INNER JOIN PRODUCTOS  P  ON D.PRODUCTO=P.CLAVE AND D.GRUPO=P.GRUPO INNER JOIN NOTASDEVENTACREDITOINV N  ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA INNER JOIN EMPLEADOSTIENDAS E ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE  INNER JOIN CLIENTES CL ON CL.CLAVE=N.CLIENTE WHERE S.CLAVE='ACIM' AND N.NOCAJA=1 AND N.NOTA=" + MN.ToString
    '        Dim REPI As New rptNotaDeVentaCredito
    '        MOSTRARREPORTE(REPI, "", BDLlenatabla(QUER, frmPrincipal.CadenaConexion), "")

    '        'IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), 1, "")
    '    End If
    'End Sub
    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        PED.AgregaQuita(DGV.Item(7, DGV.CurrentRow.Index).Value, DGV.Item(8, DGV.CurrentRow.Index).Value, DGV.Item(1, DGV.CurrentRow.Index).Value, False)
        ACTUALIZARPEDIDO()
    End Sub

    Private Sub TXTCANT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCANT.KeyPress
        If e.KeyChar = Chr(13) Then
            AGREGAR()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim REP As New rptSalidaTraspaso
        Dim QUERY As String
        QUERY = "SELECT A.NOMBRE CEDIS,B.NOMBRE ALMACEN,D.NOSALIDA,G.NOMBRE GRUPO,P.NOMBRE PRODUCTO, D.CANTIDAD, U.NOMBRE UNIDAD,DBO.EXISTENCIAALMACEN(P." + PCEDIS + ",D.GRUPO,D.PRODUCTO)EXISTENCIA,COSTOPROMEDIO=DBO.ULTIMOCOSTOGUARDADO(P." + PCEDIS + ",D.GRUPO,D.PRODUCTO),TOTAL=D.CANTIDAD*DBO.ULTIMOCOSTOGUARDADO(P." + PCEDIS + ",D.GRUPO,D.PRODUCTO),D.COSTOPROMEDIO CPGUARDADO,USU.NOMBRE USUARIO,A.RESPONSABLE RESPONSABLEO,B.RESPONSABLE RESPONSABLED FROM DETALLESALIDASTRASPASOSALMACENES D INNER JOIN SALIDASTRASPASOSALMACENES S ON S.ALMACENO=D.ALMACENO AND D.NOSALIDA=S.NOSALIDA INNER JOIN ALMACENES A ON S.ALMACENO=A.CLAVE INNER JOIN ALMACENES B ON S.ALMACEND=B.CLAVE INNER JOIN PRODUCTOS P ON D.GRUPO=P.GRUPO AND D.PRODUCTO=P.CLAVE INNER JOIN UNIDADES U ON P.UNIDAD=U.CLAVE INNER JOIN GRUPOSARTICULOS G ON P.GRUPO=G.CLAVE INNER JOIN USUARIOSINV USU ON S.USUARIO=USU.USUARIO WHERE D.ALMACENO='" + CEDIS + "' AND D.NOSALIDA=" + LBLPED.Text
        MOSTRARREPORTE(REP, "Salida por Traspaso No. " + LBLPED.Text, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), "")
    End Sub

    'Private Sub BTNIMPRIMIR2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR2.Click
    '    frmClsBusqueda.BUSCAR("SELECT D.NOSALIDA,A.NOMBRE ALMACEN,D.FECHA,D.USUARIO FROM SALIDASTRASPASOSALMACENES D INNER JOIN ALMACENES A ON D.ALMACEND=A.CLAVE WHERE ALMACENO='" + CEDIS + "' AND FECHA>=(DATEADD (dd,-1,GETDATE())) AND D.ESTADO=3", " AND A.NOMBRE", "", "Reimpresión de Salidas", "Nombre del Almacén", "Salidas", 1, frmPrincipal.CadenaConexion, True)
    '    If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
    '        Dim REP As New rptSalidaTraspaso
    '        Dim QUERY As String
    '        QUERY = "SELECT A.NOMBRE CEDIS,B.NOMBRE ALMACEN,D.NOSALIDA,G.NOMBRE GRUPO,P.NOMBRE PRODUCTO, D.CANTIDAD, U.NOMBRE UNIDAD,DBO.EXISTENCIAALMACEN(P." + PCEDIS + ",D.GRUPO,D.PRODUCTO)EXISTENCIA,COSTOPROMEDIO=DBO.ULTIMOCOSTOGUARDADO(P." + PCEDIS + ",D.GRUPO,D.PRODUCTO),TOTAL=D.CANTIDAD*DBO.ULTIMOCOSTOGUARDADO(P." + PCEDIS + ",D.GRUPO,D.PRODUCTO),D.COSTOPROMEDIO CPGUARDADO,USU.NOMBRE USUARIO,A.RESPONSABLE RESPONSABLEO,B.RESPONSABLE RESPONSABLED FROM DETALLESALIDASTRASPASOSALMACENES D INNER JOIN SALIDASTRASPASOSALMACENES S ON S.ALMACENO=D.ALMACENO AND D.NOSALIDA=S.NOSALIDA INNER JOIN ALMACENES A ON S.ALMACENO=A.CLAVE INNER JOIN ALMACENES B ON S.ALMACEND=B.CLAVE INNER JOIN PRODUCTOS P ON D.GRUPO=P.GRUPO AND D.PRODUCTO=P.CLAVE INNER JOIN UNIDADES U ON P.UNIDAD=U.CLAVE INNER JOIN GRUPOSARTICULOS G ON P.GRUPO=G.CLAVE INNER JOIN USUARIOSINV USU ON S.USUARIO=USU.USUARIO WHERE D.ALMACENO='" + CEDIS + "' AND D.NOSALIDA=" + frmClsBusqueda.TREG.Rows(0).Item(0)
    '        MOSTRARREPORTE(REP, "Salida por Traspaso No. " + LBLPED.Text, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), "")
    '    End If
    'End Sub

    Private Sub BTNBUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUS.Click
        frmClsBusqueda.BUSCAR("SELECT CP,Nombre,GRUPO,DESCRIPCION,ACTIVO FROM PRODUCTOS WHERE ACTIVO=1", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 3, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            OPCargaX(LGRU, CBGRU, (frmClsBusqueda.TREG.Rows(0).Item(2)))
            OPCargaX(LPRO, CBPROD, frmClsBusqueda.TREG.Rows(0).Item(0))
            'CARGADATOS()
            TXTCANT.Focus()
            TXTCANT.SelectAll()
        End If
    End Sub
End Class