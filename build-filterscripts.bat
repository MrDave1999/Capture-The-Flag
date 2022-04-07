@echo off
cd filterscripts
for /d %%D in (*) do (
	sampctl package ensure --dir "%%~fD"
	sampctl package build --dir "%%~fD"
)