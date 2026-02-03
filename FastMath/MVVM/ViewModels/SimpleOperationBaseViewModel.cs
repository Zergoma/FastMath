using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastMath.Core.Enums;
using FastMath.Core.Extensions;
using FastMath.Core.Interfaces;
using FastMath.Core.Models;
using FastMath.Core.Models.OperationsWorld.Display;
using FastMath.Core.Models.OperationsWorld.GenerateOperation;
using FastMath.Core.Models.OperationsWorld.Operand.OperandMetaParameter;
using System.Diagnostics;


namespace FastMath.MVVM.ViewModels
{
    abstract public partial class SimpleOperationBaseViewModel : ObservableObject
    {
        readonly IGetOperation OperationService;
        readonly IGenerateOperation GenerateOperationService;
        private IGetUserSetting UsableSetting { get; init; }

        public SimpleOperationBaseViewModel(IGetOperation operationService,
                                            IGenerateOperation generateOperationService,
                                            IGetUserSetting usableSetting)
        {
            OperationService = operationService;
            GenerateOperationService = generateOperationService;
            UsableSetting = usableSetting;

            SimpleOperationBaseInitData userSettings = UsableSetting.GetUsableSettings();

            NbSuggestedElement = userSettings.NbSuggested;

            OperandOption1 = userSettings.Left;
            OperandOption2 = userSettings.Right;

            GenerateNewOp();
        }

        private OperationDisplayState? _displayState;
        private OperationDisplayState? DisplayState
        {
            get => _displayState;
            set
            {
                SetProperty(ref _displayState, value);
                OnPropertyChanged(nameof(OperationText));
            }
        }

        public string OperationText
        {
            get
            {
                if (DisplayState == null)
                    return string.Empty;

                var visibility = DisplayState.Visibility.Mode;

                return visibility switch
                {
                    OperationalVisibility.VisibilityMode.HideAll
                        => string.Empty,

                    OperationalVisibility.VisibilityMode.ShowAll
                        => DisplayState.Operation.ToString(EOperationMask.none),

                    _ => DisplayState.Operation.ToString(DisplayState.Mask)
                };
            }
        }


        private List<SuggestedAnswer> _possibleAnswers = [];
        public List<SuggestedAnswer> PossibleAnswers
        {
            get => _possibleAnswers;
            set
            {
                SetProperty(ref _possibleAnswers, value);
            }
        }


        private OperandOptionBase? _operandOption1 = null;
        public OperandOptionBase? OperandOption1 { get => _operandOption1; set { SetProperty(ref _operandOption1, value); } }

        private OperandOptionBase? _operandOption2 = null;
        public OperandOptionBase? OperandOption2 { get => _operandOption2; set { SetProperty(ref _operandOption2, value); } }

        int _nbSuggestedElement = 4;
        public int NbSuggestedElement { get => _nbSuggestedElement; set => SetProperty(ref _nbSuggestedElement, value); }


        private bool CanVerify() => !isBusy;
        private bool isBusy;

        [RelayCommand(CanExecute = nameof(CanVerify))]
        public async Task VerifyCalcul(SuggestedAnswer suggestedAnswer)
        {
            try
            {
                isBusy = true;
                VerifyCalculCommand.NotifyCanExecuteChanged();

                if (suggestedAnswer.IsGoodSolution is false)
                {
                    return;
                }

                var current = DisplayState;
                if (current is null)
                {
                    Debug.WriteLine("DisplayState is null");
                    return;
                }

                DisplayState = current with
                {
                    Visibility = new OperationalVisibility
                    {
                        Mode = OperationalVisibility.VisibilityMode.ShowAll
                    }
                };

                await Task.Delay(TimeSpan.FromSeconds(1));

                GenerateNewOp();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            finally
            {
                isBusy = false;
                VerifyCalculCommand.NotifyCanExecuteChanged();
            }
        }

        protected void GenerateNewOp()
        {
            ArgumentNullException.ThrowIfNull(OperandOption1, nameof(OperandOption1));
            ArgumentNullException.ThrowIfNull(OperandOption2, nameof(OperandOption2));

            GenerateOperationParameters genParameter = new
            (
                OperandOption1,
                OperandOption2,
                OperationService
            );

            GenerateOperationResult genResult = GenerateOperationService.GenerateOperation(genParameter);

            PossibleAnswers = GenerateOperationService.GenerateSuggestedList(genResult, genParameter, NbSuggestedElement);

            DisplayState = new OperationDisplayState(
                genResult.Operation,
                genResult.Mask,
                new OperationalVisibility() { Mode = OperationalVisibility.VisibilityMode.UseMask });
        }
    }
}
