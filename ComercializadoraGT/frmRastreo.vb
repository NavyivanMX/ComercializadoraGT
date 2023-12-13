Public Class frmRastreo

    Private Sub frmRastreo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,ACTIVO FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' ", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCLI.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            LBLNOM.Text = frmClsBusqueda.TREG.Rows(0).Item(1).ToString
        End If
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String
        Cursor.Current = Cursors.WaitCursor
        If RB3.Checked Then
            If RB1.Checked Then
                QUERY = "SELECT C.NOMBRE CLIENTE,N.Nota,N.Total,N.FECHA,DBO.FOLIOFACNOTA('" + frmPrincipal.Serie + "',N.NOTA)Factura FROM NOTASDEVENTA N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE AND C.TIENDA=N.TIENDA WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA='" + TXTNF.Text + "'"
                DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
                DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                QUERY = "SELECT C.NOMBRE CLIENTE, N.Nota,N.Total,(N.TOTAL-(SELECT DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))[Resta por Pagar],CONVERT(VARCHAR(10),N.FECHA,103)Fecha,convert(varchar(10),DATEADD(dd,C.DIASCREDITO,N.FECHA),103) [Fecha de Vencimiento],C.DIASCREDITO [Dias de Credito],[Dias Vencido]=DATEDIFF(dd,N.FECHA,GETDATE())-C.DIASCREDITO,DBO.FOLIOFAC('" + frmPrincipal.Serie + "',N.NOTA)Factura FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE AND C.TIENDA=N.TIENDA WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA='" + TXTNF.Text + "'"
                DGV2.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
            ElseIf RB2.Checked Then
                QUERY = "SELECT C.NOMBRE CLIENTE,N.Nota,N.Total,N.FECHA,DBO.FOLIOFACNOTA('" + frmPrincipal.Serie + "',N.NOTA)Factura FROM NOTASDEVENTA N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE AND C.TIENDA=N.TIENDA WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.FECHA>='27/11/2012' AND DBO.FOLIOFACNOTA('" + frmPrincipal.Serie + "',N.NOTA)='" + TXTNF.Text + "'"
                DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
                DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                QUERY = "SELECT C.NOMBRE CLIENTE, N.Nota,N.Total,(N.TOTAL-(SELECT DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))[Resta por Pagar],CONVERT(VARCHAR(10),N.FECHA,103)Fecha,convert(varchar(10),DATEADD(dd,C.DIASCREDITO,N.FECHA),103) [Fecha de Vencimiento],C.DIASCREDITO [Dias de Credito],[Dias Vencido]=DATEDIFF(dd,N.FECHA,GETDATE())-C.DIASCREDITO,DBO.FOLIOFAC('" + frmPrincipal.Serie + "',N.NOTA)Factura FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE AND C.TIENDA=N.TIENDA WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "'  AND N.FECHA>='27/11/2012' AND DBO.FOLIOFAC('" + frmPrincipal.Serie + "',N.NOTA)='" + TXTNF.Text + "'"
                DGV2.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
            End If

        Else
            QUERY = "SELECT C.NOMBRE CLIENTE,N.Nota,N.Total,N.FECHA,DBO.FOLIOFACNOTA('" + frmPrincipal.Serie + "',N.NOTA)Factura FROM NOTASDEVENTA N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE AND C.TIENDA=N.TIENDA WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.CLIENTE='" + TXTCLI.Text + "' AND N.FECHA>=@INI AND N.FECHA<=@FIN"
            DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
            QUERY = "SELECT C.NOMBRE CLIENTE, N.Nota,N.Total,(N.TOTAL-(SELECT DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))[Resta por Pagar],CONVERT(VARCHAR(10),N.FECHA,103)Fecha,convert(varchar(10),DATEADD(dd,C.DIASCREDITO,N.FECHA),103) [Fecha de Vencimiento],C.DIASCREDITO [Dias de Credito],[Dias Vencido]=DATEDIFF(dd,N.FECHA,GETDATE())-C.DIASCREDITO,DBO.FOLIOFAC('" + frmPrincipal.Serie + "',N.NOTA)Factura FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE AND C.TIENDA=N.TIENDA WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "'  AND N.CLIENTE='" + TXTCLI.Text + "' AND N.FECHA>=@INI AND N.FECHA<=@FIN"
            DGV2.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))

        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CARGADATOS()
    End Sub
End Class