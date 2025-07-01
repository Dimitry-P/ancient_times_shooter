using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ������ ��� ������ Apply � Settings
/// </summary>
public class ApplySettingsParams : MonoBehaviour
{
    Button applaySettingsBttn;

    void Start()
    {
        applaySettingsBttn = GetComponent<Button>();
        applaySettingsBttn.onClick.AddListener(ApplyChangedSettings);
    }


    private async void ApplyChangedSettings()
    {
        applaySettingsBttn.gameObject.SetActive(false);


        //�������� ������ ������ ���������� � ����� ��� �������� Settings, �� ���� ������������ ����� SaveGame()

        await SaveGame();
    }

    private async Task SaveGame()
    {
        SaveDTO saveDTO = new SaveDTO();
        saveDTO.playerDTO = new PlayerDTO();
        saveDTO.settingsDTO = new SettingsDTO();
        saveDTO.settingsDTO.video = GameController.instance.settingsManager.VideoDTO;
        saveDTO.settingsDTO.control = GameController.instance.settingsManager.ControlDTO;
        saveDTO.settingsDTO.audio = GameController.instance.settingsManager.AudioDTO;
        Debug.Log($"saveDto {saveDTO.playerDTO.PlayerName}");

        // ������������ � ����
        string json = JsonUtility.ToJson(saveDTO); // true ��� ��������������
        Debug.Log(json);

        string directoryPath = Application.persistentDataPath + "\\Saves";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        string filePath = directoryPath + "\\Save.json";

        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            await fs.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
