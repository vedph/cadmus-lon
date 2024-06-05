@echo off
echo BUILD Cadmus Lon Packages
del .\Cadmus.Lon.Parts\bin\Debug\*.snupkg
del .\Cadmus.Lon.Parts\bin\Debug\*.nupkg

del .\Cadmus.Lon.Services\bin\Debug\*.snupkg
del .\Cadmus.Lon.Services\bin\Debug\*.nupkg

del .\Cadmus.Seed.Lon.Parts\bin\Debug\*.snupkg
del .\Cadmus.Seed.Lon.Parts\bin\Debug\*.nupkg

cd .\Cadmus.Lon.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Lon.Services
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Seed.Lon.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
