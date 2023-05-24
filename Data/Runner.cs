using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data;

[JsonSerializable(typeof(Runner))]
public class Runner : BaseRunner, INotifyPropertyChanged
{
    private int? startNumber;
    public int? StartNumber
    {
        get => startNumber;
        set
        {
            startNumber = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartNumber)));
        }
    }

    private int teamID;
    public int TeamID
    {
        get => teamID;
        set
        {
            teamID = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TeamID)));
        }
    }

    private Team team;

    [ForeignKey(nameof(TeamID))]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public virtual Team Team
    {
        get => team;
        set
        {
            team = value;
            teamID = team.ID;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Team)));
        }
    }

    private DateTime? startTime;
    public DateTime? StartTime
    {
        get => startTime;
        set
        {
            startTime = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartTime)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FinalRunTime)));
        }
    }

    private DateTime? finishTime;
    public DateTime? FinishTime
    {
        get => finishTime;
        set
        {
            finishTime = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FinishTime)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FinalRunTime)));
        }
    }

    public bool Disqualified => CheckpointInfo.Any(x => x.Disqualified);


    private int? partnerID;
    public int? PartnerID
    {
        get => partnerID;
        set
        {
            partnerID = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PartnerID)));
        }
    }

    private Partner? partner;

    [ForeignKey(nameof(PartnerID))]
    [DeleteBehavior(DeleteBehavior.SetNull)]
    [JsonIgnore]
    public virtual Partner? Partner
    {
        get => partner;
        set
        {
            partner = value;
            partnerID = partner?.ID;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Partner)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PartnerFirstName)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PartnerLastName)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PartnerBirthdate)));
        }
    }

    private ObservableCollection<CheckpointRunnerInfo> checkpointInfo = new();
    public virtual ObservableCollection<CheckpointRunnerInfo> CheckpointInfo
    {
        get => checkpointInfo;
        set
        {
            checkpointInfo = value;
            checkpointInfo.CollectionChanged += (_, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add
                    && e.NewItems != null)
                {
                    foreach (CheckpointRunnerInfo item in e.NewItems)
                    {
                        item.PropertyChanged += (_, e) =>
                        {
                            switch (e.PropertyName)
                            {
                                case nameof(item.TimeArrived) or nameof(item.TimeDeparted):
                                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AverageTimeBetweenCheckpoints)));
                                    break;

                                case nameof(item.TimeWaited):
                                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FinalRunTime)));
                                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalWaitTime)));
                                    break;

                                case nameof(item.Penalty):
                                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FinalRunTime)));
                                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalPenaltyTime)));
                                    break;

                                case nameof(item.Disqualified):
                                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Disqualified)));
                                    break;
                            }
                        };
                    }
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckpointInfo)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Disqualified)));
            };
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckpointInfo)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Disqualified)));
        }
    }

    private int? ageCategoryID;
    public int? AgeCategoryID
    {
        get => ageCategoryID;
        set
        {
            ageCategoryID = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AgeCategoryID)));
        }
    }

    private AgeCategory? ageCategory;

    [ForeignKey(nameof(AgeCategoryID))]
    [DeleteBehavior(DeleteBehavior.SetNull)]
    [JsonIgnore]
    public virtual AgeCategory? AgeCategory
    {
        get => ageCategory;
        set
        {
            ageCategory = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AgeCategory)));
        }
    }

    [NotMapped]
    [JsonIgnore]
    public string TeamBinding
    {
        get => team.Name;
        set
        {
            
        }
    }


    [NotMapped]
    [JsonIgnore]
    public string PartnerFirstName
    {
        get => partner != null ? partner.FirstName : "-";
        set
        {
            if (partner != null)
            {
                partner.FirstName = value;
            }
        }
    }


    [NotMapped]
    [JsonIgnore]
    public string PartnerLastName
    {
        get => partner != null ? partner.LastName : "-";
        set
        {
            if (partner != null)
            {
                partner.LastName = value;
            }
        }
    }


    [NotMapped]
    [JsonIgnore]
    public DateTime? PartnerBirthdate
    {
        get => partner?.Birthdate;
        set
        {
            if (partner != null)
            {
                partner.Birthdate = value;
            }
        }
    }


    [NotMapped]
    [JsonIgnore]
    public TimeSpan? FinalRunTime
    {
        get
        {
            if (!StartTime.HasValue || !FinishTime.HasValue)
                return null;
            else
            {
                var finalTime = FinishTime.Value.TimeOfDay - StartTime.Value.TimeOfDay;

                foreach (var c in CheckpointInfo)
                {
                    finalTime += c.Penalty;
                    finalTime -= c.TimeWaited;
                }

                return finalTime;
            }
        }
    }

    [NotMapped]
    [JsonIgnore]
    public TimeSpan TotalWaitTime
    {
        get
        {
            var totalWaitTime = new TimeSpan();

            foreach (var c in CheckpointInfo)
                totalWaitTime += c.TimeWaited;

            return totalWaitTime;
        }
    }

    [NotMapped]
    [JsonIgnore]
    public TimeSpan TotalPenaltyTime
    {
        get
        {
            var totalPenaltyTime = new TimeSpan();

            foreach (var c in CheckpointInfo)
                totalPenaltyTime += c.Penalty;

            return totalPenaltyTime;
        }
    }

    [NotMapped]
    [JsonIgnore]
    public TimeSpan? AverageTimeBetweenCheckpoints
    {
        get
        {
            if (CheckpointInfo.Count == 0) return null;

            var time = new TimeSpan();

            var checkpoints = CheckpointInfo.Where(x => x.ID != 1)
                                            .ToList();
            if (checkpoints.Any())
            {
                foreach (var c in checkpoints)
                {
                    if (c.TimeDeparted.HasValue && c.TimeArrived.HasValue)
                        time += c.TimeDeparted.Value.TimeOfDay - c.TimeArrived.Value.TimeOfDay;
                }

                if (time.TotalSeconds > 0)
                    time /= checkpoints.Count;
            }

            return time;
        }
    }


    public new event PropertyChangedEventHandler? PropertyChanged;

    public int? GetPlacement(LocalView<Runner> runners)
    {
        var runnersFiltered = runners.Where(x => x.FinalRunTime != null && !x.Disqualified)
                                     .OrderBy(x => x.FinalRunTime).ToList();
        var placement = runnersFiltered.FindIndex(x => x.ID == this.ID);

        return placement > -1 ? placement + 1 : null;
    }
}
