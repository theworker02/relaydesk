# Core architecture

## Process model

```text
Relaydesk Desktop UI (unprivileged)
  ├── pairing, session controls, permissions, event timeline
  └── typed local IPC only

Relaydesk Host Service (least privilege)
  ├── screen-capture adapter
  ├── explicitly enabled input adapter
  ├── optional folder-scoped file transfer
  ├── transport supervisor
  └── append-only audit writer

Transport adapters
  ├── direct LAN
  ├── direct WAN
  └── QUIC relay fallback
```

## Session state machine

```text
idle → pairing → consent-pending → negotiating → active → ending → closed
                      │                 │
                      └── denied        └── failed
```

Capability changes—input, clipboard, audio, or file transfer—are separate events during an active session and require independent consent.

## Original protocol contract

Use a public, versioned QUIC protocol with mutually authenticated ephemeral keys. Keep control messages separate from media frames.

```text
Handshake { protocolVersion, ephemeralPublicKey, deviceClaim }
ConsentRequest { sessionId, requestedCapabilities, viewerIdentity }
ConsentDecision { accepted, grantedCapabilities, expiry }
RouteSelection { route, candidates }
DisplayFrame { displayId, sequence, timestamp, encodedPayload }
InputEvent { sequence, kind, coordinatesOrKey, capabilityProof }
CapabilityUpdate { addOrRemove, capability, reason }
SessionEnd { reason, actor }
```

Design for replay protection, monotonic sequence numbers, explicit capability proofs, and a signed transcript.

## Permission defaults

| Capability | Default |
|---|---|
| View screen | Ask each session |
| Control mouse/keyboard | Off |
| Clipboard | Off |
| File transfer | Off |
| Audio | Off |
| Unattended access | Off |

## MVP acceptance criteria

1. Pair two user-owned Windows devices with a short-lived code.
2. Require explicit host approval to view a screen.
3. Require a separate approval for input.
4. Let either side end the session immediately.
5. Visibly label LAN versus relay routing.
6. Persist a local, secret-free audit timeline.
