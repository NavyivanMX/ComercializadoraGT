Public Class frmBonificacionSVenta
    Dim CLACLI As Integer
    Private Sub frmBonificacionSVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        ACTIVAR(True)
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        CHKCRE.Enabled = V
        TXTNOTA.Enabled = V
        BTNMOSTRAR.Enabled = V
        BTNGUARDAR.Enabled = Not V
    End Sub
    Private Function VALIDANOTA() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Return False
        End If
        Dim REG As Boolean
        REG = False
        Dim TOT As Double
        Dim FEC As DateTime
        Dim QUERY As String
        'TODO: VALIDAR LAS TABLAS
        If CHKCRE.Checked Then
            QUERY = "SELECT C.NOMBRE,N.TOTAL,N.FECHA,C.CLAVE FROM NOTASDEVENTACREDITOPRO N INNER JOIN CLIENTES C ON N.CLIENTE=C.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA='" + TXTNOTA.Text + "'"
        Else
            QUERY = "SELECT C.NOMBRE,N.TOTAL,N.FECHA,C.CLAVE FROM NOTASDEVENTAFF N INNER JOIN CLIENTES C ON N.CLIENTE=C.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.ID='" + TXTNOTA.Text + "'"

        End If
        Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            LBLNC.Text = LEC(0)
            LBLFV.Text = LEC(2)
            FEC = LEC(2)
            TOT = LEC(1)
            CLACLI = LEC(3)
            REG = True
        End If
        LEC.Close()
        SQL.Dispose()
        If REG Then
        Else
            MessageBox.Show("Nota no existente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
        Return REG
    End Function
    Private Function TIENEDEVOLUCION() As Double
        If Not frmPrincipal.CHECACONX Then
            Return False
        End If
        Dim REG As Double
        REG = 0
        Dim CRE As String
        If CHKCRE.Checked Then
            CRE = "1"
        Else
            CRE = "0"
        End If

        Dim SQL As New SqlClient.SqlCommand("SELECT SUM(D.TOTAL) FROM DETALLEDEVOLUCIONESSVENTASPRO D INNER JOIN DEVOLUCIONESSVENTASPRO N ON N.TIENDA=D.TIENDA AND N.DEVOLUCION=D.DEVOLUCION WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTAORIGEN='" + TXTNOTA.Text + "' AND N.CREDITO='" + CRE + "'", frmPrincipal.CONX)

        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            If LEC(0) Is DBNull.Value Then
                REG = 0
            Else
                REG = LEC(0)
            End If
        End If
        LEC.Close()
        SQL.Dispose()
        Return REG
    End Function
    Private Function TIENEBONIFICACION() As Double
        If Not frmPrincipal.CHECACONX Then
            Return False
        End If
        Dim REG As Double
        REG = 0
        Dim CRE As String
        If CHKCRE.Checked Then
            CRE = "1"
        Else
            CRE = "0"
        End If

        Dim SQL As New SqlClient.SqlCommand("SELECT SUM(TOTAL) FROM NOTADECREDITOFFPRO N WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA='" + TXTNOTA.Text + "' AND N.ESCRE='" + CRE + "' AND ESDEVOLUCION=0", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            If LEC(0) Is DBNull.Value Then
                REG = 0
            Else
                REG = LEC(0)
            End If
        End If
        LEC.Close()
        SQL.Dispose()
        Return REG
    End Function

    Private Sub BTNMOSTRAR_Click(sender As Object, e As EventArgs) Handles BTNMOSTRAR.Click
        If VALIDANOTA() Then
            Dim QUERY As String
            If CHKCRE.Checked Then
                QUERY = "SELECT D.CANTIDAD,P.NOMBRE PRODUCTO,PRECIOVENTA=DBO.DIVISIONSINCERO(TOTAL,CANTIDAD),TOTAL,PRODUCTO,D.TOTAL C2 FROM DETALLENOTASDEVENTACREDITOF D INNER JOIN PRODUCTOSF P ON D.PRODUCTO=P.CLAVE WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND NOTA='" + TXTNOTA.Text + "'"
            Else
                QUERY = "SELECT D.CANTIDAD,P.NOMBRE PRODUCTO,PRECIOVENTA=DBO.DIVISIONSINCERO(TOTAL,CANTIDAD),TOTAL,PRODUCTO,D.TOTAL C2 FROM DETALLENOTASDEVENTAFF D INNER JOIN PRODUCTOSF P ON D.PRODUCTO=P.CLAVE WHERE ID='" + TXTNOTA.Text + "'"
            End If


            ACTIVAR(False)
            DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
            DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DGV.Columns(1).ReadOnly = True
            DGV.Columns(2).ReadOnly = True
            DGV.Columns(0).ReadOnly = True
            DGV.Columns(4).ReadOnly = True
            DGV.Columns(4).Visible = False
            'DGV.Columns(5).ReadOnly = True
            DGV.Columns(5).Visible = False
            CHECATABLA()
        Else
            'NO EXISTE
            'YA TIENE DEVOLUCION
        End If
        VALIDACANTIDADES()
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Try
            CHECATABLA()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer

        Dim TOT As Double
        TOT = 0
        For X = 0 To DGV.Rows.Count - 1
            TOT += DGV.Item(3, X).Value
        Next
        TXTTOT.Text = TOT.ToString
    End Sub
    Private Function VALIDACANTIDADES() As Boolean
        Dim X As Integer

        LBLDSV.Text = "Devolución S/ Venta: " + FormatNumber(TIENEDEVOLUCION, 2).ToString
        LBLBON.Text = "Bonificación S/ Venta: " + FormatNumber(TIENEBONIFICACION, 2).ToString
        Dim TOT, DISP, ABO As Double
        TOT = 0
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(3, X).Value > DGV.Item(5, X).Value Then
                Return False
            End If
            TOT += DGV.Item(5, X).Value
        Next
        Try
            ABO = CType(TXTTOT.Text, Double)
        Catch ex As Exception
            Return False
        End Try
        If ABO <= 0 Then
            Return False
        End If

        Dim A, B As Double
        A = TIENEDEVOLUCION()
        B = TIENEBONIFICACION()
        DISP = TOT - TIENEDEVOLUCION() - ABO - TIENEBONIFICACION()
        If DISP < 0 Then
            Return False
        End If
        Return True
    End Function
    Private Sub BTNGUARDAR_Click(sender As Object, e As EventArgs) Handles BTNGUARDAR.Click
        If Not VALIDACANTIDADES() Then
            MessageBox.Show("No se permiten devoluciones mayores a la venta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea Guardar la Información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
    End Sub
    Private Sub LIMPIAR()
        LBLFV.Text = ""
        LBLNC.Text = ""
        TXTOBS.Text = ""
        TXTTOT.Text = "0"
        DGV.DataSource = Nothing
        DGV.Refresh()
    End Sub
    Private Function SIGUIENTEBONIFICACION() As Integer
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim REG As Integer
        REG = 0
        Dim SQL As New SqlClient.SqlCommand("SELECT DBO.SIGBONIFICACIONPRO('" + frmPrincipal.SucursalBase + "')", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            REG = LEC(0)
        End If
        LEC.Close()
        SQL.Dispose()
        Return REG
    End Function
    Private Function APLICANOTACREDITO() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Return False
        End If
        Dim QUERY As String
        Dim REG As Boolean
        REG = False
        If CHKCRE.Checked Then
            QUERY = "SELECT DBO.APLICANOTACREDITOFF('" + frmPrincipal.SucursalBase + "','" + TXTNOTA.Text + "',1)"
        Else
            QUERY = "SELECT DBO.APLICANOTACREDITOFF('" + frmPrincipal.SucursalBase + "','" + TXTNOTA.Text + "',0)"
        End If
        Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            REG = CType(LEC(0), Boolean)
        End If
        LEC.Close()
        SQL.Dispose()
        Return REG
    End Function
    Private Sub GUARDAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SB As Integer
        SB = SIGUIENTEBONIFICACION()
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO BONIFICACIONESSVENTASPRO (TIENDA,BONIFICACION,NOTAORIGEN,CREDITO,USUARIO,FF) VALUES (@TI,@DEV,@NO,@CRE,@USU,@FF)", frmPrincipal.CONX)
        SQL.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQL.Parameters.Add("@DEV", SqlDbType.Int).Value = SB
        SQL.Parameters.Add("@NO", SqlDbType.Int).Value = TXTNOTA.Text
        SQL.Parameters.Add("@CRE", SqlDbType.Bit).Value = CHKCRE.Checked
        SQL.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        If CHKCRE.Checked Then
            SQL.Parameters.Add("@FF", SqlDbType.VarChar).Value = "0"
        Else
            SQL.Parameters.Add("@FF", SqlDbType.VarChar).Value = TXTNOTA.Text
        End If
        SQL.ExecuteNonQuery()
        Dim SQLD As New SqlClient.SqlCommand("INSERT INTO DETALLEBONIFICACIONESSVENTASPRO (TIENDA,BONIFICACION,PRODUCTO,CANTIDAD,TOTAL,REGISTRO) VALUES (@TI,@DEV,@PRO,@CANT,@TOT,@REG)", frmPrincipal.CONX)
        SQLD.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQLD.Parameters.Add("@DEV", SqlDbType.Int).Value = SB
        SQLD.Parameters.Add("@PRO", SqlDbType.VarChar)
        SQLD.Parameters.Add("@CANT", SqlDbType.Float)
        SQLD.Parameters.Add("@TOT", SqlDbType.Float)
        SQLD.Parameters.Add("@REG", SqlDbType.Int)
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(3, X).Value > 0 Then
                SQLD.Parameters("@PRO").Value = DGV.Item(4, X).Value
                SQLD.Parameters("@CANT").Value = DGV.Item(0, X).Value
                SQLD.Parameters("@TOT").Value = DGV.Item(3, X).Value
                SQLD.Parameters("@REG").Value = X
                SQLD.ExecuteNonQuery()
            End If
        Next
        DGV.DataSource = Nothing

        Dim MP, FP, CP, COM As String
        COM = ""
        MP = 0
        FP = 0
        CP = 0
        If APLICANOTACREDITO() Then
            'VENTANA
            Dim VONC As New frmOpcionesNotaCredito
            VONC.ShowDialog()
            If VONC.DialogResult = Windows.Forms.DialogResult.Yes Then
                MP = VONC.MP
                FP = VONC.FP
                CP = VONC.CP
                COM = VONC.COM
            Else
                Exit Sub
            End If
        End If
        Dim SQLSPNC As New SqlClient.SqlCommand("SPGENERANOTACREDITOBONPRO", frmPrincipal.CONX)
        SQLSPNC.CommandType = CommandType.StoredProcedure
        SQLSPNC.CommandTimeout = 600
        SQLSPNC.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQLSPNC.Parameters.Add("@NO", SqlDbType.VarChar).Value = TXTNOTA.Text
        SQLSPNC.Parameters.Add("@CRE", SqlDbType.Bit).Value = CHKCRE.Checked
        SQLSPNC.Parameters.Add("@ESDEV", SqlDbType.Bit).Value = 0
        SQLSPNC.Parameters.Add("@DEV", SqlDbType.VarChar).Value = SB
        SQLSPNC.Parameters.Add("@CLI", SqlDbType.Int).Value = CLACLI
        SQLSPNC.Parameters.Add("@TOT", SqlDbType.Float).Value = CType(TXTTOT.Text, Double)
        SQLSPNC.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        SQLSPNC.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TXTOBS.Text

        SQLSPNC.Parameters.Add("@MP", SqlDbType.Int).Value = MP
        SQLSPNC.Parameters.Add("@FP", SqlDbType.Int).Value = FP
        SQLSPNC.Parameters.Add("@CP", SqlDbType.Int).Value = CP
        SQLSPNC.ExecuteNonQuery()


        'Dim SQLSPNC As New SqlClient.SqlCommand("SPGENERANOTACREDITOPRO", frmPrincipal.CONX)
        'SQLSPNC.CommandType = CommandType.StoredProcedure
        'SQLSPNC.CommandTimeout = 600
        'SQLSPNC.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        'SQLSPNC.Parameters.Add("@DEV", SqlDbType.Int).Value = SD
        'SQLSPNC.Parameters.Add("@MP", SqlDbType.Int).Value = MP
        'SQLSPNC.Parameters.Add("@FP", SqlDbType.Int).Value = FP
        'SQLSPNC.Parameters.Add("@CP", SqlDbType.Int).Value = CP
        'SQLSPNC.Parameters.Add("@COM", SqlDbType.VarChar).Value = "DEVOLUCION SOBRE VENTA TIENDA:" + frmPrincipal.NombreComun + " DEVOLUCION:" + SD.ToString
        'SQLSPNC.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        'SQLSPNC.ExecuteNonQuery()


        MessageBox.Show("Nota de Crédito Realizada Exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        'Else
        'MessageBox.Show("Devolución generada con Éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        'End If

        IMPRIMIRNOTACREDITO()

        TXTNOTA.Clear()
        ACTIVAR(True)
        LIMPIAR()
    End Sub
    Private Sub IMPRIMIRNOTACREDITO()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim UNC As String
        UNC = "1"
        Dim SQL As New SqlClient.SqlCommand("SELECT MAX (CLAVE) FROM NOTADECREDITOFFPRO WHERE TIENDA='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            UNC = LEC(0)
        End If
        LEC.Close()
        SQL.Dispose()
        Dim QUERY As String
        ' QUERY = "SELECT T.NOMBRECOMUN,T.NOMBREFISCAL,T.DIRECCION,T.CIUDAD,T.RFC,T.CP,T.TELEFONO,TIPODEVENTA='Nota de Credito', D.CLAVE,D.NOTA,DBO.BIT2TEXT(9,ESCRE)ESCRE,DBO.BIT2TEXT(10,D.ESDEVOLUCION)ESDEVOLUCION,C.NOMBRE CLIENTE,D.TOTAL,D.OBSERVACION,DBO.CANTIDADCONLETRA(D.TOTAL) CCL FROM NOTADECREDITOFFPRO D INNER JOIN " + frmPrincipal.TABLACLIENTES + " C ON D.CLIENTE=C.CLAVE INNER JOIN TIENDASPRO T ON D.TIENDA=T.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.CLAVE=" + UNC
        'TODO: Revisar tabla
        QUERY = "SELECT T.NOMBRECOMUN,T.NOMBREFISCAL,T.DIRECCION,T.CIUDAD,T.RFC,T.CP,T.TELEFONO,TIPODEVENTA='Nota de Credito', D.CLAVE,D.NOTA,DBO.BIT2TEXT(9,ESCRE)ESCRE,DBO.BIT2TEXT(10,D.ESDEVOLUCION)ESDEVOLUCION,C.NOMBRE CLIENTE,D.TOTAL,D.OBSERVACION,DBO.CANTIDADCONLETRA(D.TOTAL) CCL,P.NOMBRE PRODUCTO,DSV.CANTIDAD,DSV.TOTAL DTOTAL,DBO.FOLIOFACCC(D.TIENDA,D.NOTA,D.ESCRE)FOLIOFAC FROM NOTADECREDITOFFPRO D INNER JOIN CLIENTES C ON D.CLIENTE=C.CLAVE INNER JOIN TIENDASPRO T ON D.TIENDA=T.CLAVE INNER JOIN DETALLEBONIFICACIONESSVENTASPRO DSV ON D.TIENDA=DSV.TIENDA AND D.DEVOLUCION=DSV.BONIFICACION INNER JOIN PRODUCTOSF P ON DSV.PRODUCTO=P.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.CLAVE=" + UNC

        Dim REP As New rptNotaCreditoPro
        IMPRIMIRREPORTE(REP, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), 1, "")
    End Sub
    Private Sub BTNCANCELAR_Click(sender As Object, e As EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
        LIMPIAR()
    End Sub
End Class