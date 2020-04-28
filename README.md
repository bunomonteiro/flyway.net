# flyway.net
A [Flyway] wrapper for .NET

### Maintained by
[Bruno Monteiro][b'uno], also known as [b'uno].

## How to use
First, download [Flyway commandline] tool


#### Install Nuget Package
    Install-Package Flyway.net

#### Load Configurations
```c#
var config = new FlywayConfiguration("[flyway path]\conf\flyway.conf").Load();
```

#### Save Configurations
```c#
var config = new FlywayConfiguration("[flyway path]\conf\flyway.conf");
config.BaselineDescription.Value = "Some baseline description";
config.Save();
```

#### Migrate
```c#
// with default config (config file)
await new Flyway("[flyway path]").MigrateAsync();

// with config in memory
var config = new FlywayConfiguration();
config.Url.Value = "jdbc:...";
await new Flyway(config).MigrateAsync();

// with custom config
await new Flyway("[flyway path]")
  .MigrateAsync(new FlywayMigrateOptionGroup
  {
    Url = new FlywayUrlOption("jdbc:mariadb://localhost:3306/flyway"),
    User = new FlywayUserOption("root"),
    Password = new FlywayPasswordOption("pw")
  });
```

## Todo

v. 1.0.0 (04/2020)
- ☑ First Release

v. 1.1.0 (28/2020)
- ☑ Updated to version 6.4.0 of Flyway

v. x
- ☐ Create the new options/parameters present in the new version of [Flyway].

License
----

The **flyway.net** source code is issued under [MIT license][MIT], a permissive free license, which means you can modify it as you please, and incorporate it into your own commercial or non-commercial software.

**Free Software, oh yeah!**

   [flyway]: <https://github.com/flyway/flyway>
   [flyway commandline]: <https://flywaydb.org/documentation/commandline/#download-and-installation>
   [b'uno]: <http://brunomonteiro.dev>
