# Changelog

## [26.5.10] - 2026-07-28

- Regenerated against Apigen.Generator 2.4.0.
- Project files now use `<TargetFrameworks>` instead of `<TargetFramework>`, guarded by a condition so a repo-level `src/Directory.Build.props` can override it. No functional change: the client still targets `net10.0` only and build output is unchanged. See the [target framework policy](https://github.com/apigen-dotnet/generator/blob/main/docs/target-framework-policy.md).

## [26.5.9] - 2026-05-13

- Regenerated against Apigen.Generator 2.3.0.
- All operations and interfaces now accept `CancellationToken cancellationToken = default` and propagate it through HTTP calls and content reads.
- Non-success responses now throw `ApiException` (inherits from `HttpRequestException`) exposing `StatusCode`, `Method`, `Url`, `ResponseBody`, `Headers`, and `ContentHeaders`. Existing `catch (HttpRequestException)` callers continue to work.
- Improved logging: distinct events for caller cancellation (Debug, 1004), `HttpClient.Timeout` (Error, 3002), transport failures (Error, 3003), and API errors (Error, 3001).

## [26.0.0] - 2026-03-23

- Initial open-source release
- Generated C# client for Keycloak Admin REST API
