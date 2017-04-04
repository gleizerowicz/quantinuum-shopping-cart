
#Linux=FROM microsoft/aspnetcore:1.0.1
FROM microsoft/dotnet:nanoserver

#LABEL Name=quantinuum-shopping-cart Version=0.0.1 

ARG source=.
WORKDIR /app
ENV ASPNETCORE_URLS "http://+:8000;http://+:8001;http://+:8002" 
COPY $source .
EXPOSE 8000 8001 8002

RUN dotnet restore
ENTRYPOINT ["dotnet", "run"]
#ENTRYPOINT ["dotnet", "NancyTemplate.dll"]