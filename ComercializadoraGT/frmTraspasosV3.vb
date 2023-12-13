Public Class frmTraspasosV3
    Dim LALM As New List(Of String)
    Dim LCP As New List(Of Double)
    Dim LGRU As New List(Of String)
    Dim LPRO As New List(Of String)
    Dim LUNI As New List(Of String)
    Dim DV2 As New DataView
    Dim DTP As New DataTable
    Dim DT2 As New DataTable
    Dim CEDIS, NCEDIS As String
    Dim ALMO As String
    Dim VGUARDAR, DESDEPEDIDO As Boolean
    Dim EMP As String
    Dim PCEDIS As String
    Dim DT As New DataTable

    Private Sub frmTraspasosV3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        DT.Columns.Add("Producto")
        DT.Columns.Add("Cantidad")
        DT.Columns.Add("Unidad")
        DT.Columns.Add("Existencia")
        DT.Columns.Add("CostoPromedio")
        DT.Columns.Add("CP")
        DT.Columns.Add("CU")
        VGUARDAR = False
        DESDEPEDIDO = False
        'BTNSF.Enabled = False
        If Not LLAMACEDIS() Then
            Me.Close()
        Else
            OPLlenaComboBox(CBALM, LALM, "SELECT A.CLAVE,A.NOMBRECOMUN FROM TIENDAS A WHERE ACTIVO=1 AND A.CLAVE<>'" + CEDIS + "'  ORDER BY A.NOMBRECOMUN", frmPrincipal.CadenaConexion)
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
                TOT = TOT + (DGV.Item(1, X).Value * DGV.Item(4, X).Value)
            Next
            'LBLTS.Text = FormatNumber(TOT, 2).ToString
            BTNGUARDAR.Enabled = True
            BTNQUITAR.Enabled = True
            BTNELIMINAR.Enabled = True
        End If
        LBLTA.Text = DGV.RowCount.ToString
    End Sub
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
        SQLD.Parameters.Add("@NOS", SqlDbType.Int).Value = LBLPED.Text
        SQLD.Parameters.Add("@PRO", SqlDbType.VarChar)
        SQLD.Parameters.Add("@UNI", SqlDbType.VarChar)
        SQLD.Parameters.Add("@CANT", SqlDbType.Float)
        SQLD.Parameters.Add("@CP", SqlDbType.Float)
        SQLD.Parameters.Add("@TOT", SqlDbType.Float)
        SQLD.Parameters.Add("@REG", SqlDbType.Int)
        'SQLD.Parameters.Add("@uni", SqlDbType.VarChar)

        Dim INDD, INDF, REG As Integer
        INDD = 0
        INDF = 0
        REG = 0
        Dim TOTP As Double
        TOTP = 0
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(1, X).Value <= 0 Then

            Else
                Dim UNI As String
                UNI = DGV.Item(6, X).Value
                SQLD.Parameters("@PRO").Value = DGV.Item(5, X).Value
                SQLD.Parameters("@UNI").Value = DGV.Item(6, X).Value
                SQLD.Parameters("@CANT").Value = DGV.Item(1, X).Value
                SQLD.Parameters("@CP").Value = DGV.Item(4, X).Value
                SQLD.Parameters("@TOT").Value = DGV.Item(1, X).Value * DGV.Item(4, X).Value
                SQLD.Parameters("@REG").Value = REG
                REG += 1
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


    End Sub
    Private Sub DGV_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Dim CANT As Double
        Try
            CANT = CType(DGV.Item(1, DGV.CurrentRow.Index).Value, Double)
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        If DGV.Rows.Count <= 0 Then
            MessageBox.Show("No hay información para Guardar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not CHECAEXISTENCIA() Then
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea Guardar la Información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click

        If OPMsgPreguntarSiNo("¿Desea cancelar la información?") Then
            Me.DT.Rows.Clear()
            Me.DGV.Refresh()
            Me.CHECATABLA()
        End If

    End Sub
    Private Sub IMPRIMIRSALIDA()
        Dim NI As String
        NI = ""
        Dim VSI As New frmSeleccionarImpresora
        VSI.ShowDialog()
        If VSI.DialogResult = Windows.Forms.DialogResult.Yes Then
            NI = VSI.NIMPRESORA
        End If
        Dim REP As New rptSalidaTraspaso
        Dim QUERY As String
        QUERY = "SELECT A.NOMBRECOMUN CEDIS,B.NOMBRECOMUN ALMACEN,D.NOTRASPASO NOSALIDA,G.NOMBRE GRUPO,P.NOMBRE PRODUCTO, D.CANTIDAD, U.NOMBRE UNIDAD,DBO.CHECAEXISTENCIA('" + PCEDIS + "',D.PRODUCTO)EXISTENCIA,COSTOPROMEDIO=DBO.COSTOPROM('" + PCEDIS + "',D.PRODUCTO),TOTAL=DBO.TOTALUNIDADMINIMA2(D.PRODUCTO,D.CANTIDAD,D.UNIDAD)*DBO.COSTOPROM('" + PCEDIS + "',D.PRODUCTO),D.COSTOPROMEDIO CPGUARDADO,S.USUARIO,RESPONSABLEO='',RESPONSABLED='' FROM DETALLETRASPASOSTIENDAS D INNER JOIN TRASPASOSTIENDAS S ON D.NOTRASPASO=S.NOTRASPASO INNER JOIN TIENDAS A ON S.ORIGEN=A.CLAVE INNER JOIN TIENDAS B ON S.DESTINO=B.CLAVE INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CP INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE D.NOTRASPASO=" + LBLPED.Text
        MOSTRARREPORTE(REP, "Salida por Traspaso No. " + LBLPED.Text, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), NI)
        'Dim SQLNC As New SqlClient.SqlCommand("SPNOTIFICACIONMOVIMIENTO", frmPrincipal.CONX)
        'SQLNC.CommandType = CommandType.StoredProcedure
        'SQLNC.CommandTimeout = 600
        'SQLNC.Parameters.Add("@MOV", SqlDbType.Int).Value = 3
        'SQLNC.Parameters.Add("@ALM", SqlDbType.VarChar).Value = LALM(CBALM.SelectedIndex)
        'SQLNC.Parameters.Add("@NOO", SqlDbType.Int).Value = LBLPED.Text
    End Sub
    Private Function CHECAEXISTENCIA() As Boolean
        Dim X As Integer
        Dim A, B As Double
        For X = 0 To DGV.Rows.Count - 1
            A = DGV.Item(1, X).Value
            B = DGV.Item(3, X).Value
            If A > B Then
                MessageBox.Show("Cantidad de Salida excede a la existencia: " + DGV.Item(3, X).Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DGV.CurrentCell = DGV.Rows(X).Cells(1)
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        Me.DT.Rows.RemoveAt(Me.DGV.CurrentRow.Index)
        Me.CHECATABLA()
    End Sub
    Dim DTA As New DataTable
    Private Sub BTNMOSTRAR_Click(sender As Object, e As EventArgs) Handles BTNMOSTRAR.Click
        frmBusquedaSeleccionMultiple.BUSCAR("SELECT TOP 100 P.CP CLAVE,P.NOMBRE,DBO.CHECAEXISTENCIA('" + CEDIS + "',P.CP)EXISTENCIA,U.NOMBRE UNIDAD,DBO.COSTOPROM('" + CEDIS + "',P.CP)COSTO,P.UVENTA UNIDAD FROM PRODUCTOS P INNER JOIN UNIDADES U ON P.UVENTA=U.CLAVE WHERE P.ACTIVO=1", " AND P.NOMBRE", " ORDER BY P.NOMBRE", "Selección de Productos", "Nombre del Producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, False, DTP, 1, 3)
        If frmBusquedaSeleccionMultiple.DialogResult = Windows.Forms.DialogResult.Yes Then
            DTA = New DataTable
            DTA = frmBusquedaSeleccionMultiple.TREG
            'DGV.DataSource = DTA
            ACTUALIZASELECCION()
        End If
    End Sub
    Private Sub ACTUALIZASELECCION()
        Dim X, Y As Integer
        Dim ENC As Boolean
        Dim z As Integer
        z = DTA.Columns.Count - 1
        Dim algo As Boolean
        For X = 0 To DTA.Rows.Count - 1
            ENC = False
            algo = CType(DTA.Rows(X).Item(z), Boolean)
            If CType(DTA.Rows(X).Item(z), Boolean) Then
                For Y = 0 To DT.Rows.Count - 1
                    If DTA.Rows(X).Item(0).ToString = DT.Rows(Y).Item(5).ToString Then
                        ENC = True
                        'DTT.Rows(Y).Item(3) = DTA.Rows(X).Item(3)
                    End If
                Next
            Else
                ENC = True
            End If

            If Not ENC Then
                Dim UNI As String
                'SELECT TOP 100 P.CP CLAVE,P.NOMBRE,DBO.CHECAEXISTENCIA('" + CEDIS + "',P.CP)EXISTENCIA,U.NOMBRE UNIDAD,DBO.COSTOPROM('" + CEDIS + "',P.CP)COSTO,P.UVENTA UNIDAD 
                Dim DOW As System.Data.DataRow = DT.NewRow
                DOW(0) = DTA.Rows(X).Item(1).ToString
                DOW(1) = 0.00
                DOW(2) = DTA.Rows(X).Item(3).ToString
                DOW(3) = DTA.Rows(X).Item(2).ToString
                DOW(4) = DTA.Rows(X).Item(4).ToString
                DOW(5) = DTA.Rows(X).Item(0).ToString
                DOW(6) = DTA.Rows(X).Item(5).ToString
                DT.Rows.Add(DOW)
            End If
        Next
        ACTUALIZADGV()
    End Sub
    Private Sub ACTUALIZADGV()
        DGV.DataSource = DT
        DGV.Columns(6).Visible = False
        DGV.Columns(5).Visible = False
        DGV.Columns(4).Visible = False
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(3).ReadOnly = True

        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


        DGV.Columns(1).DefaultCellStyle = DgvCellFormatoNumerico(3)
        DGV.Columns(3).DefaultCellStyle = DgvCellFormatoNumerico(3)

        CHECATABLA()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim REP As New rptSalidaTraspaso
        Dim QUERY As String
        QUERY = "SELECT A.NOMBRE CEDIS,B.NOMBRE ALMACEN,D.NOSALIDA,G.NOMBRE GRUPO,P.NOMBRE PRODUCTO, D.CANTIDAD, U.NOMBRE UNIDAD,DBO.EXISTENCIAALMACEN(P." + PCEDIS + ",D.GRUPO,D.PRODUCTO)EXISTENCIA,COSTOPROMEDIO=DBO.ULTIMOCOSTOGUARDADO(P." + PCEDIS + ",D.GRUPO,D.PRODUCTO),TOTAL=D.CANTIDAD*DBO.ULTIMOCOSTOGUARDADO(P." + PCEDIS + ",D.GRUPO,D.PRODUCTO),D.COSTOPROMEDIO CPGUARDADO,USU.NOMBRE USUARIO,A.RESPONSABLE RESPONSABLEO,B.RESPONSABLE RESPONSABLED FROM DETALLESALIDASTRASPASOSALMACENES D INNER JOIN SALIDASTRASPASOSALMACENES S ON S.ALMACENO=D.ALMACENO AND D.NOSALIDA=S.NOSALIDA INNER JOIN ALMACENES A ON S.ALMACENO=A.CLAVE INNER JOIN ALMACENES B ON S.ALMACEND=B.CLAVE INNER JOIN PRODUCTOS P ON D.GRUPO=P.GRUPO AND D.PRODUCTO=P.CLAVE INNER JOIN UNIDADES U ON P.UNIDAD=U.CLAVE INNER JOIN GRUPOSARTICULOS G ON P.GRUPO=G.CLAVE INNER JOIN USUARIOSINV USU ON S.USUARIO=USU.USUARIO WHERE D.ALMACENO='" + CEDIS + "' AND D.NOSALIDA=" + LBLPED.Text
        MOSTRARREPORTE(REP, "Salida por Traspaso No. " + LBLPED.Text, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), "")
    End Sub

End Class