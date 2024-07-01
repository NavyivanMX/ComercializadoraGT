<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAlmacenesCartaPorte
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlmacenesCartaPorte))
        Me.TXTUBI = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTRESP = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTRES = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTTRI = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTNOEXT = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTCALLE = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTCOL = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTNOINT = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTCP = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTPAIS = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXTMUN = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TXTREF = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXTLOC = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CBALM = New System.Windows.Forms.ComboBox()
        Me.BTNBUSPER = New System.Windows.Forms.Button()
        Me.TXTRFC = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BTNINFO = New System.Windows.Forms.Button()
        Me.BTNGUARDAR = New System.Windows.Forms.Button()
        Me.CBEDO = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'TXTUBI
        '
        Me.TXTUBI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUBI.Location = New System.Drawing.Point(176, 166)
        Me.TXTUBI.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTUBI.MaxLength = 200
        Me.TXTUBI.Name = "TXTUBI"
        Me.TXTUBI.Size = New System.Drawing.Size(341, 29)
        Me.TXTUBI.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 173)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 22)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Id Ubicación"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 56)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 22)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Almacen"
        '
        'TXTRESP
        '
        Me.TXTRESP.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRESP.Location = New System.Drawing.Point(176, 205)
        Me.TXTRESP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTRESP.MaxLength = 200
        Me.TXTRESP.Name = "TXTRESP"
        Me.TXTRESP.Size = New System.Drawing.Size(341, 29)
        Me.TXTRESP.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 212)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 22)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Responsable"
        '
        'TXTRES
        '
        Me.TXTRES.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRES.Location = New System.Drawing.Point(176, 283)
        Me.TXTRES.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTRES.MaxLength = 200
        Me.TXTRES.Name = "TXTRES"
        Me.TXTRES.Size = New System.Drawing.Size(341, 29)
        Me.TXTRES.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(59, 290)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 22)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "Res. Fiscal"
        '
        'TXTTRI
        '
        Me.TXTTRI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTRI.Location = New System.Drawing.Point(176, 244)
        Me.TXTTRI.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTTRI.MaxLength = 200
        Me.TXTTRI.Name = "TXTTRI"
        Me.TXTTRI.Size = New System.Drawing.Size(341, 29)
        Me.TXTTRI.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 251)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 22)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Num Reg Id Trib"
        '
        'TXTNOEXT
        '
        Me.TXTNOEXT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOEXT.Location = New System.Drawing.Point(176, 361)
        Me.TXTNOEXT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTNOEXT.MaxLength = 200
        Me.TXTNOEXT.Name = "TXTNOEXT"
        Me.TXTNOEXT.Size = New System.Drawing.Size(341, 29)
        Me.TXTNOEXT.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(98, 368)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 22)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "No Ext"
        '
        'TXTCALLE
        '
        Me.TXTCALLE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCALLE.Location = New System.Drawing.Point(176, 322)
        Me.TXTCALLE.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTCALLE.MaxLength = 200
        Me.TXTCALLE.Name = "TXTCALLE"
        Me.TXTCALLE.Size = New System.Drawing.Size(341, 29)
        Me.TXTCALLE.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(112, 329)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 22)
        Me.Label7.TabIndex = 103
        Me.Label7.Text = "Calle"
        '
        'TXTCOL
        '
        Me.TXTCOL.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOL.Location = New System.Drawing.Point(714, 166)
        Me.TXTCOL.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTCOL.MaxLength = 200
        Me.TXTCOL.Name = "TXTCOL"
        Me.TXTCOL.Size = New System.Drawing.Size(341, 29)
        Me.TXTCOL.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(628, 173)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 22)
        Me.Label8.TabIndex = 109
        Me.Label8.Text = "Colonia"
        '
        'TXTNOINT
        '
        Me.TXTNOINT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOINT.Location = New System.Drawing.Point(176, 400)
        Me.TXTNOINT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTNOINT.MaxLength = 200
        Me.TXTNOINT.Name = "TXTNOINT"
        Me.TXTNOINT.Size = New System.Drawing.Size(341, 29)
        Me.TXTNOINT.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(104, 407)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 22)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "No Int"
        '
        'TXTCP
        '
        Me.TXTCP.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCP.Location = New System.Drawing.Point(714, 400)
        Me.TXTCP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTCP.MaxLength = 200
        Me.TXTCP.Name = "TXTCP"
        Me.TXTCP.Size = New System.Drawing.Size(341, 29)
        Me.TXTCP.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(556, 407)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(150, 22)
        Me.Label12.TabIndex = 121
        Me.Label12.Text = "Codigo Postal *"
        '
        'TXTPAIS
        '
        Me.TXTPAIS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPAIS.Location = New System.Drawing.Point(714, 361)
        Me.TXTPAIS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTPAIS.MaxLength = 200
        Me.TXTPAIS.Name = "TXTPAIS"
        Me.TXTPAIS.ReadOnly = True
        Me.TXTPAIS.Size = New System.Drawing.Size(341, 29)
        Me.TXTPAIS.TabIndex = 15
        Me.TXTPAIS.Text = "MEX - México"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(644, 368)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 22)
        Me.Label13.TabIndex = 119
        Me.Label13.Text = "Pais *"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(619, 329)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 22)
        Me.Label14.TabIndex = 117
        Me.Label14.Text = "Estado *"
        '
        'TXTMUN
        '
        Me.TXTMUN.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMUN.Location = New System.Drawing.Point(714, 283)
        Me.TXTMUN.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTMUN.MaxLength = 200
        Me.TXTMUN.Name = "TXTMUN"
        Me.TXTMUN.Size = New System.Drawing.Size(341, 29)
        Me.TXTMUN.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(609, 290)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 22)
        Me.Label15.TabIndex = 115
        Me.Label15.Text = "Municipio"
        '
        'TXTREF
        '
        Me.TXTREF.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREF.Location = New System.Drawing.Point(714, 244)
        Me.TXTREF.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTREF.MaxLength = 200
        Me.TXTREF.Name = "TXTREF"
        Me.TXTREF.Size = New System.Drawing.Size(341, 29)
        Me.TXTREF.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(597, 251)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 22)
        Me.Label16.TabIndex = 113
        Me.Label16.Text = "Referencia"
        '
        'TXTLOC
        '
        Me.TXTLOC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOC.Location = New System.Drawing.Point(714, 205)
        Me.TXTLOC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTLOC.MaxLength = 200
        Me.TXTLOC.Name = "TXTLOC"
        Me.TXTLOC.Size = New System.Drawing.Size(341, 29)
        Me.TXTLOC.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(607, 212)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 22)
        Me.Label17.TabIndex = 111
        Me.Label17.Text = "Localidad"
        '
        'CBALM
        '
        Me.CBALM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBALM.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBALM.FormattingEnabled = True
        Me.CBALM.Items.AddRange(New Object() {"O-", "O+", "A-", "A+", "B-", "B+", "AB-", "AB+", "ORH-", "ORH+", "RH-", "RH+", "UNIVERSAL", ""})
        Me.CBALM.Location = New System.Drawing.Point(176, 53)
        Me.CBALM.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBALM.Name = "CBALM"
        Me.CBALM.Size = New System.Drawing.Size(777, 30)
        Me.CBALM.TabIndex = 0
        '
        'BTNBUSPER
        '
        Me.BTNBUSPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSPER.Location = New System.Drawing.Point(980, 53)
        Me.BTNBUSPER.Name = "BTNBUSPER"
        Me.BTNBUSPER.Size = New System.Drawing.Size(75, 30)
        Me.BTNBUSPER.TabIndex = 1
        Me.BTNBUSPER.Text = "..."
        Me.BTNBUSPER.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNBUSPER.UseVisualStyleBackColor = True
        '
        'TXTRFC
        '
        Me.TXTRFC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRFC.Location = New System.Drawing.Point(176, 102)
        Me.TXTRFC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTRFC.MaxLength = 200
        Me.TXTRFC.Name = "TXTRFC"
        Me.TXTRFC.Size = New System.Drawing.Size(341, 29)
        Me.TXTRFC.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(119, 109)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 22)
        Me.Label10.TabIndex = 125
        Me.Label10.Text = "RFC"
        '
        'BTNINFO
        '
        Me.BTNINFO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTNINFO.BackColor = System.Drawing.SystemColors.Control
        Me.BTNINFO.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNINFO.ForeColor = System.Drawing.Color.Transparent
        Me.BTNINFO.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.btninformacion32
        Me.BTNINFO.Location = New System.Drawing.Point(13, 502)
        Me.BTNINFO.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNINFO.Name = "BTNINFO"
        Me.BTNINFO.Size = New System.Drawing.Size(50, 50)
        Me.BTNINFO.TabIndex = 126
        Me.BTNINFO.Text = "&G"
        Me.BTNINFO.UseVisualStyleBackColor = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(506, 454)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNGUARDAR.TabIndex = 17
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'CBEDO
        '
        Me.CBEDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBEDO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBEDO.FormattingEnabled = True
        Me.CBEDO.Items.AddRange(New Object() {"O-", "O+", "A-", "A+", "B-", "B+", "AB-", "AB+", "ORH-", "ORH+", "RH-", "RH+", "UNIVERSAL", ""})
        Me.CBEDO.Location = New System.Drawing.Point(714, 322)
        Me.CBEDO.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBEDO.Name = "CBEDO"
        Me.CBEDO.Size = New System.Drawing.Size(341, 30)
        Me.CBEDO.TabIndex = 127
        '
        'frmAlmacenesCartaPorte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1120, 566)
        Me.Controls.Add(Me.CBEDO)
        Me.Controls.Add(Me.BTNINFO)
        Me.Controls.Add(Me.TXTRFC)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.BTNBUSPER)
        Me.Controls.Add(Me.CBALM)
        Me.Controls.Add(Me.TXTCP)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TXTPAIS)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TXTMUN)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TXTREF)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TXTLOC)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TXTCOL)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXTNOINT)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TXTNOEXT)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TXTCALLE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TXTRES)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTTRI)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXTRESP)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXTUBI)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAlmacenesCartaPorte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Almacenes Carta-Porte"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTNGUARDAR As Button
    Friend WithEvents TXTUBI As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTRESP As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTRES As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTTRI As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTNOEXT As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTCALLE As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTCOL As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TXTNOINT As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TXTCP As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TXTPAIS As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TXTMUN As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TXTREF As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TXTLOC As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents CBALM As ComboBox
    Friend WithEvents BTNBUSPER As Button
    Friend WithEvents TXTRFC As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents BTNINFO As Button
    Friend WithEvents CBEDO As ComboBox
End Class
