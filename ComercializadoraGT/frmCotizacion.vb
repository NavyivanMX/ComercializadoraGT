Public Class frmCotizacion
    Dim CC As Integer

    Private Sub frmCotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Public Sub MOSTRAR(ByVal NCLI As String, ByVal VCC As Integer, ByVal NC As String)
        TXTNOM.Text = NCLI
        CC = VCC
        DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        TXTTOT.Text = FormatNumber(frmPrincipal.PRE.Total, 2).ToString
        TXTCAJERA.Text = NC
        SIGCOTIZACION()
        Me.ShowDialog()
    End Sub
    Private Function SIGCOTIZACION() As Integer
        If Not frmPrincipal.CHECACONX() Then
            Exit Function
        End If
        Dim QUERY As String
        Dim REG As Integer
        REG = 0
        QUERY = "SELECT MAX(COTIZACION) FROM COTIZACIONES WHERE TIENDA='" + frmPrincipal.SucursalBase + "'" ''---> Y PARA K TE SIRVE EL CAMPO TIENDA EN LA TABLA EMPLEADOS???? WHERE E.TIENDA='"+FRMPRINCIPAL.SUCURSALBASE+"'"
        Dim SQLSELECT As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            If LECTOR(0) Is DBNull.Value Then
                TXTCOT.Text = "1"
                REG = 1
            Else
                TXTCOT.Text = LECTOR(0) + 1
                REG = LECTOR(0) + 1
            End If
        End If
        LECTOR.Close()
        Return REG
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        TXTTOT.Text = FormatNumber(frmPrincipal.PRE.Total, 2).ToString
        SIGCOTIZACION()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim TOT As Double
        TOT = 0
        For X = 0 To DGV.Rows.Count - 1
            TOT += DGV.Item(5, X).Value
        Next
        TXTTOT.Text = FormatNumber(TOT, 2).ToString
    End Sub
    Private Sub CARGACOTIZACION()
        DGV.DataSource = BDLlenatabla("SELECT D.CODIGO,P.NOMBRE PRODUCTO,D.CANTIDAD,D.DESCUENTO,D.PRECIO,D.TOTAL FROM DETALLECOTIZACIONES D INNER JOIN PRODUCTOS P ON D.CODIGO=P.CLAVE WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND COTIZACION='" + TXTCOT.Text + "'", frmPrincipal.CadenaConexion)
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Dim SQL As New SqlClient.SqlCommand("SELECT D.CLIENTE,D.CAJERA,E.NOMBRE,D.PERSONAS,D.OBSERVACIONES,D.TELEFONO FROM COTIZACIONES D INNER JOIN EMPLEADOS E ON D.TIENDA=E.TIENDA AND D.CAJERA=E.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.COTIZACION='" + TXTCOT.Text + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            TXTCAJERA.Text = LEC(2)
            TXTNOM.Text = LEC(0)
            CC = LEC(1)
            TXTNP.Text = LEC(3)
            TXTOBS.Text = LEC(4)
            TXTTEL.Text = LEC(5)
        End If
        LEC.Close()
        SQL.Dispose()
        CHECATABLA()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmClsBusqueda.BUSCAR("SELECT COTIZACION,CLIENTE,FECHA,TOTAL,ELABORADA FROM COTIZACIONES WHERE FECHA>DATEADD(MM,-3,GETDATE()) AND TIENDA='" + frmPrincipal.SucursalBase + "'", " CLIENTE", " ORDER BY CLIENTE", "Búsqueda de Cotizaciones", "Nombre del Cliente", "Cotizacion(es)", 1, frmPrincipal.CadenaConexion, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCOT.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            CARGACOTIZACION()
        End If
    End Sub
    Private Sub GUARDAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim NP As Integer
        Dim TOT As Double
        Try
            TOT = CType(TXTTOT.Text, Double)
        Catch ex As Exception
            TOT = 0
        End Try
        Try
            NP = CType(TXTNP.Text, Integer)
        Catch ex As Exception
            NP = 1
        End Try
        Dim SQLB As New SqlClient.SqlCommand("DELETE FROM COTIZACIONES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND COTIZACION=" + TXTCOT.Text, frmPrincipal.CONX)
        SQLB.ExecuteNonQuery()
        SQLB.CommandText = "DELETE FROM DETALLECOTIZACIONES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND COTIZACION=" + TXTCOT.Text
        SQLB.ExecuteNonQuery()
        SQLB.Dispose()
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO COTIZACIONES (TIENDA,COTIZACION,CLIENTE,CAJERA,PERSONAS,TOTAL,OBSERVACIONES,TELEFONO) VALUES (@TI,@COT,@CLI,@CAJ,@PER,@TOT,@OBS,@TEL)", frmPrincipal.CONX)
        SQL.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQL.Parameters.Add("@COT", SqlDbType.Int).Value = TXTCOT.Text
        SQL.Parameters.Add("@CLI", SqlDbType.VarChar).Value = TXTNOM.Text
        SQL.Parameters.Add("@CAJ", SqlDbType.Int).Value = CC
        SQL.Parameters.Add("@PER", SqlDbType.Int).Value = NP
        SQL.Parameters.Add("@TOT", SqlDbType.Float).Value = TOT
        SQL.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TXTOBS.Text
        SQL.Parameters.Add("@TEL", SqlDbType.VarChar).Value = TXTTEL.Text
        SQL.ExecuteNonQuery()
        Dim SQLD As New SqlClient.SqlCommand("INSERT INTO DETALLECOTIZACIONES (TIENDA,COTIZACION,CODIGO,CANTIDAD,DESCUENTO,PRECIO,TOTAL,REGISTRO) VALUES (@TI,@COT,@COD,@CANT,@DES,@PRE,@TOT,@REG)", frmPrincipal.CONX)
        SQLD.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQLD.Parameters.Add("@COT", SqlDbType.VarChar).Value = TXTCOT.Text
        SQLD.Parameters.Add("@COD", SqlDbType.VarChar)
        SQLD.Parameters.Add("@CANT", SqlDbType.Float)
        SQLD.Parameters.Add("@DES", SqlDbType.Float)
        SQLD.Parameters.Add("@PRE", SqlDbType.Float)
        SQLD.Parameters.Add("@TOT", SqlDbType.Float)
        SQLD.Parameters.Add("@REG", SqlDbType.Int)
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            SQLD.Parameters("@COD").Value = DGV.Item(0, X).Value
            SQLD.Parameters("@CANT").Value = DGV.Item(2, X).Value
            SQLD.Parameters("@DES").Value = DGV.Item(3, X).Value
            SQLD.Parameters("@PRE").Value = DGV.Item(4, X).Value
            SQLD.Parameters("@TOT").Value = DGV.Item(5, X).Value
            SQLD.Parameters("@REG").Value = X
            SQLD.ExecuteNonQuery()
        Next
        MessageBox.Show("Cotización Guardada Exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Dim NI As String
        NI = ""
        Dim VSI As New frmSeleccionarImpresora
        VSI.ShowDialog()
        If VSI.DialogResult = Windows.Forms.DialogResult.Yes Then
            NI = VSI.NIMPRESORA
        End If
        Dim REP As New rptCotizacion
        MOSTRARREPORTE(REP, "Cotización no. " + TXTCOT.Text, BDLlenatabla("SELECT T.NOMBREFISCAL TIENDA,D.COTIZACION,E.NOMBRE CAJERA,N.CLIENTE,N.PERSONAS,N.OBSERVACIONES,D.CODIGO,P.NOMBRE DESCRIPCION,D.CANTIDAD,D.PRECIO,D.TOTAL,DBO.DIVISIONSINCERO(N.TOTAL,N.PERSONAS)PPP,N.TELEFONO TELEFONOCLIENTE,T.TELEFONO TELEFONOSUCURSAL FROM COTIZACIONES N INNER JOIN DETALLECOTIZACIONES D ON N.TIENDA=D.TIENDA AND N.COTIZACION=D.COTIZACION INNER JOIN TIENDAS T ON D.TIENDA=T.CLAVE INNER JOIN PRODUCTOS P ON D.CODIGO=P.CLAVE INNER JOIN EMPLEADOS E ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.COTIZACION='" + TXTCOT.Text + "'", frmPrincipal.CadenaConexion), NI)
        CARGACOTIZACION()
        TXTNP.Text = "0"
        TXTNOM.Text = ""
        TXTOBS.Text = ""
        DGV.DataSource = Nothing
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGV.Rows.Count <= 0 Then
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea Guardar la Información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            frmPrincipal.PRE.Agregar(DGV.Item(0, X).Value, DGV.Item(1, X).Value, DGV.Item(2, X).Value, DGV.Item(4, X).Value, DGV.Item(3, X).Value)
        Next
        CARGACOTIZACION()
        TXTNP.Text = "0"
        TXTNOM.Text = ""
        TXTOBS.Text = ""
        DGV.DataSource = Nothing
        Me.Close()
    End Sub

    Private Sub frmCotizacion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        CARGACOTIZACION()
        TXTNP.Text = "0"
        TXTNOM.Text = ""
        TXTOBS.Text = ""
        DGV.DataSource = Nothing
    End Sub
End Class