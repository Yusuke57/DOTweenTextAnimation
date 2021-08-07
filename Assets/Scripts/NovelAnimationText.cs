using DG.Tweening;
using TMPro;
using UnityEngine;

public class NovelAnimationText : MonoBehaviour, IAnimationController
{
    private TextMeshProUGUI textMeshPro;
    private string text;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void Initialize()
    {
        text = textMeshPro.text;
        textMeshPro.text = "";
    }

    public void Play(float duration)
    {
        textMeshPro.DOText(text, duration).SetEase(Ease.Linear);
    }
}
