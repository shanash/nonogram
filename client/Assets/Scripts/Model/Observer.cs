using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    // 상태 Update 메서드
    public abstract void OnNotify(ISubject s);
}

public interface ISubject
{
    void AddObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void Notify();
}