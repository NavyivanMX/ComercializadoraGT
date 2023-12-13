<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturas))
        Me.Button1 = New System.Windows.Forms.Button
        Me.BTNAGREGAR = New System.Windows.Forms.Button
        Me.TXTNOTA = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TXTLETRA = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TXTTOT = New System.Windows.Forms.TextBox
        Me.TXTIVA = New System.Windows.Forms.TextBox
        Me.TXTSUB = New System.Windows.Forms.TextBox
        Me.TXTCLI = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CBRFC = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TXTNFIS = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TXTDFIS = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TXTRFC = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TXTCD = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TXTCP = New System.Windows.Forms.TextBox
        Me.TXTFAC = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        Me.BTNBUSCAR = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.TXTNCLI = New System.Windows.Forms.TextBox
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.DTDE = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.RBNOTA = New System.Windows.Forms.RadioButton
        Me.RBCREDITO = New System.Windows.Forms.RadioButton
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(568, 242)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 36)
        Me.Button1.TabIndex = 1046
        Me.Button1.Text = "-"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'BTNAGREGAR
        '
        Me.BTNAGREGAR.BackColor = System.Drawing.Color.Green
        Me.BTNAGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNAGREGAR.ForeColor = System.Drawing.Color.Black
        Me.BTNAGREGAR.Location = New System.Drawing.Point(501, 242)
        Me.BTNAGREGAR.Name = "BTNAGREGAR"
        Me.BTNAGREGAR.Size = New System.Drawing.Size(60, 36)
        Me.BTNAGREGAR.TabIndex = 1045
        Me.BTNAGREGAR.Text = "+"
        Me.BTNAGREGAR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNAGREGAR.UseVisualStyleBackColor = False
        '
        'TXTNOTA
        '
        Me.TXTNOTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNOTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOTA.Location = New System.Drawing.Point(338, 248)
        Me.TXTNOTA.MaxLength = 10
        Me.TXTNOTA.Name = "TXTNOTA"
        Me.TXTNOTA.Size = New System.Drawing.Size(129, 26)
        Me.TXTNOTA.TabIndex = 1043
        Me.TXTNOTA.Text = "0"
        Me.TXTNOTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(290, 255)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 1044
        Me.Label1.Text = "Nota"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.DGV.Location = New System.Drawing.Point(34, 293)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.Size = New System.Drawing.Size(594, 285)
        Me.DGV.TabIndex = 1047
        '
        'Column6
        '
        Me.Column6.HeaderText = "Nota"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 50
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Descripcion"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Cantidad"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Precio"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 80
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.HeaderText = "Total"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'TXTLETRA
        '
        Me.TXTLETRA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTLETRA.Enabled = False
        Me.TXTLETRA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLETRA.Location = New System.Drawing.Point(18, 614)
        Me.TXTLETRA.MaxLength = 10
        Me.TXTLETRA.Name = "TXTLETRA"
        Me.TXTLETRA.Size = New System.Drawing.Size(653, 26)
        Me.TXTLETRA.TabIndex = 1048
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(151, 595)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 16)
        Me.Label2.TabIndex = 1049
        Me.Label2.Text = "Cantidad Con Letra"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(680, 416)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 16)
        Me.Label8.TabIndex = 1055
        Me.Label8.Text = "Total"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(680, 374)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 16)
        Me.Label7.TabIndex = 1054
        Me.Label7.Text = "I.V.A."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(649, 332)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 1053
        Me.Label5.Text = "Sub Total"
        '
        'TXTTOT
        '
        Me.TXTTOT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOT.Location = New System.Drawing.Point(742, 410)
        Me.TXTTOT.MaxLength = 50
        Me.TXTTOT.Name = "TXTTOT"
        Me.TXTTOT.ReadOnly = True
        Me.TXTTOT.Size = New System.Drawing.Size(130, 26)
        Me.TXTTOT.TabIndex = 1052
        Me.TXTTOT.Text = "0"
        Me.TXTTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTIVA
        '
        Me.TXTIVA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIVA.Location = New System.Drawing.Point(742, 368)
        Me.TXTIVA.MaxLength = 50
        Me.TXTIVA.Name = "TXTIVA"
        Me.TXTIVA.ReadOnly = True
        Me.TXTIVA.Size = New System.Drawing.Size(130, 26)
        Me.TXTIVA.TabIndex = 1051
        Me.TXTIVA.Text = "0"
        Me.TXTIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSUB
        '
        Me.TXTSUB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSUB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUB.Location = New System.Drawing.Point(742, 326)
        Me.TXTSUB.MaxLength = 50
        Me.TXTSUB.Name = "TXTSUB"
        Me.TXTSUB.ReadOnly = True
        Me.TXTSUB.Size = New System.Drawing.Size(130, 26)
        Me.TXTSUB.TabIndex = 1050
        Me.TXTSUB.Text = "0"
        Me.TXTSUB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCLI
        '
        Me.TXTCLI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLI.Location = New System.Drawing.Point(67, 22)
        Me.TXTCLI.MaxLength = 10
        Me.TXTCLI.Name = "TXTCLI"
        Me.TXTCLI.Size = New System.Drawing.Size(68, 26)
        Me.TXTCLI.TabIndex = 0
        Me.TXTCLI.Text = "0"
        Me.TXTCLI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 1057
        Me.Label3.Text = "Cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(205, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 16)
        Me.Label4.TabIndex = 1058
        Me.Label4.Text = "Datos"
        '
        'CBRFC
        '
        Me.CBRFC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBRFC.FormattingEnabled = True
        Me.CBRFC.Location = New System.Drawing.Point(270, 25)
        Me.CBRFC.Name = "CBRFC"
        Me.CBRFC.Size = New System.Drawing.Size(381, 24)
        Me.CBRFC.TabIndex = 1059
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 16)
        Me.Label6.TabIndex = 1061
        Me.Label6.Text = "Nombre Fiscal"
        '
        'TXTNFIS
        '
        Me.TXTNFIS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNFIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNFIS.Location = New System.Drawing.Point(18, 152)
        Me.TXTNFIS.MaxLength = 50
        Me.TXTNFIS.Name = "TXTNFIS"
        Me.TXTNFIS.ReadOnly = True
        Me.TXTNFIS.Size = New System.Drawing.Size(638, 26)
        Me.TXTNFIS.TabIndex = 1060
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 190)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 16)
        Me.Label9.TabIndex = 1063
        Me.Label9.Text = "Dirección Fiscal"
        '
        'TXTDFIS
        '
        Me.TXTDFIS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDFIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDFIS.Location = New System.Drawing.Point(18, 215)
        Me.TXTDFIS.MaxLength = 50
        Me.TXTDFIS.Name = "TXTDFIS"
        Me.TXTDFIS.ReadOnly = True
        Me.TXTDFIS.Size = New System.Drawing.Size(638, 26)
        Me.TXTDFIS.TabIndex = 1062
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(680, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 16)
        Me.Label10.TabIndex = 1065
        Me.Label10.Text = "R.F.C."
        '
        'TXTRFC
        '
        Me.TXTRFC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRFC.Location = New System.Drawing.Point(677, 115)
        Me.TXTRFC.MaxLength = 50
        Me.TXTRFC.Name = "TXTRFC"
        Me.TXTRFC.ReadOnly = True
        Me.TXTRFC.Size = New System.Drawing.Size(220, 26)
        Me.TXTRFC.TabIndex = 1064
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(674, 144)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 16)
        Me.Label11.TabIndex = 1067
        Me.Label11.Text = "Ciudad"
        '
        'TXTCD
        '
        Me.TXTCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCD.Location = New System.Drawing.Point(677, 163)
        Me.TXTCD.MaxLength = 50
        Me.TXTCD.Name = "TXTCD"
        Me.TXTCD.ReadOnly = True
        Me.TXTCD.Size = New System.Drawing.Size(220, 26)
        Me.TXTCD.TabIndex = 1066
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(674, 191)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 16)
        Me.Label12.TabIndex = 1069
        Me.Label12.Text = "Código Postal"
        '
        'TXTCP
        '
        Me.TXTCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCP.Location = New System.Drawing.Point(677, 210)
        Me.TXTCP.MaxLength = 50
        Me.TXTCP.Name = "TXTCP"
        Me.TXTCP.ReadOnly = True
        Me.TXTCP.Size = New System.Drawing.Size(220, 26)
        Me.TXTCP.TabIndex = 1068
        '
        'TXTFAC
        '
        Me.TXTFAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFAC.Location = New System.Drawing.Point(780, 13)
        Me.TXTFAC.MaxLength = 10
        Me.TXTFAC.Name = "TXTFAC"
        Me.TXTFAC.Size = New System.Drawing.Size(140, 26)
        Me.TXTFAC.TabIndex = 1070
        Me.TXTFAC.Text = "1"
        Me.TXTFAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(686, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 16)
        Me.Label13.TabIndex = 1071
        Me.Label13.Text = "No. Factura"
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(677, 498)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 1072
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.Location = New System.Drawing.Point(141, 22)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(43, 26)
        Me.BTNBUSCAR.TabIndex = 1073
        Me.BTNBUSCAR.Text = "..."
        Me.BTNBUSCAR.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(15, 58)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(115, 16)
        Me.Label14.TabIndex = 1075
        Me.Label14.Text = "Nombre Cliente"
        '
        'TXTNCLI
        '
        Me.TXTNCLI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNCLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNCLI.Location = New System.Drawing.Point(18, 77)
        Me.TXTNCLI.MaxLength = 50
        Me.TXTNCLI.Name = "TXTNCLI"
        Me.TXTNCLI.ReadOnly = True
        Me.TXTNCLI.Size = New System.Drawing.Size(638, 26)
        Me.TXTNCLI.TabIndex = 1074
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(792, 498)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 1076
        Me.BTNCANCELAR.Text = "&c"
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'DTDE
        '
        Me.DTDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTDE.Location = New System.Drawing.Point(780, 45)
        Me.DTDE.Name = "DTDE"
        Me.DTDE.Size = New System.Drawing.Size(140, 29)
        Me.DTDE.TabIndex = 1093
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(723, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 16)
        Me.Label15.TabIndex = 1094
        Me.Label15.Text = "Fecha"
        '
        'RBNOTA
        '
        Me.RBNOTA.AutoSize = True
        Me.RBNOTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBNOTA.Location = New System.Drawing.Point(34, 254)
        Me.RBNOTA.Name = "RBNOTA"
        Me.RBNOTA.Size = New System.Drawing.Size(59, 20)
        Me.RBNOTA.TabIndex = 1095
        Me.RBNOTA.TabStop = True
        Me.RBNOTA.Text = "Nota"
        Me.RBNOTA.UseVisualStyleBackColor = True
        '
        'RBCREDITO
        '
        Me.RBCREDITO.AutoSize = True
        Me.RBCREDITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBCREDITO.Location = New System.Drawing.Point(154, 254)
        Me.RBCREDITO.Name = "RBCREDITO"
        Me.RBCREDITO.Size = New System.Drawing.Size(76, 20)
        Me.RBCREDITO.TabIndex = 1096
        Me.RBCREDITO.TabStop = True
        Me.RBCREDITO.Text = "Crédito"
        Me.RBCREDITO.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(726, 255)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 52)
        Me.Button2.TabIndex = 1097
        Me.Button2.Text = "Clientes"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 676)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.RBCREDITO)
        Me.Controls.Add(Me.RBNOTA)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.DTDE)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TXTNCLI)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.TXTFAC)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TXTCP)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TXTCD)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TXTRFC)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TXTDFIS)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TXTNFIS)
        Me.Controls.Add(Me.CBRFC)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTCLI)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXTTOT)
        Me.Controls.Add(Me.TXTIVA)
        Me.Controls.Add(Me.TXTSUB)
        Me.Controls.Add(Me.TXTLETRA)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BTNAGREGAR)
        Me.Controls.Add(Me.TXTNOTA)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFacturas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturas"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BTNAGREGAR As System.Windows.Forms.Button
    Friend WithEvents TXTNOTA As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXTLETRA As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTTOT As System.Windows.Forms.TextBox
    Friend WithEvents TXTIVA As System.Windows.Forms.TextBox
    Friend WithEvents TXTSUB As System.Windows.Forms.TextBox
    Friend WithEvents TXTCLI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CBRFC As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTNFIS As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXTDFIS As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTRFC As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TXTCD As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTCP As System.Windows.Forms.TextBox
    Friend WithEvents TXTFAC As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TXTNCLI As System.Windows.Forms.TextBox
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents DTDE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents RBNOTA As System.Windows.Forms.RadioButton
    Friend WithEvents RBCREDITO As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
