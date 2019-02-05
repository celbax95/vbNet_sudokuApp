<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sMenu))
        Me.bM_close = New System.Windows.Forms.Button()
        Me.lblM_best = New System.Windows.Forms.Label()
        Me.cbM_player = New System.Windows.Forms.ComboBox()
        Me.bM_jouer = New System.Windows.Forms.Button()
        Me.bM_scores = New System.Windows.Forms.Button()
        Me.bM_ajouter = New System.Windows.Forms.Button()
        Me.bM_suppr = New System.Windows.Forms.Button()
        Me.pM_player = New System.Windows.Forms.Panel()
        Me.pM_player.SuspendLayout()
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
        Me.bM_close.Location = New System.Drawing.Point(879, 12)
        Me.bM_close.Name = "bM_close"
        Me.bM_close.Size = New System.Drawing.Size(64, 64)
        Me.bM_close.TabIndex = 0
        Me.bM_close.UseVisualStyleBackColor = False
        '
        'lblM_best
        '
        Me.lblM_best.AutoSize = True
        Me.lblM_best.BackColor = System.Drawing.Color.Transparent
        Me.lblM_best.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblM_best.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblM_best.ForeColor = System.Drawing.Color.White
        Me.lblM_best.Location = New System.Drawing.Point(23, 138)
        Me.lblM_best.Name = "lblM_best"
        Me.lblM_best.Size = New System.Drawing.Size(130, 31)
        Me.lblM_best.TabIndex = 1
        Me.lblM_best.Text = "lblM_best"
        Me.lblM_best.Visible = False
        '
        'cbM_player
        '
        Me.cbM_player.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbM_player.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbM_player.BackColor = System.Drawing.Color.DarkGray
        Me.cbM_player.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbM_player.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbM_player.FormattingEnabled = True
        Me.cbM_player.Location = New System.Drawing.Point(0, 0)
        Me.cbM_player.MaxDropDownItems = 5
        Me.cbM_player.Name = "cbM_player"
        Me.cbM_player.Size = New System.Drawing.Size(229, 62)
        Me.cbM_player.TabIndex = 0
        '
        'bM_jouer
        '
        Me.bM_jouer.Location = New System.Drawing.Point(679, 409)
        Me.bM_jouer.Name = "bM_jouer"
        Me.bM_jouer.Size = New System.Drawing.Size(218, 74)
        Me.bM_jouer.TabIndex = 3
        Me.bM_jouer.Text = "Jouer"
        Me.bM_jouer.UseVisualStyleBackColor = True
        '
        'bM_scores
        '
        Me.bM_scores.Location = New System.Drawing.Point(12, 442)
        Me.bM_scores.Name = "bM_scores"
        Me.bM_scores.Size = New System.Drawing.Size(75, 75)
        Me.bM_scores.TabIndex = 4
        Me.bM_scores.Text = "Scores"
        Me.bM_scores.UseVisualStyleBackColor = True
        '
        'bM_ajouter
        '
        Me.bM_ajouter.Location = New System.Drawing.Point(679, 408)
        Me.bM_ajouter.Name = "bM_ajouter"
        Me.bM_ajouter.Size = New System.Drawing.Size(218, 75)
        Me.bM_ajouter.TabIndex = 5
        Me.bM_ajouter.Text = " Ajouter le joueur"
        Me.bM_ajouter.UseVisualStyleBackColor = True
        '
        'bM_suppr
        '
        Me.bM_suppr.Location = New System.Drawing.Point(104, 453)
        Me.bM_suppr.Name = "bM_suppr"
        Me.bM_suppr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.bM_suppr.Size = New System.Drawing.Size(120, 53)
        Me.bM_suppr.TabIndex = 6
        Me.bM_suppr.Text = "Supprimer le joueur"
        Me.bM_suppr.UseVisualStyleBackColor = True
        '
        'pM_player
        '
        Me.pM_player.Controls.Add(Me.cbM_player)
        Me.pM_player.Location = New System.Drawing.Point(29, 37)
        Me.pM_player.Name = "pM_player"
        Me.pM_player.Size = New System.Drawing.Size(212, 71)
        Me.pM_player.TabIndex = 7
        '
        'sMenu
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(955, 529)
        Me.ControlBox = False
        Me.Controls.Add(Me.pM_player)
        Me.Controls.Add(Me.bM_suppr)
        Me.Controls.Add(Me.bM_ajouter)
        Me.Controls.Add(Me.bM_scores)
        Me.Controls.Add(Me.bM_jouer)
        Me.Controls.Add(Me.lblM_best)
        Me.Controls.Add(Me.bM_close)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "sMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "s"
        Me.pM_player.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bM_close As Button
    Friend WithEvents lblM_best As Label
    Friend WithEvents cbM_player As ComboBox
    Friend WithEvents bM_jouer As Button
    Friend WithEvents bM_scores As Button
    Friend WithEvents bM_ajouter As Button
    Friend WithEvents bM_suppr As Button
    Friend WithEvents pM_player As Panel
End Class
