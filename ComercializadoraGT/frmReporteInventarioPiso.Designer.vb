<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteInventarioPiso
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteInventarioPiso))
        Me.CBPRO = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CBGRU = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.BTNIMPRIMIR = New System.Windows.Forms.Button()
        Me.CBTI = New System.Windows.Forms.ComboBox()
        Me.LBLTI = New System.Windows.Forms.Label()
        Me.RB1 = New System.Windows.Forms.CheckBox()
        Me.BTNBUSCAR = New System.Windows.Forms.Button()
        Me.BTNMOSTRAR = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBPRO
        '
        Me.CBPRO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPRO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPRO.FormattingEnabled = True
        Me.CBPRO.Location = New System.Drawing.Point(180, 114)
        Me.CBPRO.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBPRO.Name = "CBPRO"
        Me.CBPRO.Size = New System.Drawing.Size(411, 31)
        Me.CBPRO.TabIndex = 1240
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(72, 127)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 1241
        Me.Label8.Text = "Producto"
        '
        'CBGRU
        '
        Me.CBGRU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBGRU.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGRU.FormattingEnabled = True
        Me.CBGRU.Location = New System.Drawing.Point(180, 65)
        Me.CBGRU.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBGRU.Name = "CBGRU"
        Me.CBGRU.Size = New System.Drawing.Size(411, 31)
        Me.CBGRU.TabIndex = 1238
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(72, 75)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 23)
        Me.Label5.TabIndex = 1239
        Me.Label5.Text = "Grupo"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(39, 166)
        Me.DGV.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGV.Size = New System.Drawing.Size(1213, 519)
        Me.DGV.TabIndex = 1237
        '
        'BTNIMPRIMIR
        '
        Me.BTNIMPRIMIR.BackColor = System.Drawing.Color.White
        Me.BTNIMPRIMIR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNIMPRIMIR.Image = CType(resources.GetObject("BTNIMPRIMIR.Image"), System.Drawing.Image)
        Me.BTNIMPRIMIR.Location = New System.Drawing.Point(996, 27)
        Me.BTNIMPRIMIR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTNIMPRIMIR.Name = "BTNIMPRIMIR"
        Me.BTNIMPRIMIR.Size = New System.Drawing.Size(123, 118)
        Me.BTNIMPRIMIR.TabIndex = 1244
        Me.BTNIMPRIMIR.UseVisualStyleBackColor = False
        '
        'CBTI
        '
        Me.CBTI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTI.FormattingEnabled = True
        Me.CBTI.Location = New System.Drawing.Point(180, 16)
        Me.CBTI.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBTI.Name = "CBTI"
        Me.CBTI.Size = New System.Drawing.Size(411, 31)
        Me.CBTI.TabIndex = 1245
        '
        'LBLTI
        '
        Me.LBLTI.AutoSize = True
        Me.LBLTI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTI.Location = New System.Drawing.Point(72, 26)
        Me.LBLTI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLTI.Name = "LBLTI"
        Me.LBLTI.Size = New System.Drawing.Size(77, 23)
        Me.LBLTI.TabIndex = 1246
        Me.LBLTI.Text = "Tienda"
        '
        'RB1
        '
        Me.RB1.AutoSize = True
        Me.RB1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB1.Location = New System.Drawing.Point(669, 128)
        Me.RB1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(164, 24)
        Me.RB1.TabIndex = 1247
        Me.RB1.Text = "Incluir Inactivos"
        Me.RB1.UseVisualStyleBackColor = True
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.Location = New System.Drawing.Point(669, 16)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(113, 95)
        Me.BTNBUSCAR.TabIndex = 1248
        Me.BTNBUSCAR.Text = "&B"
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.Color.White
        Me.BTNMOSTRAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNMOSTRAR.Image = CType(resources.GetObject("BTNMOSTRAR.Image"), System.Drawing.Image)
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(865, 26)
        Me.BTNMOSTRAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(123, 118)
        Me.BTNMOSTRAR.TabIndex = 1249
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1127, 26)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 118)
        Me.Button1.TabIndex = 1250
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmReporteInventarioPiso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1289, 720)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BTNMOSTRAR)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.RB1)
        Me.Controls.Add(Me.CBTI)
        Me.Controls.Add(Me.LBLTI)
        Me.Controls.Add(Me.BTNIMPRIMIR)
        Me.Controls.Add(Me.CBPRO)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CBGRU)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteInventarioPiso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario "
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBPRO As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CBGRU As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BTNIMPRIMIR As System.Windows.Forms.Button
    Friend WithEvents CBTI As System.Windows.Forms.ComboBox
    Friend WithEvents LBLTI As System.Windows.Forms.Label
    Friend WithEvents RB1 As System.Windows.Forms.CheckBox
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
    Friend WithEvents Button1 As Button
End Class
