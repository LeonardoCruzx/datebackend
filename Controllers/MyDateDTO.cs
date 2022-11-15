using Date.Models;

namespace Date.Controllers;

public class MyDateDTO
{
    public string Woman { get; set; }
    public string Date { get; set; }
    public bool Sucess { get; set; }

    public MyDate ToMyDate() => new MyDate{ Woman = this.Woman, Date = this.Date, Sucess = this.Sucess };
}
