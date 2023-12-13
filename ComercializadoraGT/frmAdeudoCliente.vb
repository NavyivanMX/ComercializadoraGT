Public Class frmAdeudoCliente
    Dim query As String
    Private Sub frmAdeudoCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Public Sub CHECAADEUDO(ByVal NOMBRECLIENTE As String, ByVal CLIENTEBASE As String)
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        query = "SELECT N.Nota,(N.TOTAL-(SELECT DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))Adeudo,(Select Convert(Char(10),N.FECHA,103)) Consumo,(Select Convert(Char(10),DATEADD(dd,C.DIASCREDITO,N.FECHA),103)) Vencido FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE AND C.TIENDA=N.TIENDA WHERE N.PAGADO=0 AND DATEDIFF(dd,N.FECHA,GETDATE())>C.DIASCREDITO AND C.CLAVE='" + CLIENTEBASE + "' AND N.TIENDA='" + frmPrincipal.SucursalBase + "' GROUP BY N.NOTA,N.FECHA,C.DIASCREDITO,N.TOTAL,N.TIENDA"

        DGV.DataSource = BDLlenatabla(query, frmPrincipal.CadenaConexion)
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        
        If DGV.Rows.Count <= 0 Then
            Me.Close()
        Else
            CHECATABLA()
            LBLT.Text = NOMBRECLIENTE
            Me.ShowDialog()
        End If


    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim TOTAL As Double
        TOTAL = 0

        For X = 0 To DGV.Rows.Count - 1
            TOTAL = TOTAL + DGV.Item(1, X).Value
        Next
        LBLA.Text = FormatNumber(TOTAL).ToString()
    End Sub

    Private Sub BTNACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNACEPTAR.Click
        Me.Close()
    End Sub
End Class