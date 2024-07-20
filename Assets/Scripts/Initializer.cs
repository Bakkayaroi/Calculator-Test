using Model;
using Presenter;
using UnityEngine;
using View;

public class Initializer : MonoBehaviour
{
    [SerializeField] private CalculatorView _calculatorView;

    private void Awake()
    {
        var model = new CalculatorModel();
        var presenter = new CalculatorPresenter(_calculatorView, model);
        _calculatorView.Initialize(presenter);
    }
}