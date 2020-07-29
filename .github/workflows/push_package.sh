#!/bin/bash -ex

VERSION=$1
[ -z "${VERSION}" ] && exit
[ -z "${NUGET_TOKEN}" ] && exit

PACKAGE_DIR=roslyn/artifacts/packages/Release/Shipping
PACKAGES=( \
  OpenSesame.Net.Compilers.Toolset \
  OpenSesame.Net.Compilers \
  OpenSesame.NETCore.Compilers \
)

for p in ${PACKAGES[@]}; do
    dotnet nuget push ${PACKAGE_DIR}/${p}.${VERSION}.nupkg -k ${NUGET_TOKEN} -s https://api.nuget.org/v3/index.json --skip-duplicate
done
