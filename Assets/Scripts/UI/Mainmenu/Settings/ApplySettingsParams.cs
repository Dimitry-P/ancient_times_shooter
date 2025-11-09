using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// скрипт для кнопки Apply в Settings. Будет отвечать за сохранение как настроек так и файла сохранения
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


        //добавить логику записи параметров в класс для хранения Settings, но пока используется метод SaveGame()

        await SaveGame();
    }

    private async Task SaveGame()
    {
        SaveDTO saveDTO = new SaveDTO();
        saveDTO.playerDTO = new PlayerDTO();
        saveDTO.settingsDTO = new SettingsDTO();
        saveDTO.settingsDTO.video = GameSettigsController.instance.settingsManager.VideoDTO;
        saveDTO.settingsDTO.control = GameSettigsController.instance.settingsManager.ControlDTO;
        saveDTO.settingsDTO.audio = GameSettigsController.instance.settingsManager.AudioDTO;

        for (int i = 0; i < QualitySettings.names.Length; i++)
        {
            if (QualitySettings.names[i] == GameSettigsController.instance.settingsManager.VideoDTO.quality)
            {
                QualitySettings.SetQualityLevel(i);
            }
        }
        Screen.SetResolution(GameSettigsController.instance.settingsManager.VideoDTO.widthScreen, GameSettigsController.instance.settingsManager.VideoDTO.heightScreen, true);

        Debug.Log($"saveDto {saveDTO.playerDTO.PlayerName}");

        // Сериализация в файл
        string json = JsonUtility.ToJson(saveDTO); // true для форматирования
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
