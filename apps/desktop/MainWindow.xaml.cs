using System;
using System.Windows;
using System.Windows.Threading;
namespace Relaydesk;
public partial class MainWindow : Window {
  private readonly string auditFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Magnexis", "Relaydesk", "timeline.log");
  private readonly DispatcherTimer expiryTimer = new() { Interval = TimeSpan.FromSeconds(1) };
  private int secondsRemaining;
  public MainWindow() { InitializeComponent(); System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(auditFile)!); Timeline.Text = System.IO.File.Exists(auditFile) ? System.IO.File.ReadAllText(auditFile) : ""; expiryTimer.Tick += ExpiryTimer_Tick; Add("Idle: no remote connection exists."); }
  private void Pair_Click(object sender, RoutedEventArgs e) { PairCode.Text = Random.Shared.Next(100000, 999999).ToString(); secondsRemaining = 60; expiryTimer.Start(); ViewConsent.IsChecked = false; InputConsent.IsChecked = false; InputConsent.IsEnabled = false; UpdateCapabilities(); Status.Text = "Pairing code created locally. It is not transmitted by this MVP."; Add("Pairing code created (local only; expires in 60 seconds)."); }
  private void ConsentChanged(object sender, RoutedEventArgs e) { InputConsent.IsEnabled = ViewConsent.IsChecked == true; if (!InputConsent.IsEnabled) InputConsent.IsChecked = false; UpdateCapabilities(); Add($"Consent changed: view={ViewConsent.IsChecked == true}; input={InputConsent.IsChecked == true}"); Status.Text = "Consent state updated locally."; }
  private void End_Click(object sender, RoutedEventArgs e) { expiryTimer.Stop(); ViewConsent.IsChecked = false; InputConsent.IsChecked = false; InputConsent.IsEnabled = false; PairCode.Text = ""; CodeExpiry.Text = ""; UpdateCapabilities(); Add("Session ended by local user."); Status.Text = "Ended — no remote connection exists."; }
  private void ExpiryTimer_Tick(object? sender, EventArgs e) { secondsRemaining--; if (secondsRemaining <= 0) { expiryTimer.Stop(); PairCode.Text = ""; CodeExpiry.Text = "expired"; Add("Pairing code expired."); Status.Text = "Code expired — no remote connection exists."; return; } CodeExpiry.Text = $"expires in {secondsRemaining}s"; }
  private void UpdateCapabilities() { CapabilitySummary.Text = $"Granted capabilities: {(ViewConsent.IsChecked == true ? "view" : "none")}{(InputConsent.IsChecked == true ? ", input" : "")}"; }
  private void Add(string message) { var line = $"{DateTimeOffset.Now:O} {message}"; System.IO.File.AppendAllText(auditFile, line + Environment.NewLine); Timeline.Text = System.IO.File.ReadAllText(auditFile); Timeline.ScrollToEnd(); }
}
