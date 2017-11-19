// by wangjianhong
using Entitas;
using System.Collections.Generic;

[Pool]
public class ControllerListComponent : IComponent
{
    public IList<Controller> Controllers;
}
