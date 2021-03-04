using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface IToolbarItem : IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// Do not modify this property directly. Use <see cref="Toolbar.ActivateItem(IToolbarItem)"/> and <see cref="Toolbar.DeactivateItem(IToolbarItem)"/> instead.
    /// </summary>
    bool IsActive { get; set; }
    GameObject GameObject { get; }
    Image Background { get; set; }
    ToolMode ToolMode { get; }
    void Activate();
    void Deactivate();
}
