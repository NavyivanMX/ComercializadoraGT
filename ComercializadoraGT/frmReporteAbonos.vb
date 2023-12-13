Public Class frmReporteAbonos
    Dim CLACLI As New List(Of String)
    Dim CLANOT As New List(Of String)
    Private Sub frmReporteAbonos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        ' OPLlenaComboBox(CBCLI, CLACLI, "SELECT CLAVE,NOMBRE,DIASCREDITO FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0 ORDER BY NOMBRE ", frmPrincipal.CadenaConexion)
    End Sub
    Private Function CHECAFECHAS() As Boolean
        If DTDE.Value.Date > DTHASTA.Value.Date Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then

            Exit Sub
        End If
        If Not CHECAFECHAS() Then
            MessageBox.Show("El rango de fechas esta incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim QUERY As String
        

        QUERY = "SELECT C.CLAVE ,C.NOMBRE CLIENTE,N.NOTA [NOTA DE VENTA],A.ABONO ABONO,(Select Convert(Char(10), N.FECHA,103)) [FECHA DE ABONO],A.NOTA[NOTA DE CREDITO] FROM NOTASCOBRANZAPRO N INNER JOIN ABONOSCREDITOS A  ON A.TIENDA=N.TIENDA AND A.NOTAVENTA=N.NOTA INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.FECHA>=@INI AND N.FECHA<=@FIN "

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()
        ' DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim query As String
        If DGV.Rows.Count <= 0 Then
        Else
            Dim cli As Integer
            cli = CType(DGV.Item(0, DGV.CurrentRow.Index).Value, Integer)
            query = "SELECT dbo.TOTALDEBECLIENTE('" + frmPrincipal.SucursalBase + "'," + cli.ToString + ")"
            Dim SQLSELECT As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
            Dim LECTOR As SqlClient.SqlDataReader
            LECTOR = SQLSELECT.ExecuteReader
            If LECTOR.Read Then
                LBLAT.Text = LECTOR(0)
                LECTOR.Close()
            Else
                LBLAT.Text = 0
                LECTOR.Close()
            End If
        End If
    End Sub
    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub

    Private Sub DGV_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        CARGAABONOS(DGV.Item(5, DGV.CurrentRow.Index).Value)
        CHECATABLA2(DGV.Item(5, DGV.CurrentRow.Index).Value)
        CHECATABLA()
    End Sub
    Private Sub CARGAABONOS(ByVal NOTA As Integer)
        Dim query As String
        query = "SELECT D.PRODUCTO CLAVE,P.NOMBRE PRODUCTO,D.CANTIDAD,PRECIO=CONVERT (NUMERIC(15,2),(D.TOTAL/D.CANTIDAD),2),D.TOTAL  FROM DETALLENOTASDEVENTACREDITO D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + NOTA.ToString + " "
        DGV2.DataSource = BDLlenatabla(query, frmPrincipal.CadenaConexion)
        DGV2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub
    Private Sub CHECATABLA2(ByVal NOTA As Integer)
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim query As String
        query = "SELECT FECHA FROM NOTASDEVENTACREDITO WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND NOTA=" + NOTA.ToString + ""
        Dim SQLSELECT As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            LBLFEC.Text = LECTOR(0)
            LECTOR.Close()
        Else
            LBLFEC.Text = 0
            LECTOR.Close()
        End If

        Dim X As Integer
        Dim TOTAL As Double
        TOTAL = 0
        For X = 0 To DGV2.Rows.Count - 1
            TOTAL = TOTAL + DGV2.Item(4, X).Value
        Next
        LBLNOT.Text = FormatNumber(TOTAL).ToString()
    End Sub
    
End Class