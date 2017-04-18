FROM microsoft/dotnet:onbuild
WORKDIR /app
COPY PublishOutput  /app/
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
RUN dotnet restore
ENTRYPOINT ["dotnet","LoanService.dll"]