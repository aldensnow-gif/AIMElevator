## Architecture Notes

This API uses a **contract-first, composition-based architecture**.

### Composition over Inheritance

The `AIMElevator.Api` project does **not** define controllers directly.
Instead, it composes the API surface by referencing the generated project:

- **Generated API surface:** `AIMElevator.Generated`
- **Runtime host & implementation:** `AIMElevator.Api`

Controllers, routes, and DTOs are generated from the OpenAPI contract
and live in the generated project. The API project hosts ASP.NET Core,
configures middleware and dependency injection, and provides the
implementation behind the generated endpoints.

This approach favors **composition over inheritance**:
- Generated code is isolated and replaceable
- Business logic is owned by the API project
- Regenerating the API does not overwrite handwritten code

### Project Reference

The API project references the generated project directly:

```text
AIMElevator.Api → AIMElevator.Generated
