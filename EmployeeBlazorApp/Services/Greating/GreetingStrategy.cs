namespace EmployeeBlazorApp.Services.Greating
{
    public class MorningGreetingStrategy : IGreetingStrategy
    {
        public string GetGreeting() => "Доброе утро!";
    }

    public class DayGreetingStrategy : IGreetingStrategy
    {
        public string GetGreeting() => "Добрый день!";
    }

    public class EveningGreetingStrategy : IGreetingStrategy
    {
        public string GetGreeting() => "Добрый вечер!";
    }

    public class NightGreetingStrategy : IGreetingStrategy
    {
        public string GetGreeting() => "Доброй ночи!";
    }

}
