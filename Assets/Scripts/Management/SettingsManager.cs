using System.Collections.Generic;
using UnityEngine;

public interface ISettingsObserver
{
    void OnSettingsChanged();
}
public class SettingsManager : MonoBehaviour
{
    private ControlDTO _controlSettings;
    public ControlDTO ControlDTO { get { return _controlSettings; } set { _controlSettings = value; NotifyObservers(); } }


    private VideoDTO _videoSettings;
    public VideoDTO VideoDTO { get { return _videoSettings; } set { _videoSettings = value; NotifyObservers(); } }


    private List<ISettingsObserver> observers = new List<ISettingsObserver>();

    public void RegisterObserver(ISettingsObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(ISettingsObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnSettingsChanged();
        }
    }
}
