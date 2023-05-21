@echo off
setlocal
REM Obter a data atual com dois dígitos
for /f "tokens=2 delims==" %%I in ('wmic os get localdatetime /value') do (
    set "datetime=%%I"
)
set "date=%datetime:~0,4%-%datetime:~4,2%-%datetime:~6,2%"

REM Obter a hora, minutos e segundos atuais com dois dígitos
for /f "tokens=2 delims==" %%I in ('wmic os get localdatetime /value') do (
    set "datetime=%%I"
)
set "time=%datetime:~8,2%:%datetime:~10,2%:%datetime:~12,2%"

echo y | C:\xampp\mysql\bin\mysqladmin.exe -u root -h localhost drop ecommerce
rmdir /S /Q "C:\Users\user\Desktop\ecommerce\backend\WebApi\Migrations"
echo Migration-%date%-%time:~0,2%-%time:~3,2%-%time:~6,2%
cd C:\Users\user\Desktop\ecommerce\backend\WebApi\ && dotnet ef migrations add Migration-%date%-%time:~0,2%-%time:~3,2%-%time:~6,2%
cd C:\Users\user\Desktop\ecommerce\backend\WebApi\ && dotnet ef database update
endlocal
pause