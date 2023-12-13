Public Class frmNotaDeVentaTactil
    Dim LGRU As New List(Of String)
    Dim IGRU As New List(Of String)
    Dim LNOM As New List(Of String)
    Dim LPRO As New List(Of String)
    Dim NGRU As New List(Of String)
    Dim NPRO As New List(Of String)
    Dim INDG, INDP As Integer
    Dim IPRO As New List(Of String)
    Dim PPRE As New List(Of Double)
    Dim PGRU(12) As PictureBox
    Dim PPRO(12) As PictureBox
    Dim LBG(12) As Label
    Dim LBP(12) As Label
    Dim DT As New DataTable
    Dim DV As New DataView
    Dim NCUA As Integer
    Dim POS As Integer
    Private Sub frmNotaDeVentaTactil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        NCUA = 8
        Dim DA As New SqlClient.SqlDataAdapter("SELECT P.CLAVE,P.NOMBRECORTO,P.GRUPO,P." + frmPrincipal.SucursalBase + ",P.IMG,P.DESCRIPCION FROM PRODUCTOS P WHERE P.ACTIVO=1 AND P.EMPRESA='" + frmPrincipal.Empresa + "'", frmPrincipal.CONX)
        DT.Clear()
        DA.Fill(DT)
        INICIALIZAR()
        CARGAGRUPOS()
        CARGADATAVIEW(LGRU(((INDG - 1) * 4) + CType(1, Integer) - 1))
    End Sub
    Private Sub INICIALIZAR()
        Dim X As Integer
        For X = 1 To 4
            PGRU(X) = New PictureBox
            PPRO(X) = New PictureBox
            LBG(X) = New Label
            LBP(X) = New Label
        Next
        PGRU(1) = BTNG1
        PGRU(2) = BTNG2
        PGRU(3) = BTNG3
        PGRU(4) = BTNG4
    

        PPRO(1) = BTNP1
        PPRO(2) = BTNP2
        PPRO(3) = BTNP3
        PPRO(4) = BTNP4
        PPRO(5) = BTNP5
        PPRO(6) = BTNP6
        PPRO(7) = BTNP7
        PPRO(8) = BTNP8

        LBG(1) = LB1
        LBG(2) = LB2
        LBG(3) = LB3
        LBG(4) = LB4
 

        LBP(1) = LBL1
        LBP(2) = LBL2
        LBP(3) = LBL3
        LBP(4) = LBL4
        LBP(5) = LBL5
        LBP(6) = LBL6
        LBP(7) = LBL7
        LBP(8) = LBL8


    End Sub
    Private Sub CARGAGRUPOS()
        LGRU.Clear()
        NGRU.Clear()
        IGRU.Clear()
        Dim SQL As New SqlClient.SqlCommand("SELECT G.CLAVE,G.NOMBRE,G.IMG FROM GRUPOS G WHERE G.ACTIVO=1 AND G.EMPRESA='" + frmPrincipal.Empresa + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        While LEC.Read()
            LGRU.Add(LEC(0))
            NGRU.Add(LEC(1))
            IGRU.Add(LEC(2))
        End While
        LEC.Close()
        INDG = 1
        ACTUALIZAG()
        PANELG.Enabled = True
    End Sub
    Private Sub ACTUALIZAG()
        If INDG > 1 Then
            BTNANTG.Enabled = True
        Else
            BTNANTG.Enabled = False
        End If

        Dim MAXINDG As Integer
        MAXINDG = CType((LGRU.Count / 4), Integer)
        If ((INDG - 1) * 4 + 4) < LGRU.Count Then
            BTNSIGG.Enabled = True
        Else
            BTNSIGG.Enabled = False
        End If
        ACOMODAGRUPOS()
        'MessageBox.Show(MAXINDG.ToString, MAXINDG.ToString, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub
    Private Sub ACOMODAGRUPOS()

        Dim INICIO As Integer
        Dim FIN As Integer
        INICIO = (INDG - 1) * 4
        FIN = INICIO + 4
        If FIN > LGRU.Count Then
            FIN = LGRU.Count
        Else

        End If
        Dim FF As Integer
        FF = FIN
        While FF > 4
            FF = FF - 4
        End While
        Dim X As Integer
        For X = 1 To 4
            PGRU(X).Visible = True
            LBG(X).Visible = True
            PGRU(X).Image = PBIMG.Image
        Next
        Dim UBI As String
        UBI = ""
        For X = 1 To FF
            UBI = IGRU(INICIO + X - 1)
            LBG(X).Text = NGRU(INICIO + X - 1)
            'LBP(X).Text = NPRO(INICIO + X - 1)
            PGRU(X).ImageLocation = "C:/FOTOSPRICE/" + UBI + ".JPG"
        Next
        If FF < 4 Then
            For X = FF + 1 To 4
                PGRU(X).Visible = False
                LBG(X).Visible = False
                PGRU(X).Text = ""
            Next
        End If
    End Sub
    Private Sub CARGAPRODUCTOS()
        LPRO.Clear()
        NPRO.Clear()
        PPRE.Clear()
        IPRO.Clear()
        LNOM.Clear()
        Dim X As Integer
        Dim DRV As DataRowView
        For X = 0 To DV.Count - 1
            DRV = DV.Item(X)
            LPRO.Add(DRV.Item(0))
            LNOM.Add(DRV.Item(1))
            NPRO.Add(DRV.Item(5))
            PPRE.Add(DRV.Item(3))
            IPRO.Add(DRV.Item(4))
        Next
        INDP = 1
        PANELP.Enabled = True
        ACTUALIZAP()
    End Sub
    Private Sub ACTUALIZAP()
        If INDP > 1 Then
            BTNANTP.Enabled = True
        Else
            BTNANTP.Enabled = False
        End If

        'Dim MAXINDG As Integer
        'MAXINDG = CType((LGRU.Count / 10), Integer)
        If ((INDP - 1) * NCUA + NCUA) < LPRO.Count Then
            BTNSIGP.Enabled = True
        Else
            BTNSIGP.Enabled = False
        End If
        ACOMODAPLATILLOS()
    End Sub
    Private Sub ACOMODAPLATILLOS()

        Dim INICIO As Integer
        Dim FIN As Integer
        INICIO = (INDP - 1) * NCUA
        FIN = INICIO + NCUA
        If FIN > LPRO.Count Then
            FIN = LPRO.Count
        Else
        End If

        Dim FF As Integer
        FF = FIN
        While FF > NCUA
            FF = FF - NCUA
        End While
        Dim X As Integer
        For X = 1 To NCUA
            PPRO(X).Visible = True
            LBP(X).Visible = True
            PPRO(X).Image = PBIMG.Image
        Next
        Dim UBI As String
        UBI = ""
        For X = 1 To FF
            UBI = IPRO(INICIO + X - 1)
            LBP(X).Text = LNOM(INICIO + X - 1)
            PPRO(X).ImageLocation = "C:/FOTOSPRICE/" + UBI + ".JPG"
        Next
        If FF < NCUA Then
            For X = FF + 1 To NCUA
                PPRO(X).Visible = False
                LBP(X).Visible = False
                PPRO(X).Text = ""
            Next
        Else
        End If
    End Sub
    Private Sub CARGADATAVIEW(ByVal GRUPO As String)
        DV = New DataView(DT, "GRUPO='" + GRUPO + "'", "NOMBRECORTO", DataViewRowState.CurrentRows)
        'DGV2.DataSource = DT
        CARGAPRODUCTOS()
    End Sub

    Private Sub BTNSIGG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSIGG.Click
        INDG = INDG + 1
        ACTUALIZAG()
    End Sub

    Private Sub BTNANTG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNANTG.Click
        INDG = INDG - 1
        ACTUALIZAG()
    End Sub

    Private Sub BTNSIGP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSIGP.Click
        INDP = INDP + 1
        ACTUALIZAP()
    End Sub

    Private Sub BTNANTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNANTP.Click
        INDP = INDP - 1
        ACTUALIZAP()
    End Sub

    Private Sub BTNG1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNG1.Click, BTNG2.Click, BTNG3.Click, BTNG4.Click
        CARGADATAVIEW(LGRU(((INDG - 1) * 4) + CType(sender.tag, Integer) - 1))
    End Sub
    Private Function HAYENINVENTARIO(ByVal CODIGO As String) As Boolean
        If Not frmPrincipal.CHECACONX() Then
            Exit Function
        End If
        Dim query As String
        ' Try
        query = "SELECT SUM (I.CANTIDAD)  FROM INVPISOTIENDA I INNER JOIN LOTES L ON L.CLAVE=I.PRODUCTO INNER JOIN PRODUCTOS P ON P.CP=L.PRODUCTO WHERE I.TIENDA='" + frmPrincipal.SucursalBase + "' AND P.CLAVE='" + CODIGO + "' AND P.EMPRESA=" + frmPrincipal.Empresa + " "
        Dim SQLHAY As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
        Dim LECHAY As SqlClient.SqlDataReader
        LECHAY = SQLHAY.ExecuteReader
        If LECHAY.Read Then
            If LECHAY(0) Is DBNull.Value Then
                LECHAY.Close()
                'MessageBox.Show("No hay existencia del producto en el inventario de piso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return False
            Else
                frmNotaDeVenta.LBLEXIS.Text = FormatNumber(LECHAY(0), 2).ToString

                LECHAY.Close()
                Return True
            End If
        End If
        'Catch ex As Exception

        'End Try
    End Function
    Private Function CHECAPROD() As Boolean
        Dim nohay As Boolean
        nohay = True
        Dim GRU As Integer

        If Not frmPrincipal.CHECACONX() Then
            Exit Function
        End If

        Dim query As String
        query = "SELECT P.NOMBRE,P.PRECIO,P.IMG,P.GRUPO,P.CP FROM PRODUCTOS P WHERE P.CLAVE= '" + LPRO(POS) + "' AND EMPRESA=" + frmPrincipal.Empresa + ""
        Dim SQLCARGAPROD As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        Try
            LECTOR = SQLCARGAPROD.ExecuteReader
            If LECTOR.Read Then
                frmNotaDeVenta.LBLNOM.Text = LECTOR(0)
                frmNotaDeVenta.LBLPRE.Text = LECTOR(1)
                PBIMG.ImageLocation = "C:/FOTOSPRICE/" + LECTOR(2) + ".JPG"
                frmNotaDeVenta.PBIMG.ImageLocation = "C:/FOTOSPRICE/" + LECTOR(2) + ".JPG"
                GRU = LECTOR(3)
                LECTOR.Close()
                If HAYENINVENTARIO(LPRO(POS)) Then
                Else
                    frmNotaDeVenta.Text = "0" '' --> SI NO HAY K APAREZCA UN CERO NO??
                    MessageBox.Show("Este Código NO aparece en el inventario, favor de corregir el inventario lo antes posible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    nohay = False
                    LECTOR.Close()
                End If
                Return nohay
            Else
                LECTOR.Close()
                MessageBox.Show("El codigo del producto NO existe en el sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'TXTCOD.Text = ""
                'TXTCOD.Focus()
                Return False
            End If
        Catch ex As Exception
            'MessageBox.Show("El codigo del producto NO existe en el sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'TXTCOD.Text = ""
            'TXTCOD.Focus()
            'Return False
        End Try
    End Function
    Private Function CHECAAGREGADO(ByVal CODIGO As String) As Boolean
        If frmNotaDeVenta.TXTCANT.Text > frmNotaDeVenta.LBLEXIS.Text Then
            Return False
        End If
        Dim c As Integer
        c = 0
        For X = 0 To frmNotaDeVenta.DGV.Rows.Count - 1
            If frmNotaDeVenta.DGV.Item(0, X).Value = CODIGO Then
                c = c + frmNotaDeVenta.DGV.Item(2, X).Value
            End If
        Next
        c = c + frmNotaDeVenta.TXTCANT.Text
        If c > frmNotaDeVenta.LBLEXIS.Text Then
            Return False
        End If
        Return True
    End Function
    Private Sub BTNP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNP1.Click, BTNP2.Click, BTNP3.Click, BTNP4.Click, BTNP5.Click, BTNP6.Click, BTNP7.Click, BTNP8.Click
        POS = (INDP - 1) * NCUA + CType(sender.TAG, Integer) - 1

        If Not CHECAPROD() Then
            frmNotaDeVenta.TXTCOD.Text = ""
            frmNotaDeVenta.TXTCOD.Focus()
            Exit Sub
        End If

        If Not CHECAAGREGADO(LPRO(POS)) Then
            MessageBox.Show("No puede agregar mas producto, revise su inventario por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            frmNotaDeVenta.TXTCOD.Text = ""
            frmNotaDeVenta.TXTCOD.Focus()
            frmNotaDeVenta.TXTCANT.Text = 1
            Exit Sub
        End If


        Dim n, p As String
        Dim pre As Double
        p = LPRO(POS)
        n = LNOM(POS)
        pre = PPRE(POS)
        If frmNotaDeVenta.DGV.Rows.Count >= 22 Then
            MessageBox.Show("ha rebasado el limite de productos por nota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        Dim X As Integer
        For X = 0 To frmNotaDeVenta.DTPRECIOSCLIENTES.Rows.Count - 1
            If p = frmNotaDeVenta.DTPRECIOSCLIENTES.Rows(X).Item(0).ToString Then
                pre = frmNotaDeVenta.DTPRECIOSCLIENTES.Rows(X).Item(1).ToString
            End If
        Next
        frmPrincipal.PRE.Agregar(p, n, 1, pre, 0)
        frmNotaDeVenta.DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
        frmNotaDeVenta.DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        frmNotaDeVenta.DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' frmPrincipal.PRE.EliminarNota()
        frmNotaDeVenta.CHECATABLA()
        frmNotaDeVenta.CHECAPRODUCTOS()
        frmNotaDeVenta.TXTCOD.Focus()
        Me.Close()
    End Sub

    Private Sub frmNotaDeVentaTactil_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F4 Then
            frmNotaDeVenta.CHECATABLA()
            frmNotaDeVenta.CHECAPRODUCTOS()
            frmNotaDeVenta.TXTCOD.Focus()
            Me.Close()
        End If
    End Sub

    Private Sub LBL1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBL1.Click, LBL2.Click, LBL3.Click, LBL4.Click, LBL5.Click, LBL6.Click, LBL7.Click, LBL8.Click

        POS = (INDP - 1) * NCUA + CType(sender.TAG, Integer) - 1

        Dim n, p As String
        Dim pre As Double
        p = LPRO(POS)
        n = LNOM(POS)
        pre = PPRE(POS)

        frmPrincipal.PRE.Agregar(p, n, 1, pre, 0)
        frmNotaDeVenta.DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
        frmNotaDeVenta.DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        frmNotaDeVenta.DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub PANELP_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PANELP.Paint

    End Sub
End Class