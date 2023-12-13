Imports System.Reflection.Assembly
Public Class Productos
    Dim CLAGRU As New List(Of String)
    Dim CLASG As New List(Of String)
    Dim CLAUC As New List(Of String)
    Dim CLAUV As New List(Of String)
    Dim CLAUS As New List(Of String)
    Dim DTFECHA As DateTimePicker
    Dim LEMP As New List(Of String)
    Dim LFIVA As New List(Of String)
    Dim LFIEPS As New List(Of String)

    Private Sub Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        CARGAGRUPOS()
        CARGASUBGRUPOS()
        CARGAUNIDADES()
        TabPage2.Parent = Nothing
        TXTCP.Text = ULTIMOPRODUCTO()
        OPLlenaCLB(CLBEMP, LEMP, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE ACTIVO=1 AND CLAVE<>'SBMLM1' AND CLAVE<>'PRUEBAS' ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion)
        OPLlenaComboBox(CBFIVA, LFIVA, "SELECT CLAVE,NOMBRE FROM CSATTIPOFACTOR WHERE CLAVE<>2 ORDER BY NOMBRE", frmPrincipal.CadenaConexion, "Favor de seleccionar", "")
        OPLlenaComboBox(CBFIEPS, LFIEPS, "SELECT CLAVE,NOMBRE FROM CSATTIPOFACTOR ORDER BY NOMBRE ", frmPrincipal.CadenaConexion, "Favor de seleccionar", "")
        If VERIFICARGRUPO() Then
            MessageBox.Show("Antes de dar alta un articulo debe especificar al menos un grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Dim VG As New frmGrupos
            VG.ShowDialog()
        Else
            If VERIFICARSUBGRUPO() Then
                MessageBox.Show("Antes de dar alta un articulo debe especificar al menos un sub grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Dim VG As New frmSubgrupo
                VG.ShowDialog()
            Else
                If VERIFICARUNI() Then
                    MessageBox.Show("Antes de dar alta un articulo debe especificar al menos una unidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'Dim VG As New frmUnidades
                    'VG.ShowDialog()
                    Me.Close()
                Else

                    ACTIVAR(True)

                    TXTPG.Text = "0.00"
                    TXTSM.Text = "0"
                    TXTSMAX.Text = "0"

                    TXTSM.Enabled = False
                    CBACT.SelectedIndex = 0
                    CBSP.SelectedIndex = 0
                    CBIVA.SelectedIndex = 1
                End If
            End If
        End If
        Try
            CBFIVA.SelectedIndex = 1
            CBFIEPS.SelectedIndex = 2

        Catch ex As Exception

        End Try
    End Sub
    Dim lpszName As String
    Dim lpszVer As String
    Private Sub ACTIVARCAMARA(ByVal V As Boolean)
        If V Then
            'Try
            '    capGetDriverDescriptionA(0, lpszName, 100, lpszVer, 100)
            '    lwndC = capCreateCaptureWindowA(lpszName, WS_VISIBLE Or WS_CHILD, 567, 107, 112, 150, Me.Handle.ToInt32, 0)

            '    If capDriverConnect(lwndC, 0) Then
            '        capPreviewScale(lwndC, True)
            '        capPreviewRate(lwndC, 50)
            '        capPreview(lwndC, True)
            '    End If
            'Catch ex As Exception

            'End Try
        Else
            'Try
            '    capSetCallbackOnError(lwndC, VariantType.Null)
            '    capSetCallbackOnStatus(lwndC, VariantType.Null)
            '    capSetCallbackOnYield(lwndC, VariantType.Null)
            '    capSetCallbackOnFrame(lwndC, VariantType.Null)
            '    capSetCallbackOnVideoStream(lwndC, VariantType.Null)
            '    capSetCallbackOnWaveStream(lwndC, VariantType.Null)
            '    capSetCallbackOnCapControl(lwndC, VariantType.Null)
            'Catch ex As Exception

            'End Try
        End If

    End Sub
    'Public Shared Property DefInstance() As Productos
    '    Get
    '        If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
    '            m_InitializingDefInstance = True
    '            m_vb6FormDefInstance = New frmCamara
    '            m_InitializingDefInstance = False
    '        End If
    '        DefInstance = m_vb6FormDefInstance
    '    End Get
    'End Property

    Private Function VERIFICARSUBGRUPO() As Boolean
        If CLASG.Count = 0 Then
            Return True
        End If
        Return False
    End Function
    Private Function VERIFICARGRUPO() As Boolean
        If CLAGRU.Count = 0 Then
            Return True
        End If
        Return False
    End Function
    Private Function VERIFICARUNI() As Boolean
        If CLAUC.Count = 0 Then
            Return True
        End If
        Return False
    End Function
    Private Sub ACTIVAR(ByVal V As Boolean)
        TXTCLA.Enabled = V
        RBC.Enabled = V
        BTNOPCIONES.Enabled = Not V
        TXTTCIEPS.Enabled = Not V
        BTNGI.Enabled = Not V
        TXTNOM.Enabled = Not V
        TXTDES.Enabled = Not V
        TXTNC.Enabled = Not V
        TXTPG.Enabled = Not V
        CBGRU.Enabled = Not V
        TXTIMG.Enabled = Not V
        CBACT.Enabled = Not V
        CBSP.Enabled = Not V
        CBUC.Enabled = Not V
        CBUV.Enabled = Not V
        CBUS.Enabled = Not V
        CBIVA.Enabled = Not V
        TXTSM.Enabled = Not V
        TXTSMAX.Enabled = Not V
        CBSG.Enabled = Not V
        TXTPED.Enabled = Not V
        'TXTPMIN.Enabled = Not V
        TXTPCLN.Enabled = Not V
        'TXTPOBR.Enabled = Not V
        TXTPGML.Enabled = Not V
        TXTPBOD.Enabled = Not V
        TXTPG.Enabled = Not V
        'TXTPGVE.Enabled = Not V
        'TXTPMZT.Enabled = Not V
        'TXTPMINOBR.Enabled = Not V
        BTNRESET.Enabled = Not V
        TXTPESO.Enabled = Not V
        'CHKTODAS.Enabled = Not V

        CHKBOD.Enabled = Not V
        'CHKLM.Enabled = Not V
        CHKCLN.Enabled = Not V
        'CHKOBR.Enabled = Not V
        CHKGML.Enabled = Not V
        CLBEMP.Enabled = Not V
        'CHKGVE.Enabled = Not V
        'CHKMZT.Enabled = Not V

        CBFIEPS.Enabled = Not V
        CBFIVA.Enabled = Not V
        TXTCPYSSAT.Enabled = Not V


        BTNGUARDAR.Enabled = Not V
        BTNELIMINAR.Enabled = Not V

        'CHKLM.Checked = Not V
        'CHKGVE.Checked = Not V
        'CHKOBR.Checked = Not V
        'CHKMZT.Checked = Not V

        TA.Enabled = Not V
        TB.Enabled = Not V
        TC.Enabled = Not V
        TD.Enabled = Not V
        TE.Enabled = Not V
        TF.Enabled = Not V
        TG.Enabled = Not V
        TH.Enabled = Not V
        TI.Enabled = Not V
        TJ.Enabled = Not V
        If V Then
            TXTCLA.Focus()
            TXTCLA.SelectAll()
            CBFIEPS.SelectedIndex = 0
            CBFIVA.SelectedIndex = 0
        Else
            TXTNOM.Focus()
        End If
        ACTIVARCAMARA(Not V)
    End Sub
    Private Sub LIMPIAR()
        TXTCLA.Clear()
        TXTNOM.Clear()
        TXTDES.Clear()
        TXTNC.Clear()
        TXTPG.Text = "0.00"
        TA.Clear()
        TB.Clear()
        TC.Clear()
        TD.Clear()
        TE.Clear()
        TF.Clear()
        TG.Clear()
        TH.Clear()
        TI.Clear()
        TJ.Clear()
        CBGRU.SelectedIndex = 0
        CBACT.SelectedIndex = 0
        CBSP.SelectedIndex = 0
        CBUC.SelectedIndex = 0
        CBUV.SelectedIndex = 0
        CBUS.SelectedIndex = 0
        CBIVA.SelectedIndex = 1
        RBC.Checked = False
        TXTIMG.Clear()
        TXTSM.Text = "0"
        TXTSMAX.Text = "0"
        TXTTIVA.Text = "0"
        TXTTCIEPS.Text = "0"
        TXTPESO.Text = "0"
        CBSG.SelectedIndex = 0
        PB.Image = Nothing
    End Sub
    Private Function CARGASUBGRUPOS() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBSG, CLASG, "SELECT CLAVE,NOMBRE FROM SUBGRUPOS WHERE ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + "  ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBSG.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBGRU.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Function
    Private Function CARGAGRUPOS() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        Dim LEIDO As Boolean
        LEIDO = False

        OPLlenaComboBox(CBGRU, CLAGRU, "SELECT CLAVE,NOMBRE FROM GRUPOS WHERE ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + "  ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        If CBGRU.Items.Count > 0 Then
            LEIDO = True
        End If

        Try
            CBGRU.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Function

    Private Sub CARGAUNIDADES()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        CBUC.Items.Clear()
        CBUV.Items.Clear()
        CBUS.Items.Clear()
        CLAUC.Clear()
        CLAUV.Clear()
        CLAUS.Clear()
        Dim SQLUNI As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM UNIDADES WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LECUNI As SqlClient.SqlDataReader
        LECUNI = SQLUNI.ExecuteReader
        While LECUNI.Read
            CLAUC.Add(LECUNI(0))
            CLAUV.Add(LECUNI(0))
            CLAUS.Add(LECUNI(0))
            CBUC.Items.Add(LECUNI(1))
            CBUV.Items.Add(LECUNI(1))
            CBUS.Items.Add(LECUNI(1))
        End While
        LECUNI.Close()
        Try
            CBUC.SelectedIndex = 0
            CBUV.SelectedIndex = 0
            CBUS.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CARGAELGRUPO(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CLAGRU.Count - 1
            If CLAGRU(X) = CLA Then
                CBGRU.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
    Private Sub CARGAELSUBGRUPO(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CLASG.Count - 1
            If CLASG(X) = CLA Then
                CBSG.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
    Private Sub CARGAUC(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CLAUC.Count - 1
            If CLAUC(X) = CLA Then
                CBUC.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
    Private Sub CARGAUV(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CLAUV.Count - 1
            If CLAUV(X) = CLA Then
                CBUV.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
    Private Sub CARGAUS(ByVal CLA As String)
        Dim X As Integer
        For X = 0 To CLAUS.Count - 1
            If CLAUS(X) = CLA Then
                CBUS.SelectedIndex = X
                Exit Sub
            End If
        Next
    End Sub
    Dim PANT As Double
    Private Sub CARGADATOS()
        ACTIVAR(False)
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim ENC As Boolean = False
        PANT = 0
        Dim SQLSELECT As New SqlClient.SqlCommand("SELECT NOMBRE,DESCRIPCION,GRUPO,PRECIO,ACTIVO,STOCKMIN,IMG,SEPESA,UCOMPRA,UVENTA,CP,IVA,USALIDA,NOMBRECORTO,STOCKMAX,TIPO,SUBGRUPO,IEPS,PEDIMENTO,CPM,OPM,BPM,GPM,PMIN,PM,DBO.ULTIMOCAMBIOPRECIO('" + TXTCLA.Text + "'),FACTORIVA,FACTORIEPS,TASAIVA,TASAIEPS,CPSSAT,GVE,PMINOBR,PESO,MZT,PMINMZT FROM PRODUCTOS WHERE CLAVE =@CLA AND EMPRESA=" + frmPrincipal.Empresa + "", frmPrincipal.CONX)
        SQLSELECT.Parameters.Add("@CLA", SqlDbType.VarChar, 100)
        SQLSELECT.Parameters("@CLA").Value = TXTCLA.Text
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLSELECT.ExecuteReader
        If LECTOR.Read Then
            ENC = True
            TXTNOM.Text = LECTOR(0)
            TXTDES.Text = LECTOR(1)
            CARGAELGRUPO(LECTOR(2))

            TXTPG.Text = LECTOR(3)
            If CType(LECTOR(4), Boolean) Then
                CBACT.SelectedIndex = 1
            Else
                CBACT.SelectedIndex = 0
            End If
            TXTSM.Text = LECTOR(5)
            TXTIMG.Text = LECTOR(6)
            If CType(LECTOR(7), Boolean) Then
                CBSP.SelectedIndex = 0
            Else
                CBSP.SelectedIndex = 1
            End If
            CARGAUC(LECTOR(8))
            CARGAUV(LECTOR(9))
            TXTCP.Text = LECTOR(10)
            If CType(LECTOR(11), Boolean) Then
                CBIVA.SelectedIndex = 0
            Else
                CBIVA.SelectedIndex = 1
            End If
            CARGAUS(LECTOR(12))
            TXTNC.Text = LECTOR(13)
            TXTSMAX.Text = LECTOR(14)

            If LECTOR(15) = "IMPORTADO" Then
                RBC.Checked = False
            Else
                RBC.Checked = True
            End If
            CARGAELSUBGRUPO(LECTOR(16))
            TXTTCIEPS.Text = LECTOR(17)
            TXTPED.Text = LECTOR(18)

            TXTPCLN.Text = LECTOR(19)

            TXTPBOD.Text = LECTOR(21)
            TXTPGML.Text = LECTOR(22)
            Try
                PANT = CType(TXTPG.Text, Double)
            Catch ex As Exception
                PANT = 0
            End Try
            Label34.Text = LECTOR(25)

            OPCargaX(LFIVA, CBFIVA, LECTOR(26))
            OPCargaX(LFIEPS, CBFIEPS, LECTOR(27))
            TXTTIVA.Text = LECTOR(28)
            TXTTCIEPS.Text = LECTOR(29)
            TXTCPYSSAT.Text = LECTOR(30)
            TXTTCIEPS.Text = LECTOR(29)
            TXTPESO.Text = LECTOR(33)
        End If
        LECTOR.Close()
        If Not ENC Then
            TXTCP.Text = ULTIMOPRODUCTO()
            Try
                CBFIVA.SelectedIndex = 1
                CBFIEPS.SelectedIndex = 2
            Catch ex As Exception

            End Try
            TabControl1.SelectedTab = TabControl1.TabPages(0)

        Else
            TabControl1.SelectedTab = TabControl1.TabPages(3)
        End If
        CARGAPRECIOSTIENDAS(ENC)
        CARGAPEDIMENTO()
        CARGAPRODUCTOSTIENDAS()
        TXTNOM.Focus()

        CARGARFOTO()
    End Sub
    Private Sub CARGAPRECIOSTIENDAS(ByVal ENC As Boolean)
        If ENC Then
            DGV.DataSource = BDLlenatabla("SELECT T.NOMBRECOMUN TIENDA,ISNULL(D.PRECIO,0.00)PRECIO,ISNULL(D.PRECIOMIN,0.00)PRECIOMINIMO,T.CLAVE FROM TIENDAS T FULL JOIN PRECIOSSUCURSALES D ON T.CLAVE=D.TIENDA WHERE D.PRODUCTO='" + TXTCLA.Text + "'", frmPrincipal.CadenaConexion)
        Else
            DGV.DataSource = BDLlenatabla("SELECT T.NOMBRECOMUN TIENDA,PRECIO=0.00,PRECIOMINIMO=0.00,T.CLAVE FROM TIENDAS T ", frmPrincipal.CadenaConexion)
        End If
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(2).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(3).Visible = False
        DgvAjusteEncabezado(DGV, 0)
    End Sub
    Private Sub CARGARFOTO()
        Try
            LBLRIMG.Text = "C:/FOTOSPRICE/" + TXTCP.Text + ".JPG"
            PB.ImageLocation = "C:/FOTOSPRICE/" + TXTCP.Text + ".JPG"
        Catch ex As Exception

        End Try

    End Sub
    Private Sub DESMARCARCLB(ByVal V As Boolean)
        Dim X As Integer
        For X = 0 To CLBEMP.Items.Count - 1
            CLBEMP.SetItemChecked(X, V)
        Next
    End Sub
    Private Sub MARCARCLB(ByRef LISTA As List(Of String), ByRef CLB As CheckedListBox, ByVal VALOR As String)
        Dim X As Integer
        For X = 0 To LISTA.Count - 1
            If VALOR = LISTA(X) Then
                CLB.SetItemChecked(X, True)
            End If
        Next
    End Sub
    Private Sub CARGAPRODUCTOSTIENDAS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        DESMARCARCLB(False)
        Dim SQL As New SqlClient.SqlCommand("SELECT DISTINCT(TIENDA) FROM PRODUCTOSTIENDAS WHERE PRODUCTO='" + TXTCLA.Text + "' AND ACTIVO=1", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        While LEC.Read
            MARCARCLB(LEMP, CLBEMP, LEC(0))
        End While
        LEC.Close()
        SQL.Dispose()
    End Sub
    Private Sub CARGAPEDIMENTO()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQLP As New SqlClient.SqlCommand("SELECT EXPORTADOR,IMPORTADOR,DIRECCION,ORIGEN,INGREDIENTES,SUGERENCIA,PREPARACION,INFORMACION,IMPRESO,PEDIMENTO FROM PRODUCTOPEDIMENTO WHERE PRODUCTO='" + TXTCLA.Text + "'", frmPrincipal.CONX)
        Dim LECP As SqlClient.SqlDataReader
        LECP = SQLP.ExecuteReader
        If LECP.Read Then
            TA.Text = LECP(0)
            TB.Text = LECP(1)
            TC.Text = LECP(2)
            TD.Text = LECP(3)
            TE.Text = LECP(4)
            TF.Text = LECP(5)
            TG.Text = LECP(6)
            TH.Text = LECP(7)
            TI.Text = LECP(8)
            TJ.Text = LECP(9)
        End If
        LECP.Close()
        SQLP.Dispose()
    End Sub

    Private Sub TXTCLA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLA.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTCLA.Text = "" Then
            Else
                CARGADATOS()
            End If
        End If
    End Sub

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        LimpiarForm(Me.Controls)
        'LIMPIAR()
        ACTIVAR(True)
        'LIMPIAR()
        TXTSM.Enabled = False
        TXTCP.Text = ULTIMOPRODUCTO()
    End Sub
    Private Function VALIDAPRECIOS() As Boolean
        Dim X As Integer
        For X = 0 To DGV.RowCount - 1
            If DGV.Item(2, X).Value > DGV.Item(1, X).Value Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub GUARDAR()
        If TXTNOM.Text = "" Or TXTPG.Text = 0 Then
            MessageBox.Show("Falta e< datos, revisar nombre y precio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not VALIDAPRECIOS() Then
            Exit Sub
        End If
        ''
        Dim IEPS, PG, SM, SMAX As Double
        Try
            IEPS = CType(TXTTCIEPS.Text, Double)
            PG = CType(TXTPG.Text, Double)
        Catch ex As Exception
            MessageBox.Show("Ieps No Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End Try
        If IEPS < 0 Then
            MessageBox.Show("Ieps No Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        Dim SQLGUARDAR As New SqlClient.SqlCommand
        SQLGUARDAR.Connection = frmPrincipal.CONX
        SQLGUARDAR.CommandType = CommandType.StoredProcedure
        SQLGUARDAR.Parameters.Add("@EMP", SqlDbType.Int).Value = frmPrincipal.Empresa
        SQLGUARDAR.Parameters.Add("@CLA", SqlDbType.VarChar).Value = TXTCLA.Text
        SQLGUARDAR.Parameters.Add("@NOM", SqlDbType.VarChar).Value = TXTNOM.Text
        SQLGUARDAR.Parameters.Add("@DES", SqlDbType.VarChar).Value = TXTNOM.Text
        SQLGUARDAR.Parameters.Add("@GRU", SqlDbType.Int).Value = CLAGRU(CBGRU.SelectedIndex)
        SQLGUARDAR.Parameters.Add("@PRE", SqlDbType.Float).Value = PG
        SQLGUARDAR.Parameters.Add("@SM", SqlDbType.Float).Value = 0
        SQLGUARDAR.Parameters.Add("@IMG", SqlDbType.VarChar).Value = TXTNOM.Text
        SQLGUARDAR.Parameters.Add("@UC", SqlDbType.VarChar).Value = CLAUC(CBUC.SelectedIndex)
        SQLGUARDAR.Parameters.Add("@UV", SqlDbType.VarChar).Value = CLAUV(CBUV.SelectedIndex)
        SQLGUARDAR.Parameters.Add("@US", SqlDbType.VarChar).Value = CLAUS(CBUS.SelectedIndex)
        SQLGUARDAR.Parameters.Add("@CP", SqlDbType.VarChar).Value = TXTCP.Text
        SQLGUARDAR.Parameters.Add("@NC", SqlDbType.VarChar).Value = TXTNOM.Text
        SQLGUARDAR.Parameters.Add("@SMAX", SqlDbType.Float).Value = 0
        SQLGUARDAR.Parameters.Add("@SG", SqlDbType.Int).Value = CLASG(CBSG.SelectedIndex)
        SQLGUARDAR.Parameters.Add("@PED", SqlDbType.VarChar).Value = TJ.Text

        If CHKCLN.Checked Then
            SQLGUARDAR.Parameters.Add("@PCPM", SqlDbType.Float).Value = TXTPCLN.Text
        Else
            SQLGUARDAR.Parameters.Add("@PCPM", SqlDbType.Float).Value = PG

        End If

        SQLGUARDAR.Parameters.Add("@POPM", SqlDbType.Float).Value = 0

        SQLGUARDAR.Parameters.Add("@PGVE", SqlDbType.Float).Value = 0


        If CHKGML.Checked Then
            SQLGUARDAR.Parameters.Add("@PGPM", SqlDbType.Float).Value = TXTPGML.Text
        Else
            SQLGUARDAR.Parameters.Add("@PGPM", SqlDbType.Float).Value = PG
        End If

        If CHKBOD.Checked Then
            SQLGUARDAR.Parameters.Add("@PBOD", SqlDbType.Float).Value = TXTPBOD.Text
        Else
            SQLGUARDAR.Parameters.Add("@PBOD", SqlDbType.Float).Value = PG
        End If


        SQLGUARDAR.Parameters.Add("@PMZT", SqlDbType.Float).Value = 0
        SQLGUARDAR.Parameters.Add("@PMIN", SqlDbType.Float).Value = 0
        SQLGUARDAR.Parameters.Add("@PMINOBR", SqlDbType.Float).Value = 0
        SQLGUARDAR.Parameters.Add("@PMINMZT", SqlDbType.Float).Value = 0
        SQLGUARDAR.Parameters.Add("@PESO", SqlDbType.Float).Value = TXTPESO.Text


        If RBC.Checked = True Then
            SQLGUARDAR.Parameters.Add("@TP", SqlDbType.VarChar).Value = "NACIONAL"
        Else
            SQLGUARDAR.Parameters.Add("@TP", SqlDbType.VarChar).Value = "IMPORTADO"
        End If

        If CBACT.SelectedIndex = 1 Then
            SQLGUARDAR.Parameters.Add("@ACT", SqlDbType.Bit).Value = 1
        Else
            SQLGUARDAR.Parameters.Add("@ACT", SqlDbType.Bit).Value = 0
        End If

        If CBSP.SelectedIndex = 0 Then
            SQLGUARDAR.Parameters.Add("@SP", SqlDbType.Bit).Value = 1
        Else
            SQLGUARDAR.Parameters.Add("@SP", SqlDbType.Bit).Value = 0
        End If

        If CBIVA.SelectedIndex = 0 Then
            SQLGUARDAR.Parameters.Add("@IVA", SqlDbType.Bit).Value = 1
        Else
            SQLGUARDAR.Parameters.Add("@IVA", SqlDbType.Bit).Value = 0
        End If

        SQLGUARDAR.Parameters.Add("@FIVA", SqlDbType.Int).Value = LFIVA(CBFIVA.SelectedIndex)
        SQLGUARDAR.Parameters.Add("@FIEPS", SqlDbType.Int).Value = LFIEPS(CBFIEPS.SelectedIndex)

        If TXTTIVA.Enabled Then
            SQLGUARDAR.Parameters.Add("@TIVA", SqlDbType.Float).Value = Me.TXTTIVA.Text
        Else
            SQLGUARDAR.Parameters.Add("@TIVA", SqlDbType.Float).Value = 0
        End If
        If TXTTCIEPS.Enabled Then
            SQLGUARDAR.Parameters.Add("@IEPS", SqlDbType.Float).Value = Me.TXTTCIEPS.Text
        Else
            SQLGUARDAR.Parameters.Add("@IEPS", SqlDbType.Float).Value = 0
        End If

        SQLGUARDAR.Parameters.Add("@PYSSAT", SqlDbType.VarChar).Value = Trim(TXTCPYSSAT.Text)

        SQLGUARDAR.CommandText = "SPPRODUCTOS"
        SQLGUARDAR.ExecuteNonQuery()
        GUARDARPED()
        Dim X As Integer
        Dim SQLPT As New SqlClient.SqlCommand("SPPRODUCTOSTIENDAS", frmPrincipal.CONX)
        SQLPT.Parameters.Add("@TI", SqlDbType.VarChar)
        SQLPT.Parameters.Add("@PRO", SqlDbType.VarChar).Value = TXTCLA.Text
        SQLPT.Parameters.Add("@ACT", SqlDbType.Bit)
        SQLPT.CommandType = CommandType.StoredProcedure
        For X = 0 To LEMP.Count - 1
            SQLPT.Parameters("@TI").Value = LEMP(X)
            If CLBEMP.GetItemChecked(X) Then
                SQLPT.Parameters("@ACT").Value = 1
            Else
                SQLPT.Parameters("@ACT").Value = 0
            End If
            SQLPT.ExecuteNonQuery()
        Next
        If PANT <> PG Then
            BDEjecutarSql("EXEC SPMODIFICACIONESPRECIOS '" + TXTCLA.Text + "','" + PANT.ToString + "','" + PG.ToString + "','" + frmPrincipal.Usuario + "'", frmPrincipal.CadenaConexion)
        End If
        GuardaPrecios()
        CHKBOD.Checked = False
        CHKCLN.Checked = False
        CHKGML.Checked = False
        TXTPBOD.Text = 0
        TXTPCLN.Text = 0
        TXTPGML.Text = 0

        MessageBox.Show("La información ha sido guardada correctamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        LIMPIAR()
        ACTIVAR(True)
    End Sub
    Private Sub GuardaPrecios()
        Dim X As Integer
        For X = 0 To DGV.RowCount - 1
            BDEjecutarSql("EXEC SPPRECIOSSUCURSALES '" + DGV.Item(3, X).Value + "','" + TXTCLA.Text + "','" + DGV.Item(1, X).Value.ToString + "','" + DGV.Item(2, X).Value.ToString + "'", frmPrincipal.CadenaConexion)
        Next
    End Sub
    Private Sub GUARDARPED()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SPPRODUCTOPEDIMENTO", frmPrincipal.CONX)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.Parameters.Add("@CLA", SqlDbType.VarChar).Value = TXTCLA.Text
        SQL.Parameters.Add("@EXP", SqlDbType.VarChar).Value = TA.Text
        SQL.Parameters.Add("@IMP", SqlDbType.VarChar).Value = TB.Text
        SQL.Parameters.Add("@DIR", SqlDbType.VarChar).Value = TC.Text
        SQL.Parameters.Add("@ORI", SqlDbType.VarChar).Value = TD.Text
        SQL.Parameters.Add("@ING", SqlDbType.VarChar).Value = TE.Text
        SQL.Parameters.Add("@SUG", SqlDbType.VarChar).Value = TF.Text
        SQL.Parameters.Add("@PRE", SqlDbType.VarChar).Value = TG.Text
        SQL.Parameters.Add("@INF", SqlDbType.VarChar).Value = TH.Text
        SQL.Parameters.Add("@IMPR", SqlDbType.VarChar).Value = TI.Text
        SQL.Parameters.Add("@PED", SqlDbType.VarChar).Value = TJ.Text
        SQL.ExecuteNonQuery()
    End Sub
    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        'frmClsBusqueda2Campos.BUSCAR("SELECT P.CLAVE CLAVE,P.NOMBRE,P.DESCRIPCION,G.NOMBRE GRUPO,P.PRECIO,P.ACTIVO FROM PRODUCTOS P INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE P.EMPRESA=" + frmPrincipal.Empresa + "  AND P.ACTIVO=1  ", " AND P.NOMBRE", "P.DESCRIPCION", " ORDER BY P.NOMBRE", "Búsqueda de Artículos", "Nombre o Descripción del Producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, False)
        'If frmClsBusqueda2Campos.DialogResult = Windows.Forms.DialogResult.Yes Then
        '    TXTCLA.Text = frmClsBusqueda2Campos.TREG.Rows(0).Item(0).ToString
        '    CARGADATOS()
        'End If

        frmClsBusqueda.BUSCAR("SELECT P.CLAVE CLAVE,P.NOMBRE,P.DESCRIPCION,G.NOMBRE GRUPO,P.PRECIO,P.ACTIVO FROM PRODUCTOS P INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE P.EMPRESA=" + frmPrincipal.Empresa, " AND P.NOMBRE", " ORDER BY P.NOMBRE", "Búsqueda de Productos", "Nombre del producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCLA.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
            CARGADATOS()
        End If
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim ABC As Double
        If TXTTIVA.Enabled Then
            Try
                ABC = CType(TXTTIVA.Text, Double)
                If ABC < 0 Then
                    MessageBox.Show("Tasa Iva No Válida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Exit Sub
                End If
                If ABC > 0.16 Then
                    MessageBox.Show("Tasa Iva No Válida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show("Tasa Iva No Válida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End Try
        End If

        If TXTTCIEPS.Enabled Then
            Try
                ABC = CType(TXTTCIEPS.Text, Double)
                If ABC < 0 Then
                    MessageBox.Show("Tasa IEPS No Válida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Exit Sub
                End If
                If ABC > 0.08 Then
                    MessageBox.Show("Tasa IEPS No Válida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show("Tasa IEPS No Válida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End Try
        End If

        GUARDAR()
        TXTCP.Text = ULTIMOPRODUCTO()
    End Sub

    Private Sub TXTPRE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub TXTCOS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
    Private Sub TXTSM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        BTNGUARDAR.Focus()
    End Sub
    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Esta seguro que desea eliminar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If xyz = 6 Then
            Try
                If Not frmPrincipal.CHECACONX() Then
                    Exit Sub
                End If
                Dim SQLELIMINAR As New SqlClient.SqlCommand
                SQLELIMINAR.Connection = frmPrincipal.CONX
                SQLELIMINAR.CommandText = "DELETE FROM PRODUCTOS WHERE CLAVE ='" + TXTCLA.Text + "' AND EMPRESA=" + frmPrincipal.Empresa + ""
                SQLELIMINAR.ExecuteNonQuery()
                MessageBox.Show("La información ha sido eliminada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show("El producto no se puede eliminar debido a que ya tiene alguna venta de ese producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'ex.Message.ToString()
                Exit Sub
            End Try
            LIMPIAR()
            ACTIVAR(True)

        End If
    End Sub

    Private Sub TXTNOM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOM.KeyPress, TXTDES.KeyPress, CBGRU.KeyPress, CBACT.KeyPress, TXTIMG.KeyPress, CBSP.KeyPress, CBUC.KeyPress, CBUV.KeyPress, CBUS.KeyPress, TXTNC.KeyPress, TXTSMAX.KeyPress, TXTSM.KeyPress, CBSG.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Function ULTIMOPRODUCTO() As String
        Dim REG As String
        REG = ""
        Try
            frmPrincipal.CHECACONX()
            Dim NUM As Integer
            NUM = 1
            Dim SQLMOV As New SqlClient.SqlCommand("SELECT DBO.SIGUIENTEPRODUCTO('" + frmPrincipal.Empresa + "')", frmPrincipal.CONX)
            Dim LECTOR As SqlClient.SqlDataReader
            LECTOR = SQLMOV.ExecuteReader
            If LECTOR.Read Then
                NUM = LECTOR(0)
                LECTOR.Close()
                REG = NUM.ToString
            Else
                LECTOR.Close()
            End If
        Catch ex As Exception
            Return 0
        End Try
        If REG.Length = 1 Then
            REG = REG.Insert(0, "0000")
        ElseIf REG.Length = 2 Then
            REG = REG.Insert(0, "000")
        ElseIf REG.Length = 3 Then
            REG = REG.Insert(0, "00")
        ElseIf REG.Length = 4 Then
            REG = REG.Insert(0, "0")
        End If
        Return REG



        'Dim SQL As New SqlClient.SqlCommand("SELECT MAX(CP)CLAVE FROM PRODUCTOS ", frmPrincipal.CONX)
        'Dim LEC As SqlClient.SqlDataReader
        'LEC = SQL.ExecuteReader
        'Dim NUM As Integer
        'If LEC.Read Then
        '    If LEC(0) Is DBNull.Value Then
        '        NUM = 1
        '        LEC.Close()
        '    Else
        '        NUM = LEC(0)
        '        NUM = NUM + 1
        '        LEC.Close()
        '    End If
        'Else
        '    LEC.Close()
        '    NUM = 1
        'End If

    End Function


    Private Sub RBC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBC.CheckedChanged
        If RBC.Checked = True Then
            ' TXTCODC.Enabled = True
        Else
            '  TXTCODC.Enabled = False
        End If
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CBIVA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIVA.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTSM.Focus()
        End If
    End Sub

    Private Sub Productos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Alt + Keys.G Then
            If TXTNOM.Enabled = False Then
                Exit Sub
            End If
            GUARDAR()
            TXTCP.Text = ULTIMOPRODUCTO()
        End If

        If e.KeyCode = Keys.Alt + Keys.E Then
            If BTNELIMINAR.Enabled = False Then
                Exit Sub
            End If
            Dim xyz As Short
            xyz = MessageBox.Show("¿Esta seguro que desea eliminar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xyz = 6 Then
                Try
                    If Not frmPrincipal.CHECACONX() Then
                        Exit Sub
                    End If
                    Dim SQLELIMINAR As New SqlClient.SqlCommand
                    SQLELIMINAR.Connection = frmPrincipal.CONX
                    SQLELIMINAR.CommandText = "DELETE FROM PRODUCTOS WHERE CLAVE ='" + TXTCLA.Text + "' AND EMPRESA=" + frmPrincipal.Empresa + ""
                    SQLELIMINAR.ExecuteNonQuery()
                    MessageBox.Show("La información ha sido eliminada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Catch ex As Exception
                    MessageBox.Show("El producto no se puede eliminar debido a que ya tiene alguna venta de ese producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'ex.Message.ToString()
                    Exit Sub
                End Try
                LIMPIAR()
                ACTIVAR(True)
                TXTCP.Text = ULTIMOPRODUCTO()
            End If
        End If

        If e.KeyCode = Keys.Alt + Keys.C Then
            LIMPIAR()
            ACTIVAR(True)
            LIMPIAR()
            TXTSM.Enabled = False
            TXTCP.Text = ULTIMOPRODUCTO()
        End If


        If e.KeyCode = Keys.Alt + Keys.B Then
            frmClsBusqueda.BUSCAR("SELECT P.CLAVE CLAVE,P.NOMBRE,G.NOMBRE GRUPO,P.PRECIO FROM PRODUCTOS P INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE P.EMPRESA=" + frmPrincipal.Empresa + "  ", " AND P.NOMBRE", " ORDER BY P.NOMBRE", "Búsqueda de Artículos", "Nombre del Producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, True)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                TXTCLA.Text = frmClsBusqueda.TREG.Rows(0).Item(0).ToString
                CARGADATOS()
            End If
        End If
    End Sub

    Private Sub Productos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Try
        '    capSetCallbackOnError(lwndC, VariantType.Null)
        '    capSetCallbackOnStatus(lwndC, VariantType.Null)
        '    capSetCallbackOnYield(lwndC, VariantType.Null)
        '    capSetCallbackOnFrame(lwndC, VariantType.Null)
        '    capSetCallbackOnVideoStream(lwndC, VariantType.Null)
        '    capSetCallbackOnWaveStream(lwndC, VariantType.Null)
        '    capSetCallbackOnCapControl(lwndC, VariantType.Null)
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub CAPTURARIMAGEN()
        'Dim data As IDataObject
        'Dim bmap As Bitmap

        'capEditCopy(lwndC)                  ' Llama a copiar la imagen al portapapeles
        'data = Clipboard.GetDataObject()    ' Obtiene la imagen del portapapeles
        'bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Bitmap) ' Lo comvierte a bmp
        'PB.Image = bmap
    End Sub
    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Private Sub GUARDARIMAGEN()
        CAPTURARIMAGEN()
        Dim SFD As New System.Windows.Forms.SaveFileDialog
        SFD.InitialDirectory = "C:\FOTOSPRICE"
        SFD.FileName = TXTIMG.Text + ".jpg"
        SFD.Filter = "Archivos de Imagen (*.jpg)|*.jpg|" + Chr(34) + "All files (*.*)|*.*;"
        If SFD.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                If System.IO.File.Exists(SFD.FileName) = True Then
                    System.IO.File.Delete(SFD.FileName)
                End If
            Catch ex As Exception
                MessageBox.Show("La informacion No se puede Guardar, Archivo en Uso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try

            'PB.Image.Save(SFD.FileName)


            'IMGTEM = PB.Image
            Dim IMGTEM As Image
            Dim myCallback As New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
            IMGTEM = PB.Image.GetThumbnailImage(112, 150, myCallback, IntPtr.Zero)
            IMGTEM.Save(SFD.FileName)

            MessageBox.Show("La imagen ha sido Guardada Exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
        SFD.Dispose()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGI.Click
        GUARDARIMAGEN()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim REP As New rptEtiquetaProducto

        Dim QUERY As String
        Dim DT As New DataTable
        Dim DTTEMP As New DataTable
        QUERY = "SELECT CLAVE,NOMBRECORTO,PM,CANTIDAD=1.00,CODIGO='' FROM PRODUCTOS WHERE CLAVE='" + TXTCLA.Text + "'"
        DTTEMP = New DataTable
        DT = New DataTable
        DT = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DTTEMP = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)

        DT.Rows.Clear()

        DT.Columns.RemoveAt(4)
        DT.Columns.Add("CODIGO", GetType(Byte()))

        Dim X As Integer
        Dim DR As DataRow

        For X = 0 To DTTEMP.Rows.Count - 1
            DR = DT.NewRow
            DR(0) = DTTEMP.Rows(X).Item(0)
            DR(1) = DTTEMP.Rows(X).Item(1)
            DR(2) = DTTEMP.Rows(X).Item(2)
            DR(3) = DTTEMP.Rows(X).Item(3)
            DR(4) = Image2Bytes(BarCode.CodeEAN13(DTTEMP.Rows(X).Item(0), True, 100, True, True))
            DT.Rows.Add(DR)
        Next
        MOSTRARREPORTE(REP, "Etiquetas Price Market" + TXTNOM.Text, DT, "")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim REP As New rptEtiquetaProducto

        Dim QUERY As String
        Dim DT As New DataTable
        Dim DTTEMP As New DataTable
        QUERY = "SELECT CLAVE,NOMBRECORTO,PM,CANTIDAD=1.00,CODIGO='' FROM PRODUCTOS WHERE CLAVE='" + TXTCLA.Text + "'"
        DTTEMP = New DataTable
        DT = New DataTable
        DT = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DTTEMP = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)

        DT.Rows.Clear()

        DT.Columns.RemoveAt(4)
        DT.Columns.Add("CODIGO", GetType(Byte()))

        Dim X As Integer
        Dim DR As DataRow
        Dim IMG As Image
        For X = 0 To DTTEMP.Rows.Count - 1
            DR = DT.NewRow
            DR(0) = DTTEMP.Rows(X).Item(0)
            DR(1) = DTTEMP.Rows(X).Item(1)
            DR(2) = DTTEMP.Rows(X).Item(2)
            DR(3) = DTTEMP.Rows(X).Item(3)
            IMG = BarCode.CodeEAN13AutoGenerateChecksum(DTTEMP.Rows(X).Item(0), True, 100, True, True)
            IMG.RotateFlip(RotateFlipType.Rotate90FlipX)
            DR(4) = Image2Bytes(IMG)
            DT.Rows.Add(DR)
        Next

        MOSTRARREPORTE(REP, "Etiquetas Price Market" + TXTNOM.Text, DT, "")

    End Sub

    Private Sub CBFIVA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBFIVA.SelectedIndexChanged
        TXTTIVA.Enabled = False
        If LFIVA(CBFIVA.SelectedIndex) = "1" Then
            TXTTIVA.Enabled = True
        End If
    End Sub

    Private Sub CBFIEPS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBFIEPS.SelectedIndexChanged
        TXTTCIEPS.Enabled = False
        If LFIEPS(CBFIEPS.SelectedIndex) = "1" Or LFIEPS(CBFIEPS.SelectedIndex) = "2" Then
            TXTTCIEPS.Enabled = True
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://200.57.3.46:443/PyS/catPyS.aspx")
    End Sub

    Private Sub BTNARCHIVO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNARCHIVO.Click
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
            URL = ofd.FileName
            Dim fs As System.IO.FileStream
            ' Specify a valid picture file path on your computer.
            fs = New System.IO.FileStream(URL, IO.FileMode.Open, IO.FileAccess.Read)
            PB.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()
            PB.Refresh()
            'Me.PBEMP.Image = Bitmap.FromFile(ofd.FileName)
            GUARDARFOTO()
            SUBIRFOTO()
        End If
    End Sub
    Private Sub GUARDARFOTO()
        Dim UBI As String
        UBI = "C:\FOTOSPRICE\" + TXTCP.Text + ".JPG"
        If Not IO.Directory.Exists("C:\FOTOSPRICE") Then
            IO.Directory.CreateDirectory("C:\FOTOSPRICE")
        End If
        'PBEMP.Image = Nothing
        'PBEMP.ImageLocation = Nothing
        'Try
        '    System.IO.File.Delete("c:\borrame.jpg")
        '    System.IO.File.Move(UBI, "c:\borrame.jpg")
        'Catch ex As Exception
        '    'MessageBox.Show("No se puede Eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        'End Try        
        Try
            Dim oNewImage As System.Drawing.Image
            Dim bmp As Bitmap = New Bitmap(PB.Image)
            oNewImage = bmp.GetThumbnailImage(221, 252, Nothing, IntPtr.Zero)
            oNewImage.Save(UBI, System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            'MessageBox.Show("No se pudo cargar la foto, esta en uso, favor de intentar de nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'Exit Sub
        End Try
        PB.ImageLocation = UBI
        'MessageBox.Show("Imagen Guardada Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub
    Private Sub SUBIRFOTO()
        Dim UBI As String
        UBI = "C:\FOTOSPRICE\" + TXTCP.Text + ".JPG"
        Dim LOCA As String
        LOCA = "ftp://" + frmPrincipal.IP + "/inetpub/wwwroot/FOTOSPRICE/" + TXTCP.Text + ".jpg"
        Try
            My.Computer.Network.UploadFile(UBI, LOCA, "omar", "final", True, 500, FileIO.UICancelOption.DoNothing)
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub BTNRESET_Click(sender As Object, e As EventArgs) Handles BTNRESET.Click
        Try
            BDEjecutarSql("exec spresetpreciosclientes '" + TXTCLA.Text + "'", frmPrincipal.CadenaConexion)
            OPMsgOK("Precios de clientes reestablecidos")
        Catch ex As Exception
            OPMsgError("Error: " + ex.Message)
        End Try
    End Sub

    Private Sub TXTNOM_TextChanged(sender As Object, e As EventArgs) Handles TXTNOM.TextChanged
        LBLPROD.Text = TXTNOM.Text
    End Sub
End Class