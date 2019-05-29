FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY RavenSample.Web/RavenSample.Web.csproj RavenSample.Web/
RUN dotnet restore RavenSample.Web/RavenSample.Web.csproj
COPY . .
WORKDIR /src/RavenSample.Web
RUN dotnet build RavenSample.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish RavenSample.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RavenSample.Web.dll"]
