@echo off
SET lasttag=0.0.0.0
FOR /F %%G IN ('git tag') DO (if not %%G==master (if not %%G==origin (SET lasttag=%%G)))
echo %lasttag%

