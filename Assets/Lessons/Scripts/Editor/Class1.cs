using UnityEditor;
using UnityEngine;
public class CustomEditroWindow : EditorWindow
{
    [MenuItem("Window/Custom Editor Window")]
    public static void ShowWindow()
    {
        GetWindow<CustomEditroWindow>();
    }
}