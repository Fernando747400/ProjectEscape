using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogData : MonoBehaviour
{
  public List<MyDialog> Dialogs;
}

public class MyDialog
{
  public string sentence;
  public Image imageUI;
  public Sprite sprite;
}