using System;
using SharpHook.Native;

namespace CopyUserAction;

public enum ActionType
{
    MouseMove,
    MouseDown,
    MouseUp,
    MouseWheel,
    KeyDown,
    KeyUp
}

public class UserAction
{
    public ActionType Type { get; set; }
    public long Timestamp { get; set; }

    // Mouse specific
    public short X { get; set; }
    public short Y { get; set; }
    public MouseButton MouseButton { get; set; }
    public short WheelDelta { get; set; }

    // Keyboard specific
    public KeyCode KeyCode { get; set; }
}
