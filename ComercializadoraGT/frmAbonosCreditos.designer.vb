<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbonosCreditos
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbonosCreditos))
        Me.TXTCLI = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.TXTRESTA = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TXTABONO = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CBTP = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.TXTTOT = New System.Windows.Forms.TextBox
        Me.LBLNCLI = New System.Windows.Forms.Label
        Me.LBLTRPP = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.BTNCONSUMO = New System.Windows.Forms.Button
        Me.RBAN = New System.Windows.Forms.RadioButton
        Me.RBAC = New System.Windows.Forms.RadioButton
        Me.BTNBUSCAR = New System.Windows.Forms.Button
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        Me.TXTNOTA = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CHKCE = New System.Windows.Forms.CheckBox
        Me.LBLTP = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.DTDE = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.BTNFACTURAR = New System.Windows.Forms.Button
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TXTCLI
        '
        Me.TXTCLI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLI.Location = New System.Drawing.Point(30, 45)
        Me.TXTCLI.MaxLength = 10
        Me.TXTCLI.Name = "TXTCLI"
        Me.TXTCLI.Size = New System.Drawing.Size(142, 26)
        Me.TXTCLI.TabIndex = 1047
        Me.TXTCLI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 1046
        Me.Label2.Text = "Cliente"
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(12, 372)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGV2.Size = New System.Drawing.Size(892, 154)
        Me.DGV2.TabIndex = 1069
        '
        'TXTRESTA
        '
        Me.TXTRESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTRESTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRESTA.Location = New System.Drawing.Point(12, 608)
        Me.TXTRESTA.MaxLength = 30
        Me.TXTRESTA.Name = "TXTRESTA"
        Me.TXTRESTA.ReadOnly = True
        Me.TXTRESTA.Size = New System.Drawing.Size(142, 26)
        Me.TXTRESTA.TabIndex = 1067
        Me.TXTRESTA.Text = "0"
        Me.TXTRESTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 589)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 16)
        Me.Label11.TabIndex = 1068
        Me.Label11.Text = "Resta por Pagar"
        '
        'TXTABONO
        '
        Me.TXTABONO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTABONO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTABONO.Location = New System.Drawing.Point(12, 560)
        Me.TXTABONO.MaxLength = 30
        Me.TXTABONO.Name = "TXTABONO"
        Me.TXTABONO.ReadOnly = True
        Me.TXTABONO.Size = New System.Drawing.Size(142, 26)
        Me.TXTABONO.TabIndex = 1065
        Me.TXTABONO.Text = "0"
        Me.TXTABONO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 541)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 16)
        Me.Label10.TabIndex = 1066
        Me.Label10.Text = "Abono/Pago"
        '
        'CBTP
        '
        Me.CBTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTP.FormattingEnabled = True
        Me.CBTP.Location = New System.Drawing.Point(445, 563)
        Me.CBTP.Name = "CBTP"
        Me.CBTP.Size = New System.Drawing.Size(194, 24)
        Me.CBTP.TabIndex = 1070
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(485, 541)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(103, 16)
        Me.Label18.TabIndex = 1071
        Me.Label18.Text = "Tipo de Pago"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(12, 155)
        Me.DGV.Name = "DGV"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DGV.Size = New System.Drawing.Size(892, 154)
        Me.DGV.TabIndex = 1075
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(179, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 16)
        Me.Label1.TabIndex = 1076
        Me.Label1.Text = "Notas de Credito sin Saldar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(179, 353)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(194, 16)
        Me.Label3.TabIndex = 1077
        Me.Label3.Text = "Abonos/Pagos Realizados"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(641, 323)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 16)
        Me.Label16.TabIndex = 1079
        Me.Label16.Text = "Total"
        '
        'TXTTOT
        '
        Me.TXTTOT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOT.Location = New System.Drawing.Point(691, 317)
        Me.TXTTOT.MaxLength = 5
        Me.TXTTOT.Name = "TXTTOT"
        Me.TXTTOT.ReadOnly = True
        Me.TXTTOT.Size = New System.Drawing.Size(106, 26)
        Me.TXTTOT.TabIndex = 1078
        Me.TXTTOT.Text = "0"
        Me.TXTTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLNCLI
        '
        Me.LBLNCLI.AutoSize = True
        Me.LBLNCLI.BackColor = System.Drawing.Color.Transparent
        Me.LBLNCLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNCLI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLNCLI.Location = New System.Drawing.Point(27, 96)
        Me.LBLNCLI.Name = "LBLNCLI"
        Me.LBLNCLI.Size = New System.Drawing.Size(191, 24)
        Me.LBLNCLI.TabIndex = 1080
        Me.LBLNCLI.Text = "Nombre del Cliente"
        '
        'LBLTRPP
        '
        Me.LBLTRPP.AutoSize = True
        Me.LBLTRPP.BackColor = System.Drawing.Color.Transparent
        Me.LBLTRPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTRPP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLTRPP.Location = New System.Drawing.Point(661, 96)
        Me.LBLTRPP.Name = "LBLTRPP"
        Me.LBLTRPP.Size = New System.Drawing.Size(49, 24)
        Me.LBLTRPP.TabIndex = 1081
        Me.LBLTRPP.Text = "0.00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(662, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 16)
        Me.Label5.TabIndex = 1082
        Me.Label5.Text = "Total Resta por Pagar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(31, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 16)
        Me.Label6.TabIndex = 1083
        Me.Label6.Text = "Nombre del Cliente"
        '
        'BTNCONSUMO
        '
        Me.BTNCONSUMO.BackColor = System.Drawing.SystemColors.Control
        Me.BTNCONSUMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCONSUMO.Location = New System.Drawing.Point(553, 314)
        Me.BTNCONSUMO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCONSUMO.Name = "BTNCONSUMO"
        Me.BTNCONSUMO.Size = New System.Drawing.Size(55, 35)
        Me.BTNCONSUMO.TabIndex = 1143
        Me.BTNCONSUMO.Text = "..."
        Me.BTNCONSUMO.UseVisualStyleBackColor = False
        '
        'RBAN
        '
        Me.RBAN.AutoSize = True
        Me.RBAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBAN.Location = New System.Drawing.Point(471, 608)
        Me.RBAN.Name = "RBAN"
        Me.RBAN.Size = New System.Drawing.Size(137, 24)
        Me.RBAN.TabIndex = 1144
        Me.RBAN.Text = "Abono a Nota"
        Me.RBAN.UseVisualStyleBackColor = True
        Me.RBAN.Visible = False
        '
        'RBAC
        '
        Me.RBAC.AutoSize = True
        Me.RBAC.Checked = True
        Me.RBAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBAC.Location = New System.Drawing.Point(471, 630)
        Me.RBAC.Name = "RBAC"
        Me.RBAC.Size = New System.Drawing.Size(163, 24)
        Me.RBAC.TabIndex = 1145
        Me.RBAC.TabStop = True
        Me.RBAC.Text = "Abonar a Credito"
        Me.RBAC.UseVisualStyleBackColor = True
        Me.RBAC.Visible = False
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.Location = New System.Drawing.Point(503, 13)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(85, 77)
        Me.BTNBUSCAR.TabIndex = 1074
        Me.BTNBUSCAR.Text = "&b"
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(818, 560)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 1073
        Me.BTNCANCELAR.Text = "&C"
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(706, 560)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 1072
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'TXTNOTA
        '
        Me.TXTNOTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNOTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOTA.Location = New System.Drawing.Point(644, 45)
        Me.TXTNOTA.MaxLength = 10
        Me.TXTNOTA.Name = "TXTNOTA"
        Me.TXTNOTA.ReadOnly = True
        Me.TXTNOTA.Size = New System.Drawing.Size(142, 26)
        Me.TXTNOTA.TabIndex = 1147
        Me.TXTNOTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(641, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 16)
        Me.Label4.TabIndex = 1146
        Me.Label4.Text = "Nota"
        '
        'CHKCE
        '
        Me.CHKCE.AutoSize = True
        Me.CHKCE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKCE.Location = New System.Drawing.Point(210, 560)
        Me.CHKCE.Name = "CHKCE"
        Me.CHKCE.Size = New System.Drawing.Size(144, 24)
        Me.CHKCE.TabIndex = 1148
        Me.CHKCE.Text = "Serv. Adic. 2%"
        Me.CHKCE.UseVisualStyleBackColor = True
        Me.CHKCE.Visible = False
        '
        'LBLTP
        '
        Me.LBLTP.AutoSize = True
        Me.LBLTP.BackColor = System.Drawing.Color.Transparent
        Me.LBLTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTP.Location = New System.Drawing.Point(207, 618)
        Me.LBLTP.Name = "LBLTP"
        Me.LBLTP.Size = New System.Drawing.Size(135, 16)
        Me.LBLTP.TabIndex = 1149
        Me.LBLTP.Text = "Abono/Pago Total"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(207, 590)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(135, 16)
        Me.Label7.TabIndex = 1150
        Me.Label7.Text = "Abono/Pago Total"
        '
        'DTDE
        '
        Me.DTDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTDE.Location = New System.Drawing.Point(267, 45)
        Me.DTDE.Name = "DTDE"
        Me.DTDE.Size = New System.Drawing.Size(156, 26)
        Me.DTDE.TabIndex = 1259
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(275, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 20)
        Me.Label8.TabIndex = 1258
        Me.Label8.Text = "Fecha Pago:"
        '
        'BTNFACTURAR
        '
        Me.BTNFACTURAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNFACTURAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNFACTURAR.ForeColor = System.Drawing.Color.Black
        Me.BTNFACTURAR.Location = New System.Drawing.Point(761, 115)
        Me.BTNFACTURAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNFACTURAR.Name = "BTNFACTURAR"
        Me.BTNFACTURAR.Size = New System.Drawing.Size(137, 33)
        Me.BTNFACTURAR.TabIndex = 1294
        Me.BTNFACTURAR.Text = "Facturar"
        Me.BTNFACTURAR.UseVisualStyleBackColor = False
        '
        'frmAbonosCreditos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 666)
        Me.Controls.Add(Me.BTNFACTURAR)
        Me.Controls.Add(Me.DTDE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LBLTP)
        Me.Controls.Add(Me.CHKCE)
        Me.Controls.Add(Me.TXTNOTA)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RBAC)
        Me.Controls.Add(Me.RBAN)
        Me.Controls.Add(Me.BTNCONSUMO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LBLTRPP)
        Me.Controls.Add(Me.LBLNCLI)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TXTTOT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.CBTP)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.TXTRESTA)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TXTABONO)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TXTCLI)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbonosCreditos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Abonos /  Pagos de Notas de Créditos"
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXTCLI As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents TXTRESTA As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TXTABONO As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CBTP As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TXTTOT As System.Windows.Forms.TextBox
    Friend WithEvents LBLNCLI As System.Windows.Forms.Label
    Friend WithEvents LBLTRPP As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents BTNCONSUMO As System.Windows.Forms.Button
    Friend WithEvents RBAN As System.Windows.Forms.RadioButton
    Friend WithEvents RBAC As System.Windows.Forms.RadioButton
    Friend WithEvents TXTNOTA As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CHKCE As System.Windows.Forms.CheckBox
    Friend WithEvents LBLTP As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DTDE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BTNFACTURAR As System.Windows.Forms.Button
End Class
