using DG.Tweening;
using TMPro;
using UnityEngine;

public class AnimationText3 : MonoBehaviour, IAnimationController
{
    private DOTweenTMPAnimator tmpAnimator;

    private void Awake()
    {
        var textMeshPro = GetComponent<TextMeshProUGUI>();
        tmpAnimator = new DOTweenTMPAnimator(textMeshPro);
    }

    public void Initialize()
    {
        var charCount = tmpAnimator.textInfo.characterCount;
        for (var i = 0; i < charCount; i++)
        {
            tmpAnimator.DORotateChar(i, new Vector3(0, 90, 0), 0);
            tmpAnimator.DOOffsetChar(i, Vector3.zero, 0);
            tmpAnimator.DOFadeChar(i, 1, 0);

            var colorG = Mathf.Lerp(0.3f, 0.9f, (float) i / (charCount - 1));
            tmpAnimator.DOColorChar(i, new Color(1f, colorG, 0.2f), 0);
        }
    }

    public void Play(float duration)
    {
        const float EACH_DELAY_RATIO = 0.01f;
        var eachDelay = duration * EACH_DELAY_RATIO;
        var eachDuration = duration - eachDelay;
        
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            var randomOffset = new Vector3(Random.Range(-20f, 20f), Random.Range(-60f, 60f), 1);
            DOTween.Sequence()
                .Append(tmpAnimator.DORotateChar(i, Vector3.zero, eachDuration / 2))
                .Append(tmpAnimator.DOOffsetChar(i, randomOffset, eachDuration / 2))
                .Join(tmpAnimator.DOFadeChar(i, 0, eachDuration / 4).SetDelay(eachDuration / 4))
                .SetDelay(eachDelay * i);
        }
    }
}