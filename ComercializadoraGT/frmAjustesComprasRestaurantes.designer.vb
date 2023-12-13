<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAjustesComprasRestaurantes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjustesComprasRestaurantes))
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBRES = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TXTNOORDEN = New System.Windows.Forms.TextBox
        Me.TXTCANT = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTCOS = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CBUNI = New System.Windows.Forms.ComboBox
        Me.TXTPRE = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TXTEXIS = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TXTTUM = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.TXTTOT = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TXTIVA = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TXTSUB = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CBPRO = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TXTCON = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.TTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.CHKDOC = New System.Windows.Forms.CheckBox
        Me.CHKCF = New System.Windows.Forms.CheckBox
        Me.CHKFIN = New System.Windows.Forms.CheckBox
        Me.CBTC = New System.Windows.Forms.ComboBox
        Me.BTNBUSCAR = New System.Windows.Forms.Button
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.BTNELIMINAR = New System.Windows.Forms.Button
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 24)
        Me.Label1.TabIndex = 1126
        Me.Label1.Text = "Restaurante"
        '
        'CBRES
        '
        Me.CBRES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBRES.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBRES.FormattingEnabled = True
        Me.CBRES.Location = New System.Drawing.Point(157, 9)
        Me.CBRES.Name = "CBRES"
        Me.CBRES.Size = New System.Drawing.Size(341, 28)
        Me.CBRES.TabIndex = 1125
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(516, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 24)
        Me.Label2.TabIndex = 1127
        Me.Label2.Text = "No Orden"
        '
        'TXTNOORDEN
        '
        Me.TXTNOORDEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOORDEN.Location = New System.Drawing.Point(656, 14)
        Me.TXTNOORDEN.Name = "TXTNOORDEN"
        Me.TXTNOORDEN.Size = New System.Drawing.Size(152, 24)
        Me.TXTNOORDEN.TabIndex = 1128
        '
        'TXTCANT
        '
        Me.TXTCANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT.Location = New System.Drawing.Point(22, 34)
        Me.TXTCANT.Name = "TXTCANT"
        Me.TXTCANT.Size = New System.Drawing.Size(164, 24)
        Me.TXTCANT.TabIndex = 1130
        Me.TXTCANT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(60, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 20)
        Me.Label3.TabIndex = 1129
        Me.Label3.Text = "Cantidad"
        '
        'TXTCOS
        '
        Me.TXTCOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOS.Location = New System.Drawing.Point(239, 34)
        Me.TXTCOS.Name = "TXTCOS"
        Me.TXTCOS.Size = New System.Drawing.Size(152, 24)
        Me.TXTCOS.TabIndex = 1134
        Me.TXTCOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(251, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 20)
        Me.Label5.TabIndex = 1133
        Me.Label5.Text = "Costo Unitario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(60, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 20)
        Me.Label4.TabIndex = 1136
        Me.Label4.Text = "Unidad"
        '
        'CBUNI
        '
        Me.CBUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBUNI.FormattingEnabled = True
        Me.CBUNI.Location = New System.Drawing.Point(22, 82)
        Me.CBUNI.Name = "CBUNI"
        Me.CBUNI.Size = New System.Drawing.Size(164, 28)
        Me.CBUNI.TabIndex = 1135
        '
        'TXTPRE
        '
        Me.TXTPRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPRE.Location = New System.Drawing.Point(239, 86)
        Me.TXTPRE.Name = "TXTPRE"
        Me.TXTPRE.Size = New System.Drawing.Size(152, 24)
        Me.TXTPRE.TabIndex = 1138
        Me.TXTPRE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label6.Location = New System.Drawing.Point(251, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 20)
        Me.Label6.TabIndex = 1137
        Me.Label6.Text = "Precio Unitario"
        '
        'TXTEXIS
        '
        Me.TXTEXIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEXIS.Location = New System.Drawing.Point(427, 34)
        Me.TXTEXIS.Name = "TXTEXIS"
        Me.TXTEXIS.ReadOnly = True
        Me.TXTEXIS.Size = New System.Drawing.Size(152, 24)
        Me.TXTEXIS.TabIndex = 1145
        Me.TXTEXIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label7.Location = New System.Drawing.Point(450, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 20)
        Me.Label7.TabIndex = 1144
        Me.Label7.Text = "Existencia"
        '
        'TXTTUM
        '
        Me.TXTTUM.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTUM.Location = New System.Drawing.Point(427, 86)
        Me.TXTTUM.Name = "TXTTUM"
        Me.TXTTUM.ReadOnly = True
        Me.TXTTUM.Size = New System.Drawing.Size(152, 24)
        Me.TXTTUM.TabIndex = 1147
        Me.TXTTUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label8.Location = New System.Drawing.Point(453, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 1146
        Me.Label8.Text = "Tot Uni Min"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(13, 84)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV.Size = New System.Drawing.Size(899, 249)
        Me.DGV.TabIndex = 1149
        '
        'TXTTOT
        '
        Me.TXTTOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOT.Location = New System.Drawing.Point(440, 37)
        Me.TXTTOT.Name = "TXTTOT"
        Me.TXTTOT.Size = New System.Drawing.Size(152, 24)
        Me.TXTTOT.TabIndex = 1202
        Me.TXTTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label10.Location = New System.Drawing.Point(490, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 20)
        Me.Label10.TabIndex = 1201
        Me.Label10.Text = "Total"
        '
        'TXTIVA
        '
        Me.TXTIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIVA.Location = New System.Drawing.Point(224, 37)
        Me.TXTIVA.Name = "TXTIVA"
        Me.TXTIVA.Size = New System.Drawing.Size(152, 24)
        Me.TXTIVA.TabIndex = 1200
        Me.TXTIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label11.Location = New System.Drawing.Point(278, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 20)
        Me.Label11.TabIndex = 1199
        Me.Label11.Text = "I.V.A"
        '
        'TXTSUB
        '
        Me.TXTSUB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUB.Location = New System.Drawing.Point(13, 37)
        Me.TXTSUB.Name = "TXTSUB"
        Me.TXTSUB.Size = New System.Drawing.Size(152, 24)
        Me.TXTSUB.TabIndex = 1198
        Me.TXTSUB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label12.Location = New System.Drawing.Point(40, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 20)
        Me.Label12.TabIndex = 1197
        Me.Label12.Text = "Sub Total"
        '
        'CBPRO
        '
        Me.CBPRO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPRO.FormattingEnabled = True
        Me.CBPRO.Location = New System.Drawing.Point(157, 52)
        Me.CBPRO.Name = "CBPRO"
        Me.CBPRO.Size = New System.Drawing.Size(394, 26)
        Me.CBPRO.TabIndex = 1214
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(26, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 24)
        Me.Label13.TabIndex = 1213
        Me.Label13.Text = "Proveedor"
        '
        'TXTCON
        '
        Me.TXTCON.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCON.Location = New System.Drawing.Point(157, 76)
        Me.TXTCON.Name = "TXTCON"
        Me.TXTCON.Size = New System.Drawing.Size(353, 24)
        Me.TXTCON.TabIndex = 1215
        Me.TXTCON.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label17.Location = New System.Drawing.Point(47, 80)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 20)
        Me.Label17.TabIndex = 1216
        Me.Label17.Text = "CONCEPTO"
        Me.Label17.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.GhostWhite
        Me.Panel1.Controls.Add(Me.TXTCON)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.TXTSUB)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.TXTIVA)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.TXTTOT)
        Me.Panel1.Location = New System.Drawing.Point(14, 518)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(624, 107)
        Me.Panel1.TabIndex = 1217
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.GhostWhite
        Me.Panel2.Controls.Add(Me.CBUNI)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.TXTCANT)
        Me.Panel2.Controls.Add(Me.TXTPRE)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TXTTUM)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.TXTCOS)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.TXTEXIS)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(13, 364)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(624, 123)
        Me.Panel2.TabIndex = 1218
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label9.Location = New System.Drawing.Point(12, 336)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(170, 25)
        Me.Label9.TabIndex = 1219
        Me.Label9.Text = "Detalle compra"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label14.Location = New System.Drawing.Point(13, 490)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 25)
        Me.Label14.TabIndex = 1220
        Me.Label14.Text = "Compra"
        '
        'TTT
        '
        Me.TTT.AutomaticDelay = 5000
        Me.TTT.BackColor = System.Drawing.Color.Blue
        Me.TTT.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.TTT.IsBalloon = True
        Me.TTT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'CHKDOC
        '
        Me.CHKDOC.AutoSize = True
        Me.CHKDOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKDOC.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CHKDOC.Location = New System.Drawing.Point(383, 660)
        Me.CHKDOC.Name = "CHKDOC"
        Me.CHKDOC.Size = New System.Drawing.Size(209, 24)
        Me.CHKDOC.TabIndex = 1231
        Me.CHKDOC.Text = "Documento Entregado"
        Me.CHKDOC.UseVisualStyleBackColor = True
        Me.CHKDOC.Visible = False
        '
        'CHKCF
        '
        Me.CHKCF.AutoSize = True
        Me.CHKCF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKCF.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CHKCF.Location = New System.Drawing.Point(97, 660)
        Me.CHKCF.Name = "CHKCF"
        Me.CHKCF.Size = New System.Drawing.Size(196, 24)
        Me.CHKCF.TabIndex = 1230
        Me.CHKCF.Text = "Convertido a Factura"
        Me.CHKCF.UseVisualStyleBackColor = True
        Me.CHKCF.Visible = False
        '
        'CHKFIN
        '
        Me.CHKFIN.AutoSize = True
        Me.CHKFIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKFIN.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CHKFIN.Location = New System.Drawing.Point(383, 630)
        Me.CHKFIN.Name = "CHKFIN"
        Me.CHKFIN.Size = New System.Drawing.Size(101, 24)
        Me.CHKFIN.TabIndex = 1229
        Me.CHKFIN.Text = "Finanzas"
        Me.CHKFIN.UseVisualStyleBackColor = True
        Me.CHKFIN.Visible = False
        '
        'CBTC
        '
        Me.CBTC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTC.FormattingEnabled = True
        Me.CBTC.Items.AddRange(New Object() {"Factura", "Nota", "Vale Rosa"})
        Me.CBTC.Location = New System.Drawing.Point(97, 631)
        Me.CBTC.Name = "CBTC"
        Me.CBTC.Size = New System.Drawing.Size(204, 24)
        Me.CBTC.TabIndex = 1232
        Me.CBTC.Visible = False
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.Black
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.Image = Global.ComercializadoraGT.My.Resources.Resources.xeyes1
        Me.BTNBUSCAR.Location = New System.Drawing.Point(814, 2)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNBUSCAR.TabIndex = 1142
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(740, 528)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 1141
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNELIMINAR.ForeColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Image = CType(resources.GetObject("BTNELIMINAR.Image"), System.Drawing.Image)
        Me.BTNELIMINAR.Location = New System.Drawing.Point(814, 371)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNELIMINAR.TabIndex = 1139
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Enabled = False
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.White
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(656, 371)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 1140
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'frmAjustesComprasRestaurantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 638)
        Me.Controls.Add(Me.CBTC)
        Me.Controls.Add(Me.CHKDOC)
        Me.Controls.Add(Me.CHKCF)
        Me.Controls.Add(Me.CHKFIN)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CBPRO)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNELIMINAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.TXTNOORDEN)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBRES)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAjustesComprasRestaurantes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajustes de Compras de Restaurantes"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBRES As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTNOORDEN As System.Windows.Forms.TextBox
    Friend WithEvents TXTCANT As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTCOS As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CBUNI As System.Windows.Forms.ComboBox
    Friend WithEvents TXTPRE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNELIMINAR As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Private WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Friend WithEvents TXTEXIS As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTTUM As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents TXTTOT As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTIVA As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TXTSUB As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CBPRO As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TXTCON As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TTT As System.Windows.Forms.ToolTip
    Friend WithEvents CHKDOC As System.Windows.Forms.CheckBox
    Friend WithEvents CHKCF As System.Windows.Forms.CheckBox
    Friend WithEvents CHKFIN As System.Windows.Forms.CheckBox
    Friend WithEvents CBTC As System.Windows.Forms.ComboBox
End Class
