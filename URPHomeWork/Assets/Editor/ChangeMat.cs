using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
public class ChangeMat : EditorWindow
{
    static Color originColor;
    Color color;
    Material material;
    [MenuItem("Window/Change Material")]
    [CanEditMultipleObjects]
    public static void ShowWindow()
    {
        GetWindow<ChangeMat>();
    }
    private void OnEnable()
    {
        
    }
    private void OnGUI()
    {
        GUILayout.Label("Change selected item color");
        EditorGUI.BeginChangeCheck();
        color = EditorGUILayout.ColorField(color);
        if(material != null)
        {
            material.color = color;
        }
        if(EditorGUI.EndChangeCheck())
        {
            Repaint();
        }

        EditorGUI.BeginChangeCheck();
        material=EditorGUILayout.ObjectField(material,typeof(Material),true) as Material;
        if(EditorGUI.EndChangeCheck())
        {
            color = material.color;
            Repaint();
        }
        GUILayout.FlexibleSpace();

        if(GUILayout.Button("Change Color"))
        {
            ApplyChange();
        }

    }
    private void OnDisable()
    {
        SetDefaultColor();
    }

    void ApplyChange()
    {
        if(material==null)
        {
            string[] matGID = AssetDatabase.FindAssets("Default t:Material", new[] { "Assets/Materials" });
            if(matGID.Length>0)
            {
                //�������Default������Ļ����ͽ����������Ӧ�õ�material�����
                material=AssetDatabase.LoadAssetAtPath<Material>(AssetDatabase.GUIDToAssetPath(matGID[0]));
            }
            else
            {
                //���Default�����򲻴��ڣ����ֶ�����һ��
                material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
                AssetDatabase.CreateAsset(material, "Assets/Materials/Default.mat");
            }
            AssetDatabase.Refresh();

        }

        foreach(GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            renderer.sharedMaterial = material;
            renderer.sharedMaterial.color = color;
        }
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());

    }
    void SetDefaultColor()
    {
        ChangeMat.originColor = color;
    }
}
