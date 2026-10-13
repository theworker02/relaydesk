# Test plan

Every capability requires tests for: requested, denied, granted, revoked, expired, and peer disconnect states.

Critical integration tests:

1. Pair two local devices; a code cannot be reused after expiry.
2. Reject host consent; no display frame flows.
3. Grant viewing but deny input; injected events are discarded.
4. Revoke input mid-session; control stops immediately.
5. Drop transport; both endpoints render a terminal state and write audit events.
6. Verify relay routing sees encrypted payloads only in protocol fixtures.
