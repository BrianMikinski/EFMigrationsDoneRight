
# create a self contained migration bundle for deploying to linux
param (
	[string]$connectionString = "'Server=(localdb)\\mssqllocaldb;Database=Blog;Trusted_Connection=True;'"
)

# Create new migration
$MigrationName = Read-Host -Prompt 'What is the name of the new migration?'
dotnet ef migrations add $MigrationName -c BlogDbContext -- $connectionString

dotnet ef context
