namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumInfo = context.Producers
                .Include(x => x.Albums).ThenInclude(a => a.Songs).ThenInclude(s => s.Writer)
                .First(x => x.Id == producerId)
                .Albums.Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate,
                    ProducerName = x.Producer.Name,
                    AlbumSongs = x.Songs.Select(x => new
                    {
                        SongName = x.Name,
                        SongPrice = x.Price,
                        SongWriterName = x.Writer.Name
                    }).OrderByDescending(x => x.SongName).ThenBy(x => x.SongWriterName),
                    TotalAlbumPrice = x.Price
                }).OrderByDescending(x => x.TotalAlbumPrice).AsEnumerable();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albumInfo)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int counter = 1;
                foreach (var song in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {song.SongWriterName}");
                 }

                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var span = new TimeSpan(0, 0, duration);

            var songsAboveDuration = context
                .Songs
                .Where(s => s.Duration > span)
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerFullName = s.SongPerformers
                        .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                        .OrderBy(name => name)
                        .ToList(),
                    WriterName = s.Writer.Name,
                    AlbumProducerName = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            int counter = 1;

            foreach (var s in songsAboveDuration)
            {
                sb
                    .AppendLine($"-Song #{counter++}")
                    .AppendLine($"---SongName: {s.SongName}")
                    .AppendLine($"---Writer: {s.WriterName}");

                if (s.PerformerFullName.Any())
                {
                    sb.AppendLine(string
                        .Join(Environment.NewLine, s.PerformerFullName
                            .Select(p => $"---Performer: {p}")));
                }

                sb
                    .AppendLine($"---AlbumProducer: {s.AlbumProducerName}")
                    .AppendLine($"---Duration: {s.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
