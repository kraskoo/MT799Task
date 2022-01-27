# MT799Task

## Description

Read files in MT799 format and write them to MSSQL database.
The program/service will check every 5 seconds for new files and will add them to database.

## Build
1. Publish the project with these settings:
![alt text](images/settings.png)

## Install Service
Run ``InstallService.bat`` as administrator

## Uninstall Service
Run ``UninstallService.bat`` as administrator

## How to work
Put your files in "C:\MT799" or change the path (before start install the service) in ``appsettings.json`` and put the files there.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details