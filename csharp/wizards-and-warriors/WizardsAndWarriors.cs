abstract class Character
{
    private string _characterType;

    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {_characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool _prepared;
    
    public Wizard() : base("Wizard")
    {
        _prepared = false;
    }

    public override bool Vulnerable()
    {
        return !_prepared;
    }

    public override int DamagePoints(Character target)
    {
        return _prepared ? 12 : 3;
    }

    public void PrepareSpell()
    {
        _prepared = true;
    }
}
