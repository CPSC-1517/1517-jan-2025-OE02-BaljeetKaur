namespace BlazorApp3.Components.Pages.Sample
{
    public partial class BasicButtonEvents
    {

        private string feedback;
        private Random rnd = new();

        protected override void OnInitialized()
        {
            feedback = "On Initialize";
            base.OnInitialized();
        }

        void OnFirstButtonClick()
        {
            int oddeven = rnd.Next(1, 100);

            if (oddeven % 2 == 0)
            {
                feedback = $"the value {oddeven} is EVEN";
            }
            else
            {
                feedback = $"the value {oddeven} is ODD";
            }
        }
    }
}