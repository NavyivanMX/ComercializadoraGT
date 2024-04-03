Public Class frmReporteAdeudos
    Dim CLACLI As New List(Of String)
    Dim CLACRE As New List(Of Integer)
    Dim QUERY As String
    Dim CC As New ColorConverter
    Dim QUER As String


    Private Sub frmReporteAdeudos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        If Not CARGACLIENTES() Then
            MessageBox.Show("No hay adeudos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Function CARGACLIENTES() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        CLACLI.Clear()
        CLACRE.Clear()
        Dim SQLCLI As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE,DIASCREDITO FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0  ORDER BY NOMBRE ", frmPrincipal.CONX)
        Dim LECCLI As SqlClient.SqlDataReader
        LECCLI = SQLCLI.ExecuteReader
        While LECCLI.Read
            CLACLI.Add(LECCLI(0))
            CBCLI.Items.Add(LECCLI(1))
            CLACRE.Add(LECCLI(2))
        End While
        LECCLI.Close()

        Try
            CBCLI.SelectedIndex = 0
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function DgvCellEstilo(ByVal FONDO As Integer, ByVal FUENTE As Integer) As DataGridViewCellStyle
        Dim RESTILO As New DataGridViewCellStyle
        RESTILO.BackColor = CC.ConvertFromString(FONDO)
        RESTILO.ForeColor = CC.ConvertFromString(FUENTE)
        Return RESTILO
    End Function
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim AD, AB, AT As Double
        AD = 0
        AB = 0
        AT = 0
        For X = 0 To DGV.Rows.Count - 1
            AD = AD + DGV.Item(1, X).Value
            If DGV.Item(2, X).Value Is DBNull.Value Then
            Else
                AB = AB + DGV.Item(2, X).Value
            End If
        Next
        LBLAB.Text = FormatNumber(AB).ToString()
        LBLAT.Text = FormatNumber(AD - AB).ToString()
        LBLAD.Text = FormatNumber(AD).ToString


        For Each Row As DataGridViewRow In DGV.Rows
            For X = 0 To DGV.Rows.Count - 1
                If DGV.Item(5, X).Value > CLACRE(CBCLI.SelectedIndex) Then
                    DGV.Item(5, X).Style = DgvCellEstilo(-65536, -1)
                End If
            Next
        Next

    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        QUERY = "SELECT N.NOTA,N.TOTAL,SUM(A.ABONO) ABONOS,(Select Convert(Char(10), N.FECHA,103)) CONSUMO,(Select Convert(Char(10), MAX(A.FECHA),103))[ULTIMO PAGO],DATEDIFF ( dd , n.fecha , getdate()) [DIAS TRANSCURRIDOS],DBO.FOLIOFAC('" + frmPrincipal.Serie + "',N.NOTA)Factura FROM NOTASDEVENTACREDITO N LEFT JOIN ABONOSCREDITOS A ON N.TIENDA=A.TIENDA AND N.NOTA=A.NOTA WHERE  N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "' AND N.PAGADO=0 GROUP BY N.NOTA,N.TOTAL,N.FECHA "

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()


    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub

    Private Sub DGV_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV.Sorted
        CHECATABLA()
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        IMPRIMIR()
    End Sub
   
    Private Sub IMPRIMIR()
        Dim REPI As New rptAdeudos
        QUER = "SELECT C.NOMBRE CLIENTE,N.NOTA,N.TOTAL,DBO.ADEUDOCREDITO(N.TIENDA,N.NOTA) ABONOS, (Select Convert(Char(10), N.FECHA,103)) CONSUMO, (Select Convert(Char(10), MAX(A.FECHA),103))[ULTIMO PAGO],DATEDIFF ( dd , n.fecha , getdate()) [DIAS TRANSCURRIDOS], TOTALADEUDO=DBO.TOTALDEBECLIENTE(N.TIENDA,N.CLIENTE),C.DIASCREDITO,DBO.FOLIOFACCC2(N.TIENDA,N.NOTA,1)Factura FROM NOTASDEVENTACREDITO N LEFT JOIN ABONOSCREDITOS A ON N.TIENDA=A.TIENDA AND N.NOTA=A.NOTA INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE WHERE N.PAGADO=0 AND N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.CLIENTE=" + CLACLI(CBCLI.SelectedIndex) + " GROUP BY N.NOTA,N.TOTAL,N.FECHA,C.NOMBRE,N.TIENDA,N.CLIENTE,C.DIASCREDITO "
        MOSTRARREPORTE(REPI, "Reporte de adeudos", BDLlenatabla(QUER, frmPrincipal.CadenaConexion), "")
    End Sub
    Private Sub GUARDAR()
        Dim REPI As New rptAdeudos
        QUER = "SELECT C.NOMBRE CLIENTE,N.NOTA,N.TOTAL,DBO.ADEUDOCREDITO(N.TIENDA,N.NOTA) ABONOS, (Select Convert(Char(10), N.FECHA,103)) CONSUMO, (Select Convert(Char(10), MAX(A.FECHA),103))[ULTIMO PAGO],DATEDIFF ( dd , n.fecha , getdate()) [DIAS TRANSCURRIDOS], TOTALADEUDO=DBO.TOTALDEBECLIENTE(N.TIENDA,N.CLIENTE),C.DIASCREDITO FROM NOTASDEVENTACREDITO N LEFT JOIN ABONOSCREDITOS A ON N.TIENDA=A.TIENDA AND N.NOTA=A.NOTA INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE WHERE N.PAGADO=0 AND N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.CLIENTE=" + CLACLI(CBCLI.SelectedIndex) + " GROUP BY N.NOTA,N.TOTAL,N.FECHA,C.NOMBRE,N.TIENDA,N.CLIENTE,C.DIASCREDITO"
        GUARDARREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), CrystalDecisions.Shared.ExportFormatType.Excel, "excel", "xls", "¿Desea guardar el reporte?", "Reporte adeudos", "Enviar One Note 2007")
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub

    Private Sub frmReporteAdeudos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0", " AND NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLACLI, CBCLI, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
                CARGADATOS()
            End If
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,DIASCREDITO FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0", " AND NOMBRE", "ORDER BY NOMBRE", "Búsqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            OPCargaX(CLACLI, CBCLI, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            CARGADATOS()
        End If
    End Sub
End Class