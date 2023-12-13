<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientesRFC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientesRFC))
        Me.TXTCD = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TXTCP = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXTDIR = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TXTRFC = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXTNOMFIS = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CBCLI = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTE = New System.Windows.Forms.TextBox
        Me.BTNBUSCAR = New System.Windows.Forms.Button
        Me.BTNQUITAR = New System.Windows.Forms.Button
        Me.BTNAGREGAR = New System.Windows.Forms.Button
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TXTCD
        '
        Me.TXTCD.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCD.Location = New System.Drawing.Point(405, 152)
        Me.TXTCD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTCD.MaxLength = 22
        Me.TXTCD.Name = "TXTCD"
        Me.TXTCD.Size = New System.Drawing.Size(205, 25)
        Me.TXTCD.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(340, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 17)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Ciudad"
        '
        'TXTCP
        '
        Me.TXTCP.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCP.Location = New System.Drawing.Point(123, 152)
        Me.TXTCP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTCP.MaxLength = 5
        Me.TXTCP.Name = "TXTCP"
        Me.TXTCP.Size = New System.Drawing.Size(172, 25)
        Me.TXTCP.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 17)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Codigo postal"
        '
        'TXTDIR
        '
        Me.TXTDIR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDIR.Location = New System.Drawing.Point(123, 90)
        Me.TXTDIR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTDIR.MaxLength = 300
        Me.TXTDIR.Multiline = True
        Me.TXTDIR.Name = "TXTDIR"
        Me.TXTDIR.Size = New System.Drawing.Size(487, 46)
        Me.TXTDIR.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(38, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 17)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Dirección"
        '
        'TXTRFC
        '
        Me.TXTRFC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRFC.Location = New System.Drawing.Point(123, 53)
        Me.TXTRFC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTRFC.MaxLength = 13
        Me.TXTRFC.Name = "TXTRFC"
        Me.TXTRFC.Size = New System.Drawing.Size(292, 25)
        Me.TXTRFC.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(78, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 17)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "RFC"
        '
        'TXTNOMFIS
        '
        Me.TXTNOMFIS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOMFIS.Location = New System.Drawing.Point(123, 20)
        Me.TXTNOMFIS.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTNOMFIS.MaxLength = 60
        Me.TXTNOMFIS.Name = "TXTNOMFIS"
        Me.TXTNOMFIS.Size = New System.Drawing.Size(487, 25)
        Me.TXTNOMFIS.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 17)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Nombre fiscal"
        '
        'CBCLI
        '
        Me.CBCLI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCLI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCLI.FormattingEnabled = True
        Me.CBCLI.Location = New System.Drawing.Point(144, 22)
        Me.CBCLI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CBCLI.Name = "CBCLI"
        Me.CBCLI.Size = New System.Drawing.Size(485, 25)
        Me.CBCLI.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(79, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 17)
        Me.Label12.TabIndex = 37
        Me.Label12.Tag = ""
        Me.Label12.Text = "Cliente"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(19, 289)
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
        Me.DGV.Size = New System.Drawing.Size(626, 328)
        Me.DGV.TabIndex = 393
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TXTE)
        Me.GroupBox1.Controls.Add(Me.TXTNOMFIS)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TXTRFC)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TXTDIR)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TXTCP)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TXTCD)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(626, 221)
        Me.GroupBox1.TabIndex = 394
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 191)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 17)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Encargado"
        '
        'TXTE
        '
        Me.TXTE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTE.Location = New System.Drawing.Point(123, 189)
        Me.TXTE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTE.MaxLength = 100
        Me.TXTE.Name = "TXTE"
        Me.TXTE.Size = New System.Drawing.Size(487, 25)
        Me.TXTE.TabIndex = 34
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.Location = New System.Drawing.Point(669, 13)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(85, 77)
        Me.BTNBUSCAR.TabIndex = 11
        Me.BTNBUSCAR.Text = "&b"
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'BTNQUITAR
        '
        Me.BTNQUITAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNQUITAR.Image = CType(resources.GetObject("BTNQUITAR.Image"), System.Drawing.Image)
        Me.BTNQUITAR.Location = New System.Drawing.Point(669, 371)
        Me.BTNQUITAR.Name = "BTNQUITAR"
        Me.BTNQUITAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNQUITAR.TabIndex = 7
        '
        'BTNAGREGAR
        '
        Me.BTNAGREGAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNAGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNAGREGAR.ForeColor = System.Drawing.Color.White
        Me.BTNAGREGAR.Image = CType(resources.GetObject("BTNAGREGAR.Image"), System.Drawing.Image)
        Me.BTNAGREGAR.Location = New System.Drawing.Point(669, 289)
        Me.BTNAGREGAR.Name = "BTNAGREGAR"
        Me.BTNAGREGAR.Size = New System.Drawing.Size(80, 78)
        Me.BTNAGREGAR.TabIndex = 6
        Me.BTNAGREGAR.UseVisualStyleBackColor = False
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(669, 454)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 8
        Me.BTNCANCELAR.Text = "&c"
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(669, 537)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 10
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'frmClientesRFC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 630)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.BTNQUITAR)
        Me.Controls.Add(Me.BTNAGREGAR)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.CBCLI)
        Me.Controls.Add(Me.Label12)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClientesRFC"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes-RFC"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXTCD As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTCP As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTDIR As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTRFC As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTNOMFIS As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CBCLI As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Private WithEvents BTNQUITAR As System.Windows.Forms.Button
    Friend WithEvents BTNAGREGAR As System.Windows.Forms.Button
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTE As System.Windows.Forms.TextBox
End Class
