<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientes))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTNMOSTRAR = New System.Windows.Forms.Button()
        Me.LBLNFIS = New System.Windows.Forms.Label()
        Me.CBFA = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CBCALLE = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTRFC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBDC = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTCRED = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CBACT = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTMAIL = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTCEL = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTTEL = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTDIR = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTNOM = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTCLA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BTNCANCELAR = New System.Windows.Forms.Button()
        Me.BTNBUSCAR = New System.Windows.Forms.Button()
        Me.BTNELIMINAR = New System.Windows.Forms.Button()
        Me.BTNGUARDAR = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTNMOSTRAR)
        Me.GroupBox1.Controls.Add(Me.LBLNFIS)
        Me.GroupBox1.Controls.Add(Me.CBFA)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.CBCALLE)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TXTRFC)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBDC)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TXTCRED)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.CBACT)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TXTMAIL)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TXTCEL)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TXTTEL)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TXTDIR)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TXTNOM)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 123)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(777, 512)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " "
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.Color.Transparent
        Me.BTNMOSTRAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMOSTRAR.ForeColor = System.Drawing.Color.Black
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(664, 251)
        Me.BTNMOSTRAR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(69, 32)
        Me.BTNMOSTRAR.TabIndex = 1523
        Me.BTNMOSTRAR.Text = "..."
        Me.BTNMOSTRAR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'LBLNFIS
        '
        Me.LBLNFIS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNFIS.Location = New System.Drawing.Point(16, 302)
        Me.LBLNFIS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLNFIS.Name = "LBLNFIS"
        Me.LBLNFIS.Size = New System.Drawing.Size(753, 84)
        Me.LBLNFIS.TabIndex = 65
        Me.LBLNFIS.Text = "RFC"
        '
        'CBFA
        '
        Me.CBFA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBFA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBFA.FormattingEnabled = True
        Me.CBFA.Items.AddRange(New Object() {"No", "Si"})
        Me.CBFA.Location = New System.Drawing.Point(547, 252)
        Me.CBFA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBFA.Name = "CBFA"
        Me.CBFA.Size = New System.Drawing.Size(95, 30)
        Me.CBFA.TabIndex = 63
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(543, 226)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(159, 22)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "Fac. Automática"
        '
        'CBCALLE
        '
        Me.CBCALLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCALLE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCALLE.FormattingEnabled = True
        Me.CBCALLE.Items.AddRange(New Object() {"7", "15", "20", "30"})
        Me.CBCALLE.Location = New System.Drawing.Point(160, 390)
        Me.CBCALLE.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBCALLE.Name = "CBCALLE"
        Me.CBCALLE.Size = New System.Drawing.Size(559, 30)
        Me.CBCALLE.TabIndex = 61
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 400)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 22)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Dom. Cliente"
        '
        'TXTRFC
        '
        Me.TXTRFC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRFC.Location = New System.Drawing.Point(171, 252)
        Me.TXTRFC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTRFC.MaxLength = 20
        Me.TXTRFC.Name = "TXTRFC"
        Me.TXTRFC.Size = New System.Drawing.Size(351, 29)
        Me.TXTRFC.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(107, 262)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 22)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "RFC"
        '
        'CBDC
        '
        Me.CBDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBDC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBDC.FormattingEnabled = True
        Me.CBDC.Items.AddRange(New Object() {"7", "15", "20", "30"})
        Me.CBDC.Location = New System.Drawing.Point(160, 431)
        Me.CBDC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBDC.Name = "CBDC"
        Me.CBDC.Size = New System.Drawing.Size(172, 30)
        Me.CBDC.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 441)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(123, 22)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Dias Credito"
        '
        'TXTCRED
        '
        Me.TXTCRED.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCRED.Location = New System.Drawing.Point(171, 212)
        Me.TXTCRED.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTCRED.MaxLength = 8
        Me.TXTCRED.Name = "TXTCRED"
        Me.TXTCRED.Size = New System.Drawing.Size(351, 29)
        Me.TXTCRED.TabIndex = 5
        Me.TXTCRED.Text = "1.00"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(80, 222)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 22)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Credito"
        '
        'CBACT
        '
        Me.CBACT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBACT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBACT.FormattingEnabled = True
        Me.CBACT.Items.AddRange(New Object() {"Si", "No"})
        Me.CBACT.Location = New System.Drawing.Point(160, 471)
        Me.CBACT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBACT.Name = "CBACT"
        Me.CBACT.Size = New System.Drawing.Size(95, 30)
        Me.CBACT.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(79, 478)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 22)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Activo"
        '
        'TXTMAIL
        '
        Me.TXTMAIL.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMAIL.Location = New System.Drawing.Point(171, 174)
        Me.TXTMAIL.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTMAIL.MaxLength = 50
        Me.TXTMAIL.Name = "TXTMAIL"
        Me.TXTMAIL.Size = New System.Drawing.Size(559, 29)
        Me.TXTMAIL.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(108, 183)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 22)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Mail"
        '
        'TXTCEL
        '
        Me.TXTCEL.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCEL.Location = New System.Drawing.Point(171, 139)
        Me.TXTCEL.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTCEL.MaxLength = 100
        Me.TXTCEL.Name = "TXTCEL"
        Me.TXTCEL.Size = New System.Drawing.Size(559, 29)
        Me.TXTCEL.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(76, 149)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 22)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Celular"
        '
        'TXTTEL
        '
        Me.TXTTEL.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTEL.Location = New System.Drawing.Point(171, 105)
        Me.TXTTEL.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTTEL.MaxLength = 100
        Me.TXTTEL.Name = "TXTTEL"
        Me.TXTTEL.Size = New System.Drawing.Size(559, 29)
        Me.TXTTEL.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(68, 114)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 22)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Teléfono"
        '
        'TXTDIR
        '
        Me.TXTDIR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDIR.Location = New System.Drawing.Point(171, 70)
        Me.TXTDIR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTDIR.MaxLength = 100
        Me.TXTDIR.Name = "TXTDIR"
        Me.TXTDIR.Size = New System.Drawing.Size(559, 29)
        Me.TXTDIR.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(57, 80)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 22)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Dirección"
        '
        'TXTNOM
        '
        Me.TXTNOM.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOM.Location = New System.Drawing.Point(171, 36)
        Me.TXTNOM.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTNOM.MaxLength = 100
        Me.TXTNOM.Name = "TXTNOM"
        Me.TXTNOM.Size = New System.Drawing.Size(559, 29)
        Me.TXTNOM.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(69, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 22)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Nombre"
        '
        'TXTCLA
        '
        Me.TXTCLA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLA.Location = New System.Drawing.Point(197, 65)
        Me.TXTCLA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTCLA.MaxLength = 3
        Me.TXTCLA.Name = "TXTCLA"
        Me.TXTCLA.Size = New System.Drawing.Size(105, 29)
        Me.TXTCLA.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(124, 75)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 22)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Clave"
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(515, 645)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNCANCELAR.TabIndex = 3
        Me.BTNCANCELAR.Text = "&c"
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.Location = New System.Drawing.Point(691, 18)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(113, 95)
        Me.BTNBUSCAR.TabIndex = 4
        Me.BTNBUSCAR.Text = "&b"
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.BackColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNELIMINAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNELIMINAR.Image = CType(resources.GetObject("BTNELIMINAR.Image"), System.Drawing.Image)
        Me.BTNELIMINAR.Location = New System.Drawing.Point(353, 645)
        Me.BTNELIMINAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNELIMINAR.TabIndex = 2
        Me.BTNELIMINAR.Text = "&e"
        Me.BTNELIMINAR.UseVisualStyleBackColor = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(187, 645)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNGUARDAR.TabIndex = 1
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'frmClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 759)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.BTNELIMINAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TXTCLA)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClientes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Clientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CBDC As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CBACT As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTMAIL As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTCEL As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTTEL As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTDIR As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTNOM As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTCLA As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTCRED As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNELIMINAR As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents TXTRFC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LBLNFIS As System.Windows.Forms.Label
    Friend WithEvents CBFA As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CBCALLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
End Class
