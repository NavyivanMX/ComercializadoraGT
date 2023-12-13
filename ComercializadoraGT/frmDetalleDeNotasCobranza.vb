Public Class frmDetalleDeNotasCobranza
    Dim CLACLI As New List(Of String)
    Dim CLANOTA As New List(Of String)
    Dim query As String
    Private Sub frmDetalleDeNotasCobranza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Dim SQLSELECT As New SqlClient.SqlCommand("select C.NOMBRE CLIENTE,N.FECHA,T.NOMBRE TIPOPAGO,E.NOMBRE CAJERA,N.TOTAL FROM NOTASCOBRANZAPRO N INNER JOIN CLIENTES C ON N.TIENDA=C.TIENDA AND N.CLIENTE =C.CLAVE INNER JOIN TIPOSPAGOS T ON N.TIPOPAGO =T.CLAVE INNER JOIN EMPLEADOS E ON N.TIENDA =E.TIENDA AND N.CAJERA =E.CLAVE WHERE N.NOTA=" + TXTNOTA.Text + " AND N.TIENDA='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            LBLA.Text = LECTOR(0).ToString
            LBLB.Text = LECTOR(1).ToString
            LBLC.Text = LECTOR(2).ToString
            LBLD.Text = LECTOR(3).ToString
            LBLE.Text = LECTOR(4).ToString
        End If
        LECTOR.Close()
        SQLSELECT.Dispose()
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
        BTNIMPRIMIR.Focus()
    End Sub
    'Private Sub CHECATABLA()
    '    Dim X As Integer
    '    Dim VENTA As Double
    '    VENTA = 0
    '    For X = 0 To DGV.Rows.Count - 1
    '        VENTA = VENTA + DGV.Item(4, X).Value
    '    Next
    '    LBLTOT.Text = FormatNumber(VENTA).ToString()
    'End Sub

    Private Sub TXTNOTA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            CARGADATOS()
        End If
    End Sub
    'Private Sub CHECANOTAS()
    '    If Not OPLlenaComboBox(CBNOTA, CLANOTA, "SELECT TIENDA,NOTA FROM NOTASDEVENTA WHERE CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "' AND TIENDA='" + frmPrincipal.SucursalBase + "' ORDER BY NOTA DESC ", frmPrincipal.CadenaConexion) Then
    '        MessageBox.Show("No hay notas de este cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        LBLFEC.Text = ""
    '        LBLTOT.Text = 0
    '        DGV.DataSource = Nothing
    '        TXTNOTA.Enabled = False
    '        BTNMOSTRAR.Enabled = False
    '        Exit Sub
    '    End If
    '    TXTNOTA.Enabled = True
    '    BTNMOSTRAR.Enabled = True
    '    BTNIMPRIMIR.Enabled = True
    '    LBLFEC.Text = ""
    '    LBLTOT.Text = 0
    '    DGV.DataSource = Nothing
    'End Sub
    Private Function IMPRIMIRNOTA(ByVal LANOTA As Integer) As Boolean
        Dim QUER As String
        QUER = "SELECT T.NOMBRECOMUN,T.DIRECCION,T.CIUDAD,T.RFC,N.TOTAL,N.NOTA NOCOBRANZA,N.NOCAJA,E.NOMBRE CAJERA,TP.NOMBRE TIPOPAGO,NC.TOTAL TOTALCREDITO,NC.FECHA,A.NOTA NOTACREDITO,A.ABONO,A.SALDO,DBO.TXTRECIBO(N.TIENDA,N.NOTA)RECIBO,N.FECHA FECHAAPLICACION FROM NOTASCOBRANZAPRO N INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE INNER JOIN EMPLEADOS E ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE INNER JOIN TIPOSPAGOS TP ON N.TIPOPAGO=TP.CLAVE INNER JOIN ABONOSCREDITOS A ON N.TIENDA=A.TIENDA AND N.NOTA=A.NOTAVENTA INNER JOIN NOTASDEVENTACREDITO NC ON A.TIENDA=NC.TIENDA AND A.NOTA=NC.NOTA  WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA=" + LANOTA.ToString
        If frmPrincipal.SucursalBase = "MZT" Then
            Dim REPI As New rptTicketAbonoMZT
            IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), 1, "")
        Else
            Dim REPI As New rptTicketAbono
            IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), 1, "")
        End If

    End Function

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        If TXTNOTA.Text = "" Then
            MessageBox.Show("Introduzca un numero de nota", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        IMPRIMIRNOTA(TXTNOTA.Text)
    End Sub



    Private Sub BTNMOSTRAR_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BTNMOSTRAR.KeyPress, BTNIMPRIMIR.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNIMPRIMIR.Focus()
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