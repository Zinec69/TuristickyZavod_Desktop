using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data;

[JsonSerializable(typeof(AgeCategory))]
public class AgeCategory : INotifyPropertyChanged
{
    private int id;
    public int ID
    {
        get => id;
        set
        {
            id = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
        }
    }

    private string name;
    public string Name
    {
        get => name;
        set
        {
            name = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
        }
    }

    private string code;
    public string Code
    {
        get => code;
        set
        {
            code = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Code)));
        }
    }

    private int ageMin;
    public int AgeMin
    {
        get => ageMin;
        set
        {
            ageMin = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AgeMin)));
        }
    }

    private int? ageMax;
    public int? AgeMax
    {
        get => ageMax;
        set
        {
            ageMax = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AgeMax)));
        }
    }

    private AgeCategoryType type = AgeCategoryType.DEFAULT;
    public AgeCategoryType Type
    {
        get => type;
        set
        {
            type = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
        }
    }

    private string color;
    public string Color
    {
        get => color;
        set
        {
            color = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
        }
    }

    private Gender gender;
    public Gender Gender
    {
        get => gender;
        set
        {
            gender = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gender)));
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    public static bool TryGetByBirthdate(DateTime birthdate, ICollection<AgeCategory> allCategories, Gender gender, out AgeCategory? category,
            AgeCategoryType type = AgeCategoryType.DEFAULT, DateTime? partnerBirthdate = null)
    {
        category = new();

        var today = DateTime.Today;

        var age = today.Year - birthdate.Year;

        if (birthdate.Date > today.AddYears(-age))
            age--;

        if (type == AgeCategoryType.DUOS && partnerBirthdate.HasValue)
        {
            var partnerAge = today.Year - partnerBirthdate.Value.Year;
            if (partnerBirthdate.Value.Date > today.AddYears(-partnerAge))
                partnerAge--;
            age += partnerAge;
        }

        category = allCategories.FirstOrDefault(x =>
            age >= x.AgeMin
            && (!x.AgeMax.HasValue || age <= x.AgeMax.Value)
            && (type == AgeCategoryType.DUOS || x.Gender == gender)
            && x.Type == type, null);

        return category != null;
    }

    public override string ToString() => Name ?? "-";

    [NotMapped]
    [JsonIgnore]
    public string TypeString => Type switch
    {
        AgeCategoryType.DEFAULT => "Klasický",
        AgeCategoryType.DUOS => "Dvojice",
        AgeCategoryType.RELAY => "Štafety",
        _ => "-"
    };

    [NotMapped]
    [JsonIgnore]
    public string GenderString => Gender switch
    {
        Gender.MALE => "Muži",
        Gender.FEMALE => "Ženy",
        Gender.IRRELEVANT => "Nezáleží",
        _ => "-"
    };
}
