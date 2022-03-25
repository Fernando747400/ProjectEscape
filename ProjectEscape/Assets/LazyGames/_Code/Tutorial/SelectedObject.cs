using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using Lean.Common;

public class SelectedObject : MonoBehaviour
{
    public void SetSelectable()
    {
        LeanSelectable lean = this.GetComponent<LeanSelectable>();
        lean.IsSelected = true;
    }
}
