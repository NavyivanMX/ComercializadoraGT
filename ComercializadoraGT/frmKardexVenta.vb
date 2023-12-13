Public Class frmKardexVenta
    Dim LTI As New List(Of String)
    Dim DT As New DataTable
    Private Sub frmKardexVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
       OPLlenaComboBox(CBTI, LTI, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE ACTIVO=1 ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion, "Todas las tiendas", "")
        CHECATABLA()
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String
        QUERY = "SELECT T.NOMBRECOMUN TIENDA,D.FECHA,SUM(D.EFECTIVO)EFECTIVO, SUM(D.TARJETACREDITO)[TARJETA CREDITO],SUM(D.TARJETADEBITO)[TARJETA DEBITO],SUM(D.CHEQUE)CHEQUE,SUM(D.TRANSFERENCIA)TRANSFERENCIA,SUM(D.IVACONTADO)[IVA CONTADO],SUM(D.IEPSCONTADO)[IEPS CONTADO],SUM(D.DESCUENTOCONTADO)[DESCUENTO CONTADO],SUM(D.IMPORTECONTADO)[IMPORTE CONTADO],SUM(D.CREDITO)[VTA CREDITO],SUM(D.COBEFE)[COB EFECTIVO],SUM(D.COBTCREDITO)[COB T CREDITO],SUM(D.COBTDEBITO)[COB T DEBITO],SUM(D.COBCHEQUE)[COB CHEQUE],SUM(D.COBTRANSFERENCIA)[COB TRANSFERENCIA],SUM(D.IVACOB)[IVA COBRANZA], SUM(D.IEPSCOB)[IEPS COBRANZA],SUM(D.DESCCOB)[DESCUENTO COBRANZA], SUM(D.IMPCOB)[IMPORTE COBRANZA] FROM VIMPORTESVENTAS D INNER JOIN TIENDAS T ON D.TIENDA=T.CLAVE WHERE D.FECHA>=@INI AND D.FECHA< @FIN "
        If CBTI.SelectedIndex <> 0 Then
            QUERY += " AND D.TIENDA='" + LTI(CBTI.SelectedIndex) + "'"
        End If
        QUERY += " GROUP BY T.NOMBRECOMUN,D.FECHA ORDER BY T.NOMBRECOMUN,FECHA"
        DT = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.DataSource = DT
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DGV.Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        DGV.Columns(0).Frozen = True
        DGV.Columns(1).DefaultCellStyle = DgvCellFormatoFecha()

        DGV.Columns(2).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(3).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(4).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(5).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(6).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(7).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(8).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(9).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(10).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(11).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(12).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(13).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(14).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(15).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(16).DefaultCellStyle = DgvCellFormatoNumerico()

        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()
        Dim A, B, C, D, E, F, G, H, I, CRE As Double
        Dim CA, CB, CC, CD, CE, CF, CG, CH, CI As Double
        A = 0
        B = 0
        C = 0
        D = 0
        E = 0
        F = 0
        G = 0
        H = 0
        I = 0

        CA = 0
        CB = 0
        CC = 0
        CD = 0
        CE = 0
        CF = 0
        CG = 0
        CH = 0
        CI = 0
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            A += DGV.Item(2, X).Value
            B += DGV.Item(3, X).Value
            C += DGV.Item(4, X).Value
            D += DGV.Item(5, X).Value
            E += DGV.Item(6, X).Value
            F += DGV.Item(7, X).Value
            G += DGV.Item(8, X).Value
            H += DGV.Item(9, X).Value
            I += DGV.Item(10, X).Value

            CRE += DGV.Item(11, X).Value


            CA += DGV.Item(12, X).Value
            CB += DGV.Item(13, X).Value
            CC += DGV.Item(14, X).Value
            CD += DGV.Item(15, X).Value
            CE += DGV.Item(16, X).Value
            CF += DGV.Item(17, X).Value
            CG += DGV.Item(18, X).Value
            CH += DGV.Item(19, X).Value
            CI += DGV.Item(20, X).Value
        Next
        LBLA.Text = FormatNumber(A, 2).ToString
        LBLB.Text = FormatNumber(B, 2).ToString
        LBLC.Text = FormatNumber(C, 2).ToString
        LBLD.Text = FormatNumber(D, 2).ToString
        LBLE.Text = FormatNumber(E, 2).ToString
        LBLF.Text = FormatNumber(F, 2).ToString
        LBLG.Text = FormatNumber(G, 2).ToString
        LBLH.Text = FormatNumber(H, 2).ToString
        LBLI.Text = FormatNumber(I, 2).ToString
        LBLCA.Text = FormatNumber(CA, 2).ToString
        LBLCB.Text = FormatNumber(CB, 2).ToString
        LBLCC.Text = FormatNumber(CC, 2).ToString
        LBLCD.Text = FormatNumber(CD, 2).ToString
        LBLCE.Text = FormatNumber(CE, 2).ToString
        LBLCF.Text = FormatNumber(CF, 2).ToString
        LBLCG.Text = FormatNumber(CG, 2).ToString
        LBLCH.Text = FormatNumber(CH, 2).ToString
        LBLCI.Text = FormatNumber(CI, 2).ToString
        
        LBLCRE.Text = FormatNumber(CRE, 2).ToString

    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub

    Private Sub BTNEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEXCEL.Click
        If DT.Rows.Count <= 0 Then
            MessageBox.Show("Favor de primero cargar la información", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        ExportarExcel(DT, "Desglose ventas " + CBTI.Text, True)
    End Sub
End Class