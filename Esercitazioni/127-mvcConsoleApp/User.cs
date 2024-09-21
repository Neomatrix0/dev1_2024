 class User
{
    public int Id { get;set; }
    public string Name { get;set; }
    public bool Active { get;set; }
    public string Mail { get;set; }

    public User(int id, string name, bool active, string mail)
    {
        Id = id;
        Name = name;
        Active = active;
        Mail = mail;
    }
}
