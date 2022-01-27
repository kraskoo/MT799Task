# MT799Task

## Description

Read files in MT799 format and write them to MSSQL database.
The program/service will check every 5 seconds for new files and will add them to database.

## Build
1. Publish the project with these settings:
![alt text](images/settings.png)
2. Run ``InstallService.bat`` as administrator

## How to work
Put your files in "C:\MT799" or change the path in ``appsettings.json`` and put the files there.
