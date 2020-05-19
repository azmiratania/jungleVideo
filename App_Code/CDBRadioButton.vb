Imports Microsoft.VisualBasic

Public Class CDBRadioButton

    Function getRadioButton() As ArrayList

        Dim objArrayList As New ArrayList
        Dim objRadioButton As New CRadioButton

        objRadioButton = New CRadioButton

        objRadioButton.RadioId = 1
        objRadioButton.RadioName = "Active Members"

        objArrayList.Add(objRadioButton)

        objRadioButton = New CRadioButton

        objRadioButton.RadioId = 2
        objRadioButton.RadioName = "Suspended Members"

        objArrayList.Add(objRadioButton)

        Return objArrayList

    End Function



End Class
