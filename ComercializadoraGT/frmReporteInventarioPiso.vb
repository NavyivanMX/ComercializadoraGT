Public Class frmReporteInventarioPiso
    Dim CLATI As New List(Of String)
    Dim CLAGRU As New List(Of String)
    Dim CLAPROD As New List(Of String)
    Dim LCP As New List(Of String)
    Dim CC As New ColorConverter
    Dim QUERY As String
    Private Sub frmReporteInventarioPiso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        If frmPrincipal.SucursalBase = "PM" Then
            OPLlenaComboBox(CBTI, CLATI, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE CLAVE<>'PRUEBAS' ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion)
        Else
            LBLTI.Visible = False
            CBTI.Visible = False
        End If
        CARGAGRUPOS()
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        If frmPrincipal.SucursalBase <> "PM" Then
            QUERY = "SELECT G.NOMBRE GRUPO, P.NOMBRE PRODUCTO,SUM(I.CANTIDAD) [INV ACTUAL],U.NOMBRE UNIDAD,CONVERT(NUMERIC(15,2),P.STOCKMIN,2) [STCKMINIMO],T.NOMBRECOMUN TIENDA  FROM PRODUCTOS P INNER JOIN LOTES L ON L.PRODUCTO=P.CP INNER JOIN INVPISOTIENDA I  ON I.PRODUCTO=L.CLAVE INNER JOIN TIENDAS T ON I.TIENDA=T.CLAVE INNER JOIN GRUPOS G  ON P.GRUPO=G.CLAVE  INNER JOIN UNIDADES U ON U.CLAVE=P.UVENTA WHERE I.TIENDA='" + frmPrincipal.SucursalBase + "' AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1)"
        Else
            QUERY = "SELECT G.NOMBRE GRUPO, P.NOMBRE PRODUCTO,SUM(I.CANTIDAD) [INV ACTUAL],U.NOMBRE UNIDAD,CONVERT(NUMERIC(15,2),P.STOCKMIN,2) [STCKMINIMO],T.NOMBRECOMUN TIENDA  FROM PRODUCTOS P INNER JOIN LOTES L ON L.PRODUCTO=P.CP INNER JOIN INVPISOTIENDA I  ON I.PRODUCTO=L.CLAVE INNER JOIN TIENDAS T ON I.TIENDA=T.CLAVE INNER JOIN GRUPOS G  ON P.GRUPO=G.CLAVE  INNER JOIN UNIDADES U ON U.CLAVE=P.UVENTA WHERE I.TIENDA='" + CLATI(CBTI.SelectedIndex) + "' AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + CLATI(CBTI.SelectedIndex) + "' AND ACTIVO=1)"
        End If

        If CBGRU.SelectedIndex = 0 Then
            If CBPRO.SelectedIndex = 0 Then
            Else
            End If
        Else
            If CBPRO.SelectedIndex = 0 Then
                QUERY = QUERY + " AND G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' "
            Else
                QUERY = QUERY + " AND G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' AND P.CLAVE='" + CLAPROD(CBPRO.SelectedIndex) + "' "
            End If
        End If
        If Not RB1.Checked Then
            QUERY += " AND P.ACTIVO=1"
        End If
        QUERY = QUERY + " AND P.CLAVE<>'12345' AND P.CLAVE<>'CREDITO' AND P.CLAVE<>'999' GROUP BY T.NOMBRECOMUN,G.NOMBRE,P.NOMBRE,U.NOMBRE,P.STOCKMIN ORDER BY G.NOMBRE,P.NOMBRE "

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ' CHECATABLA()
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
                CBPRO.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub

    'Private Sub CHECATABLA()
    '    Dim X As Integer
    '    Dim VENTA, COSTO, CANT As Double
    '    VENTA = 0
    '    COSTO = 0
    '    CANT = 0
    '    For X = 0 To DGV.Rows.Count - 1
    '        VENTA = VENTA + DGV.Item(3, X).Value
    '        COSTO = COSTO + DGV.Item(4, X).Value
    '        CANT = CANT + DGV.Item(5, X).Value
    '    Next
    '    'LBLV.Text = FormatNumber(VENTA).ToString()
    '    'LBLC.Text = FormatNumber(COSTO).ToString()
    '    'LBLART.Text = FormatNumber(CANT).ToString
    '    'LBLGG.Text = FormatNumber(VENTA - COSTO).ToString()

    '    For Each Row As DataGridViewRow In DGV.Rows
    '        For X = 0 To DGV.Rows.Count - 1
    '            If DGV.Item(5, X).Value <= DGV.Item(6, X).Value Then
    '                DGV.Item(5, X).Style = DgvCellEstilo(-65536, -1)
    '            End If
    '        Next
    '    Next

    'End Sub
    Private Sub CARGAGRUPOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        CBGRU.Items.Clear()
        CLAGRU.Clear()
        CBGRU.Items.Add("Todos los grupos")
        CLAGRU.Add("")
        Dim SQLGRUPO As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM GRUPOS WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LECGRUPO As SqlClient.SqlDataReader
        LECGRUPO = SQLGRUPO.ExecuteReader
        While LECGRUPO.Read
            CLAGRU.Add(LECGRUPO(0))
            CBGRU.Items.Add(LECGRUPO(1))
        End While
        LECGRUPO.Close()
        Try
            CBGRU.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub
    Private Function CARGAPRODUCTOS() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        CBPRO.Items.Clear()
        CLAPROD.Clear()
        LCP.Clear()
        CBPRO.Items.Add("Todos los productos")
        CLAPROD.Add("")
        LCP.Add("")
        Dim SQLPRO As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE,CP FROM PRODUCTOS WHERE GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "' AND ACTIVO=1 AND CLAVE<>'12345' AND CLAVE<>'CREDITO' AND CLAVE<>'999'  ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LECPRO As SqlClient.SqlDataReader
        LECPRO = SQLPRO.ExecuteReader
        While LECPRO.Read
            CLAPROD.Add(LECPRO(0))
            CBPRO.Items.Add(LECPRO(1))
            LCP.Add(LECPRO(0))
        End While
        LECPRO.Close()
        Try
            CBPRO.SelectedIndex = 0
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged
        CARGAPRODUCTOS()
    End Sub
    Private Function DgvCellEstilo(ByVal FONDO As Integer, ByVal FUENTE As Integer) As DataGridViewCellStyle
        Dim RESTILO As New DataGridViewCellStyle
        RESTILO.BackColor = CC.ConvertFromString(FONDO)
        RESTILO.ForeColor = CC.ConvertFromString(FUENTE)
        Return RESTILO
    End Function

    Private Sub DGV_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV.Sorted
        'CHECATABLA()
    End Sub
    Private Sub IMPRIMIR()
        Dim REPI As New rptCicloInvPisoTienda
        MOSTRARREPORTE(REPI, "Inventario " + frmPrincipal.NombreComun, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), "")
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        If CadenaVacia(QUERY) Then
            OPMsgError("Favor de primero cargar la información")
            Exit Sub
        End If
        IMPRIMIR()
    End Sub

    Private Sub CBPRO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBPRO.KeyPress
        If e.KeyChar = Chr(13) Then
            CARGADATOS()
        End If
    End Sub

    Private Sub frmReporteInventarioPiso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION,ACTIVO FROM PRODUCTOS WHERE ACTIVO=1 ", " AND NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Productos", "Nombre del Producto", "Productos(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLAGRU, CBGRU, frmClsBusqueda.TREG.Rows(0).Item(1).ToString)
                OPCargaX(CLAPROD, CBPRO, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
                CARGADATOS()
            End If
        End If
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION,ACTIVO FROM PRODUCTOS WHERE EMPRESA='" + frmPrincipal.Empresa + "' AND ACTIVO=1 ", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 2, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(1))
            CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
            CARGADATOS()
        End If
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CadenaVacia(QUERY) Then
            OPMsgError("Favor de primero cargar la información")
            Exit Sub
        End If
        Dim VSIMP As New frmSeleccionarImpresora
        Dim NI As String
        NI = ""
        VSIMP.ShowDialog()
        If VSIMP.DialogResult = DialogResult.Yes Then
            NI = VSIMP.NIMPRESORA
        End If
        Dim REPI As New rptCicloInvPisoTIendaA4
        MOSTRARREPORTE(REPI, "Inventario " + frmPrincipal.NombreComun, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), NI)
    End Sub
End Class