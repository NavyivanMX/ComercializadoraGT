<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEquivalenciasProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEquivalenciasProductos))
        Me.Label5 = New System.Windows.Forms.Label
        Me.TXTCANT2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXTCANT1 = New System.Windows.Forms.TextBox
        Me.LBLUNI2 = New System.Windows.Forms.Label
        Me.CBUNI2 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.LBLUNI1 = New System.Windows.Forms.Label
        Me.CBUNI1 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LBLGPO = New System.Windows.Forms.Label
        Me.CBGPO = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.LBLPROD = New System.Windows.Forms.Label
        Me.CBPROD = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BTNELIMINAR = New System.Windows.Forms.Button
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.BTNBUSCAR = New System.Windows.Forms.Button
        Me.BTNQUITAR = New System.Windows.Forms.Button
        Me.BTNAGREGAR = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(378, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 18)
        Me.Label5.TabIndex = 487
        Me.Label5.Text = "Equivale a"
        '
        'TXTCANT2
        '
        Me.TXTCANT2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT2.Location = New System.Drawing.Point(511, 139)
        Me.TXTCANT2.Name = "TXTCANT2"
        Me.TXTCANT2.Size = New System.Drawing.Size(100, 24)
        Me.TXTCANT2.TabIndex = 485
        Me.TXTCANT2.Text = "0"
        Me.TXTCANT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(525, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 18)
        Me.Label8.TabIndex = 484
        Me.Label8.Text = "Cantidad"
        '
        'TXTCANT1
        '
        Me.TXTCANT1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT1.Location = New System.Drawing.Point(67, 139)
        Me.TXTCANT1.Name = "TXTCANT1"
        Me.TXTCANT1.Size = New System.Drawing.Size(100, 24)
        Me.TXTCANT1.TabIndex = 483
        Me.TXTCANT1.Text = "0"
        Me.TXTCANT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLUNI2
        '
        Me.LBLUNI2.AutoSize = True
        Me.LBLUNI2.Enabled = False
        Me.LBLUNI2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUNI2.Location = New System.Drawing.Point(760, 143)
        Me.LBLUNI2.Name = "LBLUNI2"
        Me.LBLUNI2.Size = New System.Drawing.Size(17, 18)
        Me.LBLUNI2.TabIndex = 482
        Me.LBLUNI2.Text = "0"
        '
        'CBUNI2
        '
        Me.CBUNI2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUNI2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBUNI2.FormattingEnabled = True
        Me.CBUNI2.Location = New System.Drawing.Point(633, 140)
        Me.CBUNI2.Name = "CBUNI2"
        Me.CBUNI2.Size = New System.Drawing.Size(121, 26)
        Me.CBUNI2.TabIndex = 481
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(662, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 18)
        Me.Label7.TabIndex = 480
        Me.Label7.Text = "Unidad"
        '
        'LBLUNI1
        '
        Me.LBLUNI1.AutoSize = True
        Me.LBLUNI1.Enabled = False
        Me.LBLUNI1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUNI1.Location = New System.Drawing.Point(324, 143)
        Me.LBLUNI1.Name = "LBLUNI1"
        Me.LBLUNI1.Size = New System.Drawing.Size(17, 18)
        Me.LBLUNI1.TabIndex = 479
        Me.LBLUNI1.Text = "0"
        '
        'CBUNI1
        '
        Me.CBUNI1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUNI1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBUNI1.FormattingEnabled = True
        Me.CBUNI1.Location = New System.Drawing.Point(197, 140)
        Me.CBUNI1.Name = "CBUNI1"
        Me.CBUNI1.Size = New System.Drawing.Size(121, 26)
        Me.CBUNI1.TabIndex = 478
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(229, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 18)
        Me.Label4.TabIndex = 477
        Me.Label4.Text = "Unidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(74, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 18)
        Me.Label2.TabIndex = 476
        Me.Label2.Text = "Cantidad"
        '
        'LBLGPO
        '
        Me.LBLGPO.AutoSize = True
        Me.LBLGPO.Enabled = False
        Me.LBLGPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLGPO.Location = New System.Drawing.Point(194, 38)
        Me.LBLGPO.Name = "LBLGPO"
        Me.LBLGPO.Size = New System.Drawing.Size(17, 18)
        Me.LBLGPO.TabIndex = 475
        Me.LBLGPO.Text = "0"
        '
        'CBGPO
        '
        Me.CBGPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBGPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGPO.FormattingEnabled = True
        Me.CBGPO.Location = New System.Drawing.Point(24, 65)
        Me.CBGPO.Name = "CBGPO"
        Me.CBGPO.Size = New System.Drawing.Size(361, 26)
        Me.CBGPO.TabIndex = 474
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(108, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 18)
        Me.Label3.TabIndex = 473
        Me.Label3.Text = "Grupo"
        '
        'LBLPROD
        '
        Me.LBLPROD.AutoSize = True
        Me.LBLPROD.Enabled = False
        Me.LBLPROD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPROD.Location = New System.Drawing.Point(645, 38)
        Me.LBLPROD.Name = "LBLPROD"
        Me.LBLPROD.Size = New System.Drawing.Size(17, 18)
        Me.LBLPROD.TabIndex = 472
        Me.LBLPROD.Text = "0"
        '
        'CBPROD
        '
        Me.CBPROD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPROD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPROD.FormattingEnabled = True
        Me.CBPROD.Location = New System.Drawing.Point(415, 65)
        Me.CBPROD.Name = "CBPROD"
        Me.CBPROD.Size = New System.Drawing.Size(318, 26)
        Me.CBPROD.TabIndex = 471
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(438, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 18)
        Me.Label1.TabIndex = 470
        Me.Label1.Text = "Producto"
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.BackColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNELIMINAR.ForeColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Image = CType(resources.GetObject("BTNELIMINAR.Image"), System.Drawing.Image)
        Me.BTNELIMINAR.Location = New System.Drawing.Point(825, 471)
        Me.BTNELIMINAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNELIMINAR.TabIndex = 490
        Me.BTNELIMINAR.UseVisualStyleBackColor = False
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(825, 567)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 489
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.White
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(825, 373)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 488
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(32, 181)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.Size = New System.Drawing.Size(762, 466)
        Me.DGV.TabIndex = 486
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.Location = New System.Drawing.Point(825, 28)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(85, 77)
        Me.BTNBUSCAR.TabIndex = 491
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'BTNQUITAR
        '
        Me.BTNQUITAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNQUITAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNQUITAR.ForeColor = System.Drawing.Color.White
        Me.BTNQUITAR.Image = CType(resources.GetObject("BTNQUITAR.Image"), System.Drawing.Image)
        Me.BTNQUITAR.Location = New System.Drawing.Point(825, 278)
        Me.BTNQUITAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNQUITAR.Name = "BTNQUITAR"
        Me.BTNQUITAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNQUITAR.TabIndex = 492
        Me.BTNQUITAR.UseVisualStyleBackColor = False
        '
        'BTNAGREGAR
        '
        Me.BTNAGREGAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNAGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNAGREGAR.ForeColor = System.Drawing.Color.White
        Me.BTNAGREGAR.Image = CType(resources.GetObject("BTNAGREGAR.Image"), System.Drawing.Image)
        Me.BTNAGREGAR.Location = New System.Drawing.Point(825, 181)
        Me.BTNAGREGAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNAGREGAR.Name = "BTNAGREGAR"
        Me.BTNAGREGAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNAGREGAR.TabIndex = 493
        Me.BTNAGREGAR.UseVisualStyleBackColor = False
        '
        'frmEquivalenciasProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 688)
        Me.Controls.Add(Me.BTNAGREGAR)
        Me.Controls.Add(Me.BTNQUITAR)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.BTNELIMINAR)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.TXTCANT2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXTCANT1)
        Me.Controls.Add(Me.LBLUNI2)
        Me.Controls.Add(Me.CBUNI2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LBLUNI1)
        Me.Controls.Add(Me.CBUNI1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LBLGPO)
        Me.Controls.Add(Me.CBGPO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LBLPROD)
        Me.Controls.Add(Me.CBPROD)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEquivalenciasProductos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Equivalencias"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTCANT2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTCANT1 As System.Windows.Forms.TextBox
    Friend WithEvents LBLUNI2 As System.Windows.Forms.Label
    Friend WithEvents CBUNI2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LBLUNI1 As System.Windows.Forms.Label
    Friend WithEvents CBUNI1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LBLGPO As System.Windows.Forms.Label
    Friend WithEvents CBGPO As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LBLPROD As System.Windows.Forms.Label
    Friend WithEvents CBPROD As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNELIMINAR As System.Windows.Forms.Button
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Friend WithEvents BTNQUITAR As System.Windows.Forms.Button
    Friend WithEvents BTNAGREGAR As System.Windows.Forms.Button
End Class
