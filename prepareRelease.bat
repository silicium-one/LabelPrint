@echo off
MSBuild.exe /t:Rebuild /p:DefineConstants="VERSION_TYPE=\"a\"" LabelPrint\LabelPrint.vbproj
cd LabelPrint\bin\Debug
rar a -apLabelPrint_a LabelPrint_a.rar ru\LabelPrint.resources.dll
rar a -apLabelPrint_a LabelPrint_a.rar ru-ru\LabelPrint.resources.dll
rar a -apLabelPrint_a LabelPrint_a.rar CurentInfo.ini
rar a -apLabelPrint_a LabelPrint_a.rar LabelPrint.exe
rar a -apLabelPrint_a LabelPrint_a.rar LabelPrint.ini
cd ../../..

MSBuild.exe /t:Rebuild /p:DefineConstants="VERSION_TYPE=\"b\"" LabelPrint\LabelPrint.vbproj
cd LabelPrint\bin\Debug
rar a -apLabelPrint_b LabelPrint_b.rar ru\LabelPrint.resources.dll
rar a -apLabelPrint_b LabelPrint_b.rar ru-ru\LabelPrint.resources.dll
rar a -apLabelPrint_b LabelPrint_b.rar CurentInfo.ini
rar a -apLabelPrint_b LabelPrint_b.rar LabelPrint.exe
rar a -apLabelPrint_b LabelPrint_b.rar LabelPrint.ini
cd ../../..

MSBuild.exe /t:Rebuild permitBCutility\permitBCutility.csproj
cd permitBCutility\bin\Debug
rar a -appermitBCutility permitBCutility.rar permitBCutility.exe
rar a -appermitBCutility permitBCutility.rar permitBCutility.exe.config
cd ../../..

mkdir bins
move LabelPrint\bin\Debug\LabelPrint_a.rar bins
move LabelPrint\bin\Debug\LabelPrint_b.rar bins
move permitBCutility\bin\Debug\permitBCutility.rar bins

