Imports System.Drawing.Printing

Public Class frmPrincipal
    Public NumCajas As Integer
    Public CONX As New SqlClient.SqlConnection
    Public CONXFE As New SqlClient.SqlConnection
    Public CadenaConexion, CadenaConexionFE As String
    Public SucursalBase As String
    Public Regimen As String
    Public Serie As String
    Public NivelBase, Tipo As Integer
    Public NombreSucursal As String
    Public Empresa As String
    Public NombreComun As String
    Public Usuario As String
    Public Ciudad As String
    Public PromocionActiva As Boolean
    Public PagoTarjeta As Boolean
    Public Ajuste As Boolean
    Public CorteXX As Boolean
    Public RIFA, RIFA2 As Boolean
    Public LCopias As New List(Of Integer)
    Dim FrmsHijos(25) As System.Windows.Forms.Form
    Dim VERSION As String
    Dim LIGA As String
    Public IP As String
    Public IPFE As String
    Public BancoCuenta As String
    Public DTRIFA As New DataTable
    Public LTIC As New List(Of String)
    Public CI As New clsImprimir
    Public PRE As New clsPreNota
    Dim RES As Boolean
    Public IVA As Double
    Public VCFD As String
    Public CA As New clsActualizacion
    Public Sistema, EmisorBase As String
    Public AplicaBodega As Boolean
    Public Direccion As String
    Dim LM As New List(Of ToolStripMenuItem)
    Dim LSM As New List(Of ToolStripMenuItem)
    Dim LSSM As New List(Of ToolStripMenuItem)
    Public Perfil As Integer
    Public FacturaLibre As Boolean
    Public Resguardo As Boolean
    Public VentaSinResguardo As Integer
    Public Corporativo As String
    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Ciudad = "Cd. Juárez, Chih."
        VERSION = "BETA"
        'VERSION = "3.20"
        VCFD = "4.0"
        Corporativo = "2"
        FacturaLibre = True
        Resguardo = False
        VentaSinResguardo = 0
        EmisorBase = "GATF9701109J2"
        Regimen = "Persona Física con Actividades Empresariales y Profesionales"
        'IP = "201.120.24.238"
        'IP = "187.141.151.178"
        IP = "soluserver.ddns.net"
        'IPFE = "187.141.151.178"
        IPFE = "soluserver.ddns.net"
        'If PRUEBAPING("BAHAMUT", "Ip Local", False) Then
        '    IP = "192.168.2.75"
        '    IPFE = "192.168.2.75"
        'End If
        Sistema = "Comercializadora GT"
        'PBCNC.Image = ComercializadoraGT.My.Resources.Resources.price_market_buda
        IVA = 0.16
        SB.Items(0).Text = Ciudad + " Hoy es " + FormatDateTime(Now, DateFormat.LongDate) + " "
        'CadenaConexion = "Data Source=MINIME-PC;Initial Catalog=POSCAVA;Integrated Security=True"
        'CadenaConexion = "Data Source=IVAN-PC;Initial Catalog=PMADV;Integrated Security=True"
        CadenaConexion = "Data Source=" + IP + ",1433;Network Library=DBMSSOCN;Initial Catalog=PVGZ;User ID=dbaadmin;Password=Xoporte1234."
        CadenaConexionFE = "Data Source=" + IPFE + ",1433;Network Library=DBMSSOCN;Initial Catalog=FEMITAS;User ID=dbaadmin;Password=Xoporte1234."
        CONX.ConnectionString = CadenaConexion
        CONXFE.ConnectionString = CadenaConexionFE
        'Dim CCL As New num2text
        'OPMsgOK("13409.23  :  " + CCL.Letras("13409.23"))
        'Dim VPRU As New frmPruebaCCL
        'VPRU.ShowDialog()

        Dim A, B As Integer
        Dim LRES As New List(Of String)
        'For A = 1 To 5
        '    For B = 1 To 5
        '        LRES.Add("A=" + A.ToString + "- B=" + B.ToString + "." + (Math.Pow(A, B) + Math.Pow(B, A)).ToString + ". Suma= " + (A + B).ToString)
        '    Next
        'Next
        'For A = 1 To 6
        '    LRES.Add((6 / A).ToString)
        'Next
        'Dim SRES As String
        'SRES = ""
        'For Each VALO As String In LRES
        '    SRES += VALO + Chr(13)
        'Next
        'OPMsgOK(SRES)
        'Dim A, B, C, D, RESP As Integer
        'A = 98
        'B = 100
        'C = 97
        'D = 99

        'For X = 1 To 3
        '    If A > B Then
        '        RESP = A
        '        A = B
        '        B = RESP
        '    End If
        '    If B > C Then
        '        RESP = B
        '        B = C
        '        C = RESP
        '    End If
        '    If C > D Then
        '        RESP = C
        '        C = D
        '        D = RESP
        '    End If
        'Next

        'OPMsgOK(A.ToString + "," + B.ToString + "," + C.ToString + "," + D.ToString)
        If Not CONECTAR("WWW.BAJASUN.COM.MX") Then
            frmAyuda.Show()
            frmCambioIP.ShowDialog()
            If frmCambioIP.DialogResult = Windows.Forms.DialogResult.Yes Then
                If Not CHECACONX() Then
                    Dim VAYU As New frmAyuda
                    VAYU.Show()
                    MessageBox.Show("No se puede Conectar con el servidor, intente en un momento por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Close()
                Else
                    INICIAR()
                End If
            Else
                Me.Close()
            End If
        Else
            INICIAR()

            'Dim REP As New rptSalidaTraspaso
            'Dim QUERY As String
            'QUERY = "SELECT A.NOMBRECOMUN CEDIS,B.NOMBRECOMUN ALMACEN,D.NOTRASPASO NOSALIDA,G.NOMBRE GRUPO,P.NOMBRE PRODUCTO, D.CANTIDAD, U.NOMBRE UNIDAD,DBO.CHECAEXISTENCIA('" + SucursalBase + "',D.PRODUCTO)EXISTENCIA,COSTOPROMEDIO=DBO.COSTOPROM('pm',D.PRODUCTO),TOTAL=DBO.TOTALUNIDADMINIMA2(D.PRODUCTO,D.CANTIDAD,D.UNIDAD)*DBO.COSTOPROM('pm',D.PRODUCTO),D.COSTOPROMEDIO CPGUARDADO,S.USUARIO,RESPONSABLEO='',RESPONSABLED='' FROM DETALLETRASPASOSTIENDAS D INNER JOIN TRASPASOSTIENDAS S ON D.NOTRASPASO=S.NOTRASPASO INNER JOIN TIENDAS A ON S.ORIGEN=A.CLAVE INNER JOIN TIENDAS B ON S.DESTINO=B.CLAVE INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CP INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE D.NOTRASPASO=154"
            'MOSTRARREPORTE(REP, "Salida por Traspaso No. 153", BDLlenatabla(QUERY, CadenaConexion), "")

            'For i As Integer = 0 To PrinterSettings.InstalledPrinters.Count - 1 '' ciclo de todas las impresoras k tengo instalada en la pc
            '    Dim a As New PrinterSettings() ''' variable de propiedades de impresora
            '    a.PrinterName = PrinterSettings.InstalledPrinters(i).ToString() '' la propiedad de impresora PrinterName= a la impresoras instalada en la posicion i
            '    MessageBox.Show(a.PrinterName)
            '    'If a.PrinterName.ToUpper = NOMBREIMPRESORA.ToUpper Then '' si el nombre de la impresora instalada en la posicion i = a la impresora k le mando como parametro
            '    '    Return PrinterSettings.InstalledPrinters(i).ToString() '' nombre de impresora=a la impresora instalada
            '    'End If
            'Next
            'Dim Impresora_Plus As PrinterSettings.

            'For Each Impresora_Plus In Printers
            '    If Impresora_Plus.DeviceName = Trim("ZDesigner TLP 2824 Plus (ZPL)") Then
            '        Printer = Impresora_Plus
            '    End If
        End If

        'Dim punto As System.Drawing.Point
        'punto.X = (Me.Width - PBCNC.Width) / 2
        'punto.Y = (Me.Height - PBCNC.Height) / 2
        'PBCNC.Location = punto
        'Dim VINFOTRAS As New frmTraspasoCartaPorte
        'VINFOTRAS.MOSTRAR("150")

    End Sub
    Private Function EsMultiploDe(ByVal Numero As Integer, ByVal Multiplo As Integer) As Boolean
        If Numero Mod Multiplo Then
            Return True
        End If
        Return False
    End Function
    Public Sub PonerFondo()
        If My.Settings.RutaFondo <> "" Then
            Try
                Me.BackgroundImage = Image.FromFile(My.Settings.RutaFondo)
            Catch ex As Exception

            End Try
        End If
    End Sub
    Dim LPERFIL As New List(Of String)
    Private Sub INICIAR()
        PonerFondo()

        If VERIFICAVERSION() Then
            If Not VERIFICAUBICACION() Then
                Me.Close()
                Exit Sub
            End If
            Dim VSES As New frmLogin
            VSES.ShowDialog()
            If VSES.DialogResult = Windows.Forms.DialogResult.Yes Then
                MessageBox.Show("Bienvenido al sistema punto de venta a la sucursal " + NombreComun, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                If NivelBase >= 5 Then
                    ADMINISTRADOR(True)
                ElseIf NivelBase = 1 Then
                    ADMINISTRADOR(False)
                Else
                    MessageBox.Show("El usuario no tiene permitido ingresar al sistema", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                End If
                'CARGASD(TPV, CHIE)
                'POSICIONAICONOS(TPV)
                'CARGAPROMOCIONES()
                'CAMBIAFONDO()
                'CARGARIFAS()
                'Try
                '    CA.COMPROBAR()
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message)
                'End Try
            Else
                Me.Close()
            End If
        Else
            If Not OPCrearArchivo("C:\", "config.ns", LIGA + "|" + "C:\NUEVAVERSION\POSPM.RAR|Actualización punto de venta Comercializadora GT|D:\") Then
                OPMsgError("Favor de correr el programa como administrador")
                Me.Close()
            Else
                OPMsgError("En este momento no cuentas con la versión mas reciente, favor de utilizar el Actualizador de sistemas")
                Me.Close()
            End If
            'frmLigaVersion.MOSTRAR(LIGA, "C:\NUEVAVERSION\POSPM.RAR", "Actualización punto de venta Comercializadora GT")

        End If
    End Sub
    Private Sub INICIALIZAMENU()
        Dim S23 As New ToolStripMenuItem
        Dim S24 As New ToolStripMenuItem
        Dim S38 As New ToolStripMenuItem
        Dim S5 As New ToolStripMenuItem
        Dim SS6 As New ToolStripMenuItem
        Dim SS7 As New ToolStripMenuItem
        Dim SS8 As New ToolStripMenuItem
        Dim SS9 As New ToolStripMenuItem
        Dim S43 As New ToolStripMenuItem
        LM.Clear()
        LSM.Clear()
        LSSM.Clear()
        LM.Add(MM1)
        LM.Add(MM2)
        LM.Add(MM3)
        LM.Add(MM4)
        'LM.Add(MM5)
        'LM.Add(MM6)
        'LM.Add(MM7)
        'LM.Add(MM8)
        'LM.Add(MM9)

        LSM.Add(S1)
        LSM.Add(S2)
        LSM.Add(S3)
        LSM.Add(S4)
        LSM.Add(S5)
        LSM.Add(S6)
        LSM.Add(S7)
        LSM.Add(S8)
        LSM.Add(S9)
        LSM.Add(S10)
        LSM.Add(S11)
        LSM.Add(S12)
        LSM.Add(S13)
        LSM.Add(S14)
        LSM.Add(S15)
        LSM.Add(S16)
        LSM.Add(S17)
        LSM.Add(S18)
        LSM.Add(S19)
        LSM.Add(S20)
        LSM.Add(S21)
        LSM.Add(S22)
        LSM.Add(S23)
        LSM.Add(S24)
        LSM.Add(S25)
        LSM.Add(S26)
        LSM.Add(S27)
        LSM.Add(S28)
        LSM.Add(S29)
        LSM.Add(S30)
        LSM.Add(S31)
        LSM.Add(S32)
        LSM.Add(S33)
        LSM.Add(S34)
        LSM.Add(S35)
        LSM.Add(S36)
        LSM.Add(S37)
        LSM.Add(S38)
        LSM.Add(S39)
        LSM.Add(S40)
        LSM.Add(S41)
        LSM.Add(S42)
        LSM.Add(S43)
        LSM.Add(S44)
        LSM.Add(S45)
        LSM.Add(S46)
        LSM.Add(S47)
        LSM.Add(S48)
        LSM.Add(S49)
        LSM.Add(S50)
        LSM.Add(S51)
        LSM.Add(S52)
        LSM.Add(S53)
        LSM.Add(S54)
        LSM.Add(S55)
        LSM.Add(S56)
        LSM.Add(S57)
        LSM.Add(S58)
        LSM.Add(S59)
        LSM.Add(S60)
        LSM.Add(S61)
        LSM.Add(S62)
        LSM.Add(S63)
        LSM.Add(S64)
        LSM.Add(S65)
        LSM.Add(S66)
        LSM.Add(S67)
        LSM.Add(S68)
        LSM.Add(S69)
        LSM.Add(S70)
        'LSM.Add(S71)
        'LSM.Add(S72)
        'LSM.Add(S73)
        'LSM.Add(S74)
        'LSM.Add(S75)
        'LSM.Add(S76)
        'LSM.Add(S77)
        'LSM.Add(S78)
        'LSM.Add(S79)



        LSSM.Add(SS1)
        LSSM.Add(SS2)
        LSSM.Add(SS3)
        LSSM.Add(SS4)
        LSSM.Add(SS5)
        LSSM.Add(SS6)
        LSSM.Add(SS7)
        LSSM.Add(SS8)
        LSSM.Add(SS9)
        'LSSM.Add(SS10)
        'LSSM.Add(SS11)
        'LSSM.Add(SS12)
        'LSSM.Add(SS13)
        'LSSM.Add(SS14)
        'LSSM.Add(SS15)
        'LSSM.Add(SS16)
        'LSSM.Add(SS17)
        'LSSM.Add(SS18)
        'LSSM.Add(SS19)
        'LSSM.Add(SS20)
        'LSSM.Add(SS21)
        'LSSM.Add(SS22)
        'LSSM.Add(SS23)
        'LSSM.Add(SS24)
        'LSSM.Add(SS25)
        'LSSM.Add(SS26)
        'LSSM.Add(SS27)
        'LSSM.Add(SS28)
        'LSSM.Add(SS29)
        'LSSM.Add(SS30)
        'LSSM.Add(SS31)
        'LSSM.Add(SS32)
        'LSSM.Add(SS33)
        'LSSM.Add(SS34)
        'LSSM.Add(SS35)
        'LSSM.Add(SS36)
        'LSSM.Add(SS37)
        'LSSM.Add(SS38)
        'LSSM.Add(SS39)
        'LSSM.Add(SS40)
        'LSSM.Add(SS41)
        'LSSM.Add(SS42)
        'LSSM.Add(SS43)
        'LSSM.Add(SS44)
        'LSSM.Add(SS45)
        'LSSM.Add(SS46)
        'LSSM.Add(SS47)
        'LSSM.Add(SS48)


        Dim X As Integer
        For X = 0 To LM.Count - 1
            LM(X).Visible = False
        Next
        For X = 0 To LSM.Count - 1
            LSM(X).Visible = False
        Next
        For X = 0 To LSSM.Count - 1
            LSSM(X).Visible = False
        Next
    End Sub
    Private Sub CARGAPERFILES(ByVal vPERFIL As Integer)
        If Not CHECACONX() Then
            Exit Sub
        End If
        Perfil = vPERFIL
        INICIALIZAMENU()
        PictureBox1.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = True
        PictureBox5.Visible = False
        PBF.Visible = False
        PBCN.Visible = False
        PBCNCRE.Visible = False
        PBC.Visible = False
        PBAI.Visible = False
        PBCC.Visible = False
        PBCLI.Visible = False
        PBTRAS.Visible = False
        'PBU.Visible = False
        Label3.Visible = False
        Label2.Visible = False
        Label6.Visible = False
        Label14.Visible = False
        Label8.Visible = False
        Label15.Visible = False
        LBLTRAS.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        Label2.Visible = False
        Label9.Visible = False
        Label5.Visible = False

        If Perfil = 99 Then
            PBAI.Visible = True
            Label9.Visible = True
        End If

        Dim A As String

        Dim SQL As New SqlClient.SqlCommand("SELECT MENU FROM PERFILESD WHERE SISTEMA=1 AND PERFIL='" + Perfil.ToString + "'", CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        While LEC.Read
            Try
                LM(LEC(0) - 1).Visible = True
            Catch ex As Exception
            End Try
        End While
        LEC.Close()
        Dim DTSUBMENU As New DataTable
        DTSUBMENU = BDLlenatabla("SELECT SUBMENU FROM PERFILESD WHERE SISTEMA=1 AND PERFIL='" + Perfil.ToString + "'", CadenaConexion)
        Dim X, ELEMENTO As Integer
        For X = 0 To DTSUBMENU.Rows.Count - 1
            Try
                ELEMENTO = CType(DTSUBMENU.Rows(X).Item(0).ToString, Integer)
                LSM(ELEMENTO - 1).Visible = True
                If ELEMENTO = 5 Then
                    PBCLI.Visible = True
                    Label6.Visible = True
                End If

                If ELEMENTO = 28 Then
                    PictureBox5.Visible = True
                    Label14.Visible = True
                End If

                If ELEMENTO = 69 Then
                    PBTRAS.Visible = True
                    LBLTRAS.Visible = True
                End If

                If ELEMENTO = 49 Then
                    PictureBox1.Visible = True
                    PictureBox2.Visible = True
                    Label10.Visible = True
                    Label11.Visible = True
                End If

                If ELEMENTO = 39 Then
                    PictureBox3.Visible = True
                    Label12.Visible = True
                End If

                If ELEMENTO = 38 Then
                    PBC.Visible = True
                    Label2.Visible = True
                End If
            Catch ex As Exception

            End Try
        Next
        'SQL.CommandText = "SELECT SUBMENU FROM PERFILESD WHERE SISTEMA=1 AND PERFIL='" + Perfil.ToString + "'"
        'LEC = SQL.ExecuteReader
        'While LEC.Read
        '    Try
        '        LSM(LEC(0) - 1).Visible = True
        '        'If (LEC(0)) = 23 Then
        '        '    PBF.Visible = True
        '        '    Label3.Visible = True
        '        'End If
        '        If (LEC(0)) = 5 Then
        '            PBCLI.Visible = True
        '            Label6.Visible = True
        '        End If
        '        If (LEC(0)) = 28 Then
        '            PictureBox5.Visible = True
        '            Label14.Visible = True
        '        End If
        '        If (LEC(0)) = 69 Then
        '            PBTRAS.Visible = True
        '            LBLTRAS.Visible = True
        '        End If
        '        If (LEC(0)) = 49 Then
        '            PictureBox1.Visible = True
        '            PictureBox2.Visible = True
        '            Label10.Visible = True
        '            Label11.Visible = True
        '        End If
        '        If (LEC(0)) = 39 Then
        '            PictureBox3.Visible = True
        '            Label12.Visible = True
        '        End If
        '        If (LEC(0)) = 38 Then
        '            PBC.Visible = True
        '            Label2.Visible = True
        '        End If

        '    Catch ex As Exception
        '        ' MsgBox(ex.Message + LEC(0).ToString)
        '    End Try
        'End While
        'LEC.Close()
        SQL.CommandText = "SELECT SUBSUBMENU FROM PERFILESD WHERE SISTEMA=1 AND PERFIL='" + Perfil.ToString + "' AND SUBSUBMENU<>0"
        LEC = SQL.ExecuteReader
        While LEC.Read
            Try
                LSSM(LEC(0) - 1).Visible = True
                If (LEC(0)) = 1 Then
                    PBF.Visible = True
                    Label3.Visible = True
                End If
                If (LEC(0)) = 2 Then
                    PBCN.Visible = True
                    Label8.Visible = True
                End If
                If (LEC(0)) = 3 Then
                    PBCNCRE.Visible = True
                    Label15.Visible = True
                End If
                If (LEC(0)) = 4 Then
                    PBCC.Visible = True
                    Label5.Visible = True
                End If
            Catch ex As Exception
                ' MsgBox(ex.Message + LEC(0).ToString)
            End Try
        End While
        LEC.Close()
        SQL.Dispose()
        'MessageBox.Show(LSM(57).Visible.ToString, "", MessageBoxButtons.OK)
        'PBPRENOTAS.Visible = S58.Visible
        'PBCLI.Visible = S4.Visible
        'PBF.Visible = SS1.Visible
        'PictureBox1.Visible = S57.Visible
    End Sub
    Public Function CHECACONX() As Boolean
        If Me.CONX.State = ConnectionState.Closed Or Me.CONX.State = ConnectionState.Broken Then
            Try
                Me.CONX.Open()
            Catch ex As Exception
                MessageBox.Show("La conexión NO esta realizada, la informacion no se ha procesado, intente en un momento por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End Try
        End If
        Return True
    End Function
    Public Function CHECACONXFE() As Boolean
        If Me.CONXFE.State = ConnectionState.Closed Or Me.CONXFE.State = ConnectionState.Broken Then
            Try
                Me.CONXFE.Open()
            Catch ex As Exception
                MessageBox.Show("La conexión NO esta realizada, la informacion no se ha procesado, intente en un momento por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End Try
        End If
        Return True
    End Function
    Private Function CHECACONXX()
        If Me.CONX.State = ConnectionState.Closed Or Me.CONX.State = ConnectionState.Broken Then
            Try
                Me.CONX.Open()
            Catch ex As Exception
                Return False
            End Try
        End If
        Return True
    End Function
    Public Function CONECTAR(ByVal PAGINA As String)
        Try
            If CHECACONXX() Then
                Return True
            Else
                MessageBox.Show("Intento de conexión 1 fallido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MessageBox.Show("Intento de conexión 1 fallido (principal)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
        CadenaConexion = "Data Source=201.120.180.23,1433;Network Library=DBMSSOCN;Initial Catalog=PVGZ;User ID=dbaadmin;Password=masterkey"
        CONX.ConnectionString = CadenaConexion
        Try
            CONX.Open()
            IP = "201.120.180.23"
            IPFE = "201.120.180.23"
            MessageBox.Show("Conectado desde .23", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return True
        Catch ex As Exception
            MessageBox.Show("Intento de conexión 2 fallido (Alterno A)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
        CadenaConexion = "Data Source=201.120.180.232,1433;Network Library=DBMSSOCN;Initial Catalog=PVGZ;User ID=dbaadmin;Password=masterkey"
        CONX.ConnectionString = CadenaConexion
        Try
            CONX.Open()
            IP = "201.120.180.232"
            IPFE = "201.120.180.232"
            MessageBox.Show("Conectado desde 232", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return True
        Catch ex As Exception
            MessageBox.Show("Intento de conexión 3 fallido (Alterno B)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
        IP = CA.DNSLookup(PAGINA)
        If IP = "" Then
            Return False
        Else
            CadenaConexion = "Data Source=" + IP + ",1433;Network Library=DBMSSOCN;Initial Catalog=PVGZ;User ID=dbaadmin;Password=masterkey"
            CONX.ConnectionString = CadenaConexion
            Try
                CONX.Open()
                MessageBox.Show("Conectado desde " + IP + "", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return True
            Catch ex As Exception
                MessageBox.Show("Intento de conexión 4 fallido (Alterno No-IP)" + IP, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End Try
        End If
        Return False
    End Function
    Private Sub CreateShortCut(ByVal strLinkName_ As String, ByVal strTargetPath_ As String _
             , ByVal blnDesktop_ As Boolean, Optional ByVal strPath_ As String = "" _
             , Optional ByVal strArguments_ As String = "" _
             , Optional ByVal strDescription_ As String = "" _
             , Optional ByVal strHotKey_ As String = "" _
             , Optional ByVal strIconLocation_ As String = "" _
             , Optional ByVal strWorkingDirectory_ As String = "")

        Dim shell As Object = CreateObject("WScript.shell")
        Dim link As Object

        If blnDesktop_ Then
            Dim DesktopPath As Object = shell.SpecialFolders("Desktop")
            link = shell.CreateShortcut _
                   (DesktopPath & "\" & strLinkName_ & ".lnk")
        Else
            link = shell.CreateShortcut _
                   (strPath_ & "\" & strLinkName_ & ".lnk")
        End If
        Try
            With link
                ' Argumentos
                .Description = strLinkName_              ' Nombre del Acceso directo
                .TargetPath = strTargetPath_             ' Destino
                .WindowStyle = 1                         ' Ejecutar
                .Save()
            End With
        Catch ex As Exception

        End Try

    End Sub
    Private Function VERIFICAUBICACION() As Boolean
        Return True
        Dim FL As New System.IO.FileInfo(Application.ExecutablePath)
        Dim ORIGEN As String
        ORIGEN = FL.DirectoryName + "\ComercializadoraGT.exe"
        If FL.DirectoryName <> "C:\" Then
            MessageBox.Show("El archivo NO se encuentra en la unidad disco local C: Se creará una copia, favor de cerrar todas las aplicaciones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Try
                System.IO.File.Delete("C:\ComercializadoraGT.exe")
            Catch ex As Exception

            End Try
            System.IO.File.Copy(ORIGEN, "C:\ComercializadoraGT.exe")
            Try
                System.IO.File.Delete(ORIGEN)
            Catch ex As Exception

            End Try
            CreateShortCut("Acceso Directo a Punto De Venta Comercializadora GT", "C:\ComercializadoraGT.exe", True)
            Return False
        End If
        Return True
    End Function

    Private Function LASERIE() As String
        Dim CONZ As New SqlClient.SqlConnection
        CONZ.ConnectionString = CadenaConexionFE
        CONZ.Open()
        Dim SQL As New SqlClient.SqlCommand("SELECT SERIE FROM NEGOCIOS WHERE RFC='" + EmisorBase + "' AND CLAVE='" + SucursalBase + "'", CONZ)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        Dim REG As String
        REG = "GRAL"
        If LEC.Read Then
            REG = LEC(0)
        End If
        LEC.Close()
        SQL.Dispose()
        CONZ.Close()
        Return REG
    End Function
    Private Sub ADMINISTRADOR(ByVal V As Boolean)
        Serie = LASERIE()
        Me.Text = "Comercializadora GT.- Sistema Punto de Venta: " + NombreComun
        SB.Items(0).Text = Me.Ciudad + " Hoy es " + FormatDateTime(Now, DateFormat.LongDate) + " "
        'PBC.Enabled = V
        ''PBF.Enabled = V
        'PBAI.Enabled = V
        'PBM2.Enabled = V
        ''PBCLI.Enabled = V
        '' A1.Enabled = V
        'S2.Enabled = V
        'S3.Enabled = V
        'S5.Enabled = V
        'S8.Enabled = V
        'S9.Enabled = V
        'S10.Enabled = V
        'S11.Enabled = V
        'S4.Enabled = V
        ''A15.Enabled = V
        'S12.Enabled = V
        'S15.Enabled = V
        'S16.Enabled = V
        'S17.Enabled = V
        ' ''A11.Enabled = V
        ''A12.Enabled = V
        ''A14.Enabled = V

        'PBCN.Enabled = V
        'PBCNCRE.Enabled = V
        'PBAI.Enabled = V
        ''PBM2.Enabled = V
        'SS2.Enabled = V
        'SS4.Enabled = V
        'SS3.Enabled = V
        'M9.Enabled = V
        'M8.Enabled = V
        '' R7.Enabled = V
        'S34.Enabled = V
        'S68.Enabled = True
        'S37.Visible = False
        'S37.Enabled = V
        'S30.Enabled = AplicaBodega
        'S13.Enabled = AplicaBodega

        'If NivelBase = 10 Then
        '    PBAI.Enabled = True
        '    M9.Enabled = True
        '    S4.Enabled = True
        '    ' A15.Enabled = True
        '    S12.Enabled = True
        '    S15.Enabled = True
        '    S16.Enabled = True
        '    S17.Enabled = True
        '    S18.Enabled = True
        '    S19.Enabled = True
        '    S20.Enabled = True
        '    S21.Enabled = True
        '    S35.Enabled = True
        '    S36.Enabled = True

        'Else
        '    PBAI.Enabled = False
        '    M9.Enabled = False
        '    S4.Enabled = False
        '    ' A15.Enabled = False
        '    S12.Enabled = False
        '    S15.Enabled = False
        '    S16.Enabled = False
        '    S17.Enabled = False
        '    S18.Enabled = False
        '    S19.Enabled = False
        '    S20.Enabled = False
        '    S21.Enabled = False
        '    S35.Enabled = False
        '    S36.Enabled = False
        'End If


        'If V Then
        '    'Me.BackColor = Color.Brown
        '    'Dim locacion As String
        '    'locacion = "FONDOCAVA"
        '    'PBFONDO.ImageLocation = "C:/FOTOSTIENDA/" + locacion + ".JPG"
        '    Me.BackColor = Color.DeepSkyBlue
        'Else
        '    Me.BackColor = Color.DarkGray
        'End If
        'If SucursalBase = "PM" Then
        '    S8.Visible = True
        '    S9.Visible = True
        '    S10.Visible = True
        '    S11.Visible = True
        '    S12.Visible = True

        '    S30.Visible = True
        '    S31.Visible = True
        '    S32.Visible = True
        '    S34.Visible = True
        '    S58.Visible = True
        '    S37.Visible = True
        '    S68.Visible = False
        'Else
        '    S58.Visible = False
        '    S8.Visible = False
        '    S9.Visible = False
        '    S10.Visible = False
        '    'A4.Visible = False
        '    S12.Visible = False
        '    S68.Visible = True
        '    S30.Visible = False
        '    S31.Visible = False
        '    S32.Visible = False
        '    S34.Visible = False
        'End If
        CARGAPERFILES(Perfil)
    End Sub
    Public Sub CHECATRASDECO()
        'CHECADECOMISO()
        CHECATRASPASO()
    End Sub
    'Private Function CHECADECOMISO() As Boolean
    '    If Not Me.CHECACONX Then
    '        Return False
    '    End If
    '    Dim SQL As New SqlClient.SqlCommand("SELECT ORIGEN FROM DECOMISOSDEBODEGA WHERE ORIGEN='" + Me.SucursalBase + "' and aceptado=0 and resuelto=0", Me.CONX)
    '    Dim LEC As SqlClient.SqlDataReader
    '    LEC = SQL.ExecuteReader
    '    PBDECO.Visible = False
    '    If LEC.Read Then
    '        LEC.Close()
    '        PBDECO.Visible = True
    '        Return True
    '    End If
    '    LEC.Close()
    '    SQL.CommandText = "SELECT DESTINO FROM DECOMISOSDEBODEGA WHERE DESTINO='" + Me.SucursalBase + "' AND ACEPTADO=1 AND RECIBIDO=0"
    '    LEC = SQL.ExecuteReader
    '    If LEC.Read Then
    '        LEC.Close()
    '        PBDECO.Visible = True
    '        Return True
    '    End If
    '    LEC.Close()
    '    Return False
    'End Function
    Public Function CHECATRASPASO() As Boolean
        If Not Me.CHECACONX Then
            Return False
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT ORIGEN FROM TRASPASOS WHERE ORIGEN='" + Me.SucursalBase + "' AND ACEPTADO=0 AND RESUELTO=0", Me.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        LBLTRAS.Visible = False
        PBTRAS.Visible = False
        If LEC.Read Then
            LEC.Close()
            LBLTRAS.Visible = True
            PBTRAS.Visible = True
            Return True
        End If
        LEC.Close()
        SQL.CommandText = "SELECT DESTINO FROM TRASPASOS WHERE DESTINO='" + Me.SucursalBase + "' AND ACEPTADO=1 AND RECIBIDO=0"
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            LEC.Close()
            LBLTRAS.Visible = True
            PBTRAS.Visible = True
            Return True
        End If
        LEC.Close()
        Return False
        Return False
    End Function
    Private Sub A1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S1.Click
        Dim VEM As New frmEmpresa
        VEM.ShowDialog()
    End Sub

    Private Sub A2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S2.Click
        Dim VEMP As New frmEmpleados
        VEMP.ShowDialog()
    End Sub

    Private Sub A3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S9.Click
        Dim VGRU As New frmGrupos
        VGRU.ShowDialog()
    End Sub

    Private Sub A4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S11.Click
        Dim VPRO As New Productos
        VPRO.ShowDialog()
    End Sub
    Private Function VERIFICAVERSION() As Boolean
        Try
            CHECACONX()
            'MessageBox.Show("desconecta", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Dim VER As String
            Dim SQL As New SqlClient.SqlCommand("SELECT VERSION,LIGA FROM VERSIONES WHERE SISTEMA='POS'", Me.CONX)
            Dim LEC As SqlClient.SqlDataReader
            LEC = SQL.ExecuteReader
            If LEC.Read Then
                VER = LEC(0)
                LIGA = LEC(1)
                LEC.Close()
                If VER = VERSION Then
                    Return True
                Else
                    Return False
                End If
            Else
                LEC.Close()
                Return False
            End If
        Catch ex As Exception
            'CE.Escribir(Sistema, Now, "Verificar Version", ex.ToString)
            Return True
        End Try
    End Function

    Private Sub A8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S8.Click
        Dim VUNI As New frmUnidades
        VUNI.ShowDialog()
    End Sub

    Private Sub A5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S3.Click
        Dim VCAJ As New frmCajeras
        VCAJ.ShowDialog()
    End Sub

    Private Sub A6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S14.Click
        Dim VPRO As New frmProveedores
        VPRO.ShowDialog()
    End Sub

    Private Sub A10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S15.Click
        Dim VCONG As New frmConceptosGastos
        VCONG.ShowDialog()
    End Sub

    Private Sub A11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S16.Click
        Dim VSUB As New frmSubConceptosGastos
        VSUB.ShowDialog()
    End Sub

    Private Sub A12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S17.Click
        Dim VCSUB As New frmConceptosSubConceptosGastos
        VCSUB.ShowDialog()
    End Sub

    Private Sub M1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim VNOTA As New frmNotaDeVenta
        VNOTA.ShowDialog()
    End Sub

    Private Sub PBF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBF.Click
        frmNotaDeVenta.ShowDialog()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S5.Click
        Dim VCLI As New frmClientes
        VCLI.ShowDialog()
    End Sub

    Private Sub ClienteRFCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S6.Click
        Dim VCRFC As New frmClientesRFC
        VCRFC.ShowDialog()
    End Sub

    Private Sub PBFONDO_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TAMA As System.Drawing.Size
        TAMA = Me.Size
        TAMA.Height = TAMA.Height - 100
        TAMA.Width = TAMA.Width - 10
        PBCNC.Size = TAMA
        PBCNC.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub

    Private Sub M4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S24.Click
        Dim VCOM As New frmCompras
        VCOM.ShowDialog()
    End Sub

    Private Sub A7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S4.Click
        Dim VUSU As New frmUsuarios
        VUSU.ShowDialog()
    End Sub

    Private Sub A9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S12.Click
        Dim VEQUI As New frmEquivalenciasProductos
        VEQUI.ShowDialog()
    End Sub

    Private Sub R1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim VRC As New frmReporteCompras
        VRC.ShowDialog()
    End Sub

    Private Sub R2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S39.Click
        Dim VRV As New frmReporteVentas
        VRV.ShowDialog()
    End Sub

    Private Sub R8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S44.Click
        Dim VRGCC As New frmReportedeGastosdeCajaChica
        VRGCC.ShowDialog()
    End Sub

    Private Sub InventarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventarioToolStripMenuItem.Click
        Dim VRIP As New frmReporteInventarioPiso
        VRIP.ShowDialog()
    End Sub

    Private Sub R6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R6.Click
        Dim VRAP As New frmReporteHistorialAjustesPiso
        VRAP.ShowDialog()
    End Sub

    Private Sub R7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R7.Click
        Dim VRMP As New frmReportesMermasPiso
        VRMP.ShowDialog()
    End Sub

    Private Sub CompraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompraToolStripMenuItem.Click
        Dim VDC As New frmReporteDescuentosCompras
        VDC.ShowDialog()
    End Sub

    Private Sub VentasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasToolStripMenuItem1.Click
        Dim VDN As New frmReporteDescuentosVentas
        VDN.ShowDialog()
    End Sub

    Private Sub NotasDeVentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotasDeVentaToolStripMenuItem.Click
        Dim VNC As New frmReporteNotaCancelada
        VNC.ShowDialog()
    End Sub

    Private Sub NotasDeCréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotasDeCréditoToolStripMenuItem.Click
        Dim VNCC As New frmReporteNotaCanceladaCredito
        VNCC.ShowDialog()
    End Sub

    Private Sub NotasDeVentaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotasDeVentaToolStripMenuItem1.Click
        Dim VDNV As New frmDetalleDeNotas
        VDNV.ShowDialog()
    End Sub

    Private Sub NotasACréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotasACréditoToolStripMenuItem.Click
        Dim VDNC As New frmDetalleDeNotaCredito
        VDNC.ShowDialog()
    End Sub

    Private Sub GeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralToolStripMenuItem.Click
        Dim VSEG As New frmVentaSinExistencia
        VSEG.ShowDialog()
    End Sub

    Private Sub DesglosadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesglosadoToolStripMenuItem.Click
        Dim VSED As New frmReporteVentaSinExistenciaDesglosado
        VSED.ShowDialog()
    End Sub

    Private Sub CréditosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CréditosToolStripMenuItem2.Click
        Dim VRC As New frmReporteCreditos
        VRC.ShowDialog()
    End Sub

    Private Sub AdeudosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdeudosToolStripMenuItem.Click
        Dim VRA As New frmReporteAdeudos
        VRA.ShowDialog()
    End Sub

    Private Sub AutorizadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutorizadosToolStripMenuItem.Click
        Dim VCAU As New frmReporteCreditosAutorizados
        VCAU.ShowDialog()
    End Sub

    Private Sub FacturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S51.Click
        Dim VRF As New frmReporteFacturas
        VRF.ShowDialog()
    End Sub

    Private Sub ComprasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S38.Click
        Dim VRC As New frmReporteCompras
        VRC.ShowDialog()
    End Sub

    Private Sub R3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FacturaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S27.Click
        Dim VF As New frmFacturas
        VF.ShowDialog()
    End Sub

    Private Sub PagoDeCréditosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S28.Click
        Dim VAC As New frmAbonosCreditos
        VAC.ShowDialog()
    End Sub



    Private Sub PBM2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim VM As New frmMermasTiendasPiso
        VM.ShowDialog()
    End Sub

    Private Sub PBCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBCC.Click
        Dim VCC As New frmCorteCaja
        VCC.ShowDialog()
    End Sub

    Private Sub PBAI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBAI.Click
        Dim VA As New frmAjustesPiso
        VA.ShowDialog()
    End Sub

    Private Sub PBCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBCN.Click
        Dim VCN As New frmCancelaNotas
        VCN.ShowDialog()
    End Sub

    Private Sub PBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBC.Click
        Dim VC As New frmCompras
        VC.ShowDialog()
    End Sub

    Private Sub M2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim VCN As New frmCancelaNotas
        VCN.ShowDialog()
    End Sub

    Private Sub M3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim VCC As New frmCorteCaja
        VCC.ShowDialog()
    End Sub

    Private Sub M8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M8.Click
        Dim VMP As New frmMermasTiendasPiso
        VMP.ShowDialog()
    End Sub

    Private Sub M9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M9.Click
        'Dim VAP As New frmAjustesPiso
        'VAP.ShowDialog()
        Dim VAI As New frmAjustarInventario
        VAI.ShowDialog()

    End Sub

    Private Sub M10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S26.Click
        Dim VGCC As New frmCajaChica
        VGCC.ShowDialog()
    End Sub

    Private Sub CancelarNotaACreditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim VCNC As New frmCancelaNotasCredito
        VCNC.ShowDialog()
    End Sub

    Private Sub PreciosClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S7.Click
        Dim VPC As New frmPreciosClientes
        VPC.ShowDialog()
    End Sub

    Private Sub PBU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBU.Click
        Dim VSES As New frmLogin
        VSES.ShowDialog()
        If VSES.DialogResult = Windows.Forms.DialogResult.Yes Then
            If NivelBase >= 5 Then
                ADMINISTRADOR(True)
            Else
                ADMINISTRADOR(False)
            End If
            'LBLTI.Text = NombreSucursal
        Else
            Me.Close()
        End If
    End Sub

    Private Sub CatalogoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S46.Click
        Dim VCAT As New frmCatalogo
        VCAT.ShowDialog()
    End Sub

    Private Sub ReimprimirCorteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim VRC As New frmReimpresioncorte
        VRC.ShowDialog()
    End Sub

    Private Sub SubGruposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S10.Click
        Dim VSUB As New frmSubgrupo
        VSUB.ShowDialog()
    End Sub

    Private Sub PreciosClientesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AbonosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbonosToolStripMenuItem.Click
        Dim VRA As New frmReporteAbonos
        VRA.ShowDialog()
    End Sub

    Private Sub GeneralToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralToolStripMenuItem1.Click
        Dim VRCG As New frmReporteGeneralCredito
        VRCG.ShowDialog()
    End Sub

    Private Sub PreciosClientesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreciosClientesToolStripMenuItem2.Click
        Dim VRPC As New frmReportePreciosClientes
        VRPC.ShowDialog()
    End Sub

    Private Sub ConsumoPorClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsumoPorClienteToolStripMenuItem.Click
        Dim VCC As New frmReporteXClientes
        VCC.ShowDialog()
    End Sub

    Private Sub VentaPorClienteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaPorClienteToolStripMenuItem1.Click
        Dim VRVC As New frmReportevtaxCliente
        VRVC.ShowDialog()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBCNCRE.Click
        Dim VCNC As New frmCancelaNotasCredito
        VCNC.ShowDialog()
    End Sub

    Private Sub PBGCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim VGCC As New frmCajaChica
        VGCC.ShowDialog()
    End Sub

    Private Sub PBCLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBCLI.Click
        Dim VC As New frmClientes
        VC.ShowDialog()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        'MessageBox.Show("Favor de capturar desde la caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Dim VAC As New frmAbonosCreditos
        VAC.ShowDialog()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim VF As New frmFacturas
        VF.ShowDialog()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim VDN As New frmDetalleDeNotas
        VDN.ShowDialog()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim VDVC As New frmDetalleDeNotaCredito
        VDVC.ShowDialog()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim VRV As New frmReporteVentas
        VRV.ShowDialog()
    End Sub

    Private Sub StockMinimoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S52.Click
        Dim VRSM As New frmReporteStockMin
        VRSM.ShowDialog()
    End Sub

    Private Sub FacturasPublicoEnGeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S67.Click
        Dim VFPG As New frmFacturaPublicoGeneral
        VFPG.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        SB.Items(1).Text = "Comercializadora GT   " + Format(Now, "hh:mm:ss tt")
    End Sub

    Private Sub PedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S29.Click
        Dim VP As New frmPedidos
        VP.ShowDialog()
    End Sub

    Private Sub SurtirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S30.Click
        Dim VSP As New frmPedidosSucursales
        VSP.ShowDialog()
    End Sub

    Private Sub NotaDeVentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SS1.Click
        frmNotaDeVenta.ShowDialog()
    End Sub

    Private Sub CancelarNotaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SS2.Click
        Dim VCN As New frmCancelaNotas
        VCN.ShowDialog()
    End Sub

    Private Sub CancelarNotaACreditoToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SS3.Click
        Dim VCNC As New frmCancelaNotasCredito
        VCNC.ShowDialog()
    End Sub

    Private Sub CorteCajaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SS4.Click
        Dim VCC As New frmCorteCaja
        VCC.ShowDialog()
    End Sub

    Private Sub ReimprimirCorteToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SS5.Click
        Dim VRC As New frmReimpresioncorte
        VRC.ShowDialog()
    End Sub

    Private Sub ReciboDePedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S68.Click
        Dim VRP As New frmEntradaPedido
        VRP.ShowDialog()
    End Sub

    Private Sub ReimpresionDePedidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S31.Click
        Dim VRIP As New frmReimpresionPedido
        VRIP.ShowDialog()
    End Sub

    Private Sub EntradaPorPedidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S70.Click
        Dim VREP As New frmReporteEntradasPorPedido
        VREP.ShowDialog()
    End Sub

    Private Sub SolucionDevolucionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S32.Click
        Dim VSD As New frmSoluciondeDevolucion
        VSD.ShowDialog()
    End Sub

    Private Sub BancosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S19.Click
        Dim VB As New frmBancos
        VB.ShowDialog()
    End Sub

    Private Sub CuentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S18.Click
        Dim VC As New frmCuentas
        VC.ShowDialog()
    End Sub

    Private Sub CuentasBancosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S20.Click
        Dim VCB As New frmCuentasBancos
        VCB.ShowDialog()
    End Sub

    Private Sub DepositosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S33.Click
        Dim VD As New frmDepositos
        VD.ShowDialog()
    End Sub
    Private Sub ConfirmaciónDepositosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S34.Click
        Dim VCD As New frmConfirmarDepositos
        VCD.ShowDialog()
    End Sub

    Private Sub M24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S69.Click

    End Sub

    Private Sub M25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M25.Click
        Dim VT As New frmTraspasos
        VT.ShowDialog()
    End Sub

    Private Sub M27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M27.Click
        Dim VST As New frmTraspasosV2
        VST.ShowDialog()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub VentasACreditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S41.Click
        Dim VRVC As New frmReporteVentasCredito
        VRVC.ShowDialog()
    End Sub

    Private Sub M28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S35.Click
        Dim VCP As New frmPreciosProductos
        VCP.ShowDialog()
    End Sub

    Private Sub HistorialCambioDePreciosDeSucursalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S53.Click
        Dim VHP As New frmHistorialCambioPrecio
        VHP.ShowDialog()
    End Sub

    Private Sub PreciosPorSucursalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S54.Click
        Dim VPS As New frmReportePreciosSucursal
        VPS.ShowDialog()
    End Sub

    Private Sub VentaPorTipoDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S40.Click
        Dim VRTP As New frmVentaDiaria
        VRTP.ShowDialog()
    End Sub

    Private Sub MovimientosPorProductoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S55.Click
        Dim VRPP As New frmReporteMovientosXProducto
        VRPP.ShowDialog()
    End Sub

    Private Sub MovimientosDeInventarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S56.Click
        Dim MI As New frmReporteMovimientosInvGeneral
        MI.ShowDialog()
    End Sub

    Private Sub A20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S21.Click
        Dim VDU As New frmDeshabilitaUsuario
        VDU.ShowDialog()
    End Sub

    Private Sub M29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S36.Click
        Dim VMN As New frmModificaNotas
        VMN.ShowDialog()
    End Sub

    Private Sub M26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M26.Click
        Dim VRT As New frmEntradaTraspaso
        VRT.ShowDialog()
    End Sub

    Private Sub ComprobarVentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim VRVEN As New frmRevisarVenta
        VRVEN.ShowDialog()
    End Sub

    Private Sub ComprobarVentaToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S57.Click
        Dim VRVEN As New frmRevisarVenta
        VRVEN.ShowDialog()
    End Sub

    Private Sub CancelarCompraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S58.Click
        Dim VCC As New frmAjustesComprasRestaurantes
        VCC.ShowDialog()
    End Sub

    Private Sub FacturarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturarToolStripMenuItem.Click
        MessageBox.Show("Esta opción es solo para facturar con fecha anterior a 2018", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Dim VFAC As New frmFacturar
        VFAC.ShowDialog()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim VCFAC As New frmClientesFacturasElectronicasV2
        VCFAC.ShowDialog()
    End Sub

    Private Sub ReimprimirFacturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReimprimirFacturasToolStripMenuItem.Click
        Dim VRFAC As New frmReporteFacturasElectronicas
        VRFAC.ShowDialog()
    End Sub

    Private Sub AnalisisIvaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S59.Click
        Dim VAI As New frmAnalisisVenta
        VAI.ShowDialog()
    End Sub

    Private Sub RelacionNotaFacturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S60.Click
        Dim VRNF As New frmRelacionNotaFactura
        VRNF.ShowDialog()
    End Sub

    Private Sub RastreoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S61.Click
        Dim VRAS As New frmRastreo
        VRAS.ShowDialog()
    End Sub

    Private Sub KardexClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S62.Click
        Dim VKC As New frmKardexClientes
        VKC.ShowDialog()
    End Sub

    Private Sub AclaraciónPedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S37.Click
        Dim VAPED As New frmAclaracionPedido
        VAPED.ShowDialog()
    End Sub

    Private Sub CambioDeCódigoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S63.Click
        Dim VCC As New frmCambioCodigo
        VCC.ShowDialog()
    End Sub

    Private Sub FacturaPGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S64.Click
        Dim VFPG As New frmFacturaDelDia
        VFPG.ShowDialog()
    End Sub

    Private Sub EtiquetarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S65.Click
        Dim VETI As New frmEtiquetar
        VETI.ShowDialog()
    End Sub

    Private Sub CarteraClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarteraClientesToolStripMenuItem.Click
        Dim VETI As New frmCarteleraCliente
        VETI.ShowDialog()
    End Sub

    Private Sub LocalidadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S13.Click
        Dim VLOC As New frmLocalidades
        VLOC.ShowDialog()
    End Sub

    Private Sub PBTRAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBTRAS.Click
        Dim VTRAS As New frmTraspasosV2
        VTRAS.ShowDialog()
    End Sub

    Private Sub MezcladoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MezcladoToolStripMenuItem.Click
        Dim VIMIX As New frmReporteInventarioMixto
        VIMIX.ShowDialog()
    End Sub

    Private Sub PerfilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S66.Click
        Dim VPER As New frmPerfiles
        VPER.ShowDialog()
    End Sub

    Private Sub Facturar33ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Facturar33ToolStripMenuItem.Click
        'MessageBox.Show("No liberada", "Aviso")
        'Exit Sub
        Dim VF33 As New frmFacturar33
        VF33.ShowDialog()
    End Sub

    Private Sub VentasMétodoDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasMétodoDePagoToolStripMenuItem.Click
        Dim VRVMP As New frmVentaTipoPago
        VRVMP.ShowDialog()
    End Sub

    Private Sub KardexVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KardexVentasToolStripMenuItem.Click
        Dim VKV As New frmKardexVenta
        VKV.ShowDialog()
    End Sub

    Private Sub NotasDeCobranzaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotasDeCobranzaToolStripMenuItem.Click
        Dim VDNCOB As New frmDetalleDeNotasCobranza
        VDNCOB.ShowDialog()
    End Sub

    Private Sub KardexProductoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KardexProductoToolStripMenuItem.Click
        Dim VKPRO As New frmKardexProducto
        VKPRO.ShowDialog()
    End Sub

    Private Sub KardexPreciosClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KardexPreciosClientesToolStripMenuItem.Click
        Dim VKPCLI As New frmKardexPreciosClientes
        VKPCLI.ShowDialog()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AyudaToolStripMenuItem.Click
        frmAyuda.ShowDialog()
    End Sub

    Private Sub PictureBox4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Dim VDVNC As New frmDetalleDeNotasCobranza
        VDVNC.ShowDialog()
    End Sub

    Private Sub VehiculosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VehiculosToolStripMenuItem.Click
        Dim VVEHI As New frmVehiculosCartaPorte
        VVEHI.ShowDialog()
    End Sub

    Private Sub TrasladosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrasladosToolStripMenuItem.Click
        Dim VTCP As New frmTrasladosCartaPorte
        VTCP.ShowDialog()
    End Sub

    Private Sub InfoAlmacenesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoAlmacenesToolStripMenuItem.Click
        Dim VALMA As New frmAlmacenesCartaPorte
        VALMA.ShowDialog()
    End Sub

    Private Sub ChoferesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChoferesToolStripMenuItem.Click
        Dim VCCP As New frmChoferesCartaPorte
        VCCP.ShowDialog()
    End Sub

    Private Sub AjustesFacturasSinTimbrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjustesFacturasSinTimbrarToolStripMenuItem.Click
        Dim VAFST As New frmAjustadorFacturasSinTimbrar
        VAFST.ShowDialog()
    End Sub

    Private Sub CambiarFondoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarFondoToolStripMenuItem.Click
        Dim URL As String
        Dim ofd As New OpenFileDialog
        ofd.Title = "Buscar archivo de imagen *.png"
        ofd.DefaultExt = ".png"
        'ofd.Filter = "Archivo Imagen (*.jpg)|*.jpg"
        ofd.Filter = "Archivos de Imagen (*.png)|*.png|" + Chr(34) + "Archivos de Imagen (*.jpg)|*.jpg|" + Chr(34) + "Archivos de Imagen (*.jpeg)|*.jpeg|" + Chr(34) + "Todos los archivos(*.*)|*.*;"
        ofd.FilterIndex = 1
        ofd.FileName = ""
        URL = ""
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            My.Settings.RutaFondo = ofd.FileName
            My.Settings.Save()
        End If
        PonerFondo()
    End Sub

    Private Sub PictureBox6_Click_1(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim VCC2 As New frmCancelacionCobranza
        VCC2.ShowDialog()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Dim REP As New rptTestImpresion
        IMPRIMIRREPORTE(REP, BDLlenatabla("SELECT NOMBRE=''", CadenaConexion), 1, "")
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Dim VCH As New frmConversorHuevos
        VCH.ShowDialog()
    End Sub

    Private Sub ReimprimirTraspasoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReimprimirTraspasoToolStripMenuItem.Click
        Dim VRTRAS As New frmReporteTraspasos
        VRTRAS.ShowDialog()
    End Sub

    Private Sub CancelarAbonoPagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarAbonoPagoToolStripMenuItem.Click
        Dim VCC As New frmCancelacionCobranza
        VCC.ShowDialog()
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub DepuracionRFCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepuracionRFCToolStripMenuItem.Click
        Dim VDRFC As New frmDepuracionRfc
        VDRFC.ShowDialog()
    End Sub
End Class

