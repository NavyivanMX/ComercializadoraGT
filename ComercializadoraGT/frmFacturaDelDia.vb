Public Class frmFacturaDelDia
    Dim LTI As New List(Of String)
    Dim LSPG As New List(Of String)
    Private Sub frmFacturaDelDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        OPLlenaComboBox(CBTI, LTI, LSPG, "SELECT CLAVE,SERIEFAC,NOMBRECOMUN FROM TIENDAS WHERE ACTIVO=1 ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion)
        CHECATABLA()
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim Q1, Q2, Q3, Q4, Q5 As String
        Q1 = "SELECT N.NOTA,N.TOTAL,TP.NOMBRE TIPOPAGO FROM NOTASDEVENTA N INNER JOIN TIPOSPAGOS TP ON N.TIPOPAGO=TP.CLAVE INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE WHERE N.TIENDA='" + LTI(CBTI.SelectedIndex) + "' AND FECHA>=@INI AND FECHA<=@FIN AND DBO.FOLIOFACNOTA(T.SERIEFAC,N.NOTA)<>'N/A' AND NOTA NOT IN (SELECT NOTA FROM VNOTASPAGOCREDITO WHERE TIENDA='" + LTI(CBTI.SelectedIndex) + "')"
        Q2 = "SELECT N.NOTA,N.TOTAL,TP.NOMBRE TIPOPAGO FROM NOTASDEVENTA N INNER JOIN TIPOSPAGOS TP ON N.TIPOPAGO=TP.CLAVE INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE WHERE N.TIENDA='" + LTI(CBTI.SelectedIndex) + "' AND FECHA>=@INI AND FECHA<=@FIN AND DBO.FOLIOFACNOTA(T.SERIEFAC,N.NOTA)='N/A' AND NOTA NOT IN (SELECT NOTA FROM VNOTASPAGOCREDITO WHERE TIENDA='" + LTI(CBTI.SelectedIndex) + "')"
        Q3 = "SELECT N.NOTA,N.TOTAL FROM NOTASDEVENTACREDITO N INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE WHERE N.TIENDA='" + LTI(CBTI.SelectedIndex) + "' AND FECHA>=@INI AND FECHA<=@FIN AND DBO.FOLIOFAC(T.SERIEFAC,N.NOTA)<>'N/A' "
        Q4 = "SELECT N.NOTA,N.TOTAL FROM NOTASDEVENTACREDITO N INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE WHERE N.TIENDA='" + LTI(CBTI.SelectedIndex) + "' AND FECHA>=@INI AND FECHA<=@FIN AND DBO.FOLIOFAC(T.SERIEFAC,N.NOTA)='N/A' "
        Q5 = "SELECT N.NOTA,N.TOTAL,TP.NOMBRE TIPOPAGO FROM NOTASDEVENTA N INNER JOIN TIPOSPAGOS TP ON N.TIPOPAGO=TP.CLAVE INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE WHERE N.TIENDA='" + LTI(CBTI.SelectedIndex) + "' AND FECHA>=@INI AND FECHA<=@FIN AND DBO.FOLIOFACNOTA(T.SERIEFAC,N.NOTA)='N/A' AND NOTA IN (SELECT NOTA FROM VNOTASPAGOCREDITO WHERE TIENDA='" + LTI(CBTI.SelectedIndex) + "')"
        DGV.DataSource = BDLlenatabla(Q1, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1))
        DGV2.DataSource = BDLlenatabla(Q2, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1))
        DGV3.DataSource = BDLlenatabla(Q3, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1))
        DGV4.DataSource = BDLlenatabla(Q4, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1))
        DGV5.DataSource = BDLlenatabla(Q5, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1))
        CHECATABLA()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub CHECATABLA()
        Dim A, B, C, D, E As Double
        A = 0
        B = 0
        C = 0
        D = 0
        E = 0
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            A += DGV.Item(1, X).Value
        Next
        For X = 0 To DGV2.Rows.Count - 1
            B += DGV2.Item(1, X).Value
        Next
        For X = 0 To DGV3.Rows.Count - 1
            C += DGV3.Item(1, X).Value
        Next
        For X = 0 To DGV4.Rows.Count - 1
            D += DGV4.Item(1, X).Value
        Next
        For X = 0 To DGV5.Rows.Count - 1
            E += DGV5.Item(1, X).Value
        Next

        LBLA.Text = "Total: " + FormatNumber(A, 2).ToString
        LBLB.Text = "Total: " + FormatNumber(B, 2).ToString
        LBLC.Text = "Total: " + FormatNumber(C, 2).ToString
        LBLD.Text = "Total: " + FormatNumber(D, 2).ToString
        LBLE.Text = "Total: " + FormatNumber(E, 2).ToString
        LBLF.Text = "Total a Facturar: " + FormatNumber(B + D, 2).ToString

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CARGADATOS()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Q1 As String
        Dim Q2 As String
        Q1 = "SELECT D.PRODUCTO,D.CANTIDAD,P.NOMBRE+' '+P.PEDIMENTO DESCRIPCION,PRECIO=DBO.PRECIOFAC(D.PRODUCTO,D.CANTIDAD,D.TOTAL),TOTAL=DBO.TOTALFAC(D.PRODUCTO,D.TOTAL,D.CANTIDAD),U.NOMBRE UNIDAD,IVA=DBO.IVAFAC(D.PRODUCTO,D.TOTAL,D.CANTIDAD),DBO.IEPSFAC(P.IEPS,D.CANTIDAD,D.TOTAL) IEPS,P.TASAIEPS,P.GRUPOIEPS  FROM NOTASDEVENTA N INNER JOIN DETALLENOTASDEVENTA D ON N.NOTA=D.NOTA AND N.TIENDA=D.TIENDA INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE INNER JOIN UNIDADES U ON P.UVENTA=U.CLAVE INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE WHERE N.TIENDA='" + LTI(CBTI.SelectedIndex) + "' AND FECHA>=@INI AND N.FECHA<=@FIN AND DBO.FOLIOFACNOTA(T.SERIEFAC,N.NOTA)='N/A' AND N.NOTA NOT IN (SELECT NOTA FROM VNOTASPAGOCREDITO WHERE TIENDA='" + LTI(CBTI.SelectedIndex) + "')"
        Q2 = " UNION ALL SELECT D.PRODUCTO,D.CANTIDAD,P.NOMBRE+' '+P.PEDIMENTO DESCRIPCION,PRECIO=DBO.PRECIOFAC(D.PRODUCTO,D.CANTIDAD,D.TOTAL),TOTAL=DBO.TOTALFAC(D.PRODUCTO,D.TOTAL,D.CANTIDAD),U.NOMBRE UNIDAD,IVA=DBO.IVAFAC(D.PRODUCTO,D.TOTAL,D.CANTIDAD),DBO.IEPSFAC(P.IEPS,D.CANTIDAD,D.TOTAL) IEPS,P.TASAIEPS,P.GRUPOIEPS FROM NOTASDEVENTACREDITO N INNER JOIN DETALLENOTASDEVENTACREDITO D ON N.NOTA=D.NOTA AND N.TIENDA=D.TIENDA INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE INNER JOIN UNIDADES U ON P.UVENTA=U.CLAVE INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE WHERE N.TIENDA='" + LTI(CBTI.SelectedIndex) + "' AND FECHA>=@INI AND N.FECHA<=@FIN AND DBO.FOLIOFAC(T.SERIEFAC,N.NOTA)='N/A' "
        Q2 = ""
        frmFacturarV2.MOSTRAR(LTI(CBTI.SelectedIndex), LSPG(CBTI.SelectedIndex), BDLlenatabla(Q1 + Q2, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1)), DTDE.Value.Date)
    End Sub
End Class