namespace Mc2.CrudTest.Client.Web.Components;

public partial class MessageBox :AppComponentBase, IDisposable
{
    private static event Func<string, string, bool, Task<bool>> OnShow = default!;
    private bool _disposed;

    public static async Task<bool> Show(string message, string title = "", bool isConfirm = false)
    {
        return await OnShow.Invoke(message, title, isConfirm);
    }

    protected override void OnInitialized()
    {
        OnShow += ShowMessageBox;

        base.OnInitialized();
    }

    private TaskCompletionSource<bool>? _tsc;

    private async Task<bool> ShowMessageBox(string message, string title, bool isConfirm)
    {
        _tsc = new TaskCompletionSource<bool>();

        await InvokeAsync(() =>
        {
            IsOpen = true;

            Title = title;

            _isConfirm = isConfirm;

            Body = message;

            StateHasChanged();
        });

        return await _tsc.Task;
    }

    // ========================================================================

    private bool IsOpen { get; set; }
    private string Title { get; set; } = string.Empty;
    private string Body { get; set; } = string.Empty;
    private bool _isConfirm = false;

    private void OnCloseClick()
    {
        IsOpen = false;
    }

    private void Confirm(bool value)
    {
        IsOpen = false;
        _tsc?.SetResult(value);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed || disposing is false) return;

        OnShow -= ShowMessageBox;

        _disposed = true;
    }
}
