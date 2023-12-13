Public Class frmReporteMovimientosInvGeneral
    Dim CLAGRU As New List(Of String)
    Dim CLAPROD As New List(Of String)
    Private Sub frmReporteMovimientosInvGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGAGRUPOS()
    End Sub
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
        CBPRO.Items.Add("Todos los productos")
        CLAPROD.Add("")
        Dim SQLPRO As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM PRODUCTOS WHERE GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "' AND ACTIVO=1 AND CLAVE<>'12345'  ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LECPRO As SqlClient.SqlDataReader
        LECPRO = SQLPRO.ExecuteReader
        While LECPRO.Read
            CLAPROD.Add(LECPRO(0))
            CBPRO.Items.Add(LECPRO(1))
        End While
        LECPRO.Close()
        Try
            CBPRO.SelectedIndex = 0
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub CARGADATOS()
        Dim QUERY As String
        'Try

        QUERY = "SELECT P.NOMBRE Producto ,H.INVINICIAL[Inventario Inicial],H.Compras ,H.ENTRADAPEDIDOS [Entrada por Pedido],H.Salidas,H.AJUSTEMENOS [Ajuste Menos],H.AJUSTEMAS[Ajsute Mas],H.NOTACANC [Nota cancelada],H.NOTACANCCRED [Nota credito cancelada],H.Mermas ,H.SINEXISTENCIA[Venta Sin Existencia],H.INVFINAL[Inventario Final],Fecha FROM HISTORIALMOVIMIENTOSINV H INNER JOIN PRODUCTOS P ON P.CLAVE=H.PRODUCTO AND P.GRUPO=H.GRUPO INNER JOIN GRUPOS G  ON G.CLAVE=H.GRUPO INNER JOIN tiendas R ON R.CLAVE=H.tienda WHERE H.FECHA=@INI  AND H.tienda='" + frmPrincipal.SucursalBase + "'"
        If CBGRU.SelectedIndex = 0 Then
        Else
            If CBPRO.SelectedIndex = 0 Then
                QUERY = QUERY + " AND H.GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "'"
            Else
                QUERY = QUERY + " AND H.GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "' AND H.PRODUCTO='" + CLAPROD(CBPRO.SelectedIndex) + "'"
            End If
        End If

        Dim SQL2 As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim DA2 As New SqlClient.SqlDataAdapter()
        DA2.SelectCommand = SQL2

        DA2.SelectCommand.Parameters.Add("@INI", SqlDbType.DateTime).Value = DTDE.Value.Date

        Dim DT2 As New DataTable
        DA2.Fill(DT2)
        DGV.DataSource = DT2
        DGV.Refresh()
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub

    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged
        CARGAPRODUCTOS()
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

    Private Sub frmReporteMovimientosInvGeneral_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 3, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(1))
                CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
                CARGADATOS()
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 3, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(1))
            CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
            CARGADATOS()
        End If
    End Sub
End Class