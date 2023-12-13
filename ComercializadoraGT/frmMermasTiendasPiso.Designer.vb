<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMermasTiendasPiso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMermasTiendasPiso))
        Me.BTNBUSCAR = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LBLDES = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.LBLPRO = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.LBLEX = New System.Windows.Forms.Label
        Me.LBLUN = New System.Windows.Forms.Label
        Me.CBPRO = New System.Windows.Forms.ComboBox
        Me.CBGRU = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TXTDES = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CBUN = New System.Windows.Forms.ComboBox
        Me.TXTCAN = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTLOT = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BTNBUS = New System.Windows.Forms.Button
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        Me.BTNP1 = New System.Windows.Forms.PictureBox
        Me.PBIMG = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.BTNP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.Transparent
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.ForeColor = System.Drawing.Color.Black
        Me.BTNBUSCAR.Location = New System.Drawing.Point(510, 144)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(44, 49)
        Me.BTNBUSCAR.TabIndex = 1228
        Me.BTNBUSCAR.Text = "..."
        Me.BTNBUSCAR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LBLDES)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LBLPRO)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.LBLEX)
        Me.GroupBox1.Controls.Add(Me.LBLUN)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 213)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(672, 107)
        Me.GroupBox1.TabIndex = 1227
        Me.GroupBox1.TabStop = False
        '
        'LBLDES
        '
        Me.LBLDES.AutoSize = True
        Me.LBLDES.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDES.ForeColor = System.Drawing.Color.Blue
        Me.LBLDES.Location = New System.Drawing.Point(161, 48)
        Me.LBLDES.Name = "LBLDES"
        Me.LBLDES.Size = New System.Drawing.Size(103, 20)
        Me.LBLDES.TabIndex = 1164
        Me.LBLDES.Text = "Descripcion"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 20)
        Me.Label5.TabIndex = 1161
        Me.Label5.Text = "Producto"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 20)
        Me.Label7.TabIndex = 1162
        Me.Label7.Text = "Descripcion"
        '
        'LBLPRO
        '
        Me.LBLPRO.AutoSize = True
        Me.LBLPRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPRO.ForeColor = System.Drawing.Color.Blue
        Me.LBLPRO.Location = New System.Drawing.Point(161, 16)
        Me.LBLPRO.Name = "LBLPRO"
        Me.LBLPRO.Size = New System.Drawing.Size(81, 20)
        Me.LBLPRO.TabIndex = 1163
        Me.LBLPRO.Text = "Producto"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 20)
        Me.Label8.TabIndex = 1166
        Me.Label8.Text = " Existencia"
        '
        'LBLEX
        '
        Me.LBLEX.AutoSize = True
        Me.LBLEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEX.ForeColor = System.Drawing.Color.Blue
        Me.LBLEX.Location = New System.Drawing.Point(161, 78)
        Me.LBLEX.Name = "LBLEX"
        Me.LBLEX.Size = New System.Drawing.Size(19, 20)
        Me.LBLEX.TabIndex = 1168
        Me.LBLEX.Text = "0"
        '
        'LBLUN
        '
        Me.LBLUN.AutoSize = True
        Me.LBLUN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUN.ForeColor = System.Drawing.Color.Blue
        Me.LBLUN.Location = New System.Drawing.Point(250, 78)
        Me.LBLUN.Name = "LBLUN"
        Me.LBLUN.Size = New System.Drawing.Size(14, 20)
        Me.LBLUN.TabIndex = 1167
        Me.LBLUN.Text = "."
        '
        'CBPRO
        '
        Me.CBPRO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPRO.FormattingEnabled = True
        Me.CBPRO.Location = New System.Drawing.Point(105, 74)
        Me.CBPRO.Name = "CBPRO"
        Me.CBPRO.Size = New System.Drawing.Size(446, 28)
        Me.CBPRO.TabIndex = 1226
        '
        'CBGRU
        '
        Me.CBGRU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBGRU.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGRU.FormattingEnabled = True
        Me.CBGRU.Location = New System.Drawing.Point(105, 30)
        Me.CBGRU.Name = "CBGRU"
        Me.CBGRU.Size = New System.Drawing.Size(243, 28)
        Me.CBGRU.TabIndex = 1225
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 20)
        Me.Label10.TabIndex = 1224
        Me.Label10.Text = "Producto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(38, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 20)
        Me.Label9.TabIndex = 1223
        Me.Label9.Text = "Grupo"
        '
        'TXTDES
        '
        Me.TXTDES.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDES.Location = New System.Drawing.Point(22, 422)
        Me.TXTDES.Multiline = True
        Me.TXTDES.Name = "TXTDES"
        Me.TXTDES.Size = New System.Drawing.Size(674, 68)
        Me.TXTDES.TabIndex = 1216
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 395)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(170, 20)
        Me.Label6.TabIndex = 1222
        Me.Label6.Text = "Concepto de Merma"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(402, 351)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 20)
        Me.Label4.TabIndex = 1221
        Me.Label4.Text = "Unidad"
        '
        'CBUN
        '
        Me.CBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBUN.FormattingEnabled = True
        Me.CBUN.Location = New System.Drawing.Point(480, 343)
        Me.CBUN.Name = "CBUN"
        Me.CBUN.Size = New System.Drawing.Size(198, 28)
        Me.CBUN.TabIndex = 1214
        '
        'TXTCAN
        '
        Me.TXTCAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCAN.Location = New System.Drawing.Point(136, 345)
        Me.TXTCAN.Name = "TXTCAN"
        Me.TXTCAN.Size = New System.Drawing.Size(198, 26)
        Me.TXTCAN.TabIndex = 1215
        Me.TXTCAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(49, 351)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 20)
        Me.Label3.TabIndex = 1220
        Me.Label3.Text = "Cantidad"
        '
        'TXTLOT
        '
        Me.TXTLOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOT.Location = New System.Drawing.Point(207, 153)
        Me.TXTLOT.Name = "TXTLOT"
        Me.TXTLOT.Size = New System.Drawing.Size(272, 26)
        Me.TXTLOT.TabIndex = 1213
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(146, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 20)
        Me.Label1.TabIndex = 1218
        Me.Label1.Text = "Lote"
        '
        'BTNBUS
        '
        Me.BTNBUS.BackColor = System.Drawing.Color.White
        Me.BTNBUS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUS.ForeColor = System.Drawing.Color.Black
        Me.BTNBUS.Image = CType(resources.GetObject("BTNBUS.Image"), System.Drawing.Image)
        Me.BTNBUS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNBUS.Location = New System.Drawing.Point(567, 9)
        Me.BTNBUS.Name = "BTNBUS"
        Me.BTNBUS.Size = New System.Drawing.Size(127, 35)
        Me.BTNBUS.TabIndex = 1229
        Me.BTNBUS.Text = "        F10 Buscar"
        Me.BTNBUS.UseVisualStyleBackColor = False
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(429, 504)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 1219
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.White
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(229, 504)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 1217
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'BTNP1
        '
        Me.BTNP1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BTNP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BTNP1.ErrorImage = CType(resources.GetObject("BTNP1.ErrorImage"), System.Drawing.Image)
        Me.BTNP1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BTNP1.Location = New System.Drawing.Point(584, 57)
        Me.BTNP1.Name = "BTNP1"
        Me.BTNP1.Size = New System.Drawing.Size(112, 150)
        Me.BTNP1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BTNP1.TabIndex = 1230
        Me.BTNP1.TabStop = False
        Me.BTNP1.Tag = "1"
        '
        'PBIMG
        '
        Me.PBIMG.BackColor = System.Drawing.Color.White
        Me.PBIMG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PBIMG.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PBIMG.Location = New System.Drawing.Point(463, 15)
        Me.PBIMG.Name = "PBIMG"
        Me.PBIMG.Size = New System.Drawing.Size(36, 29)
        Me.PBIMG.TabIndex = 1231
        Me.PBIMG.TabStop = False
        Me.PBIMG.Tag = "4"
        Me.PBIMG.Visible = False
        '
        'frmMermasTiendasPiso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 596)
        Me.Controls.Add(Me.PBIMG)
        Me.Controls.Add(Me.BTNP1)
        Me.Controls.Add(Me.BTNBUS)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CBPRO)
        Me.Controls.Add(Me.CBGRU)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.TXTDES)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CBUN)
        Me.Controls.Add(Me.TXTCAN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXTLOT)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMermasTiendasPiso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mermas "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BTNP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LBLDES As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LBLPRO As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LBLEX As System.Windows.Forms.Label
    Friend WithEvents LBLUN As System.Windows.Forms.Label
    Friend WithEvents CBPRO As System.Windows.Forms.ComboBox
    Friend WithEvents CBGRU As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents TXTDES As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CBUN As System.Windows.Forms.ComboBox
    Friend WithEvents TXTCAN As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTLOT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNBUS As System.Windows.Forms.Button
    Friend WithEvents BTNP1 As System.Windows.Forms.PictureBox
    Friend WithEvents PBIMG As System.Windows.Forms.PictureBox
End Class
