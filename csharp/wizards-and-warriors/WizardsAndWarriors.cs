abstract class Character
{
    private readonly string _characterType;
    protected bool vulnerable;

    protected Character(string characterType) => _characterType = characterType;
    public abstract int DamagePoints(Character target);
    public virtual bool Vulnerable() => vulnerable;
    public override string ToString() => $"Character is a {_characterType}";
}

class Warrior : Character
{
    public Warrior() : base(nameof(Warrior)) { }
    public override int DamagePoints(Character target) => !target.Vulnerable() ? 6 : 10;
}

class Wizard : Character
{
    public Wizard() : base(nameof(Wizard)) => vulnerable = true;
    public override int DamagePoints(Character target) => !vulnerable ? 12 : 3;
    public void PrepareSpell() => vulnerable = false;
}
