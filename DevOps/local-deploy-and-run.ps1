cd C:\projects\Search.vuej 

npm run build:prod

Remove-Item C:\projects\Solution.Net.Core\Web.Server\wwwroot\js\*.*
Copy-Item -Path C:\projects\Search.vuej\build\*.js -Destination C:\projects\Solution.Net.Core\Web.Server\wwwroot\js -Force

cd C:\projects\Solution.Net.Core\Web.server

dotnet clean

dotnet build

dotnet run -c Release

cd C:\projects\Solution.Net.Core\DevOps


