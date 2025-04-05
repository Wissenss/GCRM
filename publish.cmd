:: compile
set version=0.1.1.4-alpha

set "output_path_x64=.\GCRM\bin\Release\gcrm_%version%_x64"
set "output_path_x86=.\GCRM\bin\Release\gcrm_%version%_x86"

dotnet publish -c Release -r win-x64 -p:PublishReadyToRun=true --self-contained --output "%output_path_x64%"
dotnet publish -c Release -r win-x86 -p:PublishReadyToRun=true --self-contained --output "%output_path_x86%"

:: compress
set "output_compress_path_x64=.\gcrm_%version%_x64.7z"
set "output_compress_path_x86=.\gcrm_%version%_x86.7z"

".\GCRM\Libs\7za.exe" a "%output_compress_path_x64%" "%output_path_x64%\*"
".\GCRM\Libs\7za.exe" a "%output_compress_path_x86%" "%output_path_x86%\*"