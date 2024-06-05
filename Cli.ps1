# build
dotnet build -c Debug
# publish library
Remove-Item -Path .\Cadmus.Lon.Services\bin\Debug\net8.0\publish -Recurse -Force
dotnet publish .\Cadmus.Lon.Services\Cadmus.Lon.Services.csproj -c Debug
# rename publish to Cadmus.Lon.Services and zip
Rename-Item -Path .\Cadmus.Lon.Services\bin\Debug\net8.0\publish -NewName Cadmus.Lon.Services
compress-archive -path .\Cadmus.Lon.Services\bin\Debug\net8.0\Cadmus.Lon.Services\ -DestinationPath .\Cadmus.Lon.Services\bin\Debug\net8.0\Cadmus.Lon.Services.zip -Force
# rename back
Rename-Item -Path .\Cadmus.Lon.Services\bin\Debug\net8.0\Cadmus.Lon.Services -NewName publish
