Public Class frmVentaDiaria
    Dim CLATI As New List(Of String)
    Private Sub frmVentaDiaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGATIENDA()
    End Sub
    Private Sub CARGATIENDA()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
       OPLlenaComboBox(CBTI, CLATI, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE  CLAVE<>'PRUEBAS' AND CLAVE<>'ST' AND CLAVE<>'PPM' AND CLAVE<>'BPM' ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion, "Todos las tiendas", "")
        If CBTI.Items.Count > 0 Then

        End If

        Try
            CBTI.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String

        QUERY = "SELECT FECHA,TIENDA,SUM(EFECTIVO)EFECTIVO,SUM(TARJETA)TARJETA,SUM(CHEQUE)CHEQUE,SUM(TRANSFERENCIA)TRANSFERENCIA,(SUM(EFECTIVO)+SUM(TARJETA)+SUM(CHEQUE)+SUM(TRANSFERENCIA))TOTAL,SUM([VENTA CREDITO])[VENTA CREDITO] FROM VENTAPORTIPOPAGO WHERE FECHA>=@INI AND FECHA<=@FIN "
        If CBTI.SelectedIndex = 0 Then

        Else
            QUERY = QUERY + " AND TIENDA='" + CBTI.Text + "' "
        End If
        QUERY = QUERY + " AND TIENDA<>'PRUEBAS' AND TIENDA<>'TESTING' AND TIENDA<>'PRODUCCION' AND TIENDA<>'BODEGA PRICE MARKET' GROUP BY FECHA,TIENDA ORDER BY FECHA"

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))

        DGV.Refresh()
        'DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim E, T, C, TRA, CRE As Double
        E = 0
        T = 0
        C = 0
        TRA = 0
        CRE = 0
        For X = 0 To DGV.Rows.Count - 1
            E = E + DGV.Item(2, X).Value
            T = T + DGV.Item(3, X).Value
            C = C + DGV.Item(4, X).Value
            TRA = TRA + DGV.Item(5, X).Value
            CRE = CRE + DGV.Item(7, X).Value
        Next
        LBLE.Text = FormatNumber(E).ToString()
        LBLT.Text = FormatNumber(T).ToString()
        LBLC.Text = FormatNumber(C).ToString()
        LBLTTRA.Text = FormatNumber(TRA).ToString()
        LBLTCRE.Text = FormatNumber(CRE).ToString()

    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub
End Class
