﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    [JsonSerializable(typeof(Checkpoint))]
    public class Checkpoint
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Disqualifiable { get; set; } = false;

        public int? RefereeID { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(RefereeID))]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual Referee? Referee { get; set; }

        public override string ToString() => Name;
    }
}
