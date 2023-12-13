<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaPublicoGeneral
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaPublicoGeneral))
        Me.Label15 = New System.Windows.Forms.Label
        Me.DTDE = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.TXTNCLI = New System.Windows.Forms.TextBox
        Me.TXTFAC = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TXTTOT = New System.Windows.Forms.TextBox
        Me.TXTIVA = New System.Windows.Forms.TextBox
        Me.TXTSUB = New System.Windows.Forms.TextBox
        Me.TXTLETRA = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        Me.TXTNFIS = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TXTDFIS = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TXTRFC = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TXTCD = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TXTCP = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTSI = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TXSNI = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TXTCON = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(730, 67)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 16)
        Me.Label15.TabIndex = 1132
        Me.Label15.Text = "Fecha"
        '
        'DTDE
        '
        Me.DTDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTDE.Location = New System.Drawing.Point(787, 59)
        Me.DTDE.Name = "DTDE"
        Me.DTDE.Size = New System.Drawing.Size(140, 29)
        Me.DTDE.TabIndex = 1131
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(23, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(115, 16)
        Me.Label14.TabIndex = 1129
        Me.Label14.Text = "Nombre Cliente"
        '
        'TXTNCLI
        '
        Me.TXTNCLI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNCLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNCLI.Location = New System.Drawing.Point(26, 44)
        Me.TXTNCLI.MaxLength = 50
        Me.TXTNCLI.Name = "TXTNCLI"
        Me.TXTNCLI.ReadOnly = True
        Me.TXTNCLI.Size = New System.Drawing.Size(638, 26)
        Me.TXTNCLI.TabIndex = 1128
        Me.TXTNCLI.Text = "PUBLICO GENERAL"
        '
        'TXTFAC
        '
        Me.TXTFAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFAC.Location = New System.Drawing.Point(787, 27)
        Me.TXTFAC.MaxLength = 10
        Me.TXTFAC.Name = "TXTFAC"
        Me.TXTFAC.Size = New System.Drawing.Size(140, 26)
        Me.TXTFAC.TabIndex = 1124
        Me.TXTFAC.Text = "1"
        Me.TXTFAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(693, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 16)
        Me.Label13.TabIndex = 1125
        Me.Label13.Text = "No. Factura"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(710, 438)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 16)
        Me.Label8.TabIndex = 1109
        Me.Label8.Text = "Total"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(710, 396)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 16)
        Me.Label7.TabIndex = 1108
        Me.Label7.Text = "I.V.A."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(679, 354)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 1107
        Me.Label5.Text = "Sub Total"
        '
        'TXTTOT
        '
        Me.TXTTOT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOT.Location = New System.Drawing.Point(772, 432)
        Me.TXTTOT.MaxLength = 50
        Me.TXTTOT.Name = "TXTTOT"
        Me.TXTTOT.ReadOnly = True
        Me.TXTTOT.Size = New System.Drawing.Size(130, 26)
        Me.TXTTOT.TabIndex = 1106
        Me.TXTTOT.Text = "0"
        Me.TXTTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTIVA
        '
        Me.TXTIVA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIVA.Location = New System.Drawing.Point(772, 390)
        Me.TXTIVA.MaxLength = 50
        Me.TXTIVA.Name = "TXTIVA"
        Me.TXTIVA.ReadOnly = True
        Me.TXTIVA.Size = New System.Drawing.Size(130, 26)
        Me.TXTIVA.TabIndex = 1105
        Me.TXTIVA.Text = "0"
        Me.TXTIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSUB
        '
        Me.TXTSUB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSUB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUB.Location = New System.Drawing.Point(772, 348)
        Me.TXTSUB.MaxLength = 50
        Me.TXTSUB.Name = "TXTSUB"
        Me.TXTSUB.ReadOnly = True
        Me.TXTSUB.Size = New System.Drawing.Size(130, 26)
        Me.TXTSUB.TabIndex = 1104
        Me.TXTSUB.Text = "0"
        Me.TXTSUB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTLETRA
        '
        Me.TXTLETRA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTLETRA.Enabled = False
        Me.TXTLETRA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLETRA.Location = New System.Drawing.Point(12, 350)
        Me.TXTLETRA.MaxLength = 10
        Me.TXTLETRA.Multiline = True
        Me.TXTLETRA.Name = "TXTLETRA"
        Me.TXTLETRA.Size = New System.Drawing.Size(638, 61)
        Me.TXTLETRA.TabIndex = 1102
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(258, 331)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 16)
        Me.Label2.TabIndex = 1103
        Me.Label2.Text = "Cantidad Con Letra"
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(456, 438)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 1130
        Me.BTNCANCELAR.Text = "&c"
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(296, 438)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 1126
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'TXTNFIS
        '
        Me.TXTNFIS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNFIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNFIS.Location = New System.Drawing.Point(26, 114)
        Me.TXTNFIS.MaxLength = 50
        Me.TXTNFIS.Name = "TXTNFIS"
        Me.TXTNFIS.ReadOnly = True
        Me.TXTNFIS.Size = New System.Drawing.Size(638, 26)
        Me.TXTNFIS.TabIndex = 1114
        Me.TXTNFIS.Text = "PUBLICO GENERAL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 16)
        Me.Label6.TabIndex = 1115
        Me.Label6.Text = "Nombre Fiscal"
        '
        'TXTDFIS
        '
        Me.TXTDFIS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDFIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDFIS.Location = New System.Drawing.Point(26, 177)
        Me.TXTDFIS.MaxLength = 50
        Me.TXTDFIS.Name = "TXTDFIS"
        Me.TXTDFIS.Size = New System.Drawing.Size(638, 26)
        Me.TXTDFIS.TabIndex = 1116
        Me.TXTDFIS.Text = "LOS MOCHIS, SINALOA"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(23, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 16)
        Me.Label9.TabIndex = 1117
        Me.Label9.Text = "Dirección Fiscal"
        '
        'TXTRFC
        '
        Me.TXTRFC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRFC.Location = New System.Drawing.Point(684, 129)
        Me.TXTRFC.MaxLength = 50
        Me.TXTRFC.Name = "TXTRFC"
        Me.TXTRFC.Size = New System.Drawing.Size(220, 26)
        Me.TXTRFC.TabIndex = 1118
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(687, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 16)
        Me.Label10.TabIndex = 1119
        Me.Label10.Text = "R.F.C."
        '
        'TXTCD
        '
        Me.TXTCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCD.Location = New System.Drawing.Point(684, 177)
        Me.TXTCD.MaxLength = 50
        Me.TXTCD.Name = "TXTCD"
        Me.TXTCD.Size = New System.Drawing.Size(220, 26)
        Me.TXTCD.TabIndex = 1120
        Me.TXTCD.Text = "LOS MOCHIS, SINALOA"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(681, 158)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 16)
        Me.Label11.TabIndex = 1121
        Me.Label11.Text = "Ciudad"
        '
        'TXTCP
        '
        Me.TXTCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCP.Location = New System.Drawing.Point(684, 224)
        Me.TXTCP.MaxLength = 50
        Me.TXTCP.Name = "TXTCP"
        Me.TXTCP.Size = New System.Drawing.Size(220, 26)
        Me.TXTCP.TabIndex = 1122
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(681, 205)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 16)
        Me.Label12.TabIndex = 1123
        Me.Label12.Text = "Código Postal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(654, 273)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 1134
        Me.Label1.Text = "Sub Total Iva"
        '
        'TXTSI
        '
        Me.TXTSI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSI.Location = New System.Drawing.Point(772, 267)
        Me.TXTSI.MaxLength = 50
        Me.TXTSI.Name = "TXTSI"
        Me.TXTSI.Size = New System.Drawing.Size(130, 26)
        Me.TXTSI.TabIndex = 1133
        Me.TXTSI.Text = "0"
        Me.TXTSI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(630, 305)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 16)
        Me.Label16.TabIndex = 1136
        Me.Label16.Text = "Sub Total No Iva"
        '
        'TXSNI
        '
        Me.TXSNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXSNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXSNI.Location = New System.Drawing.Point(772, 299)
        Me.TXSNI.MaxLength = 50
        Me.TXSNI.Name = "TXSNI"
        Me.TXSNI.Size = New System.Drawing.Size(130, 26)
        Me.TXSNI.TabIndex = 1135
        Me.TXSNI.Text = "0"
        Me.TXSNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(123, 226)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 16)
        Me.Label17.TabIndex = 1138
        Me.Label17.Text = "Concepto"
        '
        'TXTCON
        '
        Me.TXTCON.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCON.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCON.Location = New System.Drawing.Point(126, 251)
        Me.TXTCON.MaxLength = 50
        Me.TXTCON.Name = "TXTCON"
        Me.TXTCON.Size = New System.Drawing.Size(343, 26)
        Me.TXTCON.TabIndex = 1137
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(31, 226)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 16)
        Me.Label18.TabIndex = 1139
        Me.Label18.Text = "Cantidad"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(47, 257)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(36, 16)
        Me.Label19.TabIndex = 1140
        Me.Label19.Text = "1.00"
        '
        'frmFacturaPublicoGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 533)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TXTCON)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TXSNI)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXTSI)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.DTDE)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TXTNCLI)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.TXTFAC)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TXTCP)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TXTCD)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TXTRFC)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TXTDFIS)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TXTNFIS)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXTTOT)
        Me.Controls.Add(Me.TXTIVA)
        Me.Controls.Add(Me.TXTSUB)
        Me.Controls.Add(Me.TXTLETRA)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFacturaPublicoGeneral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Factura Público General"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DTDE As System.Windows.Forms.DateTimePicker
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TXTNCLI As System.Windows.Forms.TextBox
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents TXTFAC As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTTOT As System.Windows.Forms.TextBox
    Friend WithEvents TXTIVA As System.Windows.Forms.TextBox
    Friend WithEvents TXTSUB As System.Windows.Forms.TextBox
    Friend WithEvents TXTLETRA As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTNFIS As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTDFIS As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXTRFC As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTCD As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TXTCP As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTSI As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TXSNI As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TXTCON As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
