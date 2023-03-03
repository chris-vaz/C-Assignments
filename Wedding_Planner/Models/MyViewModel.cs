#pragma warning disable CS8618
namespace Wedding_Planner.Models;
public class MyViewModel
{
    public LoginUser LoginUser { get; set; }
    public User User { get; set; }
    public Wedding Wedding { get; set; }

    public Dictionary<int, bool> IsRSVP { get; set; }

    public List<User> AllUsers { get; set; }
    public List<Wedding> AllWeddings { get; set; }
    public List<Association> UserWeddings { get; set; }
    public List<Association> GuestList { get; set; }


}