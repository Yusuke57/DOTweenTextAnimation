using DG.Tweening;
using TMPro;
using UnityEngine;

public class CharSpaceAnimationText : MonoBehaviour, IAnimationController
{
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void Initialize()
    {
        textMeshPro.DOFade(0, 0);
        textMeshPro.characterSpacing = -50;
    }

    public void Play(float duration)
    {
        DOTween.To(() => textMeshPro.characterSpacing, value => textMeshPro.characterSpacing = value, 10, duration)
            .SetEase(Ease.OutQuart);

        DOTween.Sequence()
            .Append(textMeshPro.DOFade(1, duration / 4))
            .AppendInterval(duration / 2)
            .Append(textMeshPro.DOFade(0, duration / 4));
    }
}