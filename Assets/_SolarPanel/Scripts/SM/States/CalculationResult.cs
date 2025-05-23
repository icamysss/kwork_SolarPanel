using _SolarPanel.Scripts.UI;

namespace _SolarPanel.Scripts.SM.States
{
    public class CalculationResult : AppState
    {
        private readonly UIManager uiManager;
        public CalculationResult(AppManager appManager) : base(appManager)
        {
            uiManager = UIManager.Instance;
        }

        public override void Enter()
        {
            base.Enter();
            
            ShowUI();
            uiManager.results.UpdateRequiredPowerText(DataManager.Instance.CalculateRequiredPower());
            uiManager.results.UpdateSelectedPanelText();
        }

        public override void Exit()
        {
            base.Exit();
            ShowUI(false);
        }

       
        private void ShowUI(bool show = true)
        {
            uiManager.results.Show(show);
            uiManager.navigation.Show(show);
            
            uiManager.navigation.ShowButton(ButtonType.next, show);
            uiManager.navigation.SetButtonText(ButtonType.next, Constants.VISUALIZE_BUTTON_TEXT);
            
            uiManager.navigation.ShowButton(ButtonType.previous, show);
            uiManager.navigation.SetButtonText(ButtonType.previous, Constants.BACK_BUTTON_TEXT);
            
            uiManager.navigation.SetHeader(Constants.CALCULATION_RESULT_HEADER);
        }
    }
}