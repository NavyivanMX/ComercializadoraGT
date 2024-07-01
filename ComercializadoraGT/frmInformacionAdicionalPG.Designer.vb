<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInformacionAdicionalPG
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GBIAPG = New System.Windows.Forms.GroupBox()
        Me.Label128 = New System.Windows.Forms.Label()
        Me.CBIAAÑO = New System.Windows.Forms.ComboBox()
        Me.CBIAPER = New System.Windows.Forms.ComboBox()
        Me.Label136 = New System.Windows.Forms.Label()
        Me.Label129 = New System.Windows.Forms.Label()
        Me.CBIAMES = New System.Windows.Forms.ComboBox()
        Me.BTNACEPTAR = New System.Windows.Forms.Button()
        Me.GBIAPG.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBIAPG
        '
        Me.GBIAPG.Controls.Add(Me.Label128)
        Me.GBIAPG.Controls.Add(Me.CBIAAÑO)
        Me.GBIAPG.Controls.Add(Me.CBIAPER)
        Me.GBIAPG.Controls.Add(Me.Label136)
        Me.GBIAPG.Controls.Add(Me.Label129)
        Me.GBIAPG.Controls.Add(Me.CBIAMES)
        Me.GBIAPG.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBIAPG.Location = New System.Drawing.Point(22, 24)
        Me.GBIAPG.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GBIAPG.Name = "GBIAPG"
        Me.GBIAPG.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GBIAPG.Size = New System.Drawing.Size(561, 299)
        Me.GBIAPG.TabIndex = 1261
        Me.GBIAPG.TabStop = False
        Me.GBIAPG.Text = "Información Adicional ( Público en general )"
        '
        'Label128
        '
        Me.Label128.AutoSize = True
        Me.Label128.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label128.Location = New System.Drawing.Point(16, 42)
        Me.Label128.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(113, 20)
        Me.Label128.TabIndex = 1252
        Me.Label128.Text = "Periodicidad"
        '
        'CBIAAÑO
        '
        Me.CBIAAÑO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBIAAÑO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBIAAÑO.FormattingEnabled = True
        Me.CBIAAÑO.Items.AddRange(New Object() {"Aguascalientes ", "Baja California ", "Baja California Sur ", "Campeche ", "Chiapas ", "Chihuahua ", "Coahuila ", "Colima ", "Distrito Federal ", "Durango ", "Estado de México ", "Guanajuato ", "Guerrero ", "Hidalgo ", "Jalisco ", "Michoacán ", "Morelos ", "Nayarit ", "Nuevo León ", "Oaxaca ", "Puebla ", "Querétaro ", "Quintana Roo ", "San Luis Potosí ", "Sinaloa ", "Sonora ", "Tabasco ", "Tamaulipas ", "Tlaxcala ", "Veracruz ", "Yucatán ", "Zacatecas "})
        Me.CBIAAÑO.Location = New System.Drawing.Point(14, 232)
        Me.CBIAAÑO.Margin = New System.Windows.Forms.Padding(4)
        Me.CBIAAÑO.Name = "CBIAAÑO"
        Me.CBIAAÑO.Size = New System.Drawing.Size(221, 28)
        Me.CBIAAÑO.TabIndex = 1257
        '
        'CBIAPER
        '
        Me.CBIAPER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBIAPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBIAPER.FormattingEnabled = True
        Me.CBIAPER.Items.AddRange(New Object() {"Aguascalientes ", "Baja California ", "Baja California Sur ", "Campeche ", "Chiapas ", "Chihuahua ", "Coahuila ", "Colima ", "Distrito Federal ", "Durango ", "Estado de México ", "Guanajuato ", "Guerrero ", "Hidalgo ", "Jalisco ", "Michoacán ", "Morelos ", "Nayarit ", "Nuevo León ", "Oaxaca ", "Puebla ", "Querétaro ", "Quintana Roo ", "San Luis Potosí ", "Sinaloa ", "Sonora ", "Tabasco ", "Tamaulipas ", "Tlaxcala ", "Veracruz ", "Yucatán ", "Zacatecas "})
        Me.CBIAPER.Location = New System.Drawing.Point(14, 75)
        Me.CBIAPER.Margin = New System.Windows.Forms.Padding(4)
        Me.CBIAPER.Name = "CBIAPER"
        Me.CBIAPER.Size = New System.Drawing.Size(278, 28)
        Me.CBIAPER.TabIndex = 1253
        '
        'Label136
        '
        Me.Label136.AutoSize = True
        Me.Label136.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label136.Location = New System.Drawing.Point(16, 199)
        Me.Label136.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(41, 20)
        Me.Label136.TabIndex = 1256
        Me.Label136.Text = "Año"
        '
        'Label129
        '
        Me.Label129.AutoSize = True
        Me.Label129.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label129.Location = New System.Drawing.Point(15, 125)
        Me.Label129.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(138, 20)
        Me.Label129.TabIndex = 1254
        Me.Label129.Text = "Mes / Bimestre"
        '
        'CBIAMES
        '
        Me.CBIAMES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBIAMES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBIAMES.FormattingEnabled = True
        Me.CBIAMES.Items.AddRange(New Object() {"Aguascalientes ", "Baja California ", "Baja California Sur ", "Campeche ", "Chiapas ", "Chihuahua ", "Coahuila ", "Colima ", "Distrito Federal ", "Durango ", "Estado de México ", "Guanajuato ", "Guerrero ", "Hidalgo ", "Jalisco ", "Michoacán ", "Morelos ", "Nayarit ", "Nuevo León ", "Oaxaca ", "Puebla ", "Querétaro ", "Quintana Roo ", "San Luis Potosí ", "Sinaloa ", "Sonora ", "Tabasco ", "Tamaulipas ", "Tlaxcala ", "Veracruz ", "Yucatán ", "Zacatecas "})
        Me.CBIAMES.Location = New System.Drawing.Point(14, 158)
        Me.CBIAMES.Margin = New System.Windows.Forms.Padding(4)
        Me.CBIAMES.Name = "CBIAMES"
        Me.CBIAMES.Size = New System.Drawing.Size(520, 28)
        Me.CBIAMES.TabIndex = 1255
        '
        'BTNACEPTAR
        '
        Me.BTNACEPTAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTNACEPTAR.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.button_ok
        Me.BTNACEPTAR.Location = New System.Drawing.Point(227, 355)
        Me.BTNACEPTAR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTNACEPTAR.Name = "BTNACEPTAR"
        Me.BTNACEPTAR.Size = New System.Drawing.Size(164, 138)
        Me.BTNACEPTAR.TabIndex = 1262
        '
        'frmInformacionAdicionalPG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 506)
        Me.Controls.Add(Me.BTNACEPTAR)
        Me.Controls.Add(Me.GBIAPG)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInformacionAdicionalPG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Información Adicional Público en General"
        Me.GBIAPG.ResumeLayout(False)
        Me.GBIAPG.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GBIAPG As GroupBox
    Friend WithEvents Label128 As Label
    Friend WithEvents CBIAAÑO As ComboBox
    Friend WithEvents CBIAPER As ComboBox
    Friend WithEvents Label136 As Label
    Friend WithEvents Label129 As Label
    Friend WithEvents CBIAMES As ComboBox
    Friend WithEvents BTNACEPTAR As Button
End Class
