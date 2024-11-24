<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturarV2
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturarV2))
        Me.LBLIEPS = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TXTRFC = New System.Windows.Forms.TextBox
        Me.TXTTAR = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.LBLCCL = New System.Windows.Forms.Label
        Me.LBLIVA = New System.Windows.Forms.Label
        Me.LBLSUB = New System.Windows.Forms.Label
        Me.LBLTOT = New System.Windows.Forms.Label
        Me.CBMP = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CBFP = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LBLDD = New System.Windows.Forms.Label
        Me.CBCALLE = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IEPS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TasaIeps = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GrupoIeps = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TXTNCOM = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TXTNOM = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BTNAGREGAR = New System.Windows.Forms.Button
        Me.BTNCORREO = New System.Windows.Forms.Button
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        Me.BTNBUSCAR = New System.Windows.Forms.Button
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.TXTCOM = New System.Windows.Forms.TextBox
        Me.LBLSER = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LBLFOL = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBLIEPS
        '
        Me.LBLIEPS.AutoSize = True
        Me.LBLIEPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLIEPS.Location = New System.Drawing.Point(376, 541)
        Me.LBLIEPS.Name = "LBLIEPS"
        Me.LBLIEPS.Size = New System.Drawing.Size(99, 20)
        Me.LBLIEPS.TabIndex = 1192
        Me.LBLIEPS.Text = "Ieps $ 0.00"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Cyan
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(14, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(681, 32)
        Me.Label12.TabIndex = 1190
        Me.Label12.Text = "Favor de Revisar el RFC y tratar de no confundir las letras como el ejemplo que s" & _
            "e muestra"
        '
        'TXTRFC
        '
        Me.TXTRFC.BackColor = System.Drawing.Color.Cyan
        Me.TXTRFC.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRFC.Location = New System.Drawing.Point(109, 13)
        Me.TXTRFC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTRFC.MaxLength = 13
        Me.TXTRFC.Name = "TXTRFC"
        Me.TXTRFC.Size = New System.Drawing.Size(224, 26)
        Me.TXTRFC.TabIndex = 1189
        Me.TXTRFC.Text = "1Il6G2Z0Oq95S"
        '
        'TXTTAR
        '
        Me.TXTTAR.BackColor = System.Drawing.Color.Cyan
        Me.TXTTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTAR.Location = New System.Drawing.Point(809, 284)
        Me.TXTTAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTTAR.MaxLength = 4
        Me.TXTTAR.Name = "TXTTAR"
        Me.TXTTAR.Size = New System.Drawing.Size(97, 22)
        Me.TXTTAR.TabIndex = 1187
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(670, 284)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(123, 36)
        Me.Label16.TabIndex = 1188
        Me.Label16.Text = "4 dígitos Tarjeta o Cheque"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LBLCCL
        '
        Me.LBLCCL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LBLCCL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCCL.Location = New System.Drawing.Point(14, 577)
        Me.LBLCCL.Name = "LBLCCL"
        Me.LBLCCL.Size = New System.Drawing.Size(810, 29)
        Me.LBLCCL.TabIndex = 1183
        Me.LBLCCL.Text = "Cantidad con Letra"
        '
        'LBLIVA
        '
        Me.LBLIVA.AutoSize = True
        Me.LBLIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLIVA.Location = New System.Drawing.Point(227, 541)
        Me.LBLIVA.Name = "LBLIVA"
        Me.LBLIVA.Size = New System.Drawing.Size(88, 20)
        Me.LBLIVA.TabIndex = 1182
        Me.LBLIVA.Text = "Iva $ 0.00"
        '
        'LBLSUB
        '
        Me.LBLSUB.AutoSize = True
        Me.LBLSUB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSUB.Location = New System.Drawing.Point(20, 541)
        Me.LBLSUB.Name = "LBLSUB"
        Me.LBLSUB.Size = New System.Drawing.Size(136, 20)
        Me.LBLSUB.TabIndex = 1181
        Me.LBLSUB.Text = "SubTotal $ 0.00"
        '
        'LBLTOT
        '
        Me.LBLTOT.AutoSize = True
        Me.LBLTOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOT.Location = New System.Drawing.Point(564, 541)
        Me.LBLTOT.Name = "LBLTOT"
        Me.LBLTOT.Size = New System.Drawing.Size(104, 20)
        Me.LBLTOT.TabIndex = 1180
        Me.LBLTOT.Text = "Total $ 0.00"
        '
        'CBMP
        '
        Me.CBMP.BackColor = System.Drawing.Color.Cyan
        Me.CBMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBMP.FormattingEnabled = True
        Me.CBMP.Items.AddRange(New Object() {"Aguascalientes ", "Baja California ", "Baja California Sur ", "Campeche ", "Chiapas ", "Chihuahua ", "Coahuila ", "Colima ", "Distrito Federal ", "Durango ", "Estado de México ", "Guanajuato ", "Guerrero ", "Hidalgo ", "Jalisco ", "Michoacán ", "Morelos ", "Nayarit ", "Nuevo León ", "Oaxaca ", "Puebla ", "Querétaro ", "Quintana Roo ", "San Luis Potosí ", "Sinaloa ", "Sonora ", "Tabasco ", "Tamaulipas ", "Tlaxcala ", "Veracruz ", "Yucatán ", "Zacatecas "})
        Me.CBMP.Location = New System.Drawing.Point(85, 298)
        Me.CBMP.Name = "CBMP"
        Me.CBMP.Size = New System.Drawing.Size(204, 24)
        Me.CBMP.TabIndex = 1178
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(126, 277)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 16)
        Me.Label6.TabIndex = 1177
        Me.Label6.Text = "Método de Pago"
        '
        'CBFP
        '
        Me.CBFP.BackColor = System.Drawing.Color.Cyan
        Me.CBFP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBFP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBFP.FormattingEnabled = True
        Me.CBFP.Items.AddRange(New Object() {"Aguascalientes ", "Baja California ", "Baja California Sur ", "Campeche ", "Chiapas ", "Chihuahua ", "Coahuila ", "Colima ", "Distrito Federal ", "Durango ", "Estado de México ", "Guanajuato ", "Guerrero ", "Hidalgo ", "Jalisco ", "Michoacán ", "Morelos ", "Nayarit ", "Nuevo León ", "Oaxaca ", "Puebla ", "Querétaro ", "Quintana Roo ", "San Luis Potosí ", "Sinaloa ", "Sonora ", "Tabasco ", "Tamaulipas ", "Tlaxcala ", "Veracruz ", "Yucatán ", "Zacatecas "})
        Me.CBFP.Location = New System.Drawing.Point(322, 298)
        Me.CBFP.Name = "CBFP"
        Me.CBFP.Size = New System.Drawing.Size(303, 24)
        Me.CBFP.TabIndex = 1176
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(416, 277)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 16)
        Me.Label4.TabIndex = 1175
        Me.Label4.Text = "Forma de Pago"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LBLDD)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 199)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(689, 70)
        Me.GroupBox2.TabIndex = 1174
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Domicilio"
        '
        'LBLDD
        '
        Me.LBLDD.BackColor = System.Drawing.Color.Cyan
        Me.LBLDD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LBLDD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDD.ForeColor = System.Drawing.Color.Red
        Me.LBLDD.Location = New System.Drawing.Point(9, 17)
        Me.LBLDD.Name = "LBLDD"
        Me.LBLDD.Size = New System.Drawing.Size(674, 49)
        Me.LBLDD.TabIndex = 95
        '
        'CBCALLE
        '
        Me.CBCALLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCALLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCALLE.FormattingEnabled = True
        Me.CBCALLE.Items.AddRange(New Object() {"Aguascalientes ", "Baja California ", "Baja California Sur ", "Campeche ", "Chiapas ", "Chihuahua ", "Coahuila ", "Colima ", "Distrito Federal ", "Durango ", "Estado de México ", "Guanajuato ", "Guerrero ", "Hidalgo ", "Jalisco ", "Michoacán ", "Morelos ", "Nayarit ", "Nuevo León ", "Oaxaca ", "Puebla ", "Querétaro ", "Quintana Roo ", "San Luis Potosí ", "Sinaloa ", "Sonora ", "Tabasco ", "Tamaulipas ", "Tlaxcala ", "Veracruz ", "Yucatán ", "Zacatecas "})
        Me.CBCALLE.Location = New System.Drawing.Point(136, 168)
        Me.CBCALLE.Name = "CBCALLE"
        Me.CBCALLE.Size = New System.Drawing.Size(565, 24)
        Me.CBCALLE.TabIndex = 1173
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(82, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 1172
        Me.Label5.Text = "Calle:"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.IEPS, Me.TasaIeps, Me.GrupoIeps})
        Me.DGV.Location = New System.Drawing.Point(14, 328)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.Size = New System.Drawing.Size(810, 210)
        Me.DGV.TabIndex = 1171
        '
        'Column1
        '
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column2.HeaderText = "Cantidad"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 74
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Descripcion"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column4.HeaderText = "Precio"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 62
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column5.HeaderText = "Total"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 56
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column6.HeaderText = "Unidad"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 66
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column7.HeaderText = "IVA"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 49
        '
        'IEPS
        '
        Me.IEPS.HeaderText = "IEPS"
        Me.IEPS.Name = "IEPS"
        Me.IEPS.ReadOnly = True
        '
        'TasaIeps
        '
        Me.TasaIeps.HeaderText = "TasaIeps"
        Me.TasaIeps.Name = "TasaIeps"
        Me.TasaIeps.ReadOnly = True
        Me.TasaIeps.Width = 10
        '
        'GrupoIeps
        '
        Me.GrupoIeps.HeaderText = "GrupoIeps"
        Me.GrupoIeps.Name = "GrupoIeps"
        Me.GrupoIeps.ReadOnly = True
        Me.GrupoIeps.Width = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TXTNCOM)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.TXTNOM)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 77)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(689, 70)
        Me.GroupBox1.TabIndex = 1167
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales"
        '
        'TXTNCOM
        '
        Me.TXTNCOM.Enabled = False
        Me.TXTNCOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNCOM.Location = New System.Drawing.Point(156, 42)
        Me.TXTNCOM.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTNCOM.MaxLength = 100
        Me.TXTNCOM.Name = "TXTNCOM"
        Me.TXTNCOM.Size = New System.Drawing.Size(512, 22)
        Me.TXTNCOM.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(9, 45)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(141, 16)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Nombre Comercial:"
        '
        'TXTNOM
        '
        Me.TXTNOM.BackColor = System.Drawing.Color.Cyan
        Me.TXTNOM.Enabled = False
        Me.TXTNOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOM.ForeColor = System.Drawing.Color.Red
        Me.TXTNOM.Location = New System.Drawing.Point(156, 12)
        Me.TXTNOM.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTNOM.MaxLength = 100
        Me.TXTNOM.Name = "TXTNOM"
        Me.TXTNOM.Size = New System.Drawing.Size(512, 22)
        Me.TXTNOM.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Nombre Fiscal:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 16)
        Me.Label2.TabIndex = 1170
        Me.Label2.Text = "RFC Cliente"
        '
        'BTNAGREGAR
        '
        Me.BTNAGREGAR.BackColor = System.Drawing.Color.White
        Me.BTNAGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNAGREGAR.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BTNAGREGAR.Image = CType(resources.GetObject("BTNAGREGAR.Image"), System.Drawing.Image)
        Me.BTNAGREGAR.Location = New System.Drawing.Point(875, 116)
        Me.BTNAGREGAR.Name = "BTNAGREGAR"
        Me.BTNAGREGAR.Size = New System.Drawing.Size(80, 78)
        Me.BTNAGREGAR.TabIndex = 1193
        Me.BTNAGREGAR.UseVisualStyleBackColor = False
        '
        'BTNCORREO
        '
        Me.BTNCORREO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCORREO.Image = Global.ComercializadoraGT.My.Resources.Resources.EMAIL
        Me.BTNCORREO.Location = New System.Drawing.Point(875, 21)
        Me.BTNCORREO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCORREO.Name = "BTNCORREO"
        Me.BTNCORREO.Size = New System.Drawing.Size(80, 80)
        Me.BTNCORREO.TabIndex = 1184
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.White
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(889, 490)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 1179
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.Location = New System.Drawing.Point(754, 21)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNBUSCAR.TabIndex = 1168
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(755, 116)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 1169
        '
        'TXTCOM
        '
        Me.TXTCOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOM.Location = New System.Drawing.Point(14, 610)
        Me.TXTCOM.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTCOM.MaxLength = 100
        Me.TXTCOM.Multiline = True
        Me.TXTCOM.Name = "TXTCOM"
        Me.TXTCOM.Size = New System.Drawing.Size(810, 60)
        Me.TXTCOM.TabIndex = 1194
        '
        'LBLSER
        '
        Me.LBLSER.AutoSize = True
        Me.LBLSER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSER.Location = New System.Drawing.Point(416, 17)
        Me.LBLSER.Name = "LBLSER"
        Me.LBLSER.Size = New System.Drawing.Size(77, 16)
        Me.LBLSER.TabIndex = 1195
        Me.LBLSER.Text = "Serie: 111"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(830, 635)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 16)
        Me.Label1.TabIndex = 1196
        Me.Label1.Text = "<-- Comentario"
        '
        'LBLFOL
        '
        Me.LBLFOL.AutoSize = True
        Me.LBLFOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFOL.Location = New System.Drawing.Point(565, 18)
        Me.LBLFOL.Name = "LBLFOL"
        Me.LBLFOL.Size = New System.Drawing.Size(75, 16)
        Me.LBLFOL.TabIndex = 1197
        Me.LBLFOL.Text = "Folio: 111"
        '
        'frmFacturarV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 672)
        Me.Controls.Add(Me.LBLFOL)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LBLSER)
        Me.Controls.Add(Me.TXTCOM)
        Me.Controls.Add(Me.BTNAGREGAR)
        Me.Controls.Add(Me.LBLIEPS)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TXTRFC)
        Me.Controls.Add(Me.TXTTAR)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.BTNCORREO)
        Me.Controls.Add(Me.LBLCCL)
        Me.Controls.Add(Me.LBLIVA)
        Me.Controls.Add(Me.LBLSUB)
        Me.Controls.Add(Me.LBLTOT)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.CBMP)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CBFP)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.CBCALLE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFacturarV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturar Complementos"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNAGREGAR As System.Windows.Forms.Button
    Friend WithEvents LBLIEPS As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTRFC As System.Windows.Forms.TextBox
    Friend WithEvents TXTTAR As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents BTNCORREO As System.Windows.Forms.Button
    Friend WithEvents LBLCCL As System.Windows.Forms.Label
    Friend WithEvents LBLIVA As System.Windows.Forms.Label
    Friend WithEvents LBLSUB As System.Windows.Forms.Label
    Friend WithEvents LBLTOT As System.Windows.Forms.Label
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents CBMP As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CBFP As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LBLDD As System.Windows.Forms.Label
    Friend WithEvents CBCALLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IEPS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TasaIeps As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GrupoIeps As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTNCOM As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TXTNOM As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTCOM As System.Windows.Forms.TextBox
    Friend WithEvents LBLSER As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LBLFOL As System.Windows.Forms.Label
End Class
