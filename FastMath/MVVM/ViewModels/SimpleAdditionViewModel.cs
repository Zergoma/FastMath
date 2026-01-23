using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastMath.Core.Abstraction;
using FastMath.Core.Extension;
using FastMath.Core.Helper;
using FastMath.Core.Models;
using FastMath.Core.Models.OperandOption;
using FastMath.Services;
using ListShuffle;


namespace FastMath.MVVM.ViewModels
{
    public partial class SimpleAdditionViewModel : ObservableObject
    {
        private readonly IGetOperation ServiceAddition;
        public SimpleAdditionViewModel(AdditionService serviceAddition)
        {
            NbSuggestedElement = 4;
            ServiceAddition = serviceAddition;

            OperandOption1 = new RandomOperandOption(Value: 10);
            OperandOption2 = new RandomOperandOption(Value: 10);

            GenerateNewOp(ServiceAddition.CreateOperation(OperandOption1, OperandOption2));
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

                GenerateNewOp(ServiceAddition.CreateOperation(OperandOption1, OperandOption2));
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
            EOperationMask opMask = OperationMaskHelper.CreateRandomMask();

            OperationalVisibility visibility = new()
            {
                Mode = OperationalVisibility.VisibilityMode.UseMask
            };

            List<SuggestedAnswer> resu = new()
            {
                new(){ Value = op.GetOffuscatedValue(opMask), IsGoodSolution = true},
            };

            var LeftOperandOption = OperandOption1;
            var RightOperandOption = OperandOption2;
            SuggestedListHelper.GenerateList(NbSuggestedElement, resu, op.GetOffuscatedValueMax(opMask, LeftOperandOption, RightOperandOption));
            resu.Shuffle();
            PossibledAnswers = resu;

            DisplayState = new OperationDisplayState(op, opMask, visibility, 
                                                        LeftOperandOption: LeftOperandOption,
                                                        RightOperandOption: RightOperandOption);
        }
    }
}
