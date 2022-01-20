Add-Type -AssemblyName System.Windows.Forms
Write-Host "Capgemini - Network Reporting tool"
Write-Host "Please wait for the network report to generate..."
try
{
    $DesktopPath = [System.Environment]::GetFolderPath("Desktop")
    $env:computername | Out-File -FilePath $DesktopPath\NetworkandComputerdetails.txt
    $date = Get-Date
    $date | Out-File -Append -FilePath $DesktopPath\NetworkandComputerdetails.txt
    Get-NetIPAddress | Format-Table | Out-File -Append -FilePath $DesktopPath\NetworkandComputerdetails.txt
    Get-NetAdapter | Out-File -Append -FilePath $DesktopPath\NetworkandComputerdetails.txt

    $outlook = New-Object -ComObject Outlook.Application
    $mail = $Outlook.CreateItem(0)

    $mail.To = "ithelp.global@capgemini.com"
    $mail.Subject = "Network Issue"
    $mail.Body = "Hello. I had an issue with network connection that occurred around $date. 
    Please check the possible reason and help to solve it. 
    This email was generated automatically and contains an attachment file containing basic network connection and computer report.
    Thank You."

    $attachment1 = "$DesktopPath\NetworkandComputerdetails.txt"
    $mail.Attachments.add($attachment1)

    $mail.Send()

    $ButtonType = [System.Windows.Forms.MessageBoxButtons]::OK
    $MessageIcon = [System.Windows.Forms.MessageBoxIcon]::Information
    $MessageBody = "Network report has been successfully sent to ithelp.global@capgemini.com"
    $MessageTitle = "Message successfully sent"
    [System.Windows.Forms.MessageBox]::Show($MessageBody,$MessageTitle,$ButtonType,$MessageIcon)
    Start-Sleep -Seconds 1

}
catch [Exception]
{
    Write-Host "An exception has accrued:"
    Write-Host $_.Exception.Message
    
    $ButtonType = [System.Windows.Forms.MessageBoxButtons]::OK
    $MessageIcon = [System.Windows.Forms.MessageBoxIcon]::Stop
    $MessageBody = "Error: Unable to send an email.`rCheck internet connection and try again."
    $MessageTitle = "Error while sending an email"
                     
    [System.Windows.Forms.MessageBox]::Show($MessageBody,$MessageTitle,$ButtonType,$MessageIcon)
    Start-Sleep -Seconds 1
}