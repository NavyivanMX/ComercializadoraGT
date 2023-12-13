Public Class frmPreciosClientes
    Dim TABLAPRIN As New DataTable
    Dim CLACLI As New List(Of String)
    Dim CLAPRO As New List(Of String)
    Dim CLAGRU As New List(Of String)
    Dim CLAPRE As New List(Of String)
    Dim CLAP As New List(Of String)
    Dim DT As New DataTable
    Private Sub frmPreciosClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        OPLlenaComboBox(CBGRU, CLAGRU, "SELECT CLAVE,NOMBRE FROM GRUPOS WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        TABLAPRIN.Columns.Clear()
        TABLAPRIN.Columns.Add("Clave")
        TABLAPRIN.Columns.Add("Producto")
        TABLAPRIN.Columns.Add("Precio")
        TABLAPRIN.Columns.Add("BajoPrecio", GetType(Boolean))
        DT = BDLlenatabla("SELECT CLAVE,NOMBRE,IMG FROM PRODUCTOS ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        OPLlenaComboBox(CBCLI, CLACLI, "SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1 AND CLAVE<>0 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)

        CHECATABLA()
        ACTIVAR(True)

    End Sub
    Private Sub CARGAPRODUCTOS()
        OPLlenaComboBox(CBPRO, CLAPRO, CLAPRE, CLAP, "SELECT P.CLAVE,P.PMIN COSTO,P.PRECIO,P.NOMBRE FROM PRODUCTOS P WHERE P.ACTIVO=1 AND P.GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "' ORDER BY P.NOMBRE", frmPrincipal.CadenaConexion)
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        CBCLI.Enabled = V
        CBGRU.Enabled = Not V
        CBPRO.Enabled = Not V
        TXTPRE.Enabled = Not V
        TXTPRE.Text = "0.00"
        BTNAGREGAR.Enabled = Not V
        BTNCANCELAR.Enabled = Not V
        BTNIMPRIMIR.Enabled = Not V
    End Sub
    Private Sub LIMPIAR()
        CBCLI.SelectedIndex = 0
        CBPRO.SelectedIndex = 0
        CBGRU.SelectedIndex = 0
        TXTPRE.Text = "0.00"
        DGV.Rows.Clear()
    End Sub
    Public Function AGREGADO(ByVal BUS As String) As Boolean
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            If BUS = DGV.Item(0, X).Value Then
                MessageBox.Show("Este producto ya ha sido agregado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub AGREGAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim PRECIO As Double
        Try
            PRECIO = CType(TXTPRE.Text, Double)
            If PRECIO <= 0 Then
                MessageBox.Show("El precio del producto No es valido, favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("El precio del producto No es valido, favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End Try
        If CHKBM.Checked Then
        Else
            If PRECIO < CType(CLAPRE(CBPRO.SelectedIndex), Double) Then
                MessageBox.Show("El precio del producto es menor que el último costo, ( $" + CLAPRE(CBPRO.SelectedIndex) + " ) favor de Verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If
        End If

        If AGREGADO(CLAPRO(CBPRO.SelectedIndex)) Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SPPRECIOSCLIENTES", frmPrincipal.CONX)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.CommandTimeout = 300
        SQL.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQL.Parameters.Add("@CLI", SqlDbType.VarChar).Value = CLACLI(CBCLI.SelectedIndex)
        SQL.Parameters.Add("@PRO", SqlDbType.VarChar).Value = CLAPRO(CBPRO.SelectedIndex)
        SQL.Parameters.Add("@PRE", SqlDbType.Float).Value = PRECIO
        SQL.Parameters.Add("@PPD", SqlDbType.Bit).Value = CHKBM.Checked
        SQL.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario

        'INSERT INTO PRECIOSCLIENTES (TIENDA,CLIENTE,PRODUCTO,PRECIO,USUARIO) VALUES ('" + frmPrincipal.SucursalBase + "','" + CLACLI(CBCLI.SelectedIndex) + "','" + CLAPRO(CBPRO.SelectedIndex) + "','" + PRECIO.ToString + "','" + frmPrincipal.Usuario + "')", frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
        CARGADATOS()
    End Sub
    Private Sub QUITAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("DELETE FROM PRECIOSCLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "' AND PRODUCTO='" + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString + "'", frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
        CARGADATOS()
    End Sub
    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        QUITAR()
    End Sub
    Private Sub BTNAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGAR.Click
        AGREGAR()
    End Sub
    Private Sub CHECATABLA()
        If DGV.Rows.Count = 0 Then
            BTNQUITAR.Enabled = False
            BTNELIMINAR.Enabled = False
        Else
            BTNQUITAR.Enabled = True
            BTNELIMINAR.Enabled = True
        End If
    End Sub

    Private Sub CARGADATOS()
        Dim LAQ As String

        LAQ = "SELECT C.PRODUCTO,P.NOMBRE,C.PRECIO,C.PPD BAJOMINIMO FROM PRECIOSCLIENTES C INNER JOIN PRODUCTOS P ON C.PRODUCTO=P.CLAVE WHERE C.TIENDA='" + frmPrincipal.SucursalBase + "' AND C.CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "' ORDER BY P.NOMBRE"
        Dim DDT As New DataTable
        DDT = BDLlenatabla(LAQ, frmPrincipal.CadenaConexion)
        DGV.Rows.Clear()
        'DGV.DataSource = DDT
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).ReadOnly = True
        Dim X As Integer
        For X = 0 To DDT.Rows.Count - 1
            DGV.Rows.Add(1)
            Dim ITEMS As Integer
            ITEMS = DGV.Rows.Count - 1
            DGV.Item(0, ITEMS).Value = DDT.Rows(X).Item(0)
            DGV.Item(1, ITEMS).Value = DDT.Rows(X).Item(1)
            DGV.Item(2, ITEMS).Value = DDT.Rows(X).Item(2)
            DGV.Item(3, ITEMS).Value = DDT.Rows(X).Item(3)
        Next
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).ReadOnly = True
        ACTIVAR(False)
        CHECATABLA()
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Estas seguro que deseas eliminar los elementos agregados?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If

        Dim SQL As New SqlClient.SqlCommand("DELETE FROM PRECIOSCLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "'", frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
        DGV.Rows.Clear()
        DGV.Refresh()
        CHECATABLA()
        ACTIVAR(True)
        CBCLI.Focus()

    End Sub

    Private Sub TXTPRE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPRE.KeyPress
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
            AGREGAR()
        End If
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
        LIMPIAR()
    End Sub

    Private Sub CBCLI_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBCLI.KeyPress
        If e.KeyChar = Chr(13) Then
            CARGADATOS()
        End If
    End Sub

    Private Sub CBPRO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBPRO.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTPRE.Focus()
            TXTPRE.SelectAll()
        End If
    End Sub

    Private Sub CBPRO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBPRO.SelectedIndexChanged
        LBLPRE.Text = FormatNumber(CType(CLAPRE(CBPRO.SelectedIndex), Double), 2).ToString
        LBLP.Text = FormatNumber(CType(CLAP(CBPRO.SelectedIndex), Double), 2).ToString
        PONERIMAGEN()
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        Dim REP As New rptReportePreciosClientes
        MOSTRARREPORTE(REP, "Lista de Precios Especial por Cliente: " + CBCLI.Text, BDLlenatabla("SELECT T.NOMBRECOMUN TIENDA,C.NOMBRE CLIENTE,P.NOMBRE PRODUCTO,PC.PRECIO FROM PRECIOSCLIENTES PC INNER JOIN TIENDAS T ON PC.TIENDA=T.CLAVE INNER JOIN PRODUCTOS P ON PC.PRODUCTO=P.CLAVE INNER JOIN CLIENTES C ON PC.TIENDA=C.TIENDA AND PC.CLIENTE=C.CLAVE WHERE PC.TIENDA='" + frmPrincipal.SucursalBase + "' AND PC.CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "'", frmPrincipal.CadenaConexion), "Enviar a OneNote 2007")
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusquedaTactil.ShowDialog()
        If frmClsBusquedaTactil.DialogResult = Windows.Forms.DialogResult.Yes Then
            OPCargaX(CLAPRO, CBPRO, frmClsBusquedaTactil.TREG.Rows(0).Item(0).ToString)
            PONERIMAGEN()
            TXTPRE.Focus()
            TXTPRE.SelectAll()
        End If
    End Sub
    Private Sub PONERIMAGEN()
        Dim X As Integer
        For X = 0 To DT.Rows.Count - 1
            If DT.Rows(X).Item(0) = CLAPRO(CBPRO.SelectedIndex) Then
                Try
                    PBIMG.ImageLocation = "C:/FOTOSPRICE/" + DT.Rows(X).Item(2).ToString + ".JPG"
                Catch ex As Exception
                    PBIMG.ImageLocation = "C:/FOTOSPRICE/PANASONIC.JPG"
                End Try

            End If
        Next
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
        For X = 0 To CLAPRO.Count - 1
            If CLAPRO(X) = CLA Then
                CBPRO.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
    Private Sub frmPreciosClientes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F9 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0 ", " AND NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLACLI, CBCLI, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If

        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 3, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(1))
                CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
                CARGADATOS()
            End If
        End If
    End Sub

    Private Sub BTNBUSCAR1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR1.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS", " WHERE NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 3, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(1))
            CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
            CARGADATOS()
        End If
    End Sub

    Private Sub DGV_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Try
            Dim BM As String
            BM = "0"
            If CType(DGV.Item(3, DGV.CurrentRow.Index).Value, Boolean) Then
                BM = "1"
            End If
            Dim SQL As New SqlClient.SqlCommand("UPDATE PRECIOSCLIENTES SET PRECIO='" + DGV.Item(2, DGV.CurrentRow.Index).Value.ToString + "',PPD='" + BM + "' WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "' AND PRODUCTO='" + DGV.Item(0, DGV.CurrentRow.Index).Value + "'", frmPrincipal.CONX)
            SQL.ExecuteNonQuery()
        Catch ex As Exception

        End Try
        'INSERT INTO PRECIOSCLIENTES (TIENDA,CLIENTE,PRODUCTO,PRECIO,USUARIO)
    End Sub
End Class