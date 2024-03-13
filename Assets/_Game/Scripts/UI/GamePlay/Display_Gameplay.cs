using UnityEngine;
using DG.Tweening;
using TMPro;

public class Display_Gameplay : MonoBehaviour, IWaveObserver
{
    public const float Time_Delay = 2f;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] TextMeshProUGUI completeLevelText;
    WaveSpaner waveSpaner;

    public void OnInit()
    {
        waveSpaner = LevelManager.Instance.CurrentLevel.WaveSpaner;
        RegisterOnWaveEndEvent();
        waveText.gameObject.SetActive(false);
        completeLevelText.gameObject.SetActive(false);
        levelText.SetText(LevelManager.Instance.CurrentLevel.levelName);
        
        Invoke(nameof(FallAndFadeOutTextDelay), 0.5f);
    }

    private void FallAndFadeOutTextDelay()
    {
        FallAndFadeOutText(Time_Delay);
    }

    private void FallAndFadeOutText(float duration)
    {
        // Thiết lập vị trí ban đầu ngoại trừ chiều cao của màn hình để nó rơi từ trên xuống
        Vector3 originalPosition = levelText.rectTransform.position;
        levelText.rectTransform.position = new Vector3(originalPosition.x, Screen.height, originalPosition.z);

        // Tính toán vị trí giữa màn hình
        Vector3 targetPosition = new Vector3(originalPosition.x, Screen.height / 2, originalPosition.z);

        // Sử dụng DOMove để tạo hiệu ứng rơi từ trên xuống giữa màn hình
        levelText.rectTransform.DOMove(targetPosition, duration)
            .SetEase(Ease.OutQuad) // Tuỳ chỉnh Ease để làm mềm hiệu ứng
            .OnComplete(() =>
            {
                // Sau khi rơi xong, sử dụng DOFade để thực hiện tweening alpha của màu chữ
                levelText.DOFade(0f, duration)
                    .OnComplete(() =>
                    {
                        // Sau khi hoàn thành, tắt TextMeshProUGUI
                        levelText.gameObject.SetActive(false);

                        //Show waveText
                        waveText.gameObject.SetActive(true);
                        FadeInWaveText(waveText ,Time_Delay);
                    });
            });
    }

    private void FadeInWaveText(TextMeshProUGUI textMeshProUGUI ,float duration)
    {
        // Thiết lập alpha ban đầu của waveText là 0
        textMeshProUGUI.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, 0f);

        // Sử dụng DOFade để thực hiện hiệu ứng mờ dần alpha của màu chữ
        textMeshProUGUI.DOFade(1f, duration)
            .SetEase(Ease.InQuad) // Tuỳ chỉnh Ease để làm mềm hiệu ứng
            .OnComplete(() =>
            {
                // Tùy chỉnh các hành động khác sau khi hoàn thành nếu cần
            });
    }

    public void OnWaveStart()
    {
        waveText.SetText("Wave " + LevelManager.Instance.CurrentLevel.CurrentWave() + "/"
                     + LevelManager.Instance.CurrentLevel.TotalNumberOfWavesEnemy().ToString());
    }

    private void RegisterOnWaveEndEvent()
    {
        waveSpaner.OnWaveStartObserverAdd(this);
    }

    public void OnWaveEnd()
    {
        completeLevelText.gameObject.SetActive(true);
        waveText.gameObject.SetActive(false);
        FadeInWaveText(completeLevelText, Time_Delay);
    }



    
}