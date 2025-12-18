docker run --rm `
  -v "${PWD}:/local" `
  openapitools/openapi-generator-cli:v7.5.0 generate `
  -i local/contract/openapi.yaml `
 -g aspnetcore `
 -o local/AIMElevator.generated `
 --additional-properties=aspnetCoreVersion=6.0