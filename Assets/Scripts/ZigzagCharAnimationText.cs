using DG.Tweening;
using TMPro;
using UnityEngine;

public class ZigzagCharAnimationText : MonoBehaviour, IAnimationController
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
            tmpAnimator.DOOffsetChar(i, Vector3.zero, 0);
            var color = i % 2 == 0 ? new Color(1, 0.8f, 0.3f) : new Color(0.3f, 0.7f, 1);
            tmpAnimator.DOColorChar(i, color, 0);
        }
    }

    public void Play(float duration)
    {
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            var sign = Mathf.Sign(i % 2 - 0.5f);
            DOTween.Sequence()
                .Append(tmpAnimator.DOOffsetChar(i, Vector3.up * 20 * sign, duration / 2).SetEase(Ease.OutFlash, 2))
                .Append(tmpAnimator.DOOffsetChar(i, Vector3.down * 20 * sign, duration / 2).SetEase(Ease.OutFlash, 2));
        }
    }
}