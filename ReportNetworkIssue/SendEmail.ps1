#
# Shortcut, Target: C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -File "C:\Romanek\ReportNetworkIssue\SendEmail.ps1"
#

try
{
    $outlook = New-Object -ComObject Outlook.Application
    $mail = $Outlook.CreateItem(0)

    $mail.To = "piotrspikowski@gmail.com"
    $mail.Subject = "Email sent via Outlook from PowerShell"
    $mail.Body = "Hello"

    $mail.Send()

    $outlook.Quit()

    # [System.Runtime.Interopservices.Marshal]::ReleaseComObject($outlook)
}
catch
{
    Write-Host "Unable to send an email. An error occurred:"
    Write-Host $_
}