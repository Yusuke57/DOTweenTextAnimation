using DG.Tweening;
using TMPro;
using UnityEngine;

public class PartCharAnimationText : MonoBehaviour, IAnimationController
{
    private DOTweenTMPAnimator tmpAnimator;
    private readonly int[] animationCharIdxList = new[] {3, 4};

    private void Awake()
    {
        var textMeshPro = GetComponent<TextMeshProUGUI>();
        tmpAnimator = new DOTweenTMPAnimator(textMeshPro);
    }

    public void Initialize()
    {
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            tmpAnimator.DOScaleChar(i, Vector3.one, 0);
            tmpAnimator.DOColorChar(i, Color.white, 0);
        }
    }

    public void Play(float duration)
    {
        foreach (var animationCharIdx in animationCharIdxList)
        {
            DOTween.Sequence()
                .Append(tmpAnimator.DOScaleChar(animationCharIdx, 1.6f, duration / 8).SetEase(Ease.OutBack))
                .Join(tmpAnimator.DOColorChar(animationCharIdx, new Color(1, 0.4f, 0.2f), duration * 3 / 4).SetEase(Ease.Flash, 10))
                .Append(tmpAnimator.DOScaleChar(animationCharIdx, 1, duration / 8));
        }
    }
}