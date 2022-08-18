using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("people")]
public class Person
{
    [Key] [Column("people_identification")]
    public string Identification { get; set; }

    [Column("people_name")]
    public string Name { get; set; }

    [Column("people_age")]
    public int Age { get; set; }

    [Column("people_sex")]
    public string Sex { get; set; }

    [Column("people_pulsation")]
    public decimal Pulsation { get; set; }

    public void CalculatePulsation()
    {
        if (Sex.Equals("F") || Sex.Equals("f"))
        {
            Pulsation=(220 - Age) / 10;
        }
        else
        {
            Pulsation=(210 - Age) / 10;
        }
    }
}
