using DG.Tweening;
using TMPro;
using UnityEngine;

public class RandomCharAnimationText2 : MonoBehaviour, IAnimationController
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
            tmpAnimator.DOColorChar(i, Color.white, 0);
        }
    }

    public void Play(float duration)
    {
        const float MAX_DELAY_RATIO = 0.9f;
        var maxDelay = duration * MAX_DELAY_RATIO;
        var animDuration = duration - maxDelay;
        
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            var randomDelay = Random.Range(0f, maxDelay);
            var randomColor = Color.HSVToRGB(Random.value, 1, 1);
            randomColor = new Color(
                Mathf.Min(randomColor.r + 0.3f, 1f), 
                Mathf.Min(randomColor.g + 0.3f, 1f),
                Mathf.Min(randomColor.b + 0.3f, 1f));
            DOTween.Sequence()
                .Append(tmpAnimator.DOColorChar(i, randomColor, animDuration))
                .SetDelay(randomDelay);
        }
    }
}