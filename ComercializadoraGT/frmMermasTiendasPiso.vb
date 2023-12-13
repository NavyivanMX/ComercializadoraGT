Public Class frmMermasTiendasPiso
    Dim CLARES As New List(Of String)
    Dim CLAUN As New List(Of String)
    Dim REGISTRO As Integer
    Dim FECHA As Date
    Dim VER As Boolean
    Dim VERLOT As Boolean
    Dim VERINV As Boolean
    Dim PRODUCTO As String
    Dim GRUPO As String
    Dim CLAGRU As New List(Of String)
    Dim CLAPRO As New List(Of String)
    Dim CLACP As New List(Of String)
    Dim CLAIMG As New List(Of String)
    Dim img As String

    Private Sub frmMermasTiendasPiso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        If CARGAGRUPOS() Then
            MessageBox.Show("No hay Grupos dados de alta, favor de ingresar al menos un grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        ACTIVAR(True)
        LIMPIAR()
    End Sub
    Public Sub CARGAPRODUCTOS()
        CBPRO.Items.Clear()
        CLAPRO.Clear()
        CLACP.Clear()
        CLAIMG.Clear()
        Dim query As String
        query = "SELECT CLAVE,NOMBRE,CP,IMG FROM PRODUCTOS WHERE ACTIVO=1 AND GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "' ORDER BY NOMBRE"
        Dim BUSCAPRO As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
        Dim LEEPRO As SqlClient.SqlDataReader
        LEEPRO = BUSCAPRO.ExecuteReader
        While LEEPRO.Read
            CBPRO.Items.Add(LEEPRO(1))
            CLAPRO.Add(LEEPRO(0))
            CLACP.Add(LEEPRO(2))
            CLAIMG.Add(LEEPRO(3))
        End While
        LEEPRO.Close()
        CBPRO.SelectedIndex = 0
    End Sub
    Public Function CARGAGRUPOS() As Boolean
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

    Public Sub CARGAUNIDADES()
        CBUN.Items.Clear()
        CLAUN.Clear()
        Dim QUERY As String
        'If frmPrincipal.SucursalBase = "BPM" Then
        '    QUERY = "SELECT DISTINCT(E.UNIDAD),U.NOMBRE,P.NOMBRE,P.DESCRIPCION,P.UVENTA,I.CANTIDAD  FROM EQUIVALENCIAS E INNER JOIN UNIDADES U ON E.UNIDAD =U.CLAVE INNER JOIN LOTES L ON L.PRODUCTO=E.PRODUCTO INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP INNER JOIN INVBODEGA I ON I.PRODUCTO=L.CLAVE WHERE  L.CLAVE='" + TXTLOT.Text + "'"
        'Else
        QUERY = "SELECT DISTINCT(E.UNIDAD),U.NOMBRE,P.NOMBRE,P.DESCRIPCION,P.UVENTA,I.CANTIDAD  FROM EQUIVALENCIAS E INNER JOIN UNIDADES U ON E.UNIDAD =U.CLAVE INNER JOIN LOTES L ON L.PRODUCTO=E.PRODUCTO INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP INNER JOIN INVPISOTIENDA I ON I.PRODUCTO=L.CLAVE WHERE  L.CLAVE='" + TXTLOT.Text + "'AND I.TIENDA='" + frmPrincipal.SucursalBase + "'"
        'End If

        Dim BUSCAUNI As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LEEUN As SqlClient.SqlDataReader
        LEEUN = BUSCAUNI.ExecuteReader
        While LEEUN.Read
            CLAUN.Add(LEEUN(0))
            CBUN.Items.Add(LEEUN(1))
            LBLPRO.Text = LEEUN(2)
            LBLDES.Text = LEEUN(3)
            LBLEX.Text = LEEUN(5)
        End While
        LEEUN.Close()
        CBUN.SelectedIndex = 0

    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        VERIFICA()
        If VER = False Then
            MessageBox.Show("Algunos campos no han sido llenados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Not CARGAEXISTENCIA(CLACP(CBPRO.SelectedIndex), CType(TXTCAN.Text, Double), CLAUN(CBUN.SelectedIndex)) Then
                MessageBox.Show("La cantidad solicitada es mayor que la cantidad en existencia, no se permite agregar, favor de verificar su inventario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            GUARDAR()
        End If
    End Sub
    Public Sub GUARDAR()
        If CType(TXTCAN.Text, Double) = 0 Then
            MessageBox.Show("Especifique una cantidad mayor a cero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TXTCAN.Focus()
            TXTCAN.SelectAll()
            Exit Sub
        End If
        If Not CARGAEXISTENCIA(PRODUCTO, CType(TXTCAN.Text, Double), CLAUN(CBUN.SelectedIndex)) Then
            MessageBox.Show("La cantidad solicitada es mayor que la cantidad en existencia, no se permite guardar, favor de verificar su inventario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        'CAMBIAR A FUNCION ESTO
        Dim BUSCAREG As New SqlClient.SqlCommand("SELECT MAX(REGISTRO) FROM MERMASPISO WHERE TIENDA='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
        Dim LEER As SqlClient.SqlDataReader
        LEER = BUSCAREG.ExecuteReader
        If LEER.Read Then
            If LEER(0) Is DBNull.Value Then
                REGISTRO = 0
            Else
                REGISTRO = LEER(0) + 1
            End If

        End If
        LEER.Close()


        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If

        Dim SQLGUARDAR As New SqlClient.SqlCommand
        SQLGUARDAR.Connection = frmPrincipal.CONX
        SQLGUARDAR.CommandType = CommandType.StoredProcedure
        SQLGUARDAR.Parameters.Add("@RES", SqlDbType.VarChar, 20)
        SQLGUARDAR.Parameters.Add("@LOT", SqlDbType.VarChar, 20)
        SQLGUARDAR.Parameters.Add("@CAN", SqlDbType.Float)
        SQLGUARDAR.Parameters.Add("@UN", SqlDbType.VarChar, 10)
        SQLGUARDAR.Parameters.Add("@US", SqlDbType.VarChar, 30)
        SQLGUARDAR.Parameters.Add("@DES", SqlDbType.VarChar, 200)
        SQLGUARDAR.Parameters.Add("@REG", SqlDbType.Int)

        Dim CANT As Double
        Try
            CANT = CType(TXTCAN.Text, Double)
        Catch ex As Exception
            MessageBox.Show("Favor de especificar cantidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End Try
        SQLGUARDAR.Parameters("@RES").Value = frmPrincipal.SucursalBase
        SQLGUARDAR.Parameters("@LOT").Value = TXTLOT.Text
        SQLGUARDAR.Parameters("@CAN").Value = CANT
        SQLGUARDAR.Parameters("@UN").Value = CLAUN(CBUN.SelectedIndex)
        SQLGUARDAR.Parameters("@US").Value = frmPrincipal.USUARIO
        SQLGUARDAR.Parameters("@DES").Value = TXTDES.Text
        SQLGUARDAR.Parameters("@REG").Value = REGISTRO

        SQLGUARDAR.CommandText = "AGREGAMERMATIENDAPISO"

        SQLGUARDAR.ExecuteNonQuery()
        MessageBox.Show("La información ha sido guardada correctamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ACTIVAR(True)
        LIMPIAR()
    End Sub
    Public Sub ACTIVAR(ByVal TF As Boolean)
        CBPRO.Enabled = TF
        CBGRU.Enabled = TF
        TXTCAN.Enabled = Not TF
        TXTDES.Enabled = Not TF
        TXTLOT.Enabled = TF
        CBUN.Enabled = Not TF
        BTNGUARDAR.Enabled = Not TF
        LBLPRO.Visible = Not TF
        LBLDES.Visible = Not TF
    End Sub
    Private Sub LIMPIAR()
        TXTLOT.Text = ""
        TXTCAN.Text = ""
        TXTDES.Text = ""
        LBLUN.Text = ""
        LBLEX.Text = ""

        CBUN.Items.Clear()
    End Sub
    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        LIMPIAR()
        ACTIVAR(True)
    End Sub
    Public Sub CARGAUNIEX()
        Dim BUSCAUNEX As New SqlClient.SqlCommand("SELECT U.NOMBRE,I.CANTIDAD,P.CLAVE,P.GRUPO FROM INVPISOTIENDA I INNER JOIN LOTES L ON I.PRODUCTO=L.CLAVE INNER JOIN PRODUCTOS P ON P.CP=L.PRODUCTO  INNER JOIN UNIDADES U ON P.UVENTA=U.CLAVE WHERE I.PRODUCTO='" + TXTLOT.Text + "'AND I.TIENDA='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
        Dim LEEEX As SqlClient.SqlDataReader
        LEEEX = BUSCAUNEX.ExecuteReader
        If LEEEX.Read Then
            LBLUN.Text = LEEEX(0)
            LBLEX.Text = LEEEX(1)
            PRODUCTO = LEEEX(2)
            GRUPO = LEEEX(3)
        End If
        LEEEX.Close()
    End Sub

    Private Sub TXTLOT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTLOT.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTLOT.Text = "" Then
            Else
                CARGADATOS()
            End If
        End If
    End Sub
    Public Sub CARGADATOS()
        VERIFICALOTE()
        VERIFICALOTEINV()
        If VERLOT And VERINV Then
            CARGAUNIDADES()
            CARGAUNIEX()

            TXTLOT.Enabled = False
            ACTIVAR(False)

        ElseIf VERLOT = False Then

            MessageBox.Show("El lote no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf VERINV = False Then

            MessageBox.Show("El lote no esta en el inventario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Public Sub VERIFICA()
        If TXTCAN.Text = "" Or TXTLOT.Text = "" Or TXTDES.Text = "" Then
            VER = False
        Else
            VER = True
        End If

    End Sub

    Public Sub VERIFICALOTE()
        Dim BUSCALOTE As New SqlClient.SqlCommand("SELECT CLAVE FROM LOTES WHERE CLAVE='" + TXTLOT.Text + "'", frmPrincipal.CONX)
        Dim LEELOTE As SqlClient.SqlDataReader
        LEELOTE = BUSCALOTE.ExecuteReader
        If LEELOTE.Read Then
            VERLOT = True
        Else
            VERLOT = False
        End If
        LEELOTE.Close()

    End Sub
    Public Sub VERIFICALOTEINV()
        Dim query As String

        'If frmPrincipal.SucursalBase = "BPM" Then
        '    query = "SELECT PRODUCTO FROM INVBODEGA WHERE PRODUCTO='" + TXTLOT.Text + "'"
        'Else
        query = "SELECT PRODUCTO FROM INVPISOTIENDA WHERE PRODUCTO='" + TXTLOT.Text + "'AND TIENDA='" + frmPrincipal.SucursalBase + "'"
        'End If

        Dim BUSCALOINV As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
        Dim LEEINV As SqlClient.SqlDataReader
        LEEINV = BUSCALOINV.ExecuteReader
        If LEEINV.Read Then
            VERINV = True
        Else
            VERINV = False
        End If
        LEEINV.Close()
    End Sub

    Private Sub TXTCAN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCAN.KeyPress
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
    Private Function CARGAEXISTENCIA(ByVal PRO As String, ByVal CANT As Double, ByVal UNI As String) As Boolean

        Dim CANTEXIS As Double
        CANTEXIS = LBLEX.Text

        Dim CANTSOLI As Double
        CANTSOLI = 0
        If LBLUN.Text <> CBUN.Text Then
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

        If CANTSOLI > CANTEXIS Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub LBLUN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLUN.Click

    End Sub
    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged
        CARGAPRODUCTOS()
    End Sub

    Private Sub BTNBUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUS.Click
        frmClsBusqueda.BUSCAR("SELECT P.CLAVE,P.NOMBRE PRODUCTO,G.NOMBRE GRUPO,P.DESCRIPCION FROM PRODUCTOS P INNER JOIN GRUPOS G ON G.CLAVE=P.GRUPO WHERE P.EMPRESA=" + frmPrincipal.Empresa + " ", " AND P.NOMBRE ", " ORDER BY P.NOMBRE ", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 3, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(2))
            CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
            'CARGADATOS()
            'TXTCANT.Focus()
            'TXTCANT.SelectAll()
        End If
    End Sub
    Private Sub CARGAELGRUPO(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CBGRU.Items.Count - 1
            CBGRU.SelectedIndex = X
            If CBGRU.Text = CLA Then
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

    Private Sub frmMermasTiendasPiso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT P.CLAVE,P.NOMBRE PRODUCTO,G.NOMBRE GRUPO,P.DESCRIPCION FROM PRODUCTOS P INNER JOIN GRUPOS G ON G.CLAVE=P.GRUPO WHERE P.EMPRESA=" + frmPrincipal.Empresa + " ", " AND P.NOMBRE ", " ORDER BY P.NOMBRE ", "Búsqueda de Productos", "Nombre del Producto", "Productos(s)", 3, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                CARGAELGRUPO(frmClsBusqueda.TREG.Rows(0).Item(2))
                CARGAELPRODUCTO(frmClsBusqueda.TREG.Rows(0).Item(0))
                'CARGADATOS()
                'TXTCANT.Focus()
                'TXTCANT.SelectAll()
            End If
        End If
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        'If frmPrincipal.SucursalBase = "BPM" Then
        '    frmClsBusqueda.BUSCAR("SELECT  I.PRODUCTO LOTE,P.NOMBRE  PRODUCTO,G.NOMBRE GRUPO,I.CANTIDAD,L.FECHA FROM  INVBODEGA I INNER JOIN LOTES L ON L.CLAVE=I.PRODUCTO INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE  WHERE L.PRODUCTO='" + CLACP(CBPRO.SelectedIndex) + "' ", "NOMBRE", " ORDER BY L.FECHA", "Búsqueda de Lotes", "Lotes", "Nombre del Lote", 1, frmPrincipal.CadenaConexion, True)
        'Else
        frmClsBusqueda.BUSCAR("SELECT  I.PRODUCTO LOTE,P.NOMBRE  PRODUCTO,G.NOMBRE GRUPO,I.CANTIDAD,L.FECHA FROM  INVPISOTIENDA I INNER JOIN LOTES L ON L.CLAVE=I.PRODUCTO INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE  WHERE L.PRODUCTO='" + CLACP(CBPRO.SelectedIndex) + "' AND TIENDA='" + frmPrincipal.SucursalBase + "'", "NOMBRE", " ORDER BY L.FECHA", "Búsqueda de Lotes", "Lotes", "Nombre del Lote", 1, frmPrincipal.CadenaConexion, True)
        'End If

        'frmBusqueda.BUSCAR("SELECT  I.PRODUCTO LOTE,P.NOMBRE  PRODUCTO,G.NOMBRE GRUPO FROM  INVRESTAURANTES I INNER JOIN LOTES L ON L.CLAVE=I.PRODUCTO INNER JOIN PRODUCTOS P ON L.GRUPO=P.GRUPO AND L.PRODUCTO=P.CLAVE INNER JOIN GRUPOSARTICULOS G ON P.GRUPO=G.CLAVE WHERE L.GRUPO='" + CLAGRU(CBPRO.SelectedIndex) + "' AND L.PRODUCTO='" + CLAPRO(CBPRO.SelectedIndex) + "' AND RESTAURANTE='" + frmPrincipal.SucursalBase + "'", "NOMBRE", "CLAVE", "Búsqueda de Lotes", "Lotes", "Nombre del Lote", True)

        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTLOT.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            CARGADATOS()
        End If
    End Sub

    Private Sub CBPRO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBPRO.SelectedIndexChanged
        img = CLAIMG(CBPRO.SelectedIndex)
        BTNP1.ImageLocation = "C:/FOTOSPRICE/" + img + ".JPG"
    End Sub
End Class