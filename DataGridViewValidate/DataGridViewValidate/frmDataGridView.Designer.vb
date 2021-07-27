<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataGridView
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
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.btnAddRow = New System.Windows.Forms.Button()
        Me.btnRemoveRow = New System.Windows.Forms.Button()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvData
        '
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(0, 0)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(861, 436)
        Me.dgvData.TabIndex = 0
        '
        'btnAddRow
        '
        Me.btnAddRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddRow.BackColor = System.Drawing.Color.YellowGreen
        Me.btnAddRow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddRow.FlatAppearance.BorderSize = 0
        Me.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddRow.Location = New System.Drawing.Point(679, 447)
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Size = New System.Drawing.Size(87, 28)
        Me.btnAddRow.TabIndex = 1
        Me.btnAddRow.Text = "เพิ่มแถว F3"
        Me.btnAddRow.UseVisualStyleBackColor = False
        '
        'btnRemoveRow
        '
        Me.btnRemoveRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveRow.BackColor = System.Drawing.Color.Red
        Me.btnRemoveRow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveRow.FlatAppearance.BorderSize = 0
        Me.btnRemoveRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveRow.Location = New System.Drawing.Point(771, 447)
        Me.btnRemoveRow.Name = "btnRemoveRow"
        Me.btnRemoveRow.Size = New System.Drawing.Size(87, 28)
        Me.btnRemoveRow.TabIndex = 2
        Me.btnRemoveRow.Text = "ลบแถว F5"
        Me.btnRemoveRow.UseVisualStyleBackColor = False
        '
        'frmDataGridView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 483)
        Me.Controls.Add(Me.btnRemoveRow)
        Me.Controls.Add(Me.btnAddRow)
        Me.Controls.Add(Me.dgvData)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(877, 522)
        Me.Name = "frmDataGridView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DataGridView Validate Cell - coDe bY: Thongkorn Tubtimkrob"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddRow As System.Windows.Forms.Button
    Friend WithEvents btnRemoveRow As System.Windows.Forms.Button

End Class
