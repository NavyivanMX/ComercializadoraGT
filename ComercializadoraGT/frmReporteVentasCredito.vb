Public Class frmReporteVentasCredito
    Dim CLAGRU As New List(Of String)
    Dim CLAPROD As New List(Of String)
    Dim QUERY, QUERY2, QUERY3, QUERY4 As String
    Private Sub frmReporteVentasCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGAGRUPOS()
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

        QUERY = "SELECT G.NOMBRE GRUPO,P.NOMBRE PRODUCTO,SUM(D.CANTIDAD)CANTIDAD,SUM(D.TOTAL)[VENTA $$] FROM NOTASDEVENTAcredito N INNER JOIN DETALLENOTASDEVENTAcredito D    ON N.TIENDA=D.TIENDA AND N.NOTA=D.NOTA INNER JOIN PRODUCTOS P   ON P.CLAVE=D.PRODUCTO INNER JOIN GRUPOS G   ON G.CLAVE=P.GRUPO WHERE N.FECHA>=@INI AND N.FECHA<=@FIN  "

        QUERY3 = "SELECT T.NOMBRECOMUN TIENDA,G.NOMBRE GRUPO,P.NOMBRE PRODUCTO,SUM(D.CANTIDAD)CANTIDAD,SUM(D.TOTAL)[VENTA $$],FECHAINI='" + DTDE.Value + "',FECHAFIN='" + DTHASTA.Value + "'   FROM NOTASDEVENTAcredito N INNER JOIN DETALLENOTASDEVENTAcredito D    ON N.TIENDA=D.TIENDA AND N.NOTA=D.NOTA INNER JOIN PRODUCTOS P   ON P.CLAVE=D.PRODUCTO INNER JOIN GRUPOS G   ON G.CLAVE=P.GRUPO INNER JOIN TIENDAS T ON T.CLAVE=N.TIENDA WHERE N.FECHA>=@INI AND N.FECHA<=@FIN  "

        If CBGRU.SelectedIndex = 0 Then
            If CBPRO.SelectedIndex = 0 Then
            Else
            End If
        Else
            If CBPRO.SelectedIndex = 0 Then
                QUERY = QUERY + "and G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' "

                QUERY3 = QUERY3 + "and G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' "
            Else
                QUERY = QUERY + " AND G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' AND P.CLAVE='" + CLAPROD(CBPRO.SelectedIndex) + "'  "

                QUERY3 = QUERY3 + " AND G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' AND P.CLAVE='" + CLAPROD(CBPRO.SelectedIndex) + "'  "
            End If
        End If
        QUERY = QUERY + " AND N.TIENDA='" + frmPrincipal.SucursalBase + "'  GROUP BY G.NOMBRE,P.NOMBRE "

        QUERY3 = QUERY3 + " AND N.TIENDA='" + frmPrincipal.SucursalBase + "'  GROUP BY G.NOMBRE,P.NOMBRE,P.PRECIO,T.NOMBRECOMUN "
      

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()




    End Sub
    Private Sub CARGAGRUPOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        CBGRU.Items.Clear()
        CLAGRU.Clear()
        CBGRU.Items.Add("Todos los grupos")
        CLAGRU.Add("")
        Dim SQLGRUPO As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM GRUPOS WHERE ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LECGRUPO As SqlClient.SqlDataReader
        LECGRUPO = SQLGRUPO.ExecuteReader
        While LECGRUPO.Read
            CLAGRU.Add(LECGRUPO(0))
            CBGRU.Items.Add(LECGRUPO(1))
        End While
        LECGRUPO.Close()
        Try
            CBGRU.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CARGAPRODUCTOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        CBPRO.Items.Clear()
        CLAPROD.Clear()
        CBPRO.Items.Add("Todos los productos")
        CLAPROD.Add("")
        Dim SQLPRO As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM PRODUCTOS WHERE GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "' AND ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " AND CLAVE<>'CREDITO' AND CLAVE<>'999' ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LECPRO As SqlClient.SqlDataReader
        LECPRO = SQLPRO.ExecuteReader
        While LECPRO.Read
            CLAPROD.Add(LECPRO(0))
            CBPRO.Items.Add(LECPRO(1))
        End While
        LECPRO.Close()
        Try
            CBPRO.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
        BTNIMPRIMIR.Focus()
    End Sub
    Private Sub CHECATABLA()

        Dim X As Integer
        Dim VENTA, COSTO, CANT As Double
        VENTA = 0
        ' COSTO = 0
        CANT = 0
        For X = 0 To DGV.Rows.Count - 1
            VENTA = VENTA + DGV.Item(3, X).Value
            ' COSTO = COSTO + DGV.Item(3, X).Value
            CANT = CANT + DGV.Item(2, X).Value
        Next
        LBLV.Text = FormatNumber(VENTA).ToString()
        LBLART.Text = FormatNumber(CANT).ToString()

        Dim TOT As Double
        TOT = 0
        Dim QUERY As String
        QUERY = "SELECT CONVERT(VARCHAR (MAX),dbo.null2numeric(SUM(N.TOTAL))) FROM NOTASDEVENTA N WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND FECHA>='" + DTDE.Value.Date + "' and fecha<='" + DTHASTA.Value.Date.AddDays(1) + "' AND N.TIPOPAGO=2"
        Dim SQLSELECT As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            LBLT.Text = LECTOR(0)
        End If
        LECTOR.Close()


        Dim SQLS As New SqlClient.SqlCommand("SELECT CONVERT(VARCHAR (MAX),dbo.null2numeric(SUM(N.TOTAL))) FROM NOTASDEVENTA N WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND FECHA>='" + DTDE.Value.Date + "' and fecha<='" + DTHASTA.Value.Date.AddDays(1) + "' AND N.TIPOPAGO=1 ", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQLS.ExecuteReader
        If LEC.Read Then
            LBLCRE.Text = LEC(0)
        End If
        LEC.Close()

        Dim SQLS2 As New SqlClient.SqlCommand("SELECT CONVERT(VARCHAR (MAX),dbo.null2numeric(SUM(N.TOTAL))) FROM NOTASDEVENTA N WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND FECHA>='" + DTDE.Value.Date + "' and fecha<='" + DTHASTA.Value.Date.AddDays(1) + "' AND N.TIPOPAGO=3 ", frmPrincipal.CONX)
        Dim LEC2 As SqlClient.SqlDataReader
        LEC2 = SQLS2.ExecuteReader
        If LEC2.Read Then
            LBLC.Text = LEC2(0)
        End If
        LEC2.Close()
    End Sub

    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged
        CARGAPRODUCTOS()
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        frmPrincipal.CHECACONX()


        Dim LPARA As New List(Of String)
        Dim LVALO As New List(Of DateTime)
        Dim LTIPO As New List(Of SqlDbType)

        LPARA.Add("@INI")
        LPARA.Add("@FIN")
        LTIPO.Add(SqlDbType.DateTime)
        LTIPO.Add(SqlDbType.DateTime)
        LVALO.Add(DTDE.Value.Date)
        LVALO.Add(DTHASTA.Value.Date.AddDays(1))

        Dim REPI As New rptReporteVentas
        Dim CI As New clsImprimir
        CI.MOSTRAR1(REPI, "Reporte de ventas", QUERY3, frmPrincipal.CadenaConexion, LPARA, LTIPO, LVALO)
    End Sub

    Private Sub GUARDAR()
        Dim REPI As New rptReporteVentas
        GUARDARREPORTE(REPI, BDLlenatabla(QUERY3, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1)), CrystalDecisions.Shared.ExportFormatType.Excel, "excel", "xls", "¿Desea guardar el reporte?", "Reporte ventas", "Enviar One Note 2007")
    End Sub
    Private Sub LBLTCR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLTCR.Click
        guardar()
    End Sub

    Private Sub frmReporteVentasCredito_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS  ", " WHERE NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Productos", "Nombre del Producto", "Productos(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLAGRU, CBGRU, frmClsBusqueda.TREG.Rows(0).Item(1).ToString)
                OPCargaX(CLAPROD, CBPRO, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
    End Sub
End Class