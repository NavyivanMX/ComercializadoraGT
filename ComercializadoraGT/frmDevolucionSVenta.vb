Public Class frmDevolucionSVenta

    Private Sub frmDevolucionSVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        If CHKCRE.Checked Then
            QUERY = "SELECT C.NOMBRE,N.TOTAL,N.FECHA FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON N.TIENDA=C.TIENDA AND N.CLIENTE=C.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA='" + TXTNOTA.Text + "'"
        Else
            QUERY = "SELECT C.NOMBRE,N.TOTAL,N.FECHA FROM NOTASDEVENTA N INNER JOIN CLIENTES C ON N.TIENDA=C.TIENDA AND N.CLIENTE=C.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA='" + TXTNOTA.Text + "'"
        End If
              Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            LBLNC.Text = LEC(0)
            LBLFV.Text = LEC(2)
            FEC = LEC(2)
            TOT = LEC(1)
            REG = True
        End If
        LEC.Close()
        SQL.Dispose()
        If REG Then
            If TIENEDEVOLUCION() > 0 Then
                REG = False
            End If
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
    Private Sub BTNMOSTRAR_Click(sender As Object, e As EventArgs) Handles BTNMOSTRAR.Click
        If VALIDANOTA() Then
            Dim QUERY As String
            If CHKCRE.Checked Then
                QUERY = "SELECT D.CANTIDAD,P.NOMBRE PRODUCTO,PRECIOVENTA=DBO.DIVISIONSINCERO(TOTAL,CANTIDAD),TOTAL,PRODUCTO,D.CANTIDAD C2 FROM DETALLENOTASDEVENTACREDITOF D INNER JOIN PRODUCTOSF P ON D.PRODUCTO=P.CLAVE WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND NOTA='" + TXTNOTA.Text + "'"
            Else
                QUERY = "SELECT D.CANTIDAD,P.NOMBRE PRODUCTO,PRECIOVENTA=DBO.DIVISIONSINCERO(TOTAL,CANTIDAD),TOTAL,PRODUCTO,D.CANTIDAD C2 FROM DETALLENOTASDEVENTAFF D INNER JOIN PRODUCTOSF P ON D.PRODUCTO=P.CLAVE WHERE  ID='" + TXTNOTA.Text + "'"
            End If
            ACTIVAR(False)
            DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
            DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DGV.Columns(1).ReadOnly = True
            DGV.Columns(2).ReadOnly = True
            DGV.Columns(3).ReadOnly = True
            DGV.Columns(4).ReadOnly = True
            DGV.Columns(4).Visible = False
            DGV.Columns(5).ReadOnly = True
            DGV.Columns(5).Visible = False
            VALIDACANTIDADES()
        Else
            'NO EXISTE
            'YA TIENE DEVOLUCION
            VALIDACANTIDADES()
            If TIENEDEVOLUCION() > 0 Then
                MessageBox.Show("Nota ya tiene devolución", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Try
            Dim X As Integer
            For X = 0 To DGV.Rows.Count - 1
                DGV.Item(3, X).Value = DGV.Item(0, X).Value * DGV.Item(2, X).Value
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Function TIENEBONIFICACION() As Double
        If Not frmPrincipal.CHECACONX Then
            Return False
        End If
        Dim REG As Double
        REG = 0
        Dim CRE, QUERY As String
        If CHKCRE.Checked Then
            CRE = "1"
            QUERY = "SELECT SUM(TOTAL) FROM NOTADECREDITOFFPRO N WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOTA='" + TXTNOTA.Text + "' AND N.ESCRE='" + CRE + "' AND ESDEVOLUCION=0"
        Else
            CRE = "0"
            QUERY = "SELECT SUM(TOTAL) FROM NOTADECREDITOFFPRO N WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.FF='" + TXTNOTA.Text + "' AND N.ESCRE='" + CRE + "' AND ESDEVOLUCION=0"
        End If

        Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
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
    Private Function VALIDACANTIDADES() As Boolean
        Dim X As Integer

        LBLDSV.Text = "Devolución S/ Venta: " + FormatNumber(TIENEDEVOLUCION, 2).ToString
        LBLBON.Text = "Bonificación S/ Venta: " + FormatNumber(TIENEBONIFICACION, 2).ToString
        Dim TOT, DISP As Double
        TOT = 0
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(0, X).Value > DGV.Item(5, X).Value Then
                Return False
            End If
            TOT += DGV.Item(3, X).Value
        Next
 
        DISP = TOT - TIENEDEVOLUCION() - TIENEBONIFICACION()
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
        DGV.DataSource = Nothing
        DGV.Refresh()
    End Sub
    Private Function SIGUIENTEDEVOLUCION() As Integer
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim REG As Integer
        REG = 0
        Dim SQL As New SqlClient.SqlCommand("SELECT DBO.SIGDEVOLUCIONPRO('" + frmPrincipal.SucursalBase + "')", frmPrincipal.CONX)
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

        Dim SD As Integer
        SD = SIGUIENTEDEVOLUCION()
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO DEVOLUCIONESSVENTASPRO (TIENDA,DEVOLUCION,NOTAORIGEN,CREDITO,USUARIO,FF) VALUES (@TI,@DEV,@NO,@CRE,@USU,@FF)", frmPrincipal.CONX)
        SQL.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQL.Parameters.Add("@DEV", SqlDbType.Int).Value = SD
        SQL.Parameters.Add("@NO", SqlDbType.Int).Value = TXTNOTA.Text
        SQL.Parameters.Add("@CRE", SqlDbType.Bit).Value = CHKCRE.Checked
        SQL.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        If CHKCRE.Checked Then
            SQL.Parameters.Add("@FF", SqlDbType.VarChar).Value = "0"
        Else
            SQL.Parameters.Add("@FF", SqlDbType.VarChar).Value = TXTNOTA.Text
        End If

        SQL.ExecuteNonQuery()
        Dim SQLD As New SqlClient.SqlCommand("INSERT INTO DETALLEDEVOLUCIONESSVENTASPRO (TIENDA,DEVOLUCION,PRODUCTO,CANTIDAD,TOTAL,REGISTRO) VALUES (@TI,@DEV,@PRO,@CANT,@TOT,@REG)", frmPrincipal.CONX)
        SQLD.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQLD.Parameters.Add("@DEV", SqlDbType.Int).Value = SD
        SQLD.Parameters.Add("@PRO", SqlDbType.VarChar)
        SQLD.Parameters.Add("@CANT", SqlDbType.Float)
        SQLD.Parameters.Add("@TOT", SqlDbType.Float)
        SQLD.Parameters.Add("@REG", SqlDbType.Int)
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(0, X).Value > 0 Then
                SQLD.Parameters("@PRO").Value = DGV.Item(4, X).Value
                SQLD.Parameters("@CANT").Value = DGV.Item(0, X).Value
                SQLD.Parameters("@TOT").Value = DGV.Item(3, X).Value
                SQLD.Parameters("@REG").Value = X
                SQLD.ExecuteNonQuery()

            End If
        Next

        DGV.DataSource = Nothing
        'If APLICANOTACREDITO() Then
        Dim SQLSPNC As New SqlClient.SqlCommand("SPGENERANOTACREDITOPRO", frmPrincipal.CONX)
        SQLSPNC.CommandType = CommandType.StoredProcedure
        SQLSPNC.CommandTimeout = 600
        SQLSPNC.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQLSPNC.Parameters.Add("@DEV", SqlDbType.Int).Value = SD
        SQLSPNC.Parameters.Add("@MP", SqlDbType.Int).Value = MP
        SQLSPNC.Parameters.Add("@FP", SqlDbType.Int).Value = FP
        SQLSPNC.Parameters.Add("@CP", SqlDbType.Int).Value = CP
        SQLSPNC.Parameters.Add("@COM", SqlDbType.VarChar).Value = "DEVOLUCION SOBRE VENTA TIENDA:" + frmPrincipal.NombreComun + " DEVOLUCION:" + SD.ToString + " " + COM
        SQLSPNC.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        SQLSPNC.ExecuteNonQuery()
        IMPRIMIRNOTACREDITO()
        MessageBox.Show("Nota de Crédito Realizada Exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        'Else
        MessageBox.Show("Devolución generada con Éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        'End If
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
        QUERY = "SELECT T.NOMBRECOMUN,T.NOMBREFISCAL,T.DIRECCION,T.CIUDAD,T.RFC,T.CP,T.TELEFONO,TIPODEVENTA='Nota de Credito', D.CLAVE,D.NOTA,DBO.BIT2TEXT(9,ESCRE)ESCRE,DBO.BIT2TEXT(10,D.ESDEVOLUCION)ESDEVOLUCION,C.NOMBRE CLIENTE,D.TOTAL,D.OBSERVACION,DBO.CANTIDADCONLETRA(D.TOTAL) CCL,P.NOMBRE PRODUCTO,DSV.CANTIDAD,DSV.TOTAL DTOTAL,DBO.FOLIOFACCC(D.TIENDA,D.NOTA,D.ESCRE)FOLIOFAC FROM NOTADECREDITOFFPRO D INNER JOIN CLIENTESF C ON D.CLIENTE=C.CLAVE INNER JOIN TIENDASPRO T ON D.TIENDA=T.CLAVE INNER JOIN DETALLEDEVOLUCIONESSVENTASPRO DSV ON D.TIENDA=DSV.TIENDA AND D.DEVOLUCION=DSV.DEVOLUCION INNER JOIN PRODUCTOSF P ON DSV.PRODUCTO=P.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.CLAVE=" + UNC
        Dim REP As New rptNotaCreditoPro
        IMPRIMIRREPORTE(REP, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), 1, "")
    End Sub
    Private Sub BTNCANCELAR_Click(sender As Object, e As EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
        LIMPIAR()
    End Sub
End Class