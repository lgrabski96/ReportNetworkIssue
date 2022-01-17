#
# Shortcut, Target: C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -File "C:\Romanek\ReportNetworkIssue\SendEmail.ps1"
#

try
{
    $outlook = New-Object -ComObject Outlook.Application
    $mail = $Outlook.CreateItem(0)

    $mail.To = "milosz.krysinski@capgemini.com"
    $mail.Subject = "Network Issue"
    $mail.Body = "A network issue has been reported"

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