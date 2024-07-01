<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepositos
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepositos))
        Me.CBCAJA = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.DTFECHADIA = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TXTFICHA = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CBBANCO = New System.Windows.Forms.ComboBox
        Me.DTHORA = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXTCANT = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CBCUENTAS = New System.Windows.Forms.ComboBox
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.DTHASTA = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        Me.BTNQUITAR = New System.Windows.Forms.Button
        Me.BTNCONF = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LBLCE = New System.Windows.Forms.Label
        Me.LBLCD = New System.Windows.Forms.Label
        Me.LBLCC = New System.Windows.Forms.Label
        Me.LBLCB = New System.Windows.Forms.Label
        Me.LBLCA = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.LBLE = New System.Windows.Forms.Label
        Me.LBLD = New System.Windows.Forms.Label
        Me.LBLC = New System.Windows.Forms.Label
        Me.LBLB = New System.Windows.Forms.Label
        Me.LBLA = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.LBLTE = New System.Windows.Forms.Label
        Me.LBLTD = New System.Windows.Forms.Label
        Me.LBLTC = New System.Windows.Forms.Label
        Me.LBLTB = New System.Windows.Forms.Label
        Me.LBLTA = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.LBLTG = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.LBLTDEP = New System.Windows.Forms.Label
        Me.LBLDIF = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.LBLVN = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBCAJA
        '
        Me.CBCAJA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCAJA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCAJA.FormattingEnabled = True
        Me.CBCAJA.Items.AddRange(New Object() {"1", "2", "3"})
        Me.CBCAJA.Location = New System.Drawing.Point(861, 97)
        Me.CBCAJA.Name = "CBCAJA"
        Me.CBCAJA.Size = New System.Drawing.Size(112, 25)
        Me.CBCAJA.TabIndex = 1075
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(768, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 17)
        Me.Label9.TabIndex = 1074
        Me.Label9.Text = "Venta Caja"
        '
        'DTFECHADIA
        '
        Me.DTFECHADIA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFECHADIA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHADIA.Location = New System.Drawing.Point(822, 15)
        Me.DTFECHADIA.Name = "DTFECHADIA"
        Me.DTFECHADIA.Size = New System.Drawing.Size(134, 25)
        Me.DTFECHADIA.TabIndex = 1072
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(659, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(155, 17)
        Me.Label8.TabIndex = 1071
        Me.Label8.Text = "Depósito para el Día"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(402, 98)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 17)
        Me.Label7.TabIndex = 1070
        Me.Label7.Text = "Ficha"
        '
        'TXTFICHA
        '
        Me.TXTFICHA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFICHA.Location = New System.Drawing.Point(458, 95)
        Me.TXTFICHA.Name = "TXTFICHA"
        Me.TXTFICHA.Size = New System.Drawing.Size(273, 25)
        Me.TXTFICHA.TabIndex = 1069
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(605, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 17)
        Me.Label6.TabIndex = 1068
        Me.Label6.Text = "Banco"
        '
        'CBBANCO
        '
        Me.CBBANCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBBANCO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBBANCO.FormattingEnabled = True
        Me.CBBANCO.Items.AddRange(New Object() {"Andrés López Domínguez", "Moditelas del Pacífico SA de CV", "Ma. Elisa Carballo Grijalba", "Andrés López Camargo"})
        Me.CBBANCO.Location = New System.Drawing.Point(667, 58)
        Me.CBBANCO.Name = "CBBANCO"
        Me.CBBANCO.Size = New System.Drawing.Size(230, 25)
        Me.CBBANCO.TabIndex = 1067
        '
        'DTHORA
        '
        Me.DTHORA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTHORA.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTHORA.Location = New System.Drawing.Point(436, 13)
        Me.DTHORA.Name = "DTHORA"
        Me.DTHORA.ShowUpDown = True
        Me.DTHORA.Size = New System.Drawing.Size(158, 25)
        Me.DTHORA.TabIndex = 1066
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(355, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 17)
        Me.Label5.TabIndex = 1065
        Me.Label5.Text = "Hora Dep"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(31, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 1064
        Me.Label4.Text = "Cantidad"
        '
        'TXTCANT
        '
        Me.TXTCANT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT.Location = New System.Drawing.Point(110, 95)
        Me.TXTCANT.Name = "TXTCANT"
        Me.TXTCANT.Size = New System.Drawing.Size(242, 25)
        Me.TXTCANT.TabIndex = 1063
        Me.TXTCANT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 17)
        Me.Label2.TabIndex = 1062
        Me.Label2.Text = "Cuenta"
        '
        'CBCUENTAS
        '
        Me.CBCUENTAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCUENTAS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCUENTAS.FormattingEnabled = True
        Me.CBCUENTAS.Location = New System.Drawing.Point(110, 58)
        Me.CBCUENTAS.Name = "CBCUENTAS"
        Me.CBCUENTAS.Size = New System.Drawing.Size(413, 25)
        Me.CBCUENTAS.TabIndex = 1061
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(29, 140)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DGV.Size = New System.Drawing.Size(878, 258)
        Me.DGV.TabIndex = 1059
        '
        'DTHASTA
        '
        Me.DTHASTA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTHASTA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTHASTA.Location = New System.Drawing.Point(144, 14)
        Me.DTHASTA.Name = "DTHASTA"
        Me.DTHASTA.Size = New System.Drawing.Size(134, 25)
        Me.DTHASTA.TabIndex = 1057
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 17)
        Me.Label1.TabIndex = 1056
        Me.Label1.Text = "Fecha Dep"
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(928, 180)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 1107
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'BTNQUITAR
        '
        Me.BTNQUITAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNQUITAR.Image = CType(resources.GetObject("BTNQUITAR.Image"), System.Drawing.Image)
        Me.BTNQUITAR.Location = New System.Drawing.Point(928, 291)
        Me.BTNQUITAR.Name = "BTNQUITAR"
        Me.BTNQUITAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNQUITAR.TabIndex = 1106
        '
        'BTNCONF
        '
        Me.BTNCONF.BackColor = System.Drawing.SystemColors.Control
        Me.BTNCONF.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCONF.ForeColor = System.Drawing.Color.Transparent
        Me.BTNCONF.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.button_ok
        Me.BTNCONF.Location = New System.Drawing.Point(928, 450)
        Me.BTNCONF.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCONF.Name = "BTNCONF"
        Me.BTNCONF.Size = New System.Drawing.Size(80, 80)
        Me.BTNCONF.TabIndex = 1113
        Me.BTNCONF.Text = "&G"
        Me.BTNCONF.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(37, 460)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 17)
        Me.Label15.TabIndex = 1557
        Me.Label15.Text = "Cobranza"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(37, 401)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 17)
        Me.Label3.TabIndex = 1556
        Me.Label3.Text = "Contado"
        '
        'LBLCE
        '
        Me.LBLCE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLCE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LBLCE.Location = New System.Drawing.Point(605, 494)
        Me.LBLCE.Name = "LBLCE"
        Me.LBLCE.Size = New System.Drawing.Size(111, 17)
        Me.LBLCE.TabIndex = 1551
        Me.LBLCE.Text = "Efectivo"
        Me.LBLCE.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLCD
        '
        Me.LBLCD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLCD.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LBLCD.Location = New System.Drawing.Point(457, 494)
        Me.LBLCD.Name = "LBLCD"
        Me.LBLCD.Size = New System.Drawing.Size(111, 17)
        Me.LBLCD.TabIndex = 1550
        Me.LBLCD.Text = "Efectivo"
        Me.LBLCD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLCC
        '
        Me.LBLCC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLCC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LBLCC.Location = New System.Drawing.Point(325, 494)
        Me.LBLCC.Name = "LBLCC"
        Me.LBLCC.Size = New System.Drawing.Size(111, 17)
        Me.LBLCC.TabIndex = 1549
        Me.LBLCC.Text = "Efectivo"
        Me.LBLCC.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLCB
        '
        Me.LBLCB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLCB.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LBLCB.Location = New System.Drawing.Point(174, 494)
        Me.LBLCB.Name = "LBLCB"
        Me.LBLCB.Size = New System.Drawing.Size(111, 17)
        Me.LBLCB.TabIndex = 1548
        Me.LBLCB.Text = "Efectivo"
        Me.LBLCB.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLCA
        '
        Me.LBLCA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLCA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LBLCA.Location = New System.Drawing.Point(37, 494)
        Me.LBLCA.Name = "LBLCA"
        Me.LBLCA.Size = New System.Drawing.Size(111, 17)
        Me.LBLCA.TabIndex = 1547
        Me.LBLCA.Text = "Efectivo"
        Me.LBLCA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label35
        '
        Me.Label35.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(605, 477)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(111, 17)
        Me.Label35.TabIndex = 1542
        Me.Label35.Text = "Transferencia"
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(457, 477)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(64, 17)
        Me.Label36.TabIndex = 1541
        Me.Label36.Text = "Cheque"
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(325, 477)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(68, 17)
        Me.Label37.TabIndex = 1540
        Me.Label37.Text = "T Débito"
        '
        'Label38
        '
        Me.Label38.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(174, 477)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(75, 17)
        Me.Label38.TabIndex = 1539
        Me.Label38.Text = "T Crédito"
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(37, 477)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(67, 17)
        Me.Label39.TabIndex = 1538
        Me.Label39.Text = "Efectivo"
        '
        'LBLE
        '
        Me.LBLE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLE.ForeColor = System.Drawing.Color.Navy
        Me.LBLE.Location = New System.Drawing.Point(605, 435)
        Me.LBLE.Name = "LBLE"
        Me.LBLE.Size = New System.Drawing.Size(111, 17)
        Me.LBLE.TabIndex = 1533
        Me.LBLE.Text = "Efectivo"
        Me.LBLE.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLD
        '
        Me.LBLD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLD.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLD.ForeColor = System.Drawing.Color.Navy
        Me.LBLD.Location = New System.Drawing.Point(457, 435)
        Me.LBLD.Name = "LBLD"
        Me.LBLD.Size = New System.Drawing.Size(111, 17)
        Me.LBLD.TabIndex = 1532
        Me.LBLD.Text = "Efectivo"
        Me.LBLD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLC
        '
        Me.LBLC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLC.ForeColor = System.Drawing.Color.Navy
        Me.LBLC.Location = New System.Drawing.Point(325, 435)
        Me.LBLC.Name = "LBLC"
        Me.LBLC.Size = New System.Drawing.Size(111, 17)
        Me.LBLC.TabIndex = 1531
        Me.LBLC.Text = "Efectivo"
        Me.LBLC.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLB
        '
        Me.LBLB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLB.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLB.ForeColor = System.Drawing.Color.Navy
        Me.LBLB.Location = New System.Drawing.Point(174, 435)
        Me.LBLB.Name = "LBLB"
        Me.LBLB.Size = New System.Drawing.Size(111, 17)
        Me.LBLB.TabIndex = 1530
        Me.LBLB.Text = "Efectivo"
        Me.LBLB.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLA
        '
        Me.LBLA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLA.ForeColor = System.Drawing.Color.Navy
        Me.LBLA.Location = New System.Drawing.Point(37, 435)
        Me.LBLA.Name = "LBLA"
        Me.LBLA.Size = New System.Drawing.Size(111, 17)
        Me.LBLA.TabIndex = 1529
        Me.LBLA.Text = "Efectivo"
        Me.LBLA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(605, 418)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 17)
        Me.Label13.TabIndex = 1524
        Me.Label13.Text = "Transferencia"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(457, 418)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 17)
        Me.Label16.TabIndex = 1523
        Me.Label16.Text = "Cheque"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(325, 418)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 17)
        Me.Label17.TabIndex = 1522
        Me.Label17.Text = "T Débito"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(174, 418)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 17)
        Me.Label18.TabIndex = 1521
        Me.Label18.Text = "T Crédito"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(37, 418)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 17)
        Me.Label19.TabIndex = 1520
        Me.Label19.Text = "Efectivo"
        '
        'LBLTE
        '
        Me.LBLTE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLTE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTE.ForeColor = System.Drawing.Color.Black
        Me.LBLTE.Location = New System.Drawing.Point(605, 524)
        Me.LBLTE.Name = "LBLTE"
        Me.LBLTE.Size = New System.Drawing.Size(111, 17)
        Me.LBLTE.TabIndex = 1562
        Me.LBLTE.Text = "Efectivo"
        Me.LBLTE.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLTD
        '
        Me.LBLTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLTD.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTD.ForeColor = System.Drawing.Color.Black
        Me.LBLTD.Location = New System.Drawing.Point(457, 524)
        Me.LBLTD.Name = "LBLTD"
        Me.LBLTD.Size = New System.Drawing.Size(111, 17)
        Me.LBLTD.TabIndex = 1561
        Me.LBLTD.Text = "Efectivo"
        Me.LBLTD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLTC
        '
        Me.LBLTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLTC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTC.ForeColor = System.Drawing.Color.Black
        Me.LBLTC.Location = New System.Drawing.Point(325, 524)
        Me.LBLTC.Name = "LBLTC"
        Me.LBLTC.Size = New System.Drawing.Size(111, 17)
        Me.LBLTC.TabIndex = 1560
        Me.LBLTC.Text = "Efectivo"
        Me.LBLTC.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLTB
        '
        Me.LBLTB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLTB.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTB.ForeColor = System.Drawing.Color.Black
        Me.LBLTB.Location = New System.Drawing.Point(174, 524)
        Me.LBLTB.Name = "LBLTB"
        Me.LBLTB.Size = New System.Drawing.Size(111, 17)
        Me.LBLTB.TabIndex = 1559
        Me.LBLTB.Text = "Efectivo"
        Me.LBLTB.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLTA
        '
        Me.LBLTA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLTA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTA.ForeColor = System.Drawing.Color.Black
        Me.LBLTA.Location = New System.Drawing.Point(37, 524)
        Me.LBLTA.Name = "LBLTA"
        Me.LBLTA.Size = New System.Drawing.Size(111, 17)
        Me.LBLTA.TabIndex = 1558
        Me.LBLTA.Text = "Efectivo"
        Me.LBLTA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(786, 439)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 17)
        Me.Label21.TabIndex = 1563
        Me.Label21.Text = "Gastos"
        '
        'LBLTG
        '
        Me.LBLTG.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLTG.AutoSize = True
        Me.LBLTG.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTG.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LBLTG.Location = New System.Drawing.Point(786, 456)
        Me.LBLTG.Name = "LBLTG"
        Me.LBLTG.Size = New System.Drawing.Size(111, 17)
        Me.LBLTG.TabIndex = 1564
        Me.LBLTG.Text = "Transferencia"
        Me.LBLTG.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(786, 474)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(90, 17)
        Me.Label23.TabIndex = 1565
        Me.Label23.Text = "Depositado"
        '
        'LBLTDEP
        '
        Me.LBLTDEP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLTDEP.AutoSize = True
        Me.LBLTDEP.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTDEP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LBLTDEP.Location = New System.Drawing.Point(786, 491)
        Me.LBLTDEP.Name = "LBLTDEP"
        Me.LBLTDEP.Size = New System.Drawing.Size(111, 17)
        Me.LBLTDEP.TabIndex = 1566
        Me.LBLTDEP.Text = "Transferencia"
        Me.LBLTDEP.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLDIF
        '
        Me.LBLDIF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLDIF.AutoSize = True
        Me.LBLDIF.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDIF.Location = New System.Drawing.Point(786, 530)
        Me.LBLDIF.Name = "LBLDIF"
        Me.LBLDIF.Size = New System.Drawing.Size(111, 17)
        Me.LBLDIF.TabIndex = 1568
        Me.LBLDIF.Text = "Transferencia"
        Me.LBLDIF.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(786, 513)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(84, 17)
        Me.Label26.TabIndex = 1567
        Me.Label26.Text = "Diferencia"
        '
        'LBLVN
        '
        Me.LBLVN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLVN.AutoSize = True
        Me.LBLVN.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLVN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LBLVN.Location = New System.Drawing.Point(786, 418)
        Me.LBLVN.Name = "LBLVN"
        Me.LBLVN.Size = New System.Drawing.Size(111, 17)
        Me.LBLVN.TabIndex = 1570
        Me.LBLVN.Text = "Transferencia"
        Me.LBLVN.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(786, 401)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 17)
        Me.Label11.TabIndex = 1569
        Me.Label11.Text = "Venta Neta"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(3, 524)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 17)
        Me.Label10.TabIndex = 1571
        Me.Label10.Text = "Tot."
        '
        'frmDepositos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 550)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LBLVN)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LBLDIF)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.LBLTDEP)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.LBLTG)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.LBLTE)
        Me.Controls.Add(Me.LBLTD)
        Me.Controls.Add(Me.LBLTC)
        Me.Controls.Add(Me.LBLTB)
        Me.Controls.Add(Me.LBLTA)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LBLCE)
        Me.Controls.Add(Me.LBLCD)
        Me.Controls.Add(Me.LBLCC)
        Me.Controls.Add(Me.LBLCB)
        Me.Controls.Add(Me.LBLCA)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.LBLE)
        Me.Controls.Add(Me.LBLD)
        Me.Controls.Add(Me.LBLC)
        Me.Controls.Add(Me.LBLB)
        Me.Controls.Add(Me.LBLA)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.BTNCONF)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.BTNQUITAR)
        Me.Controls.Add(Me.CBCAJA)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DTFECHADIA)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TXTFICHA)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CBBANCO)
        Me.Controls.Add(Me.DTHORA)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTCANT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBCUENTAS)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.DTHASTA)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDepositos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Depósitos"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBCAJA As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DTFECHADIA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTFICHA As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CBBANCO As System.Windows.Forms.ComboBox
    Friend WithEvents DTHORA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTCANT As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CBCUENTAS As System.Windows.Forms.ComboBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents DTHASTA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Private WithEvents BTNQUITAR As System.Windows.Forms.Button
    Friend WithEvents BTNCONF As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LBLCE As System.Windows.Forms.Label
    Friend WithEvents LBLCD As System.Windows.Forms.Label
    Friend WithEvents LBLCC As System.Windows.Forms.Label
    Friend WithEvents LBLCB As System.Windows.Forms.Label
    Friend WithEvents LBLCA As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents LBLE As System.Windows.Forms.Label
    Friend WithEvents LBLD As System.Windows.Forms.Label
    Friend WithEvents LBLC As System.Windows.Forms.Label
    Friend WithEvents LBLB As System.Windows.Forms.Label
    Friend WithEvents LBLA As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents LBLTE As System.Windows.Forms.Label
    Friend WithEvents LBLTD As System.Windows.Forms.Label
    Friend WithEvents LBLTC As System.Windows.Forms.Label
    Friend WithEvents LBLTB As System.Windows.Forms.Label
    Friend WithEvents LBLTA As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents LBLTG As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents LBLTDEP As System.Windows.Forms.Label
    Friend WithEvents LBLDIF As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents LBLVN As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
