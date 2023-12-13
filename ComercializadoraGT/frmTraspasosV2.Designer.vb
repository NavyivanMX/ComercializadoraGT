<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraspasosV2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraspasosV2))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BTNGUARDAR = New System.Windows.Forms.Button()
        Me.BTNELIMINAR = New System.Windows.Forms.Button()
        Me.CBALM = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LBLPED = New System.Windows.Forms.Label()
        Me.LBLTA = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTNQUITAR = New System.Windows.Forms.Button()
        Me.BTNAGREGAR = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTNBUS = New System.Windows.Forms.Button()
        Me.CBUNI = New System.Windows.Forms.ComboBox()
        Me.LBLDES = New System.Windows.Forms.Label()
        Me.CBGRU = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CBPROD = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LBLCANTEXIS = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTCANT = New System.Windows.Forms.TextBox()
        Me.LBLUNIEXIS = New System.Windows.Forms.Label()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(1233, 641)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNGUARDAR.TabIndex = 417
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.BackColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNELIMINAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNELIMINAR.Image = CType(resources.GetObject("BTNELIMINAR.Image"), System.Drawing.Image)
        Me.BTNELIMINAR.Location = New System.Drawing.Point(1233, 518)
        Me.BTNELIMINAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNELIMINAR.TabIndex = 416
        Me.BTNELIMINAR.Text = "&E"
        Me.BTNELIMINAR.UseVisualStyleBackColor = False
        '
        'CBALM
        '
        Me.CBALM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBALM.FormattingEnabled = True
        Me.CBALM.Location = New System.Drawing.Point(519, 15)
        Me.CBALM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBALM.Name = "CBALM"
        Me.CBALM.Size = New System.Drawing.Size(660, 32)
        Me.CBALM.TabIndex = 412
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(420, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 24)
        Me.Label2.TabIndex = 411
        Me.Label2.Text = "Destino"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(173, 756)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(187, 20)
        Me.Label6.TabIndex = 415
        Me.Label6.Text = "Productos agregados"
        '
        'LBLPED
        '
        Me.LBLPED.AutoSize = True
        Me.LBLPED.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPED.ForeColor = System.Drawing.Color.Blue
        Me.LBLPED.Location = New System.Drawing.Point(175, 25)
        Me.LBLPED.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLPED.Name = "LBLPED"
        Me.LBLPED.Size = New System.Drawing.Size(21, 24)
        Me.LBLPED.TabIndex = 410
        Me.LBLPED.Text = "0"
        '
        'LBLTA
        '
        Me.LBLTA.AutoSize = True
        Me.LBLTA.BackColor = System.Drawing.Color.Transparent
        Me.LBLTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTA.ForeColor = System.Drawing.Color.Blue
        Me.LBLTA.Location = New System.Drawing.Point(405, 756)
        Me.LBLTA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLTA.Name = "LBLTA"
        Me.LBLTA.Size = New System.Drawing.Size(19, 20)
        Me.LBLTA.TabIndex = 414
        Me.LBLTA.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 24)
        Me.Label1.TabIndex = 408
        Me.Label1.Text = "No Traspaso"
        '
        'BTNQUITAR
        '
        Me.BTNQUITAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNQUITAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNQUITAR.Image = CType(resources.GetObject("BTNQUITAR.Image"), System.Drawing.Image)
        Me.BTNQUITAR.Location = New System.Drawing.Point(1233, 388)
        Me.BTNQUITAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTNQUITAR.Name = "BTNQUITAR"
        Me.BTNQUITAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNQUITAR.TabIndex = 409
        Me.BTNQUITAR.UseVisualStyleBackColor = False
        '
        'BTNAGREGAR
        '
        Me.BTNAGREGAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNAGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNAGREGAR.ForeColor = System.Drawing.Color.White
        Me.BTNAGREGAR.Image = CType(resources.GetObject("BTNAGREGAR.Image"), System.Drawing.Image)
        Me.BTNAGREGAR.Location = New System.Drawing.Point(1233, 263)
        Me.BTNAGREGAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTNAGREGAR.Name = "BTNAGREGAR"
        Me.BTNAGREGAR.Size = New System.Drawing.Size(107, 96)
        Me.BTNAGREGAR.TabIndex = 407
        Me.BTNAGREGAR.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTNBUS)
        Me.GroupBox1.Controls.Add(Me.CBUNI)
        Me.GroupBox1.Controls.Add(Me.LBLDES)
        Me.GroupBox1.Controls.Add(Me.CBGRU)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.CBPROD)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.LBLCANTEXIS)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TXTCANT)
        Me.GroupBox1.Controls.Add(Me.LBLUNIEXIS)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 95)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1332, 138)
        Me.GroupBox1.TabIndex = 406
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Productos"
        '
        'BTNBUS
        '
        Me.BTNBUS.Location = New System.Drawing.Point(591, 26)
        Me.BTNBUS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTNBUS.Name = "BTNBUS"
        Me.BTNBUS.Size = New System.Drawing.Size(100, 71)
        Me.BTNBUS.TabIndex = 397
        Me.BTNBUS.Text = "..."
        Me.BTNBUS.UseVisualStyleBackColor = True
        '
        'CBUNI
        '
        Me.CBUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBUNI.FormattingEnabled = True
        Me.CBUNI.Location = New System.Drawing.Point(1123, 75)
        Me.CBUNI.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBUNI.Name = "CBUNI"
        Me.CBUNI.Size = New System.Drawing.Size(188, 32)
        Me.CBUNI.TabIndex = 396
        '
        'LBLDES
        '
        Me.LBLDES.AutoSize = True
        Me.LBLDES.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDES.Location = New System.Drawing.Point(117, 103)
        Me.LBLDES.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLDES.Name = "LBLDES"
        Me.LBLDES.Size = New System.Drawing.Size(121, 24)
        Me.LBLDES.TabIndex = 298
        Me.LBLDES.Text = "Descripción"
        '
        'CBGRU
        '
        Me.CBGRU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBGRU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGRU.FormattingEnabled = True
        Me.CBGRU.Location = New System.Drawing.Point(121, 26)
        Me.CBGRU.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBGRU.Name = "CBGRU"
        Me.CBGRU.Size = New System.Drawing.Size(460, 28)
        Me.CBGRU.TabIndex = 295
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 75)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Producto"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(40, 32)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 24)
        Me.Label10.TabIndex = 296
        Me.Label10.Text = "Grupo"
        '
        'CBPROD
        '
        Me.CBPROD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPROD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPROD.FormattingEnabled = True
        Me.CBPROD.Location = New System.Drawing.Point(121, 63)
        Me.CBPROD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBPROD.Name = "CBPROD"
        Me.CBPROD.Size = New System.Drawing.Size(460, 32)
        Me.CBPROD.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(731, 36)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 24)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Existencia"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1039, 82)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 24)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Unidad"
        '
        'LBLCANTEXIS
        '
        Me.LBLCANTEXIS.AutoSize = True
        Me.LBLCANTEXIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCANTEXIS.ForeColor = System.Drawing.Color.Blue
        Me.LBLCANTEXIS.Location = New System.Drawing.Point(759, 64)
        Me.LBLCANTEXIS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLCANTEXIS.Name = "LBLCANTEXIS"
        Me.LBLCANTEXIS.Size = New System.Drawing.Size(21, 24)
        Me.LBLCANTEXIS.TabIndex = 9
        Me.LBLCANTEXIS.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1020, 36)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 24)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Cantidad"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(892, 36)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 24)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Unidad"
        '
        'TXTCANT
        '
        Me.TXTCANT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTCANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT.Location = New System.Drawing.Point(1127, 27)
        Me.TXTCANT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TXTCANT.Name = "TXTCANT"
        Me.TXTCANT.Size = New System.Drawing.Size(184, 29)
        Me.TXTCANT.TabIndex = 12
        Me.TXTCANT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLUNIEXIS
        '
        Me.LBLUNIEXIS.AutoSize = True
        Me.LBLUNIEXIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUNIEXIS.ForeColor = System.Drawing.Color.Blue
        Me.LBLUNIEXIS.Location = New System.Drawing.Point(896, 65)
        Me.LBLUNIEXIS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLUNIEXIS.Name = "LBLUNIEXIS"
        Me.LBLUNIEXIS.Size = New System.Drawing.Size(21, 24)
        Me.LBLUNIEXIS.TabIndex = 11
        Me.LBLUNIEXIS.Text = "0"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV.DefaultCellStyle = DataGridViewCellStyle11
        Me.DGV.Location = New System.Drawing.Point(8, 236)
        Me.DGV.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV.Name = "DGV"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DGV.Size = New System.Drawing.Size(1205, 503)
        Me.DGV.TabIndex = 1054
        '
        'frmTraspasosV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1360, 784)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.BTNELIMINAR)
        Me.Controls.Add(Me.CBALM)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LBLPED)
        Me.Controls.Add(Me.LBLTA)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTNQUITAR)
        Me.Controls.Add(Me.BTNAGREGAR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraspasosV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traspasos V2"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents BTNELIMINAR As System.Windows.Forms.Button
    Friend WithEvents CBALM As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LBLPED As System.Windows.Forms.Label
    Friend WithEvents LBLTA As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents BTNQUITAR As System.Windows.Forms.Button
    Friend WithEvents BTNAGREGAR As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNBUS As System.Windows.Forms.Button
    Friend WithEvents CBUNI As System.Windows.Forms.ComboBox
    Friend WithEvents LBLDES As System.Windows.Forms.Label
    Friend WithEvents CBGRU As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CBPROD As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LBLCANTEXIS As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTCANT As System.Windows.Forms.TextBox
    Friend WithEvents LBLUNIEXIS As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
End Class
