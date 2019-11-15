rem @echo off
cls

dotnet tool restore
dotnet paket restore
dotnet fake -v build target CIBuild
