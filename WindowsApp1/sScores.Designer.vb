<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sScores
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sScores))
        Me.bM_close = New System.Windows.Forms.Button()
        Me.pS_tab = New System.Windows.Forms.Panel()
        Me.tbS_pseu = New System.Windows.Forms.TextBox()
        Me.tbS_aides = New System.Windows.Forms.TextBox()
        Me.tbS_diff = New System.Windows.Forms.TextBox()
        Me.tbS_gm = New System.Windows.Forms.TextBox()
        Me.tbS_sc = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'bM_close
        '
        Me.bM_close.BackColor = System.Drawing.Color.Transparent
        Me.bM_close.FlatAppearance.BorderSize = 0
        Me.bM_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.bM_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.bM_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bM_close.ForeColor = System.Drawing.Color.Transparent
        Me.bM_close.Image = CType(resources.GetObject("bM_close.Image"), System.Drawing.Image)
        Me.bM_close.Location = New System.Drawing.Point(831, 13)
        Me.bM_close.Margin = New System.Windows.Forms.Padding(4)
        Me.bM_close.Name = "bM_close"
        Me.bM_close.Size = New System.Drawing.Size(85, 79)
        Me.bM_close.TabIndex = 1
        Me.bM_close.UseVisualStyleBackColor = False
        '
        'pS_tab
        '
        Me.pS_tab.AutoScroll = True
        Me.pS_tab.Location = New System.Drawing.Point(79, 100)
        Me.pS_tab.Margin = New System.Windows.Forms.Padding(0)
        Me.pS_tab.Name = "pS_tab"
        Me.pS_tab.Size = New System.Drawing.Size(676, 476)
        Me.pS_tab.TabIndex = 3
        '
        'tbS_pseu
        '
        Me.tbS_pseu.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbS_pseu.Location = New System.Drawing.Point(79, 66)
        Me.tbS_pseu.Margin = New System.Windows.Forms.Padding(3, 3, 3, 8)
        Me.tbS_pseu.Name = "tbS_pseu"
        Me.tbS_pseu.Size = New System.Drawing.Size(125, 26)
        Me.tbS_pseu.TabIndex = 4
        Me.tbS_pseu.Text = "Pseudo"
        Me.tbS_pseu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbS_aides
        '
        Me.tbS_aides.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbS_aides.Location = New System.Drawing.Point(601, 66)
        Me.tbS_aides.Margin = New System.Windows.Forms.Padding(3, 3, 3, 8)
        Me.tbS_aides.Name = "tbS_aides"
        Me.tbS_aides.Size = New System.Drawing.Size(125, 26)
        Me.tbS_aides.TabIndex = 5
        Me.tbS_aides.Text = "Aides"
        Me.tbS_aides.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbS_diff
        '
        Me.tbS_diff.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbS_diff.Location = New System.Drawing.Point(340, 66)
        Me.tbS_diff.Margin = New System.Windows.Forms.Padding(3, 3, 3, 8)
        Me.tbS_diff.Name = "tbS_diff"
        Me.tbS_diff.Size = New System.Drawing.Size(125, 26)
        Me.tbS_diff.TabIndex = 6
        Me.tbS_diff.Text = "Difficulté"
        Me.tbS_diff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbS_gm
        '
        Me.tbS_gm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbS_gm.Location = New System.Drawing.Point(209, 66)
        Me.tbS_gm.Margin = New System.Windows.Forms.Padding(3, 3, 3, 8)
        Me.tbS_gm.Name = "tbS_gm"
        Me.tbS_gm.Size = New System.Drawing.Size(125, 26)
        Me.tbS_gm.TabIndex = 7
        Me.tbS_gm.Text = "Mode de jeu"
        Me.tbS_gm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbS_sc
        '
        Me.tbS_sc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbS_sc.Location = New System.Drawing.Point(471, 66)
        Me.tbS_sc.Margin = New System.Windows.Forms.Padding(3, 3, 3, 8)
        Me.tbS_sc.Name = "tbS_sc"
        Me.tbS_sc.Size = New System.Drawing.Size(125, 26)
        Me.tbS_sc.TabIndex = 8
        Me.tbS_sc.Text = "Score"
        Me.tbS_sc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sScores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(929, 600)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbS_sc)
        Me.Controls.Add(Me.tbS_gm)
        Me.Controls.Add(Me.tbS_diff)
        Me.Controls.Add(Me.tbS_aides)
        Me.Controls.Add(Me.tbS_pseu)
        Me.Controls.Add(Me.pS_tab)
        Me.Controls.Add(Me.bM_close)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "sScores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "sScores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bM_close As Button
    Friend WithEvents pS_tab As Panel
    Friend WithEvents tbS_pseu As TextBox
    Friend WithEvents tbS_aides As TextBox
    Friend WithEvents tbS_diff As TextBox
    Friend WithEvents tbS_gm As TextBox
    Friend WithEvents tbS_sc As TextBox
End Class
