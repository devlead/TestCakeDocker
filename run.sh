#!/usr/bin/env bash
docker run --rm -it -v "$(pwd)/src:/src" -w /src cakebuild/cake:2.1-sdk Cake