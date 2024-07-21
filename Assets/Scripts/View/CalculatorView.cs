using Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        [SerializeField] private GameObject _errorDialog;
        [SerializeField] private TextMeshProUGUI _historyItem;
        [SerializeField] private Button _calculateButton;
        [SerializeField] private RectTransform _container;
        [SerializeField] private RectTransform _body;
        [SerializeField] private TMP_InputField _inputField;

        private CalculatorPresenter _calculatorPresenter;

        public void Initialize(CalculatorPresenter calculatorPresenter)
        {
            _calculatorPresenter = calculatorPresenter;
        }

        private void Awake()
        {
            _calculateButton.onClick.AddListener(HandleClicked);
        }

        private void OnDestroy()
        {
            _calculateButton.onClick.RemoveAllListeners();
        }

        private void HandleClicked()
        {
            if (!string.IsNullOrEmpty(_inputField.text))
            {
                _calculatorPresenter.OnCalculateClicked(_inputField.text);
            }
        }

        public void AddHistoryItem(string history)
        {
            var historyItem = Instantiate(_historyItem, _container);
            historyItem.text = history;
            historyItem.transform.SetAsFirstSibling();

            var contentHeight = _body.rect.height + historyItem.rectTransform.rect.height;
            var newHeight = Mathf.Min(contentHeight, 1000);
            _body.sizeDelta = new Vector2(_body.sizeDelta.x, newHeight);
        }

        private void OnApplicationQuit()
        {
            _calculatorPresenter.OnApplicationQuit(_inputField.text);
        }

        public void SetInput(string stateInput)
        {
            _inputField.text = stateInput;
        }

        public void ShowErrorDialog()
        {
            _errorDialog.SetActive(true);
        }
    }
}