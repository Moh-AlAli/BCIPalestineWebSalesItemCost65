<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OPCompany
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
        Me.butopencomp = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBcompname = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'butopencomp
        '
        Me.butopencomp.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butopencomp.Location = New System.Drawing.Point(287, 98)
        Me.butopencomp.Name = "butopencomp"
        Me.butopencomp.Size = New System.Drawing.Size(89, 36)
        Me.butopencomp.TabIndex = 7
        Me.butopencomp.Text = "OK"
        Me.butopencomp.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Unicode MS", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(5, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Company Name"
        '
        'CBcompname
        '
        Me.CBcompname.FormattingEnabled = True
        Me.CBcompname.Location = New System.Drawing.Point(106, 53)
        Me.CBcompname.Name = "CBcompname"
        Me.CBcompname.Size = New System.Drawing.Size(506, 21)
        Me.CBcompname.TabIndex = 5
        '
        'OPCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 186)
        Me.Controls.Add(Me.butopencomp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBcompname)
        Me.Name = "OPCompany"
        Me.Text = "OPCompany"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butopencomp As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBcompname As System.Windows.Forms.ComboBox
End Class
