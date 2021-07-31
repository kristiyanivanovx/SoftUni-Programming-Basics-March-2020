namespace SOLID.Models.Interfaces
{
    public interface IPathManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        string GetCurrentPath();

        /// <summary>
        /// nyankopasu
        /// </summary>
        void EnsureDirectoryAndFileExists();
    }
}
