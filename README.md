# Introduction 

👋 Hi, I’m Akash 👀 I’m interested in Automation testing, Penetration testing and Cloud compute. 🌱 I’m currently learning ...Azure 303/304 💞️ I’m looking to collaborate on ...Specflow, Penetration testing, IAAS,PAAS AND SAAS architectutre solutions 📫 How to reach me ...catchakashonmail@gmail.com

# Framework
Behvaiour Driver deveklopment 

# Tech

C#, SpecFlow/Renroll, Selenium and NUnit


# Pre-requisites
Visual Studio 2019 with Specflow Extension and target framework .NET Core 3.1


# Structure
ColoplastAutotestsWeb  
|-Core  
|  |-Drivers  
|  |  |-Drivers.cs //DriverManager  
|  |  |-Helper.cs //useful methods  
|  |  |-RetryAttributeEx.cs //custom NUnit  
|  |  |-WebDriverExtensions.cs //useful overrides over Selenium methods  
|  |-Base  
|    |-BasePage.cs //Base page for pageobjects  
|-Project A  
|   |-Features //folder for specflow feature files  
|   |-Hooks //general methods across the project  
|   |-PageObjects //folder for pageobjects  
|   |-Steps //Specflow steps definitions  
|   |app.<env>.config  
|   |specflow.json  
|-Project  
|_...  


# Adding a new project
1. Add new project
1. Add a dependency to Core project
1. Add a app.<env>.config containing:
``` xml
<?xml version="1.0" encoding="utf-8" ?>  
  <configuration>  
    <appSettings>  
      <add key="screenshotsPath" value="<screenhots path>"/>  
      <add key="url" value="<url to website>"/>  
    </appSettings>  
  </configuration>  
```
4. Add a specflow.json file containing:  
``` json
{
  "bindingCulture": {
    "language": "en-us"
  },
  "language": {
    "feature": "en-us"
  },
  "livingDocGenerator": {
    "enabled": true,
    "filePath": "TestExecution.json"
  },
    "stepAssemblies": [
      {
        "assembly": "Core"
      }
    ]
}
```
5. Set Copy to output directory as Always for app.<env>.config and specflow.json
5. Go to Build -> Configuration Manager and add new Configurations for project according to environments (Sandbox, Test, Prod etc.)
NOTE: Uncheck the create solution configuration checkbox
5. Add Microsoft.NET.Test.Sdk nuget package to project
5. Add NUnit3TestAdapter nuget package to project
5. Add Specflow.NUnit nuget package to project
5. Double-click on project file -> add this code before </Project> tag:
``` xml
<!-- START: This is a buildtime work around for https://github.com/dotnet/corefx/issues/22101 -->
  <Target Name="CopyCustomContent" AfterTargets="AfterBuild">
    <Copy SourceFiles="$(OutDir)\app.$(ConfigurationName).config" DestinationFiles="$(OutDir)\testhost.dll.config" />
  </Target>
  <!-- END: This is a buildtime work around for https://github.com/dotnet/corefx/issues/22101 -->
  ```


# Build and Test
1. Via Visual Studio
Right-click on solution -> Build
In the Test section: right-click on required test -> Run

1. Adding test run on Azure or via PowerShell
dotnet build <path to csproj file> -c <Configuration>
dotnet test <path to dll> --filter Category=<category> //smoke or regression
