FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ExamSoft.Presentation/ExamSoft.Presentation.csproj", "ExamSoft.Presentation/"]
RUN dotnet restore "ExamSoft.Presentation/ExamSoft.Presentation.csproj"
COPY . .
WORKDIR "/src/ExamSoft.Presentation"
RUN dotnet build "ExamSoft.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExamSoft.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExamSoft.Presentation.dll"]
