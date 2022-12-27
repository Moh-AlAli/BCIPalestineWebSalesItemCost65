Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Security.Cryptography
Imports CrystalDecisions.Windows.Forms
Imports System.Text
Imports System.IO
Public Class crviewer
    Private rdoc As New ReportDocument
    Private conrpt As New ConnectionInfo()
    Private server As String = ""
    Private uid As String = ""
    Private pass As String = ""
    Private odbc As String = ""

    Friend Function createdes(ByVal key As String) As TripleDES
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        Dim des As TripleDES = New TripleDESCryptoServiceProvider()
        des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key))
        des.IV = New Byte(des.BlockSize \ 8 - 1) {}
        Return des
    End Function
    Friend Function Decryption(ByVal cyphertext As String, ByVal key As String) As String
        Dim b As Byte() = Convert.FromBase64String(cyphertext)
        Dim des As TripleDES = createdes(key)
        Dim ct As ICryptoTransform = des.CreateDecryptor()
        Dim output As Byte() = ct.TransformFinalBlock(b, 0, b.Length)
        Return Encoding.Unicode.GetString(output)
    End Function
    Friend Function Readconnectionstring() As String

        Dim secretkey As String = "Fhghqwjehqwlegtoit123mnk12%&4#"
        Dim path As String = ("txtcon\bcicon.txt")
        Dim sr As New StreamReader(path)

        server = sr.ReadLine()
        Dim db As String = sr.ReadLine()
        uid = sr.ReadLine()
        pass = sr.ReadLine()
        odbc = sr.ReadLine()

        server = Decryption(server, secretkey)
        uid = Decryption(uid, secretkey)
        pass = Decryption(pass, secretkey)
        odbc = Decryption(odbc, secretkey)

        Dim cons As String = "" ' = "Data Source =" & server & "; DataBase =" & Agescreen.compid & "; User Id =" & uid & "; Password =" & pass & ";"

        Return cons
    End Function
    Private Sub crviewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim cwvr As New CrystalReportViewer
            cwvr.Dock = DockStyle.Fill
            cwvr.BorderStyle = BorderStyle.None
            Me.Controls.Add(cwvr)

            rdoc.Load("reports\OESalesItemsCost.rpt")

            Dim tabs As Tables = rdoc.Database.Tables
            Dim parv As New ParameterValues
            Dim dis As New ParameterDiscreteValue

            Dim fmonthnew As String = 0
            If SalesItem.fromdatepick.Value.Month.ToString.Length < 2 Then
                fmonthnew = "0" & SalesItem.fromdatepick.Value.Month
            Else
                fmonthnew = SalesItem.fromdatepick.Value.Month
            End If
            Dim tmonthnew As String = 0
            If SalesItem.todatepick.Value.Month.ToString.Length < 2 Then
                tmonthnew = "0" & SalesItem.todatepick.Value.Month
            Else
                tmonthnew = SalesItem.todatepick.Value.Month
            End If

            Dim fdaynew As String = 0
            If SalesItem.fromdatepick.Value.Day.ToString.Length < 2 Then
                fdaynew = "0" & SalesItem.fromdatepick.Value.Day
            Else
                fdaynew = SalesItem.fromdatepick.Value.Day
            End If

            Dim tdaynew As String = 0

            If SalesItem.todatepick.Value.Day.ToString.Length < 2 Then
                tdaynew = "0" & SalesItem.todatepick.Value.Day
            Else
                tdaynew = SalesItem.todatepick.Value.Day
            End If

            Dim fdate As String = SalesItem.fromdatepick.Value.Year & fmonthnew & fdaynew

            Dim tdate As String = SalesItem.todatepick.Value.Year & tmonthnew & tdaynew


            Readconnectionstring()

            For Each TAB As CrystalDecisions.CrystalReports.Engine.Table In tabs

                Dim tablog As TableLogOnInfo = TAB.LogOnInfo
                conrpt.ServerName = Odbc '"ACCPAC62" 
                conrpt.DatabaseName = OPCompany.compid
                conrpt.UserID = uid '"sa" 
                conrpt.Password = pass ' "admin@123"
                tablog.ConnectionInfo = conrpt
                TAB.ApplyLogOnInfo(tablog)


            Next



            rdoc.SetParameterValue("FromDate", fdate)
            rdoc.SetParameterValue("ToDate", tdate)
            rdoc.SetParameterValue("FromLoc", SalesItem.Txtfrmloc.Text)
            rdoc.SetParameterValue("ToLoc", SalesItem.Txttoloc.Text)
            rdoc.SetParameterValue("FromCustomer", SalesItem.txtfrmcus.Text)
            rdoc.SetParameterValue("ToCustomer", SalesItem.Txttocus.Text)
            rdoc.SetParameterValue("FromItem", SalesItem.Txtfrmitem.Text)
            rdoc.SetParameterValue("ToItem", SalesItem.Txttoitem.Text)
            rdoc.SetParameterValue("FromCategory", SalesItem.Txtfrmcat.Text)
            rdoc.SetParameterValue("ToCategory", SalesItem.Txttocat.Text)
            rdoc.SetParameterValue("DB", OPCompany.compid)
            rdoc.SetParameterValue("Coname", OPCompany.compname)
            cwvr.ReportSource = rdoc

        Catch ex As Exception

        End Try

    End Sub
End Class