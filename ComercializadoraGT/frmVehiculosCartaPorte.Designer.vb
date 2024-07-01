<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVehiculosCartaPorte
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVehiculosCartaPorte))
        Me.CBACT = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTPLACAS = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTNUMPER = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTCLA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBPER = New System.Windows.Forms.ComboBox()
        Me.TXTNOM = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBCON = New System.Windows.Forms.ComboBox()
        Me.TTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.NUDMOD = New System.Windows.Forms.NumericUpDown()
        Me.BTNBUSPER = New System.Windows.Forms.Button()
        Me.BTNBUSCON = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTASE = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTPOL = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTPOLMA = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTASEMA = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BTNBUSCAR = New System.Windows.Forms.Button()
        Me.BTNCANCELAR = New System.Windows.Forms.Button()
        Me.BTNELIMINAR = New System.Windows.Forms.Button()
        Me.BTNGUARDAR = New System.Windows.Forms.Button()
        Me.BTNINFO = New System.Windows.Forms.Button()
        CType(Me.NUDMOD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBACT
        '
        Me.CBACT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBACT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBACT.FormattingEnabled = True
        Me.CBACT.Items.AddRange(New Object() {"No", "Si"})
        Me.CBACT.Location = New System.Drawing.Point(208, 545)
        Me.CBACT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBACT.Name = "CBACT"
        Me.CBACT.Size = New System.Drawing.Size(120, 30)
        Me.CBACT.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(126, 551)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 22)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Activo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(127, 387)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 22)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Modelo"
        '
        'TXTPLACAS
        '
        Me.TXTPLACAS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPLACAS.Location = New System.Drawing.Point(208, 345)
        Me.TXTPLACAS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTPLACAS.MaxLength = 200
        Me.TXTPLACAS.Name = "TXTPLACAS"
        Me.TXTPLACAS.Size = New System.Drawing.Size(341, 29)
        Me.TXTPLACAS.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(132, 351)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 22)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Placas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 278)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(225, 22)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Configuración vehicular"
        '
        'TXTNUMPER
        '
        Me.TXTNUMPER.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNUMPER.Location = New System.Drawing.Point(208, 224)
        Me.TXTNUMPER.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTNUMPER.MaxLength = 200
        Me.TXTNUMPER.Name = "TXTNUMPER"
        Me.TXTNUMPER.Size = New System.Drawing.Size(612, 29)
        Me.TXTNUMPER.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 230)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 22)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Num Permiso SCT"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 157)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 22)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Permiso SCT"
        '
        'TXTCLA
        '
        Me.TXTCLA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLA.Location = New System.Drawing.Point(158, 59)
        Me.TXTCLA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTCLA.MaxLength = 3
        Me.TXTCLA.Name = "TXTCLA"
        Me.TXTCLA.Size = New System.Drawing.Size(75, 29)
        Me.TXTCLA.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 68)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 22)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Clave"
        '
        'CBPER
        '
        Me.CBPER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPER.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPER.FormattingEnabled = True
        Me.CBPER.Items.AddRange(New Object() {"O-", "O+", "A-", "A+", "B-", "B+", "AB-", "AB+", "ORH-", "ORH+", "RH-", "RH+", "UNIVERSAL", ""})
        Me.CBPER.Location = New System.Drawing.Point(17, 184)
        Me.CBPER.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBPER.Name = "CBPER"
        Me.CBPER.Size = New System.Drawing.Size(803, 30)
        Me.CBPER.TabIndex = 3
        '
        'TXTNOM
        '
        Me.TXTNOM.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOM.Location = New System.Drawing.Point(208, 119)
        Me.TXTNOM.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTNOM.MaxLength = 200
        Me.TXTNOM.Name = "TXTNOM"
        Me.TXTNOM.Size = New System.Drawing.Size(341, 29)
        Me.TXTNOM.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(118, 122)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 22)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Nombre"
        '
        'CBCON
        '
        Me.CBCON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCON.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCON.FormattingEnabled = True
        Me.CBCON.Items.AddRange(New Object() {"O-", "O+", "A-", "A+", "B-", "B+", "AB-", "AB+", "ORH-", "ORH+", "RH-", "RH+", "UNIVERSAL", ""})
        Me.CBCON.Location = New System.Drawing.Point(17, 305)
        Me.CBCON.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBCON.Name = "CBCON"
        Me.CBCON.Size = New System.Drawing.Size(803, 30)
        Me.CBCON.TabIndex = 6
        '
        'NUDMOD
        '
        Me.NUDMOD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDMOD.Location = New System.Drawing.Point(208, 382)
        Me.NUDMOD.Name = "NUDMOD"
        Me.NUDMOD.Size = New System.Drawing.Size(120, 27)
        Me.NUDMOD.TabIndex = 8
        Me.NUDMOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BTNBUSPER
        '
        Me.BTNBUSPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSPER.Location = New System.Drawing.Point(745, 146)
        Me.BTNBUSPER.Name = "BTNBUSPER"
        Me.BTNBUSPER.Size = New System.Drawing.Size(75, 30)
        Me.BTNBUSPER.TabIndex = 2
        Me.BTNBUSPER.Text = "..."
        Me.BTNBUSPER.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNBUSPER.UseVisualStyleBackColor = True
        '
        'BTNBUSCON
        '
        Me.BTNBUSCON.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCON.Location = New System.Drawing.Point(745, 266)
        Me.BTNBUSCON.Name = "BTNBUSCON"
        Me.BTNBUSCON.Size = New System.Drawing.Size(75, 31)
        Me.BTNBUSCON.TabIndex = 5
        Me.BTNBUSCON.Text = "..."
        Me.BTNBUSCON.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNBUSCON.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(444, 535)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(387, 47)
        Me.Label9.TabIndex = 96
        '
        'TXTASE
        '
        Me.TXTASE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTASE.Location = New System.Drawing.Point(13, 437)
        Me.TXTASE.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTASE.MaxLength = 200
        Me.TXTASE.Name = "TXTASE"
        Me.TXTASE.Size = New System.Drawing.Size(341, 29)
        Me.TXTASE.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 410)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 22)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "Aseguradora"
        '
        'TXTPOL
        '
        Me.TXTPOL.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPOL.Location = New System.Drawing.Point(479, 437)
        Me.TXTPOL.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTPOL.MaxLength = 200
        Me.TXTPOL.Name = "TXTPOL"
        Me.TXTPOL.Size = New System.Drawing.Size(341, 29)
        Me.TXTPOL.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(479, 410)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 22)
        Me.Label11.TabIndex = 100
        Me.Label11.Text = "Poliza"
        '
        'TXTPOLMA
        '
        Me.TXTPOLMA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPOLMA.Location = New System.Drawing.Point(479, 496)
        Me.TXTPOLMA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTPOLMA.MaxLength = 200
        Me.TXTPOLMA.Name = "TXTPOLMA"
        Me.TXTPOLMA.Size = New System.Drawing.Size(341, 29)
        Me.TXTPOLMA.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(479, 469)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(218, 22)
        Me.Label12.TabIndex = 104
        Me.Label12.Text = "Poliza Medio Ambiente"
        '
        'TXTASEMA
        '
        Me.TXTASEMA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTASEMA.Location = New System.Drawing.Point(13, 496)
        Me.TXTASEMA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTASEMA.MaxLength = 200
        Me.TXTASEMA.Name = "TXTASEMA"
        Me.TXTASEMA.Size = New System.Drawing.Size(341, 29)
        Me.TXTASEMA.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 469)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(282, 22)
        Me.Label13.TabIndex = 102
        Me.Label13.Text = "Aseguradora Medio Ambiente"
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.Location = New System.Drawing.Point(626, 14)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(113, 95)
        Me.BTNBUSCAR.TabIndex = 16
        Me.BTNBUSCAR.Text = "&b"
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(437, 597)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNCANCELAR.TabIndex = 15
        Me.BTNCANCELAR.Text = "&c"
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.BackColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNELIMINAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNELIMINAR.Image = CType(resources.GetObject("BTNELIMINAR.Image"), System.Drawing.Image)
        Me.BTNELIMINAR.Location = New System.Drawing.Point(17, 535)
        Me.BTNELIMINAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNELIMINAR.TabIndex = 63
        Me.BTNELIMINAR.Text = "&e"
        Me.BTNELIMINAR.UseVisualStyleBackColor = False
        Me.BTNELIMINAR.Visible = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(292, 597)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNGUARDAR.TabIndex = 14
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'BTNINFO
        '
        Me.BTNINFO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTNINFO.BackColor = System.Drawing.SystemColors.Control
        Me.BTNINFO.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNINFO.ForeColor = System.Drawing.Color.Transparent
        Me.BTNINFO.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.btninformacion32
        Me.BTNINFO.Location = New System.Drawing.Point(13, 645)
        Me.BTNINFO.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNINFO.Name = "BTNINFO"
        Me.BTNINFO.Size = New System.Drawing.Size(50, 50)
        Me.BTNINFO.TabIndex = 127
        Me.BTNINFO.Text = "&G"
        Me.BTNINFO.UseVisualStyleBackColor = False
        '
        'frmVehiculosCartaPorte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 718)
        Me.Controls.Add(Me.BTNINFO)
        Me.Controls.Add(Me.TXTPOLMA)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TXTASEMA)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TXTPOL)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TXTASE)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BTNBUSCON)
        Me.Controls.Add(Me.BTNBUSPER)
        Me.Controls.Add(Me.NUDMOD)
        Me.Controls.Add(Me.CBCON)
        Me.Controls.Add(Me.TXTNOM)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBPER)
        Me.Controls.Add(Me.CBACT)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TXTPLACAS)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXTNUMPER)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNELIMINAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.TXTCLA)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVehiculosCartaPorte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vehiculos CartaPorte"
        CType(Me.NUDMOD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBACT As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTPLACAS As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTNUMPER As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BTNBUSCAR As Button
    Private WithEvents BTNCANCELAR As Button
    Friend WithEvents BTNELIMINAR As Button
    Friend WithEvents BTNGUARDAR As Button
    Friend WithEvents TXTCLA As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CBPER As ComboBox
    Friend WithEvents TXTNOM As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CBCON As ComboBox
    Friend WithEvents TTT As ToolTip
    Friend WithEvents NUDMOD As NumericUpDown
    Friend WithEvents BTNBUSPER As Button
    Friend WithEvents BTNBUSCON As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents TXTASE As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TXTPOL As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TXTPOLMA As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TXTASEMA As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents BTNINFO As Button
End Class
