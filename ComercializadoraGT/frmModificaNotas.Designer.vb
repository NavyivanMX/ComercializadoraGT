<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModificaNotas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModificaNotas))
        Me.TXTNOTA = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LBLEMP = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.DTFECHA = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.LBLCLI = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.TXTCANT = New System.Windows.Forms.TextBox
        Me.TXTCOD = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PBIMG = New System.Windows.Forms.PictureBox
        Me.LBLNOM = New System.Windows.Forms.Label
        Me.LBLPRE = New System.Windows.Forms.Label
        Me.LBLEXIS = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.BTNRESTAR = New System.Windows.Forms.Button
        Me.BTNAGREGAR = New System.Windows.Forms.Button
        Me.TXTCAMBIO = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CBTP = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXTEFECTIVO = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.TXTTOT = New System.Windows.Forms.TextBox
        Me.LBLP = New System.Windows.Forms.Label
        Me.LBLPROA = New System.Windows.Forms.Label
        Me.BTNCOBRAR = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.BTNQUITAR = New System.Windows.Forms.Button
        Me.BTNBUS = New System.Windows.Forms.Button
        Me.TXTDESC = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TXTNOTA1 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TXTNOTA
        '
        Me.TXTNOTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNOTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOTA.Location = New System.Drawing.Point(48, 38)
        Me.TXTNOTA.MaxLength = 10
        Me.TXTNOTA.Name = "TXTNOTA"
        Me.TXTNOTA.Size = New System.Drawing.Size(112, 26)
        Me.TXTNOTA.TabIndex = 1076
        Me.TXTNOTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 20)
        Me.Label2.TabIndex = 1075
        Me.Label2.Text = "Nota"
        '
        'LBLEMP
        '
        Me.LBLEMP.AutoSize = True
        Me.LBLEMP.BackColor = System.Drawing.Color.Transparent
        Me.LBLEMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEMP.ForeColor = System.Drawing.Color.Navy
        Me.LBLEMP.Location = New System.Drawing.Point(290, 28)
        Me.LBLEMP.Name = "LBLEMP"
        Me.LBLEMP.Size = New System.Drawing.Size(19, 20)
        Me.LBLEMP.TabIndex = 1096
        Me.LBLEMP.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(184, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 20)
        Me.Label9.TabIndex = 1095
        Me.Label9.Text = "Empleado"
        '
        'DTFECHA
        '
        Me.DTFECHA.Enabled = False
        Me.DTFECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHA.Location = New System.Drawing.Point(620, 36)
        Me.DTFECHA.Name = "DTFECHA"
        Me.DTFECHA.Size = New System.Drawing.Size(119, 26)
        Me.DTFECHA.TabIndex = 1094
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(657, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 16)
        Me.Label11.TabIndex = 1093
        Me.Label11.Text = "Fecha"
        '
        'LBLCLI
        '
        Me.LBLCLI.AutoSize = True
        Me.LBLCLI.BackColor = System.Drawing.Color.Transparent
        Me.LBLCLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCLI.ForeColor = System.Drawing.Color.Navy
        Me.LBLCLI.Location = New System.Drawing.Point(105, 71)
        Me.LBLCLI.Name = "LBLCLI"
        Me.LBLCLI.Size = New System.Drawing.Size(19, 20)
        Me.LBLCLI.TabIndex = 1117
        Me.LBLCLI.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 20)
        Me.Label1.TabIndex = 1116
        Me.Label1.Text = "Cliente"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(24, 413)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.Size = New System.Drawing.Size(698, 242)
        Me.DGV.TabIndex = 1118
        '
        'TXTCANT
        '
        Me.TXTCANT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT.Location = New System.Drawing.Point(181, 125)
        Me.TXTCANT.MaxLength = 5
        Me.TXTCANT.Name = "TXTCANT"
        Me.TXTCANT.Size = New System.Drawing.Size(91, 26)
        Me.TXTCANT.TabIndex = 1120
        Me.TXTCANT.Text = "1"
        Me.TXTCANT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCOD
        '
        Me.TXTCOD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOD.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TXTCOD.Location = New System.Drawing.Point(333, 125)
        Me.TXTCOD.MaxLength = 30
        Me.TXTCOD.Name = "TXTCOD"
        Me.TXTCOD.Size = New System.Drawing.Size(248, 26)
        Me.TXTCOD.TabIndex = 1119
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(179, 102)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 20)
        Me.Label13.TabIndex = 1122
        Me.Label13.Text = "Cantidad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(330, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 20)
        Me.Label3.TabIndex = 1121
        Me.Label3.Text = "Código Producto"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.PBIMG)
        Me.GroupBox1.Controls.Add(Me.LBLNOM)
        Me.GroupBox1.Controls.Add(Me.LBLPRE)
        Me.GroupBox1.Controls.Add(Me.LBLEXIS)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(180, 154)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 252)
        Me.GroupBox1.TabIndex = 1127
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto"
        '
        'PBIMG
        '
        Me.PBIMG.BackColor = System.Drawing.Color.White
        Me.PBIMG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PBIMG.ErrorImage = CType(resources.GetObject("PBIMG.ErrorImage"), System.Drawing.Image)
        Me.PBIMG.Location = New System.Drawing.Point(142, 87)
        Me.PBIMG.Name = "PBIMG"
        Me.PBIMG.Size = New System.Drawing.Size(112, 150)
        Me.PBIMG.TabIndex = 1061
        Me.PBIMG.TabStop = False
        '
        'LBLNOM
        '
        Me.LBLNOM.AutoSize = True
        Me.LBLNOM.BackColor = System.Drawing.Color.Transparent
        Me.LBLNOM.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNOM.Location = New System.Drawing.Point(8, 28)
        Me.LBLNOM.Name = "LBLNOM"
        Me.LBLNOM.Size = New System.Drawing.Size(21, 22)
        Me.LBLNOM.TabIndex = 1062
        Me.LBLNOM.Text = "0"
        '
        'LBLPRE
        '
        Me.LBLPRE.AutoSize = True
        Me.LBLPRE.BackColor = System.Drawing.Color.Transparent
        Me.LBLPRE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPRE.Location = New System.Drawing.Point(93, 55)
        Me.LBLPRE.Name = "LBLPRE"
        Me.LBLPRE.Size = New System.Drawing.Size(22, 24)
        Me.LBLPRE.TabIndex = 1063
        Me.LBLPRE.Text = "0"
        '
        'LBLEXIS
        '
        Me.LBLEXIS.AutoSize = True
        Me.LBLEXIS.BackColor = System.Drawing.Color.Transparent
        Me.LBLEXIS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEXIS.Location = New System.Drawing.Point(281, 120)
        Me.LBLEXIS.Name = "LBLEXIS"
        Me.LBLEXIS.Size = New System.Drawing.Size(22, 24)
        Me.LBLEXIS.TabIndex = 1067
        Me.LBLEXIS.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(281, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 24)
        Me.Label6.TabIndex = 1073
        Me.Label6.Text = "Existencia"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 24)
        Me.Label5.TabIndex = 1072
        Me.Label5.Text = "Precio"
        '
        'BTNRESTAR
        '
        Me.BTNRESTAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNRESTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNRESTAR.ForeColor = System.Drawing.Color.Black
        Me.BTNRESTAR.Location = New System.Drawing.Point(599, 288)
        Me.BTNRESTAR.Name = "BTNRESTAR"
        Me.BTNRESTAR.Size = New System.Drawing.Size(60, 36)
        Me.BTNRESTAR.TabIndex = 1129
        Me.BTNRESTAR.Text = "-"
        Me.BTNRESTAR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNRESTAR.UseVisualStyleBackColor = False
        '
        'BTNAGREGAR
        '
        Me.BTNAGREGAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNAGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNAGREGAR.ForeColor = System.Drawing.Color.Black
        Me.BTNAGREGAR.Location = New System.Drawing.Point(599, 228)
        Me.BTNAGREGAR.Name = "BTNAGREGAR"
        Me.BTNAGREGAR.Size = New System.Drawing.Size(60, 36)
        Me.BTNAGREGAR.TabIndex = 1128
        Me.BTNAGREGAR.Text = "+"
        Me.BTNAGREGAR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNAGREGAR.UseVisualStyleBackColor = False
        '
        'TXTCAMBIO
        '
        Me.TXTCAMBIO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCAMBIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCAMBIO.Location = New System.Drawing.Point(780, 553)
        Me.TXTCAMBIO.MaxLength = 30
        Me.TXTCAMBIO.Name = "TXTCAMBIO"
        Me.TXTCAMBIO.ReadOnly = True
        Me.TXTCAMBIO.Size = New System.Drawing.Size(151, 26)
        Me.TXTCAMBIO.TabIndex = 1140
        Me.TXTCAMBIO.Text = "0"
        Me.TXTCAMBIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(745, 530)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 20)
        Me.Label4.TabIndex = 1139
        Me.Label4.Text = "Cambio"
        '
        'CBTP
        '
        Me.CBTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTP.FormattingEnabled = True
        Me.CBTP.Items.AddRange(New Object() {"Efectivo", "Tarjeta", "Mixto", "Cheque"})
        Me.CBTP.Location = New System.Drawing.Point(746, 417)
        Me.CBTP.Name = "CBTP"
        Me.CBTP.Size = New System.Drawing.Size(185, 28)
        Me.CBTP.TabIndex = 1137
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(745, 394)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 20)
        Me.Label12.TabIndex = 1138
        Me.Label12.Text = "Tipo de Pago"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(755, 494)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 20)
        Me.Label7.TabIndex = 1136
        Me.Label7.Text = "$"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(528, 660)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 32)
        Me.Label8.TabIndex = 1135
        Me.Label8.Text = "$"
        '
        'TXTEFECTIVO
        '
        Me.TXTEFECTIVO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTEFECTIVO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEFECTIVO.Location = New System.Drawing.Point(780, 488)
        Me.TXTEFECTIVO.MaxLength = 30
        Me.TXTEFECTIVO.Name = "TXTEFECTIVO"
        Me.TXTEFECTIVO.Size = New System.Drawing.Size(151, 26)
        Me.TXTEFECTIVO.TabIndex = 1130
        Me.TXTEFECTIVO.Text = "0"
        Me.TXTEFECTIVO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(744, 466)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 20)
        Me.Label10.TabIndex = 1133
        Me.Label10.Text = "Efectivo"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(469, 671)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 20)
        Me.Label14.TabIndex = 1132
        Me.Label14.Text = "Total "
        '
        'TXTTOT
        '
        Me.TXTTOT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOT.Location = New System.Drawing.Point(565, 665)
        Me.TXTTOT.MaxLength = 50
        Me.TXTTOT.Name = "TXTTOT"
        Me.TXTTOT.ReadOnly = True
        Me.TXTTOT.Size = New System.Drawing.Size(157, 26)
        Me.TXTTOT.TabIndex = 1131
        Me.TXTTOT.Text = "0"
        Me.TXTTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLP
        '
        Me.LBLP.AutoSize = True
        Me.LBLP.BackColor = System.Drawing.Color.Transparent
        Me.LBLP.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLP.ForeColor = System.Drawing.Color.Black
        Me.LBLP.Location = New System.Drawing.Point(54, 671)
        Me.LBLP.Name = "LBLP"
        Me.LBLP.Size = New System.Drawing.Size(21, 22)
        Me.LBLP.TabIndex = 1143
        Me.LBLP.Text = "0"
        '
        'LBLPROA
        '
        Me.LBLPROA.AutoSize = True
        Me.LBLPROA.BackColor = System.Drawing.Color.Transparent
        Me.LBLPROA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPROA.Location = New System.Drawing.Point(87, 675)
        Me.LBLPROA.Name = "LBLPROA"
        Me.LBLPROA.Size = New System.Drawing.Size(83, 17)
        Me.LBLPROA.TabIndex = 1142
        Me.LBLPROA.Text = "Productos"
        '
        'BTNCOBRAR
        '
        Me.BTNCOBRAR.BackColor = System.Drawing.Color.White
        Me.BTNCOBRAR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCOBRAR.ForeColor = System.Drawing.Color.Black
        Me.BTNCOBRAR.Image = CType(resources.GetObject("BTNCOBRAR.Image"), System.Drawing.Image)
        Me.BTNCOBRAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNCOBRAR.Location = New System.Drawing.Point(780, 600)
        Me.BTNCOBRAR.Name = "BTNCOBRAR"
        Me.BTNCOBRAR.Size = New System.Drawing.Size(117, 54)
        Me.BTNCOBRAR.TabIndex = 1134
        Me.BTNCOBRAR.Text = "        F12 Cobrar"
        Me.BTNCOBRAR.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(24, 258)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 35)
        Me.Button1.TabIndex = 1126
        Me.Button1.Text = "     F3 Touch"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'BTNQUITAR
        '
        Me.BTNQUITAR.BackColor = System.Drawing.Color.White
        Me.BTNQUITAR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNQUITAR.ForeColor = System.Drawing.Color.Black
        Me.BTNQUITAR.Image = CType(resources.GetObject("BTNQUITAR.Image"), System.Drawing.Image)
        Me.BTNQUITAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNQUITAR.Location = New System.Drawing.Point(24, 298)
        Me.BTNQUITAR.Name = "BTNQUITAR"
        Me.BTNQUITAR.Size = New System.Drawing.Size(127, 35)
        Me.BTNQUITAR.TabIndex = 1124
        Me.BTNQUITAR.Text = "      F5 Borra Art"
        Me.BTNQUITAR.UseVisualStyleBackColor = False
        '
        'BTNBUS
        '
        Me.BTNBUS.BackColor = System.Drawing.Color.White
        Me.BTNBUS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUS.ForeColor = System.Drawing.Color.Black
        Me.BTNBUS.Image = CType(resources.GetObject("BTNBUS.Image"), System.Drawing.Image)
        Me.BTNBUS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNBUS.Location = New System.Drawing.Point(24, 339)
        Me.BTNBUS.Name = "BTNBUS"
        Me.BTNBUS.Size = New System.Drawing.Size(127, 35)
        Me.BTNBUS.TabIndex = 1123
        Me.BTNBUS.Text = "        F10 Buscar"
        Me.BTNBUS.UseVisualStyleBackColor = False
        '
        'TXTDESC
        '
        Me.TXTDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDESC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESC.Location = New System.Drawing.Point(620, 122)
        Me.TXTDESC.MaxLength = 2
        Me.TXTDESC.Name = "TXTDESC"
        Me.TXTDESC.Size = New System.Drawing.Size(91, 29)
        Me.TXTDESC.TabIndex = 1144
        Me.TXTDESC.Text = "0"
        Me.TXTDESC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(616, 99)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(107, 22)
        Me.Label15.TabIndex = 1145
        Me.Label15.Text = "Descuento"
        '
        'TXTNOTA1
        '
        Me.TXTNOTA1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNOTA1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOTA1.Location = New System.Drawing.Point(803, 30)
        Me.TXTNOTA1.MaxLength = 10
        Me.TXTNOTA1.Name = "TXTNOTA1"
        Me.TXTNOTA1.ReadOnly = True
        Me.TXTNOTA1.Size = New System.Drawing.Size(144, 26)
        Me.TXTNOTA1.TabIndex = 1147
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(755, 38)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 18)
        Me.Label16.TabIndex = 1146
        Me.Label16.Text = "Nota"
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(50, 163)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 1148
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'frmModificaNotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 707)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.TXTNOTA1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TXTDESC)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.LBLP)
        Me.Controls.Add(Me.LBLPROA)
        Me.Controls.Add(Me.TXTCAMBIO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CBTP)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.BTNCOBRAR)
        Me.Controls.Add(Me.TXTEFECTIVO)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TXTTOT)
        Me.Controls.Add(Me.BTNRESTAR)
        Me.Controls.Add(Me.BTNAGREGAR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BTNQUITAR)
        Me.Controls.Add(Me.BTNBUS)
        Me.Controls.Add(Me.TXTCANT)
        Me.Controls.Add(Me.TXTCOD)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.LBLCLI)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LBLEMP)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DTFECHA)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TXTNOTA)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModificaNotas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Modificacion de notas"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXTNOTA As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LBLEMP As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DTFECHA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LBLCLI As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents TXTCANT As System.Windows.Forms.TextBox
    Friend WithEvents TXTCOD As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BTNQUITAR As System.Windows.Forms.Button
    Friend WithEvents BTNBUS As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PBIMG As System.Windows.Forms.PictureBox
    Friend WithEvents LBLNOM As System.Windows.Forms.Label
    Friend WithEvents LBLPRE As System.Windows.Forms.Label
    Friend WithEvents LBLEXIS As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BTNRESTAR As System.Windows.Forms.Button
    Friend WithEvents BTNAGREGAR As System.Windows.Forms.Button
    Friend WithEvents TXTCAMBIO As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CBTP As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BTNCOBRAR As System.Windows.Forms.Button
    Friend WithEvents TXTEFECTIVO As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TXTTOT As System.Windows.Forms.TextBox
    Friend WithEvents LBLP As System.Windows.Forms.Label
    Friend WithEvents LBLPROA As System.Windows.Forms.Label
    Friend WithEvents TXTDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TXTNOTA1 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
End Class
