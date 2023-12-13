Public Class frmConfirmarDepositos
    Dim CLASUC As New List(Of String)
    Private Sub frmConfirmarDepositos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGASUCURSALES()
    End Sub
    Private Sub CARGASUCURSALES()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        Dim LEIDO As Boolean
        LEIDO = False
        Dim query As String
        query = "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE  CLAVE<>'PRUEBAS' AND CLAVE<>'PPM' AND CLAVE<>'ST' AND CLAVE<>'BPM' ORDER BY NOMBRECOMUN"
       OPLlenaComboBox(CBSUC, CLASUC, query, frmPrincipal.CadenaConexion, "Todas las sucursales", "''")

        If CBSUC.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBSUC.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CBSUC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBSUC.SelectedIndexChanged
        If CBSUC.SelectedIndex = 0 Then
            BTNDEPOSITOS.Enabled = False
        Else
            BTNDEPOSITOS.Enabled = True
        End If
    End Sub
    Private Function CHECAFECHAS() As Boolean
        If DTDE.Value.Date > DTHASTA.Value.Date Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim TOT, NOTAS As Double
        TOT = 0
        NOTAS = 0
        For X = 0 To DGV.Rows.Count - 1
            TOT = TOT + DGV.Item(5, X).Value
            'NOTAS = NOTAS + DGV.Item(3, X).Value
        Next
        'LBLNOTAS.Text = FormatNumber(NOTAS).ToString
        LBLTOT.Text = FormatNumber(TOT).ToString
    End Sub
    Private Sub CARGARDATOS()
        If Not CHECAFECHAS() Then
            Exit Sub
        End If
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String
        If CBSUC.SelectedIndex = 0 Then
            QUERY = "SELECT S.NOMBRECOMUN TIENDA,D.BANCO,D.FICHA,CONVERT(VARCHAR(10),D.FECHADIA,103)FECHAVENTA,CONVERT(VARCHAR(8),D.HORA,108)HORA,D.CANTIDAD IMPORTE,D.FECHA FECHADEP,D.CUENTA,D.CONFIRMADO [Confirmar Deposito],D.Registro ,D.TIENDA [Clave Res] FROM DEPOSITOS D INNER JOIN TIENDAS S  ON D.TIENDA=S.CLAVE WHERE D.FECHA>=@INI AND D.FECHA<@FIN ORDER BY D.FECHA"
        Else
            QUERY = "SELECT S.NOMBRECOMUN TIENDA,D.BANCO,D.FICHA,CONVERT(VARCHAR(10),D.FECHADIA,103)FECHAVENTA,CONVERT(VARCHAR(8),D.HORA,108)HORA,D.CANTIDAD IMPORTE,D.FECHA FECHADEP,D.CUENTA,D.CONFIRMADO [Confirmar Deposito],D.Registro ,D.TIENDA [Clave Res] FROM DEPOSITOS D INNER JOIN TIENDAS S ON D.TIENDA=S.CLAVE WHERE D.TIENDA='" + CLASUC(CBSUC.SelectedIndex) + "' AND D.FECHA>=@INI AND D.FECHA<@FIN ORDER BY D.FECHA"
        End If

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()

        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).ReadOnly = True
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(3).ReadOnly = True
        DGV.Columns(4).ReadOnly = True
        DGV.Columns(5).ReadOnly = True
        DGV.Columns(6).ReadOnly = True
        DGV.Columns(7).ReadOnly = True
        DGV.Columns(9).ReadOnly = True
        DGV.Columns(10).ReadOnly = True
        DGV.Columns(10).Visible = False
        BTNDEPOSITOS.Enabled = True
        CHECATABLA()
    End Sub
    
    Private Sub BTNDEPOSITOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNDEPOSITOS.Click
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim XYZ As Short
        XYZ = MessageBox.Show("Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If XYZ = 6 Then
            Dim X As Integer
            Dim SQL As New SqlClient.SqlCommand("", frmPrincipal.CONX)
            'SQL.ExecuteNonQuery()
            For X = 0 To DGV.Rows.Count - 1
                If DGV.Item(8, X).Value = True Then
                    SQL.CommandText = "UPDATE DEPOSITOS SET CONFIRMADO=1 WHERE TIENDA='" + DGV.Item(10, X).Value + "' AND REGISTRO='" + DGV.Item(9, X).Value.ToString + "'"
                    SQL.ExecuteNonQuery()
                End If
            Next
            MessageBox.Show("Los depositos han sido confirmados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        Dim REP As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim QUERY As String
        If CBSUC.SelectedIndex = 0 Then
            QUERY = "SELECT S.NOMBRECOMUN,D.BANCO,D.FICHA,D.FECHADIA,D.HORA,D.CANTIDAD IMPORTE,D.CUENTA,D.FECHA,L.NUMCUENTA FROM DEPOSITOS D INNER JOIN TIENDAS S ON D.TIENDA=S.CLAVE INNER JOIN LASCUENTAS L ON D.CUENTA=L.CUENTA AND D.BANCO=L.BANCO WHERE D.FECHA>=@INI AND D.FECHA<@FIN ORDER BY D.FECHA"
            REP = New rptDepositosSucursales2
        Else
            QUERY = "SELECT S.NOMBRECOMUN,D.BANCO,D.FICHA,D.FECHADIA,D.HORA,D.CANTIDAD IMPORTE,D.CUENTA,D.FECHA,L.NUMCUENTA FROM DEPOSITOS D INNER JOIN TIENDAS S ON D.TIENDA=S.CLAVE INNER JOIN LASCUENTAS L ON D.CUENTA=L.CUENTA AND D.BANCO=L.BANCO WHERE D.TIENDA='" + CLASUC(CBSUC.SelectedIndex) + "' AND D.FECHA>=@INI AND D.FECHA<@FIN ORDER BY D.FECHA"
            REP = New rptDepositosSucursales
        End If

        MOSTRARREPORTE(REP, "Ventana de depositos registrados", BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1)), "Enviar One Note 2007")
        ' CI.MOSTRAR1(REP, "Ventana de Depositos Registrados Moditelas", QUERY, frmPrincipal.CadenaConexion, LPARA, LTIPO, LVALO)
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGARDATOS()
    End Sub
End Class