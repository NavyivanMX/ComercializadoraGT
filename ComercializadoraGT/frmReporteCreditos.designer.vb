<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteCreditos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteCreditos))
        Me.CBTIP = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.LBLAD = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LBLAT = New System.Windows.Forms.Label
        Me.LBLAB = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.BTNMOSTRAR = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBTIP
        '
        Me.CBTIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTIP.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTIP.FormattingEnabled = True
        Me.CBTIP.Items.AddRange(New Object() {"Todas las notas", "Adeudos", "Pagados"})
        Me.CBTIP.Location = New System.Drawing.Point(187, 38)
        Me.CBTIP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CBTIP.Name = "CBTIP"
        Me.CBTIP.Size = New System.Drawing.Size(208, 26)
        Me.CBTIP.TabIndex = 1258
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(128, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 18)
        Me.Label3.TabIndex = 1259
        Me.Label3.Text = "Tipo"
        '
        'LBLAD
        '
        Me.LBLAD.AutoSize = True
        Me.LBLAD.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLAD.ForeColor = System.Drawing.Color.Navy
        Me.LBLAD.Location = New System.Drawing.Point(103, 466)
        Me.LBLAD.Name = "LBLAD"
        Me.LBLAD.Size = New System.Drawing.Size(21, 22)
        Me.LBLAD.TabIndex = 1257
        Me.LBLAD.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 467)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 17)
        Me.Label6.TabIndex = 1256
        Me.Label6.Text = "Adeudo  $"
        '
        'LBLAT
        '
        Me.LBLAT.AutoSize = True
        Me.LBLAT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLAT.ForeColor = System.Drawing.Color.Navy
        Me.LBLAT.Location = New System.Drawing.Point(679, 465)
        Me.LBLAT.Name = "LBLAT"
        Me.LBLAT.Size = New System.Drawing.Size(21, 22)
        Me.LBLAT.TabIndex = 1255
        Me.LBLAT.Text = "0"
        '
        'LBLAB
        '
        Me.LBLAB.AutoSize = True
        Me.LBLAB.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLAB.ForeColor = System.Drawing.Color.Navy
        Me.LBLAB.Location = New System.Drawing.Point(362, 464)
        Me.LBLAB.Name = "LBLAB"
        Me.LBLAB.Size = New System.Drawing.Size(21, 22)
        Me.LBLAB.TabIndex = 1254
        Me.LBLAB.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(565, 467)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 17)
        Me.Label2.TabIndex = 1253
        Me.Label2.Text = "Adeudo total  $"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(287, 467)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 1252
        Me.Label1.Text = "Abonos  $"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(28, 129)
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
        Me.DGV.Size = New System.Drawing.Size(767, 314)
        Me.DGV.TabIndex = 1249
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.Color.White
        Me.BTNMOSTRAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNMOSTRAR.Image = CType(resources.GetObject("BTNMOSTRAR.Image"), System.Drawing.Image)
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(703, 14)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(92, 96)
        Me.BTNMOSTRAR.TabIndex = 1248
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'frmReporteCreditos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 505)
        Me.Controls.Add(Me.CBTIP)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LBLAD)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LBLAT)
        Me.Controls.Add(Me.LBLAB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.BTNMOSTRAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteCreditos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de creditos"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBTIP As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LBLAD As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LBLAT As System.Windows.Forms.Label
    Friend WithEvents LBLAB As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
End Class
