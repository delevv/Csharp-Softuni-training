namespace MusicHub.Data.Models
{
    using MusicHub.Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SongPerformer
    {
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }

        public Song Song { get; set; }

        [ForeignKey(nameof(Performer))]
        public int PerformerId { get; set; }

        public Performer Performer { get; set; }
    }
}
