@echo off
echo PRESS ANY KEY TO INSTALL Cadmus Libraries TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.Lon.Parts\bin\Debug\Cadmus.Lon.Parts.0.0.2.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Lon.Services\bin\Debug\Cadmus.Lon.Services.0.0.2.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.Lon.Parts\bin\Debug\Cadmus.Seed.Lon.Parts.0.0.2.nupkg -source C:\Projects\_NuGet
pause
