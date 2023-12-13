<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagoMixto
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagoMixto))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TXTTARJETA = New System.Windows.Forms.TextBox
        Me.CHKTARJETA = New System.Windows.Forms.CheckBox
        Me.CHKEFECTIVO = New System.Windows.Forms.CheckBox
        Me.TXTEFECTIVO = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTCAMBIO = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TXTIVA = New System.Windows.Forms.TextBox
        Me.TXTSUB = New System.Windows.Forms.TextBox
        Me.BTNCOBRAR = New System.Windows.Forms.Button
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTFALTA = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXTTOT = New System.Windows.Forms.TextBox
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TXTTARJETA
        '
        Me.TXTTARJETA.BackColor = System.Drawing.SystemColors.Window
        Me.TXTTARJETA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTARJETA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTARJETA.Location = New System.Drawing.Point(199, 76)
        Me.TXTTARJETA.MaxLength = 20
        Me.TXTTARJETA.Name = "TXTTARJETA"
        Me.TXTTARJETA.Size = New System.Drawing.Size(145, 26)
        Me.TXTTARJETA.TabIndex = 1070
        Me.TXTTARJETA.Text = "0"
        Me.TXTTARJETA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CHKTARJETA
        '
        Me.CHKTARJETA.AutoSize = True
        Me.CHKTARJETA.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKTARJETA.Location = New System.Drawing.Point(200, 38)
        Me.CHKTARJETA.Name = "CHKTARJETA"
        Me.CHKTARJETA.Size = New System.Drawing.Size(115, 33)
        Me.CHKTARJETA.TabIndex = 1068
        Me.CHKTARJETA.Text = "Tarjeta"
        Me.CHKTARJETA.UseVisualStyleBackColor = True
        '
        'CHKEFECTIVO
        '
        Me.CHKEFECTIVO.AutoSize = True
        Me.CHKEFECTIVO.Checked = True
        Me.CHKEFECTIVO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKEFECTIVO.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKEFECTIVO.Location = New System.Drawing.Point(12, 37)
        Me.CHKEFECTIVO.Name = "CHKEFECTIVO"
        Me.CHKEFECTIVO.Size = New System.Drawing.Size(125, 33)
        Me.CHKEFECTIVO.TabIndex = 1067
        Me.CHKEFECTIVO.Text = "Efectivo"
        Me.CHKEFECTIVO.UseVisualStyleBackColor = True
        '
        'TXTEFECTIVO
        '
        Me.TXTEFECTIVO.BackColor = System.Drawing.SystemColors.Window
        Me.TXTEFECTIVO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTEFECTIVO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEFECTIVO.Location = New System.Drawing.Point(15, 76)
        Me.TXTEFECTIVO.MaxLength = 20
        Me.TXTEFECTIVO.Name = "TXTEFECTIVO"
        Me.TXTEFECTIVO.Size = New System.Drawing.Size(145, 26)
        Me.TXTEFECTIVO.TabIndex = 1057
        Me.TXTEFECTIVO.Text = "0"
        Me.TXTEFECTIVO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(215, 303)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 16)
        Me.Label3.TabIndex = 1065
        Me.Label3.Text = "Cambio"
        '
        'TXTCAMBIO
        '
        Me.TXTCAMBIO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCAMBIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCAMBIO.Location = New System.Drawing.Point(217, 322)
        Me.TXTCAMBIO.MaxLength = 50
        Me.TXTCAMBIO.Name = "TXTCAMBIO"
        Me.TXTCAMBIO.ReadOnly = True
        Me.TXTCAMBIO.Size = New System.Drawing.Size(145, 26)
        Me.TXTCAMBIO.TabIndex = 1064
        Me.TXTCAMBIO.Text = "0"
        Me.TXTCAMBIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 16)
        Me.Label7.TabIndex = 1062
        Me.Label7.Text = "I.V.A."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 1061
        Me.Label5.Text = "Sub Total"
        '
        'TXTIVA
        '
        Me.TXTIVA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIVA.Location = New System.Drawing.Point(12, 182)
        Me.TXTIVA.MaxLength = 50
        Me.TXTIVA.Name = "TXTIVA"
        Me.TXTIVA.ReadOnly = True
        Me.TXTIVA.Size = New System.Drawing.Size(123, 26)
        Me.TXTIVA.TabIndex = 1059
        Me.TXTIVA.Text = "0"
        Me.TXTIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSUB
        '
        Me.TXTSUB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSUB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUB.Location = New System.Drawing.Point(12, 133)
        Me.TXTSUB.MaxLength = 50
        Me.TXTSUB.Name = "TXTSUB"
        Me.TXTSUB.ReadOnly = True
        Me.TXTSUB.Size = New System.Drawing.Size(123, 26)
        Me.TXTSUB.TabIndex = 1058
        Me.TXTSUB.Text = "0"
        Me.TXTSUB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BTNCOBRAR
        '
        Me.BTNCOBRAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNCOBRAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCOBRAR.ForeColor = System.Drawing.Color.White
        Me.BTNCOBRAR.Image = CType(resources.GetObject("BTNCOBRAR.Image"), System.Drawing.Image)
        Me.BTNCOBRAR.Location = New System.Drawing.Point(246, 148)
        Me.BTNCOBRAR.Name = "BTNCOBRAR"
        Me.BTNCOBRAR.Size = New System.Drawing.Size(80, 78)
        Me.BTNCOBRAR.TabIndex = 1066
        Me.BTNCOBRAR.UseVisualStyleBackColor = False
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV.Location = New System.Drawing.Point(377, 12)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV.Size = New System.Drawing.Size(594, 324)
        Me.DGV.TabIndex = 1072
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(215, 255)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 1074
        Me.Label1.Text = "Falta"
        '
        'TXTFALTA
        '
        Me.TXTFALTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFALTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFALTA.Location = New System.Drawing.Point(217, 274)
        Me.TXTFALTA.MaxLength = 50
        Me.TXTFALTA.Name = "TXTFALTA"
        Me.TXTFALTA.ReadOnly = True
        Me.TXTFALTA.Size = New System.Drawing.Size(145, 26)
        Me.TXTFALTA.TabIndex = 1073
        Me.TXTFALTA.Text = "0"
        Me.TXTFALTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 210)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 16)
        Me.Label8.TabIndex = 1076
        Me.Label8.Text = "Total"
        '
        'TXTTOT
        '
        Me.TXTTOT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOT.Location = New System.Drawing.Point(12, 227)
        Me.TXTTOT.MaxLength = 50
        Me.TXTTOT.Name = "TXTTOT"
        Me.TXTTOT.ReadOnly = True
        Me.TXTTOT.Size = New System.Drawing.Size(177, 26)
        Me.TXTTOT.TabIndex = 1075
        Me.TXTTOT.Text = "0"
        Me.TXTTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmPagoMixto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 360)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXTTOT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXTFALTA)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.TXTTARJETA)
        Me.Controls.Add(Me.CHKTARJETA)
        Me.Controls.Add(Me.CHKEFECTIVO)
        Me.Controls.Add(Me.BTNCOBRAR)
        Me.Controls.Add(Me.TXTEFECTIVO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXTCAMBIO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXTIVA)
        Me.Controls.Add(Me.TXTSUB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPagoMixto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pago Mixto"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXTTARJETA As System.Windows.Forms.TextBox
    Friend WithEvents CHKTARJETA As System.Windows.Forms.CheckBox
    Friend WithEvents CHKEFECTIVO As System.Windows.Forms.CheckBox
    Friend WithEvents BTNCOBRAR As System.Windows.Forms.Button
    Friend WithEvents TXTEFECTIVO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTCAMBIO As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTIVA As System.Windows.Forms.TextBox
    Friend WithEvents TXTSUB As System.Windows.Forms.TextBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTFALTA As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTTOT As System.Windows.Forms.TextBox
End Class
