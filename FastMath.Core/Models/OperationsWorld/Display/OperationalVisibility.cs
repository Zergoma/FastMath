namespace FastMath.Core.Models.OperationsWorld.Display
{
    public class OperationalVisibility
    {
        public enum VisibilityMode { UseMask, HideAll, ShowAll}
        public VisibilityMode Mode { get; init; } = VisibilityMode.UseMask;

    }
}
