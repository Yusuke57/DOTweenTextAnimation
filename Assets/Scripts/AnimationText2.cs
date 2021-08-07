using DG.Tweening;
using TMPro;
using UnityEngine;

public class AnimationText2 : MonoBehaviour, IAnimationController
{
    private DOTweenTMPAnimator tmpAnimator;

    private void Awake()
    {
        var textMeshPro = GetComponent<TextMeshProUGUI>();
        tmpAnimator = new DOTweenTMPAnimator(textMeshPro);
    }
    
    public void Initialize()
    {
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            tmpAnimator.DOScaleChar(i, 0, 0);
            tmpAnimator.DORotateChar(i, Vector3.forward * 90f, 0);
            tmpAnimator.DOColorChar(i, Color.white, 0);
        }
    }

    public void Play(float duration)
    {
        const float EACH_DELAY_RATIO = 0.01f;
        var eachDelay = duration * EACH_DELAY_RATIO;
        var eachDuration = duration - eachDelay;
        
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            DOTween.Sequence()
                .Append(tmpAnimator.DOScaleChar(i, 1, eachDuration / 8).SetEase(Ease.OutBack))
                .Join(tmpAnimator.DORotateChar(i, Vector3.zero, eachDuration / 8))
                .AppendInterval(eachDuration / 8)
                .Append(tmpAnimator.DOColorChar(i, new Color(0.5f, 0.5f, 1f), eachDuration / 8))
                .AppendInterval(eachDuration / 8)
                .Append(tmpAnimator.DOColorChar(i, new Color(0.7f, 1f, 1f), eachDuration / 8))
                .AppendInterval(eachDuration / 8)
                .Append(tmpAnimator.DOScaleChar(i, 0, eachDuration / 4).SetEase(Ease.InBack, 6))
                .SetDelay(eachDelay * i);
        }
    }
}