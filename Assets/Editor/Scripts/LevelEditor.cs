using UnityEditor;
using UnityEngine;

public sealed class LevelEditor : EditorWindow
{
    private SceneEditor _sceneEditor;
    private EditorData _data;
    private Transform _parent;

    private int _index;
    private bool _isCreatingBlocks = false;

    [MenuItem("Window/Level Editor")]
    public static void Init()
    {
        LevelEditor level = GetWindow<LevelEditor>("Level Editor");
        level.Show();
    }
    private void OnGUI()
    {
        if(_sceneEditor == null)
        {
            _sceneEditor = CreateInstance<SceneEditor>();
            _sceneEditor.Init(this, _parent);
        }
        EditorGUILayout.Space(5);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(50);
        EditorGUILayout.LabelField("Level Editor", EditorStyles.boldLabel);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(5);
        _parent = (Transform)EditorGUILayout.ObjectField(_parent, typeof(Transform), true);
        EditorGUILayout.Space(10);

        _data = (EditorData)EditorGUILayout.ObjectField(_data, typeof(EditorData), true);
        EditorGUILayout.Space(20);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("<", GUILayout.Width(50), GUILayout.Height(50)))
        {         
            _index--;
            if(_index <= 0)
            {
                _index = _data.BlockDatas.Count - 1;
            }
        }

        if(_data.BlockDatas[_index].BlockData is ColoredBlock)
        {
            ColoredBlock coloredBlock = _data.BlockDatas[_index].BlockData as ColoredBlock;
            GUI.color = coloredBlock.Color;
        }
        else
        {
            GUI.color = Color.white;
        }
        EditorGUILayout.Space(32);
        GUILayout.Label(_data.BlockDatas[_index].Texture2D, GUILayout.Width(110), GUILayout.Height(110));
        EditorGUILayout.Space(20);
        GUI.color = Color.white;

        if (GUILayout.Button(">", GUILayout.Width(50), GUILayout.Height(50)))
        {
            _index++;
            if (_index > _data.BlockDatas.Count - 1)
            {
                _index = 0;
            }
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.Space(5);

        GUI.color = _isCreatingBlocks ? Color.red : Color.white;
        if (GUILayout.Button("Creating block"))
        {
            _isCreatingBlocks = !_isCreatingBlocks;

            if(_isCreatingBlocks)
            {
                SceneView.duringSceneGui += _sceneEditor.OnSceneGUI;
            }
            else
            {
                SceneView.duringSceneGui += _sceneEditor.OnSceneGUI;
            }
        }
        GUI.color = Color.white;
    }
    public Block GetBlock()
    {
        return _data.BlockDatas[_index].BlockData.Prefab;
    }
    public BlockData GetBlockData()
    {
        return _data.BlockDatas[_index].BlockData;
    }
}
