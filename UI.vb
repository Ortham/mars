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

Public Class UI

    Dim isRunning As Boolean = False

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim response As Integer = MsgBox("Are you sure you want to quit?", vbQuestion + vbYesNo, "Quit")
        If response = vbYes Then
            If isRunning Then
                Worker.CancelAsync()
            End If
            End
        End If
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        ' This runs on the main thread. We want to start a background thread here.
        If isRunning Then
            Dim response As Integer = MsgBox("Measurements are already running. Do you want to cancel the current measurements?", vbQuestion + vbYesNo, "Run")
            If response = vbYes Then
                Worker.CancelAsync()
                'Wait for Background worker to finish.
                stsStatusBar.Text = "Cancelling current run..."
                While Worker.IsBusy()
                    Windows.Forms.Application.DoEvents()
                End While
            End If
        End If
        lblStatus.Text = "Running..."
        isRunning = True

        Dim AI As New SMUInterface
        ' Now set AI vars from control value buffers.
        Try
            AI.devAddress = txtDevAddress.Text
            AI.label = txtLabel.Text
            AI.TransGateStart = Double.Parse(txtTGateStart.Text)
            AI.TransGateStop = Double.Parse(txtTGateStop.Text)
            AI.TransGateCount = Integer.Parse(txtTGateCount.Text)
            AI.TransDrainStart = Double.Parse(txtTDrainStart.Text)
            AI.TransDrainStop = Double.Parse(txtTDrainStop.Text)
            AI.TransDrainCount = Integer.Parse(txtTDrainCount.Text)
            AI.OutGateStart = Double.Parse(txtOGateStart.Text)
            AI.OutGateStop = Double.Parse(txtOGateStop.Text)
            AI.OutGateCount = Integer.Parse(txtOGateCount.Text)
            AI.OutDrainStart = Double.Parse(txtODrainStart.Text)
            AI.OutDrainStop = Double.Parse(txtODrainStop.Text)
            AI.OutDrainCount = Integer.Parse(txtODrainCount.Text)
            AI.Compliance = Double.Parse(txtCompliance.Text)
            AI.Delay = Double.Parse(txtDelay.Text)
            AI.Aperture = Double.Parse(txtAperture.Text)
            AI.MeasurementSetNum = Integer.Parse(txtSets.Text)
            AI.RepeatInterval = Integer.Parse(txtInterval.Text)
            AI.rootPath = txtOutputLocation.Text
            AI.GateBias = Double.Parse(txtGateBiasVoltage.Text)
            AI.DrainBias = Double.Parse(txtDrainBiasVoltage.Text)

            If Not Worker.IsBusy() Then
                Worker.RunWorkerAsync(AI)
            End If
        Catch ex As System.FormatException
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub NumericOnlyTextInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTGateStop.KeyPress, txtTDrainStop.KeyPress, txtTDrainStart.KeyPress, txtOGateStop.KeyPress, txtOGateStart.KeyPress, txtODrainStop.KeyPress, txtODrainStart.KeyPress, txtTGateStart.KeyPress, txtGateBiasVoltage.KeyPress, txtDrainBiasVoltage.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." And Not e.KeyChar = "-" Then
            e.Handled = True
        End If
    End Sub

    Private Sub PositiveIntOnlyTextInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTGateCount.KeyPress, txtTDrainCount.KeyPress, txtOGateCount.KeyPress, txtODrainCount.KeyPress, txtSets.KeyPress, txtInterval.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub PositiveNumOnlyTextInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTGateCount.KeyPress, txtTDrainCount.KeyPress, txtOGateCount.KeyPress, txtODrainCount.KeyPress, txtSets.KeyPress, txtInterval.KeyPress, txtDelay.KeyPress, txtCompliance.KeyPress, txtAperture.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub UpdateTGStepSize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTGateStop.TextChanged, txtTGateStart.TextChanged, txtTGateCount.TextChanged
        Try
            ' * 2 is here because it's a double sweep.
            txtTGateStepSize.Text = (Double.Parse(txtTGateStop.Text) - Double.Parse(txtTGateStart.Text)) * 2 / (Integer.Parse(txtTGateCount.Text) - 1)
        Catch ex As System.FormatException
            txtTGateStepSize.Text = "NaN"
        End Try
    End Sub

    Private Sub UpdateTDStepSize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTDrainStop.TextChanged, txtTDrainStart.TextChanged, txtTDrainCount.TextChanged
        Try
            txtTDrainStepSize.Text = (Double.Parse(txtTDrainStop.Text) - Double.Parse(txtTDrainStart.Text)) / (Integer.Parse(txtTDrainCount.Text) - 1)
        Catch ex As System.FormatException
            txtTDrainStepSize.Text = "NaN"
        End Try
    End Sub

    Private Sub UpdateOGStepSize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOGateStop.TextChanged, txtOGateStart.TextChanged, txtOGateCount.TextChanged
        Try
            txtOGateStepSize.Text = (Double.Parse(txtOGateStop.Text) - Double.Parse(txtOGateStart.Text)) / (Integer.Parse(txtOGateCount.Text) - 1)
        Catch ex As System.FormatException
            txtOGateStepSize.Text = "NaN"
        End Try
    End Sub

    Private Sub UpdateODStepSize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtODrainStop.TextChanged, txtODrainStart.TextChanged, txtODrainCount.TextChanged
        Try
            ' * 2 is here because it's a double sweep.
            txtODrainStepSize.Text = (Double.Parse(txtODrainStop.Text) - Double.Parse(txtODrainStart.Text)) * 2 / (Integer.Parse(txtODrainCount.Text) - 1)
        Catch ex As System.FormatException
            txtODrainStepSize.Text = "NaN"
        End Try
    End Sub

    Private Sub DisplayFolderPicker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOutputLocation.Click
        BrowserDialog.SelectedPath = txtOutputLocation.Text

        If BrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtOutputLocation.Text = BrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub Worker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        ' This is where stuff happens in the background thread.
        ' We want to call Run() here so that it does its thing while the UI remains responsive.

        Dim backgroundWorker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)
        Dim obj As SMUInterface = CType(e.Argument, SMUInterface)

        obj.RunRepeatedMeasurements(backgroundWorker, e)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        ' This is called when the background thread finishes.
        ' It is run on the main thread.

        If e.Error IsNot Nothing Then
            MsgBox("Error: " & e.Error.Message)
        ElseIf e.Cancelled Then
            MsgBox("Measurements cancelled.")
        Else
            MsgBox("Finished running measurements.")
        End If

        lblStatus.Text = "Finished running."
        isRunning = False
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        ' This is called when the background thread signals a progress update.
        ' It is run on the main thread.

        Dim i As Integer = CType(e.UserState, Integer)
        lblStatus.Text = "Running... Current measurement set " & i & " (of " & txtSets.Text & ")."
    End Sub

    Private Sub QuitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitToolStripMenuItem.Click
        Dim response As Integer = MsgBox("Are you sure you want to quit?", vbQuestion + vbYesNo, "Quit")
        If response = vbYes Then
            If isRunning Then
                Worker.CancelAsync()
            End If
            End
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("MARS v1.0. Copyright (C) 2012 Oliver Hamlet. See readme for details.", MsgBoxStyle.OkOnly, "About MARS")
    End Sub
End Class