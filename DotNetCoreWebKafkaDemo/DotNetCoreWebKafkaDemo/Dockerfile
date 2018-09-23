#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 58395
EXPOSE 44372

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DotNetCoreWebKafkaDemo/DotNetCoreWebKafkaDemo.csproj", "DotNetCoreWebKafkaDemo/"]
RUN dotnet restore "DotNetCoreWebKafkaDemo/DotNetCoreWebKafkaDemo.csproj"
COPY . .
WORKDIR "/src/DotNetCoreWebKafkaDemo"
RUN dotnet build "DotNetCoreWebKafkaDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DotNetCoreWebKafkaDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DotNetCoreWebKafkaDemo.dll"]