FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://*:$PORT 

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["Date.csproj", "./"]
RUN dotnet restore "Date.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Date.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Date.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD dotnet Date.dll
