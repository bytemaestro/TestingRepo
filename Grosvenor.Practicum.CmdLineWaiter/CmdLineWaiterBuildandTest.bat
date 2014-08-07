MSBuild Grosvenor.Practicum.CmdLineWaiter.sln /t:Rebuild /p:Configuration=Release /p:Platform="x86"

cd CmdLineWaiterTests\bin\x86\Release\

MSTest /testcontainer:cmdlinewaitertests.dll


