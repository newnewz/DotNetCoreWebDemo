FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 62959
EXPOSE 44367

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["KafkaConsumerWeb/KafkaConsumerWeb.csproj", "KafkaConsumerWeb/"]
RUN dotnet restore "KafkaConsumerWeb/KafkaConsumerWeb.csproj"
COPY . .
WORKDIR "/src/KafkaConsumerWeb"
RUN dotnet build "KafkaConsumerWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KafkaConsumerWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KafkaConsumerWeb.dll"]