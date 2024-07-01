<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKardexPreciosClientes
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.DTHASTA = New System.Windows.Forms.DateTimePicker
        Me.DTDE = New System.Windows.Forms.DateTimePicker
        Me.Button1 = New System.Windows.Forms.Button
        Me.CHKTC = New System.Windows.Forms.CheckBox
        Me.CHKTP = New System.Windows.Forms.CheckBox
        Me.LBLCLI = New System.Windows.Forms.Label
        Me.LBLPRO = New System.Windows.Forms.Label
        Me.BTNC = New System.Windows.Forms.Button
        Me.BTNP = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(609, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 24)
        Me.Label4.TabIndex = 1119
        Me.Label4.Text = "Hasta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(630, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 24)
        Me.Label3.TabIndex = 1118
        Me.Label3.Text = "De:"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(12, 142)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGV.Size = New System.Drawing.Size(902, 410)
        Me.DGV.TabIndex = 1117
        '
        'DTHASTA
        '
        Me.DTHASTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTHASTA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTHASTA.Location = New System.Drawing.Point(678, 90)
        Me.DTHASTA.Name = "DTHASTA"
        Me.DTHASTA.Size = New System.Drawing.Size(126, 26)
        Me.DTHASTA.TabIndex = 1116
        '
        'DTDE
        '
        Me.DTDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTDE.Location = New System.Drawing.Point(678, 36)
        Me.DTDE.Name = "DTDE"
        Me.DTDE.Size = New System.Drawing.Size(126, 26)
        Me.DTDE.TabIndex = 1115
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.xeyes1
        Me.Button1.Location = New System.Drawing.Point(837, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 80)
        Me.Button1.TabIndex = 1120
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CHKTC
        '
        Me.CHKTC.AutoSize = True
        Me.CHKTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKTC.Location = New System.Drawing.Point(45, 14)
        Me.CHKTC.Name = "CHKTC"
        Me.CHKTC.Size = New System.Drawing.Size(175, 24)
        Me.CHKTC.TabIndex = 1149
        Me.CHKTC.Text = "Todos los Clientes"
        Me.CHKTC.UseVisualStyleBackColor = True
        '
        'CHKTP
        '
        Me.CHKTP.AutoSize = True
        Me.CHKTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKTP.Location = New System.Drawing.Point(334, 12)
        Me.CHKTP.Name = "CHKTP"
        Me.CHKTP.Size = New System.Drawing.Size(191, 24)
        Me.CHKTP.TabIndex = 1150
        Me.CHKTP.Text = "Todos los Productos"
        Me.CHKTP.UseVisualStyleBackColor = True
        '
        'LBLCLI
        '
        Me.LBLCLI.AutoSize = True
        Me.LBLCLI.BackColor = System.Drawing.Color.Transparent
        Me.LBLCLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCLI.Location = New System.Drawing.Point(42, 66)
        Me.LBLCLI.Name = "LBLCLI"
        Me.LBLCLI.Size = New System.Drawing.Size(109, 16)
        Me.LBLCLI.TabIndex = 1151
        Me.LBLCLI.Text = "Cliente: Todos"
        '
        'LBLPRO
        '
        Me.LBLPRO.AutoSize = True
        Me.LBLPRO.BackColor = System.Drawing.Color.Transparent
        Me.LBLPRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPRO.Location = New System.Drawing.Point(42, 95)
        Me.LBLPRO.Name = "LBLPRO"
        Me.LBLPRO.Size = New System.Drawing.Size(123, 16)
        Me.LBLPRO.TabIndex = 1152
        Me.LBLPRO.Text = "Producto: Todos"
        '
        'BTNC
        '
        Me.BTNC.BackColor = System.Drawing.SystemColors.Control
        Me.BTNC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNC.ForeColor = System.Drawing.Color.Black
        Me.BTNC.Location = New System.Drawing.Point(226, 6)
        Me.BTNC.Name = "BTNC"
        Me.BTNC.Size = New System.Drawing.Size(80, 36)
        Me.BTNC.TabIndex = 1153
        Me.BTNC.Text = "..."
        Me.BTNC.UseVisualStyleBackColor = False
        '
        'BTNP
        '
        Me.BTNP.BackColor = System.Drawing.SystemColors.Control
        Me.BTNP.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNP.ForeColor = System.Drawing.Color.Black
        Me.BTNP.Location = New System.Drawing.Point(531, 6)
        Me.BTNP.Name = "BTNP"
        Me.BTNP.Size = New System.Drawing.Size(80, 36)
        Me.BTNP.TabIndex = 1154
        Me.BTNP.Text = "..."
        Me.BTNP.UseVisualStyleBackColor = False
        '
        'frmKardexPreciosClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 568)
        Me.Controls.Add(Me.BTNP)
        Me.Controls.Add(Me.BTNC)
        Me.Controls.Add(Me.LBLPRO)
        Me.Controls.Add(Me.LBLCLI)
        Me.Controls.Add(Me.CHKTP)
        Me.Controls.Add(Me.CHKTC)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.DTHASTA)
        Me.Controls.Add(Me.DTDE)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKardexPreciosClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kardex de Precios de Clientes"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents DTHASTA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTDE As System.Windows.Forms.DateTimePicker
    Friend WithEvents CHKTC As System.Windows.Forms.CheckBox
    Friend WithEvents CHKTP As System.Windows.Forms.CheckBox
    Friend WithEvents LBLCLI As System.Windows.Forms.Label
    Friend WithEvents LBLPRO As System.Windows.Forms.Label
    Friend WithEvents BTNC As System.Windows.Forms.Button
    Friend WithEvents BTNP As System.Windows.Forms.Button
End Class
