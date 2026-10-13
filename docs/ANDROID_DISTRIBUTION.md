# Android-first, no-store distribution

## Decision

Ship a signed universal APK from an HTTPS release page. The page is a setup assistant, not an installer: Android's system package installer must remain responsible for user approval.

## Release channels

1. **Public release page.** Host the APK, signed manifest, SHA-256, certificate fingerprint, and installation guide on GitHub Releases or static HTTPS hosting.
2. **Local-LAN setup portal.** The Windows desktop app can explicitly start a short-lived local pairing page and display a QR code with a one-time pairing nonce. The phone downloads the same signed APK after the user confirms the matching short code.

## Android scope

### v0.1: phone as desktop viewer/controller

- Pair by QR code.
- View the approved Windows desktop stream.
- Send phone gestures to the Windows host after host approval.
- End sessions from either device.

### v0.2: phone screen sharing, view-only

- Use Android MediaProjection with the OS consent prompt for every capture session.
- Use a foreground service and persistent active-session notification.
- Do not enable remote input on the phone.

## Security rules

- No silent APK installation or updates.
- One protected signing key; publish its fingerprint.
- Signed update manifest, then OS package installer approval.
- No broad Accessibility-service use for general remote control.
- No claim of equivalent iPhone distribution without a later Apple distribution decision.

## Future Android verification

Direct APK distribution avoids a Google Play listing, but Android developer verification is expected to expand globally in 2027 on certified devices. Keep package-name and signing-key registration as a planned administrative milestone; do not build a bypass.
