using UnityEngine;
using System.Collections;

// ��ӹ޾Ƽ� Awake �������� �ʱ�!
// �ҰŸ� InitSingleton(); ���� ����
public abstract class BehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T I
    {
        get
        {
            if (appIsClosing)
                return null;

            lock (s_syncobj)
            {
                if (s_instance == null)
                {
                    T[] objs = FindObjectsOfType<T>();

                    if (objs.Length > 0)
                        s_instance = objs[0];

                    if (objs.Length > 1)
                        Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");

                    if (s_instance == null)
                    {
                        string goName = typeof(T).ToString();
                        GameObject go = new GameObject(goName);
                        s_instance = go.AddComponent<T>();
                    }
                }
                return s_instance;
            }
        }
    }

    #region Static Members
    private static T s_instance = null;
    private static object s_syncobj = new object();
    private static bool appIsClosing = false;
    #endregion

    #region Monobehaviour Callback
    private void Awake()
    {
        Debug.Log("Singleton Awake : " + gameObject.name);
        InitSingleton();
    }
    #endregion

    #region Private Method
    protected void InitSingleton()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    protected virtual void OnApplicationQuit()
    {
        appIsClosing = true;
    }
    #endregion
}
