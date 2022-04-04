using System.Collections;
using System.Collections.Generic;
using Lean.Common;
using Lean.Touch;
using UnityEngine;

public class SelectableItem : LeanSelectableBehaviour
{
    public LeanFingerFilter Use = new LeanFingerFilter(true);
    
#if UNITY_EDITOR
    protected virtual void Reset()
    {
        Use.UpdateRequiredSelectable(gameObject);
    }
#endif
}
