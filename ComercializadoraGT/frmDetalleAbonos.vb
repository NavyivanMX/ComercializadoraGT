Public Class frmDetalleAbonos
    Dim CLACLI As New List(Of String)
    Dim CLANOTA As New List(Of String)
    Dim query As String
    Private Sub frmDetalleAbonos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        ACTIVAR(True)
    End Sub
    Public Sub MOSTRAR(ByVal NOTA As String)
        TXTNOTA.Text = NOTA
        CARGADATOS()
        Me.ShowDialog()
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        If V Then
            TXTNOTA.Focus()
            TXTNOTA.SelectAll()
        Else
            ' TXTNOM.Focus()
        End If

    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        Dim query As String
        query = "SELECT A.ABONO,A.SALDO,A.FECHA,A.NotaVenta [Nota de Venta],T.NOMBRE TIPOPAGO FROM ABONOSCREDITOS A INNER JOIN NOTASDEVENTA N ON A.TIENDA=N.TIENDA AND A.NOTAVENTA=N.NOTA INNER JOIN TIPOSPAGOS T ON N.TIPOPAGO=T.CLAVE WHERE A.TIENDA='" + frmPrincipal.SucursalBase + "' AND A.NOTA=" + TXTNOTA.Text
        DGV.DataSource = BDLlenatabla(query, frmPrincipal.CadenaConexion)
        'DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()

        Dim SQLSELECT As New SqlClient.SqlCommand("SELECT N.FECHA,C.NOMBRE CLIENTE  FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON N.TIENDA=C.TIENDA AND N.CLIENTE=C.CLAVE WHERE N.NOTA=" + TXTNOTA.Text + " AND N.TIENDA='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            LBLFEC.Text = LECTOR(0).ToString
            LBLC.Text = LECTOR(1).ToString
        End If
        LECTOR.Close()
        SQLSELECT.Dispose()
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        frmClsBusqueda.BUSCAR("SELECT C.CLAVE [CLAVE CLIENTE],C.NOMBRE CLIENTE,N.NOTA,N.FECHA FROM NOTASDEVENTA N INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND N.CLIENTE=C.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' ", " AND C.NOMBRE", " ORDER BY N.NOTA DESC", "Búsqueda de notas por cliente", "Nombre del cliente", "Nota(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTNOTA.Text = frmClsBusqueda.TREG.Rows(0).Item(2)
            CARGADATOS()
        End If
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim VENTA As Double
        VENTA = 0
        For X = 0 To DGV.Rows.Count - 1
            VENTA = VENTA + DGV.Item(0, X).Value
        Next
        LBLTOT.Text = FormatNumber(VENTA)
    End Sub

    Private Sub TXTNOTA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            CARGADATOS()
        End If
    End Sub


    Private Sub TXTCP_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOTA.KeyPress
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
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class