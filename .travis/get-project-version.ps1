$proj = [xml](Get-Content ./Monstromatic/Monstromatic.csproj)
$version = $proj.Project.PropertyGroup.VersionPrefix
$env:csproj_version = $version