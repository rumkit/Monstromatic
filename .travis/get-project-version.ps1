$proj = [xml](Get-Content .\Monstromatic\Monstromatic.csproj)
$version = $proj.Project.PropertyGroup.VersionPrefix
[System.Environment]::SetEnvironmentVariable("csproj_version","$version",[System.EnvironmentVariableTarget]::Machine)
[System.Environment]::SetEnvironmentVariable("csproj_version","$version",[System.EnvironmentVariableTarget]::User)