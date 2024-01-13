# powershell and .Net core SDK/runtime is required in base image
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2022
WORKDIR /source

# copy csproj and restore as distinct layers
COPY MyWebApp.csproj .
RUN dotnet restore --use-current-runtime

# copy everything else and build app
COPY . .
RUN dotnet publish --use-current-runtime --self-contained false --no-restore -o /app
WORKDIR /app

# Download the New Relic .NET agent installer
RUN powershell.exe [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12;\
 Invoke-WebRequest "https://download.newrelic.com/dot_net_agent/latest_release/NewRelicDotNetAgent_x64.msi"\
 -UseBasicParsing -OutFile "NewRelicDotNetAgent_x64.msi"

# Install the New Relic .NET agent
RUN powershell.exe Start-Process -Wait -FilePath msiexec -ArgumentList /i, "NewRelicDotNetAgent_x64.msi", /qn,\
 NR_LICENSE_KEY=9c9394c1c8a57601f1dec8ae0fe7d135FFFFNRAL

# Remove the New Relic .NET agent installer
RUN powershell.exe -c 'Remove-Item "NewRelicDotNetAgent_x64.msi"'

# Enable the agent
ENV CORECLR_ENABLE_PROFILING=1
# Set your application name
ENV NEW_RELIC_APP_NAME="MyWebApp"

# RUN your app with dotnet
ENTRYPOINT ["dotnet", ".\\MyWebApp.dll"]