Console.WriteLine("What is the true progammers name? ");
string name = Console.ReadLine();

TrueProgrammer programmer = new TrueProgrammer(name, 25, "hero");
Skeleton skeleton1 = new Skeleton("Skeleton1", 5, "monster");
TheUncodedOne uncodedone = new TheUncodedOne("The Uncoded One", 5, "monster");

List<ICharacter> characters = new List<ICharacter>();
characters.Add(programmer);
characters.Add(skeleton1);
characters.Add(uncodedone);

while (true)
{
    programmer.AiAction(characters);
    Thread.Sleep(1000);
    skeleton1.AiAction(characters);
    Thread.Sleep(1000);
}


public interface ICharacter
{

    enum Actions;
    public string Name { get; set; }
    public int MaxHP { get; set; }
    public int HP { get; set; }
    string Party { get; set; }


    public void PlayerAction(List<ICharacter> characters);
    public void AiAction(List<ICharacter> characters);

}

public class TrueProgrammer : ICharacter
{
    enum Actions
    {
        Nothing,
        Punch
    }
    public string Name { get; set; }
    public int MaxHP { get; set; }
    public int HP { get; set; }
    public string Party { get; set; }   


    public TrueProgrammer(string name, int MaxHp, string party)
    {
        Name = name;
        MaxHP = MaxHp;
        HP = MaxHP;
        Party = party;
    }
    public void PlayerAction(List<ICharacter> characters)
    {

    }

    public void AiAction(List<ICharacter> characters)
    {
        IEnumerable<ICharacter> enemy = from character in characters
                                        where character.Party != Party
                                        select character;

        Random random = new Random();
        int enemyChoice = random.Next(enemy.Count());
        ICharacter selectedEnemy = enemy.ElementAt(enemyChoice);

        int damage = 0;
        Console.WriteLine($"It is {Name}'s turn");
        Console.WriteLine($"HP: {HP}/{MaxHP}");
        int AiChoice = random.Next(1, 3);

        Actions action = AiChoice switch
        {
            1 => Actions.Nothing,
            2 => Actions.Punch,
        };

        if (action == Actions.Nothing)
        {
            Console.WriteLine($"{Name} did {action}");
            Console.WriteLine();
        }

        if (action == Actions.Punch)
        {
            damage = 1;
            selectedEnemy.HP -= damage;
            Console.WriteLine($"{Name} did {action} on {selectedEnemy.Name} for {damage} damage");
            Console.WriteLine($"{selectedEnemy.Name} is now at {selectedEnemy.HP}/{selectedEnemy.MaxHP} HP");
            Console.WriteLine();
            
            if (selectedEnemy.HP <= 0)
            {
                characters.Remove(selectedEnemy);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{selectedEnemy.Name} has been defeated");
                Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine();
            }
        }
    }
}

public class Skeleton : ICharacter
{
    enum Actions
    {
        Nothing,
        BoneCrunch
    }
    public string Name { get; set; }
    public int MaxHP { get; set; }
    public int HP { get; set; }
    public string Party { get; set; }

    public Skeleton(string name, int MaxHp, string party)
    {
        Name = name;
        MaxHP = MaxHp;
        HP = MaxHP;
        Party = party;
    }

    public void PlayerAction(List<ICharacter> characters)
    {

    }

    public void AiAction(List<ICharacter> characters)
    {
        IEnumerable<ICharacter> enemy = from character in characters
                                        where character.Party != Party
                                        select character;

        Random random = new Random();
        int enemyChoice = random.Next(enemy.Count());
        ICharacter selectedEnemy = enemy.ElementAt(enemyChoice);

        int damage = 0;
        Console.WriteLine($"It is {Name}'s turn");
        Console.WriteLine($"HP: {HP}/{MaxHP}");
        int AiChoice = random.Next(1, 3);

        Actions action = AiChoice switch
        {
            1 => Actions.Nothing,
            2 => Actions.BoneCrunch,
        };

        if (action == Actions.Nothing)
        {
            Console.WriteLine($"{Name} did {action}");
            Console.WriteLine();
        }

        if (action == Actions.BoneCrunch)
        {
            damage = 1;
            Console.WriteLine($"{Name} did {action} on {selectedEnemy.Name} for {damage} damage");
            Console.WriteLine($"{selectedEnemy.Name} is now at {selectedEnemy.HP}/{selectedEnemy.MaxHP} HP");
            Console.WriteLine();

            if (selectedEnemy.HP <= 0)
            {
                characters.Remove(selectedEnemy);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{selectedEnemy.Name} has been defeated");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }
    }
}

public class TheUncodedOne : ICharacter
{
    enum Actions
    {
        Nothing,
        UnravelingAttack
    }
    public string Name { get; set; }
    public int MaxHP { get; set; }
    public int HP { get; set; }
    public string Party { get; set; }

    public TheUncodedOne(string name, int MaxHp, string party)
    {
        Name = name;
        MaxHP = MaxHp;
        HP = MaxHP;
        Party = party;
    }

    public void PlayerAction(List<ICharacter> characters)
    {

    }

    public void AiAction(List<ICharacter> characters)
    {
        IEnumerable<ICharacter> enemy = from character in characters
                                        where character.Party != Party
                                        select character;

        Random random = new Random();
        int enemyChoice = random.Next(enemy.Count());
        ICharacter selectedEnemy = enemy.ElementAt(enemyChoice);

        int damage = 0;
        Console.WriteLine($"It is {Name}'s turn");
        Console.WriteLine($"HP: {HP}/{MaxHP}");
        int AiChoice = random.Next(1, 3);

        Actions action = AiChoice switch
        {
            1 => Actions.Nothing,
            2 => Actions.UnravelingAttack,
        };

        if (action == Actions.Nothing)
        {
            Console.WriteLine($"{Name} did {action}");
            Console.WriteLine();
        }

        if (action == Actions.UnravelingAttack)
        {
            damage = 1;
            Console.WriteLine($"{Name} did {action} on {selectedEnemy.Name} for {damage} damage");
            Console.WriteLine($"{selectedEnemy.Name} is now at {selectedEnemy.HP}/{selectedEnemy.MaxHP} HP");
            Console.WriteLine();

            if (selectedEnemy.HP <= 0)
            {
                characters.Remove(selectedEnemy);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{selectedEnemy.Name} has been defeated");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }
    }
}