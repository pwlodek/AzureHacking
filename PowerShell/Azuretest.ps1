Try
{
    Get-AzureRmContext
}
Catch
{
    if ($_ -like "*Login-AzureRmAccount to login*") {
      Login-AzureRmAccount
    }
}


#region Log into Azure
# connect to subscription (ARM)

Write-Output 'Running script'
$rg = Find-AzureRmResourceGroup | Where-Object { $_.name -eq 'DefaultARMResourceGroup'}
if ($rg -eq $null) {
    Write-Output 'Creating resource group'
    New-AzureRmResourceGroup -Name 'DefaultARMResourceGroup' -Location 'West Europe'
} else {
    Write-Output 'Resource group found!'
}

Write-Output 'Selecting subscription' 
Select-AzureRmSubscription -SubscriptionName 'Visual Studio Professional'
#Set-AzureRmCurrentStorageAccount -ResourceGroupName 'DefaultARMResourceGroup' -StorageAccountName 'defaultarmstorageaccount' 
#Get-AzureRmSubscription


#region App Service Plan metadata

#Get-Command -Module Azure -noun *hostingplan*

#Get-Command -Noun *serviceplan*


$plan = Get-AzureRmAppServicePlan -Name 'TempServicePlan'
if ($plan -eq $null) {
    Write-Output 'Creating App service plan'
    New-AzureRmAppServicePlan -ResourceGroupName 'DefaultARMResourceGroup' `
    -Name 'TempServicePlan' `
    -Location "West Europe"  `
    -Tier Standard 

} else {
    Write-Output 'App service plan exists'
}

Get-AzureRmAppServicePlan -Name 'TempServicePlan'

$del = Read-Host -Prompt 'Do you want to cleanup everything?'
if ($del -eq 'y') {
    Write-Output 'Deleting all stuff'
    Remove-AzureRmAppServicePlan -Name 'TempServicePlan' -ResourceGroupName 'DefaultARMResourceGroup' -Force
    Remove-AzureRmResourceGroup -Name 'DefaultARMResourceGroup' -Force
}

Write-Output 'DONE!'

#endregion
