using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace SimpleChart
{
    public class Bar : MonoBehaviour
    {
        [SerializeField] Slider _BarSlider;
        [SerializeField] Image _FillImage;
        [SerializeField] Text _Label;
        [SerializeField] Text _ValueLabel;

        public ReactiveProperty<float> MaxValue = new ReactiveProperty<float>();
        public ReactiveProperty<float> CurrentValue = new ReactiveProperty<float>();
        public ReactiveProperty<Color> Color = new ReactiveProperty<Color>();
        public ReactiveProperty<string> LabelText = new ReactiveProperty<string>();
        public ReactiveProperty<string> ValueLabelText = new ReactiveProperty<string>();

        void Awake()
        {
            MaxValue.Value = _BarSlider.maxValue;
            CurrentValue.Value = _BarSlider.value;
            Color.Value = _FillImage.color;

            MaxValue.Subscribe(value => 
            {
                // Debug.Log("Max value: " + value);
                _BarSlider.maxValue = value;
            })
            .AddTo(this);

            CurrentValue.Subscribe(value => 
            {
                // Debug.Log("Current value: " + value);
                _BarSlider.value = value;
            })
            .AddTo(this);

            Color.Subscribe(value => 
            {
                _FillImage.color = value;
            })
            .AddTo(this);

            LabelText.Subscribe(text => 
            {
                _Label.text = text;
            })
            .AddTo(this);

            ValueLabelText.Subscribe(text => 
            {
                _ValueLabel.text = text;
            })
            .AddTo(this);
        }
    }
}
