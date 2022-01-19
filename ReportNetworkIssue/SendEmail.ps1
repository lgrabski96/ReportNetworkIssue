#
# Shortcut, Target: C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -File "C:\Romanek\ReportNetworkIssue\SendEmail.ps1"
#

try
{
    $DesktopPath = [System.Environment]::GetFolderPath("Desktop")
    $env:computername | Out-File -FilePath $DesktopPath\NetworkandComputerdetails.txt
    Get-Date | Format-Table -Property DisplayHint,Date,Day,DayOfWeek, Hour, Minute, Month| Out-File -Append -FilePath $DesktopPath\NetworkandComputerdetails.txt
    Get-NetIPAddress | Format-Table | Out-File -Append -FilePath $DesktopPath\NetworkandComputerdetails.txt
    Get-NetAdapter | Out-File -Append -FilePath $DesktopPath\NetworkandComputerdetails.txt

    $outlook = New-Object -ComObject Outlook.Application
    $mail = $Outlook.CreateItem(0)

    $mail.To = "marek.romanowicz@capgemini.com"
    $mail.Subject = "Network Issue"
    $mail.Body = "Hello. I had an issue with network connection. Please check the possible reason and help to solve it. Thank You."

    $attachment1 = "$DesktopPath\NetworkandComputerdetails.txt"
    $mail.Attachments.add($attachment1)

    $mail.Send()

    [System.Windows.MessageBox]::Show('Email has been successfully sent')

}
catch
{
    [System.Windows.MessageBox]::Show('Error: Unable to send an email')

   
}