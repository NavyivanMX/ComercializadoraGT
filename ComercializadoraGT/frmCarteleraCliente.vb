Public Class frmCarteleraCliente
    Dim LCLI As New List(Of String)
    Private Sub frmCarteleraCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        Cursor = Cursors.WaitCursor
        OPLlenaCLB(CLB, LCLI, "select C.CLAVE CLAVE,C.NOMBRE +' $'+ CONVERT(VARCHAR(50), DBO.TOTALDEBECLIENTE('" + frmPrincipal.SucursalBase + "', C.CLAVE)) FROM  CLIENTES C WHERE C.TIENDA='" + frmPrincipal.SucursalBase + "' AND c.activo=1  and DBO.TOTALDEBECLIENTE('" + frmPrincipal.SucursalBase + "', C.CLAVE)>0 ", frmPrincipal.CadenaConexion)
        CHECATABLA()
        Cursor = Cursors.Default
        CHKTA.Checked = True
    End Sub

    Private Sub CHKCOM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKCOM.CheckedChanged
        Dim X As Integer
        For X = 0 To CLB.Items.Count - 1
            CLB.SetItemChecked(X, CHKCOM.Checked)
        Next
    End Sub
    Private Sub CARGADATOS()
        Dim SQL As New SqlClient.SqlCommand("DELETE FROM TEMPCARTELERACLIENTES", frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
        Dim X As Integer
        For X = 0 To CLB.Items.Count - 1
            If CLB.GetItemChecked(X) Then
                SQL.CommandText = "INSERT INTO TEMPCARTELERACLIENTES VALUES ('" + LCLI(X) + "')"
                SQL.ExecuteNonQuery()
            End If
        Next
        Dim QUERY As String
        QUERY = "SELECT C.NOMBRE CLIENTE,C.CREDITO,C.DIASCREDITO [Dias de Credito],N.NOTA Ticket,DBO.FOLIOFAC(T.SERIEFAC,N.NOTA) Factura,N.Total,CONVERT(VARCHAR(10),N.FECHA,103)[Fecha Emisión],convert(varchar(10),DATEADD(dd,C.DIASCREDITO,N.FECHA),103) [Fecha de Vencimiento],DBO.CREDITOPORVENCER(N.TIENDA,NOTA,0,@INI)[Adeudo Sin Vencer],DBO.CREDITOPORVENCER(N.TIENDA,NOTA,3,@INI)[Por Vencer],DBO.CREDITOPORVENCER(N.TIENDA,NOTA,30,@INI)[1 a 30],DBO.CREDITOPORVENCER(N.TIENDA,NOTA,60,@INI)[31 a 60],DBO.CREDITOPORVENCER(N.TIENDA,NOTA,90,@INI)[61 a 90],DBO.CREDITOPORVENCER(N.TIENDA,NOTA,91,@INI)[Mas de 90],(N.TOTAL-(SELECT DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))Adeudo,[Dias Vencido]=DATEDIFF(dd,N.FECHA,GETDATE())-C.DIASCREDITO FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE AND N.TIENDA=C.TIENDA INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE "
        'If CHKEP.Checked Then
        'Else
        '    QUERY += " INNER JOIN DATOSCREDITOCLIENTES DC ON C.CLAVE=DC.CLIENTE "
        'End If
        QUERY += " WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.PAGADO = 0 "
        'AND DATEDIFF(dd,N.FECHA,@INI)-C.DIASCREDITO>=-3 
        QUERY += " AND N.CLIENTE IN (SELECT CLAVE FROM TEMPCARTELERACLIENTES) ORDER BY C.NOMBRE,N.FECHA"
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date)
        'DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        DGV.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        'DGV.Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'DGV.Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'DGV.Columns(17).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'DGV.Columns(18).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(1).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(5).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(8).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(9).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(10).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(11).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(12).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(13).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(14).DefaultCellStyle = DgvCellFormatoNumerico()

        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()
        Dim A, B, C, D, E, F, G As Double
        A = 0
        B = 0
        C = 0
        D = 0
        E = 0
        F = 0
        G = 0
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            G += DGV.Item(8, X).Value
            A += DGV.Item(9, X).Value
            B += DGV.Item(10, X).Value
            C += DGV.Item(11, X).Value
            D += DGV.Item(12, X).Value
            E += DGV.Item(13, X).Value
            F += DGV.Item(14, X).Value
        Next
        LBLA.Text = "Vencer: " + FormatNumber(A, 2).ToString
        LBLB.Text = "1 a 30: " + FormatNumber(B, 2).ToString
        LBLC.Text = "31 a 60: " + FormatNumber(C, 2).ToString
        LBLD.Text = "61 a 90: " + FormatNumber(D, 2).ToString
        LBLE.Text = "Mas de 91: " + FormatNumber(E, 2).ToString
        LBLF.Text = "Adeudo: " + FormatNumber(F, 2).ToString
        LBLG.Text = "Adeudo Sin Vencer: " + FormatNumber(G, 2).ToString


    End Sub
    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        Dim REP As New rptCarteleraCliente
        Dim QUERY As String
        If CHKTA.Checked Then
            QUERY = "SELECT T.NOMBRECOMUN TIENDA,T.DIRECCION,T.CIUDAD,T.TELEFONO,C.NOMBRE,C.CREDITO,C.DIASCREDITO,N.NOTA TICKET,DBO.FOLIOFAC(T.SERIEFAC,N.NOTA)FACTURA,N.TOTAL,CONVERT(VARCHAR(10),N.FECHA,103)[Fecha Emisión],convert(varchar(10),DATEADD(dd,C.DIASCREDITO,N.FECHA),103) [Fecha de Vencimiento],DBO.CREDITOPORVENCER(N.TIENDA,NOTA,0,@INI)SINVENCER,DBO.CREDITOPORVENCER(N.TIENDA,NOTA,3,@INI)PORVENCER,DBO.CREDITOPORVENCER(N.TIENDA,NOTA,30,@INI)VENCIDO30,DBO.CREDITOPORVENCER(N.TIENDA,NOTA,60,@INI)VENCIDO60,DBO.CREDITOPORVENCER(N.TIENDA,NOTA,90,@INI)VENCIDO90,DBO.CREDITOPORVENCER(N.TIENDA,NOTA,91,@INI)VENCIDO91,(N.TOTAL-(SELECT DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))ADEUDO,[Dias Vencido]=DATEDIFF(dd,N.FECHA,GETDATE())-C.DIASCREDITO,ENCABEZADO='Antigüedad de saldos al '+''+DBO.FECHA2TEXT(@INI),SALDO=(CREDITO- DBO.TOTALDEBECLIENTE('" + frmPrincipal.SucursalBase + "', C.CLAVE)) FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE "
            'If CHKEP.Checked Then
            'Else
            '    QUERY += " INNER JOIN DATOSCREDITOCLIENTES DC ON C.CLAVE=DC.CLIENTE "
            'End If
            QUERY += "WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.PAGADO = 0"
            ' AND DATEDIFF(dd,N.FECHA,@INI)-C.DIASCREDITO>=-3 
            QUERY += " AND N.CLIENTE IN (SELECT CLAVE FROM TEMPCARTELERACLIENTES) ORDER BY C.NOMBRE,N.FECHA"
            MOSTRARREPORTE(REP, "Cartera de Clientes", BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date), "")
        Else
            QUERY = "SELECT T.NOMBRECOMUN TIENDA,T.DIRECCION,T.CIUDAD,T.TELEFONO,C.NOMBRE,C.CREDITO,C.DIASCREDITO,N.NOTA TICKET,DBO.FOLIOFAC(T.SERIEFAC,N.NOTA)FACTURA,N.TOTAL,CONVERT(VARCHAR(10),N.FECHA,103)[Fecha Emisión],convert(varchar(10),DATEADD(dd,C.DIASCREDITO,N.FECHA),103) [Fecha de Vencimiento],DBO.CREDITOPORVENCER(N.TIENDA,NOTA,0,@INI)SINVENCER,DBO.CREDITOPORVENCER(N.TIENDA,NOTA,3,@INI)PORVENCER,DBO.CREDITOPORVENCER(N.TIENDA,NOTA,30,@INI)VENCIDO30,DBO.CREDITOPORVENCER(N.TIENDA,NOTA,60,@INI)VENCIDO60,DBO.CREDITOPORVENCER(N.TIENDA,NOTA,90,@INI)VENCIDO90,DBO.CREDITOPORVENCER(N.TIENDA,NOTA,91,@INI)VENCIDO91,(N.TOTAL-(SELECT DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))ADEUDO,[Dias Vencido]=DATEDIFF(dd,N.FECHA,GETDATE())-C.DIASCREDITO,ENCABEZADO='Total de Adeudos',SALDO=(CREDITO- DBO.TOTALDEBECLIENTE('" + frmPrincipal.SucursalBase + "', C.CLAVE)) FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE "
            'If CHKEP.Checked Then
            'Else
            '    QUERY += " INNER JOIN DATOSCREDITOCLIENTES DC ON C.CLAVE=DC.CLIENTE "
            'End If
            QUERY += "WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.PAGADO = 0"
            QUERY += " AND DATEDIFF(dd,N.FECHA,@INI)-C.DIASCREDITO>=-3 "
            QUERY += " AND N.CLIENTE IN (SELECT CLAVE FROM TEMPCARTELERACLIENTES) ORDER BY C.NOMBRE,N.FECHA"
            MOSTRARREPORTE(REP, "Cartera de Clientes", BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date), "")
        End If        

    End Sub

    Private Sub CHKTA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTA.CheckedChanged
        If CHKTA.Checked Then
            DTDE.Value = Now
        End If
        DTDE.Enabled = Not CHKTA.Checked
    End Sub
End Class