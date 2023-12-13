Public Class frmReporteHistorialAjustesPiso
    Dim CLAGRU As New List(Of String)
    Dim CLAPROD As New List(Of String)
    Private Sub frmReporteHistorialAjustesPiso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGAGRUPOS()
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String

       
        QUERY = ("SELECT HA.PRODUCTO LOTE,P.NOMBRE PRODUCTO,L.COSTOU [C.UNITARIO],HA.CANTANT [CANT. ANTERIOR],HA.CANTDES [CANT. MODIFICADA],DIFERENCIA=(SELECT DBO.RESULTADOPOSITIVO(HA.CANTDES-HA.CANTANT)),U.NOMBRE [U. MINIMA],[$$$]=(SELECT CONVERT( NUMERIC(15,2),L.COSTOU*(SELECT DBO.RESULTADOPOSITIVO(HA.CANTDES-HA.CANTANT)))),HA.FECHA  FROM HISTORIALAJUSTESPISO  HA INNER JOIN LOTES L  ON HA.PRODUCTO=L.CLAVE INNER JOIN PRODUCTOS P  ON L.PRODUCTO=P.CP INNER JOIN UNIDADES U ON P.UVENTA=U.CLAVE WHERE   HA.FECHA>=@INI AND HA.FECHA<=@FIN ")


        If CBGRU.SelectedIndex = 0 Then
            If CBPRO.SelectedIndex = 0 Then
            Else
            End If
        Else
            If CBPRO.SelectedIndex = 0 Then
                QUERY = QUERY + " AND P.GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "'  "
            Else
                QUERY = QUERY + " AND P.GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "' AND P.CLAVE='" + CLAPROD(CBPRO.SelectedIndex) + "' "
            End If
        End If
        QUERY = QUERY + " AND HA.TIENDA='" + frmPrincipal.SucursalBase + "' AND P.CLAVE<>'CREDITO' AND P.CLAVE<>'999' ORDER BY P.GRUPO,P.CLAVE "

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'CHECATABLA()
    End Sub
    Private Sub CARGAGRUPOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        CBGRU.Items.Clear()
        CLAGRU.Clear()
        CBGRU.Items.Add("Todos los grupos")
        CLAGRU.Add("")
        Dim SQLGRUPO As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM GRUPOS WHERE ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " ORDER BY NOMBRE", frmPrincipal.CONX)
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
        Dim SQLPRO As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM PRODUCTOS WHERE GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "' AND ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " AND CLAVE<>'CREDITO' AND CLAVE<>'999' ORDER BY NOMBRE", frmPrincipal.CONX)
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

    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged
        If Not CARGAPRODUCTOS() Then
            MessageBox.Show("No hay productos asignados a este grupo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub
    
    Private Sub frmReporteHistorialAjustesPiso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS  ", " WHERE NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Productos", "Nombre del Producto", "Productos(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLAGRU, CBGRU, frmClsBusqueda.TREG.Rows(0).Item(1).ToString)
                OPCargaX(CLAPROD, CBPRO, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
    End Sub
End Class