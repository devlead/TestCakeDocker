var target = Argument("target", "Package");
var configuration = Argument("configuration", "Release");
var solution = "./TestConsole.sln";

var artifacts = MakeAbsolute(Directory("./artifacts"));

Task("Clean")
    .Does( ()=> 
{
    CleanDirectory(artifacts);
    CleanDirectories("./**/obj/*.*");
    CleanDirectories($"./**/bin/{configuration}/*.*");
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does( ()=> 
{
    DotNetCoreRestore(solution);
});

Task("Build")
    .IsDependentOn("Restore")
    .Does( ()=> 
{
    DotNetCoreBuild(
        solution,
        new DotNetCoreBuildSettings {
            NoRestore = true,
            Configuration = configuration
        }
    );
});

Task("Run-Unit-tests")
    .IsDependentOn("Build")
    .DoesForEach(
        GetFiles("./**/*.Tests.csproj"),
        testProject => 
{
    DotNetCoreTest(
        testProject.FullPath,
        new DotNetCoreTestSettings{
            NoBuild = true,
            NoRestore = true,
            Configuration = configuration
        }
    );
});

Task("Package")
    .IsDependentOn("Run-Unit-tests")
    .DoesForEach(
        GetFiles("./**/*Lib*.csproj") - GetFiles("./**/*.Tests.csproj"),
        testProject => 
{
    DotNetCorePack(
        testProject.FullPath,
        new DotNetCorePackSettings{
            NoBuild = true,
            NoRestore = true,
            Configuration = configuration,
            OutputDirectory = artifacts
        }
    );
});


RunTarget(target);