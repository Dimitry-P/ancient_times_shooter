using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] protected string _title;
    public string Title => _title;
    public virtual bool _isMinValue { get; }
    public virtual bool _isMaxValue { get; }
    public virtual void SetNextValue()
    {

    }

    public virtual void SetPreviousValue()
    {

    }

    public virtual object GetValue()
    {
        return default(object);
    }

    public virtual string GetStringValue()
    {
        return string.Empty;
    }

    public virtual void Apply()
    {

    }

    public virtual void Load()
    {

    }
}
