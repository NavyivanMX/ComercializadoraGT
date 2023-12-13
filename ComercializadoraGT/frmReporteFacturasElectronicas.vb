Public Class frmReporteFacturasElectronicas
    Dim CADENA As String
    Dim LRFC As New List(Of String)
    Dim LMOT As New List(Of String)
    Private Sub frmReporteFacturasElectronicas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CADENA = frmPrincipal.CadenaConexionFE
        OPLlenaComboBox(CBCLI, LRFC, "select distinct (c.rfc)rfc,c.nombre from facturas f inner join clientes c on f.rfccliente=c.rfc where f.estado=2 and f.rfcemisor='" + frmPrincipal.EmisorBase + "' order by c.nombre", CADENA, "Todos los Clientes", "")
        OPLlenaComboBox(CBMOT, LMOT, "SELECT CLAVE,CLAVE+' - '+NOMBRE FROM CSATMOTIVOCANCELACION WHERE ACTIVO=1 ORDER BY CLAVE", CADENA, "Favor de Seleccionar", "")
        CHECATABLA()
        If frmPrincipal.Perfil >= 2 Then
            BTNELIMINAR.Visible = True
        Else
            BTNELIMINAR.Visible = False
        End If
    End Sub
    Private Sub CARGADATOS()
        If Not CHECAFECHAS() Then
            Exit Sub
        End If
        Dim QUERY As String
        QUERY = "SELECT F.SERIE,F.FOLIO,F.RFCCLIENTE,F.NOMBRE,C.NOMBRECOMERCIAL,F.TOTAL,F.FECHA,F.ESTADO,F.VCFD VERSION FROM FACTURAS F INNER JOIN CLIENTES C ON F.RFCCLIENTE=C.RFC WHERE F.RFCEMISOR='" + frmPrincipal.EmisorBase + "' AND NEGOCIO='" + frmPrincipal.SucursalBase + "' AND F.FECHA>=@INI AND F.FECHA<=@FIN AND (NTIPOCOMPROBANTE='I' or NTIPOCOMPROBANTE='T')"
        If CBCLI.SelectedIndex <> 0 Then
            QUERY += " AND F.RFCCLIENTE='" + LRFC(CBCLI.SelectedIndex) + "'"
        End If
        DGV.DataSource = BDLlenatabla(QUERY, CADENA, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        'DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(5).DefaultCellStyle = DgvCellFormatoNumerico()
        DgvAjusteEncabezado(DGV, 4)

        CHECATABLA()
    End Sub
    Private Function CHECAFECHAS() As Boolean
        If DTDE.Value.Date > DTHASTA.Value.Date Then
            Return False
        End If
        Return True
    End Function
    Private Sub CHECATABLA()
        If DGV.Rows.Count <= 0 Then
            BTNIMPRIMIR.Enabled = False
            BTNMAIL.Enabled = False
            BTNELIMINAR.Enabled = False
        Else
            BTNIMPRIMIR.Enabled = True
            BTNMAIL.Enabled = True
            BTNELIMINAR.Enabled = True
        End If
    End Sub
    Private Sub MOSTRAR(ByVal FTICKET As Boolean)
        If DGV.Item(7, DGV.CurrentRow.Index).Value = 3 Then
            MessageBox.Show("La factura no esta activada para Mostrarse (Cancelada)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        Dim NI As String
        NI = ""
        Dim VSI As New frmSeleccionarImpresora
        VSI.ShowDialog()
        If VSI.DialogResult = Windows.Forms.DialogResult.Yes Then
            NI = VSI.NIMPRESORA
        End If
        Dim QUERY As String
        QUERY = "SELECT F.RFCEMISOR,E.NOMBRE NOMBREFISCAL,F.FECHA,F.SERIE,F.SUBTOTAL,F.IVA,F.DESCUENTO,F.TOTAL,F.CCLETRA CANTIDADCONLETRA,CON.NOCERTIFICADO,F.FOLIO,DBO.DOMICILIOMATRIZ(F.RFCEMISOR,F.SERIE,F.FOLIO)DOMICILIOMATRIZ,DBO.DOMICILIOEXPEDICION(F.RFCEMISOR,F.SERIE,F.FOLIO)DOMICILIOEXPEDICION,E.LOGOTIPO,E.LOGORFC,F.RFCCLIENTE,F.NOMBRE NOMBRECLIENTE,DBO.DIRECCIONCLI1(F.RFCEMISOR,F.SERIE,F.FOLIO)DOMICLIOCLI1,DBO.DIRECCIONCLI2(F.RFCEMISOR,F.SERIE,F.FOLIO)DOMICLIOCLI2,M.NOMBRE METODOPAGO,FP.NOMBRE FORMAPAGO,F.CADENAORIGINAL,F.SELLO SELLODIGITAL,F.SELLOSAT, F.UUID, P.CODIGO, P.CANTIDAD,P.UNIDAD, P.DESCRIPCION, P.VALORUNITARIO,P.IMPORTE,F.DIGITOSTC,E.REGIMEN,TXTPAGARE=DBO.TXTPAGARE(F.RFCEMISOR,F.SERIE,F.FOLIO),F.CBB CBBFACTURA,P.IEPS,F.COMENTARIO,P.IVA DIVA,IMPORTELIC=(P.IMPORTE+P.IVA+P.IEPS),E.CURP FROM FACTURAS F INNER JOIN EMISORES E ON F.RFCEMISOR=E.RFC INNER JOIN FORMASPAGO FP ON F.FORMAPAGO=FP.CLAVE INNER JOIN METODOSPAGOS M ON F.METODOPAGO=M.CLAVE INNER JOIN CONFIGURACION CON ON E.RFC=CON.RFC INNER JOIN NEGOCIOS N ON F.RFCEMISOR=N.RFC AND F.NEGOCIO=N.CLAVE INNER JOIN CLIENTES C ON F.RFCCLIENTE=C.RFC INNER JOIN DOMICILIOSCLIENTES D ON F.RFCCLIENTE=D.RFC AND F.DOMICILIOCLIENTE=D.REGISTRO INNER JOIN DETALLEFACTURAS P ON F.RFCEMISOR=P.RFCEMISOR AND F.SERIE=P.SERIE AND F.FOLIO=P.FOLIO  where F.RFCEMISOR='" + frmPrincipal.EmisorBase + "' AND F.SERIE='" + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString + "' AND F.FOLIO=" + DGV.Item(1, DGV.CurrentRow.Index).Value.ToString
        If DGV.Item(8, DGV.CurrentRow.Index).Value = "3.3" Or DGV.Item(8, DGV.CurrentRow.Index).Value = "4.0" Then
            QUERY = "SELECT * FROM VRFACTURA33 F where F.RFCEMISOR='" + frmPrincipal.EmisorBase + "' AND F.SERIE='" + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString + "' AND F.FOLIO=" + DGV.Item(1, DGV.CurrentRow.Index).Value.ToString

            If Not frmPrincipal.CHECACONX() Then
                Exit Sub
            End If
            Dim NTC As String
            NTC = ""
            Dim CONZ As New SqlClient.SqlConnection
            CONZ.ConnectionString = CADENA
            Try
                NTC = BDExtraeUnDato("SELECT NTIPOCOMPROBANTE FROM FACTURAS WHERE RFCEMISOR='" + frmPrincipal.EmisorBase + "' AND SERIE='" + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString + "' AND FOLIO=" + DGV.Item(1, DGV.CurrentRow.Index).Value.ToString, CONZ.ConnectionString)
            Catch ex As Exception

            End Try


            If NTC = "P" Then
                If FTICKET Then
                    Dim REP As New rptFacturaTicketV33
                    MOSTRARREPORTE(REP, "Factura Electronica", BDLlenatabla(QUERY, CADENA), NI)
                Else
                    Dim REP As New rptRecepcionPagos
                    MOSTRARREPORTE(REP, "Factura Electronica", BDLlenatabla(QUERY, CADENA), NI)
                End If

            Else
                If FTICKET Then
                    Dim REP As New rptFacturaTicketV33
                    MOSTRARREPORTE(REP, "Factura Electronica", BDLlenatabla(QUERY, CADENA), NI)
                Else
                    If DGV.Item(8, DGV.CurrentRow.Index).Value = "4.0" Then
                        QUERY = "SELECT * FROM VRFACTURA33 F where F.RFCEMISOR='" + frmPrincipal.EmisorBase + "' AND F.SERIE='" + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString + "' AND F.FOLIO=" + DGV.Item(1, DGV.CurrentRow.Index).Value.ToString

                        Dim REP As New rptFENavySoluciones40
                        MOSTRARREPORTE(REP, "Factura Electronica 4.0", BDLlenatabla(QUERY, CADENA), NI)
                    Else
                        Dim REP As New rptFEBajamar33
                        MOSTRARREPORTE(REP, "Factura Electronica", BDLlenatabla(QUERY, CADENA), NI)
                    End If
                End If
            End If


        Else
            If DGV.Item(8, DGV.CurrentRow.Index).Value = "3.2" Then
                Dim REP As New rptFacturaPM
                MOSTRARREPORTE(REP, "Factura Electronica", BDLlenatabla(QUERY, CADENA), NI)
            Else
                Dim REP As New rptFacturaPM
                MOSTRARREPORTE(REP, "Factura Electronica", BDLlenatabla(QUERY, CADENA), NI)
            End If
        End If

        'Dim REP As New rptFacturaElectronica3
        'MOSTRARREPORTE(REP, "Factura Electronica", BDLlenatabla(QUERY, CADENA), "Enviar a OneNote 2007")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CARGADATOS()
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        MOSTRAR(False)
    End Sub

    Private Sub ENVIARCORREO()
        If DGV.Item(7, DGV.CurrentRow.Index).Value = 3 Then
            MessageBox.Show("La factura no esta activada para Enviarse (Cancelada)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        Dim VCC As New frmCorreosClientesFacturas
        VCC.MOSTRARYENVIAR(DGV.Item(0, DGV.CurrentRow.Index).Value.ToString, DGV.Item(1, DGV.CurrentRow.Index).Value)
    End Sub

    Private Sub BTNMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMAIL.Click
        ENVIARCORREO()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MOSTRAR(True)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmClsBusqueda.BUSCAR("SELECT RFC,NOMBRE,NOMBRECOMERCIAL FROM VCLIENTES  ", " WHERE COMPUESTO", " ORDER BY NOMBRE", "Búsqueda de Clientes de Facturas", "Nombre del cliente", "Registro(s)", 1, CADENA, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            OPCargaX(LRFC, CBCLI, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles BTNELIMINAR.Click
        If CBMOT.SelectedIndex = 0 Then
            OPMsgError("Es requerido el motivo de cancelación")
            Exit Sub
        End If

        BDEjecutarSql("UPDATE FACTURAS SET ESTADO=6,MOTIVOCANCELACION='" + LMOT(CBMOT.SelectedIndex) + "',FOLIOSUSTITUYE='" + TXTFS.Text + "' WHERE RFCEMISOR='" + frmPrincipal.EmisorBase + "' AND SERIE='" + DGV.Item(0, DGV.CurrentRow.Index).Value.ToString + "' AND FOLIO=" + DGV.Item(1, DGV.CurrentRow.Index).Value.ToString, CADENA)
        CARGADATOS()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        frmClsBusqueda.BUSCAR("SELECT F.RFCEMISOR,F.SERIE,F.FOLIO,F.FECHA,F.TOTAL,F.UUID,F.Nombre FROM FACTURAS F WHERE F.RFCEMISOR='" + frmPrincipal.EmisorBase + "' AND F.FECHA>=DATEADD(MM,-15,GETDATE()) AND UUID<>'' ", " and nombre", " ORDER BY F.FECHA", "Búsqueda de facturas a relacionar", "Nombre del Cliente", "Registro(s)", 1, CADENA, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTFS.Text = frmClsBusqueda.TREG.Rows(0).Item(5).ToString
        End If
    End Sub

    Private Sub BTNINFO_Click(sender As Object, e As EventArgs) Handles BTNINFO.Click
        frmInfo.Mostrar("Información Cancelación Factura", "", " 01.- Comprobantes emitidos con errores con relación. Este supuesto aplica cuando la factura generada contiene un error en la clave del producto, valor unitario, descuento o cualquier otro dato, por lo que se debe reexpedir. En este caso, primero se sustituye la factura y cuando se solicita la cancelación, se incorpora el folio de la factura que sustituye a la cancelada." + Chr(13) + " 02.- Comprobantes emitidos con errores sin relación. Este supuesto aplica cuando la factura generada contiene un error en la clave del producto, valor unitario, descuento o cualquier otro dato y no se requiera relacionar con otra factura generada." + Chr(13) + " 03.- No se llevó a cabo la operación. Este supuesto aplica cuando se facturó una operación que no se concreta." + Chr(13) + " 04.- Operación nominativa relacionada en una factura global. Este supuesto aplica cuando se incluye una venta en la factura global de operaciones con el público en general y posterior a ello, el cliente solicita su factura nominativa, lo que conlleva a cancelar la factura global y reexpedirla, así como generar la factura nominativa al cliente." + Chr(13) + "")
    End Sub
End Class