rem @echo off
cls

dotnet tool restore
dotnet paket restore
dotnet fsi build.fsx -- %*
