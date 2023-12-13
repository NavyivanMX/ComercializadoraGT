Imports System.Data.SqlClient
Public Class frmCajaChica
    Dim CANT As Double
    Dim LCON As New List(Of String)
    Dim LSUB As New List(Of String)
    Dim LPRO As New List(Of String)
    Dim DT As New DataTable
    Dim DV As New DataView
    Private Sub frmCajaChica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        Dim DA As New SqlClient.SqlDataAdapter("SELECT C.CLAVE CCON,C.NOMBRE NCON,S.CLAVE SCON,S.NOMBRE SNOM FROM CONCEPTOSGASTOS C INNER JOIN CONCEPTOSUBCONCEPTO D ON C.CLAVE=D.CONCEPTO INNER JOIN SUBCONCEPTOSGASTOS S ON D.SUBCONCEPTO=S.CLAVE WHERE D.ACTIVO=1 AND S.EMPRESA=" + frmPrincipal.Empresa + "", frmPrincipal.CONX)
        DA.Fill(DT)
        CARGACONCEPTOS()
        CARGAPROVEEDORES()
        CARGADATOS()
    End Sub
    Private Sub CARGACONCEPTOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        LCON.Clear()
        CBCON.Items.Clear()
        Dim SQL As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM CONCEPTOSGASTOS WHERE ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        While LEC.Read
            LCON.Add(LEC(0))
            CBCON.Items.Add(LEC(1))
        End While
        LEC.Close()
        Try
            CBCON.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub CALCULATOTAL()
        Dim SUBT, IVA, TOT As Double
        SUBT = 0
        IVA = 0
        TOT = 0
        Try
            SUBT = CType(TXTSUB.Text, Double)
        Catch ex As Exception
            TXTSUB.Text = "0"
        End Try
        Try
            IVA = CType(TXTIVA.Text, Double)
        Catch ex As Exception
            TXTIVA.Text = "0"
        End Try
        TXTTOT.Text = FormatNumber(SUBT + IVA, 2).ToString
    End Sub
    Private Sub CARGAPROVEEDORES()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        LPRO.Clear()
        CBPRO.Items.Clear()
        Dim SQL As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM PROVEEDORES WHERE EMPRESA='" + frmPrincipal.Empresa + "' AND ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        While LEC.Read
            LPRO.Add(LEC(0))
            CBPRO.Items.Add(LEC(1))
        End While
        LEC.Close()
        Try
            CBPRO.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Function CARGADATAVIEW(ByVal GRUPO As String) As Boolean
        DV = New DataView(DT, "CCON='" + GRUPO + "'", "SNOM", DataViewRowState.CurrentRows)
        Return CARGASUBCONCEPTOS(GRUPO)
    End Function
    Private Function CARGASUBCONCEPTOS(ByVal GRUPO As String) As Boolean
        LSUB.Clear()
        CBSUB.Items.Clear()
        Dim X As Integer
        Dim DRV As DataRowView



        For X = 0 To DV.Count - 1
            DRV = DV.Item(X)
            CBSUB.Items.Add(DRV.Item(3))
            LSUB.Add(DRV.Item(2))
        Next


        For X = 0 To CBSUB.Items.Count - 1
            If CBSUB.Items(X) = "GENERAL" Then
                CBSUB.SelectedIndex = X
            End If
        Next

        Try
            If CBSUB.Text = "GENERAL" Then
            Else
                CBSUB.SelectedIndex = 0
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
    Dim NOORDEN As String
    Dim FEC As DateTime
    Private Function VALIDAPROVEEDORFACTURA(ByVal FAC As String) As Boolean
        If Not frmPrincipal.CHECACONX Then
            Return False
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT FACTURA,NOORDEN,FECHA FROM COMPRAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND PROVEEDOR='" + LPRO(CBPRO.SelectedIndex).ToString + "' AND FACTURA='" + FAC + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            NOORDEN = LEC(1)
            FEC = LEC(2)
            LEC.Close()
            Return False
        Else
            LEC.Close()
        End If
        Dim SQLFR As New SqlClient.SqlCommand("SELECT FACTURA,REGISTRO,FECHA FROM GASTOSCAJACHICA WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND PROVEEDOR='" + LPRO(CBPRO.SelectedIndex).ToString + "' AND FACTURA='" + FAC + "'", frmPrincipal.CONX)
        Dim LECFR As SqlClient.SqlDataReader
        LECFR = SQLFR.ExecuteReader
        If LECFR.Read Then
            NOORDEN = LECFR(1)
            FEC = LECFR(2)
            LECFR.Close()
            Return False
        Else
            LECFR.Close()
        End If
        'Dim SQLCC As New SqlClient.SqlCommand("SELECT NUMFACTURA,REGISTRO,FECHA FROM FACTURASRESTAURANTES WHERE RESTAURANTE='" + frmPrincipal.SucursalBase + "' AND PROVEEDOR='" + LPRO(CBPRO.SelectedIndex).ToString + "' AND NUMFACTURA='" + FAC + "'", frmPrincipal.CONX)
        'Dim LECCC As SqlClient.SqlDataReader
        'LECCC = SQLCC.ExecuteReader
        'If LECCC.Read Then
        '    NOORDEN = LECCC(1)
        '    FEC = LECCC(2)
        '    LECCC.Close()
        '    Return False
        'Else
        '    LECCC.Close()
        'End If
        Return True
    End Function
    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        If Not VALIDAPROVEEDORFACTURA(TXTFAC.Text) Then
            MessageBox.Show("La Factura " + TXTFAC.Text + " del Proveedor " + CBPRO.Text + " ya se Encuentra Registrada, No se permite capturar 2 Veces una factura en una Compra. Referencias: No Orden: " + NOORDEN.ToString + ", Fecha: " + FormatDateTime(FEC, DateFormat.ShortDate).ToString, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea Guardar la Informacin?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
    End Sub
    Private Sub GUARDAR()
        CALCULATOTAL()
        Dim SQL As New SqlClient.SqlCommand("AGREGAGASTOCAJACHICA", frmPrincipal.CONX)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.Parameters.Add("@RES", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQL.Parameters.Add("@CON", SqlDbType.Int).Value = LCON(CBCON.SelectedIndex)
        SQL.Parameters.Add("@SUB", SqlDbType.Int).Value = LSUB(CBSUB.SelectedIndex)
        SQL.Parameters.Add("@PRO", SqlDbType.VarChar).Value = LPRO(CBPRO.SelectedIndex)
        SQL.Parameters.Add("@FAC", SqlDbType.VarChar).Value = TXTFAC.Text
        SQL.Parameters.Add("@SUBT", SqlDbType.Float).Value = TXTSUB.Text
        SQL.Parameters.Add("@IVA", SqlDbType.Float).Value = TXTIVA.Text
        SQL.Parameters.Add("@TOT", SqlDbType.Float).Value = TXTTOT.Text
        SQL.Parameters.Add("@FEC", SqlDbType.DateTime).Value = DTFECHADIA.Value.Date

        SQL.ExecuteNonQuery()
        MessageBox.Show("La información ha sido guardada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        IMPRIMIR()
        CARGADATOS()
    End Sub
    Private Sub IMPRIMIR()
        Dim PED As Integer
        PED = 0
        Dim SQL As New SqlClient.SqlCommand("SELECT MAX(REGISTRO)REGISTRO FROM GASTOSCAJACHICA WHERE TIENDA='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            PED = LEC(0)
        End If
        LEC.Close()
        'Dim REP As New rptTicketGastos
        'Dim CI As New clsImprimir
        'CI.IMPRIMIR2(REP, "SELECT R.NOMBRECOMUN RESTAURANTE,C.NOMBRE CONCEPTO,S.NOMBRE SUBCONCEPTO,P.NOMBRE PROVEEDOR,G.FACTURA,G.SUBTOTAL,G.IVA,G.TOTAL,G.FECHA FROM GASTOSCAJACHICA G INNER JOIN CONCEPTOSGASTOS C ON G.CONCEPTO=C.CLAVE INNER JOIN SUBCONCEPTOSGASTOS S ON G.SUBCONCEPTO=S.CLAVE INNER JOIN PROVEEDORESRESTAURANTES P ON G.RESTAURANTE=P.RESTAURANTE AND G.PROVEEDOR=P.CLAVE INNER JOIN RESTAURANTES R ON G.RESTAURANTE=R.CLAVE WHERE G.RESTAURANTE='" + frmPrincipal.SucursalBase + "' AND G.REGISTRO=" + PED.ToString + "", 1, frmPrincipal.CadenaConexion)
        'CI.GUARDAR2(REP, "SQLEC", CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "Acrobat Reader", ".pdf", "desea", frmPrincipal.CadenaConexion)
        'CI.IMPRIMIR2(REP, "seklect", 1, frmPrincipal.CadenaConexion)
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String
        QUERY = "SELECT G.FECHAFACTURA,C.NOMBRE CONCEPTO,S.NOMBRE SUBCONCEPTO,P.NOMBRE PROVEEDOR,G.FACTURA,G.SUBTOTAL,G.IVA,G.TOTAL,G.REGISTRO FROM GASTOSCAJACHICA G INNER JOIN CONCEPTOSGASTOS C ON G.CONCEPTO=C.CLAVE AND C.EMPRESA=" + frmPrincipal.Empresa + " INNER JOIN SUBCONCEPTOSGASTOS S ON G.SUBCONCEPTO=S.CLAVE AND S.EMPRESA=C.EMPRESA INNER JOIN PROVEEDORES P ON C.EMPRESA=P.EMPRESA AND G.PROVEEDOR=P.CLAVE WHERE G.TIENDA='" + frmPrincipal.SucursalBase + "' AND FECHA>=@INI AND FECHA<@FIN"
        Dim DA As New SqlClient.SqlDataAdapter(QUERY, frmPrincipal.CONX)
        DA.SelectCommand.Parameters.Add("@INI", SqlDbType.DateTime).Value = DTFECHADIA.Value.Date
        DA.SelectCommand.Parameters.Add("@FIN", SqlDbType.DateTime).Value = DTFECHADIA.Value.Date.AddDays(1)
        Dim DT As New DataTable
        DA.Fill(DT)
        DGV.DataSource = DT
        'DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim TOT As Double
        TOT = 0
        For X = 0 To DGV.Rows.Count - 1
            TOT = TOT + DGV.Item(7, X).Value
        Next
        LBLTOT.Text = FormatNumber(TOT).ToString
    End Sub

    Private Sub DTFECHADIA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTFECHADIA.ValueChanged
        CARGADATOS()
    End Sub

    Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQUITAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("Desea eliminar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("DELETE FROM GASTOSCAJACHICA WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND REGISTRO=" + DGV.Item(8, DGV.CurrentRow.Index).Value.ToString + " ", frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
        CARGADATOS()
    End Sub

    Private Sub CBCON_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBCON.SelectedIndexChanged
        CARGADATAVIEW(LCON(CBCON.SelectedIndex))
    End Sub

    Private Sub TXTIVA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTIVA.KeyPress
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
    End Sub

    Private Sub TXTSUB_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSUB.KeyPress
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
    End Sub

    Private Sub TXTSUB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSUB.TextChanged
        CALCULATOTAL()
    End Sub

    Private Sub TXTIVA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTIVA.TextChanged
        CALCULATOTAL()
    End Sub

    Private Sub frmCajaChica_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE FROM PROVEEDORES WHERE EMPRESA='" + frmPrincipal.Empresa + "' AND ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " ", " WHERE NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(LPRO, CBPRO, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
    End Sub
End Class