<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PapkaFoto = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.Pusk = New System.Windows.Forms.Button()
        Me.ViborPraisZubr = New System.Windows.Forms.Button()
        Me.MaskedTextBox2 = New System.Windows.Forms.MaskedTextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 257)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(607, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "123456789012345678901234567890123456789012345678901234567890123456789012345678901" &
    "2345678901234567890"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Label2"
        '
        'PapkaFoto
        '
        Me.PapkaFoto.AutoSize = True
        Me.PapkaFoto.Location = New System.Drawing.Point(12, 13)
        Me.PapkaFoto.Name = "PapkaFoto"
        Me.PapkaFoto.Size = New System.Drawing.Size(195, 23)
        Me.PapkaFoto.TabIndex = 2
        Me.PapkaFoto.Text = "Выбрать папку с сырыми фотками"
        Me.PapkaFoto.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TextBox1.Location = New System.Drawing.Point(213, 111)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(403, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.WordWrap = False
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaskedTextBox1.Location = New System.Drawing.Point(213, 12)
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.ReadOnly = True
        Me.MaskedTextBox1.Size = New System.Drawing.Size(403, 20)
        Me.MaskedTextBox1.TabIndex = 4
        '
        'Pusk
        '
        Me.Pusk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Pusk.Location = New System.Drawing.Point(15, 202)
        Me.Pusk.Name = "Pusk"
        Me.Pusk.Size = New System.Drawing.Size(75, 23)
        Me.Pusk.TabIndex = 5
        Me.Pusk.Text = "Пуск"
        Me.Pusk.UseVisualStyleBackColor = True
        '
        'ViborPraisZubr
        '
        Me.ViborPraisZubr.AutoSize = True
        Me.ViborPraisZubr.Location = New System.Drawing.Point(12, 42)
        Me.ViborPraisZubr.Name = "ViborPraisZubr"
        Me.ViborPraisZubr.Size = New System.Drawing.Size(175, 23)
        Me.ViborPraisZubr.TabIndex = 6
        Me.ViborPraisZubr.Text = "Выбрать Excel файл с прайсом"
        Me.ViborPraisZubr.UseVisualStyleBackColor = True
        '
        'MaskedTextBox2
        '
        Me.MaskedTextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaskedTextBox2.Location = New System.Drawing.Point(213, 45)
        Me.MaskedTextBox2.Name = "MaskedTextBox2"
        Me.MaskedTextBox2.ReadOnly = True
        Me.MaskedTextBox2.Size = New System.Drawing.Size(403, 20)
        Me.MaskedTextBox2.TabIndex = 7
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 231)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(604, 23)
        Me.ProgressBar1.TabIndex = 8
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "export.xls"
        Me.OpenFileDialog1.InitialDirectory = "D:\диск Д\000 прайсы\зубр стаер крафтол"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 279)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.MaskedTextBox2)
        Me.Controls.Add(Me.ViborPraisZubr)
        Me.Controls.Add(Me.Pusk)
        Me.Controls.Add(Me.MaskedTextBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PapkaFoto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ЗСК зубр стаер крафтол"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PapkaFoto As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MaskedTextBox1 As MaskedTextBox
    Friend WithEvents Pusk As Button
    Friend WithEvents ViborPraisZubr As Button
    Friend WithEvents MaskedTextBox2 As MaskedTextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
