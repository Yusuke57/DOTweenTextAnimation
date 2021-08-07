using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class AnimationText1 : MonoBehaviour, IAnimationController
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
            tmpAnimator.DOScaleChar(i, new Vector3(1, 0, 1), 0);
            tmpAnimator.DOColorChar(i, new Color(1f, 0.8f, 0.3f), 0);
            tmpAnimator.DOFadeChar(i, 1, 0);
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
                .Append(tmpAnimator.DOScaleChar(i, new Vector3(1, 2f, 1), eachDuration / 8))
                .Join(tmpAnimator.DOOffsetChar(i, new Vector3(0, 70f, 0), eachDuration / 8))
                .Append(tmpAnimator.DOScaleChar(i, new Vector3(1, 1f, 1), eachDuration / 8).SetEase(Ease.InQuad))
                .Join(tmpAnimator.DOOffsetChar(i, new Vector3(0, 0f, 0), eachDuration / 8).SetEase(Ease.InQuad))
                .AppendInterval(eachDuration / 4)
                .Append(tmpAnimator.DOColorChar(i, Color.white, eachDuration / 8).SetLoops(2, LoopType.Yoyo))
                .AppendInterval(eachDuration / 8)
                .Append(tmpAnimator.DOFadeChar(i, 0, eachDuration / 8))
                .SetDelay(eachDelay * i);
        }
    }
}
