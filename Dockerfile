FROM gitpod/workspace-full

USER root

# Install .NET Core 5.0 SDK binaries on Ubuntu 20.04
# Source: https://docs.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#scripted-install
RUN mkdir -p /home/gitpod/dotnet && curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel Current --install-dir /home/gitpod/dotnet
ENV DOTNET_ROOT=/home/gitpod/dotnet
ENV PATH=$PATH:/home/gitpod/dotnet