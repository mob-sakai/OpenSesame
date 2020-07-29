#!/bin/bash -ex

# Get version from issue title.
VERSION=$1
[ -z "${VERSION}" ] && exit

# Find sha1 from nuget page.
SHA1=`curl -L https://www.nuget.org/packages/Microsoft.Net.Compilers.Toolset/${VERSION} \
    | grep https://github.com/dotnet/roslyn/commit/ \
    | sed -e 's/.*\([0-9a-f]\{40\}\).*$/\1/' \
    | head -n 1`

# Git settings.
git remote set-url origin https://${{ github.repository_owner }}:${{ github.token }}@github.com/${{ github.repository }}.git
git config --local user.name GitHub
git config --local user.email noreply@github.com

# Subtree merge from dotnet/roslyn.
[ -d roslyn ] && CMD=pull || CMD=add
git checkout -f roslyn
git subtree ${CMD} --prefix=roslyn --squash https://github.com/dotnet/roslyn.git ${SHA1} -m "Merge roslyn ${VERSION}" -m "https://github.com/dotnet/roslyn/commit/${SHA1}"
git push origin HEAD:roslyn

git config --local --unset user.name
git config --local --unset user.email
