# Relaydesk

Relaydesk is an open, clean-room architecture for a local-first remote-support desktop application.

It is an original design for a consent-first remote-support product. It contains no proprietary remote-control protocol, third-party code, branding, assets, or recovered implementation material.

## Start here

- [Core architecture](docs/ARCHITECTURE.md)
- [Android-first, no-store distribution](docs/ANDROID_DISTRIBUTION.md)
- [Threat model](THREAT_MODEL.md)
- [Security policy](SECURITY.md)
- [Roadmap](ROADMAP.md)
- [Test plan](docs/TEST_PLAN.md)
- [Initial TypeScript protocol contracts](packages/protocol/README.md)
- [Contributing](CONTRIBUTING.md)

## Product principles

- Visible consent and immediate disconnect on both sides
- Unprivileged UI with a minimal host service
- Direct LAN path first; relay fallback second
- Local audit trail and no telemetry by default
- Open, versioned protocol designed independently

## Status

Implementation-ready foundation. No remote-control implementation has been published yet.
