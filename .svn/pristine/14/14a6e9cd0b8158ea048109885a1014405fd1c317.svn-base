@echo off

set databaseName=MovieAnalysis
set databaseServer=localhost

SQLCMD -E -iRecreateDatabase.sql -v DBName="%databaseName%" -s%databaseServer%"
echo success
IF ERRORLEVEL 1 GOTO Failure

SQLCMD -E -iTable_List.sql -d%databaseName% 

 IF ERRORLEVEL 1 GOTO CreateTableFailure
echo succeded creating sqlScript...

PAUSE


:Failure
echo connection fail
PAUSE
Exit /B 1

:CreateTableFailure
echo table creation fail
PAUSE
Exit /B 2


pause

