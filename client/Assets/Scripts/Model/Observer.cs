using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    // ���� Update �޼���
    public abstract void OnNotify(ISubject s);
}

public interface ISubject
{
    void AddObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void Notify();
}