<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteInventario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteInventario))
        Me.CBPRO = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CBGRU = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.LBLGG = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.LBLART = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LBLC = New System.Windows.Forms.Label
        Me.LBLV = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.BTNMOSTRAR = New System.Windows.Forms.Button
        Me.BTNIMPRIMIR = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBPRO
        '
        Me.CBPRO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPRO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPRO.FormattingEnabled = True
        Me.CBPRO.Location = New System.Drawing.Point(303, 65)
        Me.CBPRO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CBPRO.Name = "CBPRO"
        Me.CBPRO.Size = New System.Drawing.Size(309, 26)
        Me.CBPRO.TabIndex = 1234
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(222, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 18)
        Me.Label8.TabIndex = 1235
        Me.Label8.Text = "Producto"
        '
        'CBGRU
        '
        Me.CBGRU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBGRU.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGRU.FormattingEnabled = True
        Me.CBGRU.Location = New System.Drawing.Point(303, 25)
        Me.CBGRU.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CBGRU.Name = "CBGRU"
        Me.CBGRU.Size = New System.Drawing.Size(309, 26)
        Me.CBGRU.TabIndex = 1232
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(222, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 18)
        Me.Label5.TabIndex = 1233
        Me.Label5.Text = "Grupo"
        '
        'LBLGG
        '
        Me.LBLGG.AutoSize = True
        Me.LBLGG.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLGG.ForeColor = System.Drawing.Color.Navy
        Me.LBLGG.Location = New System.Drawing.Point(539, 588)
        Me.LBLGG.Name = "LBLGG"
        Me.LBLGG.Size = New System.Drawing.Size(22, 24)
        Me.LBLGG.TabIndex = 1231
        Me.LBLGG.Text = "0"
        Me.LBLGG.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(285, 593)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(248, 18)
        Me.Label7.TabIndex = 1230
        Me.Label7.Text = "GANACIA DEL INVENTARIO  $"
        Me.Label7.Visible = False
        '
        'LBLART
        '
        Me.LBLART.AutoSize = True
        Me.LBLART.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLART.ForeColor = System.Drawing.Color.Navy
        Me.LBLART.Location = New System.Drawing.Point(152, 557)
        Me.LBLART.Name = "LBLART"
        Me.LBLART.Size = New System.Drawing.Size(21, 22)
        Me.LBLART.TabIndex = 1229
        Me.LBLART.Text = "0"
        Me.LBLART.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(72, 561)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 17)
        Me.Label6.TabIndex = 1228
        Me.Label6.Text = "Articulos"
        Me.Label6.Visible = False
        '
        'LBLC
        '
        Me.LBLC.AutoSize = True
        Me.LBLC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLC.ForeColor = System.Drawing.Color.Navy
        Me.LBLC.Location = New System.Drawing.Point(840, 557)
        Me.LBLC.Name = "LBLC"
        Me.LBLC.Size = New System.Drawing.Size(21, 22)
        Me.LBLC.TabIndex = 1227
        Me.LBLC.Text = "0"
        Me.LBLC.Visible = False
        '
        'LBLV
        '
        Me.LBLV.AutoSize = True
        Me.LBLV.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLV.ForeColor = System.Drawing.Color.Navy
        Me.LBLV.Location = New System.Drawing.Point(455, 559)
        Me.LBLV.Name = "LBLV"
        Me.LBLV.Size = New System.Drawing.Size(21, 22)
        Me.LBLV.TabIndex = 1226
        Me.LBLV.Text = "0"
        Me.LBLV.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(656, 562)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 17)
        Me.Label2.TabIndex = 1225
        Me.Label2.Text = "Costo en inventario  $"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(350, 562)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 17)
        Me.Label1.TabIndex = 1224
        Me.Label1.Text = "Inventario  $"
        Me.Label1.Visible = False
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(26, 127)
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
        Me.DGV.Size = New System.Drawing.Size(910, 422)
        Me.DGV.TabIndex = 1223
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.Color.White
        Me.BTNMOSTRAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNMOSTRAR.Image = CType(resources.GetObject("BTNMOSTRAR.Image"), System.Drawing.Image)
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(701, 12)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(92, 96)
        Me.BTNMOSTRAR.TabIndex = 1221
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'BTNIMPRIMIR
        '
        Me.BTNIMPRIMIR.BackColor = System.Drawing.Color.White
        Me.BTNIMPRIMIR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNIMPRIMIR.Image = CType(resources.GetObject("BTNIMPRIMIR.Image"), System.Drawing.Image)
        Me.BTNIMPRIMIR.Location = New System.Drawing.Point(844, 12)
        Me.BTNIMPRIMIR.Name = "BTNIMPRIMIR"
        Me.BTNIMPRIMIR.Size = New System.Drawing.Size(92, 96)
        Me.BTNIMPRIMIR.TabIndex = 1243
        Me.BTNIMPRIMIR.UseVisualStyleBackColor = False
        '
        'frmReporteInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(970, 620)
        Me.Controls.Add(Me.BTNIMPRIMIR)
        Me.Controls.Add(Me.CBPRO)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CBGRU)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LBLGG)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LBLART)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LBLC)
        Me.Controls.Add(Me.LBLV)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.BTNMOSTRAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteInventario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario de bodega"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBPRO As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CBGRU As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LBLGG As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LBLART As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LBLC As System.Windows.Forms.Label
    Friend WithEvents LBLV As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
    Friend WithEvents BTNIMPRIMIR As System.Windows.Forms.Button
End Class
