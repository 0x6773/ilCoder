#!/bin/zsh

set -x

set -e

xbuild

echo "\n"

ilCoder/bin/Debug/ilCoder.exe $@
