using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastMath.Core.Abstraction;
using FastMath.Core.Extension;
using FastMath.Core.Helper;
using FastMath.Core.Models;
using FastMath.Core.Models.OperandOption;
using ListShuffle;


namespace FastMath.MVVM.ViewModels
{
    abstract public partial class SimpleOperationBaseViewModel : ObservableObject
    {
        protected IGetOperation OperationService;
        public SimpleOperationBaseViewModel()
        {
            NbSuggestedElement = 4;

            OperandOption1 = new RandomOperandOption(Value: 10);
            OperandOption2 = new RandomOperandOption(Value: 10);
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
            var leftOperandOption = OperandOption1;
            var rightOperandOption = OperandOption2;
            var opservice = OperationService;
            
            EOperationMask opMask = OperationMaskHelper.CreateRandomMask();

            OperationalVisibility visibility = new()
            {
                Mode = OperationalVisibility.VisibilityMode.UseMask
            };

            
            var op = opservice.CreateOperation(leftOperandOption, rightOperandOption);
            List<SuggestedAnswer> resu = new()
            {
                new(){ Value = op.GetOffuscatedValue(opMask), IsGoodSolution = true},
            };

            SuggestedListHelper.GenerateList(NbSuggestedElement, resu, op.GetOffuscatedValueMax(opMask, leftOperandOption, rightOperandOption));
            resu.Shuffle();
            PossibledAnswers = resu;

            DisplayState = new OperationDisplayState(op, opMask, visibility, 
                                                        LeftOperandOption: leftOperandOption,
                                                        RightOperandOption: rightOperandOption);
        }
    }
    
}
