
class User{
    private string _name = "";
    private int _id;

    private bool _active;

    public string Name{ get{ return _name; } set{ _name = value; }}
    public int Id{ get{ return _id; } set{ _id = value; }}

     public bool Active{ get{ return _active; } set{ _active = value; }}

    public User(int id, string name,bool active){
        Id = id;
        Name = name;
        Active = active;
    }

}