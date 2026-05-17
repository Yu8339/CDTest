# 1. 編譯階段 (SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 複製專案檔並進行還原
COPY ["CDTest/CDTest.csproj", "CDTest/"]
COPY ["CDTestLib/CDTestLib.csproj", "CDTestLib/"]
RUN dotnet restore "CDTest/CDTest.csproj"

# 複製所有程式碼並發布
COPY . .
WORKDIR "/src/CDTest"
RUN dotnet publish -c Release -o /app/publish

# 2. 執行階段 (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CDTest.dll"]