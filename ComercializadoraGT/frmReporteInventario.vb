Public Class frmReporteInventario
    Dim CLAGRU As New List(Of String)
    Dim CLAPROD As New List(Of String)
    Dim LCP As New List(Of String)
    Dim CC As New ColorConverter
    Dim QUERY As String
    Private Sub frmReporteInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGAGRUPOS()
    End Sub
   
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        

        QUERY = "SELECT P.CLAVE,G.NOMBRE GRUPO, P.NOMBRE PRODUCTO,sum(I.CANTIDAD) [INV ACTUAL],U.NOMBRE UNIDAD,CONVERT(NUMERIC(15,2),P.STOCKMIN,2) [STCKMINIMO]  FROM PRODUCTOS P INNER JOIN LOTES L ON L.PRODUCTO=P.CP INNER JOIN INVTIENDA I  ON I.PRODUCTO=L.CLAVE AND I.TIENDA='" + frmPrincipal.SucursalBase + "' INNER JOIN GRUPOS G  ON P.GRUPO=G.CLAVE  INNER JOIN UNIDADES U ON U.CLAVE=P.UVENTA AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1)"
        If CBGRU.SelectedIndex = 0 Then
            If CBPRO.SelectedIndex = 0 Then
            Else
            End If
        Else
            If CBPRO.SelectedIndex = 0 Then
                QUERY = QUERY + " WHERE G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' "
            Else
                QUERY = QUERY + " WHERE G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' AND P.CLAVE='" + CLAPROD(CBPRO.SelectedIndex) + "' "
            End If
        End If
        QUERY = QUERY + " AND P.CLAVE<>'12345' GROUP BY P.CLAVE,G.NOMBRE,P.NOMBRE,U.NOMBRE,P.STOCKMIN ORDER BY G.NOMBRE,P.NOMBRE "
      
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ' CHECATABLA()
    End Sub
    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
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
    '    LBLV.Text = FormatNumber(VENTA).ToString()
    '    LBLC.Text = FormatNumber(COSTO).ToString()
    '    LBLART.Text = FormatNumber(CANT).ToString
    '    LBLGG.Text = FormatNumber(VENTA - COSTO).ToString()

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
        LCP.CLEAR()
        CBPRO.Items.Add("Todos los productos")
        CLAPROD.Add("")
        LCP.ADD("")
        Dim SQLPRO As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE,CP FROM PRODUCTOS WHERE GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "' AND ACTIVO=1 AND CLAVE<>'12345'  ORDER BY NOMBRE", frmPrincipal.CONX)
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
        Dim REPI As New rptCicloInvTienda
        Dim CI As New clsImprimir
        CI.IMPRIMIR2(REPI, QUERY, 1, frmPrincipal.CadenaConexion)
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        IMPRIMIR()
    End Sub

    Private Sub frmReporteInventario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS WHERE CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1) ", " AND NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Productos", "Nombre del Producto", "Productos(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLAGRU, CBGRU, frmClsBusqueda.TREG.Rows(0).Item(1).ToString)
                OPCargaX(CLAPROD, CBPRO, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
    End Sub
End Class