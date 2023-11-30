# EFMigrationsDoneRight
Repo demonstrating the proper way to do ef migrations

## Add new solution

```shell
dotnet new sln
```

## Add new project

```shell
dotnet new project console
```

## Add new package
```shell
dotnet add package <package name>
```

```shell
dotnet add package Microsoft.EntityFrameworkCore.Design
```

```shell
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```


## Adding a new migration


## EF Core Code First Migrations Done Right with PowerShell and EF Bundles

## Intro
As software engineers, nearly all projects that we work on will contain a database of some kind. Anyone 

## What is difficult
- What is difficult about databases?
    - They have to be setup nearly perfect to work right
    - Changing them is hard

## EF Core Code First Migrations Witch Hunt
- Ef code first migrations are often slandered and maltreated
- Why?
- Any databse tool for migratiosn needs to enforce some rules of some sort and universially you will see the following pattern
    - Schema update migrations
    - Schema downgrade migration
    - Optional ability to write customize update and downgrade migrations
        - You can write custom "pre" update migration sql
        - You can write custom "post" update migration sql
        - The same is true of downgrade migrations - "pre" downgrade sql schema migration and "post" downgrade custom sql code.
- Question I like to present to the EF Migration haters is to look at what other tools offer? If you begin to explore alternatives, you'll find that everyone unverisally approves that a forced pattern of upgrade and downgrades for databases is the correct path forward
- Ef migrations force you to utilize a pattern and maintain chronological consistency with you database updates.
- Ef migrations are supported across many different database providers - first class support for
    - Ms SQL
    - SqLite
    - Postgres
    - MySql


## What are Entity Framework Code First Migrations?
- EF code first migrations allow you to define your database schema fully in code, without writing a single line of sql. EF Core also gives you the ability to quickly and easily change your existing schema definitions, add new tables, indices, etc. and subsequently apply the schema changes in a chronologically correct and safe manner.
- Insert diagram of pushing from C# files to database for your scheam

## Project layout
- Blog project, will have the following schema.
- Insert picture of schema
- We will do three migrations to get here.


## Initial Migration - Using PowerShell and Dotnet ef command


## Enhancing Database Deployment with EF Bundles

-What are EF Bundles?
- Ability to use an executable for your deployments
- Why would you want to do this? This gives you the ability to create and run your migrations anywhere, independent of having your source code or the dotnet EF tool installed. This is very powerful as it relates to deploying with in deployment pipelines





## What about down grades?
- In reality, no one downgrades database. You always go forward or roll back without the changes