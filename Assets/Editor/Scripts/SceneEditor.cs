using UnityEditor;
using UnityEngine;

public class SceneEditor : EditorWindow
{
    private readonly EditorGrid _editorGrid = new();
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
            Vector2 mousePoint = new(current.mousePosition.x, GetPositionY(current, sceneView));
            Vector2 position = sceneView.camera.ScreenToWorldPoint(mousePoint);

            if (_editorGrid.CheckPosition(position))
            {
                CreateBlock(position);
            }
        }
        if (current.type == EventType.Layout)
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
        }
    }
    public float GetPositionY(Event current, SceneView sceneView)
    {
        return sceneView.camera.pixelHeight - current.mousePosition.y;
    }
    private void CreateBlock(Vector2 position)
    {
        Block block = (Block)PrefabUtility.InstantiatePrefab(_editor.GetBlock(), _parent);
        block.transform.position = new Vector2(position.x + 3, position.y - 1);
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
