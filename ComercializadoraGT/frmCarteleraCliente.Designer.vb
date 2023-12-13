<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCarteleraCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCarteleraCliente))
        Me.CLB = New System.Windows.Forms.CheckedListBox
        Me.CHKCOM = New System.Windows.Forms.CheckBox
        Me.DTDE = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.BTNIMPRIMIR = New System.Windows.Forms.Button
        Me.BTNMOSTRAR = New System.Windows.Forms.Button
        Me.LBLA = New System.Windows.Forms.Label
        Me.LBLB = New System.Windows.Forms.Label
        Me.LBLC = New System.Windows.Forms.Label
        Me.LBLD = New System.Windows.Forms.Label
        Me.LBLE = New System.Windows.Forms.Label
        Me.LBLF = New System.Windows.Forms.Label
        Me.LBLG = New System.Windows.Forms.Label
        Me.CHKTA = New System.Windows.Forms.CheckBox
        Me.CHKEP = New System.Windows.Forms.CheckBox
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CLB
        '
        Me.CLB.CheckOnClick = True
        Me.CLB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CLB.FormattingEnabled = True
        Me.CLB.Location = New System.Drawing.Point(12, 51)
        Me.CLB.Name = "CLB"
        Me.CLB.Size = New System.Drawing.Size(678, 276)
        Me.CLB.TabIndex = 0
        '
        'CHKCOM
        '
        Me.CHKCOM.AutoSize = True
        Me.CHKCOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKCOM.Location = New System.Drawing.Point(12, 25)
        Me.CHKCOM.Name = "CHKCOM"
        Me.CHKCOM.Size = New System.Drawing.Size(157, 20)
        Me.CHKCOM.TabIndex = 1386
        Me.CHKCOM.Tag = "1"
        Me.CHKCOM.Text = "Todos los Clientes"
        Me.CHKCOM.UseVisualStyleBackColor = True
        '
        'DTDE
        '
        Me.DTDE.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDE.Enabled = False
        Me.DTDE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTDE.Location = New System.Drawing.Point(762, 45)
        Me.DTDE.Name = "DTDE"
        Me.DTDE.Size = New System.Drawing.Size(130, 25)
        Me.DTDE.TabIndex = 1388
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(759, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 17)
        Me.Label5.TabIndex = 1387
        Me.Label5.Text = "Cartera al Día de HOY"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(12, 367)
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
        Me.DGV.Size = New System.Drawing.Size(970, 317)
        Me.DGV.TabIndex = 1389
        '
        'BTNIMPRIMIR
        '
        Me.BTNIMPRIMIR.BackColor = System.Drawing.Color.White
        Me.BTNIMPRIMIR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNIMPRIMIR.Image = CType(resources.GetObject("BTNIMPRIMIR.Image"), System.Drawing.Image)
        Me.BTNIMPRIMIR.Location = New System.Drawing.Point(870, 186)
        Me.BTNIMPRIMIR.Name = "BTNIMPRIMIR"
        Me.BTNIMPRIMIR.Size = New System.Drawing.Size(92, 96)
        Me.BTNIMPRIMIR.TabIndex = 1392
        Me.BTNIMPRIMIR.UseVisualStyleBackColor = False
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.Color.White
        Me.BTNMOSTRAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNMOSTRAR.Image = CType(resources.GetObject("BTNMOSTRAR.Image"), System.Drawing.Image)
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(721, 186)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(92, 96)
        Me.BTNMOSTRAR.TabIndex = 1391
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'LBLA
        '
        Me.LBLA.AutoSize = True
        Me.LBLA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLA.Location = New System.Drawing.Point(23, 697)
        Me.LBLA.Name = "LBLA"
        Me.LBLA.Size = New System.Drawing.Size(49, 17)
        Me.LBLA.TabIndex = 1393
        Me.LBLA.Text = "$0.00"
        '
        'LBLB
        '
        Me.LBLB.AutoSize = True
        Me.LBLB.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLB.Location = New System.Drawing.Point(160, 697)
        Me.LBLB.Name = "LBLB"
        Me.LBLB.Size = New System.Drawing.Size(49, 17)
        Me.LBLB.TabIndex = 1394
        Me.LBLB.Text = "$0.00"
        '
        'LBLC
        '
        Me.LBLC.AutoSize = True
        Me.LBLC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLC.Location = New System.Drawing.Point(350, 697)
        Me.LBLC.Name = "LBLC"
        Me.LBLC.Size = New System.Drawing.Size(49, 17)
        Me.LBLC.TabIndex = 1395
        Me.LBLC.Text = "$0.00"
        '
        'LBLD
        '
        Me.LBLD.AutoSize = True
        Me.LBLD.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLD.Location = New System.Drawing.Point(479, 697)
        Me.LBLD.Name = "LBLD"
        Me.LBLD.Size = New System.Drawing.Size(49, 17)
        Me.LBLD.TabIndex = 1396
        Me.LBLD.Text = "$0.00"
        '
        'LBLE
        '
        Me.LBLE.AutoSize = True
        Me.LBLE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLE.Location = New System.Drawing.Point(629, 697)
        Me.LBLE.Name = "LBLE"
        Me.LBLE.Size = New System.Drawing.Size(49, 17)
        Me.LBLE.TabIndex = 1397
        Me.LBLE.Text = "$0.00"
        '
        'LBLF
        '
        Me.LBLF.AutoSize = True
        Me.LBLF.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLF.Location = New System.Drawing.Point(783, 697)
        Me.LBLF.Name = "LBLF"
        Me.LBLF.Size = New System.Drawing.Size(49, 17)
        Me.LBLF.TabIndex = 1398
        Me.LBLF.Text = "$0.00"
        '
        'LBLG
        '
        Me.LBLG.AutoSize = True
        Me.LBLG.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLG.Location = New System.Drawing.Point(718, 331)
        Me.LBLG.Name = "LBLG"
        Me.LBLG.Size = New System.Drawing.Size(49, 17)
        Me.LBLG.TabIndex = 1399
        Me.LBLG.Text = "$0.00"
        '
        'CHKTA
        '
        Me.CHKTA.AutoSize = True
        Me.CHKTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKTA.Location = New System.Drawing.Point(762, 87)
        Me.CHKTA.Name = "CHKTA"
        Me.CHKTA.Size = New System.Drawing.Size(146, 20)
        Me.CHKTA.TabIndex = 1400
        Me.CHKTA.Tag = "1"
        Me.CHKTA.Text = "Todos el adeudo"
        Me.CHKTA.UseVisualStyleBackColor = True
        '
        'CHKEP
        '
        Me.CHKEP.AutoSize = True
        Me.CHKEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKEP.Location = New System.Drawing.Point(762, 134)
        Me.CHKEP.Name = "CHKEP"
        Me.CHKEP.Size = New System.Drawing.Size(132, 20)
        Me.CHKEP.TabIndex = 1479
        Me.CHKEP.Tag = ""
        Me.CHKEP.Text = "Incluir Morosos"
        Me.CHKEP.UseVisualStyleBackColor = True
        Me.CHKEP.Visible = False
        '
        'frmCarteleraCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 732)
        Me.Controls.Add(Me.CHKEP)
        Me.Controls.Add(Me.CHKTA)
        Me.Controls.Add(Me.LBLG)
        Me.Controls.Add(Me.LBLF)
        Me.Controls.Add(Me.LBLE)
        Me.Controls.Add(Me.LBLD)
        Me.Controls.Add(Me.LBLC)
        Me.Controls.Add(Me.LBLB)
        Me.Controls.Add(Me.LBLA)
        Me.Controls.Add(Me.BTNIMPRIMIR)
        Me.Controls.Add(Me.BTNMOSTRAR)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.DTDE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CHKCOM)
        Me.Controls.Add(Me.CLB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCarteleraCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cartera de Clientes"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLB As System.Windows.Forms.CheckedListBox
    Friend WithEvents CHKCOM As System.Windows.Forms.CheckBox
    Friend WithEvents DTDE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BTNIMPRIMIR As System.Windows.Forms.Button
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
    Friend WithEvents LBLA As System.Windows.Forms.Label
    Friend WithEvents LBLB As System.Windows.Forms.Label
    Friend WithEvents LBLC As System.Windows.Forms.Label
    Friend WithEvents LBLD As System.Windows.Forms.Label
    Friend WithEvents LBLE As System.Windows.Forms.Label
    Friend WithEvents LBLF As System.Windows.Forms.Label
    Friend WithEvents LBLG As System.Windows.Forms.Label
    Friend WithEvents CHKTA As System.Windows.Forms.CheckBox
    Friend WithEvents CHKEP As System.Windows.Forms.CheckBox
End Class
