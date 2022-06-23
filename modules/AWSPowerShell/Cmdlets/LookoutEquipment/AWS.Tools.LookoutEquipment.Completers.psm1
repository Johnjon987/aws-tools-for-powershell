# Auto-generated argument completers for parameters of SDK ConstantClass-derived type used in cmdlets.
# Do not modify this file; it may be overwritten during version upgrades.

$psMajorVersion = $PSVersionTable.PSVersion.Major
if ($psMajorVersion -eq 2) 
{ 
	Write-Verbose "Dynamic argument completion not supported in PowerShell version 2; skipping load."
	return 
}

# PowerShell's native Register-ArgumentCompleter cmdlet is available on v5.0 or higher. For lower
# version, we can use the version in the TabExpansion++ module if installed.
$registrationCmdletAvailable = ($psMajorVersion -ge 5) -Or !((Get-Command Register-ArgumentCompleter -ea Ignore) -eq $null)

# internal function to perform the registration using either cmdlet or manipulation
# of the options table
function _awsArgumentCompleterRegistration()
{
    param
    (
        [scriptblock]$scriptBlock,
        [hashtable]$param2CmdletsMap
    )

    if ($registrationCmdletAvailable)
    {
        foreach ($paramName in $param2CmdletsMap.Keys)
        {
             $args = @{
                "ScriptBlock" = $scriptBlock
                "Parameter" = $paramName
            }

            $cmdletNames = $param2CmdletsMap[$paramName]
            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                $args["Command"] = $cmdletNames
            }

            Register-ArgumentCompleter @args
        }
    }
    else
    {
        if (-not $global:options) { $global:options = @{ CustomArgumentCompleters = @{ }; NativeArgumentCompleters = @{ } } }

        foreach ($paramName in $param2CmdletsMap.Keys)
        {
            $cmdletNames = $param2CmdletsMap[$paramName]

            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                foreach ($cn in $cmdletNames)
                {
                    $fqn =  [string]::Concat($cn, ":", $paramName)
                    $global:options['CustomArgumentCompleters'][$fqn] = $scriptBlock
                }
            }
            else
            {
                $global:options['CustomArgumentCompleters'][$paramName] = $scriptBlock
            }
        }

        $function:tabexpansion2 = $function:tabexpansion2 -replace 'End\r\n{', 'End { if ($null -ne $options) { $options += $global:options} else {$options = $global:options}'
    }
}

# To allow for same-name parameters of different ConstantClass-derived types 
# each completer function checks on command name concatenated with parameter name.
# Additionally, the standard code pattern for completers is to pipe through 
# sort-object after filtering against $wordToComplete but we omit this as our members 
# are already sorted.

# Argument completions for service Amazon Lookout for Equipment


$L4E_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.LookoutEquipment.DataUploadFrequency
        {
            ($_ -eq "New-L4EInferenceScheduler/DataUploadFrequency") -Or
            ($_ -eq "Update-L4EInferenceScheduler/DataUploadFrequency")
        }
        {
            $v = "PT10M","PT15M","PT1H","PT30M","PT5M"
            break
        }

        # Amazon.LookoutEquipment.InferenceExecutionStatus
        "Get-L4EInferenceExecutionList/Status"
        {
            $v = "FAILED","IN_PROGRESS","SUCCESS"
            break
        }

        # Amazon.LookoutEquipment.IngestionJobStatus
        "Get-L4EDataIngestionJobList/Status"
        {
            $v = "FAILED","IN_PROGRESS","SUCCESS"
            break
        }

        # Amazon.LookoutEquipment.ModelStatus
        "Get-L4EModelList/Status"
        {
            $v = "FAILED","IN_PROGRESS","SUCCESS"
            break
        }

        # Amazon.LookoutEquipment.TargetSamplingRate
        "New-L4EModel/DataPreProcessingConfiguration_TargetSamplingRate"
        {
            $v = "PT10M","PT10S","PT15M","PT15S","PT1H","PT1M","PT1S","PT30M","PT30S","PT5M","PT5S"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$L4E_map = @{
    "DataPreProcessingConfiguration_TargetSamplingRate"=@("New-L4EModel")
    "DataUploadFrequency"=@("New-L4EInferenceScheduler","Update-L4EInferenceScheduler")
    "Status"=@("Get-L4EDataIngestionJobList","Get-L4EInferenceExecutionList","Get-L4EModelList")
}

_awsArgumentCompleterRegistration $L4E_Completers $L4E_map

$L4E_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.L4E.$($commandName.Replace('-', ''))Cmdlet]"
    if (-not $cmdletType) {
        return
    }
    $awsCmdletAttribute = $cmdletType.GetCustomAttributes([Amazon.PowerShell.Common.AWSCmdletAttribute], $false)
    if (-not $awsCmdletAttribute) {
        return
    }
    $type = $awsCmdletAttribute.SelectReturnType
    if (-not $type) {
        return
    }

    $splitSelect = $wordToComplete -Split '\.'
    $splitSelect | Select-Object -First ($splitSelect.Length - 1) | ForEach-Object {
        $propertyName = $_
        $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')) | Where-Object { $_.Name -ieq $propertyName }
        if ($properties.Length -ne 1) {
            break
        }
        $type = $properties.PropertyType
        $prefix += "$($properties.Name)."

        $asEnumerableType = $type.GetInterface('System.Collections.Generic.IEnumerable`1')
        if ($asEnumerableType -and $type -ne [System.String]) {
            $type =  $asEnumerableType.GetGenericArguments()[0]
        }
    }

    $v = @( '*' )
    $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')).Name | Sort-Object
    if ($properties) {
        $v += ($properties | ForEach-Object { $prefix + $_ })
    }
    $parameters = $cmdletType.GetProperties(('Instance', 'Public')) | Where-Object { $_.GetCustomAttributes([System.Management.Automation.ParameterAttribute], $true) } | Select-Object -ExpandProperty Name | Sort-Object
    if ($parameters) {
        $v += ($parameters | ForEach-Object { "^$_" })
    }

    $v |
        Where-Object { $_ -match "^$([System.Text.RegularExpressions.Regex]::Escape($wordToComplete)).*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$L4E_SelectMap = @{
    "Select"=@("New-L4EDataset",
               "New-L4EInferenceScheduler",
               "New-L4EModel",
               "Remove-L4EDataset",
               "Remove-L4EInferenceScheduler",
               "Remove-L4EModel",
               "Get-L4EDataIngestionJob",
               "Get-L4EDataset",
               "Get-L4EInferenceScheduler",
               "Get-L4EModel",
               "Get-L4EDataIngestionJobList",
               "Get-L4EDatasetList",
               "Get-L4EInferenceEventList",
               "Get-L4EInferenceExecutionList",
               "Get-L4EInferenceSchedulerList",
               "Get-L4EModelList",
               "Get-L4ESensorStatisticList",
               "Get-L4EResourceTag",
               "Start-L4EDataIngestionJob",
               "Start-L4EInferenceScheduler",
               "Stop-L4EInferenceScheduler",
               "Add-L4EResourceTag",
               "Remove-L4EResourceTag",
               "Update-L4EInferenceScheduler")
}

_awsArgumentCompleterRegistration $L4E_SelectCompleters $L4E_SelectMap

