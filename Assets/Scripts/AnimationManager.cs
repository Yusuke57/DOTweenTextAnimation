using DG.Tweening;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private IAnimationController[] animationControllers;
    private bool isInitialized = false;

    private const float DURATION = 2.5f;
    
    private void Awake()
    {
        animationControllers = GetComponentsInChildren<IAnimationController>();
    }

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(isInitialized) Play();
            else Initialize();
        }
    }

    private void Initialize()
    {
        DOTween.KillAll(true);
        
        foreach (var animationController in animationControllers)
        {
            animationController.Initialize();
        }

        isInitialized = true;
    }

    private void Play()
    {
        foreach (var animationController in animationControllers)
        {
            animationController.Play(DURATION);
        }

        isInitialized = false;
    }
}