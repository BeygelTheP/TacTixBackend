# https://hub.docker.com/_/microsoft-dotnet
# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /source
WORKDIR /source
RUN pwd

# copy csproj and restore as distinct layers
#COPY aspnetapp/*.csproj ./aspnetapp/
#RUN dotnet restore
COPY src/TacTix.WebApi/. ./TacTix.WebApi
RUN pwd; ls
RUN dotnet restore ./TacTix.WebApi

WORKDIR /source/TacTix.WebApi
RUN pwd; ls
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "TacTix.WebApi.dll"]
