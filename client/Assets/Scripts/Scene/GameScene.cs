using UnityEngine;
using UnityEngine.InputSystem;

public class GameScene : SceneBase
{
    [SerializeField]
    private RectTransform m_parentViewMap = null;

    private Map m_map = null;
    private Cursor m_cursor = null;
    protected override void Awake()
    {
        base.Awake();
        int[] answer = new int[]
        {
            0,0,0,1,1,1,1,0,0,0,
            0,0,1,1,0,0,1,1,0,0,
            0,1,1,0,0,0,0,1,1,0,
            0,1,0,0,0,0,0,0,1,0,
            0,1,1,0,0,0,0,1,1,0,
            0,0,1,1,0,0,1,1,0,0,
            1,1,1,1,0,0,1,1,1,1,
            0,0,0,0,0,0,0,0,0,0,
            1,1,1,1,1,1,1,1,1,1,
            0,0,0,0,0,0,0,0,0,0
        };
           

        m_map = Map.Create(m_parentViewMap, answer);
        m_cursor = m_map.Cursor;
        AddInputCallback(m_cursor);
    }

    private void OnEnable()
    {
        m_controls.Cursor.Enable();
    }

    private void OnDisable()
    {
        m_controls.Cursor.Disable();
    }
}
