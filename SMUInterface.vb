' MARS is an interface for the Agilent B2900A Precision SMU 
' that can be used to make repeated measurements of a device over an 
' arbitrary period of time at regular intervals.

' Copyright (C) 2012  Oliver Hamlet

' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.

' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.

' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Public Class SMUInterface

    Dim rm As Ivi.Visa.Interop.ResourceManager
    Dim ioObj As Ivi.Visa.Interop.FormattedIO488

    Public devAddress As String = "USB0::0x0957::0x8C18::my51140134::0::INSTR"
    Public label As String = "measurement"
    Public TransGateStart As Double = 0
    Public TransGateStop As Double = 0
    Public TransGateCount As Integer = 0
    Public TransDrainStart As Double = 0
    Public TransDrainStop As Double = 0
    Public TransDrainCount As Integer = 0
    Public OutGateStart As Double = 0
    Public OutGateStop As Double = 0
    Public OutGateCount As Integer = 0
    Public OutDrainStart As Double = 0
    Public OutDrainStop As Double = 0
    Public OutDrainCount As Integer = 0
    Public Compliance As Double = 0.01
    Public Delay As Double = 0.0005
    Public Aperture As Double = 0.0001
    Public MeasurementSetNum As Integer = 1
    Public RepeatInterval As Integer = 0
    Public rootPath As String = "C:\"
    Public GateBias As Double = 0
    Public DrainBias As Double = 0

    Public Sub RunRepeatedMeasurements(ByVal worker As System.ComponentModel.BackgroundWorker, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Try
            rm = New Ivi.Visa.Interop.ResourceManager
            ioObj = New Ivi.Visa.Interop.FormattedIO488
            Try
                ioObj.IO = rm.Open(devAddress)
                ioObj.IO.Timeout = 60000
                ioObj.IO.TerminationCharacter = 10
                ioObj.IO.TerminationCharacterEnabled = True
            Catch ex As Exception
                MsgBox("An error occurred: " & ex.Message, vbOKOnly + vbCritical, "Error")
                Return
            End Try

            For i As Integer = 1 To MeasurementSetNum
                ' Check if the run has been cancelled.
                If worker.CancellationPending Then
                    e.Cancel = True
                    Exit For
                End If
                worker.ReportProgress(0, i)

                Dim path As String = rootPath
                If MeasurementSetNum > 1 Then
                    ' Create new folder for these measurements.
                    path = rootPath & "\Set " & i
                    System.IO.Directory.CreateDirectory(path)
                End If
                Dim transfer As String = ""
                Dim output As String = ""
                Dim dummy As String = ""

                ' Do the measurements, with dummy measurements beforehand.
                DoMeasurement(True, dummy)
                DoMeasurement(True, transfer)
                DoMeasurement(False, dummy)
                DoMeasurement(False, output)

                ' Write data out.
                FileOpen(1, path & "\" & "transfer-" & label & ".csv", OpenMode.Output, OpenAccess.Write, OpenShare.LockReadWrite)
                Print(1, transfer)
                FileClose(1)
                FileOpen(1, path & "\" & "output-" & label & ".csv", OpenMode.Output, OpenAccess.Write, OpenShare.LockReadWrite)
                Print(1, output)
                FileClose(1)

                If MeasurementSetNum > 1 And RepeatInterval > 0 And i < MeasurementSetNum Then
                    ' Apply stress bias voltage.
                    ApplyBiasVoltage()

                    'Now wait for interval to elapse.
                    Threading.Thread.Sleep(RepeatInterval * 1000)
                End If
            Next

            ioObj.IO.Close()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(ioObj)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(rm)
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, vbOKOnly + vbCritical, "Error")
        End Try
    End Sub

    Private Sub DoMeasurement(ByVal isTransfer As Boolean, ByRef results As String)
        ' Set up variables.
        ' Primary channel is gate, secondary channel is drain.
        ' Transfer has primary sweep, secondary list.
        ' Output has primary list, secondary sweep.

        Dim SweepChannel As String
        Dim ListChannel As String

        Dim SweepStart As Double
        Dim SweepStop As Double
        Dim SweepCount As Integer

        Dim ListStart As Double
        Dim ListStop As Double
        Dim ListCount As Integer

        If isTransfer Then
            SweepChannel = "1"
            ListChannel = "2"

            SweepStart = TransGateStart
            SweepStop = TransGateStop
            SweepCount = TransGateCount

            ListStart = TransDrainStart
            ListStop = TransDrainStop
            ListCount = TransDrainCount
        Else
            SweepChannel = "2"
            ListChannel = "1"

            SweepStart = OutDrainStart
            SweepStop = OutDrainStop
            SweepCount = OutDrainCount

            ListStart = OutGateStart
            ListStop = OutGateStop
            ListCount = OutGateCount
        End If

        ' Set the total number of counts to take place.
        Dim FullCount As Integer = SweepCount * ListCount

        ' Set direction of primary sweep.
        Dim Direction As String
        If SweepStart < SweepStop Then
            Direction = "UP"
        Else
            Direction = "DOWN"
        End If

        ' Need to create a list for the secondary sweep.
        Dim List As String = ""
        Dim ListStep As Double = (ListStop - ListStart) / (ListCount - 1)
        For i As Integer = 0 To ListCount - 1
            For j As Integer = 0 To SweepCount - 1
                If ListStart < ListStop Then
                    List = List & (ListStart + ListStep * i) & ","
                Else
                    List = List & (ListStart - ListStep * i) & ","
                End If
            Next
        Next
        ' Get rid of trailing comma.
        List = List.Remove(List.Length - 1)

        ioObj.WriteString("*RST") ' Reset

        Try

            'Set primary sweep to a linear double voltage sweep.
            ioObj.WriteString(":sour" & SweepChannel & ":func:mode volt")
            ioObj.WriteString(":sour" & SweepChannel & ":volt:mode swe")
            ioObj.WriteString(":sour" & SweepChannel & ":swe:dir " & Direction)
            ioObj.WriteString(":sour" & SweepChannel & ":swe:sta doub")
            ioObj.WriteString(":sour" & SweepChannel & ":swe:spac lin")
            ioObj.WriteString(":sour" & SweepChannel & ":volt:star " & SweepStart)
            ioObj.WriteString(":sour" & SweepChannel & ":volt:stop " & SweepStop)
            ioObj.WriteString(":sour" & SweepChannel & ":volt:poin " & SweepCount)

            ' Set secondary sweep to a linear single voltage sweep, implemented 
            ' as a list so the primary sweep occurs at every step.
            ioObj.WriteString(":sour" & ListChannel & ":func:mode volt")
            ioObj.WriteString(":sour" & ListChannel & ":volt:mode list")
            ioObj.WriteString(":sour" & ListChannel & ":list:volt " & List)

            ' Set auto-range current measurement
            ioObj.WriteString(":sens1:func ""curr"", ""volt""")
            ioObj.WriteString(":sens1:curr:aper " & Aperture)
            ioObj.WriteString(":sens1:curr:prot " & Compliance)
            ioObj.WriteString(":sens2:func ""curr"", ""volt""")
            ioObj.WriteString(":sens2:curr:aper " & Aperture)
            ioObj.WriteString(":sens2:curr:prot " & Compliance)

            ' Generate triggers by automatic internal algorithm
            ioObj.WriteString(":trig1:sour aint")
            ioObj.WriteString(":trig1:coun " & FullCount)
            ioObj.WriteString(":trig2:sour aint")
            ioObj.WriteString(":trig2:coun " & FullCount)

            ' Set up measurement delay.
            ioObj.WriteString(":sens1:wait on")
            ioObj.WriteString(":sens1:wait:auto off")
            ioObj.WriteString(":sens1:wait offs " & Delay)
            ioObj.WriteString(":sens2:wait on")
            ioObj.WriteString(":sens2:wait:auto off")
            ioObj.WriteString(":sens2:wait offs " & Delay)

            ' Set array contents
            ioObj.WriteString(":form:elem:sens volt,curr,time")

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, vbOKOnly + vbCritical, "Error")
        End Try

        ' Turn on output switch
        ioObj.WriteString(":outp1 on")
        ioObj.WriteString(":outp2 on")

        ' Initiate transition and acquire?
        ioObj.WriteString(":init (@1,2)")

        Try ' Retrieve measurement result.
            ioObj.WriteString(":fetc:arr? (@1,2)")
            results = ioObj.ReadString()

            ' Now need to break up long results string into a multi-line CSV format.
            ToCSV(results)
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, vbOKOnly + vbCritical, "Error")
        End Try
    End Sub

    Private Sub ToCSV(ByRef s As String)
        ' Now need to break up long CSV string. Each resulting line should contain 8 values.
        Dim count As Integer = 0
        Dim line As Integer = 1
        Dim pos As Integer = s.IndexOf(",")
        Dim absGateC As Double = 0
        Dim absDrainC As Double = 0
        While pos > -1
            If count = 5 Then
                ' Set count back to zero and replace this comma with a newline.
                count = 0
                line += 1
                s = s.Remove(pos, 1)
                Dim temp As String = "," & absGateC & "," & absDrainC & vbCrLf & line & ","
                s = s.Insert(pos, temp)
                pos = s.IndexOf(",", pos + temp.Length)
            Else
                If count = 0 Then
                    ' Need to record the value between the next comma and this one, it is the gate current.
                    Dim pos2 As Integer = s.IndexOf(",", pos + 1)
                    If pos2 > -1 Then
                        absGateC = Math.Abs(Double.Parse(s.Substring(pos + 1, pos2 - pos - 1)))
                    Else
                        Exit While
                    End If
                ElseIf count = 3 Then
                    ' Need to record the value between the next comma and this one, it is the drain current.
                    Dim pos2 As Integer = s.IndexOf(",", pos + 1)
                    If pos2 > -1 Then
                        absDrainC = Math.Abs(Double.Parse(s.Substring(pos + 1, pos2 - pos - 1)))
                    Else
                        Exit While
                    End If
                End If
                count += 1
                pos = s.IndexOf(",", pos + 1)
            End If
        End While

        ' There's a CRLF at the end of the string, need to remove it and stick on the two last absolute values, and the column headings.
        s = s.Remove(s.Length - 1)
        s = "Point,Gate Voltage,Gate Current,Gate Time,Drain Voltage,Drain Current,Drain Time,Abs Gate Current,Abs Drain Current" & vbCrLf & "1," & s & "," & absGateC & "," & absDrainC

    End Sub

    Private Sub ApplyBiasVoltage()
        If Not GateBias = 0 Or Not DrainBias = 0 Then
            ioObj.WriteString("*RST") ' Reset

            Try
                ' Set bias up.
                ' Primary channel is gate, secondary channel is drain.
                ioObj.WriteString(":sour1:func:mode volt")
                ioObj.WriteString(":sour1:volt " & GateBias)
                ioObj.WriteString(":sour2:func:mode volt")
                ioObj.WriteString(":sour2:volt " & DrainBias)
                ioObj.WriteString(":sens1:curr:prot " & Compliance)
                ioObj.WriteString(":sens2:curr:prot " & Compliance)

                ' Turn on output switch
                ioObj.WriteString(":outp1 on")
                ioObj.WriteString(":outp2 on")

            Catch ex As Exception
                MsgBox("An error occurred: " & ex.Message, vbOKOnly + vbCritical, "Error")
            End Try
        End If
    End Sub

End Class
