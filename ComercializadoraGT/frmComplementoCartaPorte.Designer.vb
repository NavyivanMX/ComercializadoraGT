<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComplementoCartaPorte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComplementoCartaPorte))
        Me.CBEDO = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TXTCP = New System.Windows.Forms.TextBox()
        Me.BTNGUARDAR = New System.Windows.Forms.Button()
        Me.TXTMONTO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTPOLMA = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTASEMA = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DTHORASAL = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTFSAL = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBCHO = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBVE = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DTHORALLEG = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTFLLEG = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTDIS = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CBEDO
        '
        Me.CBEDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBEDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBEDO.FormattingEnabled = True
        Me.CBEDO.Items.AddRange(New Object() {"Aguascalientes ", "Baja California ", "Baja California Sur ", "Campeche ", "Chiapas ", "Chihuahua ", "Coahuila ", "Colima ", "Distrito Federal ", "Durango ", "Estado de México ", "Guanajuato ", "Guerrero ", "Hidalgo ", "Jalisco ", "Michoacán ", "Morelos ", "Nayarit ", "Nuevo León ", "Oaxaca ", "Puebla ", "Querétaro ", "Quintana Roo ", "San Luis Potosí ", "Sinaloa ", "Sonora ", "Tabasco ", "Tamaulipas ", "Tlaxcala ", "Veracruz ", "Yucatán ", "Zacatecas "})
        Me.CBEDO.Location = New System.Drawing.Point(100, 430)
        Me.CBEDO.Margin = New System.Windows.Forms.Padding(4)
        Me.CBEDO.Name = "CBEDO"
        Me.CBEDO.Size = New System.Drawing.Size(380, 28)
        Me.CBEDO.TabIndex = 1125
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(25, 438)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(67, 20)
        Me.Label39.TabIndex = 1126
        Me.Label39.Text = "Estado"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(504, 438)
        Me.Label40.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(44, 20)
        Me.Label40.TabIndex = 1128
        Me.Label40.Text = "C.P."
        '
        'TXTCP
        '
        Me.TXTCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCP.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCP.Location = New System.Drawing.Point(561, 427)
        Me.TXTCP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTCP.MaxLength = 13
        Me.TXTCP.Name = "TXTCP"
        Me.TXTCP.Size = New System.Drawing.Size(172, 31)
        Me.TXTCP.TabIndex = 1127
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(324, 500)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNGUARDAR.TabIndex = 1143
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'TXTMONTO
        '
        Me.TXTMONTO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMONTO.Location = New System.Drawing.Point(30, 335)
        Me.TXTMONTO.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTMONTO.MaxLength = 10
        Me.TXTMONTO.Name = "TXTMONTO"
        Me.TXTMONTO.Size = New System.Drawing.Size(341, 29)
        Me.TXTMONTO.TabIndex = 1141
        Me.TXTMONTO.Text = "0"
        Me.TXTMONTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 308)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 22)
        Me.Label4.TabIndex = 1142
        Me.Label4.Text = "Monto Asegurado"
        '
        'TXTPOLMA
        '
        Me.TXTPOLMA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPOLMA.Location = New System.Drawing.Point(393, 261)
        Me.TXTPOLMA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTPOLMA.MaxLength = 200
        Me.TXTPOLMA.Name = "TXTPOLMA"
        Me.TXTPOLMA.Size = New System.Drawing.Size(341, 29)
        Me.TXTPOLMA.TabIndex = 1138
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(393, 234)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(126, 22)
        Me.Label12.TabIndex = 1140
        Me.Label12.Text = "Poliza Carga"
        '
        'TXTASEMA
        '
        Me.TXTASEMA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTASEMA.Location = New System.Drawing.Point(23, 261)
        Me.TXTASEMA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTASEMA.MaxLength = 200
        Me.TXTASEMA.Name = "TXTASEMA"
        Me.TXTASEMA.Size = New System.Drawing.Size(341, 29)
        Me.TXTASEMA.TabIndex = 1137
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(23, 234)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(190, 22)
        Me.Label13.TabIndex = 1139
        Me.Label13.Text = "Aseguradora Carga"
        '
        'DTHORASAL
        '
        Me.DTHORASAL.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTHORASAL.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTHORASAL.Location = New System.Drawing.Point(573, 124)
        Me.DTHORASAL.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTHORASAL.Name = "DTHORASAL"
        Me.DTHORASAL.ShowUpDown = True
        Me.DTHORASAL.Size = New System.Drawing.Size(171, 29)
        Me.DTHORASAL.TabIndex = 1135
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(405, 131)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 22)
        Me.Label3.TabIndex = 1136
        Me.Label3.Text = "Hora de Salida"
        '
        'DTFSAL
        '
        Me.DTFSAL.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFSAL.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFSAL.Location = New System.Drawing.Point(200, 124)
        Me.DTFSAL.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTFSAL.Name = "DTFSAL"
        Me.DTFSAL.Size = New System.Drawing.Size(171, 29)
        Me.DTFSAL.TabIndex = 1133
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 131)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 22)
        Me.Label2.TabIndex = 1134
        Me.Label2.Text = "Fecha de Salida"
        '
        'CBCHO
        '
        Me.CBCHO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCHO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCHO.FormattingEnabled = True
        Me.CBCHO.Location = New System.Drawing.Point(118, 69)
        Me.CBCHO.Margin = New System.Windows.Forms.Padding(4)
        Me.CBCHO.Name = "CBCHO"
        Me.CBCHO.Size = New System.Drawing.Size(626, 28)
        Me.CBCHO.TabIndex = 1131
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 75)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 24)
        Me.Label1.TabIndex = 1132
        Me.Label1.Text = "Chofer"
        '
        'CBVE
        '
        Me.CBVE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBVE.FormattingEnabled = True
        Me.CBVE.Location = New System.Drawing.Point(118, 26)
        Me.CBVE.Margin = New System.Windows.Forms.Padding(4)
        Me.CBVE.Name = "CBVE"
        Me.CBVE.Size = New System.Drawing.Size(626, 28)
        Me.CBVE.TabIndex = 1129
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 30)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 24)
        Me.Label10.TabIndex = 1130
        Me.Label10.Text = "Vehículo"
        '
        'DTHORALLEG
        '
        Me.DTHORALLEG.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTHORALLEG.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTHORALLEG.Location = New System.Drawing.Point(573, 178)
        Me.DTHORALLEG.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTHORALLEG.Name = "DTHORALLEG"
        Me.DTHORALLEG.ShowUpDown = True
        Me.DTHORALLEG.Size = New System.Drawing.Size(171, 29)
        Me.DTHORALLEG.TabIndex = 1146
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(405, 185)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 22)
        Me.Label5.TabIndex = 1147
        Me.Label5.Text = "Hora de Llegada"
        '
        'DTFLLEG
        '
        Me.DTFLLEG.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFLLEG.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFLLEG.Location = New System.Drawing.Point(200, 178)
        Me.DTFLLEG.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTFLLEG.Name = "DTFLLEG"
        Me.DTFLLEG.Size = New System.Drawing.Size(171, 29)
        Me.DTFLLEG.TabIndex = 1144
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 185)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(171, 22)
        Me.Label6.TabIndex = 1145
        Me.Label6.Text = "Fecha de Llegada"
        '
        'TXTDIS
        '
        Me.TXTDIS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDIS.Location = New System.Drawing.Point(393, 335)
        Me.TXTDIS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTDIS.MaxLength = 10
        Me.TXTDIS.Name = "TXTDIS"
        Me.TXTDIS.Size = New System.Drawing.Size(341, 29)
        Me.TXTDIS.TabIndex = 1148
        Me.TXTDIS.Text = "0"
        Me.TXTDIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(389, 308)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(191, 22)
        Me.Label7.TabIndex = 1149
        Me.Label7.Text = "Distancia Recorrida"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(341, 393)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 20)
        Me.Label8.TabIndex = 1150
        Me.Label8.Text = "Destino"
        '
        'frmComplementoCartaPorte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 612)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXTDIS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DTHORALLEG)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DTFLLEG)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.TXTMONTO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTPOLMA)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TXTASEMA)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.DTHORASAL)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTFSAL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBCHO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBVE)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.TXTCP)
        Me.Controls.Add(Me.CBEDO)
        Me.Controls.Add(Me.Label39)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComplementoCartaPorte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Información para Complemento Carta Porte"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CBEDO As ComboBox
    Friend WithEvents Label39 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents TXTCP As TextBox
    Friend WithEvents BTNGUARDAR As Button
    Friend WithEvents TXTMONTO As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTPOLMA As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TXTASEMA As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents DTHORASAL As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents DTFSAL As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents CBCHO As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CBVE As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents DTHORALLEG As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents DTFLLEG As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTDIS As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
