# Cake docker example

This is an example repository of building a .NET Core project using a container with Cake and .NET Core SDK pre-installed. Which means the host doesn't need to have neither Cake or .NET Core installed to be able to execute script and build project.

## Usage

### MacOS / Linux

```bash
./run.sh
```

### Windows

```batch
run.cmd
``` 

## Cake Pre-Installed

So what does Cake pre-installed mean? It means the `Cake` tool is in the container image and available in path, so you could use it either as part of your own custom image or by using docker run.