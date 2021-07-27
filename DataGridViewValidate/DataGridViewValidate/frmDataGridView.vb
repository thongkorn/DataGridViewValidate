#Region "ABOUT"
' / --------------------------------------------------------------------
' / Developer : Mr.Surapon Yodsanga (Thongkorn Tubtimkrob)
' / eMail : thongkorn@hotmail.com
' / URL: http://www.g2gnet.com (Khon Kaen - Thailand)
' / Facebook: https://www.facebook.com/g2gnet (For Thailand)
' / Facebook: https://www.facebook.com/commonindy (Worldwide)
' / More Info: http://www.g2gsoft.com/
' /
' / Purpose: DataGridView Validate Cell & Create Control Dynamic.
' / Microsoft Visual Basic .NET (2010)
' /
' / This is open source code under @Copyleft by Thongkorn Tubtimkrob.
' / You can modify and/or distribute without to inform the developer.
' / --------------------------------------------------------------------
#End Region

Public Class frmDataGridView

    '// Declare object of the DateTimePicker.
    Dim oDTP As New DateTimePicker

    Private Sub frmDataGridView_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        GC.SuppressFinalize(Me)
        Application.Exit()
    End Sub

    Private Sub frmDataGridView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Call AddRow()
            Case Keys.F5
                Call RemoveRow()
        End Select
    End Sub

    Private Sub frmDataGridView_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '// Keydown on Form.
        Me.KeyPreview = True
        Call InitializeGrid()
        Call AddRow()
    End Sub

    ' / --------------------------------------------------------------------------------
    ' / Initialized settings for DataGridView @Run Time.
    ' / --------------------------------------------------------------------------------
    Private Sub InitializeGrid()
        With dgvData
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
            '// Need to modify each cell.
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .ReadOnly = False
            .Font = New Font("Tahoma", 10)
            ' Automatically set the width.
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
        '// 
        '// Declare columns type.
        Dim colPrimary As New DataGridViewTextBoxColumn()   '// Index 0
        Dim colString As New DataGridViewTextBoxColumn()   '// Index 1
        Dim colInteger As New DataGridViewTextBoxColumn()   '// Index 2
        Dim colDouble As New DataGridViewTextBoxColumn()   '// Index 3
        Dim colDate As New DataGridViewTextBoxColumn()   '// Index 4
        '// Add new Columns
        dgvData.Columns.AddRange(New DataGridViewColumn() { _
                colPrimary, colString, colInteger, colDouble, colDate _
                })
        With dgvData
            .Columns(0).Name = "PK"
            .Columns(1).Name = "Name"
            .Columns(2).Name = "Integer"
            .Columns(3).Name = "Double"
            .Columns(4).Name = "Date"
        End With
        '// ปรับการแสดงผลตัวเลขไว้ทางด้านขวา
        For i = 2 To 3
            dgvData.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next
        '// Declare CheckBox - Index = 5
        Dim chkBox As New DataGridViewCheckBoxColumn
        With dgvData
            .Columns.Add(chkBox)
            chkBox.HeaderText = "CheckBox"
            chkBox.Name = "chkBox"
            .Columns("chkBox").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("chkBox").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '// Add 7th column (Index = 6), It's Button.
        Dim btnAddRow As New DataGridViewButtonColumn()
        dgvData.Columns.Add(btnAddRow)
        With btnAddRow
            .HeaderText = ""
            .Text = "Add"
            .Name = "btnAddRow"
            .UseColumnTextForButtonValue = True
            .Width = 80
        End With
        '// Add 8th column (Index = 7), It's Button.
        Dim btnRemoveRow As New DataGridViewButtonColumn()
        dgvData.Columns.Add(btnRemoveRow)
        With btnRemoveRow
            .HeaderText = ""
            .Text = "Delete"
            .Name = "btnRemoveRow"
            .UseColumnTextForButtonValue = True
            .Width = 80
        End With
        '// ตั้งค่า ColumnHeadersHeightSizeMode ก่อนที่จะทำการปรับความสูงของแถวได้
        dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvData.ColumnHeadersHeight = 36
        '// กำหนดให้ EnableHeadersVisualStyles = False เพื่อให้ยอมรับการเปลี่ยนแปลงสีพื้นหลัง
        dgvData.EnableHeadersVisualStyles = False
        ' ตัวอย่างการปรับ Header Style
        With dgvData.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.Black
            .Font = New Font("Tahoma", 9, FontStyle.Bold)
        End With
        For iCol As Integer = 0 To dgvData.Columns.Count - 1
            '// คำนวณหาเลขคู่กับเลขคี่ หากเลขจำนวนเต็มใดๆหารเอาเศษ (Mod) ด้วย 2 แล้วได้คำตอบ 1 คือเลขคี่
            If iCol Mod 2 = 1 Then
                dgvData.Columns(iCol).HeaderCell.Style.BackColor = Color.DarkOrange
                '// หารเอาเศษด้วย 2 ได้ 0 คือเลขคู่
            Else
                dgvData.Columns(iCol).HeaderCell.Style.BackColor = Color.DeepSkyBlue
            End If
        Next
    End Sub

    '// ข้อมูลตัวอย่างในการ Add Row
    Private Sub AddRow()
        '// SAMPLE DATA
        Dim RandomClass As New Random()
        '// DateTime.Today.AddDays(-RandomClass.Next(365)) --> Random past date 365 days.
        Dim PK As Integer
        If dgvData.Rows.Count = 0 Then
            PK = 1
        Else
            PK = dgvData.Rows(dgvData.RowCount - 1).Cells(0).Value + 1
        End If
        '// PK, Name, Integer, Double, Date
        Dim row As String() = New String() { _
            PK, _
            "Product " & PK, _
            RandomClass.Next(1, 99999), _
            FormatNumber(RandomClass.Next(100, 1000) + RandomClass.NextDouble(), 2), _
            DateTime.Today.AddDays(-RandomClass.Next(365)) _
        }
        dgvData.Rows.Add(row)
    End Sub

    Private Sub dgvData_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellClick
        Select Case e.ColumnIndex
            Case 4
                '//Adding DateTimePicker control into DataGridView   
                dgvData.Controls.Add(oDTP)

                '// Setting the format (i.e. 02/07/2017 - dd/mm/yyyy)
                oDTP.Format = DateTimePickerFormat.Short

                '// It returns the retangular area that represents the Display area for a cell  
                Dim oRectangle = dgvData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)

                '//Setting area for DateTimePicker Control  
                oDTP.Size = New Size(oRectangle.Width, oRectangle.Height)

                '// Setting Location
                oDTP.Location = New Point(oRectangle.X, oRectangle.Y)
                '// Read value from DataGridView into DateTimePicker
                oDTP.Value = dgvData.CurrentCell.Value
                '// Now make it visible  
                oDTP.Visible = True
                '// Force to change date value at oDTP_ValueChanged Event.
                AddHandler oDTP.ValueChanged, AddressOf oDTP_ValueChanged

                '// เพิ่มแถว
            Case 6
                Call AddRow()
                '// ลบแถว
            Case 7
                Call RemoveRow()
        End Select
    End Sub

    ' / --------------------------------------------------------------------------------
    Private Sub dgvData_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvData.EditingControlShowing
        Select Case dgvData.Columns(dgvData.CurrentCell.ColumnIndex).Index
            '// ColumeIndex 0, 2 is Integer and ColumnIndex 3 is double.
            Case 0, 2, 3
                '// Force to validate value at ValidKeyPress Event.
                RemoveHandler e.Control.KeyPress, AddressOf ValidKeyPress
                AddHandler e.Control.KeyPress, AddressOf ValidKeyPress
        End Select
    End Sub

    ' / --------------------------------------------------------------------------------
    Private Sub ValidKeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim tb As TextBox = sender
        Select Case dgvData.CurrentCell.ColumnIndex
            Case 0, 2  '// Integer
                Select Case e.KeyChar
                    Case "0" To "9"   ' digits 0 - 9 allowed
                    Case ChrW(Keys.Back)    ' backspace allowed for deleting (Delete key automatically overrides)
                    Case Else ' everything else ....
                        '// True = CPU cancel the KeyPress event
                        e.Handled = True '// and it's just like you never pressed a key at all
                End Select

            Case 3  '// Double
                Select Case e.KeyChar
                    Case "0" To "9"
                        '// Allowed "."
                    Case "."
                        '// But it can present "." only one.
                        If InStr(tb.Text, ".") Then e.Handled = True

                    Case ChrW(Keys.Back)
                    Case Else
                        e.Handled = True

                End Select
        End Select
    End Sub

    Private Sub RemoveRow()
        If dgvData.RowCount = 0 Then Exit Sub
        dgvData.Rows.Remove(dgvData.CurrentRow)
    End Sub

    ' / --------------------------------------------------------------------------------
    '// Event Handler when the change value in DateTimePicker.
    Private Sub oDTP_ValueChanged(sender As Object, e As System.EventArgs)
        '// Display date value and copy the value into current cell.
        dgvData.CurrentCell.Value = Format(oDTP.Value, "dd/MM/yyyy")
    End Sub

    Private Sub dgvData_CellLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellLeave
        '// Hidden DateTimePicker when lost focus the cell.
        oDTP.Visible = False
    End Sub

    Private Sub Form1_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        oDTP.Visible = False
    End Sub
    ' / --------------------------------------------------------------------------------

    Private Sub btnAddRow_Click(sender As System.Object, e As System.EventArgs) Handles btnAddRow.Click
        Call AddRow()
    End Sub

    Private Sub btnRemoveRow_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveRow.Click
        Call RemoveRow()
    End Sub
End Class
