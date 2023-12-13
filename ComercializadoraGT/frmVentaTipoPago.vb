Public Class frmVentaTipoPago
    Dim LTI As New List(Of String)

    Private Sub frmVentaTipoPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)

        If frmPrincipal.Perfil = 99 Then
            OPLlenaComboBox(CBTI, LTI, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE ACTIVO =1 ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion)
            OPCargaX(LTI, CBTI, frmPrincipal.SucursalBase)
        Else
            OPLlenaComboBox(CBTI, LTI, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE ACTIVO =1  AND CLAVE= '" + frmPrincipal.SucursalBase + "' ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion)
        End If
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim qUERY As String = ("SELECT CLIENTE,NOTA,FACTURA,REMISION,COMPRA,TOTAL,FORMA FROM VVENTATIPOPAGOPCBF N  WHERE N.TIENDA='" & Me.LTI.Item(Me.CBTI.SelectedIndex) & "' AND N.FECHA>=@INI AND N.FECHA<@FIN")
        Me.DGV.DataSource = BDLlenatabla(qUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        Me.DGV.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.DGV.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DGV.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DGV.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DGV.Columns.Item(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DGV.Columns.Item(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim qUERY As String = String.Concat(New String() {"SELECT DBO.NCLIENTESERIEFOLIONOMBRE(TIENDACOBRO,NOTAVENTA,CRE,CLIENTE)CLIENTE,NOTA,FACTURA,REMISION,COMPRA,TOTAL,FORMA,T.NOMBRECOMUN TIENDA,T.NOMBREFISCAL EMPRESA,FECHA2,FECHA=@INI,NOCAJA=1,TIPOPAGO,FACTURADO,INI=@INI,FIN=DATEADD(DD,-1,@FIN)  FROM VVENTATIPOPAGOPCBF N INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE WHERE N.TIENDA='", Me.LTI.Item(Me.CBTI.SelectedIndex), "' AND N.FECHA>=@INI AND N.FECHA<=@FIN  AND N.NOCAJA=1"})
        Dim rEP As New rptVentaSurimi
        MODULOGENERAL.MOSTRARREPORTE(rEP, ("Venta de Price Market del día:" & Me.DTDE.Text), BDLlenatabla(qUERY, frmPrincipal.CadenaConexion, Me.DTDE.Value.Date, Me.DTHASTA.Value.Date.AddDays(1)), "")

    End Sub
End Class