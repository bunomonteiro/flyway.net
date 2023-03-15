# flyway.net
A [Flyway] wrapper for .NET

### Maintained by
[Bruno Monteiro][b'uno], also known as [b'uno].

## How to use
First, download [Flyway commandline] tool

**Note:** [Flyway commandline] is required.

#### Install Nuget Package
    Install-Package Flyway.net

### Create an Instance
All you have to do is pass the Flyway's path in the constructor.
```c#
var flyway = new Flyway(@"[flyway path]");
```

### Configure
You can configure in a few ways

#### Load Configurations
By default, **Load()** will load a file from disc
```c#
var config = new FlywayConfiguration(configurationFilePath: "[flyway path]\conf\flyway.conf").Load();
config.FlywayPath = @"[flyway path]"; // is required
var flyway = new Flyway(config);
```

#### In Memory Configurations
```c#
var config = new FlywayConfiguration();
configuration.FlywayPath = @"[flyway path]";  // is required
configuration.Url.Value = "jdbc:sqlserver://localhost;databaseName=master";
configuration.User.Value = "sa";
configuration.Password.Value = "Password";
var flyway = new Flyway(config);
```

#### Save Configurations
You do not need to save the configurations, but you have that possibility.
By default, **Save()** will write a file to the disc

```c#
var config = new FlywayConfiguration("[flyway path]\conf\flyway.conf");
config.BaselineDescription.Value = "Some baseline description";
config.Save();
```

#### Customizing Loading and Saving
You can implement your own configuration saver and loader
```c#
Action<string, string> saver = (arg, config) => { /* ... */ };
Func<string, string[]> loader = arg => new string[] { /* ... */ };
var config = new FlywayConfiguration(saver, loader);
// config.Load();
// config.Save();
```

### Execute
```c#
var cleanOutput = flyway.Clean();
var infoOutput = flyway.Info();
var baselineOutput = flyway.Baseline();
var migrateOutput = flyway.Migrate();
var undoOutput = flyway.Undo();
var repairOutput = flyway.Repair();
var validateOutput = flyway.Validate();

// Overriding the config
var cleanOutput = flyway.Clean(anotherConfig);
var infoOutput = flyway.Info(anotherConfig);
var baselineOutput = flyway.Baseline(anotherConfig);
var migrateOutput = flyway.Migrate(anotherConfig);
var undoOutput = flyway.Undo(anotherConfig);
var repairOutput = flyway.Repair(anotherConfig);
var validateOutput = flyway.Validate(anotherConfig);
```

## Todo

v. x
- ☐ Create the new options/parameters present in the new version of [Flyway].

v. 1.1.1 (09/2020)
- ☑ Fix: Flyway constructor accepts FlywayConfiguration

v. 1.1.0 (04/2020)
- ☑ Updated to version 6.4.0 of Flyway

v. 1.0.0 (04/2020)
- ☑ First Release

License
----

The **flyway.net** source code is issued under [MIT license][MIT], a permissive free license, which means you can modify it as you please, and incorporate it into your own commercial or non-commercial software.

**Free Software, oh yeah!**

   [flyway]: <https://github.com/flyway/flyway>
   [flyway commandline]: <https://flywaydb.org/documentation/commandline/#download-and-installation>
   [b'uno]: <http://brunomonteiro.dev>
   [MIT]: <http://opensource.org/licenses/MIT>
