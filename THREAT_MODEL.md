# Threat model

## Assets

Screen pixels, input events, clipboard data, approved files, pairing credentials, identity keys, and session transcripts are sensitive.

## Primary threats and controls

| Threat | Control |
|---|---|
| Phishing a host into joining | Short-lived pairing codes, clear peer identity, explicit host approval |
| Capability escalation | Independent signed grants with expiry and visible state |
| Replay or injection | Ephemeral authenticated keys, monotonic sequences, transcript binding |
| Relay exposure | End-to-end encryption; relay handles encrypted frames only |
| Hidden persistence | No unattended access in MVP; visible active-session UI and local audit log |
| Malicious file transfer | Off by default; future transfer must be folder-scoped and require approval |

## Out of scope

No client can make a compromised endpoint safe. Relaydesk must communicate this plainly and avoid claims of perfect isolation.
