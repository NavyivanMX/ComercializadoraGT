Public Class frmSeleccionaCliente
    'Dim CLACLI As New List(Of String)
    Public CLIENTEBASE As String
    Public NOMBRECLIENTEBASE As String
    Public RFCCLIENTEBASE As String
    Public FAUTO As Boolean
    Dim AbrirBusqueda As Boolean
    Private Sub frmSeleccionaCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' OPLlenaComboBox(CBCLI, CLACLI, "SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        CARGADATOS()
        If AbrirBusqueda Then
            Buscar()
        Else
            BTNBUSCAR.Focus()
        End If

    End Sub
    Private Sub ACEPTAR(ByVal CB As String, ByVal NCB As String)
        CLIENTEBASE = CB
        NOMBRECLIENTEBASE = NCB
        BTNBUSCAR.Focus()
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub
    Public Sub Mostrar(ByVal pAbrirBusqueda As Boolean)
        AbrirBusqueda = pAbrirBusqueda
        Me.ShowDialog()
    End Sub

    Private Sub frmSeleccionaCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Buscar()
        frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,RFC,FAUTO FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Clientes ", "Nombre del cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CLIENTEBASE = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            NOMBRECLIENTEBASE = frmClsBusqueda.TREG.Rows(0).Item(1).ToString
            RFCCLIENTEBASE = frmClsBusqueda.TREG.Rows(0).Item(2).ToString
            FAUTO = frmClsBusqueda.TREG.Rows(0).Item(3).ToString
            ACEPTAR(CLIENTEBASE, NOMBRECLIENTEBASE)
        End If
    End Sub
    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        Buscar()
    End Sub

    Private Sub BTNACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNACEPTAR.Click
        If TXTC.Text = "" Then
            MessageBox.Show("Introduzca una clave de cliente", "aviso", MessageBoxButtons.OK)
            TXTC.Focus()
            Exit Sub
        End If
        If LBLC.Text = "." Then
            MessageBox.Show("Introduzca una clave de cliente", "aviso", MessageBoxButtons.OK)
            TXTC.Focus()
            Exit Sub
        End If
        ACEPTAR(TXTC.Text, LBLC.Text)
    End Sub

    Private Sub TXTEFECTIVO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTC.KeyPress
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
            CARGADATOS()
            BTNACEPTAR.Focus()
        End If
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If

        Dim SQLSELECT As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE,RFC,FAUTO FROM CLIENTES WHERE CLAVE=" + TXTC.Text + " AND TIENDA='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            LBLC.Text = LECTOR(1).ToString
            CLIENTEBASE = LECTOR(0)
            NOMBRECLIENTEBASE = LECTOR(1)
            RFCCLIENTEBASE = LECTOR(2)
            FAUTO = LECTOR(3)
        End If
        LECTOR.Close()
        BTNBUSCAR.Focus()
    End Sub
End Class