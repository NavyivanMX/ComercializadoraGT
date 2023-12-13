Public Class frmFacturaPublicoGeneral

    Private Sub frmFacturaPublicoGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGAPREFACTURA()
    End Sub
    Private Sub CARGAPREFACTURA()
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        Dim S, I, T, FS, FI, FT, TS, TI, TT, SI, SNI As Double
        Dim QUERY As String
        S = 0
        I = 0
        T = 0
        FS = 0
        FI = 0
        FT = 0
        TS = 0
        TI = 0
        SI = 0
        SNI = 0

        QUERY = "SELECT N.NOTA,(CONVERT (NUMERIC(15,2),SUM(DBO.SUBTOTAL(D.PRODUCTO,D.TOTAL)),2)-(DBO.IVACREDITO3 ('" + frmPrincipal.SucursalBase + "',1,@FEC,dateadd(dd,1,@fec),N.TOTAL)))SUBTOTAL,(CONVERT(NUMERIC(15,2), SUM(DBO.IVA(D.PRODUCTO,D.TOTAL)*.16),2)+(DBO.IVACREDITO3 ('" + frmPrincipal.SucursalBase + "',1,@FEC,dateadd(dd,1,@fec),N.TOTAL)))IVA,ELTOTAL=SUM(d.TOTAL) FROM NOTASDEVENTA N INNER JOIN DETALLENOTASDEVENTA D ON N.TIENDA=D.TIENDA AND N.NOTA=D.NOTA WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.FECHA>=@FEC AND N.FECHA<=(dateadd(dd,1,@fec)) GROUP BY N.NOTA,N.TOTAL"
        Dim SQLSELECT As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        SQLSELECT.CommandTimeout = 300
        SQLSELECT.Parameters.Add("@FEC", SqlDbType.DateTime).Value = DTDE.Value.Date
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        While LECTOR.Read
            S = S + LECTOR(1)
            I = I + LECTOR(2)
            T = T + LECTOR(3)
        End While
        LECTOR.Close()

        QUERY = "SELECT SUM(SUBTOTAL),SUM(IVA),SUM(ELTOTAL) FROM VISTALOFACTURADO WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND FECHA>=@FEC AND FECHA<(dateadd(dd,1,@FEC))"
        Dim SQLSELECT1 As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        SQLSELECT1.Parameters.Add("@FEC", SqlDbType.DateTime).Value = DTDE.Value.Date
        SQLSELECT1.CommandTimeout = 300
        Dim LECTOR1 As SqlClient.SqlDataReader
        LECTOR1 = SQLSELECT1.ExecuteReader
        If LECTOR1.Read Then
            FS = LECTOR1(0)
            FI = LECTOR1(1)
            FT = LECTOR1(2)
        End If
        LECTOR1.Close()

        TS = S - FS
        TI = I - FI
        TT = T - FT

        SI = TI / 0.16
        SNI = TS - (TI / 0.16)

        TXTSUB.Text = TS
        TXTIVA.Text = TI
        TXTTOT.Text = TT

        TXTSI.Text = SI
        TXSNI.Text = SNI


    End Sub
    Private Function REVISAFACTURA() As Boolean
        If TXTFAC.Text = "" Then
            Return False
        End If
        If String.IsNullOrEmpty(TXTFAC.Text) Then
            Return False
        End If
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT FACTURA FROM FACTURASCLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND FACTURA='" + TXTFAC.Text + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            LEC.Close()
            Return False
        Else
            LEC.Close()
        End If
        Dim SQL2 As New SqlClient.SqlCommand("SELECT FACTURA FROM FACTURASCLIENTESPG WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND FACTURA='" + TXTFAC.Text + "'", frmPrincipal.CONX)
        Dim LEC2 As SqlClient.SqlDataReader
        LEC2 = SQL2.ExecuteReader
        If LEC2.Read Then
            LEC2.Close()
            Return False
        Else
            LEC2.Close()
        End If
        Return True
    End Function
    Dim CNUM As New num2text
    Dim SSI, SCI, SSUB, IVA, TOTAl As Double
    Private Function CHECACANTIDADES() As Boolean

        Try
            SCI = CType(TXTSI.Text, Double)
        Catch ex As Exception
            MessageBox.Show("Favor de escribir cantidades validas, Subtotal con Iva", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return False
        End Try
        Try
            SSI = CType(TXSNI.Text, Double)
        Catch ex As Exception
            MessageBox.Show("Favor de escribir cantidades validas, Subtotal sin Iva", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return False
        End Try
        If SCI < 0 Or SSI < 0 Then
            MessageBox.Show("Favor de escribir cantidades mayores a cero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return False
        End If
        SSUB = SSI + SCI
        IVA = SCI * 0.16
        TOTAl = SSI + SCI + (SCI * 0.16)
        TXTTOT.Text = FormatNumber(TOTAL).ToString()
        TXTSUB.Text = FormatNumber(SSUB, 2).ToString()
        TXTIVA.Text = FormatNumber(IVA, 2).ToString()
        BTNGUARDAR.Enabled = True
        TXTLETRA.Text = CNUM.Letras(TXTTOT.Text)
        Return True
    End Function

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
  
        If Not REVISAFACTURA() Then
            MessageBox.Show("Este Número de Factura ya se Ha utilizado en esta Tienda, Favor de escribir otro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea Guardar la Información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
    End Sub
    Private Sub GUARDAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO FACTURASCLIENTESPG (TIENDA,FACTURA,DIRECCION,CIUDAD,RFC,CP,CONCEPTO,SUBTOTALIVA,SUBTOTALNOIVA,CCLETRA,FECHA) VALUES ('" + frmPrincipal.SucursalBase + "','" + TXTFAC.Text + "','" + TXTDFIS.Text + "','" + TXTCD.Text + "','" + TXTRFC.Text + "','" + TXTCP.Text + "','" + TXTCON.Text + "','" + TXTSI.Text + "','" + TXSNI.Text + "','" + TXTLETRA.Text + "', @FEC)", frmPrincipal.CONX)
        SQL.Parameters.Add("@FEC", SqlDbType.DateTime).Value = DTDE.Value.Date
        SQL.CommandTimeout = 300
        SQL.ExecuteNonQuery()
    
        SQL.Dispose()
        MessageBox.Show("La información ha sido guardada, se mostrara la factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Dim REP As New rptFactura
        Dim S, I, T As Double
        S = CType(TXTSUB.Text, Double)
        I = CType(TXTIVA.Text, Double)
        T = CType(TXTTOT.Text, Double)
        Dim QUERY As String
        QUERY = "SELECT FECHA,NOMBREFISCAL='Publico en General',DIRECCION,CIUDAD,RFC,CONCEPTO NOMBRE,PRECIO=(SUBTOTALIVA+SUBTOTALNOIVA),TOTAL=(SUBTOTALIVA+SUBTOTALNOIVA),SUBTOTAL=(SUBTOTALIVA+SUBTOTALNOIVA),IVA=CONVERT(NUMERIC(15,2),(SUBTOTALIVA*.16),2),ELTOTAL=CONVERT(NUMERIC(15,2),(SUBTOTALIVA+SUBTOTALNOIVA)+(SUBTOTALIVA*.16),2),CCLETRA,CP,UNIDAD='NOTAS',SUBTOTALIVA SUBTOTALPRODUCTOSCONIVA,SUBTOTALNOIVA SUBTOTALPRODUCTOSSINIVA FROM FACTURASCLIENTESPG WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND FACTURA='" + TXTFAC.Text + "'"
        MOSTRARREPORTE(REP, "Factura de: " + frmPrincipal.NombreComun + "  " + TXTFAC.Text, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), "Enviar a OneNote 2007")

        'MOSTRARREPORTE(REP, frmPrincipal.NombreComun + "  Factura " + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString, BDLlenatabla("SELECT F.FECHA,R.NOMBREFISCAL,R.DIRECCION,R.CIUDAD,R.RFC,D.CANTIDAD,P.NOMBRE,P.PRECIO,D.TOTAL,SUBTOTAL=CONVERT(NUMERIC(15,2),(F.TOTAL/1.16),2),IVA=CONVERT(NUMERIC(15,2),(F.TOTAL/1.16*.16),2)  ,ELTOTAL=F.TOTAL,CCLETRA='" + Cantidad2Letras(DGV.Item(3, DGV.CurrentRow.Index).Value) + "' FROM FACTURASCLIENTES F INNER JOIN CLIENTERFC R ON F.TIENDA=R.TIENDA AND F.CLIENTE=R.CLIENTE AND F.FACCLIENTE=R.REGISTRO INNER JOIN DETALLEFACTURASCLIENTES DF ON F.TIENDA=DF.TIENDA AND F.FACTURA=DF.FACTURA INNER JOIN DETALLENOTASDEVENTA D ON DF.TIENDA=D.TIENDA AND DF.NOTA=D.NOTA INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE F.TIENDA='" + frmPrincipal.SucursalBase + "' AND F.FACTURA=" + TXTFAC.Text + "", frmPrincipal.CadenaConexion), "Enviar a OneNote 2007")
        LIMPIAR()
    End Sub
    Private Sub LIMPIAR()
        
        TXTCD.Text = ""
        TXTCP.Text = ""
        TXTDFIS.Text = ""
        TXTFAC.Text = ""
        TXTIVA.Text = ""
        TXTLETRA.Text = ""
        TXTNCLI.Text = ""
        TXTNFIS.Text = ""
        CHECACANTIDADES()
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        LIMPIAR()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TXTSI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSI.TextChanged
        CHECACANTIDADES()
    End Sub

    Private Sub TXSNI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXSNI.TextChanged
        CHECACANTIDADES()
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim REP As New rptFactura
        Dim QUERY As String
        QUERY = "SELECT FECHA,NOMBREFISCAL='Publico en General',DIRECCION,CIUDAD,RFC,CONCEPTO NOMBRE,PRECIO=(SUBTOTALIVA+SUBTOTALNOIVA),TOTAL=(SUBTOTALIVA+SUBTOTALNOIVA),SUBTOTAL=(SUBTOTALIVA+SUBTOTALNOIVA),IVA=CONVERT(NUMERIC(15,2),(SUBTOTALIVA*.16),2),ELTOTAL=CONVERT(NUMERIC(15,2),(SUBTOTALIVA+SUBTOTALNOIVA)+(SUBTOTALIVA*.16),2),CCLETRA,CP,UNIDAD='NOTAS',SUBTOTALIVA SUBTOTALPRODUCTOSCONIVA,SUBTOTALNOIVA SUBTOTALPRODUCTOSSINIVA FROM FACTURASCLIENTESPG WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND FACTURA='" + TXTFAC.Text + "'"
        MOSTRARREPORTE(REP, "Factura de: " + frmPrincipal.NombreComun + "  " + TXTFAC.Text, BDLlenatabla(QUERY, frmPrincipal.CadenaConexion), "Enviar a OneNote 2007")

    End Sub

    Private Sub DTDE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTDE.ValueChanged
        CARGAPREFACTURA()
    End Sub
End Class