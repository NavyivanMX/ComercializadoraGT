Public Class frmKardexPreciosClientes
    Dim CS, PS, NC, NP As String
    Private Sub frmKardexPreciosClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String
        QUERY = "SELECT C.NOMBRE CLIENTE,P.NOMBRE PRODUCTO, D.NOTA,D.ESCRE,D.FECHA,P.PRECIO [PRECIO ACTUAL],D.PRECIO [PRECIO ASIGNADO] FROM HMODIFICACIONPRECIOS D INNER JOIN TIENDAS T ON D.TIENDA=T.CLAVE INNER JOIN CLIENTES C ON D.TIENDA=C.TIENDA  AND D.CLIENTE=C.CLAVE INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE D.FECHA>=@INI AND D.FECHA<=@FIN"
        If CHKTC.Checked = False And CS <> "" Then
            QUERY += " AND D.CLIENTE=" + CS
        End If
        If CHKTP.Checked = False And PS <> "" Then
            QUERY += " AND D.PRODUCTO='" + PS + "'"
        End If
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        DGV.Columns(5).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(6).DefaultCellStyle = DgvCellFormatoNumerico()
        CHECATABLA()

    End Sub
    Private Sub CHECATABLA()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CARGADATOS()
    End Sub

    Private Sub CHKTC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTC.CheckedChanged
        If CHKTC.Checked Then
            NC = ""
            CS = ""
            LBLCLI.Text = "Cliente: Todos"
        Else
            LBLCLI.Text = "Cliente: " + NC
        End If
        BTNC.Enabled = Not CHKTC.Checked
    End Sub

    Private Sub CHKTP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTP.CheckedChanged
        If CHKTP.Checked Then
            PS = ""
            NP = ""
            LBLPRO.Text = "Producto: Todos"
        Else
            LBLPRO.Text = "Producto: " + NP
        End If
        BTNP.Enabled = Not CHKTP.Checked
    End Sub

    Private Sub BTNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNC.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,ACTIVO FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "'", " AND NOMBRE", " ORDER BY NOMBRE", "Búsqueda de cientes ", "Nombre del cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            CS = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            NC = frmClsBusqueda.TREG.Rows(0).Item(1).ToString
            LBLCLI.Text = "Cliente: " + NC
        End If
    End Sub

    Private Sub BTNP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNP.Click
        frmClsBusqueda.BUSCAR("SELECT P.CLAVE CLAVE,P.NOMBRE,P.DESCRIPCION,G.NOMBRE GRUPO,P.PRECIO,P.ACTIVO FROM PRODUCTOS P INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE P.EMPRESA=" + frmPrincipal.Empresa + "  AND P.ACTIVO=1", " AND P.NOMBRE", " ORDER BY P.NOMBRE", "Búsqueda de Productos", "Nombre del producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            PS = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            NP = frmClsBusqueda.TREG.Rows(0).Item(1).ToString
            LBLPRO.Text = "Producto: " + NP
        End If
    End Sub
End Class