Console.WriteLine("Welcome to the Number Guessing Game!");
Console.WriteLine("I'm thinking of a number between 1 and 100.");

Console.WriteLine("Please select the difficulty level:\n" +
                  "1. Easy (10 chances)\n2. Medium (5 chances)\n3. Hard (3 chances)\n");
Console.WriteLine("Enter your choice");
int chances = 0;
int difficulty = Convert.ToInt32(Console.ReadLine());
switch (difficulty)
{
    case 1:
        Console.WriteLine("Great! You have selected the Easy difficulty level");
        chances = 10;
        break;
    case 2:
        Console.WriteLine("Great! You have selected the Medium difficulty level");
        chances = 5;
        break;
    case 3:
        Console.WriteLine("Great! You have selected the Hard difficulty level");
        chances = 3;
        break;
}

Console.WriteLine("Let's start the game!");

Random rd = new Random();

int num = rd.Next(1,101);

while (chances != 0)
{
    int attempts = 0;
    Console.WriteLine("Enter your guess:");
    int guess = Convert.ToInt32(Console.ReadLine());
    if (guess > num)
    {
        Console.WriteLine($"Incorrect! The number is less than {guess}.");
        attempts++;
        chances--;
    }else if (guess < num)
    {
        Console.WriteLine($"Incorrect! The number is greater than {guess}.");
        attempts++;
        chances--;
    }else if (guess == num)
    {
        attempts++;
        Console.WriteLine($"Congratulations! You guessed the correct number in {attempts} attempts.");
        break;
    }
    else
    {
        Console.WriteLine("Incorrect!");
        break;
    }
}