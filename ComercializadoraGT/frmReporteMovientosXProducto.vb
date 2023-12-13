Public Class frmReporteMovientosXProducto
    Dim CLAPROD As New List(Of String)
    Private Sub frmReporteMovientosXProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGAPRODUCTOS()
    End Sub
    Private Sub CARGAPRODUCTOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        CBPRO.Items.Clear()
        CLAPROD.Clear()
        CBPRO.Items.Add("Todos los productos")
        CLAPROD.Add("")
        Dim SQLPRO As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM PRODUCTOS WHERE ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " AND CLAVE<>'CREDITO' AND CLAVE<>'999' ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LECPRO As SqlClient.SqlDataReader
        LECPRO = SQLPRO.ExecuteReader
        While LECPRO.Read
            CLAPROD.Add(LECPRO(0))
            CBPRO.Items.Add(LECPRO(1))
        End While
        LECPRO.Close()
        Try
            CBPRO.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Function CHECAFECHAS() As Boolean
        If DTDE.Value.Date > DTHASTA.Value.Date Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        If Not CHECAFECHAS() Then
            MessageBox.Show("El rango de fechas esta incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim QUERY, QUERY2 As String

        QUERY = "SELECT MOVIMIENTO,PRODUCTO,CANTIDAD,UNIDAD,USUARIO,FECHA FROM ENTRADASTIENDA WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND FECHA>=@INI AND FECHA<=@FIN  "
        QUERY2 = "SELECT MOVIMIENTO,PRODUCTO,CANTIDAD,UNIDAD,USUARIO,FECHA FROM SALIDASTIENDA WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND FECHA>=@INI AND FECHA<=@FIN  "

     
        If CBPRO.SelectedIndex = 0 Then
           
        Else
            QUERY = QUERY + " AND  PRODUCTO='" + CBPRO.Text + "'  "
            QUERY2 = QUERY2 + " AND PRODUCTO='" + CBPRO.Text + "'  "
        End If

        QUERY = QUERY + " ORDER BY PRODUCTO,MOVIMIENTO "
        QUERY2 = QUERY2 + " ORDER BY PRODUCTO,MOVIMIENTO "


        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


        DGV2.DataSource = BDLlenatabla(QUERY2, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV2.Refresh()
        DGV2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'CHECATABLA()
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click

        frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,DESCRIPCION FROM PRODUCTOS", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 2, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
            CARGADATOS()
        End If

    End Sub

    Private Sub DTDE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTDE.KeyPress, DTHASTA.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
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
    Private Sub frmReporteMovientosXProducto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,DESCRIPCION FROM PRODUCTOS", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 3, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
                CARGADATOS()
            End If
        End If
    End Sub

    Private Sub CBPRO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBPRO.KeyPress
        If e.KeyChar = Chr(13) Then
            CARGADATOS()
        End If
    End Sub
End Class