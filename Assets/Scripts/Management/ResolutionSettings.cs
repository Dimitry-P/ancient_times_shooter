using UnityEngine;

public class ResolutionSettings : Settings
{
    [SerializeField]
    private Vector2Int[] _availableResolutions = new Vector2Int[]
        {
        new Vector2Int(800, 600),
        new Vector2Int(1280, 720),
        new Vector2Int(1600, 900),
        new Vector2Int(1920, 1080)
        };

    private int _currentResolutionIndex = 0;

    public override bool _isMinValue { get => _currentResolutionIndex == 0; }
    public override bool _isMaxValue { get => _currentResolutionIndex == _availableResolutions.Length - 1; }
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public override void SetNextValue()
    {
        if (!_isMaxValue)
        {
            _currentResolutionIndex++;
        }
    }

    public override void SetPreviousValue()
    {
        if (!_isMinValue)
        {
            _currentResolutionIndex--;
        }
    }

    public override object GetValue()
    {
        return _availableResolutions[_currentResolutionIndex];
    }

    public override string GetStringValue()
    {
        return _availableResolutions[_currentResolutionIndex].x + " x " + _availableResolutions[_currentResolutionIndex].y;
    }

    public override void Apply()
    {
        Screen.SetResolution(_availableResolutions[_currentResolutionIndex].x, _availableResolutions[_currentResolutionIndex].y, true);
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt(_title, _currentResolutionIndex);
    }

    public override void Load()
    {
        _currentResolutionIndex = PlayerPrefs.GetInt(_title, _availableResolutions.Length - 1);
    }
}
