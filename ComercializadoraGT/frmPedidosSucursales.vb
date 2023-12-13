Public Class frmPedidosSucursales
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
    Dim DV2 As New DataView
    Dim DT2 As New DataTable
    Dim SOLICITADO, EXISTENCIA, AGREGADO, CANTLOTE As Double
    Dim UNIDAD, UNIC As String
    Dim DESDEPEDIDO As Boolean
    Dim LOC, CLALOT As String
    Dim LEXIS As New List(Of Double)
    Dim LNOMUNI As New List(Of String)
    Dim DV As New DataView
    Dim LLOTES As New List(Of String)
    Dim PEDIDOACT As Integer
    Dim ACTUALIZA As Boolean
    Dim PEDIDOO As Integer
    Dim PED As New clsPedido
    Private Sub frmPedidosSucursales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGASUCURSALES()
        CARGATIPOPEDIDO()

        DTP = BDLlenatabla("SELECT CLAVE,PRODUCTO,GRUPO,UVENTA,EXISTENCIA,NOMBREUNIDAD,CP,COSTOPROM FROM INVENTARIOPEDIDOS3  ORDER BY PRODUCTO", frmPrincipal.CadenaConexion)

        Dim DA2 As New SqlClient.SqlDataAdapter("SELECT E.PRODUCTO,E.UNIDAD,U.NOMBRE  FROM EQUIVALENCIAS E INNER JOIN PRODUCTOS P  ON E.UNIDAD2=P.UVENTA AND P.CP=E.PRODUCTO  INNER JOIN UNIDADES U ON E.UNIDAD=U.CLAVE ", frmPrincipal.CONX)
        DT2.Clear()
        DA2.Fill(DT2)
        CARGAGRUPOS()
        CARGANOPEDIDO()
        DT.Columns.Add("Grupo")
        DT.Columns.Add("Producto")
        DT.Columns.Add("Cantidad")
        DT.Columns.Add("Unidad")
        DT.Columns.Add("Precio")
        DT.Columns.Add("Total")
        DT.Columns.Add("Lote")
        DT.Columns.Add("Localidad")
        DT.Columns.Add("Uni")
        CHECATABLA()
        CBGRU.SelectedIndex = 0
        LGRU.Clear()
        LPRO.Clear()
        LUNI.Clear()
        VGUARDAR = False
        BTNSF.Enabled = False
        TABLAVIRTUAL()
    End Sub
    Dim LCPROM As New List(Of Double)
    Private Function CARGAPRODUCTOS() As Boolean
        CBPROD.Items.Clear()
        CLAPROD.Clear()
        LEXIS.Clear()
        LNOMUNI.Clear()
        CLACP.Clear()
        LCPROM.Clear()
        Dim X As Integer
        Dim DRV As DataRowView
        For X = 0 To DV.Count - 1
            DRV = DV.Item(X)
            CBPROD.Items.Add(DRV.Item(1))
            CLAPROD.Add(DRV.Item(0))
            If DRV.Item(4) Is DBNull.Value Then
                LEXIS.Add(0)
            Else
                LEXIS.Add(DRV.Item(4))
            End If
            LNOMUNI.Add(DRV.Item(5))
            CLACP.Add(DRV.Item(6))
            LCPROM.Add(DRV.Item(7))
        Next

        Try
            CBPROD.SelectedIndex = 0
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
    Private Sub CARGASUCURSALES()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBSUC, CLASUC, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE  EMPRESA=" + frmPrincipal.Empresa + " AND ACTIVO=1 ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion)
        If CBSUC.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBSUC.SelectedIndex = 0
        Catch ex As Exception

        End Try
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
    Private Function CARGANOPEDIDO() As Integer
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        Dim NUM As Integer
        Dim SQLMOV As New SqlClient.SqlCommand("SELECT DBO.SIGUIENTEPEDIDOB()", frmPrincipal.CONX)
        SQLMOV.CommandTimeout = 300
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLMOV.ExecuteReader
        If LECTOR.Read Then
            NUM = LECTOR(0)
            LECTOR.Close()
            LBLPED.Text = NUM
        Else
            LECTOR.Close()
        End If
        SQLMOV.Dispose()
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
        Dim TOT As Double
        'Dim PZAS As Double
        For X = 0 To DGV.Rows.Count - 1
            TOT = TOT + CType(DGV.Item(5, X).Value, Double)
            'PZAS = PZAS + CType(DGV.Item(2, X).Value, Double)
        Next
        LBLTOT.Text = TOT.ToString
        'LBLCUANTOS.Text = "Total de Rollos= " + PZAS.ToString
    End Sub
    Private Sub TABLAVIRTUAL()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        Dim SQL As New SqlClient.SqlCommand("ACTUALIZAVIRTUAL", frmPrincipal.CONX)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.CommandTimeout = 300
        SQL.ExecuteNonQuery()
        SQL.Dispose()
    End Sub


    Private Sub BTNACT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNACT.Click
        TABLAVIRTUAL()
    End Sub

    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        If TXTCANT.Text = "" Then
            MessageBox.Show("Especifique una cantidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TXTCANT.Focus()
            TXTCANT.SelectAll()
            Exit Sub
        End If
        If CType(TXTCANT.Text, Integer) = 0 Then
            MessageBox.Show("Especifique una cantidad mayor a cero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TXTCANT.Focus()
            TXTCANT.SelectAll()
            Exit Sub
        End If
        Dim TTT As Double
        TTT = TUM(CLACP(CBPROD.SelectedIndex), TXTCANT.Text, CLAUNI(CBUNI.SelectedIndex))
        PED.Agregar(CBPROD.Text, TXTCANT.Text, CBUNI.Text, TTT, LEXIS(CBPROD.SelectedIndex), LCPROM(CBPROD.SelectedIndex), TTT * LCPROM(CBPROD.SelectedIndex), CLACP(CBPROD.SelectedIndex), CLAUNI(CBUNI.SelectedIndex))
        ACTUALIZARPEDIDO()
        TXTCLA.Clear()
        TXTCLA.Focus()        
    End Sub
    Private Function TUM(ByVal PRO As String, ByVal CANT As Double, ByVal UNI As String) As Double
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

    Private Function CALCULATOTAL(ByVal LOTE As String, ByVal CANTIDAD As Double, ByVal UNIDAD As String) As Double
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT DBO.REGRESATOTALPRECIO('" + LOTE + "'," + CANTIDAD.ToString + ",'" + UNIDAD + "')", frmPrincipal.CONX)
        SQL.CommandTimeout = 300
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            Dim REG As Double
            REG = LEC(0)
            LEC.Close()
            Return REG
        End If
        LEC.Close()
        SQL.Dispose()
        Return 0
    End Function

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
    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        PED.AgregaQuita(DGV.Item(7, DGV.CurrentRow.Index).Value, DGV.Item(1, DGV.CurrentRow.Index).Value, False)
        ACTUALIZARPEDIDO()
    End Sub

   
    Private Function CHECAESTADO() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
      
        Dim SQL As New SqlClient.SqlCommand("SELECT ESTADO FROM PEDIDOS WHERE NOPEDIDO=" + LBLPED.Text + " ", frmPrincipal.CONX)
        SQL.CommandTimeout = 300
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQL.ExecuteReader
        If LECTOR.Read Then
            Dim ESTADO As Integer
            ESTADO = LECTOR(0)
            LECTOR.Close()
            If ESTADO < 3 Then
                Return True
            Else
                Return False
            End If
        Else
            LECTOR.Close()
            SQL.Dispose()
            Return True
        End If
    End Function

    Private Sub GUARDAR()
        If Not CHECAESTADO() Then
            MessageBox.Show("El pedido No puede ser modificado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        Dim CONTFALT As Integer
        CONTFALT = 0
       
        If VGUARDAR Then
            Dim SQLB As New SqlClient.SqlCommand("DELETE FROM PEDIDOS WHERE NOPEDIDO=" + LBLPED.Text + " ", frmPrincipal.CONX)
            SQLB.ExecuteNonQuery()
            SQLB.CommandText = "DELETE FROM DETALLEPEDIDOS2 WHERE NOPEDIDO=" + LBLPED.Text
            SQLB.ExecuteNonQuery()
        Else
            CARGANOPEDIDO()
        End If

        Dim SQLD As New SqlClient.SqlCommand("INSERT INTO DETALLEPEDIDOS2  (NOPEDIDO,CP,CANTIDAD,TOTAL,REGISTRO,COSTOPROMEDIO,UNIDAD)VALUES(@NOS,@PRO,@CANT,@TOT,@REG,@CP,@UNI)", frmPrincipal.CONX)
        SQLD.Parameters.Add("@NOS", SqlDbType.Int).Value = LBLPED.Text
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
                SQLD.Parameters("@PRO").Value = PED.ElementosAgregados.Rows(X).Item(7)
                SQLD.Parameters("@UNI").Value = PED.ElementosAgregados.Rows(X).Item(8)
                SQLD.Parameters("@CANT").Value = PED.ElementosAgregados.Rows(X).Item(1)
                SQLD.Parameters("@CP").Value = PED.ElementosAgregados.Rows(X).Item(5)
                SQLD.Parameters("@TOT").Value = PED.ElementosAgregados.Rows(X).Item(6)
                SQLD.Parameters("@REG").Value = X
                SQLD.ExecuteNonQuery()
            End If
        Next


        Dim SQL As New SqlClient.SqlCommand("INSERT INTO PEDIDOS (NOPEDIDO,TIENDA,TIPOPEDIDO,ESTADO,TOTAL,FECHA,USUARIOHACE,NPPERTENECE) VALUES (@NP,@RES,@TP,@EST,@TOT,GETDATE(),@USU," + PEDIDOO.ToString + ")", frmPrincipal.CONX)
        SQL.CommandTimeout = 300
        SQL.Parameters.Add("@NP", SqlDbType.Int)
        SQL.Parameters.Add("@RES", SqlDbType.VarChar)
        SQL.Parameters.Add("@TP", SqlDbType.Int)
        SQL.Parameters.Add("@EST", SqlDbType.Int)
        SQL.Parameters.Add("@TOT", SqlDbType.Float)
        SQL.Parameters.Add("@USU", SqlDbType.VarChar)

        SQL.Parameters("@NP").Value = LBLPED.Text
        SQL.Parameters("@RES").Value = CLASUC(CBSUC.SelectedIndex)
        SQL.Parameters("@TP").Value = LISTTP(CBTP.SelectedIndex)
        SQL.Parameters("@EST").Value = 0
        SQL.Parameters("@TOT").Value = TOTP
        SQL.Parameters("@USU").Value = frmPrincipal.Usuario
        SQL.ExecuteNonQuery()
        SQL.Dispose()

        BTNSF.Enabled = False
        PED.EliminarNota()
        ACTUALIZARPEDIDO()
        VGUARDAR = False

        MessageBox.Show("La información ha sido Guardada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        Dim xyz As Short
        xyz = MessageBox.Show("Desea Imprimir el Pedido", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz = 6 Then
            Dim REP As New rptPedidoTraspaso
            Dim QREP As String
            QREP = "SELECT A.NOMBRECOMUN ALMACEN,D.NOPEDIDO NOSALIDA,G.NOMBRE GRUPO,P.NOMBRE PRODUCTO, D.CANTIDAD, U.NOMBRE UNIDAD,DBO.EXISTENCIAALMACEN('PM',D.CP)EXISTENCIA,COSTOPROMEDIO=DBO.COSTOPROM('PM',D.CP),TOTAL=DBO.TOTALUNIDADMINIMA(D.CP,D.CANTIDAD,D.UNIDAD)*DBO.COSTOPROM('PM',D.CP),D.COSTOPROMEDIO CPGUARDADO,S.USUARIOHACE USUARIO FROM PEDIDOS S INNER JOIN DETALLEPEDIDOS2 D ON S.NOPEDIDO=D.NOPEDIDO INNER JOIN TIENDAS A ON S.TIENDA=A.CLAVE INNER JOIN PRODUCTOS P ON D.CP=P.CP INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE  WHERE D.NOPEDIDO=" + LBLPED.Text
            MOSTRARREPORTE(REP, "Pedido: " + LBLPED.Text, BDLlenatabla(QREP, frmPrincipal.CadenaConexion), "")
        End If
        CARGANOPEDIDO()
    End Sub
   

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim FECHA As String
        Dim DT, DTNOW As New DateTimePicker
        DTNOW.Value = Now
        DT.Value = DTNOW.Value.AddDays(-15)
        FECHA = Format(DT.Value.Date, "yyyyMMdd")
        Dim PAR As New SqlClient.SqlParameter
        PAR.DbType = DbType.DateTime
        PAR.Value = DTNOW.Value.AddDays(-15)

        Dim QUERY As String
        QUERY = "SELECT P.NOPEDIDO,S.NOMBRECOMUN,T.NOMBRE TIPOPEDIDO,P.FECHA,P.USUARIO FROM PEDIDOSTIENDAS P INNER JOIN TIENDAS S ON P.TIENDA=S.CLAVE INNER JOIN TIPOSPEDIDOS T ON P.TIPOPEDIDO=T.CLAVE WHERE P.FECHA >='" + FECHA + "' AND P.ESTADO=0 ORDER BY FECHA DESC "
        frmClsBusqueda.BUSCAR(QUERY, " WHERE S.Nombre", " ", "Búsqueda de pedidos de sucursales", "Pedidos", "pedido(s)", 1, frmPrincipal.CadenaConexion, True)
      
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            PED.EliminarNota()
            ACTUALIZARPEDIDO()
            CARGANOPEDIDO()
            CARGARPEDIDO(frmClsBusqueda.TREG(0).Item(0))
            BTNQUITAR.Enabled = False
            'BTNAGREGAR.Enabled = False

            DGV.Columns(8).Visible = False
        End If
    End Sub
    Dim PEDORI As Integer
    Private Sub CARGARPEDIDO(ByVal NPED As Integer)
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT TIENDA,TIPOPEDIDO FROM PEDIDOSTIENDAS WHERE NOPEDIDO=@PED", frmPrincipal.CONX)
        SQL.Parameters.Add("@PED", SqlDbType.VarChar).Value = NPED
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            OPCargaX(CLASUC, CBSUC, LEC(0))
            OPCargaX(LISTTP, CBTP, LEC(1))
        End If
        LEC.Close()
        SQL.Dispose()

        VGUARDAR = False
        DESDEPEDIDO = True

        Dim QUERY As String
        QUERY = "SELECT P.NOMBRE PRODUCTO,D.CANTIDAD,U.NOMBRE UNIDAD,DBO.TOTALUNIDADMINIMA2(D.CP,D.CANTIDAD,D.UNIDAD)TOTMIN,DBO.EXISTENCIAALMACEN('PM',D.CP)EXISTENCIA,COSTOPROMEDIO=DBO.COSTOPROM('PM',D.CP),TOTAL=D.CANTIDAD*DBO.COSTOPROM('PM',D.CP),D.CP,D.UNIDAD FROM DETALLEPEDIDOS2 D INNER JOIN PRODUCTOS P ON D.CP=P.CP  INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE  WHERE D.NOPEDIDO=" + NPED.ToString + " ORDER BY P.NOMBRE"
        Dim DT As New DataTable
        DT = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        Dim X As Integer
        For X = 0 To DT.Rows.Count - 1
            PED.Agregar(DT.Rows(X).Item(0), DT.Rows(X).Item(1), DT.Rows(X).Item(2), DT.Rows(X).Item(3), DT.Rows(X).Item(4), DT.Rows(X).Item(5), DT.Rows(X).Item(6), DT.Rows(X).Item(7), DT.Rows(X).Item(8))
        Next
        DT.Dispose()
        PEDORI = NPED
        ACTUALIZARPEDIDO()

    End Sub
    Private Sub ACTUALIZARPEDIDO()
        DGV.DataSource = PED.ElementosAgregados
        DGV.Columns(7).Visible = False
        DGV.Columns(8).Visible = False
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
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


        DGV.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        CHECATABLA()
    End Sub
    Private Sub BTNBP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBP.Click
        Dim VBP As New frmBorraPedido
        VBP.ShowDialog()
    End Sub
    Private Function TODODISPONIBLE(ByVal NP As Integer) As Boolean
        Dim SQL As New SqlClient.SqlCommand("PONEPEDIDOVSEXISTENCIA", frmPrincipal.CONX)
        SQL.CommandTimeout = 300
        SQL.CommandType = CommandType.StoredProcedure
        SQL.Parameters.Add("@PED", SqlDbType.Int).Value = NP
        SQL.ExecuteNonQuery()
        SQL.Dispose()

        Dim CND As Integer
        CND = 0
        SQL.Parameters.Clear()
        SQL.CommandType = CommandType.Text
        SQL.CommandText = "SELECT COUNT(REGISTRO) FROM PEDIDOVSEXISTENCIA WHERE RESULTADO='NO DISPONIBLE'"
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            CND = LEC(0)
        End If
        LEC.Close()
        If CND > 0 Then
            Return False
        End If
        Return True
    End Function
    Private Function CHECAEXISTENCIA() As Boolean
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
    Private Sub BTNSF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSF.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea establecer el pedido listo para entregar?, El pedido no podrá ser modificado", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        If Not CHECAEXISTENCIA() Then
            Exit Sub
        End If
       
        frmPrincipal.CHECACONX()
        If Not CHECAESTADO() Then
            MessageBox.Show("El pedido No puede ser Modificado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        Else
            Dim SQLu As New SqlClient.SqlCommand("UPDATE PEDIDOS SET ESTADO=3,FECHA=GETDATE() WHERE NOPEDIDO=" + LBLPED.Text + " ", frmPrincipal.CONX)
            SQLu.ExecuteNonQuery()
            Dim SQLDP As New SqlClient.SqlCommand("SPDESCUENTAPEDIDO2", frmPrincipal.CONX)
            SQLDP.Parameters.Add("@PED", SqlDbType.Int).Value = LBLPED.Text
            SQLDP.CommandType = CommandType.StoredProcedure
            SQLDP.ExecuteNonQuery()
            Dim SQLINV As New SqlClient.SqlCommand("SPAGREGAINVENTARIOPEDIDO", frmPrincipal.CONX)
            SQLINV.Parameters.Add("@PED", SqlDbType.Int).Value = LBLPED.Text
            SQLINV.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
            SQLINV.CommandType = CommandType.StoredProcedure
            SQLINV.ExecuteNonQuery()
        End If

        Dim REPO As New rptSalidaBodega
        MOSTRARREPORTE(REPO, "Reporte de Salida de: " + frmPrincipal.NombreComun, BDLlenatabla("SELECT R.NOMBRECOMUN TIENDA,N.NOPEDIDO,P.NOMBRE,P.DESCRIPCION,D.CANTIDAD,U.NOMBRE UNIDAD,P.PRECIO COSTOU,D.CANTIDAD*P.PRECIO TOTAL,A.NOMBRE AREA,T.NOMBRE TIPOPEDIDO,LU.NOMBRE UNIDABASE  FROM PEDIDOS N INNER JOIN TIENDAS R ON N.TIENDA=R.CLAVE INNER JOIN DETALLEPEDIDOS2 D ON N.NOPEDIDO=D.NOPEDIDO INNER JOIN PRODUCTOS P ON D.CP=P.CP  INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN SUBGRUPOS A ON P.SUBGRUPO =A.CLAVE INNER JOIN TIPOSPEDIDOS T  ON N.TIPOPEDIDO=T.CLAVE INNER JOIN LASUNIDADES LU ON P.UVENTA=LU.CLAVE  WHERE N.NOPEDIDO = " + LBLPED.Text + " ", frmPrincipal.CadenaConexion), "Enviar a One Note 2007")
        'frmReportes.IMPRIMIR2(REPO, "Reporte de Salida de: " + CBSUC.Text, "SELECT R.NOMBRE RESTAURANTE,N.NOPEDIDO,D.LOTE,P.NOMBRE,P.DESCRIPCION,D.CANTIDAD,U.NOMBRE UNIDAD,L.COSTOU,TOTAL=(SELECT DBO.REGRESATOTALPRECIO(D.LOTE,D.CANTIDAD,D.UNIDAD)),A.NOMBRE AREA,T.NOMBRE TIPOPEDIDO,LU.NOMBRE UNIDABASE FROM PEDIDOS N INNER JOIN CLIENTESCOMPRAS R ON N.RESTAURANTE=R.CLAVE INNER JOIN DETALLEPEDIDOS D ON N.NOPEDIDO=D.NOPEDIDO INNER JOIN LOTES L ON D.LOTE=L.CLAVE INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CLAVE AND L.GRUPO=P.GRUPO INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN AREASURTIDO A ON P.AREAIMPRESION =A.CLAVE INNER JOIN TIPOSPEDIDOS T ON N.TIPOPEDIDO=T.CLAVE INNER JOIN LASUNIDADES LU ON P.UNIDADENTRADA=LU.CLAVE WHERE N.NOPEDIDO = " + LBLPED.Text + " ORDER BY P.NOMBRE")
        DGV.DataSource = DBNull.Value
        DT.Clear()
        CARGANOPEDIDO()
        CHECATABLA()
        TABLAVIRTUAL()
        MessageBox.Show("El pedido esta listo para ser recibido y no podrá modificarse", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub
    Private Function CARGADATAVIEW(ByVal GRUPO As String) As Boolean
        DV = New DataView(DTP, "GRUPO='" + GRUPO + "'", "PRODUCTO", DataViewRowState.CurrentRows)
        Return CARGAPRODUCTOS()
    End Function
    Private Function CARGADATAVIEW2(ByVal PRO As String) As Boolean
        DV2 = New DataView(DT2, " PRODUCTO='" + PRO + "'", "NOMBRE", DataViewRowState.CurrentRows)
        Return CARGAEQUIVALENCIAS()
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
        'TXTCOS.Enabled = V
        BTNAGREGAR.Enabled = V
    End Sub
    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged

        'TXTGAN.Text = LPCT(CBGRU.SelectedIndex).ToString
        If Not CARGADATAVIEW(CLAGRU(CBGRU.SelectedIndex)) Then
            MessageBox.Show("No Se encuentra Asignado Ningún Producto en este Grupo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            CBPROD.Enabled = False
            ACTIVAR(False)
        Else
            CBPROD.Enabled = True
            If Not CARGADATAVIEW2(CLACP(CBPROD.SelectedIndex)) Then
                MessageBox.Show("No Se encuentra Asignado Ninguna Equivalencia que Coincida con las Unidades de Entrada de Bodega", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ACTIVAR(False)
            Else
                ACTIVAR(True)
            End If
        End If
    End Sub
    Private Sub CBPROD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBPROD.SelectedIndexChanged        
        LBLEXIS.Text = FormatNumber(LEXIS(CBPROD.SelectedIndex), 2).ToString
        LBLCOSTO.Text = LCPROM(CBPROD.SelectedIndex)
        LBLNOMUNI.Text = LNOMUNI(CBPROD.SelectedIndex)
        If Not CARGADATAVIEW2(CLACP(CBPROD.SelectedIndex)) Then
            MessageBox.Show("No se encuentra asignado ninguna equivalencia que coincida con las unidades de entrada de bodega", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ACTIVAR(False)
        Else
            ACTIVAR(True)
        End If
    End Sub
    Private Sub CARGALAUNIDAD(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CLAPROD.Count - 1
            If CLAUNI(X) = CLA Then
                CBUNI.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub

    Private Sub BTNBUSBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSBD.Click
        Dim QUERY As String
        QUERY = "SELECT P.NOPEDIDO,S.NOMBRECOMUN TIENDA,P.FECHA,T.NOMBRE TIPO,E.NOMBRE ESTADO FROM PEDIDOS P INNER JOIN TIPOSPEDIDOS T ON T.CLAVE=P.TIPOPEDIDO INNER JOIN TIENDAS S ON P.TIENDA=S.CLAVE INNER JOIN ESTADOPEDIDO E ON P.ESTADO=E.CLAVE WHERE FECHA>=DATEADD(dd,-45,P.FECHA)  AND P.ESTADO=0"
        frmClsBusqueda.BUSCAR(QUERY, " AND P.NOPEDIDO", " ORDER BY FECHA DESC", "Búsqueda de Pedidos", "Número de Pedido", "Pedido(s)", 1, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            PED.EliminarNota()
            ACTUALIZARPEDIDO()
            LBLPED.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            CARGARPEDIDOBD(LBLPED.Text)
        End If
    End Sub
    Private Sub CARGARPEDIDOBD(ByVal NPED As Integer)
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT TIENDA FROM PEDIDOS WHERE NOPEDIDO=@PED", frmPrincipal.CONX)
        SQL.Parameters.Add("@PED", SqlDbType.VarChar).Value = NPED
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            OPCargaX(CLASUC, CBSUC, LEC(0))
        End If
        LEC.Close()
        SQL.Dispose()

        VGUARDAR = True
        DESDEPEDIDO = False
        Dim QUERY As String
        QUERY = "SELECT P.NOMBRE PRODUCTO,D.CANTIDAD,U.NOMBRE UNIDAD,DBO.TOTALUNIDADMINIMA2(D.CP,D.CANTIDAD,D.UNIDAD),DBO.EXISTENCIAALMACEN('PM',D.CP)EXISTENCIA,COSTOPROMEDIO=DBO.COSTOPROM('PM',D.CP),TOTAL=DBO.TOTALUNIDADMINIMA2(D.CP,D.CANTIDAD,D.UNIDAD)*DBO.COSTOPROM('PM',D.CP),D.CP,D.UNIDAD FROM DETALLEPEDIDOS2 D INNER JOIN PRODUCTOS P ON D.CP=P.CP INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE WHERE D.NOPEDIDO=" + NPED.ToString + " ORDER BY P.NOMBRE"
        Dim DT As New DataTable
        DT = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        Dim X As Integer
        For X = 0 To DT.Rows.Count - 1
            PED.Agregar(DT.Rows(X).Item(0), DT.Rows(X).Item(1), DT.Rows(X).Item(2), DT.Rows(X).Item(3), DT.Rows(X).Item(4), DT.Rows(X).Item(5), DT.Rows(X).Item(6), DT.Rows(X).Item(7), DT.Rows(X).Item(8))
        Next
        DT.Dispose()
        BTNSF.Enabled = True
        ACTUALIZARPEDIDO()
    End Sub
    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        DGV.DataSource = Nothing
        VGUARDAR = False
        BTNSF.Enabled = False
        DESDEPEDIDO = False
        CARGANOPEDIDO()
        CHECATABLA()
        DT.Clear()
    End Sub
    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea cancelar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        PED.EliminarNota()
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

    Private Sub frmPedidosSucursales_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS  ", " WHERE NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Productos", "Nombre del Producto", "Productos(s)", 2, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLAGRU, CBGRU, frmClsBusqueda.TREG.Rows(0).Item(1).ToString)
                OPCargaX(CLAPROD, CBPROD, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
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
        PED.ModificaCantidad(DGV.Item(7, DGV.CurrentRow.Index).Value, CANT, TUM(DGV.Item(7, DGV.CurrentRow.Index).Value, DGV.Item(1, DGV.CurrentRow.Index).Value, DGV.Item(8, DGV.CurrentRow.Index).Value))
        ACTUALIZARPEDIDO()
    End Sub

    Private Sub TXTCLA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLA.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not CHECAPROD() Then
                Exit Sub
            End If
            TXTCANT.Focus()
            TXTCANT.SelectAll()
        End If
    End Sub
    Private Function CHECAPROD() As Boolean

        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        Dim SQLCARGAPROD As New SqlClient.SqlCommand("SELECT P.CLAVE,P.GRUPO FROM PRODUCTOS P WHERE P.ACTIVO=1 AND P.CLAVE='" + TXTCLA.Text + "'", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        Try
            LECTOR = SQLCARGAPROD.ExecuteReader

            If LECTOR.Read() Then
                OPCargaX(CLAGRU, CBGRU, LECTOR(1))
                OPCargaX(CLAPROD, CBPROD, LECTOR(0))
                LECTOR.Close()
                Return True
            Else
                LECTOR.Close()
                MessageBox.Show("El codigo del producto NO existe en el sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                TXTCLA.Text = ""
                TXTCLA.Focus()
                LECTOR.Close()
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("El codigo del producto NO existe en el sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TXTCLA.Text = ""
            TXTCLA.Focus()
            Return False
        End Try
    End Function

    Private Sub TXTCANT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCANT.KeyPress
        If e.KeyChar = Chr(13) Then
            CBUNI.Focus()
        End If
    End Sub

    Private Sub CBUNI_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBUNI.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNAGREGAR.Focus()
        End If
    End Sub
End Class