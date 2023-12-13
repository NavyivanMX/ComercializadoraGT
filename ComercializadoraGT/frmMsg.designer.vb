<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMsg
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
        Me.LBLPREG = New System.Windows.Forms.Label
        Me.LBLPREG2 = New System.Windows.Forms.Label
        Me.BTNYES = New System.Windows.Forms.Button
        Me.BTNNO = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LBLPREG
        '
        Me.LBLPREG.AutoSize = True
        Me.LBLPREG.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPREG.Location = New System.Drawing.Point(12, 118)
        Me.LBLPREG.Name = "LBLPREG"
        Me.LBLPREG.Size = New System.Drawing.Size(667, 29)
        Me.LBLPREG.TabIndex = 2
        Me.LBLPREG.Text = "ASDFASDFASDASDFASDFASDFASDFSADFASDFFASD"
        Me.LBLPREG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LBLPREG2
        '
        Me.LBLPREG2.AutoSize = True
        Me.LBLPREG2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPREG2.Location = New System.Drawing.Point(12, 166)
        Me.LBLPREG2.Name = "LBLPREG2"
        Me.LBLPREG2.Size = New System.Drawing.Size(884, 29)
        Me.LBLPREG2.TabIndex = 3
        Me.LBLPREG2.Text = "ASDFASDFASDASDFASDFASDFASDFSADFASDFFASDFASDFASFDASDF"
        Me.LBLPREG2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BTNYES
        '
        Me.BTNYES.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.BTNYES.Image = Global.ComercializadoraGT.My.Resources.Resources.button_ok
        Me.BTNYES.Location = New System.Drawing.Point(112, 283)
        Me.BTNYES.Name = "BTNYES"
        Me.BTNYES.Size = New System.Drawing.Size(153, 139)
        Me.BTNYES.TabIndex = 0
        Me.BTNYES.Text = " "
        Me.BTNYES.UseVisualStyleBackColor = True
        '
        'BTNNO
        '
        Me.BTNNO.DialogResult = System.Windows.Forms.DialogResult.No
        Me.BTNNO.Image = Global.ComercializadoraGT.My.Resources.Resources.button_cancel
        Me.BTNNO.Location = New System.Drawing.Point(384, 283)
        Me.BTNNO.Name = "BTNNO"
        Me.BTNNO.Size = New System.Drawing.Size(153, 139)
        Me.BTNNO.TabIndex = 1
        Me.BTNNO.Text = " "
        Me.BTNNO.UseVisualStyleBackColor = True
        '
        'frmMsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 489)
        Me.Controls.Add(Me.LBLPREG2)
        Me.Controls.Add(Me.LBLPREG)
        Me.Controls.Add(Me.BTNNO)
        Me.Controls.Add(Me.BTNYES)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMsg"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMsg"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNYES As System.Windows.Forms.Button
    Friend WithEvents BTNNO As System.Windows.Forms.Button
    Friend WithEvents LBLPREG As System.Windows.Forms.Label
    Friend WithEvents LBLPREG2 As System.Windows.Forms.Label
End Class
