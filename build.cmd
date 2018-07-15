@echo off
cls

dotnet restore build.proj
dotnet fake build %*
