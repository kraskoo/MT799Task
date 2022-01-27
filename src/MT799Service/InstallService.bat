sqlcmd -Q "SP_ADDSRVROLEMEMBER 'NT AUTHORITY\SYSTEM','SYSADMIN'"
sc create "MT799 Service" binpath="%cd%\MT799Service.exe"
sc start "MT799 Service"