# NetCoreWindowsService

Windows service net core example, using topshelf with basic description and display name.

### Install Service

- First deploy application to publish dir

```bash
dotnet publish -r win-x64 -c Release
```

install application 
```bash
  \bin\Release\netcoreapp3.1\win-x64\WindowsServiceNetCore.exe install
```

### Checking service

check in service.msc if service is started and is running


```bash
  service.msc
```
