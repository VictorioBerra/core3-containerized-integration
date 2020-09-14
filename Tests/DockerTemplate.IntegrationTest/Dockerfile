# /Dockerfile.integration
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS sdk
# To use the debug build configuration pass --build-arg Configuration=Debug
ARG Configuration=Release
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true

WORKDIR /test
COPY "DockerTemplate.sln" "."
COPY "Source/DockerTemplate/*.csproj" "Source/DockerTemplate/"
COPY "Tests/DockerTemplate.IntegrationTest/*.csproj" "Tests/DockerTemplate.IntegrationTest/"
RUN dotnet restore
COPY . .
RUN dotnet build --configuration $Configuration --no-restore
RUN apk --no-cache add curl bash
RUN curl https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh > wait_for_it.sh
RUN ["chmod", "+x", "wait_for_it.sh"]
# The caller will need to pass --configuration=Release to get this to work
ENTRYPOINT ["dotnet", "test", "--no-build"]
