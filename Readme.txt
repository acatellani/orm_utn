Import EF
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.10
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.10
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.10

Enable migrations
dotnet ef migrations add InitialCreate

Create Context
Add:
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=MyDatabase.db");
    }

https://learn.microsoft.com/en-us/ef/core/cli/dotnet
dotnet ef migrations script
dotnet ef database update

NHibernate
dotnet add package NHibernate --version 5.3.13
dotnet add package FluentNHibernate