/** Original protocol message shapes; transport and cryptography are intentionally not implemented here. */
export type Capability = "view" | "input" | "clipboard" | "files" | "audio";

export interface ConsentRequest {
  sessionId: string;
  requestedCapabilities: Capability[];
  viewerIdentity: string;
}

export interface ConsentDecision {
  accepted: boolean;
  grantedCapabilities: Capability[];
  expiresAt: string;
}

export interface InputEvent {
  sequence: number;
  kind: "pointer" | "key";
  capabilityProof: string;
}

export function mayControl(granted: Capability[]): boolean {
  return granted.includes("input");
}
