rmdir /s /q coverage
rmdir /s /q CoverageReport
dotnet test --collect:"XPlat Code Coverage;Format=lcov" --results-directory:"./coverage" 
reportgenerator -reports:./coverage/*/*coverage.info -targetdir:./CoverageReport -reporttypes:HTML
rmdir /s /q coverage
start ./CoverageReport/index.html