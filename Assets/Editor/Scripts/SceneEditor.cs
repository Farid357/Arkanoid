using UnityEditor;
using UnityEngine;

public class SceneEditor : EditorWindow
{
    private LevelEditor _editor;
    private Transform _parent;

    public void Init(LevelEditor editor, Transform parent)
    {
        _editor = editor;
        _parent = parent;
    }

    public void OnSceneGUI(SceneView sceneView)
    {
        Event current = Event.current;

        if (current.type == EventType.MouseDown)
        {
            Vector2 mousePoint = current.mousePosition;
            mousePoint.y = Screen.height - mousePoint.y - 36f;
            mousePoint = sceneView.camera.ScreenToWorldPoint(mousePoint);
            CreateBlock(mousePoint);
        }

        if (current.type == EventType.Layout)
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
        }
    }

    private void CreateBlock(Vector2 position)
    {
        Block block = Instantiate(_editor.GetBlock(), _parent);
        block.transform.position = position;
        SetData(block);
    }

    private void SetData(Block block)
    {
        var data = _editor.GetBlockData();

        if (data is ColoredBlock)
        {
            block.SetData(_editor.GetBlockData() as ColoredBlock);
        }
    }
}