$ver = Get-Content -Path .\version.txt
Compress-Archive -Path .\Monstromatic\bin\Release\net5.0\win-x64\publish\Monstromatic.exe -DestinationPath Monstromatic-$ver.zip