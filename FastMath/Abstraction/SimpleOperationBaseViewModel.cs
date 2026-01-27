using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastMath.Core.Abstraction;
using FastMath.Core.Extension;
using FastMath.Core.Models;
using FastMath.Core.Models.GenerateOperation;
using FastMath.Core.Models.OperandOption;


namespace FastMath.MVVM.ViewModels
{
    abstract public partial class SimpleOperationBaseViewModel : ObservableObject
    {
        readonly IGetOperation OperationService;
        readonly IGenerateOperation GenerateOperationService;
        
        public SimpleOperationBaseViewModel(IGetOperation operation,
                                            IGenerateOperation generateOperationService,
                                            OperandOptionBase LeftOperandOption,
                                            OperandOptionBase RightOperandOption)
        {
            OperationService = operation;
            GenerateOperationService = generateOperationService;

            NbSuggestedElement = 4;

            OperandOption1 = LeftOperandOption;
            OperandOption2 = RightOperandOption;

            GenerateNewOp();
        }

        public SimpleOperationBaseViewModel(IGetOperation operation, IGenerateOperation generateOperationService)
                : this(operation, generateOperationService,
                      new RandomOperandOption(10),
                      new RandomOperandOption(10))
        {

        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(OperationText))]
        private OperationDisplayState displayState = default!;

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

        [ObservableProperty]
        List<SuggestedAnswer> possibledAnswers = new();

        [ObservableProperty]
        OperandOptionBase operandOption1;

        [ObservableProperty]
        OperandOptionBase operandOption2;

        [ObservableProperty]
        int nbSuggestedElement;

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
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
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
            GenerateOperationParameters genParameter = new
            (
                OperandOption1,
                OperandOption2,
                OperationService
            );

            GenerateOperationResult genResult = GenerateOperationService.GenerateOperation(genParameter);

            PossibledAnswers = GenerateOperationService.GenerateSuggestedList(genResult, genParameter, NbSuggestedElement);
            
            DisplayState = new OperationDisplayState(
                genResult.Operation,
                genResult.Mask,
                new OperationalVisibility() { Mode = OperationalVisibility.VisibilityMode.UseMask });
        }
    }
}
