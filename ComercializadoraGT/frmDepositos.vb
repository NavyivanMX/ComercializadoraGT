Public Class frmDepositos
    Dim CANT As Double
    Dim LCUEN As New List(Of String)
    Dim LBANCOS As New List(Of String)
    Dim LV(4) As Label
    Dim LD(4) As Label
    Dim LDIF(4) As Label
    Dim LGC As Label
    Dim INDICET As Integer
    Dim INDICEC As Integer
    Dim NUM As Integer
    Private Sub frmDepositos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        'INICIALIZAR()
        CARGACUENTAS()
        'CARGACAJAS()
        CARGADATOS()
        If frmPrincipal.NivelBase = 10 Then
            BTNCONF.Visible = True
        Else
            BTNCONF.Visible = False
        End If
        Try
            If INDICET >= 0 Then
                CBCUENTAS.SelectedIndex = INDICET
            End If
        Catch ex As Exception

        End Try
        Try
            If INDICEC >= 0 Then
                CBCAJA.SelectedIndex = INDICEC
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub MOSTRAR(ByVal CANTIDAD As Double, ByVal CAJA As Integer)
        INDICET = -1
        INDICEC = -1
        'INICIALIZAR()
        CARGACUENTAS()
        'CARGACAJAS()
        CARGADATOS()
        Dim X As Integer
        For X = 0 To CBCUENTAS.Items.Count - 1
            CBCUENTAS.SelectedIndex = X
            If CBCUENTAS.Text.ToUpper = "TARJETAS" Then
                INDICET = X
                Exit For
            End If
        Next
        For X = 0 To CBCAJA.Items.Count - 1
            CBCAJA.SelectedIndex = X
            If CBCAJA.Text = CAJA.ToString Then
                INDICEC = X
                Exit For
            End If
        Next

        TXTCANT.Text = CANTIDAD.ToString
        CBCAJA.Text = CAJA.ToString
        Me.ShowDialog()
    End Sub
    'Private Sub INICIALIZAR()
    '    Dim X As Integer
    '    For X = 0 To 3
    '        LV(X) = New Label
    '        LD(X) = New Label
    '        LDIF(X) = New Label
    '        LV(X).Text = "0"
    '        LD(X).Text = "0"
    '        LDIF(X).Text = "0"
    '    Next
    '    LV(1) = LBLVC1
    '    LV(2) = LBLVC2
    '    LV(3) = LBLVC3

    '    LD(1) = LBLDC1
    '    LD(2) = LBLDC2
    '    LD(3) = LBLDC3

    '    LDIF(1) = LBLDIF1
    '    LDIF(2) = LBLDIF2
    '    LDIF(3) = LBLDIF3
    '    For X = 0 To 3
    '        LV(X).Text = "0"
    '        LD(X).Text = "0"
    '        LDIF(X).Text = "0"
    '    Next
    'End Sub
    Private Sub CHECADATOS()
        If TXTCANT.Text = "" Or TXTFICHA.Text = "" Then
            BTNGUARDAR.Enabled = True
        Else
            BTNGUARDAR.Enabled = True
        End If
    End Sub
    'Private Sub CARGACAJAS()
    '    Dim NCAJ, X As Integer
    '    If Not frmPrincipal.CHECACONX() Then
    '        Exit Sub
    '    End If
    '    Dim SQL As New SqlClient.SqlCommand("SELECT CAJAS FROM TIENDAS WHERE CLAVE='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
    '    Dim LECTOR As SqlClient.SqlDataReader
    '    LECTOR = SQL.ExecuteReader
    '    If LECTOR.Read Then
    '        NCAJ = LECTOR(0)
    '    Else
    '        Me.Close()
    '    End If
    '    LECTOR.Close()
    '    CBCAJA.Items.Clear()
    '    For X = 1 To NCAJ
    '        CBCAJA.Items.Add(X)
    '    Next
    '    CBCAJA.SelectedIndex = 0
    'End Sub
    Private Sub CARGACUENTAS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBCUENTAS, LCUEN, "SELECT CLAVE,NOMBRE FROM CUENTAS WHERE ACTIVO=1 AND TIENDA='" + frmPrincipal.SucursalBase + "' ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBCUENTAS.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBCUENTAS.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Function CARGABANCOS(ByVal CUENTA As Integer) As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBBANCO, LBANCOS, "SELECT C.BANCO,B.NOMBRE FROM CUENTASBANCOS C INNER JOIN BANCOS B ON C.BANCO=B.CLAVE WHERE C.CUENTA=" + CUENTA.ToString + " ORDER BY B.NOMBRE", frmPrincipal.CadenaConexion)
        If CBBANCO.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBBANCO.SelectedIndex = 0
        Catch ex As Exception

        End Try
        Return LEIDO
    End Function
    'Private Function VALIDAR() As Boolean
    '    Dim SQL As New SqlClient.SqlCommand("SELECT ACTIVO FROM DIASBLOQUEODEPOSITO WHERE RESTAURANTE='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1 AND DIA=@FEC", frmPrincipal.CONX)
    '    SQL.Parameters.Add("@FEC", SqlDbType.DateTime)
    '    SQL.Parameters("@FEC").Value = DTHASTA.Value.Date
    '    Dim LEC As SqlClient.SqlDataReader
    '    LEC = SQL.ExecuteReader
    '    If LEC.Read Then
    '        LEC.Close()
    '        Return False
    '    Else
    '        LEC.Close()
    '        Return True
    '    End If
    '    Return True
    'End Function
    Dim LVEN(3) As Double
    Dim LDEP(3) As Double
    Dim LDIFE(3) As Double
    Dim LGCA As Double
    Dim VCON, VCOB As Double
    Dim DT As New DataTable
    Dim NETOVENTA As Double
    Private Sub CARGAINFO()
        'Dim X, MAX As Integer
        'If CBCAJA.Items.Count > 3 Then
        '    MAX = 3
        'Else
        '    MAX = CBCAJA.Items.Count
        'End If
        'For X = 1 To 3
        '    LV(X).Visible = True
        '    LD(X).Visible = True
        '    LDIF(X).Visible = True
        'Next

        'For X = MAX To 2
        '    LV(X + 1).Visible = False
        '    LD(X + 1).Visible = False
        '    LDIF(X + 1).Visible = False
        'Next

        'VCOB = 0
        'VCON = 0
        'Dim TVEN, TDIF, VEN, DEP, TDEP As Double
        'TVEN = 0
        'TDIF = 0
        'TDEP = 0
        'Dim SQL2 As New SqlClient.SqlCommand("SELECT SUM(D.IMPORTECONTADO+D.IVACONTADO+D.IEPSCONTADO-D.DESCUENTOCONTADO )[IMPORTE CONTADO], SUM(D.IMPCOB+D.IVACOB+D.IEPSCOB-D.DESCCOB)[IMPORTE COBRANZA] FROM VIMPORTESVENTAS D INNER JOIN TIENDAS T ON D.TIENDA=T.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.FECHA>=@INI AND D.FECHA< @FIN  GROUP BY T.NOMBRECOMUN,D.FECHA ORDER BY T.NOMBRECOMUN,FECHA", frmPrincipal.CONX)
        'SQL2.Parameters.Add("@INI", SqlDbType.DateTime).Value = DTFECHADIA.Value.Date
        'SQL2.Parameters.Add("@FIN", SqlDbType.DateTime).Value = DTFECHADIA.Value.Date.AddDays(1)
        'Dim LEC2 As SqlClient.SqlDataReader
        'LEC2 = SQL2.ExecuteReader
        'If LEC2.Read Then
        '    VCON = LEC2(0)
        '    VCOB = LEC2(1)
        'End If
        'LEC2.Close()
        'SQL2.Dispose()

        Dim SQL As New SqlClient.SqlCommand("", frmPrincipal.CONX)
        SQL.Parameters.Add("@INI", SqlDbType.DateTime)
        SQL.Parameters.Add("@FIN", SqlDbType.DateTime)
        Dim LEC As SqlClient.SqlDataReader
        'For X = 1 To MAX
        '    LVEN(X) = 0
        '    LDEP(X) = 0
        '    SQL.CommandText = "SELECT SUM(TOTAL) FROM NOTASDEVENTA  WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND NOCAJA=" + X.ToString + " AND FECHA>=@INI AND FECHA<@FIN"
        '    SQL.Parameters("@INI").Value = DTFECHADIA.Value.Date
        '    SQL.Parameters("@FIN").Value = DTFECHADIA.Value.Date.AddDays(1)
        '    LEC = SQL.ExecuteReader
        '    If LEC.Read Then
        '        If LEC(0) Is DBNull.Value Then
        '            LV(X).Text = "Venta Caja " + X.ToString + ": 0"
        '        Else
        '            LV(X).Text = "Venta Caja " + X.ToString + ": " + FormatNumber(LEC(0).ToString, 2).ToString
        '            LVEN(X) = LEC(0)

        '        End If
        '    End If
        '    LEC.Close()

        '    SQL.CommandText = "SELECT SUM(D.CANTIDAD) FROM DEPOSITOS D WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.CAJA=" + X.ToString + " AND D.FECHADIA>=@INI and D.FECHADIA<@FIN"
        '    SQL.Parameters("@INI").Value = DTFECHADIA.Value.Date
        '    SQL.Parameters("@FIN").Value = DTFECHADIA.Value.Date.AddDays(1)
        '    LEC = SQL.ExecuteReader
        '    If LEC.Read Then
        '        If LEC(0) Is DBNull.Value Then
        '            LD(X).Text = "Dep. Caja " + X.ToString + ": 0"
        '        Else
        '            LD(X).Text = "Dep. Caja " + X.ToString + ": " + FormatNumber(LEC(0).ToString, 2).ToString
        '            LDEP(X) = LEC(0)
        '            TDEP += LEC(0)
        '        End If

        '    End If
        '    LEC.Close()
        Dim GASTOS As Double
        GASTOS = 0
        Sql.CommandText = "SELECT SUM (TOTAL) FROM GASTOSCAJACHICA WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND FECHA>=@INI AND FECHA<=@FIN"
        Sql.Parameters("@INI").Value = DTFECHADIA.Value.Date
        Sql.Parameters("@FIN").Value = DTFECHADIA.Value.Date.AddDays(1)
        LEC = Sql.ExecuteReader
        If LEC.Read Then
            If LEC(0) Is DBNull.Value Then
                LBLTG.Text = "0"
            Else
                LBLTG.Text = FormatNumber(LEC(0).ToString, 2).ToString
                GASTOS = LEC(0)
            End If

        End If
        LEC.Close()

        '    Try
        '        VEN = LVEN(X)
        '        DEP = LDEP(X)
        '        LDIFE(X) = VEN - DEP
        '        LDIF(X).Text = "Falta: " + FormatNumber(LDIFE(X), 2).ToString
        '    Catch ex As Exception

        '    End Try
        '    TVEN = TVEN + LVEN(X)
        '    TDIF = TDIF + LDIFE(X) - LGCA
        'Next
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String
        QUERY = "SELECT T.NOMBRECOMUN TIENDA,D.FECHA,SUM(D.EFECTIVO)EFECTIVO, SUM(D.TARJETACREDITO)[TARJETA CREDITO],SUM(D.TARJETADEBITO)[TARJETA DEBITO],SUM(D.CHEQUE)CHEQUE,SUM(D.TRANSFERENCIA)TRANSFERENCIA,SUM(D.IVACONTADO)[IVA CONTADO],SUM(D.IEPSCONTADO)[IEPS CONTADO],SUM(D.DESCUENTOCONTADO)[DESCUENTO CONTADO],SUM(D.IMPORTECONTADO)[IMPORTE CONTADO],SUM(D.CREDITO)[VTA CREDITO],SUM(D.COBEFE)[COB EFECTIVO],SUM(D.COBTCREDITO)[COB T CREDITO],SUM(D.COBTDEBITO)[COB T DEBITO],SUM(D.COBCHEQUE)[COB CHEQUE],SUM(D.COBTRANSFERENCIA)[COB TRANSFERENCIA],SUM(D.IVACOB)[IVA COBRANZA], SUM(D.IEPSCOB)[IEPS COBRANZA],SUM(D.DESCCOB)[DESCUENTO COBRANZA], SUM(D.IMPCOB)[IMPORTE COBRANZA] FROM VIMPORTESVENTAS D INNER JOIN TIENDAS T ON D.TIENDA=T.CLAVE WHERE D.FECHA>=@INI AND D.FECHA< @FIN "
        QUERY += " AND D.TIENDA='" + frmPrincipal.SucursalBase + "'"

        QUERY += " GROUP BY T.NOMBRECOMUN,D.FECHA ORDER BY T.NOMBRECOMUN,FECHA"
        DT = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTFECHADIA.Value.Date, DTFECHADIA.Value.Date.AddDays(1))
 
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
        For X = 0 To DT.Rows.Count - 1
            A += DT.Rows(X).Item(2)
            B += DT.Rows(X).Item(3)
            C += DT.Rows(X).Item(4)
            D += DT.Rows(X).Item(5)
            E += DT.Rows(X).Item(6)
            F += DT.Rows(X).Item(7)
            G += DT.Rows(X).Item(8)
            H += DT.Rows(X).Item(9)
            I += DT.Rows(X).Item(10)

            CRE += DT.Rows(X).Item(11)


            CA += DT.Rows(X).Item(12)
            CB += DT.Rows(X).Item(13)
            CC += DT.Rows(X).Item(14)
            CD += DT.Rows(X).Item(15)
            CE += DT.Rows(X).Item(16)
            CF += DT.Rows(X).Item(17)
            CG += DT.Rows(X).Item(18)
            CH += DT.Rows(X).Item(19)
            CI += DT.Rows(X).Item(20)
        Next
        NETOVENTA = A + B + C + D + E + CA + CB + CC + CD + CE
        LBLA.Text = FormatNumber(A, 2).ToString
        LBLB.Text = FormatNumber(B, 2).ToString
        LBLC.Text = FormatNumber(C, 2).ToString
        LBLD.Text = FormatNumber(D, 2).ToString
        LBLE.Text = FormatNumber(E, 2).ToString
        'LBLF.Text = FormatNumber(F, 2).ToString
        'LBLG.Text = FormatNumber(G, 2).ToString
        'LBLH.Text = FormatNumber(H, 2).ToString
        'LBLI.Text = FormatNumber(I, 2).ToString
        LBLCA.Text = FormatNumber(CA, 2).ToString
        LBLCB.Text = FormatNumber(CB, 2).ToString
        LBLCC.Text = FormatNumber(CC, 2).ToString
        LBLCD.Text = FormatNumber(CD, 2).ToString
        LBLCE.Text = FormatNumber(CE, 2).ToString
        'LBLCF.Text = FormatNumber(CF, 2).ToString
        'LBLCG.Text = FormatNumber(CG, 2).ToString
        'LBLCH.Text = FormatNumber(CH, 2).ToString
        'LBLCI.Text = FormatNumber(CI, 2).ToString

        'LBLCRE.Text = FormatNumber(CRE, 2).ToString
        LBLDIF.Text = FormatNumber(NETOVENTA - (DEPOSITADO + GASTOS), 2).ToString

        LBLTA.Text = FormatNumber(A + CA, 2).ToString
        LBLTB.Text = FormatNumber(B + CB, 2).ToString
        LBLTC.Text = FormatNumber(C + CC, 2).ToString
        LBLTD.Text = FormatNumber(D + CD, 2).ToString
        LBLTE.Text = FormatNumber(E + CE, 2).ToString

        LBLVN.Text = FormatNumber(A + CA + B + CB + C + CC + D + CD + E + CE, 2).ToString
    End Sub
    Private Function REPETIDOFICHA() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Return False
        End If
        If CBCUENTAS.Text = "TARJETAS" Then
            Return False
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT FICHA FROM DEPOSITOS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CUENTA='" + CBCUENTAS.Text + "' AND FICHA='" + TXTFICHA.Text + "' AND CONFIRMADO=0", frmPrincipal.CONX)
        SQL.Parameters.Add("@INI", SqlDbType.DateTime).Value = DTFECHADIA.Value.Date
        SQL.Parameters.Add("@FIN", SqlDbType.DateTime).Value = DTFECHADIA.Value.Date.AddDays(1)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            LEC.Close()
            Return True
        Else
            LEC.Close()
            Return False
        End If
        Return False
    End Function
    Private Sub CARGASIGREG()
        ' Try
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If

        NUM = 1
        Dim SQLMOV As New SqlClient.SqlCommand("SELECT DBO.SIGUIENTEREGDEPOSITO('" + frmPrincipal.SucursalBase + "')", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLMOV.ExecuteReader
        If LECTOR.Read Then
            NUM = LECTOR(0)
            LECTOR.Close()
        Else
            LECTOR.Close()
        End If
        'Catch ex As Exception
        '    Me.Close()
        'End Try
    End Sub
    Private Sub GUARDAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        If Not VALORES() Then
            Exit Sub
        End If
        'If Not VALIDAR() Then
        '    MessageBox.Show("La Fecha de Depósito se Encuentra Bloqueda para Esta Sucursal, Favor de Comunicarte con Ingresos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If
        If REPETIDOFICHA Then
            MessageBox.Show("El No. de autorización de depósito ya fue ingresado para esta sucursal con este banco en este día, favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If

        CARGASIGREG()

        Dim SQLGUARDA As New SqlClient.SqlCommand("INSERT INTO DEPOSITOS (TIENDA,CUENTA,CANTIDAD,FECHA,REGISTRO,BANCO,HORA,FICHA,FECHADIA,USUARIO,CAJA) VALUES ('" + frmPrincipal.SucursalBase + "','" + CBCUENTAS.Text + "'," + CANT.ToString + ",@FEC," + NUM.ToString + ",'" + CBBANCO.Text + "',@HORA,'" + TXTFICHA.Text + "',@FD,'" + frmPrincipal.Usuario + "',1)", frmPrincipal.CONX)
        SQLGUARDA.Parameters.Add("@FEC", SqlDbType.DateTime)
        SQLGUARDA.Parameters.Add("@HORA", SqlDbType.DateTime)
        SQLGUARDA.Parameters.Add("@FD", SqlDbType.DateTime)
        SQLGUARDA.Parameters("@FEC").Value = DTHASTA.Value.Date
        SQLGUARDA.Parameters("@HORA").Value = DTHORA.Value
        SQLGUARDA.Parameters("@FD").Value = DTFECHADIA.Value.Date
        SQLGUARDA.ExecuteNonQuery()
        CARGADATOS()
        TXTCANT.Clear()
        TXTCANT.Focus()
        TXTFICHA.Clear()
        CHECADATOS()
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT CUENTA,CANTIDAD,BANCO,CONVERT(VARCHAR(10), FECHA, 103) AS FECHA,CONVERT(VARCHAR(8), HORA, 114) AS HORA, REGISTRO,CONFIRMADO,CAJA FROM DEPOSITOS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND FECHADIA>=@INI AND FECHADIA<@FIN", frmPrincipal.CONX)
        Dim DA As New SqlClient.SqlDataAdapter()
        DA.SelectCommand = SQL
        DA.SelectCommand.Parameters.Add("@INI", SqlDbType.DateTime)
        DA.SelectCommand.Parameters.Add("@FIN", SqlDbType.DateTime)
        DA.SelectCommand.Parameters("@INI").Value = DTFECHADIA.Value.Date
        DA.SelectCommand.Parameters("@FIN").Value = DTFECHADIA.Value.Date.AddDays(1)
        Dim DT As New DataTable
        DA.Fill(DT)
        DGV.DataSource = DT
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
        CARGAINFO()
    End Sub
    Dim DEPOSITADO As Double
    Private Sub CHECATABLA()
        Dim TOT As Double
        TOT = 0
        If DGV.Rows.Count <= 0 Then
            BTNQUITAR.Enabled = False
        Else
            BTNQUITAR.Enabled = True
            Dim X As Integer
            For X = 0 To DGV.Rows.Count - 1
                TOT = TOT + DGV.Item(1, X).Value
            Next
        End If
        DEPOSITADO = TOT
        LBLTDEP.Text = FormatNumber(TOT).ToString
    End Sub
    Private Function VALORES() As Boolean
        If TXTCANT.Text = "" Or TXTCANT.Text = "0" Then
            TXTCANT.Focus()
            Return False
        End If
        CANT = 0
        Try
            CANT = CType(TXTCANT.Text, Double)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub

    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        If DGV.Item(6, DGV.CurrentRow.Index).Value = True Then
            MessageBox.Show("Este depósito se encuentra confirmado, No es posible quitarlo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea eliminar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("DELETE FROM DEPOSITOS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CONFIRMADO=0 AND REGISTRO=" + DGV.Item(5, DGV.CurrentRow.Index).Value.ToString, frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
        CARGADATOS()
    End Sub

    Private Sub CBCUENTAS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBCUENTAS.SelectedIndexChanged
        If Not CARGABANCOS(LCUEN(CBCUENTAS.SelectedIndex)) Then
            MessageBox.Show("Esta cuenta no tiene asignado un banco", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            CBBANCO.Enabled = False
            BTNGUARDAR.Enabled = False
            Exit Sub
        End If
        CBBANCO.Enabled = True
        BTNGUARDAR.Enabled = True
        'If CBCUENTAS.Text = "TARJETAS" Then
        '    TXTFICHA.Enabled = False
        'Else
        '    TXTFICHA.Enabled = True
        'End If
    End Sub

    Private Sub TXTCANT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCANT.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsPunctuation(e.KeyChar) Then
            e.Handled = False
        End If
        CHECADATOS()
    End Sub

    Private Sub DTFECHADIA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTFECHADIA.ValueChanged
        CARGADATOS()
    End Sub

    Private Sub LBLGC1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DTHASTA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTHASTA.ValueChanged

    End Sub

    Private Sub BTNCONF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCONF.Click
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
                SQL.CommandText = "UPDATE DEPOSITOS SET CONFIRMADO=1 WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND REGISTRO='" + DGV.Item(5, X).Value.ToString + "'"
                SQL.ExecuteNonQuery()
            Next
            CARGADATOS()
            MessageBox.Show("Los depósitos han sido confirmados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
End Class