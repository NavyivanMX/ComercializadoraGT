Public Class frmAjustesPiso

    Dim ACTUALIZA As Boolean
    Dim ANT As Double
    Dim CLAPRO As String
    Private Sub frmAjustesPiso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        ACTIVAR(True)
        LIMPIAR()
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTCANT.Enabled = Not V
        BTNGUARDAR.Enabled = Not V
        'TXTCANT.Text = "0"
    End Sub
    Private Sub LIMPIAR()
        TXTCANT.Text = "0"
        LBLEXIS.Text = 0
        LBLPRO.Text = ""
        CLAPRO = ""
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
    End Sub
    Private Sub GUARDAR()
        If CLAPRO = "" Then
            OPMsgError("Primero seleccionar producto")
        End If

        Dim CANT As Double
        Try
            CANT = CType(TXTCANT.Text, Double)
        Catch ex As Exception
            OPMsgError("Cantidad no valida")
            Exit Sub
        End Try

        BDEjecutarSql("EXEC SPAJUSTARINVENTARIO '" + frmPrincipal.SucursalBase + "','" + CLAPRO + "','" + CANT.ToString + "','" + frmPrincipal.Usuario + "'", frmPrincipal.CadenaConexion)

        ACTIVAR(True)
        LIMPIAR()
        MessageBox.Show("La información ha sido guardada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub



    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
        LIMPIAR()
    End Sub

    Private Sub frmAjustesNice_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            BUSCAR()
        End If
    End Sub
    Private Sub BUSCAR()
        frmClsBusqueda.BUSCAR("SELECT P.CLAVE,P.NOMBRE PRODUCTO,PRE.PRECIO,DBO.EXISTENCIAALMACEN('" + frmPrincipal.SucursalBase + "',P.CP) EXISTENCIA  FROM PRODUCTOS P INNER JOIN PRECIOSSUCURSALES PRE ON PRE.TIENDA='" + frmPrincipal.SucursalBase + "' AND PRE.PRODUCTO=P.CLAVE WHERE P.ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + "  AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1)", "  AND P.NOMBRE  ", "  ORDER BY P.NOMBRE  ", "Busqueda de productos", "Nombre del producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CLAPRO = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            LBLPRO.Text = frmClsBusqueda.TREG.Rows(0).Item(1).ToString
            LBLEXIS.Text = frmClsBusqueda.TREG.Rows(0).Item(3).ToString
            ACTIVAR(False)
        End If
    End Sub

    Private Sub BTNBUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUS.Click
        BUSCAR()
    End Sub
End Class