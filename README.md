# ErrorLogger
- Install the package or reference the project into your asp.net core application.
- Add the AddLog4Net() call into your Configure method of the Startup class.

```cs
using Microsoft.Extensions.Logging;

public class Startup
{
    //...

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        //...

        loggerFactory.AddLog4Net(); // << Add this line
        app.UseMvc();

        //...
    }
}

```

- Add a log4net.config file with the content:

```cs
<?xml version="1.0" encoding="utf-8"?>
<log4net>
  <appender name="RollingFile" type="log4net.Appender.FileAppender">
    <file value="C:\Temp\app.log" />
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="%-5p %d{hh:mm:ss} %message%newline" />
    </layout>
  </appender>
   <root>
    <level value="ALL" />
    <appender-ref ref="RollingFile" />
  </root>
</log4net>
```
- Add a HomeController.cs file with the content:

```cs
public class HomeController
{
    //...

    public HomeController(ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger("RollingFile");

            logger.LogCritical("Hello");

         #if DEBUG
                   logger.LogDebug("This is a debug log");
         #endif
         
        }
        
        //...
}
```
