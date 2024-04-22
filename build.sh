#!/bin/bash

dotnet tool restore
dotnet paket restore
dotnet fsi build.fsx -- "$@"
