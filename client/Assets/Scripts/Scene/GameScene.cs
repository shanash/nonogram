using UnityEngine;
using UnityEngine.InputSystem;

public class GameScene : SceneBase
{
    [SerializeField]
    private RectTransform m_parentViewMap = null;
    [SerializeField]
    private GameObject m_resultPopup = null;

    private int[] m_answer = null;
    private ModelMap m_map = null;
    private Cursor m_cursor = null;
    protected override void Awake()
    {
        base.Awake();

        m_map = ModelMap.Create(m_parentViewMap, m_answer);
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

    public override void OnAwakeWithParameter(object param)
    {
        if (param is int[])
        {
            m_answer = param as int[];
        }
    }

    public void CreateResultPopup()
    {
        m_resultPopup.SetActive(true);
    }
}
