<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class sJeu
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
        Me.bJ_quitter = New System.Windows.Forms.Button()
        Me.lblJ_cpt = New System.Windows.Forms.Label()
        Me.bJ_sol = New System.Windows.Forms.Button()
        Me.bJ_gen = New System.Windows.Forms.Button()
        Me.bJ_vider = New System.Windows.Forms.Button()
        Me.bJ_aide = New System.Windows.Forms.Button()
        Me.bJ_aleat = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'bJ_quitter
        '
        Me.bJ_quitter.Location = New System.Drawing.Point(12, 447)
        Me.bJ_quitter.Name = "bJ_quitter"
        Me.bJ_quitter.Size = New System.Drawing.Size(76, 70)
        Me.bJ_quitter.TabIndex = 0
        Me.bJ_quitter.Text = "Quitter"
        Me.bJ_quitter.UseVisualStyleBackColor = True
        '
        'lblJ_cpt
        '
        Me.lblJ_cpt.AutoSize = True
        Me.lblJ_cpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJ_cpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJ_cpt.Location = New System.Drawing.Point(228, 9)
        Me.lblJ_cpt.Name = "lblJ_cpt"
        Me.lblJ_cpt.Size = New System.Drawing.Size(68, 50)
        Me.lblJ_cpt.TabIndex = 1
        Me.lblJ_cpt.Text = "60"
        '
        'bJ_sol
        '
        Me.bJ_sol.Location = New System.Drawing.Point(117, 467)
        Me.bJ_sol.Name = "bJ_sol"
        Me.bJ_sol.Size = New System.Drawing.Size(112, 31)
        Me.bJ_sol.TabIndex = 2
        Me.bJ_sol.Text = "Solution"
        Me.bJ_sol.UseVisualStyleBackColor = True
        '
        'bJ_gen
        '
        Me.bJ_gen.Location = New System.Drawing.Point(235, 467)
        Me.bJ_gen.Name = "bJ_gen"
        Me.bJ_gen.Size = New System.Drawing.Size(112, 31)
        Me.bJ_gen.TabIndex = 3
        Me.bJ_gen.Text = "Generer"
        Me.bJ_gen.UseVisualStyleBackColor = True
        '
        'bJ_vider
        '
        Me.bJ_vider.Location = New System.Drawing.Point(353, 467)
        Me.bJ_vider.Name = "bJ_vider"
        Me.bJ_vider.Size = New System.Drawing.Size(112, 31)
        Me.bJ_vider.TabIndex = 4
        Me.bJ_vider.Text = "Vider"
        Me.bJ_vider.UseVisualStyleBackColor = True
        '
        'bJ_aide
        '
        Me.bJ_aide.Location = New System.Drawing.Point(235, 504)
        Me.bJ_aide.Name = "bJ_aide"
        Me.bJ_aide.Size = New System.Drawing.Size(112, 31)
        Me.bJ_aide.TabIndex = 5
        Me.bJ_aide.Text = "Aide"
        Me.bJ_aide.UseVisualStyleBackColor = True
        '
        'bJ_aleat
        '
        Me.bJ_aleat.Location = New System.Drawing.Point(353, 504)
        Me.bJ_aleat.Name = "bJ_aleat"
        Me.bJ_aleat.Size = New System.Drawing.Size(112, 31)
        Me.bJ_aleat.TabIndex = 6
        Me.bJ_aleat.Text = "Aide aleatoire"
        Me.bJ_aleat.UseVisualStyleBackColor = True
        '
        'sJeu
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(496, 565)
        Me.ControlBox = False
        Me.Controls.Add(Me.bJ_aleat)
        Me.Controls.Add(Me.bJ_aide)
        Me.Controls.Add(Me.bJ_vider)
        Me.Controls.Add(Me.bJ_gen)
        Me.Controls.Add(Me.bJ_sol)
        Me.Controls.Add(Me.lblJ_cpt)
        Me.Controls.Add(Me.bJ_quitter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "sJeu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Jeu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bJ_quitter As Button
    Friend WithEvents lblJ_cpt As Label
    Friend WithEvents bJ_sol As Button
    Friend WithEvents bJ_gen As Button
    Friend WithEvents bJ_vider As Button
    Friend WithEvents bJ_aide As Button
    Friend WithEvents bJ_aleat As Button
End Class
