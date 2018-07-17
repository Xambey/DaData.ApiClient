$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'

$content = (Get-Content $root\NuGet\Dadata.nuspec) 
$content = $content -replace '\$version\$',$env:APPVEYOR_BUILD_VERSION
$content = $content -replace '\$author\$', $env:APPVEYOR_REPO_COMMIT_AUTHOR
$content = $content -replace '\$title\$', $env:APPVEYOR_PROJECT_NAME

$content | Out-File $root\Nuget\Dadata.compiled.nuspec
& nuget pack $root\Nuget\Dadata.compiled.nuspec