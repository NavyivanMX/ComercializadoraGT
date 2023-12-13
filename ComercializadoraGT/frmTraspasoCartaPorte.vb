Public Class frmTraspasoCartaPorte
    Dim LVE As New List(Of String)
    Dim LCHO As New List(Of String)
    Dim NOTRAS As String
    Private Sub frmTraspasoCartaPorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        OPLlenaComboBox(CBVE, LVE, "SELECT CLAVE,NOMBRE FROM VEHICULOSCARTAPORTE WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        OPLlenaComboBox(CBCHO, LCHO, "SELECT CLAVE,NOMBRE FROM CHOFERESCARTAPORTE WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)

    End Sub
    Public Sub MOSTRAR(ByVal VNOTRAS As String)
        NOTRAS = VNOTRAS
        Me.ShowDialog()
    End Sub

    Private Sub BTNGUARDAR_Click(sender As Object, e As EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub
    Private Sub GUARDAR()
        If CadenaVacia(TXTMONTO.Text) Then
            TXTMONTO.Text = "0"
        End If

        If OPMsgPreguntarSiNo("¿Desea generar el comprobante Traslado con Carta Porte?") Then
            If Not frmPrincipal.CHECACONX Then
                Exit Sub
            End If
            Dim EJE As String
            EJE = BDEjecutarSql("EXEC SPGENERACOMPROBANTETRASLADO '" + frmPrincipal.EmisorBase + "'," + NOTRAS + ",@INI," + LVE(CBVE.SelectedIndex) + ",'" + TXTASEMA.Text + "','" + TXTPOLMA.Text + "'," + TXTMONTO.Text + ",'" + LCHO(CBCHO.SelectedIndex) + "'", frmPrincipal.CadenaConexion, SUMARTIEMPOAFECHA(DTNAC.Value, DTHORA.Value), DTNAC.Value)
            If EJE = "OK" Then
                OPMsgOK("El comprobante ha sido generado exitosamente")
                Me.Close()
            Else
                OPMsgError(EJE)
                Me.Close()
            End If

        End If
    End Sub
End Class