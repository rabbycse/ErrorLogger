# ErrorLogger
- Install the **nuget package** or reference the project into your asp.net core application.

![ngt](https://user-images.githubusercontent.com/37344605/61993202-2a1c8b80-b08a-11e9-9522-be8ac5b0a4c6.png)


- Add the **AddLog4Net()** call into your Configure method of the Startup class.

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

- Then **log4net.config**->**Propertise**->**Copy to Output Directory**->Change to **Copy if newer**

- Add a **log4net.config** file with the content:

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
- Add a **HomeController.cs** file with the content:

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
## Ouput
  - Go to (c:\Temp\app.log):

![log](https://user-images.githubusercontent.com/37344605/61993011-95189300-b087-11e9-95b6-4c9fd5fa1f74.png)

