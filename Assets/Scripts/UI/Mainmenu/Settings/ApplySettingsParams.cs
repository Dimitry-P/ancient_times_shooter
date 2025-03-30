using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// скрипт для кнопки Apply в Settings
/// </summary>
public class ApplySettingsParams : MonoBehaviour
{
    Button applaySettingsBttn;

    [SerializeField] private SettingsManager settingsManager;

    void Start()
    {
        applaySettingsBttn = GetComponent<Button>();
        applaySettingsBttn.onClick.AddListener(ApplyChangedSettings);
    }


    private async void ApplyChangedSettings()
    {
        applaySettingsBttn.gameObject.SetActive(false);


        //добавить логику записи параметров в класс для хранения Settings, но пока используется метод SaveGame()

        await SaveGame();
    }

    private async Task SaveGame()
    {
        SaveDTO saveDTO = new SaveDTO();
        saveDTO.playerDTO = new PlayerDTO();
        saveDTO.settingsDTO = new SettingsDTO();
        saveDTO.settingsDTO.video = settingsManager.VideoDTO;
        saveDTO.settingsDTO.control = settingsManager.ControlDTO;
        Debug.Log($"saveDto {saveDTO.playerDTO.PlayerName}");

        // Сериализация в файл
        string json = JsonUtility.ToJson(saveDTO); // true для форматирования
        Debug.Log(json);

        string filePath = Application.persistentDataPath + "\\Saves\\Save.json";
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            await fs.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
