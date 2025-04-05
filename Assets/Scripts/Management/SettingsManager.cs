using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface ISettingsManagerObserver
{
    void OnSettingsChanged();
}
public class SettingsManager
{
    private StandartSettings _settingsSTD;

    private ControlDTO _controlSettings;
    public ControlDTO ControlDTO { get { return _controlSettings; } set { _controlSettings = value; } }


    private VideoDTO _videoSettings;
    public VideoDTO VideoDTO { get { return _videoSettings; } set { _videoSettings = value; } }


    private AudioDTO _audioSettings;
    public AudioDTO AudioDTO { get { return _audioSettings; } set { _audioSettings = value; NotifyObservers(); } }


    public SettingsManager()
    {
        _settingsSTD = new StandartSettings();
        ControlDTO = new ControlDTO();
        VideoDTO = new VideoDTO();
        AudioDTO = new AudioDTO();
    }

    public async Task SetSettings()
    {
        string filePath = Application.persistentDataPath + "\\Saves\\Save.json";
        if (!File.Exists(filePath))
        {
            ControlDTO = _settingsSTD.controlSettingsOnStart;
            VideoDTO = _settingsSTD.videoSettingsOnStart;
            AudioDTO = _settingsSTD.audioSettingsOnStart;
        }
        else
        {
            string jsonFromSave = string.Empty;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];
                await fs.ReadAsync(buffer, 0, buffer.Length);
                jsonFromSave = Encoding.UTF8.GetString(buffer);
            }

            SaveDTO saveDTOFromLoad = JsonUtility.FromJson<SaveDTO>(jsonFromSave);

            ControlDTO = saveDTOFromLoad.settingsDTO.control;
            VideoDTO = saveDTOFromLoad.settingsDTO.video;
            AudioDTO = saveDTOFromLoad.settingsDTO.audio;
        }
    }





    private List<ISettingsManagerObserver> observers = new List<ISettingsManagerObserver>();

    public void RegisterObserver(ISettingsManagerObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(ISettingsManagerObserver observer)
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
