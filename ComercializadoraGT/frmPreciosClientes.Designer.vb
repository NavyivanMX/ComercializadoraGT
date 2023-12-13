<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreciosClientes
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreciosClientes))
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.CLAVE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BajoMinimo = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.CBPRO = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBCLI = New System.Windows.Forms.ComboBox
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.BTNELIMINAR = New System.Windows.Forms.Button
        Me.BTNQUITAR = New System.Windows.Forms.Button
        Me.BTNAGREGAR = New System.Windows.Forms.Button
        Me.TXTPRE = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LBLPRE = New System.Windows.Forms.Label
        Me.BTNIMPRIMIR = New System.Windows.Forms.Button
        Me.BTNBUSCAR = New System.Windows.Forms.Button
        Me.PBIMG = New System.Windows.Forms.PictureBox
        Me.LBLP = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.CBGRU = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.BTNBUSCAR1 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.CHKBM = New System.Windows.Forms.CheckBox
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CLAVE, Me.Column1, Me.Descripcion, Me.BajoMinimo})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(254, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV.Location = New System.Drawing.Point(24, 307)
        Me.DGV.Name = "DGV"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGV.Size = New System.Drawing.Size(736, 328)
        Me.DGV.TabIndex = 1162
        '
        'CLAVE
        '
        Me.CLAVE.HeaderText = "Clave"
        Me.CLAVE.Name = "CLAVE"
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Producto"
        Me.Column1.Name = "Column1"
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Precio"
        Me.Descripcion.Name = "Descripcion"
        '
        'BajoMinimo
        '
        Me.BajoMinimo.HeaderText = "Bajo Mínimo"
        Me.BajoMinimo.Name = "BajoMinimo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 18)
        Me.Label2.TabIndex = 1159
        Me.Label2.Text = "Producto"
        '
        'CBPRO
        '
        Me.CBPRO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPRO.FormattingEnabled = True
        Me.CBPRO.Location = New System.Drawing.Point(96, 108)
        Me.CBPRO.Name = "CBPRO"
        Me.CBPRO.Size = New System.Drawing.Size(566, 26)
        Me.CBPRO.TabIndex = 1158
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 18)
        Me.Label1.TabIndex = 1157
        Me.Label1.Text = "Cliente"
        '
        'CBCLI
        '
        Me.CBCLI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCLI.FormattingEnabled = True
        Me.CBCLI.Location = New System.Drawing.Point(96, 34)
        Me.CBCLI.Name = "CBCLI"
        Me.CBCLI.Size = New System.Drawing.Size(566, 26)
        Me.CBCLI.TabIndex = 1156
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(777, 307)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 1166
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.BackColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNELIMINAR.ForeColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Image = CType(resources.GetObject("BTNELIMINAR.Image"), System.Drawing.Image)
        Me.BTNELIMINAR.Location = New System.Drawing.Point(777, 555)
        Me.BTNELIMINAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNELIMINAR.TabIndex = 1167
        Me.BTNELIMINAR.UseVisualStyleBackColor = False
        '
        'BTNQUITAR
        '
        Me.BTNQUITAR.BackColor = System.Drawing.Color.White
        Me.BTNQUITAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNQUITAR.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BTNQUITAR.Image = CType(resources.GetObject("BTNQUITAR.Image"), System.Drawing.Image)
        Me.BTNQUITAR.Location = New System.Drawing.Point(777, 472)
        Me.BTNQUITAR.Name = "BTNQUITAR"
        Me.BTNQUITAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNQUITAR.TabIndex = 1164
        Me.BTNQUITAR.UseVisualStyleBackColor = False
        '
        'BTNAGREGAR
        '
        Me.BTNAGREGAR.BackColor = System.Drawing.Color.White
        Me.BTNAGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNAGREGAR.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BTNAGREGAR.Image = CType(resources.GetObject("BTNAGREGAR.Image"), System.Drawing.Image)
        Me.BTNAGREGAR.Location = New System.Drawing.Point(777, 390)
        Me.BTNAGREGAR.Name = "BTNAGREGAR"
        Me.BTNAGREGAR.Size = New System.Drawing.Size(80, 78)
        Me.BTNAGREGAR.TabIndex = 1163
        Me.BTNAGREGAR.UseVisualStyleBackColor = False
        '
        'TXTPRE
        '
        Me.TXTPRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPRE.Location = New System.Drawing.Point(96, 145)
        Me.TXTPRE.Name = "TXTPRE"
        Me.TXTPRE.Size = New System.Drawing.Size(100, 26)
        Me.TXTPRE.TabIndex = 1168
        Me.TXTPRE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(33, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 18)
        Me.Label4.TabIndex = 1169
        Me.Label4.Text = "Precio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(223, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 18)
        Me.Label3.TabIndex = 1170
        Me.Label3.Text = "Ultimo Costo"
        '
        'LBLPRE
        '
        Me.LBLPRE.AutoSize = True
        Me.LBLPRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPRE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLPRE.Location = New System.Drawing.Point(340, 185)
        Me.LBLPRE.Name = "LBLPRE"
        Me.LBLPRE.Size = New System.Drawing.Size(40, 18)
        Me.LBLPRE.TabIndex = 1171
        Me.LBLPRE.Text = "0.00"
        '
        'BTNIMPRIMIR
        '
        Me.BTNIMPRIMIR.BackColor = System.Drawing.Color.White
        Me.BTNIMPRIMIR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNIMPRIMIR.Image = CType(resources.GetObject("BTNIMPRIMIR.Image"), System.Drawing.Image)
        Me.BTNIMPRIMIR.Location = New System.Drawing.Point(777, 29)
        Me.BTNIMPRIMIR.Name = "BTNIMPRIMIR"
        Me.BTNIMPRIMIR.Size = New System.Drawing.Size(92, 96)
        Me.BTNIMPRIMIR.TabIndex = 1201
        Me.BTNIMPRIMIR.UseVisualStyleBackColor = False
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.Location = New System.Drawing.Point(732, 150)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(80, 84)
        Me.BTNBUSCAR.TabIndex = 1202
        Me.BTNBUSCAR.Text = "&B"
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'PBIMG
        '
        Me.PBIMG.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PBIMG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PBIMG.ErrorImage = CType(resources.GetObject("PBIMG.ErrorImage"), System.Drawing.Image)
        Me.PBIMG.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PBIMG.Location = New System.Drawing.Point(436, 145)
        Me.PBIMG.Name = "PBIMG"
        Me.PBIMG.Size = New System.Drawing.Size(112, 150)
        Me.PBIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBIMG.TabIndex = 1232
        Me.PBIMG.TabStop = False
        Me.PBIMG.Tag = "1"
        '
        'LBLP
        '
        Me.LBLP.AutoSize = True
        Me.LBLP.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLP.Location = New System.Drawing.Point(286, 152)
        Me.LBLP.Name = "LBLP"
        Me.LBLP.Size = New System.Drawing.Size(40, 18)
        Me.LBLP.TabIndex = 1234
        Me.LBLP.Text = "0.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(223, 153)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 18)
        Me.Label6.TabIndex = 1233
        Me.Label6.Text = "Precio"
        '
        'CBGRU
        '
        Me.CBGRU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBGRU.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGRU.FormattingEnabled = True
        Me.CBGRU.Location = New System.Drawing.Point(96, 75)
        Me.CBGRU.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CBGRU.Name = "CBGRU"
        Me.CBGRU.Size = New System.Drawing.Size(566, 26)
        Me.CBGRU.TabIndex = 1238
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 18)
        Me.Label5.TabIndex = 1239
        Me.Label5.Text = "Grupo"
        '
        'BTNBUSCAR1
        '
        Me.BTNBUSCAR1.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR1.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR1.ForeColor = System.Drawing.Color.Transparent
        Me.BTNBUSCAR1.Image = CType(resources.GetObject("BTNBUSCAR1.Image"), System.Drawing.Image)
        Me.BTNBUSCAR1.Location = New System.Drawing.Point(631, 152)
        Me.BTNBUSCAR1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUSCAR1.Name = "BTNBUSCAR1"
        Me.BTNBUSCAR1.Size = New System.Drawing.Size(85, 77)
        Me.BTNBUSCAR1.TabIndex = 1240
        Me.BTNBUSCAR1.Text = "&b"
        Me.BTNBUSCAR1.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(125, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(206, 18)
        Me.Label7.TabIndex = 1241
        Me.Label7.Text = "F9.- Búsqueda de Clientes"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(433, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(232, 18)
        Me.Label8.TabIndex = 1242
        Me.Label8.Text = "F10.- Búsqueda de Productos"
        '
        'CHKBM
        '
        Me.CHKBM.AutoSize = True
        Me.CHKBM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKBM.Location = New System.Drawing.Point(96, 186)
        Me.CHKBM.Name = "CHKBM"
        Me.CHKBM.Size = New System.Drawing.Size(112, 20)
        Me.CHKBM.TabIndex = 1244
        Me.CHKBM.Text = "Bajo Mínimo"
        Me.CHKBM.UseVisualStyleBackColor = True
        '
        'frmPreciosClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 650)
        Me.Controls.Add(Me.CHKBM)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BTNBUSCAR1)
        Me.Controls.Add(Me.CBGRU)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LBLP)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PBIMG)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.BTNIMPRIMIR)
        Me.Controls.Add(Me.LBLPRE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTPRE)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNELIMINAR)
        Me.Controls.Add(Me.BTNQUITAR)
        Me.Controls.Add(Me.BTNAGREGAR)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBPRO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBCLI)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPreciosClientes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precios de Clientes"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNELIMINAR As System.Windows.Forms.Button
    Private WithEvents BTNQUITAR As System.Windows.Forms.Button
    Friend WithEvents BTNAGREGAR As System.Windows.Forms.Button
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CBPRO As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBCLI As System.Windows.Forms.ComboBox
    Friend WithEvents TXTPRE As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CLAVE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LBLPRE As System.Windows.Forms.Label
    Friend WithEvents BTNIMPRIMIR As System.Windows.Forms.Button
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Friend WithEvents PBIMG As System.Windows.Forms.PictureBox
    Friend WithEvents LBLP As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CBGRU As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BTNBUSCAR1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CHKBM As System.Windows.Forms.CheckBox
    Friend WithEvents BajoMinimo As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
