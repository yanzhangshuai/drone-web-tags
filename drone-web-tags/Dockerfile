FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish
WORKDIR /src
COPY . ./
RUN dotnet publish ./drone-web-tags/drone-web-tags.csproj -c release --self-contained true -p:PublishSingleFile=true -p:EnableCompressionInSingleFile=true -p:PublishTrimmed=true -r linux-musl-x64  -o /app/publish

FROM alpine:latest
RUN apk add --no-cache openssl ncurses-libs libstdc++
COPY --from=publish /app/publish /app
ENV ASPNETCORE_URLS="http://*:80"
EXPOSE 80
ENTRYPOINT ["/app/drone-web-tags"]