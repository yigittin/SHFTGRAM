This project build with react + vite.<br />
To run this project after cloning follows this steps<br />

-- Commands -- <br />
cd .\EFCore<br />
dotnet ef database update -s..\SHFTGRAM\SHFTGRAM.csproj<br />

Projects Schema<br />

-> Core Layer --> Holds classes that should be reachable from all across the project like Exceptions and Operations<br />
-> EFCore Layer --> Entity framework layer models, migrations and datacontext<br />
-> Service Layer --> Database and context operations handles in those services. Controller have to use service methods for dataflow<br />
-> SHFTGRAM Layer --> Controllers and programs runs on this layer. Main layer that creates api routes with controllers. And this layer has the UserManager to controll user operations and authentication management<br />
