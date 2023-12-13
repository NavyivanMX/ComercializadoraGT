<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidos))
        Me.CBPROD = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CBGRU = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.LBLTP = New System.Windows.Forms.Label
        Me.CBTP = New System.Windows.Forms.ComboBox
        Me.LBLPED = New System.Windows.Forms.TextBox
        Me.DTFECHA = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTCANT = New System.Windows.Forms.TextBox
        Me.CBUNI = New System.Windows.Forms.ComboBox
        Me.LBLDES = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.LBLCUANTOS = New System.Windows.Forms.Label
        Me.LBLTOT = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.BTNBUSCAR = New System.Windows.Forms.Button
        Me.BTNAGREGAR = New System.Windows.Forms.Button
        Me.BTNQUITAR = New System.Windows.Forms.Button
        Me.BTNELIMINAR = New System.Windows.Forms.Button
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        Me.TXTCLA = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBPROD
        '
        Me.CBPROD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPROD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPROD.FormattingEnabled = True
        Me.CBPROD.Location = New System.Drawing.Point(281, 84)
        Me.CBPROD.Name = "CBPROD"
        Me.CBPROD.Size = New System.Drawing.Size(553, 24)
        Me.CBPROD.TabIndex = 1069
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(196, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 18)
        Me.Label7.TabIndex = 1072
        Me.Label7.Text = "Producto"
        '
        'CBGRU
        '
        Me.CBGRU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBGRU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGRU.FormattingEnabled = True
        Me.CBGRU.Location = New System.Drawing.Point(280, 52)
        Me.CBGRU.Name = "CBGRU"
        Me.CBGRU.Size = New System.Drawing.Size(554, 24)
        Me.CBGRU.TabIndex = 1068
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(219, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 18)
        Me.Label8.TabIndex = 1070
        Me.Label8.Text = "Grupo"
        '
        'LBLTP
        '
        Me.LBLTP.AutoSize = True
        Me.LBLTP.BackColor = System.Drawing.Color.Transparent
        Me.LBLTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTP.Location = New System.Drawing.Point(12, 3)
        Me.LBLTP.Name = "LBLTP"
        Me.LBLTP.Size = New System.Drawing.Size(0, 16)
        Me.LBLTP.TabIndex = 1067
        '
        'CBTP
        '
        Me.CBTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTP.FormattingEnabled = True
        Me.CBTP.Location = New System.Drawing.Point(482, 12)
        Me.CBTP.Name = "CBTP"
        Me.CBTP.Size = New System.Drawing.Size(151, 24)
        Me.CBTP.TabIndex = 1056
        '
        'LBLPED
        '
        Me.LBLPED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.LBLPED.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPED.Location = New System.Drawing.Point(798, 12)
        Me.LBLPED.MaxLength = 10
        Me.LBLPED.Name = "LBLPED"
        Me.LBLPED.ReadOnly = True
        Me.LBLPED.Size = New System.Drawing.Size(144, 26)
        Me.LBLPED.TabIndex = 1062
        '
        'DTFECHA
        '
        Me.DTFECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHA.Location = New System.Drawing.Point(292, 12)
        Me.DTFECHA.Name = "DTFECHA"
        Me.DTFECHA.Size = New System.Drawing.Size(119, 26)
        Me.DTFECHA.TabIndex = 1060
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(235, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 16)
        Me.Label11.TabIndex = 1059
        Me.Label11.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(688, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 1058
        Me.Label2.Text = "No de Pedido"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(539, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 16)
        Me.Label6.TabIndex = 1076
        Me.Label6.Text = "Unidad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(403, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 1075
        Me.Label1.Text = "Cantidad"
        '
        'TXTCANT
        '
        Me.TXTCANT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT.Location = New System.Drawing.Point(395, 207)
        Me.TXTCANT.MaxLength = 5
        Me.TXTCANT.Name = "TXTCANT"
        Me.TXTCANT.Size = New System.Drawing.Size(91, 26)
        Me.TXTCANT.TabIndex = 1073
        Me.TXTCANT.Text = "0"
        Me.TXTCANT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CBUNI
        '
        Me.CBUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBUNI.FormattingEnabled = True
        Me.CBUNI.Items.AddRange(New Object() {"YDS", "MTS", "PZA"})
        Me.CBUNI.Location = New System.Drawing.Point(505, 209)
        Me.CBUNI.Name = "CBUNI"
        Me.CBUNI.Size = New System.Drawing.Size(142, 24)
        Me.CBUNI.TabIndex = 1074
        '
        'LBLDES
        '
        Me.LBLDES.AutoSize = True
        Me.LBLDES.BackColor = System.Drawing.Color.Transparent
        Me.LBLDES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDES.Location = New System.Drawing.Point(277, 164)
        Me.LBLDES.Name = "LBLDES"
        Me.LBLDES.Size = New System.Drawing.Size(91, 16)
        Me.LBLDES.TabIndex = 1078
        Me.LBLDES.Text = "Descripcion"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(15, 249)
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
        Me.DGV.Size = New System.Drawing.Size(941, 317)
        Me.DGV.TabIndex = 1079
        '
        'LBLCUANTOS
        '
        Me.LBLCUANTOS.AutoSize = True
        Me.LBLCUANTOS.BackColor = System.Drawing.Color.Transparent
        Me.LBLCUANTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCUANTOS.Location = New System.Drawing.Point(227, 582)
        Me.LBLCUANTOS.Name = "LBLCUANTOS"
        Me.LBLCUANTOS.Size = New System.Drawing.Size(16, 16)
        Me.LBLCUANTOS.TabIndex = 1086
        Me.LBLCUANTOS.Text = "0"
        '
        'LBLTOT
        '
        Me.LBLTOT.AutoSize = True
        Me.LBLTOT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOT.ForeColor = System.Drawing.Color.Blue
        Me.LBLTOT.Location = New System.Drawing.Point(724, 574)
        Me.LBLTOT.Name = "LBLTOT"
        Me.LBLTOT.Size = New System.Drawing.Size(21, 24)
        Me.LBLTOT.TabIndex = 1085
        Me.LBLTOT.Text = "0"
        Me.LBLTOT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LBLTOT.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(656, 580)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 1084
        Me.Label5.Text = "Total:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Visible = False
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.ForeColor = System.Drawing.Color.Black
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNBUSCAR.Location = New System.Drawing.Point(15, 105)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(127, 35)
        Me.BTNBUSCAR.TabIndex = 1090
        Me.BTNBUSCAR.Text = "        F10 Buscar"
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'BTNAGREGAR
        '
        Me.BTNAGREGAR.BackColor = System.Drawing.Color.White
        Me.BTNAGREGAR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNAGREGAR.ForeColor = System.Drawing.Color.Black
        Me.BTNAGREGAR.Image = CType(resources.GetObject("BTNAGREGAR.Image"), System.Drawing.Image)
        Me.BTNAGREGAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNAGREGAR.Location = New System.Drawing.Point(15, 24)
        Me.BTNAGREGAR.Name = "BTNAGREGAR"
        Me.BTNAGREGAR.Size = New System.Drawing.Size(127, 35)
        Me.BTNAGREGAR.TabIndex = 1091
        Me.BTNAGREGAR.Text = "    F4 Agregar"
        Me.BTNAGREGAR.UseVisualStyleBackColor = False
        '
        'BTNQUITAR
        '
        Me.BTNQUITAR.BackColor = System.Drawing.Color.White
        Me.BTNQUITAR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNQUITAR.ForeColor = System.Drawing.Color.Black
        Me.BTNQUITAR.Image = CType(resources.GetObject("BTNQUITAR.Image"), System.Drawing.Image)
        Me.BTNQUITAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNQUITAR.Location = New System.Drawing.Point(15, 64)
        Me.BTNQUITAR.Name = "BTNQUITAR"
        Me.BTNQUITAR.Size = New System.Drawing.Size(127, 35)
        Me.BTNQUITAR.TabIndex = 1092
        Me.BTNQUITAR.Text = "       F5 Quitar"
        Me.BTNQUITAR.UseVisualStyleBackColor = False
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.BackColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNELIMINAR.ForeColor = System.Drawing.Color.Black
        Me.BTNELIMINAR.Image = CType(resources.GetObject("BTNELIMINAR.Image"), System.Drawing.Image)
        Me.BTNELIMINAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNELIMINAR.Location = New System.Drawing.Point(15, 146)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(127, 35)
        Me.BTNELIMINAR.TabIndex = 1093
        Me.BTNELIMINAR.Text = "       F7 Cancelar"
        Me.BTNELIMINAR.UseVisualStyleBackColor = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.Color.White
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Black
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNGUARDAR.Location = New System.Drawing.Point(15, 187)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(127, 35)
        Me.BTNGUARDAR.TabIndex = 1094
        Me.BTNGUARDAR.Text = "      F12 Guardar"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'TXTCLA
        '
        Me.TXTCLA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLA.Location = New System.Drawing.Point(328, 115)
        Me.TXTCLA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTCLA.MaxLength = 50
        Me.TXTCLA.Name = "TXTCLA"
        Me.TXTCLA.Size = New System.Drawing.Size(243, 29)
        Me.TXTCLA.TabIndex = 1128
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(177, 126)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(145, 18)
        Me.Label14.TabIndex = 1129
        Me.Label14.Text = "Codigo de barras"
        '
        'frmPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 617)
        Me.Controls.Add(Me.TXTCLA)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.BTNELIMINAR)
        Me.Controls.Add(Me.BTNQUITAR)
        Me.Controls.Add(Me.BTNAGREGAR)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.LBLCUANTOS)
        Me.Controls.Add(Me.LBLTOT)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.LBLDES)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXTCANT)
        Me.Controls.Add(Me.CBUNI)
        Me.Controls.Add(Me.CBPROD)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CBGRU)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LBLTP)
        Me.Controls.Add(Me.CBTP)
        Me.Controls.Add(Me.LBLPED)
        Me.Controls.Add(Me.DTFECHA)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPedidos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBPROD As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CBGRU As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LBLTP As System.Windows.Forms.Label
    Friend WithEvents CBTP As System.Windows.Forms.ComboBox
    Friend WithEvents LBLPED As System.Windows.Forms.TextBox
    Friend WithEvents DTFECHA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTCANT As System.Windows.Forms.TextBox
    Friend WithEvents CBUNI As System.Windows.Forms.ComboBox
    Friend WithEvents LBLDES As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents LBLCUANTOS As System.Windows.Forms.Label
    Friend WithEvents LBLTOT As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Friend WithEvents BTNAGREGAR As System.Windows.Forms.Button
    Friend WithEvents BTNQUITAR As System.Windows.Forms.Button
    Friend WithEvents BTNELIMINAR As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents TXTCLA As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
