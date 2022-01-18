﻿#
# Shortcut, Target: C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -File "C:\Romanek\ReportNetworkIssue\SendEmail.ps1"
#

try
{
    $env:computername | Out-File -FilePath c:\users\mromanow\info.txt
    Get-Date | Format-Table | Out-File -Append -FilePath c:\users\mromanow\info.txt
    Get-NetIPAddress | Format-Table | Out-File -Append -FilePath c:\users\mromanow\info.txt
    Get-NetAdapter | Out-File -Append -FilePath c:\users\mromanow\info.txt

    $outlook = New-Object -ComObject Outlook.Application
    $mail = $Outlook.CreateItem(0)

    $mail.To = "marek.romanowicz@capgemini.com"
    $mail.Subject = "Network Issue"
    $mail.Body = "Hello. I had an issue with network connection. Please check the possible reason and help to solve it. Thank You."

    $attachment1 = "c:\users\mromanow\info.txt"
    $att = new-object System.Net.Mail.Attachment($attachment1)
    $mail.Attachments.add($attachment1)

    $mail.Send()

    [System.Windows.MessageBox]::Show('Email has been successfully sent')

    $outlook.Quit()

    # [System.Runtime.Interopservices.Marshal]::ReleaseComObject($outlook)
}
catch
{
    [System.Windows.MessageBox]::Show('Error: Unable to send an email')

    #Write-Host "Unable to send an email. An error occurred:"
    #Write-Host $_
}