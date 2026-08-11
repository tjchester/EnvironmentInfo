# EnvironmentInfo

A one-file console utility that dumps everything the .NET `Environment` class
knows about the machine it is running on — command line, current directory,
managed thread id, every environment variable, and every
`Environment.SpecialFolder` path.

Handy for answering "what does the runtime actually think `%PATH%` is here?" or
"where does `SpecialFolder.ApplicationData` resolve to on this box?", especially
inside a container or under a service account.

`PATH` gets special treatment: rather than printing one unreadable line, it is
split on the path separator and printed one entry per line.

Targets net8.0. No dependencies beyond the base class library.

## Running it

```sh
dotnet run --project EnvironmentInfo
```

Takes no arguments. Output goes to stdout, so redirect it if you want to diff
two machines:

```sh
dotnet run --project EnvironmentInfo > box-a.txt
```

## A note on output

It prints **every** environment variable, which on a developer machine can
include tokens, licence keys, and connection strings injected by other tooling.
Read what you captured before pasting it into an issue or sharing a log.

## License

MIT — see [LICENSE](LICENSE).
