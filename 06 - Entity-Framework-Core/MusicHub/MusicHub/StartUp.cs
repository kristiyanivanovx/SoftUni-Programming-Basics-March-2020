namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = new MusicHubDbContext();
            DbInitializer.ResetDatabase(context);

            //var result = ExportAlbumsInfo(context, 9);
            //Console.WriteLine(result);

            var result = ExportSongsAboveDuration(context, 240);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsByProducer = context.Producers
                .FirstOrDefault(p => p.Id == producerId)
                .Albums
                .Select(album => new 
                { 
                    AlbumName = album.Name,
                    ReleaseDate = album.ReleaseDate,
                    ProducerName = album.Producer.Name,
                    Songs = album.Songs.Select(song => new 
                    {
                        SongName = song.Name,
                        SongPrice = song.Price,
                        WriterName = song.Writer.Name,
                    })
                    .OrderByDescending(x => x.SongName)
                    .ThenBy(x => x.WriterName)
                    .ToList(),
                    TotalAlbumPrice = album.Price
                })
                .OrderByDescending(a => a.TotalAlbumPrice)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albumsByProducer)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate:MM/dd/yyyy}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int counter = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:F2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsAboveDuration = context.Songs
                .ToList()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    SongName = x.Name,
                    PerformerFullName = x.SongPerformers
                            .Select(x => x.Performer.FirstName + " " + x.Performer.LastName)
                            .FirstOrDefault(),
                    WriterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.PerformerFullName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            int counter = 1;
            foreach (var songInfo in songsAboveDuration)
            {
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {songInfo.SongName}");
                sb.AppendLine($"---Writer: {songInfo.WriterName}");
                sb.AppendLine($"---Performer: {songInfo.PerformerFullName}");
                sb.AppendLine($"---AlbumProducer: {songInfo.AlbumProducer}");
                sb.AppendLine($"---Duration: {songInfo.Duration:c}");
            }

            return sb.ToString().Trim();
        }
    }
}
