using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IViewOrigin
{
    public void OnUpdate(ViewBase viewBase);
}

public abstract class ViewBase : MonoBehaviour
{
    private IViewOrigin m_originInstance = null;

    protected virtual void Init(IViewOrigin origin)
    {
        m_originInstance = origin;
    }

    protected virtual void Update()
    {
        if (m_originInstance != null)
        {
            m_originInstance.OnUpdate(this);
        }
    }

}
