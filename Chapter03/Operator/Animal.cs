class Animal
{
	public string? Name { get; set; }
	public DateTime Born { get; set; }
	public byte Legs { get; set; }
}

class Cat : Animal // This is a subtype of animal.
{
	public bool IsDomestic;
}

class Spider : Animal // This is another subtype of animal.
{
	public bool IsPoisonous;
}