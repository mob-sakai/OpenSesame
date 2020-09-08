Open Sesame
===

A custom [Roslyn](https://github.com/dotnet/roslyn) compiler **that allows access to internals/privates in other assemblies.**

![License](https://img.shields.io/github/license/mob-sakai/OpenSesame)

![.NetFramework](https://img.shields.io/static/v1?label=.Net+Framework&message=4.7+or+later&color=blue)
![.NetCore](https://img.shields.io/static/v1?label=.Net+Core&message=2.0+or+later&color=red)
![.NetStandard](https://img.shields.io/static/v1?label=.Net+Standard&message=2.0+or+later&color=orange)

![test](https://github.com/mob-sakai/OpenSesame/workflows/test/badge.svg)
![release](https://github.com/mob-sakai/OpenSesame/workflows/release/badge.svg)

## Description

This package contains a custom [Roslyn](https://github.com/dotnet/roslyn) compiler.
If the package is installed in a c# project, it will override the compiler used in the build.

The custom compiler automatically injects `IgnoresAccessChecksToAttribute` to the assembly.
This attribute ignores accessibility to the assembly with the given name.
In other words, **you can access to internals/privates in other assemblies, without [reflection feature][reflection].**

Have you ever heard of a secret attribute `IgnoresAccessChecksToAttribute`?
For more information, See [the great article by Filip W][ignores-access].

[reflection]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection
[ignores-access]: https://www.strathweb.com/2018/10/no-internalvisibleto-no-problem-bypassing-c-visibility-rules-with-roslyn/

### Changes from original roslyn

* Change the names of the packages `Microsoft.*` to `OpenSesame.*`
* Allow unsafe code automatically (for .Net Framework)
* With `MetadataImportOptions.All` for compilation options
* With `BinderFlags.IgnoreAccessibility` for compilation options
* Inject `IgnoresAccessChecksToAttribute` automatically

### Supported frameworks

* .Net Framework 4.7 or later
* .Net Core 2.0 or later
* .Net Standard 2.0 or later
* Unity 2018.3 or later

<br><br><br><br>

## Packages

| Package Name                         | Original Package                    | Version | Downloads |
| ------------------------------------ | ----------------------------------- | ------- | --------- |
| [OpenSesame.Net.Compilers.Toolset][] | [Microsoft.Net.Compilers.Toolset][] | ![V1][] | ![D1][]   |
| [OpenSesame.Net.Compilers][]         | [Microsoft.Net.Compilers][]         | ![V2][] | ![D2][]   |
| [OpenSesame.NetCore.Compilers][]     | [Microsoft.NetCore.Compilers][]     | ![V3][] | ![D3][]   |

[OpenSesame.Net.Compilers.Toolset]: https://www.nuget.org/packages/OpenSesame.Net.Compilers.Toolset
[Microsoft.Net.Compilers.Toolset]: https://www.nuget.org/packages/Microsoft.Net.Compilers.Toolset
[V1]: https://img.shields.io/nuget/v/OpenSesame.Net.Compilers.Toolset
[D1]: https://img.shields.io/nuget/dt/OpenSesame.Net.Compilers.Toolset
[MV1]: https://img.shields.io/nuget/v/Microsoft.Net.Compilers.Toolset

[OpenSesame.Net.Compilers]: https://www.nuget.org/packages/OpenSesame.Net.Compilers
[Microsoft.Net.Compilers]: https://www.nuget.org/packages/Microsoft.Net.Compilers
[V2]: https://img.shields.io/nuget/v/OpenSesame.Net.Compilers
[D2]: https://img.shields.io/nuget/dt/OpenSesame.Net.Compilers

[OpenSesame.NetCore.Compilers]: https://www.nuget.org/packages/OpenSesame.NetCore.Compilers
[Microsoft.NetCore.Compilers]: https://www.nuget.org/packages/Microsoft.NetCore.Compilers
[V3]: https://img.shields.io/nuget/v/OpenSesame.NetCore.Compilers
[D3]: https://img.shields.io/nuget/dt/OpenSesame.NetCore.Compilers

<br><br><br><br>

## Usage

### For C# project (.Net Framework)

For a C# project (`*.csproj`), you can install the Toolset package to change the compiler to be used at build time.

1. Install the nuget package [OpenSesame.Net.Compilers.Toolset][] to the project.
2. The accessibility of all symbols (types, methods, properties, etc.) will be ignored.

### For C# project (.Net Core or .Net Standard)

For a C# project (`*.csproj`), you can install the Toolset package to change the compiler to be used at build time.

1. Install the nuget package [OpenSesame.Net.Compilers.Toolset][] to the project.
2. Adddd the following somewhere in your code:
```cs
[assembly: System.Runtime.CompilerServices.IgnoresAccessChecksTo("<TargetAssemblyName>")]
```
3. The accessibility of the symbols (types, methods, properties, etc.) contained in the `<TargetAssemblyName>` will be ignored.

### For Unity

Use a unity package [com.coffee.open-sesame-compiler](https://github.com/mob-sakai/OpenSesameCompilerForUnity).

<br><br><br><br>

## Unsupported Features

### Set/get value into readonly field

Use reflection

### IDE support

Use Csc-Manager to modify your VisualStudio Code and C# extension.
- csc-manager enable-vscode: Show internals/privates in other assembly.
- csc-manager disable-vscode: Hide them.

<br><br><br><br>

## Develop

### Update Roslyn version

| OpenSesame | Roslyn   |
| ---------- | -------- |
| ![V1][]    | ![MV1][] |

If a new stable version of the Rosly package has been released, please update Roslyn.

[Create an issue using the Roslyn update request issue template][issue_template]

[issue_template]: https://github.com/mob-sakai/OpenSesame/issues/new?assignees=mob-sakai&template=update_roslyn.md&title=Request+to+update+roslyn%3A+%7Bversion%7D

### Run Tests

```
./tool.sh --pack --run-tests
```

### Release

When push to `beta` or `master` branch, this package is automatically released by GitHub Action.

* Update version of the package
* Update and push CHANGELOG.md
* Create version tag
* Release on GitHub
* Publish to nuget registory

Alternatively, release it manually with the following command:

```bash
$ node run release -- --no-ci
```