$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
Write-Host "Setting .nuspec version tag to $versionStr"
$content = (Get-Content $root\NuGet\DadataApiClient.nuspec) 
$content = $content -replace '\$version\$',$env:APPVEYOR_BUILD_VERSION
$content = $content -replace '\$author\$', $env:APPVEYOR_REPO_COMMIT_AUTHOR
$content = $content -replace '\$title\$', $env:APPVEYOR_PROJECT_NAME

$content | Out-File $root\Nuget\DadataApiClient.compiled.nuspec
& nuget pack $root\Nuget\DadataApiClient.compiled.nuspec