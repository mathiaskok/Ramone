cd Ramone\bin\debug
copy Ramone.dll Ramone.Core.dll 
"C:\Program Files (x86)\Microsoft\ILMerge\ilmerge.exe" /target:library /out:Ramone.dll Ramone.Core.dll JsonFx.dll HtmlAgilityPack.dll /targetplatform:v4
xcopy Ramone*.dll ..\..\..\Binaries\ /S /I /R /Y
xcopy Ramone*.pdb ..\..\..\Binaries\ /S /I /R /Y
xcopy Ramone*.xml ..\..\..\Binaries\ /S /I /R /Y
