﻿Public Class frmReimpresioncorte

    Private Sub frmReimpresioncorte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Private Sub CARGARDATOS()
        'If Not CHECAFECHAS() Then
        '    Exit Sub
        'End If
        frmPrincipal.CHECACONX()
        Dim QUERY As String

        QUERY = "SELECT H.NOTA,H.NOCAJA CAJA,C.NOMBRE CAJERA,H.TOTAL  FROM NOTASDEVENTA H INNER JOIN TIENDAS S  ON H.TIENDA=S.CLAVE INNER JOIN EMPLEADOS C ON C.CLAVE=H.CAJERA AND C.TIENDA=H.TIENDA WHERE H.FECHA>=@INI AND H.FECHA<@FIN AND H.TIENDA='" + frmPrincipal.SucursalBase + "'"       
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1))
     
        DGV.Refresh()
        'DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim TOT, NOTAS As Double
        TOT = 0
        NOTAS = 0
        For X = 0 To DGV.Rows.Count - 1
            TOT = TOT + DGV.Item(3, X).Value
            ' NOTAS = NOTAS + DGV.Item(4, X).Value
        Next
        LBLNOTAS.Text = DGV.Rows.Count
        LBLTOT.Text = FormatNumber(TOT).ToString
    End Sub
    'Private Function CHECAFECHAS() As Boolean
    '    If DTDE.Value.Date > DTHASTA.Value.Date Then
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function
    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGARDATOS()
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        Dim IMP As New clsImprimir
        Dim QUER As String


        Dim REP2 As New rptCorteFiscal
        'QUER = "SELECT  S.NOMBRECOMUN, N.FECHA, N.NOTA AS NOTAS, n.TOTAL, N.NOCAJA, T.NOMBRE AS TIPOPAGO, S.NOMBREFISCAL AS EMPRESA, S.DIRECCION, S.CIUDAD, S.RFC, S.TELEFONO, S.NOMCAJERA, C.CZ,(CONVERT (NUMERIC(15,2),SUM(DBO.SUBTOTAL(D.PRODUCTO,D.TOTAL)),2)-(DBO.IVACREDITO3 ('" + frmPrincipal.SucursalBase + "',1,@ini,@fin,N.TOTAL)))SUBTOTAL,(CONVERT(NUMERIC(15,2), SUM(DBO.IVA(D.PRODUCTO,D.TOTAL)*.16),2)+(DBO.IVACREDITO3 ('" + frmPrincipal.SucursalBase + "',1,@ini,@fin,N.TOTAL)))IVA,ELTOTAL=SUM(d.TOTAL),FECHACORTE=@INI,HORACORTE=DATEADD(mi,1140,@INI) FROM  dbo.NOTASDEVENTA AS N INNER JOIN DETALLENOTASDEVENTA D  ON D.NOTA=N.NOTA AND D.TIENDA=n.TIENDA INNER JOIN PRODUCTOS P ON P.CLAVE=D.PRODUCTO AND P.EMPRESA=" + frmPrincipal.Empresa + " INNER JOIN dbo.TIPOSPAGOS AS T   ON N.TIPOPAGO = T.CLAVE INNER JOIN dbo.TIENDAS AS S  ON N.TIENDA = S.CLAVE AND D.TIENDA=S.CLAVE INNER JOIN dbo.CORTES AS C ON C.TIENDA = N.TIENDa  WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.FECHA>=@ini and n.fecha<=@fin  GROUP BY N.FECHA, N.NOTA ,  N.NOCAJA, T.NOMBRE , S.NOMBREFISCAL, S.DIRECCION, S.CIUDAD, S.RFC, S.TELEFONO, S.NOMCAJERA,  C.CZ,n.TOTAL,S.NOMBRECOMUN"
        'IMPRIMIRREPORTE(REP2, BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1)), 1, "")


        ' Dim REP2 As New rptCorteFiscal
        'QUER = "SELECT  S.NOMBRECOMUN, N.FECHA, N.NOTA AS NOTAS, n.TOTAL, N.NOCAJA, T.NOMBRE AS TIPOPAGO, S.NOMBREFISCAL AS EMPRESA, S.DIRECCION, S.CIUDAD, S.RFC, S.TELEFONO, S.NOMCAJERA, C.CZ,(CONVERT (NUMERIC(15,2),SUM(DBO.SUBTOTAL(D.PRODUCTO,D.TOTAL)),2)-(DBO.IVACREDITO3 ('" + frmPrincipal.SucursalBase + "'," + NOCAJA.ToString + ",@fec,dateadd(dd,1,@fec),N.TOTAL)))SUBTOTAL,(CONVERT(NUMERIC(15,2), SUM(DBO.IVA(D.PRODUCTO,D.TOTAL)*.16),2)+(DBO.IVACREDITO3 ('" + frmPrincipal.SucursalBase + "'," + NOCAJA.ToString + ",@fec,dateadd(dd,1,@fec),N.TOTAL)))IVA,ELTOTAL=SUM(d.TOTAL),FECHACORTE='" + Format(Now.Date, "yyyyMMdd") + "',HORACORTE=@FEC FROM  dbo.NOTASDEVENTA AS N INNER JOIN DETALLENOTASDEVENTA D  ON D.NOTA=N.NOTA AND D.TIENDA=n.TIENDA INNER JOIN PRODUCTOS P ON P.CLAVE=D.PRODUCTO AND P.EMPRESA=" + frmPrincipal.Empresa + " INNER JOIN dbo.TIPOSPAGOS AS T  ON N.TIPOPAGO = T.CLAVE INNER JOIN dbo.TIENDAS AS S  ON N.TIENDA = S.CLAVE AND D.TIENDA=S.CLAVE INNER JOIN dbo.CORTES AS C  ON C.TIENDA = N.TIENDa   WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.FECHA>=@fec  GROUP BY N.FECHA, N.NOTA ,  N.NOCAJA, T.NOMBRE , S.NOMBREFISCAL, S.DIRECCION, S.CIUDAD, S.RFC, S.TELEFONO, S.NOMCAJERA,  C.CZ,n.TOTAL,S.NOMBRECOMUN"
        'IMP.IMPRIMIR1(REP2, QUER, 1, frmPrincipal.CadenaConexion, LPARA, LTIPO, LVALO)


        QUER = "SELECT S.NOMBRECOMUN,N.FECHA,N.NOTA NOTAS,N.TOTAL,N.CAJA NOCAJA,T.NOMBRE TIPOPAGO,S.NOMBREFISCAL EMPRESA,S.DIRECCION,S.CIUDAD,S.RFC,S.TELEFONO,S.NOMCAJERA,C.CZ,SUBTOTAL,IVA,ELTOTAL=N.TOTAL,FECHACORTE=GETDATE(),HORACORTE=GETDATE() FROM VCORTES N INNER JOIN TIENDAS S ON N.TIENDA =S.CLAVE INNER JOIN TIPOSPAGOS T ON N.TIPOPAGO =T.CLAVE INNER JOIN CORTES C ON N.TIENDA =C.TIENDA  AND N.CAJA=C.CAJA WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.FECHA>=@INI AND N.FECHA<@FIN  AND N.FORMA<>'CREDITO' ORDER BY N.NOTA"
        IMPRIMIRREPORTE(REP2, BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1)), 1, "")
        'Dim REP2 As New rptCorteFiscal'
        'QUER = "SELECT  S.NOMBRECOMUN, N.FECHA, N.NOTA AS NOTAS, n.TOTAL, N.NOCAJA, T.NOMBRE AS TIPOPAGO, S.NOMBREFISCAL AS EMPRESA, S.DIRECCION, S.CIUDAD, S.RFC, S.TELEFONO, S.NOMCAJERA, C.CZ,(CONVERT (NUMERIC(15,2),SUM(DBO.SUBTOTAL(D.PRODUCTO,D.TOTAL)),2)-(DBO.IVACREDITO3 ('" + frmPrincipal.SucursalBase + "',1,@ini,@fin,N.TOTAL)))SUBTOTAL,(CONVERT(NUMERIC(15,2), SUM(DBO.IVA(D.PRODUCTO,D.TOTAL)*.16),2)+(DBO.IVACREDITO3 ('" + frmPrincipal.SucursalBase + "',1,@fec,@fin,N.TOTAL)))IVA,ELTOTAL=SUM(d.TOTAL),FECHACORTE=@ini,HORACORTE=DATEADD(mi,1140,@INI) FROM  dbo.NOTASDEVENTA AS N INNER JOIN DETALLENOTASDEVENTA D  ON D.NOTA=N.NOTA AND D.TIENDA=n.TIENDA INNER JOIN PRODUCTOS P ON P.CLAVE=D.PRODUCTO AND P.EMPRESA=" + frmPrincipal.Empresa + " INNER JOIN dbo.TIPOSPAGOS AS T  ON N.TIPOPAGO = T.CLAVE INNER JOIN dbo.TIENDAS AS S  ON N.TIENDA = S.CLAVE AND D.TIENDA=S.CLAVE INNER JOIN dbo.CORTES AS C  ON C.TIENDA = N.TIENDa   WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.FECHA>=@ini  GROUP BY N.FECHA, N.NOTA ,  N.NOCAJA, T.NOMBRE , S.NOMBREFISCAL, S.DIRECCION, S.CIUDAD, S.RFC, S.TELEFONO, S.NOMCAJERA,  C.CZ,n.TOTAL,S.NOMBRECOMUN"
        'IMP.IMPRIMIR1(REP2, QUER, 1, frmPrincipal.CadenaConexion, LPARA, LTIPO, LVALO)

        'Dim REP2 As New rptCorteFiscal
        'QUER = "SELECT  S.NOMBRECOMUN, N.FECHA, N.NOTA AS NOTAS, n.TOTAL, N.NOCAJA, T.NOMBRE AS TIPOPAGO, S.NOMBREFISCAL AS EMPRESA, S.DIRECCION, S.CIUDAD, S.RFC, S.TELEFONO, S.NOMCAJERA, C.CZ,(CONVERT (NUMERIC(15,2),SUM(DBO.SUBTOTAL(D.PRODUCTO,D.TOTAL)),2)-(DBO.IVACREDITO3 ('" + frmPrincipal.SucursalBase + "'," + NOCAJA.ToString + ",@fec,dateadd(dd,1,@fec),N.TOTAL)))SUBTOTAL,(CONVERT(NUMERIC(15,2), SUM(DBO.IVA(D.PRODUCTO,D.TOTAL)*.16),2)+(DBO.IVACREDITO3 ('" + frmPrincipal.SucursalBase + "',1,@fec,dateadd(dd,1,@fec),N.TOTAL)))IVA,ELTOTAL=SUM(d.TOTAL),FECHACORTE='" + Format(DTDE.Value, "yyyyMMdd") + "',HORACORTE=@FEC FROM  dbo.NOTASDEVENTA AS N INNER JOIN DETALLENOTASDEVENTA D  ON D.NOTA=N.NOTA AND D.TIENDA=n.TIENDA INNER JOIN PRODUCTOS P ON P.CLAVE=D.PRODUCTO AND P.EMPRESA=" + frmPrincipal.Empresa + " INNER JOIN dbo.TIPOSPAGOS AS T  ON N.TIPOPAGO = T.CLAVE INNER JOIN dbo.TIENDAS AS S  ON N.TIENDA = S.CLAVE AND D.TIENDA=S.CLAVE INNER JOIN dbo.CORTES AS C  ON C.TIENDA = N.TIENDa   WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.FECHA>=@fec  GROUP BY N.FECHA, N.NOTA ,  N.NOCAJA, T.NOMBRE , S.NOMBREFISCAL, S.DIRECCION, S.CIUDAD, S.RFC, S.TELEFONO, S.NOMCAJERA,  C.CZ,n.TOTAL,S.NOMBRECOMUN"
        'IMP.IMPRIMIR1(REP2, QUER, 1, frmPrincipal.CadenaConexion, LPARA, LTIPO, LVALO)

        'Dim REP3 As New rptCorteCredito
        'QUER = "select N.NOCAJA,N.FECHA,N.NOTA,N.TOTAL,T.NOMCAJERA FROM NOTASDEVENTACREDITO N INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA='1' AND N.FECHA>=@INI and N.FECHA<=@FIN"
        'IMPRIMIRREPORTE(REP3, BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date), 1, "")

        'Dim REP4 As New rptCorteCobranza
        'QUER = "select N.NOCAJA,N.FECHA,N.NOTA,N.TOTAL,T.NOMCAJERA,TP.NOMBRE TIPOPAGO FROM NOTASCOBRANZAPRO N INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE INNER JOIN TIPOSPAGOS TP ON N.TIPOPAGO=TP.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA='1' AND N.FECHA>=@INI and N.FECHA<=@FIN"
        'IMPRIMIRREPORTE(REP4, BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date), 1, "")

        MessageBox.Show("El corte se ha re-impreso exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        'Dim REP3 As New rptVentasEfectivo
        'QUER = "SELECT TI.NOMBRECOMUN TIENDA,T.NOMBRE TIPOPAGO,N.NOTA,C.NOMBRE CLIENTE,sum (d.total)TOTAL,N.FECHA FROM NOTASDEVENTA N INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE INNER JOIN DETALLENOTASDEVENTA D ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA INNER JOIN TIPOSPAGOS T ON T.CLAVE=N.TIPOPAGO INNER JOIN TIENDAS TI ON TI.CLAVE=N.TIENDA WHERE FECHA>=@INI AND FECHA<=@FIN AND D.PRODUCTO<>'CREDITO' AND T.CLAVE=1 AND n.TIENDA='" + frmPrincipal.SucursalBase + "' group by  TI.NOMBRECOMUN ,T.NOMBRE , N.NOTA,C.NOMBRE,N.FECHA  "
        'IMPRIMIRREPORTE(REP3, BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1)), 1, "")

        'Dim REP4 As New rptVentasTarjeta
        'QUER = "SELECT TI.NOMBRECOMUN TIENDA,T.NOMBRE TIPOPAGO, N.NOTA,C.NOMBRE CLIENTE,N.TOTAL,N.FECHA FROM NOTASDEVENTA N INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE INNER JOIN DETALLENOTASDEVENTA D ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA INNER JOIN TIPOSPAGOS T ON T.CLAVE=N.TIPOPAGO INNER JOIN TIENDAS TI ON TI.CLAVE=N.TIENDA WHERE FECHA>=@INI AND FECHA<=@FIN AND D.PRODUCTO<>'CREDITO' AND T.CLAVE=2 AND n.TIENDA='" + frmPrincipal.SucursalBase + "'  "
        'IMPRIMIRREPORTE(REP4, BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1)), 1, "")

        'Dim REP9 As New rptVentasCheque
        'QUER = "SELECT TI.NOMBRECOMUN TIENDA,T.NOMBRE TIPOPAGO, N.NOTA,C.NOMBRE CLIENTE,N.TOTAL,N.FECHA FROM NOTASDEVENTA N INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE INNER JOIN DETALLENOTASDEVENTA D ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA INNER JOIN TIPOSPAGOS T ON T.CLAVE=N.TIPOPAGO INNER JOIN TIENDAS TI ON TI.CLAVE=N.TIENDA WHERE FECHA>=@INI AND FECHA<=@FIN AND D.PRODUCTO<>'CREDITO' AND T.CLAVE=3 AND n.TIENDA='" + frmPrincipal.SucursalBase + "'  "
        'IMPRIMIRREPORTE(REP9, BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1)), 1, "")

        'Dim REP5 As New rptVentasCreditos
        'QUER = "SELECT TIPOPAGO='CREDITO',N.NOTA,C.NOMBRE CLIENTE,N.TOTAL,N.FECHA FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE WHERE FECHA>=@INI AND FECHA<=@FIN AND N.TIENDA='" + frmPrincipal.SucursalBase + "'  "
        'IMPRIMIRREPORTE(REP5, BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1)), 1, "")

        'Dim REP6 As New rptVentaAbonos
        'QUER = "SELECT TIPOPAGO='ABONOS',N.NOTA,C.NOMBRE CLIENTE,N.TOTAL,N.FECHA FROM NOTASDEVENTA N INNER JOIN CLIENTES C ON C.TIENDA=N.TIENDA AND C.CLAVE=N.CLIENTE INNER JOIN DETALLENOTASDEVENTA D ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA WHERE FECHA>=@INI AND FECHA<=@FIN   AND D.PRODUCTO='CREDITO' AND N.TIENDA='" + frmPrincipal.SucursalBase + "' "
        'IMPRIMIRREPORTE(REP6, BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1)), 1, "")

        'Dim REP7 As New rptVentasFacturas
        'QUER = "SELECT TIPOPAGO='FACTURAS',F.FACTURA,C.NOMBRE CLIENTE,F.TOTAL FROM FACTURASCLIENTES F INNER JOIN CLIENTES C ON C.TIENDA=F.TIENDA AND C.CLAVE=F.CLIENTE WHERE FECHAGUARDO>=@INI AND FECHAGUARDO<=@FIN AND F.TIENDA='" + frmPrincipal.SucursalBase + "' "
        'IMPRIMIRREPORTE(REP7, BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1)), 1, "")

        'Dim REP8 As New rptGasotCajaChica
        'QUER = "SELECT TIPO='GASTO DE CAJA CHICA',DBO.REGRESACONCEPTOSUBCONCEPTO(G.CONCEPTO,G.SUBCONCEPTO)CONCEPTO,P.NOMBRE PROVEEDOR,G.SUBTOTAL,G.IVA,G.TOTAL  FROM GASTOSCAJACHICA G INNER JOIN PROVEEDORES P ON P.CLAVE=G.PROVEEDOR WHERE G.TIENDA='" + frmPrincipal.SucursalBase + "' AND g.FECHA>=@INI AND g.FECHA<=@FIN "
        'IMPRIMIRREPORTE(REP8, BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1)), 1, "")


    End Sub
End Class