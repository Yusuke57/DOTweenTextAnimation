using DG.Tweening;
using TMPro;
using UnityEngine;

public class AnimationText6 : MonoBehaviour, IAnimationController
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
            tmpAnimator.DORotateChar(i, Vector3.right * 90, 0);
            tmpAnimator.DOOffsetChar(i, Vector3.zero, 0);
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
                .Append(tmpAnimator.DORotateChar(i, Vector3.right * 360, eachDuration / 2, RotateMode.FastBeyond360))
                .AppendInterval(eachDuration / 4)
                .Append(tmpAnimator.DOOffsetChar(i, Vector3.down * 40f, eachDuration / 4))
                .Join(tmpAnimator.DOFadeChar(i, 0, eachDuration / 4))
                .SetDelay(eachDelay * i);
        }
    }
}