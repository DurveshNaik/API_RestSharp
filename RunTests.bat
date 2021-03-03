set ProjectPath="D:\Work\Own\CSharp\TestAssignmentProject\TestAssignmentProject\"
set ResultDir=%ProjectPath%TestResults\
set MSTestPath="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\MSTest.exe"

if not exist %ResultDir%  md "D:\Work\Own\CSharp\TestAssignmentProject\TestResults"

%MSTestPath% /testcontainer:%ProjectPath%bin\Debug\netcoreapp3.1\TestAssignmentProject.dll /resultsfile:%ResultDir%%FileName%.trx