using System.Text.Json;
using System.Text.Json.Serialization;
using turisticky_zavod.Data;

namespace turisticky_zavod.Logic
{
    internal class RefereeJsonConverter : JsonConverter<Referee>
    {
        public override Referee Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var name = reader.GetString();
            var referee = Database.Instance.Referee.ToList().FirstOrDefault(x => x.Name == name, null);
            referee ??= Database.Instance.ChangeTracker.Entries<Referee>()
                                                       .FirstOrDefault(x => x.Entity.Name == name, null)?.Entity
                                                        ?? new() { Name = name };

            return referee;
        }

        public override void Write(Utf8JsonWriter writer, Referee value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.Name);
    }

    internal class CheckpointInfoJsonConverter : JsonConverter<CheckpointRunnerInfo>
    {
        public override CheckpointRunnerInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var info = new CheckpointRunnerInfo();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.StartObject)
                    continue;
                if (reader.TokenType == JsonTokenType.PropertyName)
                    break;
            }
            reader.Read();
            var id = reader.GetInt32();
            reader.Read();
            reader.Read();
            var refereeName = reader.GetString();
            reader.Read();
            reader.Read();
            var timeArrived = reader.GetInt64();
            reader.Read();
            reader.Read();
            var timeDeparted = reader.GetInt64();
            reader.Read();
            reader.Read();
            var timeWaited = reader.GetInt32();
            reader.Read();
            reader.Read();
            var penalty = reader.GetInt32();
            reader.Read();
            reader.Read();
            var disqualified = reader.GetBoolean();
            reader.Read();

            var checkpoint = Database.Instance.Checkpoint.Single(x => x.ID == id);

            var referee = Database.Instance.Referee.ToList().FirstOrDefault(x => x.Name == refereeName, null);
            referee ??= Database.Instance.ChangeTracker.Entries<Referee>()
                                                       .FirstOrDefault(x => x.Entity.Name == refereeName, null)?.Entity
                                                        ?? new() { Name = refereeName };

            checkpoint.Referee = referee;

            return new CheckpointRunnerInfo
            {
                CheckpointID = id,
                Checkpoint = checkpoint,
                TimeArrived = DateTimeOffset.FromUnixTimeMilliseconds(timeArrived).DateTime.ToLocalTime(),
                TimeDeparted = DateTimeOffset.FromUnixTimeMilliseconds(timeDeparted).DateTime.ToLocalTime(),
                TimeWaited = new TimeSpan(0, 0, timeWaited),
                Penalty = new TimeSpan(0, 0, penalty),
                Disqualified = disqualified
            };
        }

        public override void Write(Utf8JsonWriter writer, CheckpointRunnerInfo value, JsonSerializerOptions options) { }
    }

    internal class TeamJsonConverter : JsonConverter<Team>
    {
        public override Team Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var name = reader.GetString();
            var team = Database.Instance.Team.ToList().FirstOrDefault(x => x.Name == name, null);
            team ??= Database.Instance.ChangeTracker.Entries<Team>()
                                                    .FirstOrDefault(x => x.Entity.Name == name, null)?.Entity
                                                     ?? new() { Name = name };

            return team;
        }

        public override void Write(Utf8JsonWriter writer, Team value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.Name);
    }

    internal class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64()).DateTime.ToLocalTime();

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteNumberValue(new DateTimeOffset(value).ToUnixTimeMilliseconds());
    }

    internal class TimeSpanJsonConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => new(0, 0, reader.GetInt32());

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
            => writer.WriteNumberValue(value.TotalSeconds);
    }

    internal class RunnerJsonConverter : JsonConverter<Runner>
    {
        public override Runner Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => new();

        public override void Write(Utf8JsonWriter writer, Runner value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteNumber(nameof(value.ID), value.ID);

            if (value.StartNumber.HasValue)
                writer.WriteNumber(nameof(value.StartNumber), value.StartNumber.Value);
            else
                writer.WriteNull(nameof(value.StartNumber));

            writer.WriteString(nameof(value.Name), value.Name);

            if (value.Birthdate.HasValue)
                writer.WriteString(nameof(value.Birthdate), value.Birthdate.Value);
            else
                writer.WriteNull(nameof(value.Birthdate));

            if (value.StartTime.HasValue)
                writer.WriteString(nameof(value.StartTime), value.StartTime.Value);
            else
                writer.WriteNull(nameof(value.StartTime));

            if (value.FinishTime.HasValue)
                writer.WriteString(nameof(value.FinishTime), value.FinishTime.Value);
            else
                writer.WriteNull(nameof(value.FinishTime));

            writer.WriteNumber(nameof(value.TeamID), value.TeamID);

            if (value.PartnerID.HasValue)
                writer.WriteNumber(nameof(value.PartnerID), value.PartnerID.Value);
            else
                writer.WriteNull(nameof(value.PartnerID));

            writer.WriteBoolean(nameof(value.Disqualified), value.Disqualified);

            if (value.AgeCategoryID.HasValue)
                writer.WriteNumber(nameof(value.AgeCategoryID), value.AgeCategoryID.Value);
            else
                writer.WriteNull(nameof(value.AgeCategoryID));

            writer.WriteStartArray(nameof(value.CheckpointInfo));

            foreach (var item in value.CheckpointInfo)
            {
                writer.WriteStartObject();

                writer.WriteNumber(nameof(item.ID), item.ID);
                writer.WriteNumber(nameof(item.CheckpointID), item.CheckpointID);

                if (item.TimeArrived.HasValue)
                    writer.WriteString(nameof(item.TimeArrived), item.TimeArrived.Value);
                else
                    writer.WriteNull(nameof(item.TimeArrived));

                if (item.TimeDeparted.HasValue)
                    writer.WriteString(nameof(item.TimeDeparted), item.TimeDeparted.Value);
                else
                    writer.WriteNull(nameof(item.TimeDeparted));

                writer.WriteString(nameof(item.TimeWaited), item.TimeWaited.ToString());
                writer.WriteString(nameof(item.Penalty), item.Penalty.ToString());
                writer.WriteBoolean(nameof(item.Disqualified), item.Disqualified);

                writer.WriteEndObject();
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }
    }
}
