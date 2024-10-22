using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Lessons;

public class GraphPlotter : EditorWindow
{
    private List<float> values = new List<float>();
    private const int MaxPoints = 100;
    private float value= 0  ;
    [SerializeField] private MyScriptableObject inputData;

    [MenuItem("Window/Graph Plotter")]
    public static void ShowWindow()
    {
        GetWindow<GraphPlotter>("Graph Plotter");
    }

    private void OnGUI()
    {
        // 绘制按钮和输入
        if (GUILayout.Button("Reset"))
        {
            values.Clear();
        }

        if (!inputData) value = inputData.value;
        else value++;
        EditorGUILayout.LabelField("Horizontal Value: " + value);
        values.Add(value);  // 更新到 values 列表


        // 绘制图形
        DrawGraph();
    }

    private void OnInspectorUpdate()
    {
        Repaint();
    }

    private void DrawGraph()
    {
        // 绘制简单的图形
        for (int i = 0; i < values.Count - 1; i++)
        {
            Handles.DrawLine(
                new Vector3(i, values[i], 0),
                new Vector3(i + 1, values[i + 1], 0));
        }

        // 限制最大点数
        if (values.Count > MaxPoints)
        {
            values.RemoveAt(0);
        }
    }
}
