#!/bin/bash

cd `dirname $0`

usage()
{
  echo "[OpenSesame Development Tool]"
  echo "Common settings:"
  echo "  --version <value>  Package version. (Default: The value in 'roslyn/eng/Versions.props')"
  echo "  --token <value>    Nuget api key to publish. (Default: Environment variable 'NUGET_TOKEN')"
  echo ""
  echo "Actions:"
  echo "  --pack             Generate the packages."
  echo "  --run-tests        Run tests."
  echo "  --publish          Publish the packages. (token required.)"
  echo "  --help             Print help and exit."
}

pack=false
run_tests=false
publish=false
version=""
token="${NUGET_TOKEN}"

while [[ $# > 0 ]]; do
  opt="$(echo "$1" | awk '{print tolower($0)}')"
  case "$opt" in
    --help|-h)
      usage
      exit 0
      ;;
    --version)
      version=$2
      args="$args $1"
      shift
      ;;
    --token)
      token=$2
      args="$args $1"
      shift
      ;;
    --pack)
      pack=true
      ;;
    --run-tests)
      run_tests=true
      ;;
    --publish)
      publish=true
      ;;
    *)
      echo "Invalid argument: $1"
      usage
      exit 1
      ;;
  esac
  args="$args $1"
  shift
done

if [ $pack == false ] && [ $run_tests == false ] && ( [ $publish == false ] || [ -z "$token" ] ); then
  usage
  exit 1
fi

if [ -z "${version}" ]; then
  major=`grep '<MajorVersion>.*</MajorVersion>' roslyn/eng/Versions.props | awk '-F[<>]' '{print $3}'`
  minor=`grep '<MinorVersion>.*</MinorVersion>' roslyn/eng/Versions.props | awk '-F[<>]' '{print $3}'`
  patch=`grep '<PatchVersion>.*</PatchVersion>' roslyn/eng/Versions.props | awk '-F[<>]' '{print $3}'`
  version=${major}.${minor}.${patch}
fi

if [ $pack == true ]; then
  echo -e "\n\n>>>> Start pack: version=${version}\n"
  roslyn/build.sh --pack -r -c Release /p:PackageVersion=${version} /p:SemanticVersioningV1=false
fi

if [ $run_tests == true ]; then
  dotnet clean ./Tests/PrivateLibrary.Tests
  dotnet clean ./Tests/PrivateLibrary.Bridge
  dotnet clean ./Tests/PrivateLibrary.Console

  echo -e "\n\n>>>> Update toolset: version=${version}\n"
  dotnet add ./Tests/PrivateLibrary.Tests package OpenSesame.Net.Compilers.Toolset -v ${version}
  dotnet add ./Tests/PrivateLibrary.Bridge package OpenSesame.Net.Compilers.Toolset -v ${version}
  dotnet add ./Tests/PrivateLibrary.Console package OpenSesame.Net.Compilers.Toolset -v ${version}

  echo -e "\n\n>>>> Start tests: version=${version}\n"
  dotnet test ./Tests

  echo -e "\n\n>>>> Build runtime tests (Release): version=${version}\n"
  dotnet build ./Tests/PrivateLibrary.Console -c Release

  echo -e "\n\n>>>> Start runtime tests (Release): version=${version}\n"
  frameworks=`grep '<TargetFrameworks>.*</TargetFrameworks>' ./Tests/PrivateLibrary.Console/PrivateLibrary.Console.csproj | awk '-F[<>]' '{print $3}' | tr ';' ' '`
  for fw in `echo ${frameworks}`; do
    echo "  >> Runtime test [${fw}]"
    EXE=./Tests/PrivateLibrary.Console/bin/Release/${fw}/PrivateLibrary.Console
    if [ `echo ${fw} | grep 'netstandard'` ]; then
      echo "    skipped: ${fw}"
    elif [ -e ${EXE}.exe ]; then
      mono ${EXE}.exe
      [ "$?" != 0 ] && exit 1
    elif [ -e ${EXE}.dll ]; then
      dotnet ${EXE}.dll
      [ "$?" != 0 ] && exit 1
    else
      echo "    skipped: ${fw}"
    fi
  done
fi

if [ $publish == true ]; then
  packages=( \
    OpenSesame.Net.Compilers.Toolset \
    OpenSesame.Net.Compilers \
    OpenSesame.NETCore.Compilers \
  )

  for p in ${packages[@]}; do
    echo -e "\n\n>>>> Start Pablish: version=${p}.${version}\n"

    dotnet nuget push roslyn/artifacts/packages/Release/Shipping/${p}.${version}.nupkg \
      -k ${token} -s https://api.nuget.org/v3/index.json --skip-duplicate
  done
fi
