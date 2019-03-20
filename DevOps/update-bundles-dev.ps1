cd C:\projects\front-end-pages-and-components-vuejs

npm run build

Remove-Item C:\projects\backend-server-dot-core\Web.Server\wwwroot\js\*.*
Copy-Item -Path C:\projects\front-end-pages-and-components-vuejs\build\*.js -Destination C:\projects\backend-server-dot-core\Web.Server\wwwroot\js -Force

cd C:\projects\backend-server-dot-core\DevOps
