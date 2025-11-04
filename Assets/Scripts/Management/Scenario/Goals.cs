using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Goals : SingletonBase<Goals>
{
    [SerializeField] TMP_Text _tropicGoal;
    [SerializeField] TMP_Text _sandsGoal;

    public UnityEvent OnChangeTropicGoal;
    public UnityEvent OnChangeSandsGoal;

    string tmp;
    void Start()
    {
        _tropicGoal.text = $"-Scene1-destroy 3 enemies: Destroyed: {Scenario.instance.InemiesKilled}/{3}";
        _sandsGoal.text = $"-Scene2-walk {Scenario.instance.TargetDistance} meters: passed {Scenario.instance.DistanceTraveled}ì";

        OnChangeTropicGoal.AddListener(TropicGoalChange);
        OnChangeSandsGoal.AddListener(SandsGoalChange);
    }

    private void OnDestroy()
    {
        OnChangeTropicGoal.RemoveAllListeners();
    }

    private void TropicGoalChange()
    {
        _tropicGoal.text = $"-Scene1-destroy 3 enemies: Destroyed: {Scenario.instance.InemiesKilled}/{3}";
    }
    private void SandsGoalChange()
    {
        tmp = Scenario.instance.DistanceTraveled.ToString("F1");
        _sandsGoal.text = $"-Scene2-walk {Scenario.instance.TargetDistance} meters: passed {tmp}ì";
    }
}
