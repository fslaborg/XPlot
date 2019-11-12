#!/bin/bash

set -eu
set -o pipefail

dotnet tool restore
dotnet paket restore
dotnet fake build "$@"
