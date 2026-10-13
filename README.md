# Relaydesk

**Relaydesk is a consent-first Windows desktop foundation for transparent remote-support workflows.** It is an original clean-room Magnexis project; it contains no proprietary protocol, third-party code, recovered implementation material, or copied product assets.

## What v1.2.0 does

- Creates a local-only six-digit pairing code with a visible 60-second expiry.
- Models separate view and input consent states.
- Shows exactly which capabilities are granted.
- Persists a local consent timeline across restarts.

It deliberately does **not** connect to devices, capture displays, inject input, access clipboard data, transfer files, or provide unattended access.

## Install and run

Download the Windows x64 ZIP from [Releases](../../releases), extract it, and run `Relaydesk.exe`. The .NET 10 Desktop Runtime is required. Developers can instead follow [RUNNING.md](RUNNING.md).

## Safety baseline

| Area | Current behavior |
|---|---|
| Pairing | Locally generated only; expires after 60 seconds |
| Capabilities | View and input are independent, visible choices |
| Remote access | Not implemented |
| Audit | Local timeline only |
| Telemetry | None |

## Documentation

- [Architecture](docs/ARCHITECTURE.md)
- [Threat model](THREAT_MODEL.md)
- [Security policy](SECURITY.md)
- [Test plan](docs/TEST_PLAN.md)
- [Roadmap](ROADMAP.md)
- [Release notes](docs/releases/1.2.0.md)
- [Media-capture checklist](docs/MEDIA.md)
- [Contributing](CONTRIBUTING.md)

## Media

We will only add screenshots, GIFs, and video recorded from a runnable build. [docs/MEDIA.md](docs/MEDIA.md) defines the required capture set and prevents illustrative mockups from being mislabeled as product behavior.

