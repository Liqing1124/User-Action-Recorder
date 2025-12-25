using SharpHook;
using SharpHook.Native;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CopyUserAction;

public class RecorderService : IDisposable
{
    private TaskPoolGlobalHook? _hook;
    private readonly List<UserAction> _actions = new();
    private readonly Stopwatch _stopwatch = new();
    private bool _isRecording = false;

    public RecorderService()
    {
    }

    public void Start()
    {
        if (_isRecording) return;

        _actions.Clear();
        _stopwatch.Restart();
        _isRecording = true;

        var hook = new TaskPoolGlobalHook();
        hook.MouseMoved += OnMouseMoved;
        hook.MousePressed += OnMousePressed;
        hook.MouseReleased += OnMouseReleased;
        hook.MouseWheel += OnMouseWheel;
        hook.KeyPressed += OnKeyPressed;
        hook.KeyReleased += OnKeyReleased;

        _hook = hook;
        hook.RunAsync();
    }

    public List<UserAction> Stop()
    {
        _isRecording = false;
        _stopwatch.Stop();

        _hook?.Dispose();
        _hook = null;

        return new List<UserAction>(_actions);
    }

    private void OnMouseMoved(object? sender, MouseHookEventArgs e)
    {
        if (!_isRecording) return;
        _actions.Add(new UserAction
        {
            Type = ActionType.MouseMove,
            Timestamp = _stopwatch.ElapsedMilliseconds,
            X = e.Data.X,
            Y = e.Data.Y
        });
    }

    private void OnMousePressed(object? sender, MouseHookEventArgs e)
    {
        if (!_isRecording) return;
        _actions.Add(new UserAction
        {
            Type = ActionType.MouseDown,
            Timestamp = _stopwatch.ElapsedMilliseconds,
            X = e.Data.X,
            Y = e.Data.Y,
            MouseButton = e.Data.Button
        });
    }

    private void OnMouseReleased(object? sender, MouseHookEventArgs e)
    {
        if (!_isRecording) return;
        _actions.Add(new UserAction
        {
            Type = ActionType.MouseUp,
            Timestamp = _stopwatch.ElapsedMilliseconds,
            X = e.Data.X,
            Y = e.Data.Y,
            MouseButton = e.Data.Button
        });
    }

    private void OnMouseWheel(object? sender, MouseWheelHookEventArgs e)
    {
        if (!_isRecording) return;
        _actions.Add(new UserAction
        {
            Type = ActionType.MouseWheel,
            Timestamp = _stopwatch.ElapsedMilliseconds,
            X = e.Data.X,
            Y = e.Data.Y,
            WheelDelta = e.Data.Rotation
        });
    }

    private void OnKeyPressed(object? sender, KeyboardHookEventArgs e)
    {
        if (!_isRecording) return;
        _actions.Add(new UserAction
        {
            Type = ActionType.KeyDown,
            Timestamp = _stopwatch.ElapsedMilliseconds,
            KeyCode = e.Data.KeyCode
        });
    }

    private void OnKeyReleased(object? sender, KeyboardHookEventArgs e)
    {
        if (!_isRecording) return;
        _actions.Add(new UserAction
        {
            Type = ActionType.KeyUp,
            Timestamp = _stopwatch.ElapsedMilliseconds,
            KeyCode = e.Data.KeyCode
        });
    }

    public void Dispose()
    {
        _hook?.Dispose();
    }
}
