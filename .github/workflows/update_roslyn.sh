#!/bin/bash -ex

# Input roslyn sha1
SHA1=$1
[ -z "${SHA1}" ] && exit

# Subtree merge from dotnet/roslyn
[ -d roslyn ] && CMD=pull || CMD=add
git subtree ${CMD} --prefix=roslyn --squash https://github.com/dotnet/roslyn.git ${SHA1} -m "roslyn ${SHA1}"

# Get roslyn version
MAJOR=`grep "<MajorVersion>.*</MajorVersion>" roslyn/eng/Versions.props | awk  -F'[<>]' '{print $3}'`
MINOR=`grep "<MinorVersion>.*</MinorVersion>" roslyn/eng/Versions.props | awk  -F'[<>]' '{print $3}'`
PATCH=`grep "<PatchVersion>.*</PatchVersion>" roslyn/eng/Versions.props | awk  -F'[<>]' '{print $3}'`
VERSION="${MAJOR}.${MINOR}.${PATCH}"

# Amend
git commit --amend -m "Merge dotnet/roslyn v${VERSION}" -m "https://github.com/dotnet/roslyn"
