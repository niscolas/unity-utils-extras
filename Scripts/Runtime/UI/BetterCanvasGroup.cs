using DG.Tweening;
using niscolas.UnityExtensions;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    public class BetterCanvasGroup : CachedMonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private FloatReference _fadeDuration;

        [SerializeField]
        private Ease _fadeEase;

        [SerializeField]
        private BoolReference _useIndependentUpdate;

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onShown;

        [SerializeField]
        private UnityEvent _onHidden;

        public void Show()
        {
            _canvasGroup
                .DOFade(1, _fadeDuration.Value)
                .SetEase(_fadeEase)
                .SetAutoKill(false)
                .SetUpdate(_useIndependentUpdate.Value)
                .OnComplete(
                    () =>
                    {
                        _canvasGroup.SetInteractableAndBlocksRaycasts(true);
                        _onShown?.Invoke();
                    });
        }

        public void Hide()
        {
            _canvasGroup
                .DOFade(0, _fadeDuration.Value)
                .SetEase(_fadeEase)
                .SetAutoKill(false)
                .SetUpdate(_useIndependentUpdate.Value)
                .OnComplete(
                    () =>
                    {
                        _canvasGroup.SetInteractableAndBlocksRaycasts(false);
                        _onHidden?.Invoke();
                    });
        }
    }
}