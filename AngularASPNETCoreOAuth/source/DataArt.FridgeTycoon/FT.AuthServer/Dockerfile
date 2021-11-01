#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /source

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["FT.AuthServer/FT.AuthServic.csproj", "FT.AuthServer/"]
RUN dotnet restore "FT.Identity/FT.AuthServer/FT.AuthServer.csproj"
COPY . .
WORKDIR "/source/DataArt.FridgeTycoon/FT.AuthServer"
RUN dotnet build "FT.AuthService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FT.AuthService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FT.AuthService.dll"]