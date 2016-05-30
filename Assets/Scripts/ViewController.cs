using System;
using UnityEngine;
using UnityEngine.UI;

public interface IViewController
{
    void UpdateContent();
}

public abstract class ViewController : MonoBehaviour, IViewController
{
    public abstract void UpdateContent();
}