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

cd C:\Users\user\Desktop\ecommerce
git config user.name "Jadiael"
git config user.email Jadiael@hotmail.com.br
git add .
git add --all
git commit -am "chore: Update files %date%-%time:~0,2%-%time:~3,2%-%time:~6,2%"
git push origin main
endlocal
pause