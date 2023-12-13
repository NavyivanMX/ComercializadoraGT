Imports System.Drawing.Printing
Imports System.IO
Imports System.Runtime.InteropServices

Public Class frmEtiquetar

    Private Sub frmEtiquetar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        TXTDIR.Text = frmPrincipal.Direccion
    End Sub
    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function
    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        frmClsBusqueda.BUSCAR("SELECT P.CLAVE CLAVE,P.NOMBRECORTO,P.DESCRIPCION,G.NOMBRE GRUPO,P.PRECIO,P.ACTIVO FROM PRODUCTOS P INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE P.EMPRESA=" + frmPrincipal.Empresa + "  AND P.ACTIVO=1  ", " AND P.NOMBRE", " ORDER BY P.DESCRIPCION", "Búsqueda de Artículos", "Nombre o Descripción del Producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCLA.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            LBLNOM.Text = frmClsBusqueda.TREG.Rows(0).Item(1).ToString
            LBLDES.Text = frmClsBusqueda.TREG.Rows(0).Item(2).ToString
            LBLPRE.Text = frmClsBusqueda.TREG.Rows(0).Item(4).ToString
            CARGADATOS()
        End If
        'Exit Sub
        TA.Clear()
        TB.Clear()
        TC.Clear()
        'TD.Clear()
        TE.Clear()
        TF.Clear()
        TG.Clear()
        TH.Clear()
        'TI.Clear()
        TJ.Clear()
        CARGAPEDIMENTO()
    End Sub
    Private Sub CARGAPEDIMENTO()
        'Exit Sub
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQLP As New SqlClient.SqlCommand("SELECT EXPORTADOR,IMPORTADOR,DIRECCION,ORIGEN,INGREDIENTES,SUGERENCIA,PREPARACION,INFORMACION,IMPRESO,PEDIMENTO,LOTE,FECCAD FROM PRODUCTOPEDIMENTO WHERE PRODUCTO='" + TXTCLA.Text + "'", frmPrincipal.CONX)
        Dim LECP As SqlClient.SqlDataReader
        LECP = SQLP.ExecuteReader
        If LECP.Read Then
            TB.Text = LECP(0)
            TA.Text = LECP(1)
            TC.Text = LECP(2)
            TD.Text = LECP(3)
            TE.Text = LECP(4)
            TF.Text = LECP(5)
            TG.Text = LECP(6)
            TH.Text = LECP(7)
            TI.Text = LECP(8)
            TJ.Text = LECP(9)
            TK.Text = LECP(10)
            DTFCAD.Value = LECP(11)
        End If
        If TA.Text = "" Then
            TA.Text = "Enrique Cortez Ruiz"
        End If
        LECP.Close()
        SQLP.Dispose()
    End Sub
    Dim IMPSEL, IMPDEF As String
    Private Sub BTNIMPRIMIR2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR2.Click
        'For i As Integer = 0 To PrinterSettings.InstalledPrinters.Count - 1 '' ciclo de todas las impresoras k tengo instalada en la pc
        '    Dim a As New PrinterSettings() ''' variable de propiedades de impresora
        '    a.PrinterName = PrinterSettings.InstalledPrinters(i).ToString() '' la propiedad de impresora PrinterName= a la impresoras instalada en la posicion i
        '    Try
        '        MessageBox.Show(a.PrinterName)
        'Dim _print As New ZebraPrint
        '_print.StartWrite("//IVANCISNEROS-PC/ZEBRA")

        'Dim _Text As String = "Print test"
        '_print.Write("A30,120,0,4,2,1,N,""" & _Text & """")
        '_print.EndWrite()
        ''Catch ex As Exception
        ''MessageBox.Show(ex.Message)
        ''End Try
        ''Next
        'Exit Sub
        'If TXTCLA.Text.Length = 12 Or TXTCLA.Text.Length = 13 Then
        '    IMPRIMIR()
        'Else
        '    MessageBox.Show("Longitud del código no es soportado ( 12 o 13), No se podran crear codigos de barra", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If
        Dim VSI As New frmSeleccionarImpresora
        VSI.ShowDialog()
        If VSI.DialogResult = Windows.Forms.DialogResult.Yes Then
            IMPSEL = VSI.NIMPRESORA
            IMPDEF = VSI.IMPRESORADEFAULT
        Else
            Exit Sub
        End If
        Try
            SetDefPrinter(IMPSEL)
        Catch ex As Exception

        End Try

        Dim NETI As Integer
        NETI = CType(TXTETI.Text, Integer)
        Dim oPrintDoc As PrintDocument = New PrintDocument()
        AddHandler oPrintDoc.PrintPage, AddressOf ImprimirGrafico
        Dim X As Integer
        For X = 1 To NETI
            oPrintDoc.Print()
        Next
        'oPrintDoc.Print()
        Try
            SetDefPrinter(IMPDEF)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub IMPRIMIR()

        'Dim _print As New ZebraPrint
        '_print.StartWrite("//printserver//ZDesigner GC420t (EPL)")
        'Dim _Text As String = "Print test"
        '_print.Write("A30,120,0,4,2,1,N,""" & _Text & """")
        '_print.EndWrite()
        'Exit Sub
        'Dim REP As New rptEtiquetaProductoN2

        Dim QUERY As String
        Dim DT As New DataTable
        Dim DTTEMP As New DataTable
        QUERY = "SELECT CLAVE,NOMBRECORTO,DESCRIPCION,PM,CANTIDAD=1.00,FECHA=@INI,HORA=@FIN,CODIGO='' FROM PRODUCTOS WHERE CLAVE='" + TXTCLA.Text + "'"
        DTTEMP = New DataTable
        DT = New DataTable
        DT = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value, DTHASTA.Value)
        DTTEMP = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value, DTHASTA.Value)

        DT.Rows.Clear()

        DT.Columns.RemoveAt(7)
        DT.Columns.Add("CODIGO", GetType(Byte()))
        Dim NETI As Integer
        NETI = CType(TXTETI.Text, Integer)
        'Dim X, Y As Integer
        Dim DR As DataRow
        Dim IMG As Image

        'For X = 0 To DTTEMP.Rows.Count - 1
        '    DR = DT.NewRow
        '    DR(0) = DTTEMP.Rows(X).Item(0)
        '    DR(1) = DTTEMP.Rows(X).Item(1)
        '    DR(2) = DTTEMP.Rows(X).Item(2)
        '    DR(3) = DTTEMP.Rows(X).Item(3)
        '    DR(4) = DTTEMP.Rows(X).Item(4)
        '    DR(5) = DTTEMP.Rows(X).Item(5)
        '    DR(6) = DTTEMP.Rows(X).Item(6)
        '    If TXTCLA.Text.Length = 12 Then
        '        IMG = BarCode.CodeEAN13AutoGenerateChecksum(DTTEMP.Rows(X).Item(0), True, 90, True, True)
        '    Else
        '        IMG = BarCode.CodeEAN13(DTTEMP.Rows(X).Item(0), True, 90, True, True)
        '    End If

        '    IMG.RotateFlip(RotateFlipType.Rotate90FlipX)
        '    DR(7) = Image2Bytes(IMG)
        '    DT.Rows.Add(DR)
        'Next

        For X = 0 To NETI - 1
            DR = DT.NewRow
            DR(0) = DTTEMP.Rows(0).Item(0)
            DR(1) = DTTEMP.Rows(0).Item(1)
            DR(2) = DTTEMP.Rows(0).Item(2)
            DR(3) = DTTEMP.Rows(0).Item(3)
            DR(4) = DTTEMP.Rows(0).Item(4)
            If CHKFEC.Checked Then
                DR(5) = DTTEMP.Rows(0).Item(5)
                DR(6) = DTTEMP.Rows(0).Item(6)
            Else
                DR(5) = "'01/01/2010'"
                DR(6) = "'01/01/2010'"
            End If
     
            If TXTCLA.Text.Length = 12 Then
                IMG = BarCode.CodeEAN13AutoGenerateChecksum(DTTEMP.Rows(0).Item(0), True, 90, True, True)
            Else
                IMG = BarCode.CodeEAN13(DTTEMP.Rows(0).Item(0), True, 90, True, True)
            End If

            IMG.RotateFlip(RotateFlipType.Rotate90FlipX)
            DR(7) = Image2Bytes(IMG)
            DT.Rows.Add(DR)
        Next
        Dim REP As New rptEtiquetaProducto
        IMPRIMIRREPORTE(REP, DT, NETI, "")
        For Y = 1 To NETI
            REP = New rptEtiquetaProducto
            IMPRIMIRREPORTE(REP, DT, 1, "")
            'MsgBox("SALE UNA")
        Next


        'MOSTRARREPORTE(REP, "Etiquetas Price Market" + LBLNOM.Text, DT, "")
    End Sub
    Private Sub ImprimirPedimento(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Dim REP As New rptEtiquetaPedimento

        Dim QUERY As String
        Dim DT As New DataTable
        Dim DTTEMP As New DataTable
        Dim A, H, I, J As String
        A = "Exportador:" + TA.Text
        A += " Importador:" + TB.Text
        A += " Direccion:" + TC.Text
        A += " Origen del producto:" + TD.Text
        A += " Ingredientes:" + TE.Text
        A += " Sugerencia de Uso:" + TF.Text
        A += " Modo de Preparacion:" + TG.Text
        H = "Informacióon Nutrimental: " + TH.Text
        I = TI.Text
        J = "Pedimento: " + TJ.Text
        QUERY = "SELECT CLAVE,NOMBRECORTO,A='" + A + "',H='Información Nutrimental: " + TH.Text + "',I='" + TI.Text + "',J='" + TJ.Text + "',CODIGO='' FROM PRODUCTOS WHERE CLAVE='" + TXTCLA.Text + "'"


        e.Graphics.DrawImage(PBIMG.Image, 10, 5)
        'e.Graphics.DrawImage(PBCB.Image, 250, 60)
        Dim NP, NP1, NP2, NP3, NP4, NP5, NP6, NP7, NP8, NP9, NP10, DP, DP1, DP2 As String
        NP = A
        NP1 = ""
        NP2 = ""
        NP3 = ""
        NP4 = ""
        NP5 = ""
        NP6 = ""
        NP7 = ""
        NP8 = ""
        NP9 = ""
        NP10 = ""
        DP = H
        DP1 = I
        DP2 = J
        If NP.Length >= 37 Then
            NP1 = NP.Substring(0, 37)
            If NP.Length >= 37 Then
                NP2 = NP.Substring(37, 37)
                If NP.Length >= 111 Then
                    NP3 = NP.Substring(74, 37)
                    If NP.Length >= 148 Then
                        NP4 = NP.Substring(111, 37)
                        If NP.Length >= 185 Then
                            NP5 = NP.Substring(148, 37)
                            If NP.Length >= 222 Then
                                NP6 = NP.Substring(185, 37)
                                If NP.Length >= 259 Then
                                    NP7 = NP.Substring(222, 37)
                                    If NP.Length >= 296 Then
                                        NP8 = NP.Substring(259, 37)
                                        If NP.Length >= 333 Then
                                            NP9 = NP.Substring(296, 37)
                                            If NP.Length >= 370 Then
                                                NP10 = NP.Substring(333, 37)
                                            Else
                                                NP10 = NP.Substring(333, NP.Length - 333)
                                            End If
                                        Else
                                            NP9 = NP.Substring(296, NP.Length - 296)
                                        End If
                                    Else
                                        NP8 = NP.Substring(259, NP.Length - 259)
                                    End If
                                Else
                                    NP7 = NP.Substring(222, NP.Length - 222)
                                End If
                            Else
                                NP6 = NP.Substring(185, NP.Length - 185)
                            End If
                        Else
                            NP5 = NP.Substring(148, NP.Length - 148)
                        End If
                    Else
                        NP4 = NP.Substring(111, NP.Length - 111)
                    End If
                Else
                    NP3 = NP.Substring(74, NP.Length - 74)
                End If
            Else
                NP2 = NP.Substring(37, NP.Length - 37)
            End If
        Else
            NP1 = NP
        End If
        'If DP.Length >= 37 Then
        '    DP1 = DP.Substring(0, 37)
        '    If DP.Length >= 74 Then
        '        DP2 = DP.Substring(37, 74)
        '    Else
        '        DP2 = DP.Substring(37, NP.Length - 37)
        '    End If
        'Else
        '    DP1 = DP
        'End If
        LBLA.Text = NP1
        LBLB.Text = NP2
        LBLC.Text = NP3
        'e.Graphics.DrawImage(IMG, 0, 0, 0, 0)
        Dim F1 As Font = New Drawing.Font("Arial Black", 12, FontStyle.Bold)
        Dim F2 As Font = New Drawing.Font("Arial", 9, FontStyle.Bold)
        Dim F3 As Font = New Drawing.Font("Arial", 16, FontStyle.Bold)
        Dim F4 As Font = New Drawing.Font("Arial", 8)
        Dim F5 As Font = New Drawing.Font("Arial Black", 10)
        Dim F6 As Font = New Drawing.Font("Arial Black", 8, FontStyle.Italic)
        Dim F7 As Font = New Drawing.Font("Arial", 10)
        Dim F8 As Font = New Drawing.Font("Arial", 14)
        Dim F9 As Font = New Drawing.Font("Arial", 14)
        e.Graphics.DrawString("PRICE MARKET", F1, Brushes.Black, 85, 5)
        e.Graphics.DrawString(LBLNOM.Text, F2, Brushes.Black, 10, 25)
        e.Graphics.DrawString(NP1, F4, Brushes.Black, 10, 40)
        e.Graphics.DrawString(NP2, F4, Brushes.Black, 10, 52)
        e.Graphics.DrawString(NP3, F4, Brushes.Black, 10, 64)
        e.Graphics.DrawString(NP4, F4, Brushes.Black, 10, 76)
        e.Graphics.DrawString(NP5, F4, Brushes.Black, 10, 88)
        e.Graphics.DrawString(NP6, F4, Brushes.Black, 10, 100)
        e.Graphics.DrawString(NP7, F4, Brushes.Black, 10, 112)
        e.Graphics.DrawString(NP8, F4, Brushes.Black, 10, 124)
        e.Graphics.DrawString(NP9, F4, Brushes.Black, 10, 136)
        e.Graphics.DrawString(NP10, F4, Brushes.Black, 10, 148)
        e.Graphics.DrawString(DP, F4, Brushes.Black, 10, 155)
        e.Graphics.DrawString(DP1, F4, Brushes.Black, 10, 170)
        e.Graphics.DrawString(DP2, F4, Brushes.Black, 10, 180)
        '       e.Graphics.DrawString("CONSERVAR EN UN LUGAR FRESCO Y SECO", F6, Brushes.Black, 10, 140)
 
        'e.Graphics.DrawString("CANTIDAD", F2, Brushes.Black, 100, 125)
        'e.Graphics.DrawString("CANTIDAD", F2, Brushes.Black, 100, 125)
        'e.Graphics.DrawString("CANTIDAD", F2, Brushes.Black, 100, 125)
        'e.Graphics.DrawString("CANTIDAD", F2, Brushes.Black, 100, 125)
        'e.Graphics.DrawString("CANTIDAD", F2, Brushes.Black, 100, 125)
        'e.Graphics.DrawString("CANTIDAD", F2, Brushes.Black, 100, 125)

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim VSI As New frmSeleccionarImpresora
        VSI.ShowDialog()
        If VSI.DialogResult = Windows.Forms.DialogResult.Yes Then
            IMPSEL = VSI.NIMPRESORA
            IMPDEF = VSI.IMPRESORADEFAULT
        Else
            Exit Sub
        End If

        Try
            SetDefPrinter(IMPSEL)
        Catch ex As Exception

        End Try

        Dim DT As New DataTable
        Dim DTTEMP As New DataTable
        Dim A, H, I, J As String
        A = ""
        H = ""
        I = ""
        J = ""
        If CHK1.Checked Then
            If Not String.IsNullOrEmpty(TF.Text) Then
                A += "Descripción:" + TF.Text
            End If

        End If
        If CHK5.Checked Then
            If Not String.IsNullOrEmpty(TE.Text) Then
                A += ". Ingredientes:" + TE.Text
            End If
        End If
        If CHK8.Checked Then
            If Not String.IsNullOrEmpty(TH.Text) Then
                A += ". Información Nutrimental: " + TH.Text
            End If

        End If
        If CHK11.Checked Then
            If Not String.IsNullOrEmpty(TK.Text) Then
                A += ". #Lote:" + TK.Text
            End If

        End If
        If CHK15.Checked Then
            If Not String.IsNullOrEmpty(DTFCAD.Text) Then
                A += ". Fecha Caducidad:" + DTFCAD.Text
            End If

        End If
        If CHK4.Checked Then
            If Not String.IsNullOrEmpty(TD.Text) Then
                A += ". Origen:" + TD.Text
            End If

        End If
        If CHK9.Checked Then
            If Not String.IsNullOrEmpty(TXTEP.Text) Then
                A += ". Empacado por:" + TXTEP.Text
            End If

        End If



        If CHK11.Checked Then
            A += TI.Text
        End If
        If CHK14.Checked Then
            J = "$" + LBLPRE.Text
        End If

        Dim QUERY As String
        QUERY = "SELECT NOMBRECORTO,DESCRIPCION,PM,FECHA=@INI,HORA=@FIN,CANTIDAD=1.00,A='" + A + "',B='',C='',D='',E='',F='',G='',H='" + H + "',I='" + I + "',J='" + J + "',CONVERT(IMAGE,'')CODIGO FROM PRODUCTOS WHERE CLAVE='" + TXTCLA.Text + "'"


        DTTEMP = New DataTable
        DT = New DataTable
        DT = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value, DTHASTA.Value)
        DTTEMP = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value, DTHASTA.Value)

        DT.Rows.Clear()

        'DT.Columns.RemoveAt(6)
        'DT.Columns.Add("CODIGO", GetType(Byte()))
        'Dim NETI As Integer
        'NETI = CType(TXTETI.Text, Integer)
        Dim X As Integer
        Dim DR As DataRow
        'Dim IMG As Image
        For X = 0 To DTTEMP.Rows.Count - 1
            DR = DT.NewRow
            DR(0) = DTTEMP.Rows(X).Item(0)
            DR(1) = DTTEMP.Rows(X).Item(1)
            DR(2) = DTTEMP.Rows(X).Item(2)
            DR(3) = DTTEMP.Rows(X).Item(3)
            DR(4) = DTTEMP.Rows(X).Item(4)
            DR(5) = DTTEMP.Rows(X).Item(5)
            DR(6) = DTTEMP.Rows(X).Item(6)
            DR(7) = DTTEMP.Rows(X).Item(7)
            DR(8) = DTTEMP.Rows(X).Item(8)
            DR(9) = DTTEMP.Rows(X).Item(9)
            DR(10) = DTTEMP.Rows(X).Item(10)
            DR(11) = DTTEMP.Rows(X).Item(11)
            DR(12) = DTTEMP.Rows(X).Item(12)
            DR(13) = DTTEMP.Rows(X).Item(13)
            DR(14) = DTTEMP.Rows(X).Item(14)
            DR(15) = DTTEMP.Rows(X).Item(15)

            'If TXTCLA.Text.Length = 12 Then
            '    IMG = BarCode.CodeEAN13AutoGenerateChecksum(DTTEMP.Rows(X).Item(0), True, 100, True, True)
            'Else
            '    IMG = BarCode.CodeEAN13(DTTEMP.Rows(X).Item(0), True, 100, True, True)
            'End If

            'IMG.RotateFlip(RotateFlipType.Rotate90FlipX)
            DR(16) = Image2Bytes(PBCB.Image)
            DT.Rows.Add(DR)
        Next

        Dim REP As New rptEtiquetaProducto
        MOSTRARREPORTE(REP, "Etiquetas", DT, "")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        'Dim NuevaImpresionZPL As New clsImpresionZPL
        'NuevaImpresionZPL.Impresion("Etiquetas PM", "Narciso", "Cisneros", "PM", "1234567890123", "01/01/2015")

        'Dim X As Integer 
        'For X = 1 To 3
        'PrintDocument1.Print()
        '    MessageBox.Show("Continuar")
        'Next

        Dim oPrintDoc As PrintDocument = New PrintDocument()
        AddHandler oPrintDoc.PrintPage, AddressOf ImprimirGrafico
        'Dim X As Integer
        'For X = 1 To 3
        '    oPrintDoc.Print()
        'Next
        oPrintDoc.Print()

    End Sub
    Private Sub ImprimirGrafico(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        ' recuperar la imagen del PictureBox
        'Dim IMG As Image
        'IMG = BarCode.CodeEAN13("1234567890123", True, 90, True, True)
        'IMG.RotateFlip(RotateFlipType.Rotate270FlipX)
        '' pintamos la imagen en el dispositivo que la mostrará,
        '' en este caso la impresora
        '' Para imprimir texto
        'PBCB.Image=IMG 
        'Dim Texto As String = "Texto a imprimir" 'Puedes asignar la propiedad Text de un TextBox
        'Dim Fuente As New Font("Arial", 12, FontStyle.Bold)
        'Dim Color As Brush = New SolidBrush(Drawing.Color.Black)
        'Dim Lugar As New PointF(10, 10)
        'Dim drawFormat As New System.Drawing.StringFormat

        'e.Graphics.DrawString(Texto, Fuente, Color, Lugar, drawFormat)

        ' Para imprimir imágenes

        e.Graphics.DrawImage(PBIMG.Image, 10, 10)
        e.Graphics.DrawImage(PBCB.Image, 250, 30)
        Dim NP, NP1, NP2, NP3, DP, DP1, DP2 As String
        NP = LBLNOM.Text
        NP1 = ""
        NP2 = ""
        NP3 = ""
        DP = LBLDES.Text
        DP1 = ""
        DP2 = ""
        If NP.Length >= 19 Then
            NP1 = NP.Substring(0, 19)
            If NP.Length >= 38 Then
                NP2 = NP.Substring(19, 19)
                If NP.Length > 57 Then
                    NP3 = NP.Substring(38, 19)
                Else
                    NP3 = NP.Substring(38, NP.Length - 38)
                End If
            Else
                NP2 = NP.Substring(19, NP.Length - 19)
            End If
        Else
            NP1 = NP
        End If
        If DP.Length >= 37 Then
            DP1 = DP.Substring(0, 37)
            If DP.Length >= 74 Then
                DP2 = DP.Substring(37, 74)
            Else
                DP2 = DP.Substring(37, NP.Length - 37)
            End If
        Else
            DP1 = DP
        End If
        LBLA.Text = NP1
        LBLB.Text = NP2
        LBLC.Text = NP3
        'e.Graphics.DrawImage(IMG, 0, 0, 0, 0)
        Dim F1 As Font = New Drawing.Font("Arial Black", 12, FontStyle.Bold)
        Dim F2 As Font = New Drawing.Font("Arial", 9, FontStyle.Bold)
        Dim F3 As Font = New Drawing.Font("Arial", 16, FontStyle.Bold)
        Dim F4 As Font = New Drawing.Font("Arial", 7)
        Dim F5 As Font = New Drawing.Font("Arial Black", 10)
        Dim F6 As Font = New Drawing.Font("Arial Black", 8, FontStyle.Italic)
        Dim F7 As Font = New Drawing.Font("Arial", 10)
        Dim F8 As Font = New Drawing.Font("Arial", 14)
        Dim F9 As Font = New Drawing.Font("Arial", 14)
        e.Graphics.DrawString("PRICE MARKET", F1, Brushes.Black, 85, 3)
        e.Graphics.DrawString(NP1, F2, Brushes.Black, 80, 40)
        e.Graphics.DrawString(NP2, F2, Brushes.Black, 80, 55)
        e.Graphics.DrawString(NP3, F2, Brushes.Black, 100, 70)
        e.Graphics.DrawString("CANT.", F5, Brushes.Black, 10, 38)
        e.Graphics.DrawString("1.00", F5, Brushes.Black, 10, 52)
        e.Graphics.DrawString("$" + LBLPRE.Text, F3, Brushes.Black, 10, 65)
        e.Graphics.DrawString(DP1, F4, Brushes.Black, 10, 100)
        e.Graphics.DrawString(DP2, F4, Brushes.Black, 10, 112)
        e.Graphics.DrawString("CONSERVAR EN UN LUGAR FRESCO Y SECO", F6, Brushes.Black, 10, 140)
        If CHKFEC.Checked Then
            e.Graphics.DrawString(DTDE.Text, F7, Brushes.Black, 50, 160)
            e.Graphics.DrawString(DTHASTA.Text, F7, Brushes.Black, 140, 160)
        Else
            e.Graphics.DrawString("", F7, Brushes.Black, 50, 160)
            e.Graphics.DrawString("", F7, Brushes.Black, 140, 160)
        End If



        'e.Graphics.DrawString("CANTIDAD", F2, Brushes.Black, 100, 125)
        'e.Graphics.DrawString("CANTIDAD", F2, Brushes.Black, 100, 125)
        'e.Graphics.DrawString("CANTIDAD", F2, Brushes.Black, 100, 125)
        'e.Graphics.DrawString("CANTIDAD", F2, Brushes.Black, 100, 125)
        'e.Graphics.DrawString("CANTIDAD", F2, Brushes.Black, 100, 125)
        'e.Graphics.DrawString("CANTIDAD", F2, Brushes.Black, 100, 125)

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        
        Dim F1 As Font = New Drawing.Font("Arial", 12, FontStyle.Bold)

        e.Graphics.DrawRectangle(Pens.Black, e.Graphics.VisibleClipBounds.X, e.Graphics.VisibleClipBounds.Y, e.Graphics.VisibleClipBounds.Width, e.Graphics.VisibleClipBounds.Height)
        e.Graphics.DrawString("VisibleClipBounds:" + e.Graphics.VisibleClipBounds.ToString(), Me.Font, Brushes.Black, e.Graphics.VisibleClipBounds.X, e.Graphics.VisibleClipBounds.Y)

        'Dim F2 As Font = New Drawing.Font("Arial", 9, FontStyle.Bold)
        'Dim F3 As Font = New Drawing.Font("Arial", 16)
        'Dim F4 As Font = New Drawing.Font("Arial", 7)
        'Dim F5 As Font = New Drawing.Font("Arial", 8)
        'Dim F6 As Font = New Drawing.Font("Arial", 8, FontStyle.Bold)
        'Dim F7 As Font = New Drawing.Font("Arial", 14)
        'Dim F8 As Font = New Drawing.Font("Arial", 14)
        'Dim F9 As Font = New Drawing.Font("Arial", 14)
        'Dim PS As New PaperSize
        'PS.Height = 197
        'PS.Width = 300
        'Dim PB As New PageSettings
        'PB.PaperSize.Height = 197
        'PB.PaperSize.Width = 300
        'Dim PPSS As New PageSettings
        'PPSS.PaperSize = PS
        'e.PageSettings.PaperSize.Height = 197
        'e.PageSettings.PaperSize.Width = 300
        'e.PageSettings.Margins.Top = 10
        'e.PageSettings.Margins.Bottom = 10

        'e.PageBounds.Height = 197


        'e.Graphics.DrawString("PRICE MARKET", F1, Brushes.Chocolate, 10, 1)
        'e.Graphics.DrawString("PRODUCTO", F2, Brushes.Chocolate, 10, 15)
        'e.Graphics.DrawString("1.00", F3, Brushes.Chocolate, 10, 25)
        'e.Graphics.DrawString("DESCRIPCION CORTA DEL PRODUCTO", F2, Brushes.Chocolate, 50, 25)
        'e.Graphics.DrawString("CONSERVAR EN UN LUGAR FRESCO Y SECO", F2, Brushes.Chocolate, 10, 50)
        'e.Graphics.DrawString("18/05/2015", F2, Brushes.Chocolate, 10, 80)
        'e.Graphics.DrawString("10:16:00 PM", F2, Brushes.Chocolate, 100, 100)
        'e.Graphics.DrawString("CANTIDAD1", F2, Brushes.Chocolate, 10, 110)
        'e.Graphics.DrawString("CANTIDAD2", F2, Brushes.Chocolate, 10, 120)
        'e.Graphics.DrawString("CANTIDAD3", F2, Brushes.Chocolate, 10, 130)
        'e.Graphics.DrawString("CANTIDAD4", F2, Brushes.Chocolate, 10, 140)
        'e.Graphics.DrawString("CANTIDAD5", F2, Brushes.Chocolate, 10, 150)
        'e.Graphics.DrawString("CANTIDAD6", F2, Brushes.Chocolate, 10, 160)

    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        GUARDARPED()
    End Sub
    Private Sub GUARDARPED()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SPPRODUCTOPEDIMENTO", frmPrincipal.CONX)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.Parameters.Add("@CLA", SqlDbType.VarChar).Value = TXTCLA.Text
        SQL.Parameters.Add("@EXP", SqlDbType.VarChar).Value = TB.Text
        SQL.Parameters.Add("@IMP", SqlDbType.VarChar).Value = TA.Text
        SQL.Parameters.Add("@DIR", SqlDbType.VarChar).Value = TC.Text
        SQL.Parameters.Add("@ORI", SqlDbType.VarChar).Value = TD.Text
        SQL.Parameters.Add("@ING", SqlDbType.VarChar).Value = TE.Text
        SQL.Parameters.Add("@SUG", SqlDbType.VarChar).Value = TF.Text
        SQL.Parameters.Add("@PRE", SqlDbType.VarChar).Value = TG.Text
        SQL.Parameters.Add("@INF", SqlDbType.VarChar).Value = TH.Text
        SQL.Parameters.Add("@IMPR", SqlDbType.VarChar).Value = TI.Text
        SQL.Parameters.Add("@PED", SqlDbType.VarChar).Value = TJ.Text
        SQL.Parameters.Add("@LOTE", SqlDbType.VarChar).Value = TK.Text
        SQL.Parameters.Add("@FECCAD", SqlDbType.DateTime).Value = DTFCAD.Value.Date
        SQL.ExecuteNonQuery()
        MessageBox.Show("Pedimento Guardado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub
    Dim CLAGRU As String
    Private Sub CARGADATOS()
    
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT P.CLAVE CLAVE,P.NOMBRECORTO,P.DESCRIPCION,G.NOMBRE GRUPO,P.PRECIO,P.ACTIVO,G.CLAVE FROM PRODUCTOS P INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE P.EMPRESA=" + frmPrincipal.Empresa + "  AND P.ACTIVO=1 AND P.CLAVE='" + TXTCLA.Text + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            TXTCLA.Text = LEC(0).ToString
            LBLNOM.Text = LEC(1).ToString
            LBLDES.Text = LEC(2).ToString
            LBLPRE.Text = LEC(4).ToString
            CLAGRU = LEC(5).ToString
        End If
        LEC.Close()
        SQL.Dispose()
        Try

            If TXTCLA.Text.Length >= 12 And TXTCLA.Text.Length <= 13 Then
                Dim myCallback As New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
                Dim IMG, IMGTEM As Image
                If TXTCLA.Text.Length = 12 Then
                    IMG = BarCode.CodeEAN13AutoGenerateChecksum(TXTCLA.Text, CHKCC.Checked, 25, True, True)
                End If
                If TXTCLA.Text.Length = 13 Then
                    IMG = BarCode.CodeEAN13(TXTCLA.Text, CHKCC.Checked, 25, False, True)
                End If

                IMG.RotateFlip(RotateFlipType.Rotate90FlipXY)
                IMGTEM = IMG.GetThumbnailImage(30, 158, myCallback, IntPtr.Zero)
                ' pintamos la imagen en el dispositivo que la mostrará,
                ' en este caso la impresora
                ' Para imprimir texto
                PBCB.Image = IMG
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub TXTCLA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLA.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTCLA.Text = "" Then
            Else
                'If Not CHECAPROD() Then
                '    If Not CHECAPROD2() Then
                '        Exit Sub
                '    End If
                'End If

                CARGADATOS()
            End If
        End If
    End Sub

    Private Function CHECAPROD() As Boolean
        If Not frmPrincipal.CHECACONX() Then
            Return False
        End If

        Dim GRU As Integer
        Dim query As String
        query = "SELECT P.NOMBRE,P." + frmPrincipal.SucursalBase + ",P.IMG,P.GRUPO,P.CP FROM PRODUCTOS P WHERE P.CLAVE= '" + TXTCLA.Text + "' AND EMPRESA=" + frmPrincipal.Empresa + " AND ACTIVO=1 AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1)"
        Dim SQLCARGAPROD As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        Try
            LECTOR = SQLCARGAPROD.ExecuteReader
            If LECTOR.Read() Then
                LECTOR.Close()
                Return True
            Else
                LECTOR.Close()
                'MessageBox.Show("El codigo del producto NO existe en el sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'TXTCOD.Text = ""
                'TXTCOD.Focus()
                LECTOR.Close()
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function CHECAPROD2() As Boolean
        If Not frmPrincipal.CHECACONX() Then
            Return False
        End If
        Dim CB, COD, PES As String
        Dim CANT As Double
        CB = TXTCLA.Text
        Try
            COD = CB.Substring(0, 12)
            TXTCLA.Text = COD
        Catch ex As Exception

        End Try
        Dim GRU As Integer
        Dim query As String
        query = "SELECT P.NOMBRE,P." + frmPrincipal.SucursalBase + ",P.IMG,P.GRUPO,P.CP FROM PRODUCTOS P WHERE P.CLAVE= '" + TXTCLA.Text + "' AND EMPRESA=" + frmPrincipal.Empresa + " AND ACTIVO=1 AND P.CLAVE IN (SELECT PRODUCTO FROM PRODUCTOSTIENDAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ACTIVO=1)"
        Dim SQLCARGAPROD As New SqlClient.SqlCommand(query, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        Try
            LECTOR = SQLCARGAPROD.ExecuteReader
            If LECTOR.Read() Then
                Return True
                LECTOR.Close()
                'If INV = True Then
            Else
                LECTOR.Close()
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim VSI As New frmSeleccionarImpresora
        VSI.ShowDialog()
        If VSI.DialogResult = Windows.Forms.DialogResult.Yes Then
            IMPSEL = VSI.NIMPRESORA
            IMPDEF = VSI.IMPRESORADEFAULT
        Else
            Exit Sub
        End If

        Try
            SetDefPrinter(IMPSEL)
        Catch ex As Exception

        End Try

        Dim NETI As Integer
        NETI = CType(TXTETI.Text, Integer)
        Dim EtiPedimento As PrintDocument = New PrintDocument()
        AddHandler EtiPedimento.PrintPage, AddressOf ImprimirFinal
        Dim X As Integer
        For X = 1 To NETI
            EtiPedimento.Print()
        Next
        Try
            SetDefPrinter(IMPDEF)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ImprimirFinal(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        Dim QUERY As String
        Dim DT As New DataTable
        Dim DTTEMP As New DataTable
        Dim A, H, I, J As String
        A = ""
        H = ""
        I = ""
        J = ""
        If CHK1.Checked Then
            A += "Descripción:" + TF.Text
        End If
        If CHK5.Checked Then
            A += ". Ingredientes:" + TE.Text
        End If
        A += ". Información Nutrimental: Calorias " + TXTINA.Text + " Grasas " + TXTINB.Text + " Colesterol " + TXTINC.Text + " Sodio " + TXTIND.Text + " Carb. " + TXTINE.Text + " Proteinas " + TXTINF.Text + ""

        If CHK8.Checked Then
            A += ". Información Nutrimental: " + TH.Text
        End If
        If CHK11.Checked Then
            A += ". #Lote:" + TK.Text
        End If
        If CHK15.Checked Then
            A += ". Fecha Caducidad:" + DTFCAD.Text
        End If
        If CHK4.Checked Then
            A += ". Origen:" + TD.Text
        End If
        If CHK9.Checked Then
            A += ". Empacado por:" + TXTEP.Text
        End If


   
        If CHK11.Checked Then
            A += TI.Text
        End If
        If CHK14.Checked Then
            J = "$" + LBLPRE.Text
        End If


        'NP1 = "Descripción:" + TF.Text
        'NP2 = " Importador:" + TA.Text
        ''NP2 = ""
        'NP3 = " #Lote:" + TK.Text
        'NP4 = " Fecha Caducidad:" + DTFCAD.Text
        'NP5 = " Pedimento:" + TJ.Text
        'NP6 = " Origen:" + TD.Text
        'NP7 = " Ingredientes:" + TE.Text

        e.Graphics.DrawImage(PBIMG.Image, 10, 5)
        If CHKCB.Checked Then
            e.Graphics.DrawImage(PBCB.Image, 270, 60)
        End If

        'e.Graphics.DrawImage(PBCB.Image, 250, 60)
        Dim NP, NP1, NP2, NP3, NP4, NP5, NP6, NP7, NP8, NP9, NP10, NP11, DP, DP1, DP2, DP3, DP4 As String
        NP = A
        NP1 = ""
        NP2 = ""
        NP3 = ""
        NP4 = ""
        NP5 = ""
        NP6 = ""
        NP7 = ""
        NP8 = ""
        NP9 = ""
        NP10 = ""
        NP11 = ""
        DP = ""
        DP1 = ""
        DP2 = ""
        DP3 = ""
        If CHK3.Checked Then
            DP += "Dirección:" + TC.Text + " "
        End If
        If CHK1.Checked Then
            DP += "Importador:" + TA.Text + " "
        End If
        If CHK10.Checked Then
            DP += "Pedimento:" + TJ.Text
        End If
        'DP1 = I
        DP4 = J
        Dim NC As Integer
        NC = 42
        If NP.Length >= NC Then
            NP1 = NP.Substring(0 * NC, NC)
            If NP.Length >= (2 * NC) Then
                NP2 = NP.Substring(1 * NC, NC)
                If NP.Length >= (3 * NC) Then
                    NP3 = NP.Substring(2 * NC, NC)
                    If NP.Length >= (4 * NC) Then
                        NP4 = NP.Substring(3 * NC, NC)
                        If NP.Length >= (5 * NC) Then
                            NP5 = NP.Substring(4 * NC, NC)
                            If NP.Length >= (6 * NC) Then
                                NP6 = NP.Substring(5 * NC, NC)
                                If NP.Length >= (7 * NC) Then
                                    NP7 = NP.Substring(6 * NC, NC)
                                    If NP.Length >= (8 * NC) Then
                                        NP8 = NP.Substring(7 * NC, NC)
                                        If NP.Length >= (9 * NC) Then
                                            NP9 = NP.Substring(8 * NC, NC)
                                            If NP.Length >= (10 * NC) Then
                                                NP10 = NP.Substring(9 * NC, NC)
                                                If NP.Length >= (11 * NC) Then
                                                    NP11 = NP.Substring(10 * NC, NC)
                                                Else
                                                    NP11 = NP.Substring(10 * NC, NP.Length - (10 * NC))
                                                End If
                                            Else
                                                NP10 = NP.Substring(9 * NC, NP.Length - (9 * NC))
                                            End If
                                        Else
                                            NP9 = NP.Substring(8 * NC, NP.Length - (8 * NC))
                                        End If
                                    Else
                                        NP8 = NP.Substring(7 * NC, NP.Length - (7 * NC))
                                    End If
                                Else
                                    NP7 = NP.Substring(6 * NC, NP.Length - (6 * NC))
                                End If
                            Else
                                NP6 = NP.Substring(5 * NC, NP.Length - (5 * NC))
                            End If
                        Else
                            NP5 = NP.Substring(4 * NC, NP.Length - (4 * NC))
                        End If
                    Else
                        NP4 = NP.Substring(3 * NC, NP.Length - (3 * NC))
                    End If
                Else
                    NP3 = NP.Substring(2 * NC, NP.Length - (2 * NC))
                End If
            Else
                NP2 = NP.Substring(NC, NP.Length - NC)
            End If
        Else
            NP1 = NP
        End If
        If DP.Length >= 33 Then
            DP1 = DP.Substring(0, 33)
            If DP.Length >= 66 Then
                DP2 = DP.Substring(33, 33)
                If DP.Length >= 99 Then
                    DP3 = DP.Substring(66, 33)
                Else
                    DP3 = DP.Substring(66, DP.Length - 66)
                End If
            Else
                DP2 = DP.Substring(33, DP.Length - 33)
            End If
        Else
            DP1 = DP
        End If
        'LBLA.Text = NP1
        'LBLB.Text = NP2
        'LBLC.Text = NP3


        'NP1 = "Descripción:" + TF.Text
        'NP2 = " Importador:" + TA.Text
        ''NP2 = ""
        'NP3 = " #Lote:" + TK.Text
        'NP4 = " Fecha Caducidad:" + DTFCAD.Text
        'NP5 = " Pedimento:" + TJ.Text
        'NP6 = " Origen:" + TD.Text
        'NP7 = " Ingredientes:" + TE.Text
        'H = "Información Nutrimental: " + TH.Text
        'I = TI.Text
        'J = "$" + LBLPRE.Text

        'e.Graphics.DrawImage(IMG, 0, 0, 0, 0)
        Dim F1 As Font = New Drawing.Font("Arial Black", 12, FontStyle.Bold)
        Dim F2 As Font = New Drawing.Font("Arial", 9, FontStyle.Bold)
        Dim F3 As Font = New Drawing.Font("Arial", 16, FontStyle.Bold)
        Dim F4 As Font = New Drawing.Font("Arial", 8)
        Dim F5 As Font = New Drawing.Font("Arial Black", 10)
        Dim F6 As Font = New Drawing.Font("Arial Black", 8, FontStyle.Italic)
        Dim F7 As Font = New Drawing.Font("Arial", 10)
        Dim F8 As Font = New Drawing.Font("Arial", 14)
        Dim F9 As Font = New Drawing.Font("Arial", 14)
        e.Graphics.DrawString("PRICE MARKET", F1, Brushes.Black, 85, 5)

        If CHKIPI.Checked Then
            e.Graphics.DrawString("Presentacion Institucional", F4, Brushes.Black, 85, 25)
        End If

        e.Graphics.DrawString(LBLNOM.Text, F5, Brushes.Black, 10, 35)
        e.Graphics.DrawString(NP1, F4, Brushes.Black, 10, 50)
        e.Graphics.DrawString(NP2, F4, Brushes.Black, 10, 60)
        e.Graphics.DrawString(NP3, F4, Brushes.Black, 10, 70)
        e.Graphics.DrawString(NP4, F4, Brushes.Black, 10, 80)
        e.Graphics.DrawString(NP5, F4, Brushes.Black, 10, 90)
        e.Graphics.DrawString(NP6, F4, Brushes.Black, 10, 100)
        e.Graphics.DrawString(NP7, F4, Brushes.Black, 10, 110)
        e.Graphics.DrawString(NP8, F4, Brushes.Black, 10, 120)
        e.Graphics.DrawString(NP9, F4, Brushes.Black, 10, 130)
        e.Graphics.DrawString(NP10, F4, Brushes.Black, 10, 140)
        e.Graphics.DrawString(NP11, F4, Brushes.Black, 10, 150)
        'e.Graphics.DrawString(DP, F4, Brushes.Black, 10, 155)
        e.Graphics.DrawString(DP1, F4, Brushes.Black, 10, 155)
        e.Graphics.DrawString(DP2, F4, Brushes.Black, 10, 165)
        e.Graphics.DrawString(DP3, F4, Brushes.Black, 10, 175)
        e.Graphics.DrawString(DP4, F3, Brushes.Black, 200, 160)
        '       e.Graphics.DrawString("CONSERVAR EN UN LUGAR FRESCO Y SECO", F6, Brushes.Black, 10, 140)
    End Sub
End Class