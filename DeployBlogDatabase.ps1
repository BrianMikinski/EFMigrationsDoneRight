# create a self contained migration bundle for deploying to our 
param (
	[string]$connectionString = "'Server=(localdb)\\mssqllocaldb;Database=Blog;Trusted_Connection=True;'"
)

# build ef migrations bundle - a self contined executable for deploying the database changes
dotnet build EfMigrationsDoneRight.csproj --runtime win-x64
dotnet ef migrations bundle --no-build -c BlogDbContext --output blogDbContextBundle.exe --force -- "" --self-contained #--force -- "" --self-contained --verbose 

& .\blogDbContextBundle.exe -- --connection $connectionString
