Public Class frmDetalleDeNotaCredito
    Dim CLACLI As New List(Of String)
    Dim CLANOTA As New List(Of String)
    Dim query As String
    Private Sub frmDetalleDeNotaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        'CBNOTA.Enabled = False
        'If Not OPLlenaComboBox(CBCLI, CLACLI, "SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO =1 AND CLAVE<>0 ORDER BY NOMBRE", frmPrincipal.CadenaConexion) Then
        '    MessageBox.Show("No hay clientes dados de alta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If
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
    'Private Sub CHECANOTAS()
    '    If Not OPLlenaComboBox(CBNOTA, CLANOTA, "SELECT  TIENDA,NOTA FROM NOTASDEVENTACREDITO WHERE CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "' AND TIENDA='" + frmPrincipal.SucursalBase + "' ORDER BY NOTA DESC ", frmPrincipal.CadenaConexion) Then
    '        MessageBox.Show("No hay notas a credito de este cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        LBLFEC.Text = ""
    '        LBLTOT.Text = 0
    '        DGV.DataSource = Nothing
    '        CBNOTA.Enabled = False
    '        BTNMOSTRAR.Enabled = False
    '        Exit Sub
    '    End If
    '    CBNOTA.Enabled = True
    '    BTNMOSTRAR.Enabled = True
    '    BTNIMPRIMIR.Enabled = True
    '    LBLFEC.Text = ""
    '    LBLTOT.Text = 0
    '    DGV.DataSource = Nothing
    'End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        query = "SELECT P.NOMBRE PRODUCTO,D.CANTIDAD,PRECIO=CONVERT (NUMERIC(15,2),(D.TOTAL/D.CANTIDAD),2),D.DESCUENTO,D.TOTAL  FROM DETALLENOTASDEVENTACREDITO D INNER JOIN NOTASDEVENTACREDITO N ON N.TIENDA=D.TIENDA AND D.NOTA=N.NOTA INNER JOIN PRODUCTOS P ON P.CLAVE=D.PRODUCTO WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA=" + TXTNOTA.Text + " "

        DGV.DataSource = BDLlenatabla(query, frmPrincipal.CadenaConexion)
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()

        Dim SQLSELECT As New SqlClient.SqlCommand("SELECT N.FECHA,C.NOMBRE CLIENTE FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON N.TIENDA=C.TIENDA AND N.CLIENTE=C.CLAVE WHERE N.NOTA=" + TXTNOTA.Text + " AND N.TIENDA='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            LBLFEC.Text = LECTOR(0).ToString
            LBLC.Text = LECTOR(1).ToString            
        End If
        LECTOR.Close()
        SQLSELECT.Dispose()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim VENTA As Double
        VENTA = 0
        For X = 0 To DGV.Rows.Count - 1
            VENTA = VENTA + DGV.Item(4, X).Value
        Next
        LBLTOT.Text = FormatNumber(VENTA).ToString()
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        frmClsBusqueda.BUSCAR("SELECT C.CLAVE [CLAVE CLIENTE],C.NOMBRE CLIENTE,N.NOTA,N.FECHA FROM NOTASDEVENTAcredito N INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND N.CLIENTE=C.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' ", " AND C.NOMBRE", " ORDER BY N.NOTA DESC", "Búsqueda de notas por cliente", "Nombre del cliente", "Nota(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTNOTA.Text = frmClsBusqueda.TREG.Rows(0).Item(2)
            CARGADATOS()
        End If
        BTNIMPRIMIR.Focus()
    End Sub
    Public Function IMPRIMIRNOTA(ByVal LANOTA As Integer) As Boolean
        Try
            frmPrincipal.CHECACONX()
            Dim QUER As String
            QUER = "SELECT S.NOMBRECOMUN,CL.NOMBRE CLIENTE,S.NOMBREFISCAL,D.NOTA,D.PRODUCTO CODIGO,P.NOMBRECORTO PRODUCTO,D.CANTIDAD,PRECIO=(D.TOTAL/D.CANTIDAD),D.TOTAL,SUBTOTAL=DBO.ELSUBTOTAL(D.PRODUCTO,D.TOTAL),IVA=DBO.ELIVA(D.PRODUCTO,D.TOTAL),CONVERT(VARCHAR(10),E.CLAVE) EMPLEADO,N.FECHA,S.DIRECCION,S.CIUDAD,S.RFC,S.TELEFONO,N.NOCAJA,TIPO='NOTA',VUNI='',D.DESCUENTO,S.COMENTARIO5 COMENTARIO1,S.COMENTARIO6 COMENTARIO2,S.COMENTARIO7 COMENTARIO3,S.COMENTARIO8 COMENTARIO4,CL.TELEFONO TEL,CL.DIRECCION DIR,S.CP,CR.RFC R,VNOM=S.COLONIA  FROM DETALLENOTASDEVENTACREDITO D INNER JOIN TIENDAS S ON D.TIENDA=S.CLAVE INNER JOIN PRODUCTOS P  ON D.PRODUCTO=P.CLAVE INNER JOIN NOTASDEVENTACREDITO N   ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA INNER JOIN EMPLEADOS E  ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE  INNER JOIN CLIENTES CL   ON CL.CLAVE=N.CLIENTE AND N.TIENDA=CL.TIENDA left JOIN CLIENTERFC CR ON CR.CLIENTE=CL.CLAVE AND CL.TIENDA=CR.TIENDA AND CR.REGISTRO=0 WHERE S.CLAVE='" + frmPrincipal.SucursalBase + "' AND  N.NOTA=" + TXTNOTA.Text + "  "
            If frmPrincipal.SucursalBase = "MZT" Then
                Dim REPI As New rptNotaDeVentaCreditoMZT
                IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), 1, "")
            Else
                Dim REPI As New rptNotaDeVentaCredito
                IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), 1, "")
            End If

        Catch ex As Exception
            Dim xyz As Short
            xyz = MessageBox.Show("No se imprimió la nota, ¿Desea volver a intentar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz = 6 Then
                Return False
            Else
                ' MessageBox.Show("Utilice la opción reimprimir nota ( " + TXTNOTA.Text + " )", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return True
            End If
        End Try
        Return True
    End Function

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        If TXTNOTA.Text = "" Then
            MessageBox.Show("Introduzca un numero de nota", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        IMPRIMIRNOTA(TXTNOTA.Text)
    End Sub

    Private Sub TXTNOTA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOTA.KeyPress
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