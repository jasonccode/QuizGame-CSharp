using QuizGame;

Console.WriteLine("Quiz Game...");

var questions = new List<Question>();
var answers = new List<Answer>();
var scores = new Dictionary<string, int>();

SeedQuestionsAndOptions();
StarGame();

void StarGame()
{
    Console.WriteLine("Are you ready? We are starting now!");
    Console.WriteLine("What is your name?");

    var player = Console.ReadLine();

    Console.WriteLine($"OK {player} let´s do this");

    foreach (var item in questions)
    {
        Console.WriteLine(item.QuestionText);
        Console.WriteLine("Please, enter 1, 2, 3 or 4");

        foreach (var option in item.Options)
        {
            Console.WriteLine($"{option.Id}.{option.Text}");
        }
        var answer = GetSelectedAnswer();
        AddAnswerToList(answer, item);
    }

    int score = GetScore();
    Console.WriteLine($"Nice try {player}! You answered well {score} questions...");
    UpdateScore(player, score);
    ShowScores();

    answers = new List<Answer>();
    Console.WriteLine("Do you want to play again?");
    Console.WriteLine("Enter yes to play again or any other key to stop...");

    var playAgain = Console.ReadLine();
    if (playAgain?.ToLower().Trim() == "yes")
        StarGame();
}

string GetSelectedAnswer()
{
    var answer = Console.ReadLine();

    if (answer != null && (answer == "1") || (answer == "2") || (answer == "3") || (answer == "4"))
        return answer;
    else
    {
        Console.WriteLine("That is not a valid option, please try again...");
        answer = GetSelectedAnswer();
    }
    return answer;
}

void AddAnswerToList(string answer, Question question)
{
    answers.Add(new Answer
    {
        QuestionId = question.Id,
        SelectedOption = GetSelectedOption(answer, question)
    });
}

Option GetSelectedOption(string answer, Question question)
{
    var selectedOption = new Option();
    foreach (var item in question.Options)
    {
        if (item.Id == int.Parse(answer))
            selectedOption = item;
    }
    return selectedOption;
}

void SeedQuestionsAndOptions()
{
    questions.Add(new Question
    {
        Id = 1,
        QuestionText = "what is the biggest country on earth?",
        Options = new List<Option>()
        {
            new Option{Id= 1, Text= "Australia"},
            new Option{Id= 2, Text= "China"},
            new Option{Id= 3, Text= "Canada"},
            new Option{Id= 4, Text= "Russia", IsValid = true}
        }
    });

    questions.Add(new Question
    {
        Id = 2,
        QuestionText = "What is the country with the greatest population?",
        Options = new List<Option>()
        {
            new Option{Id= 1, Text= "India"},
            new Option{Id= 2, Text= "China", IsValid = true},
            new Option{Id= 3, Text= "United States"},
            new Option{Id= 4, Text= "Indonesia", IsValid = true}
        }
    });

    questions.Add(new Question
    {
        Id = 3,
        QuestionText = "What is the capital of France?",
        Options = new List<Option>()
    {
        new Option{Id= 1, Text= "Paris", IsValid = true},
        new Option{Id= 2, Text= "London"},
        new Option{Id= 3, Text= "Berlin"},
        new Option{Id= 4, Text= "Madrid"}
    }
    });

    questions.Add(new Question
    {
        Id = 4,
        QuestionText = "Which planet is known as the Red Planet?",
        Options = new List<Option>()
    {
        new Option{Id= 1, Text= "Mars", IsValid = true},
        new Option{Id= 2, Text= "Venus"},
        new Option{Id= 3, Text= "Jupiter"},
        new Option{Id= 4, Text= "Saturn"}
    }
    });

    questions.Add(new Question
    {
        Id = 5,
        QuestionText = "What is the chemical symbol for the element Iron?",
        Options = new List<Option>()
    {
        new Option{Id= 1, Text= "Fe", IsValid = true},
        new Option{Id= 2, Text= "Ir"},
        new Option{Id= 3, Text= "In"},
        new Option{Id= 4, Text= "Au"}
    }
    });
}

int GetScore()
{
    int score = 0;
    foreach (var item in answers)
    {
        if (item.SelectedOption.IsValid)
            score++;
    }
    return score;
}

void UpdateScore(string player, int score)
{
    bool updated = false;
    foreach (var item in scores)
    {
        if (item.Key == player)
        {
            scores[item.Key] = score;
            updated = true;
        }
    }
    if (!updated)
        scores.Add(player, score);
}

void ShowScores()
{
    Console.WriteLine("Scores:");
    foreach (var item in scores)
    {
        Console.WriteLine($"{item.Key}, score: {item.Value}");
    }
}
