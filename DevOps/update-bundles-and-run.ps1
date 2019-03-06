Remove-Item C:\projects\Solution.Net.Core\Web.Server\wwwroot\js\*.*

Copy-Item -Path C:\projects\Search.vuej\build\*.js -Destination C:\projects\Solution.Net.Core\Web.Server\wwwroot\js -Force

cd C:\projects\Solution.Net.Core\Web.Server

dotnet clean

dotnet run