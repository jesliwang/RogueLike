using Entitas;
using UnityEngine;

[Core]
public sealed class LogComponent : IComponent
{
    public LogType type;
    public string logInfo;
}
