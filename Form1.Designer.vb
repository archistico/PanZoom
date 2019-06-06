<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btTempoStart = New System.Windows.Forms.Button()
        Me.btTempoStop = New System.Windows.Forms.Button()
        Me.chbStato04 = New System.Windows.Forms.CheckBox()
        Me.chbStato06 = New System.Windows.Forms.CheckBox()
        Me.chbStato07 = New System.Windows.Forms.CheckBox()
        Me.chbStato08 = New System.Windows.Forms.CheckBox()
        Me.chbStato09 = New System.Windows.Forms.CheckBox()
        Me.chbStato01 = New System.Windows.Forms.CheckBox()
        Me.chbStato02 = New System.Windows.Forms.CheckBox()
        Me.chbStato03 = New System.Windows.Forms.CheckBox()
        Me.chbStato05 = New System.Windows.Forms.CheckBox()
        Me.chbStato10 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFame = New System.Windows.Forms.Label()
        Me.lblSete = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSalute = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblVita = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pb
        '
        Me.pb.BackColor = System.Drawing.Color.Black
        Me.pb.Location = New System.Drawing.Point(12, 12)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(660, 628)
        Me.pb.TabIndex = 0
        Me.pb.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(679, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tempo"
        '
        'btTempoStart
        '
        Me.btTempoStart.BackColor = System.Drawing.SystemColors.Control
        Me.btTempoStart.Location = New System.Drawing.Point(682, 12)
        Me.btTempoStart.Name = "btTempoStart"
        Me.btTempoStart.Size = New System.Drawing.Size(120, 25)
        Me.btTempoStart.TabIndex = 3
        Me.btTempoStart.Text = "Parti"
        Me.btTempoStart.UseVisualStyleBackColor = False
        '
        'btTempoStop
        '
        Me.btTempoStop.BackColor = System.Drawing.SystemColors.Control
        Me.btTempoStop.Location = New System.Drawing.Point(808, 12)
        Me.btTempoStop.Name = "btTempoStop"
        Me.btTempoStop.Size = New System.Drawing.Size(120, 25)
        Me.btTempoStop.TabIndex = 4
        Me.btTempoStop.Text = "Ferma"
        Me.btTempoStop.UseVisualStyleBackColor = False
        '
        'chbStato04
        '
        Me.chbStato04.AutoSize = True
        Me.chbStato04.Location = New System.Drawing.Point(713, 164)
        Me.chbStato04.Name = "chbStato04"
        Me.chbStato04.Size = New System.Drawing.Size(63, 17)
        Me.chbStato04.TabIndex = 5
        Me.chbStato04.Text = "Stato04"
        Me.chbStato04.UseVisualStyleBackColor = True
        '
        'chbStato06
        '
        Me.chbStato06.AutoSize = True
        Me.chbStato06.Location = New System.Drawing.Point(800, 103)
        Me.chbStato06.Name = "chbStato06"
        Me.chbStato06.Size = New System.Drawing.Size(77, 17)
        Me.chbStato06.TabIndex = 6
        Me.chbStato06.Text = "Cerca cibo"
        Me.chbStato06.UseVisualStyleBackColor = True
        '
        'chbStato07
        '
        Me.chbStato07.AutoSize = True
        Me.chbStato07.Location = New System.Drawing.Point(800, 123)
        Me.chbStato07.Name = "chbStato07"
        Me.chbStato07.Size = New System.Drawing.Size(87, 17)
        Me.chbStato07.TabIndex = 7
        Me.chbStato07.Text = "Cerca acqua"
        Me.chbStato07.UseVisualStyleBackColor = True
        '
        'chbStato08
        '
        Me.chbStato08.AutoSize = True
        Me.chbStato08.Location = New System.Drawing.Point(800, 143)
        Me.chbStato08.Name = "chbStato08"
        Me.chbStato08.Size = New System.Drawing.Size(99, 17)
        Me.chbStato08.TabIndex = 8
        Me.chbStato08.Text = "Ostacolo vicino"
        Me.chbStato08.UseVisualStyleBackColor = True
        '
        'chbStato09
        '
        Me.chbStato09.AutoSize = True
        Me.chbStato09.Location = New System.Drawing.Point(800, 163)
        Me.chbStato09.Name = "chbStato09"
        Me.chbStato09.Size = New System.Drawing.Size(95, 17)
        Me.chbStato09.TabIndex = 9
        Me.chbStato09.Text = "Pericolo vicino"
        Me.chbStato09.UseVisualStyleBackColor = True
        '
        'chbStato01
        '
        Me.chbStato01.AutoSize = True
        Me.chbStato01.Location = New System.Drawing.Point(713, 103)
        Me.chbStato01.Name = "chbStato01"
        Me.chbStato01.Size = New System.Drawing.Size(63, 17)
        Me.chbStato01.TabIndex = 10
        Me.chbStato01.Text = "Stato01"
        Me.chbStato01.UseVisualStyleBackColor = True
        '
        'chbStato02
        '
        Me.chbStato02.AutoSize = True
        Me.chbStato02.Location = New System.Drawing.Point(713, 123)
        Me.chbStato02.Name = "chbStato02"
        Me.chbStato02.Size = New System.Drawing.Size(63, 17)
        Me.chbStato02.TabIndex = 11
        Me.chbStato02.Text = "Stato02"
        Me.chbStato02.UseVisualStyleBackColor = True
        '
        'chbStato03
        '
        Me.chbStato03.AutoSize = True
        Me.chbStato03.Location = New System.Drawing.Point(713, 143)
        Me.chbStato03.Name = "chbStato03"
        Me.chbStato03.Size = New System.Drawing.Size(63, 17)
        Me.chbStato03.TabIndex = 12
        Me.chbStato03.Text = "Stato03"
        Me.chbStato03.UseVisualStyleBackColor = True
        '
        'chbStato05
        '
        Me.chbStato05.AutoSize = True
        Me.chbStato05.Location = New System.Drawing.Point(713, 184)
        Me.chbStato05.Name = "chbStato05"
        Me.chbStato05.Size = New System.Drawing.Size(59, 17)
        Me.chbStato05.TabIndex = 13
        Me.chbStato05.Text = "Blocco"
        Me.chbStato05.UseVisualStyleBackColor = True
        '
        'chbStato10
        '
        Me.chbStato10.AutoSize = True
        Me.chbStato10.Location = New System.Drawing.Point(800, 183)
        Me.chbStato10.Name = "chbStato10"
        Me.chbStato10.Size = New System.Drawing.Size(98, 17)
        Me.chbStato10.TabIndex = 14
        Me.chbStato10.Text = "In elaborazione"
        Me.chbStato10.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(709, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "STATI"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(710, 252)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Fame"
        '
        'lblFame
        '
        Me.lblFame.AutoSize = True
        Me.lblFame.Location = New System.Drawing.Point(756, 252)
        Me.lblFame.Name = "lblFame"
        Me.lblFame.Size = New System.Drawing.Size(13, 13)
        Me.lblFame.TabIndex = 17
        Me.lblFame.Text = "--"
        '
        'lblSete
        '
        Me.lblSete.AutoSize = True
        Me.lblSete.Location = New System.Drawing.Point(756, 276)
        Me.lblSete.Name = "lblSete"
        Me.lblSete.Size = New System.Drawing.Size(13, 13)
        Me.lblSete.TabIndex = 19
        Me.lblSete.Text = "--"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(710, 276)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Sete"
        '
        'lblSalute
        '
        Me.lblSalute.AutoSize = True
        Me.lblSalute.Location = New System.Drawing.Point(756, 300)
        Me.lblSalute.Name = "lblSalute"
        Me.lblSalute.Size = New System.Drawing.Size(13, 13)
        Me.lblSalute.TabIndex = 21
        Me.lblSalute.Text = "--"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(710, 300)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Salute"
        '
        'lblVita
        '
        Me.lblVita.AutoSize = True
        Me.lblVita.Location = New System.Drawing.Point(756, 324)
        Me.lblVita.Name = "lblVita"
        Me.lblVita.Size = New System.Drawing.Size(13, 13)
        Me.lblVita.TabIndex = 23
        Me.lblVita.Text = "--"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(710, 324)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Vita"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 647)
        Me.Controls.Add(Me.lblVita)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblSalute)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblSete)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblFame)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chbStato10)
        Me.Controls.Add(Me.chbStato05)
        Me.Controls.Add(Me.chbStato03)
        Me.Controls.Add(Me.chbStato02)
        Me.Controls.Add(Me.chbStato01)
        Me.Controls.Add(Me.chbStato09)
        Me.Controls.Add(Me.chbStato08)
        Me.Controls.Add(Me.chbStato07)
        Me.Controls.Add(Me.chbStato06)
        Me.Controls.Add(Me.chbStato04)
        Me.Controls.Add(Me.btTempoStop)
        Me.Controls.Add(Me.btTempoStart)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pb)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btTempoStart As System.Windows.Forms.Button
    Friend WithEvents btTempoStop As System.Windows.Forms.Button
    Friend WithEvents chbStato04 As System.Windows.Forms.CheckBox
    Friend WithEvents chbStato06 As System.Windows.Forms.CheckBox
    Friend WithEvents chbStato07 As System.Windows.Forms.CheckBox
    Friend WithEvents chbStato08 As System.Windows.Forms.CheckBox
    Friend WithEvents chbStato09 As System.Windows.Forms.CheckBox
    Friend WithEvents chbStato01 As System.Windows.Forms.CheckBox
    Friend WithEvents chbStato02 As System.Windows.Forms.CheckBox
    Friend WithEvents chbStato03 As System.Windows.Forms.CheckBox
    Friend WithEvents chbStato05 As System.Windows.Forms.CheckBox
    Friend WithEvents chbStato10 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFame As System.Windows.Forms.Label
    Friend WithEvents lblSete As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblSalute As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblVita As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label

End Class
