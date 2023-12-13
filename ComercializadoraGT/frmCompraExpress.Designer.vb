<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompraExpress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompraExpress))
        Me.TXTCANT = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LBLNPRO = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTNGUARDAR = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TXTCANT
        '
        Me.TXTCANT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT.Location = New System.Drawing.Point(307, 242)
        Me.TXTCANT.Margin = New System.Windows.Forms.Padding(4)
        Me.TXTCANT.MaxLength = 8
        Me.TXTCANT.Name = "TXTCANT"
        Me.TXTCANT.Size = New System.Drawing.Size(132, 26)
        Me.TXTCANT.TabIndex = 1
        Me.TXTCANT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(332, 218)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 20)
        Me.Label7.TabIndex = 1084
        Me.Label7.Text = "Cantidad"
        '
        'LBLNPRO
        '
        Me.LBLNPRO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLNPRO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNPRO.Location = New System.Drawing.Point(12, 60)
        Me.LBLNPRO.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLNPRO.Name = "LBLNPRO"
        Me.LBLNPRO.Size = New System.Drawing.Size(723, 118)
        Me.LBLNPRO.TabIndex = 0
        Me.LBLNPRO.Text = "Producto"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 33)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 22)
        Me.Label1.TabIndex = 1137
        Me.Label1.Text = "Producto"
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.Color.White
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Black
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNGUARDAR.Location = New System.Drawing.Point(294, 317)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(169, 102)
        Me.BTNGUARDAR.TabIndex = 2
        Me.BTNGUARDAR.Text = "      F12 Guardar"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'frmCompraExpress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 455)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LBLNPRO)
        Me.Controls.Add(Me.TXTCANT)
        Me.Controls.Add(Me.Label7)
        Me.Name = "frmCompraExpress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compra Express"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TXTCANT As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents LBLNPRO As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BTNGUARDAR As Button
End Class
