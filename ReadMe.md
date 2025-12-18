## Regenerating API Controllers

The API controllers in `AIMElevator.generated` are generated from the OpenAPI
contract located at `contract/openapi.yaml`.

You only need to regenerate if you change the OpenAPI contract.

## API Contract & Code Generation

The API controllers are generated from the OpenAPI contract.

- Contract: [`contract/openapi.yaml`](./contract/openapi.yaml)
- Generated output: `AIMElevator.Generated`
- Regeneration script: [`regen.ps1`](./regen.ps1)

> Most developers do **not** need to regenerate controllers.
> Only run the regeneration script if you modify the OpenAPI contract.
### Regenerate (requires OpenAPI Generator)
```powershell 
openapi-generator generate `
  -i contract/openapi.yaml `
  -g aspnetcore `
  -o AIMElevator.generated `
  --additional-properties=aspnetCoreVersion=8.0

## Requirements

### To build and run the API
- .NET 8 SDK

### To regenerate API controllers (only if changing the contract)
Choose ONE:
- Docker
- OpenAPI Generator (.NET global tool)