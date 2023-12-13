Public Class frmEsperaRespuesta
    Dim CONT As Integer
    Dim VRFC, VSERIE As String
    Dim VFOLIO As Integer
    Dim CONZ As New SqlClient.SqlConnection
    Dim CADENA As String
    Dim VECES As Integer
    Private Sub frmEsperaRespuesta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Public Sub MOSTRAR(ByVal RFC As String, ByVal SERIE As String, ByVal FOLIO As Integer)
        CADENA = frmPrincipal.CadenaConexionFE
        Try
            CONZ.ConnectionString = CADENA
        Catch ex As Exception

        End Try

        Try
            CONZ.Open()
        Catch ex As Exception

        End Try
        Timer1.Start()
        CONT = 90
        BTNCANCELAR.Visible = False
        VECES = 1
        PBAR.Value = 0
        PBAR.Maximum = 90
        PBAR.Minimum = 0
        VRFC = RFC
        VSERIE = SERIE
        VFOLIO = FOLIO
        Me.ShowDialog()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PBAR.Increment(1)
        CONT -= 1
        If CONT = 0 Then
            Timer1.Stop()
            PBAR.Value = 0
            PBAR.Maximum = 30
            PBAR.Minimum = 0
            MOSTRARFACTURA()
            Timer1.Start()
        End If
    End Sub
    Private Sub MOSTRARFACTURA()
        If Me.CONZ.State = ConnectionState.Closed Or Me.CONZ.State = ConnectionState.Broken Then
            Try
                Me.CONZ.Open()
            Catch ex As Exception
                MessageBox.Show("La Conexión NO esta realizada, La Informacion No se ha Procesado, Intente en un momento por Favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        Dim SSAT, RES As String
        Dim EST As Integer
        SSAT = ""
        RES = 0
        EST = 1
        Dim SQL As New SqlClient.SqlCommand("SELECT F.SELLOSAT,F.RESULTADO,F.ESTADO FROM FACTURAS F where F.RFCEMISOR='" + VRFC + "' AND F.SERIE='" + VSERIE + "' AND F.FOLIO=" + VFOLIO.ToString, CONZ)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            SSAT = LEC(0)
            RES = LEC(1)
            EST = LEC(2)
        End If
        LEC.Close()
        SQL.Dispose()
        If SSAT = "" Then
            CONT = 30
            BTNCANCELAR.Visible = True
            If EST = 4 Then
                MessageBox.Show("La Respuesta Obtenida fue: " + RES.ToString + ". Favor de revisar la Respuesta Obtenida, ya no se harán mas Intentos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                frmMsg.MOSTRAR("Respuesta Obtenida", "La Respuesta del PAC fue: ", RES)
                Me.Close()
                Exit Sub
            End If
            If VECES >= 3 Then
                MessageBox.Show("No se obtuvo respuesta favor de Comunicarse con Structure Veces=(" + VECES.ToString + ")", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MessageBox.Show("No se obtuvo respuesta, favor de esperar otros 30 seg. Veces=(" + VECES.ToString + ")", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
            VECES += 1
            Exit Sub
        Else
            Dim QUERY As String
            QUERY = "SELECT F.RFCEMISOR,E.NOMBRE NOMBREFISCAL,F.FECHA,F.SERIE,F.SUBTOTAL,F.IVA,F.DESCUENTO,F.TOTAL,F.CCLETRA CANTIDADCONLETRA,F.CERTIFICADOUSA NOCERTIFICADO,F.FOLIO,DBO.DOMICILIOMATRIZ(F.RFCEMISOR,F.SERIE,F.FOLIO)DOMICILIOMATRIZ,DBO.DOMICILIOEXPEDICION(F.RFCEMISOR,F.SERIE,F.FOLIO)DOMICILIOEXPEDICION,E.LOGOTIPO,E.LOGORFC,E.LOGOBIDIMENSIONAL CBBEMISOR,F.RFCCLIENTE,F.NOMBRE NOMBRECLIENTE,DBO.DIRECCIONCLI1(F.RFCEMISOR,F.SERIE,F.FOLIO)DOMICLIOCLI1,DBO.DIRECCIONCLI2(F.RFCEMISOR,F.SERIE,F.FOLIO)DOMICLIOCLI2,M.NOMBRE METODOPAGO,FP.NOMBRE FORMAPAGO,F.CADENAORIGINAL,F.SELLO SELLODIGITAL,F.SELLOSAT,F.UUID,P.CODIGO,P.CANTIDAD,P.DESCRIPCION,CONVERT(NUMERIC(15,2),P.VALORUNITARIO,2)VALORUNITARIO,CONVERT(NUMERIC(15,2),P.IMPORTE,2)IMPORTE,F.RETISR,F.RETIVA,F.NOAPROBACION,F.AÑOAPROBACION,F.CBB CBBFACTURA,P.UNIDAD,F.DIGITOSTC,E.REGIMEN,TXTPAGARE=DBO.TXTPAGARE(F.RFCEMISOR,F.SERIE,F.FOLIO),F.COMENTARIO,P.IEPS,P.IVA DIVA,IMPORTELIC=(P.IMPORTE+P.IVA+P.IEPS),E.CURP FROM FACTURAS F INNER JOIN EMISORES E ON F.RFCEMISOR=E.RFC INNER JOIN FORMASPAGO FP ON F.FORMAPAGO=FP.CLAVE INNER JOIN METODOSPAGOS M ON F.METODOPAGO=M.CLAVE INNER JOIN CONFIGURACION CON ON E.RFC=CON.RFC INNER JOIN NEGOCIOS N ON F.RFCEMISOR=N.RFC AND F.NEGOCIO=N.CLAVE INNER JOIN CLIENTES C ON F.RFCCLIENTE=C.RFC INNER JOIN DOMICILIOSCLIENTES D ON F.RFCCLIENTE=D.RFC AND F.DOMICILIOCLIENTE=D.REGISTRO INNER JOIN DETALLEFACTURAS P ON F.RFCEMISOR=P.RFCEMISOR AND F.SERIE=P.SERIE AND F.FOLIO=P.FOLIO where F.RFCEMISOR='" + VRFC + "' AND F.SERIE='" + VSERIE + "' AND F.FOLIO=" + VFOLIO.ToString
            If frmPrincipal.VCFD = "3.2" Then
                Dim REP As New rptFacturaPM
                MOSTRARREPORTE(REP, "Factura Electronica", BDLlenatabla(QUERY, CADENA), "Enviar a OneNote 2007")
            Else
                Dim REP As New rptFacturaPM
                MOSTRARREPORTE(REP, "Factura Electronica", BDLlenatabla(QUERY, CADENA), "Enviar a OneNote 2007")
            End If
            Me.Close()
        End If
    End Sub
End Class
