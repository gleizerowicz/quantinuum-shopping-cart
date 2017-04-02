
FROM microsoft/aspnetcore:1.0.1
LABEL Name=quantinuum-shopping-cart Version=0.0.1 
ARG source=.
WORKDIR /app
EXPOSE 3000
COPY $source .
ENTRYPOINT dotnet quantinuum-shopping-cart.dll
