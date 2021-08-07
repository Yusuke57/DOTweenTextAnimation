using DG.Tweening;
using TMPro;
using UnityEngine;

public class RandomCharAnimationText1 : MonoBehaviour, IAnimationController
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
            tmpAnimator.DOFadeChar(i, 1, 0);
            tmpAnimator.DOScaleChar(i, 1, 0);
        }
    }

    public void Play(float duration)
    {
        const float MAX_DELAY_RATIO = 0.7f;
        var maxDelay = duration * MAX_DELAY_RATIO;
        var animDuration = duration - maxDelay;
        
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            var randomDelay = Random.Range(0f, maxDelay);
            DOTween.Sequence()
                .Append(tmpAnimator.DOFadeChar(i, 0, animDuration))
                .Join(tmpAnimator.DOScaleChar(i, 1.6f, animDuration))
                .SetDelay(randomDelay);
        }
    }
}