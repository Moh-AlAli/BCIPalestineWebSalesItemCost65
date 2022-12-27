'Imports AccpacCOMAPI

Public Class SalesItem
    ' Public compid As String = ""
    'Private acsignon As New AccpacSignonManager.AccpacSignonMgr
    'Public mSession As New AccpacCOMAPI.AccpacSession
    Public frmcust As String
    Public Tocust As String
    Public fdate As String
    Public tdate As String
    'Private rdoc As New AccpacReport
    'Public xdbcom As AccpacDBLink

    Private Sub SalesItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'mSession.Init("", "XX", "XX0001", "65A")
            'acsignon.Signon(mSession)
            'compid = mSession.CompanyID
            'xdbcom = mSession.GetDBLink(tagDBLinkTypeEnum.DBLINK_COMPANY, tagDBLinkFlagsEnum.DBLINK_FLG_READONLY)
            'If compid = "" Then
            '    Close()
            'End If
            Txttocus.Text = "zzzzzzzzzzzzzzzzzzzzzz"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Close()
        End Try
    End Sub
    

    Private Sub bffind_Click(sender As Object, e As EventArgs) Handles bffind.Click
        FromCust.Show()
        bffind.Enabled = False
    End Sub

    Private Sub btfind_Click(sender As Object, e As EventArgs) Handles btfind.Click
        Dim f As Form = New ToCust
        f.Show()
        btfind.Enabled = False
    End Sub
    Private Sub Bfdcat_Click(sender As Object, e As EventArgs) Handles Bfdcat.Click
        Bfdcat.Enabled = False
        FromCat.Show()
    End Sub

    Private Sub Btdcat_Click(sender As Object, e As EventArgs) Handles Btdcat.Click
        Btdcat.Enabled = False
        ToCat.Show()
    End Sub

    Private Sub Bfdit_Click(sender As Object, e As EventArgs) Handles Bfdit.Click
        Bfdit.Enabled = False
        FromItem.Show()
    End Sub

    Private Sub Btdit_Click(sender As Object, e As EventArgs) Handles Btdit.Click
        Btdit.Enabled = True
        ToItem.Show()
    End Sub

    Private Sub Bfdloc_Click(sender As Object, e As EventArgs) Handles Bfdloc.Click
        fromware.Show()
        Bfdloc.Enabled = False
    End Sub

    Private Sub Btloc_Click(sender As Object, e As EventArgs) Handles Btdloc.Click
        toware.Show()
        Btdloc.Enabled = False
    End Sub

  

    Private Sub Butprint_Click(sender As Object, e As EventArgs) Handles Butprint.Click
        Try
            Dim fmonthnew As String = 0
            If DateTimePicker1.Value.Month.ToString.Length < 2 Then
                fmonthnew = "0" & DateTimePicker1.Value.Month
            Else
                fmonthnew = DateTimePicker1.Value.Month
            End If
            Dim tmonthnew As String = 0
            If DateTimePicker2.Value.Month.ToString.Length < 2 Then
                tmonthnew = "0" & DateTimePicker2.Value.Month
            Else
                tmonthnew = DateTimePicker2.Value.Month
            End If

            Dim fdaynew As String = 0
            If DateTimePicker1.Value.Day.ToString.Length < 2 Then
                fdaynew = "0" & DateTimePicker1.Value.Day
            Else
                fdaynew = DateTimePicker1.Value.Day
            End If
            Dim tdaynew As String = 0
            If DateTimePicker2.Value.Day.ToString.Length < 2 Then
                tdaynew = "0" & DateTimePicker2.Value.Day
            Else
                tdaynew = DateTimePicker2.Value.Day
            End If

            Dim fdate As String = DateTimePicker1.Value.Year & fmonthnew & fdaynew

            Dim tdate As String = DateTimePicker2.Value.Year & tmonthnew & tdaynew


            If Trim(txtfrmcus.Text) <= Trim(Txttocus.Text) Then
                If Trim(Txtfrmloc.Text) <= Trim(Txttoloc.Text) Then
                    If Trim(Txtfrmcat.Text) <= Trim(Txttocat.Text) Then
                        If Trim(Txtfrmitem.Text) <= Trim(Txttoitem.Text) Then
                            If fdate <= tdate Then
                                crviewer.Show()
                            Else
                                MessageBox.Show("From Date  greater than To Date ")
                            End If
                        Else
                            MessageBox.Show("From Item  greater than To Item ")
                        End If
                    Else
                        MessageBox.Show("From Catgory  greater than To Category ")
                    End If
                Else
                    MessageBox.Show("From Location  greater than To Location ")
                End If
            Else
                MessageBox.Show("From Customer  greater than To Customer ")
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Butexit_Click(sender As Object, e As EventArgs) Handles Butexit.Click
        Close()
    End Sub
End Class
