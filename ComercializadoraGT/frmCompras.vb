Public Class frmCompras
    Dim CLAPRO As String
    Dim NOMPRO As String
    Dim NUMFAC As String
    Dim CLIENTE As String
    Dim CLAPROD As New List(Of String)
    Dim CLAGRU As New List(Of String)
    Dim LPCT As New List(Of Double)
    Dim LUNI As New List(Of String)
    Dim LREG As New List(Of Integer)
    Dim LCOS As New List(Of Double)
    Dim LPRE As New List(Of Double)
    Dim LINV As New List(Of Boolean)
    Dim LUNICP As New List(Of String)
    Dim TABLAPRIN As New DataTable
    Dim TABLATOTALES As New DataTable


    Dim LDES As New List(Of String)
    Dim LCP As New List(Of String)
    Dim LIVA As New List(Of Boolean)
    Dim LUDC As New List(Of String)
    Dim TABLALOTES As New DataTable
    Dim CLAUNI As New List(Of String)
    Dim DV2 As New DataView
    Dim DV As New DataView
    Dim ESNOTA As Boolean
    Dim APLICAIVA As Boolean
    Dim ELCONCEPTO As String
    Dim VTOT, VSUB, VIVA As Double
    Dim CLAGRUGR As New List(Of String)
    Public DT As New DataTable
    Public DA As New SqlClient.SqlDataAdapter
    Public DT2 As New DataTable
    Public DA2 As New SqlClient.SqlDataAdapter
    Dim SIGREG As Integer
    Dim LCANT As New List(Of Double)
    Dim LCANT2 As New List(Of Double)
    Dim LALM As New List(Of String)
    Dim DM As Boolean = False
    Dim CPRODUCTO As String
    Dim CGRUPO As String
    Private Sub frmCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        If DM Then
            If Not frmPrincipal.CHECACONX Then
                Exit Sub
            End If
            'PONEULTIMOCOSTO()
            If frmPrincipal.SucursalBase = "PM" Or frmPrincipal.SucursalBase = "PRUEBAS" Or frmPrincipal.SucursalBase = "BPM" Or frmPrincipal.SucursalBase = "LOZA" Or frmPrincipal.SucursalBase = "ST" Then
                OPLlenaComboBox(CBALM, LALM, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE CLAVE='BPM' OR CLAVE='LOZA' OR CLAVE='PM' ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion)
            Else
                OPLlenaComboBox(CBALM, LALM, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE CLAVE='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CadenaConexion)
            End If

            If NOHAYENULTIMOCOSTO() Then
                PONEULTIMOCOSTO()
            End If
            DT = BDLlenatabla("SELECT P.CLAVE,P.NOMBRE,P.GRUPO,P.DESCRIPCION,P.PRECIO,P.CP,P.UVENTA,P.IVA,isnull(U.COSTO,0.00)COSTO FROM PRODUCTOS P LEFT JOIN TABLAULTIMOCOSTO U ON U.CLAVE=P.CP WHERE ACTIVO=1 AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + LALM(CBALM.SelectedIndex) + "'  AND ACTIVO=1)", frmPrincipal.CadenaConexion)
            DT2 = BDLlenatabla("SELECT E.PRODUCTO,G.CLAVE,E.UNIDAD2,U.NOMBRE,E.CANTIDAD,E.CANTIDAD2  FROM EQUIVALENCIAS E INNER JOIN PRODUCTOS P  ON E.UNIDAD2=P.UVENTA AND P.CP=E.PRODUCTO INNER JOIN UNIDADES U  ON E.UNIDAD2=U.CLAVE INNER JOIN GRUPOS G ON G.CLAVE=P.GRUPO", frmPrincipal.CadenaConexion)

            If Not CARGAGRUPOS() Then
                MessageBox.Show("Favor de Agregar Grupos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                CBGRU.SelectedIndex = 0
            End If

            TABLALOTES.Columns.Add("Lote")
            TABLALOTES.Columns.Add("Producto")
            TABLALOTES.Columns.Add("Grupo")
            TABLALOTES.Columns.Add("Fecha")
            TABLALOTES.Columns.Add("Costo")
            TABLALOTES.Columns.Add("Precio")
            TABLALOTES.Columns.Add("Ganancia")
            TABLALOTES.Columns.Add("CostoU")
            TABLALOTES.Columns.Add("PrecioU")
            TABLALOTES.Columns.Add("Proveedor")
            TABLALOTES.Columns.Add("Origen")
            TABLALOTES.Columns.Add("Año")
            TABLALOTES.Columns.Add("Semana")
            TABLALOTES.Columns.Add("Registro")
            TABLALOTES.Columns.Add("Iva")
            TABLALOTES.Columns.Add("CP")

            TXTPED.Enabled = CHK1.Checked
            'TABLAPRIN.Columns.Add("LOTE")
            'TABLAPRIN.Columns.Add("GRUPO")
            'TABLAPRIN.Columns.Add("PRODUCTO")
            'TABLAPRIN.Columns.Add("CANTIDAD")
            'TABLAPRIN.Columns.Add("UNIDAD")
            'TABLAPRIN.Columns.Add("COSTO TOTAL")
            'TABLAPRIN.Columns.Add("TOTAL")
            'TABLAPRIN.Columns.Add("ORIGEN")
            'TABLAPRIN.Columns.Add("COSTO UNITARIO")

            TABLATOTALES.Columns.Add("SUBTOTAL")
            TABLATOTALES.Columns.Add("IVA")
            TABLATOTALES.Columns.Add("TOTAL")
            TXTNOCOMPRA.Text = CARGANOCOMPRA.ToString
            TXTDESC.Text = "0"
            Me.Text = "Compras de Tienda"
            CHECATABLA()
            CARGAELGRUPO(CGRUPO)
            CARGAELPRODUCTO(CPRODUCTO)
            TXTCANT.Focus()
            TXTCANT.SelectAll()
            TXTCANT.Focus()
            TXTCANT.SelectAll()
        Else
            If Not LLAMACOMPRAS() Then
                Me.Close()
            Else
                If Not frmPrincipal.CHECACONX Then
                    Exit Sub
                End If
                'PONEULTIMOCOSTO()
                If frmPrincipal.SucursalBase = "PM" Or frmPrincipal.SucursalBase = "PRUEBAS" Or frmPrincipal.SucursalBase = "BPM" Or frmPrincipal.SucursalBase = "LOZA" Or frmPrincipal.SucursalBase = "ST" Then
                    OPLlenaComboBox(CBALM, LALM, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE CLAVE='BPM' OR CLAVE='LOZA' OR CLAVE='PM' ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion)
                Else
                    OPLlenaComboBox(CBALM, LALM, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE CLAVE='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CadenaConexion)
                End If

                If NOHAYENULTIMOCOSTO() Then
                    PONEULTIMOCOSTO()
                End If
                DT = BDLlenatabla("SELECT P.CLAVE,P.NOMBRE,P.GRUPO,P.DESCRIPCION,P.PRECIO,P.CP,P.UVENTA,P.IVA,isnull(U.COSTO,0.00)COSTO FROM PRODUCTOS P LEFT JOIN TABLAULTIMOCOSTO U ON U.CLAVE=P.CP WHERE ACTIVO=1 AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + LALM(CBALM.SelectedIndex) + "'  AND ACTIVO=1)", frmPrincipal.CadenaConexion)
                DT2 = BDLlenatabla("SELECT E.PRODUCTO,G.CLAVE,E.UNIDAD2,U.NOMBRE,E.CANTIDAD,E.CANTIDAD2  FROM EQUIVALENCIAS E INNER JOIN PRODUCTOS P  ON E.UNIDAD2=P.UVENTA AND P.CP=E.PRODUCTO INNER JOIN UNIDADES U  ON E.UNIDAD2=U.CLAVE INNER JOIN GRUPOS G ON G.CLAVE=P.GRUPO", frmPrincipal.CadenaConexion)

                If Not CARGAGRUPOS() Then
                    MessageBox.Show("Favor de Agregar Grupos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    CBGRU.SelectedIndex = 0
                End If

                TABLALOTES.Columns.Add("Lote")
                TABLALOTES.Columns.Add("Producto")
                TABLALOTES.Columns.Add("Grupo")
                TABLALOTES.Columns.Add("Fecha")
                TABLALOTES.Columns.Add("Costo")
                TABLALOTES.Columns.Add("Precio")
                TABLALOTES.Columns.Add("Ganancia")
                TABLALOTES.Columns.Add("CostoU")
                TABLALOTES.Columns.Add("PrecioU")
                TABLALOTES.Columns.Add("Proveedor")
                TABLALOTES.Columns.Add("Origen")
                TABLALOTES.Columns.Add("Año")
                TABLALOTES.Columns.Add("Semana")
                TABLALOTES.Columns.Add("Registro")
                TABLALOTES.Columns.Add("Iva")
                TABLALOTES.Columns.Add("CP")

                TXTPED.Enabled = CHK1.Checked
                'TABLAPRIN.Columns.Add("LOTE")
                'TABLAPRIN.Columns.Add("GRUPO")
                'TABLAPRIN.Columns.Add("PRODUCTO")
                'TABLAPRIN.Columns.Add("CANTIDAD")
                'TABLAPRIN.Columns.Add("UNIDAD")
                'TABLAPRIN.Columns.Add("COSTO TOTAL")
                'TABLAPRIN.Columns.Add("TOTAL")
                'TABLAPRIN.Columns.Add("ORIGEN")
                'TABLAPRIN.Columns.Add("COSTO UNITARIO")

                TABLATOTALES.Columns.Add("SUBTOTAL")
                TABLATOTALES.Columns.Add("IVA")
                TABLATOTALES.Columns.Add("TOTAL")
                TXTNOCOMPRA.Text = CARGANOCOMPRA.ToString
                TXTDESC.Text = "0"
                Me.Text = "Compras de Tienda"
                CHECATABLA()
            End If
        End If
      
    End Sub
    Private Function NOHAYENULTIMOCOSTO() As Boolean
        If Not frmPrincipal.CHECACONX() Then
            Return False
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT COUNT(CLAVE) FROM ULTIMOCOSTOPRODUCTOS", frmPrincipal.CONX)
        SQL.CommandTimeout = 300
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        Dim CUANTOS As Double
        CUANTOS = 0
        If LEC.Read Then
            CUANTOS = LEC(0)
        End If
        LEC.Close()
        If CUANTOS <= 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function PONEULTIMOCOSTO() As Boolean
        If Not frmPrincipal.CHECACONX() Then
            Return False
        End If
        Dim SQL As New SqlClient.SqlCommand("PONEULTIMOCOSTO", frmPrincipal.CONX)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.CommandTimeout = 300
        Try
            SQL.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTCANT.Enabled = V
        TXTCOS.Enabled = V
        TXTDESC.Enabled = V
        CBUNI.Enabled = V
        BTNAGREGAR.Enabled = V
    End Sub
    Public Sub MOSTRAR(ByVal TV As String, ByVal VPRO As String)
        DM = True
        CLAPRO = "1"
        NOMPRO = "PUBLICO EN GENERAL"
        ESNOTA = True
        APLICAIVA = True
        NUMFAC = ""
        ELCONCEPTO = ""
        LBLPRO.Text = "Entrada por compra para venta: " + TV
        LBLNOTFAC.Text = TV
        CPRODUCTO = VPRO

        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        Else
            Dim SQL As New SqlClient.SqlCommand("SELECT GRUPO FROM PRODUCTOS WHERE CLAVE='" + CPRODUCTO + "'", frmPrincipal.CONX)
            Dim LEC As SqlClient.SqlDataReader
            LEC = SQL.ExecuteReader
            If LEC.Read Then
                CGRUPO = LEC(0)
            End If
            LEC.Close()
            SQL.Dispose()
        End If
        If ESNOTA Then
            LBLFACNOT.Text = "Nota"
        Else
            LBLFACNOT.Text = "Factura"
        End If
        TXTCANT.Focus()
        TXTCANT.SelectAll()
        Me.ShowDialog()
    End Sub
    Private Function LLAMACOMPRAS() As Boolean

        Me.Opacity = 25
        Dim VNV As New frmEntrarCompras
        VNV.ShowDialog()
        If VNV.DialogResult = Windows.Forms.DialogResult.Yes Then
            CLAPRO = VNV.CLAVEPRO
            NOMPRO = VNV.NOMPRO
            ESNOTA = VNV.ESNOTA
            APLICAIVA = VNV.APLICAIVA
            NUMFAC = VNV.NOTAFAC
            ELCONCEPTO = VNV.CONCEPTO
            LBLPRO.Text = NOMPRO
            LBLNOTFAC.Text = NUMFAC
            
            If ESNOTA Then
                LBLFACNOT.Text = "Nota"
            Else
                LBLFACNOT.Text = "Factura"
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Private Function CARGANOCOMPRA() As Integer
        Try
            If Not frmPrincipal.CHECACONX() Then
                Exit Function
            End If
            Dim NUM As Integer
            NUM = 1
            Dim SQLMOV As New SqlClient.SqlCommand("SELECT DBO.SIGUIENTECOMPRA('" + LALM(CBALM.SelectedIndex) + "')", frmPrincipal.CONX)
            Dim LECTOR As SqlClient.SqlDataReader
            LECTOR = SQLMOV.ExecuteReader
            If LECTOR.Read Then
                NUM = LECTOR(0)
                LECTOR.Close()
                Return NUM
            Else
                LECTOR.Close()
                Return NUM
            End If
        Catch ex As Exception
            Me.Close()
        End Try
    End Function
    Private Function CARGAGRUPOS() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Return False
        End If
        OPLlenaComboBox(CBGRU, CLAGRU, "SELECT CLAVE,NOMBRE FROM GRUPOS WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBGRU.Items.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Private Function CARGADATAVIEW(ByVal GRUPO As String) As Boolean
        DV = New DataView(DT, " GRUPO='" + GRUPO + "' ", "NOMBRE", DataViewRowState.CurrentRows)
        Return CARGAPRODUCTOS()
    End Function
    Private Function CARGADATAVIEW2(ByVal PRO As String) As Boolean
        DV2 = New DataView(DT2, " PRODUCTO='" + PRO + "'", "NOMBRE", DataViewRowState.CurrentRows)
        Return CARGAEQUIVALENCIAS()
    End Function
    Private Function CARGAEQUIVALENCIAS() As Boolean
        CLAUNI.Clear()
        CBUNI.Items.Clear()
        LCANT.Clear()
        LCANT2.Clear()
        Dim X As Integer
        Dim DRV As DataRowView
        For X = 0 To DV2.Count - 1
            DRV = DV2.Item(X)
            CBUNI.Items.Add(DRV.Item(3))
            CLAUNI.Add(DRV.Item(2))
            LCANT.Add(DRV.Item(4))
            LCANT2.Add(DRV.Item(5))
        Next
        Try
            CBUNI.SelectedIndex = 0
            'DESPLIEGAPRECIOU()
            Return True
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            Return False
        End Try
       


    End Function
    Private Function CARGAPRODUCTOS() As Boolean
        CBPROD.Items.Clear()
        CLAPROD.Clear()
        LCOS.Clear()
        LPRE.Clear()
        LDES.Clear()
        LIVA.Clear()
        LUDC.Clear()
        LCP.Clear()

        Dim X As Integer
        Dim DRV As DataRowView
        For X = 0 To DV.Count - 1
            DRV = DV.Item(X)
            CLAPROD.Add(DRV.Item(0))
            CBPROD.Items.Add(DRV.Item(1))
            LDES.Add(DRV.Item(3))
            LPRE.Add(DRV.Item(4))
            LCP.Add(DRV.Item(5))
            LUDC.Add(DRV.Item(6))
            LIVA.Add(DRV.Item(7))
            LCOS.Add(DRV.Item(8))
        Next
        Try
            CBPROD.SelectedIndex = 0
            Return True
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
    Private Function PRODUCTOAGREGADO(ByVal PRO As String) As Boolean
        Dim X As Integer
        Dim valor As String
        For X = 0 To TABLALOTES.Rows.Count - 1
            valor = TABLALOTES.Rows(X).Item(1).ToString
            If TABLALOTES.Rows(X).Item(1).ToString = PRO Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        CHECAAGREGAR()
    End Sub
    Private Function CALCULAPRECIOU() As Double
        Try
            Dim C1, PRECIO, CANT As Double
            Dim C2 As Double
            C1 = LCANT(CBUNI.SelectedIndex)
            C2 = LCANT2(CBUNI.SelectedIndex)
            PRECIO = CType(LBLPRE.Text, Double)
            CANT = CType(TXTCANT.Text, Double)
            Dim REG As Double
            REG = PRECIO / ((CANT / C1) * C2)
            REG = Math.Round(REG, 3)
            Return REG
        Catch ex As Exception
        End Try
    End Function
    Private Sub AGREGAR(ByVal LOTE As String, ByVal GRUPO As String, ByVal PRODUCTO As String, ByVal CANTIDAD As String, ByVal UNIDAD As String, ByVal CU As Double, ByVal COSTO As Double, ByVal PRO As String, ByVal GANANCIA As Double, ByVal PRECIO As Double, ByVal FECHA As String, ByVal ORIGEN As String, ByVal PU As Double, ByVal REG As Integer, ByVal PRODUCTOIVA As Boolean, ByVal CP As String, ByVal CLAGRUP As String, ByVal DESC As Double, ByVal CLAVEUNIDAD As String)
        Dim DOW As System.Data.DataRow = TABLAPRIN.NewRow
        DGV.Rows.Add(1)
        Dim ITEMS As Integer
        ITEMS = DGV.Rows.Count - 1

        Dim ELCU As Double
        ELCU = 0
        If PRODUCTOIVA Then
            'If ESNOTA Then
            If APLICAIVA Then
                ELCU = CU / (1 + (frmPrincipal.IVA))
            Else
                ELCU = CU
            End If
            'End If
            'If Not ESNOTA Then
            '    If APLICAIVA Then
            '        ELCU = CU * (1 + (frmPrincipal.IVA))
            '    Else
            '        ELCU = CU
            '    End If
            'End If
        Else
            ELCU = CU
        End If
        COSTO = COSTO - DESC
        If PRODUCTOIVA Then
            'If ESNOTA Then
            If APLICAIVA Then
                DGV.Item(7, ITEMS).Value = COSTO / (1 + (frmPrincipal.IVA))
            Else
                DGV.Item(7, ITEMS).Value = COSTO
            End If
            'End If
            'If Not ESNOTA Then
            '    If APLICAIVA Then
            '        DGV.Item(6, ITEMS).Value = COSTO * (1 + (frmPrincipal.IVA))
            '    Else
            '        DGV.Item(6, ITEMS).Value = COSTO
            '    End If
            'End If
        Else
            DGV.Item(7, ITEMS).Value = COSTO
        End If


        DGV.Item(0, ITEMS).Value = LOTE
        DGV.Item(1, ITEMS).Value = GRUPO
        DGV.Item(2, ITEMS).Value = PRODUCTO
        DGV.Item(3, ITEMS).Value = CANTIDAD
        DGV.Item(4, ITEMS).Value = UNIDAD
        DGV.Item(5, ITEMS).Value = DESC
        DGV.Item(6, ITEMS).Value = ELCU


        ' TABLAPRIN.Rows.Add(DOW)

        Dim SUBT, IVAT, TOTT As Double
        Dim TDOW As System.Data.DataRow = TABLATOTALES.NewRow

        If PRODUCTOIVA Then
            'If ESNOTA Then
            If APLICAIVA Then
                SUBT = COSTO / (1 + (frmPrincipal.IVA))
            Else
                SUBT = COSTO
            End If
            'End If
            'If Not ESNOTA Then
            '    If Not APLICAIVA Then
            '        SUBT = COSTO / (1 + (frmPrincipal.IVA))
            '    Else
            '        SUBT = COSTO
            '    End If
            'End If
            IVAT = SUBT * (frmPrincipal.IVA) '' k es iva t ??
        Else
            'If ESNOTA Then
            '    If Not APLICAIVA Then
            '        SUBT = COSTO / (1 + (frmPrincipal.IVA))
            '    Else
            '        SUBT = COSTO
            '    End If
            'End If
            'If Not ESNOTA Then
            '    If Not APLICAIVA Then
            '        SUBT = COSTO / (1 + (frmPrincipal.IVA))
            '    Else
            SUBT = COSTO
            'End If
            '    End If
            'IVAT = SUBT * (frmPrincipal.IVA)
            IVAT = 0
        End If

        TOTT = SUBT + IVAT
        'TOTT = SUBT + IVAT
        TOTT = Math.Round(TOTT, 2)
        IVAT = Math.Round(IVAT, 2)

        TDOW(0) = SUBT
        TDOW(1) = IVAT
        TDOW(2) = TOTT
        TABLATOTALES.Rows.Add(TDOW)

        Dim LDOW As System.Data.DataRow = TABLALOTES.NewRow
        LDOW(0) = LOTE
        LDOW(1) = CP
        LDOW(2) = CLAGRUP
        LDOW(3) = DTFECHA.Value.Date.ToString
        LDOW(4) = COSTO
        LDOW(5) = PRECIO
        LDOW(6) = GANANCIA
        LDOW(7) = CLAPRO
        LDOW(8) = 0
        LDOW(9) = DTFECHA.Value.Year
        LDOW(10) = CALCULASEMANA(DTFECHA.Value.Date)
        LDOW(11) = ELCU
        LDOW(12) = ELCU
        LDOW(13) = REG
        LDOW(14) = PRODUCTOIVA
        LDOW(15) = CP
        TABLALOTES.Rows.Add(LDOW)
        LUNI.Add(CLAVEUNIDAD)


        'DGV.DataSource = TABLAPRIN
        DGV.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable

        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DGV.Refresh()
        CHECATABLA()
        TXTCANT.Focus()
        TXTCANT.SelectAll()
    End Sub
    Private Sub CHECATABLA()
        VTOT = 0
        VSUB = 0
        VIVA = 0
        If DGV.Rows.Count = 0 Then
            BTNQUITAR.Enabled = False
            BTNCANCELAR.Enabled = False
            BTNGUARDAR.Enabled = False
            TXTCANT.Text = ""
            TXTCOS.Text = ""
            'BTNBUS.Enabled = False
        Else
            Dim X As Integer
            For X = 0 To TABLATOTALES.Rows.Count - 1
                VSUB = VSUB + TABLATOTALES.Rows(X).Item(0)
                VIVA = VIVA + TABLATOTALES.Rows(X).Item(1)
                VTOT = VTOT + TABLATOTALES.Rows(X).Item(2)
            Next
            BTNBUS.Enabled = True
            BTNGUARDAR.Enabled = True
            BTNQUITAR.Enabled = True
            BTNCANCELAR.Enabled = True
        End If
        LBLTS.Text = FormatNumber(VSUB, 2).ToString
        LBLTI.Text = FormatNumber(VIVA, 2).ToString
        VTOT = Math.Round(VTOT, 2, MidpointRounding.ToEven)
        LBLTF.Text = FormatNumber(VTOT, 2).ToString
        Try
            DGV.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            DGV.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        Catch ex As Exception

        End Try

    End Sub
    Private Sub REGRESARUNO(ByVal GRU As String, ByVal PRO As String, ByVal CANT As Double)
        Dim X As Integer
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim GRUGR As String
        GRUGR = ""
        Dim SQL As New SqlClient.SqlCommand("SELECT GRUPO FROM PRODUCTOS WHERE CP='" + PRO + "' AND GRUPO='" + GRU + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            GRUGR = LEC(0)
        End If
        LEC.Close()
        For X = 0 To CBGRU.Items.Count - 1
            If CLAGRU(X) = GRUGR Then
                CBGRU.SelectedIndex = X
            End If
        Next
        For X = 0 To CBPROD.Items.Count - 1
            If LCP(X) = PRO Then
                CBPROD.SelectedIndex = X
            End If
        Next
        TXTCANT.Text = CANT.ToString
    End Sub

  
    Private Sub GUARDAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        CHECATABLA()
        If CHK1.Checked = False Then
            TXTPED.Text = "N/A"
        End If
        'Dim TRAN As SqlClient.SqlTransaction

        Dim SQLGUARDALOTES As New SqlClient.SqlCommand("INSERT INTO LOTES (CLAVE,PRODUCTO,FECHA,COSTO,PRECIO,PROVEEDOR,AÑO,SEMANA,REGISTRO,GANANCIA,ORIGEN,COSTOU,PRECIOU) VALUES (@CLA,@PRO,GETDATE(),@COS,@PRE,@PROO,@AÑO,@SEM,@REG,@GAN,@ORI,@CU,@PU)", frmPrincipal.CONX)
        SQLGUARDALOTES.CommandTimeout = 300
        '(@CLA,@PRO,@GRU,GETDATE(),@COS,@PRE,@PROO,@AÑO,@SEM,@REG,@GAN,@ORI)", frmPrincipal.CONX)
        SQLGUARDALOTES.Parameters.Add("@CLA", SqlDbType.VarChar)
        SQLGUARDALOTES.Parameters.Add("@PRO", SqlDbType.VarChar)
        'SQLGUARDALOTES.Parameters.Add("@GRU", SqlDbType.VarChar)
        SQLGUARDALOTES.Parameters.Add("@COS", SqlDbType.Float)
        SQLGUARDALOTES.Parameters.Add("@PRE", SqlDbType.Float)
        SQLGUARDALOTES.Parameters.Add("@PROO", SqlDbType.VarChar)
        SQLGUARDALOTES.Parameters.Add("@AÑO", SqlDbType.Int)
        SQLGUARDALOTES.Parameters.Add("@SEM", SqlDbType.Int)
        SQLGUARDALOTES.Parameters.Add("@REG", SqlDbType.Int)
        SQLGUARDALOTES.Parameters.Add("@GAN", SqlDbType.Float)
        SQLGUARDALOTES.Parameters.Add("@ORI", SqlDbType.VarChar)
        SQLGUARDALOTES.Parameters.Add("@CU", SqlDbType.Float)
        SQLGUARDALOTES.Parameters.Add("@PU", SqlDbType.Float)
        Dim X As Integer
        For X = 0 To TABLALOTES.Rows.Count - 1
            'STR = TABLALOTES.Rows(X).Item(0).ToString
            SQLGUARDALOTES.Parameters("@CLA").Value = TABLALOTES.Rows(X).Item(0).ToString
            'STR = TABLALOTES.Rows(X).Item(1).ToString
            SQLGUARDALOTES.Parameters("@PRO").Value = TABLALOTES.Rows(X).Item(1).ToString
            'STR = TABLALOTES.Rows(X).Item(2).ToString
            'SQLGUARDALOTES.Parameters("@GRU").Value = TABLALOTES.Rows(X).Item(2).ToString
            'STR = TABLALOTES.Rows(X).Item(4).ToString
            SQLGUARDALOTES.Parameters("@COS").Value = TABLALOTES.Rows(X).Item(4).ToString
            'STR = TABLALOTES.Rows(X).Item(5).ToString
            SQLGUARDALOTES.Parameters("@PRE").Value = TABLALOTES.Rows(X).Item(5).ToString
            'STR = TABLALOTES.Rows(X).Item(7).ToString
            SQLGUARDALOTES.Parameters("@PROO").Value = TABLALOTES.Rows(X).Item(7).ToString
            'STR = TABLALOTES.Rows(X).Item(9).ToString
            SQLGUARDALOTES.Parameters("@AÑO").Value = TABLALOTES.Rows(X).Item(9)
            SQLGUARDALOTES.Parameters("@SEM").Value = TABLALOTES.Rows(X).Item(10)
            SQLGUARDALOTES.Parameters("@REG").Value = TABLALOTES.Rows(X).Item(13)
            SQLGUARDALOTES.Parameters("@GAN").Value = TABLALOTES.Rows(X).Item(6)
            SQLGUARDALOTES.Parameters("@ORI").Value = TABLALOTES.Rows(X).Item(8).ToString
            SQLGUARDALOTES.Parameters("@CU").Value = TABLALOTES.Rows(X).Item(11)
            SQLGUARDALOTES.Parameters("@PU").Value = TABLALOTES.Rows(X).Item(12)

            SQLGUARDALOTES.ExecuteNonQuery()

        Next
        SQLGUARDALOTES.Dispose()

        Dim NOCOMPRA As Integer
        NOCOMPRA = CARGANOCOMPRA()
        'TRAN = frmPrincipal.CONX.BeginTransaction(IsolationLevel.RepeatableRead)
        Dim SQLBORRA As New SqlClient.SqlCommand("DELETE FROM COMPRAS WHERE TIENDA='" + LALM(CBALM.SelectedIndex) + "' AND NOORDEN=" + NOCOMPRA.ToString, frmPrincipal.CONX)
        SQLBORRA.CommandTimeout = 300
        SQLBORRA.ExecuteNonQuery()
        SQLBORRA.CommandText = "DELETE FROM DETALLECOMPRAS WHERE TIENDA='" + LALM(CBALM.SelectedIndex) + "' AND NOORDEN=" + NOCOMPRA.ToString
        SQLBORRA.ExecuteNonQuery()
        SQLBORRA.Dispose()

        Dim SQLGUARDACOMPRA As New SqlClient.SqlCommand("INSERT INTO COMPRAS (TIENDA,NOORDEN,FACTURA,PROVEEDOR,FECHA,USUARIO,CONCEPTO,SUBTOTAL,IVA,TOTAL,PAGADO,ESNOTA,PEDIMENTO) VALUES ('" + LALM(CBALM.SelectedIndex) + "'," + NOCOMPRA.ToString + ",'" + NUMFAC.ToString + "','" + CLAPRO.ToString + "',GETDATE(),'" + frmPrincipal.Usuario + "','" + ELCONCEPTO.ToString + "'," + VSUB.ToString + "," + VIVA.ToString + "," + VTOT.ToString + ",0,@NF,'" + TXTPED.Text + "')", frmPrincipal.CONX)
        SQLGUARDACOMPRA.CommandTimeout = 300
        SQLGUARDACOMPRA.Parameters.Add("@NF", SqlDbType.Bit)
        If ESNOTA Then
            SQLGUARDACOMPRA.Parameters("@NF").Value = 1
        Else
            SQLGUARDACOMPRA.Parameters("@NF").Value = 0
        End If
        SQLGUARDACOMPRA.ExecuteNonQuery()
        SQLGUARDACOMPRA.Dispose()

        Dim SQLGUARDADETALLECOMPRA As New SqlClient.SqlCommand("INSERT INTO DETALLECOMPRAS (TIENDA,NOORDEN,PRODUCTO,CANTIDAD,UNIDAD,TOTAL,REGISTRO,DESCUENTO)VALUES (@TI,@NOO,@PRO,@CANT,@UNI,@TOT,@REG,@DESC)", frmPrincipal.CONX)
        SQLGUARDADETALLECOMPRA.CommandTimeout = 300
        SQLGUARDADETALLECOMPRA.Parameters.Add("@TI", SqlDbType.VarChar, 10)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@NOO", SqlDbType.Int)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@PRO", SqlDbType.VarChar, 50)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@CANT", SqlDbType.Float)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@TOT", SqlDbType.Float)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@REG", SqlDbType.Int)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@UNI", SqlDbType.Int)
        SQLGUARDADETALLECOMPRA.Parameters.Add("@DESC", SqlDbType.Float)


        SQLGUARDADETALLECOMPRA.Parameters("@TI").Value = LALM(CBALM.SelectedIndex)
        SQLGUARDADETALLECOMPRA.Parameters("@NOO").Value = NOCOMPRA
        Dim L, d As String
        Dim U, C As Integer
        L = DGV.Item(0, 0).Value.ToString

        For X = 0 To DGV.Rows.Count - 1
            U = LUNI(X)
            d = TABLALOTES.Rows(X).Item(0)
            C = DGV.Item(3, X).Value.ToString
            SQLGUARDADETALLECOMPRA.Parameters("@PRO").Value = d
            SQLGUARDADETALLECOMPRA.Parameters("@CANT").Value = DGV.Item(3, X).Value.ToString
            SQLGUARDADETALLECOMPRA.Parameters("@TOT").Value = DGV.Item(7, X).Value.ToString
            SQLGUARDADETALLECOMPRA.Parameters("@UNI").Value = U
            SQLGUARDADETALLECOMPRA.Parameters("@REG").Value = X
            SQLGUARDADETALLECOMPRA.Parameters("@DESC").Value = DGV.Item(5, X).Value.ToString
            'Try
            SQLGUARDADETALLECOMPRA.ExecuteNonQuery()

            'Catch ex As Exception
            'MessageBox.Show(ex.Message)
            'End Try
        Next
        SQLGUARDADETALLECOMPRA.Dispose()

        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea imprimir el ticket de compra?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If xyz = 6 Then
            IMPRIMIR(NOCOMPRA)
        End If




        Dim SP As New SqlClient.SqlCommand("SPPEDIMENTOSCOMPRAS", frmPrincipal.CONX)
        SP.CommandType = CommandType.StoredProcedure
        SP.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SP.Parameters.Add("@NOO", SqlDbType.Int).Value = NOCOMPRA
        SP.ExecuteNonQuery()
        MessageBox.Show("La información ha sido guardada exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        TABLAPRIN.Rows.Clear()
        TABLALOTES.Rows.Clear()
        TABLATOTALES.Clear()
        DGV.Rows.Clear()
        DGV.Refresh()
        CHECATABLA()
        TXTCANT.Text = ""
        TXTCOS.Text = ""
        TXTNOCOMPRA.Text = CARGANOCOMPRA()

        If DM Then
            Me.DialogResult = Windows.Forms.DialogResult.Yes
            Me.Close()
            Exit Sub
        End If
        If Not LLAMACOMPRAS() Then
            Me.DialogResult = Windows.Forms.DialogResult.Yes
            Me.Close()
        End If
    End Sub
    Private Sub IMPRIMIR(ByVal NOCOMPRA As Integer)
        Dim QUERY As String
        Dim REP As New rptTicketCompra
        QUERY = "SELECT T.NOMBRECOMUN TIENDA,D.NOORDEN,PR.NOMBRE PROVEEDOR,C.FECHA,P.NOMBRE PRODUCTO,D.CANTIDAD,U.NOMBRE UNIDAD,D.TOTAL,C.SUBTOTAL,C.IVA,C.TOTAL TOTALCOMPRA FROM COMPRAS C INNER JOIN DETALLECOMPRAS D ON C.TIENDA=D.TIENDA AND C.NOORDEN=D.NOORDEN INNER JOIN LOTES L ON L.CLAVE=D.PRODUCTO INNER JOIN PRODUCTOS P  ON P.CP=L.PRODUCTO INNER JOIN UNIDADES U ON U.CLAVE=D.UNIDAD INNER JOIN TIENDAS T ON T.CLAVE=C.TIENDA INNER JOIN  PROVEEDORES PR  ON P.EMPRESA=T.EMPRESA AND PR.CLAVE=C.PROVEEDOR WHERE C.NOORDEN='" + NOCOMPRA.ToString + "'  AND C.TIENDA='" + LALM(CBALM.SelectedIndex) + "' ORDER BY D.REGISTRO"
        IMPRIMIRREPORTE(REP, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), 1, "")
    End Sub
    Private Function CALCULACOSTOU() As Double
        Dim COSTO, CANT, DESC As Double
        COSTO = CType(TXTCOS.Text, Double)
        CANT = CType(TXTCANT.Text, Double)
        DESC = CType(TXTDESC.Text, Double)
        Dim REG As Double
        COSTO = COSTO - DESC
        REG = COSTO / CANT
        REG = Math.Round(REG, 3)
        Return REG
    End Function
    
    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged
        If Not CARGADATAVIEW(CLAGRU(CBGRU.SelectedIndex)) Then
            MessageBox.Show("No se encuentra asignado ningún producto en este grupo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            CBPROD.Enabled = False
            ACTIVAR(False)
        Else
            CBPROD.Enabled = True
            'ACTIVAR(True)
        End If
    End Sub
    Private Sub CBPROD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBPROD.SelectedIndexChanged
        LBLDES.Text = LDES(CBPROD.SelectedIndex)
        LBLPRE.Text = FormatNumber(LPRE(CBPROD.SelectedIndex), 2).ToString
        LBLCOSTO.Text = FormatNumber(LCOS(CBPROD.SelectedIndex), 2).ToString
        ACTIVAR(True)
        LBLNPRO.Text = CBPROD.Text
        If Not CARGADATAVIEW2(LCP(CBPROD.SelectedIndex)) Then
            MessageBox.Show("No se encuentra asignada ninguna equivalencia a este producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ACTIVAR(False)
        Else
            'CARGAUNIDADDEFAULT()
            'CARGAULTIMOCOSTO()
        End If
    End Sub
    Private Sub CHECAAGREGAR()
        If TXTCOS.Text = "" Then

        Else
            Dim COSTO, CANT, DESC As Double
            Try
                CANT = CType(TXTCANT.Text, Double)
                COSTO = CType(TXTCOS.Text, Double)
                DESC = CType(TXTDESC.Text, Double)
            Catch ex As Exception
                MessageBox.Show("Favor de especificar correctamente la cantidad y el total", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End Try
            frmPrincipal.CHECACONX()

            If PRODUCTOAGREGADO(CLAPROD(CBPROD.SelectedIndex)) Then
                MessageBox.Show("Este producto ya ha sido agregado en esta compra", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            If DESC >= COSTO Then
                MessageBox.Show("La cantidad de descuento es igual o supera el costo de producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                TXTDESC.Focus()
                Exit Sub
            End If

            If TXTCLA.Text = "" Then
                AGREGAR(GENERALOTE(LCP(CBPROD.SelectedIndex), CALCULASEMANA(DTFECHA.Value.Date), DTFECHA.Value.Year), CBGRU.Text, CBPROD.Text, TXTCANT.Text, CBUNI.Text, CALCULACOSTOU, TXTCOS.Text, CLAPROD(CBPROD.SelectedIndex), 0, LBLPRE.Text, DTFECHA.Value.Date.ToString, "Nacional", CALCULAPRECIOU, SIGREG, LIVA(CBPROD.SelectedIndex), LCP(CBPROD.SelectedIndex), CLAGRU(CBGRU.SelectedIndex), TXTDESC.Text, CLAUNI(CBUNI.SelectedIndex))
            Else
                If Not CHECAPROD() Then
                    Exit Sub
                End If
                AGREGAR(GENERALOTE(LCP(CBPROD.SelectedIndex), CALCULASEMANA(DTFECHA.Value.Date), DTFECHA.Value.Year), CBGRU.Text, CBPROD.Text, TXTCANT.Text, CBUNI.Text, CALCULACOSTOU, TXTCOS.Text, CLAPROD(CBPROD.SelectedIndex), 0, LBLPRE.Text, DTFECHA.Value.Date.ToString, "Nacional", CALCULAPRECIOU, SIGREG, LIVA(CBPROD.SelectedIndex), LCP(CBPROD.SelectedIndex), CLAGRU(CBGRU.SelectedIndex), TXTDESC.Text, CLAUNI(CBUNI.SelectedIndex))
            End If

            TXTCANT.Focus()
            TXTCANT.SelectAll()
            TXTCANT.Text = ""
            TXTCOS.Text = ""
            TXTDESC.Text = "0"
            TXTCLA.Text = ""
        End If
    End Sub
    Private Sub TXTCOS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOS.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsPunctuation(e.KeyChar) Then
            e.Handled = False
        End If
        If e.KeyChar = Chr(13) Then
            CHECAAGREGAR()
            BTNBUS.Focus()
        End If
    End Sub
    

    Private Sub TXTCANT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCANT.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsPunctuation(e.KeyChar) Then
            e.Handled = False
        End If

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
    Private Sub frmABCLotes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION,ACTIVO FROM PRODUCTOS WHERE EMPRESA=" + frmPrincipal.Empresa + "  AND ACTIVO=1 AND CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + LALM(CBALM.SelectedIndex) + "' AND ACTIVO=1)", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 2, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(1))
                CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
                TXTCANT.Focus()
                TXTCANT.SelectAll()
            End If
        End If
        If e.KeyCode = Keys.F4 Then
            CHECAAGREGAR()
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
            xyz = MessageBox.Show("¿Esta seguro que desea Eliminar TODOS los elementos Agregados?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xyz = 6 Then
                TABLAPRIN.Rows.Clear()
                LUNI.Clear()
                TABLALOTES.Rows.Clear()
                TABLATOTALES.Rows.Clear()
                DGV.Rows.Clear()
                DGV.Refresh()
                TXTCANT.Text = ""
                TXTCOS.Text = ""
                CHECATABLA()
            End If
        End If
        If e.KeyCode = Keys.F8 Then
            Dim DT As New DataTable
            DT = BDLlenatabla("SELECT dbo.SIGLOTE('CDJ',P.CP)LOTE, G.NOMBRE, P.NOMBRE, CANTIDAD=100, U.NOMBRE, CALCULACOSTOU=3600, TOTAL=360000, P.CLAVE,0 CAMPO, P.PM, GETDATE() FECHA, ORIGEN='Nacional', PRECIOU=3600, P.CLAVE, P.IVA, P.CP, P.GRUPO, DESCUENTO=0,P.UVENTA FROM PRODUCTOS P INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE INNER JOIN UNIDADES U ON P.UVENTA=U.CLAVE ", frmPrincipal.CadenaConexion)
            Dim X As Integer
            For X = 0 To DT.Rows.Count - 1
                AGREGAR(DT.Rows(X).Item(0).ToString, DT.Rows(X).Item(1).ToString, DT.Rows(X).Item(2).ToString, DT.Rows(X).Item(3).ToString, DT.Rows(X).Item(4).ToString, DT.Rows(X).Item(5).ToString, DT.Rows(X).Item(6).ToString, DT.Rows(X).Item(7).ToString, DT.Rows(X).Item(8).ToString, DT.Rows(X).Item(9).ToString, DT.Rows(X).Item(10).ToString, DT.Rows(X).Item(11).ToString, DT.Rows(X).Item(12).ToString, DT.Rows(X).Item(13).ToString, DT.Rows(X).Item(14).ToString, DT.Rows(X).Item(15).ToString, DT.Rows(X).Item(16).ToString, DT.Rows(X).Item(17).ToString, DT.Rows(X).Item(18).ToString)
            Next
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
        End If

       

    End Sub
   
    Private Sub BTNREFLEJO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim xyz As Short
        xyz = MessageBox.Show("Este botón tratará de corregir productos que aparecen dobles, ¿Desea continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        MessageBox.Show("Se cerrará la ventana, favor de volverla a abrir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Me.Close()
    End Sub

    Private Sub TXTGAN_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsPunctuation(e.KeyChar) Then
            e.Handled = False
        End If
        CALCULACOSTOU()
    End Sub
    Private Function CALCULASEMANA(ByVal Fecha As Date) As Integer
        Return DatePart("ww", Fecha)
    End Function
    Private Function GENERALOTE(ByVal PRO As String, ByVal SEM As String, ByVal AÑO As String)
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim SIG As Integer
        Dim QUERY As String
        QUERY = "SELECT max(REGISTRO) FROM LOTES WHERE  PRODUCTO='" + PRO + "' AND AÑO=" + AÑO + " AND SEMANA=" + SEM + "GROUP BY PRODUCTO"
        Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            If LEC(0) Is DBNull.Value Then
                SIG = 1
                LEC.Close()
            Else
                SIG = LEC(0)
                SIG = SIG + 1
                LEC.Close()
            End If
        Else
            SIG = 1
            LEC.Close()
        End If

        If TXTCLA.Text = "" Then
            For X = 0 To DGV.Rows.Count - 1
                If DGV.Item(2, X).Value.ToString = CBPROD.Text.ToString Then
                    SIG = SIG + 1
                End If
            Next
        Else
            For X = 0 To DGV.Rows.Count - 1
                If DGV.Item(2, X).Value.ToString = CBPROD.Text.ToString Then
                    SIG = SIG + 1
                End If
            Next
        End If
        


        Dim REG As String
        REG = ""
        If SEM.Length = 1 Then
            SEM = "0" + SEM
        End If
        AÑO = AÑO.Substring(2, 2)
        REG = REG + PRO + SEM + AÑO + "-" + SIG.ToString
        REG = frmPrincipal.SucursalBase + REG
        SIGREG = SIG

        Return REG

    End Function
    Private Sub QUITAR()
        Dim A, B, C As String
        A = TABLALOTES.Rows(DGV.CurrentRow.Index).Item(2).ToString
        B = TABLALOTES.Rows(DGV.CurrentRow.Index).Item(1).ToString
        C = DGV.Item(3, DGV.CurrentRow.Index).Value
        REGRESARUNO(A, B, C)
        TABLATOTALES.Rows.RemoveAt(DGV.CurrentRow.Index)
        TABLALOTES.Rows.RemoveAt(DGV.CurrentRow.Index)
        'TABLAPRIN.Rows.RemoveAt(DGV.CurrentRow.Index)
        DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
        CHECATABLA()
    End Sub
    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        QUITAR()
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Esta seguro que desea eliminar TODOS los elementos agregados?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If xyz = 6 Then
            TABLAPRIN.Rows.Clear()
            LUNI.Clear()
            TABLALOTES.Rows.Clear()
            TABLATOTALES.Rows.Clear()
            DGV.Rows.Clear()
            DGV.Refresh()
            TXTCANT.Text = ""
            TXTCOS.Text = ""
            CHECATABLA()
        End If
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        If CHK1.Checked Then
            If String.IsNullOrEmpty(TXTPED.Text) Then
                MessageBox.Show("Pedimento no especificado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        'Dim xyz As Short
        'xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        'If xyz <> 6 Then
        '    Exit Sub
        'End If
        GUARDAR()
    End Sub


    Private Sub BTNBUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUS.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION,ACTIVO FROM PRODUCTOS WHERE EMPRESA=" + frmPrincipal.Empresa + "  AND ACTIVO=1 AND CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + LALM(CBALM.SelectedIndex) + "' AND ACTIVO=1)", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 2, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(1))
            CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
            TXTCANT.Focus()
            TXTCANT.SelectAll()
        End If
    End Sub
    Private Sub CARGAUNIDADDEFAULT()
        Try
            Dim VUNI As String
            VUNI = LUDC(CBPROD.SelectedIndex)
            Dim X As Integer
            For X = 0 To CLAUNI.Count - 1
                If CLAUNI(X) = VUNI Then
                    CBUNI.SelectedIndex = X
                End If
            Next
        Catch ex As Exception
        End Try


    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub CBGRU_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBGRU.KeyPress, CBPROD.KeyPress, CBUNI.KeyPress, TXTCANT.KeyPress, TXTDESC.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Dim CLAPRODC As New List(Of String)
    Dim CLAGRUC As New List(Of String)
    Dim LDESC As New List(Of String)
    Dim LPREC As New List(Of Double)
    Dim LCPC As New List(Of String)
    Dim LUDCC As New List(Of Integer)
    Dim LIVAC As New List(Of Boolean)
    Dim LCOSC As New List(Of Double)
    Dim LPROD As New List(Of String)
    Dim LGRU As New List(Of String)
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
                If Not OPCargaX(CLAPROD, CBPROD, LECTOR(0)) Then
                    MessageBox.Show("El codigo del producto NO existe en el sistema o se encuentra deshabilitado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
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

    Private Sub TXTCLA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLA.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not CHECAPROD() Then
                Exit Sub
            End If
            TXTCANT.Focus()
            TXTCANT.SelectAll()
            'If Not CARGADATAVIEW2(LCP(CBPROD.SelectedIndex)) Then
            '    MessageBox.Show("No se encuentra asignada ninguna equivalencia a este producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '    ACTIVAR(False)
            'Else
            '    'CARGAUNIDADDEFAULT()
            '    'CARGAULTIMOCOSTO()
            'End If
            'TXTCANT.Focus()
            'LBLDES.Text = LDESC(0)
            'LBLCOSTO.Text = LCOSC(0)
            'LBLPRE.Text = LPREC(0)
            'CARGAELGRUPO(CLAGRUC(0))
            'CARGAELPRODUCTO(CLAPRODC(0))
        End If
    End Sub

    Private Sub frmCompras_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TXTCANT.Focus()
    End Sub

    Private Sub BTNAGREGAR_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BTNAGREGAR.KeyDown
        If e.KeyCode = Keys.F4 Then
            CHECAAGREGAR()
        End If
        If e.KeyCode = Keys.F5 Then
            QUITAR()
        End If
        If e.KeyCode = Keys.F7 Then
            Dim abc As Short
            abc = MessageBox.Show("¿Esta seguro que desea eliminar TODOS los elementos agregados?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If abc = 6 Then
                TABLAPRIN.Rows.Clear()
                LUNI.Clear()
                TABLALOTES.Rows.Clear()
                TABLATOTALES.Rows.Clear()
                DGV.Rows.Clear()
                DGV.Refresh()
                TXTCANT.Text = ""
                TXTCOS.Text = ""
                CHECATABLA()
            End If
        End If
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS WHERE EMPRESA=" + frmPrincipal.Empresa + " ", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 3, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(1))
                CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
                TXTCANT.Focus()
                TXTCANT.SelectAll()
            End If
        End If
        If e.KeyCode = Keys.F12 Then
            Dim xyz As Short
            xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz <> 6 Then
                Exit Sub
            End If
            GUARDAR()
        End If

    End Sub

    Private Sub CHK1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK1.CheckedChanged
        TXTPED.Enabled = CHK1.Checked
    End Sub
End Class