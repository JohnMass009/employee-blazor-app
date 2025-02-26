namespace EmployeeBlazorApp.Services.Greating
{
    public class GreetingService
    {
        private readonly IGreetingStrategy _greetingStrategy;

        public GreetingService(IGreetingStrategy greetingStrategy)
        {
            _greetingStrategy = greetingStrategy;
        }

        public string GetGreeting()
        {
            return _greetingStrategy.GetGreeting();
        }
    }

}
