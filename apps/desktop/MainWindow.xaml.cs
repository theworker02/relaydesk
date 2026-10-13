using System;
using System.Windows;
namespace Relaydesk;
public partial class MainWindow : Window {
  public MainWindow() { InitializeComponent(); Add("Idle: no remote connection exists."); }
  private void Pair_Click(object sender, RoutedEventArgs e) { PairCode.Text = Random.Shared.Next(100000, 999999).ToString(); ViewConsent.IsChecked = false; InputConsent.IsChecked = false; InputConsent.IsEnabled = false; Status.Text = "Pairing code created locally. It is not transmitted by this MVP."; Add("Pairing code created."); }
  private void ConsentChanged(object sender, RoutedEventArgs e) { InputConsent.IsEnabled = ViewConsent.IsChecked == true; if (!InputConsent.IsEnabled) InputConsent.IsChecked = false; Add($"Consent changed: view={ViewConsent.IsChecked == true}; input={InputConsent.IsChecked == true}"); Status.Text = "Consent state updated locally."; }
  private void End_Click(object sender, RoutedEventArgs e) { ViewConsent.IsChecked = false; InputConsent.IsChecked = false; InputConsent.IsEnabled = false; PairCode.Text = ""; Add("Session ended by local user."); Status.Text = "Ended — no remote connection exists."; }
  private void Add(string message) { Timeline.Text += $"{DateTimeOffset.Now:HH:mm:ss} {message}{Environment.NewLine}"; Timeline.ScrollToEnd(); }
}
