using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastMath.Core.Abstraction;
using FastMath.Core.Models;
using FastMath.Core.Extension;
using ListShuffle;
using FastMath.Core.Helper;


namespace FastMath.MVVM.ViewModels
{
    public partial class SimpleAdditionViewModel : ObservableObject
    {
        private readonly IGetAddition ServiceAddition;
        public SimpleAdditionViewModel(IGetAddition serviceAddition)
        {
            NbSuggestedElement = 4;
            ServiceAddition = serviceAddition;

            OperandOption1 = new ComputeOperandOption(randOrFixed: OperandDof.randomized, maxOrValue: 10, zeroAuthorized: true);
            OperandOption2 = new ComputeOperandOption(randOrFixed: OperandDof.randomized, maxOrValue: 10, zeroAuthorized: true);

            GenerateNewOp(ServiceAddition.GetAddition(OperandOption1, OperandOption2));
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
                        => DisplayState.Operation.ToString(
                               new() { Masked = OperationMasked.none }),

                    _ => DisplayState.Operation.ToString(DisplayState.Mask)
                };
            }
        }

        [ObservableProperty]
        List<SuggestedAnswer> possibledAnswers = new();

        [ObservableProperty]
        ComputeOperandOption operandOption1;

        [ObservableProperty]
        ComputeOperandOption operandOption2;

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

                GenerateNewOp(ServiceAddition.GetAddition(OperandOption1, OperandOption2));
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

        private void GenerateNewOp(OperationalBase op)
        {
            OperationMask opMask = new();

            OperationalVisibility visibility = new()
            {
                Mode = OperationalVisibility.VisibilityMode.UseMask
            };

            List<SuggestedAnswer> resu = new()
            {
                new(){ Value = op.GetOffuscatedValue(opMask), IsGoodSolution = true},
            };

            SuggestedListHelper.GenerateList(NbSuggestedElement, resu, op.GetOffuscatedValueMax(opMask, OperandOption1, OperandOption2));
            resu.Shuffle();
            PossibledAnswers = resu;

            DisplayState = new OperationDisplayState(op, opMask, visibility);
        }
    }
}
