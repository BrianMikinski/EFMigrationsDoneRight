# create a self contained migration bundle for deploying to our 
param (
	[string]$connectionString = "'Server=(localdb)\\mssqllocaldb;Database=Blog;Trusted_Connection=True;'"
)

# build ef migrations bundle - a self contined executable for deploying the database changes
dotnet ef migrations bundle  -c BlogDbContext --output blogDbContextBundle.exe --force -- "" --self-contained #--verbose

& .\blogDbContextBundle.exe -- --connection $connectionString
