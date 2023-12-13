Public Class frmAjustadorFacturasSinTimbrar
    Dim LRFC As New List(Of String)
    Dim LNEG As New List(Of String)
    Dim LFP As New List(Of String)
    Dim LMP As New List(Of String)
    Dim LRF As New List(Of String)
    Dim LUSO As New List(Of String)
    Dim LMON As New List(Of String)
    Dim LTC As New List(Of String)
    Dim REGDOM As String

    Private Sub frmAjustadorFacturasSinTimbrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        OPLlenaComboBox(CBEMISOR, LRFC, "SELECT NOMBRE,RFC FROM EMISORES WHERE EMPRESA=" + frmPrincipal.Corporativo + " ORDER BY NOMBRE", frmPrincipal.CadenaConexionFE)
        OPLlenaComboBox(CBFP, LFP, "SELECT CLAVE,CLAVE+' - '+NOMBRE FROM CSATFORMAPAGO WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexionFE, "Favor de Seleccionar", "")
        OPLlenaComboBox(CBMP, LMP, "SELECT CLAVE,CLAVE+' - '+NOMBRE FROM CSATMETODOPAGO WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexionFE, "Favor de Seleccionar", "")
        OPLlenaComboBox(CBRF, LRF, "SELECT CLAVE,CLAVE +' - '+NOMBRE FROM CSATREGIMENFISCAL WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexionFE, "Favor de Seleccionar", "")
        OPLlenaComboBox(CBMON, LMON, "SELECT CLAVE,NOMBRE FROM CSATMONEDA WHERE CLAVE IN ('MXN','USD','XXX') ORDER BY NOMBRE", frmPrincipal.CadenaConexionFE, "Favor de Seleccionar", "")
        OPLlenaComboBox(CBTC, LTC, "SELECT CLAVE,NOMBRE FROM CSATTIPOCOMPROBANTE WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexionFE, "Favor de Seleccionar", "")
        CARGAINFO(True)
        ACTIVAR(True)
    End Sub
    Private Sub ACTIVAR(ByVal V As Boolean)
        TABC.TabPages(1).Enabled = Not V
        TABC.TabPages(2).Enabled = Not V
    End Sub
    Private Sub CARGAINFO(ByVal V As Boolean)
        Dim QUERY As String
        QUERY = "SELECT RFCEMISOR,SERIE,FOLIO,RFCCLIENTE,FECHA,TOTAL,RESULTADO,NOMBRECLIENTE,NOMBRECOMERCIAL FROM VFACTURASSINTIMBRAR WHERE RFCEMISOR='" + CBEMISOR.Text + "'"

        If V Then
            QUERY += " AND FECHA>=DATEADD(MM,-5,GETDATE())"
        Else
            QUERY += " AND FECHA>=@INI AND FECHA<@FIN"
            If CBNEG.SelectedIndex <> 0 Then
                QUERY += " AND NEGOCIO='" + LNEG(CBNEG.SelectedIndex) + "'"
            End If
        End If
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexionFE, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DgvAjusteEncabezado(DGV, "")
    End Sub
    Private Sub CARGADATOS()

    End Sub
    Private Sub CBEMISOR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBEMISOR.SelectedIndexChanged
        Try
            OPLlenaComboBox(CBNEG, LNEG, "SELECT CLAVE,NOMBRE FROM NEGOCIOS WHERE RFC ='" + CBEMISOR.Text + "' ORDER BY NOMBRE", frmPrincipal.CadenaConexionFE, "Todos los Negocios", "")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CARGAINFO(False)
    End Sub

    Private Sub DGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellDoubleClick
        If DGV.RowCount <= 0 Then
            Exit Sub
        End If
        CargaInfoFactura(DGV.Item(0, DGV.CurrentRow.Index).Value.ToString, DGV.Item(1, DGV.CurrentRow.Index).Value.ToString, DGV.Item(2, DGV.CurrentRow.Index).Value.ToString)
    End Sub
    Private Sub CargaInfoFactura(ByVal RFC As String, ByVal SERIE As String, ByVal FOLIO As String)
        If Not frmPrincipal.CHECACONXFE Then

        End If
        ACTIVAR(False)
        TABC.SelectedTab = TABC.TabPages(1)
        LBLEMISOR.Text = RFC
        LBLEMISORD.Text = RFC
        LBLSERIE.Text = SERIE
        LBLSERIED.Text = SERIE
        LBLFOLIO.Text = FOLIO
        LBLFOLIOD.Text = FOLIO

        Dim SQL As New SqlClient.SqlCommand("select F.RFCCLIENTE,F.NOMBRE,F.SUBTOTAL,F.DESCUENTO,F.NFORMAPAGO,F.NMETODOPAGO,F.NUSOCFDI,F.TOTAL,F.RESULTADO,C.REGIMENFISCAL,FECHA,NMONEDA,NTIPOCOMPROBANTE,D.CP,D.REGISTRO,C.NOMBRECOMERCIAL FROM FACTURAS F INNER JOIN CLIENTES C ON F.RFCCLIENTE=C.RFC INNER JOIN DOMICILIOSCLIENTES D ON F.RFCCLIENTE=D.RFC AND F.DOMICILIOCLIENTE=D.REGISTRO WHERE F.RFCEMISOR='" + RFC + "' AND F.SERIE='" + SERIE + "' AND F.FOLIO=" + FOLIO, frmPrincipal.CONXFE)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            TXTRFC.Text = LEC(0)
            TXTNOM.Text = LEC(1)
            TXTSUB.Text = LEC(2)
            TXTDES.Text = LEC(3)
            TXTTOT.Text = LEC(7)
            TXTRESULTADO.Text = LEC(8)
            OPCargaX(LFP, CBFP, LEC(4))
            OPCargaX(LMP, CBMP, LEC(5))
            OPCargaX(LRF, CBRF, LEC(9))
            OPCargaX(LUSO, CBUSO, LEC(6))
            DTFECHAFAC.Value = LEC(10)
            DTHORA.Value = LEC(10)
            OPCargaX(LMON, CBMON, LEC(11))
            OPCargaX(LTC, CBTC, LEC(12))
            TXTCP.Text = LEC(13)
            REGDOM = LEC(14)
            TXTNOMCOM.Text = LEC(15)
        End If
        LEC.Close()
        SQL.Dispose()
        DGVD.DataSource = BDLlenatabla("SELECT CODIGO,CANTIDAD,DESCRIPCION,VALORUNITARIO,IMPORTE,UNIDAD,IVA,TASAIVA,TIPOFACTORIVA,IEPS,TASAIEPS,TIPOFACTORIEPS,PYSSAT,UNISAT,FRACCIONARANCELARIA,CANTIDADADUANA,PESO,REGISTRO FROM DETALLEFACTURAS F WHERE F.RFCEMISOR='" + RFC + "' AND F.SERIE='" + SERIE + "' AND F.FOLIO=" + FOLIO, frmPrincipal.CadenaConexionFE)
        ''17 REGISTRO
        DgvAjusteEncabezado(DGVD, "")
        DGVD.Columns(17).ReadOnly = True
    End Sub

    Private Sub CBRF_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBRF.SelectedIndexChanged
        CARGAUSOCOMPROBANTE(LRF(CBRF.SelectedIndex))
    End Sub
    Private Sub CARGAUSOCOMPROBANTE(ByVal REGIMEN As String)
        Try
            OPLlenaComboBox(CBUSO, LUSO, "SELECT D.CLAVE,D.NOMBRE FROM CSATREGIMENUSO N INNER JOIN CSATUSOCOMPROBANTE D ON N.USO=D.CLAVE WHERE D.ACTIVO=1 AND N.REGIMEN='" + REGIMEN + "' ORDER BY NOMBRE", frmPrincipal.CadenaConexionFE, "Favor de Seleccionar", "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTNGUARDAR_Click(sender As Object, e As EventArgs) Handles BTNGUARDAR.Click
        If CBUSO.SelectedIndex = 0 Then
            OPMsgError("Favor de seleccionar un uso")
            CBUSO.Focus()
            Exit Sub
        End If
        If CBRF.SelectedIndex = 0 Then
            OPMsgError("Favor de seleccionar un regimen")
            CBRF.Focus()
            Exit Sub
        End If
        If CBFP.SelectedIndex = 0 Then
            OPMsgError("Favor de seleccionar forma de pago")
            CBFP.Focus()
            Exit Sub
        End If
        If CBMP.SelectedIndex = 0 Then
            OPMsgError("Favor de seleccionar metodo pago")
            CBMP.Focus()
            Exit Sub
        End If
        If CBMON.SelectedIndex = 0 Then
            OPMsgError("Favor de seleccionar moneda")
            CBMP.Focus()
            Exit Sub
        End If
        If CBTC.SelectedIndex = 0 Then
            OPMsgError("Favor de seleccionar tipocomprobante")
            CBTC.Focus()
            Exit Sub
        End If
        Dim CP As Integer
        Try
            CP = CType(TXTCP.Text, Integer)
        Catch ex As Exception
            OPMsgError("Favor de escribir un codigo postal valido")
            Exit Sub
        End Try
        If TXTCP.TextLength <> 5 Then
            OPMsgError("Favor de escribir un codigo postal valido")
            Exit Sub
        End If
        BDEjecutarSql("UPDATE CLIENTES SET REGIMENFISCAL='" + LRF(CBRF.SelectedIndex) + "',NOMBRE='" + TXTNOM.Text + "' WHERE RFC='" + TXTRFC.Text + "'", frmPrincipal.CadenaConexionFE)
        BDEjecutarSql("UPDATE DOMICILIOSCLIENTES SET CP='" + TXTCP.Text + "' WHERE RFC='" + TXTRFC.Text + "' AND REGISTRO=" + REGDOM, frmPrincipal.CadenaConexionFE)
        BDEjecutarSql("UPDATE FACTURAS SET ESTADO=1,ERRORAJUSTADO=1,FECHA=@INI,RFCCLIENTE='" + TXTRFC.Text + "',NOMBRE='" + TXTNOM.Text + "',SUBTOTAL='" + TXTSUB.Text + "',DESCUENTO='" + TXTDES.Text + "',NFORMAPAGO='" + LFP(CBFP.SelectedIndex) + "',NMETODOPAGO='" + LMP(CBMP.SelectedIndex) + "',NUSOCFDI='" + LUSO(CBUSO.SelectedIndex) + "',TOTAL='" + TXTTOT.Text + "',NMONEDA='" + LMON(CBMON.SelectedIndex) + "',NTIPOCOMPROBANTE='" + LTC(CBTC.SelectedIndex) + "' WHERE RFCEMISOR='" + LBLEMISOR.Text + "' AND SERIE='" + LBLSERIE.Text + "' AND FOLIO='" + LBLFOLIO.Text + "'", frmPrincipal.CadenaConexionFE, SUMARTIEMPOAFECHA(DTFECHAFAC.Value, DTHORA.Value), DTFECHAFAC.Value)
        OPMsgOK("La información general ha sido guardada")
    End Sub

    Private Sub BTNCLI_Click(sender As Object, e As EventArgs) Handles BTNCLI.Click
        frmClsBusqueda.BUSCAR("SELECT RFC,NOMBRE,NOMBRECOMERCIAL [NOMBRE COMERCIAL] FROM CLIENTES ", " WHERE NOMBRECOMERCIAL", " ORDER BY NOMBRE", "Búsqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 2, frmPrincipal.CadenaConexionFE, True)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTRFC.Text = frmClsBusqueda.TREG.Rows(0).Item(0)
            TXTNOM.Text = frmClsBusqueda.TREG.Rows(0).Item(1)
            TXTNOMCOM.Text = frmClsBusqueda.TREG.Rows(0).Item(2)
        End If
    End Sub

    Private Sub BTNGUARDARD_Click(sender As Object, e As EventArgs) Handles BTNGUARDARD.Click
        Dim X As Integer
        For X = 0 To DGVD.RowCount - 1
            BDEjecutarSql("UPDATE DETALLEFACTURAS SET CODIGO='" + DGVD.Item(0, X).Value.ToString + "',CANTIDAD='" + DGVD.Item(1, X).Value.ToString + "',DESCRIPCION='" + DGVD.Item(2, X).Value.ToString + "',VALORUNITARIO='" + DGVD.Item(3, X).Value.ToString + "',IMPORTE='" + DGVD.Item(4, X).Value.ToString + "',UNIDAD='" + DGVD.Item(5, X).Value.ToString + "',IVA='" + DGVD.Item(6, X).Value.ToString + "',TASAIVA='" + DGVD.Item(7, X).Value.ToString + "',TIPOFACTORIVA='" + DGVD.Item(8, X).Value.ToString + "',IEPS='" + DGVD.Item(9, X).Value.ToString + "',TASAIEPS='" + DGVD.Item(10, X).Value.ToString + "',TIPOFACTORIEPS='" + DGVD.Item(11, X).Value.ToString + "',PYSSAT='" + DGVD.Item(12, X).Value.ToString + "',UNISAT='" + DGVD.Item(13, X).Value.ToString + "',FRACCIONARANCELARIA='" + DGVD.Item(14, X).Value.ToString + "',CANTIDADADUANA='" + DGVD.Item(15, X).Value.ToString + "',PESO='" + DGVD.Item(16, X).Value.ToString + "' WHERE RFC='" + LBLEMISORD.Text + "' AND SERIE='" + LBLSERIED.Text + "' AND FOLIO='" + LBLFOLIOD.Text + "' AND REGISTRO='" + DGV.Item(0, X).Value.ToString + "'", frmPrincipal.CadenaConexionFE)
        Next
        OPMsgOK("La información detalle ha sido guardada, favor de confirmar en generales")
    End Sub

    Private Sub BTNMAIL_Click(sender As Object, e As EventArgs) Handles BTNMAIL.Click
        If BDEjecutarSql("EXEC ENVIARMAILSOLICITUDCONSTANCIA '" + LBLEMISOR.Text + "','" + LBLSERIE.Text + "','" + LBLFOLIO.Text + "'", frmPrincipal.CadenaConexionFE, DTFECHAFAC.Value, DTFECHAFAC.Value) = "OK" Then
            OPMsgOK("Correo de solicitud constancia enviado correctamente")
        Else
            OPMsgError(RESPUESTAMG)
        End If

    End Sub
End Class


