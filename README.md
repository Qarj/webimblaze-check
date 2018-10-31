# webimblaze-check
Website for WebImblaze to run self tests against. Also to provide examples for WebImblaze automated tests.

See http://webimblaze-check.azurewebsites.net/

## FAQ
- https://stackoverflow.com/questions/47349608/how-to-fix-microsoft-netcore-app-version-1-1-2-was-not-found

Manual create SQL
```
cd C:\git\webimblaze-check\webimblaze-check
dotnet ef migrations script --idempotent --context webimblazecheckContext --verbose
```