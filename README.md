Open Sesame
===

A custom [Roslyn](https://github.com/dotnet/roslyn) compiler **that allows access to internals/privates in other assemblies.**

![GitHub](https://img.shields.io/github/license/mob-sakai/OpenSesame)
![ci](https://github.com/mob-sakai/OpenSesame/workflows/Release/badge.svg)

## Changes from original roslyn

* Change the names of the packages
* Allow unsafe code automatically
* Add `MetadataImportOptions.All` to compilation options
* All public static methods in `AccessCheck.cs` will return `true`

## Packages

| PAckage Name                         | Original Package                    | Version | Downloads |
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

## Usage

### For .Net Framework



### For .Net Core

### For Unity

Use [OpenSesameCompilerForUnity]()


#### ~~How to run (demo)~~

1. ~~Clone [demo project]()~~
```sh
git clone demo-proj
cd demo-proj
```
2. ~~The compilation will fail because this project contains internals/privates access.~~
```sh
# The following command will fail.
dotnet run
```
```sh
```
3. ~~Install `OpenSesameCompiler` package to project from nuget~~
```sh
dotnet add OpenSesameCompiler
```
4. ~~Add `<CscToolPath>$(PkgOpenSesameCompiler)tools/csc.exe</CscToolPath>` to `PropertyGroup` in `demo.csproj`.~~  
~~Or, execute the following command.~~
```sh
dotnet run /p:CscToolPath=$(PkgOpenSesameCompiler)tools/csc.exe
```
5. ~~Enjoy!~~

## Develop

### Update Roslyn

| OpenSesame | Roslyn   |
| ---------- | -------- |
| ![V1][]    | ![MV1][] |

If a new stable version of the Rosly package has been released, please update Roslyn.

[Create an issue using the Roslyn update request issue template][issue_template]

[issue_template]: https://github.com/mob-sakai/OpenSesame/issues/new?assignees=mob-sakai&template=update_roslyn.md&title=Request+to+update+roslyn%3A+%7Bversion%7D

### Test

```
roslyn/build.sh --pack -r -c Release
dotnet test tests
```