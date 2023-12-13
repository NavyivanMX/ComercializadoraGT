Public Class frmTraspasos
    Dim CLARES As New List(Of String)
    Dim CLARES2 As New List(Of String)
    Dim CLAGRU As New List(Of String)
    Dim CLACP As New List(Of String)
    Dim CLAGRUP As New List(Of String)
    Dim CLAPRO As New List(Of String)
    Dim CLAEXIS As New List(Of String)
    Dim CLAUNI As New List(Of String)
    Dim CLAUNI2 As New List(Of String)
    Dim LGRU As New List(Of String)
    Dim LPRO As New List(Of String)
    Dim LUNI As New List(Of String)
    Dim LNUNI As New List(Of String)
    Dim LDES As New List(Of String)
    Dim DT As New DataTable
    Dim LAUNI As String
    Dim NOMUNI As String
    Dim DTP As New DataTable
    Dim DTE As New DataTable
    Dim DV As New DataView
    Dim DV2 As New DataView
    Private Sub frmTraspasos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        If Not frmPrincipal.CHECACONX Then
            Me.Close()
        End If

        DT.Columns.Add("ORIGEN")
        DT.Columns.Add("PRODUCTO")
        DT.Columns.Add("GRUPO")
        DT.Columns.Add("UNIDAD")
        Dim DA As New SqlClient.SqlDataAdapter("SELECT PRODUCTO,GRUPO,TIENDA,CANTIDAD,NOMBRE,DESCRIPCION,UVENTA,UNIDAD,CP FROM EXISTENCIAENTIENDAS ", frmPrincipal.CONX)
        DA.Fill(DTP)
        DA.SelectCommand.CommandText = "SELECT PRODUCTO,UNIDAD,NOMBRE FROM EQUIVALENCIASTIENDAS"
        DA.Fill(DTE)
        DT.Clear()
        CARGATIENDA()
        'CARGARESTAURANTE2()
        CARGAGRUPOS()
        CARGAPRODUCTO()
        CARGAEQUIVALENCIAS()
        CARGADECOMISO()
        CHECATABLA()
    End Sub
    Private Function CARGADECOMISO() As Integer
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim REG As String
        REG = ""

        frmPrincipal.CHECACONX()
        Dim NUM As Integer
        NUM = 1
        Dim SQLMOV As New SqlClient.SqlCommand("SELECT DBO.SIGUIENTETRASPASO()", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLMOV.ExecuteReader
        If LECTOR.Read Then
            NUM = LECTOR(0)
            REG = NUM.ToString
        End If
        LECTOR.Close()
        SQLMOV.Dispose()
        LBLDECOM.Text = NUM.ToString
        Return NUM
    End Function
    Private Sub CHECATABLA()
        If DGV.Rows.Count <= 0 Then
            BTNQUITAR.Enabled = False
            BTNELIMINAR.Enabled = False
            BTNGUARDAR.Enabled = False
            LBLC.Text = "0"
        Else
            BTNQUITAR.Enabled = True
            BTNELIMINAR.Enabled = True
            BTNGUARDAR.Enabled = True
            LBLC.Text = DGV.Rows.Count
        End If
    End Sub
    Private Function CARGATIENDA() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBORI, CLARES, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE CLAVE<>'PRUEBAS' AND CLAVE<>'ST' AND CLAVE<>'" + frmPrincipal.SucursalBase + "'  ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion)
        If CBORI.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBORI.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Function
    Private Function CARGAGRUPOS() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBGRU, CLAGRU, "SELECT CLAVE,NOMBRE FROM GRUPOS WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBGRU.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBGRU.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Function
    Private Function CARGAPRODUCTO() As Boolean
        CBPRO.Items.Clear()
        CLAPRO.Clear()
        CLAGRUP.Clear()
        CLAEXIS.Clear()
        LDES.Clear()
        LNUNI.Clear()
        CLACP.Clear()
        Dim X As Integer
        Dim DRV As DataRowView
        For X = 0 To DV.Count - 1
            DRV = DV.Item(X)
            CBPRO.Items.Add(DRV.Item(4))
            CLAPRO.Add(DRV.Item(0))
            CLAGRUP.Add(DRV.Item(1))
            CLAEXIS.Add(DRV.Item(3))
            LDES.Add(DRV.Item(5))
            LNUNI.Add(DRV.Item(7))
            CLACP.Add(DRV.Item(8))
        Next

        Try
            CBPRO.SelectedIndex = 0
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Private Function CARGADATAVIEW(ByVal RES As String, ByVal GRUPO As String) As Boolean
        DV = New DataView(DTP, "TIENDA='" + RES + "' AND GRUPO=" + GRUPO + "", "NOMBRE", DataViewRowState.CurrentRows)
        Return CARGAPRODUCTO()
    End Function

    Private Sub CBORI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBORI.SelectedIndexChanged
        CARGADATAVIEW(CLARES(CBORI.SelectedIndex), CLAGRU(CBGRU.SelectedIndex))
    End Sub

    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged
        CARGADATAVIEW(CLARES(CBORI.SelectedIndex), CLAGRU(CBGRU.SelectedIndex))
    End Sub
    Private Function CARGAEQUIVALENCIAS() As Boolean
        CLAUNI2.Clear()
        CBUNI.Items.Clear()
        Dim X As Integer
        Dim DRV As DataRowView
        For X = 0 To DV2.Count - 1
            DRV = DV2.Item(X)
            CBUNI.Items.Add(DRV.Item(2))
            CLAUNI2.Add(DRV.Item(1))
        Next
        Try
            CBUNI.SelectedIndex = 0
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function CARGADATAVIEW2(ByVal PRO As String) As Boolean
        DV2 = New DataView(DTE, "PRODUCTO='" + PRO + "'", "NOMBRE", DataViewRowState.CurrentRows)
        Return CARGAEQUIVALENCIAS()
    End Function
    Private Sub CBPRO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBPRO.SelectedIndexChanged
        LBLEXIS.Text = CLAEXIS(CBPRO.SelectedIndex)
        LBLDES.Text = LDES(CBPRO.SelectedIndex)
        CARGADATAVIEW2(CLACP(CBPRO.SelectedIndex))
        'CARGAEQUIVALENCIAS()
        LBLUNI.Text = LNUNI(CBPRO.SelectedIndex)
        TXTCANT.Focus()
    End Sub

    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        Dim X As Integer
        'If CBORI.Text = CBDES.Text Then
        '    MessageBox.Show("La Sucursal Origen y Destino deben ser Diferentes", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        If TXTCANT.Text = "" Then
            MessageBox.Show("Especifique una cantidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TXTCANT.Focus()
            TXTCANT.SelectAll()
            Exit Sub
        End If
        If CType(TXTCANT.Text, Double) <= -1 Then
            MessageBox.Show("Especifique una cantidad mayor a cero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TXTCANT.Focus()
            TXTCANT.SelectAll()
            Exit Sub
        End If
        If Not CARGAEXISTENCIA(CLAPRO(CBPRO.SelectedIndex), CType(TXTCANT.Text, Double), CLAUNI2(CBUNI.SelectedIndex)) Then
            MessageBox.Show("La Cantidad solicitada es mayor que la cantidad en existencia, No se permite agregar, favor de verificar su inventario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTCANT.Text = ""
            TXTCANT.Focus()
            Exit Sub
        End If
        For X = 0 To DGV.Rows.Count - 1
            If CBPRO.Text = DGV.Item(1, X).Value Then
                MessageBox.Show("El producto ya fue agregado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next

        AGREGAR(CLARES(CBORI.SelectedIndex), CBORI.Text, frmPrincipal.SucursalBase, frmPrincipal.NombreComun, CLAPRO(CBPRO.SelectedIndex), CBPRO.Text, CType(TXTCANT.Text, Double), CLAUNI2(CBUNI.SelectedIndex), CBUNI.Text, CLAGRUP(CBPRO.SelectedIndex))
        TXTCANT.Text = ""
        TXTCANT.Focus()
        CHECATABLA()
    End Sub
    Private Sub AGREGAR(ByVal CORI As String, ByVal ORI As String, ByVal CDES As String, ByVal DES As String, ByVal CPRO As String, ByVal PRO As String, ByVal CANT As Double, ByVal CUNI As String, ByVal UNI As String, ByVal GRU As String)
        Dim DOW As System.Data.DataRow = DT.NewRow
        DOW(0) = CORI
        'DOW(1) = CDES
        DOW(1) = CPRO
        DOW(2) = GRU
        DOW(3) = CUNI
        DT.Rows.Add(DOW)
        'LGRU.Add(GRU)
        'LPRO.Add(CPRO)
        'LUNI.Add(CUNI)
        DGV.Rows.Add(1)
        Dim ITEMS As Integer
        ITEMS = DGV.Rows.Count - 1
        DGV.Item(0, ITEMS).Value = ORI
        'DGV.Item(1, ITEMS).Value = DES
        DGV.Item(1, ITEMS).Value = PRO
        DGV.Item(2, ITEMS).Value = CANT
        DGV.Item(3, ITEMS).Value = UNI
        DGV.Refresh()

        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Refresh()
        CHECATABLA()
    End Sub
    Private Function CALCANT(ByVal PRO As String, ByVal CANT As Double, ByVal UNI As String) As Double
        If Not frmPrincipal.CHECACONX Then
            Return 0
        End If
        Dim REG As Double
        REG = 0
        Dim SQL2 As New SqlClient.SqlCommand("SELECT DBO.TOTALUNIDADMINIMATIENDA('" + PRO + "'," + CANT.ToString + ",'" + UNI + "')", frmPrincipal.CONX)
        Dim LEC2 As SqlClient.SqlDataReader
        LEC2 = SQL2.ExecuteReader
        If LEC2.Read Then
            REG = LEC2(0)
        End If
        LEC2.Close()
        Return REG
    End Function
    Private Function LOAGREGADO(ByVal PRO As String) As Double
        Dim X As Integer
        Dim TA As Double
        TA = 0
        For X = 0 To LPRO.Count - 1
            If LPRO(X) = PRO Then
                TA = TA + CALCANT(PRO, DGV.Item(3, X).Value, LUNI(X))
            End If
        Next
        Return TA
    End Function
    Private Function CARGAEXISTENCIA(ByVal PRO As String, ByVal CANT As Double, ByVal UNI As String) As Boolean
        If Not frmPrincipal.CHECACONX Then
            Return False
        End If
        LBLEXIS.Text = CLAEXIS(CBPRO.SelectedIndex).ToString
        'LBLUNI2.Text = CLAUNI2(CBUNI.SelectedIndex).ToString
        Dim CANTEXIS As Double
        CANTEXIS = CLAEXIS(CBPRO.SelectedIndex)

        Dim CANTSOLI As Double
        CANTSOLI = 0
        If LBLUNI.Text <> CBUNI.Text Then
            Dim SQL2 As New SqlClient.SqlCommand("SELECT DBO.TOTALUNIDADMINIMATIENDA('" + PRO + "'," + CANT.ToString + ",'" + UNI + "')", frmPrincipal.CONX)
            Dim LEC2 As SqlClient.SqlDataReader
            LEC2 = SQL2.ExecuteReader
            If LEC2.Read Then
                CANTSOLI = LEC2(0)
            End If
            LEC2.Close()
        Else
            CANTSOLI = CANT
        End If
        Dim AGREGADO As Double
        AGREGADO = LOAGREGADO(PRO)
        If (CANTSOLI + AGREGADO) > CANTEXIS Then
            Return False
        End If
        Return True
    End Function

    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        REGRESARUNO(DT.Rows(DGV.CurrentRow.Index).Item(2), DT.Rows(DGV.CurrentRow.Index).Item(1), DGV.Item(2, DGV.CurrentRow.Index).Value, DT.Rows(DGV.CurrentRow.Index).Item(3))
       
        DT.Rows.RemoveAt(DGV.CurrentRow.Index)
        DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
        DGV.Refresh()
        CHECATABLA()
        TXTCANT.Focus()
        TXTCANT.SelectAll()
    End Sub
    Private Sub REGRESARUNO(ByVal GRU As String, ByVal PRO As String, ByVal CANT As Double, ByVal UNI As String)
        Dim X As Integer
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        For X = 0 To CBGRU.Items.Count - 1
            If CLAGRU(X) = GRU Then
                CBGRU.SelectedIndex = X
            End If
        Next
        For X = 0 To CBPRO.Items.Count - 1
            If CLAPRO(X) = PRO Then
                CBPRO.SelectedIndex = X
            End If
        Next
        TXTCANT.Text = CANT.ToString
        For X = 0 To CBUNI.Items.Count - 1
            If CLAUNI2(X) = UNI Then
                CBUNI.SelectedIndex = X
            End If
        Next
    End Sub
    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Esta seguro que desea eliminar TODOS los elementos agregados?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If xyz = 6 Then
            DT.Rows.Clear()
            DGV.Rows.Clear()
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
    Private Sub GUARDAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim ND As Integer
        ND = CARGADECOMISO()
        LBLDECOM.Text = ND.ToString
        Dim X As Integer
        Dim ABC As String

        Dim SQLD As New SqlClient.SqlCommand("AGREGADECOMISO", frmPrincipal.CONX)
        SQLD.CommandType = CommandType.StoredProcedure
        SQLD.Parameters.Add("@NODECOM", SqlDbType.Int)
        SQLD.Parameters.Add("@ORI", SqlDbType.VarChar)
        SQLD.Parameters.Add("@DES", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQLD.Parameters.Add("@PROD", SqlDbType.VarChar)
        SQLD.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        SQLD.Parameters.Add("@CANT", SqlDbType.Float)
        SQLD.Parameters.Add("@UNI", SqlDbType.VarChar)
        SQLD.Parameters.Add("@REG", SqlDbType.Int)


        SQLD.Parameters("@NODECOM").Value = ND
        For X = 0 To DGV.Rows.Count - 1
            SQLD.Parameters("@ORI").Value = DT.Rows(X).Item(0).ToString
            ABC = DT.Rows(X).Item(1).ToString
            SQLD.Parameters("@PROD").Value = DT.Rows(X).Item(1).ToString
            ABC = DT.Rows(X).Item(2).ToString
            SQLD.Parameters("@CANT").Value = DGV.Item(2, X).Value
            SQLD.Parameters("@UNI").Value = DT.Rows(X).Item(3).ToString
            ABC = DT.Rows(X).Item(0).ToString
            SQLD.Parameters("@REG").Value = X
            SQLD.ExecuteNonQuery()
        Next

        MessageBox.Show("La información ha sido guardada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        DT.Clear()
        DGV.Rows.Clear()
        DT.Rows.Clear()
        LGRU.Clear()
        LPRO.Clear()
        LUNI.Clear()
        CARGADECOMISO()
    End Sub

    Private Sub BTNBUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUS.Click
        frmClsBusqueda.BUSCAR("SELECT D.PRODUCTO,D.GRUPO,D.TIENDA CLATIENDA,T.NOMBRECOMUN TIENDA,D.CANTIDAD,D.NOMBRE,D.DESCRIPCION FROM EXISTENCIAENTIENDAS D INNER JOIN TIENDAS T ON D.TIENDA=T.CLAVE", " WHERE D.NOMBRE", " ORDER BY D.NOMBRE", "Búsqueda de Productos para Solicitar Traspasos", "Nombre del Producto", "Registro(s)", 6, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            OPCargaX(CLARES, CBORI, frmClsBusqueda.TREG.Rows(0).Item(2))
            OPCargaX(CLAGRU, CBGRU, frmClsBusqueda.TREG.Rows(0).Item(1))
            OPCargaX(CLAPRO, CBPRO, frmClsBusqueda.TREG.Rows(0).Item(0))
        End If
    End Sub

    Private Sub frmTraspasos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT PRODUCTO,GRUPO,TIENDA,CANTIDAD,NOMBRE,DESCRIPCION,UVENTA,UNIDAD,CP FROM EXISTENCIAENTIENDAS  ", " WHERE NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Productos", "Nombre del Producto", "Productos(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLAGRU, CBGRU, frmClsBusqueda.TREG.Rows(0).Item(1).ToString)
                OPCargaX(CLAPRO, CBPRO, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
    End Sub
End Class