<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportePreciosSucursal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportePreciosSucursal))
        Me.CBPRO = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CBGRU = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.BTNMOSTRAR = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBPRO
        '
        Me.CBPRO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPRO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPRO.FormattingEnabled = True
        Me.CBPRO.Location = New System.Drawing.Point(245, 74)
        Me.CBPRO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CBPRO.Name = "CBPRO"
        Me.CBPRO.Size = New System.Drawing.Size(309, 26)
        Me.CBPRO.TabIndex = 1240
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(163, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 18)
        Me.Label8.TabIndex = 1241
        Me.Label8.Text = "Producto"
        '
        'CBGRU
        '
        Me.CBGRU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBGRU.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGRU.FormattingEnabled = True
        Me.CBGRU.Location = New System.Drawing.Point(245, 34)
        Me.CBGRU.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CBGRU.Name = "CBGRU"
        Me.CBGRU.Size = New System.Drawing.Size(309, 26)
        Me.CBGRU.TabIndex = 1238
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(164, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 18)
        Me.Label5.TabIndex = 1239
        Me.Label5.Text = "Grupo"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(23, 132)
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
        Me.DGV.Size = New System.Drawing.Size(788, 301)
        Me.DGV.TabIndex = 1237
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.Color.White
        Me.BTNMOSTRAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNMOSTRAR.Image = CType(resources.GetObject("BTNMOSTRAR.Image"), System.Drawing.Image)
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(719, 17)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(92, 96)
        Me.BTNMOSTRAR.TabIndex = 1236
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'frmReportePreciosSucursal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 451)
        Me.Controls.Add(Me.CBPRO)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CBGRU)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.BTNMOSTRAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportePreciosSucursal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de precios por sucursal"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBPRO As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CBGRU As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
End Class
