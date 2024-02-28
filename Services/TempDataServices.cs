namespace InventoryManagement.Services;

public class TempDataService
{
  private string? message;
  private Timer? resetTimer;

  public event Action? OnTempDataChanged;

  public void SetTempData(string message)
  {
    this.message = message;
    NotifyStateChanged();

    // Start or restart the reset timer
    if (resetTimer != null)
    {
      resetTimer.Dispose();
    }
    resetTimer = new Timer(_ =>
    {
      ResetTempData();
    }, null, 1000, Timeout.Infinite);
  }

  public string? GetTempData()
  {
    return message;
  }

  private void ResetTempData()
  {
    message = null; // Clear TempData
    NotifyStateChanged();
  }

  private void NotifyStateChanged() => OnTempDataChanged?.Invoke();
}
