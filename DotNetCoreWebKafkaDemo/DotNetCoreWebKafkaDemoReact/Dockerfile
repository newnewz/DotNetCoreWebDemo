FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 54770
EXPOSE 44328

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DotNetCoreWebKafkaDemoReact/DotNetCoreWebKafkaDemoReact.csproj", "DotNetCoreWebKafkaDemoReact/"]
RUN dotnet restore "DotNetCoreWebKafkaDemoReact/DotNetCoreWebKafkaDemoReact.csproj"
COPY . .
WORKDIR "/src/DotNetCoreWebKafkaDemoReact"
RUN dotnet build "DotNetCoreWebKafkaDemoReact.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DotNetCoreWebKafkaDemoReact.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DotNetCoreWebKafkaDemoReact.dll"]