@echo off
"c:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\amd64\MSBuild.exe" /t:Rebuild /p:DefineConstants="VERSION_TYPE=\"a\"" LabelPrint\LabelPrint.vbproj
cd LabelPrint\bin\Debug
"C:\Program Files\WinRAR\rar" a -apLabelPrint_a LabelPrint_a.rar ru\LabelPrint.resources.dll
"C:\Program Files\WinRAR\rar" a -apLabelPrint_a LabelPrint_a.rar ru-ru\LabelPrint.resources.dll
"C:\Program Files\WinRAR\rar" a -apLabelPrint_a LabelPrint_a.rar CurentInfo.ini
"C:\Program Files\WinRAR\rar" a -apLabelPrint_a LabelPrint_a.rar LabelPrint.exe
"C:\Program Files\WinRAR\rar" a -apLabelPrint_a LabelPrint_a.rar LabelPrint.ini
cd ../../..

"c:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\amd64\MSBuild.exe" /t:Rebuild /p:DefineConstants="VERSION_TYPE=\"b\"" LabelPrint\LabelPrint.vbproj
cd LabelPrint\bin\Debug
"C:\Program Files\WinRAR\rar" a -apLabelPrint_b LabelPrint_b.rar ru\LabelPrint.resources.dll
"C:\Program Files\WinRAR\rar" a -apLabelPrint_b LabelPrint_b.rar ru-ru\LabelPrint.resources.dll
"C:\Program Files\WinRAR\rar" a -apLabelPrint_b LabelPrint_b.rar CurentInfo.ini
"C:\Program Files\WinRAR\rar" a -apLabelPrint_b LabelPrint_b.rar LabelPrint.exe
"C:\Program Files\WinRAR\rar" a -apLabelPrint_b LabelPrint_b.rar LabelPrint.ini
cd ../../..

"c:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\amd64\MSBuild.exe" /t:Rebuild permitBCutility\permitBCutility.csproj
cd permitBCutility\bin\Debug
"C:\Program Files\WinRAR\rar" a -appermitBCutility permitBCutility.rar permitBCutility.exe
"C:\Program Files\WinRAR\rar" a -appermitBCutility permitBCutility.rar permitBCutility.exe.config
cd ../../..

mkdir bins
move LabelPrint\bin\Debug\LabelPrint_a.rar bins
move LabelPrint\bin\Debug\LabelPrint_b.rar bins
move permitBCutility\bin\Debug\permitBCutility.rar bins
pause

