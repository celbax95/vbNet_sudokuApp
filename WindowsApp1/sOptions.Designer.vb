<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class sOptions
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sOptions))
        Me.pO_aide = New System.Windows.Forms.Panel()
        Me.ckO_defil2 = New System.Windows.Forms.CheckBox()
        Me.ckO_coul5 = New System.Windows.Forms.CheckBox()
        Me.ckO_sol4 = New System.Windows.Forms.CheckBox()
        Me.ckO_sug3 = New System.Windows.Forms.CheckBox()
        Me.ckO_aleat1 = New System.Windows.Forms.CheckBox()
        Me.ckO_ind0 = New System.Windows.Forms.CheckBox()
        Me.lO_aide = New System.Windows.Forms.Label()
        Me.pO_diff = New System.Windows.Forms.Panel()
        Me.rbO_diff1 = New System.Windows.Forms.RadioButton()
        Me.rbO_diff2 = New System.Windows.Forms.RadioButton()
        Me.lO_diff = New System.Windows.Forms.Label()
        Me.rbO_diff0 = New System.Windows.Forms.RadioButton()
        Me.pO_gm = New System.Windows.Forms.Panel()
        Me.rbO_gm2 = New System.Windows.Forms.RadioButton()
        Me.rbO_gm1 = New System.Windows.Forms.RadioButton()
        Me.rbO_gm0 = New System.Windows.Forms.RadioButton()
        Me.lO_mode = New System.Windows.Forms.Label()
        Me.lO_option = New System.Windows.Forms.Label()
        Me.bO_close = New System.Windows.Forms.Button()
        Me.bM_jouer = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.rtbO_infos = New System.Windows.Forms.RichTextBox()
        Me.lO_infos = New System.Windows.Forms.Label()
        Me.pO_infos = New System.Windows.Forms.Panel()
        Me.pO_aide.SuspendLayout()
        Me.pO_diff.SuspendLayout()
        Me.pO_gm.SuspendLayout()
        Me.pO_infos.SuspendLayout()
        Me.SuspendLayout()
        '
        'pO_aide
        '
        Me.pO_aide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pO_aide.Controls.Add(Me.ckO_defil2)
        Me.pO_aide.Controls.Add(Me.ckO_coul5)
        Me.pO_aide.Controls.Add(Me.ckO_sol4)
        Me.pO_aide.Controls.Add(Me.ckO_sug3)
        Me.pO_aide.Controls.Add(Me.ckO_aleat1)
        Me.pO_aide.Controls.Add(Me.ckO_ind0)
        Me.pO_aide.Controls.Add(Me.lO_aide)
        Me.pO_aide.Location = New System.Drawing.Point(48, 290)
        Me.pO_aide.Margin = New System.Windows.Forms.Padding(4)
        Me.pO_aide.Name = "pO_aide"
        Me.pO_aide.Size = New System.Drawing.Size(567, 151)
        Me.pO_aide.TabIndex = 0
        '
        'ckO_defil2
        '
        Me.ckO_defil2.AutoSize = True
        Me.ckO_defil2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckO_defil2.Location = New System.Drawing.Point(27, 104)
        Me.ckO_defil2.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ckO_defil2.Name = "ckO_defil2"
        Me.ckO_defil2.Size = New System.Drawing.Size(233, 24)
        Me.ckO_defil2.TabIndex = 20
        Me.ckO_defil2.Text = "Défilement des possibilités"
        Me.ckO_defil2.UseVisualStyleBackColor = True
        '
        'ckO_coul5
        '
        Me.ckO_coul5.AutoSize = True
        Me.ckO_coul5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckO_coul5.Location = New System.Drawing.Point(332, 32)
        Me.ckO_coul5.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ckO_coul5.Name = "ckO_coul5"
        Me.ckO_coul5.Size = New System.Drawing.Size(171, 24)
        Me.ckO_coul5.TabIndex = 19
        Me.ckO_coul5.Text = "Indications couleur"
        Me.ckO_coul5.UseVisualStyleBackColor = True
        '
        'ckO_sol4
        '
        Me.ckO_sol4.AutoSize = True
        Me.ckO_sol4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckO_sol4.Location = New System.Drawing.Point(332, 68)
        Me.ckO_sol4.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ckO_sol4.Name = "ckO_sol4"
        Me.ckO_sol4.Size = New System.Drawing.Size(132, 24)
        Me.ckO_sol4.TabIndex = 18
        Me.ckO_sol4.Text = "Solution case"
        Me.ckO_sol4.UseVisualStyleBackColor = True
        '
        'ckO_sug3
        '
        Me.ckO_sug3.AutoSize = True
        Me.ckO_sug3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckO_sug3.Location = New System.Drawing.Point(332, 104)
        Me.ckO_sug3.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ckO_sug3.Name = "ckO_sug3"
        Me.ckO_sug3.Size = New System.Drawing.Size(123, 24)
        Me.ckO_sug3.TabIndex = 17
        Me.ckO_sug3.Text = "Suggestions"
        Me.ckO_sug3.UseVisualStyleBackColor = True
        '
        'ckO_aleat1
        '
        Me.ckO_aleat1.AutoSize = True
        Me.ckO_aleat1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckO_aleat1.Location = New System.Drawing.Point(27, 68)
        Me.ckO_aleat1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ckO_aleat1.Name = "ckO_aleat1"
        Me.ckO_aleat1.Size = New System.Drawing.Size(219, 24)
        Me.ckO_aleat1.TabIndex = 15
        Me.ckO_aleat1.Text = "Solution cases aleatoires"
        Me.ckO_aleat1.UseVisualStyleBackColor = True
        '
        'ckO_ind0
        '
        Me.ckO_ind0.AutoSize = True
        Me.ckO_ind0.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckO_ind0.Location = New System.Drawing.Point(27, 32)
        Me.ckO_ind0.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ckO_ind0.Name = "ckO_ind0"
        Me.ckO_ind0.Size = New System.Drawing.Size(84, 24)
        Me.ckO_ind0.TabIndex = 16
        Me.ckO_ind0.Text = "Indices"
        Me.ckO_ind0.UseVisualStyleBackColor = True
        '
        'lO_aide
        '
        Me.lO_aide.AutoSize = True
        Me.lO_aide.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lO_aide.ForeColor = System.Drawing.Color.White
        Me.lO_aide.Location = New System.Drawing.Point(114, 0)
        Me.lO_aide.Margin = New System.Windows.Forms.Padding(4, 0, 4, 6)
        Me.lO_aide.Name = "lO_aide"
        Me.lO_aide.Size = New System.Drawing.Size(46, 20)
        Me.lO_aide.TabIndex = 12
        Me.lO_aide.Text = "Aide"
        '
        'pO_diff
        '
        Me.pO_diff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pO_diff.Controls.Add(Me.rbO_diff1)
        Me.pO_diff.Controls.Add(Me.rbO_diff2)
        Me.pO_diff.Controls.Add(Me.lO_diff)
        Me.pO_diff.Controls.Add(Me.rbO_diff0)
        Me.pO_diff.Location = New System.Drawing.Point(348, 89)
        Me.pO_diff.Margin = New System.Windows.Forms.Padding(4)
        Me.pO_diff.Name = "pO_diff"
        Me.pO_diff.Size = New System.Drawing.Size(267, 160)
        Me.pO_diff.TabIndex = 1
        '
        'rbO_diff1
        '
        Me.rbO_diff1.AutoSize = True
        Me.rbO_diff1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbO_diff1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbO_diff1.Location = New System.Drawing.Point(27, 76)
        Me.rbO_diff1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.rbO_diff1.Name = "rbO_diff1"
        Me.rbO_diff1.Size = New System.Drawing.Size(79, 24)
        Me.rbO_diff1.TabIndex = 6
        Me.rbO_diff1.TabStop = True
        Me.rbO_diff1.Text = "Moyen"
        Me.rbO_diff1.UseVisualStyleBackColor = True
        '
        'rbO_diff2
        '
        Me.rbO_diff2.AutoSize = True
        Me.rbO_diff2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbO_diff2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbO_diff2.Location = New System.Drawing.Point(27, 118)
        Me.rbO_diff2.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.rbO_diff2.Name = "rbO_diff2"
        Me.rbO_diff2.Size = New System.Drawing.Size(87, 24)
        Me.rbO_diff2.TabIndex = 1
        Me.rbO_diff2.TabStop = True
        Me.rbO_diff2.Text = "Difficile"
        Me.rbO_diff2.UseVisualStyleBackColor = True
        '
        'lO_diff
        '
        Me.lO_diff.AutoSize = True
        Me.lO_diff.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lO_diff.ForeColor = System.Drawing.Color.White
        Me.lO_diff.Location = New System.Drawing.Point(28, 0)
        Me.lO_diff.Margin = New System.Windows.Forms.Padding(4, 0, 4, 6)
        Me.lO_diff.Name = "lO_diff"
        Me.lO_diff.Size = New System.Drawing.Size(96, 20)
        Me.lO_diff.TabIndex = 10
        Me.lO_diff.Text = "Difficultée"
        '
        'rbO_diff0
        '
        Me.rbO_diff0.AutoSize = True
        Me.rbO_diff0.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbO_diff0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbO_diff0.Location = New System.Drawing.Point(27, 37)
        Me.rbO_diff0.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.rbO_diff0.Name = "rbO_diff0"
        Me.rbO_diff0.Size = New System.Drawing.Size(75, 24)
        Me.rbO_diff0.TabIndex = 8
        Me.rbO_diff0.TabStop = True
        Me.rbO_diff0.Text = "Facile"
        Me.rbO_diff0.UseVisualStyleBackColor = True
        '
        'pO_gm
        '
        Me.pO_gm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pO_gm.Controls.Add(Me.rbO_gm2)
        Me.pO_gm.Controls.Add(Me.rbO_gm1)
        Me.pO_gm.Controls.Add(Me.rbO_gm0)
        Me.pO_gm.Controls.Add(Me.lO_mode)
        Me.pO_gm.Location = New System.Drawing.Point(48, 89)
        Me.pO_gm.Margin = New System.Windows.Forms.Padding(4)
        Me.pO_gm.Name = "pO_gm"
        Me.pO_gm.Size = New System.Drawing.Size(267, 160)
        Me.pO_gm.TabIndex = 2
        '
        'rbO_gm2
        '
        Me.rbO_gm2.AutoSize = True
        Me.rbO_gm2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbO_gm2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbO_gm2.Location = New System.Drawing.Point(27, 116)
        Me.rbO_gm2.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.rbO_gm2.Name = "rbO_gm2"
        Me.rbO_gm2.Size = New System.Drawing.Size(72, 24)
        Me.rbO_gm2.TabIndex = 4
        Me.rbO_gm2.TabStop = True
        Me.rbO_gm2.Text = "Block"
        Me.rbO_gm2.UseVisualStyleBackColor = True
        '
        'rbO_gm1
        '
        Me.rbO_gm1.AutoSize = True
        Me.rbO_gm1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbO_gm1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbO_gm1.Location = New System.Drawing.Point(27, 76)
        Me.rbO_gm1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.rbO_gm1.Name = "rbO_gm1"
        Me.rbO_gm1.Size = New System.Drawing.Size(155, 24)
        Me.rbO_gm1.TabIndex = 3
        Me.rbO_gm1.TabStop = True
        Me.rbO_gm1.Text = "Contre la montre"
        Me.rbO_gm1.UseVisualStyleBackColor = True
        '
        'rbO_gm0
        '
        Me.rbO_gm0.AutoSize = True
        Me.rbO_gm0.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbO_gm0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbO_gm0.Location = New System.Drawing.Point(27, 37)
        Me.rbO_gm0.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.rbO_gm0.Name = "rbO_gm0"
        Me.rbO_gm0.Size = New System.Drawing.Size(97, 24)
        Me.rbO_gm0.TabIndex = 2
        Me.rbO_gm0.TabStop = True
        Me.rbO_gm0.Text = "Standard"
        Me.rbO_gm0.UseVisualStyleBackColor = True
        '
        'lO_mode
        '
        Me.lO_mode.AutoSize = True
        Me.lO_mode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lO_mode.ForeColor = System.Drawing.Color.White
        Me.lO_mode.Location = New System.Drawing.Point(28, 0)
        Me.lO_mode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 6)
        Me.lO_mode.Name = "lO_mode"
        Me.lO_mode.Size = New System.Drawing.Size(111, 20)
        Me.lO_mode.TabIndex = 11
        Me.lO_mode.Text = "Mode de jeu"
        '
        'lO_option
        '
        Me.lO_option.AutoSize = True
        Me.lO_option.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lO_option.ForeColor = System.Drawing.Color.White
        Me.lO_option.Location = New System.Drawing.Point(16, 11)
        Me.lO_option.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lO_option.Name = "lO_option"
        Me.lO_option.Size = New System.Drawing.Size(141, 39)
        Me.lO_option.TabIndex = 0
        Me.lO_option.Text = "Options"
        '
        'bO_close
        '
        Me.bO_close.BackColor = System.Drawing.Color.Transparent
        Me.bO_close.FlatAppearance.BorderSize = 0
        Me.bO_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.bO_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.bO_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bO_close.ForeColor = System.Drawing.Color.Transparent
        Me.bO_close.Image = CType(resources.GetObject("bO_close.Image"), System.Drawing.Image)
        Me.bO_close.Location = New System.Drawing.Point(937, 13)
        Me.bO_close.Margin = New System.Windows.Forms.Padding(4)
        Me.bO_close.Name = "bO_close"
        Me.bO_close.Size = New System.Drawing.Size(60, 60)
        Me.bO_close.TabIndex = 13
        Me.bO_close.UseVisualStyleBackColor = False
        '
        'bM_jouer
        '
        Me.bM_jouer.Location = New System.Drawing.Point(651, 325)
        Me.bM_jouer.Margin = New System.Windows.Forms.Padding(4)
        Me.bM_jouer.Name = "bM_jouer"
        Me.bM_jouer.Size = New System.Drawing.Size(258, 91)
        Me.bM_jouer.TabIndex = 14
        Me.bM_jouer.Text = "Jouer"
        Me.bM_jouer.UseVisualStyleBackColor = True
        '
        'rtbO_infos
        '
        Me.rtbO_infos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbO_infos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.rtbO_infos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbO_infos.Location = New System.Drawing.Point(7, 3)
        Me.rtbO_infos.Name = "rtbO_infos"
        Me.rtbO_infos.ReadOnly = True
        Me.rtbO_infos.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbO_infos.ShortcutsEnabled = False
        Me.rtbO_infos.Size = New System.Drawing.Size(200, 145)
        Me.rtbO_infos.TabIndex = 14
        Me.rtbO_infos.Text = ""
        Me.rtbO_infos.Visible = False
        '
        'lO_infos
        '
        Me.lO_infos.AutoSize = True
        Me.lO_infos.BackColor = System.Drawing.SystemColors.Control
        Me.lO_infos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lO_infos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lO_infos.ForeColor = System.Drawing.Color.ForestGreen
        Me.lO_infos.Location = New System.Drawing.Point(1, 1)
        Me.lO_infos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 6)
        Me.lO_infos.Name = "lO_infos"
        Me.lO_infos.Size = New System.Drawing.Size(52, 22)
        Me.lO_infos.TabIndex = 12
        Me.lO_infos.Text = "Infos"
        '
        'pO_infos
        '
        Me.pO_infos.BackColor = System.Drawing.SystemColors.Control
        Me.pO_infos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pO_infos.Controls.Add(Me.lO_infos)
        Me.pO_infos.Controls.Add(Me.rtbO_infos)
        Me.pO_infos.Location = New System.Drawing.Point(666, 89)
        Me.pO_infos.Name = "pO_infos"
        Me.pO_infos.Size = New System.Drawing.Size(215, 153)
        Me.pO_infos.TabIndex = 15
        Me.pO_infos.Visible = False
        '
        'sOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(1010, 485)
        Me.ControlBox = False
        Me.Controls.Add(Me.bM_jouer)
        Me.Controls.Add(Me.bO_close)
        Me.Controls.Add(Me.pO_gm)
        Me.Controls.Add(Me.pO_diff)
        Me.Controls.Add(Me.pO_aide)
        Me.Controls.Add(Me.lO_option)
        Me.Controls.Add(Me.pO_infos)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "sOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Options"
        Me.pO_aide.ResumeLayout(False)
        Me.pO_aide.PerformLayout()
        Me.pO_diff.ResumeLayout(False)
        Me.pO_diff.PerformLayout()
        Me.pO_gm.ResumeLayout(False)
        Me.pO_gm.PerformLayout()
        Me.pO_infos.ResumeLayout(False)
        Me.pO_infos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pO_aide As Panel
    Friend WithEvents pO_diff As Panel
    Friend WithEvents pO_gm As Panel
    Friend WithEvents lO_aide As Label
    Friend WithEvents lO_mode As Label
    Friend WithEvents lO_diff As Label
    Friend WithEvents rbO_diff0 As RadioButton
    Friend WithEvents rbO_diff1 As RadioButton
    Friend WithEvents rbO_gm2 As RadioButton
    Friend WithEvents rbO_gm1 As RadioButton
    Friend WithEvents rbO_gm0 As RadioButton
    Friend WithEvents rbO_diff2 As RadioButton
    Friend WithEvents lO_option As Label
    Friend WithEvents bO_close As Button
    Friend WithEvents bM_jouer As Button
    Friend WithEvents ckO_aleat1 As CheckBox
    Friend WithEvents ckO_ind0 As CheckBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ckO_sug3 As CheckBox
    Friend WithEvents ckO_defil2 As CheckBox
    Friend WithEvents ckO_coul5 As CheckBox
    Friend WithEvents ckO_sol4 As CheckBox
    Friend WithEvents rtbO_infos As RichTextBox
    Friend WithEvents lO_infos As Label
    Friend WithEvents pO_infos As Panel
End Class
