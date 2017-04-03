
#Linux=FROM microsoft/aspnetcore:1.0.1
FROM microsoft/dotnet:nanoserver

LABEL Name=quantinuum-shopping-cart Version=0.0.1 

ARG source=.
WORKDIR /app
ENV ASPNETCORE_URLS http://+:3000
COPY $source .
EXPOSE 3000

RUN dotnet restore
ENTRYPOINT ["dotnet", "run"]
#ENTRYPOINT ["dotnet", "NancyTemplate.dll"]