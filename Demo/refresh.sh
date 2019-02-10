#!/bin/bash -x

dotnet tool uninstall CodeAnalyser

rm -rf ~/.nuget/packages/codeanalyser/

dotnet tool install CodeAnalyser --add-source ../CodeAnalyser/output/