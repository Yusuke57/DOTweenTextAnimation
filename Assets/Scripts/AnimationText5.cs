using DG.Tweening;
using TMPro;
using UnityEngine;

public class AnimationText5 : MonoBehaviour, IAnimationController
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
            tmpAnimator.DOScaleChar(i, 1, 0);
        }
    }

    public void Play(float duration)
    {
        const float EACH_DELAY_RATIO = 0.01f;
        var eachDelay = duration * EACH_DELAY_RATIO;
        var eachDuration = duration - eachDelay;
        
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            var i2 = i;
            DOTween.Sequence()
                .Append(tmpAnimator.DOPunchCharScale(i2, 1.2f, eachDuration, 6))
                .SetDelay(eachDelay * i);
        }
    }
}