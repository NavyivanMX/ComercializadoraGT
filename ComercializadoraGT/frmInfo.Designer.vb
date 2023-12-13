<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfo
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
        Me.LBLTIT = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LBLMSG = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LBLTIT
        '
        Me.LBLTIT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLTIT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTIT.Location = New System.Drawing.Point(24, 30)
        Me.LBLTIT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLTIT.Name = "LBLTIT"
        Me.LBLTIT.Size = New System.Drawing.Size(543, 22)
        Me.LBLTIT.TabIndex = 95
        Me.LBLTIT.Text = "Almacen"
        Me.LBLTIT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.ComercializadoraGT.My.Resources.Resources.btninformacion32
        Me.PictureBox1.Location = New System.Drawing.Point(603, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 96
        Me.PictureBox1.TabStop = False
        '
        'LBLMSG
        '
        Me.LBLMSG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLMSG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LBLMSG.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMSG.Location = New System.Drawing.Point(24, 88)
        Me.LBLMSG.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLMSG.Name = "LBLMSG"
        Me.LBLMSG.Size = New System.Drawing.Size(628, 479)
        Me.LBLMSG.TabIndex = 97
        Me.LBLMSG.Text = "Almacen"
        '
        'frmInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 593)
        Me.Controls.Add(Me.LBLMSG)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LBLTIT)
        Me.Name = "frmInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmInfo"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LBLTIT As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LBLMSG As Label
End Class
