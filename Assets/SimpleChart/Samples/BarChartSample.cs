using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace SimpleChart.Samples
{
    public class BarChartSample : MonoBehaviour
    {
        [SerializeField] Bar _VerticalBar;
        [SerializeField] Bar _HorizontalBar;
        [SerializeField] Slider _Slider_CurrentValue;
        [SerializeField] Slider _Slider_MaxValue;

        void Awake()
        {
            _VerticalBar.LabelText.Value = "Current Value";
            _HorizontalBar.LabelText.Value = "Current Value";

            _Slider_CurrentValue.OnValueChangedAsObservable()
            .Subscribe(value => 
            {
                _VerticalBar.CurrentValue.Value = value;
                _VerticalBar.ValueLabelText.Value = value.ToString();
                _HorizontalBar.CurrentValue.Value = value;
                _HorizontalBar.ValueLabelText.Value = value.ToString();
            })
            .AddTo(this);

            _Slider_MaxValue.OnValueChangedAsObservable()
            .Subscribe(value => 
            {
                _VerticalBar.MaxValue.Value = value;
                _HorizontalBar.MaxValue.Value = value;
            })
            .AddTo(this);
        }
    }
}
