<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentaDiaria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentaDiaria))
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.DTDE = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTHASTA = New System.Windows.Forms.DateTimePicker
        Me.BTNMOSTRAR = New System.Windows.Forms.Button
        Me.CBTI = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.LBLE = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LBLT = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LBLC = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.LBLTTRA = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.LBLTCRE = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(21, 147)
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
        Me.DGV.Size = New System.Drawing.Size(906, 404)
        Me.DGV.TabIndex = 1211
        '
        'DTDE
        '
        Me.DTDE.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTDE.Location = New System.Drawing.Point(196, 85)
        Me.DTDE.Name = "DTDE"
        Me.DTDE.Size = New System.Drawing.Size(104, 25)
        Me.DTDE.TabIndex = 1206
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(388, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 17)
        Me.Label4.TabIndex = 1210
        Me.Label4.Text = "Hasta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(168, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 17)
        Me.Label3.TabIndex = 1209
        Me.Label3.Text = "De"
        '
        'DTHASTA
        '
        Me.DTHASTA.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTHASTA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTHASTA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTHASTA.Location = New System.Drawing.Point(438, 85)
        Me.DTHASTA.Name = "DTHASTA"
        Me.DTHASTA.Size = New System.Drawing.Size(104, 25)
        Me.DTHASTA.TabIndex = 1207
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.Color.White
        Me.BTNMOSTRAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNMOSTRAR.Image = CType(resources.GetObject("BTNMOSTRAR.Image"), System.Drawing.Image)
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(675, 32)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(103, 96)
        Me.BTNMOSTRAR.TabIndex = 1208
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'CBTI
        '
        Me.CBTI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTI.FormattingEnabled = True
        Me.CBTI.Location = New System.Drawing.Point(154, 32)
        Me.CBTI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CBTI.Name = "CBTI"
        Me.CBTI.Size = New System.Drawing.Size(388, 26)
        Me.CBTI.TabIndex = 1240
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(86, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 18)
        Me.Label5.TabIndex = 1241
        Me.Label5.Text = "Tienda"
        '
        'LBLE
        '
        Me.LBLE.AutoSize = True
        Me.LBLE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLE.ForeColor = System.Drawing.Color.Navy
        Me.LBLE.Location = New System.Drawing.Point(163, 565)
        Me.LBLE.Name = "LBLE"
        Me.LBLE.Size = New System.Drawing.Size(21, 22)
        Me.LBLE.TabIndex = 1269
        Me.LBLE.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 565)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 22)
        Me.Label2.TabIndex = 1268
        Me.Label2.Text = "Total efectivo $"
        '
        'LBLT
        '
        Me.LBLT.AutoSize = True
        Me.LBLT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLT.ForeColor = System.Drawing.Color.Navy
        Me.LBLT.Location = New System.Drawing.Point(482, 565)
        Me.LBLT.Name = "LBLT"
        Me.LBLT.Size = New System.Drawing.Size(21, 22)
        Me.LBLT.TabIndex = 1271
        Me.LBLT.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(348, 565)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 22)
        Me.Label6.TabIndex = 1270
        Me.Label6.Text = "Total tarjeta $"
        '
        'LBLC
        '
        Me.LBLC.AutoSize = True
        Me.LBLC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLC.ForeColor = System.Drawing.Color.Navy
        Me.LBLC.Location = New System.Drawing.Point(830, 565)
        Me.LBLC.Name = "LBLC"
        Me.LBLC.Size = New System.Drawing.Size(21, 22)
        Me.LBLC.TabIndex = 1273
        Me.LBLC.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(689, 565)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 22)
        Me.Label8.TabIndex = 1272
        Me.Label8.Text = "Total cheque $"
        '
        'LBLTTRA
        '
        Me.LBLTTRA.AutoSize = True
        Me.LBLTTRA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTTRA.ForeColor = System.Drawing.Color.Navy
        Me.LBLTTRA.Location = New System.Drawing.Point(326, 594)
        Me.LBLTTRA.Name = "LBLTTRA"
        Me.LBLTTRA.Size = New System.Drawing.Size(21, 22)
        Me.LBLTTRA.TabIndex = 1275
        Me.LBLTTRA.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(134, 594)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(198, 22)
        Me.Label7.TabIndex = 1274
        Me.Label7.Text = "Total transferencia $"
        '
        'LBLTCRE
        '
        Me.LBLTCRE.AutoSize = True
        Me.LBLTCRE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTCRE.ForeColor = System.Drawing.Color.Navy
        Me.LBLTCRE.Location = New System.Drawing.Point(694, 594)
        Me.LBLTCRE.Name = "LBLTCRE"
        Me.LBLTCRE.Size = New System.Drawing.Size(21, 22)
        Me.LBLTCRE.TabIndex = 1277
        Me.LBLTCRE.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(556, 594)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(145, 22)
        Me.Label10.TabIndex = 1276
        Me.Label10.Text = "Total Crédito $"
        '
        'frmVentaDiaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 625)
        Me.Controls.Add(Me.LBLTCRE)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LBLTTRA)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LBLC)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LBLT)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LBLE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBTI)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.DTDE)
        Me.Controls.Add(Me.BTNMOSTRAR)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTHASTA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVentaDiaria"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Venta diaria"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents DTDE As System.Windows.Forms.DateTimePicker
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTHASTA As System.Windows.Forms.DateTimePicker
    Friend WithEvents CBTI As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LBLE As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LBLT As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LBLC As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LBLTTRA As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LBLTCRE As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
