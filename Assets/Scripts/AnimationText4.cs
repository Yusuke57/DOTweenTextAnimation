using DG.Tweening;
using TMPro;
using UnityEngine;

public class AnimationText4 : MonoBehaviour, IAnimationController
{
    private DOTweenTMPAnimator tmpAnimator;

    [SerializeField] private Color[] colors;

    private void Awake()
    {
        var textMeshPro = GetComponent<TextMeshProUGUI>();
        tmpAnimator = new DOTweenTMPAnimator(textMeshPro);
    }

    public void Initialize()
    {
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            tmpAnimator.DOColorChar(i, colors[i], 0);
            tmpAnimator.DOOffsetChar(i, Vector3.zero, 0);
        }
    }

    public void Play(float duration)
    {
        const float EACH_DELAY_RATIO = 0.01f;
        var eachDelay = duration * EACH_DELAY_RATIO;
        var eachDuration = duration - eachDelay;
        var charCount = tmpAnimator.textInfo.characterCount;
        
        for (var i = 0; i < charCount; i++)
        {
            DOTween.Sequence()
                .Append(tmpAnimator.DOOffsetChar(i, Vector3.up * 30, eachDuration / 4).SetEase(Ease.OutFlash, 2))
                .SetDelay(eachDelay * i)
                .SetLoops(-1);

            var i2 = i;
            DOVirtual.Float(0f, charCount, duration, value =>
            {
                var colorIdx = (i2 + (int) value) % charCount;
                tmpAnimator.DOColorChar(i2, colors[colorIdx], 0);
            }).SetEase(Ease.Linear).SetLoops(-1);
        }
    }
}